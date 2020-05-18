using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Shell
{
    public static class ShellImageList
    {
        private static IntPtr smallImageListHandle, largeImageListHandle;
        private static Hashtable imageTable;

        private const int TVSIL_NORMAL = 0;
        private const int TVSIL_SMALL = 1;

        static ShellImageList()
        {
            imageTable = new Hashtable();

            ShellAPI.SHGFI flag = ShellAPI.SHGFI.USEFILEATTRIBUTES | ShellAPI.SHGFI.SYSICONINDEX | ShellAPI.SHGFI.SMALLICON;
            ShellAPI.SHFILEINFO shfiSmall = new ShellAPI.SHFILEINFO();
            smallImageListHandle = ShellAPI.SHGetFileInfo(".txt", ShellAPI.FILE_ATTRIBUTE.NORMAL, ref shfiSmall, ShellAPI.cbFileInfo, flag);

            flag = ShellAPI.SHGFI.USEFILEATTRIBUTES | ShellAPI.SHGFI.SYSICONINDEX | ShellAPI.SHGFI.LARGEICON;
            ShellAPI.SHFILEINFO shfiLarge = new ShellAPI.SHFILEINFO();
            largeImageListHandle = ShellAPI.SHGetFileInfo(".txt", ShellAPI.FILE_ATTRIBUTE.NORMAL, ref shfiLarge, ShellAPI.cbFileInfo, flag);
        }

        internal static void SetIconIndex(ShellItem item, int index, bool SelectedIcon)
        {
            bool HasOverlay = false; //true if it's an overlay
            int rVal = 0; //The returned Index

            ShellAPI.SHGFI dwflag = ShellAPI.SHGFI.SYSICONINDEX | ShellAPI.SHGFI.PIDL | ShellAPI.SHGFI.ICON;
            ShellAPI.FILE_ATTRIBUTE dwAttr = 0;
            //build Key into HashTable for this Item
            int Key = index * 256;
            if (item.IsLink)
            {
                Key = Key | 1;
                dwflag = dwflag | ShellAPI.SHGFI.LINKOVERLAY;
                HasOverlay = true;
            }
            if (item.IsShared)
            {
                Key = Key | 2;
                dwflag = dwflag | ShellAPI.SHGFI.ADDOVERLAYS;
                HasOverlay = true;
            }
            if (SelectedIcon)
            {
                Key = Key | 4;
                dwflag = dwflag | ShellAPI.SHGFI.OPENICON;
                HasOverlay = true; //not really an overlay, but handled the same
            }

            if (imageTable.ContainsKey(Key))
            {
                rVal = (int)imageTable[Key];
            }
            else if (!HasOverlay && !item.IsHidden) //for non-overlay icons, we already have
            {
                rVal = (int)System.Math.Floor((double)Key / 256); // the right index -- put in table
                imageTable[Key] = rVal;
            }
            else //don't have iconindex for an overlay, get it.
            {
                if (item.IsFileSystem & !item.IsDisk & !item.IsFolder)
                {
                    dwflag = dwflag | ShellAPI.SHGFI.USEFILEATTRIBUTES;
                    dwAttr = dwAttr | ShellAPI.FILE_ATTRIBUTE.NORMAL;
                }

                PIDL pidlFull = item.PIDLFull;

                ShellAPI.SHFILEINFO shfiSmall = new ShellAPI.SHFILEINFO();
                ShellAPI.SHGetFileInfo(pidlFull.Ptr, dwAttr, ref shfiSmall, ShellAPI.cbFileInfo, dwflag | ShellAPI.SHGFI.SMALLICON);

                ShellAPI.SHFILEINFO shfiLarge = new ShellAPI.SHFILEINFO();
                ShellAPI.SHGetFileInfo(pidlFull.Ptr, dwAttr, ref shfiLarge, ShellAPI.cbFileInfo, dwflag | ShellAPI.SHGFI.LARGEICON);

                Marshal.FreeCoTaskMem(pidlFull.Ptr);

                lock (imageTable)
                {
                    rVal = ShellAPI.ImageList_ReplaceIcon(smallImageListHandle, -1, shfiSmall.hIcon);
                    ShellAPI.ImageList_ReplaceIcon(largeImageListHandle, -1, shfiLarge.hIcon);
                }

                ShellAPI.DestroyIcon(shfiSmall.hIcon);
                ShellAPI.DestroyIcon(shfiLarge.hIcon);
                imageTable[Key] = rVal;
            }

            if (SelectedIcon)
                item.SelectedImageIndex = rVal;
            else
                item.ImageIndex = rVal;
        }

        public static Icon GetIcon(int index, bool small)
        {
            IntPtr iconPtr;

            if (small)
                iconPtr = ShellAPI.ImageList_GetIcon(smallImageListHandle, index, ShellAPI.ILD.NORMAL);
            else
                iconPtr = ShellAPI.ImageList_GetIcon(largeImageListHandle, index, ShellAPI.ILD.NORMAL);

            if (iconPtr != IntPtr.Zero)
            {
                Icon icon = Icon.FromHandle(iconPtr);
                Icon retVal = (Icon)icon.Clone();
                ShellAPI.DestroyIcon(iconPtr);
                return retVal;
            }
            else
                return null;
        }

        internal static IntPtr SmallImageList { get { return smallImageListHandle; } }
        internal static IntPtr LargeImageList { get { return largeImageListHandle; } }

        #region Set Small Handle

        internal static void SetSmallImageList(KryptonTreeView treeView)
        {
            ShellAPI.SendMessage(treeView.Handle, ShellAPI.WM.TVM_SETIMAGELIST, TVSIL_NORMAL, smallImageListHandle);
        }

        // TODO: Use KryptonListView when ready
        internal static void SetSmallImageList(ListView listView)
        {
            ShellAPI.SendMessage(listView.Handle, ShellAPI.WM.LVM_SETIMAGELIST, TVSIL_SMALL, smallImageListHandle);
        }

        #endregion

        #region Set Large Handle
        // TODO: Use KryptonListView when ready
        internal static void SetLargeImageList(ListView listView)
        {
            ShellAPI.SendMessage(listView.Handle, ShellAPI.WM.LVM_SETIMAGELIST, TVSIL_NORMAL, largeImageListHandle);
        }

        #endregion
    }
}