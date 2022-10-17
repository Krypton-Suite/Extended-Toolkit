#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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