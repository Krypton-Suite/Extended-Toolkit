using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public static class KryptonToggleSwitchGraphicsExtensionMethods
    {
        public static Color ToGrayScale(this Color originalColour)
        {
            if (originalColour == Color.Transparent)
            {
                return originalColour;
            }

            int grayScale = (int)((originalColour.R * .299) + (originalColour.G * .587) + (originalColour.B * .114));

            return Color.FromArgb(grayScale, grayScale, grayScale);
        }
    }
}