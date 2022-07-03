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
