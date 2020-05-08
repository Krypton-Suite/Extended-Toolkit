using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

namespace Krypton.Toolkit.Suite.Extended.Shell
{
    public sealed class ShellItem : IEnumerable, IDisposable, IComparable
    {
        #region Fields

        private ShellBrowser browser;

        private ShellItem parentItem;
        private IShellFolder shellFolder;
        private IntPtr shellFolderPtr;
        private ShellItemCollection subFiles, subFolders;

        private PIDL pidlRel;

        private short sortFlag;
        private int imageIndex, selectedImageIndex;

        private bool isFolder, isLink, isShared, isFileSystem,
                     isHidden, hasSubfolder, isBrowsable, isDisk, filesExpanded,
                     foldersExpanded, canRename, updateShellFolder, canRead;

        private string text, path, type;

        private bool disposed = false;

        #endregion

        #region Constructors

        internal ShellItem(ShellBrowser browser, IntPtr pidl, IntPtr shellFolderPtr)
        {
            this.browser = browser;

            this.shellFolderPtr = shellFolderPtr;
            this.shellFolder = (IShellFolder)Marshal.GetTypedObjectForIUnknown(shellFolderPtr, typeof(IShellFolder));
            subFiles = new ShellItemCollection(this);
            subFolders = new ShellItemCollection(this);

            pidlRel = new PIDL(pidl, false);

            text = "Desktop";
            path = "Desktop";

            SetAttributesDesktop(this);

            ShellAPI.SHFILEINFO info = new ShellAPI.SHFILEINFO();
            ShellAPI.SHGetFileInfo(pidlRel.Ptr, 0, ref info, ShellAPI.cbFileInfo,
                ShellAPI.SHGFI.PIDL | ShellAPI.SHGFI.TYPENAME | ShellAPI.SHGFI.SYSICONINDEX);

            type = info.szTypeName;

            ShellImageList.SetIconIndex(this, info.iIcon, false);
            ShellImageList.SetIconIndex(this, info.iIcon, true);

            sortFlag = 1;
        }

        internal ShellItem(ShellBrowser browser, ShellItem parentItem, IntPtr pidl, IntPtr shellFolderPtr)
        {
            this.browser = browser;

            this.parentItem = parentItem;
            this.shellFolderPtr = shellFolderPtr;
            this.shellFolder = (IShellFolder)Marshal.GetTypedObjectForIUnknown(shellFolderPtr, typeof(IShellFolder));
            subFiles = new ShellItemCollection(this);
            subFolders = new ShellItemCollection(this);

            pidlRel = new PIDL(pidl, false);

            SetText(this);
            SetPath(this);
            SetAttributesFolder(this);
            SetInfo(this);

            sortFlag = MakeSortFlag(this);
        }

        internal ShellItem(ShellBrowser browser, ShellItem parentItem, IntPtr pidl)
        {
            this.browser = browser;

            this.parentItem = parentItem;

            pidlRel = new PIDL(pidl, false);

            SetText(this);
            SetPath(this);
            SetAttributesFile(this);
            SetInfo(this);

            sortFlag = MakeSortFlag(this);
        }

        ~ShellItem()
        {
            ((IDisposable)this).Dispose();
        }

        #endregion

        #region Init Methods

        private static void SetText(ShellItem item)
        {
            IntPtr strr = Marshal.AllocCoTaskMem(ShellAPI.MAX_PATH * 2 + 4);
            Marshal.WriteInt32(strr, 0, 0);
            StringBuilder buf = new StringBuilder(ShellAPI.MAX_PATH);

            if (item.ParentItem.ShellFolder.GetDisplayNameOf(
                            item.PIDLRel.Ptr,
                            ShellAPI.SHGNO.INFOLDER,
                            strr) == ShellAPI.S_OK)
            {
                ShellAPI.StrRetToBuf(strr, item.PIDLRel.Ptr, buf, ShellAPI.MAX_PATH);
                item.text = buf.ToString();
            }

            Marshal.FreeCoTaskMem(strr);
        }

        private static void SetPath(ShellItem item)
        {
            IntPtr strr = Marshal.AllocCoTaskMem(ShellAPI.MAX_PATH * 2 + 4);
            Marshal.WriteInt32(strr, 0, 0);
            StringBuilder buf = new StringBuilder(ShellAPI.MAX_PATH);

            if (item.ParentItem.ShellFolder.GetDisplayNameOf(
                            item.PIDLRel.Ptr,
                            ShellAPI.SHGNO.FORADDRESSBAR | ShellAPI.SHGNO.FORPARSING,
                            strr) == ShellAPI.S_OK)
            {
                ShellAPI.StrRetToBuf(strr, item.PIDLRel.Ptr, buf, ShellAPI.MAX_PATH);
                item.path = buf.ToString();
            }

            Marshal.FreeCoTaskMem(strr);
        }

