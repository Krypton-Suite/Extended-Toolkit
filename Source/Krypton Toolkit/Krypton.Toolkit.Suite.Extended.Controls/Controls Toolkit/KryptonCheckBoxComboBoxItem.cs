#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2024 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Controls;

/// <summary>
/// The CheckBox items displayed in the Popup of the ComboBox.
/// </summary>
[ToolboxItem(false)]
public class KryptonCheckBoxComboBoxItem : KryptonCheckBox
{
    #region Identity

    /// <summary>
    /// 
    /// </summary>
    /// <param name="owner">A reference to the CheckBoxComboBox.</param>
    /// <param name="comboBoxItem">A reference to the item in the ComboBox.Items that this object is extending.</param>
    public KryptonCheckBoxComboBoxItem(KryptonCheckBoxComboBox owner, object comboBoxItem)
        : base()
    {
        DoubleBuffered = true;
        _checkBoxComboBox = owner;
        _comboBoxItem = comboBoxItem;
        if (_checkBoxComboBox.DataSource != null)
        {
            AddBindings();
        }
        else
        {
            Text = comboBoxItem.ToString();
        }
    }

    #endregion

    #region Instance Fields

    /// <summary>
    /// A reference to the CheckBoxComboBox.
    /// </summary>
    private readonly KryptonCheckBoxComboBox _checkBoxComboBox;

    /// <summary>
    /// A reference to the Item in ComboBox.Items that this object is extending.
    /// </summary>
    private object _comboBoxItem;

    #endregion

    #region Public

    /// <summary>
    /// A reference to the Item in ComboBox.Items that this object is extending.
    /// </summary>
    public object ComboBoxItem
    {
        get => _comboBoxItem;
        internal set => _comboBoxItem = value;
    }

    #endregion

    #region Implementation

    /// <summary>
    /// When using Data Binding operations via the DataSource property of the ComboBox. This
    /// adds the required Bindings for the CheckBoxes.
    /// </summary>
    public void AddBindings()
    {
        // Note, the text uses "DisplayMemberSingleItem", not "DisplayMember" (unless its not assigned)
        DataBindings.Add(
            "Text",
            _comboBoxItem,
            _checkBoxComboBox.DisplayMemberSingleItem
        );
        // The ValueMember must be a bool type property usable by the CheckBox.Checked.
        DataBindings.Add(
            "Checked",
            _comboBoxItem,
            _checkBoxComboBox.ValueMember,
            false,
            // This helps to maintain proper selection state in the Binded object,
            // even when the controls are added and removed.
            DataSourceUpdateMode.OnPropertyChanged,
            false, null, null);
        // Helps to maintain the Checked status of this
        // checkbox before the control is visible
        if (_comboBoxItem is INotifyPropertyChanged)
        {
            ((INotifyPropertyChanged)_comboBoxItem).PropertyChanged +=
                new PropertyChangedEventHandler(
                    CheckBoxComboBoxItem_PropertyChanged);
        }
    }

    internal void ApplyProperties(KryptonCheckBoxProperties properties)
    {
        //this.Appearance = properties.Appearance;
        AutoCheck = properties.AutoCheck;
        //this.AutoEllipsis = properties.AutoEllipsis;
        AutoSize = properties.AutoSize;
        //this.CheckAlign = properties.CheckAlign;
        //this.FlatAppearance.BorderColor = properties.FlatAppearanceBorderColor;
        //this.FlatAppearance.BorderSize = properties.FlatAppearanceBorderSize;
        //this.FlatAppearance.CheckedBackColor = properties.FlatAppearanceCheckedBackColor;
        //this.FlatAppearance.MouseDownBackColor = properties.FlatAppearanceMouseDownBackColor;
        //this.FlatAppearance.MouseOverBackColor = properties.FlatAppearanceMouseOverBackColor;
        //this.FlatStyle = properties.FlatStyle;
        ForeColor = properties.ForeColor;
        RightToLeft = properties.RightToLeft;
        //this.TextAlign = properties.TextAlign;
        ThreeState = properties.ThreeState;
    }

    /// <summary>
    /// Added this handler because the control doesn't seem 
    /// to initialize correctly until shown for the first
    /// time, which also means the summary text value
    /// of the combo is out of sync initially.
    /// </summary>
    private void CheckBoxComboBoxItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == _checkBoxComboBox.ValueMember)
        {
            Checked =
                (bool)_comboBoxItem
                    .GetType()
                    .GetProperty(_checkBoxComboBox.ValueMember)!
                    .GetValue(_comboBoxItem, null);
        }
    }

    #endregion

    #region Protected Overrides

    protected override void OnCheckedChanged(EventArgs e)
    {
        // Found that when this event is raised, the bool value of the binded item is not yet updated.
        if (_checkBoxComboBox.DataSource != null)
        {
            PropertyInfo? pi = ComboBoxItem.GetType().GetProperty(_checkBoxComboBox.ValueMember);
            pi.SetValue(ComboBoxItem, Checked, null);
        }

        base.OnCheckedChanged(e);
        // Forces a refresh of the Text displayed in the main TextBox of the ComboBox,
        // since that Text will most probably represent a concatenation of selected values.
        // Also see DisplayMemberSingleItem on the CheckBoxComboBox for more information.
        if (_checkBoxComboBox.DataSource != null)
        {
            string oldDisplayMember = _checkBoxComboBox.DisplayMember;
            _checkBoxComboBox.DisplayMember = null;
            _checkBoxComboBox.DisplayMember = oldDisplayMember;
        }
    }

    #endregion
}