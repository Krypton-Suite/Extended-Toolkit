#region License
/*
 * ImageCombo Control is developed by Niels Penneman
 * All credit goes to him for this control
 * http://www.codeproject.com/cs/combobox/ImageCombo_NET.asp
 * 
*/
#endregion

using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonImageCombo : KryptonComboBox
    {
        #region Variables
        private ImageList _imageList = new ImageList();
        #endregion

        #region Property
        public ImageList ImageList { get => _imageList; set => _imageList = value; }
        #endregion

        #region Constructor
        public KryptonImageCombo()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
        }
        #endregion

        #region Override
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();

            e.DrawFocusRectangle();

            if (e.Index < 0)
            {
                e.Graphics.DrawString(Text, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + ImageList.ImageSize.Width, e.Bounds.Top);
            }
            else
            {
                if (Items[e.Index].GetType() == typeof(ImageComboItem))
                {
                    ImageComboItem item = (ImageComboItem)Items[e.Index];

                    Color foreColour = (item.ForeColour != Color.FromKnownColor(KnownColor.Transparent)) ? item.ForeColour : e.ForeColor;

                    Font typeface = item.Mark ? new Font(e.Font, FontStyle.Bold) : e.Font;

                    if (item.ImageIndex != -1)
                    {
                        ImageList.Draw(e.Graphics, e.Bounds.Left, e.Bounds.Top, item.ImageIndex);

                        e.Graphics.DrawString(item.Text, typeface, new SolidBrush(foreColour), e.Bounds.Left + ImageList.ImageSize.Width, e.Bounds.Top);
                    }
                    else
                    {
                        e.Graphics.DrawString(item.Text, typeface, new SolidBrush(foreColour), e.Bounds.Left + ImageList.ImageSize.Width, e.Bounds.Top);
                    }
                }
                else
                {
                    e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + ImageList.ImageSize.Width, e.Bounds.Top);
                }
            }

            base.OnDrawItem(e);
        }
        #endregion
    }

    #region Image Combo Item Class
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
    #endregion
}