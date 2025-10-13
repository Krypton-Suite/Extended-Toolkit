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

namespace Krypton.Toolkit.Suite.Extended.Common;

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
        IntPtr hIcon = CommonNativeMethods.LoadImage(IntPtr.Zero, $"#{(int) type}", 1, size.Width, size.Height, 0);

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