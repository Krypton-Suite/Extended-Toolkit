#region MS-PL License
/*
* Copyright (C) 2013 - 2018 JDH Software - <support@jdhsoftware.com>
*
* This program is provided to you under the terms of the Microsoft Public
* License (Ms-PL) as published at https://kryptonoutlookgrid.codeplex.com/license
*
* Visit http://www.jdhsoftware.com and follow @jdhsoftware on Twitter
*/
#endregion

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