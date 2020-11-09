#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
#if !NETCOREAPP31 && !NET5
    public class ListViewSort : IComparer
    {

        // Fields
        private bool mAscending = true;
        private int mSortColumn = 0;
        private LVSortDataType mSortType = LVSortDataType.TextCaseSensitive;


        // Methods
        public int Compare(object x, object y)
        {
            int num = 0;
            ListViewItem item = (ListViewItem)x;
            ListViewItem item2 = (ListViewItem)y;
            switch (this.mSortType)
            {
                case LVSortDataType.TextCaseSensitive:
                    if (!this.mAscending)
                    {
                        return string.Compare(item2.SubItems[this.mSortColumn].Text, item.SubItems[this.mSortColumn].Text);
                    }
                    return string.Compare(item.SubItems[this.mSortColumn].Text, item2.SubItems[this.mSortColumn].Text);

                case LVSortDataType.TextIgnoreCase:
                    if (!this.mAscending)
                    {
                        return string.Compare(item2.SubItems[this.mSortColumn].Text, item.SubItems[this.mSortColumn].Text, true);
                    }
                    return string.Compare(item.SubItems[this.mSortColumn].Text, item2.SubItems[this.mSortColumn].Text, true);

                case LVSortDataType.Numbers:
                    try
                    {
                        if (this.mAscending)
                        {
                            return (int)Math.Round((double)(Conversions.ToDouble(item.SubItems[this.mSortColumn].Text) - Conversions.ToDouble(item2.SubItems[this.mSortColumn].Text)));
                        }
                        num = (int)Math.Round((double)(Conversions.ToDouble(item2.SubItems[this.mSortColumn].Text) - Conversions.ToDouble(item.SubItems[this.mSortColumn].Text)));
                    }
                    catch (Exception exception1)
                    {
                        ProjectData.SetProjectError(exception1);
                        Exception exception = exception1;
                        num = 0;
                        ProjectData.ClearProjectError();
                    }
                    return num;

                case (LVSortDataType.Numbers | LVSortDataType.TextIgnoreCase):
                    return num;

                case LVSortDataType.Dates:
                    try
                    {
                        if (this.mAscending)
                        {
                            return (int)DateAndTime.DateDiff(DateInterval.Day, Conversions.ToDate(item2.SubItems[this.mSortColumn].Text), Conversions.ToDate(item.SubItems[this.mSortColumn].Text), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
                        }
                        num = (int)DateAndTime.DateDiff(DateInterval.Day, Conversions.ToDate(item.SubItems[this.mSortColumn].Text), Conversions.ToDate(item2.SubItems[this.mSortColumn].Text), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1);
                    }
                    catch (Exception exception3)
                    {
                        ProjectData.SetProjectError(exception3);
                        Exception exception2 = exception3;
                        num = 0;
                        ProjectData.ClearProjectError();
                    }
                    return num;
            }
            return num;
        }

        // Properties
        public bool SortAscending
        {
            get
            {
                return this.mAscending;
            }
            set
            {
                this.mAscending = value;
            }
        }

        public int SortColumn
        {
            get
            {
                return this.mSortColumn;
            }
            set
            {
                this.mSortColumn = value;
            }
        }

        public LVSortDataType SortType
        {
            get
            {
                return this.mSortType;
            }
            set
            {
                this.mSortType = value;
            }
        }

        // Nested Types
        [StructLayout(LayoutKind.Sequential)]
        public struct LSColumn
        {
            public int ColumnNumber;
            public bool SortedAscending;
            public LSColumn(int ColNumber, bool SortAsc)
            {
                this = new ListViewSort.LSColumn();
                this.ColumnNumber = ColNumber;
                this.SortedAscending = SortAsc;
            }
        }

        public enum LVSortDataType
        {
            Dates = 4,
            Numbers = 2,
            TextCaseSensitive = 0,
            TextIgnoreCase = 1
        }
    }
#endif
}