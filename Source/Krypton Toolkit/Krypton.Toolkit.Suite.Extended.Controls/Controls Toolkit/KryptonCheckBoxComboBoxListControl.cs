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
    /// This ListControl that pops up to the User. It contains the CheckBoxComboBoxItems. 
    /// The items are docked DockStyle.Top in this control.
    /// </summary>
    [ToolboxItem(false)]
    public partial class KryptonCheckBoxComboBoxListControl : ScrollableControl
    {
        #region Identity

        public KryptonCheckBoxComboBoxListControl(KryptonCheckBoxComboBox owner)
            : base()
        {
            DoubleBuffered = true;
            _checkBoxComboBox = owner;
            _items = new KryptonCheckBoxComboBoxItemList(_checkBoxComboBox);
            BackColor = SystemColors.Window;
            // AutoScaleMode = AutoScaleMode.Inherit;
            AutoScroll = true;
            ResizeRedraw = true;
            // if you don't set this, a Resize operation causes an error in the base class.
            MinimumSize = new Size(1, 1);
            MaximumSize = new Size(500, 500);
        }

        #endregion

        #region Instance Fields

        /// <summary>
        /// Simply a reference to the CheckBoxComboBox.
        /// </summary>
        private readonly KryptonCheckBoxComboBox _checkBoxComboBox;

        /// <summary>
        /// A Typed list of ComboBoxCheckBoxItems.
        /// </summary>
        private readonly KryptonCheckBoxComboBoxItemList _items;

        #endregion

        #region Public

        public KryptonCheckBoxComboBoxItemList Items => _items;

        #endregion

        #region Protected Overrides

        /// <summary>
        /// Prescribed by the Popup control to enable Resize operations.
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (((Parent.Parent as Popup)!).ProcessResizing(ref m))
            {
                return;
            }

            base.WndProc(ref m);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            // Synchronises the CheckBox list with the items in the ComboBox.
            SynchroniseControlsWithComboBoxItems();
            base.OnVisibleChanged(e);
        }

        #endregion

        #region Implementation

        /// <summary>
        /// Maintains the controls displayed in the list by keeping them in sync with the actual 
        /// items in the combobox. (e.g. removing and adding as well as ordering)
        /// </summary>
        public void SynchroniseControlsWithComboBoxItems()
        {
            SuspendLayout();
            if (_checkBoxComboBox.MustAddHiddenItem)
            {
                _checkBoxComboBox.Items.Insert(
                    0, _checkBoxComboBox.GetCsvText(false)); // INVISIBLE ITEM
                _checkBoxComboBox.SelectedIndex = 0;
                _checkBoxComboBox.MustAddHiddenItem = false;
            }

            Controls.Clear();

            #region Disposes all items that are no longer in the combo box list

            for (int index = _items.Count - 1; index >= 0; index--)
            {
                KryptonCheckBoxComboBoxItem item = _items[index];
                if (!_checkBoxComboBox.Items.Contains(item.ComboBoxItem))
                {
                    _items.Remove(item);
                    item.Dispose();
                }
            }

            #endregion

            #region Recreate the list in the same order of the combo box items

            bool hasHiddenItem =
                _checkBoxComboBox.DropDownStyle == ComboBoxStyle.DropDownList
                && _checkBoxComboBox.DataSource == null
                && !DesignMode;

            KryptonCheckBoxComboBoxItemList newList = new KryptonCheckBoxComboBoxItemList(_checkBoxComboBox);
            for (int index0 = 0; index0 <= _checkBoxComboBox.Items.Count - 1; index0++)
            {
                object @object = _checkBoxComboBox.Items[index0];
                KryptonCheckBoxComboBoxItem item = null;
                // The hidden item could match any other item when only
                // one other item was selected.
                if (index0 == 0 && hasHiddenItem && _items.Count > 0)
                {
                    item = _items[0];
                }
                else
                {
                    int startIndex = hasHiddenItem
                        ? 1 // Skip the hidden item, it could match 
                        : 0;
                    for (int index1 = startIndex; index1 <= _items.Count - 1; index1++)
                    {
                        if (_items[index1].ComboBoxItem == @object)
                        {
                            item = _items[index1];
                            break;
                        }
                    }
                }

                if (item == null)
                {
                    item = new KryptonCheckBoxComboBoxItem(_checkBoxComboBox, @object);
                    item.ApplyProperties(_checkBoxComboBox.CheckBoxProperties);
                }

                newList.Add(item);
                item.Dock = DockStyle.Top;
            }

            _items.Clear();
            _items.AddRange(newList);

            #endregion

            #region Add the items to the controls in reversed order to maintain correct docking order

            if (newList.Count > 0)
            {
                // This reverse helps to maintain correct docking order.
                newList.Reverse();
                // If you get an error here that "Cannot convert to the desired 
                // type, it probably means the controls are not binding correctly.
                // The Checked property is binded to the ValueMember property. 
                // It must be a bool for example.
                Controls.AddRange(newList.ToArray());
            }

            #endregion

            // Keep the first item invisible
            if (_checkBoxComboBox.DropDownStyle == ComboBoxStyle.DropDownList
                && _checkBoxComboBox.DataSource == null
                && !DesignMode)
            {
                _checkBoxComboBox.CheckBoxItems[0].Visible = false;
            }

            ResumeLayout();
        }

        #endregion
    }
}