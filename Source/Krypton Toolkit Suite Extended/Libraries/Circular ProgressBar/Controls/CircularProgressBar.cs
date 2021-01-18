using Krypton.Toolkit.Suite.Extended.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Circular.Progress.Bar.Suite
{
    /// <summary>The circular progress bar windows form control.</summary>
    [ToolboxItem(true), ToolboxBitmap(typeof(CircularProgressBar), "ToolboxBitmaps.CircularProgressBar.bmp"),
     DefaultBindingProperty("Value")]
    public class CircularProgressBar : ProgressBar
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
        #endregion

        #region Constructor
        public CircularProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
        }
        #endregion
    }
}