        private static void SetInfo(ShellItem item)
        {
            PIDL pidlFull = item.PIDLFull;

            ShellAPI.SHFILEINFO info = new ShellAPI.SHFILEINFO();
            ShellAPI.SHGetFileInfo(pidlFull.Ptr, 0, ref info, ShellAPI.cbFileInfo,
                ShellAPI.SHGFI.PIDL | ShellAPI.SHGFI.TYPENAME | ShellAPI.SHGFI.SYSICONINDEX);

            pidlFull.Free();

            ShellImageList.SetIconIndex(item, info.iIcon, false);
            ShellImageList.SetIconIndex(item, info.iIcon, true);

            item.type = info.szTypeName;
        }

        private static void SetAttributesDesktop(ShellItem item)
        {
            item.isFolder = true;
            item.isLink = false;
            item.isShared = false;
            item.isFileSystem = true;
            item.isHidden = false;
            item.hasSubfolder = true;
            item.isBrowsable = true;
            item.canRename = false;
            item.canRead = true;
        }

        private static void SetAttributesFolder(ShellItem item)
        {
            // file/folder attributes
            ShellAPI.SFGAO attribs =
                ShellAPI.SFGAO.SHARE |
                ShellAPI.SFGAO.FILESYSTEM |
                ShellAPI.SFGAO.HIDDEN |
                ShellAPI.SFGAO.HASSUBFOLDER |
                ShellAPI.SFGAO.BROWSABLE |
                ShellAPI.SFGAO.CANRENAME |
                ShellAPI.SFGAO.STORAGE;
            item.ParentItem.ShellFolder.GetAttributesOf(
                1, new IntPtr[] { item.PIDLRel.Ptr }, ref attribs);

            item.isFolder = true;
            item.isLink = false;
            item.isShared = (attribs & ShellAPI.SFGAO.SHARE) != 0;
            item.isFileSystem = (attribs & ShellAPI.SFGAO.FILESYSTEM) != 0;
            item.isHidden = (attribs & ShellAPI.SFGAO.HIDDEN) != 0;
            item.hasSubfolder = (attribs & ShellAPI.SFGAO.HASSUBFOLDER) != 0;
            item.isBrowsable = (attribs & ShellAPI.SFGAO.BROWSABLE) != 0;
            item.canRename = (attribs & ShellAPI.SFGAO.CANRENAME) != 0;
            item.canRead = (attribs & ShellAPI.SFGAO.STORAGE) != 0;

            item.isDisk = (item.path.Length == 3 && item.path.EndsWith(":\\"));
        }

        private static void SetAttributesFile(ShellItem item)
        {
            // file/folder attributes
            ShellAPI.SFGAO attribs =
                ShellAPI.SFGAO.LINK |
                ShellAPI.SFGAO.SHARE |
                ShellAPI.SFGAO.FILESYSTEM |
                ShellAPI.SFGAO.HIDDEN |
                ShellAPI.SFGAO.CANRENAME |
                ShellAPI.SFGAO.STREAM;
            item.ParentItem.ShellFolder.GetAttributesOf(
                1, new IntPtr[] { item.PIDLRel.Ptr }, ref attribs);

            item.isFolder = false;
            item.isLink = (attribs & ShellAPI.SFGAO.LINK) != 0;
            item.isShared = (attribs & ShellAPI.SFGAO.SHARE) != 0;
            item.isFileSystem = (attribs & ShellAPI.SFGAO.FILESYSTEM) != 0;
            item.isHidden = (attribs & ShellAPI.SFGAO.HIDDEN) != 0;
            item.hasSubfolder = false;
            item.isBrowsable = false;
            item.canRename = (attribs & ShellAPI.SFGAO.CANRENAME) != 0;
            item.canRead = (attribs & ShellAPI.SFGAO.STREAM) != 0;

            item.isDisk = false;
        }

        #endregion

        #region Browse Methods

