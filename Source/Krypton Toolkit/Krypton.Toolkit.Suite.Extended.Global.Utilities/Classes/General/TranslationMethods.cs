﻿#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Global.Utilities
{
    /// <summary>
    /// Some translation methods.
    /// </summary>
    public class TranslationMethods
    {
        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationMethods"/> class.
        /// </summary>
        public TranslationMethods()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Parses the boolean.
        /// </summary>
        /// <param name="booleanInput">The boolean input.</param>
        /// <returns></returns>
        public bool ParseBoolean(string booleanInput)
        {
            return bool.Parse(booleanInput.ToLower());
        }

        /// <summary>
        /// Parses the date time.
        /// </summary>
        /// <param name="dateTimeInput">The date time input.</param>
        /// <returns></returns>
        public DateTime ParseDateTime(string dateTimeInput)
        {
            return DateTime.Parse(dateTimeInput);
        }

        /// <summary>
        /// Parses the long.
        /// </summary>
        /// <param name="longInput">The long input.</param>
        /// <returns></returns>
        public long ParseLong(string longInput)
        {
            return long.Parse(longInput);
        }

        /// <summary>
        /// Parses the integer.
        /// </summary>
        /// <param name="integerInput">The integer input.</param>
        /// <returns></returns>
        public int ParseInteger(string integerInput)
        {
            return int.Parse(integerInput);
        }

        /// <summary>
        /// Parses the version.
        /// </summary>
        /// <param name="versionInput">The version input.</param>
        /// <returns></returns>
        public Version ParseVersion(string versionInput)
        {
            return Version.Parse(versionInput);
        }

        /// <summary>
        /// Translates the colour to ARGB.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        public static string TranslateColourToARGB(Color colour)
        {
            return $"ARGB: ({colour.A}, {colour.R}, {colour.G}, {colour.B})";
        }

        /// <summary>
        /// Translates the colour to RGB.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        public static string TranslateColourToRGB(Color colour)
        {
            return $"RGB: ({colour.R}, {colour.G}, {colour.B})";
        }

        /// <summary>
        /// Translates the colour to hexadecinal.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        public static string TranslateColourToHexadecimal(Color colour)
        {
            return $"Hexadecimal Value: #{ConvertRGBToHexadecimal(Convert.ToInt32(colour.R), Convert.ToInt32(colour.G), Convert.ToInt32(colour.B)).ToUpper()}";
        }

        /// <summary>
        /// Gets the colour brightness.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        public static string GetColourBrightness(Color colour)
        {
            return $"Brightness: {Convert.ToInt32(colour.GetBrightness()).ToString()}";
        }

        /// <summary>
        /// Gets the colour hue.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        public static string GetColourHue(Color colour)
        {
            return $"Hue: {colour.GetHue().ToString()}";
        }

        /// <summary>
        /// Gets the colour saturation.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        public static string GetColourSaturation(Color colour)
        {
            return $"Saturation: {colour.GetSaturation().ToString()}";
        }

        /// <summary>
        /// Converts the RGB to hexadecimal.
        /// </summary>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        /// <returns></returns>
        private static string ConvertRGBToHexadecimal(int red, int green, int blue)
        {
            return ColorTranslator.FromHtml(String.Format("#{0:X2}{1:X2}{2:X2}", red, green, blue)).Name.Remove(0, 1);
        }

        /// <summary>
        /// Gets the name of the known colour.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        public static string GetKnownColourName(Color colour)
        {
            return colour.ToKnownColor().ToString();
        }

        /// <summary>
        /// Gets the name of the colour.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        public static string GetColourName(Color colour) => colour.Name;

        /// <summary>
        /// Returns the safe file name date time string.
        /// </summary>
        /// <param name="format">The format.
        /// Syntax:-
        /// dd - The current day of week.
        /// MM - The current Month.
        /// yy or yyyy - The current year.
        /// HH - The current hour.
        /// mm - The current minute.
        /// tt - Only use this for a 12-hour clock (AM/PM).
        /// </param>
        /// <returns></returns>
        public static string ReturnSafeFileNameDateTimeString(string format = "dd-MM-yyyy HH-mm-ss-tt") => $"{DateTime.Now.ToString(format)}";

        /// <summary>
        /// Colours the string to ARGB.
        /// </summary>
        /// <param name="argbString">The ARGB string.</param>
        /// <returns></returns>
        public static Color ColourStringToARGB(string argbString) => Color.FromArgb(Convert.ToInt32(argbString));

        /// <summary>
        /// Colours the ARGB to string.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        public static string ColourARGBToString(Color colour) => $"{colour.A},{colour.R},{colour.G},{colour.B}";

        /// <summary>
        /// RGBs the colour to string.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <returns></returns>
        public static string RGBColourToString(Color colour) => $"{Convert.ToString(colour.R)},{Convert.ToString(colour.G)},{Convert.ToString(colour.B)}";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputColour"></param>
        /// <returns></returns>
        public static Color RGBStringToColour(string inputColour)
        {
            string[] rgbString = inputColour.Split(',');

            int[] rgbValues = new int[3];

            rgbValues = Array.ConvertAll<string, int>(rgbString, int.Parse);

            return Color.FromArgb(rgbValues[0], rgbValues[1], rgbValues[2]);
        }

        /// <summary>
        /// Determines whether the specified input is hexadecimal.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if the specified input is hexadecimal; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsHexadecimal(string input)
        {
            Regex validCharacters = new("^[a-fA-F0-9]+$");

            bool isValid = false;

            if (string.IsNullOrWhiteSpace(input))
            {
                isValid = false;
            }
            else
            {
                isValid = validCharacters.IsMatch(input);
            }

            return isValid;
        }

        public static string[] ObjectCollectionToArray(ComboBox.ObjectCollection items)
        {
            string[] tmp;

            StringCollection stringCollection = new();

            List<string> itemList = new();

            foreach (string item in items)
            {
                stringCollection.Add(item);
            }

            foreach (string item2 in stringCollection)
            {
                itemList.Add(item2);
            }

            tmp = itemList.ToArray();

            return tmp;
        }
        #endregion
    }
}