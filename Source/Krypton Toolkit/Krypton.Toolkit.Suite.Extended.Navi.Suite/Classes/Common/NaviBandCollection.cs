#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

// ReSharper disable ConvertTypeCheckToNullCheck
namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    /// <summary>
    /// This class represents a collection of Navigation Bands
    /// </summary>
    public class NaviBandCollection : IList
    {
        // Fields
        private NaviBar _owner;
        private ArrayList _innerList;

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the NaviBandCollection class
        /// </summary>
        public NaviBandCollection(NaviBar owner)
           : base()
        {
            this._owner = owner;
            _innerList = new ArrayList();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new NaviBand the the collection
        /// </summary>
        /// <param name="value">The new NaviBand to add</param>
        /// <exception>Raised when the band argument is null</exception>
        public int Add(NaviBand value)
        {
            int result = _innerList.Add(value);
            _owner.Controls.Add(value);
            _owner.Controls.SetChildIndex(value, result);
            value.OriginalOrder = result;
            return result;
        }

        /// <summary>
        /// Removes a band from the collection of bands
        /// </summary>
        /// <param name="value">The band to remove</param>
        /// <exception>Raised when the band argument is null</exception>
        public void Remove(NaviBand value)
        {
            _innerList.Remove(value);
            _owner.Controls.Remove(value);

            if (_owner.Controls.Contains(value.Button))
            {
                _owner.Controls.Remove(value.Button);
            }
        }

        /// <summary>
        /// Infrastructure. Adds a band to the collection
        /// </summary>
        /// <param name="value">The band to add</param>
        internal void AddInternal(NaviBand value)
        {
            _innerList.Add(value);
        }

        /// <summary>
        /// Infrastructure. Removes a band from the collection
        /// </summary>
        /// <param name="value">The band to remove</param>
        internal void RemoveInternal(NaviBand value)
        {
            _innerList.Remove(value);
        }

        /// <summary>
        /// Gets or sets a NaviBand at a certain location
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The item if found</returns>
        public NaviBand this[int index]
        {
            get => (NaviBand)_innerList[index];
            set
            {
                if (!(value is NaviBand))
                {
                    throw new ArgumentException("value");
                }

                _innerList[index] = value;
            }
        }

        /// <summary>
        /// Determines whether the list contains a specific value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>Returns true if the list contains the item; false otherwise</returns>
        public bool Contains(NaviBand value) => _innerList.Contains(value);

        /// <summary>
        /// Clears the items from the list
        /// </summary>
        public void Clear()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                Remove((NaviBand)_innerList[i]);
            }
        }

        /// <summary>
        /// Sorts the elements in the entire collection using the specified comparer.
        /// </summary>
        /// <param name="comparer">The IComparer implementation to use when comparing elements.</param>
        public virtual void Sort(IComparer comparer)
        {
            _innerList.Sort(comparer);
        }

        #endregion

        #region IList Members

        int IList.Add(object value)
        {
            if (!(value is NaviBand))
            {
                throw new ArgumentException("value");
            }

            return Add((NaviBand)value);
        }

        void IList.Clear()
        {
            Clear();
        }

        bool IList.Contains(object value)
        {
            if (!(value is NaviBand))
            {
                throw new ArgumentException("value");
            }

            return ((IList)_innerList).Contains(value);
        }

        int IList.IndexOf(object value)
        {
            if (!(value is NaviBand))
            {
                throw new ArgumentException("value");
            }

            return ((IList)_innerList).IndexOf((NaviBand)value);
        }

        void IList.Insert(int index, object value)
        {
            if (!(value is NaviBand))
            {
                throw new ArgumentException("value");
            }

            ((IList)_innerList).Insert(index, value);
        }

        bool IList.IsFixedSize => false;

        bool IList.IsReadOnly => false;

        void IList.Remove(object value)
        {
            if (!(value is NaviBand))
            {
                throw new ArgumentException("value");
            }

            Remove((NaviBand)value);
        }

        void IList.RemoveAt(int index)
        {
            if ((index < 0) || (index >= _innerList.Count))
            {
                throw new IndexOutOfRangeException();
            }

            Remove((NaviBand)this[index]);
        }

        Object IList.this[int index]
        {
            get => ((IList)_innerList)[index];
            set
            {
                if (!(value is NaviBand))
                {
                    throw new ArgumentException("value");
                }

                ((IList)_innerList)[index] = value;
            }
        }

        #endregion

        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
            _innerList.CopyTo(array, index);
        }

        public int Count => _innerList.Count;

        public bool IsSynchronized => false;

        public object SyncRoot => this;

        #endregion

        #region IEnumerable Members

        public NaviBandEnumerator GetNaviEnumerator()
        {
            return new NaviBandEnumerator(this);
        }

        public IEnumerator GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }

        #endregion
    }
}