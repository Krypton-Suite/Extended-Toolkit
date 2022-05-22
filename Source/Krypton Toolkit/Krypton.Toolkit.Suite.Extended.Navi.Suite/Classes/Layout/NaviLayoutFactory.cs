#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    /// <summary>
    /// Responsible for reinitializing the LayoutEngine
    /// </summary>
    public class NaviLayoutFactory
    {
        // Fields
        private NaviBar ownerBar;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NaviLayoutFactory class 
        /// </summary>
        /// <param name="owner">The owner control</param>
        public NaviLayoutFactory(NaviBar owner)
        {
            ownerBar = owner;
        }

        /// <summary>
        /// Reinitializes the layout
        /// </summary>
        public void ReinitializeLayout()
        {
            if (ownerBar.NaviLayoutEngine != null)
                ownerBar.NaviLayoutEngine.Cleanup();

            if (ownerBar.LayoutStyle == NaviLayoutStyle.StyleFromOwner)
                ownerBar.LayoutStyle = NaviLayoutStyle.Office2007Blue;

            switch (ownerBar.LayoutStyle)
            {
                case NaviLayoutStyle.Office2003Blue:
                case NaviLayoutStyle.Office2003Green:
                case NaviLayoutStyle.Office2003Silver:
                case NaviLayoutStyle.Office2007Blue:
                case NaviLayoutStyle.Office2007Silver:
                case NaviLayoutStyle.Office2007Black:
                case NaviLayoutStyle.Office2010Blue:
                case NaviLayoutStyle.Office2010Silver:
                case NaviLayoutStyle.Office2010Black:
                    ownerBar.NaviLayoutEngine = new NaviLayoutEngineOffice(ownerBar);
                    break;
                default:
                    break;
            }

            ownerBar.NaviLayoutEngine.Initialize();
        }

        #endregion
    }
}