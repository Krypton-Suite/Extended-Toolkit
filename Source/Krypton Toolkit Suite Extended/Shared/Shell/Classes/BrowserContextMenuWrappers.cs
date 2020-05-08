using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Shell
{
    /// <summary>
    /// This class takes care of showing ContextMenu's for a BrowserTreeView
    /// </summary>
    internal class BrowserTVContextMenuWrapper : NativeWindow
    {
        #region Fields

        // The browser for which to provide the context menu's
        private Browser br;

        // If this bool is true the next time the context menu has to be shown will be cancelled
        private bool suspendContextMenu;

        // The interfaces for the needed context menu's
        private IContextMenu iContextMenu;
        private IContextMenu2 iContextMenu2;
        private IContextMenu3 iContextMenu3;

        private bool contextMenuVisible;

        // The cmd for a custom added menu item
        private enum CMD_CUSTOM
        {
            ExpandCollapse = (int)ShellAPI.CMD_LAST + 1
        }

        #endregion

        /// <summary>
        /// Registers the neccesairy events
        /// </summary>
        /// <param name="br">The browser for which to support the ContextMenu</param>
        public BrowserTVContextMenuWrapper(Browser br)
        {
            this.br = br;

            br.FolderView.MouseUp += new System.Windows.Forms.MouseEventHandler(FolderView_MouseUp);
            br.FolderView.AfterLabelEdit += new NodeLabelEditEventHandler(FolderView_AfterLabelEdit);
            br.FolderView.BeforeLabelEdit += new NodeLabelEditEventHandler(FolderView_BeforeLabelEdit);
            br.FolderView.KeyDown += new KeyEventHandler(FolderView_KeyDown);

            this.CreateHandle(new CreateParams());
        }

        #region Public

        public bool SuspendContextMenu
        {
            get { return suspendContextMenu; }
            set { suspendContextMenu = value; }
        }

        #endregion

        #region Override

        /// <summary>
        /// This method receives WindowMessages. It will make the "Open With" and "Send To" work 
        /// by calling HandleMenuMsg and HandleMenuMsg2. It will also call the OnContextMenuMouseHover 
        /// method of Browser when hovering over a ContextMenu item.
        /// </summary>
        /// <param name="m">the Message of the Browser's WndProc</param>
        /// <returns>true if the message has been handled, false otherwise</returns>
        protected override void WndProc(ref Message m)
        {
            #region IContextMenu

            if (iContextMenu != null &&
                m.Msg == (int)ShellAPI.WM.MENUSELECT &&
                ((int)ShellHelper.HiWord(m.WParam) & (int)ShellAPI.MFT.SEPARATOR) == 0 &&
                ((int)ShellHelper.HiWord(m.WParam) & (int)ShellAPI.MFT.POPUP) == 0)
            {
                string info = string.Empty;

                if (ShellHelper.LoWord(m.WParam) == (int)CMD_CUSTOM.ExpandCollapse)
                    info = "Expands or collapses the current selected item";
                else
                {
                    info = ContextMenuHelper.GetCommandString(
                        iContextMenu,
                        ShellHelper.LoWord(m.WParam) - ShellAPI.CMD_FIRST,
                        false);
                }

                br.OnContextMenuMouseHover(new ContextMenuMouseHoverEventArgs(info.ToString()));
            }

            #endregion

            #region IContextMenu2

            if (iContextMenu2 != null &&
                (m.Msg == (int)ShellAPI.WM.INITMENUPOPUP ||
                 m.Msg == (int)ShellAPI.WM.MEASUREITEM ||
                 m.Msg == (int)ShellAPI.WM.DRAWITEM))
            {
                if (iContextMenu2.HandleMenuMsg(
                    (uint)m.Msg, m.WParam, m.LParam) == ShellAPI.S_OK)
                    return;
            }

            #endregion

            #region IContextMenu3

            if (iContextMenu3 != null &&
                m.Msg == (int)ShellAPI.WM.MENUCHAR)
            {
                if (iContextMenu3.HandleMenuMsg2(
                    (uint)m.Msg, m.WParam, m.LParam, IntPtr.Zero) == ShellAPI.S_OK)
                    return;
            }

            #endregion            

            base.WndProc(ref m);
        }

        #endregion

        #region Events

        void FolderView_KeyDown(object sender, KeyEventArgs e)
        {
            ContextMenuHelper.ProcessKeyCommands(br, sender, e);
        }

        void FolderView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            ShellItem item = e.Node.Tag as ShellItem;

            if (!item.CanRename)
            {
                e.CancelEdit = true;
                System.Media.SystemSounds.Beep.Play();
            }
            if (item.IsDisk)
            {
                IntPtr editHandle = ShellAPI.SendMessage(br.FolderView.Handle, ShellAPI.WM.TVM_GETEDITCONTROL, 0, IntPtr.Zero);
                ShellAPI.SendMessage(editHandle, ShellAPI.WM.SETTEXT, 0,
                    Marshal.StringToHGlobalAuto(item.Text.Substring(0, item.Text.LastIndexOf(' '))));
            }
        }

        void FolderView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            ShellItem item = e.Node.Tag as ShellItem;

            IntPtr newPidl = IntPtr.Zero;
            if (e.Label != null && !(item.IsDisk && item.Text.Substring(0, item.Text.LastIndexOf(' ')) == e.Label) &&
                item.ParentItem.ShellFolder.SetNameOf(
                    br.Handle,
                    item.PIDLRel.Ptr,
                    e.Label,
                    ShellAPI.SHGNO.NORMAL,
                    out newPidl) == ShellAPI.S_OK)
            {
                item.Update(newPidl, ShellItemUpdateType.Renamed);
            }
            else
            {
                e.CancelEdit = true;
            }

            br.FolderView.LabelEdit = false;
        }

        /// <summary>
        /// When the mouse goes up on an node and suspendContextMenu is true, this method will show the
        /// ContextMenu for that node and after the user selects an item, it will execute that command.
        /// </summary>
        void FolderView_MouseUp(object sender, MouseEventArgs e)
        {
            if (suspendContextMenu || contextMenuVisible)
            {
                suspendContextMenu = false;
                return;
            }

            TreeViewHitTestInfo hitTest = br.FolderView.HitTest(e.Location);

            contextMenuVisible = true;
            if (e.Button == MouseButtons.Right &&
                (hitTest.Location == TreeViewHitTestLocations.Image ||
                hitTest.Location == TreeViewHitTestLocations.Label ||
                hitTest.Location == TreeViewHitTestLocations.StateImage))
            {
                #region Fields
                ShellItem item = (ShellItem)hitTest.Node.Tag;

                IntPtr contextMenu = IntPtr.Zero,
                    iContextMenuPtr = IntPtr.Zero,
                    iContextMenuPtr2 = IntPtr.Zero,
                    iContextMenuPtr3 = IntPtr.Zero;
                IShellFolder parentShellFolder =
                    (item.ParentItem != null) ? item.ParentItem.ShellFolder : item.ShellFolder;

                #endregion

                #region Show / Invoke
                try
                {
                    if (ContextMenuHelper.GetIContextMenu(parentShellFolder, new IntPtr[] { item.PIDLRel.Ptr },
                            out iContextMenuPtr, out iContextMenu))
                    {
                        contextMenu = ShellAPI.CreatePopupMenu();

                        iContextMenu.QueryContextMenu(
                            contextMenu,
                            0,
                            ShellAPI.CMD_FIRST,
                            ShellAPI.CMD_LAST,
                            ShellAPI.CMF.EXPLORE |
                            ShellAPI.CMF.CANRENAME |
                            ((Control.ModifierKeys & Keys.Shift) != 0 ? ShellAPI.CMF.EXTENDEDVERBS : 0));

                        string topInvoke = hitTest.Node.IsExpanded ? "Collapse" : "Expand";
                        ShellAPI.MFT extraFlag = (hitTest.Node.Nodes.Count > 0) ? 0 : ShellAPI.MFT.GRAYED;
                        ShellAPI.InsertMenu(contextMenu, 0,
                            ShellAPI.MFT.BYPOSITION | extraFlag,
                            (int)CMD_CUSTOM.ExpandCollapse, topInvoke);
                        ShellAPI.InsertMenu(contextMenu, 1,
                            ShellAPI.MFT.BYPOSITION | ShellAPI.MFT.SEPARATOR,
                            0, "-");

                        ShellAPI.SetMenuDefaultItem(
                            contextMenu,
                            0,
                            true);

                        Marshal.QueryInterface(iContextMenuPtr, ref ShellAPI.IID_IContextMenu2, out iContextMenuPtr2);
                        Marshal.QueryInterface(iContextMenuPtr, ref ShellAPI.IID_IContextMenu3, out iContextMenuPtr3);

                        try
                        {
                            iContextMenu2 =
                                (IContextMenu2)Marshal.GetTypedObjectForIUnknown(iContextMenuPtr2, typeof(IContextMenu2));

                            iContextMenu3 =
                                (IContextMenu3)Marshal.GetTypedObjectForIUnknown(iContextMenuPtr3, typeof(IContextMenu3));
                        }
                        catch (Exception) { }

                        Point ptInvoke = br.FolderView.PointToScreen(e.Location);
                        uint selected = ShellAPI.TrackPopupMenuEx(
                                            contextMenu,
                                            ShellAPI.TPM.RETURNCMD,
                                            ptInvoke.X,
                                            ptInvoke.Y,
                                            this.Handle,
                                            IntPtr.Zero);

                        br.OnContextMenuMouseHover(new ContextMenuMouseHoverEventArgs(string.Empty));

                        if (selected == (int)CMD_CUSTOM.ExpandCollapse)
                        {
                            if (hitTest.Node.IsExpanded)
                                hitTest.Node.Collapse(true);
                            else
                                hitTest.Node.Expand();
                        }
                        else if (selected >= ShellAPI.CMD_FIRST)
                        {
                            string command = ContextMenuHelper.GetCommandString(
                                iContextMenu,
                                selected - ShellAPI.CMD_FIRST,
                                true);

                            if (command == "rename")
                            {
                                br.FolderView.LabelEdit = true;
                                hitTest.Node.BeginEdit();
                            }
                            else
                            {
                                ContextMenuHelper.InvokeCommand(
                                    iContextMenu,
                                    selected - ShellAPI.CMD_FIRST,
                                    (item.ParentItem != null) ?
                                    ShellItem.GetRealPath(item.ParentItem) : ShellItem.GetRealPath(item),
                                    ptInvoke);
                            }
                        }
                    }
                }
                #endregion
                catch (Exception) { }
                #region Finally
                finally
                {
                    if (iContextMenu != null)
                    {
                        Marshal.ReleaseComObject(iContextMenu);
                        iContextMenu = null;
                    }

                    if (iContextMenu2 != null)
                    {
                        Marshal.ReleaseComObject(iContextMenu2);
                        iContextMenu2 = null;
                    }

                    if (iContextMenu3 != null)
                    {
                        Marshal.ReleaseComObject(iContextMenu3);
                        iContextMenu3 = null;
                    }

                    if (contextMenu != null)
                        ShellAPI.DestroyMenu(contextMenu);

                    if (iContextMenuPtr != IntPtr.Zero)
                        Marshal.Release(iContextMenuPtr);

                    if (iContextMenuPtr2 != IntPtr.Zero)
                        Marshal.Release(iContextMenuPtr2);

                    if (iContextMenuPtr3 != IntPtr.Zero)
                        Marshal.Release(iContextMenuPtr3);
                }
                #endregion
            }
            contextMenuVisible = false;
        }

        #endregion
    }

    /// <summary>
    /// This class takes care of showing ContextMenu's for a BrowserListView and 
    /// executing items when pressing enter or double clicking
    /// </summary>
    internal class BrowserLVContextMenuWrapper : NativeWindow
    {
        #region Fields

        // The browser for which to provide the context menu's
        private Browser br;

        private BrowserPluginWrapper pluginWrapper;
        private StreamStorageProvider provider;

        private BackgroundWorker viewPluginWorker;
        private System.Windows.Forms.Timer viewPluginTimer;
        private delegate void ViewPluginFileChange(IFileInfoProvider provider, ShellItem item);
        private delegate void ViewPluginFolderChange(IDirInfoProvider provider, ShellItem item);

        private delegate void ToolTipDelegate(ListViewItem listItem);
        private ToolTipDelegate toolTipDelegate;

        // If this bool is true the next time the context menu has to be shown will be cancelled
        private bool suspendContextMenu;

        // The interfaces for the needed context menu's
        private IContextMenu iContextMenu, newContextMenu;
        private IContextMenu2 iContextMenu2, newContextMenu2;
        private IContextMenu3 iContextMenu3, newContextMenu3;

        private IntPtr newSubmenuPtr;

        private bool contextMenuVisible;

        // The cmd for a custom added menu item
        private enum CMD_CUSTOM
        {
            Tiles = (int)ShellAPI.CMD_LAST + 1,
            Icons,
            List,
            Details,
            Properties,
            Paste,
            Paste_ShortCut,
            SpecialView
        }

        #endregion

        /// <summary>
        /// Registers the neccesairy events
        /// </summary>
        /// <param name="br">The browser for which to support the ContextMenu</param>
        public BrowserLVContextMenuWrapper(Browser br, BrowserPluginWrapper pluginWrapper)
        {
            this.br = br;
            this.pluginWrapper = pluginWrapper;

            provider = new StreamStorageProvider(FileAccess.ReadWrite);
            viewPluginWorker = new BackgroundWorker();
            viewPluginWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            viewPluginTimer = new System.Windows.Forms.Timer();
            viewPluginTimer.Tick += new EventHandler(viewPluginTimer_Tick);
            viewPluginTimer.Interval = 300;

            br.FileView.ShowItemToolTips = true;
            toolTipDelegate = new ToolTipDelegate(SetToolTip);

            br.SelectedFolderChanged += new SelectedFolderChangedEventHandler(br_SelectedFolderChanged);

            br.FileView.LabelEdit = true;
            br.FileView.MouseUp += new MouseEventHandler(FileView_MouseUp);
            br.FileView.ItemActivate += new EventHandler(FileView_ItemActivate);
            br.FileView.AfterLabelEdit += new LabelEditEventHandler(FileView_AfterLabelEdit);
            br.FileView.BeforeLabelEdit += new LabelEditEventHandler(FileView_BeforeLabelEdit);
            br.FileView.KeyDown += new KeyEventHandler(FileView_KeyDown);
            br.FileView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(FileView_ItemSelectionChanged);
            br.FileView.ItemMouseHover += new ListViewItemMouseHoverEventHandler(FileView_ItemMouseHover);

            this.CreateHandle(new CreateParams());
        }

        #region Public

        public bool SuspendContextMenu
        {
            get { return suspendContextMenu; }
            set { suspendContextMenu = value; }
        }

        #endregion

        #region Override

        /// <summary>
        /// This method receives WindowMessages. It will make the "Open With" and "Send To" work 
        /// by calling HandleMenuMsg and HandleMenuMsg2. It will also call the OnContextMenuMouseHover 
        /// method of Browser when hovering over a ContextMenu item.
        /// </summary>
        /// <param name="m">the Message of the Browser's WndProc</param>
        /// <returns>true if the message has been handled, false otherwise</returns>
        protected override void WndProc(ref Message m)
        {
            #region IContextMenu

            if (iContextMenu != null &&
                m.Msg == (int)ShellAPI.WM.MENUSELECT &&
                ((int)ShellHelper.HiWord(m.WParam) & (int)ShellAPI.MFT.SEPARATOR) == 0 &&
                ((int)ShellHelper.HiWord(m.WParam) & (int)ShellAPI.MFT.POPUP) == 0)
            {
                string info = string.Empty;
                info = ContextMenuHelper.GetCommandString(
                    iContextMenu,
                    ShellHelper.LoWord(m.WParam) - ShellAPI.CMD_FIRST,
                    false);
                br.OnContextMenuMouseHover(new ContextMenuMouseHoverEventArgs(info.ToString()));
            }

            #endregion

            #region IContextMenu2

            if (iContextMenu2 != null &&
                (m.Msg == (int)ShellAPI.WM.INITMENUPOPUP ||
                 m.Msg == (int)ShellAPI.WM.MEASUREITEM ||
                 m.Msg == (int)ShellAPI.WM.DRAWITEM))
            {
                if (iContextMenu2.HandleMenuMsg(
                    (uint)m.Msg, m.WParam, m.LParam) == ShellAPI.S_OK)
                    return;
            }

            if (newContextMenu2 != null &&
                ((m.Msg == (int)ShellAPI.WM.INITMENUPOPUP && m.WParam == newSubmenuPtr) ||
                 m.Msg == (int)ShellAPI.WM.MEASUREITEM ||
                 m.Msg == (int)ShellAPI.WM.DRAWITEM))
            {
                if (newContextMenu2.HandleMenuMsg(
                    (uint)m.Msg, m.WParam, m.LParam) == ShellAPI.S_OK)
                    return;
            }

            #endregion

            #region IContextMenu3

            if (iContextMenu3 != null &&
                m.Msg == (int)ShellAPI.WM.MENUCHAR)
            {
                if (iContextMenu3.HandleMenuMsg2(
                    (uint)m.Msg, m.WParam, m.LParam, IntPtr.Zero) == ShellAPI.S_OK)
                    return;
            }

            if (newContextMenu3 != null &&
                m.Msg == (int)ShellAPI.WM.MENUCHAR)
            {
                if (newContextMenu3.HandleMenuMsg2(
                    (uint)m.Msg, m.WParam, m.LParam, IntPtr.Zero) == ShellAPI.S_OK)
                    return;
            }

            #endregion   

            base.WndProc(ref m);
        }

        #endregion

        #region Events

        void FileView_KeyDown(object sender, KeyEventArgs e)
        {
            ContextMenuHelper.ProcessKeyCommands(br, sender, e);
        }

        void FileView_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            ShellItem item = br.FileView.Items[e.Item].Tag as ShellItem;

            if (!item.CanRename)
            {
                e.CancelEdit = true;
                System.Media.SystemSounds.Beep.Play();
                return;
            }
            else if (item.IsDisk)
            {
                IntPtr editHandle = ShellAPI.SendMessage(br.FileView.Handle, ShellAPI.WM.LVM_GETEDITCONTROL, 0, IntPtr.Zero);
                ShellAPI.SendMessage(editHandle, ShellAPI.WM.SETTEXT, 0,
                    Marshal.StringToHGlobalAuto(item.Text.Substring(0, item.Text.LastIndexOf(' '))));
            }
        }

        void FileView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            ShellItem item = br.FileView.Items[e.Item].Tag as ShellItem;

            if (e.Label != null && br.FileView.SelectedOrder.Count == 1)
            {
                #region Rename One
                IntPtr newPidl = IntPtr.Zero;
                if (!(item.IsDisk && item.Text.Substring(0, item.Text.LastIndexOf(' ')) == e.Label) &&
                    item.ParentItem.ShellFolder.SetNameOf(
                        br.Handle,
                        item.PIDLRel.Ptr,
                        e.Label,
                        ShellAPI.SHGNO.NORMAL,
                        out newPidl) == ShellAPI.S_OK)
                {
                    item.Update(newPidl, ShellItemUpdateType.Renamed);
                }
                else
                    e.CancelEdit = true;
                #endregion
            }
            else if (e.Label != null)
            {
                #region Rename Batch
                string label = (!string.IsNullOrEmpty(e.Label) ? e.Label : br.FileView.Items[e.Item].Text);

                string startString = Path.GetFileNameWithoutExtension(label);
                string endString = Path.GetExtension(label);

                int countLength = br.FileView.SelectedOrder.Count.ToString().Length;

                IntPtr newPidl = IntPtr.Zero;
                ShellItem shellItem;
                ListViewItem listItem;

                StringBuilder renameString = new StringBuilder(startString.Length + endString.Length + countLength);
                renameString.Append(startString);
                renameString.Append('0', countLength);
                renameString.Append(endString);

                string counter;
                for (int i = 1; i <= br.FileView.SelectedOrder.Count; i++)
                {
                    listItem = br.FileView.SelectedOrder[i - 1] as ListViewItem;
                    shellItem = listItem.Tag as ShellItem;

                    if (shellItem.IsDisk)
                        continue;

                    counter = i.ToString();
                    renameString.Insert(startString.Length, "0", countLength - counter.Length);
                    renameString.Insert(startString.Length + countLength - counter.Length, counter);
                    renameString.Remove(startString.Length + countLength, countLength);

                    if (shellItem.ParentItem.ShellFolder.SetNameOf(
                            (i == 1 ? br.Handle : IntPtr.Zero),
                            shellItem.PIDLRel.Ptr,
                            renameString.ToString(),
                            ShellAPI.SHGNO.NORMAL,
                            out newPidl) == ShellAPI.S_OK)
                    {
                        shellItem.Update(newPidl, ShellItemUpdateType.Renamed);
                    }
                    else if (i == 1)
                        break;
                }

                e.CancelEdit = true;
                #endregion
            }
        }

        /// <summary>
        /// When items are activated (by pressing enter or double clicking) this method will invoke
        /// the default item of the items contextmenu.
        /// </summary>
        void FileView_ItemActivate(object sender, EventArgs e)
        {
            TreeNode parent = br.FolderView.SelectedNode;

            if (parent != null && br.FileView.SelectedOrder.Count > 0)
            {
                ListViewItem listViewItem = (ListViewItem)br.FileView.SelectedOrder[0];
                ShellItem shellItem = (ShellItem)listViewItem.Tag;
                int startIndex = 0;

                if ((Control.ModifierKeys & Keys.Alt) == 0)
                {
                    if (shellItem.IsFolder)
                    {
                        if (!parent.IsExpanded)
                            parent.Expand();

                        br.FolderView.SelectedNode = parent.Nodes[listViewItem.Text];
                        startIndex = 1;
                    }

                    if (br.FileView.SelectedOrder.Count - startIndex > 0)
                    {
                        #region Fields

                        IntPtr[] pidls = new IntPtr[br.FileView.SelectedOrder.Count - startIndex];
                        for (int i = startIndex; i < pidls.Length; i++)
                        {
                            pidls[i - startIndex] = ((ShellItem)((ListViewItem)br.FileView.SelectedOrder[i]).Tag).PIDLRel.Ptr;
                        }

                        IntPtr icontextMenuPtr = IntPtr.Zero, context2Ptr = IntPtr.Zero, context3Ptr = IntPtr.Zero;
                        ContextMenu contextMenu = new ContextMenu();
                        ShellItem parentShellItem = (ShellItem)parent.Tag;
                        IShellFolder parentShellFolder = parentShellItem.ShellFolder;

                        #endregion

                        #region Show / Invoke

                        try
                        {
                            if (ContextMenuHelper.GetIContextMenu(parentShellFolder, pidls, out icontextMenuPtr, out iContextMenu))
                            {
                                iContextMenu.QueryContextMenu(
                                    contextMenu.Handle,
                                    0,
                                    ShellAPI.CMD_FIRST,
                                    ShellAPI.CMD_LAST,
                                    ShellAPI.CMF.DEFAULTONLY);

                                int defaultCommand = ShellAPI.GetMenuDefaultItem(contextMenu.Handle, false, 0);
                                if (defaultCommand >= ShellAPI.CMD_FIRST)
                                {
                                    ContextMenuHelper.InvokeCommand(
                                        iContextMenu,
                                        (uint)defaultCommand - ShellAPI.CMD_FIRST,
                                        ShellItem.GetRealPath(parentShellItem),
                                        Control.MousePosition);
                                }
                            }
                        }
                        #endregion
                        catch (Exception) { }
                        #region Finally
                        finally
                        {
                            if (iContextMenu != null)
                            {
                                Marshal.ReleaseComObject(iContextMenu);
                                iContextMenu = null;
                            }

                            if (contextMenu.Handle != null)
                                Marshal.FreeCoTaskMem(contextMenu.Handle);

                            Marshal.Release(icontextMenuPtr);
                        }
                        #endregion
                    }
                }
                else
                {
                    IntPtr[] pidls = new IntPtr[br.FileView.SelectedOrder.Count - startIndex];
                    for (int i = startIndex; i < pidls.Length; i++)
                    {
                        pidls[i - startIndex] = ((ShellItem)((ListViewItem)br.FileView.SelectedOrder[i]).Tag).PIDLRel.Ptr;
                    }

                    ContextMenuHelper.InvokeCommand(shellItem.ParentItem, pidls, "properties", Control.MousePosition);
                }
            }
        }

        /// <summary>
        /// When the mouse goes up on an item and suspendContextMenu is true, this method will show the
        /// ContextMenu for that item and after the user selects an item, it will execute that command.
        /// </summary>
        void FileView_MouseUp(object sender, MouseEventArgs e)
        {
            if (suspendContextMenu || contextMenuVisible)
            {
                suspendContextMenu = false;
                return;
            }

            ListViewHitTestInfo hitTest = br.FileView.HitTest(e.Location);
            Point ptInvoke = br.FileView.PointToScreen(e.Location);

            contextMenuVisible = true;
            if (e.Button == MouseButtons.Right &&
                hitTest.Item != null &&
                (br.FileView.View != View.Details || (hitTest.SubItem != null && hitTest.Item.Name == hitTest.SubItem.Name)) &&
                (hitTest.Location == ListViewHitTestLocations.Image ||
                hitTest.Location == ListViewHitTestLocations.Label ||
                hitTest.Location == ListViewHitTestLocations.StateImage))
            {
                CreateNormalMenu(ptInvoke, hitTest, e);
            }
            else if (e.Button == MouseButtons.Right)
            {
                CreateFolderMenu(ptInvoke, e);
            }
            contextMenuVisible = false;
        }

        private void CreateNormalMenu(Point ptInvoke, ListViewHitTestInfo hitTest, MouseEventArgs e)
        {
            hitTest.Item.Selected = true;

            #region Fields

            ShellItem item = (ShellItem)hitTest.Item.Tag;

            int offset = br.FileView.SelectedOrder.Contains(hitTest.Item) ? 0 : 1;
            IntPtr[] pidls = new IntPtr[br.FileView.SelectedOrder.Count + offset];

            if (offset == 1)
                pidls[0] = item.PIDLRel.Ptr;

            for (int i = offset; i < pidls.Length; i++)
            {
                pidls[i] = ((ShellItem)((ListViewItem)br.FileView.SelectedOrder[i - offset]).Tag).PIDLRel.Ptr;
            }


            IntPtr contextMenu = IntPtr.Zero,
                iContextMenuPtr = IntPtr.Zero,
                iContextMenuPtr2 = IntPtr.Zero,
                iContextMenuPtr3 = IntPtr.Zero;
            IShellFolder parentShellFolder =
                (item.ParentItem != null) ? item.ParentItem.ShellFolder : item.ShellFolder;

            #endregion

            #region Show / Invoke

            try
            {
                if (ContextMenuHelper.GetIContextMenu(parentShellFolder, pidls, out iContextMenuPtr, out iContextMenu))
                {
                    contextMenu = ShellAPI.CreatePopupMenu();
                    iContextMenu.QueryContextMenu(
                        contextMenu,
                        0,
                        ShellAPI.CMD_FIRST,
                        ShellAPI.CMD_LAST,
                        ShellAPI.CMF.EXPLORE |
                        ShellAPI.CMF.CANRENAME |
                        ((Control.ModifierKeys & Keys.Shift) != 0 ? ShellAPI.CMF.EXTENDEDVERBS : 0));

                    Marshal.QueryInterface(iContextMenuPtr, ref ShellAPI.IID_IContextMenu2, out iContextMenuPtr2);
                    Marshal.QueryInterface(iContextMenuPtr, ref ShellAPI.IID_IContextMenu3, out iContextMenuPtr3);

                    try
                    {
                        iContextMenu2 =
                            (IContextMenu2)Marshal.GetTypedObjectForIUnknown(iContextMenuPtr2, typeof(IContextMenu2));

                        iContextMenu3 =
                            (IContextMenu3)Marshal.GetTypedObjectForIUnknown(iContextMenuPtr3, typeof(IContextMenu3));
                    }
                    catch (Exception) { }

                    uint selected = ShellAPI.TrackPopupMenuEx(
                                        contextMenu,
                                        ShellAPI.TPM.RETURNCMD,
                                        ptInvoke.X,
                                        ptInvoke.Y,
                                        this.Handle,
                                        IntPtr.Zero);

                    br.OnContextMenuMouseHover(new ContextMenuMouseHoverEventArgs(string.Empty));

                    if (selected >= ShellAPI.CMD_FIRST)
                    {
                        string command = ContextMenuHelper.GetCommandString(iContextMenu, selected - ShellAPI.CMD_FIRST, true);

                        if (command == "Explore" && br.FolderView.SelectedNode != null)
                        {
                            if (!br.FolderView.SelectedNode.IsExpanded)
                                br.FolderView.SelectedNode.Expand();

                            br.FolderView.SelectedNode = br.FolderView.SelectedNode.Nodes[hitTest.Item.Text];
                        }
                        else if (command == "rename")
                        {
                            hitTest.Item.BeginEdit();
                        }
                        else
                        {
                            ContextMenuHelper.InvokeCommand(
                                iContextMenu,
                                selected - ShellAPI.CMD_FIRST,
                                ShellItem.GetRealPath(br.SelectedItem),
                                ptInvoke);
                        }
                    }
                }
            }
            #endregion
            catch (Exception) { }
            #region Finally
            finally
            {
                if (iContextMenu != null)
                {
                    Marshal.ReleaseComObject(iContextMenu);
                    iContextMenu = null;
                }

                if (iContextMenu2 != null)
                {
                    Marshal.ReleaseComObject(iContextMenu2);
                    iContextMenu2 = null;
                }

                if (iContextMenu3 != null)
                {
                    Marshal.ReleaseComObject(iContextMenu3);
                    iContextMenu3 = null;
                }

                if (contextMenu != null)
                    ShellAPI.DestroyMenu(contextMenu);

                if (iContextMenuPtr != IntPtr.Zero)
                    Marshal.Release(iContextMenuPtr);

                if (iContextMenuPtr2 != IntPtr.Zero)
                    Marshal.Release(iContextMenuPtr2);

                if (iContextMenuPtr3 != IntPtr.Zero)
                    Marshal.Release(iContextMenuPtr3);
            }
            #endregion
        }

        private void CreateFolderMenu(Point ptInvoke, MouseEventArgs e)
        {
            #region Fields

            ShellItem currentItem = br.SelectedItem;

            foreach (ListViewItem item in br.FileView.SelectedItems)
                item.Selected = false;

            IntPtr contextMenu = IntPtr.Zero, viewSubMenu = IntPtr.Zero;
            IntPtr newContextMenuPtr = IntPtr.Zero, newContextMenuPtr2 = IntPtr.Zero, newContextMenuPtr3 = IntPtr.Zero;
            newSubmenuPtr = IntPtr.Zero;

            #endregion

            try
            {
                #region Make Menu

                contextMenu = ShellAPI.CreatePopupMenu();
                viewSubMenu = ShellAPI.CreatePopupMenu();

                #region View Submenu

                ShellAPI.MENUITEMINFO itemInfo = new ShellAPI.MENUITEMINFO("View");
                itemInfo.cbSize = ShellAPI.cbMenuItemInfo;
                itemInfo.fMask = ShellAPI.MIIM.SUBMENU | ShellAPI.MIIM.STRING;
                itemInfo.hSubMenu = viewSubMenu;
                ShellAPI.InsertMenuItem(contextMenu, 0, true, ref itemInfo);

                ShellAPI.MFT rCheck = ShellAPI.MFT.RADIOCHECK | ShellAPI.MFT.CHECKED;
                ShellAPI.AppendMenu(viewSubMenu,
                    (br.CurrentViewPlugin == null && br.FileView.View == View.Tile ? rCheck : 0), (uint)CMD_CUSTOM.Tiles, "Tiles");
                ShellAPI.AppendMenu(viewSubMenu,
                    (br.CurrentViewPlugin == null && br.FileView.View == View.LargeIcon ? rCheck : 0), (uint)CMD_CUSTOM.Icons, "Icons");
                ShellAPI.AppendMenu(viewSubMenu,
                    (br.CurrentViewPlugin == null && br.FileView.View == View.List ? rCheck : 0), (uint)CMD_CUSTOM.List, "List");
                ShellAPI.AppendMenu(viewSubMenu,
                    (br.CurrentViewPlugin == null && br.FileView.View == View.Details ? rCheck : 0), (uint)CMD_CUSTOM.Details, "Details");

                for (int i = 0; i < pluginWrapper.ViewPlugins.Count; i++)
                {
                    ShellAPI.AppendMenu(viewSubMenu,
                        (IViewPlugin.Equals(br.CurrentViewPlugin, pluginWrapper.ViewPlugins[i]) ? rCheck : 0),
                            (uint)CMD_CUSTOM.SpecialView + (uint)i, ((IViewPlugin)pluginWrapper.ViewPlugins[i]).ViewName);
                }

                #endregion

                #region Paste Menu

                DragDropEffects effects = ShellHelper.CanDropClipboard(currentItem);
                bool canPaste = (effects & DragDropEffects.Copy) != 0 || (effects & DragDropEffects.Move) != 0;
                bool canPasteShortCut = (effects & DragDropEffects.Link) != 0;

                ShellAPI.AppendMenu(contextMenu, ShellAPI.MFT.SEPARATOR, 0, string.Empty);
                ShellAPI.AppendMenu(contextMenu, canPaste ? 0 : ShellAPI.MFT.GRAYED, (int)CMD_CUSTOM.Paste, "Paste");
                ShellAPI.AppendMenu(contextMenu, canPasteShortCut ? 0 : ShellAPI.MFT.GRAYED, (int)CMD_CUSTOM.Paste_ShortCut, "Paste Shortcut");

                #endregion

                #region New Submenu

                if (br.SelectedItem.IsFileSystem &&
                    ContextMenuHelper.GetNewContextMenu(br.SelectedItem, out newContextMenuPtr, out newContextMenu))
                {
                    ShellAPI.AppendMenu(contextMenu, ShellAPI.MFT.SEPARATOR, 0, string.Empty);
                    newContextMenu.QueryContextMenu(
                        contextMenu,
                        5,
                        ShellAPI.CMD_FIRST,
                        ShellAPI.CMD_LAST,
                        ShellAPI.CMF.NORMAL);

                    newSubmenuPtr = ShellAPI.GetSubMenu(contextMenu, 5);

                    Marshal.QueryInterface(newContextMenuPtr, ref ShellAPI.IID_IContextMenu2, out newContextMenuPtr2);
                    Marshal.QueryInterface(newContextMenuPtr, ref ShellAPI.IID_IContextMenu3, out newContextMenuPtr3);

                    try
                    {
                        newContextMenu2 =
                            (IContextMenu2)Marshal.GetTypedObjectForIUnknown(newContextMenuPtr2, typeof(IContextMenu2));

                        newContextMenu3 =
                            (IContextMenu3)Marshal.GetTypedObjectForIUnknown(newContextMenuPtr3, typeof(IContextMenu3));
                    }
                    catch (Exception) { }
                }

                #endregion

                #region Properties Menu

                if (!br.SelectedItem.Equals(br.ShellBrowser.DesktopItem))
                {
                    ShellAPI.AppendMenu(contextMenu, ShellAPI.MFT.SEPARATOR, 0, string.Empty);
                    ShellAPI.AppendMenu(contextMenu, 0, (int)CMD_CUSTOM.Properties, "Properties");
                }

                #endregion

                #endregion

                CMD_CUSTOM selected = (CMD_CUSTOM)ShellAPI.TrackPopupMenuEx(
                                    contextMenu,
                                    ShellAPI.TPM.RETURNCMD,
                                    ptInvoke.X,
                                    ptInvoke.Y,
                                    this.Handle,
                                    IntPtr.Zero);

                #region Invoke

                if ((int)selected >= ShellAPI.CMD_FIRST)
                {
                    switch (selected)
                    {
                        #region Normal Views

                        case CMD_CUSTOM.Tiles:
                            br.FileView.View = View.Tile;
                            br.ResetSpecialView();
                            provider.ReleaseStorage();
                            provider.ReleaseStream();
                            break;
                        case CMD_CUSTOM.Icons:
                            br.FileView.View = View.LargeIcon;
                            br.ResetSpecialView();
                            provider.ReleaseStorage();
                            provider.ReleaseStream();
                            break;
                        case CMD_CUSTOM.List:
                            br.FileView.View = View.List;
                            br.ResetSpecialView();
                            provider.ReleaseStorage();
                            provider.ReleaseStream();
                            break;
                        case CMD_CUSTOM.Details:
                            br.FileView.SuspendHeaderContextMenu = true;
                            br.FileView.View = View.Details;
                            br.ResetSpecialView();
                            provider.ReleaseStorage();
                            provider.ReleaseStream();
                            break;

                        #endregion

                        #region Folder Items

                        case CMD_CUSTOM.Properties:
                            ContextMenuHelper.InvokeCommand(
                                br.SelectedItem.ParentItem,
                                new IntPtr[] { br.SelectedItem.PIDLRel.Ptr },
                                "properties",
                                ptInvoke);
                            break;

                        case CMD_CUSTOM.Paste:
                            ContextMenuHelper.InvokeCommand(
                                br.SelectedItem.ParentItem,
                                new IntPtr[] { br.SelectedItem.PIDLRel.Ptr },
                                "paste",
                                ptInvoke);
                            break;

                        case CMD_CUSTOM.Paste_ShortCut:
                            ContextMenuHelper.InvokeCommand(
                                br.SelectedItem.ParentItem,
                                new IntPtr[] { br.SelectedItem.PIDLRel.Ptr },
                                "pastelink",
                                ptInvoke);
                            break;

                        #endregion

                        default:
                            #region New
                            if ((uint)selected <= ShellAPI.CMD_LAST)
                            {
                                lock (br.ShellBrowser)
                                {
                                    br.NewItemCreated = true;
                                }

                                ContextMenuHelper.InvokeCommand(
                                    newContextMenu,
                                    (uint)selected - ShellAPI.CMD_FIRST,
                                    ShellItem.GetRealPath(br.SelectedItem),
                                    ptInvoke);
                            }
                            #endregion
                            #region Special Views
                            else
                            {
                                int index = (int)selected - (int)CMD_CUSTOM.SpecialView;

                                if (br.FileView.Alignment != ListViewAlignment.Left)
                                    br.FileView.Alignment = ListViewAlignment.Left;

                                br.FileView.View = View.LargeIcon;
                                br.CurrentViewPlugin = pluginWrapper.ViewPlugins[index] as IViewPlugin;
                                br.SpecialViewPanelVisible = true;
                                br.SpecialViewPanel.Controls.Add(br.CurrentViewPlugin.ViewControl);
                                br.CurrentViewPlugin.ViewControl.Dock = DockStyle.Fill;
                            }
                            #endregion
                            break;
                    }
                }

                #endregion
            }
            catch (Exception) { }
            #region Finally
            finally
            {
                if (newContextMenu != null)
                {
                    Marshal.ReleaseComObject(newContextMenu);
                    newContextMenu = null;
                }

                if (newContextMenu2 != null)
                {
                    Marshal.ReleaseComObject(newContextMenu2);
                    newContextMenu2 = null;
                }

                if (newContextMenu3 != null)
                {
                    Marshal.ReleaseComObject(newContextMenu3);
                    newContextMenu3 = null;
                }

                if (contextMenu != null)
                    ShellAPI.DestroyMenu(contextMenu);

                if (viewSubMenu != null)
                    ShellAPI.DestroyMenu(viewSubMenu);

                if (newContextMenuPtr != IntPtr.Zero)
                    Marshal.Release(newContextMenuPtr);

                if (newContextMenuPtr2 != IntPtr.Zero)
                    Marshal.Release(newContextMenuPtr2);

                if (newContextMenuPtr3 != IntPtr.Zero)
                    Marshal.Release(newContextMenuPtr3);

                newSubmenuPtr = IntPtr.Zero;
            }
            #endregion
        }

        #endregion

        #region IViewPlugin Methods

        private delegate void FileSelected(IFileInfoProvider provider, ShellItem item);
        private delegate void FolderSelected(IDirInfoProvider provider, ShellItem item);

        void viewPluginTimer_Tick(object sender, EventArgs e)
        {
            if (!viewPluginWorker.IsBusy)
            {
                viewPluginWorker.RunWorkerAsync();
                viewPluginTimer.Stop();
            }
        }

        void br_SelectedFolderChanged(object sender, SelectedFolderChangedEventArgs e)
        {
            if (br.CurrentViewPlugin != null)
                br.CurrentViewPlugin.Reset();
        }

        void FileView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected && br.SelectionChange && br.CurrentViewPlugin != null)
            {
                viewPluginTimer.Stop();
                provider.ProviderItem = e.Item.Tag as ShellItem;
                viewPluginTimer.Start();
            }
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            provider.ReleaseStorage();
            provider.ReleaseStream();

            try
            {
                if (provider.ProviderItem.CanRead)
                {
                    IAsyncResult asyncResult = null;

                    if (provider.ProviderItem.IsFolder)
                    {
                        FolderSelected selectedDelegate = new FolderSelected(br.CurrentViewPlugin.FolderSelected);
                        asyncResult = br.CurrentViewPlugin.ViewControl.BeginInvoke(selectedDelegate, provider, provider.ProviderItem);
                    }
                    else
                    {
                        FileSelected selectedDelegate = new FileSelected(br.CurrentViewPlugin.FileSelected);
                        asyncResult = br.CurrentViewPlugin.ViewControl.BeginInvoke(selectedDelegate, provider, provider.ProviderItem);
                    }

                    asyncResult.AsyncWaitHandle.WaitOne();
                }
                else
                    br.CurrentViewPlugin.Reset();
            }
            catch (Exception) { }
        }

        #endregion

        #region ToolTip

        void SetToolTip(ListViewItem listItem)
        {
            IntPtr queryInfoPtr;
            IQueryInfo queryInfo;

            if (ShellHelper.GetIQueryInfo((ShellItem)listItem.Tag, out queryInfoPtr, out queryInfo))
            {
                string info;
                queryInfo.GetInfoTip(ShellAPI.QITIPF.DEFAULT, out info);

                //if (string.IsNullOrEmpty(info))
                //queryInfo.GetInfoTip(ShellAPI.QITIPF.USESLOWTIP, out info);

                Marshal.ReleaseComObject(queryInfo);
                Marshal.Release(queryInfoPtr);

                listItem.ToolTipText = info;
            }
        }

        void FileView_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            br.BeginInvoke(toolTipDelegate, e.Item);
        }

        #endregion
    }

    #region ContextMenuHelper

    /// <summary>
    /// This class provides static methods which are being used to retrieve IContextMenu's for specific items
    /// and to invoke certain commands.
    /// </summary>
    internal static class ContextMenuHelper
    {
        #region GetCommandString

        public static string GetCommandString(IContextMenu iContextMenu, uint idcmd, bool executeString)
        {
            string command = GetCommandStringW(iContextMenu, idcmd, executeString);

            if (string.IsNullOrEmpty(command))
                command = GetCommandStringA(iContextMenu, idcmd, executeString);

            return command;
        }

        /// <summary>
        /// Retrieves the command string for a specific item from an iContextMenu (Ansi)
        /// </summary>
        /// <param name="iContextMenu">the IContextMenu to receive the string from</param>
        /// <param name="idcmd">the id of the specific item</param>
        /// <param name="executeString">indicating whether it should return an execute string or not</param>
        /// <returns>if executeString is true it will return the executeString for the item, 
        /// otherwise it will return the help info string</returns>
        public static string GetCommandStringA(IContextMenu iContextMenu, uint idcmd, bool executeString)
        {
            string info = string.Empty;
            byte[] bytes = new byte[256];
            int index;

            iContextMenu.GetCommandString(
                idcmd,
                (executeString ? ShellAPI.GCS.VERBA : ShellAPI.GCS.HELPTEXTA),
                0,
                bytes,
                ShellAPI.MAX_PATH);

            index = 0;
            while (index < bytes.Length && bytes[index] != 0)
            { index++; }

            if (index < bytes.Length)
                info = Encoding.Default.GetString(bytes, 0, index);

            return info;
        }

        /// <summary>
        /// Retrieves the command string for a specific item from an iContextMenu (Unicode)
        /// </summary>
        /// <param name="iContextMenu">the IContextMenu to receive the string from</param>
        /// <param name="idcmd">the id of the specific item</param>
        /// <param name="executeString">indicating whether it should return an execute string or not</param>
        /// <returns>if executeString is true it will return the executeString for the item, 
        /// otherwise it will return the help info string</returns>
        public static string GetCommandStringW(IContextMenu iContextMenu, uint idcmd, bool executeString)
        {
            string info = string.Empty;
            byte[] bytes = new byte[256];
            int index;

            iContextMenu.GetCommandString(
                idcmd,
                (executeString ? ShellAPI.GCS.VERBW : ShellAPI.GCS.HELPTEXTW),
                0,
                bytes,
                ShellAPI.MAX_PATH);

            index = 0;
            while (index < bytes.Length - 1 && (bytes[index] != 0 || bytes[index + 1] != 0))
            { index += 2; }

            if (index < bytes.Length - 1)
                info = Encoding.Unicode.GetString(bytes, 0, index + 1);

            return info;
        }

        #endregion

        #region Invoke Commands

        /// <summary>
        /// Invokes a specific command from an IContextMenu
        /// </summary>
        /// <param name="iContextMenu">the IContextMenu containing the item</param>
        /// <param name="cmd">the index of the command to invoke</param>
        /// <param name="parentDir">the parent directory from where to invoke</param>
        /// <param name="ptInvoke">the point (in screen coördinates) from which to invoke</param>
        public static void InvokeCommand(IContextMenu iContextMenu, uint cmd, string parentDir, Point ptInvoke)
        {
            ShellAPI.CMINVOKECOMMANDINFOEX invoke = new ShellAPI.CMINVOKECOMMANDINFOEX();
            invoke.cbSize = ShellAPI.cbInvokeCommand;
            invoke.lpVerb = (IntPtr)cmd;
            invoke.lpDirectory = parentDir;
            invoke.lpVerbW = (IntPtr)cmd;
            invoke.lpDirectoryW = parentDir;
            invoke.fMask = ShellAPI.CMIC.UNICODE | ShellAPI.CMIC.PTINVOKE |
                ((Control.ModifierKeys & Keys.Control) != 0 ? ShellAPI.CMIC.CONTROL_DOWN : 0) |
                ((Control.ModifierKeys & Keys.Shift) != 0 ? ShellAPI.CMIC.SHIFT_DOWN : 0);
            invoke.ptInvoke = new ShellAPI.POINT(ptInvoke.X, ptInvoke.Y);
            invoke.nShow = ShellAPI.SW.SHOWNORMAL;

            iContextMenu.InvokeCommand(ref invoke);
        }

        /// <summary>
        /// Invokes a specific command from an IContextMenu
        /// </summary>
        /// <param name="iContextMenu">the IContextMenu containing the item</param>
        /// <param name="cmdA">the Ansi execute string to invoke</param>
        /// <param name="cmdW">the Unicode execute string to invoke</param>
        /// <param name="parentDir">the parent directory from where to invoke</param>
        /// <param name="ptInvoke">the point (in screen coördinates) from which to invoke</param>
        public static void InvokeCommand(IContextMenu iContextMenu, string cmd, string parentDir, Point ptInvoke)
        {
            ShellAPI.CMINVOKECOMMANDINFOEX invoke = new ShellAPI.CMINVOKECOMMANDINFOEX();
            invoke.cbSize = ShellAPI.cbInvokeCommand;
            invoke.lpVerb = Marshal.StringToHGlobalAnsi(cmd);
            invoke.lpDirectory = parentDir;
            invoke.lpVerbW = Marshal.StringToHGlobalUni(cmd);
            invoke.lpDirectoryW = parentDir;
            invoke.fMask = ShellAPI.CMIC.UNICODE | ShellAPI.CMIC.PTINVOKE |
                ((Control.ModifierKeys & Keys.Control) != 0 ? ShellAPI.CMIC.CONTROL_DOWN : 0) |
                ((Control.ModifierKeys & Keys.Shift) != 0 ? ShellAPI.CMIC.SHIFT_DOWN : 0);
            invoke.ptInvoke = new ShellAPI.POINT(ptInvoke.X, ptInvoke.Y);
            invoke.nShow = ShellAPI.SW.SHOWNORMAL;

            iContextMenu.InvokeCommand(ref invoke);
        }

        /// <summary>
        /// Invokes a specific command for a set of pidls
        /// </summary>
        /// <param name="parent">the parent ShellItem which contains the pidls</param>
        /// <param name="pidls">the pidls from the items for which to invoke</param>
        /// <param name="cmd">the execute string from the command to invoke</param>
        /// <param name="ptInvoke">the point (in screen coördinates) from which to invoke</param>
        public static void InvokeCommand(ShellItem parent, IntPtr[] pidls, string cmd, Point ptInvoke)
        {
            IntPtr icontextMenuPtr;
            IContextMenu iContextMenu;

            if (GetIContextMenu(parent.ShellFolder, pidls, out icontextMenuPtr, out iContextMenu))
            {
                try
                {
                    InvokeCommand(
                        iContextMenu,
                        cmd,
                        ShellItem.GetRealPath(parent),
                        ptInvoke);
                }
                catch (Exception) { }
                finally
                {
                    if (iContextMenu != null)
                        Marshal.ReleaseComObject(iContextMenu);

                    if (icontextMenuPtr != IntPtr.Zero)
                        Marshal.Release(icontextMenuPtr);
                }
            }
        }

        #endregion

        /// <summary>
        /// Retrieves the IContextMenu for specific items
        /// </summary>
        /// <param name="parent">the parent IShellFolder which contains the items</param>
        /// <param name="pidls">the pidls of the items for which to retrieve the IContextMenu</param>
        /// <param name="icontextMenuPtr">the pointer to the IContextMenu</param>
        /// <param name="iContextMenu">the IContextMenu for the items</param>
        /// <returns>true if the IContextMenu has been retrieved succesfully, false otherwise</returns>
        public static bool GetIContextMenu(
            IShellFolder parent,
            IntPtr[] pidls,
            out IntPtr iContextMenuPtr,
            out IContextMenu iContextMenu)
        {
            if (parent.GetUIObjectOf(
                        IntPtr.Zero,
                        (uint)pidls.Length,
                        pidls,
                        ref ShellAPI.IID_IContextMenu,
                        IntPtr.Zero,
                        out iContextMenuPtr) == ShellAPI.S_OK)
            {
                iContextMenu =
                    (IContextMenu)Marshal.GetTypedObjectForIUnknown(
                        iContextMenuPtr, typeof(IContextMenu));

                return true;
            }
            else
            {
                iContextMenuPtr = IntPtr.Zero;
                iContextMenu = null;

                return false;
            }
        }

        public static bool GetNewContextMenu(ShellItem item, out IntPtr iContextMenuPtr, out IContextMenu iContextMenu)
        {
            if (ShellAPI.CoCreateInstance(
                    ref ShellAPI.CLSID_NewMenu,
                    IntPtr.Zero,
                    ShellAPI.CLSCTX.INPROC_SERVER,
                    ref ShellAPI.IID_IContextMenu,
                    out iContextMenuPtr) == ShellAPI.S_OK)
            {
                iContextMenu = Marshal.GetTypedObjectForIUnknown(iContextMenuPtr, typeof(IContextMenu)) as IContextMenu;

                IntPtr iShellExtInitPtr;
                if (Marshal.QueryInterface(
                    iContextMenuPtr,
                    ref ShellAPI.IID_IShellExtInit,
                    out iShellExtInitPtr) == ShellAPI.S_OK)
                {
                    IShellExtInit iShellExtInit = Marshal.GetTypedObjectForIUnknown(
                        iShellExtInitPtr, typeof(IShellExtInit)) as IShellExtInit;

                    PIDL pidlFull = item.PIDLFull;
                    iShellExtInit.Initialize(pidlFull.Ptr, IntPtr.Zero, 0);

                    Marshal.ReleaseComObject(iShellExtInit);
                    Marshal.Release(iShellExtInitPtr);
                    pidlFull.Free();

                    return true;
                }
                else
                {
                    if (iContextMenu != null)
                    {
                        Marshal.ReleaseComObject(iContextMenu);
                        iContextMenu = null;
                    }

                    if (iContextMenuPtr != IntPtr.Zero)
                    {
                        Marshal.Release(iContextMenuPtr);
                        iContextMenuPtr = IntPtr.Zero;
                    }

                    return false;
                }
            }
            else
            {
                iContextMenuPtr = IntPtr.Zero;
                iContextMenu = null;
                return false;
            }
        }

        /// <summary>
        /// When keys are pressed, this method will check for known key combinations. For example copy and past with
        /// Ctrl + C and Ctrl + V.
        /// </summary>
        public static void ProcessKeyCommands(Browser br, object sender, KeyEventArgs e)
        {
            if (e.Control && !e.Shift && !e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.C:
                    case Keys.Insert:
                    case Keys.V:
                    case Keys.X:
                        #region Copy/Paste/Cut
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            IntPtr[] pidls;
                            ShellItem parent;
                            if (sender.Equals(br.FileView) && e.KeyCode != Keys.V)
                            {
                                pidls = new IntPtr[br.FileView.SelectedItems.Count];
                                for (int i = 0; i < pidls.Length; i++)
                                {
                                    pidls[i] = ((ShellItem)br.FileView.SelectedItems[i].Tag).PIDLRel.Ptr;
                                }
                                parent = br.SelectedItem;
                            }
                            else
                            {
                                pidls = new IntPtr[1];
                                pidls[0] = br.SelectedItem.PIDLRel.Ptr;
                                parent = (br.SelectedItem.ParentItem != null ? br.SelectedItem.ParentItem : br.SelectedItem);
                            }

                            if (pidls.Length > 0)
                            {
                                string cmd;
                                if (e.KeyCode == Keys.C || e.KeyCode == Keys.Insert)
                                    cmd = "copy";
                                else if (e.KeyCode == Keys.V)
                                    cmd = "paste";
                                else
                                    cmd = "cut";

                                ContextMenuHelper.InvokeCommand(parent, pidls, cmd, new Point(0, 0));
                                Cursor.Current = Cursors.Default;
                            }
                            e.Handled = true;
                            e.SuppressKeyPress = true;
                        }
                        #endregion
                        break;

                    case Keys.A:
                        #region Select All
                        {
                            foreach (ListViewItem item in br.FileView.Items)
                                item.Selected = true;

                            br.FileView.Focus();
                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        #endregion
                        break;

                    case Keys.N:
                        #region Create New Folder
                        if (!br.CreateNewFolder())
                            System.Media.SystemSounds.Beep.Play();

                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        #endregion
                        break;

                    case Keys.Z:
                        break;

                    case Keys.Y:
                        break;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        #region Paste
                        if (e.Shift && !e.Control && !e.Alt)
                        {
                            IntPtr[] pidls = new IntPtr[1];
                            pidls[0] = br.SelectedItem.PIDLRel.Ptr;
                            ShellItem parent = (br.SelectedItem.ParentItem != null ? br.SelectedItem.ParentItem : br.SelectedItem);
                            ContextMenuHelper.InvokeCommand(parent, pidls, "paste", new Point(0, 0));
                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        #endregion
                        break;

                    case Keys.Delete:
                        #region Delete
                        if (!e.Control && !e.Alt)
                        {
                            IntPtr[] pidls;
                            ShellItem parent;
                            if (sender.Equals(br.FileView))
                            {
                                pidls = new IntPtr[br.FileView.SelectedItems.Count];
                                for (int i = 0; i < pidls.Length; i++)
                                {
                                    pidls[i] = ((ShellItem)br.FileView.SelectedItems[i].Tag).PIDLRel.Ptr;
                                }
                                parent = br.SelectedItem;
                            }
                            else
                            {
                                pidls = new IntPtr[1];
                                pidls[0] = br.SelectedItem.PIDLRel.Ptr;
                                parent = (br.SelectedItem.ParentItem != null ? br.SelectedItem.ParentItem : br.SelectedItem);
                            }

                            if (pidls.Length > 0)
                                ContextMenuHelper.InvokeCommand(parent, pidls, "delete", new Point(0, 0));
                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        #endregion
                        break;

                    case Keys.F4:
                        #region AddressBox
                        {
                            br.NavAddressBox.Focus();
                            br.NavAddressBox.DroppedDown = true;
                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        #endregion
                        break;

                    case Keys.F2:
                        #region Rename
                        if (sender.Equals(br.FolderView))
                        {
                            if (br.FolderView.SelectedNode != null)
                            {
                                br.FolderView.LabelEdit = true;
                                br.FolderView.SelectedNode.BeginEdit();
                            }
                        }
                        else if (sender.Equals(br.FileView))
                        {
                            if (br.FileView.SelectedOrder.Count > 0)
                            {
                                ArrayList temp = new ArrayList();
                                foreach (object obj in br.FileView.SelectedOrder)
                                    temp.Add(obj);

                                ListViewItem item = br.FileView.SelectedOrder[0] as ListViewItem;
                                item.BeginEdit();

                                for (int i = temp.Count - 1; i >= 0; i--)
                                {
                                    item = temp[i] as ListViewItem;
                                    item.Selected = false;
                                    item.Selected = true;
                                }
                            }
                        }
                        #endregion
                        break;

                    case Keys.Back:
                        #region Up
                        {
                            if (br.FolderView.SelectedNode != null && br.FolderView.SelectedNode.Parent != null)
                                br.FolderView.SelectedNode = br.FolderView.SelectedNode.Parent;
                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        #endregion
                        break;
                }
            }
        }
    }

    #endregion
}