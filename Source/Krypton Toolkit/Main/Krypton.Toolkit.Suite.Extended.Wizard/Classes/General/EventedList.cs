#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace System.Collections.Generic
{
    /// <summary>
    /// A generic list that provides event for changes to the list.
    /// </summary>
    /// <typeparam name="T">Type for the list.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [Serializable]
    public class EventedList<T> : IList<T>, IList
    {
        // Fields
        private const int _defaultCapacity = 4;

        private static T[] _emptyArray = new T[0];

        private T[] _items;
        private int _size;
        [NonSerialized]
        private object _syncRoot;
        private int _version;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventedList{T}"/> class that is empty and has the default initial capacity.
        /// </summary>
        public EventedList()
        {
            _items = EventedList<T>._emptyArray;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventedList{T}" /> class that contains elements copied from the specified collection and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> is <c>null</c>.</exception>
        [Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EventedList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            ICollection<T> is2 = collection as ICollection<T>;
            if (is2 != null)
            {
                int count = is2.Count;
                _items = new T[count];
                is2.CopyTo(_items, 0);
                _size = count;
            }
            else
            {
                _size = 0;
                _items = new T[4];
                using (IEnumerator<T> enumerator = collection.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        Add(enumerator.Current);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventedList{T}" /> class that is empty and has the default initial capacity.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0.</exception>
        public EventedList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            _items = new T[capacity];
        }

        /// <summary>
        /// Occurs when an item has been added.
        /// </summary>
        public event EventHandler<ListChangedEventArgs<T>> ItemAdded;

        /// <summary>
        /// Occurs when an item has changed.
        /// </summary>
        public event EventHandler<ListChangedEventArgs<T>> ItemChanged;

        /// <summary>
        /// Occurs when an item has been deleted.
        /// </summary>
        public event EventHandler<ListChangedEventArgs<T>> ItemDeleted;

        /// <summary>
        /// Occurs when the list has been reset.
        /// </summary>
        public event EventHandler<ListChangedEventArgs<T>> Reset;

        /// <summary>
        /// Gets or sets the total number of elements the internal data structure can hold without resizing.
        /// </summary>
        /// <value>
        /// The number of elements that the <see cref="EventedList{T}" /> can contain before resizing is required.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>Capacity</c> is set to a value that is less than <see cref="Count"/>.</exception>
        public int Capacity
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value != _items.Length)
                {
                    if (value < _size)
                    {
                        throw new ArgumentOutOfRangeException("value");
                    }
                    if (value > 0)
                    {
                        T[] destinationArray = new T[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, 0, destinationArray, 0, _size);
                        }
                        _items = destinationArray;
                    }
                    else
                    {
                        _items = EventedList<T>._emptyArray;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="EventedList{T}" />.
        /// </summary>
        /// <value>
        /// The number of elements contained in the <see cref="EventedList{T}" />.
        /// </value>
        public int Count => _size;

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection" /> is synchronized (thread safe).
        /// </summary>
        bool ICollection.IsSynchronized => false;

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection" />.
        /// </summary>
        object ICollection.SyncRoot
        {
            get
            {
                if (_syncRoot == null)
                {
                    System.Threading.Interlocked.CompareExchange(ref _syncRoot, new object(), null);
                }
                return _syncRoot;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        bool ICollection<T>.IsReadOnly => false;

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.IList" /> has a fixed size.
        /// </summary>
        bool IList.IsFixedSize => false;

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        bool IList.IsReadOnly => false;

        /// <summary>
        /// Gets or sets the <see cref="System.Object" /> at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The element at the specified index.</returns>
        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                EventedList<T>.VerifyValueType(value);
                this[index] = (T)value;
            }
        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <value>The element at the specified index.</value>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"><paramref name="index"/> is less than 0.</exception>
        public T this[int index]
        {
            get
            {
                if (index >= _size)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return _items[index];
            }
            set
            {
                if (index >= _size)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                T oldValue = _items[index];
                _items[index] = value;
                _version++;
                OnItemChanged(index, oldValue, value);
            }
        }

        /// <summary>
        /// Adds an item to the <see cref="EventedList{T}" />.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="EventedList{T}" />.</param>
        /// <exception cref="T:System.NotSupportedException">The <see cref="EventedList{T}" /> is read-only.</exception>
        public void Add(T item)
        {
            if (_size == _items.Length)
            {
                EnsureCapacity(_size + 1);
            }
            _items[_size++] = item;
            _version++;
            OnItemAdded(_size, item);
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public void AddRange(IEnumerable<T> collection)
        {
            InsertRange(_size, collection);
        }

        /// <summary>
        /// Returns a read-only <see cref="EventedList{T}" /> wrapper for the current collection.
        /// </summary>
        /// <returns>A <see cref="ReadOnlyCollection{T}" /> that acts as a read-only wrapper around the current <see cref="EventedList{T}" />.</returns>
        public ReadOnlyCollection<T> AsReadOnly() => new ReadOnlyCollection<T>(this);

        /// <summary>
        /// Searches the entire sorted <see cref="EventedList{T}" /> for an element using the default comparer and returns the zero-based index of the element.
        /// </summary>
        /// <param name="item">The object to locate. The value can be <c>null</c> for reference types.</param>
        /// <returns>The zero-based index of <paramref name="item"/> in the sorted <see cref="EventedList{T}" />, if <paramref name="item"/> is found; otherwise, a negative number that is the bitwise complement of the index of the next element that is larger than item or, if there is no larger element, the bitwise complement of <see cref="Count"/>.</returns>
        public int BinarySearch(T item) => BinarySearch(0, Count, item, null);

        /// <summary>
        /// Searches the entire sorted <see cref="EventedList{T}" /> for an element using the specified comparer and returns the zero-based index of the element.
        /// </summary>
        /// <param name="item">The object to locate. The value can be <c>null</c> for reference types.</param>
        /// <param name="comparer">The <see cref="IComparer{T}" /> implementation to use when comparing elements, or <c>null</c> to use the default comparer <see cref="Comparer{T}.Default" />.</param>
        /// <returns>The zero-based index of <paramref name="item"/> in the sorted <see cref="EventedList{T}" />, if <paramref name="item"/> is found; otherwise, a negative number that is the bitwise complement of the index of the next element that is larger than item or, if there is no larger element, the bitwise complement of <see cref="Count"/>.</returns>
        public int BinarySearch(T item, IComparer<T> comparer) => BinarySearch(0, Count, item, comparer);

        /// <summary>
        /// Searches a range of elements in the sorted <see cref="EventedList{T}" /> for an element using the specified comparer and returns the zero-based index of the element.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range to search.</param>
        /// <param name="count">The length of the range to search.</param>
        /// <param name="item">The object to locate. The value can be <c>null</c> for reference types.</param>
        /// <param name="comparer">The <see cref="IComparer{T}" /> implementation to use when comparing elements, or <c>null</c> to use the default comparer <see cref="Comparer{T}.Default" />.</param>
        /// <returns>The zero-based index of <paramref name="item"/> in the sorted <see cref="EventedList{T}" />, if <paramref name="item"/> is found; otherwise, a negative number that is the bitwise complement of the index of the next element that is larger than item or, if there is no larger element, the bitwise complement of <see cref="Count"/>.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><paramref name="index"/> is less than 0. -or- <paramref name="count"/> is less than 0.</exception>
        /// <exception cref="System.ArgumentException"><paramref name="index"/> and <paramref name="count"/> do not denote a valid range in the <see cref="EventedList{T}" />.</exception>
        public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
        {
            if ((index < 0) || (count < 0))
            {
                throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count");
            }
            if ((_size - index) < count)
            {
                throw new ArgumentException($"{nameof(index)} and {nameof(count)} do not denote a valid range in the {nameof(EventedList<T>)}.");
            }
            return Array.BinarySearch<T>(_items, index, count, item, comparer);
        }

        /// <summary>
        /// Removes all items from the <see cref="EventedList{T}" />.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">The <see cref="EventedList{T}" /> is read-only. </exception>
        public void Clear()
        {
            Array.Clear(_items, 0, _size);
            _size = 0;
            _version++;
            OnReset();
        }

        /// <summary>
        /// Determines whether the <see cref="EventedList{T}" /> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="EventedList{T}" />.</param>
        /// <returns>
        /// true if <paramref name="item"/> is found in the <see cref="EventedList{T}" />; otherwise, false.
        /// </returns>
        public bool Contains(T item)
        {
            if (item == null)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_items[j] == null)
                    {
                        return true;
                    }
                }
                return false;
            }
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < _size; i++)
            {
                if (comparer.Equals(_items[i], item))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Converts the elements in the current <see cref="EventedList{T}" /> to another type, and returns a list containing the converted elements.
        /// </summary>
        /// <typeparam name="TOutput">The type of the elements of the target array.</typeparam>
        /// <param name="converter">A <see cref="Converter{T, TOutput}" /> delegate that converts each element from one type to another type.</param>
        /// <returns>A <see cref="EventedList{T}" /> of the target type containing the converted elements from the current <see cref="EventedList{T}" />.</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="converter"/> is <c>null</c>.</exception>
        public EventedList<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
        {
            if (converter == null)
            {
                throw new ArgumentNullException(nameof(converter));
            }
            EventedList<TOutput> list = new EventedList<TOutput>(_size);
            for (int i = 0; i < _size; i++)
            {
                list._items[i] = converter(_items[i]);
            }
            list._size = _size;
            return list;
        }

        /// <summary>
        /// Copies the entire <see cref="EventedList{T}" /> to a compatible one-dimensional array, starting at the beginning of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="EventedList{T}" />. The <see cref="T:System.Array"/> must have zero-based indexing.</param>
        public void CopyTo(T[] array)
        {
            CopyTo(array, 0);
        }

        /// <summary>
        /// Copies the elements of the <see cref="EventedList{T}" /> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="EventedList{T}" />. The <see cref="T:System.Array"/> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="array" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="arrayIndex" /> is less than 0.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="array" /> is multidimensional. -or- <paramref name="arrayIndex" /> is equal to or greater than the length of <paramref name="array" />.-or-The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1" /> is greater than the available space from <paramref name="arrayIndex" /> to the end of the destination <paramref name="array" />.-or-Type <c>T</c> cannot be cast automatically to the type of the destination <paramref name="array" />.</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_items, 0, array, arrayIndex, _size);
        }

        /// <summary>
        /// Copies a range of elements from the <see cref="EventedList{T}" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
        /// </summary>
        /// <param name="index">The zero-based index in the source <see cref="EventedList{T}" /> at which copying begins.</param>
        /// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="EventedList{T}" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
        /// <param name="count">The number of elements to copy.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="array" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="arrayIndex" /> is less than 0.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="array" /> is multidimensional. -or- <paramref name="arrayIndex" /> is equal to or greater than the length of <paramref name="array" />.-or-The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1" /> is greater than the available space from <paramref name="arrayIndex" /> to the end of the destination <paramref name="array" />.-or-Type <c>T</c> cannot be cast automatically to the type of the destination <paramref name="array" />.</exception>
        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            if ((_size - index) < count)
            {
                throw new ArgumentException($"{nameof(array)} is multidimensional. -or- {nameof(arrayIndex)} is equal to or greater than the length of {nameof(array)}. -or- The number of elements in the source list is greater than the available space from {nameof(arrayIndex)} to the end of the destination {nameof(array)}. -or- Type {nameof(T)} cannot be cast automatically to the type of the destination {nameof(array)}.");
            }
            Array.Copy(_items, index, array, arrayIndex, count);
        }

        /// <summary>
        /// Determines whether the <see cref="EventedList{T}" /> contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The <see cref="Predicate{T}" /> delegate that defines the conditions of the elements to search for.</param>
        /// <returns><c>true</c> if the <see cref="EventedList{T}" /> contains one or more elements that match the conditions defined by the specified predicate; otherwise, <c>false</c>.</returns>
        public bool Exists(Predicate<T> match) => (FindIndex(match) != -1);

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurrence within the entire <see cref="EventedList{T}" />.
        /// </summary>
        /// <param name="match">The <see cref="Predicate{T}" /> delegate that defines the conditions of the elements to search for.</param>
        /// <returns>The first element that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type <typeparamref name="T"/>.</returns>
        public T Find(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }
            for (int i = 0; i < _size; i++)
            {
                if (match(_items[i]))
                {
                    return _items[i];
                }
            }
            return default(T);
        }

        /// <summary>
        /// Retrieves all the elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The <see cref="Predicate{T}" /> delegate that defines the conditions of the elements to search for.</param>
        /// <returns>A <see cref="EventedList{T}" /> containing all the elements that match the conditions defined by the specified predicate, if found; otherwise, an empty <see cref="EventedList{T}" />.</returns>
        public EventedList<T> FindAll(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }
            EventedList<T> list = new EventedList<T>();
            for (int i = 0; i < _size; i++)
            {
                if (match(_items[i]))
                {
                    list.Add(_items[i]);
                }
            }
            return list;
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the entire <see cref="EventedList{T}" />.
        /// </summary>
        /// <param name="match">The <see cref="Predicate{T}" /> delegate that defines the conditions of the elements to search for.</param>
        /// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by <paramref name="match"/>, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="match"/> is <c>null</c>.</exception>
        public int FindIndex(Predicate<T> match) => FindIndex(0, _size, match);

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the range of elements in the <see cref="EventedList{T}" /> that extends from the specified index to the last element.
        /// </summary>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="match">The <see cref="Predicate{T}" /> delegate that defines the conditions of the elements to search for.</param>
        /// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by <paramref name="match" />, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="startIndex" /> is outside the range of valid indexes for the <see cref="EventedList{T}" />.
        /// </exception>
        /// <exception cref="System.ArgumentNullException"><paramref name="match"/> is <c>null</c>.</exception>
        public int FindIndex(int startIndex, Predicate<T> match) => FindIndex(startIndex, _size - startIndex, match);

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the range of elements in the <see cref="EventedList{T}" /> that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <param name="match">The <see cref="Predicate{T}" /> delegate that defines the conditions of the elements to search for.</param>
        /// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by <paramref name="match" />, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="startIndex" /> is outside the range of valid indexes for the <see cref="EventedList{T}" />.
        /// -or-
        /// <paramref name="count" /> is less than 0.
        /// -or-
        /// <paramref name="startIndex" /> and <paramref name="count" /> do not specify a valid section in the <see cref="EventedList{T}" />.
        /// </exception>
        /// <exception cref="System.ArgumentNullException"><paramref name="match"/> is <c>null</c>.</exception>
        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            if (startIndex > _size)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }
            if ((count < 0) || (startIndex > (_size - count)))
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }
            int num = startIndex + count;
            for (int i = startIndex; i < num; i++)
            {
                if (match(_items[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the last occurrence within the entire <see cref="EventedList{T}" />.
        /// </summary>
        /// <param name="match">The <see cref="Predicate{T}" /> delegate that defines the conditions of the elements to search for.</param>
        /// <returns>The last element that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type <typeparamref name="T"/>.</returns>
        public T FindLast(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }
            for (int i = _size - 1; i >= 0; i--)
            {
                if (match(_items[i]))
                {
                    return _items[i];
                }
            }
            return default(T);
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the entire <see cref="EventedList{T}" />.
        /// </summary>
        /// <param name="match">The <see cref="Predicate{T}" /> delegate that defines the conditions of the elements to search for.</param>
        /// <returns>The zero-based index of the last occurrence of an element that matches the conditions defined by <paramref name="match"/>, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="match"/> is <c>null</c>.</exception>
        public int FindLastIndex(Predicate<T> match) => FindLastIndex(_size - 1, _size, match);

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the range of elements in the <see cref="EventedList{T}" /> that extends from the specified index to the last element.
        /// </summary>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="match">The <see cref="Predicate{T}" /> delegate that defines the conditions of the elements to search for.</param>
        /// <returns>The zero-based index of the last occurrence of an element that matches the conditions defined by <paramref name="match" />, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="startIndex" /> is outside the range of valid indexes for the <see cref="EventedList{T}" />.
        /// </exception>
        /// <exception cref="System.ArgumentNullException"><paramref name="match"/> is <c>null</c>.</exception>
        public int FindLastIndex(int startIndex, Predicate<T> match) => FindLastIndex(startIndex, startIndex + 1, match);

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the range of elements in the <see cref="EventedList{T}" /> that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <param name="match">The <see cref="Predicate{T}" /> delegate that defines the conditions of the elements to search for.</param>
        /// <returns>The zero-based index of the last occurrence of an element that matches the conditions defined by <paramref name="match" />, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="startIndex" /> is outside the range of valid indexes for the <see cref="EventedList{T}" />.
        /// -or-
        /// <paramref name="count" /> is less than 0.
        /// -or-
        /// <paramref name="startIndex" /> and <paramref name="count" /> do not specify a valid section in the <see cref="EventedList{T}" />.
        /// </exception>
        /// <exception cref="System.ArgumentNullException"><paramref name="match"/> is <c>null</c>.</exception>
        public int FindLastIndex(int startIndex, int count, Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }
            if (_size == 0)
            {
                if (startIndex != -1)
                {
                    throw new ArgumentOutOfRangeException(nameof(startIndex));
                }
            }
            else if (startIndex >= _size)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }
            if ((count < 0) || (((startIndex - count) + 1) < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            int num = startIndex - count;
            for (int i = startIndex; i > num; i--)
            {
                if (match(_items[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Performs the specified action on each element of the <see cref="EventedList{T}"/>.
        /// </summary>
        /// <param name="action">The <see cref="Action{T}"/> delegate to perform on each element of the <see cref="EventedList{T}"/>.</param>
        public void ForEach(Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            for (int i = 0; i < _size; i++)
            {
                action(_items[i]);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="EventedList{T}"/>.
        /// </summary>
        /// <returns>A <see cref="EventedList{T}.Enumerator"/> for the <see cref="EventedList{T}"/>.</returns>
        public EventedList<T>.Enumerator GetEnumerator() => new EventedList<T>.Enumerator((EventedList<T>)this);

        /// <summary>
        /// Creates a shallow copy of a range of elements in the source <see cref="EventedList{T}" />.
        /// </summary>
        /// <param name="index">The zero-based <see cref="EventedList{T}" /> index at which the range starts.</param>
        /// <param name="count">The number of elements in the range.</param>
        /// <returns>A shallow copy of a range of elements in the source <see cref="EventedList{T}" />.</returns>
        public EventedList<T> GetRange(int index, int count)
        {
            if ((index < 0) || (count < 0))
            {
                throw new ArgumentOutOfRangeException((index < 0) ? nameof(index) : nameof(count));
            }
            if ((_size - index) < count)
            {
                throw new ArgumentException($"{nameof(index)} and {nameof(count)} do not denote a valid range of elements in the {nameof(EventedList<T>)}.");
            }
            EventedList<T> list = new EventedList<T>(count);
            Array.Copy(_items, index, list._items, 0, count);
            list._size = count;
            return list;
        }

        /// <summary>
        /// Copies the elements of the ICollection to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">Index of the array.</param>
        /// <exception cref="System.ArgumentException">Destination array cannot be null or multidimensional.</exception>
        void ICollection.CopyTo(Array array, int arrayIndex)
        {
            if (array?.Rank != 1)
                throw new ArgumentException("Destination array cannot be null or multidimensional.", nameof(array));
            try
            {
                Array.Copy(_items, 0, array, arrayIndex, _size);
            }
            catch (ArrayTypeMismatchException e)
            {
                throw new ArgumentException("Type mismatch", e);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator() => new EventedList<T>.Enumerator((EventedList<T>)this);

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new EventedList<T>.Enumerator((EventedList<T>)this);

        /// <summary>
        /// Adds an item to the IList.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        int IList.Add(object item)
        {
            EventedList<T>.VerifyValueType(item);
            Add((T)item);
            return (Count - 1);
        }

        /// <summary>
        /// Determines whether the IList contains a specific value.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// 	<c>true</c> if contains the specified item; otherwise, <c>false</c>.
        /// </returns>
        bool IList.Contains(object item) => (EventedList<T>.IsCompatibleObject(item) && Contains((T)item));

        /// <summary>
        /// Determines the index of a specific item in the IList.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        int IList.IndexOf(object item)
        {
            if (EventedList<T>.IsCompatibleObject(item))
            {
                return IndexOf((T)item);
            }
            return -1;
        }

        /// <summary>
        /// Inserts an item to the IList at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        void IList.Insert(int index, object item)
        {
            EventedList<T>.VerifyValueType(item);
            Insert(index, (T)item);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the IList.
        /// </summary>
        /// <param name="item">The item.</param>
        void IList.Remove(object item)
        {
            if (EventedList<T>.IsCompatibleObject(item))
            {
                Remove((T)item);
            }
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="EventedList{T}"/>.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="EventedList{T}" />. The value can be <c>null</c> for reference types.</param>
        /// <returns>
        /// The index of <paramref name="item"/> if found in the list; otherwise, -1.
        /// </returns>
        public int IndexOf(T item) => Array.IndexOf<T>(_items, item, 0, _size);

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the range of elements in the <see cref="EventedList{T}" /> that starts at the specified index.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="EventedList{T}" />. The value can be <c>null</c> for reference types.</param>
        /// <param name="index">The zero-based starting index of the search. 0 (zero) is valid in an empty list.</param>
        /// <returns>The zero-based <paramref name="index" /> of the first occurrence of <paramref name="item" /> within the range of elements in the <see cref="EventedList{T}" /> that starts at <paramref name="index" />, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="index" /> is outside the range of valid indexes for the <see cref="EventedList{T}" />.
        /// </exception>
        public int IndexOf(T item, int index)
        {
            if (index > _size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return Array.IndexOf<T>(_items, item, index, _size - index);
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the range of elements in the <see cref="EventedList{T}" /> that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="EventedList{T}" />. The value can be <c>null</c> for reference types.</param>
        /// <param name="index">The zero-based starting index of the search. 0 (zero) is valid in an empty list.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The zero-based <paramref name="index" /> of the first occurrence of <paramref name="item" /> within the range of elements in the <see cref="EventedList{T}" /> that starts at <paramref name="index" /> and contains <paramref name="count" /> number of elements, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="index" /> is outside the range of valid indexes for the <see cref="EventedList{T}" />.
        /// -or-
        /// <paramref name="count" /> is less than 0.
        /// -or-
        /// <paramref name="index" /> and <paramref name="count" /> do not specify a valid section in the <see cref="EventedList{T}" />.
        /// </exception>
        public int IndexOf(T item, int index, int count)
        {
            if (index > _size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            if ((count < 0) || (index > (_size - count)))
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            return Array.IndexOf<T>(_items, item, index, count);
        }

        /// <summary>
        /// Inserts an item to the <see cref="EventedList{T}" /> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
        /// <param name="item">The object to insert into the <see cref="EventedList{T}" />.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="EventedList{T}" />.</exception>
        /// <exception cref="T:System.NotSupportedException">The <see cref="EventedList{T}" /> is read-only.</exception>
        public void Insert(int index, T item)
        {
            if (index > _size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            if (_size == _items.Length)
            {
                EnsureCapacity(_size + 1);
            }
            if (index < _size)
            {
                Array.Copy(_items, index, _items, index + 1, _size - index);
            }
            _items[index] = item;
            _size++;
            _version++;
            OnItemAdded(index, item);
        }

        /// <summary>
        /// Inserts the elements of a collection into the <see cref="EventedList{T}" /> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the <see cref="EventedList{T}" />. The collection itself cannot be <c>null</c>, but it can contain elements that are <c>null</c>, if type <typeparamref name="T"/> is a reference type.</param>
        public void InsertRange(int index, IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            if (index > _size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            ICollection<T> is2 = collection as ICollection<T>;
            if (is2 != null)
            {
                int count = is2.Count;
                if (count > 0)
                {
                    EnsureCapacity(_size + count);
                    if (index < _size)
                    {
                        Array.Copy(_items, index, _items, index + count, _size - index);
                    }
                    if (this == is2)
                    {
                        Array.Copy(_items, 0, _items, index, index);
                        Array.Copy(_items, (int)(index + count), _items, (int)(index * 2), (int)(_size - index));
                    }
                    else
                    {
                        T[] array = new T[count];
                        is2.CopyTo(array, 0);
                        array.CopyTo(_items, index);
                    }
                    _size += count;
                    for (int i = index; i < index + count; i++)
                        OnItemAdded(i, _items[i]);
                }
            }
            else
            {
                using (IEnumerator<T> enumerator = collection.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        Insert(index++, enumerator.Current);
                    }
                }
            }
            _version++;
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the last occurrence within the entire <see cref="EventedList{T}"/>.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="EventedList{T}" />. The value can be <c>null</c> for reference types.</param>
        /// <returns>
        /// The index of <paramref name="item"/> if found in the list; otherwise, -1.
        /// </returns>
        public int LastIndexOf(T item) => LastIndexOf(item, _size - 1, _size);

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the last occurrence within the range of elements in the <see cref="EventedList{T}" /> that starts at the specified index.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="EventedList{T}" />. The value can be <c>null</c> for reference types.</param>
        /// <param name="index">The zero-based starting index of the search. 0 (zero) is valid in an empty list.</param>
        /// <returns>The zero-based <paramref name="index" /> of the last occurrence of <paramref name="item" /> within the range of elements in the <see cref="EventedList{T}" /> that starts at <paramref name="index" />, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="index" /> is outside the range of valid indexes for the <see cref="EventedList{T}" />.
        /// </exception>
        public int LastIndexOf(T item, int index)
        {
            if (index >= _size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return LastIndexOf(item, index, index + 1);
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the last occurrence within the range of elements in the <see cref="EventedList{T}" /> that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="EventedList{T}" />. The value can be <c>null</c> for reference types.</param>
        /// <param name="index">The zero-based starting index of the search. 0 (zero) is valid in an empty list.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The zero-based <paramref name="index" /> of the last occurrence of <paramref name="item" /> within the range of elements in the <see cref="EventedList{T}" /> that starts at <paramref name="index" /> and contains <paramref name="count" /> number of elements, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// <paramref name="index" /> is outside the range of valid indexes for the <see cref="EventedList{T}" />.
        /// -or-
        /// <paramref name="count" /> is less than 0.
        /// -or-
        /// <paramref name="index" /> and <paramref name="count" /> do not specify a valid section in the <see cref="EventedList{T}" />.
        /// </exception>
        public int LastIndexOf(T item, int index, int count)
        {
            if (_size == 0)
            {
                return -1;
            }
            if ((index < 0) || (count < 0))
            {
                throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count");
            }
            if ((index >= _size) || (count > (index + 1)))
            {
                throw new ArgumentOutOfRangeException((index >= _size) ? "index" : "count");
            }
            return Array.LastIndexOf<T>(_items, item, index, count);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="EventedList{T}" />.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="EventedList{T}" />.</param>
        /// <returns>
        /// true if <paramref name="item"/> was successfully removed from the <see cref="EventedList{T}" />; otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The <see cref="EventedList{T}" /> is read-only.</exception>
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes all the elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The <see cref="Predicate{T}" /> delegate that defines the conditions of the elements to remove.</param>
        /// <returns>The number of elements removed from the <see cref="EventedList{T}" />.</returns>
        public int RemoveAll(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }
            int index = 0;
            while ((index < _size) && !match(_items[index]))
            {
                index++;
            }
            if (index >= _size)
            {
                return 0;
            }
            int num2 = index + 1;
            while (num2 < _size)
            {
                while ((num2 < _size) && match(_items[num2]))
                {
                    num2++;
                }
                if (num2 < _size)
                {
                    T oldVal = _items[index + 1];
                    _items[index++] = _items[num2++];
                    OnItemDeleted(index, oldVal);
                }
            }
            Array.Clear(_items, index, _size - index);
            int num3 = _size - index;
            _size = index;
            _version++;
            return num3;
        }

        /// <summary>
        /// Removes the <see cref="EventedList{T}" /> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="EventedList{T}" />.</exception>
        /// <exception cref="T:System.NotSupportedException">The <see cref="EventedList{T}" /> is read-only.</exception>
        public void RemoveAt(int index)
        {
            if (index >= _size)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            _size--;
            T oldVal = _items[index];
            if (index < _size)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }
            _items[_size] = default(T);
            _version++;
            OnItemDeleted(index, oldVal);
        }

        /// <summary>
        /// Removes a range of elements from the <see cref="EventedList{T}" />.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public void RemoveRange(int index, int count)
        {
            if ((index < 0) || (count < 0))
            {
                throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count");
            }
            if ((_size - index) < count)
            {
                throw new ArgumentException($"{nameof(index)} and {nameof(count)} do not denote a valid range of elements in the {nameof(EventedList<T>)}.");
            }
            if (count > 0)
            {
                _size -= count;
                T[] array = new T[count];
                Array.Copy(_items, index, array, 0, count);
                if (index < _size)
                {
                    Array.Copy(_items, index + count, _items, index, _size - index);
                }
                Array.Clear(_items, _size, count);
                _version++;
                for (int i = index; i < index + count; i++)
                    OnItemDeleted(i, array[i - index]);
            }
        }

        /// <summary>
        /// Reverses the order of the elements in the entire <see cref="EventedList{T}" />.
        /// </summary>
        public void Reverse()
        {
            Reverse(0, Count);
        }

        /// <summary>
        /// Reverses the order of the elements in the specified range.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to reverse.</param>
        /// <param name="count">The number of elements to reverse.</param>
        public void Reverse(int index, int count)
        {
            if ((index < 0) || (count < 0))
            {
                throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count");
            }
            if ((_size - index) < count)
            {
                throw new ArgumentException($"{nameof(index)} and {nameof(count)} do not denote a valid range of elements in the {nameof(EventedList<T>)}.");
            }
            Array.Reverse(_items, index, count);
            _version++;
        }

        /// <summary>
        /// Sorts the elements in the entire <see cref="EventedList{T}" /> using the default comparer.
        /// </summary>
        public void Sort()
        {
            Sort(0, Count, null);
        }

        /// <summary>
        /// Sorts the elements in the entire <see cref="EventedList{T}" /> using the specified comparer.
        /// </summary>
        /// <param name="comparer">The <see cref="IComparer{T}" /> implementation to use when comparing elements, or <c>null</c> to use the default comparer <see cref="Comparer{T}.Default" />.</param>
        public void Sort(IComparer<T> comparer)
        {
            Sort(0, Count, comparer);
        }

        /// <summary>
        /// Sorts the elements in a range of elements in <see cref="EventedList{T}" /> using the specified comparer.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to sort.</param>
        /// <param name="count">The number of elements to sort.</param>
        /// <param name="comparer">The <see cref="IComparer{T}" /> implementation to use when comparing elements, or <c>null</c> to use the default comparer <see cref="Comparer{T}.Default" />.</param>
        public void Sort(int index, int count, IComparer<T> comparer)
        {
            if ((index < 0) || (count < 0))
            {
                throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count");
            }
            if ((_size - index) < count)
            {
                throw new ArgumentException($"{nameof(index)} and {nameof(count)} do not denote a valid range of elements in the {nameof(EventedList<T>)}.");
            }
            Array.Sort<T>(_items, index, count, comparer);
            _version++;
        }

        /// <summary>
        /// Copies the elements of the <see cref="EventedList{T}" /> to a new array.
        /// </summary>
        /// <returns>An array containing copies of the elements of the <see cref="EventedList{T}" />.</returns>
        public T[] ToArray()
        {
            T[] destinationArray = new T[_size];
            Array.Copy(_items, 0, destinationArray, 0, _size);
            return destinationArray;
        }

        /// <summary>
        /// Sets the capacity to the actual number of elements in the <see cref="EventedList{T}" />, if that number is less than a threshold value.
        /// </summary>
        public void TrimExcess()
        {
            int num = (int)(_items.Length * 0.9);
            if (_size < num)
            {
                Capacity = _size;
            }
        }

        /// <summary>
        /// Determines whether every element in the <see cref="EventedList{T}" /> matches the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The <see cref="Predicate{T}" /> delegate that defines the conditions to check against the elements.</param>
        /// <returns><c>true</c> if every element in the <see cref="EventedList{T}" /> matches the conditions defined by the specified predicate; otherwise, <c>false</c>. If the list has no elements, the return value is <c>true</c>.</returns>
        public bool TrueForAll(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }
            for (int i = 0; i < _size; i++)
            {
                if (!match(_items[i]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Raises the <see cref="ItemAdded"/> event.
        /// </summary>
        /// <param name="index">The index of the added item.</param>
        /// <param name="value">The value of the added item.</param>
        protected virtual void OnItemAdded(int index, T value)
        {
            EventHandler<ListChangedEventArgs<T>> h = ItemAdded;
            if (h != null)
                h(this, new EventedList<T>.ListChangedEventArgs<T>(ListChangedType.ItemAdded, value, index));
        }

        /// <summary>
        /// Raises the <see cref="ItemChanged"/> event.
        /// </summary>
        /// <param name="index">The index of the changed item.</param>
        /// <param name="oldValue">The previous value of the changed item.</param>
        /// <param name="newValue">The new value of the changed item.</param>
        protected virtual void OnItemChanged(int index, T oldValue, T newValue)
        {
            EventHandler<ListChangedEventArgs<T>> h = ItemChanged;
            if (h != null)
                h(this, new EventedList<T>.ListChangedEventArgs<T>(ListChangedType.ItemChanged, newValue, index, oldValue));
        }

        /// <summary>
        /// Raises the <see cref="ItemDeleted"/> event.
        /// </summary>
        /// <param name="index">The index of the deleted item.</param>
        /// <param name="value">The value of the deleted item.</param>
        protected virtual void OnItemDeleted(int index, T value)
        {
            EventHandler<ListChangedEventArgs<T>> h = ItemDeleted;
            if (h != null)
                h(this, new EventedList<T>.ListChangedEventArgs<T>(ListChangedType.ItemDeleted, value, index));
        }

        /// <summary>
        /// Raises the <see cref="Reset"/> event.
        /// </summary>
        protected virtual void OnReset()
        {
            EventHandler<ListChangedEventArgs<T>> h = Reset;
            if (h != null)
                h(this, new EventedList<T>.ListChangedEventArgs<T>(ListChangedType.Reset));
        }

        /// <summary>
        /// Determines whether the specified object is compatible with this list's item type.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified object is compatible with this list's item type; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsCompatibleObject(object value)
        {
            if (!(value is T) && ((value != null) || typeof(T).IsValueType))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Verifies the type of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        private static void VerifyValueType(object value)
        {
            if (!EventedList<T>.IsCompatibleObject(value))
            {
                throw new ArgumentException("Incompatible type.", nameof(value));
            }
        }

        /// <summary>
        /// Ensures the capacity.
        /// </summary>
        /// <param name="min">The min.</param>
        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int num = (_items.Length == 0) ? 4 : (_items.Length * 2);
                if (num < min)
                {
                    num = min;
                }
                Capacity = num;
            }
        }

        /// <summary>
        /// Enumerates over the <see cref="EventedList{T}"/>.
        /// </summary>
        [Serializable,
        System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private EventedList<T> list;
            private int index;
            private int version;
            private T current;

            /// <summary>
            /// Initializes a new instance of the <see cref="EventedList{T}.Enumerator"/> struct.
            /// </summary>
            /// <param name="list">The list.</param>
            internal Enumerator(EventedList<T> list)
            {
                this.list = list;
                index = 0;
                version = list._version;
                current = default(T);
            }

            /// <summary>
            /// Gets the element at the current position of the enumerator.
            /// </summary>
            /// <value>The current element.</value>
            public T Current => current;

            /// <summary>
            /// Gets the element at the current position of the enumerator.
            /// </summary>
            /// <value>The current element.</value>
            object IEnumerator.Current
            {
                get
                {
                    if ((index == 0) || (index == (list._size + 1)))
                    {
                        throw new InvalidOperationException();
                    }
                    return Current;
                }
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
            void IEnumerator.Reset()
            {
                if (version != list._version)
                {
                    throw new InvalidOperationException();
                }
                index = 0;
                current = default(T);
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>
            /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
            /// </returns>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
            public bool MoveNext()
            {
                if (version != list._version)
                {
                    throw new InvalidOperationException();
                }
                if (index < list._size)
                {
                    current = list._items[index];
                    index++;
                    return true;
                }
                index = list._size + 1;
                current = default(T);
                return false;
            }
        }

        /// <summary>
        /// An <see cref="EventArgs"/> structure passed to events generated by an <see cref="EventedList{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
#pragma warning disable 693
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class ListChangedEventArgs<T> : EventArgs
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="EventedList{T}.ListChangedEventArgs&lt;T&gt;"/> class.
            /// </summary>
            /// <param name="type">The type of change.</param>
            public ListChangedEventArgs(ListChangedType type)
            {
                ItemIndex = -1;
                ListChangedType = type;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="EventedList{T}.ListChangedEventArgs&lt;T&gt;"/> class.
            /// </summary>
            /// <param name="type">The type of change.</param>
            /// <param name="item">The item that has changed.</param>
            /// <param name="itemIndex">Index of the changed item.</param>
            public ListChangedEventArgs(ListChangedType type, T item, int itemIndex)
            {
                Item = item;
                ItemIndex = itemIndex;
                ListChangedType = type;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="EventedList{T}.ListChangedEventArgs&lt;T&gt;"/> class.
            /// </summary>
            /// <param name="type">The type of change.</param>
            /// <param name="item">The item that has changed.</param>
            /// <param name="itemIndex">Index of the changed item.</param>
            /// <param name="oldItem">The old item when an item has changed.</param>
            public ListChangedEventArgs(ListChangedType type, T item, int itemIndex, T oldItem) : this(type, item, itemIndex) => OldItem = oldItem;

            /// <summary>
            /// Gets the item that has changed.
            /// </summary>
            /// <value>The item.</value>
            public T Item { get; }

            /// <summary>
            /// Gets the index of the item.
            /// </summary>
            /// <value>The index of the item.</value>
            public int ItemIndex { get; }

            /// <summary>
            /// Gets the type of change for the list.
            /// </summary>
            /// <value>The type of change for the list.</value>
            public ListChangedType ListChangedType { get; }

            /// <summary>
            /// Gets the item's previous value.
            /// </summary>
            /// <value>The old item.</value>
            public T OldItem { get; }
        }
#pragma warning restore 693
    }
}