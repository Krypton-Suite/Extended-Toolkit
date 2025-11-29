#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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
/// Token object
/// </summary>
public class Token : IComparable<Token>
{
    /// <summary>
    /// Default constructor
    /// </summary>
    public Token()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="text">Text of the token</param>
    /// <param name="bg">Background color</param>
    /// <param name="fg">Foreground text color</param>
    public Token(string text, Color bg, Color fg)
    {
        Text = text;
        BackColour = bg;
        ForeColour = fg;
    }

    /// <summary>
    /// Text of the token
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// Background color
    /// </summary>
    public Color BackColour { get; set; }
    /// <summary>
    /// Foreground text color
    /// </summary>
    public Color ForeColour { get; set; }

    /// <summary>
    /// Compare a Token to another
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(Token other) => Text.CompareTo(other.Text);

    /// <summary>
    /// Overrides ToString
    /// </summary>
    /// <returns>String that represents TextAndImage</returns>
    public override string ToString() => Text;

    /// <summary>
    /// Overrides Equals
    /// </summary>
    /// <param name="obj">The object to compare</param>
    /// <returns>true if equal, false otherwise.</returns>
    public override bool Equals(object obj) => Text.Equals(obj.ToString());

    /// <summary>
    /// Overrides GetHashCode
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => base.GetHashCode();
}

/// <summary>
/// Class for a Token cell
/// </summary>
public class TokenCell : KryptonDataGridViewTextBoxCell
{
    //List<Token> TokenList;
    /// <summary>
    /// Constructor
    /// </summary>
    public TokenCell()
    {
        //Value type is an integer. 
        //Formatted value type is an image since we derive from the ImageCell 
        ValueType = typeof(TokenCell);
    }

    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    /// A <see cref="System.String" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        Token tok = (Token)Value;
        if (tok != null)
        {
            return tok.Text;
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// Overrides Paint
    /// </summary>
    /// <param name="graphics"></param>
    /// <param name="clipBounds"></param>
    /// <param name="cellBounds"></param>
    /// <param name="rowIndex"></param>
    /// <param name="elementState"></param>
    /// <param name="value"></param>
    /// <param name="formattedValue"></param>
    /// <param name="errorText"></param>
    /// <param name="cellStyle"></param>
    /// <param name="advancedBorderStyle"></param>
    /// <param name="paintParts"></param>
    protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
    {
        float factorX = graphics.DpiX > 96 ? 1f * graphics.DpiX / 96 : 1f;
        float factorY = graphics.DpiY > 96 ? 1f * graphics.DpiY / 96 : 1f;

        int nextPosition = cellBounds.X + (int)(1 * factorX);
        if (KryptonManager.CurrentGlobalPalette != null)
        {
            Font f = KryptonManager.CurrentGlobalPalette.GetContentShortTextFont(PaletteContentStyle.GridDataCellList, PaletteState.Normal);

            Token tok = (Token)Value;
            if (tok != null)
            {
                Rectangle rectangle = new Rectangle();
                Size s = TextRenderer.MeasureText(tok.Text, f);
                rectangle.Width = s.Width + (int)(10 * factorX);
                rectangle.X = nextPosition;
                rectangle.Y = cellBounds.Y + (int)(2 * factorY);
                rectangle.Height = (int)(17 * factorY);
                nextPosition += rectangle.Width + (int)(5 * factorX);

                graphics.FillRectangle(new SolidBrush(tok.BackColour), rectangle);
                TextRenderer.DrawText(graphics, tok.Text, f, rectangle, tok.ForeColour);
            }
        }
    }

    /// <summary>
    /// Overrides GetPreferredSize
    /// </summary>
    /// <param name="graphics"></param>
    /// <param name="cellStyle"></param>
    /// <param name="rowIndex"></param>
    /// <param name="constraintSize"></param>
    /// <returns></returns>
    protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
    {
        float factorX = graphics.DpiX > 96 ? 1f * graphics.DpiX / 96 : 1f;
        float factorY = graphics.DpiY > 96 ? 1f * graphics.DpiY / 96 : 1f;

        Size tmpSize = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
        if (KryptonManager.CurrentGlobalPalette != null)
        {
            Font f = KryptonManager.CurrentGlobalPalette.GetContentShortTextFont(PaletteContentStyle.GridDataCellList, PaletteState.Normal);
            int nextPosition = (int)(1 * factorX);
            if (Value != null)
            {
                Token tok = (Token)Value;
                Size s = TextRenderer.MeasureText(tok.Text, f);
                nextPosition += s.Width + (int)(10 * factorX) + (int)(5 * factorX);

                tmpSize.Width = nextPosition;
            }
        }

        return tmpSize;
    }

    /// <summary>
    /// Update cell's value when the user clicks on a star 
    /// </summary>
    /// <param name="e">A DataGridViewCellEventArgs that contains the event data.</param>
    protected override void OnContentClick(DataGridViewCellEventArgs e)
    {
        base.OnContentClick(e);
    }

    #region Invalidate cells when mouse moves or leaves the cell

    /// <summary>
    /// Overrides OnMouseLeave
    /// </summary>
    /// <param name="rowIndex">the row that contains the cell.</param>
    protected override void OnMouseLeave(int rowIndex)
    {
        base.OnMouseLeave(rowIndex);
    }

    /// <summary>
    /// Overrides OnMouseMove
    /// </summary>
    /// <param name="e">A DataGridViewCellMouseEventArgs that contains the event data.</param>
    protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
    {
        base.OnMouseMove(e);
    }
    #endregion
}

/// <summary>
/// Class for a rating celle
/// </summary>
public class TokenListCell : KryptonDataGridViewTextBoxCell
{
    //List<Token> TokenList;
    /// <summary>
    /// Constructor
    /// </summary>
    public TokenListCell()
    {
        //Value type is an integer. 
        //Formatted value type is an image since we derive from the ImageCell 
        ValueType = typeof(List<TokenListCell>);
    }

