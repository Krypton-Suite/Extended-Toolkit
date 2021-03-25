#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Collections;
using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Common
{
    /// <summary>
    /// A custom collection for maintaining recently used lists of any kind. For example, recently used fonts, color etc.
    /// List with limited size which is given by MaxSize. As list grows beyond MaxSize, oldest item is removed.
    /// New items are added at the top of the list (at index 0), existing items move down.
    /// If added item is already there in the list, it is moved to the top (at index 0).
    /// 
    /// https://github.com/umaranis/CustomFontDialog
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RecentlyUsedList<T> : IEnumerable<T>
    {
        #region Variables
        private int _maximumSize;

        private List<T> _list = new List<T>();
        #endregion

        #region Properties
        public T this[int i] => _list[i];

        public int MaximumSize => _maximumSize;

        public int Count => _list.Count;
        #endregion

        #region Constructor
        public RecentlyUsedList(int maximumSize)
        {
            _maximumSize = maximumSize;
        }
        #endregion

        #region Methods
        public void Add(T item)
        {
            int i = _list.IndexOf(item);

            if (i != -1) _list.RemoveAt(i);

            if (_list.Count == MaximumSize) _list.RemoveAt(_list.Count - 1);

            _list.Insert(0, item);
        }


        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Reverses the list. First item becomes last, for instance.
        /// </summary>
        public void Reverse()
        {
            T temp;

            for (int i = 0; i < _list.Count / 2; i++)
            {
                temp = _list[i];

                _list[i] = _list[_list.Count - i - 1];

                _list[_list.Count - i - 1] = temp;
            }
        }
        #endregion
    }
}