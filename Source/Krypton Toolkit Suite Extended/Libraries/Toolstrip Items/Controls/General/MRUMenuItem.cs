using System.Windows.Forms;
using System.Windows.Forms.Design;

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