#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    [ToolboxBitmap(typeof(KryptonMaskedTextBox))]
    public class KryptonRoundedMaskedTextBox : KryptonMaskedTextBox
    {
        #region Variables
        private int _cornerRadius;
        #endregion

        #region Properties
        [Category("Appearance"), DefaultValue(25), Description("Size of corner radius. (-1 is the 'default system look' value)")]
        public int CornerRadius { get => _cornerRadius; set { _cornerRadius = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonRoundedMaskedTextBox()
        {
            CornerRadius = 25;

            StateCommon.Border.Rounding = CornerRadius;
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