#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    public class KryptonPopUpNotification : KryptonForm
    {
        #region Design Code
        private KryptonPanel kpnlBackground;

        private void InitializeComponent()
        {
            this.kpnlBackground = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlBackground
            // 
            this.kpnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlBackground.Location = new System.Drawing.Point(0, 0);
            this.kpnlBackground.Name = "kpnlBackground";
            this.kpnlBackground.Size = new System.Drawing.Size(376, 59);
            this.kpnlBackground.TabIndex = 0;
            // 
            // KryptonPopUpNotification
            // 
            this.ClientSize = new System.Drawing.Size(376, 59);
            this.ControlBox = false;
            this.Controls.Add(this.kpnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonPopUpNotification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBackground)).EndInit();
            this.ResumeLayout(false);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposeGDIObjects();
            }

            base.Dispose(disposing);
        }
        #endregion

        #region Variables
        private Brush _brushForeColour, _brushLinkHover, _brushContent, _brushButtonHover, _brushTitle;
        private bool _mouseOnClose = false, _mouseOnLink = false, _mouseOnOptions = false, _gdiInitialised = false;
        private int _heightOfTitle;
        private Rectangle _rectBody, _rectHeader, _rectForm;
        private LinearGradientBrush _lgbBody, _lgbHeader;
        private Pen _penButtonBorder, _penContent, _penBorder;
        private KryptonPanel kpnlBack;
        #endregion

        #region Properties
        public new KryptonToastNotificationPopup Parent { get; set; }

        /// <summary>
        /// Gets the rectangle of the content text.
        /// </summary>
        private RectangleF RectContentText
        {
            get
            {
                if (Parent.Image != null)
                {
                    return new RectangleF(
                        Parent.ImagePadding.Left + Parent.ImageSize.Width + Parent.ImagePadding.Right + Parent.ContentPadding.Left,
                        Parent.HeaderHeight + Parent.TitlePadding.Top + _heightOfTitle + Parent.TitlePadding.Bottom + Parent.ContentPadding.Top,
                        this.Width - Parent.ImagePadding.Left - Parent.ImageSize.Width - Parent.ImagePadding.Right - Parent.ContentPadding.Left - Parent.ContentPadding.Right - 16 - 5,
                        this.Height - Parent.HeaderHeight - Parent.TitlePadding.Top - _heightOfTitle - Parent.TitlePadding.Bottom - Parent.ContentPadding.Top - Parent.ContentPadding.Bottom - 1);
                }
                else
                {
                    return new RectangleF(
                        Parent.ContentPadding.Left,
                        Parent.HeaderHeight + Parent.TitlePadding.Top + _heightOfTitle + Parent.TitlePadding.Bottom + Parent.ContentPadding.Top,
                        this.Width - Parent.ContentPadding.Left - Parent.ContentPadding.Right - 16 - 5,
                        this.Height - Parent.HeaderHeight - Parent.TitlePadding.Top - _heightOfTitle - Parent.TitlePadding.Bottom - Parent.ContentPadding.Top - Parent.ContentPadding.Bottom - 1);
                }
            }
        }

        /// <summary>
        /// gets the rectangle of the close button.
        /// </summary>
        private Rectangle RectClose
        {
            get { return new Rectangle(this.Width - 5 - 16, Parent.HeaderHeight + 3, 16, 16); }
        }

        /// <summary>
        /// Gets the rectangle of the options button.
        /// </summary>
        private Rectangle RectOptions
        {
            get { return new Rectangle(this.Width - 5 - 16, Parent.HeaderHeight + 3 + 16 + 5, 16, 16); }
        }

        #endregion

        #region Events
        /// <summary>
        /// Event that is raised when the text is clicked.
        /// </summary>
        public event EventHandler LinkClick;

        /// <summary>
        /// Event that is raised when the notification window is manually closed.
        /// </summary>
        public event EventHandler CloseClick;

        internal event EventHandler ContextMenuOpened;

        internal event EventHandler ContextMenuClosed;
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="KryptonPopUpNotification" /> class.</summary>
        /// <param name="parent">The parent.</param>
        /// <param name="borderStyle">The border style.</param>
        public KryptonPopUpNotification(KryptonToastNotificationPopup parent, FormBorderStyle borderStyle = FormBorderStyle.FixedSingle)
        {
            Parent = parent;

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);

            ShowInTaskbar = false;

            VisibleChanged += KryptonPopUpNotification_VisibleChanged;

            MouseMove += KryptonPopUpNotification_MouseMove;

            MouseUp += KryptonPopUpNotification_MouseUp;

            Paint += KryptonPopUpNotification_Paint;

            FormBorderStyle = borderStyle;
        }
        #endregion

        #region Event Handlers
        private void KryptonPopUpNotification_Paint(object sender, PaintEventArgs e)
        {
            if (!_gdiInitialised)
            {
                AllocateGDIObjects();
            }

            // draw window
            e.Graphics.FillRectangle(_lgbBody, _rectBody);
            e.Graphics.FillRectangle(_lgbHeader, _rectHeader);
            e.Graphics.DrawRectangle(_penBorder, _rectForm);
            if (Parent.ShowGrip)
            {
                e.Graphics.DrawImage(Properties.Resources.Grip, (int)((this.Width - Properties.Resources.Grip.Width) / 2), (int)((Parent.HeaderHeight - 3) / 2));
            }
            if (Parent.ShowCloseButton)
            {
                if (_mouseOnClose)
                {
                    e.Graphics.FillRectangle(_brushButtonHover, RectClose);
                    e.Graphics.DrawRectangle(_penButtonBorder, RectClose);
                }
                e.Graphics.DrawLine(_penContent, RectClose.Left + 4, RectClose.Top + 4, RectClose.Right - 4, RectClose.Bottom - 4);
                e.Graphics.DrawLine(_penContent, RectClose.Left + 4, RectClose.Bottom - 4, RectClose.Right - 4, RectClose.Top + 4);
            }
            if (Parent.ShowOptionsButton)
            {
                if (_mouseOnOptions)
                {
                    e.Graphics.FillRectangle(_brushButtonHover, RectOptions);
                    e.Graphics.DrawRectangle(_penButtonBorder, RectOptions);
                }
                e.Graphics.FillPolygon(_brushForeColour, new Point[] { new Point(RectOptions.Left + 4, RectOptions.Top + 6), new Point(RectOptions.Left + 12, RectOptions.Top + 6), new Point(RectOptions.Left + 8, RectOptions.Top + 4 + 6) });
            }

            // draw icon
            if (Parent.Image != null)
            {
                e.Graphics.DrawImage(Parent.Image, Parent.ImagePadding.Left, Parent.HeaderHeight + Parent.ImagePadding.Top, Parent.ImageSize.Width, Parent.ImageSize.Height);
            }


            if (Parent.IsRightToLeft)
            {
                _heightOfTitle = (int)e.Graphics.MeasureString("A", Parent.TitleFont).Height;

                // the value 30 is because of x close icon
                int titleX2 = this.Width - 30;// Parent.TitlePadding.Right;

                // draw title right to left
                StringFormat headerFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                e.Graphics.DrawString(Parent.TitleText, Parent.TitleFont, _brushTitle, titleX2, Parent.HeaderHeight + Parent.TitlePadding.Top, headerFormat);

                // draw content text, optionally with a bold part
                this.Cursor = _mouseOnLink ? Cursors.Hand : Cursors.Default;
                Brush brushText = _mouseOnLink ? _brushLinkHover : _brushContent;

                // draw content right to left
                StringFormat contentFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                e.Graphics.DrawString(Parent.ContentText, Parent.ContentFont, brushText, RectContentText, contentFormat);
            }
            else
            {
                // calculate height of title
                _heightOfTitle = (int)e.Graphics.MeasureString("A", Parent.TitleFont).Height;
                int titleX = Parent.TitlePadding.Left;
                if (Parent.Image != null)
                {
                    titleX += Parent.ImagePadding.Left + Parent.ImageSize.Width + Parent.ImagePadding.Right;
                }

                e.Graphics.DrawString(Parent.TitleText, Parent.TitleFont, _brushTitle, titleX, Parent.HeaderHeight + Parent.TitlePadding.Top);
                // draw content text, optionally with a bold part
                this.Cursor = _mouseOnLink ? Cursors.Hand : Cursors.Default;
                Brush brushText = _mouseOnLink ? _brushLinkHover : _brushContent;
                e.Graphics.DrawString(Parent.ContentText, Parent.ContentFont, brushText, RectContentText);
            }
        }

        private void KryptonPopUpNotification_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (RectClose.Contains(e.X, e.Y) && (CloseClick != null))
                {
                    CloseClick(this, EventArgs.Empty);
                }
                if (RectContentText.Contains(e.X, e.Y) && (LinkClick != null))
                {
                    LinkClick(this, EventArgs.Empty);
                }
                if (RectOptions.Contains(e.X, e.Y) && (Parent.OptionsMenu != null))
                {
                    if (ContextMenuOpened != null)
                    {
                        ContextMenuOpened(this, EventArgs.Empty);
                    }
                    Parent.OptionsMenu.Show(this, new Point(RectOptions.Right - Parent.OptionsMenu.Width, RectOptions.Bottom));
                    Parent.OptionsMenu.Closed += new ToolStripDropDownClosedEventHandler(OptionsMenu_Closed);
                }
            }
        }

        private void KryptonPopUpNotification_MouseMove(object sender, MouseEventArgs e)
        {
            if (Parent.ShowCloseButton)
            {
                _mouseOnClose = RectClose.Contains(e.X, e.Y);
            }

            if (Parent.ShowOptionsButton)
            {
                _mouseOnOptions = RectOptions.Contains(e.X, e.Y);
            }

            _mouseOnLink = RectContentText.Contains(e.X, e.Y);

            Invalidate();
        }

        private void KryptonPopUpNotification_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                _mouseOnClose = false;

                _mouseOnLink = false;

                _mouseOnOptions = false;
            }
        }

        /// <summary>
        /// The options popup menu has been closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionsMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            Parent.OptionsMenu.Closed -= new ToolStripDropDownClosedEventHandler(OptionsMenu_Closed);

            if (ContextMenuClosed != null)
            {
                ContextMenuClosed(this, EventArgs.Empty);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add two values but do not return a value greater than 255.
        /// </summary>
        /// <param name="input">first value</param>
        /// <param name="add">value to add</param>
        /// <returns>sum of both values</returns>
        private int AddValueMax255(int input, int add)
        {
            return (input + add < 256) ? input + add : 255;
        }

        /// <summary>
        /// Subtract two values but do not returns a value below 0.
        /// </summary>
        /// <param name="input">first value</param>
        /// <param name="ded">value to subtract</param>
        /// <returns>first value minus second value</returns>
        private int DedValueMin0(int input, int ded)
        {
            return (input - ded > 0) ? input - ded : 0;
        }

        /// <summary>
        /// Returns a color which is darker than the given color.
        /// </summary>
        /// <param name="colour">Color</param>
        /// <returns>darker color</returns>
        private Color GetDarkerColour(Color colour)
        {
            return Color.FromArgb(255, DedValueMin0((int)colour.R, Parent.GradientPower), DedValueMin0((int)colour.G, Parent.GradientPower), DedValueMin0((int)colour.B, Parent.GradientPower));
        }

        /// <summary>
        /// Returns a color which is lighter than the given color.
        /// </summary>
        /// <param name="color">Color</param>
        /// <returns>lighter color</returns>
        private Color GetLighterColour(Color colour)
        {
            return Color.FromArgb(255, AddValueMax255((int)colour.R, Parent.GradientPower), AddValueMax255((int)colour.G, Parent.GradientPower), AddValueMax255((int)colour.B, Parent.GradientPower));
        }

        /// <summary>
        /// Create all GDI objects used to paint the form.
        /// </summary>
        private void AllocateGDIObjects()
        {
            _rectBody = new Rectangle(0, 0, this.Width, this.Height);
            _rectHeader = new Rectangle(0, 0, this.Width, Parent.HeaderHeight);
            _rectForm = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            _lgbBody = new LinearGradientBrush(_rectBody, Parent.BodyColour, GetLighterColour(Parent.BodyColour), LinearGradientMode.Vertical);
            _lgbHeader = new LinearGradientBrush(_rectHeader, Parent.HeaderColour, GetDarkerColour(Parent.HeaderColour), LinearGradientMode.Vertical);
            _brushButtonHover = new SolidBrush(Parent.ButtonHoverColour);
            _penButtonBorder = new Pen(Parent.ButtonBorderColour);
            _penContent = new Pen(Parent.ContentColour, 2);
            _penBorder = new Pen(Parent.BorderColour);
            _brushForeColour = new SolidBrush(ForeColor);
            _brushLinkHover = new SolidBrush(Parent.ContentHoverColour);
            _brushContent = new SolidBrush(Parent.ContentColour);
            _brushTitle = new SolidBrush(Parent.TitleColour);

            _gdiInitialised = true;
        }

        /// <summary>
        /// Free all GDI objects.
        /// </summary>
        private void DisposeGDIObjects()
        {
            if (_gdiInitialised)
            {
                _lgbBody.Dispose();
                _lgbHeader.Dispose();
                _brushButtonHover.Dispose();
                _penButtonBorder.Dispose();
                _penContent.Dispose();
                _penBorder.Dispose();
                _brushForeColour.Dispose();
                _brushLinkHover.Dispose();
                _brushContent.Dispose();
                _brushTitle.Dispose();
            }
        }
        #endregion

        #region Overrides
        protected override bool ShowWithoutActivation => true;

        protected override CreateParams CreateParams
        {
            get
            {
                //make sure Top Most property on form is set to false
                //otherwise this doesn't work
                int WS_EX_TOPMOST = 0x00000008;

                CreateParams cp = base.CreateParams;

                cp.ExStyle |= WS_EX_TOPMOST;

                return cp;
            }
        }
        #endregion
    }
}