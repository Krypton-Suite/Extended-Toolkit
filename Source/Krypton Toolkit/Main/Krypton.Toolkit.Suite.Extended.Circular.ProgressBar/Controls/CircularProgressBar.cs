#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

using WinFormAnimation_NET5;

namespace Krypton.Toolkit.Suite.Extended.Circular.ProgressBar
{
    /// <summary>The circular progress bar windows form control.</summary>
    [Description("A circular progress bar for your applications."), ToolboxItem(true),
     ToolboxBitmap(typeof(CircularProgressBar), "ToolboxBitmaps.CircularProgressBar.bmp"),
     DefaultBindingProperty("Value")]
    public class CircularProgressBar : System.Windows.Forms.ProgressBar
    {
        #region Variables
        private readonly Animator _animator;
        private int? _animatedStartAngle;
        private float? _animatedValue;
        private AnimationFunctions.Function _animationFunction;
        private Brush _backBrush;
        private KnownAnimationFunctions _knownAnimationFunction;
        private ProgressBarStyle? _lastStyle;
        private int _lastValue;
        private bool _useColourTrio;
        private Color _firstValueColour, _secondValueColour, _thirdValueColour;

        #region Krypton
        //Palette State
        private KryptonManager _manager = new KryptonManager();
        private PaletteBackInheritRedirect _paletteBack;
        private PaletteBorderInheritRedirect _paletteBorder;
        private PaletteContentInheritRedirect _paletteContent;

        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;
        #endregion

        #endregion

        #region Properties
        /// <summary>
        ///     Sets a known animation function.
        /// </summary>
        [Category("Behavior")]
        public KnownAnimationFunctions AnimationFunction
        {
            get => _knownAnimationFunction;
            set
            {
                _animationFunction = AnimationFunctions.FromKnown(value);
                _knownAnimationFunction = value;
            }
        }

        /// <summary>
        ///     Gets or sets the animation speed in milliseconds.
        /// </summary>
        [Category("Behavior")]
        public int AnimationSpeed { get; set; }

        /// <summary>
        ///     Sets a custom animation function.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public AnimationFunctions.Function CustomAnimationFunction
        {
            private get { return _animationFunction; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _knownAnimationFunction = KnownAnimationFunctions.None;
                _animationFunction = value;
            }
        }

        /// <summary>
        ///     Gets or sets the font of text in the <see cref="CircularProgressBar" />.
        /// </summary>
        /// <returns>
        ///     The <see cref="T:System.Drawing.Font" /> of the text. The default is the font set by the container.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public override Font Font
        {
            get => base.Font;
            set => base.Font = value;
        }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color InnerColour { get; set; }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int InnerMargin { get; set; }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int InnerWidth { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color OuterColour { get; set; }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int OuterMargin { get; set; }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int OuterWidth { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color ProgressColour { get; set; }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int ProgressWidth { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Font SecondaryFont { get; set; }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public int StartAngle { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color SubscriptColour { get; set; }


        /// <summary>
        /// </summary>
        [Category("Layout")]
        public Padding SubscriptMargin { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public string SubscriptText { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public Color SuperscriptColour { get; set; }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public Padding SuperscriptMargin { get; set; }

        /// <summary>
        /// </summary>
        [Category("Appearance")]
        public string SuperscriptText { get; set; }

        /// <summary>
        ///     Gets or sets the text in the <see cref="CircularProgressBar" />.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        /// <summary>
        /// </summary>
        [Category("Layout")]
        public Padding TextMargin { get; set; }

        [Category("Appearance"), DefaultValue(false), Description("Use three colours to depict the current values.")]
        public bool UseColourTrio { get => _useColourTrio; set => _useColourTrio = value; }

        public Color FirstValueColour { get => _firstValueColour; set => _firstValueColour = value; }

        public Color SecondValueColour { get => _secondValueColour; set => _secondValueColour = value; }

        public Color ThirdValueColour { get => _thirdValueColour; set => _thirdValueColour = value; }
        #endregion

        #region Constructor
        public CircularProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);

            _animator = DesignMode ? null : new Animator();

            AnimationFunction = KnownAnimationFunctions.Linear;

            AnimationSpeed = 500;

            MarqueeAnimationSpeed = 2000;

            StartAngle = 270;

            _lastValue = Value;

            DoubleBuffered = true;

            Font = new Font(Font.FontFamily, 72, FontStyle.Bold);

            SecondaryFont = new Font(Font.FontFamily, (float)(Font.Size * .5), FontStyle.Regular);

            OuterMargin = -25;

            OuterWidth = 26;

            ProgressWidth = 25;

            InnerMargin = 2;

            InnerWidth = -1;

            TextMargin = new Padding(8, 8, 0, 0);

            Value = 0;

            SuperscriptMargin = new Padding(10, 35, 0, 0);

            SuperscriptText = string.Empty;

            SubscriptMargin = new Padding(10, -35, 0, 0);

            SubscriptText = string.Empty;

            Size = new Size(320, 320);

            if (((_palette != null)))
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
            }

            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);

            _palette = KryptonManager.CurrentGlobalPalette;

            _paletteRedirect = new PaletteRedirect(_palette);

            _paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);

            _paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);

            _paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

            InitialiseKrypton();

            Text = "0";

            FirstValueColour = Color.Red;

            SecondValueColour = Color.FromArgb(255, 191, 0);

            ThirdValueColour = Color.Green;
        }
        #endregion

