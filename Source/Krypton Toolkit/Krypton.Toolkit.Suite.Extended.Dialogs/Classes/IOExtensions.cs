

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    internal class IOExtensions
    {
        #region Identity

        /// <summary>Initializes a new instance of the <see cref="IOExtensions" /> class.</summary>
        public IOExtensions()
        {

        }

        #endregion

        #region Implementation

        internal static Image? ExtractIconFromFilePath(string filePath)
        {
            Image? icon = null;

            try
            {
                //Icon i = new Icon().

                //icon = i.
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);
            }

            return icon;
        }

        /// <summary>Gets the fav icon.</summary>
        /// <param name="targetControl">The target control.</param>
        /// <param name="url">The URL.</param>
        /// <param name="sizeMode">The size mode.</param>
        internal static void GetFavIcon(PictureBox targetControl, string url, PictureBoxSizeMode sizeMode = PictureBoxSizeMode.CenterImage)
        {
            try
            {
                targetControl.ImageLocation = $"{url}/favicon.ico";

                targetControl.SizeMode = sizeMode;
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);
            }
        }

        #endregion
    }
}