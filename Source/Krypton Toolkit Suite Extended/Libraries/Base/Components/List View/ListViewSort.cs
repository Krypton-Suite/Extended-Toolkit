using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    public class ListViewSort : IComparer
    {
        #region Variables
        private bool _mAscending = true;

        private int _mSortColumn = 0;

        private LVSortDataType _dataType = LVSortDataType.TEXTCASESENSITIVE;
        #endregion

        #region Methods
        public int Compare(object x, object y)
        {
            int num = 0;

            ListViewItem item0 = (ListViewItem)x, item1 = (ListViewItem)y;

            switch (_dataType)
            {
                case LVSortDataType.DATES:
                    try
                    {
                        if (_mAscending) return (int)DateAndTime.DateDiff(DateInterval.Day, Conversions.ToDate(item1.SubItems[_mSortColumn].Text), Conversions.ToDate(item0.SubItems[_mSortColumn].Text), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1);

                        num = (int)DateAndTime.DateDiff(DateInterval.Day, Conversions.ToDate(item0.SubItems[_mSortColumn].Text), Conversions.ToDate(item1.SubItems[_mSortColumn].Text), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1);
                    }
                    catch (Exception e3)
                    {
                        ProjectData.SetProjectError(e3);

                        Exception e2 = e3;

                        num = 0;

                        ProjectData.ClearProjectError();
                    }
                    break;
                case LVSortDataType.NUMBERS:
                    try
                    {
                        if (_mAscending) return (int)Math.Round((double)(Conversions.ToDouble(item0.SubItems[_mSortColumn].Text) - Conversions.ToDouble(item1.SubItems[_mSortColumn].Text)));

                        num = (int)Math.Round((double)(Conversions.ToDouble(item1.SubItems[_mSortColumn].Text) - Conversions.ToDouble(item0.SubItems[_mSortColumn].Text)));
                    }
                    catch (Exception e1)
                    {
                        ProjectData.SetProjectError(e1);

                        Exception e0 = e1;

                        num = 0;

                        ProjectData.ClearProjectError();
                    }
                    break;
                case LVSortDataType.TEXTCASESENSITIVE:
                    if (!_mAscending) return string.Compare(item1.SubItems[_mSortColumn].Text, item0.SubItems[_mSortColumn].Text);

                    return string.Compare(item0.SubItems[_mSortColumn].Text, item1.SubItems[_mSortColumn].Text);
                    break;
                case LVSortDataType.TEXTIGNORECASE:
                    if (!_mAscending) return string.Compare(item1.SubItems[_mSortColumn].Text, item0.SubItems[_mSortColumn].Text, true);

                    return string.Compare(item0.SubItems[_mSortColumn].Text, item1.SubItems[_mSortColumn].Text, true);
                    break;
                case (LVSortDataType.NUMBERS | LVSortDataType.TEXTIGNORECASE):
                    return num;
            }

            return num;
        }
        #endregion

        #region Properties
        public bool SortAscending { get => _mAscending; set => _mAscending = value; }

        public int SortColumn { get => _mSortColumn; set => _mSortColumn = value; }

        public LVSortDataType SortType { get => _dataType; set => _dataType = value; }
        #endregion

        #region Structs
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
        #endregion
    }
}