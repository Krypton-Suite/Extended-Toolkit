using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Calendar.Library
{
    /// <summary>
    /// This column is used in SevenDay mode
    /// </summary>
    public class HalfWeekColumn : DataGridViewColumn
    {
        private DateTime m_startTime = DateTime.MinValue;

        public HalfWeekColumn()
        {
            this.CellTemplate = new DayCell();
        }


        public HalfWeekColumn(DateTime startTime) : this()
        {
            m_startTime = startTime;
        }

        public DateTime StartTime
        {
            get
            {
                return new DateTime(m_startTime.Year, m_startTime.Month, m_startTime.Day);
            }
        }

        public DateTime EndTime
        {
            get
            {
                if (this.Index == 0)
                    return this.StartTime.AddDays(3);
                else
                    return this.StartTime.AddDays(4);
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

    }// class
}