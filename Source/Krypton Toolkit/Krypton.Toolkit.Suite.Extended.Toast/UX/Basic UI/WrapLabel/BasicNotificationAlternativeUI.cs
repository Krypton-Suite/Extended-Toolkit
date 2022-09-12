﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    public partial class BasicNotificationAlternativeUI : KryptonForm
    {
        #region Variables

        private ActionButtonLocation _actionButtonLocation;

        private ActionType _actionType;

        private bool _showControlButton, _showCloseButton;

        private IconType _iconType;

        private int _time, _seconds;

        private Timer _timer;

        private SoundPlayer _soundPlayer;

        private string _title, _contentText, _soundPath, _dismissText;

        private Stream _soundStream;

        private Image _customImage;

        private RightToLeftSupport _rightToLeft;

        private KryptonCommand _actionButtonCommand;

        #endregion

        #region Properties

        public ActionButtonLocation ActionButtonLocation { get => _actionButtonLocation; set => _actionButtonLocation = value; }

        public ActionType ActionType { get => _actionType; set => _actionType = value; }

        public bool ShowCloseButton { get => _showControlButton; set => _showControlButton = value; }

        public IconType IconType { get => _iconType; set => _iconType = value; }

        public int Time { get => _time; set => _time = value; }

        public int Seconds { get => _seconds; set => _seconds = value; }

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

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationAlternativeUI" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotificationAlternativeUI(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                              IconType iconType, string title, string contentText, 
                                              bool? showCloseButton,
                                              Image customImage = null, string dismissText = "&Dismiss",
                                              RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                              KryptonCommand actionButtonCommand = null)
        {
            InitializeComponent();

            SetupBaseUI(actionButtonLocation, actionType, iconType, title, contentText, showCloseButton, customImage, dismissText, rightToLeftSupport, actionButtonCommand);
        }

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationAlternativeUI" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotificationAlternativeUI(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                              IconType iconType, string title, string contentText,
                                              bool? showCloseButton, int seconds, 
                                              Image customImage = null, string dismissText = "&Dismiss", 
                                              RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                              KryptonCommand actionButtonCommand = null)
            : this(actionButtonLocation, actionType,iconType, title, contentText, 
                   showCloseButton, customImage, dismissText,
                   rightToLeftSupport, actionButtonCommand) => Seconds = seconds;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationAlternativeUI" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotificationAlternativeUI(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                              IconType iconType, string title, string contentText,
                                              bool? showCloseButton, int seconds, 
                                              string soundPath, Image customImage = null, 
                                              string dismissText = "&Dismiss",
                                              RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                              KryptonCommand actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText, 
                   showCloseButton, seconds, customImage, dismissText,
                   rightToLeftSupport, actionButtonCommand) => SoundPath = soundPath;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationAlternativeUI" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotificationAlternativeUI(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                              IconType iconType, string title, string contentText,
                                              bool? showCloseButton, 
                                              Stream soundStream, Image customImage = null,
                                              string dismissText = "&Dismiss",
                                              RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                              KryptonCommand actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText, 
                   showCloseButton, customImage, dismissText, 
                   rightToLeftSupport, actionButtonCommand) => SoundStream = soundStream;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationAlternativeUI" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotificationAlternativeUI(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                              IconType iconType, string title, string contentText,
                                              bool? showCloseButton, int seconds, 
                                              Stream soundStream, Image customImage = null, 
                                              string dismissText = "&Dismiss",
                                              RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                              KryptonCommand actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText,
                   showCloseButton, seconds, customImage, dismissText,
                   rightToLeftSupport, actionButtonCommand) => SoundStream = soundStream;
        #endregion

        #region Event Handlers

        private void BasicNotificationAlternativeUI_Load(object sender, EventArgs e) => SetupUI(RightToLeftSupport);

        private void BasicNotificationAlternativeUI_GotFocus(object sender, EventArgs e)
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

        private void BasicNotificationAlternativeUI_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void kbtnDismiss_Click(object sender, EventArgs e) => UtilityMethods.FadeOutAndClose(this);
        #endregion

        #region Methods
        public new void Show()
        {
            Opacity = 0;

            UtilityMethods.SetIconType(IconType, CustomImage, pbxToastImage);

            kwlTitle.Text = Title;

            kwlContent.Text = ContentText;

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
                                 bool? showCloseButton, Image customImage,
                                 string dismissText, RightToLeftSupport? rightToLeftSupport,
                                 KryptonCommand actionButtonCommand)
        {
            ActionButtonLocation = actionButtonLocation ?? ActionButtonLocation.Left;

            ActionType = actionType ?? ActionType.Default;

            IconType = iconType;

            Title = title;

            ContentText = contentText;

            ShowCloseButton = showCloseButton ?? false;

            CustomImage = customImage;

            DismissText = dismissText;

            RightToLeftSupport = rightToLeftSupport ?? RightToLeftSupport.LeftToRight;

            TopMost = true;

            SetControlBoxVisibility(ShowCloseButton);

            Resize += BasicNotificationAlternativeUI_Resize;

            GotFocus += BasicNotificationAlternativeUI_GotFocus;

            DoubleBuffered = true;

            ActionButtonCommand = actionButtonCommand;

            RearrangeUI(rightToLeftSupport);
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
                    // Note: Come back to this
                    break;
                case RightToLeftSupport.LeftToRight:
                    UtilityMethods.CalibrateUILayout(this, new Control[] { ktbActionButton1, ktbActionButton2, ktbActionButton3, kwlTitle, kwlContent }, RightToLeft.No);

                    RightToLeftLayout = false;

                    pbxToastImage.Location = new Point(12, 12);

                    kwlTitle.Location = new Point(146, 12);

                    kwlContent.Location = new Point(146, 92); //89);
                    break;
                case RightToLeftSupport.RightToLeft:
                    UtilityMethods.CalibrateUILayout(this, new Control[] { ktbActionButton1, ktbActionButton2, ktbActionButton3, kwlTitle, kwlContent }, RightToLeft.Yes);

                    RightToLeftLayout = true;

                    pbxToastImage.Location = new Point(469, 12);

                    kwlTitle.Location = new Point(12, 12);

                    kwlContent.Location = new Point(12, 92);
                    break;
            }
        }

        #endregion

        #region Overrides
        protected override bool ShowWithoutActivation => true;
        #endregion
    }
}
