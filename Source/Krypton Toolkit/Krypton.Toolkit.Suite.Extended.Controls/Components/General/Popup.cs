#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2024 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

using VisualStyleRender = System.Windows.Forms.VisualStyles;

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    [ToolboxItem(false), CLSCompliant(true)]
    public partial class Popup : ToolStripDropDown
    {
        #region Instance Fields

        private bool _fade;

        private bool _focusOnOpen;

        private bool _acceptAlt;

        private bool _resizable;

        private bool _resizableControl;

        private bool _resizableTop;

        private bool _resizableRight;

        private Control _content;

        private Popup _ownerPopup;

        private Popup _childPopup;

        private ToolStripControlHost _host;

        private Size _maximumSize;

        private Size _minimumSize;

        private VisualStyleRender.VisualStyleRenderer _sizeGripRenderer;

        #endregion

        #region Public

        public bool UseFadeEffect
        {
            get => _fade;

            set
            {
                if (_fade != value)
                {
                    _fade = value;
                }
                else
                {
                    return;
                }
            }
        }

        public bool FocusOnOpen
        {
            get => _focusOnOpen;
            set => _focusOnOpen = value;
        }

        public bool AcceptAlt
        {
            get => _acceptAlt;
            set => _acceptAlt = value;
        }

        public bool Resizable
        {
            get => _resizableControl && _resizable;
            set => _resizableControl = value;
        }

        public Control Content => _content;

        public DateTime LastClosedTimeStamp { get; set; }

        public new Size MinimumSize
        {
            get => _minimumSize;
            set => _minimumSize = value;
        }

        public new Size MaximumSize
        {
            get => _maximumSize;
            set => _maximumSize = value;
        }

        #endregion

        #region Identity

        public Popup(Control? content)
        {
            if (content == null)
            {
                return;
            }

            _content = content;

            _fade = SystemInformation.IsMenuAnimationEnabled && SystemInformation.IsMenuFadeEnabled;

            _resizable = true;
            
            InitializeComponent();
            
            AutoSize = false;
            
            DoubleBuffered = true;
            
            ResizeRedraw = true;
            
            _host = new ToolStripControlHost(content);
            
            Padding = Margin = _host.Padding = _host.Margin = Padding.Empty;

            MinimumSize = content.MinimumSize;
            
            content.MinimumSize = content.Size;
            
            MaximumSize = content.MaximumSize;
            
            content.MaximumSize = content.Size;
            
            Size = content.Size;
            
            content.Location = Point.Empty;
            
            Items.Add(_host);

            content.Disposed += delegate (object sender, EventArgs e)
            {
                content = null;
                Dispose(true);
            };
  
            content.RegionChanged += delegate (object sender, EventArgs e)
            {
                UpdateRegion();
            };
            
            content.Paint += delegate (object sender, PaintEventArgs e)
            {
                PaintSizeGrip(e);
            };
            
            UpdateRegion();
        }

        #endregion

        #region Protected Overrides

        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                CreateParams cp = base.CreateParams;

                cp.ExStyle |= NativeMethods.WS_EX_NOACTIVATE;

                return cp;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (_acceptAlt && ((keyData & Keys.Alt) == Keys.Alt))
            {
                return false;
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void SetVisibleCore(bool visible)
        {
            double opacity = Opacity;
            if (visible && _fade && _focusOnOpen)
            {
                Opacity = 0;
            }

            base.SetVisibleCore(visible);
            if (!visible || !_fade || !_focusOnOpen)
            {
                return;
            }
            for (int i = 1; i <= FRAMES; i++)
            {
                if (i > 1)
                {
                    System.Threading.Thread.Sleep(FRAMEDURATION);
                }
                Opacity = opacity * (double)i / (double)FRAMES;
            }
            Opacity = opacity;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            _content.MinimumSize = Size;
            _content.MaximumSize = Size;
            _content.Size = Size;
            _content.Location = Point.Empty;

            base.OnSizeChanged(e);
        }

        protected override void OnOpening(CancelEventArgs e)
        {
            if (_content.IsDisposed || _content.Disposing)
            {
                e.Cancel = true;
                return;
            }
            UpdateRegion();

            base.OnOpening(e);
        }

        protected override void OnOpened(EventArgs e)
        {
            if (_ownerPopup != null)
            {
                _ownerPopup._resizable = false;
            }
            if (_focusOnOpen)
            {
                _content.Focus();
            }

            base.OnOpened(e);
        }

        protected override void OnClosed(ToolStripDropDownClosedEventArgs e)
        {
            if (_ownerPopup != null)
            {
                _ownerPopup._resizable = true;
            }

            base.OnClosed(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (!Visible)
            {
                LastClosedTimeStamp = DateTime.Now;
            }

            base.OnVisibleChanged(e);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            if (InternalProcessResizing(ref m, false))
            {
                return;
            }
            base.WndProc(ref m);
        }

        #endregion

        #region Implementation

        /// <summary>
        /// Updates the pop-up region.
        /// </summary>
        protected void UpdateRegion()
        {
            if (Region != null)
            {
                Region.Dispose();
                Region = null;
            }
            if (_content.Region != null)
            {
                Region = _content.Region.Clone();
            }
        }

        /// <summary>
        /// Shows pop-up window below the specified control.
        /// </summary>
        /// <param name="control">The control below which the pop-up will be shown.</param>
        /// <remarks>
        /// When there is no space below the specified control, the pop-up control is shown above it.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="control"/> is <code>null</code>.</exception>
        public void Show(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }
            SetOwnerItem(control);
            Show(control, control.ClientRectangle);
        }

        /// <summary>
        /// Shows pop-up window below the specified area of specified control.
        /// </summary>
        /// <param name="control">The control used to compute screen location of specified area.</param>
        /// <param name="area">The area of control below which the pop-up will be shown.</param>
        /// <remarks>
        /// When there is no space below specified area, the pop-up control is shown above it.
        /// </remarks>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="control"/> is <code>null</code>.</exception>
        public void Show(Control control, Rectangle area)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }
            SetOwnerItem(control);
            _resizableTop = _resizableRight = false;
            Point location = control.PointToScreen(new Point(area.Left, area.Top + area.Height));
            Rectangle screen = Screen.FromControl(control).WorkingArea;
            if (location.X + Size.Width > (screen.Left + screen.Width))
            {
                _resizableRight = true;
                location.X = (screen.Left + screen.Width) - Size.Width;
            }
            if (location.Y + Size.Height > (screen.Top + screen.Height))
            {
                _resizableTop = true;
                location.Y -= Size.Height + area.Height;
            }
            location = control.PointToClient(location);
            Show(control, location, ToolStripDropDownDirection.BelowRight);
        }

        private void SetOwnerItem(Control control)
        {
            if (control == null)
            {
                return;
            }
            if (control is Popup)
            {
                Popup popupControl = control as Popup;
                _ownerPopup = popupControl;
                _ownerPopup._childPopup = this;
                OwnerItem = popupControl.Items[0];
                return;
            }
            if (control.Parent != null)
            {
                SetOwnerItem(control.Parent);
            }
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool ProcessResizing(ref Message m)
        {
            return InternalProcessResizing(ref m, true);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private bool InternalProcessResizing(ref Message m, bool contentControl)
        {
            if (m.Msg == NativeMethods.WM_NCACTIVATE && m.WParam != IntPtr.Zero && _childPopup != null && _childPopup.Visible)
            {
                _childPopup.Hide();
            }
            if (!Resizable)
            {
                return false;
            }
            if (m.Msg == NativeMethods.WM_NCHITTEST)
            {
                return OnNcHitTest(ref m, contentControl);
            }
            else if (m.Msg == NativeMethods.WM_GETMINMAXINFO)
            {
                return OnGetMinMaxInfo(ref m);
            }
            return false;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private bool OnGetMinMaxInfo(ref Message m)
        {
            NativeMethods.MINMAXINFO minmax = (NativeMethods.MINMAXINFO)Marshal.PtrToStructure(m.LParam, typeof(NativeMethods.MINMAXINFO));
            minmax.MaximumTrackSize = this.MaximumSize;
            minmax.MinimumTrackSize = this.MinimumSize;
            Marshal.StructureToPtr(minmax, m.LParam, false);
            return true;
        }

        private bool OnNcHitTest(ref Message m, bool contentControl)
        {
            int x = NativeMethods.LOWORD(m.LParam);
            int y = NativeMethods.HIWORD(m.LParam);
            Point clientLocation = PointToClient(new Point(x, y));

            GripBounds gripBounds = new GripBounds(contentControl ? _content.ClientRectangle : ClientRectangle);
            IntPtr transparent = new IntPtr(NativeMethods.HTTRANSPARENT);

            if (_resizableTop)
            {
                if (_resizableRight && gripBounds.TopLeft.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)NativeMethods.HTTOPLEFT;
                    return true;
                }
                if (!_resizableRight && gripBounds.TopRight.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)NativeMethods.HTTOPRIGHT;
                    return true;
                }
                if (gripBounds.Top.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)NativeMethods.HTTOP;
                    return true;
                }
            }
            else
            {
                if (_resizableRight && gripBounds.BottomLeft.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)NativeMethods.HTBOTTOMLEFT;
                    return true;
                }
                if (!_resizableRight && gripBounds.BottomRight.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)NativeMethods.HTBOTTOMRIGHT;
                    return true;
                }
                if (gripBounds.Bottom.Contains(clientLocation))
                {
                    m.Result = contentControl ? transparent : (IntPtr)NativeMethods.HTBOTTOM;
                    return true;
                }
            }
            if (_resizableRight && gripBounds.Left.Contains(clientLocation))
            {
                m.Result = contentControl ? transparent : (IntPtr)NativeMethods.HTLEFT;
                return true;
            }
            if (!_resizableRight && gripBounds.Right.Contains(clientLocation))
            {
                m.Result = contentControl ? transparent : (IntPtr)NativeMethods.HTRIGHT;
                return true;
            }
            return false;
        }

        public void PaintSizeGrip(PaintEventArgs e)
        {
            if (e == null || e.Graphics == null || !_resizable)
            {
                return;
            }
            Size clientSize = _content.ClientSize;
            if (Application.RenderWithVisualStyles)
            {
                _sizeGripRenderer ??= new VisualStyleRender.VisualStyleRenderer(VisualStyleRender.VisualStyleElement.Status.Gripper.Normal);

                _sizeGripRenderer.DrawBackground(e.Graphics, new Rectangle(clientSize.Width - 0x10, clientSize.Height - 0x10, 0x10, 0x10));
            }
            else
            {
                ControlPaint.DrawSizeGrip(e.Graphics, _content.BackColor, clientSize.Width - 0x10, clientSize.Height - 0x10, 0x10, 0x10);
            }
        }

        private const int FRAMES = 1;
        private const int TOTALDURATION = 0; // ML : 2007-11-05 : was 100 but caused a flicker.
        private const int FRAMEDURATION = TOTALDURATION / FRAMES;

        #endregion

        #region Designer Code

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                if (_content != null)
                {
                    Control? content = _content;
                    content = null;
                    _content.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion

        #endregion
    }
}