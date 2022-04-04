namespace Krypton.Toolkit.Suite.Extended.Toast
{
    internal class BasicNotificationWithUserResponseWrappedLabelLTR : KryptonForm
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnDismiss;
        private KryptonPanel kpnlContent;
        private KryptonTextBox ktxtUserResponse;
        private KryptonWrapLabel kwlTitle;
        private PictureBox pbxToastImage;
        private KryptonWrapLabel kwlContent;
        private KryptonBorderEdge kryptonBorderEdge1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnDismiss = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kpnlContent = new Krypton.Toolkit.KryptonPanel();
            this.kwlContent = new Krypton.Toolkit.KryptonWrapLabel();
            this.ktxtUserResponse = new Krypton.Toolkit.KryptonTextBox();
            this.kwlTitle = new Krypton.Toolkit.KryptonWrapLabel();
            this.pbxToastImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).BeginInit();
            this.kpnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxToastImage)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnDismiss);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 277);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(609, 50);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // kbtnDismiss
            // 
            this.kbtnDismiss.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnDismiss.Location = new System.Drawing.Point(423, 13);
            this.kbtnDismiss.Name = "kbtnDismiss";
            this.kbtnDismiss.Size = new System.Drawing.Size(174, 25);
            this.kbtnDismiss.TabIndex = 1;
            this.kbtnDismiss.Values.Text = "{0} ({1})";
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(609, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kpnlContent
            // 
            this.kpnlContent.Controls.Add(this.kwlContent);
            this.kpnlContent.Controls.Add(this.ktxtUserResponse);
            this.kpnlContent.Controls.Add(this.kwlTitle);
            this.kpnlContent.Controls.Add(this.pbxToastImage);
            this.kpnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlContent.Location = new System.Drawing.Point(0, 0);
            this.kpnlContent.Name = "kpnlContent";
            this.kpnlContent.Size = new System.Drawing.Size(609, 277);
            this.kpnlContent.TabIndex = 3;
            // 
            // kwlContent
            // 
            this.kwlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kwlContent.AutoSize = false;
            this.kwlContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlContent.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlContent.Location = new System.Drawing.Point(146, 90);
            this.kwlContent.Name = "kwlContent";
            this.kwlContent.Size = new System.Drawing.Size(451, 154);
            this.kwlContent.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlContent.Text = "{0}";
            this.kwlContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ktxtUserResponse
            // 
            this.ktxtUserResponse.Location = new System.Drawing.Point(146, 247);
            this.ktxtUserResponse.Name = "ktxtUserResponse";
            this.ktxtUserResponse.Size = new System.Drawing.Size(451, 23);
            this.ktxtUserResponse.TabIndex = 3;
            // 
            // kwlTitle
            // 
            this.kwlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kwlTitle.AutoSize = false;
            this.kwlTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlTitle.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlTitle.Location = new System.Drawing.Point(146, 12);
            this.kwlTitle.Name = "kwlTitle";
            this.kwlTitle.Size = new System.Drawing.Size(451, 74);
            this.kwlTitle.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlTitle.Text = "{0}";
            this.kwlTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxToastImage
            // 
            this.pbxToastImage.BackColor = System.Drawing.Color.Transparent;
            this.pbxToastImage.Location = new System.Drawing.Point(12, 12);
            this.pbxToastImage.Name = "pbxToastImage";
            this.pbxToastImage.Size = new System.Drawing.Size(128, 128);
            this.pbxToastImage.TabIndex = 1;
            this.pbxToastImage.TabStop = false;
            // 
            // BasicNotificationWithUserResponseWrappedLabelLTR
            // 
            this.ClientSize = new System.Drawing.Size(609, 327);
            this.Controls.Add(this.kpnlContent);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BasicNotificationWithUserResponseWrappedLabelLTR";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).EndInit();
            this.kpnlContent.ResumeLayout(false);
            this.kpnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxToastImage)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

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
        public BasicNotificationWithUserResponseWrappedLabelLTR(IconType iconType, string title, string contentText, Image customImage = null,
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

            Resize += BasicNotificationWithUserResponseWrappedLabelLTR_Resize;

            GotFocus += BasicNotificationWithUserResponseWrappedLabelLTR_GotFocus;

            LostFocus += BasicNotificationWithUserResponseWrappedLabelLTR_LostFocus;

            DoubleBuffered = true;
        }

        public BasicNotificationWithUserResponseWrappedLabelLTR(IconType iconType, string title, string contentText, int seconds, Image customImage = null,
                                                    string dismissText = "&Dismiss", string userResponseCueText = "",
                                                    Color? userResponseCueColour = null,
                                                    PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                    PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                    Font userResponseCueFont = null)
            : this(iconType, title, contentText, customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont) => Seconds = seconds;

        public BasicNotificationWithUserResponseWrappedLabelLTR(IconType iconType, string title, string contentText, int seconds, string soundPath, Image customImage = null,
                                                    string dismissText = "&Dismiss", string userResponseCueText = "",
                                                    Color? userResponseCueColour = null,
                                                    PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                    PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                    Font userResponseCueFont = null)
            : this(iconType, title, contentText, seconds, customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont) => SoundPath = soundPath;

        public BasicNotificationWithUserResponseWrappedLabelLTR(IconType iconType, string title, string contentText, Stream soundStream, Image customImage = null,
                                                    string dismissText = "&Dismiss", string userResponseCueText = "",
                                                    Color? userResponseCueColour = null,
                                                    PaletteRelativeAlign? userResponseCueAlignHorizontal = null,
                                                    PaletteRelativeAlign? userResponseCueAlignVertical = null,
                                                    Font userResponseCueFont = null)
            : this(iconType, title, contentText, customImage, dismissText, userResponseCueText,
                   userResponseCueColour, userResponseCueAlignHorizontal,
                   userResponseCueAlignVertical, userResponseCueFont) => SoundStream = soundStream;

        public BasicNotificationWithUserResponseWrappedLabelLTR(IconType iconType, string title, string contentText, int seconds, Stream soundStream, Image customImage = null,
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
        private void BasicNotificationWithUserResponseWrappedLabelLTR_Load(object sender, EventArgs e)
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

        private void BasicNotificationWithUserResponseWrappedLabelLTR_GotFocus(object sender, EventArgs e)
        {
            kbtnDismiss.Focus();

            if (_timer != null)
            {
                _timer.Stop();
            }
        }

        private void BasicNotificationWithUserResponseWrappedLabelLTR_LostFocus(object sender, EventArgs e)
        {
            if (_timer != null)
            {
                _timer.Start();
            }
        }

        private void BasicNotificationWithUserResponseWrappedLabelLTR_Resize(object sender, EventArgs e)
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
                kbtnDismiss.Text = $"{ DismissText } ({ Seconds - Time })";

                _timer = new Timer();

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
                kbtnDismiss.Text = $"{ DismissText } ({ Seconds - Time })";

                _timer = new Timer();

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