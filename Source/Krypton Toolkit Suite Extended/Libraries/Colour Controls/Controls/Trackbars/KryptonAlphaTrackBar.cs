#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite
{
    [ToolboxBitmap(typeof(KryptonTrackBar))]
    public class KryptonAlphaTrackBar : KryptonTrackBar
    {
        #region Constructor
        public KryptonAlphaTrackBar()
        {
            Maximum = 255;

            TickStyle = TickStyle.None;

            Size = new Size(182, 27);
        }
        #endregion
    }
}