#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    /// <summary>
    /// Represents a day present on the <see cref="KryptonCalendar"/> control's view.
    /// </summary>
    public class CalendarDay : CalendarSelectableElement
    {
        #region Static

        private Size overflowSize = new Size(16, 16);
        private Padding overflowPadding = new Padding(5);

        #endregion

        #region Events

        #endregion

        #region Fields
        private List<CalendarItemAlternative> _containedItems;
        private KryptonCalendar _calendar;
        private DateTime _date;
        private CalendarDayTop _dayTop;
        private int _index;
        private bool _overflowStart;
        private bool _overflowEnd;
        private bool _overflowStartSelected;
        private bool _overlowEndSelected;
        private CalendarTimeScaleUnit[] _timeUnits;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Day
        /// </summary>
        /// <param name="calendar">Calendar this day belongs to</param>
        /// <param name="date">Date of the day</param>
        /// <param name="index">Index of the day on the current calendar's view</param>
        internal CalendarDay(KryptonCalendar calendar, DateTime date, int index) : base(calendar)
        {
            _containedItems = new List<CalendarItemAlternative>();
            _calendar = calendar;
            _dayTop = new CalendarDayTop(this);
            _date = date;
            _index = index;

            UpdateUnits();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a list of items contained on the day
        /// </summary>
        internal List<CalendarItemAlternative> ContainedItems
        {
            get { return _containedItems; }
        }

        /// <summary>
        /// Gets the DayTop of the day, the place where multi-day and all-day items are placed
        /// </summary>
        public CalendarDayTop DayTop
        {
            get { return _dayTop; }
        }

        /// <summary>
        /// Gets the bounds of the body of the day (where time-based CalendarItems are placed)
        /// </summary>
        public Rectangle BodyBounds
        {
            get
            {
                return Rectangle.FromLTRB(Bounds.Left, DayTop.Bounds.Bottom, Bounds.Right, Bounds.Bottom);
            }
        }

        /// <summary>
        /// Gets the date this day represents
        /// </summary>
        public override DateTime Date
        {
            get { return _date; }
        }

        /// <summary>
        /// Gets the bounds of the header of the day
        /// </summary>
        public Rectangle HeaderBounds
        {
            get
            {
                return new Rectangle(Bounds.Left, Bounds.Top, Bounds.Width, Calendar.Renderer.DayHeaderHeight);
            }
        }

        /// <summary>
        /// Gets the index of this day on the calendar
        /// </summary>
        public int Index
        {
            get { return _index; }
        }

        /// <summary>
        /// Gets a value indicating if the day is specified on the view (See remarks).
        /// </summary>
        /// <remarks>
        /// A day may not be specified on the view, but still present to make up a square calendar.
        /// This days should be drawn in a way that indicates it's necessary but unrequested presence.
        /// </remarks>
        public bool SpecifiedOnView
        {
            get
            {
                return Date.CompareTo(Calendar.ViewStart) >= 0 && Date.CompareTo(Calendar.ViewEnd) <= 0;
            }
        }

        /// <summary>
        /// Gets the time units contained on the day
        /// </summary>
        public CalendarTimeScaleUnit[] TimeUnits
        {
            get { return _timeUnits; }
        }

        /// <summary>
        /// /// <summary>
        /// Gets a value indicating if the day contains items not shown through the start of the day
        /// </summary>
        /// </summary>
        public bool OverflowStart
        {
            get { return _overflowStart; }
        }

        /// <summary>
        /// Gets the bounds of the <see cref="OverflowStart"/> indicator
        /// </summary>
        public virtual Rectangle OverflowStartBounds
        {
            get { return new Rectangle(new Point(Bounds.Right - overflowPadding.Right - overflowSize.Width, Bounds.Top + overflowPadding.Top), overflowSize); }
        }

        /// <summary>
        /// Gets a value indicating if the <see cref="OverflowStart"/> indicator is currently selected
        /// </summary>
        /// <remarks>
        /// This value set to <c>true</c> when user hovers the mouse on the <see cref="OverflowStartBounds"/> area
        /// </remarks>
        public bool OverflowStartSelected
        {
            get { return _overflowStartSelected; }
        }


        /// <summary>
        /// Gets a value indicating if the day contains items not shown through the end of the day
        /// </summary>
        public bool OverflowEnd
        {
            get { return _overflowEnd; }
        }

        /// <summary>
        /// Gets the bounds of the <see cref="OverflowEnd"/> indicator
        /// </summary>
        public virtual Rectangle OverflowEndBounds
        {
            get { return new Rectangle(new Point(Bounds.Right - overflowPadding.Right - overflowSize.Width, Bounds.Bottom - overflowPadding.Bottom - overflowSize.Height), overflowSize); }
        }

        /// <summary>
        /// Gets a value indicating if the <see cref="OverflowEnd"/> indicator is currently selected
        /// </summary>
        /// <remarks>
        /// This value set to <c>true</c> when user hovers the mouse on the <see cref="OverflowStartBounds"/> area
        /// </remarks>
        public bool OverflowEndSelected
        {
            get { return _overlowEndSelected; }
        }


        #endregion

        #region Public Methods

        public override string ToString()
        {
            return Date.ToShortDateString();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Adds an item to the <see cref="ContainedItems"/> list if not in yet
        /// </summary>
        /// <param name="item"></param>
        internal void AddContainedItem(CalendarItemAlternative item)
        {
            if (!ContainedItems.Contains(item))
            {
                ContainedItems.Add(item);
            }
        }

        /// <summary>
        /// Sets the value of he <see cref="OverflowEnd"/> property
        /// </summary>
        /// <param name="overflow">Value of the property</param>
        internal void SetOverflowEnd(bool overflow)
        {
            _overflowEnd = overflow;
        }

        /// <summary>
        /// Sets the value of the <see cref="OverflowEndSelected"/> property
        /// </summary>
        /// <param name="selected">Value to pass to the property</param>
        internal void SetOverflowEndSelected(bool selected)
        {
            _overlowEndSelected = selected;
        }

        /// <summary>
        /// Sets the value of he <see cref="OverflowStart"/> property
        /// </summary>
        /// <param name="overflow">Value of the property</param>
        internal void SetOverflowStart(bool overflow)
        {
            _overflowStart = overflow;
        }

        /// <summary>
        /// Sets the value of the <see cref="OverflowStartSelected"/> property
        /// </summary>
        /// <param name="selected">Value to pass to the property</param>
        internal void SetOverflowStartSelected(bool selected)
        {
            _overflowStartSelected = selected;
        }

        /// <summary>
        /// Updates the value of <see cref="TimeUnits"/> property
        /// </summary>
        internal void UpdateUnits()
        {
            int factor = 0;

            switch (Calendar.TimeScale)
            {
                case CalendarTimeScale.SIXTYMINUTES: factor = 1; break;
                case CalendarTimeScale.THIRTYMINUTES: factor = 2; break;
                case CalendarTimeScale.FIFTEENMINUTES: factor = 4; break;
                case CalendarTimeScale.TENMINUTES: factor = 6; break;
                case CalendarTimeScale.SIXMINUTES: factor = 10; break;
                case CalendarTimeScale.FIVEMINUTES: factor = 12; break;
                default: throw new NotImplementedException("TimeScale not supported");
            }

            _timeUnits = new CalendarTimeScaleUnit[24 * factor];

            int hourSum = 0;
            int minSum = 0;

            for (int i = 0; i < _timeUnits.Length; i++)
            {
                _timeUnits[i] = new CalendarTimeScaleUnit(this, i, hourSum, minSum);

                minSum += 60 / factor;

                if (minSum >= 60)
                {
                    minSum = 0;
                    hourSum++;
                }
            }

            UpdateHighlights();
        }

        /// <summary>
        /// Updates the highlights of the units
        /// </summary>
        internal void UpdateHighlights()
        {
            if (TimeUnits == null)
                return;

            for (int i = 0; i < TimeUnits.Length; i++)
            {
                TimeUnits[i].SetHighlighted(TimeUnits[i].CheckHighlighted());
            }
        }

        #endregion
    }
}