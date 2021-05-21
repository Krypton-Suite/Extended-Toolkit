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
    /// This class is used for Month mode
    /// </summary>
    public class WeekRow : DataGridViewRow
    {
        private DateTime m_startTime = DateTime.MinValue;

        public WeekRow()
        {
        }

        public WeekRow(DateTime startTime) : this()
        {
            m_startTime = startTime;
        }

        public DateTime StartTime
        {
            get
            {
                return this.Calendar.StartTime.AddDays(7 * this.Index);
            }
        }

        public DateTime EndTime
        {
            get
            {
                return this.StartTime.AddDays(7);
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