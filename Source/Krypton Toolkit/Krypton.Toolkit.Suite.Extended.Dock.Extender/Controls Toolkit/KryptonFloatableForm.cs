using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dock.Extender
{
    internal partial class KryptonFloatableForm : KryptonForm, IFloatable
    {
        #region API Stuff

        private const int WM_NCLBUTTONDBLCLK = 0x00A3;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int msg, int wParam, int lParam);

        #endregion

        #region Instance Fields

        private bool _startFloating;

        private bool _isFloating;

        private bool _dockOnHostOnly;

        private bool _dockOnInside;

        private DockState _dockState;

        private KryptonDockExtender _dockExtender;

        #endregion

        #region Identity

        public KryptonFloatableForm(KryptonDockExtender dockExtender)
        {
            InitializeComponent();

            _dockExtender = dockExtender;

            _dockOnInside = true;

            _dockOnHostOnly = true;
        }

        #endregion

        #region Public

        internal DockState DockState => _dockState;

        public bool DockOnHostOnly { get => _dockOnHostOnly; set => _dockOnHostOnly = value; }
        public bool DockOnInside { get => _dockOnInside; set => _dockOnInside = value; }

        #endregion

        #region Overrides

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                DockFloating();
            }

            base.WndProc(ref m);
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            if (_dockExtender._overlay.Visible && _dockExtender._overlay.DockHostControl != null) //ok found new docking position
            {
                _dockState.OrgDockingParent = _dockExtender._overlay.DockHostControl;
                _dockState.OrgBounds = _dockState.Container.RectangleToClient(_dockExtender._overlay.Bounds);
                _dockState.OrgDockStyle = _dockExtender._overlay.Dock;
                _dockExtender._overlay.Hide();
                DockFloating(); // dock the container
            }

            _dockExtender._overlay.DockHostControl = null;
            _dockExtender._overlay.Hide();

            base.OnResizeEnd(e);
        }

        protected override void OnMove(EventArgs e)
        {
            if (IsDisposed) return;

            Point pt = Cursor.Position;
            Point pc = PointToClient(pt);
            if (pc.Y < -21 || pc.Y > 0) return;
            if (pc.X < -1 || pc.X > Width) return;

            Control t = _dockExtender.FindDockHost(this, pt);
            if (t == null)
            {
                _dockExtender._overlay.Hide();
            }
            else
            {
                SetOverlay(t, pt);
            }

            base.OnMove(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;

            Hide();

            base.OnClosing(e);
        }

        #endregion

        #region Public Methods

        public new void Show()
        {
            if (!Visible && _isFloating)
            {
                base.Show(_dockState.OrgDockHost);
            }

            _dockState.Container.Show();
        }

        public new void Show(IWin32Window owner) => Show();

        public new void Hide()
        {
            if (Visible)
            {
                base.Hide();
            }

            _dockState.Container.Hide();
        }

        #endregion

        #region Implementation

        /// <summary>
        /// determines the client area of the control. The area of docked controls are excluded
        /// </summary>
        /// <param name="c">the control to which to determine the client area</param>
        /// <returns>returns the docking area in screen coordinates</returns>
        private Rectangle GetDockingArea(Control c)
        {
            Rectangle r = c.Bounds;

            if (c.Parent != null)
                r = c.Parent.RectangleToScreen(r);

            Rectangle rc = c.ClientRectangle;

            int borderwidth = (r.Width - rc.Width) / 2;
            r.X += borderwidth;
            r.Y += (r.Height - rc.Height) - borderwidth;

            if (!_dockOnInside)
            {
                rc.X += r.X;
                rc.Y += r.Y;
                return rc;
            }

            foreach (Control cs in c.Controls)
            {
                if (!cs.Visible) continue;
                switch (cs.Dock)
                {
                    case DockStyle.Left:
                        rc.X += cs.Width;
                        rc.Width -= cs.Width;
                        break;
                    case DockStyle.Right:
                        rc.Width -= cs.Width;
                        break;
                    case DockStyle.Top:
                        rc.Y += cs.Height;
                        rc.Height -= cs.Height;
                        break;
                    case DockStyle.Bottom:
                        rc.Height -= cs.Height;
                        break;
                    default:
                        break;
                }
            }
            rc.X += r.X;
            rc.Y += r.Y;

            //Console.WriteLine("Client = " + c.Name + " " + rc.ToString());

            return rc;
        }

        /// <summary>
        /// This method will check if the overlay needs to be displayed or not
        /// for display it will position the overlay
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p">position of cursor in screen coordinates</param>
        private void SetOverlay(Control c, Point pc)
        {

            Rectangle r = GetDockingArea(c);
            Rectangle rc = r;

            //determine relative coordinates
            float rx = (pc.X - r.Left) / (float)(r.Width);
            float ry = (pc.Y - r.Top) / (float)(r.Height);

            //Console.WriteLine("Moving over " + c.Name + " " +  rx.ToString() + "," + ry.ToString());

            _dockExtender._overlay.Dock = DockStyle.None; // keep floating

            // this section determines when the overlay is to be displayed.
            // it depends on the position of the mouse cursor on the client area.
            // the overlay is currently only shown if the mouse is moving over either the Northern, Western, 
            // Southern or Eastern parts of the client area.
            // when the mouse is in the center or in the NE, NW, SE or SW, no overlay preview is displayed, hence
            // allowing the user to dock the container.

            // dock to left, checks the Western area
            if (rx > 0 && rx < ry && rx < 0.25 && ry < 0.75 && ry > 0.25)
            {
                r.Width = r.Width / 2;
                if (r.Width > Width)
                    r.Width = Width;

                _dockExtender._overlay.Dock = DockStyle.Left; // dock to left
            }

            // dock to the right, checks the Easter area
            if (rx < 1 && rx > ry && rx > 0.75 && ry < 0.75 && ry > 0.25)
            {
                r.Width = r.Width / 2;
                if (r.Width > Width)
                    r.Width = Width;
                r.X = rc.X + rc.Width - r.Width;
                _dockExtender._overlay.Dock = DockStyle.Right;
            }

            // dock to top, checks the Northern area
            if (ry > 0 && ry < rx && ry < 0.25 && rx < 0.75 && rx > 0.25)
            {
                r.Height = r.Height / 2;
                if (r.Height > Height)
                    r.Height = Height;
                _dockExtender._overlay.Dock = DockStyle.Top;
            }

            // dock to the bottom, checks the Southern area
            if (ry < 1 && ry > rx && ry > 0.75 && rx < 0.75 && rx > 0.25)
            {
                r.Height = r.Height / 2;
                if (r.Height > Height)
                    r.Height = Height;
                r.Y = rc.Y + rc.Height - r.Height;
                _dockExtender._overlay.Dock = DockStyle.Bottom;
            }
            if (_dockExtender._overlay.Dock != DockStyle.None)
                _dockExtender._overlay.Bounds = r;
            else
                _dockExtender._overlay.Hide();

            if (!_dockExtender._overlay.Visible && _dockExtender._overlay.Dock != DockStyle.None)
            {
                _dockExtender._overlay.DockHostControl = c;
                _dockExtender._overlay.Show(_dockState.OrgDockHost);
                BringToFront();
            }
        }

        internal void Attach(DockState dockState)
        {
            // track the handle's mouse movements
            _dockState = dockState;
            Text = _dockState.Handle.Text;
            _dockState.Handle.MouseMove += new MouseEventHandler(Handle_MouseMove);
            _dockState.Handle.MouseHover += new EventHandler(Handle_MouseHover);
            _dockState.Handle.MouseLeave += new EventHandler(Handle_MouseLeave);
        }

        /// <summary>
        /// makes the docked control floatable in this Floaty form
        /// </summary>
        /// <param name="dockState"></param>
        /// <param name="offsetx"></param>
        /// <param name="offsety"></param>
        private void MakeFloatable(DockState dockState, int offsetx, int offsety)
        {
            Point ps = Cursor.Position;
            _dockState = dockState;
            Text = _dockState.Handle.Text;

            Size sz = _dockState.Container.Size;
            if (_dockState.Container.Equals(_dockState.Handle))
            {
                sz.Width += 18;
                sz.Height += 28;
            }
            if (sz.Width > 600) sz.Width = 600;
            if (sz.Height > 600) sz.Height = 600;



            _dockState.OrgDockingParent = _dockState.Container.Parent;
            _dockState.OrgBounds = _dockState.Container.Bounds;
            _dockState.OrgDockStyle = _dockState.Container.Dock;
            //_dockState.OrgDockingParent.Controls.Remove(_dockState.Container);
            //Controls.Add(_dockState.Container);
            _dockState.Handle.Hide();
            _dockState.Container.Parent = this;
            _dockState.Container.Dock = DockStyle.Fill;
            //_dockState.Handle.Visible = false; // hide it for now
            if (_dockState.Splitter != null)
            {
                _dockState.Splitter.Visible = false; // hide splitter
                _dockState.Splitter.Parent = this;
            }
            // allow redraw of floaty and container
            //Application.DoEvents();  

            // this is kind of tricky
            // disable the mousemove events of the handle
            SendMessage(_dockState.Handle.Handle.ToInt32(), WM_LBUTTONUP, 0, 0);
            ps.X -= offsetx;
            ps.Y -= offsety;


            Bounds = new Rectangle(ps, sz);
            _isFloating = true;
            Show();
            // enable the mousemove events of the new floating form, start dragging the form immediately
            SendMessage(Handle.ToInt32(), WM_SYSCOMMAND, SC_MOVE | 0x02, 0);
        }

        /// <summary>
        /// this will dock the floaty control
        /// </summary>
        private void DockFloating()
        {
            // bring dockhost to front first to prevent flickering
            _dockState.OrgDockHost.TopLevelControl.BringToFront();
            Hide();
            _dockState.Container.Visible = false; // hide it temporarely
            _dockState.Container.Parent = _dockState.OrgDockingParent;
            _dockState.Container.Dock = _dockState.OrgDockStyle;
            _dockState.Container.Bounds = _dockState.OrgBounds;
            _dockState.Handle.Visible = true; // show handle again
            _dockState.Container.Visible = true; // it's good, show it

            if (_dockOnInside)
                _dockState.Container.BringToFront(); // set to front

            //show splitter
            if (_dockState.Splitter != null && _dockState.OrgDockStyle != DockStyle.Fill && _dockState.OrgDockStyle != DockStyle.None)
            {
                _dockState.Splitter.Parent = _dockState.OrgDockingParent;
                _dockState.Splitter.Dock = _dockState.OrgDockStyle;
                _dockState.Splitter.Visible = true; // show splitter

                if (_dockOnInside)
                    _dockState.Splitter.BringToFront();
                else
                    _dockState.Splitter.SendToBack();
            }

            if (!_dockOnInside)
                _dockState.Container.SendToBack(); // set to back

            _isFloating = false;

            if (Docking != null)
                Docking.Invoke(this, new EventArgs());
        }

        private void DetachHandle()
        {
            _dockState.Handle.MouseMove -= new MouseEventHandler(Handle_MouseMove);
            _dockState.Handle.MouseHover -= new EventHandler(Handle_MouseHover);
            _dockState.Handle.MouseLeave -= new EventHandler(Handle_MouseLeave);
            _dockState.Container = null;
            _dockState.Handle = null;
        }

        #endregion

        #region Tracking

        void Handle_MouseHover(object sender, EventArgs e) => _startFloating = true;

        void Handle_MouseLeave(object sender, EventArgs e) => _startFloating = false;

        void Handle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _startFloating)
            {
                Point ps = _dockState.Handle.PointToScreen(new Point(e.X, e.Y));
                MakeFloatable(_dockState, e.X, e.Y);
            }
        }

        #endregion

        #region Event

        public event EventHandler Docking;

        #endregion
    }
}
