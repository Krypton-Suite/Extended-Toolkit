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

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite;

public class LargeImageIndexConverter : ImageIndexConverter
{
    public override object? ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string)
        {
            int result = -1;
            string text = value.ToString();
            if (!text.Equals("(none)") && !string.IsNullOrEmpty(text))
            {
                int.TryParse(text, out result);
            }
            return result;
        }
        else
        {
            return null;
        }
    }

    public override object? ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (value is int)
        {
            int number = (int)value;
            if (number >= 0)
            {
                return number.ToString();
            }
            else
            {
                return "(none)";
            }
        }
        else
        {
            return null;
        }
    }

    public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
    {
        ImageList? imageList = null;

        PropertyDescriptorCollection propertyCollection
            = TypeDescriptor.GetProperties(context.Instance);

        PropertyDescriptor property;
        if ((property = propertyCollection.Find("LargeImages", false)) != null)
        {
            imageList = property.GetValue(context.Instance) as ImageList;
        }

        if (imageList != null)
        {
            ArrayList imgIdx = new ArrayList();
            imgIdx.Add(-1);
            for (int i = 0; i < imageList.Images.Count; i++)
            {
                imgIdx.Add(i);
            }

            return new StandardValuesCollection(imgIdx);
        }

        return new StandardValuesCollection(new int[1] { -1 });
    }

    public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
    {
        if (context.Instance != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}