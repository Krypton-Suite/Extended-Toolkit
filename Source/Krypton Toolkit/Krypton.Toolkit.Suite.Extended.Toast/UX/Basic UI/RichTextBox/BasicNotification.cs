#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    public partial class BasicNotification : KryptonForm
    {
        #region Variables

        private ActionButtonLocation _actionButtonLocation;

        private ActionType _actionType;

        private bool _usePanelColourInTextArea, _showCloseButton;

        private Font _contentTypeface, _headerTypeface;

        private IconType _iconType;

        private int _time, _seconds;

        private Timer _timer;

        private SoundPlayer _soundPlayer;

        private string _actionButtonText, _title, _contentText, _soundPath, _dismissText;

        private Stream _soundStream;

        private Image _customImage;

        private RightToLeftSupport _rightToLeft;

        private KryptonCommand _actionButtonCommand;

        #endregion

        #region Properties

        public ActionButtonLocation ActionButtonLocation { get => _actionButtonLocation; set => _actionButtonLocation = value; }

        public ActionType ActionType { get => _actionType; set => _actionType = value; }

        public bool UsePanelColourInTextArea { get => _usePanelColourInTextArea; set => _usePanelColourInTextArea = value; }

        public bool ShowCloseButton { get => _showCloseButton; set => _showCloseButton = value; }

        public IconType IconType { get => _iconType; set => _iconType = value; }

        public int Time { get => _time; set => _time = value; }

        public int Seconds { get => _seconds; set => _seconds = value; }

        public string ActionButtonText { get => _actionButtonText; set => _actionButtonText = value; }

        public string Title { get => _title; set => _title = value; }

        public string ContentText { get => _contentText; set => _contentText = value; }

        public string SoundPath { get => _soundPath; set => _soundPath = value; }

        public string DismissText { get => _dismissText; set => _dismissText = value; }

        public Stream SoundStream { get => _soundStream; set => _soundStream = value; }

        public Image CustomImage { get => _customImage; set => _customImage = value; }

        public RightToLeftSupport RightToLeftSupport { get => _rightToLeft; set { _rightToLeft = value; Invalidate(); } }

        public KryptonCommand ActionButtonCommand { get => _actionButtonCommand; set => _actionButtonCommand = value; }

        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="BasicNotification" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeft">The right to left.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotification(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                 IconType iconType, string title, string contentText,
                                 bool? usePanelColourInTextArea, bool? showCloseButton, Image customImage = null,
                                 string dismissText = "&Dismiss", 
                                 RightToLeftSupport? rightToLeft = RightToLeftSupport.LeftToRight,
                                 KryptonCommand actionButtonCommand = null)
        {
            InitializeComponent();

            SetupBaseUI(actionButtonLocation, actionType, iconType, title, contentText, usePanelColourInTextArea, showCloseButton, customImage, dismissText, rightToLeft, actionButtonCommand);
        }

        /// <summary>Initializes a new instance of the <see cref="BasicNotification" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeft">The right to left.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotification(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                 IconType iconType, string title, string contentText,
                                 bool? usePanelColourInTextArea, bool? showCloseButton,
                                 int seconds, Image customImage = null,
                                 string dismissText = "&Dismiss",
                                 RightToLeftSupport? rightToLeft = RightToLeftSupport.LeftToRight,
                                 KryptonCommand actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText,
                   usePanelColourInTextArea, showCloseButton, customImage, 
                   dismissText, rightToLeft, actionButtonCommand) => Seconds = seconds;

        /// <summary>Initializes a new instance of the <see cref="BasicNotification" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeft">The right to left.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotification(ActionButtonLocation? actionButtonLocation, ActionType? actionType, 
                                 IconType iconType, string title, string contentText,
                                 bool? usePanelColourInTextArea,
                                 bool? showCloseButton, int seconds,
                                 string soundPath, Image customImage = null,
                                 string dismissText = "&Dismiss",
                                 RightToLeftSupport? rightToLeft = RightToLeftSupport.LeftToRight,
                                 KryptonCommand actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText,
                  usePanelColourInTextArea, showCloseButton, seconds, customImage,
                  dismissText, rightToLeft, actionButtonCommand) => SoundPath = soundPath;

        /// <summary>Initializes a new instance of the <see cref="BasicNotification" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeft">The right to left.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotification(ActionButtonLocation? actionButtonLocation, ActionType? actionType, 
                                 IconType iconType, string title, string contentText,
                                 bool? usePanelColourInTextArea,
                                 bool? showCloseButton, Stream soundStream,
                                 Image customImage = null,
                                 string dismissText = "&Dismiss",
                                 RightToLeftSupport? rightToLeft = RightToLeftSupport.LeftToRight,
                                 KryptonCommand actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText, 
                   usePanelColourInTextArea, showCloseButton, customImage,
                   dismissText, rightToLeft, actionButtonCommand) => SoundStream = soundStream;

        /// <summary>Initializes a new instance of the <see cref="BasicNotification" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeft">The right to left.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotification(ActionButtonLocation? actionButtonLocation, ActionType? actionType, 
                                 IconType iconType, string title, string contentText,
                                 bool? usePanelColourInTextArea,
                                 bool? showCloseButton, int seconds,
                                 Stream soundStream, Image customImage = null,
                                 string dismissText = "&Dismiss",
                                 RightToLeftSupport? rightToLeft = RightToLeftSupport.LeftToRight,
                                 KryptonCommand actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText,
                   usePanelColourInTextArea, showCloseButton, seconds, customImage,
                   dismissText, rightToLeft, actionButtonCommand) => SoundStream = soundStream;
        #endregion

        #region Event Handlers
        private void BasicNotification_Load(object sender, EventArgs e) => SetupUI(RightToLeftSupport);

        private void BasicNotification_GotFocus(object sender, EventArgs e)
        {
            if (RightToLeftSupport == RightToLeftSupport.LeftToRight)
            {
                kbtnToastButton3.Focus();
            }
            else
            {
                kbtnToastButton1.Focus();
            }
        }

        private void BasicNotification_Resize(object sender, EventArgs e)
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
        }

        public new void Show()
        {
            Opacity = 0;

            UtilityMethods.SetIconType(IconType, CustomImage, pbxToastImage);

            kwlTitle.Text = Title;

            krtbContent.Text = ContentText;

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
            else
            {
                if (RightToLeftSupport == RightToLeftSupport.LeftToRight)
                {
                    kbtnToastButton3.Text = DismissText;
                }
                else
                {
                    kbtnToastButton1.Text = DismissText;
                }
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

        private void SetControlBoxVisibility(bool visibilityToggle) => ControlBox = visibilityToggle;

        private void SetWindowBorderStyle(FormBorderStyle borderStyle) => FormBorderStyle = borderStyle;

        private void SetupBaseUI(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                 IconType iconType, string title, string contentText,
                                 bool? usePanelColourInTextArea, bool? showCloseButton, Image customImage = null,
                                 string dismissText = "&Dismiss", 
                                 RightToLeftSupport? rightToLeft = RightToLeftSupport.LeftToRight,
                                 KryptonCommand actionButtonCommand = null)
        {
            ActionButtonLocation = actionButtonLocation ?? ActionButtonLocation.Left;

            ActionType = actionType ?? ActionType.Default;

            IconType = iconType;

            Title = title;

            ContentText = contentText;

            UsePanelColourInTextArea = usePanelColourInTextArea ?? false;

            ShowCloseButton = showCloseButton ?? false;

            CustomImage = customImage;

            DismissText = dismissText;

            RightToLeftSupport = rightToLeft ?? RightToLeftSupport.RightToLeft;

            TopMost = true;

            ActionButtonCommand = actionButtonCommand;

            SetControlBoxVisibility(ShowCloseButton);

            Resize += BasicNotification_Resize;

            GotFocus += BasicNotification_GotFocus;

            DoubleBuffered = true;

            SetupTextArea();

            RearrangeUI(rightToLeft);
        }

        private void SetupUI(RightToLeftSupport rightToLeft = RightToLeftSupport.LeftToRight)
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

            RearrangeUI(rightToLeft);

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
                    break;
                case RightToLeftSupport.LeftToRight:
                    UtilityMethods.CalibrateUILayout(this, new Control[]{kbtnToastButton1, kbtnToastButton2, kbtnToastButton3, kwlTitle, krtbContent}, RightToLeft.No);

                    RightToLeftLayout = false;
                    
                    UtilityMethods.ChangeControlLocation(pbxToastImage, new Point(12, 12));

                    UtilityMethods.ChangeControlLocation(kwlTitle, new Point(146, 12));
                    
                    UtilityMethods.ChangeControlLocation(krtbContent, new Point(146, 89));
                    break;
                case RightToLeftSupport.RightToLeft:
                    UtilityMethods.CalibrateUILayout(this, new Control[] { kbtnToastButton1, kbtnToastButton2, kbtnToastButton3, kwlTitle, krtbContent }, RightToLeft.Yes);

                    RightToLeftLayout = true;

                    UtilityMethods.ChangeControlLocation(pbxToastImage, new Point(469, 12));

                    UtilityMethods.ChangeControlLocation(kwlTitle, new Point(12, 12));

                    UtilityMethods.ChangeControlLocation(krtbContent, new Point(12, 89));
                    break;
            }
        }

        #endregion

        #region Overrides
        protected override bool ShowWithoutActivation => true;
        #endregion
    }
}
