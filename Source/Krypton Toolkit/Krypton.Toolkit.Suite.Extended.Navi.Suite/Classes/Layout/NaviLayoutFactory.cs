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