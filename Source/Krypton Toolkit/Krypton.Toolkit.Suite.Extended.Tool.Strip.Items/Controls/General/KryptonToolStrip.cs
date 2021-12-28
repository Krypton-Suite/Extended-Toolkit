#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [ToolboxBitmap(typeof(ToolStrip)), Description("A standard tool strip equipped with the Krypton theme."), ToolboxItem(true)]
    public class KryptonToolStrip : ToolStrip
    {
        #region Constructor
        public KryptonToolStrip()
        {
            // Use Krypton
            RenderMode = ToolStripRenderMode.ManagerRenderMode;
        }
        #endregion
    }
}