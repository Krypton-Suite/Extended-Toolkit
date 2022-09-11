using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Toast.UX
{
    public partial class BasicNotificationWithUserResponseWrappedLabelAndProgressBar : KryptonForm
    {
        #region Variables

        private ActionButtonLocation _actionButtonLocation;

        private ActionType _actionType;

        private bool _useNativeBackColourInUserResponseArea, _showCloseButton;

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

        private RightToLeftSupport _rightToLeftSupport;

        private KryptonCommand _actionButtonCommand;

        #endregion

        #region Properties

        public ActionButtonLocation ActionButtonLocation { get => _actionButtonLocation; set => _actionButtonLocation = value; }

        public ActionType ActionType { get => _actionType; set => _actionType = value; }

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

        public RightToLeftSupport RightToLeftSupport { get => _rightToLeftSupport; set { _rightToLeftSupport = value; Invalidate(); } }

        public KryptonCommand ActionButtonCommand { get => _actionButtonCommand; set => _actionButtonCommand = value; }

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithUserResponseWrappedLabelAndProgressBar" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="userResponseCueText">The user response cue text.</param>
        /// <param name="userResponseCueColour">The user response cue colour.</param>
        /// <param name="userResponseCueAlignHorizontal">The user response cue align horizontal.</param>
        /// <param name="userResponseCueAlignVertical">The user response cue align vertical.</param>
        /// <param name="userResponseCueFont">The user response cue font.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotificationWithUserResponseWrappedLabelAndProgressBar(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                                             IconType iconType, string title, string contentText,
                                                             Image customImage = null,
                                                             string dismissText = "&Dismiss", string userResponseCueText = "",
                                                             Color? userResponseCueColour = null,
                                                             PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                             PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                             Font userResponseCueFont = null,
                                                             RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                                             KryptonCommand actionButtonCommand = null)
        {
            InitializeComponent();

            SetupUI(actionButtonLocation, actionType, iconType, title, contentText, customImage, dismissText, userResponseCueText, userResponseCueColour, userResponseCueAlignHorizontal, userResponseCueAlignVertical, userResponseCueFont, rightToLeftSupport, actionButtonCommand);
        }

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithUserResponseWrappedLabelAndProgressBar" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="userResponseCueText">The user response cue text.</param>
        /// <param name="userResponseCueColour">The user response cue colour.</param>
        /// <param name="userResponseCueAlignHorizontal">The user response cue align horizontal.</param>
        /// <param name="userResponseCueAlignVertical">The user response cue align vertical.</param>
        /// <param name="userResponseCueFont">The user response cue font.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotificationWithUserResponseWrappedLabelAndProgressBar(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                                             IconType iconType, string title, string contentText,
                                                             int seconds, Image customImage = null,
                                                             string dismissText = "&Dismiss", string userResponseCueText = "",
                                                             Color? userResponseCueColour = null,
                                                             PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                             PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                             Font userResponseCueFont = null,
                                                             RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                                             KryptonCommand actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText,
                   customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont, rightToLeftSupport,
                   actionButtonCommand) => Seconds = seconds;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithUserResponseWrappedLabelAndProgressBar" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="userResponseCueText">The user response cue text.</param>
        /// <param name="userResponseCueColour">The user response cue colour.</param>
        /// <param name="userResponseCueAlignHorizontal">The user response cue align horizontal.</param>
        /// <param name="userResponseCueAlignVertical">The user response cue align vertical.</param>
        /// <param name="userResponseCueFont">The user response cue font.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotificationWithUserResponseWrappedLabelAndProgressBar(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                                             IconType iconType, string title, string contentText,
                                                             int seconds, string soundPath, Image customImage = null,
                                                             string dismissText = "&Dismiss", string userResponseCueText = "",
                                                             Color? userResponseCueColour = null,
                                                             PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                             PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                             Font userResponseCueFont = null,
                                                             RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                                             KryptonCommand actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText,
                   seconds, customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont, rightToLeftSupport,
                   actionButtonCommand) => SoundPath = soundPath;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithUserResponseWrappedLabelAndProgressBar" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="userResponseCueText">The user response cue text.</param>
        /// <param name="userResponseCueColour">The user response cue colour.</param>
        /// <param name="userResponseCueAlignHorizontal">The user response cue align horizontal.</param>
        /// <param name="userResponseCueAlignVertical">The user response cue align vertical.</param>
        /// <param name="userResponseCueFont">The user response cue font.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotificationWithUserResponseWrappedLabelAndProgressBar(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                                             IconType iconType, string title, string contentText,
                                                             Stream soundStream, Image customImage = null,
                                                             string dismissText = "&Dismiss", string userResponseCueText = "",
                                                             Color? userResponseCueColour = null,
                                                             PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                             PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                             Font userResponseCueFont = null,
                                                             RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                                             KryptonCommand actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText,
                   customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont, rightToLeftSupport,
                   actionButtonCommand) => SoundStream = soundStream;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithUserResponseWrappedLabelAndProgressBar" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="userResponseCueText">The user response cue text.</param>
        /// <param name="userResponseCueColour">The user response cue colour.</param>
        /// <param name="userResponseCueAlignHorizontal">The user response cue align horizontal.</param>
        /// <param name="userResponseCueAlignVertical">The user response cue align vertical.</param>
        /// <param name="userResponseCueFont">The user response cue font.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotificationWithUserResponseWrappedLabelAndProgressBar(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                                             IconType iconType, string title, string contentText,
                                                             int seconds, Stream soundStream, Image customImage = null,
                                                             string dismissText = "&Dismiss", string userResponseCueText = "",
                                                             Color? userResponseCueColour = null,
                                                             PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                             PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                             Font userResponseCueFont = null,
                                                             RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                                             KryptonCommand actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText,
                seconds, customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont, rightToLeftSupport,
                   actionButtonCommand) => SoundStream = soundStream;

        #endregion

        #region Event Handlers
        private void BasicNotificationWithUserResponseWrappedLabelAndProgressBar_Load(object sender, EventArgs e) => SetupBaseUI(RightToLeftSupport);

        private void BasicNotificationWithUserResponseWrappedLabelAndProgressBar_GotFocus(object sender, EventArgs e)
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

        private void BasicNotificationWithUserResponseWrappedLabelAndProgressBar_LostFocus(object sender, EventArgs e)
        {
            if (_timer != null)
            {
                _timer.Start();
            }
        }

        private void BasicNotificationWithUserResponseWrappedLabelAndProgressBar_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void Dismiss_Click(object sender, EventArgs e) => UtilityMethods.FadeOutAndClose(this);
        #endregion

        #region Methods
        private void SetupTextArea()
        {
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

            kwlContent.Text = ContentText;

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

            kwlContent.Text = ContentText;

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

        private void SetupUI(ActionButtonLocation? actionButtonLocation, ActionType? actionType, IconType iconType,
            string title, string contentText, Image customImage, string dismissText, string userResponseCueText,
            Color? userResponseCueColour, PaletteRelativeAlign? userResponseCueAlignHorizontal,
            PaletteRelativeAlign? userResponseCueAlignVertical, Font userResponseCueFont,
            RightToLeftSupport? rightToLeftSupport, KryptonCommand actionButtonCommand)
        {
            ActionButtonLocation = actionButtonLocation ?? ActionButtonLocation.Left;

            ActionType = actionType ?? ActionType.Default;

            IconType = iconType;

            Title = title;

            ContentText = contentText;

            CustomImage = customImage;

            DismissText = dismissText;

            UserResponsePrompt = userResponseCueText;

            UserResponsePromptColour = userResponseCueColour ?? Color.Empty;

            UserResponsePromptAlignHorizontal = userResponseCueAlignHorizontal ?? PaletteRelativeAlign.Near;

            UserResponsePromptAlignVertical = userResponseCueAlignVertical ?? PaletteRelativeAlign.Near;

            UserResponsePromptFont = userResponseCueFont;

            RightToLeftSupport = rightToLeftSupport ?? RightToLeftSupport.LeftToRight;

            ActionButtonCommand = actionButtonCommand;

            TopMost = true;

            Resize += BasicNotificationWithUserResponseWrappedLabelAndProgressBar_Resize;

            GotFocus += BasicNotificationWithUserResponseWrappedLabelAndProgressBar_GotFocus;

            LostFocus += BasicNotificationWithUserResponseWrappedLabelAndProgressBar_LostFocus;

            DoubleBuffered = true;

            RearrangeUI(rightToLeftSupport);
        }

        private void SetupBaseUI(RightToLeftSupport rightToLeft)
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
                    UtilityMethods.CalibrateUILayout(this, new Control[] { ktbActionButton1, ktbActionButton2, ktbActionButton3, kwlTitle, kwlContent, ktxtUserResponse }, RightToLeft.No);

                    RightToLeftLayout = false;

                    pbxToastImage.Location = new Point(12, 12);

                    kwlTitle.Location = new Point(146, 12);

                    kwlContent.Location = new Point(146, 90);

                    ktxtUserResponse.Location = new Point(146, 247);
                    break;
                case RightToLeftSupport.RightToLeft:
                    UtilityMethods.CalibrateUILayout(this, new Control[] { ktbActionButton1, ktbActionButton2, ktbActionButton3, kwlTitle, kwlContent, ktxtUserResponse }, RightToLeft.Yes);

                    RightToLeftLayout = true;

                    pbxToastImage.Location = new Point(469, 12);

                    kwlTitle.Location = new Point(12, 12);

                    kwlContent.Location = new Point(12, 90);

                    ktxtUserResponse.Location = new Point(12, 247);
                    break;
            }
        }

        private void SetupProgressBar(int value)
        {
            pbProgress.Maximum = value;

            pbProgress.Value = value;
        }

        private void ChangeProgressBarValue(int value) => pbProgress.Value = value;

        #endregion
    }
}