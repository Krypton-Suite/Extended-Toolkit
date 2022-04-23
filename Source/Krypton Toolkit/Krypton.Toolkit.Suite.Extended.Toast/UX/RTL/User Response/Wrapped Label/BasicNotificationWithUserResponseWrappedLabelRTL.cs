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
    public partial class BasicNotificationWithUserResponseWrappedLabelRTL : KryptonForm
    {
        #region Variables

        private bool _useNativeBackColourInUserResponseArea;

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
        public BasicNotificationWithUserResponseWrappedLabelRTL(IconType iconType, string title, string contentText, Image customImage = null,
                                                    string dismissText = "&Dismiss", string userResponseCueText = "",
                                                    Color? userResponseCueColour = null,
                                                    PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                    PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                    Font userResponseCueFont = null)
        {
            InitializeComponent();

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

            TopMost = true;

            Resize += BasicNotificationWithUserResponseWrappedLabelRTL_Resize;

            GotFocus += BasicNotificationWithUserResponseWrappedLabelRTL_GotFocus;

            LostFocus += BasicNotificationWithUserResponseWrappedLabelRTL_LostFocus;

            DoubleBuffered = true;
        }

        public BasicNotificationWithUserResponseWrappedLabelRTL(IconType iconType, string title, string contentText, int seconds, Image customImage = null,
                                                    string dismissText = "&Dismiss", string userResponseCueText = "",
                                                    Color? userResponseCueColour = null,
                                                    PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                    PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                    Font userResponseCueFont = null)
            : this(iconType, title, contentText, customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont) => Seconds = seconds;

        public BasicNotificationWithUserResponseWrappedLabelRTL(IconType iconType, string title, string contentText, int seconds, string soundPath, Image customImage = null,
                                                    string dismissText = "&Dismiss", string userResponseCueText = "",
                                                    Color? userResponseCueColour = null,
                                                    PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                    PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                    Font userResponseCueFont = null)
            : this(iconType, title, contentText, seconds, customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont) => SoundPath = soundPath;

        public BasicNotificationWithUserResponseWrappedLabelRTL(IconType iconType, string title, string contentText, Stream soundStream, Image customImage = null,
                                                    string dismissText = "&Dismiss", string userResponseCueText = "",
                                                    Color? userResponseCueColour = null,
                                                    PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                    PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                    Font userResponseCueFont = null)
            : this(iconType, title, contentText, customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont) => SoundStream = soundStream;

        public BasicNotificationWithUserResponseWrappedLabelRTL(IconType iconType, string title, string contentText, int seconds, Stream soundStream, Image customImage = null,
                                                    string dismissText = "&Dismiss", string userResponseCueText = "",
                                                    Color? userResponseCueColour = null,
                                                    PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                    PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                    Font userResponseCueFont = null)
            : this(iconType, title, contentText, seconds, customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont) => SoundStream = soundStream;
        #endregion

        #region Event Handlers
        private void BasicNotificationWithUserResponseWrappedLabelRTL_Load(object sender, EventArgs e)
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

        private void BasicNotificationWithUserResponseWrappedLabelRTL_GotFocus(object sender, EventArgs e)
        {
            kbtnDismiss.Focus();

            if (_timer != null)
            {
                _timer.Stop();
            }
        }

        private void BasicNotificationWithUserResponseWrappedLabelRTL_LostFocus(object sender, EventArgs e)
        {
            if (_timer != null)
            {
                _timer.Start();
            }
        }

        private void BasicNotificationWithUserResponseWrappedLabelRTL_Resize(object sender, EventArgs e)
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
                kbtnDismiss.Text = $"{DismissText} ({Seconds - Time})";

                _timer = new Timer();

                _timer.Interval = 1000;

                _timer.Tick += (sender, e) =>
                {
                    _time++;

                    kbtnDismiss.Text = $"{DismissText} ({Seconds - Time}s)";

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
                kbtnDismiss.Text = $"{DismissText} ({Seconds - Time})";

                _timer = new Timer();

                _timer.Interval = 1000;

                _timer.Tick += (sender, e) =>
                {
                    _time++;

                    kbtnDismiss.Text = $"{DismissText} ({Seconds - Time}s)";

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
        #endregion
    }
}
