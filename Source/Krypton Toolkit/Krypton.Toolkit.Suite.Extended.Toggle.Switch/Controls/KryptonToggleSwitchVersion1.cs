﻿#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Toggle.Switch
{
    [DefaultValue("Checked"), DefaultEvent("CheckedChanged"), ToolboxBitmap(typeof(CheckBox)), ToolboxItem(false)]
    public class KryptonToggleSwitchVersion1 : Control
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

        private readonly System.Windows.Forms.Timer _animationTimer = new();
        private ToggleSwitchRendererBase _renderer;

        private ToggleSwitchStyle _style = ToggleSwitchStyle.Metro;
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
        private bool _useKryptonRender = false;

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
        private ToggleSwitchButtonAlignment _buttonAlignment = ToggleSwitchButtonAlignment.Center;
        private Image _buttonImage = null;

        private string _offText = "";
        private Color _offForeColour = Color.Black;
        private Font _offFont;
        private Image _offSideImage = null;
        private bool _offSideScaleImage;
        private ToggleSwitchAlignment _offSideAlignment = ToggleSwitchAlignment.Center;
        private Image _offButtonImage = null;
        private bool _offButtonScaleImage;
        private ToggleSwitchButtonAlignment _offButtonAlignment = ToggleSwitchButtonAlignment.Center;

        private string _onText = "";
        private Color _onForeColour = Color.Black;
        private Font _onFont;
        private Image _onSideImage = null;
        private bool _onSideScaleImage;
        private ToggleSwitchAlignment _onSideAlignment = ToggleSwitchAlignment.Center;
        private Image _onButtonImage = null;
        private bool _onButtonScaleImage;
        private ToggleSwitchButtonAlignment _onButtonAlignment = ToggleSwitchButtonAlignment.Center;

        #endregion

        #region Constructor
        public KryptonToggleSwitchVersion1()
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

        private void SetValueInternal(bool checkedValue)
        {
            if (checkedValue == _checked)
                return;

            while (_animating)
            {
                Application.DoEvents();
            }

            BeginAnimation(checkedValue);
        }

        private void BeginAnimation(bool checkedValue)
        {
            _animating = true;
            _animationResult = checkedValue;

            if (_animationTimer != null && _useAnimation)
            {
                _animationTimer.Interval = _animationInterval;
                _animationTimer.Enabled = true;
            }
            else
            {
                AnimationComplete();
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            _animationTimer.Enabled = false;

            bool animationDone = false;
            int newButtonValue;

            if (IsButtonMovingRight)
            {
                newButtonValue = ButtonValue + _animationStep;

                if (newButtonValue > _animationTarget)
                    newButtonValue = _animationTarget;

                ButtonValue = newButtonValue;

                animationDone = ButtonValue >= _animationTarget;
            }
            else
            {
                newButtonValue = ButtonValue - _animationStep;

                if (newButtonValue < _animationTarget)
                    newButtonValue = _animationTarget;

                ButtonValue = newButtonValue;

                animationDone = ButtonValue <= _animationTarget;
            }

            if (animationDone)
                AnimationComplete();
            else
                _animationTimer.Enabled = true;
        }

        private void AnimationComplete()
        {
            _animating = false;
            _moving = false;
            _checked = _animationResult;

            _isButtonHovered = false;
            _isButtonPressed = false;
            _isLeftFieldHovered = false;
            _isLeftFieldPressed = false;
            _isRightFieldHovered = false;
            _isRightFieldPressed = false;

            Refresh();

            if (CheckedChanged != null)
                CheckedChanged(this, new EventArgs());

            if (_lastMouseEventArgs != null)
                OnMouseMove(_lastMouseEventArgs);

            _lastMouseEventArgs = null;
        }
        #endregion

        #region Public Properties

        [Bindable(false)]
        [DefaultValue(typeof(ToggleSwitchStyle), "Metro")]
        [Category("Appearance")]
        [Description("Gets or sets the style of the ToggleSwitch")]
        public ToggleSwitchStyle Style
        {
            get => _style;
            set
            {
                if (value != _style)
                {
                    _style = value;

                    switch (_style)
                    {
                        case ToggleSwitchStyle.Metro:
                            if (_useKryptonRender)
                            {
                                SetRenderer(new ToggleSwitchMetroKryptonRenderer());
                            }
                            else
                            {
                                SetRenderer(new ToggleSwitchMetroRenderer());
                            }
                            break;
                        case ToggleSwitchStyle.Android:
                            if (_useKryptonRender)
                            {
                                SetRenderer(new ToggleSwitchAndroidKryptonRenderer());
                            }
                            else
                            {
                                SetRenderer(new ToggleSwitchAndroidRenderer());
                            }
                            break;
                        case ToggleSwitchStyle.iOS5:

                            if (_useKryptonRender)
                            {
                                SetRenderer(new ToggleSwitchIOS5KryptonRenderer());
                            }
                            else
                            {
                                SetRenderer(new ToggleSwitchIOS5Renderer());
                            }
                            break;
                        case ToggleSwitchStyle.BrushedMetal:

                            if (_useKryptonRender)
                            {
                                SetRenderer(new ToggleSwitchBrushedMetalKryptonRenderer());
                            }
                            else
                            {
                                SetRenderer(new ToggleSwitchBrushedMetalRenderer());
                            }
                            break;
                        case ToggleSwitchStyle.macOS:

                            if (_useKryptonRender)
                            {
                                SetRenderer(new ToggleSwitchOSXKryptonRenderer());
                            }
                            else
                            {
                                SetRenderer(new ToggleSwitchOSXRenderer());
                            }
                            break;
                        case ToggleSwitchStyle.Carbon:

                            if (_useKryptonRender)
                            {
                                SetRenderer(new ToggleSwitchCarbonKryptonRenderer());
                            }
                            else
                            {
                                SetRenderer(new ToggleSwitchCarbonRenderer());
                            }
                            break;
                        case ToggleSwitchStyle.iPhone:

                            if (_useKryptonRender)
                            {
                                SetRenderer(new ToggleSwitchIphoneKryptonRenderer());
                            }
                            else
                            {
                                SetRenderer(new ToggleSwitchIphoneRenderer());
                            }
                            break;
                        case ToggleSwitchStyle.Fancy:

                            if (_useKryptonRender)
                            {
                                SetRenderer(new ToggleSwitchFancyKryptonRenderer());
                            }
                            else
                            {
                                SetRenderer(new ToggleSwitchFancyRenderer());
                            }
                            break;
                        case ToggleSwitchStyle.Modern:

                            if (_useKryptonRender)
                            {
                                SetRenderer(new ToggleSwitchModernKryptonRenderer());
                            }
                            else
                            {
                                SetRenderer(new ToggleSwitchModernRenderer());
                            }
                            break;
                        case ToggleSwitchStyle.PlainAndSimple:

                            if (_useKryptonRender)
                            {
                                SetRenderer(new ToggleSwitchPlainAndSimpleKryptonRenderer());
                            }
                            else
                            {
                                SetRenderer(new ToggleSwitchPlainAndSimpleRenderer());
                            }
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
            get => _checked;
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
            get => _allowUserChange;
            set => _allowUserChange = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CheckedString => Checked ? (string.IsNullOrEmpty(OnText) ? "ON" : OnText) : (string.IsNullOrEmpty(OffText) ? "OFF" : OffText);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rectangle ButtonRectangle => _renderer.GetButtonRectangle();

        [Bindable(false)]
        [DefaultValue(true)]
        [Category("Appearance")]
        [Description("Gets or sets if the ToggleSwitch should be grayed out when disabled")]
        public bool GrayWhenDisabled
        {
            get => _grayWhenDisabled;
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
            get => _toggleOnButtonClick;
            set => _toggleOnButtonClick = value;
        }

        [Bindable(false)]
        [DefaultValue(true)]
        [Category("Behavior")]
        [Description("Gets or sets if the ToggleSwitch should toggle when the track besides the button is clicked")]
        public bool ToggleOnSideClick
        {
            get => _toggleOnSideClick;
            set => _toggleOnSideClick = value;
        }

        [Bindable(false)]
        [DefaultValue(50)]
        [Category("Behavior")]
        [Description("Gets or sets how much the button need to be on the other side (in percent) before it snaps")]
        public int ThresholdPercentage
        {
            get => _thresholdPercentage;
            set => _thresholdPercentage = value;
        }

        [Bindable(false)]
        [DefaultValue(typeof(Color), "Black")]
        [Category("Appearance")]
        [Description("Gets or sets the forecolor of the text when Checked=false")]
        public Color OffForeColour
        {
            get => _offForeColour;
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
            get => _offFont;
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
            get => _offText;
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
            get => _offSideImage;
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
            get => _offSideScaleImage;
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
            get => _offSideAlignment;
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
            get => _offButtonImage;
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
            get => _offButtonScaleImage;
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
            get => _offButtonAlignment;
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
            get => _onForeColour;
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
            get => _onFont;
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
            get => _onText;
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
            get => _onSideImage;
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
            get => _onSideScaleImage;
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
            get => _buttonImage;
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
            get => _buttonScaleImage;
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
            get => _buttonAlignment;
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
            get => _onSideAlignment;
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
            get => _onButtonImage;
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
            get => _onButtonScaleImage;
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
            get => _onButtonAlignment;
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
            get => _useAnimation;
            set => _useAnimation = value;
        }

        [DefaultValue(false), Category("Appearance"), Description("Gets or sets whether the toggle change should use the krypton renderer or not")]
        public bool UseKryptonRender { get => _useKryptonRender; set { _useKryptonRender = value; Refresh(); } }

        [Bindable(false)]
        [DefaultValue(1)]
        [Category("Behavior")]
        [Description("Gets or sets the interval in ms between animation frames")]
        public int AnimationInterval
        {
            get => _animationInterval;
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
            get => _animationStep;
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
            get => "";
            set => base.Text = "";
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color ForeColor
        {
            get => Color.Black;
            set => base.ForeColor = Color.Black;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Font Font
        {
            get => base.Font;
            set => base.Font = new Font(base.Font, FontStyle.Regular);
        }

        #endregion Hidden Base Properties

        #endregion Public Properties

        #region Internal Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonHovered => _isButtonHovered && !_isButtonPressed;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonPressed => _isButtonPressed;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsLeftSideHovered => _isLeftFieldHovered && !_isLeftFieldPressed;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsLeftSidePressed => _isLeftFieldPressed;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsRightSideHovered => _isRightFieldHovered && !_isRightFieldPressed;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsRightSidePressed => _isRightFieldPressed;

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
        internal bool IsButtonOnLeftSide => (ButtonValue <= 0);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonOnRightSide => (ButtonValue >= (Width - _renderer.GetButtonWidth()));

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonMovingLeft => (_animating && !IsButtonOnLeftSide && _animationResult == false);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool IsButtonMovingRight => (_animating && !IsButtonOnRightSide && _animationResult == true);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool AnimationResult => _animationResult;

        #endregion

        #region Overrides
        protected override Size DefaultSize => new(50, 19);

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            pevent.Graphics.ResetClip();

            base.OnPaintBackground(pevent);

            if (_renderer != null)
            {
                _renderer.RenderBackground(pevent);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.ResetClip();

            base.OnPaint(e);

            if (_renderer != null)
            {
                if (BeforeRendering != null)
                {
                    BeforeRendering(this, new BeforeRenderingEventArgs(_renderer));
                }

                _renderer.RenderControl(e);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            _lastMouseEventArgs = e;

            int buttonWidth = _renderer.GetButtonWidth();
            Rectangle buttonRectangle = _renderer.GetButtonRectangle(buttonWidth);

            if (_moving)
            {
                int val = _xValue + (e.Location.X - _xOffset);

                if (val < 0)
                    val = 0;

                if (val > Width - buttonWidth)
                    val = Width - buttonWidth;

                ButtonValue = val;
                Refresh();
                return;
            }

            if (buttonRectangle.Contains(e.Location))
            {
                _isButtonHovered = true;
                _isLeftFieldHovered = false;
                _isRightFieldHovered = false;
            }
            else
            {
                if (e.Location.X > buttonRectangle.X + buttonRectangle.Width)
                {
                    _isButtonHovered = false;
                    _isLeftFieldHovered = false;
                    _isRightFieldHovered = true;
                }
                else if (e.Location.X < buttonRectangle.X)
                {
                    _isButtonHovered = false;
                    _isLeftFieldHovered = true;
                    _isRightFieldHovered = false;
                }
            }

            Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (_animating || !AllowUserChange)
                return;

            int buttonWidth = _renderer.GetButtonWidth();
            Rectangle buttonRectangle = _renderer.GetButtonRectangle(buttonWidth);

            _savedButtonValue = ButtonValue;

            if (buttonRectangle.Contains(e.Location))
            {
                _isButtonPressed = true;
                _isLeftFieldPressed = false;
                _isRightFieldPressed = false;

                _moving = true;
                _xOffset = e.Location.X;
                _buttonValue = buttonRectangle.X;
                _xValue = ButtonValue;
            }
            else
            {
                if (e.Location.X > buttonRectangle.X + buttonRectangle.Width)
                {
                    _isButtonPressed = false;
                    _isLeftFieldPressed = false;
                    _isRightFieldPressed = true;
                }
                else if (e.Location.X < buttonRectangle.X)
                {
                    _isButtonPressed = false;
                    _isLeftFieldPressed = true;
                    _isRightFieldPressed = false;
                }
            }

            Refresh();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_animating || !AllowUserChange)
                return;

            int buttonWidth = _renderer.GetButtonWidth();

            bool wasLeftSidePressed = IsLeftSidePressed;
            bool wasRightSidePressed = IsRightSidePressed;

            _isButtonPressed = false;
            _isLeftFieldPressed = false;
            _isRightFieldPressed = false;

            if (_moving)
            {
                int percentage = (int)((100 * (double)ButtonValue) / ((double)Width - (double)buttonWidth));

                if (_checked)
                {
                    if (percentage <= (100 - _thresholdPercentage))
                    {
                        _animationTarget = 0;
                        BeginAnimation(false);
                    }
                    else if (ToggleOnButtonClick && _savedButtonValue == ButtonValue)
                    {
                        _animationTarget = 0;
                        BeginAnimation(false);
                    }
                    else
                    {
                        _animationTarget = Width - buttonWidth;
                        BeginAnimation(true);
                    }
                }
                else
                {
                    if (percentage >= _thresholdPercentage)
                    {
                        _animationTarget = Width - buttonWidth;
                        BeginAnimation(true);
                    }
                    else if (ToggleOnButtonClick && _savedButtonValue == ButtonValue)
                    {
                        _animationTarget = Width - buttonWidth;
                        BeginAnimation(true);
                    }
                    else
                    {
                        _animationTarget = 0;
                        BeginAnimation(false);
                    }
                }

                _moving = false;
                return;
            }

            if (IsButtonOnRightSide)
            {
                _buttonValue = Width - buttonWidth;
                _animationTarget = 0;
            }
            else
            {
                _buttonValue = 0;
                _animationTarget = Width - buttonWidth;
            }

            if (wasLeftSidePressed && ToggleOnSideClick)
            {
                SetValueInternal(false);
            }
            else if (wasRightSidePressed && ToggleOnSideClick)
            {
                SetValueInternal(true);
            }

            Refresh();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _isButtonHovered = false;
            _isLeftFieldHovered = false;
            _isRightFieldHovered = false;
            _isButtonPressed = false;
            _isLeftFieldPressed = false;
            _isRightFieldPressed = false;

            Refresh();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            Refresh();
        }

        protected override void OnRegionChanged(EventArgs e)
        {
            base.OnRegionChanged(e);

            Refresh();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (_animationTarget > 0)
            {
                int buttonWidth = _renderer.GetButtonWidth();
                _animationTarget = Width - buttonWidth;
            }

            base.OnSizeChanged(e);
        }
        #endregion
    }
}