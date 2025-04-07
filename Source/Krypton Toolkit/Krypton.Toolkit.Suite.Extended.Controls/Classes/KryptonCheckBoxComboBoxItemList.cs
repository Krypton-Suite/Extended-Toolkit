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
    /// A Typed List of the CheckBox items.
    /// Simply a wrapper for the CheckBoxComboBox.Items. A list of CheckBoxComboBoxItem objects.
    /// This List is automatically synchronised with the Items of the ComboBox and extended to
    /// handle the additional boolean value. That said, do not Add or Remove using this List, 
    /// it will be lost or regenerated from the ComboBox.Items.
    /// </summary>
    [ToolboxItem(false)]
    public class KryptonCheckBoxComboBoxItemList : List<KryptonCheckBoxComboBoxItem>
    {
        #region CONSTRUCTORS

        public KryptonCheckBoxComboBoxItemList(KryptonCheckBoxComboBox checkBoxComboBox)
        {
            _checkBoxComboBox = checkBoxComboBox;
        }

        #endregion

        #region PRIVATE FIELDS

        private KryptonCheckBoxComboBox _checkBoxComboBox;

        #endregion

        #region EVENTS, This could be moved to the list control if needed

        public event EventHandler CheckBoxCheckedChanged;

        protected void OnCheckBoxCheckedChanged(object? sender, EventArgs e)
        {
            EventHandler handler = CheckBoxCheckedChanged;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        private void item_CheckedChanged(object? sender, EventArgs e)
        {
            OnCheckBoxCheckedChanged(sender, e);
        }

        #endregion

        #region LIST MEMBERS & OBSOLETE INDICATORS

        [Obsolete("Do not add items to this list directly. Use the ComboBox items instead.", false)]
        public new void Add(KryptonCheckBoxComboBoxItem item)
        {
            item.CheckedChanged += new EventHandler(item_CheckedChanged);
            base.Add(item);
        }

        public new void AddRange(IEnumerable<KryptonCheckBoxComboBoxItem> collection)
        {
            foreach (KryptonCheckBoxComboBoxItem item in collection)
                item.CheckedChanged += new EventHandler(item_CheckedChanged);
            base.AddRange(collection);
        }

        public new void Clear()
        {
            foreach (KryptonCheckBoxComboBoxItem item in this)
                item.CheckedChanged -= item_CheckedChanged;
            base.Clear();
        }

        [Obsolete("Do not remove items from this list directly. Use the ComboBox items instead.", false)]
        public new bool Remove(KryptonCheckBoxComboBoxItem item)
        {
            item.CheckedChanged -= item_CheckedChanged;
            return base.Remove(item);
        }

        #endregion

        #region DEFAULT PROPERTIES

        /// <summary>
        /// Returns the item with the specified displayName or Text.
        /// </summary>
        public KryptonCheckBoxComboBoxItem this[string displayName]
        {
            get
            {
                int startIndex =
                    // An invisible item exists in this scenario to help 
                    // with the Text displayed in the TextBox of the Combo
                    _checkBoxComboBox.DropDownStyle == ComboBoxStyle.DropDownList
                    && _checkBoxComboBox.DataSource == null
                        ? 1 // Ubiklou : 2008-04-28 : Ignore first item. (http://www.codeproject.com/KB/combobox/extending_combobox.aspx?fid=476622&df=90&mpp=25&noise=3&sort=Position&view=Quick&select=2526813&fr=1#xx2526813xx)
                        : 0;
                for (int index = startIndex; index <= Count - 1; index++)
                {
                    KryptonCheckBoxComboBoxItem item = this[index];

                    string text;
                    // The binding might not be active yet
                    if (string.IsNullOrEmpty(item.Text)
                        // Ubiklou : 2008-04-28 : No databinding
                        && item.DataBindings != null
                        && item.DataBindings["Text"] != null
                       )
                    {
                        PropertyInfo propertyInfo
                            = item.ComboBoxItem.GetType().GetProperty(
                                item.DataBindings["Text"].BindingMemberInfo.BindingMember);
                        text = (string)propertyInfo.GetValue(item.ComboBoxItem, null);
                    }
                    else
                    {
                        text = item.Text;
                    }

                    if (text.CompareTo(displayName) == 0)
                    {
                        return item;
                    }
                }

                throw new ArgumentOutOfRangeException($"\"{displayName}\" does not exist in this combo box.");
            }
        }

        #endregion
    }
}