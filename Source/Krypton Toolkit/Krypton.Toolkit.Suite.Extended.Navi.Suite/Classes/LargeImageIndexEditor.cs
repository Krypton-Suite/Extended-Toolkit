#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
                return;

            ImageList imageList = null;

            PropertyDescriptorCollection PropertyCollection
                              = TypeDescriptor.GetProperties(instance);

            PropertyDescriptor property;
            if ((property = PropertyCollection.Find("LargeImages", false)) != null)
                imageList = (ImageList)property.GetValue(instance);

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