        internal bool Expand(bool expandFiles, bool expandFolders, IntPtr winHandle)
        {
            if (((expandFiles && !filesExpanded) || !expandFiles) &&
                ((expandFolders && !foldersExpanded) || !expandFolders) &&
                (expandFiles || expandFolders) && ShellFolder != null && !disposed)
            {
                #region Fields

                IntPtr fileEnumPtr = IntPtr.Zero, folderEnumPtr = IntPtr.Zero;
                IEnumIDList fileEnum = null, folderEnum = null;
                IntPtr pidlSubItem;
                int celtFetched;

                ShellAPI.SHCONTF fileFlag =
                        ShellAPI.SHCONTF.NONFOLDERS |
                        ShellAPI.SHCONTF.INCLUDEHIDDEN;

                ShellAPI.SHCONTF folderFlag =
                        ShellAPI.SHCONTF.FOLDERS |
                        ShellAPI.SHCONTF.INCLUDEHIDDEN;

                #endregion

                try
                {
                    #region Add Files

                    if (expandFiles)
                    {
                        if (this.Equals(browser.DesktopItem) || parentItem.Equals(browser.DesktopItem))
                        {
                            if (ShellFolder.EnumObjects(
                                    winHandle,
                                    fileFlag,
                                    out fileEnumPtr) == ShellAPI.S_OK)
                            {
                                fileEnum = (IEnumIDList)Marshal.GetTypedObjectForIUnknown(fileEnumPtr, typeof(IEnumIDList));
                                ShellAPI.SFGAO attribs = ShellAPI.SFGAO.FOLDER;
                                while (fileEnum.Next(1, out pidlSubItem, out celtFetched) == ShellAPI.S_OK && celtFetched == 1)
                                {
                                    ShellFolder.GetAttributesOf(1, new IntPtr[] { pidlSubItem }, ref attribs);

                                    if ((attribs & ShellAPI.SFGAO.FOLDER) == 0)
                                    {
                                        ShellItem newItem = new ShellItem(browser, this, pidlSubItem);

                                        if (!subFolders.Contains(newItem.Text))
                                            subFiles.Add(newItem);
                                    }
                                    else
                                        Marshal.FreeCoTaskMem(pidlSubItem);
                                }

                                subFiles.Sort();
                                filesExpanded = true;
                            }
                        }
                        else
                        {
                            if (ShellFolder.EnumObjects(
                                    winHandle,
                                    fileFlag,
                                    out fileEnumPtr) == ShellAPI.S_OK)
                            {
                                fileEnum = (IEnumIDList)Marshal.GetTypedObjectForIUnknown(fileEnumPtr, typeof(IEnumIDList));
                                while (fileEnum.Next(1, out pidlSubItem, out celtFetched) == ShellAPI.S_OK && celtFetched == 1)
                                {
                                    ShellItem newItem = new ShellItem(browser, this, pidlSubItem);
                                    subFiles.Add(newItem);
                                }

                                subFiles.Sort();
                                filesExpanded = true;
                            }
                        }
                    }

                    #endregion

                    #region Add Folders

                    if (expandFolders)
                    {
                        if (ShellFolder.EnumObjects(
                                    winHandle,
                                    folderFlag,
                                    out folderEnumPtr) == ShellAPI.S_OK)
                        {
                            folderEnum = (IEnumIDList)Marshal.GetTypedObjectForIUnknown(folderEnumPtr, typeof(IEnumIDList));
                            while (folderEnum.Next(1, out pidlSubItem, out celtFetched) == ShellAPI.S_OK && celtFetched == 1)
                            {
                                IntPtr shellFolderPtr;
                                if (ShellFolder.BindToObject(
                                            pidlSubItem,
                                            IntPtr.Zero,
                                            ref ShellAPI.IID_IShellFolder,
                                            out shellFolderPtr) == ShellAPI.S_OK)
                                {
                                    ShellItem newItem = new ShellItem(
                                        browser,
                                        this,
                                        pidlSubItem,
                                        shellFolderPtr);
                                    subFolders.Add(newItem);
                                }
                            }

                            subFolders.Sort();
                            foldersExpanded = true;
                        }
                    }

                    #endregion
                }
                catch (Exception) { }
                finally
                {
                    #region Free

                    if (folderEnum != null)
                    {
                        Marshal.ReleaseComObject(folderEnum);
                        Marshal.Release(folderEnumPtr);
                    }

                    if (fileEnum != null)
                    {
                        Marshal.ReleaseComObject(fileEnum);
                        Marshal.Release(fileEnumPtr);
                    }

                    #endregion
                }
            }

            return ((expandFiles == filesExpanded || !expandFiles) && (expandFolders == foldersExpanded || !expandFolders));
        }

        internal void Clear(bool clearFiles, bool clearFolders)
        {
            if (((clearFiles && filesExpanded) || !clearFiles) &&
                ((clearFolders && foldersExpanded) || !clearFolders) &&
                (clearFiles || clearFolders) && ShellFolder != null && !disposed)
            {
                lock (browser)
                {
                    try
                    {
                        #region Reset Files

                        if (clearFiles)
                        {
                            foreach (IDisposable item in subFiles)
                                item.Dispose();

                            subFiles.Clear();
                            filesExpanded = false;
                        }

                        #endregion

                        #region Reset Folders

                        if (clearFolders)
                        {
                            foreach (IDisposable item in subFolders)
                                item.Dispose();

                            subFolders.Clear();
                            foldersExpanded = false;
                        }

                        #endregion
                    }
                    catch (Exception) { }
                }
            }
        }

        #region Updates

