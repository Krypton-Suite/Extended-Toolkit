#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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