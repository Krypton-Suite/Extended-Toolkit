using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Common
{
    /// <summary>
    /// A replacement for the default ProgressBar control.
    /// </summary>
    [DefaultEvent("ValueChanged"), ToolboxBitmap(typeof(ProgressBar)), ToolboxItem(false)]
    public class ProgressBarControl : UserControl
    {
        #region -  Designer  -

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Create the control and initialize it.
        /// </summary>
        public ProgressBarControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;
            if (!(InDesignMode()))
            {
                mGlowAnimation.Tick += mGlowAnimation_Tick;
                mGlowAnimation.Interval = 15;
                if (Value < MaxValue)
                {
                    mGlowAnimation.Start();
                }
            }
        }

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

        #region -  Component Designer  -

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // ProgressBar
            // 
            this.Name = "ProgressBar";
            this.Size = new System.Drawing.Size(264, 32);
            //					Me.Paint += New PaintEventHandler(ProgressBar_Paint);
            //INSTANT C# NOTE: Converted event handlers:
            base.Paint += ProgressBar_Paint;

        }

        #endregion

        #endregion

        #region -  Properties  -

        private int mGlowPosition = -325;
        private Timer mGlowAnimation = new Timer();
        private string mDisplayText = "";


        #region -  Value  -
        /// <summary>
        /// The value that is displayed on the progress bar.
        /// </summary>
        [Category("Value"), DefaultValue(""), Description("The text that is displayed on the progress bar.")]
        public string DisplayText
        {
            get
            {
                return mDisplayText;
            }
            set
            {
                mDisplayText = value;
            }
        }

        private int mValue = 0;
        /// <summary>
        /// The value that is displayed on the progress bar.
        /// </summary>
        [Category("Value"), DefaultValue(0), Description("The value that is displayed on the progress bar.")]
        public int Value
        {
            get
            {
                return mValue;
            }
            set
            {
                if (value > MaxValue || value < MinValue)
                {
                    return;
                }
                mValue = value;
                if (value < MaxValue)
                {
                    mGlowAnimation.Start();
                }
                if (value == MaxValue)
                {
                    mGlowAnimation.Stop();
                }
                ValueChangedHandler vc = ValueChanged;
                if (vc != null)
                {
                    vc(this, new System.EventArgs());
                }
                this.Invalidate();
            }
        }

        private int mMaxValue = 100;
        /// <summary>
        /// The maximum value for the Value property.
        /// </summary>
        [Category("Value"), DefaultValue(100), Description("The maximum value for the Value property.")]
        public int MaxValue
        {
            get
            {
                return mMaxValue;
            }
            set
            {
                mMaxValue = value;
                if (value > MaxValue)
                {
                    this.Value = MaxValue;
                }
                if (this.Value < MaxValue)
                {
                    mGlowAnimation.Start();
                }
                MaxChangedHandler mc = MaxChanged;
                if (mc != null)
                {
                    mc(this, new System.EventArgs());
                }
                this.Invalidate();
            }
        }

        private int mMinValue = 0;
        /// <summary>
        /// The minimum value for the Value property.
        /// </summary>
        [Category("Value"), DefaultValue(0), Description("The minimum value for the Value property.")]
        public int MinValue
        {
            get
            {
                return mMinValue;
            }
            set
            {
                mMinValue = value;
                if (value < MinValue)
                {
                    this.Value = MinValue;
                }
                MinChangedHandler mc = MinChanged;
                if (mc != null)
                {
                    mc(this, new System.EventArgs());
                }
                this.Invalidate();
            }
        }

        #endregion

        #region -  Bar  -

        private Color mStartColor = Color.FromArgb(210, 0, 0);
        /// <summary>
        /// The start color for the progress bar.
        /// 210, 000, 000 = Red
        /// 210, 202, 000 = Yellow
        /// 000, 163, 211 = Blue
        /// 000, 211, 040 = Green
        /// </summary>
        [Category("Bar"), DefaultValue(typeof(Color), "210, 0, 0"), Description("The start colour for the progress bar." + "210, 000, 000 = Red" + "\n" + "210, 202, 000 = Yellow" + "\n" + "000, 163, 211 = Blue" + "\n" + "000, 211, 040 = Green" + "\n")]
        public Color StartColour
        {
            get
            {
                return mStartColor;
            }
            set
            {
                mStartColor = value;
                this.Invalidate();
            }
        }

        private Color mEndColor = Color.FromArgb(0, 211, 40);
        /// <summary>
        /// The end color for the progress bar.
        /// 210, 000, 000 = Red
        /// 210, 202, 000 = Yellow
        /// 000, 163, 211 = Blue
        /// 000, 211, 040 = Green
        /// </summary>
        [Category("Bar"), DefaultValue(typeof(Color), "0, 211, 40"), Description("The end colour for the progress bar." + "210, 000, 000 = Red" + "\n" + "210, 202, 000 = Yellow" + "\n" + "000, 163, 211 = Blue" + "\n" + "000, 211, 040 = Green" + "\n")]
        public Color EndColour
        {
            get
            {
                return mEndColor;
            }
            set
            {
                mEndColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #region -  Highlights and Glows  -

        private Color mHighlightColor = Color.White;
        /// <summary>
        /// The color of the highlights.
        /// </summary>
        [Category("Highlights and Glows"), DefaultValue(typeof(Color), "White"), Description("The colour of the highlights.")]
        public Color HighlightColour
        {
            get
            {
                return mHighlightColor;
            }
            set
            {
                mHighlightColor = value;
                this.Invalidate();
            }
        }

        private Color mBackgroundColor = Color.FromArgb(201, 201, 201);
        /// <summary>
        /// The color of the background.
        /// </summary>
        [Category("Highlights and Glows"), DefaultValue(typeof(Color), "201,201,201"), Description("The colour of the background.")]
        public Color BackgroundColour
        {
            get
            {
                return mBackgroundColor;
            }
            set
            {
                mBackgroundColor = value;
                this.Invalidate();
            }
        }

        private bool mAnimate = true;
        /// <summary>
        /// Whether the glow is animated.
        /// </summary>
        [Category("Highlights and Glows"), DefaultValue(typeof(bool), "true"), Description("Whether the glow is animated or not.")]
        public bool Animate
        {
            get
            {
                return mAnimate;
            }
            set
            {
                mAnimate = value;
                if (value)
                {
                    mGlowAnimation.Start();
                }
                else
                {
                    mGlowAnimation.Stop();
                }
                this.Invalidate();
            }
        }

        private Color mGlowColor = Color.FromArgb(150, 255, 255, 255);
        /// <summary>
        /// The color of the glow.
        /// </summary>
        [Category("Highlights and Glows"), DefaultValue(typeof(Color), "150, 255, 255, 255"), Description("The colour of the glow.")]
        public Color GlowColour
        {
            get
            {
                return mGlowColor;
            }
            set
            {
                mGlowColor = value;
                this.Invalidate();
            }
        }

        #endregion

        #endregion

        #region -  Drawing  -

        private void DrawBackground(Graphics g)
        {
            Rectangle r = this.ClientRectangle;
            r.Width -= 1;
            r.Height -= 1;
            GraphicsPath rr = RoundRect(r, 2F, 2F, 2F, 2F);
            g.FillPath(new SolidBrush(this.BackgroundColour), rr);
        }

        private void DrawBackgroundShadows(Graphics g)
        {
            Rectangle lr = new Rectangle(2, 2, 10, this.Height - 5);
            LinearGradientBrush lg = new LinearGradientBrush(lr, Color.FromArgb(30, 0, 0, 0), Color.Transparent, LinearGradientMode.Horizontal);
            lr.X -= 1;
            g.FillRectangle(lg, lr);

            Rectangle rr = new Rectangle(this.Width - 12, 2, 10, this.Height - 5);
            LinearGradientBrush rg = new LinearGradientBrush(rr, Color.Transparent, Color.FromArgb(20, 0, 0, 0), LinearGradientMode.Horizontal);
            g.FillRectangle(rg, rr);
        }

        private void DrawBar(Graphics g)
        {
            Rectangle r = new Rectangle(1, 2, this.Width - 3, this.Height - 3);
            r.Width = System.Convert.ToInt32((int)(Value * 1.0F / (MaxValue - MinValue) * this.Width));
            g.FillRectangle(new SolidBrush(GetIntermediateColor()), r);
        }

        private void DrawBarShadows(Graphics g)
        {
            Rectangle lr = new Rectangle(1, 2, 15, this.Height - 3);
            LinearGradientBrush lg = new LinearGradientBrush(lr, Color.White, Color.White, LinearGradientMode.Horizontal);

            ColorBlend lc = new ColorBlend(3);
            lc.Colors = new Color[] { Color.Transparent, Color.FromArgb(40, 0, 0, 0), Color.Transparent };
            lc.Positions = new float[] { 0.0F, 0.2F, 1.0F };
            lg.InterpolationColors = lc;

            lr.X -= 1;
            g.FillRectangle(lg, lr);

            Rectangle rr = new Rectangle(this.Width - 3, 2, 15, this.Height - 3);
            rr.X = System.Convert.ToInt32((int)((Value * 1.0F / (MaxValue - MinValue) * this.Width) - 14));
            LinearGradientBrush rg = new LinearGradientBrush(rr, Color.Black, Color.Black, LinearGradientMode.Horizontal);

            ColorBlend rc = new ColorBlend(3);
            rc.Colors = new Color[] { Color.Transparent, Color.FromArgb(40, 0, 0, 0), Color.Transparent };
            rc.Positions = new float[] { 0.0F, 0.8F, 1.0F };
            rg.InterpolationColors = rc;

            g.FillRectangle(rg, rr);
        }

        private void DrawHighlight(Graphics g)
        {
            Rectangle tr = new Rectangle(1, 1, this.Width - 1, 6);
            GraphicsPath tp = RoundRect(tr, 2F, 2F, 0F, 0F);

            g.SetClip(tp);
            LinearGradientBrush tg = new LinearGradientBrush(tr, Color.White, Color.FromArgb(128, Color.White), LinearGradientMode.Vertical);
            g.FillPath(tg, tp);
            g.ResetClip();

            Rectangle br = new Rectangle(1, this.Height - 8, this.Width - 1, 6);
            GraphicsPath bp = RoundRect(br, 0F, 0F, 2F, 2F);

            g.SetClip(bp);
            LinearGradientBrush bg = new LinearGradientBrush(br, Color.Transparent, Color.FromArgb(100, this.HighlightColour), LinearGradientMode.Vertical);
            g.FillPath(bg, bp);
            g.ResetClip();
        }

        private void DrawInnerStroke(Graphics g)
        {
            Rectangle r = this.ClientRectangle;
            r.X += 1;
            r.Y += 1;
            r.Width -= 3;
            r.Height -= 3;
            GraphicsPath rr = RoundRect(r, 2F, 2F, 2F, 2F);
            g.DrawPath(new Pen(Color.FromArgb(100, Color.White)), rr);
        }

        private void DrawString(Graphics g, string Text, Font fnt, Color FontColor)
        {
            Rectangle r = this.ClientRectangle;
            r.X += 1;
            r.Y += 1;
            r.Width -= 3;
            r.Height -= 3;
            GraphicsPath rr = RoundRect(r, 2F, 2F, 2F, 2F);
            SizeF TextSize;
            TextSize = g.MeasureString(Text, fnt);
            g.DrawString(Text, fnt, new SolidBrush(FontColor), r.Width / 2 - TextSize.Width / 2, r.Height / 2 - fnt.SizeInPoints / 2);
        }
        private void DrawGlow(Graphics g)
        {
            Rectangle r = new Rectangle(mGlowPosition, 0, 60, this.Height);
            LinearGradientBrush lgb = new LinearGradientBrush(r, Color.White, Color.White, LinearGradientMode.Horizontal);

            ColorBlend cb = new ColorBlend(4);
            cb.Colors = new Color[] { Color.Transparent, this.GlowColour, this.GlowColour, Color.Transparent };
            cb.Positions = new float[] { 0.0F, 0.5F, 0.6F, 1.0F };
            lgb.InterpolationColors = cb;

            Rectangle clip = new Rectangle(1, 2, this.Width - 3, this.Height - 3);
            clip.Width = System.Convert.ToInt32((int)(Value * 1.0F / (MaxValue - MinValue) * this.Width));
            g.SetClip(clip);
            g.FillRectangle(lgb, r);
            g.ResetClip();
        }

        private void DrawOuterStroke(Graphics g)
        {
            Rectangle r = this.ClientRectangle;
            r.Width -= 1;
            r.Height -= 1;
            GraphicsPath rr = RoundRect(r, 2F, 2F, 2F, 2F);
            g.DrawPath(new Pen(Color.FromArgb(178, 178, 178)), rr);
        }

        #endregion

        #region -  Functions  -

        private GraphicsPath RoundRect(RectangleF r, float r1, float r2, float r3, float r4)
        {
            float x = (float)(r.X);
            float y = (float)(r.Y);
            float w = (float)(r.Width);
            float h = (float)(r.Height);
            GraphicsPath rr = new GraphicsPath();
            rr.AddBezier(x, y + r1, x, y, x + r1, y, x + r1, y);
            rr.AddLine(x + r1, y, x + w - r2, y);
            rr.AddBezier(x + w - r2, y, x + w, y, x + w, y + r2, x + w, y + r2);
            rr.AddLine(x + w, y + r2, x + w, y + h - r3);
            rr.AddBezier(x + w, y + h - r3, x + w, y + h, x + w - r3, y + h, x + w - r3, y + h);
            rr.AddLine(x + w - r3, y + h, x + r4, y + h);
            rr.AddBezier(x + r4, y + h, x, y + h, x, y + h - r4, x, y + h - r4);
            rr.AddLine(x, y + h - r4, x, y + r1);
            return rr;
        }

        private bool InDesignMode()
        {
            return (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
        }

        private Color GetIntermediateColor()
        {
            Color c = this.StartColour;
            Color c2 = this.EndColour;

            float pc = (float)(this.Value * 1.0F / (this.MaxValue - this.MinValue));

            int ca = c.A;
            int cr = c.R;
            int cg = c.G;
            int cb = c.B;
            int c2a = c2.A;
            int c2r = c2.R;
            int c2g = c2.G;
            int c2b = c2.B;

            int a = System.Convert.ToInt32((int)(Math.Abs(ca + (ca - c2a) * pc)));
            int r = System.Convert.ToInt32((int)(Math.Abs(cr - ((cr - c2r) * pc))));
            int g = System.Convert.ToInt32((int)(Math.Abs(cg - ((cg - c2g) * pc))));
            int b = System.Convert.ToInt32((int)(Math.Abs(cb - ((cb - c2b) * pc))));

            if (a > 255)
            {
                a = 255;
            }
            if (r > 255)
            {
                r = 255;
            }
            if (g > 255)
            {
                g = 255;
            }
            if (b > 255)
            {
                b = 255;
            }

            return (Color.FromArgb(a, r, g, b));
        }

        #endregion

        #region -  Other  -

        private void ProgressBar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            DrawBackground(e.Graphics);
            DrawBackgroundShadows(e.Graphics);
            DrawBar(e.Graphics);
            DrawBarShadows(e.Graphics);
            DrawHighlight(e.Graphics);
            DrawString(e.Graphics, mDisplayText, this.Font, this.ForeColor);
            DrawInnerStroke(e.Graphics);
            DrawGlow(e.Graphics);
            DrawOuterStroke(e.Graphics);
        }

        private void mGlowAnimation_Tick(object sender, EventArgs e)
        {
            if (this.Animate)
            {
                mGlowPosition += 4;
                if (mGlowPosition > this.Width)
                {
                    mGlowPosition = -300;
                }
                this.Invalidate();
            }
            else
            {
                mGlowAnimation.Stop();
                mGlowPosition = -320;
            }
        }

        #endregion

        #region -  Events  -

        /// <summary>
        /// When the Value property is changed.
        /// </summary>
        public delegate void ValueChangedHandler(object sender, EventArgs e);
        /// <summary>
        /// When the Value property is changed.
        /// </summary>
        public event ValueChangedHandler ValueChanged;

        /// <summary>
        /// When the MinValue property is changed.
        /// </summary>
        public delegate void MinChangedHandler(object sender, EventArgs e);
        /// <summary>
        /// When the MinValue property is changed.
        /// </summary>
        public event MinChangedHandler MinChanged;

        /// <summary>
        /// When the MaxValue property is changed.
        /// </summary>
        public delegate void MaxChangedHandler(object sender, EventArgs e);
        /// <summary>
        /// When the MaxValue property is changed.
        /// </summary>
        public event MaxChangedHandler MaxChanged;

        #endregion
    }
}