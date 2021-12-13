#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Specialised.Dialogs
{
    /// <summary>Provides useful methods for specified tasks.</summary>
    public class UtilityMethods
    {
        #region Constructor
        /// <summary>
        /// Initialises a new instance of <see cref="UtilityMethods"/>.
        /// </summary>
        public UtilityMethods()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Elevates the application to use administrative privileges. To be used with <see cref="Krypton.Toolkit.Suite.Extended.Buttons.KryptonUACElevatedButton"/> or <see cref="Krypton.Toolkit.Suite.Extended.Tool.Strip.Items.ToolStripMenuItemUACSheld"/> button click.
        /// </summary>
        /// <param name="processName">The process name that you wish to elevate.</param>
        public static void ElevateProcessWithAdministrativeRights(string processName)
        {
            WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

            bool hasAdministrativeRight = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (!hasAdministrativeRight)
            {
                // Relaunch the application with administrative rights
                ProcessStartInfo processStartInfo = new ProcessStartInfo();

                processStartInfo.Verb = "runas";

                processStartInfo.FileName = processName;

                try
                {
                    Process.Start(processStartInfo);
                }
                catch (Win32Exception wexc)
                {
                    KryptonMessageBox.Show("Error: " + wexc.Message, "An Error has Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

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