#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    public partial class KryptonPopUpNotificationWindow : KryptonForm
    {
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

        #region Variables
        private bool _mouseOnClose = false;
        private bool _mouseOnLink = false;
        private bool _mouseOnOptions = false;
        private int _heightOfTitle;

        #region GDI Objects

        private bool _gdiInitialized = false;
        private Rectangle _rcBody;
        private Rectangle _rcHeader;
        private Rectangle _rcForm;
        private LinearGradientBrush _brushBody;
        private LinearGradientBrush _brushHeader;
        private Brush _brushButtonHover;
        private Pen _penButtonBorder;
        private Pen _penContent;
        private Pen _penBorder;
        private Brush _brushForeColour;
        private Brush _brushLinkHover;
        private Brush _brushContent;
        private Brush _brushTitle;

        #endregion


        #endregion

        #region Properties
        public new KryptonToastNotificationPopup PopUp { get; set; }

        /// <summary>
        /// Gets the rectangle of the content text.
        /// </summary>
        private RectangleF RectContentText
        {
            get
            {
                if (PopUp.Image != null)
                {
                    return new RectangleF(
                        PopUp.ImagePadding.Left + PopUp.ImageSize.Width + PopUp.ImagePadding.Right + PopUp.ContentPadding.Left,
                        PopUp.HeaderHeight + PopUp.TitlePadding.Top + _heightOfTitle + PopUp.TitlePadding.Bottom + PopUp.ContentPadding.Top,
                        Width - PopUp.ImagePadding.Left - PopUp.ImageSize.Width - PopUp.ImagePadding.Right - PopUp.ContentPadding.Left - PopUp.ContentPadding.Right - 16 - 5,
                        Height - PopUp.HeaderHeight - PopUp.TitlePadding.Top - _heightOfTitle - PopUp.TitlePadding.Bottom - PopUp.ContentPadding.Top - PopUp.ContentPadding.Bottom - 1);
                }
                else
                {
                    return new RectangleF(
                        PopUp.ContentPadding.Left,
                        PopUp.HeaderHeight + PopUp.TitlePadding.Top + _heightOfTitle + PopUp.TitlePadding.Bottom + PopUp.ContentPadding.Top,
                        Width - PopUp.ContentPadding.Left - PopUp.ContentPadding.Right - 16 - 5,
                        Height - PopUp.HeaderHeight - PopUp.TitlePadding.Top - _heightOfTitle - PopUp.TitlePadding.Bottom - PopUp.ContentPadding.Top - PopUp.ContentPadding.Bottom - 1);
                }
            }
        }

        /// <summary>
        /// gets the rectangle of the close button.
        /// </summary>
        private Rectangle RectClose => new Rectangle(Width - 5 - 16, PopUp.HeaderHeight + 3, 16, 16);

        /// <summary>
        /// Gets the rectangle of the options button.
        /// </summary>
        private Rectangle RectOptions => new Rectangle(Width - 5 - 16, PopUp.HeaderHeight + 3 + 16 + 5, 16, 16);
        #endregion

        #region Constructor
        public KryptonPopUpNotificationWindow(KryptonToastNotificationPopup popup)
        {
            PopUp = popup;

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);

            ShowInTaskbar = false;

            VisibleChanged += new EventHandler(PopupNotifierForm_VisibleChanged);

            MouseMove += new MouseEventHandler(PopupNotifierForm_MouseMove);

            MouseUp += new MouseEventHandler(PopupNotifierForm_MouseUp);

            Paint += new PaintEventHandler(PopupNotifierForm_Paint);
        }
        #endregion

        #region Event Handlers
        /// <summary>The form is shown/hidden.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopupNotifierForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                _mouseOnClose = false;

                _mouseOnLink = false;

                _mouseOnOptions = false;
            }
        }

        /// <summary>
        /// Update form to display hover styles when the mouse moves over the notification form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopupNotifierForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (PopUp.ShowCloseButton)
            {
                _mouseOnClose = RectClose.Contains(e.X, e.Y);
            }
            if (PopUp.ShowOptionsButton)
            {
                _mouseOnOptions = RectOptions.Contains(e.X, e.Y);
            }
            _mouseOnLink = RectContentText.Contains(e.X, e.Y);
            Invalidate();
        }

        /// <summary>
        /// A mouse button has been released, check if something has been clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopupNotifierForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (RectClose.Contains(e.X, e.Y) && CloseClick != null)
                {
                    CloseClick(this, EventArgs.Empty);
                }
                if (RectContentText.Contains(e.X, e.Y) && LinkClick != null)
                {
                    LinkClick(this, EventArgs.Empty);
                }
                if (RectOptions.Contains(e.X, e.Y) && PopUp.OptionsMenu != null)
                {
                    if (ContextMenuOpened != null)
                    {
                        ContextMenuOpened(this, EventArgs.Empty);
                    }
                    PopUp.OptionsMenu.Show(this, new Point(RectOptions.Right - PopUp.OptionsMenu.Width, RectOptions.Bottom));
                    PopUp.OptionsMenu.Closed += new ToolStripDropDownClosedEventHandler(OptionsMenu_Closed);
                }
            }
        }

        /// <summary>
        /// The options popup menu has been closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionsMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            PopUp.OptionsMenu.Closed -= new ToolStripDropDownClosedEventHandler(OptionsMenu_Closed);

            if (ContextMenuClosed != null)
            {
                ContextMenuClosed(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Draw the notification form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopupNotifierForm_Paint(object sender, PaintEventArgs e)
        {
            if (!_gdiInitialized)
            {
                AllocateGdiObjects();
            }

            // draw window
            e.Graphics.FillRectangle(_brushBody, _rcBody);
            e.Graphics.FillRectangle(_brushHeader, _rcHeader);
            e.Graphics.DrawRectangle(_penBorder, _rcForm);
            if (PopUp.ShowGrip)
            {
                e.Graphics.DrawImage(Properties.Resources.Grip, (int)((Width - Properties.Resources.Grip.Width) / 2), (int)((PopUp.HeaderHeight - 3) / 2));
            }
            if (PopUp.ShowCloseButton)
            {
                if (_mouseOnClose)
                {
                    e.Graphics.FillRectangle(_brushButtonHover, RectClose);
                    e.Graphics.DrawRectangle(_penButtonBorder, RectClose);
                }
                e.Graphics.DrawLine(_penContent, RectClose.Left + 4, RectClose.Top + 4, RectClose.Right - 4, RectClose.Bottom - 4);
                e.Graphics.DrawLine(_penContent, RectClose.Left + 4, RectClose.Bottom - 4, RectClose.Right - 4, RectClose.Top + 4);
            }
            if (PopUp.ShowOptionsButton)
            {
                if (_mouseOnOptions)
                {
                    e.Graphics.FillRectangle(_brushButtonHover, RectOptions);
                    e.Graphics.DrawRectangle(_penButtonBorder, RectOptions);
                }
                e.Graphics.FillPolygon(_brushForeColour, [new Point(RectOptions.Left + 4, RectOptions.Top + 6), new Point(RectOptions.Left + 12, RectOptions.Top + 6), new Point(RectOptions.Left + 8, RectOptions.Top + 4 + 6)
                ]);
            }

            // draw icon
            if (PopUp.Image != null)
            {
                e.Graphics.DrawImage(PopUp.Image, PopUp.ImagePadding.Left, PopUp.HeaderHeight + PopUp.ImagePadding.Top, PopUp.ImageSize.Width, PopUp.ImageSize.Height);
            }


            if (PopUp.IsRightToLeft)
            {
                _heightOfTitle = (int)e.Graphics.MeasureString("A", PopUp.TitleFont).Height;

                // the value 30 is because of x close icon
                int titleX2 = Width - 30;// PopUp.TitlePadding.Right;

                // draw title right to left
                StringFormat headerFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                e.Graphics.DrawString(PopUp.TitleText, PopUp.TitleFont, _brushTitle, titleX2, PopUp.HeaderHeight + PopUp.TitlePadding.Top, headerFormat);

                // draw content text, optionally with a bold part
                Cursor = _mouseOnLink ? Cursors.Hand : Cursors.Default;
                Brush brushText = _mouseOnLink ? _brushLinkHover : _brushContent;

                // draw content right to left
                StringFormat contentFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                e.Graphics.DrawString(PopUp.ContentText, PopUp.ContentFont, brushText, RectContentText, contentFormat);
            }
            else
            {
                // calculate height of title
                _heightOfTitle = (int)e.Graphics.MeasureString("A", PopUp.TitleFont).Height;
                int titleX = PopUp.TitlePadding.Left;
                if (PopUp.Image != null)
                {
                    titleX += PopUp.ImagePadding.Left + PopUp.ImageSize.Width + PopUp.ImagePadding.Right;
                }

                e.Graphics.DrawString(PopUp.TitleText, PopUp.TitleFont, _brushTitle, titleX, PopUp.HeaderHeight + PopUp.TitlePadding.Top);
                // draw content text, optionally with a bold part
                Cursor = _mouseOnLink ? Cursors.Hand : Cursors.Default;
                Brush brushText = _mouseOnLink ? _brushLinkHover : _brushContent;
                e.Graphics.DrawString(PopUp.ContentText, PopUp.ContentFont, brushText, RectContentText);
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
        private int AddValueMax255(int input, int add) => input + add < 256 ? input + add : 255;

        /// <summary>
        /// Subtract two values but do not returns a value below 0.
        /// </summary>
        /// <param name="input">first value</param>
        /// <param name="ded">value to subtract</param>
        /// <returns>first value minus second value</returns>
        private int DedValueMin0(int input, int ded) => input - ded > 0 ? input - ded : 0;

        /// <summary>
        /// Returns a color which is darker than the given color.
        /// </summary>
        /// <param name="colour">Color</param>
        /// <returns>darker color</returns>
        private Color GetDarkerColour(Color colour) => Color.FromArgb(255, DedValueMin0((int)colour.R, PopUp.GradientPower), DedValueMin0((int)colour.G, PopUp.GradientPower), DedValueMin0((int)colour.B, PopUp.GradientPower));

        /// <summary>
        /// Returns a color which is lighter than the given color.
        /// </summary>
        /// <param name="colour">Color</param>
        /// <returns>lighter color</returns>
        private Color GetLighterColour(Color colour) => Color.FromArgb(255, AddValueMax255((int)colour.R, PopUp.GradientPower), AddValueMax255((int)colour.G, PopUp.GradientPower), AddValueMax255((int)colour.B, PopUp.GradientPower));

        /// <summary>
        /// Create all GDI objects used to paint the form.
        /// </summary>
        private void AllocateGdiObjects()
        {
            _rcBody = new Rectangle(0, 0, Width, Height);
            _rcHeader = new Rectangle(0, 0, Width, PopUp.HeaderHeight);
            _rcForm = new Rectangle(0, 0, Width - 1, Height - 1);

            _brushBody = new LinearGradientBrush(_rcBody, PopUp.BodyColour, GetLighterColour(PopUp.BodyColour), LinearGradientMode.Vertical);
            _brushHeader = new LinearGradientBrush(_rcHeader, PopUp.HeaderColour, GetDarkerColour(PopUp.HeaderColour), LinearGradientMode.Vertical);
            _brushButtonHover = new SolidBrush(PopUp.ButtonHoverColour);
            _penButtonBorder = new Pen(PopUp.ButtonBorderColour);
            _penContent = new Pen(PopUp.ContentColour, 2);
            _penBorder = new Pen(PopUp.BorderColour);
            _brushForeColour = new SolidBrush(ForeColor);
            _brushLinkHover = new SolidBrush(PopUp.ContentHoverColour);
            _brushContent = new SolidBrush(PopUp.ContentColour);
            _brushTitle = new SolidBrush(PopUp.TitleColour);

            _gdiInitialized = true;
        }

        /// <summary>
        /// Free all GDI objects.
        /// </summary>
        private void DisposeGdiObjects()
        {
            if (_gdiInitialized)
            {
                _brushBody.Dispose();
                _brushHeader.Dispose();
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
    }
}