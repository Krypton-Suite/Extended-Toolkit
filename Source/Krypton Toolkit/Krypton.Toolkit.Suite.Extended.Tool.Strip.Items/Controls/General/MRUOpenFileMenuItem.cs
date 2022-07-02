using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip)]
    public class MRUOpenFileMenuItem : ToolStripMenuItem
    {
        #region Instance Fields

        private string _defaultText = "O&pen";

        private string _applicationName;

        private MRUMenuItem _parentMruMenuItem;
        
        private MostRecentlyUsedFileManager _recentlyUsedFileManager = null;

        #endregion

        #region Identity

        public MRUOpenFileMenuItem()
        {
            
        }

        #endregion

        #region Protected

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        #endregion
    }
}