        internal void Update(bool updateFiles, bool updateFolders)
        {
            if (browser.UpdateCondition.ContinueUpdate && (updateFiles || updateFolders) && ShellFolder != null && !disposed)
            {
                lock (browser)
                {
                    #region Fields

                    IntPtr fileEnumPtr = IntPtr.Zero, folderEnumPtr = IntPtr.Zero;
                    IEnumIDList fileEnum = null, folderEnum = null;
                    IntPtr pidlSubItem;
                    int celtFetched;

                    ShellAPI.SHCONTF fileFlag =
                            ShellAPI.SHCONTF.NONFOLDERS |
                            ShellAPI.SHCONTF.INCLUDEHIDDEN;

                    ShellAPI.SHCONTF folderFlag =
                            ShellAPI.SHCONTF.FOLDERS |
                            ShellAPI.SHCONTF.INCLUDEHIDDEN;

                    bool[] fileExists;
                    fileExists = new bool[subFiles.Count];

                    bool[] folderExists;
                    folderExists = new bool[subFolders.Count];

                    int index;

                    #endregion

                    try
                    {
                        #region Update Files

                        if (browser.UpdateCondition.ContinueUpdate && updateFiles)
                        {
                            ShellItemCollection add = new ShellItemCollection(this);
                            ShellItemCollection remove = new ShellItemCollection(this);

                            bool fileEnumCompleted = false;

                            #region Add Files

                            if (this.Equals(browser.DesktopItem) || parentItem.Equals(browser.DesktopItem))
                            {
                                if (ShellFolder.EnumObjects(
                                        IntPtr.Zero,
                                        fileFlag,
                                        out fileEnumPtr) == ShellAPI.S_OK)
                                {
                                    fileEnum = (IEnumIDList)Marshal.GetTypedObjectForIUnknown(fileEnumPtr, typeof(IEnumIDList));
                                    ShellAPI.SFGAO attribs = ShellAPI.SFGAO.FOLDER;
                                    while (browser.UpdateCondition.ContinueUpdate &&
                                           fileEnum.Next(1, out pidlSubItem, out celtFetched) == ShellAPI.S_OK && celtFetched == 1)
                                    {
                                        ShellFolder.GetAttributesOf(1, new IntPtr[] { pidlSubItem }, ref attribs);

                                        if ((attribs & ShellAPI.SFGAO.FOLDER) == 0)
                                        {
                                            if ((index = subFiles.IndexOf(pidlSubItem)) == -1)
                                            {
                                                ShellItem newItem = new ShellItem(browser, this, pidlSubItem);

                                                if (!subFolders.Contains(newItem.Text))
                                                {
                                                    add.Add(newItem);
                                                }
                                            }
                                            else if (index < fileExists.Length)
                                            {
                                                fileExists[index] = true;
                                                Marshal.FreeCoTaskMem(pidlSubItem);
                                            }
                                        }
                                        else
                                            Marshal.FreeCoTaskMem(pidlSubItem);
                                    }

                                    fileEnumCompleted = true;
                                }

                            }
                            else
                            {
                                if (ShellFolder.EnumObjects(
                                        IntPtr.Zero,
                                        fileFlag,
                                        out fileEnumPtr) == ShellAPI.S_OK)
                                {
                                    fileEnum = (IEnumIDList)Marshal.GetTypedObjectForIUnknown(fileEnumPtr, typeof(IEnumIDList));
                                    while (browser.UpdateCondition.ContinueUpdate &&
                                           fileEnum.Next(1, out pidlSubItem, out celtFetched) == ShellAPI.S_OK && celtFetched == 1)
                                    {
                                        if ((index = subFiles.IndexOf(pidlSubItem)) == -1)
                                        {
                                            add.Add(new ShellItem(browser, this, pidlSubItem));
                                        }
                                        else if (index < fileExists.Length)
                                        {
                                            fileExists[index] = true;
                                            Marshal.FreeCoTaskMem(pidlSubItem);
                                        }
                                    }

                                    fileEnumCompleted = true;
                                }
                            }

                            #endregion

                            #region Remove Files

                            for (int i = 0; fileEnumCompleted && browser.UpdateCondition.ContinueUpdate && i < fileExists.Length; i++)
                            {
                                if (!fileExists[i] && subFiles[i] != null)
                                {
                                    remove.Add(subFiles[i]);
                                }
                            }

                            #endregion

                            #region Do Events

                            if (fileEnumCompleted && browser.UpdateCondition.ContinueUpdate)
                            {
                                int newIndex;
                                foreach (ShellItem oldItem in remove)
                                {
                                    if ((newIndex = add.IndexOf(oldItem.Text)) > -1)
                                    {
                                        ShellItem newItem = add[newIndex];
                                        add.Remove(newItem);

                                        oldItem.pidlRel.Free();
                                        oldItem.pidlRel = new PIDL(newItem.pidlRel.Ptr, true);

                                        oldItem.shellFolder = newItem.shellFolder;
                                        oldItem.shellFolderPtr = newItem.shellFolderPtr;

                                        ((IDisposable)newItem).Dispose();

                                        browser.OnShellItemUpdate(this, new ShellItemUpdateEventArgs(oldItem, oldItem, ShellItemUpdateType.Updated));
                                    }
                                    else
                                    {
                                        subFiles.Remove(oldItem);
                                        browser.OnShellItemUpdate(this, new ShellItemUpdateEventArgs(oldItem, null, ShellItemUpdateType.Deleted));
                                        ((IDisposable)oldItem).Dispose();
                                    }
                                }

                                foreach (ShellItem newItem in add)
                                {
                                    subFiles.Add(newItem);
                                    browser.OnShellItemUpdate(this, new ShellItemUpdateEventArgs(null, newItem, ShellItemUpdateType.Created));
                                }

                                subFiles.Capacity = subFiles.Count;
                                subFiles.Sort();

                                filesExpanded = true;
                            }

                            #endregion
                        }

                        #endregion

                        #region Update Folders

                        if (browser.UpdateCondition.ContinueUpdate && updateFolders)
                        {
                            ShellItemCollection add = new ShellItemCollection(this);
                            ShellItemCollection remove = new ShellItemCollection(this);

                            bool folderEnumCompleted = false;

                            #region Add Folders

                            if (ShellFolder.EnumObjects(
                                        IntPtr.Zero,
                                        folderFlag,
                                        out folderEnumPtr) == ShellAPI.S_OK)
                            {
                                folderEnum = (IEnumIDList)Marshal.GetTypedObjectForIUnknown(folderEnumPtr, typeof(IEnumIDList));
                                while (browser.UpdateCondition.ContinueUpdate &&
                                       folderEnum.Next(1, out pidlSubItem, out celtFetched) == ShellAPI.S_OK && celtFetched == 1)
                                {
                                    if ((index = subFolders.IndexOf(pidlSubItem)) == -1)
                                    {
                                        IntPtr shellFolderPtr;
                                        if (ShellFolder.BindToObject(
                                                    pidlSubItem,
                                                    IntPtr.Zero,
                                                    ref ShellAPI.IID_IShellFolder,
                                                    out shellFolderPtr) == ShellAPI.S_OK)
                                        {
                                            add.Add(new ShellItem(
                                                browser,
                                                this,
                                                pidlSubItem,
                                                shellFolderPtr));
                                        }
                                    }
                                    else if (index < folderExists.Length)
                                    {
                                        folderExists[index] = true;
                                        Marshal.FreeCoTaskMem(pidlSubItem);
                                    }
                                }

                                folderEnumCompleted = true;
                            }

                            #endregion

                            #region Remove Folders

                            for (int i = 0; folderEnumCompleted && browser.UpdateCondition.ContinueUpdate && i < folderExists.Length; i++)
                            {
                                if (!folderExists[i] && subFolders[i] != null)
                                {
                                    remove.Add(subFolders[i]);
                                }
                            }

                            #endregion

                            #region Do Events

                            if (folderEnumCompleted && browser.UpdateCondition.ContinueUpdate)
                            {
                                int newIndex;
                                foreach (ShellItem oldItem in remove)
                                {
                                    if ((newIndex = add.IndexOf(oldItem.Text)) > -1)
                                    {
                                        ShellItem newItem = add[newIndex];
                                        add.Remove(newItem);

                                        oldItem.pidlRel.Free();
                                        oldItem.pidlRel = new PIDL(newItem.pidlRel, true);

                                        Marshal.ReleaseComObject(oldItem.shellFolder);
                                        Marshal.Release(oldItem.shellFolderPtr);

                                        oldItem.shellFolder = newItem.shellFolder;
                                        oldItem.shellFolderPtr = newItem.shellFolderPtr;

                                        newItem.shellFolder = null;
                                        newItem.shellFolderPtr = IntPtr.Zero;
                                        ((IDisposable)newItem).Dispose();

                                        browser.OnShellItemUpdate(this, new ShellItemUpdateEventArgs(oldItem, oldItem, ShellItemUpdateType.Updated));
                                    }
                                    else
                                    {
                                        subFolders.Remove(oldItem);
                                        browser.OnShellItemUpdate(this, new ShellItemUpdateEventArgs(oldItem, null, ShellItemUpdateType.Deleted));
                                        ((IDisposable)oldItem).Dispose();
                                    }
                                }

                                foreach (ShellItem newItem in add)
                                {
                                    subFolders.Add(newItem);

                                    browser.OnShellItemUpdate(this, new ShellItemUpdateEventArgs(null, newItem, ShellItemUpdateType.Created));
                                }

                                subFolders.Capacity = subFolders.Count;
                                subFolders.Sort();
                                foldersExpanded = true;
                            }

                            #endregion
                        }

                        #endregion
                    }
                    catch (Exception) { }
                    finally
                    {
                        #region Free

                        if (folderEnum != null)
                        {
                            Marshal.ReleaseComObject(folderEnum);
                            Marshal.Release(folderEnumPtr);
                        }

                        if (fileEnum != null)
                        {
                            Marshal.ReleaseComObject(fileEnum);

                            if (!(type == browser.SystemFolderName && string.Compare(text, "Control Panel", true) == 0))
                                Marshal.Release(fileEnumPtr);
                        }

                        #endregion
                    }
                }
            }
        }

