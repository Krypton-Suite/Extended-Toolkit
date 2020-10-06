using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public struct LabelFormat
    {
        public string Text;
        public Font Font;
        public Brush Colour;
        public ChartTextAlign TextAlign;
        public float Margin;

        public LabelFormat(string text, Font font, Brush colour, ChartTextAlign textAlign, float margin)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException($"'{nameof(text)}' cannot be null or empty", nameof(text));
            }

            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }

            if (colour is null)
            {
                throw new ArgumentNullException(nameof(colour));
            }

            if (textAlign is null)
            {
                throw new ArgumentNullException(nameof(textAlign));
            }
        }
    }
}