using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Common
{
    public class GraphicsUtilities
    {
        #region Constructor
        public GraphicsUtilities()
        {

        }
        #endregion

        #region Metods
        /// <summary>Extracts the binary icon.</summary>
        /// <param name="binaryFilePath">The binary file path.</param>
        /// <returns></returns>
        public static Image ExtractBinaryIcon(string binaryFilePath) => Icon.ExtractAssociatedIcon(binaryFilePath).ToBitmap();

        public static void GrabFavIcon(PictureBox container, string url)
        {
            container.ImageLocation = url + "/favicon.ico";

            container.SizeMode = PictureBoxSizeMode.CenterImage;
        }
        #endregion
    }
}