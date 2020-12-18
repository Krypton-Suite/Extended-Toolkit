#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class KryptonToolStripProgressBar : ToolStripProgressBar
    {
        #region Constructor
        public KryptonToolStripProgressBar()
        {

        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}