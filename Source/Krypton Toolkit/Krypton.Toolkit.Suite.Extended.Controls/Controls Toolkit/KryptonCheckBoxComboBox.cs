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

public partial class KryptonCheckBoxComboBox : KryptonPopUpComboBox
{
    #region Instance Fields

    /// <summary>
    /// The checkbox list control. The public CheckBoxItems property provides a direct reference to its Items.
    /// </summary>
    internal KryptonCheckBoxComboBoxListControl CheckBoxComboBoxListControl;

    /// <summary>
    /// In DataBinding operations, this property will be used as the DisplayMember in the CheckBoxComboBoxListBox.
    /// The normal/existing "DisplayMember" property is used by the TextBox of the ComboBox to display 
    /// a concatenated Text of the items selected. This concatenation and its formatting however is controlled 
    /// by the Binded object, since it owns that property.
    /// </summary>
    private string? _displayMemberSingleItem;

    internal bool MustAddHiddenItem;

    private KryptonCheckBoxProperties _checkBoxProperties;

    #endregion

    #region Events

    public event EventHandler CheckBoxCheckedChanged;

    #endregion

    #region Identity

    public KryptonCheckBoxComboBox()
    {
        InitializeComponent();

        _checkBoxProperties = new KryptonCheckBoxProperties();
        _checkBoxProperties.PropertyChanged += CheckBoxProperties_PropertyChanged;
        // Dumps the ListControl in a(nother) Container to ensure the ScrollBar on the ListControl does not
        // Paint over the Size grip. Setting the Padding or Margin on the Popup or host control does
        // not work as I expected. I don't think it can work that way.
        KryptonCheckBoxComboBoxListControlContainer containerControl = new KryptonCheckBoxComboBoxListControlContainer();
        CheckBoxComboBoxListControl = new KryptonCheckBoxComboBoxListControl(this);
        CheckBoxComboBoxListControl.Items.CheckBoxCheckedChanged += Items_CheckBoxCheckedChanged;
        containerControl.Controls.Add(CheckBoxComboBoxListControl);
        // This padding spaces neatly on the left-hand side and allows space for the size grip at the bottom.
        containerControl.Padding = new Padding(4, 0, 0, 14);
        // The ListControl FILLS the ListContainer.
        CheckBoxComboBoxListControl.Dock = DockStyle.Fill;
        // The DropDownControl used by the base class. Will be wrapped in a popup by the base class.
        DropDownControl = containerControl;
        // Must be set after the DropDownControl is set, since the popup is recreated.
        // NOTE: I made the dropDown protected so that it can be accessible here. It was private.
        _dropDown!.ReSizable = true;
    }

    #endregion

    #region Public

    /// <summary>
    /// A direct reference to the Items of CheckBoxComboBoxListControl.
    /// You can use it to Get or Set the Checked status of items manually if you want.
    /// But do not manipulate the List itself directly, e.g. Adding and Removing, 
    /// since the list is synchronised when shown with the ComboBox.Items. So for changing 
    /// the list contents, use Items instead.
    /// </summary>
    [Browsable(false)]
    public KryptonCheckBoxComboBoxItemList CheckBoxItems
    {
        get
        {
            // Added to ensure the CheckBoxItems are ALWAYS
            // available for modification via code.
            if (CheckBoxComboBoxListControl.Items.Count != Items.Count)
            {
                CheckBoxComboBoxListControl.SynchronizeControlsWithComboBoxItems();
            }
            return CheckBoxComboBoxListControl.Items;
        }
    }
    /// <summary>
    /// The DataSource of the combobox. Refreshes the CheckBox wrappers when this is set.
    /// </summary>
    public new object? DataSource
    {
        get => base.DataSource;
        set
        {
            base.DataSource = value;
            if (!string.IsNullOrEmpty(ValueMember))
            {
                // This ensures that at least the checkboxitems are available to be initialised.
                CheckBoxComboBoxListControl.SynchronizeControlsWithComboBoxItems();
            }
        }
    }
    /// <summary>
    /// The ValueMember of the combobox. Refreshes the CheckBox wrappers when this is set.
    /// </summary>
    public new string ValueMember
    {
        get => base.ValueMember;
        set
        {
            base.ValueMember = value;
            if (!string.IsNullOrEmpty(ValueMember))
            {
                // This ensures that at least the checkboxitems are available to be initialised.
                CheckBoxComboBoxListControl.SynchronizeControlsWithComboBoxItems();
            }
        }
    }
    /// <summary>
    /// In DataBinding operations, this property will be used as the DisplayMember in the CheckBoxComboBoxListBox.
    /// The normal/existing "DisplayMember" property is used by the TextBox of the ComboBox to display 
    /// a concatenated Text of the items selected. This concatenation however is controlled by the Binded 
    /// object, since it owns that property.
    /// </summary>
    public string? DisplayMemberSingleItem
    {
        get
        {
            if (string.IsNullOrEmpty(_displayMemberSingleItem))
            {
                return DisplayMember;
            }
            else
            {
                return _displayMemberSingleItem;
            }
        }
        set => _displayMemberSingleItem = value;
    }
    /// <summary>
    /// Made this property Browsable again, since the Base Popup hides it. This class uses it again.
    /// Gets an object representing the collection of the items contained in this 
    /// System.Windows.Forms.ComboBox.
    /// </summary>
    /// <returns>A System.Windows.Forms.ComboBox.ObjectCollection representing the items in 
    /// the System.Windows.Forms.ComboBox.
    /// </returns>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public new ComboBox.ObjectCollection Items => base.Items;

