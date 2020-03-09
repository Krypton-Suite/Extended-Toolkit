using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    /// <summary>
    /// Summary description for KnobControl.
    /// </summary>
    //[ToolboxItem(false)]
    [DefaultEvent("ValueChanged"), ToolboxBitmap(typeof(Timer))]
    public class KryptonKnobControlEnhanced : UserControl
    {
        #region Enumerators
        public enum KnobPointerStyles
        {
            CIRCLE,
            LINE
        }
        #endregion

        #region Variables
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        #region Krypton
        private KryptonManager _kryptonManager = new KryptonManager();

        private PaletteBackInheritRedirect m_paletteBack;

        private PaletteBorderInheritRedirect m_paletteBorder;

        private PaletteContentInheritRedirect m_paletteContent;

        private IPalette _palette;

        private PaletteRedirect _paletteRedirect;
        #endregion

        private bool _scaleFontAutoSize = true, _drawDivInside, _showSmallScale = false, _showLargeScale = true, _isFocused = false, _isKnobRotating = false;

        private Brush _brushKnob, _brushKnobPointer;

        private Color _pointerColour = Color.SlateBlue, _knobBackColour = Color.LightGray, _knobBackColourBegin, _knobBackColourEnd, _knobMouseOverColour, _knobMouseDownColour, _pointerMouseOverColour, _pointerMouseDownColour, _scaleColour;

        private Font _scaleFont, _knobFont;

        private float _startAngle = 135, _endAngle = 405, _deltaAngle, _drawRatio = 1, _gradLength = 4;

        private Rectangle _rKnob;

        private Pen _dottedPen;

        private Point _pKnob;

        private Image _offScreenImage;

        private Graphics _gOffScreen;

        private LinearGradientMode _gradientMode;

        private KnobPointerStyles _pointerStyle = KnobPointerStyles.CIRCLE;

        private int _minimumValue = 0, _maximumValue = 100, _largeChange = 5, _smallChange = 1, _scaleDivisions, _scaleSubDivisions, _mouseWheelBarPartitions = 10, _value = 0;
        #endregion

        #region Properties
        /// <summary>
        /// Font of graduations
        /// </summary>
        [Description("Font of graduations")]
        [Category("KnobControl")]
        public Font ScaleFont
        {
            get { return _scaleFont; }

            set
            {
                _scaleFont = value;

                // Redraw
                SetDimensions();

                Invalidate();
            }
        }

        /// <summary>
        /// Autosize or not for font of graduations
        /// </summary>
        [Description("Autosize Font of graduations")]
        [Category("KnobControl")]
        [DefaultValue(true)]
        public bool ScaleFontAutoSize
        {
            get { return _scaleFontAutoSize; }

            set
            {
                _scaleFontAutoSize = value;

                // Redraw
                SetDimensions();

                Invalidate();
            }
        }

        /// <summary>
        /// Start angle to display graduations
        /// </summary>
        /// <value>The start angle to display graduations.</value>
        [Description("Set the start angle to display graduations (min 90)")]
        [Category("KnobControl")]
        [DefaultValue(135)]
        public float StartAngle
        {
            get { return _startAngle; }

            set
            {
                if (value >= 90 && value < _endAngle)
                {
                    _startAngle = value;

                    _deltaAngle = _endAngle - StartAngle;

                    // Redraw
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// End angle to display graduations
        /// </summary>
        /// <value>The end angle to display graduations.</value>
        [Description("Set the end angle to display graduations (max 450)")]
        [Category("KnobControl")]
        [DefaultValue(405)]
        public float EndAngle
        {
            get { return _endAngle; }
            set
            {
                if (value <= 450 && value > _startAngle)
                {
                    _endAngle = value;

                    _deltaAngle = _endAngle - _startAngle;

                    // Redraw
                    Invalidate();
                }
            }
        }


        /// <summary>
        /// Style of pointer: circle or line
        /// </summary>
        [Description("Set the style of the knob pointer: a circle or a line")]
        [Category("KnobControl")]
        public KnobPointerStyles KnobPointerStyle
        {
            get { return _pointerStyle; }

            set
            {
                _pointerStyle = value;

                // Redraw
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the mouse wheel bar partitions.
        /// </summary>
        /// <value>The mouse wheel bar partitions.</value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">exception thrown when value isn't greather than zero</exception>
        [Description("Set to how many parts is bar divided when using mouse wheel")]
        [Category("KnobControl")]
        [DefaultValue(10)]
        public int MouseWheelBarPartitions
        {
            get { return _mouseWheelBarPartitions; }
            set
            {
                if (value > 0)
                    _mouseWheelBarPartitions = value;
                else throw new ArgumentOutOfRangeException("MouseWheelBarPartitions has to be greather than zero");
            }
        }

        /// <summary>
        /// Draw string graduations inside or outside knob circle
        /// </summary>
        /// 
        [Description("Draw graduation strings inside or outside the knob circle")]
        [Category("KnobControl")]
        [DefaultValue(false)]
        public bool DrawDivInside
        {
            get { return _drawDivInside; }
            set
            {
                _drawDivInside = value;
                // Redraw
                SetDimensions();
                Invalidate();
            }
        }

        /// <summary>
        /// Color of graduations
        /// </summary>
        [Description("Colour of graduations")]
        [Category("KnobControl")]
        public Color ScaleColour
        {
            get { return _scaleColour; }
            set
            {
                _scaleColour = value;
                // Redraw
                Invalidate();
            }
        }

        /// <summary>
        /// Color of graduations
        /// </summary>
        [Description("Colour of knob")]
        [Category("KnobControl")]
        public Color KnobBackColour
        {
            get { return _knobBackColour; }
            set
            {
                _knobBackColour = value;

                SetDimensions();

                // Redraw
                Invalidate();
            }
        }

        [Description("Colour of knob")]
        [Category("KnobControl")]
        public Color KnobBackColourBegin
        {
            get { return _knobBackColourBegin; }
            set
            {
                _knobBackColourBegin = value;

                SetDimensions();

                // Redraw
                Invalidate();
            }
        }

        [Description("Colour of knob")]
        [Category("KnobControl")]
        public Color KnobBackColourEnd
        {
            get { return _knobBackColourEnd; }
            set
            {
                _knobBackColourEnd = value;

                SetDimensions();

                // Redraw
                Invalidate();
            }
        }

        /// <summary>
        /// How many divisions of maximum?
        /// </summary>
        [Description("Set the number of intervals between minimum and maximum")]
        [Category("KnobControl")]
        public int ScaleDivisions
        {
            get { return _scaleDivisions; }
            set
            {
                if (value > 1)
                {
                    _scaleDivisions = value;
                    // Redraw
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// How many subdivisions for each division
        /// </summary>
        [Description("Set the number of subdivisions between main divisions of graduation.")]
        [Category("KnobControl")]
        public int ScaleSubDivisions
        {
            get { return _scaleSubDivisions; }
            set
            {
                if (value > 0 && _scaleDivisions > 0 && (_maximumValue - _minimumValue) / (value * _scaleDivisions) > 0)
                {
                    _scaleSubDivisions = value;
                    // Redraw
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Shows Small Scale marking.
        /// </summary>
        [Description("Show or hide subdivisions of graduations")]
        [Category("KnobControl")]
        public bool ShowSmallScale
        {
            get { return _showSmallScale; }
            set
            {
                if (value == true)
                {
                    if (_scaleDivisions > 0 && _scaleSubDivisions > 0 && (_maximumValue - _minimumValue) / (_scaleSubDivisions * _scaleDivisions) > 0)
                    {
                        _showSmallScale = value;
                        // Redraw 
                        Invalidate();
                    }
                }
                else
                {
                    _showSmallScale = value;
                    // Redraw 
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Shows Large Scale marking
        /// </summary>
        [Description("Show or hide graduations")]
        [Category("KnobControl")]
        public bool ShowLargeScale
        {
            get { return _showLargeScale; }
            set
            {
                _showLargeScale = value;
                // need to redraw
                SetDimensions();
                // Redraw 
                Invalidate();
            }
        }

        /// <summary>
        /// Minimum Value for knob Control
        /// </summary>
        [Description("set the minimum value for the knob control")]
        [Category("KnobControl")]
        public int Minimum
        {
            get { return _minimumValue; }
            set
            {
                _minimumValue = value;
                // Redraw 
                Invalidate();
            }
        }

        /// <summary>
        /// Maximum value for knob control
        /// </summary>
        [Description("set the maximum value for the knob control")]
        [Category("KnobControl")]
        public int Maximum
        {
            get { return _maximumValue; }
            set
            {
                if (value > _minimumValue)
                {
                    _maximumValue = value;


                    if (_scaleSubDivisions > 0 && _scaleDivisions > 0 && (_maximumValue - _minimumValue) / (_scaleSubDivisions * _scaleDivisions) <= 0)
                    {
                        _showSmallScale = false;
                    }

                    SetDimensions();
                    // Redraw
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// value set for large change
        /// </summary>
        [Description("set the value for the large changes")]
        [Category("KnobControl")]
        public int LargeChange
        {
            get { return _largeChange; }
            set
            {
                _largeChange = value;
                // Redraw
                Invalidate();
            }
        }

        /// <summary>
        /// value set for small change.
        /// </summary>
        [Description("set the minimum value for the small changes")]
        [Category("KnobControl")]
        public int SmallChange
        {
            get { return _smallChange; }
            set
            {
                _smallChange = value;
                // Redraw
                Invalidate();
            }
        }

        /// <summary>
        /// Current Value of knob control
        /// </summary>
        [Description("set the current value of the knob control")]
        [Category("KnobControl")]
        public int Value
        {
            get { return _value; }
            set
            {
                if (value >= _minimumValue && value <= _maximumValue)
                {
                    _value = value;
                    // Redraw
                    Invalidate();
                    // call delegate  
                    OnValueChanged(this);
                }
            }
        }

        /// <summary>
        /// Color of the button
        /// </summary>
        [Description("set the color of the pointer")]
        [Category("KnobControl")]
        public Color PointerColour
        {
            get { return _pointerColour; }
            set
            {
                _pointerColour = value;

                SetDimensions();

                // Redraw
                Invalidate();
            }
        }
        #endregion

        #region Delegates
        public delegate void ValueChangedEventHandler(object sender);
        #endregion

        #region Events
        public event ValueChangedEventHandler ValueChanged;

        protected virtual void OnValueChanged(object sender) => ValueChanged?.Invoke(sender);
        #endregion

        #region Constructor
        public KryptonKnobControlEnhanced()
        {
            InitializeComponent();

            _dottedPen = new Pen(KnobExtendedRenderer.GetDarkColour(BackColor, 40)) { DashStyle = DashStyle.Dash, DashCap = DashCap.Flat };

            _knobFont = new Font(Font.FontFamily, Font.Size);

            _scaleFont = new Font(Font.FontFamily, Font.Size);

            _startAngle = 135;

            _endAngle = 405;

            _deltaAngle = _endAngle - _startAngle;

            _minimumValue = 0;

            _maximumValue = 100;

            _scaleDivisions = 11;

            _scaleSubDivisions = 4;

            _mouseWheelBarPartitions = 10;

            _scaleColour = Color.Black;

            _knobBackColour = _palette.ColorTable.ToolStripGradientBegin;

            InitiliseControlColours();

            SetDimensions();
        }
        #endregion

        #region Overrides     
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Setup graphics
            Graphics g = e.Graphics;

            // Set background colour of Image...
            _gOffScreen.Clear(BackColor);

            // Fill knob Background to give knob effect....
            _gOffScreen.FillEllipse(_brushKnob, _rKnob);

            // Set antialias effect on
            _gOffScreen.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw border of knob
            _gOffScreen.DrawEllipse(new Pen(BackColor), _rKnob);

            // If control is focused
            if (_isFocused) _gOffScreen.DrawEllipse(_dottedPen, _rKnob);

            // Draw the indicator
            DrawPointer(_gOffScreen);

            // Draw small and large scale
            DrawDivisions(_gOffScreen, _rKnob);

            // Draw image on screen
            g.DrawImage(_offScreenImage, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (KnobExtendedRenderer.IsPointinRectangle(new Point(e.X, e.Y), _rKnob))
            {
                if (_isFocused)
                {
                    _isKnobRotating = true;
                }
                else
                {
                    Focus();

                    _isFocused = true;

                    _isKnobRotating = true;

                    Invalidate();
                }
            }
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Left:
                    return true;
            }

            return base.IsInputKey(keyData);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (KnobExtendedRenderer.IsPointinRectangle(new Point(e.X, e.Y), _rKnob))
            {
                if (_isFocused && _isKnobRotating)
                {
                    Value = GetValueFromPosition(new Point(e.X, e.Y));
                }
                else
                {
                    _isFocused = true;

                    _isKnobRotating = true;
                }
            }

            Cursor = Cursors.Default;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _isKnobRotating)
            {
                Cursor = Cursors.Hand;

                Point p = new Point(e.X, e.Y);

                int posVal = GetValueFromPosition(p);

                Value = posVal;
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (_isFocused && _isKnobRotating && KnobExtendedRenderer.IsPointinRectangle(new Point(e.X, e.Y), _rKnob))
            {
                // the Delta value is always 120, as explained in MSDN
                int v = (e.Delta / 120) * (_maximumValue - _minimumValue) / _mouseWheelBarPartitions;

                SetProperValue(Value + v);

                // Avoid to send MouseWheel event to the parent container
                ((HandledMouseEventArgs)e).Handled = true;
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            // unselect the control (remove dotted border)
            _isFocused = false;

            _isKnobRotating = false;

            Invalidate();

            base.OnLeave(new EventArgs());
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (_isFocused)
            {
                //--------------------------------------------------------
                // Handles knob rotation with up,down,left and right keys 
                //--------------------------------------------------------
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Right)
                {
                    if (_value < _maximumValue) Value = _value + 1;

                    Refresh();
                }
                else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Left)
                {
                    if (_value > _minimumValue) Value = _value - 1;

                    Refresh();
                }
            }
        }
        #endregion

        #region Virtual functions		

        #endregion

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // KryptonKnobControlEnhanced
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "KryptonKnobControlEnhanced";
            this.Size = new System.Drawing.Size(91, 91);
            this.Resize += new System.EventHandler(this.KryptonKnobControlEnhanced_Resize);
            this.ResumeLayout(false);

        }
        #endregion

        #region Methods      
        private void InitiliseControlColours()
        {
            /*
            BorderStyle = BorderStyle.None;
            
            KnobColour = _palette.ColorTable.OverflowButtonGradientBegin;
            
            KnobBorderColour = _palette.ColorTable.ToolStripGradientBegin;
            
            ForeColor = _palette.ColorTable.MenuItemText;
            
            KnobBackColour = _palette.ColorTable.MenuStripGradientBegin;
            
            MouseOverKnobColour = _palette.ColorTable.ButtonCheckedGradientBegin;
            
            MouseDownKnobColour = _palette.ColorTable.ButtonPressedGradientBegin;
            */
        }

        /// <summary>
        /// Draw the pointer of the knob (a small button inside the main button)
        /// </summary>
        /// <param name="g"></param>
        private void DrawPointer(Graphics g)
        {
            try
            {
                float radius = (float)(_rKnob.Width / 2);

                // Draw a line
                if (_pointerStyle == KnobPointerStyles.LINE)
                {
                    int l = (int)radius / 2, w = l / 4;
                    Point[] pt = GetKnobLine(g, l);

                    g.DrawLine(new Pen(_pointerColour, w), pt[0], pt[1]);

                }
                else
                {
                    // Draw a circle
                    int w = 0, h = 0, l = 0;

                    string strvalmax = _maximumValue.ToString(), strvalmin = _minimumValue.ToString(), strval = strvalmax.Length > strvalmin.Length ? strvalmax : strvalmin;

                    double val = Convert.ToDouble(strval);

                    String str = String.Format("{0,0:D}", (int)val);

                    float fSize;
                    SizeF strsize;
                    if (_scaleFontAutoSize)
                    {
                        // Use font family = _scaleFont, but size = automatic
                        fSize = (float)(6F * _drawRatio);
                        if (fSize < 6) fSize = 6;

                        strsize = g.MeasureString(str, new Font(_scaleFont.FontFamily, fSize));
                    }
                    else
                    {
                        // Use font family = _scaleFont, but size = fixed
                        fSize = _scaleFont.Size;

                        strsize = g.MeasureString(str, _scaleFont);
                    }

                    int strw = (int)strsize.Width, strh = (int)strsize.Height;

                    w = Math.Max(strw, strh);

                    // radius of small circle
                    l = (int)radius - w / 2;

                    h = w;

                    Point Arrow = GetKnobPosition(l - 2); // Remove 2 pixels to offset the small circle inside the knob

                    // Draw pointer arrow that shows knob position             
                    Rectangle rPointer = new Rectangle(Arrow.X - w / 2, Arrow.Y - w / 2, w, h);


                    //Utility.DrawInsetCircle(ref Gr, rPointer, new Pen(_PointerColor));
                    KnobExtendedRenderer.DrawInsetCircle(ref g, rPointer, new Pen(KnobExtendedRenderer.GetLightColour(_pointerColour, 55)));

                    g.FillEllipse(_brushKnobPointer, rPointer);

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        /// <summary>
        /// Draw graduations
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rc">Knob rectangle</param>
        /// <returns></returns>
        private bool DrawDivisions(Graphics g, RectangleF rc)
        {
            if (this == null)
                return false;

            float cx = _pKnob.X;
            float cy = _pKnob.Y;

            float w = rc.Width;
            float h = rc.Height;

            float tx;
            float ty;

            float incr = KnobExtendedRenderer.GetRadian((_endAngle - _startAngle) / ((_scaleDivisions - 1) * (_scaleSubDivisions + 1)));
            float currentAngle = KnobExtendedRenderer.GetRadian(_startAngle);

            float radius = (float)(rc.Width / 2);
            float rulerValue = (float)_minimumValue;

            Font font;

            Pen penL = new Pen(_scaleColour, (2 * _drawRatio));
            Pen penS = new Pen(_scaleColour, (1 * _drawRatio));

            SolidBrush br = new SolidBrush(_scaleColour);

            PointF ptStart = new PointF(0, 0);
            PointF ptEnd = new PointF(0, 0);
            int n = 0;

            if (_showLargeScale)
            {
                // Size of maxi string
                string strvalmax = _maximumValue.ToString();
                string strvalmin = _minimumValue.ToString();
                string strval = strvalmax.Length > strvalmin.Length ? strvalmax : strvalmin;
                double val = Convert.ToDouble(strval);
                //double val = _maximumValue;
                String str = String.Format("{0,0:D}", (int)val);
                float fSize;
                SizeF strsize;

                if (_scaleFontAutoSize)
                {
                    fSize = (float)(6F * _drawRatio);
                    if (fSize < 6)
                        fSize = 6;
                }
                else
                {
                    fSize = _scaleFont.Size;
                }

                font = new Font(_scaleFont.FontFamily, fSize);
                strsize = g.MeasureString(str, font);

                int strw = (int)strsize.Width;
                int strh = (int)strsize.Height;
                int wmax = Math.Max(strw, strh);

                float l = 0;
                _gradLength = 2 * _drawRatio;

                for (; n < _scaleDivisions; n++)
                {
                    // draw divisions
                    ptStart.X = (float)(cx + (radius) * Math.Cos(currentAngle));
                    ptStart.Y = (float)(cy + (radius) * Math.Sin(currentAngle));

                    ptEnd.X = (float)(cx + (radius + _gradLength) * Math.Cos(currentAngle));
                    ptEnd.Y = (float)(cy + (radius + _gradLength) * Math.Sin(currentAngle));

                    g.DrawLine(penL, ptStart, ptEnd);


                    //Draw graduation values                                                                                
                    val = Math.Round(rulerValue);
                    str = String.Format("{0,0:D}", (int)val);

                    // If autosize
                    if (_scaleFontAutoSize)
                        strsize = g.MeasureString(str, new Font(_scaleFont.FontFamily, fSize));
                    else
                        strsize = g.MeasureString(str, new Font(_scaleFont.FontFamily, _scaleFont.Size));



                    if (_drawDivInside)
                    {
                        // graduations values inside the knob                        
                        l = (int)radius - (wmax / 2) - 2;

                        tx = (float)(cx + l * Math.Cos(currentAngle));
                        ty = (float)(cy + l * Math.Sin(currentAngle));

                    }
                    else
                    {
                        // graduation values outside the knob 
                        //l = (Width / 2) - (wmax / 2) ;
                        l = radius + _gradLength + wmax / 2;

                        tx = (float)(cx + l * Math.Cos(currentAngle));
                        ty = (float)(cy + l * Math.Sin(currentAngle));
                    }

                    g.DrawString(str,
                                    font,
                                    br,
                                    tx - (float)(strsize.Width * 0.5),
                                    ty - (float)(strsize.Height * 0.5));



                    rulerValue += (float)((_maximumValue - _minimumValue) / (_scaleDivisions - 1));

                    if (n == _scaleDivisions - 1)
                    {
                        break;
                    }


                    // Subdivisions
                    #region SubDivisions

                    if (_scaleDivisions <= 0)
                        currentAngle += incr;
                    else
                    {

                        for (int j = 0; j <= _scaleSubDivisions; j++)
                        {
                            currentAngle += incr;

                            // if user want to display small graduations
                            if (_showSmallScale)
                            {
                                ptStart.X = (float)(cx + radius * Math.Cos(currentAngle));
                                ptStart.Y = (float)(cy + radius * Math.Sin(currentAngle));
                                ptEnd.X = (float)(cx + (radius + _gradLength / 2) * Math.Cos(currentAngle));
                                ptEnd.Y = (float)(cy + (radius + _gradLength / 2) * Math.Sin(currentAngle));

                                g.DrawLine(penS, ptStart, ptEnd);
                            }
                        }
                    }
                    #endregion                    
                }
                font.Dispose();
            }

            return true;
        }

        /// <summary>
        /// Set position of button inside its rectangle to insure that divisions will fit.
        /// </summary>
        private void SetDimensions()
        {
            Font font;

            // Rectangle
            float x, y, w, h;
            x = 0;
            y = 0;
            w = h = Width;

            // Calculate ratio
            _drawRatio = w / 150;
            if (_drawRatio == 0.0) _drawRatio = 1;


            if (_showLargeScale)
            {
                Graphics Gr = this.CreateGraphics();
                string strvalmax = _maximumValue.ToString();
                string strvalmin = _minimumValue.ToString();
                string strval = strvalmax.Length > strvalmin.Length ? strvalmax : strvalmin;
                double val = Convert.ToDouble(strval);

                //double val = _maximumValue;
                String str = String.Format("{0,0:D}", (int)val);

                float fSize = _scaleFont.Size;

                if (_scaleFontAutoSize)
                {
                    fSize = (float)(6F * _drawRatio);
                    if (fSize < 6)
                        fSize = 6;
                    font = new Font(_scaleFont.FontFamily, fSize);
                }
                else
                {
                    fSize = _scaleFont.Size;
                    font = new Font(_scaleFont.FontFamily, _scaleFont.Size);
                }

                SizeF strsize = Gr.MeasureString(str, font);

                // Graduations outside
                _gradLength = 4 * _drawRatio;

                if (_drawDivInside)
                {
                    // Graduations inside : remove only 2*8 pixels
                    // x = y = 8;
                    x = y = _gradLength;
                    w = Width - 2 * x;
                }
                else
                {
                    // remove 2 * size of text and length of graduation
                    //gradLength = 4 * drawRatio;
                    int strw = (int)strsize.Width;
                    int strh = (int)strsize.Height;

                    int max = Math.Max(strw, strh);
                    x = max;
                    y = max;
                    w = (int)(Width - 2 * max - _gradLength);
                }

                if (w <= 0)
                    w = 1;
                h = w;

                // Rectangle of the rounded knob
                _rKnob = new Rectangle((int)x, (int)y, (int)w, (int)h);

                Gr.Dispose();
            }
            else
            {
                _rKnob = new Rectangle(0, 0, Width, Height);
            }


            // Center of knob
            _pKnob = new Point(_rKnob.X + _rKnob.Width / 2, _rKnob.Y + _rKnob.Height / 2);

            // create offscreen image                                 
            _offScreenImage = new Bitmap(Width, Height);

            // create offscreen graphics                              
            _gOffScreen = Graphics.FromImage(_offScreenImage);


            // Depends on retangle dimensions
            // create LinearGradientBrush for creating knob            
            _brushKnob = new LinearGradientBrush(_rKnob, KnobExtendedRenderer.GetLightColour(_knobBackColour, 55), KnobExtendedRenderer.GetDarkColour(_knobBackColour, 55), LinearGradientMode.ForwardDiagonal);

            // create LinearGradientBrush for knobPointer                
            _brushKnobPointer = new LinearGradientBrush(_rKnob, KnobExtendedRenderer.GetLightColour(_pointerColour, 55), KnobExtendedRenderer.GetDarkColour(_pointerColour, 55), LinearGradientMode.ForwardDiagonal);
        }

        /// <summary>
        /// Sets the trackbar value so that it wont exceed allowed range.
        /// </summary>
        /// <param name="val">The value.</param>
        private void SetProperValue(int val)
        {
            if (val < _minimumValue) Value = _minimumValue;
            else if (val > _maximumValue) Value = _maximumValue;
            else Value = val;
        }

        /// <summary>
        /// gets knob position that is to be drawn on control minus a small amount in order that the knob position stay inside the circle.
        /// </summary>
        /// <returns>Point that describes current knob position</returns>
        private Point GetKnobPosition(int l)
        {
            float cx = _pKnob.X;
            float cy = _pKnob.Y;

            // FAB: 21/08/18            
            float degree = _deltaAngle * (this.Value - _minimumValue) / (_maximumValue - _minimumValue);

            degree = KnobExtendedRenderer.GetRadian(degree + _startAngle);

            Point Pos = new Point(0, 0)
            {
                X = (int)(cx + l * Math.Cos(degree)),
                Y = (int)(cy + l * Math.Sin(degree))
            };

            return Pos;
        }

        /// <summary>
        /// return 2 points of a line starting from the center of the knob to the periphery
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        private Point[] GetKnobLine(Graphics Gr, int l)
        {
            Point[] pret = new Point[2];

            float cx = _pKnob.X;
            float cy = _pKnob.Y;


            float radius = (float)(_rKnob.Width / 2);

            // FAB: 21/08/18            
            float degree = _deltaAngle * (this.Value - _minimumValue) / (_maximumValue - _minimumValue);

            degree = KnobExtendedRenderer.GetRadian(degree + _startAngle);


            double val = _maximumValue;
            String str = String.Format("{0,0:D}", (int)val);
            float fSize;
            SizeF strsize;

            if (!_scaleFontAutoSize)
            {
                fSize = _scaleFont.Size;
                strsize = Gr.MeasureString(str, _scaleFont);
            }
            else
            {
                fSize = (float)(6F * _drawRatio);
                if (fSize < 6)
                    fSize = 6;

                _knobFont = new Font(_scaleFont.FontFamily, fSize);
                strsize = Gr.MeasureString(str, _knobFont);
            }

            int strw = (int)strsize.Width;
            int strh = (int)strsize.Height;
            int w = Math.Max(strw, strh);


            Point Pos = new Point(0, 0);

            if (_drawDivInside)
            {
                // Center (from)
                Pos.X = (int)(cx + (radius / 10) * Math.Cos(degree));
                Pos.Y = (int)(cy + (radius / 10) * Math.Sin(degree));
                pret[0] = new Point(Pos.X, Pos.Y);

                // External (to)
                Pos.X = (int)(cx + (radius - w) * Math.Cos(degree));
                Pos.Y = (int)(cy + (radius - w) * Math.Sin(degree));
                pret[1] = new Point(Pos.X, Pos.Y);
            }
            else
            {
                // Internal (from)
                Pos.X = (int)(cx + (radius - _drawRatio * 10 - l) * Math.Cos(degree));
                Pos.Y = (int)(cy + (radius - _drawRatio * 10 - l) * Math.Sin(degree));


                pret[0] = new Point(Pos.X, Pos.Y);

                // External (to)
                Pos.X = (int)(cx + (radius - 4) * Math.Cos(degree));
                Pos.Y = (int)(cy + (radius - 4) * Math.Sin(degree));

                pret[1] = new Point(Pos.X, Pos.Y);
            }
            return pret;
        }

        /// <summary>
        /// converts geometrical position into value..
        /// </summary>
        /// <param name="p">Point that is to be converted</param>
        /// <returns>Value derived from position</returns>
        private int GetValueFromPosition(Point p)
        {
            float degree = 0;
            int v = 0;

            if (p.X <= _pKnob.X)
            {
                degree = (float)(_pKnob.Y - p.Y) / (float)(_pKnob.X - p.X);
                degree = (float)Math.Atan(degree);

                degree = (degree) * (float)(180 / Math.PI) + (180 - _startAngle);

            }
            else if (p.X > _pKnob.X)
            {
                degree = (float)(p.Y - _pKnob.Y) / (float)(p.X - _pKnob.X);
                degree = (float)Math.Atan(degree);

                degree = (degree) * (float)(180 / Math.PI) + 360 - _startAngle;
            }

            // round to the nearest value (when you click just before or after a graduation!)
            // FAB: 25/08/18            
            v = _minimumValue + (int)Math.Round(degree * (_maximumValue - _minimumValue) / _deltaAngle);

            if (v > _maximumValue) v = _maximumValue;
            if (v < _minimumValue) v = _minimumValue;
            return v;
        }
        #endregion

        private void KryptonKnobControlEnhanced_Resize(object sender, EventArgs e)
        {
            Height = Width;

            SetDimensions();

            Invalidate();
        }
    }
}