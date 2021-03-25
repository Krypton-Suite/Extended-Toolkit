#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class TimeChangedEventArgs : EventArgs
    {
        #region Variables
        private DateTime _currentDateTime;
        #endregion

        #region Properties
        /// <summary>Gets or sets the current date and time.</summary>
        /// <value>The current date and time.</value>
        public DateTime CurrentDateTime { get => _currentDateTime; set => _currentDateTime = value; }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="TimeChangedEventArgs"/> class.</summary>
        /// <param name="currentDateTime">The current date and time.</param>
        public TimeChangedEventArgs(DateTime currentDateTime) => CurrentDateTime = currentDateTime;
        #endregion

        #region Methods
        /// <summary>Synchronises the date time to now.</summary>
        /// <returns></returns>
        public DateTime SynchroniseDateTime() => DateTime.Now;
        #endregion
    }
}