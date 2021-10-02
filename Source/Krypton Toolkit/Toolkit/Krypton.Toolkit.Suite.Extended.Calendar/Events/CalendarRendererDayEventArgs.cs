#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    /// <summary>
    /// Contains information about a day to draw on the calendar
    /// </summary>
    public class CalendarRendererDayEventArgs : CalendarRendererEventArgs
    {
        #region Fields
        private CalendarDay _day;
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new <see cref="CalendarRendererDayEventArgs"/> object
        /// </summary>
        /// <param name="original">Orignal object to copy basic paramters</param>
        /// <param name="day">Day to render</param>
        public CalendarRendererDayEventArgs(CalendarRendererEventArgs original, CalendarDay day)
            : base(original)
        {
            _day = day;
        }

        #endregion

        #region Props

        /// <summary>
        /// Gets the day to paint
        /// </summary>
        public CalendarDay Day
        {
            get { return _day; }
        }


        #endregion
    }
}