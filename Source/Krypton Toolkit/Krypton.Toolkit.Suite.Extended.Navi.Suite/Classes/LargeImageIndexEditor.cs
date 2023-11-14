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

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class LargeImageIndexEditor : UITypeEditor
    {
        object instance;

        public override bool GetPaintValueSupported(
           ITypeDescriptorContext context)
        {
            instance = context.Instance;
            return true;
        }

        public override void PaintValue(PaintValueEventArgs pe)
        {
            Image image = null;
            int imageIndex = 0;

            if (!int.TryParse(pe.Value.ToString(), out imageIndex))
            {
                return;
            }

            ImageList imageList = null;

            PropertyDescriptorCollection PropertyCollection
                              = TypeDescriptor.GetProperties(instance);

            PropertyDescriptor property;
            if ((property = PropertyCollection.Find("LargeImages", false)) != null)
            {
                imageList = (ImageList)property.GetValue(instance);
            }

            if ((imageList != null) && (imageList.Images.Count > imageIndex) && (imageIndex >= 0))
            {
                image = imageList.Images[imageIndex];
            }

            if (imageIndex < 0 || image == null)
            {
                pe.Graphics.DrawLine(Pens.Black, pe.Bounds.X + 1, pe.Bounds.Y + 1,
                   pe.Bounds.Right - 1, pe.Bounds.Bottom - 1);
                pe.Graphics.DrawLine(Pens.Black, pe.Bounds.Right - 1, pe.Bounds.Y + 1,
                   pe.Bounds.X + 1, pe.Bounds.Bottom - 1);
            }
            else
            {
                pe.Graphics.DrawImage(image, pe.Bounds);
            }
        }
    }
}