        internal void AddItem(ShellItem item)
        {
            browser.UpdateCondition.ContinueUpdate = false;
            lock (browser)
            {
                try
                {
                    if (item.IsFolder)
                        SubFolders.Add(item);
                    else
                        SubFiles.Add(item);

                    Browser.OnShellItemUpdate(this, new ShellItemUpdateEventArgs(null, item, ShellItemUpdateType.Created));
                }
                catch (Exception) { }
            }
        }

        internal void Update(IntPtr newPidlFull, ShellItemUpdateType changeType)
        {
            browser.UpdateCondition.ContinueUpdate = false;

            lock (browser)
            {
                #region Change Pidl and ShellFolder

                if (newPidlFull != IntPtr.Zero)
                {
                    IntPtr tempPidl = PIDL.ILClone(PIDL.ILFindLastID(newPidlFull)), newPidlRel, newShellFolderPtr;
                    ShellAPI.SHGetRealIDL(ParentItem.ShellFolder, tempPidl, out newPidlRel);

                    if (IsFolder && ParentItem.ShellFolder.BindToObject(
                                        newPidlRel,
                                        IntPtr.Zero,
                                        ref ShellAPI.IID_IShellFolder,
                                        out newShellFolderPtr) == ShellAPI.S_OK)
                    {
                        Marshal.ReleaseComObject(shellFolder);
                        Marshal.Release(shellFolderPtr);
                        pidlRel.Free();

                        shellFolderPtr = newShellFolderPtr;
                        shellFolder = (IShellFolder)Marshal.GetTypedObjectForIUnknown(shellFolderPtr, typeof(IShellFolder));
                        pidlRel = new PIDL(newPidlRel, false);

                        foreach (ShellItem child in SubFolders)
                            UpdateShellFolders(child);
                    }
                    else
                    {
                        pidlRel.Free();
                        pidlRel = new PIDL(newPidlRel, false);
                    }

                    Marshal.FreeCoTaskMem(tempPidl);
                    Marshal.FreeCoTaskMem(newPidlFull);
                }

                #endregion

                #region Make Other Changes

                switch (changeType)
                {
                    case ShellItemUpdateType.Renamed:
                        SetText(this);
                        SetPath(this);
                        break;

                    case ShellItemUpdateType.Updated:
                        if (IsFolder)
                            SetAttributesFolder(this);
                        else
                            SetAttributesFile(this);
                        break;

                    case ShellItemUpdateType.MediaChange:
                        SetInfo(this);
                        Clear(true, true);
                        break;

                    case ShellItemUpdateType.IconChange:
                        SetInfo(this);
                        break;
                }

                #endregion
            }

            Browser.OnShellItemUpdate(ParentItem, new ShellItemUpdateEventArgs(this, this, changeType));
        }

