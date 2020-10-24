using Krypton.Toolkit.Suite.Extended.Core;
using System;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonExceptionMessageBox : KryptonForm
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // KryptonExceptionMessageBox
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "KryptonExceptionMessageBox";
            this.Load += new System.EventHandler(this.KryptonExceptionMessageBox_Load);
            this.ResumeLayout(false);

        }

        private void KryptonExceptionMessageBox_Load(object sender, EventArgs e)
        {
            GlobalUtilityMethods.NotImplementedYet();

            Close();
        }
    }
}