#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Common
{
    public delegate void ValueChangedEventHandler(object sender, KnobValueChangedEventArgs e);

    [DefaultEvent("ValueChanged"), ToolboxBitmap(typeof(System.Windows.Forms.Timer)), ToolboxItem(false)]
    public class CommonKryptonKnobControlEnhanced : UserControl
    {
        #region Enumerations
        public enum KnobPointerStyles
        {
            CIRCLE,
            LINE
        }
        #endregion

        #region Designer Code
        private Container components = null;
        #endregion

        #region Variables
        private bool _scaleTypefaceAutoSize = true, _drawDivInside, _showSmallScale = false, _showLargeScale = true, _isFocused = false, _isKnobRotating = false;

        private Brush _brushKnob, _brushKnobPointer;

        private Color _pointerColour = Color.SlateBlue, _knobBackColour = Color.LightGray, _scaleColour = Color.Black;

        private int _minimum = 0, _maximum = 25, _largeChange = 5, _smallChange = 1, _scaleDivisions, _scaleSubDivisions, _mouseWheelBarPartitions = 10, _value = 0;

        private Font _scaleTypeface, _knobTypeface;

        private float _startAngle = 135, _endAngle = 405, _deltaAngle, _drawRatio = 1, _gradLength = 4;

        private Rectangle _rKnob;

        private Point _pKnob;

        private Pen _dottedPen;

        private Image _offScreenImage;

        private Graphics _gOffScreen;

        private KnobPointerStyles _pointerStyle = KnobPointerStyles.CIRCLE;

        #region Krypton
        private KryptonManager _manager = new KryptonManager();

        private PaletteBackInheritRedirect _paletteBack;

        private PaletteBorderInheritRedirect _paletteBorder;

        private PaletteContentInheritRedirect _paletteContent;

        private IPalette _palette;

        private PaletteRedirect _paletteRedirect;
        #endregion

        #endregion

        #region Events
        //-------------------------------------------------------
        // An event that clients can use to be notified whenever 
        // the Value is Changed.                                 
        //-------------------------------------------------------
        public event ValueChangedEventHandler ValueChanged;

        //-------------------------------------------------------
        // Invoke the ValueChanged event; called  when value     
        // is changed                                            
        //-------------------------------------------------------
        protected virtual void OnValueChanged(object sender, KnobValueChangedEventArgs e) => ValueChanged?.Invoke(sender, e);
        #endregion

        #region Properties
        /// <summary>
        /// Font of graduations
        /// </summary>
        [Description("Font of graduations")]
        [Category("KryptonKnobControlEnhanced")]
        public Font ScaleTypeface
        {
            get { return _scaleTypeface; }
            set
            {
                _scaleTypeface = value;
                // Redraw
                SetDimensions();
                Invalidate();
            }
        }

        /// <summary>
        /// Autosize or not for font of graduations
        /// </summary>
        [Description("Autosize Font of graduations")]
        [Category("KryptonKnobControlEnhanced")]
        [DefaultValue(true)]
        public bool ScaleTypefaceAutoSize
        {
            get { return _scaleTypefaceAutoSize; }
            set
            {
                _scaleTypefaceAutoSize = value;
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
        [Category("KryptonKnobControlEnhanced")]
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
        [Category("KryptonKnobControlEnhanced")]
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
        [Category("KryptonKnobControlEnhanced")]
        public KnobPointerStyles PointerStyle
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
        [Category("KryptonKnobControlEnhanced")]
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
        [Category("KryptonKnobControlEnhanced")]
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
        [Category("KryptonKnobControlEnhanced")]
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
        [Category("KryptonKnobControlEnhanced")]
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

        /// <summary>
        /// How many divisions of maximum?
        /// </summary>
        [Description("Set the number of intervals between minimum and maximum")]
        [Category("KryptonKnobControlEnhanced")]
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
        [Category("KryptonKnobControlEnhanced")]
        public int ScaleSubDivisions
        {
            get { return _scaleSubDivisions; }
            set
            {
                if (value > 0 && _scaleDivisions > 0 && (_maximum - _minimum) / (value * _scaleDivisions) > 0)
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
        [Category("KryptonKnobControlEnhanced")]
        public bool ShowSmallScale
        {
            get { return _showSmallScale; }
            set
            {
                if (value == true)
                {
                    if (_scaleDivisions > 0 && _scaleSubDivisions > 0 && (_maximum - _minimum) / (_scaleSubDivisions * _scaleDivisions) > 0)
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
        [Category("KryptonKnobControlEnhanced")]
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
        [Category("KryptonKnobControlEnhanced")]
        public int Minimum
        {
            get { return _minimum; }
            set
            {
                _minimum = value;
                // Redraw 
                Invalidate();
            }
        }

        /// <summary>
        /// Maximum value for knob control
        /// </summary>
        [Description("set the maximum value for the knob control")]
        [Category("KryptonKnobControlEnhanced")]
        public int Maximum
        {
            get { return _maximum; }
            set
            {
                if (value > _minimum)
                {
                    _maximum = value;


                    if (_scaleSubDivisions > 0 && _scaleDivisions > 0 && (_maximum - _minimum) / (_scaleSubDivisions * _scaleDivisions) <= 0)
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
        [Category("KryptonKnobControlEnhanced")]
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
        [Category("KryptonKnobControlEnhanced")]
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
        [Category("KryptonKnobControlEnhanced")]
        public int Value
        {
            get { return _value; }
            set
            {
                if (value >= _minimum && value <= _maximum)
                {
                    _value = value;

                    KnobValueChangedEventArgs e = new KnobValueChangedEventArgs(value);

                    // Redraw
                    Invalidate();
                    // call delegate  
                    OnValueChanged(null, e);
                }
            }
        }

        /// <summary>
        /// Color of the button
        /// </summary>
        [Description("set the color of the pointer")]
        [Category("KryptonKnobControlEnhanced")]
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

        #region Constructor
        public CommonKryptonKnobControlEnhanced()
        {
            _dottedPen = new Pen(KryptonKnobUtilities.GetDarkColour(BackColor, 40)) { DashStyle = DashStyle.Dash, DashCap = DashCap.Flat };

            InitializeComponent();

            _knobTypeface = new Font(Font.FontFamily, Font.Size);

            _scaleTypeface = new Font(Font.FontFamily, Font.Size);

            // Properties initialisation

            // "start angle" and "end angle" possible values:

            // 90 = bottom (minimum value for "start angle")
            // 180 = left
            // 270 = top
            // 360 = right
            // 450 = bottom again (maximum value for "end angle")

            // So the couple (90, 450) will give an entire circle and the couple (180, 360) will give half a circle.

            _startAngle = 135;
            _endAngle = 405;
            _deltaAngle = _endAngle - _startAngle;

            _minimum = 0;
            _maximum = 100;
            _scaleDivisions = 11;
            _scaleSubDivisions = 4;
            _mouseWheelBarPartitions = 10;

            _scaleColour = Color.Black;
            _knobBackColour = Color.White;

            SetDimensions();

            if (((_palette != null))) _palette.PalettePaint += OnPalettePaint;

            KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;

            _palette = KryptonManager.CurrentGlobalPalette;

            _paletteRedirect = new PaletteRedirect(_palette);

            _paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);

            _paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);

            _paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

            InitiliseColourScheme();
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // Set background color of Image...            
            _gOffScreen.Clear(BackColor);
            // Fill knob Background to give knob effect....
            _gOffScreen.FillEllipse(_brushKnob, _rKnob);
            // Set antialias effect on                     
            _gOffScreen.SmoothingMode = SmoothingMode.AntiAlias;
            // Draw border of knob                         
            _gOffScreen.DrawEllipse(new Pen(BackColor), _rKnob);

            //if control is focused 
            if (_isFocused)
            {
                _gOffScreen.DrawEllipse(_dottedPen, _rKnob);
            }

            // DrawPointer
            DrawPointer(_gOffScreen);

            //---------------------------------------------
            // draw small and large scale                  
            //---------------------------------------------
            DrawDivisions(_gOffScreen, _rKnob);

            // Draw image on screen                    
            g.DrawImage(_offScreenImage, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (KryptonKnobUtilities.IsPointinRectangle(new Point(e.X, e.Y), _rKnob))
            {
                if (_isFocused)
                {
                    // was already selected
                    // Start Rotation of knob only if it was selected before        
                    _isKnobRotating = true;
                }
                else
                {
                    // Was not selected before => select it
                    Focus();
                    _isFocused = true;
                    _isKnobRotating = false; // disallow rotation, must click again
                    // draw dotted border to show that it is selected
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
            if (KryptonKnobUtilities.IsPointinRectangle(new Point(e.X, e.Y), _rKnob))
            {
                if (_isFocused == true && _isKnobRotating == true)
                {
                    // Change value is allowed only only after 2nd click                   
                    this.Value = this.GetValueFromPosition(new Point(e.X, e.Y));
                }
                else
                {
                    // 1st click = only focus
                    _isFocused = true;
                    _isKnobRotating = true;
                }

            }

            this.Cursor = Cursors.Default;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            //--------------------------------------
            //  Following Handles Knob Rotating     
            //--------------------------------------
            if (e.Button == MouseButtons.Left && _isKnobRotating == true)
            {
                this.Cursor = Cursors.Hand;
                Point p = new Point(e.X, e.Y);
                int posVal = this.GetValueFromPosition(p);
                Value = posVal;
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (_isFocused && _isKnobRotating && KryptonKnobUtilities.IsPointinRectangle(new Point(e.X, e.Y), _rKnob))
            {
                // the Delta value is always 120, as explained in MSDN
                int v = (e.Delta / 120) * (_maximum - _minimum) / _mouseWheelBarPartitions;
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
                    if (_value < _maximum) Value = _value + 1;
                    this.Refresh();
                }
                else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Left)
                {
                    if (_value > _minimum) Value = _value - 1;
                    this.Refresh();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null) components.Dispose();
            }

            base.Dispose(disposing);
        }
        #endregion

        #region Designer Code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // KnobControl
            // 
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "KryptonKnobControlEnhanced";
            this.Resize += KryptonKnobControlEnhanced_Resize;

        }
        #endregion

        #region Methods
        /// <summary>
        /// Draw the pointer of the knob (a small button inside the main button)
        /// </summary>
        /// <param name="Gr"></param>
        private void DrawPointer(Graphics Gr)
        {
            try
            {
                float radius = (float)(_rKnob.Width / 2);

                // Draw a line
                if (_pointerStyle == KnobPointerStyles.LINE)
                {
                    int l = (int)radius / 2;
                    int w = l / 4;
                    Point[] pt = GetKnobLine(Gr, l);

                    Gr.DrawLine(new Pen(_pointerColour, w), pt[0], pt[1]);

                }
                else
                {
                    // Draw a circle
                    int w = 0;
                    int h = 0;
                    int l = 0;

                    string strvalmax = _maximum.ToString();
                    string strvalmin = _minimum.ToString();
                    string strval = strvalmax.Length > strvalmin.Length ? strvalmax : strvalmin;
                    double val = Convert.ToDouble(strval);
                    String str = String.Format("{0,0:D}", (int)val);

                    float fSize;
                    SizeF strsize;
                    if (_scaleTypefaceAutoSize)
                    {
                        // Use font family = _scaleTypeface, but size = automatic
                        fSize = (float)(6F * _drawRatio);
                        if (fSize < 6)
                            fSize = 6;
                        strsize = Gr.MeasureString(str, new Font(_scaleTypeface.FontFamily, fSize));
                    }
                    else
                    {
                        // Use font family = _scaleTypeface, but size = fixed
                        fSize = _scaleTypeface.Size;
                        strsize = Gr.MeasureString(str, _scaleTypeface);
                    }

                    int strw = (int)strsize.Width;
                    int strh = (int)strsize.Height;
                    w = Math.Max(strw, strh);
                    // radius of small circle
                    l = (int)radius - w / 2;

                    h = w;

                    Point Arrow = this.GetKnobPosition(l - 2); // Remove 2 pixels to offset the small circle inside the knob

                    // Draw pointer arrow that shows knob position             
                    Rectangle rPointer = new Rectangle(Arrow.X - w / 2, Arrow.Y - w / 2, w, h);


                    //KryptonKnobUtilities.DrawInsetCircle(ref Gr, rPointer, new Pen(_pointerColour));
                    KryptonKnobUtilities.DrawInsetCircle(ref Gr, rPointer, new Pen(KryptonKnobUtilities.GetLightColour(_pointerColour, 55)));

                    Gr.FillEllipse(_brushKnobPointer, rPointer);

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
        /// <param name="Gr"></param>
        /// <param name="rc">Knob rectangle</param>
        /// <returns></returns>
        private bool DrawDivisions(Graphics Gr, RectangleF rc)
        {
            if (this == null)
                return false;

            float cx = _pKnob.X;
            float cy = _pKnob.Y;

            float w = rc.Width;
            float h = rc.Height;

            float tx;
            float ty;

            float incr = KryptonKnobUtilities.GetRadian((_endAngle - _startAngle) / ((_scaleDivisions - 1) * (_scaleSubDivisions + 1)));
            float currentAngle = KryptonKnobUtilities.GetRadian(_startAngle);

            float radius = (float)(rc.Width / 2);
            float rulerValue = (float)_minimum;

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
                string strvalmax = _maximum.ToString();
                string strvalmin = _minimum.ToString();
                string strval = strvalmax.Length > strvalmin.Length ? strvalmax : strvalmin;
                double val = Convert.ToDouble(strval);
                //double val = _maximum;
                String str = String.Format("{0,0:D}", (int)val);
                float fSize;
                SizeF strsize;

                if (_scaleTypefaceAutoSize)
                {
                    fSize = (float)(6F * _drawRatio);
                    if (fSize < 6)
                        fSize = 6;
                }
                else
                {
                    fSize = _scaleTypeface.Size;
                }

                font = new Font(_scaleTypeface.FontFamily, fSize);
                strsize = Gr.MeasureString(str, font);

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

                    Gr.DrawLine(penL, ptStart, ptEnd);


                    //Draw graduation values                                                                                
                    val = Math.Round(rulerValue);
                    str = String.Format("{0,0:D}", (int)val);

                    // If autosize
                    if (_scaleTypefaceAutoSize)
                        strsize = Gr.MeasureString(str, new Font(_scaleTypeface.FontFamily, fSize));
                    else
                        strsize = Gr.MeasureString(str, new Font(_scaleTypeface.FontFamily, _scaleTypeface.Size));



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

                    Gr.DrawString(str,
                                    font,
                                    br,
                                    tx - (float)(strsize.Width * 0.5),
                                    ty - (float)(strsize.Height * 0.5));



                    rulerValue += (float)((_maximum - _minimum) / (_scaleDivisions - 1));

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

                                Gr.DrawLine(penS, ptStart, ptEnd);
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
            if (_drawRatio == 0.0)
                _drawRatio = 1;


            if (_showLargeScale)
            {
                Graphics Gr = this.CreateGraphics();
                string strvalmax = _maximum.ToString();
                string strvalmin = _minimum.ToString();
                string strval = strvalmax.Length > strvalmin.Length ? strvalmax : strvalmin;
                double val = Convert.ToDouble(strval);

                //double val = _maximum;
                String str = String.Format("{0,0:D}", (int)val);

                float fSize = _scaleTypeface.Size;

                if (_scaleTypefaceAutoSize)
                {
                    fSize = (float)(6F * _drawRatio);
                    if (fSize < 6)
                        fSize = 6;
                    font = new Font(_scaleTypeface.FontFamily, fSize);
                }
                else
                {
                    fSize = _scaleTypeface.Size;
                    font = new Font(_scaleTypeface.FontFamily, _scaleTypeface.Size);
                }

                SizeF strsize = Gr.MeasureString(str, font);

                // Graduations outside
                _gradLength = 4 * _drawRatio;

                if (_drawDivInside)
                {
                    // Graduations inside : remove only 2*8 pixels
                    //x = y = 8;
                    x = y = _gradLength;
                    w = Width - 2 * x;
                }
                else
                {
                    // remove 2 * size of text and length of graduation
                    //_gradLength = 4 * _drawRatio;
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
                this._rKnob = new Rectangle((int)x, (int)y, (int)w, (int)h);

                Gr.Dispose();
            }
            else
            {
                this._rKnob = new Rectangle(0, 0, Width, Height);
            }


            // Center of knob
            this._pKnob = new Point(_rKnob.X + _rKnob.Width / 2, _rKnob.Y + _rKnob.Height / 2);

            // create offscreen image                                 
            this._offScreenImage = new Bitmap(this.Width, this.Height);
            // create offscreen graphics                              
            this._gOffScreen = Graphics.FromImage(_offScreenImage);


            // Depends on retangle dimensions
            // create LinearGradientBrush for creating knob            
            _brushKnob = new LinearGradientBrush(
                _rKnob, KryptonKnobUtilities.GetLightColour(_knobBackColour, 55), KryptonKnobUtilities.GetDarkColour(_knobBackColour, 55), LinearGradientMode.ForwardDiagonal);

            // create LinearGradientBrush for knobPointer                
            _brushKnobPointer = new LinearGradientBrush(
                _rKnob, KryptonKnobUtilities.GetLightColour(_pointerColour, 55), KryptonKnobUtilities.GetDarkColour(_pointerColour, 55), LinearGradientMode.ForwardDiagonal);

        }

        /// <summary>
        /// Sets the trackbar value so that it wont exceed allowed range.
        /// </summary>
        /// <param name="val">The value.</param>
        private void SetProperValue(int val)
        {
            if (val < _minimum) Value = _minimum;
            else if (val > _maximum) Value = _maximum;
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
            float degree = _deltaAngle * (this.Value - _minimum) / (_maximum - _minimum);

            degree = KryptonKnobUtilities.GetRadian(degree + _startAngle);

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
            float degree = _deltaAngle * (this.Value - _minimum) / (_maximum - _minimum);

            degree = KryptonKnobUtilities.GetRadian(degree + _startAngle);


            double val = _maximum;
            String str = String.Format("{0,0:D}", (int)val);
            float fSize;
            SizeF strsize;

            if (!_scaleTypefaceAutoSize)
            {
                fSize = _scaleTypeface.Size;
                strsize = Gr.MeasureString(str, _scaleTypeface);
            }
            else
            {
                fSize = (float)(6F * _drawRatio);
                if (fSize < 6)
                    fSize = 6;

                _knobTypeface = new Font(_scaleTypeface.FontFamily, fSize);
                strsize = Gr.MeasureString(str, _knobTypeface);
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
            v = _minimum + (int)Math.Round(degree * (_maximum - _minimum) / _deltaAngle);

            if (v > _maximum) v = _maximum;
            if (v < _minimum) v = _minimum;
            return v;
        }

        private void InitiliseColourScheme()
        {
            KnobBackColour = _palette.ColorTable.MenuStripGradientBegin;

            PointerColour = _palette.ColorTable.OverflowButtonGradientMiddle;

            ScaleColour = _palette.ColorTable.MenuItemText;

            BackColor = _palette.ColorTable.MenuStripGradientBegin;
        }
        #endregion

        #region Event Handlers
        private void KryptonKnobControlEnhanced_Resize(object sender, EventArgs e)
        {
            // Control remains square
            Height = Width;

            SetDimensions();

            Invalidate();
        }

        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (((_palette != null))) _palette.PalettePaint -= OnPalettePaint;

            _palette = KryptonManager.CurrentGlobalPalette;

            _paletteRedirect.Target = _palette;

            if (((_palette != null)))
            {
                _palette.PalettePaint += OnPalettePaint;

                InitiliseColourScheme();
            }

            Invalidate();
        }

        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }
        #endregion
    }
}