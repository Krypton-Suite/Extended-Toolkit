using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// A replacement for the DataGridViewSortCompareEventArgs.
    /// </summary>
    public class OutlookGridSortCompareEventArgs : HandledEventArgs
    {
        public OutlookGridSortCompareEventArgs(OutlookGridColumn column, object cellValue1, object cellValue2,
                                               OutlookGridRow row1, OutlookGridRow row2)
        {
            this.Column = column;
            this.CellValue1 = cellValue1;
            this.CellValue2 = cellValue2;
            this.Row1 = row1;
            this.Row2 = row2;
        }

        public object CellValue1 { get; }

        public object CellValue2 { get; }

        public OutlookGridColumn Column { get; }

        public OutlookGridRow Row1 { get; }

        public OutlookGridRow Row2 { get; }

        public int SortResult { get; set; }
    }
}