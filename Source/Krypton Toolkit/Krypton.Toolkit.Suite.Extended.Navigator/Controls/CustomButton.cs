#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    [ToolboxBitmap(typeof(Button)), ToolboxItem(false)]
    public class CustomButton : Button
    {
        #region ... Fields ...

        private Color gradientTop = Color.FromArgb(255, 44, 85, 177);
        private Color gradientBottom = Color.FromArgb(255, 153, 198, 241);
        private Color gradientBorderColor = Color.FromArgb(255, 153, 198, 241);
        private Color _hotGradientTop = Color.FromArgb(255, 234, 157);
        private Color _hotGradientBottom = Color.FromArgb(255, 213, 77);
        private Color _hotGradientBorderColor = Color.FromArgb(220, 205, 153);
        private Color _hotForeColor = Color.Gray;
        private Color _pressedGradientTop = Color.FromArgb(225, 178, 129);
        private Color _pressedGradientBottom = Color.FromArgb(235, 122, 5);
        private Color _pressedGradientBorderColor = Color.FromArgb(185, 150, 82);
        private Color _pressedForeColor = Color.DarkGray;
        private Color paintGradientTop;
        private Color paintGradientBottom;
        private Color paintGradientBorderColor;
        private Color paintForeColor;
        private Rectangle buttonRect;
        private Rectangle highlightRect;
        private int rectCornerRadius;
        private float rectOutlineWidth;
        private int highlightRectOffset;
        private int defaultHighlightOffset;
        /*
        private int highlightAlphaTop = 255;
        private int highlightAlphaBottom;
        private Timer animateButtonHighlightedTimer = new Timer();
        private Timer animateResumeNormalTimer = new Timer();
        private bool increasingAlpha;
         */
        private bool isHotTracking;
        private bool isPressed = false;

        #endregion

        public CustomButton()
        {
            //this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();

        }

        #region ... Properties ...

        [Category("Appearance-Extended")]
        [Description("The color to use for the top portion of the gradient fill of the component.")]
        [DefaultValue(typeof(Color), "0x2C55B1")]
        public Color GradientTop
        {
            get
            {
                return gradientTop;
            }
            set
            {
                gradientTop = value;
                SetPaintColors();
                Invalidate();
            }
        }

        [Category("Appearance-Extended")]
        [Description("The color to use for the bottom portion of the gradient fill of the component.")]
        [DefaultValue(typeof(Color), "0x99C6F1")]
        public Color GradientBottom
        {
            get
            {
                return gradientBottom;
            }
            set
            {
                gradientBottom = value;
                SetPaintColors();
                Invalidate();
            }
        }

        [Category("Appearance-Extended")]
        [Description("The color to use for the bottom portion of the gradient fill of the component.")]
        public Color GradientBorderColour
        {
            get
            {
                return gradientBorderColor;
            }
            set
            {
                gradientBorderColor = value;
                SetPaintColors();
                Invalidate();
            }
        }

        [Category("Appearance-Extended")]
        [Description("The color to use for the top portion of the gradient fill of the component.")]
        [DefaultValue(typeof(Color), "0x2C55B1")]
        public Color HotGradientTop
        {
            get
            {
                return _hotGradientTop;
            }
            set
            {
                _hotGradientTop = value;
                SetPaintColors();
                Invalidate();
            }
        }

        [Category("Appearance-Extended")]
        [Description("The color to use for the bottom portion of the gradient fill of the component.")]
        [DefaultValue(typeof(Color), "0x99C6F1")]
        public Color HotGradientBottom
        {
            get
            {
                return _hotGradientBottom;
            }
            set
            {
                _hotGradientBottom = value;
                SetPaintColors();
                Invalidate();
            }
        }

        [Category("Appearance-Extended")]
        [Description("The color to use for the bottom portion of the gradient fill of the component.")]
        public Color HotGradientBorderColour
        {
            get
            {
                return _hotGradientBorderColor;
            }
            set
            {
                _hotGradientBorderColor = value;
                SetPaintColors();
                Invalidate();
            }
        }

        [Category("Appearance-Extended")]
        [Description("The color to use for the bottom portion of the gradient fill of the component.")]
        public Color HotForeColour
        {
            get
            {
                return _hotForeColor;
            }
            set
            {
                _hotForeColor = value;
                Invalidate();
            }
        }
        [Category("Appearance-Extended")]
        [Description("The color to use for the top portion of the gradient fill of the component.")]
        [DefaultValue(typeof(Color), "0x2C55B1")]
        public Color PressedGradientTop
        {
            get
            {
                return _pressedGradientTop;
            }
            set
            {
                _pressedGradientTop = value;
                SetPaintColors();
                Invalidate();
            }
        }

        [Category("Appearance-Extended")]
        [Description("The color to use for the bottom portion of the gradient fill of the component.")]
        [DefaultValue(typeof(Color), "0x99C6F1")]
        public Color PressedGradientBottom
        {
            get
            {
                return _pressedGradientBottom;
            }
            set
            {
                _pressedGradientBottom = value;
                SetPaintColors();
                Invalidate();
            }
        }

        [Category("Appearance-Extended")]
        [Description("The color to use for the bottom portion of the gradient fill of the component.")]
        public Color PressedGradientBorderColour
        {
            get
            {
                return _pressedGradientBorderColor;
            }
            set
            {
                _pressedGradientBorderColor = value;
                SetPaintColors();
                Invalidate();
            }
        }

        [Category("Appearance-Extended")]
        [Description("The color to use for the bottom portion of the gradient fill of the component.")]
        public Color PressedForeColour
        {
            get
            {
                return _pressedForeColor;
            }
            set
            {
                _pressedForeColor = value;
                SetPaintColors();
                Invalidate();
            }
        }
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                SetPaintColors();
                Invalidate();
            }
        }

        #endregion

        #region Initialization and Modification

        protected override void OnCreateControl()
        {
            SuspendLayout();
            SetControlSizes();
            SetPaintColors();
            InitializeTimers();
            base.OnCreateControl();
            ResumeLayout();
        }

        protected override void OnResize(EventArgs e)
        {
            SetControlSizes();
            this.Invalidate();
            base.OnResize(e);
        }

        private void SetControlSizes()
        {
            int scalingDividend = Math.Min(ClientRectangle.Width, ClientRectangle.Height);
            buttonRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            rectCornerRadius = Math.Max(1, scalingDividend / 10);
            rectOutlineWidth = Math.Max(1, scalingDividend / 50);
            highlightRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, (ClientRectangle.Height - 1));
            highlightRectOffset = Math.Max(1, scalingDividend / 35);
            defaultHighlightOffset = Math.Max(1, scalingDividend / 35);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            /*
             if (!Enabled)
            {
                animateButtonHighlightedTimer.Stop();
                animateResumeNormalTimer.Stop();
            }
             */
            SetPaintColors();
            Invalidate();
            base.OnEnabledChanged(e);
        }

        private void SetPaintColors()
        {
            if (Enabled)
            {
                if (SystemInformation.HighContrast)
                {
                    paintGradientTop = Color.Black;
                    paintGradientBottom = Color.Black;
                    paintGradientBorderColor = Color.Black;
                    paintForeColor = Color.White;
                }
                else
                {
                    paintGradientTop = gradientTop;
                    paintGradientBottom = gradientBottom;
                    paintGradientBorderColor = gradientBorderColor;
                    paintForeColor = ForeColor;
                }
                if (isHotTracking) paintForeColor = _hotForeColor;
                if (isPressed) paintForeColor = _pressedForeColor;
            }
            else
            {
                if (SystemInformation.HighContrast)
                {
                    paintGradientTop = Color.Gray;
                    paintGradientBottom = Color.White;
                    paintGradientBorderColor = Color.Gray;
                    paintForeColor = Color.Black;
                }
                else
                {
                    int grayscaleColorTop = (int)(gradientTop.GetBrightness() * 255);
                    paintGradientTop = Color.FromArgb(grayscaleColorTop, grayscaleColorTop, grayscaleColorTop);
                    int grayscaleGradientBottom = (int)(gradientBottom.GetBrightness() * 255);
                    paintGradientBottom = Color.FromArgb(grayscaleGradientBottom, grayscaleGradientBottom, grayscaleGradientBottom);
                    int grayscaleForeColor = (int)(ForeColor.GetBrightness() * 255);
                    if (grayscaleForeColor > 255 / 2)
                    {
                        grayscaleForeColor -= 60;
                    }
                    else
                    {
                        grayscaleForeColor += 60;
                    }
                    paintForeColor = Color.FromArgb(grayscaleForeColor, grayscaleForeColor, grayscaleForeColor);
                }
            }
        }

        private void InitializeTimers()
        {
            /*
            animateButtonHighlightedTimer.Interval = 20;
            animateButtonHighlightedTimer.Tick += new EventHandler(animateButtonHighlightedTimer_Tick);
            animateResumeNormalTimer.Interval = 5;
            animateResumeNormalTimer.Tick += new EventHandler(animateResumeNormalTimer_Tick);
             */
        }

        #endregion

        #region Custom Painting

        private Point locPoint;
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            ButtonRenderer.DrawParentBackground(g, ClientRectangle, this);
            float Angle = 90F;

            if (!isHotTracking)
            {
                paintGradientTop = gradientTop;
                paintGradientBottom = gradientBottom;
                paintGradientBorderColor = gradientBorderColor;
                paintForeColor = ForeColor;
            }
            else
            {
                paintGradientTop = _hotGradientTop;
                paintGradientBottom = _hotGradientBottom;
                paintGradientBorderColor = _hotGradientBorderColor;
                paintForeColor = _hotForeColor;
            }
            if (isPressed)
            {
                paintGradientTop = _pressedGradientTop;
                paintGradientBottom = _pressedGradientBottom;
                paintGradientBorderColor = _pressedGradientBorderColor;
                paintForeColor = _pressedForeColor;
            }


            // Paint the outer rounded rectangle
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath outerPath = RoundedRectangle(buttonRect, rectCornerRadius, 0))
            {
                using (LinearGradientBrush outerBrush = new LinearGradientBrush(buttonRect, Color.White, Color.White, LinearGradientMode.Vertical))
                {
                    g.FillPath(outerBrush, outerPath);
                }
                using (Pen outlinePen = new Pen(paintGradientBorderColor, rectOutlineWidth))
                {
                    outlinePen.Alignment = PenAlignment.Inset;
                    g.DrawPath(outlinePen, outerPath);
                }
            }
            // If this is the default button, paint an additional highlight
            if (IsDefault)
            {
                using (GraphicsPath defaultPath = new GraphicsPath())
                {
                    defaultPath.AddPath(RoundedRectangle(buttonRect, rectCornerRadius, 0), false);
                    defaultPath.AddPath(RoundedRectangle(buttonRect, rectCornerRadius, defaultHighlightOffset), false);
                    using (PathGradientBrush defaultBrush = new PathGradientBrush(defaultPath))
                    {
                        defaultBrush.CenterColor = Color.FromArgb(50, Color.White);
                        defaultBrush.SurroundColors = new Color[] { Color.FromArgb(150, Color.White) };
                        g.FillPath(defaultBrush, defaultPath);
                    }
                }
            }
            // Paint the gel highlight
            using (GraphicsPath innerPath = RoundedRectangle(highlightRect, rectCornerRadius, highlightRectOffset))
            {
                //using (LinearGradientBrush innerBrush = new LinearGradientBrush(highlightRect, Color.FromArgb(highlightAlphaTop, Color.White), Color.FromArgb(highlightAlphaBottom, Color.White), LinearGradientMode.Vertical))
                //{
                g.FillPath(DrawingMethods.GetBrush(ClientRectangle, paintGradientTop, paintGradientBottom, DrawingMethods.PaletteColourStyle.Default, Angle, DrawingMethods.VisualOrientation.Top, false), innerPath);
                //g.FillPath(innerBrush, innerPath);
                //}
            }
            // Paint the text
            //TextRenderer.DrawText(g, Text, Font, buttonRect, paintForeColor, Color.Transparent, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            OnDrawTextAndImage(g);
        }

        private void OnDrawTextAndImage(Graphics g)
        {
            SolidBrush brushText;

            brushText = new SolidBrush(paintForeColor);

            StringFormat sf = Utility.GetStringFormat(this.TextAlign);
            sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            if (this.Image != null)
            {
                Rectangle rc = new Rectangle();
                Point ImagePoint = new Point(6, 4);
                switch (this.ImageAlign)
                {
                    case System.Drawing.ContentAlignment.MiddleRight:
                        {
                            rc.Width = this.ClientRectangle.Width - this.Image.Width - 8;
                            rc.Height = this.ClientRectangle.Height;
                            rc.X = 0;
                            rc.Y = 0;
                            ImagePoint.X = rc.Width;
                            ImagePoint.Y = this.ClientRectangle.Height / 2 - Image.Height / 2;
                            break;
                        }
                    case System.Drawing.ContentAlignment.TopCenter:
                        {
                            ImagePoint.Y = 2;
                            ImagePoint.X = (this.ClientRectangle.Width - this.Image.Width) / 2;
                            rc.Width = this.ClientRectangle.Width;
                            rc.Height = this.ClientRectangle.Height - this.Image.Height - 4;
                            rc.X = this.ClientRectangle.X;
                            rc.Y = this.Image.Height;

                            break;
                        }
                    case System.Drawing.ContentAlignment.MiddleCenter:
                        { // no text in this alignment
                            ImagePoint.X = (this.ClientRectangle.Width - this.Image.Width) / 2;
                            ImagePoint.Y = (this.ClientRectangle.Height - this.Image.Height) / 2;
                            rc.Width = 0;
                            rc.Height = 0;
                            rc.X = this.ClientRectangle.Width;
                            rc.Y = this.ClientRectangle.Height;
                            break;
                        }
                    default:
                        {
                            ImagePoint.X = 6;
                            ImagePoint.Y = this.ClientRectangle.Height / 2 - Image.Height / 2;
                            rc.Width = this.ClientRectangle.Width - this.Image.Width;
                            rc.Height = this.ClientRectangle.Height;
                            rc.X = this.Image.Width;
                            rc.Y = 0;
                            break;
                        }
                }
                ImagePoint.X += locPoint.X;
                ImagePoint.Y += locPoint.Y;
                if (this.Enabled)
                    g.DrawImage(this.Image, ImagePoint.X, ImagePoint.Y);
                else
                    System.Windows.Forms.ControlPaint.DrawImageDisabled(g, this.Image, ImagePoint.X, ImagePoint.Y, this.BackColor);
                if (System.Drawing.ContentAlignment.MiddleCenter != this.ImageAlign)
                {
                    g.DrawString(this.Text, this.Font, brushText, rc, sf);
                }
            }
            else
                g.DrawString(this.Text, this.Font, brushText, this.ClientRectangle, sf);

            brushText.Dispose();

            sf.Dispose();
        }
        #endregion

        private static GraphicsPath RoundedRectangle(Rectangle boundingRect, int cornerRadius, int margin)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(boundingRect.X + margin, boundingRect.Y + margin, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddArc(boundingRect.X + boundingRect.Width - margin - cornerRadius * 2, boundingRect.Y + margin, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddArc(boundingRect.X + boundingRect.Width - margin - cornerRadius * 2, boundingRect.Y + boundingRect.Height - margin - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddArc(boundingRect.X + margin, boundingRect.Y + boundingRect.Height - margin - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.AddLine(boundingRect.X + margin, boundingRect.Y + boundingRect.Height - margin - cornerRadius * 2, boundingRect.X + margin, boundingRect.Y + margin + cornerRadius);
            roundedRect.CloseFigure();
            return roundedRect;
        }


        #region Mouse and Keyboard Interaction

        protected override void OnMouseEnter(EventArgs e)
        {
            HighlightButton();
            base.OnMouseEnter(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            HighlightButton();
            base.OnGotFocus(e);
        }

        private void HighlightButton()
        {
            if (Enabled)
            {
                isHotTracking = true;
                /*
                animateResumeNormalTimer.Stop();
                animateButtonHighlightedTimer.Start();
                 */
            }
        }

        private void animateButtonHighlightedTimer_Tick(object sender, EventArgs e)
        {
            /*
            if (increasingAlpha)
            {
                if (100 <= highlightAlphaBottom)
                {
                    increasingAlpha = false;
                }
                else
                {
                    highlightAlphaBottom += 5;
                }
            }
            else
            {
                if (0 >= highlightAlphaBottom)
                {
                    increasingAlpha = true;
                }
                else
                {
                    highlightAlphaBottom -= 5;
                }
            }
             */
            //Hot
            isHotTracking = true;
            //
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            ResumeNormalButton();
            base.OnMouseLeave(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            ResumeNormalButton();
            base.OnLostFocus(e);
        }

        private void ResumeNormalButton()
        {
            if (Enabled)
            {
                //Hot
                isHotTracking = false;
                //
                /*
                animateButtonHighlightedTimer.Stop();
                animateResumeNormalTimer.Start();
                 */
            }
        }

        private void animateResumeNormalTimer_Tick(object sender, EventArgs e)
        {
            /*
             bool modified = false;
            if (highlightAlphaBottom > 0)
            {
                highlightAlphaBottom -= 5;
                modified = true;
            }
            if (highlightAlphaTop < 255)
            {
                highlightAlphaTop += 5;
                modified = true;
            }
            if (!modified)
            {
                animateResumeNormalTimer.Stop();
            }
             */
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            PressButton();
            base.OnMouseDown(mevent);
        }

        protected override void OnKeyDown(KeyEventArgs kevent)
        {
            if (kevent.KeyCode == Keys.Space || kevent.KeyCode == Keys.Return)
            {
                PressButton();
            }
            base.OnKeyDown(kevent);
        }

        private void PressButton()
        {
            if (Enabled)
            {
                //Hot
                isHotTracking = false;
                //
                //Hot
                isPressed = true;
                //
                /*
                animateButtonHighlightedTimer.Stop();
                animateResumeNormalTimer.Stop();
                //highlightRect.Location = new Point(0, ClientRectangle.Height / 2);
                highlightAlphaTop = 0;
                highlightAlphaBottom = 200;
                 */
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            ReleaseButton();
            if (DisplayRectangle.Contains(mevent.Location))
            {
                HighlightButton();
            }
            base.OnMouseUp(mevent);
        }

        protected override void OnKeyUp(KeyEventArgs kevent)
        {
            if (kevent.KeyCode == Keys.Space || kevent.KeyCode == Keys.Return)
            {
                ReleaseButton();
                if (IsDefault)
                {
                    HighlightButton();
                }
            }
            base.OnKeyUp(kevent);
        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            if (Enabled && (mevent.Button & MouseButtons.Left) == MouseButtons.Left && !ClientRectangle.Contains(mevent.Location))
            {
                //Hot
                isHotTracking = false;
                //
                ReleaseButton();
            }
            base.OnMouseMove(mevent);
        }

        private void ReleaseButton()
        {
            if (Enabled)
            {
                isPressed = false;
                highlightRect.Location = new Point(0, 0);
                /*
                highlightAlphaTop = 255;
                highlightAlphaBottom = 0;
                 */
            }
        }

        #endregion


    }
}