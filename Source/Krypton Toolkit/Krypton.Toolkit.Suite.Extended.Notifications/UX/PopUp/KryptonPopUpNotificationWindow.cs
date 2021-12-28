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
    internal class KryptonPopUpNotificationWindow : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(424, 70);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // KryptonPopUpNotificationWindow
            // 
            this.ClientSize = new System.Drawing.Size(424, 70);
            this.ControlBox = false;
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonPopUpNotificationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.ResumeLayout(false);

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

        #region Variables
        private bool mouseOnClose = false;
        private bool mouseOnLink = false;
        private bool mouseOnOptions = false;
        private int heightOfTitle;

        #region GDI Objects

        private bool gdiInitialized = false;
        private Rectangle rcBody;
        private Rectangle rcHeader;
        private Rectangle rcForm;
        private LinearGradientBrush brushBody;
        private LinearGradientBrush brushHeader;
        private Brush brushButtonHover;
        private Pen penButtonBorder;
        private Pen penContent;
        private Pen penBorder;
        private Brush brushForeColour;
        private Brush brushLinkHover;
        private Brush brushContent;
        private Brush brushTitle;

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
                        PopUp.HeaderHeight + PopUp.TitlePadding.Top + heightOfTitle + PopUp.TitlePadding.Bottom + PopUp.ContentPadding.Top,
                        Width - PopUp.ImagePadding.Left - PopUp.ImageSize.Width - PopUp.ImagePadding.Right - PopUp.ContentPadding.Left - PopUp.ContentPadding.Right - 16 - 5,
                        Height - PopUp.HeaderHeight - PopUp.TitlePadding.Top - heightOfTitle - PopUp.TitlePadding.Bottom - PopUp.ContentPadding.Top - PopUp.ContentPadding.Bottom - 1);
                }
                else
                {
                    return new RectangleF(
                        PopUp.ContentPadding.Left,
                        PopUp.HeaderHeight + PopUp.TitlePadding.Top + heightOfTitle + PopUp.TitlePadding.Bottom + PopUp.ContentPadding.Top,
                        Width - PopUp.ContentPadding.Left - PopUp.ContentPadding.Right - 16 - 5,
                        Height - PopUp.HeaderHeight - PopUp.TitlePadding.Top - heightOfTitle - PopUp.TitlePadding.Bottom - PopUp.ContentPadding.Top - PopUp.ContentPadding.Bottom - 1);
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
                mouseOnClose = false;
             
                mouseOnLink = false;
                
                mouseOnOptions = false;
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
                mouseOnClose = RectClose.Contains(e.X, e.Y);
            }
            if (PopUp.ShowOptionsButton)
            {
                mouseOnOptions = RectOptions.Contains(e.X, e.Y);
            }
            mouseOnLink = RectContentText.Contains(e.X, e.Y);
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
                if (RectClose.Contains(e.X, e.Y) && (CloseClick != null))
                {
                    CloseClick(this, EventArgs.Empty);
                }
                if (RectContentText.Contains(e.X, e.Y) && (LinkClick != null))
                {
                    LinkClick(this, EventArgs.Empty);
                }
                if (RectOptions.Contains(e.X, e.Y) && (PopUp.OptionsMenu != null))
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
            if (!gdiInitialized)
            {
                AllocateGDIObjects();
            }

            // draw window
            e.Graphics.FillRectangle(brushBody, rcBody);
            e.Graphics.FillRectangle(brushHeader, rcHeader);
            e.Graphics.DrawRectangle(penBorder, rcForm);
            if (PopUp.ShowGrip)
            {
                e.Graphics.DrawImage(Properties.Resources.Grip, (int)((this.Width - Properties.Resources.Grip.Width) / 2), (int)((PopUp.HeaderHeight - 3) / 2));
            }
            if (PopUp.ShowCloseButton)
            {
                if (mouseOnClose)
                {
                    e.Graphics.FillRectangle(brushButtonHover, RectClose);
                    e.Graphics.DrawRectangle(penButtonBorder, RectClose);
                }
                e.Graphics.DrawLine(penContent, RectClose.Left + 4, RectClose.Top + 4, RectClose.Right - 4, RectClose.Bottom - 4);
                e.Graphics.DrawLine(penContent, RectClose.Left + 4, RectClose.Bottom - 4, RectClose.Right - 4, RectClose.Top + 4);
            }
            if (PopUp.ShowOptionsButton)
            {
                if (mouseOnOptions)
                {
                    e.Graphics.FillRectangle(brushButtonHover, RectOptions);
                    e.Graphics.DrawRectangle(penButtonBorder, RectOptions);
                }
                e.Graphics.FillPolygon(brushForeColour, new Point[] { new Point(RectOptions.Left + 4, RectOptions.Top + 6), new Point(RectOptions.Left + 12, RectOptions.Top + 6), new Point(RectOptions.Left + 8, RectOptions.Top + 4 + 6) });
            }

            // draw icon
            if (PopUp.Image != null)
            {
                e.Graphics.DrawImage(PopUp.Image, PopUp.ImagePadding.Left, PopUp.HeaderHeight + PopUp.ImagePadding.Top, PopUp.ImageSize.Width, PopUp.ImageSize.Height);
            }


            if (PopUp.IsRightToLeft)
            {
                heightOfTitle = (int)e.Graphics.MeasureString("A", PopUp.TitleFont).Height;

                // the value 30 is because of x close icon
                int titleX2 = this.Width - 30;// PopUp.TitlePadding.Right;

                // draw title right to left
                StringFormat headerFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                e.Graphics.DrawString(PopUp.TitleText, PopUp.TitleFont, brushTitle, titleX2, PopUp.HeaderHeight + PopUp.TitlePadding.Top, headerFormat);

                // draw content text, optionally with a bold part
                this.Cursor = mouseOnLink ? Cursors.Hand : Cursors.Default;
                Brush brushText = mouseOnLink ? brushLinkHover : brushContent;

                // draw content right to left
                StringFormat contentFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                e.Graphics.DrawString(PopUp.ContentText, PopUp.ContentFont, brushText, RectContentText, contentFormat);
            }
            else
            {
                // calculate height of title
                heightOfTitle = (int)e.Graphics.MeasureString("A", PopUp.TitleFont).Height;
                int titleX = PopUp.TitlePadding.Left;
                if (PopUp.Image != null)
                    titleX += PopUp.ImagePadding.Left + PopUp.ImageSize.Width + PopUp.ImagePadding.Right;
                e.Graphics.DrawString(PopUp.TitleText, PopUp.TitleFont, brushTitle, titleX, PopUp.HeaderHeight + PopUp.TitlePadding.Top);
                // draw content text, optionally with a bold part
                this.Cursor = mouseOnLink ? Cursors.Hand : Cursors.Default;
                Brush brushText = mouseOnLink ? brushLinkHover : brushContent;
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
        private int AddValueMax255(int input, int add) => (input + add < 256) ? input + add : 255;

        /// <summary>
        /// Subtract two values but do not returns a value below 0.
        /// </summary>
        /// <param name="input">first value</param>
        /// <param name="ded">value to subtract</param>
        /// <returns>first value minus second value</returns>
        private int DedValueMin0(int input, int ded) => (input - ded > 0) ? input - ded : 0;

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
        private void AllocateGDIObjects()
        {
            rcBody = new Rectangle(0, 0, Width, Height);
            rcHeader = new Rectangle(0, 0, Width, PopUp.HeaderHeight);
            rcForm = new Rectangle(0, 0, Width - 1, Height - 1);

            brushBody = new LinearGradientBrush(rcBody, PopUp.BodyColour, GetLighterColour(PopUp.BodyColour), LinearGradientMode.Vertical);
            brushHeader = new LinearGradientBrush(rcHeader, PopUp.HeaderColour, GetDarkerColour(PopUp.HeaderColour), LinearGradientMode.Vertical);
            brushButtonHover = new SolidBrush(PopUp.ButtonHoverColour);
            penButtonBorder = new Pen(PopUp.ButtonBorderColour);
            penContent = new Pen(PopUp.ContentColour, 2);
            penBorder = new Pen(PopUp.BorderColour);
            brushForeColour = new SolidBrush(ForeColor);
            brushLinkHover = new SolidBrush(PopUp.ContentHoverColour);
            brushContent = new SolidBrush(PopUp.ContentColour);
            brushTitle = new SolidBrush(PopUp.TitleColour);

            gdiInitialized = true;
        }

        /// <summary>
        /// Free all GDI objects.
        /// </summary>
        private void DisposeGDIObjects()
        {
            if (gdiInitialized)
            {
                brushBody.Dispose();
                brushHeader.Dispose();
                brushButtonHover.Dispose();
                penButtonBorder.Dispose();
                penContent.Dispose();
                penBorder.Dispose();
                brushForeColour.Dispose();
                brushLinkHover.Dispose();
                brushContent.Dispose();
                brushTitle.Dispose();
            }
        }
        #endregion

        #region Overrides
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposeGDIObjects();
            }

            base.Dispose(disposing);
        }
        #endregion
    }
}