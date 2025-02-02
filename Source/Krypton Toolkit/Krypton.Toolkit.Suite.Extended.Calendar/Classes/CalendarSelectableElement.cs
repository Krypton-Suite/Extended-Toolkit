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
    /// Implements a basic <see cref="ICalendarSelectableElement"/>
    /// </summary>
    public abstract class CalendarSelectableElement : ICalendarSelectableElement
    {
        #region Fields
        private KryptonCalendar _calendar;
        private Rectangle _bounds;
        private DateTime _date = DateTime.Now;
        private bool _selected;
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new Element
        /// </summary>
        /// <param name="calendar"></param>
        public CalendarSelectableElement(KryptonCalendar calendar)
        {
            if (calendar == null)
            {
                throw new ArgumentNullException("calendar");
            }

            _calendar = calendar;
        }

        #endregion

        #region ICalendarSelectableElement Members


        public virtual DateTime Date => _date;


        /// <summary>
        /// Gets the Calendar this element belongs to
        /// </summary>
        public virtual KryptonCalendar Calendar => _calendar;

        /// <summary>
        /// Gets the Bounds of the element on the <see cref="Calendar"/> window
        /// </summary>
        public virtual Rectangle Bounds => _bounds;

        /// <summary>
        /// Gets a value indicating if the element is currently selected
        /// </summary>
        public virtual bool Selected => _selected;

        /// <summary>
        /// Compares this element with other using date as comparer
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public virtual int CompareTo(ICalendarSelectableElement? element) => Date.CompareTo(element!.Date);

        #endregion

        #region Internal Methods

        /// <summary>
        /// Sets the value of the <see cref="Bounds"/> property
        /// </summary>
        /// <param name="bounds">Bounds of the element</param>
        internal virtual void SetBounds(Rectangle bounds)
        {
            _bounds = bounds;
        }

        /// <summary>
        /// Sets the value of the <see cref="Selected"/> property
        /// </summary>
        /// <param name="selected">Value indicating if the element is currently selected</param>
        internal virtual void SetSelected(bool selected)
        {
            _selected = selected;

            //Calendar.Invalidate(Bounds);
        }

        #endregion
    }
}