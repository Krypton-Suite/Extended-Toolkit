#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ContextMenuStrip | ToolStripItemDesignerAvailability.MenuStrip)]
    public class MRUMenuItem : ToolStripItem
    {
        #region Variables
        private string _defaultText = "Mo&st Recently Used...";
        #endregion

        #region Constructor
        public MRUMenuItem()
        {
            Text = _defaultText;
        }
        #endregion
    }
}