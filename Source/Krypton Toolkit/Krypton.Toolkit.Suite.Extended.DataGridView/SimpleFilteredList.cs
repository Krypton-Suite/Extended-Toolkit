#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;
// ReSharper disable UnusedType.Global

namespace Krypton.Toolkit.Suite.Extended.DataGridView
{
    /// <summary>
    /// Stolen from here https://docs.microsoft.com/en-gb/archive/blogs/winformsue/filtering-code
    /// and then modified to follow coding standards and fix subsequent filtering
    /// </summary>
    public class SimpleFilteredList<T> : BindingList<T>, IBindingListView
    {
        #region sourceItems

        private IList<T> sourceItems;
        private IList<T> SourceItems
        {
            get { return sourceItems ??= new List<T>(Items); }
        }
        // TODO: Have to deal with updates to the initial source list !
        #endregion sourceItems

        #region Searching

        /// <inheritdoc />
        protected override bool SupportsSearchingCore => true;

        /// <inheritdoc />
        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            return FindCore(0, prop, key);
        }

        private int FindCore(int startIndex, PropertyDescriptor prop, object key)
        {
            // Get the property info for the specified property.
            PropertyInfo propInfo = typeof(T).GetProperty(prop.Name);

            if (key != null)
            {
                // Loop through the items to see if the key
                // value matches the property value.
                for (int i = startIndex; i < SourceItems.Count; ++i)
                {
                    var item = SourceItems[i];
                    if (propInfo.GetValue(item, null).Equals(key))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private int Find(int startIndex, string property, object key)
        {
            // Check the properties for a property with the specified name.
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            PropertyDescriptor prop = properties.Find(property, true);

            // If there is not a match, return -1 otherwise pass search to
            // FindCore method.
            if (prop == null)
            {
                return -1;
            }
            else if (startIndex <= 0)
            {
                return FindCore(prop, key);
            }
            else
            {
                return FindCore(startIndex, prop, key);
            }

        }

        #endregion Searching

        #region Sorting

        private ArrayList sortedList;
        private ArrayList unsortedItems;
        private bool isSortedValue;
        private ListSortDirection sortDirectionValue;
        private PropertyDescriptor sortPropertyValue;

        /// <inheritdoc />
        protected override bool SupportsSortingCore => true;

        /// <inheritdoc />
        protected override bool IsSortedCore => isSortedValue;

        /// <inheritdoc />
        protected override PropertyDescriptor SortPropertyCore => sortPropertyValue;

        /// <inheritdoc />
        protected override ListSortDirection SortDirectionCore => sortDirectionValue;

        public void ApplySort(string propertyName, ListSortDirection direction)
        {
            // Check the properties for a property with the specified name.
            PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(T))[propertyName];
            // If there is not a match, return -1 otherwise pass search to
            // FindCore method.
            if (prop == null)
            {
                throw new ArgumentException($"{propertyName} is not a valid property for type:{typeof(T).Name}");
            }
            else
            {
                ApplySortCore(prop, direction);
            }
        }

        /// <inheritdoc />
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            RaiseListChangedEvents = false;

            sortedList = new ArrayList();

            // Check to see if the property type we are sorting by implements
            // the IComparable interface.

            Type interfaceType = prop.PropertyType.GetInterface("IComparable");
            if (interfaceType != null)
            {
                // If so, set the SortPropertyValue and SortDirectionValue.
                sortPropertyValue = prop;
                sortDirectionValue = direction;
                unsortedItems = new ArrayList(Count);

                // Loop through each item, adding it the the sortedItems ArrayList.
                foreach (object item in SourceItems)
                {
                    sortedList.Add(prop.GetValue(item));
                    unsortedItems.Add(item);
                }

                // Call Sort on the ArrayList.
                sortedList.Sort();

                // Check the sort direction and then copy the sorted items back into the list.
                if (direction == ListSortDirection.Descending)
                {
                    sortedList.Reverse();
                }

                for (int i = 0; i < Count; i++)
                {
                    int position = Find(0, prop.Name, sortedList[i]);
                    if (position != i
                        && position > -1
                        && position < Count
                        )
                    {
                        var temp = this[i];
                        this[i] = this[position];
                        this[position] = temp;
                    }
                }

                RaiseListChangedEvents = true;

                isSortedValue = true;

                // Raise the ListChanged event so bound controls refresh their values.
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
            else
            {
                // If the property type does not implement IComparable, let the user know.
                throw new NotSupportedException($"Cannot sort by {prop.Name}. This{prop.PropertyType} does not implement IComparable");
            }

        }

        /// <inheritdoc />
        protected override void RemoveSortCore()
        {
            RaiseListChangedEvents = false;

            // Ensure the list has been sorted.
            if (unsortedItems != null)
            {
                // Loop through the unsorted items and reorder the list per the unsorted list.
                for (int i = 0; i < unsortedItems.Count;)
                {
                    var position = Find(0, SortPropertyCore.Name,
                        unsortedItems[i].GetType().
                            GetProperty(SortPropertyCore.Name).GetValue(unsortedItems[i], null)
                        );

                    if (position >= 0 && position != i)
                    {
                        object temp = this[i];
                        this[i] = this[position];
                        this[position] = (T)temp;
                        i++;
                    }
                    else if (position == i)
                    {
                        i++;
                    }
                    else
                    {
                        // If an item in the unsorted list no longer exists, delete it.
                        unsortedItems.RemoveAt(i);
                    }
                }

                RaiseListChangedEvents = true;
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
        }

        /// <inheritdoc />
        public void RemoveSort()
        {
            RemoveSortCore();
        }

        /// <inheritdoc />
        public override void EndNew(int itemIndex)
        {
            // Check to see if the item is added to the end of the list,
            // and if so, re-sort the list.
            if (sortPropertyValue != null && itemIndex > 0 && itemIndex == Count - 1)
            {
                ApplySortCore(sortPropertyValue, sortDirectionValue);
            }

            base.EndNew(itemIndex);
        }

        #endregion Sorting

        #region AdvancedSorting

        /// <inheritdoc />
        public bool SupportsAdvancedSorting => false;

        /// <inheritdoc />
        public ListSortDescriptionCollection SortDescriptions => null;

        /// <inheritdoc />
        public void ApplySort(ListSortDescriptionCollection sorts)
        {
            throw new NotImplementedException();
        }

        #endregion AdvancedSorting

        #region Filtering

        private List<T> UnfilteredList { get; } = new();

        /// <inheritdoc />
        public bool SupportsFiltering => true;

        /// <inheritdoc />
        public void RemoveFilter()
        {
            if (Filter != null)
            {
                Filter = null;
            }
        }

        /// <summary>
        /// Should be in the format columnName ='desiredValue'
        /// </summary>
        private string FilterPropertyName { get; set; }

        private object FilterCompare { get; set; }

        private string filterValue = string.Empty;
        /// <inheritdoc />
        public string Filter
        {
            get => filterValue;
            set
            {
                if (filterValue != value)
                {
                    RaiseListChangedEvents = false;
                    // If filter value is null, reset list.
                    if (value == null)
                    {
                        ClearItems();
                        foreach (T t in UnfilteredList)
                        {
                            Items.Add(t);
                        }

                        filterValue = value;
                    }

                    // If the value is empty string, do nothing.
                    // This behavior is compatible with DataGridView AutoFilter code.
                    else if (value == string.Empty)
                    {
                    }

                    // If the value is not null or string, than process normal.
                    else if (Regex.Matches(value,
                     "[?[\\w ]+]? ?[=] ?'?[\\w|/: ]+'?",
                         RegexOptions.Singleline).Count == 1
                             && value != string.Empty)
                    {
                        // If the filter is not set.
                        UnfilteredList.Clear();
                        UnfilteredList.AddRange(Items);
                        filterValue = value;
                        GetFilterParts();
                        ApplyFilter();
                    }
                    else if (Regex.Matches(value,
                        "[?[\\w ]+]? ?[=] ?'?[\\w|/: ]+'?",
                        RegexOptions.Singleline).Count > 1)
                    {
                        throw new ArgumentException("Multi-column filtering is not implemented.");
                    }
                    else
                    {
                        throw new ArgumentException("Filter is not in the format: propName = 'value'.");
                    }

                    RaiseListChangedEvents = true;

                    OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
                }
            }
        }

        private void FilteredListView_ListChanged(object sender, ListChangedEventArgs e)
        {
            // Add the new item
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                UnfilteredList.Add(this[e.NewIndex]);
            }
            // Remove the new item

            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                UnfilteredList.RemoveAt(e.NewIndex);
            }
        }

        private void ApplyFilter()
        {
            UnfilteredList.Clear();
            UnfilteredList.AddRange(SourceItems);

            List<T> results = new();

            PropertyDescriptor propDesc = TypeDescriptor.GetProperties(typeof(T))[FilterPropertyName];

            if (propDesc != null)
            {
                int tempResults = -1;
                do
                {
                    tempResults = FindCore(tempResults + 1, propDesc, FilterCompare);
                    if (tempResults != -1)
                    {
                        results.Add(SourceItems[tempResults]);
                    }
                } while (tempResults != -1);
            }

            ClearItems();

            if (results.Count > 0)
            {
                foreach (T itemFound in results)
                {
                    Add(itemFound);
                }
            }

        }

        private void GetFilterParts()
        {
            string[] filterParts = Filter.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            FilterPropertyName = filterParts[0].Replace("[", string.Empty)
                                        .Replace("]", string.Empty)
                                        .Trim();

            PropertyDescriptor propDesc = TypeDescriptor.GetProperties(typeof(T))[FilterPropertyName.ToString()];

            if (propDesc != null)
            {
                try
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(propDesc.PropertyType);
                    FilterCompare = converter.ConvertFromString(filterParts[1].Replace("'", string.Empty).Trim());
                }
                catch (NotSupportedException)
                {
                    throw new ArgumentException(
                        $"Specified filter value {FilterCompare} can not be converted from string...Implement a type converter for {propDesc.PropertyType}");
                }
            }
            else
            {
                throw new ArgumentException(
                    $"Specified property '{FilterPropertyName}' is not found on type {typeof(T).Name}.");
            }

        }

        #endregion Filtering

    }
}
