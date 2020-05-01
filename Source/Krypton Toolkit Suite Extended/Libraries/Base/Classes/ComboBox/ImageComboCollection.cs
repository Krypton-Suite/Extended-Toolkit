using System;
using System.Collections;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    public class ImageComboCollection<TComboBoxItem> : CollectionBase
    {

        public EventHandler UpdateItems;
        public ComboBox.ObjectCollection ItemsBase { get; set; }

        public ImageComboBoxItem this[int index]
        {
            get
            {
                return ((ImageComboBoxItem)ItemsBase[index]);
            }
            set
            {
                ItemsBase[index] = value;
            }
        }

        public int Add(ImageComboBoxItem value)
        {
            var result = ItemsBase.Add(value);
            UpdateItems.Invoke(this, null);
            return result;
        }

        public int IndexOf(ImageComboBoxItem value)
        {
            return (ItemsBase.IndexOf(value));
        }

        public void Insert(int index, ImageComboBoxItem value)
        {
            ItemsBase.Insert(index, value);
            UpdateItems.Invoke(this, null);
        }

        public void Remove(ImageComboBoxItem value)
        {
            ItemsBase.Remove(value);
            UpdateItems.Invoke(this, null);
        }

        public bool Contains(ImageComboBoxItem value)
        {
            return (ItemsBase.Contains(value));
        }

    }

}