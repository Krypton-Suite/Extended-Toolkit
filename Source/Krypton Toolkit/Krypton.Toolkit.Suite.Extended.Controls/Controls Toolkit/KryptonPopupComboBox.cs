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

namespace Krypton.Toolkit.Suite.Extended.Controls;

[ToolboxBitmap(typeof(KryptonComboBox)), ToolboxItem(true), Description("Displays an editable text box with a drop-down list of permitted values.")]
public partial class KryptonPopUpComboBox : KryptonComboBox
{
    #region Instance Fields

    private Control _dropDownControl;

    protected PopUp? _dropDown;

    #endregion

    #region Identity

    public KryptonPopUpComboBox()
    {
        InitializeComponent();

        base.DropDownHeight = base.DropDownWidth = 1;

        IntegralHeight = false;
    }

    #endregion

    #region Public

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Control DropDownControl
    {
        get => _dropDownControl;

        set
        {
            if (_dropDownControl == value)
            {
                return;
            }

            _dropDownControl = value;

            _dropDown = new PopUp(value);
        }
    }

    #endregion

    #region Implementation

    /// <summary>
    /// Shows the drop down.
    /// </summary>
    public void ShowDropDown()
    {
        _dropDown?.Show(this);
    }

    /// <summary>
    /// Hides the drop down.
    /// </summary>
    public void HideDropDown()
    {
        _dropDown?.Hide();
    }

    #endregion

    #region Protected Overrides

    protected override void WndProc(ref Message m)
    {
        if (NativeMethods.HIWORD(m.WParam) == NativeMethods.CBN_DROPDOWN)
        {
            // Blocks a redisplay when the user closes the control by clicking 
            // on the combobox.
            TimeSpan timeSpan = DateTime.Now.Subtract(_dropDown!.LastClosedTimeStamp);
            if (timeSpan.TotalMilliseconds > 500)
            {
                ShowDropDown();
            }

            return;
        }

        base.WndProc(ref m);
    }

    #endregion

    #region Removed Designer

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>This property is not relevant for this class.</returns>
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
    public new int DropDownWidth
    {
        get => base.DropDownWidth;
        set => base.DropDownWidth = value;
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>This property is not relevant for this class.</returns>
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
    public new int DropDownHeight
    {
        get => base.DropDownHeight;
        set
        {
            _dropDown!.Height = value;
            base.DropDownHeight = value;
        }
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>This property is not relevant for this class.</returns>
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
    public new bool IntegralHeight
    {
        get => base.IntegralHeight;
        set => base.IntegralHeight = value;
    }

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>This property is not relevant for this class.</returns>
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
    public new ComboBox.ObjectCollection Items => base.Items;

    /// <summary>This property is not relevant for this class.</summary>
    /// <returns>This property is not relevant for this class.</returns>
    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)]
    public new int ItemHeight
    {
        get => base.ItemHeight;
        set => base.ItemHeight = value;
    }

    #endregion
}