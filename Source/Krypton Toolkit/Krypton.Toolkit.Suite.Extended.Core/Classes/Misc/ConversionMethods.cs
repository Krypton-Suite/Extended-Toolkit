#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class ConversionMethods
    {
        #region Constant Variables
        private const int MINIMUM_COLOUR_CHANNEL_VALUE = 0, MAXIMUM_COLOUR_CHANNEL_VALUE = 255;

        private const double MINIMUM_ALPHA_CHANNEL_VALUE = 0.0, MAXIMUM_ALPHA_CHANNEL_VALUE = 1.0;
        #endregion

        #region Variables
        private int _red, _green, _blue;
        private double _alpha;
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the red value.
        /// </summary>
        /// <value>
        /// The red value.
        /// </value>
        public int Red
        {
            get
            {
                return _red;
            }

            set
            {
                _red = value;
            }
        }

        /// <summary>
        /// Gets or sets the green value.
        /// </summary>
        /// <value>
        /// The green value.
        /// </value>
        public int Green
        {
            get
            {
                return _green;
            }

            set
            {
                _green = value;
            }
        }

        /// <summary>
        /// Gets or sets the blue value.
        /// </summary>
        /// <value>
        /// The blue value.
        /// </value>
        public int Blue
        {
            get
            {
                return _blue;
            }

            set
            {
                _blue = value;
            }
        }

        /// <summary>
        /// Gets or sets the alpha value.
        /// </summary>
        /// <value>
        /// The alpha value.
        /// </value>
        public double Alpha
        {
            get
            {
                return _alpha;
            }

            set
            {
                _alpha = value;
            }
        }
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ConversionMethods"/> class.
        /// </summary>
        public ConversionMethods()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Converts the colour from RGB to hexadecimal.
        /// </summary>
        /// <param name="red">The red channel.</param>
        /// <param name="green">The green channel.</param>
        /// <param name="blue">The blue channel.</param>
        /// <returns></returns>
        public string ConvertRGBToHexadecimal(int red, int green, int blue)
        {
            return ColorTranslator.FromHtml(String.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue)).Name.Remove(0, 1);
        }

        /// <summary>
        /// Converts the hexadecimal to RGB.
        /// </summary>
        /// <param name="hexColour">The hexadecimal colour.</param>
        /// <returns></returns>
        public Color ConvertHexadecimalToRGB(string hexColour)
        {
            //int red = 0, green = 0, blue = 0;

            //Color rgbColour = ColorTranslator.FromHtml(hexColour);

            //red = Convert.ToInt32(rgbColour.R);

            //green = Convert.ToInt32(rgbColour.G);

            //blue = Convert.ToInt32(rgbColour.B);

            /*if (hexColour.IndexOf('#') != -1)
            {
                hexColour = hexColour.Replace("#", "");
            }

            if (hexColour.Length == 6)
            {
                red = int.Parse(hexColour.Substring(0, 2), NumberStyles.AllowHexSpecifier);

                green = int.Parse(hexColour.Substring(2, 2), NumberStyles.AllowHexSpecifier);

                blue = int.Parse(hexColour.Substring(4, 2), NumberStyles.AllowHexSpecifier);
            }
            else if (hexColour.Length == 3)
            {
                red = int.Parse(hexColour[0].ToString() + hexColour[0].ToString(), NumberStyles.AllowHexSpecifier);

                green = int.Parse(hexColour[1].ToString() + hexColour[1].ToString(), NumberStyles.AllowHexSpecifier);

                blue = int.Parse(hexColour[2].ToString() + hexColour[2].ToString(), NumberStyles.AllowHexSpecifier);
            }*/

            //SetRGB(red, green, blue);

            Color output = ColorTranslator.FromHtml(hexColour);

            return output;
        }

        //public Color ConvertHexadecimalToRGBTest(string hexColour)
        //{
        //    if (hexColour.StartsWith("#"))
        //    {
        //        hexColour = hexColour.Remove(0, 1);
        //    }

        //    byte red, green, blue;

        //    if (hexColour.Length == 3)
        //    {
        //        red = Convert.ToByte(hexColour[0] + "" + hexColour[0], 16);

        //        green = Convert.ToByte(hexColour[1] + "" + hexColour[1], 16);

        //        blue = Convert.ToByte(hexColour[2] + "" + hexColour[2], 16);
        //    }
        //    else if (hexColour.Length == 6)
        //    {
        //        red = Convert.ToByte(hexColour[0] + "" + hexColour[1], 16);

        //        green = Convert.ToByte(hexColour[2] + "" + hexColour[3], 16);

        //        blue = Convert.ToByte(hexColour[4] + "" + hexColour[5], 16);
        //    }
        //    else
        //    {
        //        throw new ArgumentNullException($"Hex colour value: '{ hexColour.ToUpper() }' is invalid.");
        //    }

        //    SetRGB(Convert.ToInt32(red), Convert.ToInt32(green), Convert.ToInt32(blue));

        //    return Color.FromArgb(255, red, green, blue);
        //}

        /// <summary>
        /// Converts the hexadecimal to RGB test.
        /// </summary>
        /// <param name="hexColour">The hexadecimal colour.</param>
        /// <returns></returns>
        public static int[] ConvertHexadecimalToRGBTest(string hexColour)
        {
            int[] result;

            try
            {
                if (!hexColour.StartsWith("#"))
                {
                    hexColour = string.Concat("#", hexColour);
                }

                Color colourResult = ColorTranslator.FromHtml(hexColour);

                result = new int[] { colourResult.R, colourResult.G, colourResult.B };
            }
            catch (Exception)
            {
                result = new int[3];
            }

            return result;
        }

        /// <summary>
        /// Converts the decimal to integer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public int ConvertDecimalToInteger(decimal value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// Sets the RGB.
        /// </summary>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        public void SetRGB(int red, int green, int blue)
        {
            SetRed(red);

            SetGreen(green);

            SetBlue(blue);
        }

        /// <summary>
        /// Sets the rgba.
        /// </summary>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        /// <param name="alpha">The alpha.</param>
        public void SetRGBA(int red, int green, int blue, double alpha = 0.5)
        {
            SetRed(red);

            SetGreen(green);

            SetBlue(blue);

            SetAlpha(alpha);
        }

        /// <summary>
        /// Formats the colour RGB string.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        public static String FormatColourRGBString(Color colour)
        {
            return $"{ colour.R.ToString() }, { colour.G.ToString() }, { colour.B.ToString() }";
        }

        /// <summary>
        /// Formats the colour ARGB string.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        public static String FormatColourARGBString(Color colour)
        {
            return $"{ colour.A.ToString() }, { colour.R.ToString() }, { colour.G.ToString() }, { colour.B.ToString() }";
        }

        /// <summary>
        /// Formats the colour to hexadecimal.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        public static String FormatColourToHexadecimal(Color colour)
        {
            int redValue = colour.R, greenValue = colour.G, blueValue = colour.B;

            return ColorTranslator.FromHtml(string.Format("#{0:X2}{1:X2}{2:X2}", redValue, greenValue, blueValue)).Name.Remove(0, 1);
        }

        /// <summary>
        /// Converts the float to decimal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static decimal ConvertFloatToDecimal(float value)
        {
            return (decimal)value;
        }

        /// <summary>
        /// Converts the float to double.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static double ConvertFloatToDouble(float value)
        {
            return (double)value;
        }
        #endregion

        #region Setters & Getters
        /// <summary>
        /// Sets the red.
        /// </summary>
        /// <param name="redValue">The red value.</param>
        public void SetRed(int redValue)
        {
            Red = redValue;
        }

        /// <summary>
        /// Gets the red.
        /// </summary>
        /// <returns></returns>
        public int GetRed()
        {
            if (Red < MINIMUM_COLOUR_CHANNEL_VALUE || Red > MAXIMUM_COLOUR_CHANNEL_VALUE)
            {
                return Red;
            }
            else
            {
                return MAXIMUM_COLOUR_CHANNEL_VALUE;
            }
        }

        /// <summary>
        /// Sets the green.
        /// </summary>
        /// <param name="greenValue">The green value.</param>
        public void SetGreen(int greenValue)
        {
            Green = greenValue;
        }

        /// <summary>
        /// Gets the green.
        /// </summary>
        /// <returns></returns>
        public int GetGreen()
        {
            if (Green < MINIMUM_COLOUR_CHANNEL_VALUE || Green > MAXIMUM_COLOUR_CHANNEL_VALUE)
            {
                return Green;
            }
            else
            {
                return MAXIMUM_COLOUR_CHANNEL_VALUE;
            }
        }

        /// <summary>
        /// Sets the blue.
        /// </summary>
        /// <param name="blueValue">The blue value.</param>
        public void SetBlue(int blueValue)
        {
            Blue = blueValue;
        }

        /// <summary>
        /// Gets the blue.
        /// </summary>
        /// <returns></returns>
        public int GetBlue()
        {
            if (Blue < MINIMUM_COLOUR_CHANNEL_VALUE || Blue > MAXIMUM_COLOUR_CHANNEL_VALUE)
            {
                return Blue;
            }
            else
            {
                return MAXIMUM_COLOUR_CHANNEL_VALUE;
            }
        }

        /// <summary>
        /// Sets the alpha.
        /// </summary>
        /// <param name="alphaValue">The alpha value.</param>
        public void SetAlpha(double alphaValue)
        {
            Alpha = alphaValue;
        }

        /// <summary>
        /// Gets the alpha.
        /// </summary>
        /// <returns></returns>
        public double GetAlpha()
        {
            if (Alpha < MINIMUM_ALPHA_CHANNEL_VALUE || Alpha > MAXIMUM_ALPHA_CHANNEL_VALUE)
            {
                return Alpha;
            }
            else
            {
                return 0.5;
            }
        }

        public static bool ConvertStringToBoolean(string text) => bool.Parse(text);
        #endregion
    }
}