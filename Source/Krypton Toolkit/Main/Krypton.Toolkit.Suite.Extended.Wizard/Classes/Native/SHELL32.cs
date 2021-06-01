#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    [SuppressUnmanagedCodeSecurity]
    internal static partial class NativeMethods
    {
        internal const string SHELL32 = "shell32.dll";

        [Flags]
        public enum KF_FLAG : uint
        {
            ALIAS_ONLY = 0x80000000,
            CREATE = 0x8000,
            DEFAULT = 0,
            DEFAULT_PATH = 0x400,
            DONT_UNEXPAND = 0x2000,
            DONT_VERIFY = 0x4000,
            INIT = 0x800,
            NO_ALIAS = 0x1000,
            NOT_PARENT_RELATIVE = 0x200,
            SIMPLE_IDLIST = 0x100
        }

        public enum SHARD
        {
            APPIDINFO = 4,
            APPIDINFOIDLIST = 5,
            APPIDINFOLINK = 7,
            LINK = 6,
            PATHA = 2,
            PATHW = 3,
            PIDL = 1,
            SHELLITEM = 8
        }

        [Flags]
        public enum ShellExecuteMaskFlags : uint
        {
            SEE_MASK_DEFAULT = 0x00000000,
            SEE_MASK_CLASSNAME = 0x00000001,
            SEE_MASK_CLASSKEY = 0x00000003,
            SEE_MASK_IDLIST = 0x00000004,
            SEE_MASK_INVOKEIDLIST = 0x0000000c,   // Note SEE_MASK_INVOKEIDLIST(0xC) implies SEE_MASK_IDLIST(0x04)
            SEE_MASK_HOTKEY = 0x00000020,
            SEE_MASK_NOCLOSEPROCESS = 0x00000040,
            SEE_MASK_CONNECTNETDRV = 0x00000080,
            SEE_MASK_NOASYNC = 0x00000100,
            SEE_MASK_FLAG_DDEWAIT = SEE_MASK_NOASYNC,
            SEE_MASK_DOENVSUBST = 0x00000200,
            SEE_MASK_FLAG_NO_UI = 0x00000400,
            SEE_MASK_UNICODE = 0x00004000,
            SEE_MASK_NO_CONSOLE = 0x00008000,
            SEE_MASK_ASYNCOK = 0x00100000,
            SEE_MASK_HMONITOR = 0x00200000,
            SEE_MASK_NOZONECHECKS = 0x00800000,
            SEE_MASK_NOQUERYCLASSSTORE = 0x01000000,
            SEE_MASK_WAITFORINPUTIDLE = 0x02000000,
            SEE_MASK_FLAG_LOG_USAGE = 0x04000000,
        }

        [Flags]
        public enum SHGFI : int
        {
            /// <summary>get icon</summary>
            Icon = 0x000000100,

            /// <summary>get display name</summary>
            DisplayName = 0x000000200,

            /// <summary>get type name</summary>
            TypeName = 0x000000400,

            /// <summary>get attributes</summary>
            Attributes = 0x000000800,

            /// <summary>get icon location</summary>
            IconLocation = 0x000001000,

            /// <summary>return executable type</summary>
            ExeType = 0x000002000,

            /// <summary>get system icon index</summary>
            SysIconIndex = 0x000004000,

            /// <summary>put a link overlay on icon</summary>
            LinkOverlay = 0x000008000,

            /// <summary>show icon in selected state</summary>
            Selected = 0x000010000,

            /// <summary>get only specified attributes</summary>
            Attr_Specified = 0x000020000,

            /// <summary>get large icon</summary>
            LargeIcon = 0x000000000,

            /// <summary>get small icon</summary>
            SmallIcon = 0x000000001,

            /// <summary>get open icon</summary>
            OpenIcon = 0x000000002,

            /// <summary>get shell size icon</summary>
            ShellIconSize = 0x000000004,

            /// <summary>pszPath is a PIDL</summary>
            PIDL = 0x000000008,

            /// <summary>use passed dwFileAttribute</summary>
            UseFileAttributes = 0x000000010,

            /// <summary>apply the appropriate overlays</summary>
            AddOverlays = 0x000000020,

            /// <summary>Get the index of the overlay in the upper 8 bits of the iIcon</summary>
            OverlayIndex = 0x000000040,
        }

        public enum ShowCommands : int
        {
            SW_HIDE = 0,
            SW_SHOWNORMAL = 1,
            SW_NORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3,
            SW_MAXIMIZE = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10,
            SW_FORCEMINIMIZE = 11,
            SW_MAX = 11
        }

        [DllImport(SHELL32, CharSet = CharSet.Auto)]
        public extern static int ExtractIconEx([MarshalAs(UnmanagedType.LPTStr)] string lpszFile, int nIconIndex, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] IntPtr[] phIconLarge, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] IntPtr[] phIconSmall, int nIcons);

        /// <summary> Retrieves the User Model AppID that has been explicitly set for the current process via SetCurrentProcessExplicitAppUserModelID</summary>
        /// <param name="AppID">The application ID</param>
        [DllImport(SHELL32)]
        public static extern HRESULT GetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)] out string AppID);

        /// <summary> Sets the User Model AppID for the current process, enabling Windows to retrieve this ID </summary>
        /// <param name="AppID">The application ID</param>
        [DllImport(SHELL32, PreserveSig = false)]
        public static extern void SetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)] string AppID);

        // This overload is required. There's a cast in the Shell code that causes the wrong vtbl to be used if we let
        // the marshaller convert the parameter to an IUnknown.
        ///<securitynote>
        ///     Critical - elevates via a SUC.
        ///</securitynote>
        [DllImport(SHELL32, EntryPoint = "SHAddToRecentDocs")]
        [SecurityCritical, SuppressUnmanagedCodeSecurity]
        public static extern void SHAddToRecentDocs(SHARD uFlags, IShellLinkW pv);

        ///<securitynote>
        ///     Critical - elevates via a SUC.
        ///</securitynote>
        [DllImport(SHELL32, EntryPoint = "SHAddToRecentDocs")]
        [SecurityCritical, SuppressUnmanagedCodeSecurity]
        public static extern void SHAddToRecentDocs(SHARD uFlags, [MarshalAs(UnmanagedType.LPWStr)] string pv);

        // Vista only
        ///<securitynote>
        ///     Critical - elevates via a SUC.
        ///</securitynote>
        [DllImport(SHELL32, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        [SecurityCritical, SuppressUnmanagedCodeSecurity]
        public static extern void SHCreateItemFromParsingName([MarshalAs(UnmanagedType.LPWStr)] string pszPath, [MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.Interface)] out IShellItem ppv);

        // Vista only
        ///<securitynote>
        ///     Critical - elevates via a SUC.
        ///</securitynote>
        [DllImport(SHELL32, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        [SecurityCritical, SuppressUnmanagedCodeSecurity]
        public static extern void SHCreateItemFromParsingName([MarshalAs(UnmanagedType.LPWStr)] string pszPath, [MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, [MarshalAs(UnmanagedType.Interface)] out IShellItem2 ppv);

        [DllImport(SHELL32, CharSet = CharSet.Auto)]
        public static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        [DllImport(SHELL32, CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int SHGetFileInfo(string pszPath, System.IO.FileAttributes dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, SHGFI uFlags);

        [DllImport(SHELL32, CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int SHGetFileInfo(IntPtr itemIdList, System.IO.FileAttributes dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, SHGFI uFlags);

        // Vista only. Also inconsistently documented on MSDN. It was available in some versions of the SDK, and it
        // mentioned on several pages, but isn't specifically documented.
        ///<securitynote>
        ///     Critical - elevates via a SUC.
        ///</securitynote>
        [DllImport(SHELL32)]
        [SecurityCritical, SuppressUnmanagedCodeSecurity]
        public static extern HRESULT SHGetFolderPathEx([In] ref Guid rfid, KF_FLAG dwFlags, [In, Optional] IntPtr hToken, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszPath, uint cchPath);

        [DllImport(SHELL32, CharSet = CharSet.Unicode, PreserveSig = false, SetLastError = true)]
        public static extern void SHGetIDListFromObject(IntPtr iUnknown, out IntPtr ppidl);

        // Note that the BROWSEINFO object's pszDisplayName only gives you the name of the folder. To get the actual
        // folderToSelect, you need to parse the returned PIDL
        [DllImport(SHELL32, CharSet = CharSet.Unicode)]
        public static extern uint SHGetPathFromIDList(IntPtr pidl, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszPath);

        [DllImport(SHELL32, CharSet = CharSet.Unicode, SetLastError = false)]
        public static extern int SHGetSpecialFolderLocation(IntPtr hwndOwner, int nFolder, out IntPtr ppidl);

        [DllImport(SHELL32, SetLastError = true)]
        public static extern int SHOpenFolderAndSelectItems(IntPtr pidlFolder, uint cidl, [In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl, uint dwFlags);

        [DllImport(SHELL32, CharSet = CharSet.Unicode, SetLastError = false)]
        public static extern int SHParseDisplayName([MarshalAs(UnmanagedType.LPWStr)] string pszName, IntPtr pbc, out IntPtr ppidl, uint sfgaoIn, out uint psfgaoOut);

        [StructLayout(LayoutKind.Sequential)]
        public struct ITEMIDLIST
        {
            /// <summary>A list of item identifiers.</summary>
            [MarshalAs(UnmanagedType.Struct)]
            public SHITEMID mkid;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SHELLEXECUTEINFO
        {
            public int cbSize;
            public ShellExecuteMaskFlags fMask;
            public IntPtr hwnd;

            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;

            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;

            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;

            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;

            public ShowCommands nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;

            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;

            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public int dwAttributes;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SHITEMID
        {
            /// <summary>The size of identifier, in bytes, including <see cref="cb"/> itself.</summary>
            public ushort cb;

            /// <summary>A variable-length item identifier.</summary>
            public byte[] abID;
        }
    }
}
