#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public static class ColourExtensions
    {
        #region Variables
        private static Random _randomiser = new Random();
        #endregion

        #region Structures        
        /// <summary>
        /// 
        /// </summary>
        internal struct RGB
        {
            internal double R, G, B;
        }

        internal struct HSB
        {
            internal double H, S, B;
        }
        #endregion

        #region Methods
        /// <summary>Gets the contrast of a colour.</summary>
        /// <param name="source">The source.</param>
        /// <param name="preserveOpacity">if set to <c>true</c> [preserve opacity].</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static Color GetContrast(this Color source, bool preserveOpacity = true)
        {
            byte averageColourValue = (byte)((source.R + source.G + source.B) / 3);

            Color inputColourSource = source;

            int diffR = Math.Abs(source.R - averageColourValue), diffG = Math.Abs(source.G - averageColourValue), diffB = Math.Abs(source.B - averageColourValue);

            if (diffR < 20 && diffG < 20 && diffB < 20)
            {
                // Colour is dark
                if (averageColourValue < 123)
                {
                    inputColourSource = Color.FromArgb(source.A, 220, 230, 50);
                }
                else
                {
                    inputColourSource = Color.FromArgb(source.A, 255, 255, 50);
                }
            }

            byte sourceAlphaValue = source.A;

            if (!preserveOpacity)
            {
                sourceAlphaValue = Math.Max(source.A, (byte)127);
            }

            RGB rgb = new RGB { R = inputColourSource.R, G = inputColourSource.G, B = inputColourSource.B };

            HSB hsb = ConvertToHSB(rgb);

            hsb.H = hsb.H < 180 ? hsb.H + 180 : hsb.H - 180;

            rgb = ConvertToRGB(hsb);

            return Color.FromArgb((int)sourceAlphaValue, (int)rgb.R, (int)rgb.G, (int)rgb.B);
        }

        /// <summary>Gets a random colour.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public static Color GetRandomColour()
        {
            // Create a new random instance
            Random r = new Random();

            return Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Converts to RGB.
        /// </summary>
        /// <param name="hsb">The HSB.</param>
        /// <returns></returns>
        internal static RGB ConvertToRGB(HSB hsb)
        {
            double chroma = hsb.S * hsb.B, hue2 = hsb.H / 60, x = chroma * (1 - Math.Abs(hue2 % 2 - 1)), r1 = 0d, g1 = 0d, b1 = 0d;

            if (hue2 >= 0 && hue2 < 1)
            {
                r1 = chroma;

                g1 = x;
            }
            else if (hue2 >= 1 && hue2 < 2)
            {
                r1 = x;

                g1 = chroma;
            }
            else if (hue2 >= 2 && hue2 < 3)
            {
                g1 = chroma;

                b1 = x;
            }
            else if (hue2 >= 3 && hue2 < 4)
            {
                g1 = x;

                b1 = chroma;
            }
            else if (hue2 >= 4 && hue2 < 5)
            {
                r1 = x;

                b1 = chroma;
            }
            else if (hue2 >= 5 && hue2 <= 6)
            {
                r1 = chroma;

                b1 = x;
            }

            double m = hsb.B - chroma;

            return new RGB()
            {
                R = r1 + m,
                G = g1 + m,
                B = b1 + m
            };
        }

        internal static HSB ConvertToHSB(RGB rgb)
        {
            double r = rgb.R, g = rgb.G, b = rgb.B, max = Max(r, g, b), min = Min(r, g, b), chroma = max - min, hue2 = 0d;

            if (chroma != 0)
            {
                if (max == r)
                {
                    hue2 = (g - b) / chroma;
                }
                else if (max == g)
                {
                    hue2 = (b - r) / chroma + 2;
                }
                else
                {
                    hue2 = (r - g) / chroma + 4;
                }
            }

            double hue = hue2 * 60;

            if (hue < 0)
            {
                hue += 360;
            }

            double brightness = max, saturation = 0;

            if (chroma != 0)
            {
                saturation = chroma / brightness;
            }

            return new HSB()
            {
                H = hue,
                S = saturation,
                B = brightness
            };
        }

        private static double Max(double r, double g, double b)
        {
            if (r > g)
            {
                return Math.Max(r, b);
            }

            return Math.Max(g, b);
        }

        private static double Min(double r, double g, double b)
        {
            if (r < g)
            {
                return Math.Min(r, b);
            }

            return Math.Min(g, b);
        }

        /// <summary>
        /// Creates a Color from alpha, hue, saturation and brightness.
        /// Code from: https://stackoverflow.com/questions/4106363/converting-rgb-to-hsb-colors
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <param name="hue">The hue.</param>
        /// <param name="saturation">The saturation.</param>
        /// <param name="brightness">The brightness.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// alpha - Value must be within a range of 0 - 255.
        /// or
        /// hue - Value must be within a range of 0 - 360.
        /// or
        /// saturation - Value must be within a range of 0 - 1.
        /// or
        /// brightness - Value must be within a range of 0 - 1.
        /// </exception>
        public static Color FromAHSB(int alpha, float hue, float saturation, float brightness)
        {
            if (0 > alpha || 255 < alpha)
            {
                throw new ArgumentOutOfRangeException(
                    "alpha",
                    alpha,
                    "Value must be within a range of 0 - 255.");
            }

            if (0f > hue || 360f < hue)
            {
                throw new ArgumentOutOfRangeException(
                    "hue",
                    hue,
                    "Value must be within a range of 0 - 360.");
            }

            if (0f > saturation || 1f < saturation)
            {
                throw new ArgumentOutOfRangeException(
                    "saturation",
                    saturation,
                    "Value must be within a range of 0 - 1.");
            }

            if (0f > brightness || 1f < brightness)
            {
                throw new ArgumentOutOfRangeException(
                    "brightness",
                    brightness,
                    "Value must be within a range of 0 - 1.");
            }

            if (0 == saturation)
            {
                return Color.FromArgb(
                                    alpha,
                                    Convert.ToInt32(brightness * 255),
                                    Convert.ToInt32(brightness * 255),
                                    Convert.ToInt32(brightness * 255));
            }

            float fMax, fMid, fMin;
            int iSextant, iMax, iMid, iMin;

            if (0.5 < brightness)
            {
                fMax = brightness - (brightness * saturation) + saturation;
                fMin = brightness + (brightness * saturation) - saturation;
            }
            else
            {
                fMax = brightness + (brightness * saturation);
                fMin = brightness - (brightness * saturation);
            }

            iSextant = (int)Math.Floor(hue / 60f);
            if (300f <= hue)
            {
                hue -= 360f;
            }

            hue /= 60f;
            hue -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
            if (0 == iSextant % 2)
            {
                fMid = (hue * (fMax - fMin)) + fMin;
            }
            else
            {
                fMid = fMin - (hue * (fMax - fMin));
            }

            iMax = Convert.ToInt32(fMax * 255);
            iMid = Convert.ToInt32(fMid * 255);
            iMin = Convert.ToInt32(fMin * 255);

            switch (iSextant)
            {
                case 1:
                    return Color.FromArgb(alpha, iMid, iMax, iMin);
                case 2:
                    return Color.FromArgb(alpha, iMin, iMax, iMid);
                case 3:
                    return Color.FromArgb(alpha, iMin, iMid, iMax);
                case 4:
                    return Color.FromArgb(alpha, iMid, iMin, iMax);
                case 5:
                    return Color.FromArgb(alpha, iMax, iMin, iMid);
                default:
                    return Color.FromArgb(alpha, iMax, iMid, iMin);
            }
        }

        /// <summary>
        /// Colours from hexadecimal.
        /// </summary>
        /// <param name="hexValue">The hexadecimal value.</param>
        /// <returns></returns>
        public static Color ColourFromHexadecimal(string hexValue) => ColorTranslator.FromHtml(hexValue);

        /// <summary>
        /// Colours to hexadecimal.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        public static string ColourToHexadecimal(Color colour) => ColorTranslator.ToHtml(colour);

        public static string ColourToARGB(Color colour) => $"{colour.A}, {colour.R}, {colour.G}, {colour.B}";

        public static string ColourToRGB(Color colour) => $"{colour.R}, {colour.G}, {colour.B}";
        #endregion
    }
}