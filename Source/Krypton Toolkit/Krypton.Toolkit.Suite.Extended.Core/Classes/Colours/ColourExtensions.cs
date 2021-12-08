#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
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
        public static Color GenerateRandomColour()
        {
            // Create a new random instance
            Random r = new Random();

            return Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
        }

        /// <summary>Generates a random colour.</summary>
        /// <param name="control">The control.</param>
        public static void GenerateRandomColour(Control control)
        {
            Color randomColour = GenerateRandomColour();

            control.BackColor = randomColour;
        }

        /// <summary>Use as a base colour.</summary>
        /// <param name="baseColour">The base colour.</param>
        public static void UseAsBaseColour(Color baseColour)
        {
            InternalBasicPaletteCreator colourCreator = new InternalBasicPaletteCreator(baseColour);

            colourCreator.Show();
        }

        /// <summary>Use as a base colour.</summary>
        /// <param name="control">The control.</param>
        public static void UseAsBaseColour(Control control)
        {
            InternalBasicPaletteCreator colourCreator = new InternalBasicPaletteCreator(control.BackColor);

            colourCreator.Show();
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
        #endregion
    }
}