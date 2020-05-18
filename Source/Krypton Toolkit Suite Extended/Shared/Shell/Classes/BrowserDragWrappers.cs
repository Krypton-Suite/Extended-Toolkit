using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Shell
{
    /// <summary>
    /// This class takes care of every drag operation in a BrowserTreeView
    /// </summary>
    internal class BrowserTVDragWrapper : IDropSource, IDisposable
    {
        #region Fields

        // The browser for which to do the drag work
        private Browser br;

        // The pointer to the IDataObject being dragged
        private IntPtr dataObjectPtr;

        // The mouseButtons state when a drag starts
        private MouseButtons startButton;

        // A bool to indicate whether this class has been disposed
        private bool disposed = false;

        // The events that will be raised when a drag starts and when it ends
        public event DragEnterEventHandler DragStart;
        public event EventHandler DragEnd;

        #endregion

        /// <summary>
        /// Registers the TreeView.ItemDrag to receive the event when an item is being dragged
        /// </summary>
        /// <param name="br">The browser for which to support the drag</param>
        public BrowserTVDragWrapper(Browser br)
        {
            this.br = br;
            br.FolderView.ItemDrag += new ItemDragEventHandler(ItemDrag);
        }

        ~BrowserTVDragWrapper()
        {
            ((IDisposable)this).Dispose();
        }

        #region Generated Events

        /// <summary>
        /// The event that is being raised when a drag starts
        /// </summary>
        /// <param name="e">the DragEnterEventArgs for the event</param>
        private void OnDragStart(DragEnterEventArgs e)
        {
            if (DragStart != null)
                DragStart(this, e);
        }

        /// <summary>
        /// The event that is being raised when a drag ends
        /// </summary>
        /// <param name="e">the EventArgs for the event</param>
        private void OnDragEnd(EventArgs e)
        {
            if (DragEnd != null)
                DragEnd(this, e);
        }

        #endregion

        #region IDropSource Members

        /// <summary>
        /// This method initialises the dragging of a TreeNode
        /// </summary>
        void ItemDrag(object sender, ItemDragEventArgs e)
        {
            ReleaseCom();

            startButton = e.Button;
            ShellItem item = (ShellItem)((TreeNode)e.Item).Tag;
            dataObjectPtr = ShellHelper.GetIDataObject(new ShellItem[] { item });

            if (dataObjectPtr != IntPtr.Zero)
            {
                DragDropEffects effects;
                OnDragStart(new DragEnterEventArgs((item.ParentItem != null ? item.ParentItem : item), br.FolderView));
                ShellAPI.DoDragDrop(dataObjectPtr, this, DragDropEffects.Copy | DragDropEffects.Link | DragDropEffects.Move, out effects);
                OnDragEnd(new EventArgs());
            }
        }

        public int QueryContinueDrag(bool fEscapePressed, ShellAPI.MK grfKeyState)
        {
            if (fEscapePressed)
                return ShellAPI.DRAGDROP_S_CANCEL;
            else
            {
                if ((startButton & MouseButtons.Left) != 0 && (grfKeyState & ShellAPI.MK.LBUTTON) == 0)
                    return ShellAPI.DRAGDROP_S_DROP;
                else if ((startButton & MouseButtons.Right) != 0 && (grfKeyState & ShellAPI.MK.RBUTTON) == 0)
                    return ShellAPI.DRAGDROP_S_DROP;
                else
                    return ShellAPI.S_OK;
            }
        }

        public int GiveFeedback(DragDropEffects dwEffect)
        {
            return ShellAPI.DRAGDROP_S_USEDEFAULTCURSORS;
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
                ReleaseCom();
                GC.SuppressFinalize(this);

                disposed = true;
            }
        }

        /// <summary>
        /// Release the IDataObject and free's the allocated memory
        /// </summary>
        private void ReleaseCom()
        {
            if (dataObjectPtr != IntPtr.Zero)
            {
                Marshal.Release(dataObjectPtr);
                dataObjectPtr = IntPtr.Zero;
            }
        }

        #endregion
    }

    /// <summary>
    /// This class takes care of every drag operation in a BrowserListView
    /// </summary>
    internal class BrowserLVDragWrapper : IDropSource, IDisposable
    {
        #region Fields

        // The browser for which to do the drag work
        private Browser br;

        // The pointer to the IDataObject being dragged
        private IntPtr dataObjectPtr;

        // The mouseButtons state when a drag starts
        private MouseButtons startButton;

        // A bool to indicate whether this class has been disposed
        private bool disposed = false;

        // The events that will be raised when a drag starts and when it ends
        public event DragEnterEventHandler DragStart;
        public event EventHandler DragEnd;

        #endregion

        /// <summary>
        /// Registers the ListView.ItemDrag to receive the event when an item is being dragged
        /// </summary>
        /// <param name="br">The browser for which to support the drag</param>
        public BrowserLVDragWrapper(Browser br)
        {
            this.br = br;
            br.FileView.ItemDrag += new ItemDragEventHandler(ItemDrag);
        }

        ~BrowserLVDragWrapper()
        {
            ((IDisposable)this).Dispose();
        }

        #region Generated Events

        /// <summary>
        /// The event that is being raised when a drag starts
        /// </summary>
        /// <param name="e">the DragEnterEventArgs for the event</param>
        private void OnDragStart(DragEnterEventArgs e)
        {
            if (DragStart != null)
                DragStart(this, e);
        }

        /// <summary>
        /// The event that is being raised when a drag ends
        /// </summary>
        /// <param name="e">the EventArgs for the event</param>
        private void OnDragEnd(EventArgs e)
        {
            if (DragEnd != null)
                DragEnd(this, e);
        }

        #endregion

        #region IDropSource Members

        /// <summary>
        /// This method initialises the dragging of a ListViewItem
        /// </summary>
        void ItemDrag(object sender, ItemDragEventArgs e)
        {
            ReleaseCom();

            startButton = e.Button;

            ShellItem[] items = new ShellItem[br.FileView.SelectedItems.Count];
            for (int i = 0; i < br.FileView.SelectedItems.Count; i++)
            {
                items[i] = (ShellItem)br.FileView.SelectedItems[i].Tag;
            }

            dataObjectPtr = ShellHelper.GetIDataObject(items);

            if (dataObjectPtr != IntPtr.Zero)
            {
                DragDropEffects effects;
                OnDragStart(new DragEnterEventArgs((items[0].ParentItem != null ? items[0].ParentItem : items[0]), br.FileView));
                ShellAPI.DoDragDrop(dataObjectPtr, this, DragDropEffects.Copy | DragDropEffects.Link | DragDropEffects.Move, out effects);
                OnDragEnd(new EventArgs());
            }
        }

        public int QueryContinueDrag(bool fEscapePressed, ShellAPI.MK grfKeyState)
        {
            if (fEscapePressed)
                return ShellAPI.DRAGDROP_S_CANCEL;
            else
            {
                if ((startButton & MouseButtons.Left) != 0 && (grfKeyState & ShellAPI.MK.LBUTTON) == 0)
                    return ShellAPI.DRAGDROP_S_DROP;
                else if ((startButton & MouseButtons.Right) != 0 && (grfKeyState & ShellAPI.MK.RBUTTON) == 0)
                    return ShellAPI.DRAGDROP_S_DROP;
                else
                    return ShellAPI.S_OK;
            }
        }

        public int GiveFeedback(DragDropEffects dwEffect)
        {
            return ShellAPI.DRAGDROP_S_USEDEFAULTCURSORS;
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
                ReleaseCom();
                GC.SuppressFinalize(this);

                disposed = true;
            }
        }

        /// <summary>
        /// Release the IDataObject and free's the allocated memory
        /// </summary>
        private void ReleaseCom()
        {
            if (dataObjectPtr != IntPtr.Zero)
            {
                Marshal.Release(dataObjectPtr);
                dataObjectPtr = IntPtr.Zero;
            }
        }

        #endregion
    }

    #region Event Classes

    internal delegate void DragEnterEventHandler(object sender, DragEnterEventArgs e);

    internal class DragEnterEventArgs : EventArgs
    {
        private ShellItem parent;
        private Control dragStartControl;

        public DragEnterEventArgs(ShellItem parent, Control dragStartControl)
        {
            this.parent = parent;
            this.dragStartControl = dragStartControl;
        }

        public ShellItem Parent { get { return parent; } }
        public Control DragStartControl { get { return dragStartControl; } }
    }

    #endregion
}