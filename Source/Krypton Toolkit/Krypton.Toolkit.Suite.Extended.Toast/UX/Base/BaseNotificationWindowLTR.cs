using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    internal class BaseNotificationWindowLTR : KryptonForm
    {
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnDismiss;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseNotificationWindow
            // 
            this.ClientSize = new System.Drawing.Size(609, 293);
            this.Name = "BaseNotificationWindow";
            this.ResumeLayout(false);

        }
    }
}