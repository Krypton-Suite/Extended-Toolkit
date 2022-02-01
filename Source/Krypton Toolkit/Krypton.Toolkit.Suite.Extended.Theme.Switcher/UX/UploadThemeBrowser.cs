namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher
{
    public class UploadThemeBrowser : KryptonForm
    {
        #region Design Code
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UploadThemeBrowser
            // 
            this.ClientSize = new System.Drawing.Size(1055, 631);
            this.Name = "UploadThemeBrowser";
            this.Load += new System.EventHandler(this.UploadThemeBrowser_Load);
            this.ResumeLayout(false);

        }
        #endregion

        #region Constructor
        public UploadThemeBrowser()
        {
            InitializeComponent();
        }
        #endregion

        private void UploadThemeBrowser_Load(object sender, EventArgs e)
        {
            ApplicationUtilities.UnderConstruction();

            Hide();
        }
    }
}