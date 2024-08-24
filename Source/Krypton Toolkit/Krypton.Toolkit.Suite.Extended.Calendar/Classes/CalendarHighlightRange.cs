#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

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
        public KryptonCalendar Calendar => _calendar;

        /// <summary>
        /// Gets or sets the day of the week for this range
        /// </summary>
        public DayOfWeek DayOfWeek
        {
            get => _dayOfWeek;
            set { _dayOfWeek = value; Update(); }
        }

        /// <summary>
        /// Gets or sets the start time of the range
        /// </summary>
        public TimeSpan StartTime
        {
            get => _startTime;
            set { _startTime = value; Update(); }
        }

        /// <summary>
        /// Gets or sets the end time of the range
        /// </summary>
        public TimeSpan EndTime
        {
            get => _endTime;
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