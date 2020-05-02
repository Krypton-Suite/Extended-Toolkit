using System;

namespace Krypton.Toolkit.Extended.Base
{
    public class CalendarItemEventArgs : EventArgs
    {
        #region Ctor

        /// <summary>
        /// Creates a new <see cref="CalendarItemEventArgs"/>
        /// </summary>
        /// <param name="item">Related Item</param>
        public CalendarItemEventArgs(CalendarItem item)
        {
            _item = item;
        }

        #endregion

        #region Props

        private CalendarItem _item;

        /// <summary>
        /// Gets the <see cref="CalendarItem"/> related to the event
        /// </summary>
        public CalendarItem Item => _item;
        #endregion
    }
}