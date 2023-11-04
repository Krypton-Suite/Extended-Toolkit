#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Shared
{
    /// <summary>Represents a hue, saturation, luminance triple.</summary>
    public class ColorHSL : GlobalId
    {
        #region Instance Fields
        private double _hue;
        private double _saturation;
        private double _luminance;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the ColorHSL class.
        /// </summary>
        public ColorHSL()
        {
        }

        /// <summary>
        /// Initialize a new instance of the ColorHSL class.
        /// </summary>
        /// <param name="c">Initialize from an existing Color.</param>
        public ColorHSL(Color c)
        {
            // Initialize from the color instance
            _hue = c.GetHue() / 360f;
            _saturation = c.GetBrightness();
            _luminance = c.GetSaturation();
        }
        #endregion

        #region Color
        /// <summary>
        /// Get a Color instance from the HSL triple.
        /// </summary>
        public Color Color
        {
            get
            {
                double red = 0;
                double green = 0;
                double blue = 0;

                if (Luminance > 0)
                {
                    if (Saturation == 0)
                    {
                        red = green = blue = Luminance;
                    }
                    else
                    {
                        double temp2;

                        if (Luminance <= 0.5)
                        {
                            temp2 = Luminance * (1.0 + Saturation);
                        }
                        else
                        {
                            temp2 = Luminance + Saturation - (Luminance * Saturation);
                        }

                        var temp1 = (2.0 * Luminance) - temp2;

                        double[] t3 = { Hue + (1.0 / 3.0), Hue, Hue - (1.0 / 3.0) };
                        double[] clr = { 0, 0, 0 };

                        for (var i = 0; i < 3; i++)
                        {
                            if (t3[i] < 0)
                            {
                                t3[i] += 1.0;
                            }

                            if (t3[i] > 1)
                            {
                                t3[i] -= 1.0;
                            }

                            if ((6.0 * t3[i]) < 1.0)
                            {
                                clr[i] = temp1 + ((temp2 - temp1) * t3[i] * 6.0);
                            }
                            else if ((2.0 * t3[i]) < 1.0)
                            {
                                clr[i] = temp2;
                            }
                            else if ((3.0 * t3[i]) < 2.0)
                            {
                                clr[i] = temp1 + ((temp2 - temp1) * ((2.0 / 3.0) - t3[i]) * 6.0);
                            }
                            else
                            {
                                clr[i] = temp1;
                            }
                        }

                        red = clr[0];
                        green = clr[1];
                        blue = clr[2];
                    }
                }

                return Color.FromArgb((int)(255 * red),
                                      (int)(255 * green),
                                      (int)(255 * blue));
            }
        }
        #endregion

        #region Hue
        /// <summary>
        /// Gets and sets the hue.
        /// </summary>
        public double Hue
        {
            get => _hue;

            set
            {
                // Store new value
                _hue = value;

                // Limit check inside range of 0 -> 1
                if (_hue > 1)
                {
                    _hue = 1;
                }
                else if (_hue < 0)
                {
                    _hue = 0;
                }
            }
        }
        #endregion

        #region Saturation
        /// <summary>
        /// Gets and sets the saturation.
        /// </summary>
        public double Saturation
        {
            get => _saturation;

            set
            {
                // Store new value
                _saturation = value;

                // Limit check inside range of 0 -> 1
                if (_saturation > 1)
                {
                    _saturation = 1;
                }
                else if (_saturation < 0)
                {
                    _saturation = 0;
                }
            }
        }
        #endregion

        #region Luminance
        /// <summary>
        /// Gets and sets the luminance.
        /// </summary>
        public double Luminance
        {
            get => _luminance;

            set
            {
                // Store new value
                _luminance = value;

                // Limit check inside range of 0 -> 1
                if (_luminance > 1)
                {
                    _luminance = 1;
                }
                else if (_luminance < 0)
                {
                    _luminance = 0;
                }
            }
        }
        #endregion
    }
}