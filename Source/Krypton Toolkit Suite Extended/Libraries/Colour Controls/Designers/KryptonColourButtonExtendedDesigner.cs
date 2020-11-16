#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite
{
    internal class KryptonColourButtonExtendedDesigner : ControlDesigner
    {
        #region Constructor
        public KryptonColourButtonExtendedDesigner()
        {
            AutoResizeHandles = true;
        }
        #endregion

        #region Overrides
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection listCollection = new DesignerActionListCollection
                {
                    new KryptonColourButtonExtendedActionList(this)
                };

                return listCollection;
            }
        }
        #endregion
    }
}