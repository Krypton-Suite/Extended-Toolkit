#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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