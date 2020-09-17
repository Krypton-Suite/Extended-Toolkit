using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    /// <summary>
    ///   <a href="https://stackoverflow.com/questions/42910628/is-there-a-way-to-get-the-windows-default-folder-icon-using-c">
    ///     <u>
    ///       <font color="#0066cc">https://stackoverflow.com/questions/42910628/is-there-a-way-to-get-the-windows-default-folder-icon-using-c</font>
    ///     </u>
    ///   </a>
    /// </summary>
    public class IconExtractor
    {
        #region Structs
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;

            public int iIcon;

            public uint dwAttributes;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };
        #endregion

        #region WIN32 Calls
        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        #endregion

        #region Constants
        private const uint SHGFI_ICON = 0x100;
        private const uint SHGFI_LARGEICON = 0x0;
        private const uint SHGFI_SMALLICON = 0x000000001;
        #endregion

        #region Variable
        private static readonly Lazy<Icon> _lazyFolderIcon = new Lazy<Icon>(FetchIcon, true);
        #endregion

        #region Property
        public static Icon FolderLargeIcon { get => _lazyFolderIcon.Value; }
        #endregion

        #region Methods
        public static Icon FetchIcon()
        {
            string tempDirectory = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString())).FullName;

            Icon icon = ExtractIconFromPath(tempDirectory);

            Directory.Delete(tempDirectory);

            return icon;
        }

        public static Icon ExtractIconFromPath(string path, bool useSmallIcon = true)
        {
            SHFILEINFO shInfo = new SHFILEINFO();

            if (useSmallIcon)
            {
                SHGetFileInfo(path, 0, ref shInfo, (uint)Marshal.SizeOf(shInfo), SHGFI_ICON | SHGFI_SMALLICON);
            }
            else
            {
                SHGetFileInfo(path, 0, ref shInfo, (uint)Marshal.SizeOf(shInfo), SHGFI_ICON | SHGFI_LARGEICON);
            }

            return Icon.FromHandle(shInfo.hIcon);
        }
        #endregion
    }
}