#region MIT License
/*
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

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    internal class Utility
    {
        /// <summary>
        /// Determines whether [is windows seven or above].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is windows seven or above]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWindowsSevenOrAbove()
        {
            bool result = false;

            Version currentOSVersion = Environment.OSVersion.Version;

            if (currentOSVersion.Major >= 6 && currentOSVersion.Minor >= 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public static bool IsVista()
        {
            // Check OS Before using XP drop shadow
            bool result = false;
            Version OSVer = Environment.OSVersion.Version;
            if (OSVer.Major >= 6)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static StringFormat GetStringFormat(System.Drawing.ContentAlignment contentAlignment)
        {
            if (!Enum.IsDefined(typeof(System.Drawing.ContentAlignment), (int)contentAlignment))
                throw new System.ComponentModel.InvalidEnumArgumentException(
                    "contentAlignment", (int)contentAlignment, typeof(System.Drawing.ContentAlignment));

            StringFormat stringFormat = new StringFormat();

            switch (contentAlignment)
            {
                case System.Drawing.ContentAlignment.MiddleCenter:
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Center;
                    break;

                case System.Drawing.ContentAlignment.MiddleLeft:
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Near;
                    break;

                case System.Drawing.ContentAlignment.MiddleRight:
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Far;
                    break;

                case System.Drawing.ContentAlignment.TopCenter:
                    stringFormat.LineAlignment = StringAlignment.Near;
                    stringFormat.Alignment = StringAlignment.Center;
                    break;

                case System.Drawing.ContentAlignment.TopLeft:
                    stringFormat.LineAlignment = StringAlignment.Near;
                    stringFormat.Alignment = StringAlignment.Near;
                    break;

                case System.Drawing.ContentAlignment.TopRight:
                    stringFormat.LineAlignment = StringAlignment.Near;
                    stringFormat.Alignment = StringAlignment.Far;
                    break;

                case System.Drawing.ContentAlignment.BottomCenter:
                    stringFormat.LineAlignment = StringAlignment.Far;
                    stringFormat.Alignment = StringAlignment.Center;
                    break;

                case System.Drawing.ContentAlignment.BottomLeft:
                    stringFormat.LineAlignment = StringAlignment.Far;
                    stringFormat.Alignment = StringAlignment.Near;
                    break;

                case System.Drawing.ContentAlignment.BottomRight:
                    stringFormat.LineAlignment = StringAlignment.Far;
                    stringFormat.Alignment = StringAlignment.Far;
                    break;
            }

            return stringFormat;
        }
    }
}