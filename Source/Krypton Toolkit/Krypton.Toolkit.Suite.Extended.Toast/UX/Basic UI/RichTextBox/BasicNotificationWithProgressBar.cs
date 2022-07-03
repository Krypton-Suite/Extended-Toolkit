#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    public partial class BasicNotificationWithProgressBar : KryptonForm
    {
        #region Variables

        private bool _usePanelColourInTextArea;

        private IconType _iconType;

        private int _time, _seconds;

        private Timer _timer;

        private SoundPlayer _soundPlayer;

        private string _title, _contentText, _soundPath, _dismissText;

        private Stream _soundStream;

        private Image _customImage;

        private RightToLeftSupport _rightToLeftSupport;
        #endregion

        #region Properties
        public bool UsePanelColourInTextArea { get => _usePanelColourInTextArea; set => _usePanelColourInTextArea = value; }

        public IconType IconType { get => _iconType; set => _iconType = value; }

        public int Time { get => _time; set => _time = value; }

        public int Seconds { get => _seconds; set => _seconds = value; }

        public string Title { get => _title; set => _title = value; }

        public string ContentText { get => _contentText; set => _contentText = value; }

        public string SoundPath { get => _soundPath; set => _soundPath = value; }

        public string DismissText { get => _dismissText; set => _dismissText = value; }

        public Stream SoundStream { get => _soundStream; set => _soundStream = value; }

        public Image CustomImage { get => _customImage; set => _customImage = value; }

        public RightToLeftSupport RightToLeftSupport { get => _rightToLeftSupport; set { _rightToLeftSupport = value; Invalidate(); } }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBar" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        public BasicNotificationWithProgressBar(IconType iconType, string title, string contentText,
                                                bool? usePanelColourInTextArea,
                                                Image customImage = null,
                                                string dismissText = "&Dismiss",
                                                RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LEFTTORIGHT)
        {
            InitializeComponent();

            IconType = iconType;

            Title = title;

            ContentText = contentText;

            UsePanelColourInTextArea = usePanelColourInTextArea ?? false;

            CustomImage = customImage;

            DismissText = dismissText;

            RightToLeftSupport = rightToLeftSupport ?? RightToLeftSupport.LEFTTORIGHT;

            TopMost = true;

            Resize += BasicNotificationWithProgressBar_Resize;

            GotFocus += BasicNotificationWithProgressBar_GotFocus;

            MouseEnter += BasicNotificationWithProgressBar_MouseEnter;

            MouseHover += BasicNotificationWithProgressBar_MouseHover;

            MouseLeave += BasicNotificationWithProgressBar_MouseLeave;

            DoubleBuffered = true;

            SetupTextArea();

            ReconfigureUI(rightToLeftSupport);
        }

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBar" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        public BasicNotificationWithProgressBar(IconType iconType, string title, string contentText,
                                                bool? usePanelColourInTextArea, int seconds,
                                                Image customImage = null, string dismissText = "&Dismiss",
                                                RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LEFTTORIGHT)
            : this(iconType, title, contentText, usePanelColourInTextArea, customImage, dismissText, rightToLeftSupport)
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

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBar" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        public BasicNotificationWithProgressBar(IconType iconType, string title, string contentText,
                                                bool? usePanelColourInTextArea, int seconds,
                                                string soundPath, Image customImage = null,
                                                string dismissText = "&Dismiss",
                                                RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LEFTTORIGHT)
            : this(iconType, title, contentText, usePanelColourInTextArea, seconds, customImage, dismissText, rightToLeftSupport) => SoundPath = soundPath;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBar" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        public BasicNotificationWithProgressBar(IconType iconType, string title, string contentText,
                                                bool? usePanelColourInTextArea, Stream soundStream,
                                                Image customImage = null, string dismissText = "&Dismiss",
                                                RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LEFTTORIGHT)
            : this(iconType, title, contentText, usePanelColourInTextArea, customImage, dismissText, rightToLeftSupport) => SoundStream = soundStream;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBar" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        public BasicNotificationWithProgressBar(IconType iconType, string title, string contentText,
                                                bool? usePanelColourInTextArea, int seconds,
                                                Stream soundStream, Image customImage = null,
                                                string dismissText = "&Dismiss",
                                                RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LEFTTORIGHT)
            : this(iconType, title, contentText, usePanelColourInTextArea, seconds, customImage, dismissText, rightToLeftSupport) => SoundStream = soundStream;
        #endregion

        #region Event Handlers
        private void BasicNotificationWithProgressBar_GotFocus(object sender, EventArgs e) => kbtnDismiss.Focus();

        private void BasicNotificationWithProgressBar_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void BasicNotificationWithProgressBar_Load(object sender, EventArgs e)
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

        private void BasicNotificationWithProgressBar_MouseLeave(object sender, EventArgs e) => _timer.Enabled = true;

        private void BasicNotificationWithProgressBar_MouseHover(object sender, EventArgs e) => _timer.Enabled = false;
        
        private void BasicNotificationWithProgressBar_MouseEnter(object sender, EventArgs e) => _timer.Enabled = false;

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
        }

        public new void Show()
        {
            int currentValue;

            Opacity = 0;

            UtilityMethods.SetIconType(IconType, CustomImage, pbxToastImage);

            kwlTitle.Text = Title;

            krtbContent.Text = ContentText;

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
            else
            {
                kbtnDismiss.Text = DismissText;
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

        private void ReconfigureUI(RightToLeftSupport? rightToLeftSupport)
        {
            if (rightToLeftSupport == RightToLeftSupport.LEFTTORIGHT)
            {
                RightToLeft = RightToLeft.No;

                RightToLeftLayout = false;

                pbxToastImage.Location = new Point(12, 12);

                kwlTitle.Location = new Point(146, 12);

                krtbContent.Location = new Point(146, 89);

                kbtnDismiss.Location = new Point(423, 13);
            }
            else
            {
                RightToLeft = RightToLeft.Yes;

                RightToLeftLayout = true;

                pbxToastImage.Location = new Point(469, 12);

                kwlTitle.Location = new Point(12, 12);

                krtbContent.Location = new Point(12, 89);

                kbtnDismiss.Location = new Point(12, 13);
            }
        }
        #endregion
    }
}
