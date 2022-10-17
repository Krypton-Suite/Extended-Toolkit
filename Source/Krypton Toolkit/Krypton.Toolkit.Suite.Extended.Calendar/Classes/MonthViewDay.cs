#region MIT License
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
            get => _monthView;
            set => _monthView = value;
        }

        /// <summary>
        /// Gets the parent MonthViewMonth
        /// </summary>
        public MonthViewMonth Month => _month;

        /// <summary>
        /// Gets the bounds of the day
        /// </summary>
        public Rectangle Bounds => _bounds;

        /// <summary>
        /// Gets the date this day represents
        /// </summary>
        public DateTime Date => _date;

        /// <summary>
        /// Gets or sets if the day is currently selected
        /// </summary>
        public bool Selected => Date >= MonthView.SelectionStart && Date <= MonthView.SelectionEnd;

        /// <summary>
        /// Gets if the day is grayed
        /// </summary>
        public bool Grayed => Month.Date.Month != Date.Month;

        /// <summary>
        /// Gets a value indicating if the day instance is visible on the calendar
        /// </summary>
        public bool Visible => !(Grayed && (Date > MonthView.ViewStart && Date < MonthView.ViewEnd));

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