namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher
{
    public class DownloadThemePackage : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(100, 100);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // DownloadThemePackage
            // 
            this.ClientSize = new System.Drawing.Size(598, 261);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "DownloadThemePackage";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Constructors
        public DownloadThemePackage()
        {
            InitializeComponent();
        }
        #endregion
    }
}