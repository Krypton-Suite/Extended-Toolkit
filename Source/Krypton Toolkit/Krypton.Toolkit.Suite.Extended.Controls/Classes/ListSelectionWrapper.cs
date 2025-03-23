#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2024 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    /// <summary>
    /// Maintains an additional "Selected" & "Count" value for each item in a List.
    /// Useful in the CheckBoxComboBox. It holds a reference to the List[Index] Item and 
    /// whether it is selected or not.
    /// It also caters for a Count, if needed.
    /// </summary>
    /// <typeparam name="TSelectionWrapper"></typeparam>
    public class ListSelectionWrapper<T> : List<ObjectSelectionWrapper<T>>
    {
        #region Identity

        /// <summary>
        /// No property on the object is specified for display purposes, so simple ToString() operation 
        /// will be performed. And no Counts will be displayed
        /// </summary>
        public ListSelectionWrapper(IEnumerable source) : this(source, false) { }
        /// <summary>
        /// No property on the object is specified for display purposes, so simple ToString() operation 
        /// will be performed.
        /// </summary>
        public ListSelectionWrapper(IEnumerable source, bool showCounts)
            : base()
        {
            _source = source;
            _showCounts = showCounts;
            if (_source is IBindingList)
            {
                ((IBindingList)_source).ListChanged += new ListChangedEventHandler(ListSelectionWrapper_ListChanged);
            }

            Populate();
        }
        /// <summary>
        /// A Display "Name" property is specified. ToString() will not be performed on items.
        /// This is specifically useful on DataTable implementations, or where PropertyDescriptors are used to read the values.
        /// If a PropertyDescriptor is not found, a Property will be used.
        /// </summary>
        public ListSelectionWrapper(IEnumerable source, string usePropertyAsDisplayName) : this(source, false, usePropertyAsDisplayName) { }
        /// <summary>
        /// A Display "Name" property is specified. ToString() will not be performed on items.
        /// This is specifically useful on DataTable implementations, or where PropertyDescriptors are used to read the values.
        /// If a PropertyDescriptor is not found, a Property will be used.
        /// </summary>
        public ListSelectionWrapper(IEnumerable source, bool showCounts, string usePropertyAsDisplayName)
            : this(source, showCounts)
        {
            _displayNameProperty = usePropertyAsDisplayName;
        }

        #endregion

        #region Instance Fields

        /// <summary>
        /// Is a Count indicator used.
        /// </summary>
        private bool _showCounts;
        /// <summary>
        /// The original List of values wrapped. A "Selected" and possibly "Count" functionality is added.
        /// </summary>
        private IEnumerable _source;
        /// <summary>
        /// Used to indicate NOT to use ToString(), but read this property instead as a display value.
        /// </summary>
        private string _displayNameProperty = null;

        #endregion

        #region Public

        /// <summary>
        /// When specified, indicates that ToString() should not be performed on the items. 
        /// This property will be read instead. 
        /// This is specifically useful on DataTable implementations, where PropertyDescriptors are used to read the values.
        /// </summary>
        public string DisplayNameProperty
        {
            get => _displayNameProperty;
            set => _displayNameProperty = value;
        }
        /// <summary>
        /// Builds a concatenation list of selected items in the list.
        /// </summary>
        public string SelectedNames
        {
            get
            {
                string text = "";
                foreach (ObjectSelectionWrapper<T> item in this)
                    if (item.Selected)
                    {
                        text += string.IsNullOrEmpty(text)
                            ? $"\"{(object)item.Name}\""
                            : $" & \"{(object)item.Name}\"";
                    }

                return text;
            }
        }
        /// <summary>
        /// Indicates whether the Item display value (Name) should include a count.
        /// </summary>
        public bool ShowCounts
        {
            get => _showCounts;
            set => _showCounts = value;
        }

        #endregion

        #region Implementation

        /// <summary>
        /// Reset all counts to zero.
        /// </summary>
        public void ClearCounts()
        {
            foreach (ObjectSelectionWrapper<T> item in this)
            {
                item.Count = 0;
            }
        }
        /// <summary>
        /// Creates a ObjectSelectionWrapper item.
        /// Note that the constructor signature of sub classes classes are important.
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        private ObjectSelectionWrapper<T> CreateSelectionWrapper(IEnumerator @object)
        {
            Type[] types = [typeof(T), GetType()];
            ConstructorInfo ci = typeof(ObjectSelectionWrapper<T>).GetConstructor(types);
            if (ci == null)
            {
                throw new Exception(
                    $"The selection wrapper class {typeof(ObjectSelectionWrapper<T>)} must have a constructor with ({typeof(T)} Item, {GetType()} Container) parameters.");
            }

            object[] parameters = [@object.Current, this];
            object result = ci.Invoke(parameters);
            return (ObjectSelectionWrapper<T>)result;
        }

        public ObjectSelectionWrapper<T> FindObjectWithItem(T @object)
        {
            return Find(new Predicate<ObjectSelectionWrapper<T>>(
                target => target.Item.Equals(@object)));
        }

        /*
        public TSelectionWrapper FindObjectWithKey(object key)
        {
            return FindObjectWithKey(new object[] { key });
        }

        public TSelectionWrapper FindObjectWithKey(object[] keys)
        {
            return Find(new Predicate<TSelectionWrapper>(
                            delegate(TSelectionWrapper target)
                            {
                                return
                                    ReflectionHelper.CompareKeyValues(
                                        ReflectionHelper.GetKeyValuesFromObject(target.Item, target.Item.TableInfo),
                                        keys);
                            }));
        }

        public object[] GetArrayOfSelectedKeys()
        {
            List<object> List = new List<object>();
            foreach (TSelectionWrapper Item in this)
                if (Item.Selected)
                {
                    if (Item.Item.TableInfo.KeyProperties.Length == 1)
                        List.Add(ReflectionHelper.GetKeyValueFromObject(Item.Item, Item.Item.TableInfo));
                    else
                        List.Add(ReflectionHelper.GetKeyValuesFromObject(Item.Item, Item.Item.TableInfo));
                }
            return List.ToArray();
        }

        public T[] GetArrayOfSelectedKeys<T>()
        {
            List<T> List = new List<T>();
            foreach (TSelectionWrapper Item in this)
                if (Item.Selected)
                {
                    if (Item.Item.TableInfo.KeyProperties.Length == 1)
                        List.Add((T)ReflectionHelper.GetKeyValueFromObject(Item.Item, Item.Item.TableInfo));
                    else
                        throw new LibraryException("This generator only supports single value keys.");
                    // List.Add((T)ReflectionHelper.GetKeyValuesFromObject(Item.Item, Item.Item.TableInfo));
                }
            return List.ToArray();
        }
        */
        private void Populate()
        {
            Clear();
            /*
            for(int Index = 0; Index <= _Source.Count -1; Index++)
                Add(CreateSelectionWrapper(_Source[Index]));
             */
            IEnumerator? enumerator = _source.GetEnumerator();
            if (enumerator != null)
            {
                while (enumerator.MoveNext())
                {
                    Add(CreateSelectionWrapper(enumerator));
                }
            }
        }

        private void ListSelectionWrapper_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    Add(CreateSelectionWrapper((IEnumerator)((IBindingList)_source)[e.NewIndex]));
                    break;
                case ListChangedType.ItemDeleted:
                    Remove(FindObjectWithItem((T)((IBindingList)_source)[e.OldIndex]));
                    break;
                case ListChangedType.Reset:
                    Populate();
                    break;
            }
        }

        #endregion
    }
}