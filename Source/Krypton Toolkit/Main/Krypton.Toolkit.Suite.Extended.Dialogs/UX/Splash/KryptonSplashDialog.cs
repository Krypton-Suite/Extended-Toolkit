namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonSplashDialog : CommonExtendedKryptonForm
    {
        #region Design Code
        private System.Windows.Forms.ProgressBar pbLoading;
        private System.Windows.Forms.PictureBox pbAppIcon;
        private KryptonWrapLabel kwlApplicationName;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.pbLoading = new System.Windows.Forms.ProgressBar();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.pbAppIcon = new System.Windows.Forms.PictureBox();
            this.kwlApplicationName = new Krypton.Toolkit.KryptonWrapLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAppIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLoading
            // 
            this.pbLoading.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbLoading.Location = new System.Drawing.Point(0, 421);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(801, 5);
            this.pbLoading.TabIndex = 0;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.pbAppIcon);
            this.kryptonPanel1.Controls.Add(this.kwlApplicationName);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(801, 421);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // pbAppIcon
            // 
            this.pbAppIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbAppIcon.Location = new System.Drawing.Point(274, 32);
            this.pbAppIcon.Name = "pbAppIcon";
            this.pbAppIcon.Size = new System.Drawing.Size(256, 256);
            this.pbAppIcon.TabIndex = 1;
            this.pbAppIcon.TabStop = false;
            // 
            // kwlApplicationName
            // 
            this.kwlApplicationName.AutoSize = false;
            this.kwlApplicationName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kwlApplicationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlApplicationName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlApplicationName.Location = new System.Drawing.Point(0, 306);
            this.kwlApplicationName.Name = "kwlApplicationName";
            this.kwlApplicationName.Size = new System.Drawing.Size(801, 115);
            this.kwlApplicationName.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlApplicationName.Text = "<##APPLICATION-NAME##>";
            this.kwlApplicationName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KryptonSplashDialog
            // 
            this.ClientSize = new System.Drawing.Size(801, 426);
            this.ControlBox = false;
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.pbLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "KryptonSplashDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAppIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Properties
        public bool ShowProgressBar { get; set; } = false;

        public string ApplicationName { get; set; } = null;

        public Image ApplicationIcon { get; set; } = null;
        #endregion

        #region Constructors
        public KryptonSplashDialog()
        {
            InitializeComponent();

            UpdateUI(ShowProgressBar, ApplicationName, ApplicationIcon);
        }

        public KryptonSplashDialog(bool showProgressBar, string applicationName, Image applicationIcon)
        {
            InitializeComponent();

            UpdateUI(showProgressBar, applicationName, applicationIcon);
        }
        #endregion

        #region Methods
        private void UpdateUI(bool showProgressBar, string applicationName, Image applicationIcon)
        {
            pbLoading.Visible = showProgressBar;

            kwlApplicationName.Text = applicationName;

            pbAppIcon.Image = applicationIcon;
        }

        public void UpdateProgressBar(int maximum = 100, int increment = 1)
        {
            if (ShowProgressBar)
            {
                pbLoading.Maximum = maximum;

                while (pbLoading.Value >= maximum)
                {
                    pbLoading.Increment(increment);
                }
            }
        }
        #endregion
    }
}