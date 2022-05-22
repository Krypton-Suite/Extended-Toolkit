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