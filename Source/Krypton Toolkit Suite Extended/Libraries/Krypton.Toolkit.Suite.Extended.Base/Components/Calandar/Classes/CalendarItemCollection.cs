﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class CalendarItemCollection : List<CalendarItem>
    {
        #region Events

        #endregion

        #region Fields
        private KryptonCalendar _calendar;
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new collection that will belong to the specified calendar.
        /// </summary>
        /// <param name="c">Calendar this collection will belong to.</param>
        internal CalendarItemCollection(KryptonCalendar c)
        {
            _calendar = c;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the calendar this collection belongs to
        /// </summary>
        public KryptonCalendar Calendar
        {
            get { return _calendar; }
        }


        #endregion

        #region Public Methods

        /// <summary>
        /// Adds an item to the end of the list
        /// </summary>
        /// <param name="item">The object to be added to the end of the collection. The value can be null for reference types.</param>
        public new void Add(CalendarItem item)
        {
            base.Add(item); CollectionChanged();
        }

        /// <summary>
        /// Adds the items of the specified collection to the end of the list.
        /// </summary>
        /// <param name="items">The items whose elements should be added to the end of the collection. The collection itself cannont be null, but it can contain elements that are null.</param>
        public new void AddRange(IEnumerable<CalendarItem> items)
        {
            base.AddRange(items); CollectionChanged();
        }

        /// <summary>
        /// Removes all elements from the collection.
        /// </summary>
        public new void Clear()
        {
            base.Clear(); CollectionChanged();
        }

        /// <summary>
        /// Inserts an item into the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert. The value can be null for reference types.</param>
        public new void Insert(int index, CalendarItem item)
        {
            base.Insert(index, item); CollectionChanged();
        }

        /// <summary>
        /// Inserts the items of a collection into this collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="items"></param>
        public new void InsertRange(int index, IEnumerable<CalendarItem> items)
        {
            base.InsertRange(index, items); CollectionChanged();
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the collection.
        /// </summary>
        /// <param name="item">The item to remove from the collection. The value can be null for reference types.</param>
        /// <returns><c>true</c> if item is successfully removed; otherwise, <c>false</c>. This method also returns false if item was not found in the collection.</returns>
        public new bool Remove(CalendarItem item)
        {
            bool result = base.Remove(item);

            CollectionChanged();

            return result;
        }

        /// <summary>
        /// Removes the item at the specified index of the collection
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        /// <returns></returns>
        public new void RemoveAt(int index)
        {
            base.RemoveAt(index); CollectionChanged();
        }

        /// <summary>
        /// Removes the all the items that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the items to remove.</param>
        /// <returns>The number of items removed from the collection.</returns>
        public new int RemoveAll(Predicate<CalendarItem> match)
        {
            int result = base.RemoveAll(match);

            CollectionChanged();

            return result;
        }

        /// <summary>
        /// Removes a range of elements from the collection
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of items to remove.</param>
        /// <param name="count">The number of items to remove</param>
        public new void RemoveRange(int index, int count)
        {
            base.RemoveRange(index, count); CollectionChanged();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Handles what to do when this collection changes
        /// </summary>
        private void CollectionChanged()
        {
            Calendar.Renderer.PerformItemsLayout();
            Calendar.Invalidate();
        }

        #endregion
    }
}