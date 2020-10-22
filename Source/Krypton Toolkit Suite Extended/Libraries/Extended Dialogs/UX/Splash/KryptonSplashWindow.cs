using Krypton.Toolkit.Suite.Extended.Base;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>A splash window for your application. Use this in your entry point.</summary>
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
        private bool _applicationIconImageBoxVisibility, _applicationIconCircularImageBoxVisibility, _progressBarVisibility, _extraTextVisibility, _useFadingEffects;

        private Color _progressBarBackgroundColour, _progressBarStartColour, _progressBarEndColour, _progressBarGlowColour,
                      _wondowBorderColourOne, _windowBorderColourTwo, _panelBackColourOne, _panelBackColourTwo,
                      _labelTextColourOne, _labelTextColourTwo, _labelTextExtraColourOne, _labelTextExtraColourTwo;

        private KryptonFadeManager _fadeManager = new KryptonFadeManager();

        private Font _applicationTitleTypeface, _extraTextTypeface;

        private KryptonForm _mainWindow;

        private int _timerInterval, _cornerRadius;

        private Image _applicationImage;

        private Timer _tmrUpdateSplash;

        private string _applicationName, _extraText;
        #endregion

        #region Properties
        /// <summary>Gets or sets a value indicating whether [application icon image box visibility].</summary>
        /// <value><c>true</c> if [application icon image box visibility]; otherwise, <c>false</c>.</value>
        public bool ApplicationIconImageBoxVisibility { get => _applicationIconImageBoxVisibility; set { _applicationIconImageBoxVisibility = value; Invalidate(); } }

        /// <summary>Gets or sets a value indicating whether [application icon circular image box visibility].</summary>
        /// <value><c>true</c> if [application icon circular image box visibility]; otherwise, <c>false</c>.</value>
        public bool ApplicationIconCircularImageBoxVisibility { get => _applicationIconCircularImageBoxVisibility; set { _applicationIconCircularImageBoxVisibility = value; Invalidate(); } }

        /// <summary>Gets or sets a value indicating whether [progress bar visibility].</summary>
        /// <value><c>true</c> if [progress bar visibility]; otherwise, <c>false</c>.</value>
        public bool ProgressBarVisibility { get => _progressBarVisibility; set { _progressBarVisibility = value; Invalidate(); } }

        /// <summary>Gets or sets a value indicating whether [extra text visibility].</summary>
        /// <value><c>true</c> if [extra text visibility]; otherwise, <c>false</c>.</value>
        public bool ExtraTextVisibility { get => _extraTextVisibility; set { _extraTextVisibility = value; Invalidate(); } }

        /// <summary>Gets or sets a value indicating whether [use fading effects].</summary>
        /// <value><c>true</c> if [use fading effects]; otherwise, <c>false</c>.</value>
        public bool UseFadingEffects { get => _useFadingEffects; set => _useFadingEffects = value; }

        /// <summary>Gets or sets the progress bar background colour.</summary>
        /// <value>The progress bar background colour.</value>
        public Color ProgressBarBackgroundColour { get => _progressBarBackgroundColour; set => _progressBarBackgroundColour = value; }

        /// <summary>Gets or sets the progress bar start colour.</summary>
        /// <value>The progress bar start colour.</value>
        public Color ProgressBarStartColour { get => _progressBarStartColour; set => _progressBarStartColour = value; }

        /// <summary>Gets or sets the progress bar end colour.</summary>
        /// <value>The progress bar end colour.</value>
        public Color ProgressBarEndColour { get => _progressBarEndColour; set => _progressBarEndColour = value; }

        /// <summary>Gets or sets the progress bar glow colour.</summary>
        /// <value>The progress bar glow colour.</value>
        public Color ProgressBarGlowColour { get => _progressBarGlowColour; set => _progressBarGlowColour = value; }

        /// <summary>Gets or sets the main window.</summary>
        /// <value>The main window.</value>
        public KryptonForm MainWindow { get => _mainWindow; set => _mainWindow = value; }

        /// <summary>Gets or sets the timer interval.</summary>
        /// <value>The timer interval.</value>
        public int TimerInterval { get => _timerInterval; set => _timerInterval = value; }

        /// <summary>Gets or sets the corner radius.</summary>
        /// <value>The corner radius.</value>
        [DefaultValue(-1)]
        public int CornerRadius { get => _cornerRadius; set => _cornerRadius = value; }

        /// <summary>Gets or sets the application image.</summary>
        /// <value>The application image.</value>
        public Image ApplicationImage { get => _applicationImage; set => _applicationImage = value; }

        /// <summary>Gets or sets the name of the application.</summary>
        /// <value>The name of the application.</value>
        public string ApplicationName { get => _applicationName; set => _applicationName = value; }

        /// <summary>Gets or sets the extra text.</summary>
        /// <value>The extra text.</value>
        public string ExtraText { get => _extraText; set => _extraText = value; }
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="KryptonSplashWindow" /> class.</summary>
        /// <param name="applicationName">Name of the application.</param>
        /// <param name="applicationImage">The application image.</param>
        /// <param name="mainWindow">The main window to move on to, once the process finishes.</param>
        public KryptonSplashWindow(string applicationName, Image applicationImage, KryptonForm mainWindow)
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

        /// <summary>Initializes a new instance of the <see cref="KryptonSplashWindow" /> class.</summary>
        /// <param name="applicationName">Name of the application.</param>
        /// <param name="applicationImage">The application image.</param>
        /// <param name="mainWindow">The main window to move on to, once the process finishes.</param>
        /// <param name="showApplicationIconImageBox">if set to <c>true</c> [show application icon image box].</param>
        /// <param name="showApplicationIconCircularImageBox">if set to <c>true</c> [show application icon circular image box].</param>
        public KryptonSplashWindow(string applicationName, Image applicationImage, KryptonForm mainWindow, bool showApplicationIconImageBox = false, bool showApplicationIconCircularImageBox = true)
        {
            InitializeComponent();
        }
        #endregion

        private void KryptonSplashWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UseFadingEffects)
            {
                _fadeManager.FadeExtendedWindowOut(this, MainWindow);
            }
        }

        private void KryptonSplashWindow_Load(object sender, EventArgs e)
        {
            if (UseFadingEffects)
            {
                _fadeManager.FadeExtendedWindowIn(this);
            }
        }

        private void UpdateSplash_Tick(object sender, EventArgs e)
        {
            kpProgress.Value = kpProgress.Value + 1;

            if (kpProgress.Value == 100)
            {
                //var newThread = new System.Threading.Thread(RunMainWindow(MainWindow));

                //newThread.SetApartmentState(System.Threading.ApartmentState.STA);

                //newThread.Start();

                MainWindow.Show();

                Close();
            }
        }

        #region Methods
        /// <summary>Updates the UI elements.</summary>
        /// <param name="applicationIconImageBoxVisability">if set to <c>true</c> [application icon image box visability].</param>
        /// <param name="applicationIconCircularImageBoxVisability">if set to <c>true</c> [application icon circular image box visability].</param>
        /// <param name="extraTextVisability">if set to <c>true</c> [extra text visability].</param>
        /// <param name="progressBarVisability">if set to <c>true</c> [progress bar visability].</param>
        private void UpdateUIElements(bool applicationIconImageBoxVisability, bool applicationIconCircularImageBoxVisability, bool extraTextVisability, bool progressBarVisability)
        {
            pbxApplicationIconStandard.Visible = applicationIconImageBoxVisability;

            cbApplicationIconCircular.Visible = applicationIconCircularImageBoxVisability;

            kmlblExtraText.Visible = extraTextVisability;

            kpnlProgressBar.Visible = progressBarVisability;
        }

        /// <summary>Updates the name of the application.</summary>
        /// <param name="applicationName">Name of the application.</param>
        private void UpdateApplicationName(string applicationName) => klblApplicationName.Text = applicationName;

        /// <summary>Polls the current progress value.</summary>
        /// <returns></returns>
        public int PollCurrentProgressValue() => kpProgress.Value;

        /// <summary>Updates the extra text.</summary>
        /// <param name="message">The message.</param>
        public void UpdateExtraText(string message) => kmlblExtraText.Text = message;

        /// <summary>Changes the progress bar colour.</summary>
        /// <param name="backgroundColour">The background colour.</param>
        /// <param name="startColour">The start colour.</param>
        /// <param name="endColour">The end colour.</param>
        /// <param name="glowColour">The glow colour.</param>
        public void ChangeProgressBarColour(Color backgroundColour, Color startColour, Color endColour, Color glowColour)
        {
            kpProgress.BackgroundColour = backgroundColour;

            kpProgress.StartColour = startColour;

            kpProgress.EndColour = endColour;

            kpProgress.GlowColour = glowColour;
        }

        /// <summary>Runs the main window.</summary>
        /// <param name="mainWindow">The main window.</param>
        public void RunMainWindow(KryptonForm mainWindow) => Application.Run(mainWindow);
        #endregion
    }
}