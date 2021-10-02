#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    public class CalendarItemCancelEventArgs : CancelEventArgs
    {
        #region Ctor

        /// <summary>
        /// Creates a new <see cref="CalendarItemEventArgs"/>
        /// </summary>
        /// <param name="item">Related Item</param>
        public CalendarItemCancelEventArgs(CalendarItemAlternative item)
        {
            _item = item;
        }

        #endregion

        #region Props

        private CalendarItemAlternative _item;

        /// <summary>
        /// Gets the <see cref="CalendarItemAlternative"/> related to the event
        /// </summary>
        public CalendarItemAlternative Item
        {
            get { return _item; }
        }


        #endregion
    }
}
