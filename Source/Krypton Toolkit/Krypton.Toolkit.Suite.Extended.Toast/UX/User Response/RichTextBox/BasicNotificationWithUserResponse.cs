#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    public partial class BasicNotificationWithUserResponse : KryptonForm
    {
        #region Variables

        private ActionButtonLocation _actionButtonLocation;

        private ActionType _actionType;

        private bool _usePanelColourInTextArea, _useNativeBackColourInUserResponseArea, _showCloseButton;

        private Color _userResponsePromptColour;

        private PaletteRelativeAlign _userResponsePromptAlignHorizontal, _userResponsePromptAlignVertical;

        private Font _userResponsePromptFont;

        private IconType _iconType;

        private int _time, _seconds;

        private Timer _timer;

        private SoundPlayer _soundPlayer;

        private string _title, _contentText, _soundPath, _dismissText, _userResponsePrompt;

        private Stream _soundStream;

        private Image _customImage;

        private RightToLeftSupport _rightToLeft;

        private KryptonCommand _actionButtonCommand;

        #endregion

        #region Properties

        public ActionButtonLocation ActionButtonLocation { get => _actionButtonLocation; set => _actionButtonLocation = value; }

        public ActionType ActionType { get => _actionType; set => _actionType = value; }

        public bool UsePanelColourInTextArea { get => _usePanelColourInTextArea; set => _usePanelColourInTextArea = value; }

        public bool UseNativeBackColourInUserResponseArea { get => _useNativeBackColourInUserResponseArea; set => _useNativeBackColourInUserResponseArea = value; }

        public bool ShowCloseButton { get => _showCloseButton; set => _showCloseButton = value; }

        public Color UserResponsePromptColour { get => _userResponsePromptColour; set => _userResponsePromptColour = value; }

        public PaletteRelativeAlign UserResponsePromptAlignHorizontal { get => _userResponsePromptAlignHorizontal; set => _userResponsePromptAlignHorizontal = value; }

        public PaletteRelativeAlign UserResponsePromptAlignVertical { get => _userResponsePromptAlignVertical; set => _userResponsePromptAlignVertical = value; }

        public Font UserResponsePromptFont { get => _userResponsePromptFont; set => _userResponsePromptFont = value; }

        public IconType IconType { get => _iconType; set => _iconType = value; }

        public int Time { get => _time; set => _time = value; }

        public int Seconds { get => _seconds; set => _seconds = value; }

        public string Title { get => _title; set => _title = value; }

        public string ContentText { get => _contentText; set => _contentText = value; }

        public string SoundPath { get => _soundPath; set => _soundPath = value; }

        public string DismissText { get => _dismissText; set => _dismissText = value; }

        public string UserResponsePrompt { get => _userResponsePrompt; set => _userResponsePrompt = value; }

        public Stream SoundStream { get => _soundStream; set => _soundStream = value; }

        public Image CustomImage { get => _customImage; set => _customImage = value; }

        public RightToLeftSupport RightToLeftSupport { get => _rightToLeft; set { _rightToLeft = value; Invalidate(); } }

        public KryptonCommand ActionButtonCommand { get => _actionButtonCommand; set => _actionButtonCommand = value; }

        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithUserResponse" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="useNativeBackColourInUserResponseArea">The use native back colour in user response area.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="userResponseCueText">The user response cue text.</param>
        /// <param name="userResponseCueColour">The user response cue colour.</param>
        /// <param name="userResponseCueAlignHorizontal">The user response cue align horizontal.</param>
        /// <param name="userResponseCueAlignVertical">The user response cue align vertical.</param>
        /// <param name="userResponseCueFont">The user response cue font.</param>
        public BasicNotificationWithUserResponse(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                                 IconType iconType, string title, string contentText,
                                                 bool? usePanelColourInTextArea,
                                                 bool? useNativeBackColourInUserResponseArea,
                                                 bool? showCloseButton,
                                                 Image? customImage = null,
                                                 string dismissText = "&Dismiss",
                                                 string userResponseCueText = "",
                                                 Color? userResponseCueColour = null,
                                                 PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                 PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                 Font? userResponseCueFont = null,
                                                 RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                                 KryptonCommand? actionButtonCommand = null)
        {
            InitializeComponent();

            SetupBaseUI(actionButtonLocation, actionType, iconType, title, contentText, usePanelColourInTextArea,
                        useNativeBackColourInUserResponseArea, showCloseButton, customImage, dismissText,
                        userResponseCueText, userResponseCueColour, userResponseCueAlignHorizontal,
                        userResponseCueAlignVertical, userResponseCueFont, rightToLeftSupport,
                        actionButtonCommand);
        }

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithUserResponse" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="useNativeBackColourInUserResponseArea">The use native back colour in user response area.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="userResponseCueText">The user response cue text.</param>
        /// <param name="userResponseCueColour">The user response cue colour.</param>
        /// <param name="userResponseCueAlignHorizontal">The user response cue align horizontal.</param>
        /// <param name="userResponseCueAlignVertical">The user response cue align vertical.</param>
        /// <param name="userResponseCueFont">The user response cue font.</param>
        public BasicNotificationWithUserResponse(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                                 IconType iconType, string title, string contentText,
                                                 bool? usePanelColourInTextArea,
                                                 bool? useNativeBackColourInUserResponseArea,
                                                 bool? showCloseButton,
                                                 int seconds, Image? customImage = null,
                                                 string dismissText = "&Dismiss", string userResponseCueText = "",
                                                 Color? userResponseCueColour = null,
                                                 PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                 PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                 Font? userResponseCueFont = null,
                                                 RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                                 KryptonCommand? actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText, usePanelColourInTextArea, useNativeBackColourInUserResponseArea, showCloseButton, customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont, rightToLeftSupport, actionButtonCommand) => Seconds = seconds;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithUserResponse" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="useNativeBackColourInUserResponseArea">The use native back colour in user response area.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="userResponseCueText">The user response cue text.</param>
        /// <param name="userResponseCueColour">The user response cue colour.</param>
        /// <param name="userResponseCueAlignHorizontal">The user response cue align horizontal.</param>
        /// <param name="userResponseCueAlignVertical">The user response cue align vertical.</param>
        /// <param name="userResponseCueFont">The user response cue font.</param>
        public BasicNotificationWithUserResponse(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                                 IconType iconType, string title, string contentText,
                                                 bool? usePanelColourInTextArea,
                                                 bool? useNativeBackColourInUserResponseArea,
                                                 bool? showCloseButton,
                                                 int seconds, string soundPath, Image? customImage = null,
                                                 string dismissText = "&Dismiss", string userResponseCueText = "",
                                                 Color? userResponseCueColour = null,
                                                 PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                 PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                 Font? userResponseCueFont = null,
                                                 RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                                 KryptonCommand? actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText,
                   usePanelColourInTextArea, useNativeBackColourInUserResponseArea, showCloseButton,
                   seconds, customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont, rightToLeftSupport,
                   actionButtonCommand) => SoundPath = soundPath;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithUserResponse" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="useNativeBackColourInUserResponseArea">The use native back colour in user response area.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="userResponseCueText">The user response cue text.</param>
        /// <param name="userResponseCueColour">The user response cue colour.</param>
        /// <param name="userResponseCueAlignHorizontal">The user response cue align horizontal.</param>
        /// <param name="userResponseCueAlignVertical">The user response cue align vertical.</param>
        /// <param name="userResponseCueFont">The user response cue font.</param>
        public BasicNotificationWithUserResponse(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                                 IconType iconType, string title, string contentText,
                                                 bool? usePanelColourInTextArea,
                                                 bool? useNativeBackColourInUserResponseArea,
                                                 bool? showCloseButton,
                                                 Stream soundStream, Image? customImage = null,
                                                 string dismissText = "&Dismiss", string userResponseCueText = "",
                                                 Color? userResponseCueColour = null,
                                                 PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                 PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                 Font? userResponseCueFont = null,
                                                 RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                                 KryptonCommand? actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText, usePanelColourInTextArea,
                   useNativeBackColourInUserResponseArea, showCloseButton,
                   customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont, rightToLeftSupport,
                   actionButtonCommand) => SoundStream = soundStream;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithUserResponse" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="useNativeBackColourInUserResponseArea">The use native back colour in user response area.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="userResponseCueText">The user response cue text.</param>
        /// <param name="userResponseCueColour">The user response cue colour.</param>
        /// <param name="userResponseCueAlignHorizontal">The user response cue align horizontal.</param>
        /// <param name="userResponseCueAlignVertical">The user response cue align vertical.</param>
        /// <param name="userResponseCueFont">The user response cue font.</param>
        public BasicNotificationWithUserResponse(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                                 IconType iconType, string title, string contentText,
                                                 bool? usePanelColourInTextArea,
                                                 bool? useNativeBackColourInUserResponseArea,
                                                 bool? showCloseButton,
                                                 int seconds, Stream soundStream, Image? customImage = null,
                                                 string dismissText = "&Dismiss", string userResponseCueText = "",
                                                 Color? userResponseCueColour = null,
                                                 PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                 PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                 Font? userResponseCueFont = null,
                                                 RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                                 KryptonCommand? actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText,
                   usePanelColourInTextArea, useNativeBackColourInUserResponseArea, showCloseButton,
                   seconds, customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont, rightToLeftSupport,
                   actionButtonCommand) => SoundStream = soundStream;
        #endregion

        #region Event Handlers
        private void BasicNotificationWithUserResponse_Load(object sender, EventArgs e)
        {
            SetupUI(RightToLeftSupport);
        }

        private void BasicNotificationWithUserResponse_GotFocus(object sender, EventArgs e)
        {
            if (RightToLeftSupport == RightToLeftSupport.LeftToRight)
            {
                kbtnToastButton3.Focus();
            }
            else
            {
                kbtnToastButton1.Focus();
            }

            if (_timer != null)
            {
                _timer.Stop();
            }
        }

        private void BasicNotificationWithUserResponse_LostFocus(object sender, EventArgs e)
        {
            if (_timer != null)
            {
                _timer.Start();
            }
        }

        private void BasicNotificationWithUserResponse_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void kbtnDismiss_Click(object sender, EventArgs e) => UtilityMethods.FadeOutAndClose(this);
        #endregion

        #region Methods
        private void SetupTextArea()
        {
            if (!_usePanelColourInTextArea)
            {
                krtbContent.InputControlStyle = InputControlStyle.Standalone;
            }
            else
            {
                if (kpnlContent.PanelBackStyle == PaletteBackStyle.PanelClient)
                {
                    krtbContent.InputControlStyle = InputControlStyle.PanelClient;
                }
                else if (kpnlContent.PanelBackStyle == PaletteBackStyle.PanelAlternate)
                {
                    krtbContent.InputControlStyle = InputControlStyle.PanelAlternate;
                }
                else
                {
                    krtbContent.InputControlStyle = InputControlStyle.Standalone;
                }
            }

            if (_useNativeBackColourInUserResponseArea)
            {
                ktxtUserResponse.InputControlStyle = InputControlStyle.Standalone;
            }
            else
            {
                if (kpnlContent.PanelBackStyle == PaletteBackStyle.PanelClient)
                {
                    ktxtUserResponse.InputControlStyle = InputControlStyle.PanelClient;
                }
                else if (kpnlContent.PanelBackStyle == PaletteBackStyle.PanelAlternate)
                {
                    ktxtUserResponse.InputControlStyle = InputControlStyle.PanelAlternate;
                }
                else
                {
                    ktxtUserResponse.InputControlStyle = InputControlStyle.Standalone;
                }
            }
        }

        public new void Show()
        {
            Opacity = 0;

            UtilityMethods.SetIconType(IconType, CustomImage, pbxToastImage);

            kwlTitle.Text = Title;

            krtbContent.Text = ContentText;

            ktxtUserResponse.CueHint.CueHintText = UserResponsePrompt;

            ktxtUserResponse.CueHint.Color1 = UserResponsePromptColour;

            ktxtUserResponse.CueHint.Font = UserResponsePromptFont;

            ktxtUserResponse.CueHint.TextH = UserResponsePromptAlignHorizontal;

            ktxtUserResponse.CueHint.TextV = UserResponsePromptAlignVertical;

            if (Seconds != 0)
            {
                if (RightToLeftSupport == RightToLeftSupport.LeftToRight)
                {
                    kbtnToastButton3.Text = $"{DismissText} ({Seconds - Time})";
                }
                else
                {
                    kbtnToastButton1.Text = $"{DismissText} ({Seconds - Time})";
                }

                _timer = new Timer();

                _timer.Interval = 1000;

                _timer.Tick += (sender, e) =>
                {
                    _time++;

                    if (RightToLeftSupport == RightToLeftSupport.LeftToRight)
                    {
                        kbtnToastButton3.Text = $"{DismissText} ({Seconds - Time}s)";
                    }
                    else
                    {
                        kbtnToastButton1.Text = $"{DismissText} ({Seconds - Time}s)";
                    }

                    if (_time == Seconds)
                    {
                        _timer.Stop();

                        UtilityMethods.FadeOutAndClose(this);
                    }
                };

                MouseEnter += (sender, e) => { _timer.Enabled = false; };

                MouseLeave += (sender, e) => { _timer.Enabled = true; };
            }

            if (SoundPath != null)
            {
                _soundPlayer = new SoundPlayer(SoundPath);
            }
            else
            {
                _soundPlayer = null;
            }

            if (SoundStream != null)
            {
                _soundPlayer = new SoundPlayer(SoundStream);
            }
            else
            {
                _soundPlayer = null;
            }

            base.Show();
        }

        public new DialogResult ShowDialog()
        {
            Opacity = 0;

            UtilityMethods.SetIconType(IconType, CustomImage, pbxToastImage);

            kwlTitle.Text = Title;

            krtbContent.Text = ContentText;

            ktxtUserResponse.CueHint.CueHintText = UserResponsePrompt;

            ktxtUserResponse.CueHint.Color1 = UserResponsePromptColour;

            ktxtUserResponse.CueHint.Font = UserResponsePromptFont;

            ktxtUserResponse.CueHint.TextH = UserResponsePromptAlignHorizontal;

            ktxtUserResponse.CueHint.TextV = UserResponsePromptAlignVertical;

            if (Seconds != 0)
            {
                if (RightToLeftSupport == RightToLeftSupport.LeftToRight)
                {
                    kbtnToastButton3.Text = $"{DismissText} ({Seconds - Time})";
                }
                else
                {
                    kbtnToastButton1.Text = $"{DismissText} ({Seconds - Time})";
                }

                _timer = new Timer();

                _timer.Interval = 1000;

                _timer.Tick += (sender, e) =>
                {
                    _time++;

                    if (RightToLeftSupport == RightToLeftSupport.LeftToRight)
                    {
                        kbtnToastButton3.Text = $"{DismissText} ({Seconds - Time}s)";
                    }
                    else
                    {
                        kbtnToastButton1.Text = $"{DismissText} ({Seconds - Time}s)";
                    }

                    if (_time == Seconds)
                    {
                        _timer.Stop();

                        UtilityMethods.FadeOutAndClose(this);
                    }
                };
            }

            if (SoundPath != null)
            {
                _soundPlayer = new SoundPlayer(SoundPath);
            }
            else
            {
                _soundPlayer = null;
            }

            if (SoundStream != null)
            {
                _soundPlayer = new SoundPlayer(SoundStream);
            }
            else
            {
                _soundPlayer = null;
            }

            return base.ShowDialog();
        }

        public string GetUserResponse() => ktxtUserResponse.Text;

        private void SetupBaseUI(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                 IconType iconType, string title, string contentText,
                                 bool? usePanelColourInTextArea, bool? useNativeBackColourInUserResponseArea,
                                 bool? showCloseButton, Image customImage, string dismissText,
                                 string userResponseCueText, Color? userResponseCueColour,
                                 PaletteRelativeAlign? userResponseCueAlignHorizontal,
                                 PaletteRelativeAlign? userResponseCueAlignVertical, Font userResponseCueFont,
                                 RightToLeftSupport? rightToLeftSupport, KryptonCommand actionButtonCommand)
        {
            ActionButtonLocation = actionButtonLocation ?? ActionButtonLocation.Left;

            ActionType = actionType ?? ActionType.Default;

            IconType = iconType;

            Title = title;

            ContentText = contentText;

            CustomImage = customImage;

            UsePanelColourInTextArea = usePanelColourInTextArea ?? false;

            UseNativeBackColourInUserResponseArea = useNativeBackColourInUserResponseArea ?? false;

            ShowCloseButton = showCloseButton ?? false;

            DismissText = dismissText;

            UserResponsePrompt = userResponseCueText;

            UserResponsePromptColour = userResponseCueColour ?? Color.Empty;

            UserResponsePromptAlignHorizontal = userResponseCueAlignHorizontal ?? PaletteRelativeAlign.Near;

            UserResponsePromptAlignVertical = userResponseCueAlignVertical ?? PaletteRelativeAlign.Near;

            UserResponsePromptFont = userResponseCueFont;

            RightToLeftSupport = rightToLeftSupport ?? RightToLeftSupport.LeftToRight;

            ActionButtonCommand = actionButtonCommand;

            TopMost = true;

            Resize += BasicNotificationWithUserResponse_Resize;

            GotFocus += BasicNotificationWithUserResponse_GotFocus;

            LostFocus += BasicNotificationWithUserResponse_LostFocus;

            DoubleBuffered = true;

            SetupTextArea();

            RearrangeUI(rightToLeftSupport);
        }

        private void SetupUI(RightToLeftSupport rightToLeft)
        {
            //Once loaded, position the form to the bottom left of the screen with added padding
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 5,
                Screen.PrimaryScreen.WorkingArea.Height - Height - 5);

            UtilityMethods.FadeIn(this);

            if (_timer != null)
            {
                _timer.Start();
            }

            if (_soundPlayer != null)
            {
                _soundPlayer.Play();
            }

            if (rightToLeft == RightToLeftSupport.LeftToRight)
            {
                kbtnToastButton3.Text = _dismissText;
            }
            else
            {
                kbtnToastButton1.Text = _dismissText;
            }
        }

        private void RearrangeUI(RightToLeftSupport? rightToLeft)
        {
            switch (rightToLeft)
            {
                case RightToLeftSupport.Inherit:
                    // Note: Come back to this
                    break;
                case RightToLeftSupport.LeftToRight:
                    UtilityMethods.CalibrateUILayout(this, new Control[] { ktbActionButton1, ktbActionButton2, ktbActionButton3, kwlTitle, krtbContent, ktxtUserResponse }, RightToLeft.No);

                    RightToLeftLayout = false;

                    pbxToastImage.Location = new Point(12, 12);

                    kwlTitle.Location = new Point(146, 12);

                    krtbContent.Location = new Point(146, 89);

                    ktxtUserResponse.Location = new Point(146, 247);
                    break;
                case RightToLeftSupport.RightToLeft:
                    UtilityMethods.CalibrateUILayout(this, new Control[] { ktbActionButton1, ktbActionButton2, ktbActionButton3, kwlTitle, krtbContent, ktxtUserResponse }, RightToLeft.Yes);

                    RightToLeftLayout = true;

                    pbxToastImage.Location = new Point(469, 12);

                    kwlTitle.Location = new Point(12, 12);

                    krtbContent.Location = new Point(12, 89);

                    ktxtUserResponse.Location = new Point(12, 247);
                    break;
            }
        }

        /// <summary>Setups the action button.</summary>
        /// <param name="showActionButton">if set to <c>true</c> [show action button].</param>
        /// <param name="actionButtonLocation">The action button location.</param>
        private void SetupActionButton(bool? showActionButton, ActionButtonLocation? actionButtonLocation)
        {
            if (showActionButton != null)
            {
                if (_rightToLeft == RightToLeftSupport.LeftToRight)
                {
                    if (actionButtonLocation == ActionButtonLocation.Left)
                    {
                        kbtnToastButtonPanel1.Visible = true;

                        ktbActionButton1.Visible = true;
                    }
                    else
                    {
                        kbtnToastButtonPanel2.Visible = true;

                        ktbActionButton2.Visible = true;
                    }
                }
                else if (_rightToLeft == RightToLeftSupport.RightToLeft)
                {
                    if (actionButtonLocation == ActionButtonLocation.Right)
                    {
                        tlpButtons.ColumnStyles[0].SizeType = SizeType.Percent;

                        tlpButtons.ColumnStyles[0].Width = 100F;

                        tlpButtons.ColumnStyles[2].SizeType = SizeType.AutoSize;

                        kbtnToastButtonPanel3.Visible = true;

                        ktbActionButton3.Visible = true;
                    }
                    else
                    {
                        tlpButtons.ColumnStyles[0].SizeType = SizeType.Percent;

                        tlpButtons.ColumnStyles[0].Width = 100F;

                        tlpButtons.ColumnStyles[2].SizeType = SizeType.AutoSize;

                        kbtnToastButtonPanel3.Visible = false;

                        ktbActionButton3.Visible = false;

                        kbtnToastButtonPanel1.Visible = true;

                        ktbActionButton1.Visible = true;
                    }
                }
            }
            else
            {
                if (_rightToLeft == RightToLeftSupport.LeftToRight)
                {
                    kbtnToastButtonPanel1.Visible = false;

                    kbtnToastButtonPanel2.Visible = false;
                }
                else if (_rightToLeft == RightToLeftSupport.RightToLeft)
                {
                    kbtnToastButtonPanel2.Visible = false;

                    kbtnToastButtonPanel3.Visible = false;

                    kbtnToastButtonPanel1.Visible = true;

                    ktbActionButton1.Visible = true;
                }
            }
        }

        #endregion

        #region Overrides
        protected override bool ShowWithoutActivation => true;
        #endregion
    }
}
