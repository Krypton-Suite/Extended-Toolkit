#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    /// <summary>
    /// Represents the top area of a day, where multiday and all day items are stored
    /// </summary>
    public class CalendarDayTop : CalendarSelectableElement
    {
        #region Events

        #endregion

        #region Fields
        private CalendarDay _day;
        private List<CalendarItemAlternative> _passingItems;
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new DayTop for the specified day
        /// </summary>
        /// <param name="day"></param>
        public CalendarDayTop(CalendarDay day) : base(day.Calendar)
        {
            _day = day;
            _passingItems = new List<CalendarItemAlternative>();
        }

        #endregion

        #region Properties

        public override DateTime Date
        {
            get
            {
                return new DateTime(Day.Date.Year, Day.Date.Month, Day.Date.Day);
            }
        }

        /// <summary>
        /// Gets the Day of this DayTop
        /// </summary>
        public CalendarDay Day
        {
            get { return _day; }
        }


        /// <summary>
        /// Gets the list of items passing on this daytop
        /// </summary>
        public List<CalendarItemAlternative> PassingItems
        {
            get { return _passingItems; }
        }


        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        internal void AddPassingItem(CalendarItemAlternative item)
        {
            if (!PassingItems.Contains(item))
            {
                PassingItems.Add(item);
            }
        }

        #endregion
    }
}