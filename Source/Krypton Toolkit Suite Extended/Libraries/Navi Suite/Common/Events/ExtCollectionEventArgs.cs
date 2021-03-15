#region BSD License
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

using System;

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    /// <summary>
    /// This class contains additional info about an add or remove operation
    /// For more information see <see cref="ChildControlCollection"/>
    /// </summary>
    public class ExtCollectionEventArgs : EventArgs
    {
        #region Fields

        private Object m_item;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the CollectionEventArgs class
        /// </summary>
        public ExtCollectionEventArgs()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CollectionEventArgs class
        /// </summary>
        /// <param name="item">Item which changed the collection</param>
        public ExtCollectionEventArgs(object item)
        {
            m_item = item;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the item which changed the collection
        /// </summary>
        public Object Item
        {
            get { return m_item; }
            set { m_item = value; }
        }

        #endregion
    }

    public delegate void CollectionEventHandler(object sender, ExtCollectionEventArgs e);
}