using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    internal class OutlookGridRowComparer : IComparer<OutlookGridRow>
    {
        int sortColumnIndex;
        SortOrder sortOrderModifier;

        public OutlookGridRowComparer(int sortColumnIndex, SortOrder sortOrder)
        {
            this.sortColumnIndex = sortColumnIndex;
            this.sortOrderModifier = sortOrder;
        }

        #region IComparer Members

        public int Compare(OutlookGridRow x, OutlookGridRow y)
        {
            int compareResult = 0;
            int orderModifier = (sortOrderModifier == SortOrder.Ascending ? 1 : -1);
            try
            {
                OutlookGridRow obj1 = (OutlookGridRow)x;
                OutlookGridRow obj2 = (OutlookGridRow)y;

                object o1 = obj1.Cells[this.sortColumnIndex].Value;
                object o2 = obj2.Cells[this.sortColumnIndex].Value;
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
                    //TODO implement a value for Token Column ??
                    else if (o1 is Token)
                    {
                        compareResult = ((Token)o1).CompareTo((Token)o2) * orderModifier;
                    }
                }
                return compareResult;
            }
            catch (Exception ex)
            {
                throw new Exception("OutlookGridRowComparer: " + this.ToString(), ex);
            }
        }
        #endregion
    }
}