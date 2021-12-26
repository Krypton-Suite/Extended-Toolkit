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
    /// Represents a range of time that is highlighted as work-time
    /// </summary>
    public class CalendarHighlightRange
    {
        #region Events

        #endregion

        #region Fields
        private KryptonCalendar _calendar;
        private DayOfWeek _dayOfWeek;
        private TimeSpan _startTime;
        private TimeSpan _endTime;
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new empty range
        /// </summary>
        public CalendarHighlightRange()
        {

        }

        /// <summary>
        /// Creates a new range with the specified information
        /// </summary>
        /// <param name="day"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public CalendarHighlightRange(DayOfWeek day, TimeSpan startTime, TimeSpan endTime)
            : this()
        {
            _dayOfWeek = day;
            _startTime = startTime;
            _endTime = endTime;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the calendar that this range is assigned to. (If any)
        /// </summary>
        public KryptonCalendar Calendar
        {
            get { return _calendar; }
        }

        /// <summary>
        /// Gets or sets the day of the week for this range
        /// </summary>
        public DayOfWeek DayOfWeek
        {
            get { return _dayOfWeek; }
            set { _dayOfWeek = value; Update(); }
        }

        /// <summary>
        /// Gets or sets the start time of the range
        /// </summary>
        public TimeSpan StartTime
        {
            get { return _startTime; }
            set { _startTime = value; Update(); }
        }

        /// <summary>
        /// Gets or sets the end time of the range
        /// </summary>
        public TimeSpan EndTime
        {
            get { return _endTime; }
            set { _endTime = value; Update(); }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        /// <summary>
        /// Tells the calendar to update the highlights
        /// </summary>
        private void Update()
        {
            if (Calendar != null)
            {
                Calendar.UpdateHighlights();
            }
        }

        /// <summary>
        /// Sets the value of the <see cref="KryptonCalendar"/> property
        /// </summary>
        /// <param name="calendar">Calendar that this range belongs to</param>
        internal void SetCalendar(KryptonCalendar calendar)
        {
            _calendar = calendar;
        }

        #endregion
    }
}