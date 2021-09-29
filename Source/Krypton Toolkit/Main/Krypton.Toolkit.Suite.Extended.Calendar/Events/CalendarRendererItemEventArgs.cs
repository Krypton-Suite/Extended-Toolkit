#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    /// <summary>
    /// Contains information to render an item
    /// </summary>
    public class CalendarRendererItemEventArgs : CalendarRendererEventArgs
    {
        #region Fields
        private CalendarItemAlternative _item;
        #endregion

        #region Ctor


        public CalendarRendererItemEventArgs(CalendarRendererEventArgs original, CalendarItemAlternative item)
            : base(original)
        {
            _item = item;
        }

        #endregion

        #region Props

        /// <summary>
        /// Gets the Item being rendered
        /// </summary>
        public CalendarItemAlternative Item
        {
            get { return _item; }
        }


        #endregion
    }
}