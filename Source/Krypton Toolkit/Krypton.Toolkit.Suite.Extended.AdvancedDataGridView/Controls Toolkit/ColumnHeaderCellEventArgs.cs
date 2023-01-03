namespace Krypton.Toolkit.Suite.Extended.AdvancedDataGridView
{
    internal class ColumnHeaderCellEventArgs : EventArgs
    {
        public MenuStrip FilterMenu { get; private set; }

        public DataGridViewColumn Column { get; private set; }

        public ColumnHeaderCellEventArgs(MenuStrip filterMenu, DataGridViewColumn column)
        {
            FilterMenu = filterMenu;
            Column = column;
        }
    }
}