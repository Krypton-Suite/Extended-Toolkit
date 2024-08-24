#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// Utility to take a screenshot and return as a graphic file 
    /// </summary>
    internal class WinFormsScreenShooter : IScreenShooter
    {
        private const string ScreenshotFileName = "exceptionreport-screenshot.jpg";

        /// <summary> Take a screenshot (supports multiple monitors) </summary>
        /// <returns>temp file name of JPEG image</returns>
        public string TakeScreenShot()
        {
            var rectangle = Rectangle.Empty;

            foreach (var screen in Screen.AllScreens)
            {
                rectangle = Rectangle.Union(rectangle, screen.Bounds);
            }

            using (var bitmap = new Bitmap(rectangle.Width, rectangle.Height, PixelFormat.Format32bppArgb))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(rectangle.X, rectangle.Y, 0, 0, rectangle.Size, CopyPixelOperation.SourceCopy);
                }

                return GetImageAsFile(bitmap);
            }
        }

        /// <summary>
        /// Return the supplied Bitmap, as a file on the system, in JPEG format
        /// </summary>
        /// <param name="bitmap">The Bitmap to save</param>
        private static string GetImageAsFile(Image bitmap)
        {
            var tempFileName = Path.GetTempPath() + ScreenshotFileName; // image is not deleted but same file is reused
            bitmap.Save(tempFileName, ImageFormat.Jpeg);
            return tempFileName;
        }
    }
}