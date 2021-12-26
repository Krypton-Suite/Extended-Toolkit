#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.DataGridView
{
    /// <summary>
    /// Helper for color manipulations
    /// </summary>
    public static class ColourHelper
    {
        #region Structures for HSL and HSV colors

        /// <summary>
        /// HSV Structure
        /// </summary>
        public struct HSVColour
        {
            /// <summary>
            /// Hue value, from 0° to 360°
            /// </summary>
            public float Hue { get; set; }

            /// <summary>
            /// Saturation value, from 0 to 1
            /// </summary>
            public float Saturation { get; set; }

            /// <summary>
            /// Value or Brightness value, from 0 to 1
            /// </summary>
            public float ValueOrBrightness { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="HSVColour"/> struct.
            /// </summary>
            /// <param name="hue">The hue.</param>
            /// <param name="saturation">The saturation.</param>
            /// <param name="value">The value.</param>
            public HSVColour(float hue, float saturation, float value)
            {
                Hue = hue;
                Saturation = saturation;
                ValueOrBrightness = value;
            }
        }

        /// <summary>
        /// HSL Structure
        /// </summary>
        public struct HSLColour
        {
            /// <summary>
            /// Hue value, from 0° to 360°
            /// </summary>
            public float Hue { get; set; }

            /// <summary>
            /// Saturation value, from 0 to 1
            /// </summary>
            public float Saturation { get; set; }

            /// <summary>
            /// Value or Lightness value, from 0 to 1
            /// </summary>
            public float Lightness { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="HSLColour"/> struct.
            /// </summary>
            /// <param name="hue">The hue.</param>
            /// <param name="saturation">The saturation.</param>
            /// <param name="lightness">The lightness.</param>
            public HSLColour(float hue, float saturation, float lightness)
            {
                Hue = hue;
                Saturation = saturation;
                Lightness = lightness;
            }
        }

        #endregion


        /// <summary>
        /// Returns a System.Color from HSL values
        /// </summary>
        /// <param name="h">Hue (0 to 360°)</param>
        /// <param name="s">Saturation (0 to 1)</param>
        /// <param name="v">Value/Brightness (0 to 1)</param>
        /// <returns></returns>
        public static Color FromHSV(float h, float s, float v)
        {
            // Hue checking
            if (h < 0f)
            {
                h = 0f;
            }
            else if (h > 360f)
            {
                h = 360f;
            }

            // Saturation checking
            if (s < 0f)
            {
                s = 0f;
            }
            else if (s > 1f)
            {
                s = 1f;
            }

            // Value/Brightness checking
            if (v < 0f)
            {
                v = 0f;
            }
            else if (v > 1f)
            {
                v = 1f;
            }

            // === Conversion ===

            if (s == 0)
            {
                // No saturation => shade of gray
                int grayValue = Convert.ToInt32(v * 255);
                return Color.FromArgb(grayValue, grayValue, grayValue);
            }
            else
            {
                float hVal = h / 360f;  // 0 <= hVah < 1

                float varH = hVal * 6f;
                if (varH == 6f)
                {
                    varH = 0f;
                }

                int i = (int)varH;             //Or ... vari = floor( varh )
                float var1 = v * (1f - s);
                float var2 = v * (1f - s * (varH - (float)i));
                float var3 = v * (1f - s * (1f - (varH - i)));

                float fRed;
                float fGreen;
                float fBlue;
                switch (i)
                {
                    case 0: fRed = v; fGreen = var3; fBlue = var1; break;
                    case 1: fRed = var2; fGreen = v; fBlue = var1; break;
                    case 2: fRed = var1; fGreen = v; fBlue = var3; break;
                    case 3: fRed = var1; fGreen = var2; fBlue = v; break;
                    case 4: fRed = var3; fGreen = var1; fBlue = v; break;
                    default: fRed = v; fGreen = var1; fBlue = var2; break;
                }

                return Color.FromArgb((int)(fRed * 255f), (int)(fGreen * 255f), (int)(fBlue * 255f));
            }
        }


        /// <summary>
        /// Returns HSV values from RGB
        /// </summary>
        /// <param name="red">Red component from 0 to 255</param>
        /// <param name="green">Green component from 0 to 255</param>
        /// <param name="blue">Blue component from 0 to 255</param>
        /// <returns></returns>
        public static HSVColour ToHSV(int red, int green, int blue)
        {
            float varR = red / 255f;    //RGB from 0 to 255
            float varG = green / 255f;
            float varB = blue / 255f;

            float varMin = Math.Min(varR, Math.Min(varG, varB));    //Min. value of RGB
            float varMax = Math.Max(varR, Math.Max(varG, varB));    //Max. value of RGB
            float deltaMax = varMax - varMin;     //Delta RGB value 

            float h = 0;
            float s;

            // Value / Brightness
            var v = varMax;

            if (deltaMax == 0)
            {
                // Gray scale
                h = 0;      //HSV results from 0 to 1
                s = 0;
            }
            else
            {
                // Saturation
                s = deltaMax / varMax;

                // Hue
                float deltaR = (((varMax - varR) / 6f) + (deltaMax / 2f)) / deltaMax;
                float deltaG = (((varMax - varG) / 6f) + (deltaMax / 2f)) / deltaMax;
                float deltaB = (((varMax - varB) / 6f) + (deltaMax / 2f)) / deltaMax;

                if (varR == varMax)
                {
                    h = deltaB - deltaG;
                }
                else if (varG == varMax)
                {
                    h = (1f / 3f) + deltaR - deltaB;
                }
                else if (varB == varMax)
                {
                    h = (2f / 3f) + deltaG - deltaR;
                }

                if (h < 0f)
                {
                    h += 1;
                }

                if (h > 1f)
                {
                    h -= 1;
                }
            }

            return new HSVColour(h * 360f, s, v);
        }


        /// <summary>
        /// Returns a System.Color from HSL values
        /// </summary>
        /// <param name="h">Hue (0 to 360°)</param>
        /// <param name="s">Saturation (0 to 1)</param>
        /// <param name="l">Lightness (0 to 1)</param>
        /// <returns></returns>
        public static Color FromHSL(float h, float s, float l)
        {
            // Hue checking
            if (h < 0f)
            {
                h = 0f;
            }
            else if (h > 360f)
            {
                h = 360f;
            }

            // Saturation checking
            if (s < 0f)
            {
                s = 0f;
            }
            else if (s > 1f)
            {
                s = 1f;
            }

            // Lightness checking
            if (l < 0f)
            {
                l = 0f;
            }
            else if (l > 1f)
            {
                l = 1f;
            }

            // === Conversion ===
            if (s == 0)
            {
                // No saturation => shade of gray
                int grayValue = Convert.ToInt32(l * 255);
                return Color.FromArgb(grayValue, grayValue, grayValue);
            }

            var var2 = l < 0.5f ? l * (1f + s) : (l + s) - (s * l);

            var var1 = 2f * l - var2;
            var hval = h / 360f;

            int red = Convert.ToInt32(255f * FromHueToRGB(var1, var2, hval + (1f / 3f)));
            int green = Convert.ToInt32(255f * FromHueToRGB(var1, var2, hval));
            int blue = Convert.ToInt32(255f * FromHueToRGB(var1, var2, hval - (1f / 3f)));

            return Color.FromArgb(red, green, blue);
        }

        private static float FromHueToRGB(float var1, float var2, float hue)
        {
            float rgbColor;

            if (hue < 0f)
            {
                hue += 1f;
            }

            if (hue > 1f)
            {
                hue -= 1f;
            }

            if ((6f * hue) < 1f)
            {
                rgbColor = (var1 + (var2 - var1) * 6f * hue);
            }
            else if ((2f * hue) < 1f)
            {
                rgbColor = var2;
            }
            else if ((3f * hue) < 2f)
            {
                rgbColor = (var1 + (var2 - var1) * ((2f / 3f) - hue) * 6f);
            }
            else
            {
                rgbColor = var1;
            }

            return rgbColor;
        }

        /// <summary>
        /// Returns HSL values from RGB
        /// </summary>
        /// <param name="red">Red component from 0 to 255</param>
        /// <param name="green">Green component from 0 to 255</param>
        /// <param name="blue">Blue component from 0 to 255</param>
        /// <returns></returns>
        public static HSLColour ToHSL(int red, int green, int blue)
        {
            float varR = red / 255f;       //RGB from 0 to 255
            float varG = green / 255f;
            float varB = blue / 255f;

            float varMin = Math.Min(varR, Math.Min(varG, varB));    //Min. value of RGB
            float varMax = Math.Max(varR, Math.Max(varG, varB));    //Max. value of RGB
            float deltaMax = varMax - varMin;     //Delta RGB value

            float h = 0;
            float s;

            // Lightness
            var l = (varMax + varMin) / 2f;

            if (deltaMax == 0)
            {
                // Gray scale
                h = 0;      //HSL results from 0 to 1
                s = 0;
            }
            else
            {
                // Saturation
                if (l < 0.5f)
                {
                    s = deltaMax / (varMax + varMin);
                }
                else
                {
                    s = deltaMax / (2f - varMax - varMin);
                }

                // Hue
                float deltaR = (((varMax - varR) / 6f) + (deltaMax / 2f)) / deltaMax;
                float deltaG = (((varMax - varG) / 6f) + (deltaMax / 2f)) / deltaMax;
                float deltaB = (((varMax - varB) / 6f) + (deltaMax / 2f)) / deltaMax;

                if (varR == varMax)
                {
                    h = deltaB - deltaG;
                }
                else if (varG == varMax)
                {
                    h = (1f / 3f) + deltaR - deltaB;
                }
                else if (varB == varMax)
                {
                    h = (2f / 3f) + deltaG - deltaR;
                }

                if (h < 0f)
                {
                    h += 1f;
                }

                if (h > 1f)
                {
                    h -= 1f;
                }
            }

            return new HSLColour(h * 360f, s, l);
        }

    }
}