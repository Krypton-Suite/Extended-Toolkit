namespace Krypton.Toolkit.Suite.Extended.Toast
{
    public class BasicNotificationWithProgressBarLTR : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnDismiss;
        private KryptonPanel kpnlContent;
        private KryptonRichTextBox krtbContent;
        private KryptonWrapLabel kwlTitle;
        private PictureBox pbxToastImage;
        private ProgressBar pbCountdown;
        private KryptonBorderEdge kryptonBorderEdge1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnDismiss = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kpnlContent = new Krypton.Toolkit.KryptonPanel();
            this.pbCountdown = new System.Windows.Forms.ProgressBar();
            this.krtbContent = new Krypton.Toolkit.KryptonRichTextBox();
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
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 243);
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
            this.kbtnDismiss.Click += new System.EventHandler(this.kbtnDismiss_Click);
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
            this.kpnlContent.Controls.Add(this.pbCountdown);
            this.kpnlContent.Controls.Add(this.krtbContent);
            this.kpnlContent.Controls.Add(this.kwlTitle);
            this.kpnlContent.Controls.Add(this.pbxToastImage);
            this.kpnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlContent.Location = new System.Drawing.Point(0, 0);
            this.kpnlContent.Name = "kpnlContent";
            this.kpnlContent.Size = new System.Drawing.Size(609, 243);
            this.kpnlContent.TabIndex = 3;
            // 
            // pbCountdown
            // 
            this.pbCountdown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbCountdown.Location = new System.Drawing.Point(0, 238);
            this.pbCountdown.Name = "pbCountdown";
            this.pbCountdown.Size = new System.Drawing.Size(609, 5);
            this.pbCountdown.TabIndex = 4;
            // 
            // krtbContent
            // 
            this.krtbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.krtbContent.Location = new System.Drawing.Point(146, 89);
            this.krtbContent.Name = "krtbContent";
            this.krtbContent.ReadOnly = true;
            this.krtbContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.krtbContent.Size = new System.Drawing.Size(451, 143);
            this.krtbContent.TabIndex = 4;
            this.krtbContent.Text = "";
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
            // BasicNotificationWithProgressBarLTR
            // 
            this.AcceptButton = this.kbtnDismiss;
            this.ClientSize = new System.Drawing.Size(609, 293);
            this.Controls.Add(this.kpnlContent);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BasicNotificationWithProgressBarLTR";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.BasicNotificationWithProgressBarLTR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).EndInit();
            this.kpnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxToastImage)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables

        private bool _usePanelColourInTextArea;

        private IconType _iconType;

        private int _time, _seconds;

        private Timer _timer;

        private SoundPlayer _soundPlayer;

        private string _title, _contentText, _soundPath, _dismissText;

        private Stream _soundStream;

        private Image _customImage;
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
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBarLTR" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        public BasicNotificationWithProgressBarLTR(IconType iconType, string title, string contentText,
                                                   bool? usePanelColourInTextArea, 
                                                   Image customImage = null, 
                                                   string dismissText = "&Dismiss")
        {
            InitializeComponent();

            IconType = iconType;

            Title = title;

            ContentText = contentText;

            UsePanelColourInTextArea = usePanelColourInTextArea ?? false;

            CustomImage = customImage;

            DismissText = dismissText;

            TopMost = true;

            Resize += BasicNotificationWithProgressBarLTR_Resize;

            GotFocus += BasicNotificationWithProgressBarLTR_GotFocus;

            DoubleBuffered = true;

            SetupTextArea();
        }

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBarLTR" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        public BasicNotificationWithProgressBarLTR(IconType iconType, string title, string contentText,
                                                   bool? usePanelColourInTextArea, int seconds, 
                                                   Image customImage = null, string dismissText = "&Dismiss")
            : this(iconType, title, contentText, usePanelColourInTextArea, customImage, dismissText) => Seconds = seconds;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBarLTR" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        public BasicNotificationWithProgressBarLTR(IconType iconType, string title, string contentText,
                                                   bool? usePanelColourInTextArea, int seconds,
                                                   string soundPath, Image customImage = null, 
                                                   string dismissText = "&Dismiss")
            : this(iconType, title, contentText, usePanelColourInTextArea, seconds, customImage, dismissText) => SoundPath = soundPath;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBarLTR" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        public BasicNotificationWithProgressBarLTR(IconType iconType, string title, string contentText,
                                                   bool? usePanelColourInTextArea, Stream soundStream, 
                                                   Image customImage = null, string dismissText = "&Dismiss")
            : this(iconType, title, contentText, usePanelColourInTextArea, customImage, dismissText) => SoundStream = soundStream;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBarLTR" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        public BasicNotificationWithProgressBarLTR(IconType iconType, string title, string contentText,
                                                   bool? usePanelColourInTextArea, int seconds, 
                                                   Stream soundStream, Image customImage = null, 
                                                   string dismissText = "&Dismiss")
            : this(iconType, title, contentText, usePanelColourInTextArea, seconds, customImage, dismissText) => SoundStream = soundStream;
        #endregion

        #region Event Handlers
        private void BasicNotificationWithProgressBarLTR_GotFocus(object sender, EventArgs e) => kbtnDismiss.Focus();

        private void BasicNotificationWithProgressBarLTR_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void BasicNotificationWithProgressBarLTR_Load(object sender, EventArgs e)
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

                kbtnDismiss.Text = $"{ DismissText } ({ Seconds - Time })";

                _timer = new Timer();

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

            if (SoundStream != null)
            {
                _soundPlayer = new SoundPlayer(SoundStream);
            }

            base.Show();
        }
        #endregion
    }
}
