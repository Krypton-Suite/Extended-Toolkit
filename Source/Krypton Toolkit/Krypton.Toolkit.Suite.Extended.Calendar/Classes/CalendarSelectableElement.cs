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
            if (calendar == null) throw new ArgumentNullException("calendar");

            _calendar = calendar;
        }

        #endregion

        #region ICalendarSelectableElement Members


        public virtual DateTime Date
        {
            get { return _date; }
        }


        /// <summary>
        /// Gets the Calendar this element belongs to
        /// </summary>
        public virtual KryptonCalendar Calendar
        {
            get { return _calendar; }
        }

        /// <summary>
        /// Gets the Bounds of the element on the <see cref="Calendar"/> window
        /// </summary>
        public virtual Rectangle Bounds
        {
            get { return _bounds; }
        }

        /// <summary>
        /// Gets a value indicating if the element is currently selected
        /// </summary>
        public virtual bool Selected
        {
            get
            {
                return _selected;
            }
        }

        /// <summary>
        /// Compares this element with other using date as comparer
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public virtual int CompareTo(ICalendarSelectableElement element)
        {
            return this.Date.CompareTo(element.Date);
        }

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