        internal void RemoveItem(ShellItem item)
        {
            browser.UpdateCondition.ContinueUpdate = false;

            lock (browser)
            {
                try
                {
                    if (item.IsFolder)
                        SubFolders.Remove(item);
                    else
                        SubFiles.Remove(item);

                    Browser.OnShellItemUpdate(this, new ShellItemUpdateEventArgs(item, null, ShellItemUpdateType.Deleted));
                    ((IDisposable)item).Dispose();
                }
                catch (Exception) { }
            }
        }

        #endregion

        #endregion

        #region Static Methods

        public static string GetRealPath(ShellItem item)
        {
            if (item.Equals(item.browser.DesktopItem))
            {
                return "::{450d8fba-ad25-11d0-98a8-0800361b1103}";
            }
            else if (item.Type == item.Browser.SystemFolderName)
            {
                IntPtr strr = Marshal.AllocCoTaskMem(ShellAPI.MAX_PATH * 2 + 4);
                Marshal.WriteInt32(strr, 0, 0);
                StringBuilder buf = new StringBuilder(ShellAPI.MAX_PATH);

                if (item.ParentItem.ShellFolder.GetDisplayNameOf(
                                item.PIDLRel.Ptr,
                                ShellAPI.SHGNO.FORPARSING,
                                strr) == ShellAPI.S_OK)
                {
                    ShellAPI.StrRetToBuf(strr, item.PIDLRel.Ptr, buf, ShellAPI.MAX_PATH);
                }

                Marshal.FreeCoTaskMem(strr);

                return buf.ToString();
            }
            else
                return item.Path;
        }

        public static void UpdateShellFolders(ShellItem item)
        {
            item.UpdateShellFolder = true;

            foreach (ShellItem child in item.SubFolders)
                ShellItem.UpdateShellFolders(child);
        }

        #endregion

        #region Properties

        internal ShellBrowser Browser { get { return browser; } }

        internal ShellItem ParentItem { get { return parentItem; } }
        internal ShellItemCollection SubFiles { get { return subFiles; } }
        internal ShellItemCollection SubFolders { get { return subFolders; } }

        internal IShellFolder ShellFolder
        {
            get
            {
                if (updateShellFolder)
                {
                    Marshal.ReleaseComObject(shellFolder);
                    Marshal.Release(shellFolderPtr);

                    if (ParentItem.ShellFolder.BindToObject(
                                pidlRel.Ptr,
                                IntPtr.Zero,
                                ref ShellAPI.IID_IShellFolder,
                                out shellFolderPtr) == ShellAPI.S_OK)
                    {
                        shellFolder = (IShellFolder)Marshal.GetTypedObjectForIUnknown(shellFolderPtr, typeof(IShellFolder));
                    }

                    updateShellFolder = false;
                }

                return shellFolder;
            }
        }

