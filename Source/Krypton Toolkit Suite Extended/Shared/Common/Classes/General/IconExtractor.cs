using System;
using System.Drawing;

namespace Krypton.Toolkit.Extended.Common
{
    public class IconExtractor
    {
        #region Constructor
        public IconExtractor()
        {

        }
        #endregion

        #region Methods        
        /// <summary>
        /// Extracts the icon.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static Bitmap ExtractIcon(string path) => Icon.ExtractAssociatedIcon(path).ToBitmap();

        /// <summary>
        /// Extracts the icon from file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static Icon ExtractIconFromFile(string path) => Icon.ExtractAssociatedIcon(path);

        /// <summary>
        /// Loads the icon.
        /// </summary>
        /// <param name="type">The type of icon.</param>
        /// <param name="size">The size.</param>
        /// <returns>The icon.</returns>
        /// <exception cref="System.PlatformNotSupportedException"></exception>
        public static Icon LoadIcon(IconType type, Size size)
        {
            IntPtr hIcon = CommonNativeMethods.LoadImage(IntPtr.Zero, "#" + (int)type, 1, size.Width, size.Height, 0);

            return hIcon == IntPtr.Zero ? null : Icon.FromHandle(hIcon);
        }
        #endregion
    }
}