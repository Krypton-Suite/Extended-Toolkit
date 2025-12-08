#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.DataGridView;

/// <summary>
/// Hosts a collection of KryptonDataGridViewPercentageColumn cells.
/// </summary>
/// <seealso cref="System.Windows.Forms.DataGridViewColumn" />
public class KryptonDataGridViewPercentageColumn : DataGridViewColumn// KryptonDataGridViewTextBoxColumn
{
    #region Identity
    /// <summary>
    /// Initialize a new instance of the KryptonDataGridViewPercentageColumn class.
    /// </summary>
    public KryptonDataGridViewPercentageColumn()
        : base(new DataGridViewPercentageCell())
    {
        DefaultCellStyle.Format = "P";
    }

    /// <summary>
    /// Returns a standard compact string representation of the column.
    /// </summary>
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder(0x40);
        builder.Append("KryptonDataGridViewPercentageColumn { Name=");
        builder.Append(Name);
        builder.Append(", Index=");
        builder.Append(Index.ToString(CultureInfo.CurrentCulture));
        builder.Append(" }");
        return builder.ToString();
    }

    #endregion

    /// <summary>
    /// Overrides CellTemplate
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override DataGridViewCell CellTemplate
    {
        get => base.CellTemplate;

        set
        {
            // Ensure that the cell used for the template is a DataGridViewPercentageCell.
            if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewPercentageCell)))
            {
                throw new InvalidCastException("Must be a DataGridViewPercentageCell");
            }
            base.CellTemplate = value;

        }
    }

}

/// <summary>
/// Class for a DataGridViewPercentageCell
/// </summary>
public class DataGridViewPercentageCell : KryptonDataGridViewTextBoxCell
{
    /// <summary>
    /// Constructor
    /// </summary>
    public DataGridViewPercentageCell()
    {
        Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
    }

    /// <summary>
    /// Specify the type of object used for editing. This is how the WinForms
    /// framework figures out what type of edit control to make.
    /// </summary>
    public override Type EditType => typeof(PercentageEditingControl);

    /// <summary>
    /// Overrides TypeValue
    /// </summary>
    public override Type ValueType => typeof(double);

    /// <summary>
    /// Specify the default cell contents upon creation of a new cell.
    /// </summary>
    public override object DefaultNewRowValue => 0;

    /// <summary>
    /// Overrides Paint
    /// </summary>
    /// <param name="graphics"></param>
    /// <param name="clipBounds"></param>
    /// <param name="cellBounds"></param>
    /// <param name="rowIndex"></param>
    /// <param name="cellState"></param>
    /// <param name="value"></param>
    /// <param name="formattedValue"></param>
    /// <param name="errorText"></param>
    /// <param name="cellStyle"></param>
    /// <param name="advancedBorderStyle"></param>
    /// <param name="paintParts"></param>
    protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
    {
        //Draw the bar
        int barWidth;
        if ((double)value >= 1.0)
        {
            barWidth = cellBounds.Width - 10;
        }
        else
        {
            barWidth = (int)((cellBounds.Width - 10) * (double)value);
        }

        if ((double)value > 0 && barWidth > 0)
        {
            Rectangle r = new Rectangle(cellBounds.X + 3, cellBounds.Y + 3, barWidth, cellBounds.Height - 8);

            using (LinearGradientBrush linearBrush = new LinearGradientBrush(r, KryptonManager.CurrentGlobalPalette.GetBackColor1(PaletteBackStyle.GridHeaderColumnList, PaletteState.Normal), KryptonManager.CurrentGlobalPalette.GetBackColor2(PaletteBackStyle.GridHeaderColumnList, PaletteState.Normal), LinearGradientMode.Vertical))
            {
                graphics.FillRectangle(linearBrush, r);
            }

            using (Pen pen = new Pen(KryptonManager.CurrentGlobalPalette.GetBorderColor1(PaletteBorderStyle.GridHeaderColumnList, PaletteState.Normal)))
            {
                graphics.DrawRectangle(pen, r);
            }

            //TODO : implement customization like conditional formatting
            //using (LinearGradientBrush linearBrush = new LinearGradientBrush(r, Color.FromArgb(255, 140, 197, 66), Color.FromArgb(255, 247, 251, 242), LinearGradientMode.Horizontal))
            //{
            //    graphics.FillRectangle(linearBrush, r);
            //}

            //using (Pen pen = new Pen(Color.FromArgb(255, 140, 197, 66)))
            //{
            //    graphics.DrawRectangle(pen, r);

            //}
        }

        base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle,
            DataGridViewPaintParts.None | DataGridViewPaintParts.ContentForeground);
    }
}

/// <summary>
/// Public class for the underlying editing control
/// </summary>
[ToolboxItem(false)]
public class PercentageEditingControl : DataGridViewTextBoxEditingControl
{
    /// <summary>
    /// Constructor
    /// </summary>
    public PercentageEditingControl()
    {
    }

    /// <summary>
    /// Returns if the character is a valid digit
    /// </summary>
    /// <param name="c">The character.</param>
    /// <returns>True if valid digit, false otherwise.</returns>
    private bool IsValidForNumberInput(char c)
    {
        return Char.IsDigit(c);
        // OrElse c = Chr(8) OrElse c = "."c OrElse c = "-"c OrElse c = "("c OrElse c = ")"c
    }

    /// <summary>
    /// Overrides onKeypPress
    /// </summary>
    /// <param name="e"></param>
    protected override void OnKeyPress(KeyPressEventArgs e)
    {
        if (!IsValidForNumberInput(e.KeyChar))
        {
            e.Handled = true;
        }
    }
}