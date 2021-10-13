#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    public class KryptonMessageBoxConfiguratorDesigner : ControlDesigner
    {
        #region Identity
        public KryptonMessageBoxConfiguratorDesigner()
        {
            AutoResizeHandles = true;
        }
        #endregion

        #region Overrides
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection actionLists = new()
                {
                    new KryptonMessageBoxConfiguratorActionList(this)
                };

                return actionLists;
            }
        }
        #endregion
    }
}