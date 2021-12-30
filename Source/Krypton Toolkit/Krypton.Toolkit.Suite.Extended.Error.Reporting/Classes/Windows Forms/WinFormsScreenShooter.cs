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