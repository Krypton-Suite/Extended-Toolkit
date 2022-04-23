using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    public partial class BasicNotificationWithUserResponseAndProgressBarRTL : KryptonForm
    {
        #region Variables
        private bool _usePanelColourInTextArea, _useNativeBackColourInUserResponseArea;

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
        #endregion

        #region Properties
        public bool UsePanelColourInTextArea { get => _usePanelColourInTextArea; set => _usePanelColourInTextArea = value; }

        public bool UseNativeBackColourInUserResponseArea { get => _useNativeBackColourInUserResponseArea; set => _useNativeBackColourInUserResponseArea = value; }

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
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithUserResponseAndProgressBarRTL" /> class.</summary>
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
        public BasicNotificationWithUserResponseAndProgressBarRTL(IconType iconType, string title, string contentText,
                                                                  bool? usePanelColourInTextArea,
                                                                  bool? useNativeBackColourInUserResponseArea,
                                                                  Image customImage = null,
                                                                  string dismissText = "&Dismiss",
                                                                  string userResponseCueText = "",
                                                                  Color? userResponseCueColour = null,
                                                                  PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                                  PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                                  Font userResponseCueFont = null)
        {
            InitializeComponent();

            IconType = iconType;

            Title = title;

            ContentText = contentText;

            UsePanelColourInTextArea = usePanelColourInTextArea ?? false;

            UseNativeBackColourInUserResponseArea = useNativeBackColourInUserResponseArea ?? false;

            CustomImage = customImage;

            DismissText = dismissText;

            UserResponsePrompt = userResponseCueText;

            UserResponsePromptColour = userResponseCueColour ?? Color.Empty;

            UserResponsePromptAlignHorizontal = userResponseCueAlignHorizontal ?? PaletteRelativeAlign.Near;

            UserResponsePromptAlignVertical = userResponseCueAlignVertical ?? PaletteRelativeAlign.Near;

            UserResponsePromptFont = userResponseCueFont;

            TopMost = true;

            Resize += BasicNotificationWithUserResponseAndProgressBarRTL_Resize;

            GotFocus += BasicNotificationWithUserResponseAndProgressBarRTL_GotFocus;

            MouseEnter += BasicNotificationWithUserResponseAndProgressBarRTL_MouseEnter;

            MouseHover += BasicNotificationWithUserResponseAndProgressBarRTL_MouseHover;

            MouseLeave += BasicNotificationWithUserResponseAndProgressBarRTL_MouseLeave;

            DoubleBuffered = true;

            SetupTextArea();
        }

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithUserResponseAndProgressBarRTL" /> class.</summary>
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
        public BasicNotificationWithUserResponseAndProgressBarRTL(IconType iconType, string title, string contentText,
                                                                  bool? usePanelColourInTextArea,
                                                                  bool? useNativeBackColourInUserResponseArea,
                                                                  int seconds, Image customImage = null,
                                                                  string dismissText = "&Dismiss",
                                                                  string userResponseCueText = "",
                                                                  Color? userResponseCueColour = null,
                                                                  PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                                  PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                                  Font userResponseCueFont = null)
            : this(iconType, title, contentText, usePanelColourInTextArea, useNativeBackColourInUserResponseArea,
                   customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont)
        {
            Seconds = seconds;

            if (seconds > 0)
            {
                // Setup the timer
                _timer = new Timer();

                _timer.Interval = 1000;

                _timer.Enabled = true;

                _timer.Tick += CountdownTimer_Tick;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithUserResponseAndProgressBarRTL" /> class.</summary>
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
        public BasicNotificationWithUserResponseAndProgressBarRTL(IconType iconType, string title, string contentText,
                                                                  bool? usePanelColourInTextArea,
                                                                  bool? useNativeBackColourInUserResponseArea,
                                                                  int seconds, string soundPath,
                                                                  Image customImage = null,
                                                                  string dismissText = "&Dismiss",
                                                                  string userResponseCueText = "",
                                                                  Color? userResponseCueColour = null,
                                                                  PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                                  PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                                  Font userResponseCueFont = null)
            : this(iconType, title, contentText, usePanelColourInTextArea, useNativeBackColourInUserResponseArea, seconds, customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont) => SoundPath = soundPath;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithUserResponseAndProgressBarRTL" /> class.</summary>
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
        public BasicNotificationWithUserResponseAndProgressBarRTL(IconType iconType, string title, string contentText,
                                                                  bool? usePanelColourInTextArea,
                                                                  bool? useNativeBackColourInUserResponseArea,
                                                                  Stream soundStream, Image customImage = null,
                                                                  string dismissText = "&Dismiss",
                                                                  string userResponseCueText = "",
                                                                  Color? userResponseCueColour = null,
                                                                  PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                                  PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                                  Font userResponseCueFont = null)
            : this(iconType, title, contentText, usePanelColourInTextArea, useNativeBackColourInUserResponseArea, customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont) => SoundStream = soundStream;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithUserResponseAndProgressBarRTL" /> class.</summary>
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
        public BasicNotificationWithUserResponseAndProgressBarRTL(IconType iconType, string title, string contentText,
                                                                  bool? usePanelColourInTextArea,
                                                                  bool? useNativeBackColourInUserResponseArea,
                                                                  int seconds, Stream soundStream, Image customImage = null,
                                                                  string dismissText = "&Dismiss", string userResponseCueText = "",
                                                                  Color? userResponseCueColour = null,
                                                                  PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                                  PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                                  Font userResponseCueFont = null)
            : this(iconType, title, contentText, usePanelColourInTextArea, useNativeBackColourInUserResponseArea, seconds, customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont) => SoundStream = soundStream;
        #endregion

        #region Event Handlers
        private void BasicNotificationWithUserResponseAndProgressBarRTL_GotFocus(object sender, EventArgs e) => kbtnDismiss.Focus();

        private void BasicNotificationWithUserResponseAndProgressBarRTL_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void ktxtUserResponse_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ktxtUserResponse.Text))
            {
                _timer.Stop();
            }
            else
            {
                _timer.Start();
            }
        }

        private void BasicNotificationWithUserResponseAndProgressBarRTL_Load(object sender, EventArgs e)
        {
            //Once loaded, position the form to the bottom left of the screen with added padding
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 5, Screen.PrimaryScreen.WorkingArea.Height - Height - 5);

            UtilityMethods.FadeIn(this);

            if (_timer != null)
            {
                _timer.Start();
            }

            if (_soundPlayer != null)
            {
                _soundPlayer.Play();
            }

            kbtnDismiss.Text = _dismissText;
        }

        private void kbtnDismiss_Click(object sender, EventArgs e) => UtilityMethods.FadeOutAndClose(this);

        private void BasicNotificationWithUserResponseAndProgressBarRTL_MouseLeave(object sender, EventArgs e) => _timer.Enabled = true;

        private void BasicNotificationWithUserResponseAndProgressBarRTL_MouseHover(object sender, EventArgs e) => _timer.Enabled = false;

        private void BasicNotificationWithUserResponseAndProgressBarRTL_MouseEnter(object sender, EventArgs e) => _timer.Enabled = false;

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            _time++;

            kbtnDismiss.Text = $"{DismissText} ({Seconds - Time}s)";

            if (_time == Seconds)
            {
                _timer.Stop();

                UtilityMethods.FadeOutAndClose(this);
            }
        }
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
            int currentValue;

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
                pbCountdown.Maximum = Seconds;

                currentValue = pbCountdown.Maximum;

                pbCountdown.Value = currentValue;

                kbtnDismiss.Text = $"{DismissText} ({Seconds - Time})";

                _timer = new Timer();

                _timer.Interval = 1000;

                _timer.Tick += (sender, e) =>
                {
                    _time++;

                    kbtnDismiss.Text = $"{DismissText} ({Seconds - Time}s)";

                    pbCountdown.Value = Seconds - Time;

                    if (string.IsNullOrEmpty(ktxtUserResponse.Text))
                    {
                        _timer.Stop();
                    }
                    else
                    {
                        _timer.Start();
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

            if (SoundStream != null)
            {
                _soundPlayer = new SoundPlayer(SoundStream);
            }

            base.Show();
        }

        public new DialogResult ShowDialog()
        {
            int currentValue;

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
                pbCountdown.Maximum = Seconds;

                currentValue = pbCountdown.Maximum;

                pbCountdown.Value = currentValue;

                kbtnDismiss.Text = $"{DismissText} ({Seconds - Time})";

                /*_timer = new Timer();

                _timer.Interval = 1000;

                _timer.Tick += (sender, e) =>
                {
                    _time++;

                    kbtnDismiss.Text = $"{ DismissText } ({ Seconds - Time }s)";

                    pbCountdown.Value = Seconds - Time;

                    if (_time == Seconds)
                    {
                        _timer.Stop();

                        UtilityMethods.FadeOutAndClose(this);
                    }
                };*/
            }

            if (SoundPath != null)
            {
                _soundPlayer = new SoundPlayer(SoundPath);
            }

            if (SoundStream != null)
            {
                _soundPlayer = new SoundPlayer(SoundStream);
            }

            return base.ShowDialog();
        }

        public string GetUserResponse() => ktxtUserResponse.Text;
        #endregion

        #region Overrides
        protected override bool ShowWithoutActivation => true;

        protected override void OnMouseEnter(EventArgs e)
        {
            _timer?.Stop();

            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _timer?.Start();

            base.OnMouseLeave(e);
        }
        #endregion
    }
}
