#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class ShellAPI
    {
        #region Constants

        public const Int32 FILE_ATTRIBUTE_NORMAL = 0x80;
        public static Guid IID_IShellFolder = new Guid("000214E6-0000-0000-C000-000000000046");

        #endregion

        #region DLL Imports

        [DllImport("user32.dll")]
        public static extern Int32 SendMessage(IntPtr pWnd, UInt32 uMsg, UInt32 wParam, IntPtr lParam);

        [DllImport("shell32.dll")]
        public static extern Int32 SHGetDesktopFolder(ref IShellFolder ppshf);

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttribs, ref SHFILEINFO psfi, uint cbFileInfo, SHGFI uFlags);

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(IntPtr pIDL, uint dwFileAttributes, out SHFILEINFO psfi, uint cbFileInfo, SHGFI uFlags);

        [DllImport("shell32.dll")]
        public static extern Int32 SHGetSpecialFolderLocation(IntPtr hwndOwner, CSIDL nFolder, ref IntPtr ppidl);

        [DllImport("shell32.dll")]
        public static extern IntPtr ILCombine(IntPtr pIDLParent, IntPtr pIDLChild);

        [DllImport("shell32.dll")]
        public static extern Int32 SHGetPathFromIDList(IntPtr pIDL, StringBuilder strPath);

        #endregion

        #region Enumerations

        [Flags]
        public enum SHGNO : uint
        {
            SHGDN_NORMAL = 0x0000,                 // Default (display purpose)
            SHGDN_INFOLDER = 0x0001,               // Displayed under a folder (relative)
            SHGDN_FOREDITING = 0x1000,             // For in-place editing
            SHGDN_FORADDRESSBAR = 0x4000,          // UI friendly parsing name (remove ugly stuff)
            SHGDN_FORPARSING = 0x8000,             // Parsing name for ParseDisplayName()
        }

        [Flags]
        public enum SHCONTF : uint
        {
            SHCONTF_FOLDERS = 0x0020,              // Only want folders enumerated (SFGAO_FOLDER)
            SHCONTF_NONFOLDERS = 0x0040,           // Include non folders
            SHCONTF_INCLUDEHIDDEN = 0x0080,        // Show items normally hidden
            SHCONTF_INIT_ON_FIRST_NEXT = 0x0100,   // Allow EnumObject() to return before validating enum
            SHCONTF_NETPRINTERSRCH = 0x0200,       // Hint that client is looking for printers
            SHCONTF_SHAREABLE = 0x0400,            // Hint that client is looking sharable resources (remote shares)
            SHCONTF_STORAGE = 0x0800,              // Include all items with accessible storage and their ancestors
        }

        [Flags]
        public enum SFGAOF : uint
        {
            SFGAO_CANCOPY = 0x1,                   // Objects can be copied  (DROPEFFECT_COPY)
            SFGAO_CANMOVE = 0x2,                   // Objects can be moved   (DROPEFFECT_MOVE)
            SFGAO_CANLINK = 0x4,                   // Objects can be linked  (DROPEFFECT_LINK)
            SFGAO_STORAGE = 0x00000008,            // Supports BindToObject(IID_IStorage)
            SFGAO_CANRENAME = 0x00000010,          // Objects can be renamed
            SFGAO_CANDELETE = 0x00000020,          // Objects can be deleted
            SFGAO_HASPROPSHEET = 0x00000040,       // Objects have property sheets
            SFGAO_DROPTARGET = 0x00000100,         // Objects are drop target
            SFGAO_CAPABILITYMASK = 0x00000177,
            SFGAO_ENCRYPTED = 0x00002000,          // Object is encrypted (use alt color)
            SFGAO_ISSLOW = 0x00004000,             // 'Slow' object
            SFGAO_GHOSTED = 0x00008000,            // Ghosted icon
            SFGAO_LINK = 0x00010000,               // Shortcut (link)
            SFGAO_SHARE = 0x00020000,              // Shared
            SFGAO_READONLY = 0x00040000,           // Read-only
            SFGAO_HIDDEN = 0x00080000,             // Hidden object
            SFGAO_DISPLAYATTRMASK = 0x000FC000,
            SFGAO_FILESYSANCESTOR = 0x10000000,    // May contain children with SFGAO_FILESYSTEM
            SFGAO_FOLDER = 0x20000000,             // Support BindToObject(IID_IShellFolder)
            SFGAO_FILESYSTEM = 0x40000000,         // Is a win32 file system object (file/folder/root)
            SFGAO_HASSUBFOLDER = 0x80000000,       // May contain children with SFGAO_FOLDER
            SFGAO_CONTENTSMASK = 0x80000000,
            SFGAO_VALIDATE = 0x01000000,           // Invalidate cached information
            SFGAO_REMOVABLE = 0x02000000,          // Is this removeable media?
            SFGAO_COMPRESSED = 0x04000000,         // Object is compressed (use alt color)
            SFGAO_BROWSABLE = 0x08000000,          // Supports IShellFolder, but only implements CreateViewObject() (non-folder view)
            SFGAO_NONENUMERATED = 0x00100000,      // Is a non-enumerated object
            SFGAO_NEWCONTENT = 0x00200000,         // Should show bold in explorer tree
            SFGAO_CANMONIKER = 0x00400000,         // Defunct
            SFGAO_HASSTORAGE = 0x00400000,         // Defunct
            SFGAO_STREAM = 0x00400000,             // Supports BindToObject(IID_IStream)
            SFGAO_STORAGEANCESTOR = 0x00800000,    // May contain children with SFGAO_STORAGE or SFGAO_STREAM
            SFGAO_STORAGECAPMASK = 0x70C50008,     // For determining storage capabilities, ie for open/save semantics
        }

        [Flags]
        public enum STRRET : uint
        {
            STRRET_WSTR = 0,
            STRRET_OFFSET = 0x1,
            STRRET_CSTR = 0x2,
        }

        [Flags]
        public enum SHGFI
        {
            SHGFI_ICON = 0x000000100,
            SHGFI_DISPLAYNAME = 0x000000200,
            SHGFI_TYPENAME = 0x000000400,
            SHGFI_ATTRIBUTES = 0x000000800,
            SHGFI_ICONLOCATION = 0x000001000,
            SHGFI_EXETYPE = 0x000002000,
            SHGFI_SYSICONINDEX = 0x000004000,
            SHGFI_LINKOVERLAY = 0x000008000,
            SHGFI_SELECTED = 0x000010000,
            SHGFI_ATTR_SPECIFIED = 0x000020000,
            SHGFI_LARGEICON = 0x000000000,
            SHGFI_SMALLICON = 0x000000001,
            SHGFI_OPENICON = 0x000000002,
            SHGFI_SHELLICONSIZE = 0x000000004,
            SHGFI_PIDL = 0x000000008,
            SHGFI_USEFILEATTRIBUTES = 0x000000010,
            SHGFI_ADDOVERLAYS = 0x000000020,
            SHGFI_OVERLAYINDEX = 0x000000040
        }

        [Flags]
        public enum CSIDL : uint
        {
            CSIDL_DESKTOP = 0x0000,
            CSIDL_WINDOWS = 0x0024
        }

        #endregion

        #region Structures

        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        #endregion

        #region Interfaces

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("000214E6-0000-0000-C000-000000000046")]
        public interface IShellFolder
        {
            // Translates a file object's or folder's display name into an item identifier list.
            // Return value: error code, if any
            [PreserveSig()]
            uint ParseDisplayName(
                IntPtr hwnd,             // Optional window handle
                IntPtr pbc,              // Optional bind context that controls the parsing operation. This parameter is normally set to NULL. 
                [In(), MarshalAs(UnmanagedType.LPWStr)]
                string pszDisplayName,   // Null-terminated UNICODE string with the display name.
                out uint pchEaten,       // Pointer to a ULONG value that receives the number of characters of the display name that was parsed.
                out IntPtr ppidl,        // Pointer to an ITEMIDLIST pointer that receives the item identifier list for the object.
                ref uint pdwAttributes); // Optional parameter that can be used to query for file attributes. This can be values from the SFGAO enum

            // Allows a client to determine the contents of a folder by creating an item identifier enumeration object and returning its IEnumIDList interface.
            // Return value: error code, if any
            [PreserveSig()]
            uint EnumObjects(
                IntPtr hwnd,                    // If user input is required to perform the enumeration, this window handle should be used by the enumeration object as the parent window to take user input.
                SHCONTF grfFlags,               // Flags indicating which items to include in the enumeration. For a list of possible values, see the SHCONTF enum. 
                out IEnumIDList ppenumIDList);  // Address that receives a pointer to the IEnumIDList interface of the enumeration object created by this method. 

            // Retrieves an IShellFolder object for a subfolder.
            // Return value: error code, if any
            [PreserveSig()]
            uint BindToObject(
                IntPtr pidl,            // Address of an ITEMIDLIST structure (PIDL) that identifies the subfolder.
                IntPtr pbc,             // Optional address of an IBindCtx interface on a bind context object to be used during this operation.
                [In()]
                ref Guid riid,          // Identifier of the interface to return. 
                out IShellFolder ppv);        // Address that receives the interface pointer.

            // Requests a pointer to an object's storage interface. 
            // Return value: error code, if any
            [PreserveSig()]
            uint BindToStorage(
                IntPtr pidl,            // Address of an ITEMIDLIST structure that identifies the subfolder relative to its parent folder. 
                IntPtr pbc,             // Optional address of an IBindCtx interface on a bind context object to be used during this operation.
                [In()]
                ref Guid riid,          // Interface identifier (IID) of the requested storage interface.
                [MarshalAs(UnmanagedType.Interface)]
                out object ppv);        // Address that receives the interface pointer specified by riid.

            // Determines the relative order of two file objects or folders, given their item identifier lists. 
            // Return value: If this method is successful, the CODE field of the HRESULT contains one of the following values (the code can be retrived using the helper function GetHResultCode)...
            // A negative return value indicates that the first item should precede the second (pidl1 < pidl2). 
            // A positive return value indicates that the first item should follow the second (pidl1 > pidl2).  Zero A return value of zero indicates that the two items are the same (pidl1 = pidl2). 
            [PreserveSig()]
            int CompareIDs(
                int lParam,             // Value that specifies how the comparison should be performed. The lower sixteen bits of lParam define the sorting rule.
                                        // The upper sixteen bits of lParam are used for flags that modify the sorting rule. values can be from the SHCIDS enum
                IntPtr pidl1,           // Pointer to the first item's ITEMIDLIST structure.
                IntPtr pidl2);          // Pointer to the second item's ITEMIDLIST structure.

            // Requests an object that can be used to obtain information from or interact with a folder object.
            // Return value: error code, if any
            [PreserveSig()]
            uint CreateViewObject(
                IntPtr hwndOwner,       // Handle to the owner window.
                [In()]
                ref Guid riid,          // Identifier of the requested interface.
                [MarshalAs(UnmanagedType.Interface)]
                out object ppv);        // Address of a pointer to the requested interface. 

            // Retrieves the attributes of one or more file objects or subfolders. 
            // Return value: error code, if any
            [PreserveSig()]
            uint GetAttributesOf(
                int cidl,               // Number of file objects from which to retrieve attributes. 
                out IntPtr apidl,           // Address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies a file object relative to the parent folder.
                out SFGAOF rgfInOut);       // Address of a single ULONG value that, on entry, contains the attributes that the caller is requesting. On exit, this value contains the requested attributes that are common to all of the specified objects. this value can be from the SFGAO enum

            // Retrieves an OLE interface that can be used to carry out actions on the specified file objects or folders. 
            // Return value: error code, if any
            [PreserveSig()]
            uint GetUIObjectOf(
                IntPtr hwndOwner,       // Handle to the owner window that the client should specify if it displays a dialog box or message box.
                int cidl,               // Number of file objects or subfolders specified in the apidl parameter. 
                [In(), MarshalAs(UnmanagedType.LPArray)] IntPtr[]
                apidl,                  // Address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies a file object or subfolder relative to the parent folder.
                [In()]
                ref Guid riid,          // Identifier of the COM interface object to return.
                IntPtr rgfReserved,     // Reserved. 
                [MarshalAs(UnmanagedType.Interface)]
                out object ppv);        // Pointer to the requested interface.

            // Retrieves the display name for the specified file object or subfolder. 
            // Return value: error code, if any
            [PreserveSig()]
            uint GetDisplayNameOf(
                IntPtr pidl,            // Address of an ITEMIDLIST structure (PIDL) that uniquely identifies the file object or subfolder relative to the parent folder. 
                SHGNO uFlags,           // Flags used to request the type of display name to return. For a list of possible values. 
                out STRRET pName);      // Address of a STRRET structure in which to return the display name.

            // Sets the display name of a file object or subfolder, changing the item identifier in the process.
            // Return value: error code, if any
            [PreserveSig()]
            uint SetNameOf(
                IntPtr hwnd,            // Handle to the owner window of any dialog or message boxes that the client displays.
                IntPtr pidl,            // Pointer to an ITEMIDLIST structure that uniquely identifies the file object or subfolder relative to the parent folder. 
                [In(), MarshalAs(UnmanagedType.LPWStr)]
                string pszName,         // Pointer to a null-terminated string that specifies the new display name. 
                SHGNO uFlags,           // Flags indicating the type of name specified by the lpszName parameter. For a list of possible values, see the description of the SHGNO enum. 
                out IntPtr ppidlOut);   // Address of a pointer to an ITEMIDLIST structure which receives the new ITEMIDLIST. 
        }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("000214F2-0000-0000-C000-000000000046")]
        public interface IEnumIDList
        {

            // Retrieves the specified number of item identifiers in the enumeration sequence and advances the current position by the number of items retrieved. 
            [PreserveSig()]
            uint Next(
                uint celt,                // Number of elements in the array pointed to by the rgelt parameter.
                out IntPtr rgelt,         // Address of an array of ITEMIDLIST pointers that receives the item identifiers. The implementation must allocate these item identifiers using the Shell's allocator (retrieved by the SHGetMalloc function). 
                                          // The calling application is responsible for freeing the item identifiers using the Shell's allocator.
                out Int32 pceltFetched    // Address of a value that receives a count of the item identifiers actually returned in rgelt. The count can be smaller than the value specified in the celt parameter. This parameter can be NULL only if celt is one. 
                );

            // Skips over the specified number of elements in the enumeration sequence. 
            [PreserveSig()]
            uint Skip(
                uint celt                 // Number of item identifiers to skip.
                );

            // Returns to the beginning of the enumeration sequence. 
            [PreserveSig()]
            uint Reset();

            // Creates a new item enumeration object with the same contents and state as the current one. 
            [PreserveSig()]
            uint Clone(
                out IEnumIDList ppenum    // Address of a pointer to the new enumeration object. The calling application must eventually free the new object by calling its Release member function. 
                );
        }

        #endregion
    }
}