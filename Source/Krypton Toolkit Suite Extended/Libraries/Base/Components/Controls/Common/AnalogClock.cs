using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    /// <summary>
    /// Defines the ticking style used for the second and minute hands of the analog clock. 
    /// </summary>
    public enum TickStyle
    {
        /// <summary>
        /// Smooth ticking style. For example if used with second hand it will be updated every millisecond.
        /// </summary>
        Smooth,
        /// <summary>
        /// Normal ticking style. For example if used with second hand it will be updated every second only.
        /// </summary>
        Normal
    }


    /// <summary>
    /// Represents the Analog clock control.
    /// </summary>
    //[ToolboxBitmap(typeof(AnalogClock), "AC.ExtendedRenderer.Toolkit.StdControls.Images.AnalogClock.bmp"), ToolboxItem(true)]
    [ToolboxBitmap(typeof(Timer)), ToolboxItem(true), DefaultEvent("TimeChanged")]
    public class AnalogClock : UserControl
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Creates a new instace of the Analog Clock control.
        /// </summary>
        public AnalogClock()
        {

            InitializeComponent();

            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            //SetStyle(ControlStyles.Opaque, true);
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            if (((_palette != null))) _palette.PalettePaint += OnPalettePaint;

            KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;

            _palette = KryptonManager.CurrentGlobalPalette;

            _paletteRedirect = new PaletteRedirect(_palette);

            _paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);

            _paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);

            _paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

            InitialiseColours();

            BackColor = Color.Transparent;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Events
        public delegate void TimeChangedEventHandler(object sender, TimeChangedEventArgs e);

        public event TimeChangedEventHandler TimeChanged;

        protected virtual void OnTimeChanged(object sender, TimeChangedEventArgs e) => TimeChanged?.Invoke(sender, e);
        #endregion

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // AnalogClock
            // 
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.Name = "AnalogClock";
            this.Size = new System.Drawing.Size(232, 232);
            this.Resize += new System.EventHandler(this.AnalogClock_Resize);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AnalogClock_Paint);

        }
        #endregion

        #region Properties
        /// <summary>
        /// The Background image used in the clock face.
        /// </summary>
        /// <remarks>Using a large image will result in poor performance and increased memory consumption.</remarks>
        [
        Category("Clock"),
        Description("The Background image used in the clock face."),

        ]
        public Image FaceImage
        {
            get { return img; }
            set { img = value; Invalidate(); }
        }


        /// <summary>
        /// Defines the second hand tick style.
        /// </summary>
        [
        Category("Clock"),
        Description("Defines the second hand tick style."),

        ]
        public TickStyle SecondHandTickStyle
        {
            get { return secondHandTickStyle; }
            set { secondHandTickStyle = value; }
        }

        /// <summary>
        /// Defines the minute hand tick style.
        /// </summary>
        [
        Category("Clock"),
        Description("Defines the minute hand tick style."),

        ]
        public TickStyle MinuteHandTickStyle
        {
            get { return minHandTickStyle; }
            set { minHandTickStyle = value; }
        }

        /// <summary>
        /// Determines whether the Numerals are drawn on the clock face.
        /// </summary>
        [
        Category("Clock"),
        Description("Determines whether the Numerals are drawn on the clock face."),
        DefaultValue(true),
        ]
        public bool DrawNumerals
        {
            get { return drawnumerals; }
            set { drawnumerals = value; Invalidate(); }

        }

        /// <summary>
        /// Sets or gets the rendering quality of the clock.
        /// </summary>
        /// <remarks>This property does not effect the numeral text rendering quality. To set the numeral text rendering quality use the <see cref="TextRenderingHint"/> Property</remarks>
        [
        Category("Clock"),
        Description("Sets or gets the rendering quality of the clock."),
        DefaultValue(SmoothingMode.AntiAlias),
        ]
        public SmoothingMode SmoothingMode
        {
            get { return smoothingMode; }
            set { smoothingMode = value; Invalidate(); }
        }

        /// <summary>
        /// Sets or gets the text rendering mode used for the clock numerals.
        /// </summary>
        [
        Category("Clock"),
        Description("Sets or gets the text rendering mode used for the clock numerals."),
        DefaultValue(TextRenderingHint.AntiAlias),
        ]
        public TextRenderingHint TextRenderingHint
        {
            get { return textRenderingHint; }
            set { textRenderingHint = value; Invalidate(); }

        }

        /// <summary>
        /// Determines whether the clock Rim is drawn or not.
        /// </summary>
        [
        Category("Clock"),
        Description("Determines whether the clock Rim is drawn or not."),
        DefaultValue(true),
        ]
        public bool DrawRim
        {
            get { return drawRim; }
            set { drawRim = value; Invalidate(); }
        }

        /// <summary>
        /// Determines whether drop shadow for the clock is drawn or not.
        /// </summary>
        [
        Category("Clock"),
        Description("Determines whether drop shadow for the clock is drawn or not."),
        DefaultValue(true),
        ]
        public bool DrawDropShadow
        {
            get { return drawDropShadow; }
            set { drawDropShadow = value; Invalidate(); }
        }

        /// <summary>
        /// Sets or gets the color of the Drop Shadow.
        /// </summary>
        [
        Category("Clock"),
        Description("Sets or gets the color of the Drop Shadow."),

        ]
        public Color DropShadowColour
        {
            get { return dropShadowColour; }
            set { dropShadowColour = value; Invalidate(); }
        }


        /// <summary>
        /// Sets or gets the color of the second hand drop Shadow.
        /// </summary>
        [
        Category("Clock"),
        Description("Sets or gets the color of the second hand drop Shadow."),

        ]
        public Color SecondHandDropShadowColour
        {
            get { return secondHandDropShadowColour; }
            set { secondHandDropShadowColour = value; Invalidate(); }
        }


        /// <summary>
        /// Sets or gets the color of the Minute hand drop Shadow.
        /// </summary>
        [
        Category("Clock"),
        Description("Sets or gets the color of the Minute hand drop Shadow."),

        ]
        public Color MinuteHandDropShadowColour
        {
            get { return minuteHandDropShadowColour; }
            set { minuteHandDropShadowColour = value; Invalidate(); }
        }

        /// <summary>
        /// Sets or gets the color of the hour hand drop Shadow.
        /// </summary>
        [
        Category("Clock"),
        Description("Sets or gets the color of the hour hand drop Shadow."),

        ]
        public Color HourHandDropShadowColour
        {
            get { return hourHandDropShadowColour; }
            set { hourHandDropShadowColour = value; Invalidate(); }
        }

        /// <summary>
        /// Determines the first color of the clock face gradient.
        /// </summary>
        [
        Category("Clock"),
        Description("Determines the first color of the clock face gradient."),

        ]
        public Color FaceColourHigh
        {
            get { return faceColour1; }
            set { faceColour1 = value; Invalidate(); }
        }

        /// <summary>
        /// Determines the second color of the clock face gradient.
        /// </summary>
        [
        Category("Clock"),
        Description("Determines the second color of the clock face gradient."),
        DefaultValue(typeof(Color), "Black")
        ]
        public Color FaceColourLow
        {
            get { return faceColour2; }
            set { faceColour2 = value; Invalidate(); }
        }


        /// <summary>
        /// Determines whether the second hand casts a drop shadow for added realism.  
        /// </summary>
        [
        Category("Clock"),
        Description("Determines whether the second hand casts a drop shadow for added realism."),
        DefaultValue(true)
        ]
        public bool DrawSecondHandShadow
        {
            get { return drawSecondHandShadow; }
            set { drawSecondHandShadow = value; Invalidate(); }
        }


        /// <summary>
        /// Determines whether the hour hand casts a drop shadow for added realism.  
        /// </summary>
        [
        Category("Clock"),
        Description("Determines whether the hour hand casts a drop shadow for added realism."),
        ]
        public bool DrawHourHandShadow
        {
            get { return drawHourHandShadow; }
            set { drawHourHandShadow = value; Invalidate(); }
        }

        /// <summary>
        /// Determines whether the minute hand casts a drop shadow for added realism.  
        /// </summary>
        [
        Category("Clock"),
        Description("Determines whether the minute hand casts a drop shadow for added realism."),
        ]
        public bool DrawMinuteHandShadow
        {
            get { return drawMinuteHandShadow; }
            set { drawMinuteHandShadow = value; Invalidate(); }
        }

        /// <summary>
        /// Determines the first color of the rim gradient.
        /// </summary>
        [
        Category("Clock"),
        Description("Determines the first color of the rim gradient."),
        ]
        public Color RimColourHigh
        {
            get { return rimColour1; }
            set { rimColour1 = value; Invalidate(); }
        }

        /// <summary>
        /// Determines the second color of the rim face gradient.
        /// </summary>
        [
        Category("Clock"),
        Description("Determines the second color of the rim face gradient."),
        ]
        public Color RimColourLow
        {
            get { return rimColour2; }
            set { rimColour2 = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the direction of the Rim gradient.
        /// </summary>
        //TODO:replace this by degree
        [
        Category("Clock"),
        Description("Gets or sets the direction of the Rim gradient."),
        ]
        public LinearGradientMode RimGradientMode
        {
            get { return faceGradientMode; }
            set { faceGradientMode = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the direction of the Clock Face gradient.
        /// </summary>
        //TODO:replace this by degree
        [
        Category("Clock"),
        Description("Gets or sets the direction of the Clock Face gradient."),
        ]
        public LinearGradientMode FaceGradientMode
        {
            get { return rimGradientMode; }
            set { rimGradientMode = value; Invalidate(); }
        }

        /// <summary>
        /// Determines the Seconds hand end line shape.
        /// </summary>
        [
        Category("Clock"),
        Description("Determines the shape of second hand."),
        ]
        public LineCap SecondHandEndCap
        {
            get { return secLineEndCap; }
            set { secLineEndCap = value; Invalidate(); }
        }

        /// <summary>
        /// The System.DateTime structure which is used to display time.
        /// </summary>
        /// <example>
        /// <code>
        /// AnalogClock clock = new AnalogClock();
        /// clock.Time = DateTime.Now;
        /// </code>
        /// </example>
        /// <remarks>The clock face is updated every time the value of this property is changed.</remarks>
        [
        Category("Clock"),
        Description("The DateTime structure which the clock uses to display time."),
        Browsable(false)
        ]
        public DateTime Time
        {
            get => time;

            set
            {
                time = value;

                Invalidate();

                TimeChangedEventArgs evt = new TimeChangedEventArgs(value);

                OnTimeChanged(this, evt);
            }
        }

        /// <summary>
        /// Gets or sets the color of the Seconds Hand.
        /// </summary>
        [
        Category("Clock"),
        Description("Gets or sets the color of the Seconds Hand."),
        ]
        public Color SecondHandColour
        {
            get { return secondHandColour; }
            set { secondHandColour = value; Invalidate(); }
        }

        /// <summary>
        /// Sets or gets the color of the clock Numerals.
        /// </summary>
        /// <remarks>To change the numeral font use the <see cref=" Font "/> Property </remarks>
        [
        Category("Clock"),
        Description("Sets or gets the color of the clock Numerals."),
        ]
        public Color NumeralColour
        {
            get { return numeralColour; }
            set { numeralColour = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the Hour Hand.
        /// </summary>
        [
        Category("Clock"),
        Description("Gets or sets the color of the Hour Hand."),
        ]
        public Color HourHandColour
        {
            get { return hourHandColour; }
            set { hourHandColour = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the color of the Minute Hand.
        /// </summary>
        [
        Category("Clock"),
        Description("Gets or sets the color of the Minute Hand."),
        ]
        public Color MinuteHandColour
        {
            get { return minHandColour; }
            set { minHandColour = value; Invalidate(); }
        }


        /// <summary>
        /// Determines whether the second Hand is shown. 
        /// </summary>
        /// 
        [
        Category("Clock"),
        Description("Determines whether the second Hand is shown."),
        ]
        public bool DrawSecondHand
        {
            get { return drawSecondHand; }
            set { drawSecondHand = value; Invalidate(); }
        }


        /// <summary>
        /// Determines whether the minute hand is shown. 
        /// </summary>
        /// 
        [
        Category("Clock"),
        Description("Determines whether the minute hand is shown."),
        ]
        public bool DrawMinuteHand
        {
            get { return drawMinuteHand; }
            set { drawMinuteHand = value; Invalidate(); }
        }

        /// <summary>
        /// Determines whether the hour Hand is shown. 
        /// </summary>
        /// 
        [
        Category("Clock"),
        Description("Determines whether the hour Hand is shown."),
        ]
        public bool DrawHourHand
        {
            get { return drawHourHand; }
            set { drawHourHand = value; Invalidate(); }
        }

        /// <summary>
        /// Gets or sets the drop shadow offset.
        /// </summary>
        /// 
        [
        Category("Clock"),
        Description("Gets or sets the drop shadow offset."),
        ]
        public Point DropShadowOffset
        {
            get { return dropShadowOffset; }
            set { dropShadowOffset = value; Invalidate(); }
        }
        #endregion

        #region Variables
        private bool drawnumerals = true;
        private bool drawRim = true;
        private bool drawDropShadow = true;
        private bool drawSecondHandShadow = true;
        private bool drawMinuteHandShadow = true;
        private bool drawHourHandShadow = true;
        private bool drawSecondHand = true;
        private bool drawMinuteHand = true;
        private bool drawHourHand = true;

        private Color dropShadowColour = Color.Black;
        private Color secondHandDropShadowColour = Color.Gray;
        private Color hourHandDropShadowColour = Color.Gray;
        private Color minuteHandDropShadowColour = Color.Gray;
        private Color faceColour1 = Color.RoyalBlue;
        private Color faceColour2 = Color.SkyBlue;
        private Color rimColour1 = Color.RoyalBlue;
        private Color rimColour2 = Color.SkyBlue;
        private Color numeralColour = Color.WhiteSmoke;
        private Color secondHandColour = Color.Tomato;
        private Color hourHandColour = Color.Gainsboro;
        private Color minHandColour = Color.WhiteSmoke;

        private LinearGradientBrush gb;
        private SmoothingMode smoothingMode = SmoothingMode.AntiAlias;
        private TextRenderingHint textRenderingHint = TextRenderingHint.AntiAlias;
        private LineCap secLineEndCap = LineCap.Round;
        //private Point dropShadowOffset = new Point(5,5);
        private LinearGradientMode faceGradientMode = LinearGradientMode.ForwardDiagonal;
        private LinearGradientMode rimGradientMode = LinearGradientMode.BackwardDiagonal;
        private DateTime time;

        private float radius;
        private float midx;
        private float midy;
        private float y;
        private float x;
        private float fontsize;
        private Font textFont;
        private int min;
        private int hour;
        private double sec;
        private Image img;
        private float minuteAngle;
        private double secondAngle;
        private double hourAngle;

        private TickStyle secondHandTickStyle = TickStyle.Normal;
        private TickStyle minHandTickStyle = TickStyle.Normal;

        private Point dropShadowOffset;

        #region Krypton
        private KryptonManager _manager = new KryptonManager();

        private PaletteBackInheritRedirect _paletteBack;

        private PaletteBorderInherit _paletteBorder;

        private PaletteContentInheritRedirect _paletteContent;

        private IPalette _palette;

        private PaletteRedirect _paletteRedirect;
        #endregion

        #endregion

        private void AnalogClock_Paint(object sender, PaintEventArgs e)
        {
            DrawClock(e.Graphics);
        }


        private float GetX(float deg)
        { return (float)(radius * Math.Cos((Math.PI / 180) * deg)); }

        private float GetY(float deg)
        { return (float)(radius * Math.Sin((Math.PI / 180) * deg)); }


        private void AnalogClock_Resize(object sender, System.EventArgs e)
        {
            Width = Height;
            Width = Width;
            Invalidate();
        }

        /// <summary>
        /// Draws analog clock on the given GDI+ Drawing surface.
        /// </summary>
        /// <param name="e">The GDI+ Drawing surface.</param>
        private void DrawClock(Graphics e)
        {
            Graphics grfx = e;
            grfx.SmoothingMode = smoothingMode;
            grfx.TextRenderingHint = textRenderingHint;
            grfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            midx = ClientSize.Width / 2;
            midy = ClientSize.Height / 2;


            x = ClientSize.Width;
            y = ClientSize.Height;

            SolidBrush stringBrush = new SolidBrush(numeralColour);
            Pen pen = new Pen(stringBrush, 2);


            //Define rectangles inside which we will draw circles.

            Rectangle rect = new Rectangle(0 + 10, 0 + 10, (int)x - 20, (int)y - 20);
            Rectangle rectrim = new Rectangle(0 + 20, 0 + 20, (int)x - 40, (int)y - 40);

            Rectangle rectinner = new Rectangle(0 + 40, 0 + 40, (int)x - 80, (int)y - 80);
            Rectangle rectdropshadow = new Rectangle(0 + 10, 0 + 10, (int)x - 17, (int)y - 17);


            radius = rectinner.Width / 2;

            fontsize = radius / 5;
            textFont = Font;


            //Drop Shadow
            gb = new LinearGradientBrush(rect, Color.Transparent, dropShadowColour, LinearGradientMode.BackwardDiagonal);
            rectdropshadow.Offset(dropShadowOffset);
            if (drawDropShadow)
                grfx.FillEllipse(gb, rectdropshadow);


            //Face
            gb = new LinearGradientBrush(rect, rimColour1, rimColour2, faceGradientMode);
            if (drawRim)
                grfx.FillEllipse(gb, rect);




            //Rim
            gb = new LinearGradientBrush(rect, faceColour1, faceColour2, rimGradientMode);
            grfx.FillEllipse(gb, rectrim);










            //Define a circular clip region and draw the image inside it.
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(rectrim);
            grfx.SetClip(path);

            if (img != null)
            {
                grfx.DrawImage(img, rect);
            }
            path.Dispose();

            //Reset clip region
            grfx.ResetClip();

            //			Triangular region
            //			pen.Width =2;
            //			grfx.DrawRectangle(pen, rect);
            //			grfx.DrawRectangle(pen, rectinner);
            //			grfx.DrawRectangle(pen, rectrim);
            //			grfx.DrawRectangle(pen, rectdropshadow);
            //			
            //			grfx.DrawRectangle(pen, rect);
            //			grfx.DrawEllipse(pen, rect);
            //			grfx.DrawEllipse(pen, rectinner);
            //			grfx.DrawEllipse(pen, rectrim);
            //			grfx.DrawEllipse(pen, rectdropshadow);
            //			


            //Center Point
            //grfx.DrawEllipse(pen, midx, midy ,2 ,2);

            //Define the midpoint of the control as the centre
            grfx.TranslateTransform(midx, midy);



            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;


            //Draw Numerals on the Face 
            int deg = 360 / 12;
            if (drawnumerals)
            {
                for (int i = 1; i <= 12; i++)
                {

                    grfx.DrawString(i.ToString(), textFont, stringBrush, -1 * GetX(i * deg + 90), -1 * GetY(i * deg + 90), format);
                }

            }
            format.Dispose();



            hour = time.Hour;
            min = time.Minute;
            Point centre = new Point(0, 0);

            //Draw Minute hand
            if (drawMinuteHand)
            {

                if (minHandTickStyle == TickStyle.Smooth)
                    minuteAngle = (float)(2.0 * Math.PI * (min + sec / 60.0) / 60.0);
                else
                    minuteAngle = (float)(2.0 * Math.PI * (min / 60.0));

                pen.EndCap = LineCap.Round;
                pen.StartCap = LineCap.RoundAnchor;
                pen.Width = (int)radius / 14;

                centre.Offset(2, 2);
                pen.Color = Color.Gray;
                Point minHandShadow = new Point((int)(radius * Math.Sin(minuteAngle)), (int)(-(radius) * Math.Cos(minuteAngle) + 2));


                if (drawMinuteHandShadow)
                {
                    pen.Color = minuteHandDropShadowColour;
                    grfx.DrawLine(pen, centre, minHandShadow);
                }

                centre.X = centre.Y = 0;
                pen.Color = minHandColour;
                Point minHand = new Point((int)(radius * Math.Sin(minuteAngle)), (int)(-(radius) * Math.Cos(minuteAngle)));
                grfx.DrawLine(pen, centre, minHand);
            }

            //--End Minute Hand


            // Draw Hour Hand
            if (drawHourHand)
            {
                hourAngle = 2.0 * Math.PI * (hour + min / 60.0) / 12.0;


                pen.EndCap = LineCap.Round;
                pen.StartCap = LineCap.RoundAnchor;
                pen.Width = (int)radius / 14;

                centre.X = centre.Y = 1;
                pen.Color = Color.Gray;
                Point hourHandShadow = new Point((int)((radius * Math.Sin(hourAngle) / 1.5) + 2), (int)((-(radius) * Math.Cos(hourAngle) / 1.5) + 2));

                if (drawHourHandShadow)
                {
                    pen.Color = hourHandDropShadowColour;
                    grfx.DrawLine(pen, centre, hourHandShadow);
                }

                centre.X = centre.Y = 0;
                pen.Color = hourHandColour;
                Point hourHand = new Point((int)(radius * Math.Sin(hourAngle) / 1.5), (int)(-(radius) * Math.Cos(hourAngle) / 1.5));
                grfx.DrawLine(pen, centre, hourHand);
            }
            //---End Hour Hand


            if (secondHandTickStyle == TickStyle.Smooth)
                sec = time.Second + (time.Millisecond * 0.001);
            else
                sec = time.Second;


            //Draw Sec Hand
            if (drawSecondHand)
            {
                int width = (int)radius / 25;
                pen.Width = width;
                pen.EndCap = secLineEndCap;
                pen.StartCap = LineCap.RoundAnchor;
                secondAngle = 2.0 * Math.PI * sec / 60.0;




                //Draw Second Hand Drop Shadow
                pen.Color = Color.DimGray;
                centre.X = 1;
                centre.Y = 1;

                Point secHand = new Point((int)(radius * Math.Sin(secondAngle)), (int)(-(radius) * Math.Cos(secondAngle)));
                Point secHandshadow = new Point((int)(radius * Math.Sin(secondAngle)), (int)(-(radius) * Math.Cos(secondAngle) + 2));



                if (drawSecondHandShadow)
                {
                    pen.Color = secondHandDropShadowColour;
                    grfx.DrawLine(pen, centre, secHandshadow);

                }

                centre.X = centre.Y = 0;
                pen.Color = secondHandColour;
                grfx.DrawLine(pen, centre, secHand);
            }
            pen.Dispose();


        }

        #region Krypton
        private void InitialiseColours()
        {
            faceColour1 = _palette.ColorTable.MenuStripGradientBegin;

            faceColour2 = _palette.ColorTable.MenuStripGradientEnd;

            rimColour1 = _palette.ColorTable.StatusStripGradientBegin;

            rimColour2 = _palette.ColorTable.StatusStripGradientEnd;

            numeralColour = _palette.ColorTable.MenuStripText;
        }

        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (((_palette != null))) _palette.PalettePaint -= OnPalettePaint;

            _palette = KryptonManager.CurrentGlobalPalette;

            _paletteRedirect.Target = _palette;

            if (((_palette != null)))
            {
                _palette.PalettePaint += OnPalettePaint;

                RefreshColours();
            }

            Invalidate();
        }

        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }

        private void RefreshColours() => InitialiseColours();
        #endregion
    }
}