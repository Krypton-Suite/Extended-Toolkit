#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Calendar.Library
{
    /// <summary>
    /// This class is used for OneDay and FiveDay modes
    /// </summary>
    public class DayColumn : DataGridViewColumn
    {
        private DateTime m_startTime = DateTime.MinValue;
        private int m_workingHourStart = 8;
        private int m_workingHourEnd = 17;

        public DayColumn()
        {
            this.CellTemplate = new HalfHourCell();
            this.HeaderCell = new DayColumnHeaderCell();
            this.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public DayColumn(DateTime startTime) : this()
        {
            m_startTime = startTime;
            SetHeaderCellValue();
        }

        public DateMode DateMode
        {
            get
            {
                try
                {
                    Calendar calendar = this.DataGridView as Calendar;
                    return calendar.DateMode;
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    return DateMode.OneDay;
                }
            }
        }

        public Calendar Calendar
        {
            get
            {
                return this.DataGridView as Calendar;
            }
        }

        public List<CalendarItem> CalendarItems
        {
            get
            {
                try
                {
                    if (this.Calendar.CalendarItems == null || this.Calendar.CalendarItems.Count <= 0)
                        return null;

                    List<CalendarItem> items = new List<CalendarItem>();
                    for (int i = 0; i < this.Calendar.CalendarItems.Count; i++)
                    {
                        DateTime ciStartTime = this.Calendar.CalendarItems[i].StartTime;
                        DateTime ciEndTime = this.Calendar.CalendarItems[i].EndTime;

                        if (((ciStartTime.CompareTo(this.StartTime) <= 0) && (ciEndTime.CompareTo(this.StartTime) > 0))
                        || ((ciStartTime.CompareTo(this.StartTime) >= 0) && (ciEndTime.CompareTo(this.EndTime) <= 0))
                        || ((ciStartTime.CompareTo(this.EndTime) < 0) && (ciEndTime.CompareTo(this.EndTime) >= 0)))
                        {
                            items.Add(this.Calendar.CalendarItems[i]);
                        }
                    }
                    return items;
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    return null;
                }
            }
        }

        public HalfHourCell GetHalfHourCell(DateTime startTime)
        {
            try
            {
                if (startTime.CompareTo(this.StartTime) < 0 || startTime.CompareTo(this.EndTime) > 0)
                    return null;

                int rowIndex = startTime.Hour * 2;
                if (startTime.Minute == 30)
                    rowIndex++;
                return this.Calendar.Rows[rowIndex].Cells[this.Index] as HalfHourCell;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return null;
            }
        }

        private void SetHeaderCellValue()
        {
            try
            {
                if (this.DateMode != DateMode.OneDay && this.DateMode != DateMode.FiveDay)
                    return;

                this.HeaderCell.Value = this.StartTime.ToLongDateString();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        public DateTime StartTime
        {
            get
            {
                return new DateTime(m_startTime.Year, m_startTime.Month, m_startTime.Day);
            }
            set
            {
                m_startTime = value;
                SetHeaderCellValue();
            }
        }

        public DateTime EndTime
        {
            get
            {
                return this.StartTime.AddDays(1);
            }
        }

        public bool IsWeekend
        {
            get
            {
                if (this.StartTime.DayOfWeek == DayOfWeek.Saturday || this.StartTime.DayOfWeek == DayOfWeek.Sunday)
                    return true;
                else
                    return false;
            }
        }

        public int WorkingHourStart
        {
            get
            {
                return m_workingHourStart;
            }
            set
            {
                m_workingHourStart = value;
            }
        }

        public int WorkingHourEnd
        {
            get
            {
                return m_workingHourEnd;
            }
            set
            {
                m_workingHourEnd = value;
            }
        }

    }
}
