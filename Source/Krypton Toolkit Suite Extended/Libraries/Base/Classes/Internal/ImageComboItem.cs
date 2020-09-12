using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class ImageComboItem : object
    {
        #region Variables
        private Color _foreColour = Color.FromKnownColor(KnownColor.Transparent);

        private bool _mark = false;

        private int _imageIndex = -1;

        private object _tag = null;

        private string _text = null;

        private string _itemValue = null;
        #endregion

        #region Properties
        // Item value
        public string ItemValue { get => _itemValue; set => _itemValue = value; }

        // forecolor
        public Color ForeColour { get => _foreColour; set => _foreColour = value; }

        // image index
        public int ImageIndex { get => _imageIndex; set => _imageIndex = value; }

        // mark (bold)
        public bool Mark { get => _mark; set => _mark = value; }

        // tag
        public object Tag { get => _tag; set => _tag = value; }

        // item text
        public string Text { get => _text; set => _text = value; }
        #endregion

        #region Constructors
        public ImageComboItem()
        {
        }

        public ImageComboItem(string text)
        {
            Text = text;
        }

        public ImageComboItem(string text, int imageIndex)
        {
            Text = text;

            ImageIndex = imageIndex;
        }

        public ImageComboItem(string text, int imageIndex, bool mark)
        {
            Text = text;

            ImageIndex = imageIndex;

            Mark = mark;
        }

        public ImageComboItem(string text, int imageIndex, bool mark, Color foreColour)
        {
            Text = text;

            ImageIndex = imageIndex;

            Mark = mark;

            ForeColour = foreColour;
        }

        public ImageComboItem(string text, int imageIndex, bool mark, Color foreColour, object tag)
        {
            Text = text;

            ImageIndex = imageIndex;

            Mark = mark;

            ForeColour = foreColour;

            Tag = tag;
        }
        #endregion

        #region Override
        public override string ToString() => _text;
        #endregion
    }
}