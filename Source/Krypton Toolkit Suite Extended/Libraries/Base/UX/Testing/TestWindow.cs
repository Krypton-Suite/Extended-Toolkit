using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Base.UX.Testing
{
    public class TestWindow : KryptonForm
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TestWindow
            // 
            this.ClientSize = new System.Drawing.Size(1384, 697);
            this.Name = "TestWindow";
            this.ResumeLayout(false);

        }
    }
}