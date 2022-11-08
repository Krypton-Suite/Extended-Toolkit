#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    [ToolboxItem(false)]
    public class KryptonImageComboBox : KryptonComboBox
    {
        #region Variables
        private ImageList _images;
        #endregion

        #region Properties
        public ImageList ImageList { get => _images; set => _images = value; }
        #endregion

        #region Constructor
        public KryptonImageComboBox()
        {
            _images = new ImageList();

            DrawMode = DrawMode.OwnerDrawFixed;
        }
        #endregion

        #region Overrides
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();

            e.DrawFocusRectangle();

            if (e.Index < 0)
            {
                // not an item, draw the text (indented)
                e.Graphics.DrawString(this.Text, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + _images.ImageSize.Width, e.Bounds.Top);
            }
            else
            {

                // check if item is an ImageComboItem
                if (this.Items[e.Index].GetType() == typeof(ImageComboItem))
                {

                    // get item to draw
                    ImageComboItem item = (ImageComboItem)this.Items[e.Index];

                    // get forecolor & font
                    Color foreColour = (item.ForeColour != Color.FromKnownColor(KnownColor.Transparent)) ? item.ForeColour : e.ForeColor;

                    Font font = item.Mark ? new Font(e.Font, FontStyle.Bold) : e.Font;

                    // -1: no image
                    if (item.ImageIndex != -1)
                    {
                        // draw image, then draw text next to it
                        ImageList.Draw(e.Graphics, e.Bounds.Left, e.Bounds.Top, item.ImageIndex);

                        e.Graphics.DrawString(item.Text, font, new SolidBrush(foreColour), e.Bounds.Left + _images.ImageSize.Width, e.Bounds.Top);
                    }
                    else
                    {
                        // draw text (indented)
                        e.Graphics.DrawString(item.Text, font, new SolidBrush(foreColour), e.Bounds.Left + _images.ImageSize.Width, e.Bounds.Top);
                    }
                }
                else
                {

                    // it is not an ImageComboItem, draw it
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + _images.ImageSize.Width, e.Bounds.Top);
                }
            }

            base.OnDrawItem(e);
        }
        #endregion
    }
}