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

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities;

public class ImageComboItem : object
{
    // forecolor: transparent = inherit
    private Color _foreColor = Color.FromKnownColor(KnownColor.Transparent);
    private bool _mark = false;
    private int _imageIndex = -1;
    private object? _tag = null;
    private string? _text = null;

    private string? _itemValue = null;

    // constructors
    public ImageComboItem()
    {
    }

    public ImageComboItem(string? text)
    {
        _text = text;
    }

    public ImageComboItem(string? text, int imageIndex)
    {
        _text = text;
        _imageIndex = imageIndex;
    }

    public ImageComboItem(string? text, int imageIndex, bool mark)
    {
        _text = text;
        _imageIndex = imageIndex;
        _mark = mark;
    }

    public ImageComboItem(string? text, int imageIndex, bool mark, Color foreColour)
    {
        _text = text;
        _imageIndex = imageIndex;
        _mark = mark;
        _foreColor = foreColour;
    }

    public ImageComboItem(string? text, int imageIndex, bool mark, Color foreColour, object? tag)
    {
        _text = text;
        _imageIndex = imageIndex;
        _mark = mark;
        _foreColor = foreColour;
        _tag = tag;
    }

    // Item value
    public string? ItemValue { get => _itemValue; set => _itemValue = value; }

    // forecolor
    public Color ForeColour { get => _foreColor; set => _foreColor = value; }

    // image index
    public int ImageIndex { get => _imageIndex; set => _imageIndex = value; }

    // mark (bold)
    public bool Mark { get => _mark; set => _mark = value; }

    // tag
    public object? Tag { get => _tag; set => _tag = value; }

    // item text
    public string? Text { get => _text; set => _text = value; }

    // ToString() should return item text
    public override string? ToString()
    {
        return _text;
    }

}