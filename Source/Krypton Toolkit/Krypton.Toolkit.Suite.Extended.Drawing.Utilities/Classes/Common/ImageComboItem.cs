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

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class ImageComboItem : object
    {
        // forecolor: transparent = inherit
        private Color forecolour = Color.FromKnownColor(KnownColor.Transparent);
        private bool mark = false;
        private int imageindex = -1;
        private object tag = null;
        private string text = null;

        private string _itemValue = null;

        // constructors
        public ImageComboItem()
        {
        }

        public ImageComboItem(string Text)
        {
            text = Text;
        }

        public ImageComboItem(string Text, int ImageIndex)
        {
            text = Text;
            imageindex = ImageIndex;
        }

        public ImageComboItem(string Text, int ImageIndex, bool Mark)
        {
            text = Text;
            imageindex = ImageIndex;
            mark = Mark;
        }

        public ImageComboItem(string Text, int ImageIndex, bool Mark, Color ForeColour)
        {
            text = Text;
            imageindex = ImageIndex;
            mark = Mark;
            forecolour = ForeColour;
        }

        public ImageComboItem(string Text, int ImageIndex, bool Mark, Color ForeColour, object Tag)
        {
            text = Text;
            imageindex = ImageIndex;
            mark = Mark;
            forecolour = ForeColour;
            tag = Tag;
        }

        // Item value
        public string ItemValue { get => _itemValue; set => _itemValue = value; }

        // forecolor
        public Color ForeColour { get => forecolour; set => forecolour = value; }

        // image index
        public int ImageIndex { get => imageindex; set => imageindex = value; }

        // mark (bold)
        public bool Mark { get => mark; set => mark = value; }

        // tag
        public object Tag { get => tag; set => tag = value; }

        // item text
        public string Text { get => text; set => text = value; }

        // ToString() should return item text
        public override string ToString()
        {
            return text;
        }

    }
}