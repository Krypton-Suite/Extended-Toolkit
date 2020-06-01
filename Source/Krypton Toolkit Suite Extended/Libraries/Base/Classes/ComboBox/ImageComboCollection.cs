using System;
using System.Collections;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    /// <summary></summary>
    /// <typeparam name="TComboBoxItem">The type of the ComboBox item.</typeparam>
    public class ImageComboCollection<TComboBoxItem> : CollectionBase
    {

        /// <summary>The update items</summary>
        public EventHandler UpdateItems;

        /// <summary>Gets or sets the items base.</summary>
        /// <value>The items base.</value>
        public ComboBox.ObjectCollection ItemsBase { get; set; }

        /// <summary>Gets or sets the <see cref="ImageComboBoxItem" /> at the specified index.</summary>
        /// <param name="index">The index.</param>
        /// <value>The <see cref="ImageComboBoxItem" />.</value>
        /// <returns></returns>
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

        /// <summary>Adds the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int Add(ImageComboBoxItem value)
        {
            var result = ItemsBase.Add(value);
            UpdateItems.Invoke(this, null);
            return result;
        }

        /// <summary>Indexes the of.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int IndexOf(ImageComboBoxItem value)
        {
            return (ItemsBase.IndexOf(value));
        }

        /// <summary>Inserts the specified index.</summary>
        /// <param name="index">The index.</param>
        /// <param name="value">The value.</param>
        public void Insert(int index, ImageComboBoxItem value)
        {
            ItemsBase.Insert(index, value);
            UpdateItems.Invoke(this, null);
        }

        /// <summary>Removes the specified value.</summary>
        /// <param name="value">The value.</param>
        public void Remove(ImageComboBoxItem value)
        {
            ItemsBase.Remove(value);
            UpdateItems.Invoke(this, null);
        }

        /// <summary>Determines whether this instance contains the object.</summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified value]; otherwise, <c>false</c>.</returns>
        public bool Contains(ImageComboBoxItem value)
        {
            return (ItemsBase.Contains(value));
        }

    }

}