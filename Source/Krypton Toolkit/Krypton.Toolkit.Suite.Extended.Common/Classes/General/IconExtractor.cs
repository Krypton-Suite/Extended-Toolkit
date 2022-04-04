#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Common
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

        /// <summary>
        /// 
        /// </summary>
        public enum IconType
        {
            /// <summary>
            /// The warning
            /// </summary>
            WARNING = 101,
            /// <summary>
            /// The help
            /// </summary>
            HELP = 102,
            /// <summary>
            /// The error
            /// </summary>
            ERROR = 103,
            /// <summary>
            /// The information
            /// </summary>
            INFO = 104,
            /// <summary>
            /// The shield
            /// </summary>
            SHIELD = 106
        }
    }
}