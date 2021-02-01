#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Base;
using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Rounded.Controls
{
    public class KryptonRoundedUACButton : KryptonUACElevatedButton
    {
        #region Variables
        private int _cornerRoundness;
        #endregion

        #region Properties
        [DefaultValue(-1)]
        public int CornerRoundness { get => _cornerRoundness; set { _cornerRoundness = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonRoundedUACButton()
        {
            CornerRoundness = -1;
        }
        #endregion

        #region Overrides
        //protected override 
        #endregion
    }
}