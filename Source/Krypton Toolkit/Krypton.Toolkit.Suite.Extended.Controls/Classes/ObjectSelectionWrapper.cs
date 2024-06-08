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
    /// Used together with the ListSelectionWrapper in order to wrap data sources for a CheckBoxComboBox.
    /// It helps to ensure you don't add an extra "Selected" property to a class that don't really need or want that information.
    /// </summary>
    public class ObjectSelectionWrapper<T> : INotifyPropertyChanged
    {
        public ObjectSelectionWrapper(T item, ListSelectionWrapper<T> container)
            : base()
        {
            _container = container;
            _item = item;
        }


        #region Instance Fields

        /// <summary>
        /// Used as a count indicator for the item. Not necessarily displayed.
        /// </summary>
        private int _count = 0;
        /// <summary>
        /// Is this item selected.
        /// </summary>
        private bool _selected = false;
        /// <summary>
        /// A reference to the wrapped item.
        /// </summary>
        private T _item;
        /// <summary>
        /// The containing list for these selections.
        /// </summary>
        private readonly ListSelectionWrapper<T> _container;

        #endregion

        #region Public

        /// <summary>
        /// An indicator of how many items with the specified status is available for the current filter level.
        /// Thought this would make the app a bit more user-friendly and help not to miss items in Statuses
        /// that are not often used.
        /// </summary>
        public int Count
        {
            get => _count;
            set => _count = value;
        }
        /// <summary>
        /// A reference to the item wrapped.
        /// </summary>
        public T Item
        {
            get => _item;
            set => _item = value;
        }
        /// <summary>
        /// The item display value. If ShowCount is true, it displays the "Name [Count]".
        /// </summary>
        public string? Name
        {
            get
            {
                string? name = null;
                if (string.IsNullOrEmpty(_container.DisplayNameProperty))
                {
                    name = Item.ToString();
                }
                else if (Item is DataRow) // A specific implementation for DataRow
                {
                    name = ((DataRow)(object)Item)[_container.DisplayNameProperty].ToString();
                }
                else
                {
                    PropertyDescriptorCollection pDs = TypeDescriptor.GetProperties(Item);
                    foreach (PropertyDescriptor pd in pDs)
                        if (pd.Name.CompareTo(_container.DisplayNameProperty) == 0)
                        {
                            name = (string)pd.GetValue(Item).ToString();
                            break;
                        }
                    if (string.IsNullOrEmpty(name))
                    {
                        PropertyInfo pi = Item.GetType().GetProperty(_container.DisplayNameProperty);
                        if (pi == null)
                        {
                            throw new Exception($"Property {_container.DisplayNameProperty} cannot be found on {Item.GetType()}.");
                        }

                        name = pi.GetValue(Item, null).ToString();
                    }
                }
                return _container.ShowCounts ? $"{name} [{Count}]" : name;
            }
        }
        /// <summary>
        /// The textbox display value. The names concatenated.
        /// </summary>
        public string NameConcatenated => _container.SelectedNames;

        /// <summary>
        /// Indicates whether the item is selected.
        /// </summary>
        public bool Selected
        {
            get => _selected;
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    OnPropertyChanged("Selected");
                    OnPropertyChanged("NameConcatenated");
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler? handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}