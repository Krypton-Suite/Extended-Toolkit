using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace Krypton.Toolkit.Suite.Extended.Shell
{
    public class ShellBrowser : Component
    {
        #region Fields

        private ShellItem desktopItem;
        private string mydocsName, mycompName, sysfolderName, mydocsPath;

        private ShellBrowserUpdater updater;

        private ArrayList browsers;
        private ShellItemUpdateCondition updateCondition;

        internal event ShellItemUpdateEventHandler ShellItemUpdate;

        #endregion

        public ShellBrowser()
        {
            InitVars();
            browsers = new ArrayList();
            updateCondition = new ShellItemUpdateCondition();
            updater = new ShellBrowserUpdater(this);
        }

        private void InitVars()
        {
            IntPtr tempPidl;
            ShellAPI.SHFILEINFO info;

            //My Computer
            info = new ShellAPI.SHFILEINFO();
            tempPidl = IntPtr.Zero;
            ShellAPI.SHGetSpecialFolderLocation(IntPtr.Zero, ShellAPI.CSIDL.DRIVES, out tempPidl);

            ShellAPI.SHGetFileInfo(tempPidl, 0, ref info, ShellAPI.cbFileInfo,
                ShellAPI.SHGFI.PIDL | ShellAPI.SHGFI.DISPLAYNAME | ShellAPI.SHGFI.TYPENAME);

            sysfolderName = info.szTypeName;
            mycompName = info.szDisplayName;
            Marshal.FreeCoTaskMem(tempPidl);
            //

            //Dekstop
            tempPidl = IntPtr.Zero;
            ShellAPI.SHGetSpecialFolderLocation(IntPtr.Zero, ShellAPI.CSIDL.DESKTOP, out tempPidl);
            IntPtr desktopFolderPtr;
            ShellAPI.SHGetDesktopFolder(out desktopFolderPtr);
            desktopItem = new ShellItem(this, tempPidl, desktopFolderPtr);
            //

            //My Documents
            uint pchEaten = 0;
            ShellAPI.SFGAO pdwAttributes = 0;
            desktopItem.ShellFolder.ParseDisplayName(
                IntPtr.Zero,
                IntPtr.Zero,
                "::{450d8fba-ad25-11d0-98a8-0800361b1103}",
                ref pchEaten,
                out tempPidl,
                ref pdwAttributes);

            info = new ShellAPI.SHFILEINFO();
            ShellAPI.SHGetFileInfo(tempPidl, 0, ref info, ShellAPI.cbFileInfo,
                ShellAPI.SHGFI.PIDL | ShellAPI.SHGFI.DISPLAYNAME);

            mydocsName = info.szDisplayName;
            Marshal.FreeCoTaskMem(tempPidl);

            StringBuilder path = new StringBuilder(ShellAPI.MAX_PATH);
            ShellAPI.SHGetFolderPath(
                    IntPtr.Zero, ShellAPI.CSIDL.PERSONAL,
                    IntPtr.Zero, ShellAPI.SHGFP.TYPE_CURRENT, path);
            mydocsPath = path.ToString();
            //
        }

        #region ShellBrowser Update

        internal void OnShellItemUpdate(object sender, ShellItemUpdateEventArgs e)
        {
            if (ShellItemUpdate != null)
            {
                ShellItemUpdate(sender, e);
            }
        }

        #endregion

        #region Utility Methods

        internal ShellItem GetShellItem(PIDL pidlFull)
        {
            ShellItem current = DesktopItem;
            if (pidlFull.Ptr == IntPtr.Zero)
                return current;

            foreach (IntPtr pidlRel in pidlFull)
            {
                int index;
                if ((index = current.IndexOf(pidlRel)) > -1)
                {
                    current = current[index];
                }
                else
                {
                    current = null;
                    break;
                }
            }

            return current;
        }

        internal ShellItem[] GetPath(ShellItem item)
        {
            ArrayList pathList = new ArrayList();

            ShellItem currentItem = item;
            while (currentItem.ParentItem != null)
            {
                pathList.Add(currentItem);
                currentItem = currentItem.ParentItem;
            }
            pathList.Add(currentItem);
            pathList.Reverse();

            return (ShellItem[])pathList.ToArray(typeof(ShellItem));
        }

        #endregion

        #region Properties

        internal ShellItem DesktopItem { get { return desktopItem; } }

        internal string MyDocumentsName { get { return mydocsName; } }
        internal string MyComputerName { get { return mycompName; } }
        internal string SystemFolderName { get { return sysfolderName; } }

        internal string MyDocumentsPath { get { return mydocsPath; } }

        internal ShellItemUpdateCondition UpdateCondition { get { return updateCondition; } }

        internal ArrayList Browsers { get { return browsers; } }

        #endregion
    }

    #region ShellItemUpdate

    internal delegate void ShellItemUpdateEventHandler(object sender, ShellItemUpdateEventArgs e);

    internal enum ShellItemUpdateType
    {
        Created,
        IconChange,
        Updated,
        Renamed,
        Deleted,
        MediaChange
    }

    internal class ShellItemUpdateEventArgs : EventArgs
    {
        ShellItem oldItem, newItem;
        ShellItemUpdateType type;

        public ShellItemUpdateEventArgs(
            ShellItem oldItem,
            ShellItem newItem,
            ShellItemUpdateType type)
        {
            this.oldItem = oldItem;
            this.newItem = newItem;
            this.type = type;
        }

        public ShellItem OldItem { get { return oldItem; } }
        public ShellItem NewItem { get { return newItem; } }
        public ShellItemUpdateType UpdateType { get { return type; } }
    }

    #endregion
}