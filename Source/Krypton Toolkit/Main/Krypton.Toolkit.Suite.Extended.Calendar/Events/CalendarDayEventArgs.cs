#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    /// <summary>
    /// Event data with a <see cref="CalendarDay"/> element
    /// </summary>
    public class CalendarDayEventArgs : EventArgs
    {
        #region Constructor
        /// <summary>
        /// Creates a new event with the specified day
        /// </summary>
        /// <param name="day">Day of the event</param>
        public CalendarDayEventArgs(CalendarDay day)
        {
            _calendarDay = day;
        }

        #endregion

        #region Props
        private CalendarDay _calendarDay;

        /// <summary>
        /// Gets the day related to the event
        /// </summary>
        public CalendarDay CalendarDay => _calendarDay;

        #endregion
    }
}