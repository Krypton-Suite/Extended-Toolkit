using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Navi.Suite
{
    public class LargeImageIndexConverter : ImageIndexConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                int result = -1;
                string text = value.ToString();
                if (!text.Equals("(none)") && !(string.IsNullOrEmpty(text)))
                {
                    int.TryParse(text, out result);
                }
                return result;
            }
            else
                return null;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is Int32)
            {
                int number = (int)value;
                if (number >= 0)
                    return number.ToString();
                else
                    return "(none)";
            }
            else
                return null;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            ImageList imageList = null;

            PropertyDescriptorCollection PropertyCollection
                              = TypeDescriptor.GetProperties(context.Instance);

            PropertyDescriptor property;
            if ((property = PropertyCollection.Find("LargeImages", false)) != null)
                imageList = (ImageList)property.GetValue(context.Instance);

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
                return true;
            else
                return false;
        }

    }

}