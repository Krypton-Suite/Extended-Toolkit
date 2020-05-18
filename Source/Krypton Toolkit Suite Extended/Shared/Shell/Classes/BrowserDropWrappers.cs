using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Shell
{
    /// <summary>
    /// This class takes care of every drop operation in a BrowserTreeView
    /// </summary>
    internal class BrowserTVDropWrapper : IDropTarget, IDisposable
    {
        #region Fields

        // The browser for which to do the drop work
        private Browser br;

        private IntPtr treeViewHandle;

        // The current IDropTarget the cursor is over and the pointers to the target and dataobject
        private IDropTarget dropTarget;
        private IntPtr dropTargetPtr;
        private IntPtr dropDataObject;

        private IDropTargetHelper dropHelper;
        private IntPtr dropHelperPtr;

        // The current node the cursor is over to drop on
        private TreeNode dropNode;

        // The last selected node from the browser
        // This is to remember which node to select after drop has completed
        private TreeNode lastSelectedNode;

        // The parent ShellItems of the drop- and dragitem
        private ShellItem parentDropItem, parentDragItem;

        // The mouse and keys state when a drag enter occurs
        private ShellAPI.MK mouseButtons;

        // A bool to indicate whether this class has been disposed
        private bool disposed = false;

        // The event for when a drop is occuring
        public event DropEventHandler Drop;

        #endregion

        /// <summary>
        /// Registers the TreeView for drag/drop operations and uses this class as the IDropTarget
        /// </summary>
        /// <param name="br">The browser for which to support the drop</param>
        public BrowserTVDropWrapper(Browser br)
        {
            this.br = br;

            treeViewHandle = br.FolderView.Handle;
            ShellAPI.RegisterDragDrop(treeViewHandle, this);

            br.FolderView.HandleCreated += new EventHandler(FolderView_HandleCreated);
            br.FolderView.HandleDestroyed += new EventHandler(FolderView_HandleDestroyed);

            ShellHelper.GetIDropTargetHelper(out dropHelperPtr, out dropHelper);
        }

        ~BrowserTVDropWrapper()
        {
            ((IDisposable)this).Dispose();
        }

        #region Handle Changes

        void FolderView_HandleCreated(object sender, EventArgs e)
        {
            treeViewHandle = br.FolderView.Handle;
            ShellAPI.RegisterDragDrop(treeViewHandle, this);
        }

        void FolderView_HandleDestroyed(object sender, EventArgs e)
        {
            ShellAPI.RevokeDragDrop(br.FolderView.Handle);
        }

        #endregion

        #region Public

        /// <summary>
        /// This ShellItem is the parent item of the item being currently dragged. This field is used
        /// to check whether an item is being moved to it's original folder. If this is the case, we don't
        /// have to do anything, cause the item is allready there.
        /// </summary>
        public ShellItem ParentDragItem
        {
            get { return parentDragItem; }
            set { parentDragItem = value; }
        }

        #endregion

        #region Generated Events

        /// <summary>
        /// This event will be raised whenever a drop occurs on the TreeView.
        /// </summary>
        /// <param name="e">The DropEventArgs for the event</param>
        private void OnDrop(DropEventArgs e)
        {
            if (Drop != null)
                Drop(this, e);
        }

        #endregion

        #region IDropTarget Members

        public int DragEnter(IntPtr pDataObj, ShellAPI.MK grfKeyState, ShellAPI.POINT pt, ref DragDropEffects pdwEffect)
        {
            mouseButtons = grfKeyState;

            br.FolderView.Focus();
            br.SelectionChange = false;
            lastSelectedNode = br.FolderView.SelectedNode;

            ReleaseCom();

            dropDataObject = pDataObj;

            #region Get DropItem

            Point point = br.FolderView.PointToClient(new Point(pt.x, pt.y));
            TreeViewHitTestInfo hitTest = br.FolderView.HitTest(point);

            dropNode = hitTest.Node;
            br.FolderView.SelectedNode = dropNode;

            if (dropNode != null)
            {
                ShellItem item = (ShellItem)dropNode.Tag;
                parentDropItem = item;

                if (ShellHelper.GetIDropTarget(item, out dropTargetPtr, out dropTarget))
                {
                    dropTarget.DragEnter(pDataObj, grfKeyState, pt, ref pdwEffect);
                }
            }

            #endregion

            if (dropHelper != null)
                dropHelper.DragEnter(br.Handle, pDataObj, ref pt, pdwEffect);

            return ShellAPI.S_OK;
        }

        public int DragOver(ShellAPI.MK grfKeyState, ShellAPI.POINT pt, ref DragDropEffects pdwEffect)
        {
            bool reset = false;

            #region Get DropItem

            Point point = br.FolderView.PointToClient(new Point(pt.x, pt.y));
            TreeViewHitTestInfo hitTest = br.FolderView.HitTest(point);
            if (!TreeNode.Equals(dropNode, hitTest.Node))
            {
                if (dropTarget != null)
                    dropTarget.DragLeave();

                ReleaseCom();

                dropNode = hitTest.Node;
                br.FolderView.SelectedNode = dropNode;

                if (dropNode == null)
                {
                    pdwEffect = DragDropEffects.None;

                    if (dropHelper != null)
                        dropHelper.DragOver(ref pt, pdwEffect);

                    return ShellAPI.S_OK;
                }
                else
                {
                    ShellItem item = (ShellItem)dropNode.Tag;
                    parentDropItem = item;

                    ShellHelper.GetIDropTarget(item, out dropTargetPtr, out dropTarget);
                    reset = true;
                }
            }
            else if (dropNode == null)
            {
                if (dropTarget != null)
                    dropTarget.DragLeave();

                ReleaseCom();

                dropNode = null;
                br.SelectedNode = null;

                pdwEffect = DragDropEffects.None;

                if (dropHelper != null)
                    dropHelper.DragOver(ref pt, pdwEffect);

                return ShellAPI.S_OK;
            }

            #endregion

            if (dropTarget != null)
            {
                if (reset)
                    dropTarget.DragEnter(dropDataObject, grfKeyState, pt, ref pdwEffect);
                else
                    dropTarget.DragOver(grfKeyState, pt, ref pdwEffect);
            }
            else
                pdwEffect = DragDropEffects.None;

            if (dropHelper != null)
                dropHelper.DragOver(ref pt, pdwEffect);

            return ShellAPI.S_OK;
        }

        public int DragLeave()
        {
            ResetDrop();
            if (dropTarget != null)
            {
                dropTarget.DragLeave();

                ReleaseCom();
                dropDataObject = IntPtr.Zero;
            }

            if (dropHelper != null)
                dropHelper.DragLeave();

            return ShellAPI.S_OK;
        }

        public int DragDrop(IntPtr pDataObj, ShellAPI.MK grfKeyState, ShellAPI.POINT pt, ref DragDropEffects pdwEffect)
        {
            OnDrop(new DropEventArgs(mouseButtons, br.FolderView));

            if (!((mouseButtons & ShellAPI.MK.RBUTTON) != 0 ||
                  grfKeyState == ShellAPI.MK.CONTROL ||
                  grfKeyState == ShellAPI.MK.ALT ||
                  grfKeyState == (ShellAPI.MK.CONTROL | ShellAPI.MK.SHIFT)) && ShellItem.Equals(parentDragItem, parentDropItem))
            {
                ResetDrop();
                ReleaseCom();
                pdwEffect = DragDropEffects.None;

                if (dropHelper != null)
                    dropHelper.DragLeave();

                return ShellAPI.S_OK;
            }

            ResetDrop();
            if (dropTarget != null)
            {
                dropTarget.DragDrop(pDataObj, grfKeyState, pt, ref pdwEffect);

                ReleaseCom();
                dropDataObject = IntPtr.Zero;
            }

            if (dropHelper != null)
                dropHelper.Drop(pDataObj, ref pt, pdwEffect);

            return ShellAPI.S_OK;
        }

        /// <summary>
        /// Reset all fields to the default values and release the IDropTarget
        /// </summary>
        private void ResetDrop()
        {
            if (dropNode != null)
            {
                dropNode = null;
                parentDropItem = null;
            }

            if (lastSelectedNode != null)
                br.FolderView.SelectedNode = lastSelectedNode;

            br.SelectionChange = true;
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// If not disposed, dispose the class
        /// </summary>
        public void Dispose()
        {
            if (!disposed)
            {
                DisposeDropWrapper();
                GC.SuppressFinalize(this);

                disposed = true;
            }
        }

        /// <summary>
        /// Revokes the TreeView from getting drop messages and releases the IDropTarget
        /// </summary>
        private void DisposeDropWrapper()
        {
            ReleaseCom();

            if (dropHelper != null)
            {
                Marshal.ReleaseComObject(dropHelper);
            }
        }

        /// <summary>
        /// Release the IDropTarget and free's the allocated memory
        /// </summary>
        private void ReleaseCom()
        {
            if (dropTarget != null)
            {
                Marshal.ReleaseComObject(dropTarget);

                dropTarget = null;
                dropHelperPtr = IntPtr.Zero;
            }
        }

        #endregion
    }

    /// <summary>
    /// This class takes care of every drop operation in a BrowserListView
    /// </summary>
    internal class BrowserLVDropWrapper : IDropTarget, IDisposable
    {
        #region Fields

        // The browser for which to do the drop work
        private Browser br;

        private IntPtr listViewHandle;

        // The current IDropTarget the cursor is over and the pointers to the target and dataobject
        private IDropTarget dropTarget;
        private IntPtr dropTargetPtr;
        private IntPtr dropDataObject;

        private IDropTargetHelper dropHelper;
        private IntPtr dropHelperPtr;

        // The current ListViewItem the cursor is over to drop on
        private ListViewItem dropListItem;

        // The selected state from the dropListItem before the cursor moved over it
        private bool wasSelected;

        // The parent ShellItems of the drop- and dragitem
        private ShellItem parentDropItem, parentDragItem;

        // The mouse and keys state and DragDropEffects when a drag enter occurs
        private ShellAPI.MK mouseButtons;
        private DragDropEffects startEffects;

        // A bool to indicate whether this class has been disposed
        private bool disposed = false;

        // The event for when a drop is occuring
        public event DropEventHandler Drop;

        #endregion

        /// <summary>
        /// Registers the ListView for drag/drop operations and uses this class as the IDropTarget
        /// </summary>
        /// <param name="br">The browser for which to support the drop</param>
        public BrowserLVDropWrapper(Browser br)
        {
            this.br = br;

            listViewHandle = br.FileView.Handle;
            ShellAPI.RegisterDragDrop(listViewHandle, this);

            br.FileView.HandleCreated += new EventHandler(FileView_HandleCreated);
            br.FileView.HandleDestroyed += new EventHandler(FileView_HandleDestroyed);

            ShellHelper.GetIDropTargetHelper(out dropHelperPtr, out dropHelper);
        }

        ~BrowserLVDropWrapper()
        {
            ((IDisposable)this).Dispose();
        }

        #region Handle Changes

        void FileView_HandleCreated(object sender, EventArgs e)
        {
            listViewHandle = br.FileView.Handle;
            ShellAPI.RegisterDragDrop(listViewHandle, this);
        }

        void FileView_HandleDestroyed(object sender, EventArgs e)
        {
            ShellAPI.RevokeDragDrop(listViewHandle);
        }

        #endregion

        #region Public

        /// <summary>
        /// This ShellItem is the parent item of the item being currently dragged. This field is used
        /// to check whether an item is being moved to it's original folder. If this is the case, we don't
        /// have to do anything, cause the item is allready there.
        /// </summary>
        public ShellItem ParentDragItem
        {
            get { return parentDragItem; }
            set { parentDragItem = value; }
        }

        #endregion

        #region Generated Events

        /// <summary>
        /// This event will be raised whenever a drop occurs on the ListView.
        /// </summary>
        /// <param name="e">The DropEventArgs for the event</param>
        private void OnDrop(DropEventArgs e)
        {
            if (Drop != null)
                Drop(this, e);
        }

        #endregion

        #region IDropTarget Members

        public int DragEnter(IntPtr pDataObj, ShellAPI.MK grfKeyState, ShellAPI.POINT pt, ref DragDropEffects pdwEffect)
        {
            mouseButtons = grfKeyState;
            startEffects = pdwEffect;

            br.FileView.Focus();
            br.SelectionChange = false;
            ReleaseCom();

            dropDataObject = pDataObj;

            #region Get DropItem
            Point point = br.FileView.PointToClient(new Point(pt.x, pt.y));
            ListViewHitTestInfo hitTest = br.FileView.HitTest(point);
            if (hitTest.Item != null &&
                (br.FileView.View != View.Details || hitTest.SubItem == null || hitTest.Item.Name == hitTest.SubItem.Name) &&
                (hitTest.Location == ListViewHitTestLocations.Image ||
                 hitTest.Location == ListViewHitTestLocations.Label ||
                 hitTest.Location == ListViewHitTestLocations.StateImage))
            {
                dropListItem = hitTest.Item;

                wasSelected = dropListItem.Selected;
                dropListItem.Selected = true;

                ShellItem item = (ShellItem)dropListItem.Tag;
                parentDropItem = item;

                ShellHelper.GetIDropTarget(item, out dropTargetPtr, out dropTarget);
            }
            else
            {
                dropListItem = null;
                parentDropItem = br.SelectedItem;
                ShellHelper.GetIDropTarget(br.SelectedItem, out dropTargetPtr, out dropTarget);
            }
            #endregion

            if (dropTarget != null)
                dropTarget.DragEnter(pDataObj, grfKeyState, pt, ref pdwEffect);

            if (dropHelper != null)
                dropHelper.DragEnter(br.Handle, pDataObj, ref pt, pdwEffect);

            return ShellAPI.S_OK;
        }

        public int DragOver(ShellAPI.MK grfKeyState, ShellAPI.POINT pt, ref DragDropEffects pdwEffect)
        {
            bool reset = false;

            #region Get DropItem

            Point point = br.FileView.PointToClient(new Point(pt.x, pt.y));
            ListViewHitTestInfo hitTest = br.FileView.HitTest(point);
            if (hitTest.Item != null &&
                (br.FileView.View != View.Details || hitTest.SubItem == null || hitTest.Item.Name == hitTest.SubItem.Name) &&
                (hitTest.Location == ListViewHitTestLocations.Image ||
                 hitTest.Location == ListViewHitTestLocations.Label ||
                 hitTest.Location == ListViewHitTestLocations.StateImage))
            {
                if (!hitTest.Item.Equals(dropListItem))
                {
                    if (dropTarget != null)
                        dropTarget.DragLeave();

                    ReleaseCom();

                    if (dropListItem != null)
                        dropListItem.Selected = wasSelected;

                    dropListItem = hitTest.Item;
                    wasSelected = dropListItem.Selected;
                    dropListItem.Selected = true;

                    ShellItem item = (ShellItem)dropListItem.Tag;
                    parentDropItem = item;

                    ShellHelper.GetIDropTarget(item, out dropTargetPtr, out dropTarget);
                    reset = true;
                }
            }
            else
            {
                if (dropListItem != null)
                {
                    if (dropTarget != null)
                        dropTarget.DragLeave();

                    ReleaseCom();

                    dropListItem.Selected = wasSelected;

                    dropListItem = null;
                    parentDropItem = br.SelectedItem;

                    ShellHelper.GetIDropTarget(br.SelectedItem, out dropTargetPtr, out dropTarget);
                    reset = true;
                }
            }

            #endregion

            if (dropTarget != null)
            {
                if (reset)
                    dropTarget.DragEnter(dropDataObject, grfKeyState, pt, ref pdwEffect);
                else
                    dropTarget.DragOver(grfKeyState, pt, ref pdwEffect);
            }
            else
                pdwEffect = DragDropEffects.None;

            if (dropHelper != null)
                dropHelper.DragOver(ref pt, pdwEffect);

            return ShellAPI.S_OK;
        }

        public int DragLeave()
        {
            ResetDrop();
            if (dropTarget != null)
            {
                dropTarget.DragLeave();

                ReleaseCom();
                dropDataObject = IntPtr.Zero;
            }

            if (dropHelper != null)
                dropHelper.DragLeave();

            return ShellAPI.S_OK;
        }

        public int DragDrop(IntPtr pDataObj, ShellAPI.MK grfKeyState, ShellAPI.POINT pt, ref DragDropEffects pdwEffect)
        {
            OnDrop(new DropEventArgs(mouseButtons, br.FileView));

            if (!((mouseButtons & ShellAPI.MK.RBUTTON) != 0 ||
                  grfKeyState == ShellAPI.MK.CONTROL ||
                  grfKeyState == ShellAPI.MK.ALT ||
                  grfKeyState == (ShellAPI.MK.CONTROL | ShellAPI.MK.SHIFT)) && ShellItem.Equals(parentDragItem, parentDropItem))
            {
                ResetDrop();
                ReleaseCom();
                pdwEffect = DragDropEffects.None;

                if (dropHelper != null)
                    dropHelper.Drop(pDataObj, ref pt, pdwEffect);

                return ShellAPI.S_OK;
            }

            ResetDrop();
            if (dropTarget != null)
            {
                dropTarget.DragDrop(pDataObj, grfKeyState, pt, ref pdwEffect);

                ReleaseCom();
                dropDataObject = IntPtr.Zero;
            }

            if (dropHelper != null)
                dropHelper.Drop(pDataObj, ref pt, pdwEffect);

            return ShellAPI.S_OK;
        }

        /// <summary>
        /// Reset all fields to the default values and release the IDropTarget
        /// </summary>
        private void ResetDrop()
        {
            if (dropListItem != null)
            {
                dropListItem.Selected = wasSelected;
                dropListItem = null;
                parentDropItem = null;
            }

            br.SelectionChange = true;
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// If not disposed, dispose the class
        /// </summary>
        public void Dispose()
        {
            if (!disposed)
            {
                DisposeDropWrapper();
                GC.SuppressFinalize(this);

                disposed = true;
            }
        }

        /// <summary>
        /// Revokes the ListView from getting drop messages and releases the IDropTarget
        /// </summary>
        private void DisposeDropWrapper()
        {
            ReleaseCom();

            if (dropHelper != null)
            {
                Marshal.ReleaseComObject(dropHelper);
            }
        }

        /// <summary>
        /// Release the IDropTarget and free's the allocated memory
        /// </summary>
        private void ReleaseCom()
        {
            if (dropTarget != null)
            {
                Marshal.ReleaseComObject(dropTarget);

                dropTarget = null;
                dropHelperPtr = IntPtr.Zero;
            }
        }

        #endregion
    }

    #region Event Classes

    internal delegate void DropEventHandler(object sender, DropEventArgs e);

    internal class DropEventArgs : EventArgs
    {
        private ShellAPI.MK mouseButtons;
        private Control dragStartControl;

        public DropEventArgs(ShellAPI.MK mouseButtons, Control dragStartControl)
        {
            this.mouseButtons = mouseButtons;
            this.dragStartControl = dragStartControl;
        }

        public ShellAPI.MK MouseButtons { get { return mouseButtons; } }
        public Control DragStartControl { get { return dragStartControl; } }
    }

    #endregion
}