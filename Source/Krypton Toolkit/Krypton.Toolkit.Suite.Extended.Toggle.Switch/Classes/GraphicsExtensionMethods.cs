using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Toggle.Switch
{
    public static class GraphicsExtensionMethods
    {
        public static Color ToGrayScale(this Color originalColour)
        {
            if (originalColour.Equals(Color.Transparent))
                return originalColour;

            int grayScale = (int)((originalColour.R * .299) + (originalColour.G * .587) + (originalColour.B * .114));
            return Color.FromArgb(grayScale, grayScale, grayScale);
        }
    }
}