    /// <summary>
    /// The properties that will be assigned to the checkboxes as default values.
    /// </summary>
    [Description("The properties that will be assigned to the checkboxes as default values.")]
    [Browsable(true)]
    public KryptonCheckBoxProperties CheckBoxProperties
    {
        get => _checkBoxProperties;
        set
        {
            _checkBoxProperties = value; CheckBoxProperties_PropertyChanged(this, EventArgs.Empty);
        }
    }

    #endregion

    #region Implementation

    /// <summary>
    /// Builds a CSV string of the items selected.
    /// </summary>
    internal string GetCsvText(bool skipFirstItem)
    {
        string listText = string.Empty;
        int startIndex =
            DropDownStyle == ComboBoxStyle.DropDownList
            && DataSource == null
            && skipFirstItem
                ? 1
                : 0;
        for (int index = startIndex; index <= CheckBoxComboBoxListControl.Items.Count - 1; index++)
        {
            KryptonCheckBoxComboBoxItem item = CheckBoxComboBoxListControl.Items[index];
            if (item.Checked)
            {
                listText += string.IsNullOrEmpty(listText) ? item.Text : $", {item.Text}";
            }
        }
        return listText;
    }

    private void Items_CheckBoxCheckedChanged(object sender, EventArgs e)
    {
        OnCheckBoxCheckedChanged(sender, e);
    }

    /// <summary>
    /// A function to clear/reset the list.
    /// (Ubiklou : http://www.codeproject.com/KB/combobox/extending_combobox.aspx?msg=2526813#xx2526813xx)
    /// </summary>
    public void Clear()
    {
        Items.Clear();

        if (DropDownStyle == ComboBoxStyle.DropDownList && DataSource == null)
        {
            MustAddHiddenItem = true;
        }
    }

    /// <summary>
    /// Uncheck all items.
    /// </summary>
    public void ClearSelection()
    {
        foreach (KryptonCheckBoxComboBoxItem item in CheckBoxItems)
        {
            if (item.Checked)
            {
                item.Checked = false;
            }
        }
    }

    private void CheckBoxProperties_PropertyChanged(object sender, EventArgs e)
    {
        foreach (KryptonCheckBoxComboBoxItem item in CheckBoxItems)
        {
            item.ApplyProperties(CheckBoxProperties);
        }
    }

    #endregion

    #region Protected

    protected void OnCheckBoxCheckedChanged(object sender, EventArgs e)
    {
        string ListText = GetCsvText(true);
        // The DropDownList style seems to require that the text
        // part of the "textbox" should match a single item.
        if (DropDownStyle != ComboBoxStyle.DropDownList)
        {
            Text = ListText;
        }
        // This refreshes the Text of the first item (which is not visible)
        else if (DataSource == null)
        {
            Items[0] = ListText;
            // Keep the hidden item and first checkbox item in 
            // sync in order to ensure the Synchronise process
            // can match the items.
            CheckBoxItems[0].ComboBoxItem = ListText;
        }

        EventHandler handler = CheckBoxCheckedChanged;
        handler?.Invoke(sender, e);
    }

    #endregion

    #region Protected Overrides

    protected override void OnDropDownStyleChanged(EventArgs e)
    {
        base.OnDropDownStyleChanged(e);

        if (DropDownStyle == ComboBoxStyle.DropDownList
            && DataSource == null
            && !DesignMode)
        {
            MustAddHiddenItem = true;
        }
    }

    protected override void OnResize(EventArgs e)
    {
        //Size size = new Size(Width, DropDownControl.Height);

        //_dropDown!.Size = size;

        //_dropDown.Size = new Size(DropDownWidth, DropDownHeight);

        base.OnResize(e);
    }

    protected override void WndProc(ref Message m)
    {
        // 323 : Item Added
        // 331 : Clearing
        if (m.Msg == 331
            && DropDownStyle == ComboBoxStyle.DropDownList
            && DataSource == null)
        {
            MustAddHiddenItem = true;
        }

        base.WndProc(ref m);
    }

    #endregion
}