﻿#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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
    /// Represents a selectable timescale unit on a <see cref="CalendarDay"/>
    /// </summary>
    public class CalendarTimeScaleUnit : CalendarSelectableElement
    {
        #region Events

        #endregion

        #region Fields
        private DateTime _date;
        private CalendarDay _day;
        private bool _highlighted;
        private int _hours;
        private int _index;
        private int _minutes;
        private List<CalendarItemAlternative> _passingItems;
        private bool _visible;
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new <see cref="CalendarTimeScaleUnit"/>
        /// </summary>
        /// <param name="day"><see cref="CalendarDay"/> this unit belongs to</param>
        /// <param name="index">Index of the unit relative to the container day</param>
        /// <param name="hours">Hour of the unit</param>
        /// <param name="minutes">Minutes of the unit</param>
        internal CalendarTimeScaleUnit(CalendarDay day, int index, int hours, int minutes)
            : base(day.Calendar)
        {
            _day = day;
            _index = index;
            _hours = hours;
            _minutes = minutes;

            _passingItems = new List<CalendarItemAlternative>();
        }

        #endregion

        #region Properties



        /// <summary>
        /// Gets the exact date when the unit starts
        /// </summary>
        public override DateTime Date
        {
            get
            {
                if (_date.Equals(DateTime.MinValue))
                {
                    _date = new DateTime(Day.Date.Year, Day.Date.Month, Day.Date.Day, Hours, Minutes, 0);
                }

                return _date;
            }
        }

        /// <summary>
        /// Gets the <see cref="CalendarDay"/> this unit belongs to
        /// </summary>
        public CalendarDay Day => _day;

        /// <summary>
        /// Gets the duration of the unit.
        /// </summary>
        public TimeSpan Duration => new(0, (int)Calendar.TimeScale, 0);

        /// <summary>
        /// Gets if the unit is highlighted because it fits in some of the calendar's highlight ranges
        /// </summary>
        public bool Highlighted => _highlighted;

        /// <summary>
        /// Gets the hour when this unit starts
        /// </summary>
        public int Hours => _hours;

        /// <summary>
        /// Gets the index of the unit relative to the day
        /// </summary>
        public int Index => _index;

        /// <summary>
        /// Gets the minute when this unit starts
        /// </summary>
        public int Minutes
        {
            get => _minutes;
            set => _minutes = value;
        }

        /// <summary>
        /// Gets or sets the amount of items that pass over the unit
        /// </summary>
        internal List<CalendarItemAlternative> PassingItems
        {
            get => _passingItems;
            set => _passingItems = value;
        }

        /// <summary>
        /// Gets a value indicating if the unit is currently visible on viewport
        /// </summary>
        public bool Visible => _visible;

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return $"[{Index}] - {Date.ToShortTimeString()}";
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets a value indicating if the unit should be higlighted
        /// </summary>
        /// <returns></returns>
        internal bool CheckHighlighted()
        {
            for (int i = 0; i < Day.Calendar.HighlightRanges.Length; i++)
            {
                CalendarHighlightRange range = Day.Calendar.HighlightRanges[i];

                if (range.DayOfWeek != Date.DayOfWeek)
                    continue;

                if (Date.TimeOfDay.CompareTo(range.StartTime) >= 0
                    && Date.TimeOfDay.CompareTo(range.EndTime) < 0)
                {
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// Sets the value of the <see cref="Highlighted"/> property
        /// </summary>
        /// <param name="highlighted">Value of the property</param>
        internal void SetHighlighted(bool highlighted)
        {
            _highlighted = highlighted;
        }

        /// <summary>
        /// Sets the value of the <see cref="Visible"/> property
        /// </summary>
        /// <param name="visible">Value indicating if the unit is currently visible on viewport</param>
        internal void SetVisible(bool visible)
        {
            _visible = visible;
        }

        #endregion


        internal void AddPassingItem(CalendarItemAlternative item)
        {
            if (!PassingItems.Contains(item))
            {
                PassingItems.Add(item);
                Day.AddContainedItem(item);
            }
        }

        /// <summary>
        /// Clears existance of item from this unit and it's corresponding day.
        /// </summary>
        /// <param name="item"></param>
        internal void ClearItemExistance(CalendarItemAlternative item)
        {
            if (PassingItems.Contains(item))
            {
                PassingItems.Remove(item);
            }

            if (Day.ContainedItems.Contains(item))
            {
                Day.ContainedItems.Remove(item);
            }
        }
    }
}