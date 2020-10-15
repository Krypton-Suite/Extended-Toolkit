using System;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonStringCollectionDialog : KryptonForm
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // KryptonStringCollectionDialog
            // 
            this.ClientSize = new System.Drawing.Size(579, 356);
            this.Name = "KryptonStringCollectionDialog";
            this.Load += new System.EventHandler(this.KryptonStringCollectionDialog_Load);
            this.ResumeLayout(false);

        }

        private void KryptonStringCollectionDialog_Load(object sender, EventArgs e)
        {

        }
    }
}