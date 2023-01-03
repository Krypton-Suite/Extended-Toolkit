namespace Krypton.Toolkit.Suite.Extended.AdvancedDataGridView;

public class AdvancedDataGridViewSearchToolBarSearchEventArgs : EventArgs
{
    public string ValueToSearch { get; private set; }
    public DataGridViewColumn ColumnToSearch { get; private set; }
    public bool CaseSensitive { get; private set; }
    public bool WholeWord { get; private set; }
    public bool FromBegin { get; private set; }

    public AdvancedDataGridViewSearchToolBarSearchEventArgs(string Value, DataGridViewColumn Column, bool Case, bool Whole, bool fromBegin)
    {
        ValueToSearch = Value;
        ColumnToSearch = Column;
        CaseSensitive = Case;
        WholeWord = Whole;
        FromBegin = fromBegin;
    }
}