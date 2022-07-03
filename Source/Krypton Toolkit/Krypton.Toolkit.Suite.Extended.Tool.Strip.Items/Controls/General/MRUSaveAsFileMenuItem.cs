#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip)]
    public class MRUSaveAsFileMenuItem : ToolStripMenuItem
    {
        #region Instance Fields

        private string _defaultText = "Save &As";

        private string _applicationName;

        private MRUMenuItem _parentMruMenuItem;

        private MostRecentlyUsedFileManager _recentlyUsedFileManager = null;

        #endregion
    }
}
