using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Extended.IO
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SHQUERYRBINFO
    {
        public uint cbSize;
        public ulong i64Size;
        public ulong i64NumItems;
    };

    //Shell functions
    public class NativeMethods
    {
        public const uint SHGFI_ICON = 0x100;
        //public const uint SHGFI_LARGEICON = 0x0;    // 'Large icon
        public const uint SHGFI_SMALLICON = 0x1;    // 'Small icon

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(
            string pszPath,
            uint dwFileAttributes,
            ref SHFILEINFO psfi,
            uint cbSizeFileInfo,
            uint uFlags);

        [DllImport("kernel32")]
        public static extern uint GetDriveType(
            string lpRootPathName);

        [DllImport("shell32.dll")]
        public static extern bool SHGetDiskFreeSpaceEx(
            string pszVolume,
            ref ulong pqwFreeCaller,
            ref ulong pqwTot,
            ref ulong pqwFree);

        [DllImport("shell32.Dll")]
        public static extern int SHQueryRecycleBin(
            string pszRootPath,
            ref SHQUERYRBINFO pSHQueryRBInfo);

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };



        [StructLayout(LayoutKind.Sequential)]
        public class BITMAPINFO
        {
            public Int32 biSize;
            public Int32 biWidth;
            public Int32 biHeight;
            public Int16 biPlanes;
            public Int16 biBitCount;
            public Int32 biCompression;
            public Int32 biSizeImage;
            public Int32 biXPelsPerMeter;
            public Int32 biYPelsPerMeter;
            public Int32 biClrUsed;
            public Int32 biClrImportant;
            public Int32 colors;
        };
        [DllImport("comctl32.dll")]
        public static extern bool ImageList_Add(IntPtr hImageList, IntPtr hBitmap, IntPtr hMask);
        [DllImport("kernel32.dll")]
        private static extern bool RtlMoveMemory(IntPtr dest, IntPtr source, int dwcount);
        [DllImport("shell32.dll")]
        public static extern IntPtr DestroyIcon(IntPtr hIcon);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, [In, MarshalAs(UnmanagedType.LPStruct)]BITMAPINFO pbmi, uint iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);


    }

    public enum ResourceScope
    {
        RESOURCE_CONNECTED = 1,
        RESOURCE_GLOBALNET,
        RESOURCE_REMEMBERED,
        RESOURCE_RECENT,
        RESOURCE_CONTEXT
    };

    public enum ResourceType
    {
        RESOURCETYPE_ANY,
        RESOURCETYPE_DISK,
        RESOURCETYPE_PRINT,
        RESOURCETYPE_RESERVED
    };

    public enum ResourceUsage
    {
        RESOURCEUSAGE_CONNECTABLE = 0x00000001,
        RESOURCEUSAGE_CONTAINER = 0x00000002,
        RESOURCEUSAGE_NOLOCALDEVICE = 0x00000004,
        RESOURCEUSAGE_SIBLING = 0x00000008,
        RESOURCEUSAGE_ATTACHED = 0x00000010,
        RESOURCEUSAGE_ALL = (RESOURCEUSAGE_CONNECTABLE | RESOURCEUSAGE_CONTAINER | RESOURCEUSAGE_ATTACHED),
    };

    public enum ResourceDisplayType
    {
        RESOURCEDISPLAYTYPE_GENERIC,
        RESOURCEDISPLAYTYPE_DOMAIN,
        RESOURCEDISPLAYTYPE_SERVER,
        RESOURCEDISPLAYTYPE_SHARE,
        RESOURCEDISPLAYTYPE_FILE,
        RESOURCEDISPLAYTYPE_GROUP,
        RESOURCEDISPLAYTYPE_NETWORK,
        RESOURCEDISPLAYTYPE_ROOT,
        RESOURCEDISPLAYTYPE_SHAREADMIN,
        RESOURCEDISPLAYTYPE_DIRECTORY,
        RESOURCEDISPLAYTYPE_TREE,
        RESOURCEDISPLAYTYPE_NDSCONTAINER
    };

    public class ServerEnum : IEnumerable
    {
        enum ErrorCodes
        {
            NO_ERROR = 0,
            ERROR_NO_MORE_ITEMS = 259
        };

        [StructLayout(LayoutKind.Sequential)]
        private class NETRESOURCE
        {
            public ResourceScope dwScope = 0;
            public ResourceType dwType = 0;
            public ResourceDisplayType dwDisplayType = 0;
            public ResourceUsage dwUsage = 0;
            public string lpLocalName = null;
            public string lpRemoteName = null;
            public string lpComment = null;
            public string lpProvider = null;
        };


        private ArrayList aData = new ArrayList();


        public int Count
        {
            get { return aData.Count; }
        }

        [DllImport("Mpr.dll", EntryPoint = "WNetOpenEnumA", CallingConvention = CallingConvention.Winapi)]
        private static extern ErrorCodes WNetOpenEnum(ResourceScope dwScope, ResourceType dwType, ResourceUsage dwUsage, NETRESOURCE p, out IntPtr lphEnum);

        [DllImport("Mpr.dll", EntryPoint = "WNetCloseEnum", CallingConvention = CallingConvention.Winapi)]
        private static extern ErrorCodes WNetCloseEnum(IntPtr hEnum);

        [DllImport("Mpr.dll", EntryPoint = "WNetEnumResourceA", CallingConvention = CallingConvention.Winapi)]
        private static extern ErrorCodes WNetEnumResource(IntPtr hEnum, ref uint lpcCount, IntPtr buffer, ref uint lpBufferSize);


        private void EnumerateServers(NETRESOURCE pRsrc, ResourceScope scope, ResourceType type, ResourceUsage usage, ResourceDisplayType displayType, string kPath)
        {
            uint bufferSize = 16384;
            IntPtr buffer = Marshal.AllocHGlobal((int)bufferSize);
            IntPtr handle = IntPtr.Zero;
            ErrorCodes result;
            uint cEntries = 1;
            bool serverenum = false;

            result = WNetOpenEnum(scope, type, usage, pRsrc, out handle);

            if (result == ErrorCodes.NO_ERROR)
            {
                do
                {
                    result = WNetEnumResource(handle, ref cEntries, buffer, ref bufferSize);

                    if ((result == ErrorCodes.NO_ERROR))
                    {
                        Marshal.PtrToStructure(buffer, pRsrc);

                        if (String.Compare(kPath, "") == 0)
                        {
                            if ((pRsrc.dwDisplayType == displayType) || (pRsrc.dwDisplayType == ResourceDisplayType.RESOURCEDISPLAYTYPE_DOMAIN))
                                aData.Add(pRsrc.lpRemoteName + "|" + pRsrc.dwDisplayType);

                            if ((pRsrc.dwUsage & ResourceUsage.RESOURCEUSAGE_CONTAINER) == ResourceUsage.RESOURCEUSAGE_CONTAINER)
                            {
                                if ((pRsrc.dwDisplayType == displayType))
                                {
                                    EnumerateServers(pRsrc, scope, type, usage, displayType, kPath);

                                }

                            }
                        }
                        else
                        {
                            if (pRsrc.dwDisplayType == displayType)
                            {
                                aData.Add(pRsrc.lpRemoteName);
                                EnumerateServers(pRsrc, scope, type, usage, displayType, kPath);
                                //return;
                                serverenum = true;
                            }
                            if (!serverenum)
                            {
                                if (pRsrc.dwDisplayType == ResourceDisplayType.RESOURCEDISPLAYTYPE_SHARE)
                                {
                                    aData.Add(pRsrc.lpRemoteName + "-share");
                                }
                            }
                            else
                            {
                                serverenum = false;
                            }
                            if ((kPath.IndexOf(pRsrc.lpRemoteName) >= 0) || (String.Compare(pRsrc.lpRemoteName, "Microsoft Windows Network") == 0))
                            {
                                EnumerateServers(pRsrc, scope, type, usage, displayType, kPath);
                                //return;

                            }
                            //}
                        }

                    }
                    else if (result != ErrorCodes.ERROR_NO_MORE_ITEMS)
                        break;
                } while (result != ErrorCodes.ERROR_NO_MORE_ITEMS);

                WNetCloseEnum(handle);
            }

            Marshal.FreeHGlobal((IntPtr)buffer);
        }

        public ServerEnum(ResourceScope scope, ResourceType type, ResourceUsage usage, ResourceDisplayType displayType, string kPath)
        {

            NETRESOURCE netRoot = new NETRESOURCE();
            EnumerateServers(netRoot, scope, type, usage, displayType, kPath);

        }
        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return aData.GetEnumerator();
        }

        #endregion
    }
}