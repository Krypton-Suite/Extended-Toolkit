using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    /// <summary>
    /// Aqua Gauge Control - A Windows User Control.
    /// Author  : Ambalavanar Thirugnanam, Angelo Cresta
    /// Date    : 24th August 2007, 30 June 2008
    /// email   : ambalavanar.thiru@gmail.com, angelo@angelonline.net
    /// This is control is for free. You can use for any commercial or non-commercial purposes.
    /// [Please do no remove this header when using this control in your application.]
    /// </summary>
    [ToolboxBitmap(typeof(Timer)), ToolboxItem(false)]
    public class AquaGauge : UserControl
    {
        #region Design Code
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AquaGauge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "AquaGauge";
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private int _x, _y, _height, _width, _leadingZeros = 0, _miminumSize = 140, _noOfDivisions, _noOfSubDivisions;

        private float _fromAngle = 135F, _toAngle = 405F, _minValue, _maxValue = 100.0F, _threshold, _recommendedValue,
                      _currentValue, _glossinessAlpha = 75;

        private bool _requiresRedraw, _centerPointRotateEnable = true, _handOverCenterPoint = false, _digitBackPanelEnabled,
                     _digitBackPanelBorderEnabled, _enableTransparentBackground;

        private Image _backgroundImage;

        private Rectangle _rectangleImage;

        private CentrePointTypes _centrePointType = CentrePointTypes.ROUND;

        private CentrePointSizes _centrePointSize = CentrePointSizes.NORMAL;

        private HandTypes _handType = HandTypes.NORMAL;

        private Color _thresholdColour = Color.LawnGreen, _internalRimColour = Color.Gainsboro, _externalRimColour = Color.SlateGray,
                      _digitColour = Color.Black, _centrePointColour = Color.Black, _thinCalibrationColour = Color.Black,
                      _thickCalibrationColour = Color.Black, _handColour = Color.Black, _digitBackPanelColour = Color.Gray,
                      _digitBackPanelBorderColour = Color.Gray, _dialColour = Color.Lavender;

        private Font _dialTextTypeface;

        private string _dialText;

        private IContainer components = null;
        #endregion

        #region Properties
        /// <summary>
        /// Minimun Size
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Leading Zeros")]
        public int LeadingZeros
        {
            get => _leadingZeros;

            set
            {
                _leadingZeros = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }
        /// <summary>
        /// Minimun Size
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Minimum Size")]
        public int MiminumSize
        {
            get => _miminumSize;

            set
            {
                _miminumSize = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// Center Point Rotate Enable
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Center Point Type")]
        public bool CenterPointRotateEnable
        {
            get => _centerPointRotateEnable;

            set
            {
                _centerPointRotateEnable = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// Center Point Size
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Center Point Type")]
        public CentrePointTypes CentrePointType
        {
            get => _centrePointType;

            set
            {
                _centrePointType = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// Center Point Size
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Center Point Type")]
        public CentrePointSizes CentrePointSize
        {
            get => _centrePointSize;

            set
            {
                _centrePointSize = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// Hand Type
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Hand Type")]
        public HandTypes HandType
        {
            get => _handType;

            set
            {
                _handType = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// Threshold Color
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Color of the Hand")]
        public Color ThresholdColour
        {
            get => _thresholdColour;

            set
            {
                _thresholdColour = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }
        /// <summary>
        /// Internal Rim Color
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Color of the Hand")]
        public Color InternalRimColour
        {
            get => _internalRimColour;

            set
            {
                _internalRimColour = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// External Rim Color
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Color of the Hand")]
        public Color ExternalRimColour
        {
            get => _externalRimColour;

            set
            {
                _externalRimColour = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// Dial Text Font
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Color of the Hand")]
        public Font DialTextTypeface
        {
            get => _dialTextTypeface;

            set
            {
                _dialTextTypeface = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// Digit Color
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Color of the Hand")]
        public Color DigitColour
        {
            get => _digitColour;

            set
            {
                _digitColour = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// CenterPoint Color
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Color of the Hand")]
        public Color CenterPointColour
        {
            get => _centrePointColour;

            set
            {
                _centrePointColour = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// CenterPoint Color
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Color of the Hand")]
        public Color ThinCalibrationColour
        {
            get => _thinCalibrationColour;

            set
            {
                _thinCalibrationColour = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// CenterPoint Color
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Color of the Hand")]
        public Color ThickCalibrationColour
        {
            get => _thickCalibrationColour;

            set
            {
                _thickCalibrationColour = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// Draw Hand over CenterPoint
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Draw Hand over CenterPoint")]
        public bool HandOverCenterPoint
        {
            get => _handOverCenterPoint;

            set
            {
                _handOverCenterPoint = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// Color of the Hand
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Color of the Hand")]
        public Color HandColour
        {
            get => _handColour;

            set
            {
                _handColour = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// Digit Back Panel Color
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Color Digit Back Panel")]
        public Color DigitBackPanelColour
        {
            get => _digitBackPanelColour;

            set
            {
                _digitBackPanelColour = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// Digit Back Panel Border Color
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Color Digit Back Panel")]
        public Color DigitBackPanelBorderColour
        {
            get => _digitBackPanelBorderColour;

            set
            {
                _digitBackPanelBorderColour = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// Show Digit Back Panel
        /// </summary>
        [DefaultValue(true), Browsable(true), Category("Appearance-Extended"), Description("Show Digit BackPanel")]
        public bool DigitBackPanelEnabled
        {
            get => _digitBackPanelEnabled;

            set
            {
                _digitBackPanelEnabled = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }
        /// <summary>
        /// Show Digit Back Panel Border
        /// </summary>
        [DefaultValue(true), Browsable(true), Category("Appearance-Extended"), Description("Show Digit BackPanel Border")]
        public bool DigitBackPanelBorderEnabled
        {
            get => _digitBackPanelBorderEnabled;

            set
            {
                _digitBackPanelBorderEnabled = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }
        /// <summary>
        /// Minimum value on the scale
        /// </summary>
        [DefaultValue(0), Browsable(true), Category("Appearance-Extended"), Description("Minimum value on the scale")]
        public float MinValue
        {
            get => _minValue;

            set
            {
                if (value < _maxValue)
                {
                    _minValue = value;

                    if (_currentValue < _minValue)
                    {
                        _currentValue = _minValue;
                    }

                    if (_recommendedValue < _minValue)
                    {
                        _recommendedValue = _minValue;
                    }

                    _requiresRedraw = true;

                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Maximum value on the scale
        /// </summary>
        [DefaultValue(100), Browsable(true), Category("Appearance-Extended"), Description("Maximum value on the scale")]
        public float MaxValue
        {
            get => _maxValue;

            set
            {
                if (value > _minValue)
                {
                    _maxValue = value;

                    if (_currentValue > _maxValue)
                    {
                        _currentValue = _maxValue;
                    }

                    if (_recommendedValue > _maxValue)
                    {
                        _recommendedValue = _maxValue;
                    }

                    _requiresRedraw = true;

                    Invalidate();
                }
            }
        }


        /// <summary>
        /// Gets or Sets the Threshold area from the Recommended Value. (1-99%)
        /// </summary>
        [DefaultValue(25), Browsable(true), Category("Appearance-Extended"), Description("Gets or Sets the Threshold area from the Recommended Value. (1-99%)")]
        public float ThresholdPercent
        {
            get => _threshold;
            set
            {
                if (value > 0 && value < 100)
                {
                    _threshold = value;

                    _requiresRedraw = true;

                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Threshold value from which green area will be marked.
        /// </summary>
        [DefaultValue(25), Browsable(true), Category("Appearance-Extended"), Description("Threshold value from which green area will be marked.")]
        public float RecommendedValue
        {
            get => _recommendedValue;

            set
            {
                if (value > _minValue && value < _maxValue)
                {
                    _recommendedValue = value;

                    _requiresRedraw = true;

                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Value where the pointer will point to.
        /// </summary>
        [DefaultValue(0), Browsable(true), Category("Appearance-Extended"), Description("Value where the pointer will point to.")]
        public float Value
        {
            get => _currentValue;

            set
            {
                if (value >= _minValue && value <= _maxValue)
                {
                    _currentValue = value;

                    _requiresRedraw = true;

                    Refresh();
                }
            }
        }

        /// <summary>
        /// Background color of the dial
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Background color of the dial")]
        public Color DialColour
        {
            get => _dialColour;

            set
            {
                _dialColour = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// Glossiness strength. Range: 0-100
        /// </summary>
        [DefaultValue(75), Browsable(true), Category("Appearance-Extended"), Description("Glossiness strength. Range: 0-100")]
        public float Glossiness
        {
            get => (_glossinessAlpha * 100) / 220;

            set
            {
                float val = value;

                if (val > 100)
                {
                    value = 100;
                }

                if (val < 0)
                {
                    value = 0;
                }

                _glossinessAlpha = (value * 220) / 100;

                Refresh();
            }
        }

        /// <summary>
        /// Get or Sets the number of Divisions in the dial scale.
        /// </summary>
        [DefaultValue(10), Browsable(true), Category("Appearance-Extended"), Description("Get or Sets the number of Divisions in the dial scale.")]
        public int NoOfDivisions
        {
            get => _noOfDivisions;

            set
            {
                if (value > 1 && value < 25)
                {
                    _noOfDivisions = value;

                    _requiresRedraw = true;

                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or Sets the number of Sub Divisions in the scale per Division.
        /// </summary>
        [DefaultValue(3), Browsable(true), Category("Appearance-Extended"), Description("Gets or Sets the number of Sub Divisions in the scale per Division.")]
        public int NoOfSubDivisions
        {
            get => _noOfSubDivisions;

            set
            {
                if (value > 0 && value <= 10)
                {
                    _noOfSubDivisions = value;

                    _requiresRedraw = true;

                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or Sets the Text to be displayed in the dial
        /// </summary>
        [Browsable(true), Category("Appearance-Extended"), Description("Gets or Sets the Text to be displayed in the dial")]
        public string DialText
        {
            get => _dialText;

            set
            {
                _dialText = value;

                _requiresRedraw = true;

                Invalidate();
            }
        }

        /// <summary>
        /// Enables or Disables Transparent Background color.
        /// Note: Enabling this will reduce the performance and may make the control flicker.
        /// </summary>
        [DefaultValue(false), Browsable(true), Category("Appearance-Extended"), Description("Enables or Disables Transparent Background color. Note: Enabling this will reduce the performance and may make the control flicker.")]
        public bool EnableTransparentBackground
        {
            get => _enableTransparentBackground;

            set
            {
                _enableTransparentBackground = value;

                SetStyle(ControlStyles.OptimizedDoubleBuffer, !_enableTransparentBackground);

                _requiresRedraw = true;

                Refresh();
            }
        }
        #endregion

        #region Constructor
        public AquaGauge()
        {
            InitializeComponent();

            _x = 10;

            _y = 10;

            _width = Width;

            _height = Height;

            _noOfDivisions = 10;

            _noOfSubDivisions = 3;

            _dialTextTypeface = Font;

            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

            BackColor = Color.Transparent;

            _requiresRedraw = true;
        }
        #endregion

        #region Overrides
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            _width = Width - _x * 2;

            _height = Height - _y * 2;

            DrawPointer(e.Graphics, ((_width) / 2) + _x, ((_height) / 2) + _y);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (!_enableTransparentBackground)
            {
                base.OnPaintBackground(e);
            }

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            e.Graphics.FillRectangle(new SolidBrush(Color.Transparent), new Rectangle(0, 0, Width, Height));
            if (_backgroundImage == null || _requiresRedraw)
            {
                _backgroundImage = new Bitmap(Width, Height);
                Graphics g = Graphics.FromImage(_backgroundImage);
                g.SmoothingMode = SmoothingMode.HighQuality;
                _width = Width - _x * 2;
                _height = Height - _y * 2;
                _rectangleImage = new Rectangle(_x, _y, _width, _height);

                //Draw background color
                Brush backGroundBrush = new SolidBrush(Color.FromArgb(120, _dialColour));
                if (_enableTransparentBackground && Parent != null)
                {
                    float gg = _width / 60;
                    //g.FillEllipse(new SolidBrush(Parent.BackColor), -gg, -gg, Width+gg*2, Height+gg*2);
                }
                g.FillEllipse(backGroundBrush, _x, _y, _width, _height);

                //Draw Rim
                SolidBrush outlineBrush = new SolidBrush(Color.FromArgb(100, _externalRimColour));
                Pen outline = new Pen(outlineBrush, (float)(_width * .03));
                g.DrawEllipse(outline, _rectangleImage);
                Pen darkRim = new Pen(_externalRimColour);
                g.DrawEllipse(darkRim, _x, _y, _width, _height);

                //Draw Callibration
                DrawCalibration(g, _rectangleImage, ((_width) / 2) + _x, ((_height) / 2) + _y);

                //Draw Colored Rim
                Pen colorPen = new Pen(Color.FromArgb(190, _internalRimColour), Width / 40);
                Pen blackPen = new Pen(Color.FromArgb(250, Color.Black), Width / 200);
                int gap = (int)(Width * 0.03F);
                Rectangle rectg = new Rectangle(_rectangleImage.X + gap, _rectangleImage.Y + gap, _rectangleImage.Width - gap * 2, _rectangleImage.Height - gap * 2);
                g.DrawArc(colorPen, rectg, 135, 270);

                //Draw Threshold
                colorPen = new Pen(Color.FromArgb(200, _thresholdColour), Width / 50);
                rectg = new Rectangle(_rectangleImage.X + gap, _rectangleImage.Y + gap, _rectangleImage.Width - gap * 2, _rectangleImage.Height - gap * 2);
                float val = MaxValue - MinValue;
                val = (100 * (_recommendedValue - MinValue)) / val;
                val = ((_toAngle - _fromAngle) * val) / 100;
                val += _fromAngle;
                float stAngle = val - ((270 * _threshold) / 200);
                if (stAngle <= 135) stAngle = 135;
                float sweepAngle = ((270 * _threshold) / 100);
                if (stAngle + sweepAngle > 405) sweepAngle = 405 - stAngle;
                g.DrawArc(colorPen, rectg, stAngle, sweepAngle);

                //Draw Digital Value
                RectangleF digiRect = new RectangleF((float)Width / 2F - (float)_width / 5F, (float)_height / 1.2F, (float)_width / 2.5F, (float)Height / 9F);
                RectangleF digiFRect = new RectangleF(Width / 2 - _width / 7, (int)(_height / 1.18), _width / 4, Height / 12);

                //DigitBackPanel 
                if (_digitBackPanelEnabled)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(90, _digitBackPanelColour)), digiRect);
                    if (_digitBackPanelBorderEnabled)
                    {
                        g.DrawRectangle(new Pen(Color.FromArgb(120, _digitBackPanelBorderColour)), digiRect.X, digiRect.Y, digiRect.Width, digiRect.Height);
                    }
                }
                DisplayNumber(g, _currentValue, digiFRect);

                //draw Text
                g.SmoothingMode = SmoothingMode.AntiAlias;
                SizeF textSize = g.MeasureString(_dialText, _dialTextTypeface);
                RectangleF digiFRectText = new RectangleF(Width / 2 - textSize.Width / 2, (int)(_height / 1.5), textSize.Width, textSize.Height);
                g.DrawString(_dialText, _dialTextTypeface, new SolidBrush(ForeColor), digiFRectText);
                _requiresRedraw = false;
            }
            e.Graphics.DrawImage(_backgroundImage, _rectangleImage);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                cp.ExStyle |= 0x20;

                return cp;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            AquaGauge_Resize();

            _requiresRedraw = true;

            Refresh();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Draws the Pointer.
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        private void DrawPointer(Graphics gr, int cx, int cy)
        {
            float radius = Width / 2 - (Width * .12F);
            float val = MaxValue - MinValue;

            Image img = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(img);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            val = (100 * (_currentValue - MinValue)) / val;
            val = ((_toAngle - _fromAngle) * val) / 100;
            val += _fromAngle;


            //draw hand over CenterPoint
            if (_handOverCenterPoint)
            {
                //Draw Center Point
                Rectangle rect = new Rectangle(_x, _y, _width, _height);
                DrawCenterPoint(g, rect, ((_width) / 2) + _x, ((_height) / 2) + _y, val);
            }



            float angle = GetRadian(val);
            float gradientAngle = angle;

            PointF[] pts = new PointF[5];

            double AngleOffset = 0.02;
            float PositionOffset = 0.09F;

            switch (_handType)
            {
                case HandTypes.NORMAL:
                    AngleOffset = 0.02;
                    PositionOffset = 0.09F;
                    break;
                case HandTypes.MEDIUM:
                    AngleOffset = 0.01;
                    PositionOffset = 0.045F;
                    break;
                case HandTypes.SMALL:
                    AngleOffset = 0.001;
                    PositionOffset = 0.01F;
                    break;
            }


            pts[0].X = (float)(cx + radius * Math.Cos(angle));
            pts[0].Y = (float)(cy + radius * Math.Sin(angle));

            pts[4].X = (float)(cx + radius * Math.Cos(angle - AngleOffset));
            pts[4].Y = (float)(cy + radius * Math.Sin(angle - AngleOffset));

            angle = GetRadian((val + 20));
            pts[1].X = (float)(cx + (Width * PositionOffset) * Math.Cos(angle));
            pts[1].Y = (float)(cy + (Width * PositionOffset) * Math.Sin(angle));

            pts[2].X = cx;
            pts[2].Y = cy;

            angle = GetRadian((val - 20));
            pts[3].X = (float)(cx + (Width * PositionOffset) * Math.Cos(angle));
            pts[3].Y = (float)(cy + (Width * PositionOffset) * Math.Sin(angle));

            //hand part (bottom)
            Brush pointer = new SolidBrush(_handColour);
            g.FillPolygon(pointer, pts);

            PointF[] shinePts = new PointF[3];
            angle = GetRadian(val);
            shinePts[0].X = (float)(cx + radius * Math.Cos(angle));
            shinePts[0].Y = (float)(cy + radius * Math.Sin(angle));

            angle = GetRadian(val + 20);
            shinePts[1].X = (float)(cx + (Width * PositionOffset) * Math.Cos(angle));
            shinePts[1].Y = (float)(cy + (Width * PositionOffset) * Math.Sin(angle));

            shinePts[2].X = cx;
            shinePts[2].Y = cy;

            //hand part top
            LinearGradientBrush gpointer = new LinearGradientBrush(shinePts[0], shinePts[2], Color.SlateGray, _handColour);
            g.FillPolygon(gpointer, shinePts);

            //draw CenterPoint over hand
            if (!_handOverCenterPoint)
            {
                //Draw Center Point
                Rectangle rect = new Rectangle(_x, _y, _width, _height);
                DrawCenterPoint(g, rect, ((_width) / 2) + _x, ((_height) / 2) + _y, val);
            }

            //Draw Gloss
            DrawGloss(g);

            //  Draw image
            gr.DrawImage(img, 0, 0);
        }

        /// <summary>
        /// Draws the glossiness.
        /// </summary>
        /// <param name="g"></param>
        private void DrawGloss(Graphics g)
        {
            RectangleF glossRect = new RectangleF(
               _x + (float)(_width * 0.10),
               _y + (float)(_height * 0.07),
               (float)(_width * 0.80),
               (float)(_height * 0.7));
            LinearGradientBrush gradientBrush =
                new LinearGradientBrush(glossRect,
                Color.FromArgb((int)_glossinessAlpha, Color.White),
                Color.Transparent,
                LinearGradientMode.Vertical);
            g.FillEllipse(gradientBrush, glossRect);

            //TODO: Gradient from bottom
            glossRect = new RectangleF(
               _x + (float)(_width * 0.25),
               _y + (float)(_height * 0.77),
               (float)(_width * 0.50),
               (float)(_height * 0.2));
            int gloss = (int)(_glossinessAlpha / 3);
            gradientBrush =
                new LinearGradientBrush(glossRect,
                Color.Transparent, Color.FromArgb(gloss, BackColor),
                LinearGradientMode.Vertical);
            g.FillEllipse(gradientBrush, glossRect);

            gradientBrush.Dispose();
        }

        /// <summary>
        /// Draws the center point.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        private void DrawCenterPoint(Graphics g, Rectangle rect, int cX, int cY, float angle)
        {

            // try rotate the Center
            // Create new matrix
            Matrix mx = new Matrix();
            // Set the point
            Point pnt = new Point(cX, cY);

            GraphicsState State;
            //save state
            State = g.Save();

            if (_centerPointRotateEnable)
            {
                // Rotate angle degrees around a point
                mx.RotateAt(angle, pnt);
                // Apply the matrix to the graphic object
                g.Transform = mx;
            }

            float shiftBig = Width / 7;
            float shift = Width / 9;

            switch (_centrePointSize)
            {
                case CentrePointSizes.NORMAL:
                    shiftBig = Width / 7;
                    shift = Width / 9;
                    break;
                case CentrePointSizes.MEDIUM:
                    shiftBig = Width / 9;
                    shift = Width / 12;
                    break;
                case CentrePointSizes.SMALL:
                    shiftBig = Width / 11;
                    shift = Width / 14;
                    break;
                case CentrePointSizes.SMALLER:
                    shiftBig = Width / 20;
                    shift = Width / 30;
                    break;

            }

            //Outher
            RectangleF rectangleBig = new RectangleF(cX - (shiftBig / 2), cY - (shiftBig / 2), shiftBig, shiftBig);
            LinearGradientBrush brushBig = new LinearGradientBrush(rect, _centrePointColour, Color.FromArgb(100, _dialColour), LinearGradientMode.Vertical);

            //inner
            RectangleF rectangle = new RectangleF(cX - (shift / 2), cY - (shift / 2), shift, shift);
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.SlateGray, _centrePointColour, LinearGradientMode.ForwardDiagonal);

            //CenterPoint Type
            switch (_centrePointType)
            {
                case CentrePointTypes.ROUND:
                    g.FillEllipse(brushBig, rectangleBig);
                    g.FillEllipse(brush, rectangle);
                    break;
                case CentrePointTypes.SQUARE:
                    g.FillRectangle(brushBig, rectangleBig);
                    g.FillRectangle(brush, rectangle);
                    break;
            }


            // try rotate the Center back
            if (_centerPointRotateEnable)
            {
                // Rotate -angle degrees around a point
                mx.Invert();
                // Apply the matrix to the graphic object
                mx.RotateAt(-angle, pnt);
                //restore 
                g.Restore(State);
            }

            //dispose objects
            brush.Dispose();
            brushBig.Dispose();
        }

        /// <summary>
        /// Draws the Ruler
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        /// <param name="cX"></param>
        /// <param name="cY"></param>
        private void DrawCalibration(Graphics g, Rectangle rect, int cX, int cY)
        {
            int noOfParts = _noOfDivisions + 1;
            int noOfIntermediates = _noOfSubDivisions;
            float currentAngle = GetRadian(_fromAngle);
            int gap = (int)(Width * 0.01F);
            float shift = Width / 25;
            Rectangle rectangle = new Rectangle(rect.Left + gap, rect.Top + gap, rect.Width - gap, rect.Height - gap);

            float x, y, x1, y1, tx, ty, radius;
            radius = rectangle.Width / 2 - gap * 5;
            float totalAngle = _toAngle - _fromAngle;
            float incr = GetRadian(((totalAngle) / ((noOfParts - 1) * (noOfIntermediates + 1))));

            Pen thickPen = new Pen(_thickCalibrationColour, Width / 50);
            Pen thinPen = new Pen(_thinCalibrationColour, Width / 100);
            float rulerValue = MinValue;
            for (int i = 0; i <= noOfParts; i++)
            {
                //Draw Thick Line
                x = (float)(cX + radius * Math.Cos(currentAngle));
                y = (float)(cY + radius * Math.Sin(currentAngle));
                x1 = (float)(cX + (radius - Width / 20) * Math.Cos(currentAngle));
                y1 = (float)(cY + (radius - Width / 20) * Math.Sin(currentAngle));
                g.DrawLine(thickPen, x, y, x1, y1);

                //Draw Strings
                StringFormat format = new StringFormat();
                tx = (float)(cX + (radius - Width / 10) * Math.Cos(currentAngle));
                ty = (float)(cY - shift + (radius - Width / 10) * Math.Sin(currentAngle));
                Brush stringPen = new SolidBrush(ForeColor);
                StringFormat strFormat = new StringFormat(StringFormatFlags.NoClip);
                strFormat.Alignment = StringAlignment.Center;
                Font f = new Font(Font.FontFamily, (float)(Width / 23), Font.Style);
                g.DrawString(rulerValue.ToString() + "", f, stringPen, new PointF(tx, ty), strFormat);
                rulerValue += (float)((MaxValue - MinValue) / (noOfParts - 1));
                rulerValue = (float)Math.Round(rulerValue, 2);

                //currentAngle += incr;
                if (i == noOfParts - 1)
                    break;
                for (int j = 0; j <= noOfIntermediates; j++)
                {
                    //Draw thin lines 
                    currentAngle += incr;
                    x = (float)(cX + radius * Math.Cos(currentAngle));
                    y = (float)(cY + radius * Math.Sin(currentAngle));
                    x1 = (float)(cX + (radius - Width / 50) * Math.Cos(currentAngle));
                    y1 = (float)(cY + (radius - Width / 50) * Math.Sin(currentAngle));
                    g.DrawLine(thinPen, x, y, x1, y1);
                }
            }
        }

        /// <summary>
        /// Converts the given degree to radian.
        /// </summary>
        /// <param name="theta"></param>
        /// <returns></returns>
        public float GetRadian(float theta)
        {
            return theta * (float)Math.PI / 180F;
        }

        /// <summary>
        /// Displays the given number in the 7-Segement format.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="number"></param>
        /// <param name="drect"></param>
        private void DisplayNumber(Graphics g, float number, RectangleF drect)
        {
            try
            {

                /*
                float shift = 0;
                string num = number.ToString("000.00");
                num.PadLeft(3, '0');
                */
                //
                // The minimum string length is 4 characters:
                // "0.00". If the user wants leading zeros,
                // prepend to acheive the desired width.
                // The decimal point doesn't contribute to the width.
                string num = number.ToString("0.00");
                float shift = 0;

                while ((num.Length - 1) < _leadingZeros)
                {
                    num = "0" + num;
                }

                /* test on measurement
                //SizeF textSize = g.MeasureString(num, Font);
                float numLenght = num.Length * 10F * drect.Height / 13;
                float Xoffset = (width - numLenght) / 4;
                drect.Offset(-Xoffset, 0);
                */

                // If the width is less than the original value,
                // adjust the horizontal position to center.
                if ((num.Length - 1) < 5)
                {
                    shift = (5 - num.Length + 1) / 2 * (_width / 17);
                }
                else
                {
                    shift -= _width / 17;
                }
                //

                bool drawDPS = false;
                char[] chars = num.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    char c = chars[i];
                    if (i < chars.Length - 1 && chars[i + 1] == '.')
                        drawDPS = true;
                    else
                        drawDPS = false;
                    if (c != '.')
                    {
                        if (c == '-')
                        {
                            DrawDigit(g, -1, new PointF(drect.X + shift, drect.Y), drawDPS, drect.Height);
                        }
                        else
                        {
                            DrawDigit(g, Int16.Parse(c.ToString()), new PointF(drect.X + shift, drect.Y), drawDPS, drect.Height);
                        }
                        shift += 15 * _width / 250;
                    }
                    else
                    {
                        shift += 2 * _width / 250;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Draws a digit in 7-Segement format.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="number"></param>
        /// <param name="position"></param>
        /// <param name="dp"></param>
        /// <param name="height"></param>
        private void DrawDigit(Graphics g, int number, PointF position, bool dp, float height)
        {
            float width;
            width = 10F * height / 13;

            Pen outline = new Pen(Color.FromArgb(40, _dialColour));
            Pen fillPen = new Pen(_digitColour);

            #region Form Polygon Points
            //Segment A
            PointF[] segmentA = new PointF[5];
            segmentA[0] = segmentA[4] = new PointF(position.X + GetX(2.8F, width), position.Y + GetY(1F, height));
            segmentA[1] = new PointF(position.X + GetX(10, width), position.Y + GetY(1F, height));
            segmentA[2] = new PointF(position.X + GetX(8.8F, width), position.Y + GetY(2F, height));
            segmentA[3] = new PointF(position.X + GetX(3.8F, width), position.Y + GetY(2F, height));

            //Segment B
            PointF[] segmentB = new PointF[5];
            segmentB[0] = segmentB[4] = new PointF(position.X + GetX(10, width), position.Y + GetY(1.4F, height));
            segmentB[1] = new PointF(position.X + GetX(9.3F, width), position.Y + GetY(6.8F, height));
            segmentB[2] = new PointF(position.X + GetX(8.4F, width), position.Y + GetY(6.4F, height));
            segmentB[3] = new PointF(position.X + GetX(9F, width), position.Y + GetY(2.2F, height));

            //Segment C
            PointF[] segmentC = new PointF[5];
            segmentC[0] = segmentC[4] = new PointF(position.X + GetX(9.2F, width), position.Y + GetY(7.2F, height));
            segmentC[1] = new PointF(position.X + GetX(8.7F, width), position.Y + GetY(12.7F, height));
            segmentC[2] = new PointF(position.X + GetX(7.6F, width), position.Y + GetY(11.9F, height));
            segmentC[3] = new PointF(position.X + GetX(8.2F, width), position.Y + GetY(7.7F, height));

            //Segment D
            PointF[] segmentD = new PointF[5];
            segmentD[0] = segmentD[4] = new PointF(position.X + GetX(7.4F, width), position.Y + GetY(12.1F, height));
            segmentD[1] = new PointF(position.X + GetX(8.4F, width), position.Y + GetY(13F, height));
            segmentD[2] = new PointF(position.X + GetX(1.3F, width), position.Y + GetY(13F, height));
            segmentD[3] = new PointF(position.X + GetX(2.2F, width), position.Y + GetY(12.1F, height));

            //Segment E
            PointF[] segmentE = new PointF[5];
            segmentE[0] = segmentE[4] = new PointF(position.X + GetX(2.2F, width), position.Y + GetY(11.8F, height));
            segmentE[1] = new PointF(position.X + GetX(1F, width), position.Y + GetY(12.7F, height));
            segmentE[2] = new PointF(position.X + GetX(1.7F, width), position.Y + GetY(7.2F, height));
            segmentE[3] = new PointF(position.X + GetX(2.8F, width), position.Y + GetY(7.7F, height));

            //Segment F
            PointF[] segmentF = new PointF[5];
            segmentF[0] = segmentF[4] = new PointF(position.X + GetX(3F, width), position.Y + GetY(6.4F, height));
            segmentF[1] = new PointF(position.X + GetX(1.8F, width), position.Y + GetY(6.8F, height));
            segmentF[2] = new PointF(position.X + GetX(2.6F, width), position.Y + GetY(1.3F, height));
            segmentF[3] = new PointF(position.X + GetX(3.6F, width), position.Y + GetY(2.2F, height));

            //Segment G
            PointF[] segmentG = new PointF[7];
            segmentG[0] = segmentG[6] = new PointF(position.X + GetX(2F, width), position.Y + GetY(7F, height));
            segmentG[1] = new PointF(position.X + GetX(3.1F, width), position.Y + GetY(6.5F, height));
            segmentG[2] = new PointF(position.X + GetX(8.3F, width), position.Y + GetY(6.5F, height));
            segmentG[3] = new PointF(position.X + GetX(9F, width), position.Y + GetY(7F, height));
            segmentG[4] = new PointF(position.X + GetX(8.2F, width), position.Y + GetY(7.5F, height));
            segmentG[5] = new PointF(position.X + GetX(2.9F, width), position.Y + GetY(7.5F, height));

            //Segment DP
            #endregion

            #region Draw Segments Outline
            g.FillPolygon(outline.Brush, segmentA);
            g.FillPolygon(outline.Brush, segmentB);
            g.FillPolygon(outline.Brush, segmentC);
            g.FillPolygon(outline.Brush, segmentD);
            g.FillPolygon(outline.Brush, segmentE);
            g.FillPolygon(outline.Brush, segmentF);
            g.FillPolygon(outline.Brush, segmentG);
            #endregion

            #region Fill Segments
            //Fill SegmentA
            if (IsNumberAvailable(number, 0, 2, 3, 5, 6, 7, 8, 9))
            {
                g.FillPolygon(fillPen.Brush, segmentA);
            }

            //Fill SegmentB
            if (IsNumberAvailable(number, 0, 1, 2, 3, 4, 7, 8, 9))
            {
                g.FillPolygon(fillPen.Brush, segmentB);
            }

            //Fill SegmentC
            if (IsNumberAvailable(number, 0, 1, 3, 4, 5, 6, 7, 8, 9))
            {
                g.FillPolygon(fillPen.Brush, segmentC);
            }

            //Fill SegmentD
            if (IsNumberAvailable(number, 0, 2, 3, 5, 6, 8, 9))
            {
                g.FillPolygon(fillPen.Brush, segmentD);
            }

            //Fill SegmentE
            if (IsNumberAvailable(number, 0, 2, 6, 8))
            {
                g.FillPolygon(fillPen.Brush, segmentE);
            }

            //Fill SegmentF
            if (IsNumberAvailable(number, 0, 4, 5, 6, 7, 8, 9))
            {
                g.FillPolygon(fillPen.Brush, segmentF);
            }

            //Fill SegmentG
            if (IsNumberAvailable(number, 2, 3, 4, 5, 6, 8, 9, -1))
            {
                g.FillPolygon(fillPen.Brush, segmentG);
            }
            #endregion

            //Draw decimal point
            if (dp)
            {
                g.FillEllipse(fillPen.Brush, new RectangleF(
                    position.X + GetX(10F, width),
                    position.Y + GetY(12F, height),
                    width / 7,
                    width / 7));
            }
        }

        /// <summary>
        /// Gets Relative X for the given width to draw digit
        /// </summary>
        /// <param name="x"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        private float GetX(float x, float width)
        {
            return x * width / 12;
        }

        /// <summary>
        /// Gets relative Y for the given height to draw digit
        /// </summary>
        /// <param name="y"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private float GetY(float y, float height)
        {
            return y * height / 15;
        }

        /// <summary>
        /// Returns true if a given number is available in the given list.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="listOfNumbers"></param>
        /// <returns></returns>
        private bool IsNumberAvailable(int number, params int[] listOfNumbers)
        {
            if (listOfNumbers.Length > 0)
            {
                foreach (int i in listOfNumbers)
                {
                    if (i == number)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Restricts the size to make sure the height and width are always same.
        /// </summary>
        private void AquaGauge_Resize()
        {
            if ((Width < _miminumSize) || (Width < _miminumSize))
            {
                Width = _miminumSize;
                Height = _miminumSize;
            }

            if (Width > Height)
            {
                Width = Height;
                _width = _height;
            }
            if (Height > Width)
            {
                Height = Width;
                _height = _width;
            }

            /*
            if (oldWidth != Width)
            {
                Height = Width;
                oldHeight = Width;
            }
            if (oldHeight != Height)
            {
                Width = Height;
                oldWidth = Width;
            }
            */
        }
        #endregion
    }
}