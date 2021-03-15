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

using System.Collections;

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    /// <summary>
    /// The basic collection class with events which notifies when new items have been added or removed
    /// </summary>
    /// <remarks>
    /// This class can be useful when a container class needs to now which object have been added to
    /// the collection or have been removed. This is especially useful when you want the child controls
    /// to appear in the document outline (Visual Studio only). The child controls needs to be part of
    /// the controls collection to achieve this. You can use the events <see cref="ItemAdded"/> and
    /// <see cref="ItemRemoved"/> to add or remove the controls from the Controls collection. 
    /// </remarks>
    /// <example>TODO</example>
    public class ExtCollection : CollectionBase
    {
        #region Fields

        CollectionEventHandler m_itemAdded;
        CollectionEventHandler m_itemRemoved;
        protected bool notify = true;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ChildControlCollection class
        /// </summary>
        public ExtCollection()
           : base()
        {
        }

        #endregion

        #region Properties
        #endregion

        #region Methods

        /// <summary>
        // Sorts the elements in the entire collection using the specified comparer.
        /// </summary>
        /// <param name="comparer">The IComparer implementation to use when comparing elements.</param>
        public virtual void Sort(IComparer comparer)
        {
            InnerList.Sort(comparer);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Overriden. Raises the Removed event 
        /// </summary>      
        protected override void OnRemoveComplete(int index, object value)
        {
            base.OnRemoveComplete(index, value);
            CollectionEventHandler handler = m_itemRemoved;
            if ((handler != null)
            && notify)
            {
                handler(this, new ExtCollectionEventArgs(value));
            }
        }

        /// <summary>
        /// Overriden. Raises the item added event 
        /// </summary>      
        protected override void OnInsertComplete(int index, object value)
        {
            base.OnInsertComplete(index, value);
            CollectionEventHandler handler = m_itemAdded;
            if ((handler != null)
            && notify)
            {
                handler(this, new ExtCollectionEventArgs(value));
            }
        }

        #endregion

        #region Event Handling

        /// <summary>
        /// Occurs when an item has been added to the collection
        /// </summary>
        public event CollectionEventHandler ItemAdded
        {
            add { m_itemAdded += value; }
            remove { m_itemAdded -= value; }
        }

        /// <summary>
        /// Occurs when an item has been removed from the collection
        /// </summary>
        public event CollectionEventHandler ItemRemoved
        {
            add { m_itemRemoved += value; }
            remove { m_itemRemoved -= value; }
        }

        #endregion
    }
}