    /// <summary>
    /// Overrides Paint
    /// </summary>
    /// <param name="graphics"></param>
    /// <param name="clipBounds"></param>
    /// <param name="cellBounds"></param>
    /// <param name="rowIndex"></param>
    /// <param name="elementState"></param>
    /// <param name="value"></param>
    /// <param name="formattedValue"></param>
    /// <param name="errorText"></param>
    /// <param name="cellStyle"></param>
    /// <param name="advancedBorderStyle"></param>
    /// <param name="paintParts"></param>
    protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
    {
        float factorX = graphics.DpiX > 96 ? 1f * graphics.DpiX / 96 : 1f;
        float factorY = graphics.DpiY > 96 ? 1f * graphics.DpiY / 96 : 1f;

        int nextPosition = cellBounds.X + (int)(1 * factorX);
        if (KryptonManager.CurrentGlobalPalette != null)
        {
            Font f = KryptonManager.CurrentGlobalPalette.GetContentShortTextFont(PaletteContentStyle.GridDataCellList, PaletteState.Normal);

            foreach (Token tok in (List<Token>)Value)
            {
                Rectangle rectangle = new Rectangle();
                Size s = TextRenderer.MeasureText(tok.Text, f);
                rectangle.Width = s.Width + (int)(10 * factorX);
                rectangle.X = nextPosition;
                rectangle.Y = cellBounds.Y + (int)(2 * factorY);
                rectangle.Height = (int)(17 * factorY);
                nextPosition += rectangle.Width + (int)(5 * factorX);

                graphics.FillRectangle(new SolidBrush(tok.BackColour), rectangle);
                TextRenderer.DrawText(graphics, tok.Text, f, rectangle, tok.ForeColour);
            }
        }
    }

    /// <summary>
    /// Overrides GetPreferredSize
    /// </summary>
    /// <param name="graphics"></param>
    /// <param name="cellStyle"></param>
    /// <param name="rowIndex"></param>
    /// <param name="constraintSize"></param>
    /// <returns></returns>
    protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
    {
        float factorX = graphics.DpiX > 96 ? 1f * graphics.DpiX / 96 : 1f;
        float factorY = graphics.DpiY > 96 ? 1f * graphics.DpiY / 96 : 1f;

        Size tmpSize = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
        if (KryptonManager.CurrentGlobalPalette != null)
        {
            Font f = KryptonManager.CurrentGlobalPalette.GetContentShortTextFont(PaletteContentStyle.GridDataCellList, PaletteState.Normal);
            int nextPosition = (int)(1 * factorX);
            if (Value != null)
            {
                foreach (Token tok in (List<Token>)Value)
                {
                    Size s = TextRenderer.MeasureText(tok.Text, f);
                    nextPosition += s.Width + (int)(10 * factorX) + (int)(5 * factorX);
                }
                tmpSize.Width = nextPosition;
            }
        }

        return tmpSize;
    }

    /// <summary>
    /// Update cell's value when the user clicks on a star 
    /// </summary>
    /// <param name="e">A DataGridViewCellEventArgs that contains the event data.</param>
    protected override void OnContentClick(DataGridViewCellEventArgs e)
    {
        base.OnContentClick(e);
    }

    #region Invalidate cells when mouse moves or leaves the cell

    /// <summary>
    /// Overrides OnMouseLeave
    /// </summary>
    /// <param name="rowIndex">the row that contains the cell.</param>
    protected override void OnMouseLeave(int rowIndex)
    {
        base.OnMouseLeave(rowIndex);
    }

    /// <summary>
    /// Overrides OnMouseMove
    /// </summary>
    /// <param name="e">A DataGridViewCellMouseEventArgs that contains the event data.</param>
    protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
    {
        base.OnMouseMove(e);
    }
    #endregion
}

/// <summary>
/// Class for a rating column
/// </summary>
public class KryptonDataGridViewTokenColumn : KryptonDataGridViewTextBoxColumn
{
    /// <summary>
    /// Constructor
    /// </summary>
    public KryptonDataGridViewTokenColumn()
    {
        CellTemplate = new TokenCell();
        DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        ValueType = typeof(TokenCell);
    }
}

/// <summary>
/// Class for a rating column
/// </summary>
public class KryptonDataGridViewTokenListColumn : KryptonDataGridViewTextBoxColumn
{
    /// <summary>
    /// Constructor
    /// </summary>
    public KryptonDataGridViewTokenListColumn()
    {
        CellTemplate = new TokenListCell();
        DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        ValueType = typeof(List<TokenListCell>);
    }
}