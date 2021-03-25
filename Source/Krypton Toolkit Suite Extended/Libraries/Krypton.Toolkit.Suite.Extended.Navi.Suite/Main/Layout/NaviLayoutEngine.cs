﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

// Original license

/**
* MIT License
*
* Copyright (c) 2017 - 2018 Jacob Mesu
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
*/
#endregion

using System.Drawing;
using System.Windows.Forms.Layout;

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    /// <summary>
    /// Contains layout logic defining the view and the functionality of the NavigationBar
    /// </summary>
    public class NaviLayoutEngine : LayoutEngine, IObserver
    {
        // Fields
        private NaviBar ownerBar;

        #region Constructor 

        /// <summary>
        /// Intializes a new instance of the NaviLayoutEngine class
        /// </summary>
        /// <param name="owner">The Bar owner</param>
        public NaviLayoutEngine(NaviBar owner)
        {
            ownerBar = owner;
        }

        #endregion

        #region Properties 

        /// <summary>
        /// The NaviBar to which this layout logic applies
        /// </summary>
        protected NaviBar OwnerBar
        {
            get { return ownerBar; }
        }

        #endregion

        #region Public Virtual Methods

        /// <summary>
        /// Request the engine to clean up resource being used, like local controls
        /// </summary>
        public virtual void Cleanup()
        {
        }

        /// <summary>
        /// Requests the engine to initialize itself
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        /// Initializes the Bands for the first time. This typically occurs when a new band has been added 
        /// or removed
        /// </summary>
        public virtual void InitializeBands()
        {
        }

        /// <summary>
        /// Requests the engine to start the drawing process for the navigation bar
        /// </summary>
        /// <param name="g"></param>
        public virtual void Draw(Graphics g)
        {
        }

        /// <summary>
        /// Requests the engine to start the drawing process for the background of the navigation bar
        /// </summary>
        /// <param name="g"></param>
        public virtual void DrawBackground(Graphics g)
        {
        }

        #endregion

        #region IObserver Members

        /// <summary>
        /// Overriden. Handles the Notification the observable object sent
        /// </summary>
        /// <param name="obj">The observable object</param>
        /// <param name="id">An identification which caused this notification</param>
        /// <param name="arguments">Additional info</param>
        public virtual void Notify(IObservable obj, string id, object arguments)
        {
        }

        #endregion
    }
}