        #region Methods
        private static PointF AddPoint(PointF point, int value)
        {
            point.X += value;

            point.Y += value;

            return point;
        }

        private static SizeF AddSize(SizeF size, int value)
        {
            size.Height += value;

            size.Width += value;

            return size;
        }

        private static Rectangle ToRectangle(RectangleF rectangle) => new Rectangle((int)rectangle.X, (int)rectangle.Y, (int)rectangle.Width, (int)rectangle.Height);

        /// <summary>
        ///     Initialize the animation for the continues styling
        /// </summary>
        /// <param name="firstTime">True if it is the first execution of this function, otherwise false</param>
        protected virtual void InitialiseContinues(bool firstTime)
        {
            if (_lastValue == Value && !firstTime)
            {
                return;
            }

            _lastValue = Value;

            _animator.Stop();
            _animatedStartAngle = null;

            if (AnimationSpeed <= 0)
            {
                _animatedValue = Value;
                Invalidate();

                return;
            }

            _animator.Paths =
                new WinFormAnimation_NET5.Path(_animatedValue ?? Value, Value, (ulong)AnimationSpeed, CustomAnimationFunction).ToArray();
            _animator.Repeat = false;
            _animator.Play(
                new SafeInvoker<float>(
                    v =>
                    {
                        try
                        {
                            _animatedValue = v;
                            Invalidate();
                        }
                        catch
                        {
                            _animator.Stop();
                        }
                    },
                    this));
        }

        /// <summary>
        ///     Initialize the animation for the marquee styling
        /// </summary>
        /// <param name="firstTime">True if it is the first execution of this function, otherwise false</param>
        protected virtual void InitialiseMarquee(bool firstTime)
        {
            if (!firstTime &&
                (_animator.ActivePath == null ||
                 _animator.ActivePath.Duration == (ulong)MarqueeAnimationSpeed &&
                 _animator.ActivePath.Function == CustomAnimationFunction))
            {
                return;
            }

            _animator.Stop();
            _animatedValue = null;

            if (AnimationSpeed <= 0)
            {
                _animatedStartAngle = 0;
                Invalidate();

                return;
            }

            _animator.Paths = new WinFormAnimation_NET5.Path(0, 359, (ulong)MarqueeAnimationSpeed, CustomAnimationFunction).ToArray();
            _animator.Repeat = true;
            _animator.Play(
                new SafeInvoker<float>(
                    v =>
                    {
                        try
                        {
                            _animatedStartAngle = (int)(v % 360);
                            Invalidate();
                        }
                        catch
                        {
                            _animator.Stop();
                        }
                    },
                    this));
        }

        /// <summary>
        ///     Occurs when parent's display requires redrawing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="invalidateEventArgs"></param>
        protected virtual void ParentOnInvalidated(object sender, InvalidateEventArgs invalidateEventArgs) => RecreateBackgroundBrush();

        /// <summary>
        ///     Occurs when the parent resized.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        protected virtual void ParentOnResize(object sender, EventArgs eventArgs) => RecreateBackgroundBrush();

