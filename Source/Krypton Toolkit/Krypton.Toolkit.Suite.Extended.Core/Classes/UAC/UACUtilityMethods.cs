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

namespace Krypton.Toolkit.Suite.Extended.Core
{
    /// <summary>Utility methods for the user account control.</summary>
    public static class UACUtilityMethods
    {
        #region Methods
        /// <summary>
        /// Elevates the application to use administrative privileges. To be used with <see cref="KryptonUACButtonVersion1"/> or <see cref="ToolStripMenuItemUACSheld"/> button click.
        /// </summary>
        /// <param name="processName">The process name that you wish to elevate.</param>
        public static void ElevateProcessWithAdministrativeRights(string processName)
        {
            WindowsPrincipal principal = new(WindowsIdentity.GetCurrent());

            bool hasAdministrativeRight = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (!hasAdministrativeRight)
            {
                // Relaunch the application with administrative rights
                ProcessStartInfo processStartInfo = new();

                processStartInfo.Verb = "runas";

                processStartInfo.FileName = processName;

                try
                {
                    Process.Start(processStartInfo);
                }
                catch (Win32Exception wexc)
                {
                    ExceptionCapture.CaptureException(wexc);
                }

                return;
            }
        }

        /// <summary>
        /// Checks to see if the current process has launched with administrative rights.
        /// </summary>
        /// <remarks>
        /// Use this method in your 'Load' event.
        /// </remarks>
        /// <returns>True if the current process has launched with administrative rights, false if not.</returns>
        public static bool GetHasElevateProcessWithAdministrativeRights()
        {
            WindowsPrincipal principal = new(WindowsIdentity.GetCurrent());

            bool hasAdministrativeRight = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (hasAdministrativeRight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>Changes the control location.</summary>
        /// <param name="control">The control.</param>
        /// <param name="location">The location.</param>
        public static void ChangeControlLocation(Control control, Point location) => control.Location = location;

        /// <summary>
        /// Bitmaps to image.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns></returns>
        public static Image BitmapToImage(Bitmap bitmap)
        {
            Image tmp = new Bitmap(bitmap);

            return tmp;
        }

        /// <summary>Resize the image to the specified width and height. Copied from: https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp</summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);

            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;

                graphics.CompositingQuality = CompositingQuality.HighQuality;

                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                graphics.SmoothingMode = SmoothingMode.HighQuality;

                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);

                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        #endregion
    }
}