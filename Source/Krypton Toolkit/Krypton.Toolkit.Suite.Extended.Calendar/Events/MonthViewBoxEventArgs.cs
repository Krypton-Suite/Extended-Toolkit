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

namespace Krypton.Toolkit.Suite.Extended.Calendar;

/// <summary>
/// Holds data about a box of text to be rendered on the month view
/// </summary>
public class MonthViewBoxEventArgs
{
    #region Fields
    private Graphics _graphics;
    private Color _textColor;
    private Color _backgroundColor;
    private string _text;
    private Color _borderColor;
    private Rectangle _bounds;
    private Font _font;
    private TextFormatFlags _TextFlags;
    #endregion

    #region Ctor

    internal MonthViewBoxEventArgs(Graphics g, Rectangle bounds, string text, StringAlignment textAlign, Color textColor, Color backColor, Color borderColor)
    {
        _graphics = g;
        _bounds = bounds;
        Text = text;
        TextColor = textColor;
        BackgroundColor = backColor;
        BorderColor = borderColor;

        switch (textAlign)
        {
            case StringAlignment.Center:
                TextFlags |= TextFormatFlags.HorizontalCenter;
                break;
            case StringAlignment.Far:
                TextFlags |= TextFormatFlags.Right;
                break;
            case StringAlignment.Near:
                TextFlags |= TextFormatFlags.Left;
                break;
            default:
                break;
        }

        TextFlags |= TextFormatFlags.VerticalCenter;
    }

    internal MonthViewBoxEventArgs(Graphics g, Rectangle bounds, string text, Color textColor)
        : this(g, bounds, text, StringAlignment.Center, textColor, Color.Empty, Color.Empty)
    { }

    internal MonthViewBoxEventArgs(Graphics g, Rectangle bounds, string text, Color textColor, Color backColor)
        : this(g, bounds, text, StringAlignment.Center, textColor, backColor, Color.Empty)
    { }

    internal MonthViewBoxEventArgs(Graphics g, Rectangle bounds, string text, StringAlignment textAlign, Color textColor, Color backColor)
        : this(g, bounds, text, textAlign, textColor, backColor, Color.Empty)
    { }

    internal MonthViewBoxEventArgs(Graphics g, Rectangle bounds, string text, StringAlignment textAlign, Color textColor)
        : this(g, bounds, text, textAlign, textColor, Color.Empty, Color.Empty)
    { }

    #endregion

    #region Props

    /// <summary>
    /// Gets or sets the bounds of the box
    /// </summary>
    public Rectangle Bounds => _bounds;

    /// <summary>
    /// Gets or sets the font of the text. If null, default will be used.
    /// </summary>
    public Font Font
    {
        get => _font;
        set => _font = value;
    }

    /// <summary>
    /// Gets or sets the Graphics object where to draw
    /// </summary>
    public Graphics Graphics => _graphics;

    /// <summary>
    /// Gets or sets the border color of the box
    /// </summary>
    public Color BorderColor
    {
        get => _borderColor;
        set => _borderColor = value;
    }

    /// <summary>
    /// Gets or sets the text of the box
    /// </summary>
    public string Text
    {
        get => _text;
        set => _text = value;
    }

    /// <summary>
    /// Gets or sets the background color of the box
    /// </summary>
    public Color BackgroundColor
    {
        get => _backgroundColor;
        set => _backgroundColor = value;
    }

    /// <summary>
    /// Gets or sets the text color of the box
    /// </summary>
    public Color TextColor
    {
        get => _textColor;
        set => _textColor = value;
    }

    /// <summary>
    /// Gets or sets the flags of the text
    /// </summary>
    public TextFormatFlags TextFlags
    {
        get => _TextFlags;
        set => _TextFlags = value;
    }


    #endregion
}