        /// <summary>
        ///     Update or create the brush used for drawing the background
        /// </summary>
        protected virtual void RecreateBackgroundBrush()
        {
            lock (this)
            {
                _backBrush?.Dispose();
                _backBrush = new SolidBrush(BackColor);

                if (BackColor.A == 255)
                {
                    return;
                }

                if (Parent != null && Parent.Width > 0 && Parent.Height > 0)
                {
                    using (var parentImage = new Bitmap(Parent.Width, Parent.Height))
                    {
                        using (var parentGraphic = Graphics.FromImage(parentImage))
                        {
                            var pe = new PaintEventArgs(parentGraphic,
                                new Rectangle(new Point(0, 0), parentImage.Size));
                            InvokePaintBackground(Parent, pe);
                            InvokePaint(Parent, pe);

                            if (BackColor.A > 0) // Translucent
                            {
                                parentGraphic.FillRectangle(_backBrush, Bounds);
                            }
                        }

                        _backBrush = new TextureBrush(parentImage);
                        ((TextureBrush)_backBrush).TranslateTransform(-Bounds.X, -Bounds.Y);
                    }
                }
                else
                {
                    _backBrush = new SolidBrush(Color.FromArgb(255, BackColor));
                }
            }
        }

        /// <summary>
        ///     The function responsible for painting the control
        /// </summary>
        /// <param name="g">The <see cref="Graphics" /> object to draw into</param>
        protected virtual void StartPaint(Graphics g)
        {
            try
            {
                lock (this)
                {
                    g.TextRenderingHint = TextRenderingHint.AntiAlias;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    var point = AddPoint(Point.Empty, 2);
                    var size = AddSize(Size, -2 * 2);

                    if (OuterWidth + OuterMargin < 0)
                    {
                        var offset = Math.Abs(OuterWidth + OuterMargin);
                        point = AddPoint(Point.Empty, offset);
                        size = AddSize(Size, -2 * offset);
                    }

                    if (OuterColour != Color.Empty && OuterColour != Color.Transparent && OuterWidth != 0)
                    {
                        g.FillEllipse(new SolidBrush(OuterColour), new RectangleF(point, size));

                        if (OuterWidth >= 0)
                        {
                            point = AddPoint(point, OuterWidth);
                            size = AddSize(size, -2 * OuterWidth);
                            g.FillEllipse(_backBrush, new RectangleF(point, size));
                        }
                    }

                    point = AddPoint(point, OuterMargin);
                    size = AddSize(size, -2 * OuterMargin);

                    g.FillPie(
                        new SolidBrush(ProgressColour),
                        ToRectangle(new RectangleF(point, size)),
                        _animatedStartAngle ?? StartAngle,
                        ((_animatedValue ?? Value) - Minimum) / (Maximum - Minimum) * 360);

                    if (ProgressWidth >= 0)
                    {
                        point = AddPoint(point, ProgressWidth);
                        size = AddSize(size, -2 * ProgressWidth);
                        g.FillEllipse(_backBrush, new RectangleF(point, size));
                    }

                    point = AddPoint(point, InnerMargin);
                    size = AddSize(size, -2 * InnerMargin);

                    if (InnerColour != Color.Empty && InnerColour != Color.Transparent && InnerWidth != 0)
                    {
                        g.FillEllipse(new SolidBrush(InnerColour), new RectangleF(point, size));

                        if (InnerWidth >= 0)
                        {
                            point = AddPoint(point, InnerWidth);
                            size = AddSize(size, -2 * InnerWidth);
                            g.FillEllipse(_backBrush, new RectangleF(point, size));
                        }
                    }

                    if (Text == string.Empty)
                    {
                        return;
                    }

                    point.X += TextMargin.Left;
                    point.Y += TextMargin.Top;
                    size.Width -= TextMargin.Right;
                    size.Height -= TextMargin.Bottom;
                    var stringFormat =
                        new StringFormat(RightToLeft == RightToLeft.Yes ? StringFormatFlags.DirectionRightToLeft : 0)
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Near
                        };
                    var textSize = g.MeasureString(Text, Font);
                    var textPoint = new PointF(
                        point.X + (size.Width - textSize.Width) / 2,
                        point.Y + (size.Height - textSize.Height) / 2);

                    if (SubscriptText != string.Empty || SuperscriptText != string.Empty)
                    {
                        float maxSWidth = 0;
                        var supSize = SizeF.Empty;
                        var subSize = SizeF.Empty;

                        if (SuperscriptText != string.Empty)
                        {
                            supSize = g.MeasureString(SuperscriptText, SecondaryFont);
                            maxSWidth = Math.Max(supSize.Width, maxSWidth);
                            supSize.Width -= SuperscriptMargin.Right;
                            supSize.Height -= SuperscriptMargin.Bottom;
                        }

                        if (SubscriptText != string.Empty)
                        {
                            subSize = g.MeasureString(SubscriptText, SecondaryFont);
                            maxSWidth = Math.Max(subSize.Width, maxSWidth);
                            subSize.Width -= SubscriptMargin.Right;
                            subSize.Height -= SubscriptMargin.Bottom;
                        }

                        textPoint.X -= maxSWidth / 4;

                        if (SuperscriptText != string.Empty)
                        {
                            var supPoint = new PointF(
                                textPoint.X + textSize.Width - supSize.Width / 2,
                                textPoint.Y - supSize.Height * 0.85f);
                            supPoint.X += SuperscriptMargin.Left;
                            supPoint.Y += SuperscriptMargin.Top;
                            g.DrawString(
                                SuperscriptText,
                                SecondaryFont,
                                new SolidBrush(SuperscriptColour),
                                new RectangleF(supPoint, supSize),
                                stringFormat);
                        }

                        if (SubscriptText != string.Empty)
                        {
                            var subPoint = new PointF(
                                textPoint.X + textSize.Width - subSize.Width / 2,
                                textPoint.Y + textSize.Height * 0.85f);
                            subPoint.X += SubscriptMargin.Left;
                            subPoint.Y += SubscriptMargin.Top;
                            g.DrawString(
                                SubscriptText,
                                SecondaryFont,
                                new SolidBrush(SubscriptColour),
                                new RectangleF(subPoint, subSize),
                                stringFormat);
                        }
                    }

                    g.DrawString(
                        Text,
                        Font,
                        new SolidBrush(ForeColor),
                        new RectangleF(textPoint, textSize),
                        stringFormat);
                }
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>Increments the specified value.</summary>
        /// <param name="step">The step.</param>
        public void Increment(int step) => Value = Value + step;
        #endregion

        #region Overrides
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    if (Style == ProgressBarStyle.Marquee)
                    {
                        InitialiseMarquee(_lastStyle != Style);
                    }
                    else
                    {
                        InitialiseMarquee(_lastStyle != Style);
                    }

                    _lastStyle = Style;
                }

