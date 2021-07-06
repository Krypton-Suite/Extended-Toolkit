namespace Krypton.Toolkit.Suite.Extended.Developer.Utilities
{
    public class KryptonDeveloperDebugConsole : KryptonForm
    {
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Location = new System.Drawing.Point(385, 480);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(100, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // KryptonDeveloperDebugConsole
            // 
            this.ClientSize = new System.Drawing.Size(935, 623);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "KryptonDeveloperDebugConsole";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}