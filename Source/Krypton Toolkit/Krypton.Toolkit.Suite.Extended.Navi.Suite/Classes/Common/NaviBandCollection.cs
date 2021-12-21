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
    /// This class represents a collection of Navigation Bands
    /// </summary>
    public class NaviBandCollection : IList
    {
        // Fields
        private NaviBar owner;
        private ArrayList innerList;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NaviBandCollection class
        /// </summary>
        public NaviBandCollection(NaviBar owner)
           : base()
        {
            this.owner = owner;
            innerList = new ArrayList();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new NaviBand the the collection
        /// </summary>
        /// <param name="value">The new NaviBand to add</param>
        /// <exception cref="ArgumentNullExceptions">Raised when the band argument is null</exception>
        public int Add(NaviBand value)
        {
            int result = innerList.Add(value);
            owner.Controls.Add(value);
            owner.Controls.SetChildIndex(value, result);
            value.OriginalOrder = result;
            return result;
        }

        /// <summary>
        /// Removes a band from the collection of bands
        /// </summary>
        /// <param name="band">The band to remove</param>
        /// <exception cref="ArgumentNullExceptions">Raised when the band argument is null</exception>
        public void Remove(NaviBand value)
        {
            innerList.Remove(value);
            owner.Controls.Remove(value);

            if (owner.Controls.Contains(value.Button))
                owner.Controls.Remove(value.Button);
        }

        /// <summary>
        /// Infrastructure. Adds a band to the collection
        /// </summary>
        /// <param name="value">The band to add</param>
        internal void AddInternal(NaviBand value)
        {
            innerList.Add(value);
        }

        /// <summary>
        /// Infrastructure. Removes a band from the collection
        /// </summary>
        /// <param name="value">The band to remove</param>
        internal void RemoveInternal(NaviBand value)
        {
            innerList.Remove(value);
        }

        /// <summary>
        /// Gets or sets a NaviBand at a certain location
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The item if found</returns>
        public NaviBand this[int index]
        {
            get { return (NaviBand)innerList[index]; }
            set
            {
                if (!(value is NaviBand))
                    throw new ArgumentException("value");
                innerList[index] = value;
            }
        }

        /// <summary>
        /// Determines whether the list contains a specific value
        /// </summary>
        /// <param name="band">The value</param>
        /// <returns>Returns true if the list contains the item; false otherwise</returns>
        public bool Contains(NaviBand value)
        {
            return innerList.Contains(value);
        }

        /// <summary>
        /// Clears the items from the list
        /// </summary>
        public void Clear()
        {
            for (int i = Count - 1; i >= 0; i--)
                Remove((NaviBand)innerList[i]);
        }

        /// <summary>
        // Sorts the elements in the entire collection using the specified comparer.
        /// </summary>
        /// <param name="comparer">The IComparer implementation to use when comparing elements.</param>
        public virtual void Sort(IComparer comparer)
        {
            innerList.Sort(comparer);
        }

        #endregion

        #region IList Members

        int IList.Add(object value)
        {
            if (!(value is NaviBand))
                throw new ArgumentException("value");

            return Add((NaviBand)value);
        }

        void IList.Clear()
        {
            Clear();
        }

        bool IList.Contains(object value)
        {
            if (!(value is NaviBand))
                throw new ArgumentException("value");
            return ((IList)innerList).Contains(value);
        }

        int IList.IndexOf(object value)
        {
            if (!(value is NaviBand))
                throw new ArgumentException("value");
            return ((IList)innerList).IndexOf((NaviBand)value);
        }

        void IList.Insert(int index, object value)
        {
            if (!(value is NaviBand))
                throw new ArgumentException("value");
            ((IList)innerList).Insert(index, value);
        }

        bool IList.IsFixedSize
        {
            get { return false; }
        }

        bool IList.IsReadOnly
        {
            get { return false; }
        }

        void IList.Remove(object value)
        {
            if (!(value is NaviBand))
                throw new ArgumentException("value");
            Remove((NaviBand)value);
        }

        void IList.RemoveAt(int index)
        {
            if ((index < 0) || (index >= innerList.Count))
                throw new IndexOutOfRangeException();
            Remove((NaviBand)this[index]);
        }

        Object IList.this[int index]
        {
            get { return ((IList)innerList)[index]; }
            set
            {
                if (!(value is NaviBand))
                    throw new ArgumentException("value");
                ((IList)innerList)[index] = value;
            }
        }

        #endregion

        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
            innerList.CopyTo(array, index);
        }

        public int Count
        {
            get { return innerList.Count; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        #endregion

        #region IEnumerable Members

        public NaviBandEnumerator GetNaviEnumerator()
        {
            return new NaviBandEnumerator(this);
        }

        public IEnumerator GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        #endregion
    }
}