        internal int ImageIndex
        {
            get { return imageIndex; }
            set { imageIndex = value; }
        }
        internal int SelectedImageIndex
        {
            get { return selectedImageIndex; }
            set { selectedImageIndex = value; }
        }

        internal PIDL PIDLRel { get { return pidlRel; } }
        internal PIDL PIDLFull
        {
            get
            {
                PIDL pidlFull = new PIDL(pidlRel.Ptr, true);
                ShellItem current = ParentItem;
                while (current != null)
                {
                    pidlFull.Insert(current.PIDLRel.Ptr);
                    current = current.ParentItem;
                }
                return pidlFull;
            }
        }

        public string Text { get { return text; } }
        public string Path { get { return path; } }

        public string Type { get { return type; } }
        internal short SortFlag { get { return sortFlag; } }

        public bool FilesExpanded { get { return filesExpanded; } }
        public bool FoldersExpanded { get { return foldersExpanded; } }

        public bool IsSystemFolder { get { return type == browser.SystemFolderName; } }

        public bool IsHidden { get { return isHidden; } }
        public bool IsFolder { get { return isFolder; } }
        public bool IsLink { get { return isLink; } }
        public bool IsShared { get { return isShared; } }
        public bool IsFileSystem { get { return isFileSystem; } }
        public bool IsBrowsable { get { return isBrowsable; } }
        public bool HasSubfolder { get { return hasSubfolder; } }
        public bool IsDisk { get { return isDisk; } }
        public bool CanRename { get { return canRename; } }
        public bool CanRead { get { return canRead; } }

        internal bool UpdateShellFolder
        {
            get { return updateShellFolder; }
            set { updateShellFolder = value; }
        }

        #endregion

        #region IEnumerable Members

        public System.Collections.IEnumerator GetEnumerator()
        {
            return new ShellItemEnumerator(this);
        }

        #endregion

        #region IDisposable

        void IDisposable.Dispose()
        {
            if (!disposed)
            {
                DisposeShellItem();
                GC.SuppressFinalize(this);
            }
        }

        private void DisposeShellItem()
        {
            disposed = true;

            if (ShellFolder != null)
            {
                Marshal.ReleaseComObject(ShellFolder);
                shellFolder = null;
            }

            if (shellFolderPtr != IntPtr.Zero)
            {
                try
                {
                    Marshal.Release(shellFolderPtr);
                }
                catch (Exception) { }
                finally
                {
                    shellFolderPtr = IntPtr.Zero;
                }
            }

            PIDLRel.Free();
        }

        #endregion

        #region IComparable

        private static short MakeSortFlag(ShellItem item)
        {
            if (item.IsFolder)
            {
                if (item.IsDisk)
                    return 1;
                if (item.Text == item.browser.MyDocumentsName &&
                    item.Type == item.Browser.SystemFolderName)
                    return 2;
                else if (item.Text == item.browser.MyComputerName)
                    return 3;
                else if (item.Type == item.Browser.SystemFolderName)
                {
                    if (!item.IsBrowsable)
                        return 4;
                    else
                        return 5;
                }
                else if (item.IsFolder && !item.IsBrowsable)
                    return 6;
                else
                    return 7;
            }
            else
                return 8;
        }

        public int CompareTo(object obj)
        {
            ShellItem other = (ShellItem)obj;

            if (SortFlag != other.SortFlag)
                return ((SortFlag > other.SortFlag) ? 1 : -1);
            else if (IsDisk)
                return string.Compare(Path, other.Path);
            else
                return string.Compare(Text, other.Text);
        }

        #endregion

        #region IList Members

        internal bool Contains(ShellItem value)
        {
            return (SubFolders.Contains(value) || SubFiles.Contains(value));
        }

        internal bool Contains(string name)
        {
            return (SubFolders.Contains(name) || SubFiles.Contains(name));
        }

        internal bool Contains(IntPtr pidl)
        {
            return (SubFolders.Contains(pidl) || SubFiles.Contains(pidl));
        }

        internal int IndexOf(ShellItem value)
        {
            int index;
            index = SubFolders.IndexOf(value);

            if (index > -1)
                return index;

            index = SubFiles.IndexOf(value);

            if (index > -1)
                return SubFolders.Count + index;

            return -1;
        }

        internal int IndexOf(string name)
        {
            int index;
            index = SubFolders.IndexOf(name);

            if (index > -1)
                return index;

            index = SubFiles.IndexOf(name);

            if (index > -1)
                return SubFolders.Count + index;

            return -1;
        }

        internal int IndexOf(IntPtr pidl)
        {
            int index;
            index = SubFolders.IndexOf(pidl);

            if (index > -1)
                return index;

            index = SubFiles.IndexOf(pidl);

            if (index > -1)
                return SubFolders.Count + index;

            return -1;
        }

        internal ShellItem this[int index]
        {
            get
            {
                if (index >= 0 && index < SubFolders.Count)
                    return SubFolders[index];
                else if (index >= 0 && index - SubFolders.Count < SubFiles.Count)
                    return SubFiles[index - SubFolders.Count];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < SubFolders.Count)
                    SubFolders[index] = value;
                else if (index >= 0 && index - SubFolders.Count < SubFiles.Count)
                    SubFiles[index - SubFolders.Count] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }

