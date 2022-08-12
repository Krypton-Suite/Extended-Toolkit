#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    public partial class BasicNotificationWithProgressBarAlternativeUI : KryptonForm
    {
        #region Variables
        private KryptonToastNotificationIconType _iconType;

        private int _time, _seconds;

        private Timer _timer;

        private SoundPlayer _soundPlayer;

        private string _title, _contentText, _soundPath, _dismissText;

        private Stream _soundStream;

        private Image _customImage;

        private KryptonToastNotificationRightToLeftSupport _rightToLeftSupport;
        #endregion

        #region Properties
        public KryptonToastNotificationIconType IconType { get => _iconType; set => _iconType = value; }

        public int Time { get => _time; set => _time = value; }

        public int Seconds { get => _seconds; set => _seconds = value; }

        public string Title { get => _title; set => _title = value; }

        public string ContentText { get => _contentText; set => _contentText = value; }

        public string SoundPath { get => _soundPath; set => _soundPath = value; }

        public string DismissText { get => _dismissText; set => _dismissText = value; }

        public Stream SoundStream { get => _soundStream; set => _soundStream = value; }

        public Image CustomImage { get => _customImage; set => _customImage = value; }

        public KryptonToastNotificationRightToLeftSupport RightToLeftSupport { get => _rightToLeftSupport; set { _rightToLeftSupport = value; Invalidate(); } }
        #endregion

        #region Constructor
        public BasicNotificationWithProgressBarAlternativeUI(KryptonToastNotificationIconType iconType, string title, string contentText, 
                                                             Image customImage = null, string dismissText = "&Dismiss",
                                                             KryptonToastNotificationRightToLeftSupport? rightToLeftSupport = KryptonToastNotificationRightToLeftSupport.LEFTTORIGHT)
        {
            InitializeComponent();

            IconType = iconType;

            Title = title;

            ContentText = contentText;

            CustomImage = customImage;

            DismissText = dismissText;

            RightToLeftSupport = rightToLeftSupport ?? KryptonToastNotificationRightToLeftSupport.LEFTTORIGHT;

            TopMost = true;

            Resize += BasicNotificationWithProgressBarAlternativeUI_Resize;

            GotFocus += BasicNotificationWithProgressBarAlternativeUI_GotFocus;

            MouseEnter += BasicNotificationWithProgressBarAlternativeUI_MouseEnter;

            MouseHover += BasicNotificationWithProgressBarAlternativeUI_MouseHover;

            MouseLeave += BasicNotificationWithProgressBarAlternativeUI_MouseLeave;

            DoubleBuffered = true;

            ReconfigureUI(rightToLeftSupport);
        }

        public BasicNotificationWithProgressBarAlternativeUI(KryptonToastNotificationIconType iconType, string title, string contentText,
                                                             int seconds, Image customImage = null, 
                                                             string dismissText = "&Dismiss",
                                                             KryptonToastNotificationRightToLeftSupport? rightToLeftSupport = KryptonToastNotificationRightToLeftSupport.LEFTTORIGHT)
            : this(iconType, title, contentText, customImage, dismissText, rightToLeftSupport)
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

        public BasicNotificationWithProgressBarAlternativeUI(KryptonToastNotificationIconType iconType, string title, string contentText, 
                                                             int seconds, string soundPath, Image customImage = null, 
                                                             string dismissText = "&Dismiss",
                                                             KryptonToastNotificationRightToLeftSupport? rightToLeftSupport = KryptonToastNotificationRightToLeftSupport.LEFTTORIGHT)
            : this(iconType, title, contentText, seconds, customImage, dismissText, rightToLeftSupport) => SoundPath = soundPath;

        public BasicNotificationWithProgressBarAlternativeUI(KryptonToastNotificationIconType iconType, string title, string contentText, 
                                                             Stream soundStream, Image customImage = null,
                                                             string dismissText = "&Dismiss",
                                                             KryptonToastNotificationRightToLeftSupport? rightToLeftSupport = KryptonToastNotificationRightToLeftSupport.LEFTTORIGHT)
            : this(iconType, title, contentText, customImage, dismissText, rightToLeftSupport) => SoundStream = soundStream;

        public BasicNotificationWithProgressBarAlternativeUI(KryptonToastNotificationIconType iconType, string title, string contentText,
                                                             int seconds, Stream soundStream, Image customImage = null,
                                                             string dismissText = "&Dismiss",
                                                             KryptonToastNotificationRightToLeftSupport? rightToLeftSupport = KryptonToastNotificationRightToLeftSupport.LEFTTORIGHT)
            : this(iconType, title, contentText, seconds, customImage, dismissText, rightToLeftSupport) => SoundStream = soundStream;
        #endregion

        #region Event Handlers
        private void BasicNotificationWithProgressBarAlternativeUI_Load(object sender, EventArgs e)
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

        private void BasicNotificationWithProgressBarAlternativeUI_GotFocus(object sender, EventArgs e) => kbtnDismiss.Focus();

        private void BasicNotificationWithProgressBarAlternativeUI_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void kbtnDismiss_Click(object sender, EventArgs e) => UtilityMethods.FadeOutAndClose(this);

        private void BasicNotificationWithProgressBarAlternativeUI_MouseLeave(object sender, EventArgs e) => _timer.Enabled = true;

        private void BasicNotificationWithProgressBarAlternativeUI_MouseHover(object sender, EventArgs e) => _timer.Enabled = false;

        private void BasicNotificationWithProgressBarAlternativeUI_MouseEnter(object sender, EventArgs e) => _timer.Enabled = false;

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
        public new void Show()
        {
            int currentValue;

            Opacity = 0;

            UtilityMethods.SetIconType(IconType, CustomImage, pbxToastImage);

            kwlTitle.Text = Title;

            kwlContent.Text = ContentText;

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

        private void ReconfigureUI(KryptonToastNotificationRightToLeftSupport? rightToLeftSupport)
        {
            if (rightToLeftSupport == KryptonToastNotificationRightToLeftSupport.LEFTTORIGHT)
            {
                RightToLeft = RightToLeft.No;

                RightToLeftLayout = false;

                pbxToastImage.Location = new Point(12, 12);

                kwlTitle.Location = new Point(146, 12);

                kwlContent.Location = new Point(146, 95);

                kbtnDismiss.Location = new Point(423, 13);
            }
            else
            {
                RightToLeft = RightToLeft.Yes;

                RightToLeftLayout = true;

                pbxToastImage.Location = new Point(469, 12);

                kwlTitle.Location = new Point(12, 12);

                kwlContent.Location = new Point(12, 95);

                kbtnDismiss.Location = new Point(12, 13);
            }
        }
        #endregion

        #region Overrides
        protected override bool ShowWithoutActivation => true;
        #endregion
    }
}
