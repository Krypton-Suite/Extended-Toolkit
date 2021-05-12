#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    /// <summary>
    /// Provides a method for extracting images from the system via LoadImage
    /// </summary>
    internal static class IconExtractor
    {
        /// <summary>
        /// Loads the icon.
        /// </summary>
        /// <param name="type">The type of icon.</param>
        /// <param name="size">The size.</param>
        /// <returns>The icon.</returns>
        /// <exception cref="System.PlatformNotSupportedException"></exception>
        public static Icon LoadIcon(IconType type, Size size)
        {
            IntPtr hIcon = NativeMethods.LoadImage(IntPtr.Zero, "#" + (int)type, 1, size.Width, size.Height, 0);
            return hIcon == IntPtr.Zero ? null : Icon.FromHandle(hIcon);
        }

        public enum IconType
        {
            Warning = 101,
            Help = 102,
            Error = 103,
            Info = 104,
            Shield = 106
        }
    }
}