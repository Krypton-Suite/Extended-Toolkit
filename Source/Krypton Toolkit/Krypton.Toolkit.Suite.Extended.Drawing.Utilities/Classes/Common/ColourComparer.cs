#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    /// <summary>
    /// Provides access to color comparison operations.
    /// </summary>
    public static class ColourComparer
    {
        #region Constants

        private const double BlueLuminance = 0.072187;

        private const double GreenLuminance = 0.715158;

        private const double RedLuminance = 0.212655;

        #endregion

        #region Static Methods

        /// <summary>
        /// Compares two colors by brightness and returns an indication of their relative sort order.
        /// </summary>
        /// <param name="x">A color to compare to y.</param>
        /// <param name="y">A color to compare to x.</param>
        public static int Brightness(Color x, Color y)
        {
            int v1;
            int v2;
            int result;

            v1 = GetBrightness(x);
            v2 = GetBrightness(y);

            if (v1 < v2)
            {
                result = -1;
            }
            else if (v1 > v2)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// Compares two colors by hue and returns an indication of their relative sort order.
        /// </summary>
        /// <param name="x">A color to compare to y.</param>
        /// <param name="y">A color to compare to x.</param>
        public static int Hue(Color x, Color y)
        {
            float v1;
            float v2;
            int result;

            v1 = x.GetHue();
            v2 = y.GetHue();

            if (v1 < v2)
            {
                result = -1;
            }
            else if (v1 > v2)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// Compares two colors by value and returns an indication of their relative sort order.
        /// </summary>
        /// <param name="x">A color to compare to y.</param>
        /// <param name="y">A color to compare to x.</param>
        public static int Value(Color x, Color y)
        {
            int v1;
            int v2;
            int result;

            v1 = x.R << 16 | x.G << 8 | x.B;
            v2 = y.R << 16 | y.G << 8 | y.B;

            if (v1 > v2)
            {
                result = -1;
            }
            else if (v1 < v2)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }

            return result;
        }

        private static int GetBrightness(Color color)
        {
            //http://stackoverflow.com/a/13558570/148962

            // GRAY VALUE ("brightness")

            return GetGamma(RedLuminance * GetInverseGamma(color.R) + GreenLuminance * GetInverseGamma(color.G) + BlueLuminance * GetInverseGamma(color.B));
        }

        private static int GetGamma(double v)
        {
            // sRGB "gamma" function (approx 2.2)

            if (v <= 0.0031308)
            {
                v *= 12.92;
            }
            else
            {
                v = 1.055 * Math.Pow(v, 1.0 / 2.4) - 0.055;
            }

            return (int)(v * 255 + .5);
        }

        private static double GetInverseGamma(int ic)
        {
            double result;

            // Inverse of sRGB "gamma" function. (approx 2.2)

            double c = ic / 255.0;
            if (c <= 0.04045)
            {
                result = c / 12.92;
            }
            else
            {
                result = Math.Pow((c + 0.055) / 1.055, 2.4);
            }

            return result;
        }

        #endregion
    }
}