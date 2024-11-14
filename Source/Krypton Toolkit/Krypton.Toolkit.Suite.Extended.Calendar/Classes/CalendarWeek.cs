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
    /// Represents a week displayed on the <see cref="KryptonCalendar"/>
    /// </summary>
    public class CalendarWeek
    {
        #region Events

        #endregion

        #region Fields
        private Rectangle _bounds;
        private KryptonCalendar _calendar;
        private DateTime _firstDay;
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new week for the specified calendar
        /// </summary>
        /// <param name="calendar">Calendar this week belongs to</param>
        /// <param name="firstDay">Start day of the week</param>
        internal CalendarWeek(KryptonCalendar calendar, DateTime firstDay)
        {
            _calendar = calendar;
            _firstDay = firstDay;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the bounds of the week
        /// </summary>
        public Rectangle Bounds => _bounds;

        /// <summary>
        /// Gets the calendar this week belongs to
        /// </summary>
        public KryptonCalendar Calendar => _calendar;

        /// <summary>
        /// Gets the bounds of the week header
        /// </summary>
        public Rectangle HeaderBounds
        {
            get
            {
                if (Calendar.Renderer != null)
                {
                    return new Rectangle(
                        Bounds.Left,
                        Bounds.Top + Calendar.Renderer.DayHeaderHeight,
                        Calendar.Renderer.WeekHeaderWidth,
                        Bounds.Height - Calendar.Renderer.DayHeaderHeight);
                }

                return Rectangle.Empty;
            }
        }

        /// <summary>
        /// Gets the sunday that starts the week
        /// </summary>
        public DateTime StartDate => _firstDay;

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the short version of week's string representation
        /// </summary>
        /// <returns></returns>
        public string? ToStringShort()
        {
            DateTime saturday = StartDate.AddDays(6);

            if (saturday.Month != StartDate.Month)
            {
                return $"{StartDate.ToString("d/M")} - {saturday.ToString("d/M")}";
            }
            else
            {
                return $"{StartDate.Day} - {saturday.ToString("d/M")}";
            }
        }

        /// <summary>
        /// Gets the large version of string representation
        /// </summary>
        /// <returns>The week in a string format</returns>
        public string? ToStringLarge()
        {
            DateTime saturday = StartDate.AddDays(6);

            if (saturday.Month != StartDate.Month)
            {
                return $"{StartDate.ToString("d MMM")} - {saturday.ToString("d MMM")}";
            }
            else
            {
                return $"{StartDate.Day} - {saturday.ToString("d MMM")}";
            }
        }

        /// <summary>
        /// Returns a string representation of the week
        /// </summary>
        /// <returns></returns>
        public override string? ToString()
        {
            return ToStringLarge();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the value of the <see cref="Bounds"/> property
        /// </summary>
        /// <param name="r"></param>
        internal void SetBounds(Rectangle r)
        {
            _bounds = r;
        }

        #endregion
    }
}