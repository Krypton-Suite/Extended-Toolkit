using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    /// <summary></summary>
    [Serializable]
    public class ImageComboBoxItem
    {
        private object _value;
        private Image _image;


        /// <summary>
        /// ComobBox Item.
        /// </summary>
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }


        /// <summary>
        /// Item image.
        /// </summary>
        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }


        /// <summary>Initializes a new instance of the <see cref="ImageComboBoxItem" /> class.</summary>
        public ImageComboBoxItem()
        {
            _value = string.Empty;
            _image = new Bitmap(1, 1);
        }


        /// <summary>
        /// Constructor item without image.
        /// </summary>
        /// <param name="value">Item value.</param>
        public ImageComboBoxItem(object value)
        {
            _value = value;
            _image = new Bitmap(1, 1);

        }


        /// <summary>
        ///  Constructor item with image.
        /// </summary>
        /// <param name="value">Item value.</param>
        /// <param name="image">Item image.</param>
        public ImageComboBoxItem(object value, Image image)
        {
            _value = value;
            _image = image;
        }


        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return _value.ToString();
        }
    }
}