                if (_backBrush == null)
                {
                    RecreateBackgroundBrush();
                }

                if (_useColourTrio)
                {
                    if (Value <= 33)
                    {
                        ProgressColour = _firstValueColour;
                    }
                    else if (Value <= 66)
                    {
                        ProgressColour = _secondValueColour; // _palette.ColorTable.ButtonCheckedGradientBegin;
                    }
                    else
                    {
                        ProgressColour = _thirdValueColour;
                    }
                }
                else
                {
                    InitialiseKrypton();
                }

                StartPaint(e.Graphics);
            }
            catch (Exception exc)
            {

                throw;
            }
        }

        protected override void OnParentBackColorChanged(EventArgs e) => RecreateBackgroundBrush();

        protected override void OnParentBackgroundImageChanged(EventArgs e) => RecreateBackgroundBrush();

        protected override void OnParentChanged(EventArgs e)
        {
            if (Parent != null)
            {
                Parent.Invalidated -= ParentOnInvalidated;

                Parent.Resize -= ParentOnResize;
            }

            base.OnParentChanged(e);

            if (Parent != null)
            {
                Parent.Invalidated += ParentOnInvalidated;

                Parent.Resize += ParentOnResize;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            Invalidate();
        }
        #endregion

        #region Krypton
        private void InitialiseKrypton()
        {
            BackColor = Color.Transparent;

            ForeColor = _palette.ColorTable.MenuItemText;

            OuterColour = _palette.ColorTable.ToolStripGradientBegin;

            ProgressColour = _palette.ColorTable.ButtonCheckedGradientBegin;

            InnerColour = _palette.ColorTable.OverflowButtonGradientBegin;

            SuperscriptColour = _palette.ColorTable.MenuStripText;

            SubscriptColour = _palette.ColorTable.StatusStripText;
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
                InitialiseKrypton();
            }
            Invalidate();
        }

        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e) => Invalidate();
        #endregion
    }
}