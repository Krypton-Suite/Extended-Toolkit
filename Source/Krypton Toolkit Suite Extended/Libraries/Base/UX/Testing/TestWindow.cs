#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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