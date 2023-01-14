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

// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
using System.Diagnostics;
#pragma warning disable CS8602

#pragma warning disable CS1574, CS1584, CS1581, CS1580
namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    /// <summary>
    /// Represents a month displayed on <see cref="CalendarMonth"/>
    /// </summary>
    public class MonthViewMonth
    {
        #region Fields
        private DateTime _date;
        private Rectangle monthNameBounds;
        private Rectangle[] dayNamesBounds;
        private MonthViewDay?[] days;
        private string[] _dayHeaders;
        //private Size _size;
        private Point _location;
        private MonthView _monthview;
        #endregion

        #region Ctor

        internal MonthViewMonth(MonthView monthView, DateTime date)
        {
            if (date.Day != 1)
            {
                date = new DateTime(date.Year, date.Month, 1);
            }


            _monthview = monthView;
            _date = date;

            int preDays = (new int[] { 0, 1, 2, 3, 4, 5, 6 })[(int)date.DayOfWeek] - (int)MonthView.FirstDayOfWeek;
            days = new MonthViewDay?[6 * 7];
            DateTime curDate = date.AddDays(-preDays);
            DayHeaders = new string[7];

            for (int i = 0; i < days.Length; i++)
            {
                days[i] = new MonthViewDay(this, curDate);

                if (i < 7)
                {
                    DayHeaders[i] = curDate.ToString(MonthView.DayNamesFormat).Substring(0, MonthView.DayNamesLength);
                }

                curDate = curDate.AddDays(1);
            }
        }

        #endregion

        #region Props

        public Rectangle Bounds => new Rectangle(Location, Size);

        public MonthView MonthView => _monthview;

        public Point Location => _location;

        public Size Size => MonthView.MonthSize;

        public MonthViewDay?[] Days
        {
            get => days;
            set => days = value;
        }

        public Rectangle[] DayNamesBounds
        {
            get => dayNamesBounds;
            set => dayNamesBounds = value;
        }

        public string[] DayHeaders
        {
            get => _dayHeaders;
            set => _dayHeaders = value;
        }

        public Rectangle MonthNameBounds
        {
            get => monthNameBounds;
            set => monthNameBounds = value;
        }

        /// <summary>
        /// Gets or sets the date of the first day of the month
        /// </summary>
        public DateTime Date => _date;

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the value of the <see cref="Location"/> property
        /// </summary>
        /// <param name="location"></param>
        internal void SetLocation(Point location)
        {

            int startX = location.X;
            int startY = location.Y;
            int curX = startX;
            int curY = startY;

            _location = location;

            monthNameBounds = new Rectangle(location, new Size(Size.Width, MonthView.DaySize.Height));

            if (MonthView.DayNamesVisible)
            {
                dayNamesBounds = new Rectangle[7];
                curY = location.Y + MonthView.DaySize.Height;
                for (int i = 0; i < dayNamesBounds.Length; i++)
                {
                    DayNamesBounds[i] = new Rectangle(curX, curY, MonthView.DaySize.Width, MonthView.DaySize.Height);

                    curX += MonthView.DaySize.Width;
                }

            }
            else
            {
                dayNamesBounds = new Rectangle[] { };
            }

            curX = startX;
            curY = startY + MonthView.DaySize.Height * 2;

            for (int i = 0; i < Days.Length; i++)
            {
                if (Days != null)
                {
                    Debug.Assert(Days != null, nameof(Days) + " != null");
                    Days[i].SetBounds(new Rectangle(new Point(curX, curY), MonthView.DaySize));
                }

                curX += MonthView.DaySize.Width;

                if ((i + 1) % 7 == 0)
                {
                    curX = startX;
                    curY += MonthView.DaySize.Height;
                }
            }

        }

        #endregion
    }
}