        internal ShellItem this[string name]
        {
            get
            {
                ShellItem temp = SubFolders[name];

                if (temp != null)
                    return temp;
                else
                    return SubFiles[name];
            }
            set
            {
                ShellItem temp = SubFolders[name];

                if (temp != null)
                    SubFolders[name] = value;
                else
                    SubFiles[name] = value;
            }
        }

        internal ShellItem this[IntPtr pidl]
        {
            get
            {
                ShellItem temp = SubFolders[pidl];

                if (temp != null)
                    return temp;
                else
                    return SubFiles[pidl];
            }
            set
            {
                ShellItem temp = SubFolders[pidl];

                if (temp != null)
                    SubFolders[pidl] = value;
                else
                    SubFiles[pidl] = value;
            }
        }

        internal int Count
        {
            get { return SubFolders.Count + SubFiles.Count; }
        }

        #endregion

        public override string ToString()
        {
            return text;
        }
    }

    #region ShellItem Utility Classes

    #region Update Helpers

    internal class ShellItemUpdateCondition
    {
        private bool continueUpdate;

        public ShellItemUpdateCondition()
        {
            continueUpdate = true;
        }

        public bool ContinueUpdate
        {
            get { return continueUpdate; }
            set { continueUpdate = value; }
        }
    }

    #endregion

    #region Item Enumeration

    public class ShellItemEnumerator : IEnumerator
    {
        private ShellItem parent;
        private int index;

        public ShellItemEnumerator(ShellItem parent)
        {
            this.parent = parent;
            index = -1;
        }

        #region IEnumerator Members

        public object Current
        {
            get
            {
                return parent[index];
            }
        }

        public bool MoveNext()
        {
            index++;
            return (index < parent.Count);
        }

        public void Reset()
        {
            index = -1;
        }

        #endregion
    }

    internal class ShellItemCollection : IEnumerable
    {
        private ArrayList items;
        private ShellItem shellItem;

        public ShellItemCollection(ShellItem shellItem)
        {
            this.shellItem = shellItem;
            items = new ArrayList();
        }

        public ShellItem ShellItem { get { return shellItem; } }

        #region ArrayList Members

        public int Count
        {
            get { return items.Count; }
        }

        public void Sort()
        {
            items.Sort();
        }

        internal int Capacity
        {
            get { return items.Capacity; }
            set { items.Capacity = value; }
        }

        #endregion

        #region IList Members

        internal int Add(ShellItem value)
        {
            return items.Add(value);
        }

        internal void Clear()
        {
            items.Clear();
        }

        public bool Contains(ShellItem value)
        {
            return items.Contains(value);
        }

        public bool Contains(string name)
        {
            foreach (ShellItem item in this)
            {
                if (string.Compare(item.Text, name, true) == 0)
                    return true;
            }

            return false;
        }

        public bool Contains(IntPtr pidl)
        {
            foreach (ShellItem item in this)
            {
                if (item.PIDLRel.Equals(pidl))
                    return true;
            }

            return false;
        }

        public int IndexOf(ShellItem value)
        {
            return items.IndexOf(value);
        }

        public int IndexOf(string name)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (string.Compare(this[i].Text, name, true) == 0)
                    return i;
            }

            return -1;
        }

        public int IndexOf(IntPtr pidl)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (this[i].PIDLRel.Equals(pidl))
                    return i;
            }

            return -1;
        }

        internal void Insert(int index, ShellItem value)
        {
            items.Insert(index, value);
        }

        public bool IsFixedSize
        {
            get { return items.IsFixedSize; }
        }

        public bool IsReadOnly
        {
            get { return items.IsReadOnly; }
        }

        internal void Remove(ShellItem value)
        {
            items.Remove(value);
        }

        internal void Remove(string name)
        {
            int index;

            if ((index = IndexOf(name)) > -1)
                RemoveAt(index);
        }

        internal void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }

        public ShellItem this[int index]
        {
            get
            {
                try
                {
                    return (ShellItem)items[index];
                }
                catch (ArgumentOutOfRangeException)
                {
                    return null;
                }
            }
            set
            {
                items[index] = value;
            }
        }

        public ShellItem this[string name]
        {
            get
            {
                int index;
                if ((index = IndexOf(name)) > -1)
                    return (ShellItem)items[index];
                else
                    return null;
            }
            set
            {
                int index;
                if ((index = IndexOf(name)) > -1)
                    items[index] = value;
            }
        }

        public ShellItem this[IntPtr pidl]
        {
            get
            {
                int index;
                if ((index = IndexOf(pidl)) > -1)
                    return (ShellItem)items[index];
                else
                    return null;
            }
            set
            {
                int index;
                if ((index = IndexOf(pidl)) > -1)
                    items[index] = value;
            }
        }

        #endregion

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }

        #endregion
    }

    #endregion

    #endregion
}