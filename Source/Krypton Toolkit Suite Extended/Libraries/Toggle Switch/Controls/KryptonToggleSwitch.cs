using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Toggle.Switch
{
    [DefaultValue("Checked"), DefaultEvent("CheckedChanged"), ToolboxBitmap(typeof(CheckBox))]
    public class KryptonToggleSwitch : Control
    {
        #region Delegate and Event declarations

        public delegate void CheckedChangedDelegate(object sender, EventArgs e);
        [Description("Raised when the ToggleSwitch has changed state")]
        public event CheckedChangedDelegate CheckedChanged;

        public delegate void BeforeRenderingDelegate(object sender, BeforeRenderingEventArgs e);
        [Description("Raised when the ToggleSwitch renderer is changed")]
        public event BeforeRenderingDelegate BeforeRendering;

        #endregion

        #region Private Members

        private readonly Timer _animationTimer = new Timer();
        private ToggleSwitchRendererBase _renderer;

        private ToggleSwitchStyle _style = ToggleSwitchStyle.METRO;
        private bool _checked = false;
        private bool _moving = false;
        private bool _animating = false;
        private bool _animationResult = false;
        private int _animationTarget = 0;
        private bool _useAnimation = true;
        private int _animationInterval = 1;
        private int _animationStep = 10;
        private bool _allowUserChange = true;

        private bool _isLeftFieldHovered = false;
        private bool _isButtonHovered = false;
        private bool _isRightFieldHovered = false;
        private bool _isLeftFieldPressed = false;
        private bool _isButtonPressed = false;
        private bool _isRightFieldPressed = false;

        private int _buttonValue = 0;
        private int _savedButtonValue = 0;
        private int _xOffset = 0;
        private int _xValue = 0;
        private int _thresholdPercentage = 50;
        private bool _grayWhenDisabled = true;
        private bool _toggleOnButtonClick = true;
        private bool _toggleOnSideClick = true;

        private MouseEventArgs _lastMouseEventArgs = null;

        private bool _buttonScaleImage;
        private ToggleSwitchButtonAlignment _buttonAlignment = ToggleSwitchButtonAlignment.CENTER;
        private Image _buttonImage = null;

        private string _offText = "";
        private Color _offForeColour = Color.Black;
        private Font _offFont;
        private Image _offSideImage = null;
        private bool _offSideScaleImage;
        private ToggleSwitchAlignment _offSideAlignment = ToggleSwitchAlignment.CENTER;
        private Image _offButtonImage = null;
        private bool _offButtonScaleImage;
        private ToggleSwitchButtonAlignment _offButtonAlignment = ToggleSwitchButtonAlignment.CENTER;

        private string _onText = "";
        private Color _onForeColour = Color.Black;
        private Font _onFont;
        private Image _onSideImage = null;
        private bool _onSideScaleImage;
        private ToggleSwitchAlignment _onSideAlignment = ToggleSwitchAlignment.CENTER;
        private Image _onButtonImage = null;
        private bool _onButtonScaleImage;
        private ToggleSwitchButtonAlignment _onButtonAlignment = ToggleSwitchButtonAlignment.CENTER;

        #endregion

        #region Constructor
        public KryptonToggleSwitch()
        {
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer, true);

            OnFont = base.Font;
            OffFont = base.Font;

            SetRenderer(new ToggleSwitchMetroRenderer());

            _animationTimer.Enabled = false;
            _animationTimer.Interval = _animationInterval;
            _animationTimer.Tick += AnimationTimer_Tick;
        }
        #endregion

        #region Methods
        public void SetRenderer(ToggleSwitchRendererBase renderer)
        {
            renderer.SetToggleSwitch(this);
            _renderer = renderer;

            if (_renderer != null)
                Refresh();
        }
        #endregion

        #region Public Properties

        [Bindable(false)]
        [DefaultValue(typeof(ToggleSwitchStyle), "Metro")]
        [Category("Appearance")]
        [Description("Gets or sets the style of the ToggleSwitch")]
        public ToggleSwitchStyle Style
        {
            get { return _style; }
            set
            {
                if (value != _style)
                {
                    _style = value;

                    switch (_style)
                    {
                        case ToggleSwitchStyle.METRO:
                            SetRenderer(new ToggleSwitchMetroRenderer());
                            break;
                        case ToggleSwitchStyle.ANDROID:
                            SetRenderer(new ToggleSwitchAndroidRenderer());
                            break;
                        case ToggleSwitchStyle.IOS5:
                            SetRenderer(new ToggleSwitchIOS5Renderer());
                            break;
                        case ToggleSwitchStyle.BRUSHEDMETAL:
                            SetRenderer(new ToggleSwitchBrushedMetalRenderer());
                            break;
                        case ToggleSwitchStyle.OSX:
                            SetRenderer(new ToggleSwitchOSXRenderer());
                            break;
                        case ToggleSwitchStyle.CARBON:
                            SetRenderer(new ToggleSwitchCarbonRenderer());
                            break;
                        case ToggleSwitchStyle.IPHONE:
                            SetRenderer(new ToggleSwitchIphoneRenderer());
                            break;
                        case ToggleSwitchStyle.FANCY:
                            SetRenderer(new ToggleSwitchFancyRenderer());
                            break;
                        case ToggleSwitchStyle.MODERN:
                            SetRenderer(new ToggleSwitchModernRenderer());
                            break;
                        case ToggleSwitchStyle.PLAINANDSIMPLE:
                            SetRenderer(new ToggleSwitchPlainAndSimpleRenderer());
                            break;
                        case ToggleSwitchStyle.KRYPTON:
                            break;
                    }
                }

                Refresh();
            }
        }

        [Bindable(true)]
        [DefaultValue(false)]
        [Category("Data")]
        [Description("Gets or sets the Checked value of the ToggleSwitch")]
        public bool Checked
        {
            get { return _checked; }
            set
            {
                if (value != _checked)
                {
                    while (_animating)
                    {
                        Application.DoEvents();
                    }

                    if (value == true)
                    {
                        int buttonWidth = _renderer.GetButtonWidth();
                        _animationTarget = Width - buttonWidth;
                        BeginAnimation(true);
                    }
                    else
                    {
                        _animationTarget = 0;
                        BeginAnimation(false);
                    }
                }
            }
        }

        [Bindable(true)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("Gets or sets whether the user can change the value of the button or not")]
        public bool AllowUserChange
        {
            get { return _allowUserChange; }
            set { _allowUserChange = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CheckedString
        {
            get
            {
                return Checked ? (string.IsNullOrEmpty(OnText) ? "ON" : OnText) : (string.IsNullOrEmpty(OffText) ? "OFF" : OffText);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle ButtonRectangle
        {
            get
            {
                return _renderer.GetButtonRectangle();
            }
        }

        [Bindable(false)]
        [DefaultValue(true)]
        [Category("Appearance")]
        [Description("Gets or sets if the ToggleSwitch should be grayed out when disabled")]
        public bool GrayWhenDisabled
        {
            get { return _grayWhenDisabled; }
            set
            {
                if (value != _grayWhenDisabled)
                {
                    _grayWhenDisabled = value;

                    if (!Enabled)
                        Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("Gets or sets if the ToggleSwitch should toggle when the button is clicked")]
        public bool ToggleOnButtonClick
        {
            get { return _toggleOnButtonClick; }
            set { _toggleOnButtonClick = value; }
        }

        [Bindable(false)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("Gets or sets if the ToggleSwitch should toggle when the track besides the button is clicked")]
        public bool ToggleOnSideClick
        {
            get { return _toggleOnSideClick; }
            set { _toggleOnSideClick = value; }
        }

        [Bindable(false)]
        [DefaultValue(50)]
        [Category("Behavior")]
        [Description("Gets or sets how much the button need to be on the other side (in percent) before it snaps")]
        public int ThresholdPercentage
        {
            get { return _thresholdPercentage; }
            set { _thresholdPercentage = value; }
        }

        [Bindable(false)]
        [DefaultValue(typeof(Color), "Black")]
        [Category("Appearance")]
        [Description("Gets or sets the forecolor of the text when Checked=false")]
        public Color OffForeColour
        {
            get { return _offForeColour; }
            set
            {
                if (value != _offForeColour)
                {
                    _offForeColour = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25pt")]
        [Category("Appearance")]
        [Description("Gets or sets the font of the text when Checked=false")]
        public Font OffFont
        {
            get { return _offFont; }
            set
            {
                if (!value.Equals(_offFont))
                {
                    _offFont = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue("")]
        [Category("Appearance")]
        [Description("Gets or sets the text when Checked=true")]
        public string OffText
        {
            get { return _offText; }
            set
            {
                if (value != _offText)
                {
                    _offText = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(null)]
        [Category("Appearance")]
        [Description("Gets or sets the side image when Checked=false - Note: Settings the OffSideImage overrules the OffText property. Only the image will be shown")]
        public Image OffSideImage
        {
            get { return _offSideImage; }
            set
            {
                if (value != _offSideImage)
                {
                    _offSideImage = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Gets or sets whether the side image visible when Checked=false should be scaled to fit")]
        public bool OffSideScaleImageToFit
        {
            get { return _offSideScaleImage; }
            set
            {
                if (value != _offSideScaleImage)
                {
                    _offSideScaleImage = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(typeof(ToggleSwitchAlignment), "Center")]
        [Category("Appearance")]
        [Description("Gets or sets how the text or side image visible when Checked=false should be aligned")]
        public ToggleSwitchAlignment OffSideAlignment
        {
            get { return _offSideAlignment; }
            set
            {
                if (value != _offSideAlignment)
                {
                    _offSideAlignment = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(null)]
        [Category("Appearance")]
        [Description("Gets or sets the button image when Checked=false and ButtonImage is not set")]
        public Image OffButtonImage
        {
            get { return _offButtonImage; }
            set
            {
                if (value != _offButtonImage)
                {
                    _offButtonImage = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Gets or sets whether the button image visible when Checked=false should be scaled to fit")]
        public bool OffButtonScaleImageToFit
        {
            get { return _offButtonScaleImage; }
            set
            {
                if (value != _offButtonScaleImage)
                {
                    _offButtonScaleImage = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(typeof(ToggleSwitchButtonAlignment), "Center")]
        [Category("Appearance")]
        [Description("Gets or sets how the button image visible when Checked=false should be aligned")]
        public ToggleSwitchButtonAlignment OffButtonAlignment
        {
            get { return _offButtonAlignment; }
            set
            {
                if (value != _offButtonAlignment)
                {
                    _offButtonAlignment = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(typeof(Color), "Black")]
        [Category("Appearance")]
        [Description("Gets or sets the forecolor of the text when Checked=true")]
        public Color OnForeColour
        {
            get { return _onForeColour; }
            set
            {
                if (value != _onForeColour)
                {
                    _onForeColour = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8,25pt")]
        [Category("Appearance")]
        [Description("Gets or sets the font of the text when Checked=true")]
        public Font OnFont
        {
            get { return _onFont; }
            set
            {
                if (!value.Equals(_onFont))
                {
                    _onFont = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue("")]
        [Category("Appearance")]
        [Description("Gets or sets the text when Checked=true")]
        public string OnText
        {
            get { return _onText; }
            set
            {
                if (value != _onText)
                {
                    _onText = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(null)]
        [Category("Appearance")]
        [Description("Gets or sets the side image visible when Checked=true - Note: Settings the OnSideImage overrules the OnText property. Only the image will be shown.")]
        public Image OnSideImage
        {
            get { return _onSideImage; }
            set
            {
                if (value != _onSideImage)
                {
                    _onSideImage = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Gets or sets whether the side image visible when Checked=true should be scaled to fit")]
        public bool OnSideScaleImageToFit
        {
            get { return _onSideScaleImage; }
            set
            {
                if (value != _onSideScaleImage)
                {
                    _onSideScaleImage = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(null)]
        [Category("Appearance")]
        [Description("Gets or sets the button image")]
        public Image ButtonImage
        {
            get { return _buttonImage; }
            set
            {
                if (value != _buttonImage)
                {
                    _buttonImage = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Gets or sets whether the button image should be scaled to fit")]
        public bool ButtonScaleImageToFit
        {
            get { return _buttonScaleImage; }
            set
            {
                if (value != _buttonScaleImage)
                {
                    _buttonScaleImage = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(typeof(ToggleSwitchButtonAlignment), "Center")]
        [Category("Appearance")]
        [Description("Gets or sets how the button image should be aligned")]
        public ToggleSwitchButtonAlignment ButtonAlignment
        {
            get { return _buttonAlignment; }
            set
            {
                if (value != _buttonAlignment)
                {
                    _buttonAlignment = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(typeof(ToggleSwitchAlignment), "Center")]
        [Category("Appearance")]
        [Description("Gets or sets how the text or side image visible when Checked=true should be aligned")]
        public ToggleSwitchAlignment OnSideAlignment
        {
            get { return _onSideAlignment; }
            set
            {
                if (value != _onSideAlignment)
                {
                    _onSideAlignment = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(null)]
        [Category("Appearance")]
        [Description("Gets or sets the button image visible when Checked=true and ButtonImage is not set")]
        public Image OnButtonImage
        {
            get { return _onButtonImage; }
            set
            {
                if (value != _onButtonImage)
                {
                    _onButtonImage = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(false)]
        [Category("Behavior")]
        [Description("Gets or sets whether the button image visible when Checked=true should be scaled to fit")]
        public bool OnButtonScaleImageToFit
        {
            get { return _onButtonScaleImage; }
            set
            {
                if (value != _onButtonScaleImage)
                {
                    _onButtonScaleImage = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(typeof(ToggleSwitchButtonAlignment), "Center")]
        [Category("Appearance")]
        [Description("Gets or sets how the button image visible when Checked=true should be aligned")]
        public ToggleSwitchButtonAlignment OnButtonAlignment
        {
            get { return _onButtonAlignment; }
            set
            {
                if (value != _onButtonAlignment)
                {
                    _onButtonAlignment = value;
                    Refresh();
                }
            }
        }

        [Bindable(false)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("Gets or sets whether the toggle change should be animated or not")]
        public bool UseAnimation
        {
            get { return _useAnimation; }
            set { _useAnimation = value; }
        }

        [Bindable(false)]
        [DefaultValue(1)]
        [Category("Behavior")]
        [Description("Gets or sets the interval in ms between animation frames")]
        public int AnimationInterval
        {
            get { return _animationInterval; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("AnimationInterval must larger than zero!");
                }

                _animationInterval = value;
            }
        }

        [Bindable(false)]
        [DefaultValue(10)]
        [Category("Behavior")]
        [Description("Gets or sets the step in pixes the button shouldbe moved between each animation interval")]
        public int AnimationStep
        {
            get { return _animationStep; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("AnimationStep must larger than zero!");
                }

                _animationStep = value;
            }
        }

        #region Hidden Base Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Text
        {
            get { return ""; }
            set { base.Text = ""; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color ForeColor
        {
            get { return Color.Black; }
            set { base.ForeColor = Color.Black; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Font Font
        {
            get { return base.Font; }
            set { base.Font = new Font(base.Font, FontStyle.Regular); }
        }

        #endregion Hidden Base Properties

        #endregion Public Properties

        #region Internal Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonHovered
        {
            get { return _isButtonHovered && !_isButtonPressed; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonPressed
        {
            get { return _isButtonPressed; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsLeftSideHovered
        {
            get { return _isLeftFieldHovered && !_isLeftFieldPressed; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsLeftSidePressed
        {
            get { return _isLeftFieldPressed; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsRightSideHovered
        {
            get { return _isRightFieldHovered && !_isRightFieldPressed; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsRightSidePressed
        {
            get { return _isRightFieldPressed; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int ButtonValue
        {
            get
            {
                if (_animating || _moving)
                    return _buttonValue;
                else if (_checked)
                    return Width - _renderer.GetButtonWidth();
                else
                    return 0;
            }
            set
            {
                if (value != _buttonValue)
                {
                    _buttonValue = value;
                    Refresh();
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonOnLeftSide
        {
            get { return (ButtonValue <= 0); }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonOnRightSide
        {
            get { return (ButtonValue >= (Width - _renderer.GetButtonWidth())); }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonMovingLeft
        {
            get { return (_animating && !IsButtonOnLeftSide && _animationResult == false); }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonMovingRight
        {
            get { return (_animating && !IsButtonOnRightSide && _animationResult == true); }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool AnimationResult
        {
            get { return _animationResult; }
        }

        #endregion

        #region Overrides
        protected override Size DefaultSize => new Size(50, 19);


        #endregion
    }
}
