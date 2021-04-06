using System;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonAboutDialog : KryptonForm
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // KryptonAboutDialog
            // 
            this.ClientSize = new System.Drawing.Size(622, 373);
            this.Name = "KryptonAboutDialog";
            this.Load += new System.EventHandler(this.KryptonAboutDialog_Load);
            this.ResumeLayout(false);

        }

        private void KryptonAboutDialog_Load(object sender, EventArgs e)
        {

        }
    }
}