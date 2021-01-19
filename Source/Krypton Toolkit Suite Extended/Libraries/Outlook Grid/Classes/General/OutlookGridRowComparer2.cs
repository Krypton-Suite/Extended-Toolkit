using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    internal class OutlookGridRowComparer2 : IComparer<OutlookGridRow>
    {
        KryptonOutlookGrid outlookGrid;

        List<OutlookGridColumn> sortedColumns;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookGridRowComparer2"/> class.
        /// </summary>
        /// <param name="kryptonOutlookGrid">The KryptonOutlookGrid owning the rows and columns.</param>
        /// <param name="sortedColumnsList">A list of the sorted columns.</param>
        public OutlookGridRowComparer2(KryptonOutlookGrid kryptonOutlookGrid, List<OutlookGridColumn> sortedColumnsList)
        {
            outlookGrid = kryptonOutlookGrid;

            sortedColumns = sortedColumnsList;
        }

        #region IComparer Members

        /// <summary>
        /// Compares the specified rows.
        /// </summary>
        /// <param name="row1">The first row.</param>
        /// <param name="row2">The second row.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">OutlookGridRowComparer:  + this.ToString()</exception>
        public int Compare(OutlookGridRow row1, OutlookGridRow row2)
        {
            int compareResult = 0;
            int orderModifier;
            try
            {
                for (int i = 0; i < sortedColumns.Count; i++)
                {
                    if (compareResult == 0)
                    {
                        orderModifier = (sortedColumns[i].SortDirection == SortOrder.Ascending ? 1 : -1);

                        int columnIndex = sortedColumns[i].DataGridViewColumn.Index;

                        object o1 = row1.Cells[columnIndex].Value;
                        object o2 = row2.Cells[columnIndex].Value;
                        if (sortedColumns[i].GroupingType.ItemsComparer != null)
                        {
                            compareResult = sortedColumns[i].GroupingType.ItemsComparer.Compare(o1, o2) * orderModifier;
                        }
                        else if (this.outlookGrid.OnSortCompare(sortedColumns[i], o1, o2, row1, row2,
                                                                out int userCompareResult))
                        {
                            compareResult = userCompareResult * orderModifier;
                        }
                        else
                        {
                            if ((o1 == null || o1 == DBNull.Value) && (o2 != null && o2 != DBNull.Value))
                            {
                                compareResult = 1;
                            }
                            else if ((o1 != null && o1 != DBNull.Value) && (o2 == null || o2 == DBNull.Value))
                            {
                                compareResult = -1;
                            }
                            else
                            {
                                if (o1 is string)
                                {
                                    compareResult = string.Compare(o1.ToString(), o2.ToString()) * orderModifier;
                                }
                                else if (o1 is DateTime)
                                {
                                    compareResult = ((DateTime)o1).CompareTo((DateTime)o2) * orderModifier;
                                }
                                else if (o1 is int)
                                {
                                    compareResult = ((int)o1).CompareTo((int)o2) * orderModifier;
                                }
                                else if (o1 is bool)
                                {
                                    bool b1 = (bool)o1;
                                    bool b2 = (bool)o2;
                                    compareResult = (b1 == b2 ? 0 : b1 == true ? 1 : -1) * orderModifier;
                                }
                                else if (o1 is float)
                                {
                                    float n1 = (float)o1;
                                    float n2 = (float)o2;
                                    compareResult = (n1 > n2 ? 1 : n1 < n2 ? -1 : 0) * orderModifier;
                                }
                                else if (o1 is double)
                                {
                                    double n1 = (double)o1;
                                    double n2 = (double)o2;
                                    compareResult = (n1 > n2 ? 1 : n1 < n2 ? -1 : 0) * orderModifier;
                                }
                                else if (o1 is decimal)
                                {
                                    decimal d1 = (decimal)o1;
                                    decimal d2 = (decimal)o2;
                                    compareResult = (d1 > d2 ? 1 : d1 < d2 ? -1 : 0) * orderModifier;
                                }
                                else if (o1 is long)
                                {
                                    long n1 = (long)o1;
                                    long n2 = (long)o2;
                                    compareResult = (n1 > n2 ? 1 : n1 < n2 ? -1 : 0) * orderModifier;
                                }
                                else if (o1 is TimeSpan)
                                {
                                    TimeSpan t1 = (TimeSpan)o1;
                                    TimeSpan t2 = (TimeSpan)o2;
                                    compareResult = (t1 > t2 ? 1 : t1 < t2 ? -1 : 0) * orderModifier;
                                }
                                else if (o1 is TextAndImage)
                                {
                                    compareResult = ((TextAndImage)o1).CompareTo((TextAndImage)o2) * orderModifier;
                                }
                                else if (o1 is Token)
                                {
                                    compareResult = ((Token)o1).CompareTo((Token)o2) * orderModifier;
                                }
                            }
                        }
                    }
                }
                return compareResult;
            }
            catch (Exception ex)
            {
                throw new Exception("OutlookGridRowComparer: " + ToString(), ex);
            }
        }
        #endregion
    }
}