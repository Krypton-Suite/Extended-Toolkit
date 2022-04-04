#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [ToolboxBitmap(typeof(TrackBar)), ToolboxItem(false)]
    public partial class KryptonToolbarSlider : UserControl, IContentValues
    {
        #region Designer Code
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kplus = new KryptonSliderButton();
            this.kminus = new KryptonSliderButton();
            this.SuspendLayout();
            // 
            // kplus
            // 
            this.kplus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.kplus.BackColor = System.Drawing.Color.Transparent;
            this.kplus.ButtonStyle = KryptonSliderButton.ButtonStyles.PlusButton;
            this.kplus.EventFireRate = 200;
            this.kplus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kplus.Location = new System.Drawing.Point(124, 0);
            this.kplus.Name = "kplus";
            this.kplus.Orientation = Krypton.Toolkit.VisualOrientation.Top;
            this.kplus.SingleClick = false;
            this.kplus.Size = new System.Drawing.Size(16, 16);
            this.kplus.TabIndex = 1;
            this.kplus.VisualLook = Krypton.Toolkit.PaletteBackStyle.ButtonStandalone;
            this.kplus.SliderButtonFire += new KryptonSliderButton.SliderButtonFireEventHandler(this.kplus_SliderButtonFire);
            // 
            // kminus
            // 
            this.kminus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.kminus.BackColor = System.Drawing.Color.Transparent;
            this.kminus.ButtonStyle = KryptonSliderButton.ButtonStyles.MinusButton;
            this.kminus.EventFireRate = 200;
            this.kminus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kminus.Location = new System.Drawing.Point(0, 0);
            this.kminus.Name = "kminus";
            this.kminus.Orientation = Krypton.Toolkit.VisualOrientation.Top;
            this.kminus.SingleClick = false;
            this.kminus.Size = new System.Drawing.Size(16, 16);
            this.kminus.TabIndex = 0;
            this.kminus.VisualLook = Krypton.Toolkit.PaletteBackStyle.ButtonStandalone;
            this.kminus.SliderButtonFire += new KryptonSliderButton.SliderButtonFireEventHandler(this.kminus_SliderButtonFire);
            // 
            // KryptonSlider
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kplus);
            this.Controls.Add(this.kminus);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "KryptonSlider";
            this.Size = new System.Drawing.Size(140, 16);
            this.MouseLeave += new System.EventHandler(this.KryptonSliderButton_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.KryptonSlider_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.KryptonSliderButton_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.KryptonSliderButton_MouseUp);
            this.MouseEnter += new System.EventHandler(this.KryptonSliderButton_MouseEnter);
            this.ResumeLayout(false);

        }
        internal KryptonSliderButton kminus;
        internal KryptonSliderButton kplus;


        #endregion
        #endregion

        #region "Entry"

        public KryptonToolbarSlider()
        {

            //(1) To remove flicker we use double buffering for drawing
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);

            //Initialize Component
            InitializeComponent();

            //(5) Create redirection object to the base palette
            // add Palette Handler
            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            //(6) Create accessor objects for the back, border and content
            m_paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);
            m_paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);
            m_paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

            //Set Back Color
            this.BackColor = System.Drawing.Color.Transparent;

        }

        #endregion

        #region "Declares"

        //Colors
        private Color m_sliderlinetop = Color.FromArgb(116, 150, 194);
        private Color m_sliderlinebottom = Color.FromArgb(222, 226, 236);

        //Krypton
        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;

        private PaletteBackInheritRedirect m_paletteBack;
        private PaletteBorderInheritRedirect m_paletteBorder;
        private PaletteContentInheritRedirect m_paletteContent;
        private IDisposable m_mementoContent;
        private IDisposable m_mementoBack1;
        private IDisposable m_mementoBack2;

        //Declares
        private int m_range = 100;
        private int m_value = 0;
        private int m_step = 2;
        private bool m_highlight = false;
        private bool m_sliderhighlight = false;
        private bool glowing = false;
        private bool m_down = false;
        private int m_fireInterval = 200;
        private bool m_singleClick = false;

        //Events
        public event ValueChangedEventHandler ValueChanged;
        public delegate void ValueChangedEventHandler(KryptonToolbarSlider Sender, SliderEventArgs e);

        //Enumerations
        public enum RangeTests
        {
            MinusDomain = 0,
            LeftDomain = 1,
            MiddleDomain = 2,
            RightDomain = 3,
            PlusDomain = 4,
            ElseDomain = 5
        }

        #endregion

        #region "Painting"

        //Overrides
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawLines(e.Graphics);
            DrawSlider(e.Graphics);
        }
        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {

                //Dispose Memento Content
                if (m_mementoContent != null)
                {
                    m_mementoContent.Dispose();
                    m_mementoContent = null;
                }

                //Dispose Memento BackGround One
                if (m_mementoBack1 != null)
                {
                    m_mementoBack1.Dispose();
                    m_mementoBack1 = null;
                }

                //Dispose Memento BackGround Two
                if (m_mementoBack2 != null)
                {
                    m_mementoBack2.Dispose();
                    m_mementoBack2 = null;
                }

                if (this.components != null)
                {
                    components.Dispose();
                }


                if (_palette != null)
                {
                    _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                    _palette = null;
                }


                KryptonManager.GlobalPaletteChanged -= new EventHandler(OnGlobalPaletteChanged);

            }

            base.Dispose(disposing);
        }
        protected override void OnLayout(System.Windows.Forms.LayoutEventArgs e)
        {

            //Active Palette
            //If m_palette IsNot Nothing Then
            if (_palette != null)
            {

                // We want the inner part of the control to act like a button, so 
                // we need to find the correct palette state based on if the mouse 
                // is over the control and currently being pressed down or not.
                PaletteState buttonState = GetSliderState();

                // Create a rectangle inset, this is where we will draw a button
                Rectangle ButtonBounds = GetSliderBounds(GetSliderPosition());

                // Get the renderer associated with this palette
                //Dim Renderer As IRenderer =  m_palette.GetRenderer()
                IRenderer Renderer = _palette.GetRenderer();

                // Create a layout context used to allow the renderer to layout the content
                using (ViewLayoutContext ViewContext = new ViewLayoutContext(this, Renderer))
                {

                    // Setup the appropriate style for the content
                    m_paletteContent.Style = PaletteContentStyle.ButtonStandalone;

                    // Cleaup resources by disposing of old memento instance
                    if (m_mementoContent != null)
                    {
                        m_mementoContent.Dispose();
                    }

                    // Ask the renderer to work out how the Content values will be layed out and
                    // return a memento object that we cache for use when actually performing painting
                    m_mementoContent = Renderer.RenderStandardContent.LayoutContent(ViewContext, ButtonBounds, m_paletteContent, this, VisualOrientation.Top, buttonState, false, glowing);

                }
            }

            //Base Layout Call
            base.OnLayout(e);

        }

        //Renderers
        private void DrawLines(Graphics Gfx)
        {

            //Smoothing Mode
            Gfx.SmoothingMode = SmoothingMode.AntiAlias;
            Gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            //Define Pen Colors
            Pen TopPen = new Pen(m_sliderlinetop, 1);
            Pen BottomPen = new Pen(m_sliderlinebottom, 1);

            //Draw Lines
            Gfx.DrawLine(TopPen, 17, (int)this.Height / 2 - 1, this.Width - 18, (int)this.Height / 2 - 1);
            Gfx.DrawLine(BottomPen, 17, (int)this.Height / 2, this.Width - 18, (int)this.Height / 2);
            Gfx.DrawLine(TopPen, (int)this.Width / 2, (int)this.Height / 2 - 3, (int)this.Width / 2, (int)this.Height / 2 + 3);
            Gfx.DrawLine(BottomPen, (int)this.Width / 2 + 1, (int)this.Height / 2 - 3, (int)this.Width / 2 + 1, (int)this.Height / 2 + 3);

        }
        private void DrawSlider(Graphics Gfx)
        {

            //Smoothing Mode
            Gfx.SmoothingMode = SmoothingMode.AntiAlias;
            Gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            //Slider Bounds
            Rectangle SliderBounds = GetSliderBounds(GetSliderPosition());

            //Check Palette
            if (_palette != null)
            {

                //Get the renderer associated with this palette
                IRenderer Renderer = _palette.GetRenderer();

                //Create the rendering context that is passed into all renderer calls
                using (RenderContext RenderContext = new RenderContext(this, Gfx, SliderBounds, Renderer))
                {

                    // We want to draw the background of the entire control over the entire client area.
                    using (GraphicsPath Path = GetSliderPath(GetSliderPosition()))
                    {

                        // Set the style we want picked up from the base palette
                        m_paletteBack.Style = PaletteBackStyle.HeaderPrimary;

                        // Ask renderer to draw the background
                        m_mementoBack1 = Renderer.RenderStandardBack.DrawBack(RenderContext, SliderBounds, Path, m_paletteBack, VisualOrientation.Top, (this.Enabled ? PaletteState.Normal : PaletteState.Disabled), m_mementoBack1);

                    }

                    //We want the inner part of the control to act like a button, so 
                    //we need to find the correct palette state based on if the mouse 
                    //is over the control if the mouse button is pressed down or not.
                    PaletteState ButtonState = GetSliderState();

                    //Set the style of button we want to draw
                    m_paletteBack.Style = PaletteBackStyle.ButtonStandalone;
                    m_paletteBorder.Style = PaletteBorderStyle.ButtonStandalone;
                    m_paletteContent.Style = PaletteContentStyle.ButtonStandalone;

                    //Do we need to draw the background?
                    if (m_paletteBack.GetBackDraw(ButtonState) == InheritBool.True)
                    {

                        //BackGround Path
                        using (GraphicsPath Path = GetSliderPath(GetSliderPosition()))
                        {

                            // Ask renderer to draw the background
                            m_mementoBack2 = Renderer.RenderStandardBack.DrawBack(RenderContext, SliderBounds, Path, m_paletteBack, VisualOrientation.Top, ButtonState, m_mementoBack2);
                            Gfx.DrawPath(new Pen(m_paletteBorder.GetBorderColor2(ButtonState)), Path);
                            Gfx.DrawLine(new Pen(m_paletteBorder.GetBorderColor2(ButtonState)), (int)SliderBounds.X + (SliderBounds.Width / 2) + 1, SliderBounds.Y + 4, (int)SliderBounds.X + (SliderBounds.Width / 2) + 1, SliderBounds.Y + 8);

                        }

                    }

                }

            }

        }

        #endregion

        #region "Helpers"

        //Slider Helpers
        private Point GetPointFromValue(int Value)
        {
            if (Value == 0)
            {
                return new Point((int)Math.Round((double)(((double)this.Width) / 2.0)), (int)Math.Round((double)((((double)this.Height) / 2.0) - 6.5)));
            }
            Point Result = new Point((int)Math.Round((double)((((double)this.Width) / 2.0) + (((((double)this.Width) / 2.0) - 20.0) * (((double)Value) / (((double)this.m_range) / 2.0))))), (int)Math.Round((double)((((double)this.Height) / 2.0) - 6.5)));
            if (Result.X > (this.Width - 0x16))
            {
                Result.X = this.Width - 0x16;
            }
            if (Result.X < 20)
            {
                Result.X = 20;
            }
            return Result;

        }
        private int GetValueFromPoint(Point Value)
        {
            int Result = (int)Math.Round((double)((((Value.X - (((double)this.Width) / 2.0)) / ((((double)this.Width) / 2.0) - 20.0)) * this.m_range) / 2.0));
            if (Result > (((double)this.m_range) / 2.0))
            {
                Result = (int)Math.Round((double)(((double)this.m_range) / 2.0));
            }
            if (Result < ((((double)this.m_range) / 2.0) * -1.0))
            {
                Result = (int)Math.Round((double)((((double)this.m_range) / 2.0) * -1.0));
            }
            return Result;

        }
        private GraphicsPath GetSliderPath(Point Location)
        {
            GraphicsPath Path = new GraphicsPath();
            {
                Path.AddLine(new Point(Location.X + 1, Location.Y), new Point(Location.X + 1, Location.Y + 9));
                Path.AddLine(new Point(Location.X + 1, Location.Y + 9), new Point(Location.X + 5, Location.Y + 13));
                Path.AddLine(new Point(Location.X + 5, Location.Y + 13), new Point(Location.X + 9, Location.Y + 9));
                Path.AddLine(new Point(Location.X + 9, Location.Y + 9), new Point(Location.X + 9, Location.Y));
                Path.AddLine(new Point(Location.X + 1, Location.Y), new Point(Location.X + 9, Location.Y));
            }
            return Path;
        }
        private Rectangle GetSliderBounds(Point Location)
        {
            return new Rectangle(Location.X, Location.Y, 9, 13);
        }
        private Point GetSliderPosition()
        {
            return new Point((int)Math.Round((double)(this.GetPointFromValue(this.m_value).X - 4.5)), (int)Math.Round((double)((((double)this.Height) / 2.0) - 6.5)));
        }

        private PaletteState GetSliderState()
        {
            if (!this.Enabled)
            {
                return PaletteState.Disabled;
            }
            else
            {
                if (m_down)
                {
                    return PaletteState.Pressed;
                }
                else
                {
                    if (m_highlight)
                    {
                        if (m_sliderhighlight)
                        {
                            return PaletteState.CheckedTracking;
                        }
                        else
                        {
                            return PaletteState.Tracking;
                        }
                    }
                    else
                    {
                        return PaletteState.Normal;
                    }
                }
            }
        }
        private RangeTests GetSliderRangeTest(Point Location)
        {
            if ((Location.X > 20) & (Location.X < (this.Width - 20)))
            {
                if ((Location.X >= ((((double)this.Width) / 2.0) - 5.0)) & (Location.X <= ((((double)this.Width) / 2.0) + 5.0)))
                {
                    return RangeTests.MiddleDomain;
                }
                if (Location.X < (((double)this.Width) / 2.0))
                {
                    return RangeTests.LeftDomain;
                }
                return RangeTests.RightDomain;
            }
            if (Location.X <= 20)
            {
                return RangeTests.MinusDomain;
            }
            if (Location.X >= (this.Width - 20))
            {
                return RangeTests.PlusDomain;
            }
            return RangeTests.ElseDomain;

        }

        //Slider Values
        private void ChangeValue(int NewValue)
        {
            if (this.Enabled)
            {
                if (ValueChanged != null)
                {
                    ValueChanged(this, new SliderEventArgs(NewValue, m_value, m_range, m_step));
                }
                m_value = NewValue;
            }
        }
        private void SliderIncrement()
        {
            if ((m_value + m_step) <= (m_range / 2))
            {
                ChangeValue(m_value + m_step);
            }
        }
        private void SliderDecrement()
        {
            if ((m_value - m_step) >= ((m_range / 2) * -1))
            {
                ChangeValue(m_value - m_step);
            }
        }

        #endregion

        #region "Events"

        //Key Mouse Events
        private void KryptonSliderButton_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (GetSliderBounds(GetSliderPosition()).Contains(e.Location))
            {
                m_down = true;
                this.Invalidate();
            }
        }
        private void KryptonSliderButton_MouseEnter(object sender, System.EventArgs e)
        {
            m_highlight = true;
            this.Invalidate();
        }
        private void KryptonSliderButton_MouseLeave(object sender, System.EventArgs e)
        {
            m_highlight = false;
            this.Invalidate();
        }
        private void KryptonSlider_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            //Repaint Flag
            bool DoInvalidate = false;

            //Check Mouse Location
            if (GetSliderBounds(GetSliderPosition()).Contains(e.Location))
            {
                if (!m_sliderhighlight)
                {
                    m_sliderhighlight = true;
                    DoInvalidate = true;
                }
            }
            else
            {
                if (m_sliderhighlight)
                {
                    m_sliderhighlight = false;
                    DoInvalidate = true;
                }
            }

            //Check Moving Slider
            if (m_down)
            {
                /*
                switch (GetSliderRangeTest(e.Location))
                {
                    case RangeTests.MinusDomain:
                        ChangeValue((m_range / 2) * -1);
                        break;
                    case RangeTests.MiddleDomain:
                        ChangeValue(0);
                        break;
                    case RangeTests.PlusDomain:
                        ChangeValue((int)m_range / 2);
                        break;
                    default:
                        ChangeValue(GetValueFromPoint(e.Location));
                        break;
                }
                */
                ChangeValue(GetValueFromPoint(e.Location));
                DoInvalidate = true;
            }

            //Check Invalidation
            if (DoInvalidate) this.Invalidate();

        }
        private void KryptonSliderButton_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            m_down = false;
            if (!GetSliderBounds(GetSliderPosition()).Contains(e.Location))
            {
                switch (GetSliderRangeTest(e.Location))
                {
                    case RangeTests.LeftDomain:
                        ChangeValue(GetValueFromPoint(e.Location));
                        break;
                    case RangeTests.RightDomain:
                        ChangeValue(GetValueFromPoint(e.Location));
                        break;
                    case RangeTests.MiddleDomain:
                        ChangeValue(0);
                        break;
                }
            }
            this.Invalidate();
        }

        //Krypton Paint Helpers
        private void k_palette_BasePaletteChanged(object sender, System.EventArgs e)
        {
            this.Invalidate();
        }
        private void k_palette_BaseRendererChanged(object sender, System.EventArgs e)
        {
            this.Invalidate();
        }
        private void k_palette_PalettePaint(object sender, Krypton.Toolkit.PaletteLayoutEventArgs e)
        {
            this.Invalidate();
        }

        //Slider Buttons
        private void kminus_SliderButtonFire(KryptonSliderButton Sender, System.EventArgs e)
        {
            SliderDecrement();
            this.Invalidate();
        }
        private void kplus_SliderButtonFire(KryptonSliderButton Sender, System.EventArgs e)
        {
            SliderIncrement();
            this.Invalidate();
        }

        #endregion

        #region "Properties"

        public int Value
        {
            get { return m_value; }
            set
            {
                if (m_value != value)
                {
                    m_value = value;
                    this.Invalidate();
                }
            }
        }

        public bool SingleClick
        {
            get { return m_singleClick; }
            set
            {
                m_singleClick = value;
                this.kplus.SingleClick = value;
                this.kminus.SingleClick = value;

                this.Invalidate();
            }
        }

        public int FireInterval
        {
            get { return m_fireInterval; }
            set
            {
                m_fireInterval = value;
                this.kplus.EventFireRate = value;
                this.kminus.EventFireRate = value;

                this.Invalidate();
            }
        }

        public int Range
        {
            get { return m_range; }
            set
            {
                if (m_range != value)
                {
                    m_range = value;
                    this.Invalidate();
                }
            }
        }
        public int Steps
        {
            get { return m_step; }
            set
            {
                if (m_step != value)
                {
                    m_step = value;
                    this.Invalidate();
                }
            }
        }
        public int Maximum
        {
            get { return (int)m_range / 2; }
        }
        public int Minimum
        {
            get { return -1 * (int)m_range / 2; }
        }

        #endregion

        #region "IContentValues"

        //Implements IContentValues
        public System.Drawing.Image GetImage(Krypton.Toolkit.PaletteState state)
        {
            return null;
        }
        public System.Drawing.Color GetImageTransparentColor(Krypton.Toolkit.PaletteState state)
        {
            return Color.Empty;
        }
        public string GetLongText()
        {
            return string.Empty;
        }
        public string GetShortText()
        {
            return string.Empty;
        }

        #endregion

        #region "SliderEventArgs"

        public class SliderEventArgs : System.EventArgs
        {

            //Starter
            public SliderEventArgs(int NewValue, int OldValue, int Range, int Steps)
                : base()
            {
                m_newvalue = NewValue;
                m_oldvalue = OldValue;
                m_range = Range;
                m_steps = Steps;
            }

            //Properties
            private int m_newvalue;
            public int NewValue
            {
                get { return m_newvalue; }
            }
            private int m_oldvalue;
            public int OldValue
            {
                get { return m_oldvalue; }
            }
            private int m_range;
            public int Range
            {
                get { return m_range; }
            }
            private int m_steps;
            public int Steps
            {
                get { return m_steps; }
            }

            //ToString
            public override string ToString()
            {
                string RetStr = "";
                RetStr += "Values: " + DateTime.Now.ToLongTimeString() + Environment.NewLine;
                RetStr += "NewValue: " + m_newvalue + Environment.NewLine;
                RetStr += "OldValue: " + m_oldvalue + Environment.NewLine;
                RetStr += "Range: " + m_range + Environment.NewLine;
                RetStr += "Steps: " + m_steps + Environment.NewLine;
                return RetStr;
            }

        }

        #endregion

        #region "   Krypton Events   "

        //Krypton Palette Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }

        //Krypton Palette Events
        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (_palette != null)
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;

            if (_palette != null)
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                //repaint with new values

                //set colors
                InitColours();


            }

            Invalidate();
        }

        private void InitColours()
        {
            //Colors
            m_sliderlinetop = _palette.ColorTable.GripDark;
            m_sliderlinebottom = _palette.ColorTable.GripLight;

        }
        #endregion


    }
}