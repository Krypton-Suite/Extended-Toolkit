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

namespace Krypton.Toolkit.Suite.Extended.Common
{
    public class Utility
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
        public static StringFormat GetStringFormat(ContentAlignment contentAlignment)
        {
            if (!Enum.IsDefined(typeof(ContentAlignment), (int)contentAlignment))
            {
                throw new System.ComponentModel.InvalidEnumArgumentException(
                    "contentAlignment", (int)contentAlignment, typeof(ContentAlignment));
            }

            StringFormat stringFormat = new StringFormat();

            switch (contentAlignment)
            {
                case ContentAlignment.MiddleCenter:
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Center;
                    break;

                case ContentAlignment.MiddleLeft:
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Near;
                    break;

                case ContentAlignment.MiddleRight:
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Far;
                    break;

                case ContentAlignment.TopCenter:
                    stringFormat.LineAlignment = StringAlignment.Near;
                    stringFormat.Alignment = StringAlignment.Center;
                    break;

                case ContentAlignment.TopLeft:
                    stringFormat.LineAlignment = StringAlignment.Near;
                    stringFormat.Alignment = StringAlignment.Near;
                    break;

                case ContentAlignment.TopRight:
                    stringFormat.LineAlignment = StringAlignment.Near;
                    stringFormat.Alignment = StringAlignment.Far;
                    break;

                case ContentAlignment.BottomCenter:
                    stringFormat.LineAlignment = StringAlignment.Far;
                    stringFormat.Alignment = StringAlignment.Center;
                    break;

                case ContentAlignment.BottomLeft:
                    stringFormat.LineAlignment = StringAlignment.Far;
                    stringFormat.Alignment = StringAlignment.Near;
                    break;

                case ContentAlignment.BottomRight:
                    stringFormat.LineAlignment = StringAlignment.Far;
                    stringFormat.Alignment = StringAlignment.Far;
                    break;
            }

            return stringFormat;
        }

        /// <summary>Repositions the control.</summary>
        /// <param name="targetControl">The target control.</param>
        /// <param name="xPosition">The x position.</param>
        /// <param name="yPosition">The y position.</param>
        /// <returns></returns>
        public static Point RepositionControl(Control targetControl, int xPosition, int yPosition) => targetControl.Location = new Point(xPosition, yPosition);
    }
}