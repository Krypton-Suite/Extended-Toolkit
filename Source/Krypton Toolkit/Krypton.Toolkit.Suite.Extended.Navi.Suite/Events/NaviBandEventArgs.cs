#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public delegate void NaviBandEventHandler(object sender, NaviBandEventArgs e);

    /// <summary>
    /// Contains additional event info
    /// </summary>
    public class NaviBandEventArgs : EventArgs
    {
        #region Fields

        private NaviBand newActiveBand;
        private bool cancel = false;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NaviBandEventArgs class
        /// </summary>
        /// <param name="newActiveButton">The new active band</param>
        public NaviBandEventArgs(NaviBand newActiveBand)
           : base()
        {
            this.newActiveBand = newActiveBand;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the new active band
        /// </summary>
        public NaviBand NewActiveBand
        {
            get { return newActiveBand; }
            set { newActiveBand = value; }
        }

        /// <summary>
        /// Gets or sets whether the event is canceled
        /// </summary>
        public bool Canceled
        {
            get { return cancel; }
            set { cancel = value; }
        }

        #endregion
    }

}