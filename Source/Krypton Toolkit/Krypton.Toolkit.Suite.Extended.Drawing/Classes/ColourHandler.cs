﻿#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Drawing
{
    public class ColourHandler
    {
        // Handle conversions between RGB and HSV    
        // (and Color types, as well).

        public struct ARGB
        {
            public int alpha, red, green, blue;

            public ARGB(int a, int r, int g, int b)
            {
                alpha = a;

                red = r;

                green = g;

                blue = b;
            }

            public override string ToString()
            {
                return $"({alpha}, {red}, {green}, {blue})";
            }
        }

        public struct RGB
        {
            // All values are between 0 and 255.
            public int Red;
            public int Green;
            public int Blue;

            public RGB(int R, int G, int B)
            {
                Red = R;
                Green = G;
                Blue = B;
            }

            public override string ToString()
            {
                return String.Format("({0}, {1}, {2})", Red, Green, Blue);
            }
        }

        public struct HSV
        {
            // All values are between 0 and 255.
            public int Hue;
            public int Saturation;
            public int value;

            public HSV(int H, int S, int V)
            {
                Hue = H;
                Saturation = S;
                value = V;
            }

            public override string ToString()
            {
                return String.Format("({0}, {1}, {2})", Hue, Saturation, value);
            }
        }

        public static RGB HSVtoRGB(int H, int S, int V)
        {
            // H, S, and V must all be between 0 and 255.
            return HSVtoRGB(new HSV(H, S, V));
        }

        public static Color HSVtoColour(HSV hsv)
        {
            RGB RGB = HSVtoRGB(hsv);
            return Color.FromArgb(RGB.Red, RGB.Green, RGB.Blue);
        }

        public static Color HSVtoColour(int H, int S, int V)
        {
            return HSVtoColour(new HSV(H, S, V));
        }

        public static RGB HSVtoRGB(HSV HSV)
        {
            // HSV contains values scaled as in the color wheel:
            // that is, all from 0 to 255. 

            // for ( this code to work, HSV.Hue needs
            // to be scaled from 0 to 360 (it//s the angle of the selected
            // point within the circle). HSV.Saturation and HSV.value must be 
            // scaled to be between 0 and 1.

            double h;
            double s;
            double v;

            double r = 0;
            double g = 0;
            double b = 0;

            // Scale Hue to be between 0 and 360. Saturation
            // and value scale to be between 0 and 1.
            h = (double)HSV.Hue / 255 * 360 % 360;
            s = (double)HSV.Saturation / 255;
            v = (double)HSV.value / 255;

            if (s == 0)
            {
                // If s is 0, all colors are the same.
                // This is some flavor of gray.
                r = v;
                g = v;
                b = v;
            }
            else
            {
                double p;
                double q;
                double t;

                double fractionalSector;
                int sectorNumber;
                double sectorPos;

                // The color wheel consists of 6 sectors.
                // Figure out which sector you//re in.
                sectorPos = h / 60;
                sectorNumber = (int)Math.Floor(sectorPos);

                // get the fractional part of the sector.
                // That is, how many degrees into the sector
                // are you?
                fractionalSector = sectorPos - sectorNumber;

                // Calculate values for the three axes
                // of the color. 
                p = v * (1 - s);
                q = v * (1 - s * fractionalSector);
                t = v * (1 - s * (1 - fractionalSector));

                // Assign the fractional colors to r, g, and b
                // based on the sector the angle is in.
                switch (sectorNumber)
                {
                    case 0:
                        r = v;
                        g = t;
                        b = p;
                        break;

                    case 1:
                        r = q;
                        g = v;
                        b = p;
                        break;

                    case 2:
                        r = p;
                        g = v;
                        b = t;
                        break;

                    case 3:
                        r = p;
                        g = q;
                        b = v;
                        break;

                    case 4:
                        r = t;
                        g = p;
                        b = v;
                        break;

                    case 5:
                        r = v;
                        g = p;
                        b = q;
                        break;
                }
            }
            // return an RGB structure, with values scaled
            // to be between 0 and 255.
            return new RGB((int)(r * 255), (int)(g * 255), (int)(b * 255));
        }

        public static HSV RGBtoHSV(RGB RGB)
        {
            // In this function, R, G, and B values must be scaled 
            // to be between 0 and 1.
            // HSV.Hue will be a value between 0 and 360, and 
            // HSV.Saturation and value are between 0 and 1.
            // The code must scale these to be between 0 and 255 for
            // the purposes of this application.

            double min;
            double max;
            double delta;

            double r = (double)RGB.Red / 255;
            double g = (double)RGB.Green / 255;
            double b = (double)RGB.Blue / 255;

            double h;
            double s;
            double v;

            min = Math.Min(Math.Min(r, g), b);
            max = Math.Max(Math.Max(r, g), b);
            v = max;
            delta = max - min;
            if (max == 0 || delta == 0)
            {
                // R, G, and B must be 0, or all the same.
                // In this case, S is 0, and H is undefined.
                // Using H = 0 is as good as any...
                s = 0;
                h = 0;
            }
            else
            {
                s = delta / max;
                if (r == max)
                {
                    // Between Yellow and Magenta
                    h = (g - b) / delta;
                }
                else if (g == max)
                {
                    // Between Cyan and Yellow
                    h = 2 + (b - r) / delta;
                }
                else
                {
                    // Between Magenta and Cyan
                    h = 4 + (r - g) / delta;
                }

            }
            // Scale h to be between 0 and 360. 
            // This may require adding 360, if the value
            // is negative.
            h *= 60;
            if (h < 0)
            {
                h += 360;
            }

            // Scale to the requirements of this 
            // application. All values are between 0 and 255.
            return new HSV((int)(h / 360 * 255), (int)(s * 255), (int)(v * 255));
        }
    }
}