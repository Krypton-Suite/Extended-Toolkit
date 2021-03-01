#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    [ToolboxBitmap(typeof(KryptonUACElevatedButtonVersion1))]
    public class KryptonRoundedUACElevatedButton : KryptonUACElevatedButtonVersion1
    {
        #region Variables
        private int _cornerRadius;
        #endregion

        #region Properties
        public int CornerRadius { get => _cornerRadius; set { _cornerRadius = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonRoundedUACElevatedButton()
        {
            CornerRadius = 10;
        }
        #endregion

        #region Override
        protected override void OnPaint(PaintEventArgs e)
        {
            StateCommon.Border.Rounding = CornerRadius;

            base.OnPaint(e);
        }
        #endregion
    }
}