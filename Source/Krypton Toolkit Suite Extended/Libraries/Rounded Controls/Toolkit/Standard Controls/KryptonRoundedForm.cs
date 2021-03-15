#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Rounded.Controls
{
    [Category("Code")]
    public class KryptonRoundedForm : KryptonForm
    {
        #region Variables
        private int _cornerRoundness;
        #endregion

        #region Properties
        [DefaultValue(-1)]
        public int CornerRoundness { get => _cornerRoundness; set { _cornerRoundness = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonRoundedForm()
        {
            CornerRoundness = -1;
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            StateCommon.Border.Rounding = CornerRoundness;

            base.OnPaint(e);
        }
        #endregion
    }
}