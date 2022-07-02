using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip)]
    public class MRUSaveFileMenuItem : ToolStripMenuItem
    {
        #region Instance Fields

        private string _defaultText = "S&ave";

        private string _applicationName;

        private MRUMenuItem _parentMruMenuItem;

        private MostRecentlyUsedFileManager _recentlyUsedFileManager = null;

        #endregion
    }
}
