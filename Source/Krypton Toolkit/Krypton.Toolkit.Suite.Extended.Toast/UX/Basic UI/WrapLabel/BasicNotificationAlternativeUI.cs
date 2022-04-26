namespace Krypton.Toolkit.Suite.Extended.Toast
{
    public partial class BasicNotificationAlternativeUI : KryptonForm
    {
        #region Variables
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
        public BasicNotificationAlternativeUI(IconType iconType, string title, string contentText, 
                                              Image customImage = null, string dismissText = "&Dismiss",
                                              RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LEFTTORIGHT)
        {
            InitializeComponent();

            IconType = iconType;

            Title = title;

            ContentText = contentText;

            CustomImage = customImage;

            DismissText = dismissText;

            RightToLeftSupport = rightToLeftSupport ?? RightToLeftSupport.LEFTTORIGHT;

            TopMost = true;

            Resize += BasicNotificationAlternativeUI_Resize;

            GotFocus += BasicNotificationAlternativeUI_GotFocus;

            DoubleBuffered = true;

            ReconfigureUI(rightToLeftSupport);
        }

        public BasicNotificationAlternativeUI(IconType iconType, string title, string contentText, int seconds, 
                                              Image customImage = null, string dismissText = "&Dismiss", 
                                              RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LEFTTORIGHT)
            : this(iconType, title, contentText, customImage, dismissText, rightToLeftSupport) => Seconds = seconds;

        public BasicNotificationAlternativeUI(IconType iconType, string title, string contentText, int seconds, 
                                              string soundPath, Image customImage = null, 
                                              string dismissText = "&Dismiss",
                                              RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LEFTTORIGHT)
            : this(iconType, title, contentText, seconds, customImage, dismissText, rightToLeftSupport) => SoundPath = soundPath;

        public BasicNotificationAlternativeUI(IconType iconType, string title, string contentText, 
                                              Stream soundStream, Image customImage = null,
                                              string dismissText = "&Dismiss",
                                              RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LEFTTORIGHT)
            : this(iconType, title, contentText, customImage, dismissText, rightToLeftSupport) => SoundStream = soundStream;

        public BasicNotificationAlternativeUI(IconType iconType, string title, string contentText, int seconds, 
                                              Stream soundStream, Image customImage = null, 
                                              string dismissText = "&Dismiss",
                                              RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LEFTTORIGHT)
            : this(iconType, title, contentText, seconds, customImage, dismissText, rightToLeftSupport) => SoundStream = soundStream;
        #endregion

        #region Event Handlers
        private void BasicNotificationAlternativeUI_Load(object sender, EventArgs e)
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

        private void BasicNotificationAlternativeUI_GotFocus(object sender, EventArgs e) => kbtnDismiss.Focus();

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

                kwlContent.Location = new Point(146, 92); //89);

                kbtnDismiss.Location = new Point(423, 13);
            }
            else
            {
                RightToLeft = RightToLeft.Yes;

                RightToLeftLayout = true;

                pbxToastImage.Location = new Point(469, 12);

                kwlTitle.Location = new Point(12, 12);

                kwlContent.Location = new Point(12, 92);

                kbtnDismiss.Location = new Point(12, 13);
            }
        }
        #endregion

        #region Overrides
        protected override bool ShowWithoutActivation => true;
        #endregion
    }
}
