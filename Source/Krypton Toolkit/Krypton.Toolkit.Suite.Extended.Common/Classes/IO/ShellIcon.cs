#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Common
{
    /// <summary>
    /// Provides static methods to read system icons for both folders and files.
    /// Summary description for ShellIcon.  Get a small or large Icon with an easy C# function call
    /// that returns a 32x32 or 16x16 System.Drawing.Icon depending on which function you call
    /// either GetSmallIcon(string fileName) or GetLargeIcon(string fileName)
    /// </summary>
    public static class ShellIcon
    {

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szDisplayName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        public class Win32
        {
            public const uint SHGFI_ICON = 0x000000100; // get icon
            public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010; // use passed dwFileAttribute

            public const uint SHGFI_LARGEICON = 0x000000000;
            public const uint SHGFI_SMALLICON = 0x000000001;

            public const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
            public const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;

            [DllImport("shell32.dll")]
            public static extern IntPtr SHGetFileInfo(
                string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi,
                uint cbSizeFileInfo, uint uFlags
            );

            [DllImport("User32.dll")]
            public static extern int DestroyIcon(IntPtr hIcon);
        }




        public static Icon DriveIcon { get; }
        public static Icon FolderIcon { get; }


        static ShellIcon()
        {
            uint flags = Win32.SHGFI_USEFILEATTRIBUTES;
            flags += Win32.SHGFI_LARGEICON;
            DriveIcon = GetIcon(null, Win32.FILE_ATTRIBUTE_DIRECTORY, flags);

            flags = Win32.SHGFI_LARGEICON;
            FolderIcon = GetIcon(null, Win32.FILE_ATTRIBUTE_DIRECTORY, flags);
        }


        public static Icon GetSmallIcon(string fileName)
        {
            return GetIcon(fileName, Win32.FILE_ATTRIBUTE_NORMAL, Win32.SHGFI_SMALLICON);
        }


        public static Icon GetLargeIcon(string fileName) => GetIcon(fileName, Win32.FILE_ATTRIBUTE_NORMAL, Win32.SHGFI_LARGEICON);


        private static Icon GetIcon(string fileName, uint dwAttributes, uint flags)
        {
            SHFILEINFO shinfo = new SHFILEINFO();
            IntPtr hImgSmall = Win32.SHGetFileInfo(fileName, dwAttributes,
                ref shinfo, (uint)Marshal.SizeOf(shinfo),
                Win32.SHGFI_ICON | flags);

            Icon icon = (Icon)Icon.FromHandle(shinfo.hIcon).Clone();
            Win32.DestroyIcon(shinfo.hIcon);
            return icon;
        }
    }
}