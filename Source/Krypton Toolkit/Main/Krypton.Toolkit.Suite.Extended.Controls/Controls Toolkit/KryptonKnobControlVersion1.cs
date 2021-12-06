#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    // Delegate type for hooking up ValueChanged notifications.
    public delegate void ValueChangedEventHandler(object sender, KnobValueChangedEventArgs e);

    [DefaultEvent("ValueChanged"), ToolboxBitmap(typeof(System.Windows.Forms.Timer))]
    public class KryptonKnobControlVersion1 : UserControl
    {
        #region " constructor "

        private int _Minimum = 0, _Maximum = 100, _LargeChange = 20, _SmallChange = 5, _SizeLargeScaleMarker = 6, _SizeSmallScaleMarker = 3;
        private bool _ShowSmallScale = false;
        private bool _ShowLargeScale = true;
        private bool _isFocused = false;
        private Color _KnobColour = Color.FromKnownColor(KnownColor.ControlLight), _mouseOverColour = Color.FromKnownColor(KnownColor.ControlLightLight),
            _KnobBorderColour = Color.FromKnownColor(KnownColor.ControlDarkDark), _KnobBackColour = Color.FromKnownColor(KnownColor.Control),
            _mouseDownColour, _indicatorColourBegin, _indicatorColourEnd, _insetCircleColour;
        private int _Value;
        private bool isKnobRotating = false;
        private Rectangle rKnob;
        private Point pKnob;
        private Rectangle rScale;
        private Pen DottedPen;
        private Brush bKnob;
        private Brush bKnobPoint;

        //Palette State
        private KryptonManager k_manager = new KryptonManager();
        private PaletteBackInheritRedirect m_paletteBack;
        private PaletteBorderInheritRedirect m_paletteBorder;
        private PaletteContentInheritRedirect m_paletteContent;
        //private IDisposable m_mementoContent;
        //private IDisposable m_mementoBack1;
        //private IDisposable m_mementoBack2;

        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;

        // declare Off screen image and Offscreen graphics
        private Image OffScreenImage;
        private Graphics gOffScreen;

        // An event that clients can use to be notified whenever
        // the Value is Changed.

        // Events
        public event ValueChangedEventHandler ValueChanged;

        #endregion

        #region " Windows Form Designer generated code "

        public KryptonKnobControlVersion1()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);


            //Create redirection object to the base palette
            if (((_palette != null)))
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
            }
            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);
            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            //Create accessor objects for the back, border and content
            m_paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);
            m_paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);
            m_paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

            InitColours();

            //This call is required by the Windows Form Designer.
            InitializeComponent();

            ImeMode = ImeMode.On;
            Name = "Knob";
            Resize += new EventHandler(Knob_Resize);
            //ValueChanged += new ValueChangedEventHandler(ValueChanged);

            DottedPen = new Pen(getDarkColor(_KnobBorderColour, 40));
            DottedPen.DashStyle = DashStyle.Dot;
            DottedPen.DashCap = DashCap.Round;
            setDimensions();

            InitColours();

        }

        /*
        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        //UserControl1 overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components == null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        */

        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // KryptonKnobControl
            // 
            Name = "KryptonKnobControl";
            Size = new System.Drawing.Size(91, 91);
            ResumeLayout(false);

        }
        #endregion

        #region " Public Properties "
        // Shows Small Scale marking.
        [Browsable(true), Category("Appearance-Extended")]
        [Description("Shows Small Scale marking")]
        public bool ShowSmallScale
        {
            get { return _ShowSmallScale; }
            set
            {
                _ShowSmallScale = value;
                // Need to redraw
                setDimensions(); Invalidate();
            }
        }


        // Shows Large Scale marking
        [Browsable(true), Category("Appearance-Extended")]
        [Description(" Shows Large Scale marking")]
        public bool ShowLargeScale
        {
            get { return _ShowLargeScale; }
            set
            {
                _ShowLargeScale = value;
                // Need to redraw
                setDimensions(); Invalidate();
            }
        }

        // Size of the Large Scale Marker
        [Browsable(true), Category("Appearance-Extended")]
        [Description("Size of the large Scale Marker")]
        public int SizeLargeScaleMarker
        {
            get { return _SizeLargeScaleMarker; }
            set
            {
                _SizeLargeScaleMarker = value;
                setDimensions(); Invalidate();
            }
        }

        // Size of the Small Scale Marker
        [Browsable(true), Category("Appearance-Extended")]
        [Description("Size of the small Scale Marker")]
        public int SizeSmallScaleMarker
        {
            get { return _SizeSmallScaleMarker; }
            set
            {
                _SizeSmallScaleMarker = value;
                setDimensions(); Invalidate();
            }
        }


        // Minimum Value for knob Control
        [Browsable(true), Category("Appearance-Extended")]
        [Description("Minimum Value for knob Control")]
        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                _Minimum = value;
                setDimensions(); Invalidate();
            }
        }


        // Maximum value for knob control
        [Browsable(true), Category("Appearance-Extended")]
        [Description("Maximum value for knob control")]
        public int Maximum
        {
            get { return _Maximum; }
            set
            {
                _Maximum = value;
                setDimensions(); Invalidate();
            }
        }


        // value set for large change
        [Browsable(true), Category("Appearance-Extended")]
        [Description("value set for large change")]
        public int LargeChange
        {
            get { return _LargeChange; }
            set
            {
                _LargeChange = value;
                setDimensions(); Invalidate();
            }
        }


        // value set for small change.
        [Browsable(true), Category("Appearance-Extended")]
        [Description("value set for small change")]
        public int SmallChange
        {
            get { return _SmallChange; }
            set
            {
                _SmallChange = value;
                setDimensions(); Invalidate();
            }
        }
        // Current Value of knob control
        [Browsable(true), Category("Appearance-Extended")]
        [Description("Current Value of knob control")]
        public int Value
        {
            get { return _Value; }
            set
            {
                _Value = value;

                KnobValueChangedEventArgs e = new KnobValueChangedEventArgs(value);

                // Call delegate
                OnValueChanged(null, e);
                setDimensions(); Invalidate();
            }
        }

        // Set Color of knob control
        [Browsable(true), Category("Appearance-Extended")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Set Colour of knob control")]
        public Color KnobColour
        {
            get { return _KnobColour; }
            set
            {
                _KnobColour = value;
                //Refresh Colors
                Invalidate();
            }
        }

        [Browsable(true), Category("Appearance-Extended")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Sets the mouse over Colour of knob control")]
        public Color MouseOverKnobColour
        {
            get
            {
                return _mouseOverColour;
            }

            set
            {
                _mouseOverColour = value;

                // Redraw
                Invalidate();
            }
        }

        // Set Color of the border of knob control
        [Browsable(true), Category("Appearance-Extended")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Set Colour of the border of knob control")]
        public Color KnobBorderColour
        {
            get { return _KnobBorderColour; }
            set
            {
                _KnobBorderColour = value;
                //Refresh Colors
                Invalidate();
            }
        }

        // Set Color of the back of knob control
        [Browsable(true), Category("Appearance-Extended")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Set Colour of the back of knob control")]
        public Color KnobBackColour
        {
            get { return _KnobBackColour; }
            set
            {
                _KnobBackColour = value;
                //Refresh Colors
                Invalidate();
            }
        }

        [Browsable(true), Category("Appearance-Extended")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Set mouse down Colour of the back of knob control")]
        public Color MouseDownKnobColour { get => _mouseDownColour; set { _mouseDownColour = value; Invalidate(); } }

        public Color KnobIndicatorColourBegin { get => _indicatorColourBegin; set { _indicatorColourBegin = value; Invalidate(); } }

        public Color KnobIndicatorColourEnd { get => _indicatorColourEnd; set { _indicatorColourEnd = value; Invalidate(); } }

        public Color KnobIndicatorBorderColour { get => _insetCircleColour; set { _insetCircleColour = value; Invalidate(); } }
        #endregion

        #region " Events and sub management "
        protected object OnValueChanged(object sender, KnobValueChangedEventArgs e)
        {
            if (ValueChanged != null)
            {
                ValueChanged(sender, e);
            }
            return sender;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            // create LinearGradientBrush for creating knob
            bKnob = new LinearGradientBrush(rKnob, getLightColor(KnobColour, 55), getDarkColor(KnobColour, 55), LinearGradientMode.ForwardDiagonal);
            // create LinearGradientBrush for knobPoint
            //bKnobPoint = new LinearGradientBrush(rKnob, getLightColor(_KnobBorderColour, 55), getDarkColor(_KnobBorderColour, 55), LinearGradientMode.ForwardDiagonal);
            bKnobPoint = new LinearGradientBrush(rKnob, KnobIndicatorColourBegin, KnobIndicatorColourEnd, LinearGradientMode.ForwardDiagonal);

            // Set background color of Image...
            e.Graphics.FillRectangle(new SolidBrush(_KnobBackColour), new Rectangle(0, 0, Width, Height));
            //gOffScreen.Clear(BackColor);
            // Fill knob Background to give knob effect....
            gOffScreen.FillEllipse(bKnob, rKnob);
            // Set antialias effect on
            gOffScreen.SmoothingMode = SmoothingMode.AntiAlias;
            // Draw border of knob
            gOffScreen.DrawEllipse(new Pen(_KnobBorderColour), rKnob);

            //if control is focused
            if ((_isFocused))
            {
                gOffScreen.DrawEllipse(DottedPen, rKnob);
            }
            // get current position of pointer
            Point Arrow = getKnobPosition();
            // Draw pointer arrow that shows knob position

            Rectangle rect = new Rectangle(Arrow.X - 3, Arrow.Y - 3, 6, 6);

            DrawInsetCircle(ref gOffScreen, ref rect, new Pen(KnobIndicatorBorderColour));

            // Draw small and large scale
            int i = Minimum;
            if ((_ShowSmallScale))
            {
                for (i = Minimum; i <= Maximum; i = i + _SmallChange)
                {
                    gOffScreen.DrawLine(new Pen(ForeColor), getMarkerPoint(0, i), getMarkerPoint(_SizeSmallScaleMarker, i));
                }
            }

            if ((_ShowLargeScale))
            {
                for (i = Minimum; i <= Maximum; i = i + _LargeChange)
                {
                    gOffScreen.DrawLine(new Pen(ForeColor), getMarkerPoint(0, i), getMarkerPoint(_SizeLargeScaleMarker, i));
                }
            }

            // Drawimage on screen
            g.DrawImage(OffScreenImage, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
            //e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.FillRectangle(new SolidBrush(_KnobBackColour), new Rectangle(0, 0, Width, Height));
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if ((isPointinRectangle(new Point(e.X, e.Y), rKnob)))
            {
                // Start Rotation of knob
                isKnobRotating = true;
            }

            KnobColour = MouseDownKnobColour;
        }

        protected override void OnMouseHover(EventArgs e)
        {
            KnobColour = MouseOverKnobColour;

            base.OnMouseHover(e);
        }

        // ----------------------------------------------------------
        // we need to override IsInputKey method to allow user to
        // use up, down, right and bottom keys other wise using me
        // keys will change focus from current object to another
        // object on the form
        // ----------------------------------------------------------
        protected override bool IsInputKey(Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Left:
                    return true;
                default:
                    return false;
            }
            // return base.IsInputKey(key);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Stop rotation
            isKnobRotating = false;
            if ((isPointinRectangle(new Point(e.X, e.Y), rKnob)))
            {
                // get value
                Value = getValueFromPosition(new Point(e.X, e.Y));
            }
            Cursor = Cursors.Default;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            // --------------------------------------
            // Following Handles Knob Rotating
            // --------------------------------------
            if ((isKnobRotating == true))
            {
                Cursor = Cursors.Hand;
                Point p = new Point(e.X, e.Y);
                int posVal = getValueFromPosition(p);
                Value = posVal;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            _isFocused = true;
            Refresh();
            base.OnEnter(new EventArgs());
        }

        protected override void OnLeave(EventArgs e)
        {
            _isFocused = false;
            Refresh();
            base.OnLeave(new EventArgs());
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            // --------------------------------------------------------
            // Handles knob rotation with up,down,left and right keys
            // --------------------------------------------------------
            if ((e.KeyCode == Keys.Up | e.KeyCode == Keys.Right))
            {
                if ((_Value < Maximum))
                {
                    Value = _Value + 1;
                    Invalidate();
                }
            }
            else if ((e.KeyCode == Keys.Down | e.KeyCode == Keys.Left))
            {
                if ((_Value > Minimum))
                {
                    Value = _Value - 1;
                    Invalidate();
                }
            }
        }

        private void setDimensions()
        {
            // get smaller from height and width
            int size = Width;
            if ((Width > Height))
            {
                size = Height;
            }
            // allow 10% gap on all side to determine size of knob
            rKnob = new Rectangle((int)Math.Round((double)(size * 0.1)), (int)Math.Round((double)(size * 0.1)), (int)Math.Round((double)(size * 0.8)), (int)Math.Round((double)(size * 0.8)));
            rScale = new Rectangle(2, 2, size - 4, size - 4);
            pKnob = new Point((int)Math.Round((double)(rKnob.X + (((double)rKnob.Width) / 2.0))), (int)Math.Round((double)(rKnob.Y + (((double)rKnob.Height) / 2.0))));
            // create offscreen image
            OffScreenImage = new Bitmap(Width, Height);
            // create offscreen graphics
            gOffScreen = Graphics.FromImage(OffScreenImage);
        }

        private void Knob_Resize(object sender, System.EventArgs e)
        {
            setDimensions();
            Invalidate();
        }


        // gets knob position that is to be drawn on control.
        private Point getKnobPosition()
        {
            double degree = 270 * Value / (Maximum - Minimum);
            degree = (degree + 135) * Math.PI / 180;

            Point Pos = (new Point(0, 0));
            Pos.X = (int)Math.Round((double)(((Math.Cos(degree) * ((((double)rKnob.Width) / 2.0) - 10.0)) + rKnob.X) + (((double)rKnob.Width) / 2.0)));
            Pos.Y = (int)Math.Round((double)(((Math.Sin(degree) * ((((double)rKnob.Width) / 2.0) - 10.0)) + rKnob.Y) + (((double)rKnob.Height) / 2.0)));
            return Pos;
        }


        // gets marker point required to draw scale marker.
        // <param name="length">distance from center</param>
        // <param name="Value">value that is to be marked</param>
        // <returns>Point that describes marker position</returns>
        private Point getMarkerPoint(int length, int Value)
        {
            double degree = 270 * Value / (Maximum - Minimum);
            degree = (degree + 135) * Math.PI / 180;

            Point Pos = new Point(0, 0);
            Pos.X = (int)Math.Round((double)(((Math.Cos(degree) * (((((double)rKnob.Width) / 2.0) - length) + 7.0)) + rKnob.X) + (((double)rKnob.Width) / 2.0)));
            Pos.Y = (int)Math.Round((double)(((Math.Sin(degree) * (((((double)rKnob.Width) / 2.0) - length) + 7.0)) + rKnob.Y) + (((double)rKnob.Height) / 2.0)));

            return Pos;
        }


        // converts geomatrical position in to value..
        // <param name="p">Point that is to be converted</param>
        // <returns>Value derived from position</returns>
        private int getValueFromPosition(Point p)
        {

            double degree = 0.0;
            int v = 0;
            try
            {
                if ((p.X <= pKnob.X))
                {
                    degree = (pKnob.Y - p.Y) / (pKnob.X - p.X);
                    degree = Math.Atan(degree);
                    degree = (degree) * (180 / Math.PI) + 45;
                    v = (int)Math.Round((double)((degree * (Maximum - Minimum)) / 270.0));
                }
                else if ((p.X > pKnob.X))
                {
                    degree = (p.Y - pKnob.Y) / (p.X - pKnob.X);
                    degree = Math.Atan(degree);
                    degree = 225 + (degree) * (180 / Math.PI);
                    v = (int)Math.Round((double)((degree * (Maximum - Minimum)) / 270.0));
                }

                if ((v > Maximum)) v = Maximum;
                if ((v < Minimum)) v = Minimum;
            }
            catch
            {
            }
            return v;
        }
        #endregion

        #region " support functions "
        public Color getDarkColor(Color c, byte d)
        {
            byte r = 0;
            byte g = 0;
            byte b = 0;

            if ((c.R > d)) r = (byte)(c.R - d);
            if ((c.G > d)) g = (byte)(c.G - d);
            if ((c.B > d)) b = (byte)(c.B - d);

            Color c1 = Color.FromArgb(r, g, b);
            return c1;
        }

        public Color getLightColor(Color c, byte d)
        {
            byte r = 255;
            byte g = 255;
            byte b = 255;

            if (((int)c.R + (int)d <= 255)) r = (byte)(c.R + d);
            if (((int)c.G + (int)d <= 255)) g = (byte)(c.G + d);
            if (((int)c.B + (int)d <= 255)) b = (byte)(c.B + d);

            Color c2 = Color.FromArgb(r, g, b);
            return c2;
        }

        // Method which checks is particular point is in rectangle
        // <param name="p">Point to be Chaecked</param>
        // <param name="r">Rectangle</param>
        // <returns>true is Point is in rectangle, else false</returns>
        public bool isPointinRectangle(Point p, Rectangle r)
        {
            bool flag = false;
            if ((p.X > r.X & p.X < r.X + r.Width & p.Y > r.Y & p.Y < r.Y + r.Height))
            {
                flag = true;
            }
            return flag;
        }

        public void DrawInsetCircle(ref Graphics g, ref Rectangle r, Pen p)
        {
            int i;
            Pen p1 = new Pen(getDarkColor(p.Color, 50));
            Pen p2 = new Pen(getLightColor(p.Color, 50));

            for (i = 0; i <= p.Width; i++)
            {
                Rectangle r1 = new Rectangle(r.X + i, r.Y + i, r.Width - i * 2, r.Height - i * 2);
                g.DrawArc(p2, r1, -45, 180);
                g.DrawArc(p1, r1, 135, 180);
            }
        }
        #endregion

        #region " Krypton "
        //Krypton Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            base.Invalidate();
        }

        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (((_palette != null)))
            {
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
            }
            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;
            if (((_palette != null)))
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                InitColours();
            }
            base.Invalidate();

        }


        private void InitColours()
        {
            BorderStyle = BorderStyle.None;
            KnobColour = _palette.ColorTable.OverflowButtonGradientBegin;
            KnobBorderColour = _palette.ColorTable.ToolStripGradientBegin;
            ForeColor = _palette.ColorTable.MenuItemText;
            KnobBackColour = _palette.ColorTable.MenuStripGradientBegin;
            MouseOverKnobColour = _palette.ColorTable.ButtonCheckedGradientBegin;
            MouseDownKnobColour = _palette.ColorTable.ButtonPressedGradientBegin;
            KnobIndicatorColourBegin = _palette.ColorTable.MenuStripGradientBegin;
            KnobIndicatorColourEnd = _palette.ColorTable.MenuStripGradientEnd;
            KnobIndicatorBorderColour = _palette.ColorTable.ToolStripGradientBegin;
        }
        #endregion

    }
}