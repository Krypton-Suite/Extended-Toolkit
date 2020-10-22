using Krypton.Toolkit.Suite.Extended.Base;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonSplashWindow : KryptonForm
    {
        #region Design Code
        private KryptonProgressBar kpProgress;
        private KryptonPanel kpContent;
        private CircularPictureBox cbApplicationIconCircular;
        private System.Windows.Forms.PictureBox pbxApplicationIconStandard;
        private KryptonMarqueeLabel kmlblExtraText;
        private System.ComponentModel.IContainer components;
        private KryptonLabel klblApplicationName;
        private KryptonPanel kpnlProgressBar;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kpnlProgressBar = new Krypton.Toolkit.KryptonPanel();
            this.kpProgress = new Krypton.Toolkit.Suite.Extended.Base.KryptonProgressBar();
            this.kpContent = new Krypton.Toolkit.KryptonPanel();
            this.cbApplicationIconCircular = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            this.pbxApplicationIconStandard = new System.Windows.Forms.PictureBox();
            this.kmlblExtraText = new Krypton.Toolkit.Suite.Extended.Base.KryptonMarqueeLabel();
            this.klblApplicationName = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlProgressBar)).BeginInit();
            this.kpnlProgressBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpContent)).BeginInit();
            this.kpContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbApplicationIconCircular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIconStandard)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlProgressBar
            // 
            this.kpnlProgressBar.Controls.Add(this.kpProgress);
            this.kpnlProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlProgressBar.Location = new System.Drawing.Point(0, 341);
            this.kpnlProgressBar.Name = "kpnlProgressBar";
            this.kpnlProgressBar.Size = new System.Drawing.Size(725, 32);
            this.kpnlProgressBar.TabIndex = 0;
            // 
            // kpProgress
            // 
            this.kpProgress.BackColor = System.Drawing.Color.Transparent;
            this.kpProgress.BackgroundColour = System.Drawing.Color.Transparent;
            this.kpProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpProgress.EndColour = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(224)))), ((int)(((byte)(135)))));
            this.kpProgress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kpProgress.ForeColour = System.Drawing.Color.Empty;
            this.kpProgress.Location = new System.Drawing.Point(0, 0);
            this.kpProgress.Name = "kpProgress";
            this.kpProgress.Size = new System.Drawing.Size(725, 32);
            this.kpProgress.StartColour = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(224)))), ((int)(((byte)(135)))));
            this.kpProgress.TabIndex = 1;
            // 
            // kpContent
            // 
            this.kpContent.Controls.Add(this.cbApplicationIconCircular);
            this.kpContent.Controls.Add(this.pbxApplicationIconStandard);
            this.kpContent.Controls.Add(this.kmlblExtraText);
            this.kpContent.Controls.Add(this.klblApplicationName);
            this.kpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpContent.Location = new System.Drawing.Point(0, 0);
            this.kpContent.Name = "kpContent";
            this.kpContent.Size = new System.Drawing.Size(725, 341);
            this.kpContent.TabIndex = 1;
            // 
            // cbApplicationIconCircular
            // 
            this.cbApplicationIconCircular.BackColor = System.Drawing.Color.Transparent;
            this.cbApplicationIconCircular.Location = new System.Drawing.Point(234, 59);
            this.cbApplicationIconCircular.Name = "cbApplicationIconCircular";
            this.cbApplicationIconCircular.Size = new System.Drawing.Size(256, 256);
            this.cbApplicationIconCircular.TabIndex = 5;
            this.cbApplicationIconCircular.TabStop = false;
            this.cbApplicationIconCircular.ToolTipValues = null;
            // 
            // pbxApplicationIconStandard
            // 
            this.pbxApplicationIconStandard.BackColor = System.Drawing.Color.Transparent;
            this.pbxApplicationIconStandard.Location = new System.Drawing.Point(234, 59);
            this.pbxApplicationIconStandard.Name = "pbxApplicationIconStandard";
            this.pbxApplicationIconStandard.Size = new System.Drawing.Size(256, 256);
            this.pbxApplicationIconStandard.TabIndex = 4;
            this.pbxApplicationIconStandard.TabStop = false;
            // 
            // kmlblExtraText
            // 
            this.kmlblExtraText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kmlblExtraText.Location = new System.Drawing.Point(0, 321);
            this.kmlblExtraText.Name = "kmlblExtraText";
            this.kmlblExtraText.Size = new System.Drawing.Size(725, 20);
            this.kmlblExtraText.Speed = 1;
            this.kmlblExtraText.TabIndex = 3;
            this.kmlblExtraText.Values.Text = "<##SOME-TEXT##>";
            this.kmlblExtraText.YOffset = 0;
            // 
            // klblApplicationName
            // 
            this.klblApplicationName.AutoSize = false;
            this.klblApplicationName.Location = new System.Drawing.Point(12, 12);
            this.klblApplicationName.Name = "klblApplicationName";
            this.klblApplicationName.Size = new System.Drawing.Size(701, 41);
            this.klblApplicationName.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblApplicationName.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblApplicationName.TabIndex = 2;
            this.klblApplicationName.Values.Text = "<##APPLICATION-NAME##>";
            // 
            // KryptonSplashWindow
            // 
            this.ClientSize = new System.Drawing.Size(725, 373);
            this.ControlBox = false;
            this.Controls.Add(this.kpContent);
            this.Controls.Add(this.kpnlProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonSplashWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KryptonSplashWindow_FormClosing);
            this.Load += new System.EventHandler(this.KryptonSplashWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlProgressBar)).EndInit();
            this.kpnlProgressBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpContent)).EndInit();
            this.kpContent.ResumeLayout(false);
            this.kpContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbApplicationIconCircular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIconStandard)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _applicationIconImageBoxVisability, _applicationIconCircularImageBoxVisibility, _progressBarVisibility, _extraTextVisibility, _useFadingEffects;

        private Color _progressBarBackgroundColour, _progressBarStartColour, _progressBarEndColour, _progressBarGlowColour,
                      _wondowBorderColourOne, _windowBorderColourTwo, _panelBackColourOne, _panelBackColourTwo;

        private int _timerInterval, _cornerRadius;

        private Image _applicationImage;

        private Timer _tmrUpdateSplash;

        private string _applicationName, _extraText;
        #endregion

        #region Properties
        public bool ApplicationIconImageBoxVisability { get => _applicationIconImageBoxVisability; set { _applicationIconImageBoxVisability = value; Invalidate(); } }

        public bool ApplicationIconCircularImageBoxVisibility { get => _applicationIconCircularImageBoxVisibility; set { _applicationIconCircularImageBoxVisibility = value; Invalidate(); } }

        public bool ProgressBarVisibility { get => _progressBarVisibility; set { _progressBarVisibility = value; Invalidate(); } }

        public bool ExtraTextVisibility { get => _extraTextVisibility; set { _extraTextVisibility = value; Invalidate(); } }

        public bool UseFadingEffects { get => _useFadingEffects; set => _useFadingEffects = value; }

        public Color ProgressBarBackgroundColour { get => _progressBarBackgroundColour; set => _progressBarBackgroundColour = value; }

        public Color ProgressBarStartColour { get => _progressBarStartColour; set => _progressBarStartColour = value; }

        public Color ProgressBarEndColour { get => _progressBarEndColour; set => _progressBarEndColour = value; }

        public Color ProgressBarGlowColour { get => _progressBarGlowColour; set => _progressBarGlowColour = value; }

        public int TimerInterval { get => _timerInterval; set => _timerInterval = value; }

        [DefaultValue(-1)]
        public int CornerRadius { get => _cornerRadius; set => _cornerRadius = value; }

        public Image ApplicationImage { get => _applicationImage; set => _applicationImage = value; }

        public string ApplicationName { get => _applicationName; set => _applicationName = value; }

        public string ExtraText { get => _extraText; set => _extraText = value; }
        #endregion

        #region Constructors
        public KryptonSplashWindow(string applicationName, Image applicationImage)
        {
            InitializeComponent();

            // Setup timer
            _tmrUpdateSplash = new Timer();

            _tmrUpdateSplash.Interval = 250;

            _tmrUpdateSplash.Enabled = true;

            _tmrUpdateSplash.Tick += UpdateSplash_Tick;

            // Set application name
            ApplicationName = applicationName;

            UpdateApplicationName(ApplicationName);

            UpdateUIElements(true, false, false, false);

            pbxApplicationIconStandard.Image = applicationImage;
        }

        public KryptonSplashWindow(string applicationName, Image applicationImage, bool showApplicationIconImageBox = false, bool showApplicationIconCircularImageBox = true)
        {
            InitializeComponent();
        }
        #endregion

        private void KryptonSplashWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void KryptonSplashWindow_Load(object sender, EventArgs e)
        {

        }

        private void UpdateSplash_Tick(object sender, EventArgs e)
        {
            kpProgress.Value = kpProgress.Value + 1;
        }

        private void UpdateUIElements(bool applicationIconImageBoxVisability, bool applicationIconCircularImageBoxVisability, bool extraTextVisability, bool progressBarVisability)
        {
            pbxApplicationIconStandard.Visible = applicationIconImageBoxVisability;

            cbApplicationIconCircular.Visible = applicationIconCircularImageBoxVisability;

            kmlblExtraText.Visible = extraTextVisability;

            kpnlProgressBar.Visible = progressBarVisability;
        }

        private void UpdateApplicationName(string applicationName)
        {
            throw new NotImplementedException();
        }

        public int PollCurrentProgressValue() => kpProgress.Value;

        public void UpdateExtraText(string message) => kmlblExtraText.Text = message;

        public void ChangeProgressBarColour(Color backgroundColour, Color startColour, Color endColour, Color glowColour)
        {
            kpProgress.BackgroundColour = backgroundColour;

            kpProgress.StartColour = startColour;

            kpProgress.EndColour = endColour;

            kpProgress.GlowColour = glowColour;
        }
    }
}