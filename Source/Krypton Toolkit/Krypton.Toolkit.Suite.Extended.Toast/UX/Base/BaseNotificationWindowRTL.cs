using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    internal class BaseNotificationWindowRTL : KryptonForm
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseNotificationWindowRTL
            // 
            this.ClientSize = new System.Drawing.Size(609, 293);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseNotificationWindowRTL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);

        }
    }
}
