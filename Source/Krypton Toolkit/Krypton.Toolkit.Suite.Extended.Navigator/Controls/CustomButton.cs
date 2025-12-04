#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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


namespace Krypton.Toolkit.Suite.Extended.Navigator;

[ToolboxBitmap(typeof(Button)), ToolboxItem(false)]
public class CustomButton : Button
{
    #region ... Fields ...

    private Color _gradientTop = Color.FromArgb(255, 44, 85, 177);
    private Color _gradientBottom = Color.FromArgb(255, 153, 198, 241);
    private Color _gradientBorderColor = Color.FromArgb(255, 153, 198, 241);
    private Color _hotGradientTop = Color.FromArgb(255, 234, 157);
    private Color _hotGradientBottom = Color.FromArgb(255, 213, 77);
    private Color _hotGradientBorderColor = Color.FromArgb(220, 205, 153);
    private Color _hotForeColor = Color.Gray;
    private Color _pressedGradientTop = Color.FromArgb(225, 178, 129);
    private Color _pressedGradientBottom = Color.FromArgb(235, 122, 5);
    private Color _pressedGradientBorderColor = Color.FromArgb(185, 150, 82);
    private Color _pressedForeColor = Color.DarkGray;
    private Color _paintGradientTop;
    private Color _paintGradientBottom;
    private Color _paintGradientBorderColor;
    private Color _paintForeColor;
    private Rectangle _buttonRect;
    private Rectangle _highlightRect;
    private int _rectCornerRadius;
    private float _rectOutlineWidth;
    private int _highlightRectOffset;
    private int _defaultHighlightOffset;
    /*
    private int highlightAlphaTop = 255;
    private int highlightAlphaBottom;
    private Timer animateButtonHighlightedTimer = new Timer();
    private Timer animateResumeNormalTimer = new Timer();
    private bool increasingAlpha;
     */
    private bool _isHotTracking;
    private bool _isPressed = false;

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
        get => _gradientTop;
        set
        {
            _gradientTop = value;
            SetPaintColors();
            Invalidate();
        }
    }

    [Category("Appearance-Extended")]
    [Description("The color to use for the bottom portion of the gradient fill of the component.")]
    [DefaultValue(typeof(Color), "0x99C6F1")]
    public Color GradientBottom
    {
        get => _gradientBottom;
        set
        {
            _gradientBottom = value;
            SetPaintColors();
            Invalidate();
        }
    }

    [Category("Appearance-Extended")]
    [Description("The color to use for the bottom portion of the gradient fill of the component.")]
    public Color GradientBorderColour
    {
        get => _gradientBorderColor;
        set
        {
            _gradientBorderColor = value;
            SetPaintColors();
            Invalidate();
        }
    }

    [Category("Appearance-Extended")]
    [Description("The color to use for the top portion of the gradient fill of the component.")]
    [DefaultValue(typeof(Color), "0x2C55B1")]
    public Color HotGradientTop
    {
        get => _hotGradientTop;
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
        get => _hotGradientBottom;
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
        get => _hotGradientBorderColor;
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
        get => _hotForeColor;
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
        get => _pressedGradientTop;
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
        get => _pressedGradientBottom;
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
        get => _pressedGradientBorderColor;
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
        get => _pressedForeColor;
        set
        {
            _pressedForeColor = value;
            SetPaintColors();
            Invalidate();
        }
    }
    public override Color ForeColor
    {
        get => base.ForeColor;
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
        _buttonRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
        _rectCornerRadius = Math.Max(1, scalingDividend / 10);
        _rectOutlineWidth = Math.Max(1, scalingDividend / 50);
        _highlightRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
        _highlightRectOffset = Math.Max(1, scalingDividend / 35);
        _defaultHighlightOffset = Math.Max(1, scalingDividend / 35);
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
                _paintGradientTop = Color.Black;
                _paintGradientBottom = Color.Black;
                _paintGradientBorderColor = Color.Black;
                _paintForeColor = Color.White;
            }
            else
            {
                _paintGradientTop = _gradientTop;
                _paintGradientBottom = _gradientBottom;
                _paintGradientBorderColor = _gradientBorderColor;
                _paintForeColor = ForeColor;
            }
            if (_isHotTracking)
            {
                _paintForeColor = _hotForeColor;
            }

            if (_isPressed)
            {
                _paintForeColor = _pressedForeColor;
            }
        }
        else
        {
            if (SystemInformation.HighContrast)
            {
                _paintGradientTop = Color.Gray;
                _paintGradientBottom = Color.White;
                _paintGradientBorderColor = Color.Gray;
                _paintForeColor = Color.Black;
            }
            else
            {
                int grayscaleColorTop = (int)(_gradientTop.GetBrightness() * 255);
                _paintGradientTop = Color.FromArgb(grayscaleColorTop, grayscaleColorTop, grayscaleColorTop);
                int grayscaleGradientBottom = (int)(_gradientBottom.GetBrightness() * 255);
                _paintGradientBottom = Color.FromArgb(grayscaleGradientBottom, grayscaleGradientBottom, grayscaleGradientBottom);
                int grayscaleForeColor = (int)(ForeColor.GetBrightness() * 255);
                if (grayscaleForeColor > 255 / 2)
                {
                    grayscaleForeColor -= 60;
                }
                else
                {
                    grayscaleForeColor += 60;
                }
                _paintForeColor = Color.FromArgb(grayscaleForeColor, grayscaleForeColor, grayscaleForeColor);
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

    private Point _locPoint;
    protected override void OnPaint(PaintEventArgs pevent)
    {
        Graphics g = pevent.Graphics;
        ButtonRenderer.DrawParentBackground(g, ClientRectangle, this);
        float angle = 90F;

        if (!_isHotTracking)
        {
            _paintGradientTop = _gradientTop;
            _paintGradientBottom = _gradientBottom;
            _paintGradientBorderColor = _gradientBorderColor;
            _paintForeColor = ForeColor;
        }
        else
        {
            _paintGradientTop = _hotGradientTop;
            _paintGradientBottom = _hotGradientBottom;
            _paintGradientBorderColor = _hotGradientBorderColor;
            _paintForeColor = _hotForeColor;
        }
        if (_isPressed)
        {
            _paintGradientTop = _pressedGradientTop;
            _paintGradientBottom = _pressedGradientBottom;
            _paintGradientBorderColor = _pressedGradientBorderColor;
            _paintForeColor = _pressedForeColor;
        }


        // Paint the outer rounded rectangle
        g.SmoothingMode = SmoothingMode.AntiAlias;
        using (GraphicsPath outerPath = RoundedRectangle(_buttonRect, _rectCornerRadius, 0))
        {
            using (LinearGradientBrush outerBrush = new LinearGradientBrush(_buttonRect, Color.White, Color.White, LinearGradientMode.Vertical))
            {
                g.FillPath(outerBrush, outerPath);
            }
            using (Pen outlinePen = new Pen(_paintGradientBorderColor, _rectOutlineWidth))
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
                defaultPath.AddPath(RoundedRectangle(_buttonRect, _rectCornerRadius, 0), false);
                defaultPath.AddPath(RoundedRectangle(_buttonRect, _rectCornerRadius, _defaultHighlightOffset), false);
                using (PathGradientBrush defaultBrush = new PathGradientBrush(defaultPath))
                {
                    defaultBrush.CenterColor = Color.FromArgb(50, Color.White);
                    defaultBrush.SurroundColors = [Color.FromArgb(150, Color.White)];
                    g.FillPath(defaultBrush, defaultPath);
                }
            }
        }
        // Paint the gel highlight
        using (GraphicsPath innerPath = RoundedRectangle(_highlightRect, _rectCornerRadius, _highlightRectOffset))
        {
            //using (LinearGradientBrush innerBrush = new LinearGradientBrush(highlightRect, Color.FromArgb(highlightAlphaTop, Color.White), Color.FromArgb(highlightAlphaBottom, Color.White), LinearGradientMode.Vertical))
            //{
            g.FillPath(DrawingMethods.GetBrush(ClientRectangle, _paintGradientTop, _paintGradientBottom, DrawingMethods.PaletteColourStyle.Default, angle, DrawingMethods.VisualOrientation.Top, false), innerPath);
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

        brushText = new SolidBrush(_paintForeColor);

        StringFormat sf = Utility.GetStringFormat(this.TextAlign);
        sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;

        g.SmoothingMode = SmoothingMode.AntiAlias;

        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        if (this.Image != null)
        {
            Rectangle rc = new Rectangle();
            Point imagePoint = new Point(6, 4);
            switch (this.ImageAlign)
            {
                case System.Drawing.ContentAlignment.MiddleRight:
                {
                    rc.Width = this.ClientRectangle.Width - this.Image.Width - 8;
                    rc.Height = this.ClientRectangle.Height;
                    rc.X = 0;
                    rc.Y = 0;
                    imagePoint.X = rc.Width;
                    imagePoint.Y = this.ClientRectangle.Height / 2 - Image.Height / 2;
                    break;
                }
                case System.Drawing.ContentAlignment.TopCenter:
                {
                    imagePoint.Y = 2;
                    imagePoint.X = (this.ClientRectangle.Width - this.Image.Width) / 2;
                    rc.Width = this.ClientRectangle.Width;
                    rc.Height = this.ClientRectangle.Height - this.Image.Height - 4;
                    rc.X = this.ClientRectangle.X;
                    rc.Y = this.Image.Height;

                    break;
                }
                case System.Drawing.ContentAlignment.MiddleCenter:
                { // no text in this alignment
                    imagePoint.X = (this.ClientRectangle.Width - this.Image.Width) / 2;
                    imagePoint.Y = (this.ClientRectangle.Height - this.Image.Height) / 2;
                    rc.Width = 0;
                    rc.Height = 0;
                    rc.X = this.ClientRectangle.Width;
                    rc.Y = this.ClientRectangle.Height;
                    break;
                }
                default:
                {
                    imagePoint.X = 6;
                    imagePoint.Y = this.ClientRectangle.Height / 2 - Image.Height / 2;
                    rc.Width = this.ClientRectangle.Width - this.Image.Width;
                    rc.Height = this.ClientRectangle.Height;
                    rc.X = this.Image.Width;
                    rc.Y = 0;
                    break;
                }
            }
            imagePoint.X += _locPoint.X;
            imagePoint.Y += _locPoint.Y;
            if (this.Enabled)
            {
                g.DrawImage(this.Image, imagePoint.X, imagePoint.Y);
            }
            else
            {
                System.Windows.Forms.ControlPaint.DrawImageDisabled(g, this.Image, imagePoint.X, imagePoint.Y, this.BackColor);
            }

            if (System.Drawing.ContentAlignment.MiddleCenter != this.ImageAlign)
            {
                g.DrawString(this.Text, this.Font, brushText, rc, sf);
            }
        }
        else
        {
            g.DrawString(this.Text, this.Font, brushText, this.ClientRectangle, sf);
        }

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
            _isHotTracking = true;
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
        _isHotTracking = true;
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
            _isHotTracking = false;
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
        if (kevent.KeyCode is Keys.Space or Keys.Return)
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
            _isHotTracking = false;
            //
            //Hot
            _isPressed = true;
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
        if (kevent.KeyCode is Keys.Space or Keys.Return)
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
            _isHotTracking = false;
            //
            ReleaseButton();
        }
        base.OnMouseMove(mevent);
    }

    private void ReleaseButton()
    {
        if (Enabled)
        {
            _isPressed = false;
            _highlightRect.Location = new Point(0, 0);
            /*
            highlightAlphaTop = 255;
            highlightAlphaBottom = 0;
             */
        }
    }

    #endregion


}