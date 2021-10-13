#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    public class MonthViewDay
    {
        #region Fields

        private Rectangle _bounds;
        private DateTime _date;
        private MonthViewMonth _month;
        private MonthView _monthView;

        #endregion

        #region Ctor

        internal MonthViewDay(MonthViewMonth month, DateTime date)
        {
            _month = month;
            _monthView = month.MonthView;
            _date = date;


        }

        #endregion

        #region Props

        /// <summary>
        /// Gets the parent MonthView
        /// </summary>
        public MonthView MonthView
        {
            get { return _monthView; }
            set { _monthView = value; }
        }

        /// <summary>
        /// Gets the parent MonthViewMonth
        /// </summary>
        public MonthViewMonth Month
        {
            get { return _month; }
        }

        /// <summary>
        /// Gets the bounds of the day
        /// </summary>
        public Rectangle Bounds
        {
            get { return _bounds; }
        }

        /// <summary>
        /// Gets the date this day represents
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
        }

        /// <summary>
        /// Gets or sets if the day is currently selected
        /// </summary>
        public bool Selected
        {
            get { return Date >= MonthView.SelectionStart && Date <= MonthView.SelectionEnd; }
        }

        /// <summary>
        /// Gets if the day is grayed
        /// </summary>
        public bool Grayed
        {
            get { return Month.Date.Month != Date.Month; }
        }

        /// <summary>
        /// Gets a value indicating if the day instance is visible on the calendar
        /// </summary>
        public bool Visible
        {
            get
            {
                return !(Grayed && (Date > MonthView.ViewStart && Date < MonthView.ViewEnd));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the value of the <see cref="Bounds"/> property
        /// </summary>
        /// <param name="bounds"></param>
        internal void SetBounds(Rectangle bounds)
        {
            _bounds = bounds;
        }

        #endregion
    }
}