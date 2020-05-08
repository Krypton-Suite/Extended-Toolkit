using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Shell
{
    #region Delegates

    // This delegate is used for the ContextMenuHoverEvent
    public delegate void ContextMenuMouseHoverEventHandler(object sender, ContextMenuMouseHoverEventArgs e);

    // This delegate is used for the SelectedFolderChangedEvent
    public delegate void SelectedFolderChangedEventHandler(object sender, SelectedFolderChangedEventArgs e);

    #endregion

    #region SpecialFolders

    /// <summary>
    /// This enum is used to indicate which folder should be opened when initialising the browser.
    /// When 'Other' is chosen, the browser will start in the directory given by the StartUpDirectoryOther
    /// property.
    /// </summary>
    public enum SpecialFolders : uint
    {
        UserProfiles = 0x003e,
        DesktopDir_All = 0x0019,
        ApplicationData_All = 0x0023,
        MyDocuments_All = 0x002e,
        MyFavorites_All = 0x001f,
        MyMusic_All = 0x0035,
        MyPictures_All = 0x0036,
        StartMenu_All = 0x0016,
        MyVideos_All = 0x0037,

        Desktop = 0x0000,
        DekstopDir = 0x0010,
        MyComputer = 0x0011,
        MyFavorites = 0x0006,
        ApplicationData = 0x001c,
        MyDocuments = 0x000c,
        MyMusic = 0x000d,
        MyPictures = 0x0027,
        MyVideos = 0x000e,
        MyNetworkPlaces = 0x0012,
        MyDocumentsDir = 0x0005,
        StartMenu = 0x000b,

        ControlPanel = 0x0003,
        Printers = 0x0004,
        ProgramFiles = 0x0026,
        SendTo = 0x0009,
        System = 0x0025,
        Windows = 0x0024,
        RecycleBin = 0x000a,

        Other = 0x1000
    }

    #endregion

    /// <summary>
    /// This control is used to browse the files and folders on your computer as with Windows Explorer
    /// </summary>
    public partial class Browser : UserControl
    {
        #region Designer Code
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browser));
            this.browseSplitter = new System.Windows.Forms.SplitContainer();
            this.folderView = new BrowserTreeView();
            this.viewSplitContainer = new System.Windows.Forms.SplitContainer();
            this.fileView = new BrowserListView();
            this.browseToolStrip = new System.Windows.Forms.ToolStripContainer();
            this.navigationBar = new System.Windows.Forms.ToolStrip();
            this.navBackButton = new System.Windows.Forms.ToolStripSplitButton();
            this.navForwardButton = new System.Windows.Forms.ToolStripSplitButton();
            this.navUpButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.navFoldersButton = new System.Windows.Forms.ToolStripButton();
            this.navAddressLabel = new System.Windows.Forms.ToolStripLabel();
            this.navAddressBox = new BrowserComboBox();
            this.browseSplitter.Panel1.SuspendLayout();
            this.browseSplitter.Panel2.SuspendLayout();
            this.browseSplitter.SuspendLayout();
            this.viewSplitContainer.Panel2.SuspendLayout();
            this.viewSplitContainer.SuspendLayout();
            this.browseToolStrip.ContentPanel.SuspendLayout();
            this.browseToolStrip.TopToolStripPanel.SuspendLayout();
            this.browseToolStrip.SuspendLayout();
            this.navigationBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseSplitter
            // 
            this.browseSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browseSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.browseSplitter.Location = new System.Drawing.Point(0, 0);
            this.browseSplitter.Name = "browseSplitter";
            // 
            // browseSplitter.Panel1
            // 
            this.browseSplitter.Panel1.Controls.Add(this.folderView);
            // 
            // browseSplitter.Panel2
            // 
            this.browseSplitter.Panel2.Controls.Add(this.viewSplitContainer);
            this.browseSplitter.Size = new System.Drawing.Size(536, 408);
            this.browseSplitter.SplitterDistance = 162;
            this.browseSplitter.SplitterWidth = 3;
            this.browseSplitter.TabIndex = 0;
            this.browseSplitter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitter_MouseDown);
            this.browseSplitter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitter_MouseMove);
            this.browseSplitter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitter_MouseUp);
            // 
            // folderView
            // 
            this.folderView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderView.HideSelection = false;
            this.folderView.HotTracking = true;
            this.folderView.Location = new System.Drawing.Point(0, 0);
            this.folderView.Name = "folderView";
            this.folderView.ShowLines = false;
            this.folderView.ShowRootLines = false;
            this.folderView.Size = new System.Drawing.Size(162, 408);
            this.folderView.TabIndex = 0;
            // 
            // viewSplitContainer
            // 
            this.viewSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.viewSplitContainer.IsSplitterFixed = true;
            this.viewSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.viewSplitContainer.Name = "viewSplitContainer";
            this.viewSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // viewSplitContainer.Panel1
            // 
            this.viewSplitContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.viewSplitContainer.Panel1Collapsed = true;
            this.viewSplitContainer.Panel1MinSize = 0;
            // 
            // viewSplitContainer.Panel2
            // 
            this.viewSplitContainer.Panel2.Controls.Add(this.fileView);
            this.viewSplitContainer.Panel2MinSize = 0;
            this.viewSplitContainer.Size = new System.Drawing.Size(371, 408);
            this.viewSplitContainer.SplitterDistance = 300;
            this.viewSplitContainer.TabIndex = 1;
            this.viewSplitContainer.Resize += new System.EventHandler(this.viewSplitContainer_Resize);
            // 
            // fileView
            // 
            this.fileView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.fileView.AllowColumnReorder = true;
            this.fileView.ColumnHeaderContextMenu = null;
            this.fileView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileView.HideSelection = false;
            this.fileView.Location = new System.Drawing.Point(0, 0);
            this.fileView.Name = "fileView";
            this.fileView.OwnerDraw = true;
            this.fileView.Size = new System.Drawing.Size(371, 408);
            this.fileView.SuspendHeaderContextMenu = false;
            this.fileView.TabIndex = 0;
            this.fileView.UseCompatibleStateImageBehavior = false;
            this.fileView.View = System.Windows.Forms.View.List;
            // 
            // browseToolStrip
            // 
            // 
            // browseToolStrip.ContentPanel
            // 
            this.browseToolStrip.ContentPanel.Controls.Add(this.browseSplitter);
            this.browseToolStrip.ContentPanel.Size = new System.Drawing.Size(536, 408);
            this.browseToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browseToolStrip.LeftToolStripPanelVisible = false;
            this.browseToolStrip.Location = new System.Drawing.Point(0, 0);
            this.browseToolStrip.Name = "browseToolStrip";
            this.browseToolStrip.RightToolStripPanelVisible = false;
            this.browseToolStrip.Size = new System.Drawing.Size(536, 439);
            this.browseToolStrip.TabIndex = 1;
            this.browseToolStrip.Text = "browseToolStrip";
            // 
            // browseToolStrip.TopToolStripPanel
            // 
            this.browseToolStrip.TopToolStripPanel.Controls.Add(this.navigationBar);
            // 
            // navigationBar
            // 
            this.navigationBar.CanOverflow = false;
            this.navigationBar.Dock = System.Windows.Forms.DockStyle.None;
            this.navigationBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.navigationBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.navigationBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navBackButton,
            this.navForwardButton,
            this.navUpButton,
            this.toolStripSeparator1,
            this.navFoldersButton,
            this.navAddressLabel,
            this.navAddressBox});
            this.navigationBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.navigationBar.Location = new System.Drawing.Point(0, 0);
            this.navigationBar.Name = "navigationBar";
            this.navigationBar.Size = new System.Drawing.Size(536, 31);
            this.navigationBar.Stretch = true;
            this.navigationBar.TabIndex = 0;
            this.navigationBar.Resize += new System.EventHandler(this.navigationBar_Resize);
            // 
            // navBackButton
            // 
            this.navBackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navBackButton.Enabled = false;
            //? this.navBackButton.Image = global::Krypton.Toolkit.Suite.Extended.Shell.Properties.Resources.ResourceManager.BrowserBack;
            this.navBackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navBackButton.Name = "navBackButton";
            this.navBackButton.Size = new System.Drawing.Size(40, 28);
            this.navBackButton.Text = "Back";
            this.navBackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.navBackButton.ButtonClick += new System.EventHandler(this.navBackForwardButton_ButtonClick);
            this.navBackButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.navBackForwardButton_DropDownItemClicked);
            // 
            // navForwardButton
            // 
            this.navForwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navForwardButton.Enabled = false;
            //? this.navForwardButton.Image = global::FileBrowser.Properties.Resources.BrowserForward;
            this.navForwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navForwardButton.Name = "navForwardButton";
            this.navForwardButton.Size = new System.Drawing.Size(40, 28);
            this.navForwardButton.Text = "Forward";
            this.navForwardButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.navForwardButton.ButtonClick += new System.EventHandler(this.navBackForwardButton_ButtonClick);
            this.navForwardButton.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.navBackForwardButton_DropDownItemClicked);
            // 
            // navUpButton
            // 
            this.navUpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navUpButton.Image = ((System.Drawing.Image)(resources.GetObject("navUpButton.Image")));
            this.navUpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navUpButton.Name = "navUpButton";
            this.navUpButton.Size = new System.Drawing.Size(28, 28);
            this.navUpButton.Text = "Up";
            this.navUpButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.navUpButton.Click += new System.EventHandler(this.navUpButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // navFoldersButton
            // 
            this.navFoldersButton.Checked = true;
            this.navFoldersButton.CheckOnClick = true;
            this.navFoldersButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.navFoldersButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.navFoldersButton.Image = ((System.Drawing.Image)(resources.GetObject("navFoldersButton.Image")));
            this.navFoldersButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.navFoldersButton.Name = "navFoldersButton";
            this.navFoldersButton.Size = new System.Drawing.Size(28, 28);
            this.navFoldersButton.Text = "Folders";
            this.navFoldersButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.navFoldersButton.CheckedChanged += new System.EventHandler(this.navFoldersButton_CheckedChanged);
            // 
            // navAddressLabel
            // 
            this.navAddressLabel.MergeIndex = 0;
            this.navAddressLabel.Name = "navAddressLabel";
            this.navAddressLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.navAddressLabel.Size = new System.Drawing.Size(46, 28);
            this.navAddressLabel.Text = "Address";
            // 
            // navAddressBox
            // 
            this.navAddressBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.navAddressBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.navAddressBox.AutoSize = false;
            this.navAddressBox.CurrentItem = null;
            this.navAddressBox.MaxDropDownItems = 14;
            this.navAddressBox.MergeIndex = 0;
            this.navAddressBox.Name = "navAddressBox";
            this.navAddressBox.Size = new System.Drawing.Size(200, 22);
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.browseToolStrip);
            this.Name = "Browser";
            this.Size = new System.Drawing.Size(536, 439);
            this.browseSplitter.Panel1.ResumeLayout(false);
            this.browseSplitter.Panel2.ResumeLayout(false);
            this.browseSplitter.ResumeLayout(false);
            this.viewSplitContainer.Panel2.ResumeLayout(false);
            this.viewSplitContainer.ResumeLayout(false);
            this.browseToolStrip.ContentPanel.ResumeLayout(false);
            this.browseToolStrip.TopToolStripPanel.ResumeLayout(false);
            this.browseToolStrip.TopToolStripPanel.PerformLayout();
            this.browseToolStrip.ResumeLayout(false);
            this.browseToolStrip.PerformLayout();
            this.navigationBar.ResumeLayout(false);
            this.navigationBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer browseSplitter;
        private BrowserTreeView folderView;
        private BrowserListView fileView;
        private System.Windows.Forms.ToolStripContainer browseToolStrip;
        private System.Windows.Forms.ToolStrip navigationBar;
        private System.Windows.Forms.ToolStripLabel navAddressLabel;
        private BrowserComboBox navAddressBox;
        private System.Windows.Forms.ToolStripButton navUpButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton navFoldersButton;
        private System.Windows.Forms.ToolStripSplitButton navBackButton;
        private System.Windows.Forms.ToolStripSplitButton navForwardButton;
        private System.Windows.Forms.SplitContainer viewSplitContainer;
        #endregion

        #region Fields

        // The shellbrowser used by this browser to get the shellitems of all files and folders
        private ShellBrowser shellBrowser;

        // These wrappers are used for accepting drops on the browser
        private BrowserTVDropWrapper tvDropWrapper;
        private BrowserLVDropWrapper lvDropWrapper;

        // These wrappers are used to allow dragging from the browser
        private BrowserTVDragWrapper tvDragWrapper;
        private BrowserLVDragWrapper lvDragWrapper;

        // These wrappers are used to create the standard context menu's, like in Windows Explorer
        private BrowserTVContextMenuWrapper tvContextWrapper;
        private BrowserLVContextMenuWrapper lvContextWrapper;

        private BrowserPluginWrapper pluginWrapper;

        // This field is used to store the control from where dragging has started
        private Control dragStartControl;

        // When this bool is true, selecting a node will change the current directory, 
        // otherwise the current directory won't change
        private bool selectionChange = true, newItemCreated;

        // These fields are used to determine the directory to start the browser in
        private SpecialFolders startupDir = SpecialFolders.MyComputer;
        private string otherStartupDir = string.Empty;

        // Selected node and item are the TreeNode and ShellItem of the current directory
        private TreeNode selectedNode;
        private ShellItem selectedItem;

        // These TreeNodes are used very often, so need own fields. They are for the Root (Desktop) and My Computer.
        private TreeNode desktopNode, myCompNode;

        private Thread updateThread;
        private UpdateInvoker updateInvoker;
        private bool updating;
        private ContextMenu columnContextMenu;
        private ArrayList invisibleColumns;
        private StreamStorageProvider provider;

        private IViewPlugin currentViewPlugin;

        private int maxBackForward = 10;
        private bool suspendNavBackAdd, handleCreated;

        private delegate void UpdateInvoker(object sender, ShellItemUpdateEventArgs e);

        #region Events

        /// <summary>
        /// These event will be raised when the mouse moves over a contextmenu item. This event is used to show the 
        /// help text with that contextmenu item (just like the help text in the statusbar of Windows Explorer).
        /// </summary>
        public event ContextMenuMouseHoverEventHandler ContextMenuMouseHover;

        /// <summary>
        /// This event will be raised every time the current directory changes. It will include the new current TreeNode,
        /// ShellItem and the full path to that directory.
        /// </summary>
        public event SelectedFolderChangedEventHandler SelectedFolderChanged;

        #endregion

        #endregion

        public Browser()
        {
            InitializeComponent();

            InitBrowser();
            InitFolderView();
            InitFileView();
        }

        #region Init Browser

        #region At Constructor

        /// <summary>
        /// Inits the shellbrowser and registeres some events
        /// </summary>
        private void InitBrowser()
        {
            updateInvoker = new UpdateInvoker(ShellItemUpdateInvoke);
            provider = new StreamStorageProvider(FileAccess.Read);

            Load += new EventHandler(Browser_Load);
            HandleCreated += new EventHandler(FileBrowser_HandleCreated);
            HandleDestroyed += new EventHandler(FileBrowser_HandleDestroyed);

            navAddressBox.SelectedIndexChanged += new EventHandler(navAddressBox_SelectedIndexChanged);
            navAddressBox.KeyDown += new KeyEventHandler(navAddressBox_KeyDown);
        }

        /// <summary>
        /// Registers the needed events of the TreeView control
        /// </summary>
        private void InitFolderView()
        {
            folderView.BeforeExpand += new TreeViewCancelEventHandler(folderView_BeforeExpand);
            folderView.BeforeSelect += new TreeViewCancelEventHandler(folderView_BeforeSelect);
            folderView.AfterSelect += new TreeViewEventHandler(folderView_AfterSelect);

            folderView.SetSorting(true);
        }

        /// <summary>
        /// Registers the needed events of the ListView control
        /// </summary>
        private void InitFileView()
        {
            fileView.Columns.Add("Name", "Name", 0, HorizontalAlignment.Left, -1);
            columnContextMenu = new ContextMenu();
            invisibleColumns = new ArrayList();
        }

        #endregion

        #region After Handle Created

        private void InitPlugins()
        {
            if (PluginWrapper == null)
                PluginWrapper = new BrowserPluginWrapper();

            while (fileView.Columns.Count > 1)
                fileView.Columns.RemoveAt(1);

            ColumnHeader header;
            MenuItem item;
            foreach (IColumnPlugin columnPlugin in PluginWrapper.ColumnPlugins)
            {
                foreach (string columnName in columnPlugin.ColumnNames)
                {
                    item = new MenuItem(columnName);
                    item.Checked = true;
                    item.Click += new EventHandler(ColumnContextItem_Click);
                    columnContextMenu.MenuItems.Add(item);

                    header = new ColumnHeader();
                    header.TextAlign = columnPlugin.GetAlignment(columnName);
                    header.Text = columnName;
                    header.Name = header.Text;
                    header.Tag = columnPlugin;
                    header.Width = 0;

                    fileView.Columns.Add(header);
                }
            }

            fileView.ColumnHeaderContextMenu = columnContextMenu;
        }

        /// <summary>
        /// Initialises the ContextMenu wrappers
        /// </summary>
        private void InitContextMenu()
        {
            tvContextWrapper = new BrowserTVContextMenuWrapper(this);
            lvContextWrapper = new BrowserLVContextMenuWrapper(this, PluginWrapper);
        }

        /// <summary>
        /// If the browser allows dropping, the wrappers for drag/drop are initialised and the events are registered
        /// </summary>
        private void InitDragDrop()
        {
            if (AllowDrop)
            {
                tvDropWrapper = new BrowserTVDropWrapper(this);
                lvDropWrapper = new BrowserLVDropWrapper(this);

                tvDropWrapper.Drop += new DropEventHandler(DropWrapper_Drop);
                lvDropWrapper.Drop += new DropEventHandler(DropWrapper_Drop);

                tvDragWrapper = new BrowserTVDragWrapper(this);
                lvDragWrapper = new BrowserLVDragWrapper(this);

                tvDragWrapper.DragStart += new DragEnterEventHandler(DragWrapper_DragStart);
                lvDragWrapper.DragStart += new DragEnterEventHandler(DragWrapper_DragStart);

                tvDragWrapper.DragEnd += new EventHandler(DragWrapper_DragEnd);
                lvDragWrapper.DragEnd += new EventHandler(DragWrapper_DragEnd);
            }
        }

        /// <summary>
        /// Selects the startup directory of the browser
        /// </summary>
        private void InitStartUp()
        {
            if (startupDir != SpecialFolders.Other)
                SelectPath(startupDir, true);
            else
                SelectPath(otherStartupDir, true);

            navAddressBox.SelectionLength = 0;
            navAddressBox.Text = navAddressBox.CurrentItem.Text;
            folderView.Focus();
        }

        /// <summary>
        /// Initialises the base ShellItems, including the Desktop and all it's children and the children of My Computer.
        /// These items are also added to the TreeView and the navigation bar.
        /// </summary>
        private void InitBaseItems()
        {
            if (ShellBrowser == null)
                ShellBrowser = new ShellBrowser();

            desktopNode = new TreeNode(
                ShellBrowser.DesktopItem.Text,
                ShellBrowser.DesktopItem.ImageIndex,
                ShellBrowser.DesktopItem.SelectedImageIndex);
            desktopNode.Tag = ShellBrowser.DesktopItem;
            desktopNode.Name = desktopNode.Text;

            folderView.Nodes.Add(desktopNode);
            navAddressBox.Items.Clear();
            navAddressBox.Items.Add(new BrowserComboItem(ShellBrowser.DesktopItem, 0));

            navAddressBox.CurrentItem = (BrowserComboItem)navAddressBox.Items[0];
            selectedNode = desktopNode;
            selectedItem = ShellBrowser.DesktopItem;

            ShellBrowser.DesktopItem.Expand(false, true, IntPtr.Zero);

            foreach (ShellItem desktopChild in ShellBrowser.DesktopItem.SubFolders)
            {
                TreeNode desktopChildNode = new TreeNode(
                    desktopChild.Text,
                    desktopChild.ImageIndex,
                    desktopChild.SelectedImageIndex);
                desktopChildNode.Tag = desktopChild;
                desktopChildNode.Name = desktopChildNode.Text;

                navAddressBox.Items.Add(new BrowserComboItem(desktopChild, 1));

                if (desktopChildNode.Text == ShellBrowser.MyComputerName)
                {
                    myCompNode = desktopChildNode;
                    desktopChild.Expand(false, true, IntPtr.Zero);

                    foreach (ShellItem myCompChild in desktopChild.SubFolders)
                    {
                        TreeNode myCompChildNode = new TreeNode(
                            myCompChild.Text,
                            myCompChild.ImageIndex,
                            myCompChild.SelectedImageIndex);
                        myCompChildNode.Tag = myCompChild;
                        myCompChildNode.Name = myCompChildNode.Text;

                        if (myCompChild.HasSubfolder)
                            myCompChildNode.Nodes.Add(string.Empty);

                        navAddressBox.Items.Add(new BrowserComboItem(myCompChild, 2));
                        desktopChildNode.Nodes.Add(myCompChildNode);
                    }
                }
                else if (desktopChild.HasSubfolder)
                    desktopChildNode.Nodes.Add(string.Empty);

                desktopNode.Nodes.Add(desktopChildNode);
            }
        }

        private void InitUpdate()
        {
            updateThread = new Thread(new ThreadStart(UpdateLoop));
            updateThread.IsBackground = true;
            updating = true;

            ShellBrowser.ShellItemUpdate += new ShellItemUpdateEventHandler(shellBrowser_ShellItemUpdate);
            updateThread.Start();
        }

        #endregion

        #endregion

        #region Events

        #region Browser Events

        void Browser_Load(object sender, EventArgs e)
        {
            browseSplitter.Panel1Collapsed = false;
            browseSplitter.Panel1Collapsed = !navFoldersButton.Checked;
        }

        /// <summary>
        /// When the handle of the browser is created all wrappers are initialised and the startup directory is selected.
        /// Also the update thread will be started
        /// </summary>
        void FileBrowser_HandleCreated(object sender, EventArgs e)
        {
            InitPlugins();
            InitBaseItems();
            InitContextMenu();
            InitDragDrop();
            InitStartUp();
            InitUpdate();

            GC.Collect();

            handleCreated = true;
        }

        /// <summary>
        /// When the handle is destroyed the update thread must be aborted
        /// </summary>
        void FileBrowser_HandleDestroyed(object sender, EventArgs e)
        {
            if (handleCreated)
            {
                handleCreated = false;

                folderView.Nodes.Clear();
                fileView.Items.Clear();

                updating = false;

                ShellBrowser.UpdateCondition.ContinueUpdate = false;

                updateThread.IsBackground = false;
                updateThread.Join(5000);

                GC.Collect();
            }
        }

        #endregion

        #region FolderView Events

        /// <summary>
        /// If selectionChange is true, the current directory is changed after a TreeNode is selected, if that happens
        /// the ListView will be cleared and filled with the contents of the new directory and the 
        /// SelectedFolderChangeEvent will be raised
        /// </summary>
        void folderView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (selectionChange)
            {
                ShellItem oldItem = selectedItem;
                ShellItem newItem = e.Node.Tag as ShellItem;

                if (SetNewPath(oldItem, newItem))
                {
                    if (!ShellItem.Equals(oldItem, newItem))
                    {
                        if (suspendNavBackAdd)
                            suspendNavBackAdd = false;
                        else
                            AddNavBackForwardItem(navBackButton, oldItem);

                        OnSelectedFolderChanged(new SelectedFolderChangedEventArgs(folderView.SelectedNode));
                    }
                }
                else
                    SelectPath(oldItem, false);
            }
        }

        /// <summary>
        /// If selectionChange is true, before a node is selected, the node will be expanded if it's selected by
        /// Mouse or the ShellItem will be expanded and all nodes will be added
        /// </summary>
        void folderView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (selectionChange)
            {
                ShellItem nodeItem = (ShellItem)e.Node.Tag;

                if (e.Action == TreeViewAction.ByMouse && !e.Node.IsExpanded)
                    e.Node.Expand();
                else
                    ExtendTreeNode(e.Node, false);
            }
        }

        /// <summary>
        /// Before a node is expanded, if the ShellItem hasn't been expanded or the child nodes haven't been added,
        /// this method will add all the children to the node.
        /// </summary>
        void folderView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            ShellItem nodeItem = (ShellItem)e.Node.Tag;

            Cursor.Current = Cursors.WaitCursor;
            e.Cancel = !ExtendTreeNode(e.Node, false);
            Cursor.Current = Cursors.Default;

            if (e.Cancel)
                e.Node.Nodes.Clear();
        }

        #endregion

        #region FileView Events

        private void viewSplitContainer_Resize(object sender, EventArgs e)
        {
            int distance = Math.Max(viewSplitContainer.Height - 108, 0);
            viewSplitContainer.SplitterDistance = distance;
        }

        #endregion

        #endregion

        #region Generated Events

        /// <summary>
        /// This method will raise the OnSelectedFolderChangedEvent. Before raising it the navigation bar item is changed
        /// to match the new current directory and the selectedNode property is set to the new node.
        /// </summary>
        /// <param name="e">The SelectedFolderChangedEventArgs to pass on</param>
        private void OnSelectedFolderChanged(SelectedFolderChangedEventArgs e)
        {
            ChangeNavBarItem(e);
            selectedNode = e.Node;

            if (SelectedFolderChanged != null)
                SelectedFolderChanged(this, e);
        }

        /// <summary>
        /// This method will raise the OnContextMenuMouseHoverEvent.
        /// </summary>
        /// <param name="e">The ContextMenuMouseHoverEventArgs to pass on</param>
        internal void OnContextMenuMouseHover(ContextMenuMouseHoverEventArgs e)
        {
            if (ContextMenuMouseHover != null)
                ContextMenuMouseHover(this, e);
        }

        #endregion

        #region Update File/Folder Changes

        private void UpdateLoop()
        {
            while (updating)
            {
                if (selectedItem != null)
                {
                    ShellBrowser.UpdateCondition.ContinueUpdate = true;
                    selectedItem.Update(true, true);
                }

                Thread.Sleep(500);
            }
        }

        void shellBrowser_ShellItemUpdate(object sender, ShellItemUpdateEventArgs e)
        {
            if (updating)
            {
                if (this.InvokeRequired)
                    Invoke(updateInvoker, sender, e);
                else
                    ShellItemUpdateInvoke(sender, e);
            }
        }

        private void ShellItemUpdateInvoke(object sender, ShellItemUpdateEventArgs e)
        {
            switch (e.UpdateType)
            {
                case ShellItemUpdateType.Created:
                    #region Created
                    {
                        if (Object.Equals(sender, selectedItem))
                        {
                            string[] subItems = new string[fileView.Columns.Count - 1];
                            ListViewItem newListItem = GetListViewItem(subItems, e.NewItem);
                            fileView.Items.Add(newListItem);

                            if (newItemCreated)
                            {
                                newItemCreated = false;

                                foreach (ListViewItem item in fileView.Items)
                                    item.Selected = false;

                                newListItem.Selected = true;
                                newListItem.BeginEdit();
                            }
                        }

                        if (e.NewItem.IsFolder)
                        {
                            ShellItem parent = sender as ShellItem;
                            TreeNode parentNode;

                            if (folderView.GetTreeNode(parent, out parentNode))
                            {
                                TreeNode newNode = new TreeNode(
                                    e.NewItem.Text,
                                    e.NewItem.ImageIndex,
                                    e.NewItem.SelectedImageIndex);
                                newNode.Tag = e.NewItem;

                                if (e.NewItem.HasSubfolder)
                                    newNode.Nodes.Add(string.Empty);

                                newNode.Name = newNode.Text;

                                parentNode.Nodes.Add(newNode);
                            }
                        }
                    }
                    #endregion
                    break;

                case ShellItemUpdateType.Deleted:
                    #region Deleted
                    {
                        ListViewItem listItem;
                        if (Object.Equals(sender, selectedItem) && fileView.GetListItem(e.OldItem, out listItem))
                        {
                            fileView.Items.Remove(listItem);
                        }

                        if (e.OldItem.IsFolder)
                        {
                            ShellItem parent = sender as ShellItem;
                            TreeNode parentNode;

                            if (folderView.GetTreeNode(parent, out parentNode))
                            {
                                parentNode.Nodes.RemoveByKey(e.OldItem.Text);
                            }
                        }
                    }
                    #endregion
                    break;

                case ShellItemUpdateType.Renamed:
                    #region Renamed
                    {
                        ListViewItem listItem;
                        if (Object.Equals(sender, selectedItem) && fileView.GetListItem(e.OldItem, out listItem))
                        {
                            listItem.Text = e.NewItem.Text;
                            listItem.Name = listItem.Text;
                        }

                        if (e.NewItem.IsFolder)
                        {
                            TreeNode node;

                            if (folderView.GetTreeNode(e.NewItem, out node))
                            {
                                node.Text = e.NewItem.Text;
                                node.Name = node.Text;

                                TreeNode parent = node.Parent;
                                parent.Nodes.Remove(node);
                                parent.Nodes.Add(node);
                            }
                        }
                    }
                    #endregion 
                    break;

                case ShellItemUpdateType.IconChange:
                    #region IconChange
                    {
                        ListViewItem listItem;
                        if (Object.Equals(sender, selectedItem) &&
                            fileView.GetListItem(e.OldItem, out listItem) &&
                            listItem.ImageIndex != e.NewItem.ImageIndex)
                        {
                            listItem.ImageIndex = e.NewItem.ImageIndex;
                        }

                        if (e.NewItem.IsFolder)
                        {
                            TreeNode node;

                            if (folderView.GetTreeNode(e.NewItem, out node) && node.ImageIndex != e.NewItem.ImageIndex)
                            {
                                node.ImageIndex = e.NewItem.ImageIndex;
                            }
                        }
                    }
                    #endregion
                    break;

                case ShellItemUpdateType.MediaChange:
                    #region MediaChange
                    {
                        ListViewItem listItem;
                        if (Object.Equals(sender, selectedItem) && fileView.GetListItem(e.OldItem, out listItem))
                        {
                            listItem.ImageIndex = e.NewItem.ImageIndex;
                        }

                        TreeNode node;
                        if (folderView.GetTreeNode(e.NewItem, out node))
                        {
                            node.Collapse(true);

                            if (node.Equals(selectedNode) || folderView.IsParentNode(node, selectedNode))
                                folderView.SelectedNode = node.Parent;

                            node.Nodes.Clear();
                            node.ImageIndex = e.NewItem.ImageIndex;

                            if (e.NewItem.HasSubfolder)
                                node.Nodes.Add(string.Empty);
                        }
                    }
                    #endregion
                    break;
            }
        }

        #endregion

        #region Select Path

        /// <summary>
        /// This method is used by PathExists and SelectPath to convert a string (path to a directory)
        /// to another string which is easier to use.
        /// </summary>
        /// <param name="path">The path to a directory to convert</param>
        /// <returns>The converted string</returns>
        private string ConvertPath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return path;

            string newPath = path.Trim();

            if (newPath.StartsWith(
                    string.Format(@"{0}\", ShellBrowser.MyComputerName),
                    false,
                    CultureInfo.InstalledUICulture) && newPath.Length > 12)
                newPath = newPath.Substring(path.IndexOf('\\') + 1);

            if (!newPath.EndsWith(@":\") && newPath.EndsWith(@"\"))
                newPath = newPath.Substring(0, newPath.Length - 1);

            if (newPath.EndsWith(@"\"))
                newPath = newPath.Substring(0, newPath.Length - 1);

            return newPath;
        }

        /// <summary>
        /// This method uses SHGetFileInfo to check whether a path to a directory exists.
        /// </summary>
        /// <param name="path">The path to check</param>
        /// <returns>true if it exists, false otherwise</returns>
        private bool PathExists(string path)
        {
            string realPath = ConvertPath(path);

            if (string.IsNullOrEmpty(realPath))
                return false;
            else if (string.Compare(path, "desktop", true) == 0)
                return true;

            string[] pathParts = realPath.Split('\\');

            for (int i = 0; i < pathParts.Length; i++)
            {
                bool found = false;
                if (ShellBrowser.DesktopItem.SubFolders.Contains(pathParts[i]))
                {
                    pathParts[i] = ShellItem.GetRealPath(
                        ShellBrowser.DesktopItem.SubFolders[pathParts[i]]);

                    found = true;
                }
                else
                {
                    ShellItem myComp =
                        ShellBrowser.DesktopItem.SubFolders[ShellBrowser.MyComputerName];

                    if (myComp.SubFolders.Contains(pathParts[i]))
                    {
                        pathParts[i] = ShellItem.GetRealPath(
                            myComp.SubFolders[pathParts[i]]);

                        found = true;
                    }
                }

                if (!found)
                    break;
            }

            realPath = string.Join("\\", pathParts);

            if (realPath.EndsWith(":"))
                realPath += "\\";

            ShellAPI.SHFILEINFO info = new ShellAPI.SHFILEINFO();
            IntPtr ptr = ShellAPI.SHGetFileInfo(realPath, 0, ref info, ShellAPI.cbFileInfo, ShellAPI.SHGFI.DISPLAYNAME);
            bool exists = (ptr != IntPtr.Zero);

            Marshal.FreeCoTaskMem(ptr);
            return exists;
        }

        /// <summary>
        /// Selects a path from a string, this can be a direct path, or something like 
        /// "My Documents/My Music". It will set the directory as the current directory.
        /// </summary>
        /// <param name="path">The path to select</param>
        /// <returns>The TreeNode of the directory which was selected, this will be null if the directory
        /// doesn't exist</returns>
        public TreeNode SelectPath(string path, bool expandNode)
        {
            if (string.IsNullOrEmpty(path))
                return null;

            if (PathExists(path))
            {
                string converted = ConvertPath(path);
                string[] pathParts = converted.Split('\\');

                TreeNode currentNode = null;

                #region Get Start Node
                // Change .Expand() to function which extends the node without expanding it

                if (string.Compare(pathParts[0], "desktop", true) == 0)
                    currentNode = desktopNode;
                else if (desktopNode.Nodes.ContainsKey(pathParts[0]))
                {
                    currentNode = desktopNode.Nodes[pathParts[0]];
                    ExtendTreeNode(currentNode, false);
                }
                else
                {
                    if (string.Compare(pathParts[0], myCompNode.Text, true) == 0)
                        currentNode = myCompNode;
                    else
                    {
                        if (pathParts[0][pathParts[0].Length - 1] == ':')
                            pathParts[0] += "\\";

                        foreach (TreeNode node in myCompNode.Nodes)
                        {
                            if (string.Compare(
                                    pathParts[0],
                                    ((ShellItem)node.Tag).Path, true) == 0)
                            {
                                currentNode = node;
                                ExtendTreeNode(currentNode, false);
                                break;
                            }
                        }
                    }
                }

                #endregion

                if (currentNode == null)
                {
                    folderView.EndUpdate();
                    return null;
                }

                #region Iterate

                for (int i = 1; i < pathParts.Length; i++)
                {
                    if (pathParts[i][pathParts[i].Length - 1] == ':')
                        pathParts[i] += "\\";

                    bool found = false;
                    foreach (TreeNode child in currentNode.Nodes)
                    {
                        if (string.Compare(pathParts[i], child.Text, true) == 0)
                        {
                            currentNode = child;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        folderView.EndUpdate();
                        return null;
                    }

                    ExtendTreeNode(currentNode, false);
                }

                #endregion

                if (expandNode)
                    currentNode.Expand();

                folderView.SelectedNode = currentNode;

                return currentNode;
            }
            else
                return null;
        }

        /// <summary>
        /// Selects a path from a value from the SpecialFolders enumeration.
        /// </summary>
        /// <param name="specialFolder">The SpecialFolder to select</param>
        /// <returns>The TreeNode of the directory which was selected, this will be null if the directory
        /// doesn't exist</returns>
        public TreeNode SelectPath(SpecialFolders specialFolder, bool expandNode)
        {
            StringBuilder path = new StringBuilder(256);
            IntPtr pidl = IntPtr.Zero;

            if (specialFolder == SpecialFolders.Desktop)
                return SelectPath("Desktop", expandNode);
            else if (ShellAPI.SHGetFolderPath(
                    IntPtr.Zero, (ShellAPI.CSIDL)specialFolder,
                    IntPtr.Zero, ShellAPI.SHGFP.TYPE_CURRENT, path) == ShellAPI.S_OK)
            {
                path.Replace(ShellBrowser.MyDocumentsPath, ShellBrowser.MyDocumentsName);
                return SelectPath(path.ToString(), expandNode);
            }
            else
            {
                #region Get Pidl

                if (specialFolder == SpecialFolders.MyDocuments)
                {
                    uint pchEaten = 0;
                    ShellAPI.SFGAO pdwAttributes = 0;
                    ShellBrowser.DesktopItem.ShellFolder.ParseDisplayName(
                        IntPtr.Zero,
                        IntPtr.Zero,
                        "::{450d8fba-ad25-11d0-98a8-0800361b1103}",
                        ref pchEaten,
                        out pidl,
                        ref pdwAttributes);
                }
                else
                {
                    ShellAPI.SHGetSpecialFolderLocation(
                        IntPtr.Zero,
                        (ShellAPI.CSIDL)specialFolder,
                        out pidl);
                }

                #endregion

                #region Make Path

                if (pidl != IntPtr.Zero)
                {
                    IntPtr strr = Marshal.AllocCoTaskMem(ShellAPI.MAX_PATH * 2 + 4);
                    Marshal.WriteInt32(strr, 0, 0);
                    StringBuilder buf = new StringBuilder(ShellAPI.MAX_PATH);

                    if (ShellBrowser.DesktopItem.ShellFolder.GetDisplayNameOf(
                                    pidl,
                                    ShellAPI.SHGNO.FORADDRESSBAR | ShellAPI.SHGNO.FORPARSING,
                                    strr) == ShellAPI.S_OK)
                    {
                        ShellAPI.StrRetToBuf(strr, pidl, buf, ShellAPI.MAX_PATH);
                    }

                    Marshal.FreeCoTaskMem(pidl);
                    Marshal.FreeCoTaskMem(strr);

                    if (!string.IsNullOrEmpty(buf.ToString()))
                        return SelectPath(buf.ToString(), expandNode);
                    else
                        return null;
                }
                else
                    return null;

                #endregion
            }
        }

        /// <summary>
        /// Selects a path from an existing ShellItem, this ShellItem must be present in the browsers 
        /// ShellBrowser, otherwise it can't be selected.
        /// </summary>
        /// <param name="specialFolder">The ShellItem to select</param>
        /// <returns>The TreeNode of the directory which was selected, this will be null if the directory
        /// doesn't exist</returns>
        public TreeNode SelectPath(ShellItem item, bool expandNode)
        {
            if (item == null)
                return null;

            ShellItem[] path = ShellBrowser.GetPath(item);

            if (path != null)
            {
                TreeNode currentNode = desktopNode;
                for (int i = 1; i < path.Length; i++)
                {
                    ExtendTreeNode(currentNode, false);
                    foreach (TreeNode subNode in currentNode.Nodes)
                    {
                        if (path[i].Equals(subNode.Tag))
                        {
                            currentNode = subNode;
                            break;
                        }
                    }
                }

                if (expandNode)
                    currentNode.Expand();

                folderView.SelectedNode = currentNode;

                return currentNode;
            }
            else
                return null;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// This method will fill a TreeNode with the folders from it's ShellItem
        /// </summary>
        /// <param name="node">The TreeNode to extend</param>
        private bool ExtendTreeNode(TreeNode node, bool overwrite, IntPtr handle)
        {
            if (overwrite || !IsExtended(node))
            {
                ShellItem nodeItem = (ShellItem)node.Tag;
                ShellBrowser.UpdateCondition.ContinueUpdate = false;

                if (nodeItem.Expand(false, true, handle))
                {
                    folderView.BeginUpdate();
                    node.Nodes.Clear();

                    TreeNode[] newNodesArray = new TreeNode[nodeItem.SubFolders.Count];
                    for (int i = 0; i < newNodesArray.Length; i++)
                    {
                        newNodesArray[i] = new TreeNode(
                            nodeItem.SubFolders[i].Text,
                            nodeItem.SubFolders[i].ImageIndex,
                            nodeItem.SubFolders[i].SelectedImageIndex);
                        newNodesArray[i].Tag = nodeItem.SubFolders[i];

                        if (nodeItem.SubFolders[i].HasSubfolder)
                            newNodesArray[i].Nodes.Add(string.Empty);

                        newNodesArray[i].Name = newNodesArray[i].Text;
                    }

                    node.Nodes.AddRange(newNodesArray);

                    folderView.EndUpdate();
                    return true;
                }
                else
                    return false;
            }
            else
                return true;
        }

        private bool ExtendTreeNode(TreeNode node, bool overwrite)
        {
            return ExtendTreeNode(node, overwrite, IntPtr.Zero);
        }

        private bool IsExtended(TreeNode node)
        {
            if (node.Nodes.Count == 1 && string.IsNullOrEmpty(node.Nodes[0].Text))
                return false;
            else
                return true;
        }

        /// <summary>
        /// When a new directory is selected, this method is called to clear the ListView and fill it with
        /// the contents of the new directory
        /// </summary>
        /// <param name="oldItem">The ShellItem of the previous selected directory</param>
        /// <param name="newItem">The ShellItem of the new selected directory</param>
        private bool SetNewPath(ShellItem oldItem, ShellItem newItem)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (oldItem != newItem && newItem.Expand(true, false, Handle))
            {
                ShellBrowser.UpdateCondition.ContinueUpdate = false;

                fileView.BeginUpdate();
                fileView.Items.Clear();
                fileView.ClearSelections();

                if (oldItem != null)
                {
                    bool used = false;
                    foreach (Browser br in ShellBrowser.Browsers)
                    {
                        if (!this.Equals(br) && oldItem.Equals(br.SelectedItem))
                        {
                            used = true;
                            break;
                        }
                    }

                    if (!used)
                        oldItem.Clear(true, false);
                }

                selectedItem = newItem;

                ListViewItem[] newListItemsArray = new ListViewItem[newItem.Count];
                string[] subItems = new string[fileView.Columns.Count - 1];
                for (int i = 0; i < newListItemsArray.Length; i++)
                {
                    newListItemsArray[i] = GetListViewItem(subItems, newItem[i]);
                }
                fileView.SetSorting(true);
                fileView.Items.AddRange(newListItemsArray);
                fileView.SetSorting(false);

                fileView.EndUpdate();

                Cursor.Current = Cursors.Default;
                return true;
            }
            else
            {
                Cursor.Current = Cursors.Default;
                return (oldItem == newItem);
            }
        }

        internal void ResetSpecialView()
        {
            if (fileView.Alignment != ListViewAlignment.Top)
                fileView.Alignment = ListViewAlignment.Top;

            SpecialViewPanel.Controls.Clear();
            SpecialViewPanelVisible = false;
            currentViewPlugin = null;
        }

        #endregion

        #region ListView Items/Columns

        private ListViewItem GetListViewItem(string[] subItems, ShellItem shellItem)
        {
            ListViewItem listItem = new ListViewItem(shellItem.Text, shellItem.ImageIndex);
            listItem.Name = listItem.Text;
            listItem.Tag = shellItem;

            provider.ProviderItem = shellItem;

            if (shellItem.CanRead)
            {
                if (shellItem.IsFolder)
                {
                    #region Folder Info

                    for (int i = 1; i < fileView.Columns.Count; i++)
                    {
                        IColumnPlugin plugin = fileView.Columns[i].Tag as IColumnPlugin;

                        try
                        {
                            subItems[i - 1] = plugin.GetFolderInfo(
                                provider,
                                fileView.Columns[i].Text,
                                shellItem);
                        }
                        catch (Exception)
                        {
                            subItems[i - 1] = string.Empty;
                        }
                    }

                    provider.ReleaseStorage();

                    #endregion
                }
                else
                {
                    #region File Info

                    for (int i = 1; i < fileView.Columns.Count; i++)
                    {
                        IColumnPlugin plugin = fileView.Columns[i].Tag as IColumnPlugin;

                        try
                        {
                            subItems[i - 1] = plugin.GetFileInfo(
                                provider,
                                fileView.Columns[i].Text,
                                shellItem);
                        }
                        catch (Exception)
                        {
                            subItems[i - 1] = string.Empty;
                        }
                    }

                    provider.ReleaseStream();

                    #endregion
                }
            }
            else
            {
                for (int i = 1; i < fileView.Columns.Count; i++)
                {
                    subItems[i - 1] = string.Empty;
                }
            }

            provider.ProviderItem = null;
            listItem.SubItems.AddRange(subItems);
            return listItem;
        }

        void ColumnContextItem_Click(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            item.Checked = !item.Checked;

            fileView.BeginUpdate();
            Cursor.Current = Cursors.WaitCursor;

            if (item.Checked)
            {
                #region Add Column

                foreach (ColumnHeader header in invisibleColumns)
                {
                    if (header.Text == item.Text)
                    {
                        invisibleColumns.Remove(header);
                        fileView.Columns.Add(header);

                        IColumnPlugin plugin = header.Tag as IColumnPlugin;
                        foreach (ListViewItem listItem in fileView.Items)
                        {
                            provider.ProviderItem = listItem.Tag as ShellItem;

                            if (provider.ProviderItem.CanRead)
                            {
                                try
                                {
                                    if (provider.ProviderItem.IsFolder)
                                    {
                                        #region Folder Info

                                        listItem.SubItems.Add(plugin.GetFolderInfo(
                                            provider,
                                            header.Text,
                                            provider.ProviderItem));

                                        provider.ReleaseStorage();

                                        #endregion
                                    }
                                    else
                                    {
                                        #region File Info

                                        listItem.SubItems.Add(plugin.GetFileInfo(
                                            provider,
                                            header.Text,
                                            provider.ProviderItem));

                                        provider.ReleaseStream();

                                        #endregion
                                    }
                                }
                                catch (Exception)
                                {
                                    listItem.SubItems.Add(string.Empty);
                                }
                            }
                            else
                                listItem.SubItems.Add(string.Empty);
                        }

                        provider.ProviderItem = null;

                        break;
                    }
                }

                #endregion
            }
            else
            {
                #region Remove Column

                ColumnHeader header = fileView.Columns[item.Text];

                int index = header.Index;
                fileView.Columns.Remove(header);

                foreach (ListViewItem listItem in fileView.Items)
                {
                    listItem.SubItems.RemoveAt(index);
                }

                invisibleColumns.Add(header);

                #endregion
            }

            Cursor.Current = Cursors.Default;
            fileView.EndUpdate();
        }

        #endregion

        #region Properties

        #region Non Browsable

        #region Public

        [Browsable(false)]
        public ShellItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (value != null)
                    SelectPath(value, false);
            }
        }

        [Browsable(false)]
        public TreeNode SelectedNode
        {
            get { return folderView.SelectedNode; }
            set
            {
                if (value != null)
                    folderView.SelectedNode = value;
            }
        }

        [Browsable(false)]
        public View ListViewMode
        {
            get { return fileView.View; }
            set
            {
                if (currentViewPlugin != null && value != View.SmallIcon)
                    ResetSpecialView();

                fileView.View = value;
            }
        }

        #endregion

        #region Internal

        internal IViewPlugin CurrentViewPlugin
        {
            get { return currentViewPlugin; }
            set { currentViewPlugin = value; }
        }

        [Browsable(false)]
        internal BrowserTreeView FolderView { get { return folderView; } }

        [Browsable(false)]
        internal BrowserListView FileView { get { return fileView; } }

        [Browsable(false)]
        internal BrowserComboBox NavAddressBox { get { return navAddressBox; } }

        [Browsable(false)]
        internal Panel SpecialViewPanel { get { return viewSplitContainer.Panel1; } }

        [Browsable(false)]
        internal bool SpecialViewPanelVisible
        {
            get { return !viewSplitContainer.Panel1Collapsed; }
            set { viewSplitContainer.Panel1Collapsed = !value; }
        }

        [Browsable(false)]
        internal bool NewItemCreated
        {
            get { return newItemCreated; }
            set { newItemCreated = value; }
        }

        /// <summary>
        /// The Property of selectionChange. When this bool is true the current directory will change when
        /// a TreeNode is selected, otherwise no change is made to the current directory. This is used to
        /// allow dropping on a TreeNode without changing the current directory.
        /// </summary>
        [Browsable(false)]
        internal bool SelectionChange
        {
            get { return selectionChange; }
            set { selectionChange = value; }
        }

        #endregion

        #endregion

        #region Browsable

        [Browsable(true)]
        public int SplitterDistance
        {
            get { return browseSplitter.SplitterDistance; }
            set { browseSplitter.SplitterDistance = value; }
        }

        [Category("Options"),
         Description("Shows or hides the Navigation Bar"),
         DefaultValue(true),
         Browsable(true)]
        public bool ShowNavigationBar
        {
            get { return navigationBar.Visible; }
            set { navigationBar.Visible = value; }
        }

        [Category("Options"),
         Description("Shows or hides the folder TreeView"),
         DefaultValue(true),
         Browsable(true)]
        public bool ShowFolders
        {
            get { return navFoldersButton.Checked; }
            set { navFoldersButton.Checked = value; }
        }

        [Category("Options"),
         Description("Shows or hides the button to hide and show the Folders TreeView"),
         DefaultValue(true),
         Browsable(true)]
        public bool ShowFoldersButton
        {
            get { return navFoldersButton.Visible; }
            set { navFoldersButton.Visible = value; }
        }

        [Category("Options"),
         Description("Sets the Initial Directory of the Tree"),
         DefaultValue(SpecialFolders.MyComputer),
         Browsable(true)]
        public SpecialFolders StartUpDirectory
        {
            get { return startupDir; }
            set
            {
                if (startupDir != value)
                {
                    startupDir = value;
                }
            }
        }

        [Category("Options"),
         Description("Sets the Initial Directory of the Tree when StartUpDirectory is set to \"Other\""),
         DefaultValue(""),
         Browsable(true)]
        public string StartUpDirectoryOther
        {
            get { return otherStartupDir; }
            set
            {
                if (otherStartupDir != value)
                {
                    otherStartupDir = value;
                }
            }
        }

        [Category("Options"),
         Description("Sets the ShellBrowser for the control, if null the control will create it's own."),
         DefaultValue(null),
         Browsable(true)]
        public ShellBrowser ShellBrowser
        {
            get { return shellBrowser; }
            set
            {
                if (!ShellBrowser.Equals(ShellBrowser, value))
                {
                    if (ShellBrowser != null)
                        ShellBrowser.Browsers.Remove(this);

                    if (handleCreated) FileBrowser_HandleDestroyed(this, new EventArgs());
                    shellBrowser = value;
                    if (handleCreated) FileBrowser_HandleCreated(this, new EventArgs());

                    if (!ShellBrowser.Browsers.Contains(this))
                        ShellBrowser.Browsers.Add(this);
                }
            }
        }

        [Category("Options"),
         Description("Sets the BrowserPluginWrapper for the control, if null the control will create it's own."),
         DefaultValue(null),
         Browsable(true)]
        public BrowserPluginWrapper PluginWrapper
        {
            get { return pluginWrapper; }
            set
            {
                if (!BrowserPluginWrapper.Equals(PluginWrapper, value))
                {
                    if (handleCreated) FileBrowser_HandleDestroyed(this, new EventArgs());
                    pluginWrapper = value;
                    if (handleCreated) FileBrowser_HandleCreated(this, new EventArgs());
                }
            }
        }

        #endregion

        #endregion

        #region Public

        public bool BrowserBack()
        {
            if (navBackButton.DropDownItems.Count > 0)
            {
                navBackForwardButton_ButtonClick(navBackButton, new EventArgs());
                return true;
            }
            else
                return false;
        }

        public bool BrowserForward()
        {
            if (navForwardButton.DropDownItems.Count > 0)
            {
                navBackForwardButton_ButtonClick(navForwardButton, new EventArgs());
                return true;
            }
            else
                return false;
        }

        public bool BrowserUp()
        {
            if (folderView.SelectedNode != null && folderView.SelectedNode.Parent != null)
            {
                folderView.SelectedNode = folderView.SelectedNode.Parent;
                return true;
            }
            else
                return false;
        }

        public bool CreateNewFolder()
        {
            if (selectedItem.IsFileSystem)
            {
                IntPtr newMenuPtr;
                IContextMenu newMenu;

                if (ContextMenuHelper.GetNewContextMenu(selectedItem, out newMenuPtr, out newMenu))
                {
                    lock (ShellBrowser)
                    {
                        NewItemCreated = true;
                    }

                    ContextMenuHelper.InvokeCommand(newMenu, "NewFolder", ShellItem.GetRealPath(selectedItem), new Point(0, 0));

                    Marshal.ReleaseComObject(newMenu);
                    Marshal.Release(newMenuPtr);

                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        #endregion

        #region Drag/Drop

        /// <summary>
        /// When an item is being dragged from the browser this method will set the dragStartControl to the
        /// Control from which it is being dragged. And the drop wrappers will also be informed.
        /// </summary>
        void DragWrapper_DragStart(object sender, DragEnterEventArgs e)
        {
            dragStartControl = e.DragStartControl;

            tvDropWrapper.ParentDragItem = e.Parent;
            lvDropWrapper.ParentDragItem = e.Parent;
        }

        void DragWrapper_DragEnd(object sender, EventArgs e)
        {
            tvDropWrapper.ParentDragItem = null;
            lvDropWrapper.ParentDragItem = null;
        }

        /// <summary>
        /// When an item is being dropped on the browser while holding the right mouse button, the context
        /// menu should not be showed. This method will take care of that problem.
        /// </summary>
        void DropWrapper_Drop(object sender, DropEventArgs e)
        {
            if (Control.Equals(dragStartControl, e.DragStartControl) && (e.MouseButtons & ShellAPI.MK.RBUTTON) != 0)
            {
                if (Control.Equals(dragStartControl, folderView))
                    tvContextWrapper.SuspendContextMenu = true;
                else if (Control.Equals(dragStartControl, fileView))
                    lvContextWrapper.SuspendContextMenu = true;
            }

            dragStartControl = null;
        }

        #endregion

        #region Splitter Focus Fix

        // These methods will fix a problem with the focus of the SplitContainer. 

        private void splitter_MouseDown(object sender, MouseEventArgs e)
        {
            /* This disables the normal move behavior */
            ((SplitContainer)sender).IsSplitterFixed = true;
        }

        private void splitter_MouseMove(object sender, MouseEventArgs e)
        {
            /* Check to make sure the splitter won't be updated by the 
               normal move behavior also */
            if (((SplitContainer)sender).IsSplitterFixed)
            {
                /* Make sure that the button used to move the splitter 
                   is the left mouse button */
                if (e.Button.Equals(MouseButtons.Left))
                {
                    /* Checks to see if the splitter is aligned Vertically */
                    if (((SplitContainer)sender).Orientation.Equals(Orientation.Vertical))
                    {
                        /* Only move the splitter if the mouse is within 
                           the appropriate bounds */
                        if (e.X > 0 && e.X < ((SplitContainer)sender).Width)
                        {
                            /* Move the splitter */
                            ((SplitContainer)sender).SplitterDistance = e.X;
                        }
                    }
                    /* If it isn't aligned vertically then it must be 
                       horizontal */
                    else
                    {
                        /* Only move the splitter if the mouse is within 
                           the appropriate bounds */
                        if (e.Y > 0 && e.Y < ((SplitContainer)sender).Height)
                        {
                            /* Move the splitter */
                            ((SplitContainer)sender).SplitterDistance = e.Y;
                        }
                    }

                    ((SplitContainer)sender).Refresh();
                }
                /* If a button other than left is pressed or no button 
                   at all */
                else
                {
                    /* This allows the splitter to be moved normally again */
                    ((SplitContainer)sender).IsSplitterFixed = false;
                }
            }
        }

        private void splitter_MouseUp(object sender, MouseEventArgs e)
        {
            /* This allows the splitter to be moved normally again */
            ((SplitContainer)sender).IsSplitterFixed = false;
        }

        #endregion        

        #region Navigation Bar

        #region Path

        /// <summary>
        /// This method will set the current directory of the navigation bar to match the current selected
        /// directory of the browser. It will add and remove items to make it look like the Windows Explorer
        /// ComboBox.
        /// </summary>
        private void ChangeNavBarItem(SelectedFolderChangedEventArgs e)
        {
            if (!navAddressBox.CurrentItem.ShellItem.Equals(e.Item))
            {
                int currentIndex = navAddressBox.Items.IndexOf(navAddressBox.CurrentItem);
                BrowserComboItem currentItem = navAddressBox.CurrentItem;
                int maxIndent = folderView.IsParentNode(myCompNode, selectedNode) ? 3 : 2;
                TreeNode[] path;

                bool isMyCompChild = folderView.IsParentNode(myCompNode, e.Node);
                if (selectedNode.Nodes.Contains(e.Node) &&
                    ((isMyCompChild && e.Node.Level >= 3) || (!isMyCompChild && e.Node.Level >= 2)))
                {
                    navAddressBox.Items.Insert(currentIndex + 1, new BrowserComboItem(e.Item, e.Node.Level));
                    navAddressBox.SelectedIndex = currentIndex + 1;
                }
                else if (folderView.IsParentNode(e.Node, selectedNode, out path))
                {
                    if (e.Node.Equals(desktopNode))
                        navAddressBox.SelectedIndex = 0;
                    else if (e.Node.Equals(myCompNode))
                        navAddressBox.SelectedIndex = desktopNode.Nodes.IndexOf(myCompNode) + 1;
                    else
                        navAddressBox.SelectedIndex = currentIndex - path.Length + 1;

                    while (currentItem.Text != e.Node.Text && currentItem.Indent >= maxIndent)
                    {
                        navAddressBox.Items.Remove(currentItem);
                        currentIndex--;
                        currentItem = (BrowserComboItem)navAddressBox.Items[currentIndex];
                    }
                }
                else
                {
                    while (currentItem.Indent >= maxIndent && !e.Node.Equals(myCompNode))
                    {
                        navAddressBox.Items.Remove(currentItem);
                        currentIndex--;
                        currentItem = (BrowserComboItem)navAddressBox.Items[currentIndex];
                    }

                    if (folderView.IsParentNode(myCompNode, e.Node, out path))
                    {
                        if (path.Length > 2)
                        {
                            int startIndex =
                                desktopNode.Nodes.IndexOf(myCompNode) +
                                myCompNode.Nodes.IndexOf(path[1]) + 1;

                            for (int i = 2; i < path.Length; i++)
                            {
                                navAddressBox.Items.Insert(startIndex + i,
                                    new BrowserComboItem((ShellItem)path[i].Tag, i + 1));
                            }

                            navAddressBox.SelectedIndex = startIndex + path.Length - 1;
                        }
                        else
                        {
                            navAddressBox.SelectedIndex =
                                desktopNode.Nodes.IndexOf(myCompNode) +
                                myCompNode.Nodes.IndexOf(e.Node) + 2;
                        }
                    }
                    else if (folderView.IsParentNode(desktopNode, e.Node, out path))
                    {
                        if (path.Length > 2)
                        {
                            int startIndex = desktopNode.Nodes.IndexOf(path[1]);

                            for (int i = 2; i < path.Length; i++)
                            {
                                navAddressBox.Items.Insert(startIndex + i,
                                    new BrowserComboItem((ShellItem)path[i].Tag, i));
                            }

                            navAddressBox.SelectedIndex = startIndex + path.Length - 1;
                        }
                        else
                        {
                            if (desktopNode.Nodes.IndexOf(e.Node) <= desktopNode.Nodes.IndexOf(myCompNode))
                                navAddressBox.SelectedIndex = desktopNode.Nodes.IndexOf(e.Node) + 1;
                            else
                                navAddressBox.SelectedIndex = desktopNode.Nodes.IndexOf(e.Node) + myCompNode.Nodes.Count + 1;
                        }
                    }
                    else
                        navAddressBox.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// This method will take care of resizing the Navigation ComboBox to make it as long as possible
        /// </summary>
        private void navigationBar_Resize(object sender, EventArgs e)
        {
            int newSize = navigationBar.Width - navAddressLabel.Bounds.Right - 15;

            if (newSize > 0)
                navAddressBox.Size = new Size(newSize, navAddressBox.Height);

            navAddressBox.SelectionLength = 0;
        }

        /// <summary>
        /// When another item is selected from the navigationbar, 
        /// this method will set the current selected directory to math it
        /// </summary>
        void navAddressBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (navAddressBox.SelectedIndex > -1)
            {
                ShellItem item = ((BrowserComboItem)navAddressBox.Items[navAddressBox.SelectedIndex]).ShellItem;

                if (!selectedItem.Equals(item))
                {
                    TreeNode oldNode = selectedNode;
                    int currentIndex = navAddressBox.Items.IndexOf(navAddressBox.CurrentItem);
                    BrowserComboItem currentItem = navAddressBox.CurrentItem;
                    int maxIndent = folderView.IsParentNode(myCompNode, selectedNode) ? 3 : 2;

                    navAddressBox.CurrentItem = (BrowserComboItem)navAddressBox.Items[navAddressBox.SelectedIndex];
                    TreeNode newNode = SelectPath(item, false);

                    if (folderView.IsParentNode(newNode, oldNode))
                    {
                        while (currentItem.Text != newNode.Text && currentItem.Indent >= maxIndent)
                        {
                            navAddressBox.Items.Remove(currentItem);
                            currentIndex--;
                            currentItem = (BrowserComboItem)navAddressBox.Items[currentIndex];
                        }
                    }
                    else
                    {
                        while (currentItem.Indent >= maxIndent)
                        {
                            navAddressBox.Items.Remove(currentItem);
                            currentIndex--;
                            currentItem = (BrowserComboItem)navAddressBox.Items[currentIndex];
                        }
                    }
                }
            }
        }

        #endregion

        #region Buttons

        #region Back/Forward

        private void AddNavBackForwardItem(ToolStripSplitButton button, ShellItem selectedItem)
        {
            Bitmap image = ShellImageList.GetIcon(selectedItem.ImageIndex, true).ToBitmap();
            ToolStripMenuItem backItem = new ToolStripMenuItem(selectedItem.Text, image);
            backItem.Name = backItem.Text;
            backItem.Tag = selectedItem;
            backItem.ImageScaling = ToolStripItemImageScaling.None;

            if (button.DropDownItems.Count == maxBackForward)
                button.DropDownItems.RemoveAt(maxBackForward - 1);

            button.DropDownItems.Insert(0, backItem);
            button.Enabled = true;
        }

        private void navBackForwardButton_ButtonClick(object sender, EventArgs e)
        {
            ToolStripSplitButton button = sender as ToolStripSplitButton;

            if (sender.Equals(navBackButton))
            {
                AddNavBackForwardItem(navForwardButton, selectedItem);
            }
            else
            {
                AddNavBackForwardItem(navBackButton, selectedItem);
            }

            ToolStripItem item = button.DropDownItems[0];
            button.DropDownItems.Remove(item);

            if (button.DropDownItems.Count == 0)
                button.Enabled = false;

            suspendNavBackAdd = true;
            SelectPath((ShellItem)item.Tag, false);
        }

        private void navBackForwardButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripSplitButton button = sender as ToolStripSplitButton;

            if (sender.Equals(navBackButton))
            {
                AddNavBackForwardItem(navForwardButton, selectedItem);
            }
            else
            {
                AddNavBackForwardItem(navBackButton, selectedItem);
            }

            int index = button.DropDownItems.IndexOf(e.ClickedItem);

            ToolStripItem item;
            while (index > -1)
            {
                item = button.DropDownItems[0];
                button.DropDownItems.Remove(item);
                index--;

                if (index > -1 && sender.Equals(navBackButton))
                {
                    navForwardButton.Enabled = true;
                    navForwardButton.DropDownItems.Insert(0, item);

                    if (navForwardButton.DropDownItems.Count > maxBackForward)
                        navForwardButton.DropDownItems.RemoveAt(maxBackForward);
                }
                else if (index > -1)
                {
                    navBackButton.Enabled = true;
                    navBackButton.DropDownItems.Insert(0, item);

                    if (navBackButton.DropDownItems.Count > maxBackForward)
                        navBackButton.DropDownItems.RemoveAt(maxBackForward);
                }
            }

            if (button.DropDownItems.Count == 0)
                button.Enabled = false;

            suspendNavBackAdd = true;
            SelectPath((ShellItem)e.ClickedItem.Tag, false);
        }

        #endregion

        /// <summary>
        /// When the folders button on the navigationbar is clicked this method will show or hide
        /// the TreeView
        /// </summary>
        private void navFoldersButton_CheckedChanged(object sender, EventArgs e)
        {
            browseSplitter.Panel1Collapsed = !browseSplitter.Panel1Collapsed;
        }

        /// <summary>
        /// When the up button on the navigationbar is clicked this method will select
        /// the parent of the current selected directory
        /// </summary>
        private void navUpButton_Click(object sender, EventArgs e)
        {
            BrowserUp();
        }

        #endregion

        /// <summary>
        /// When enter is pressed when focused on the ComboBox of the navigation bar, 
        /// this method will select the directory of the navigationbar.
        /// </summary>
        void navAddressBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (SelectPath(navAddressBox.Text, false) == null)
                    e.Handled = true;
            }
        }

        #endregion
    }

    #region Custom EventArgs

    public class ContextMenuMouseHoverEventArgs : EventArgs
    {
        private string info;

        public ContextMenuMouseHoverEventArgs(string info)
        {
            this.info = info;
        }

        // The help info of the contextmenu item
        public string ContextMenuItemInfo { get { return info; } }
    }

    public class SelectedFolderChangedEventArgs : EventArgs
    {
        private TreeNode node;
        private ShellItem item;

        public SelectedFolderChangedEventArgs(TreeNode node)
        {
            this.node = node;
            item = (ShellItem)node.Tag;
        }

        // The TreeNode of the new current selected directory
        public TreeNode Node { get { return node; } }

        // The ShellItem of the new current selected directory
        public ShellItem Item { get { return item; } }

        // The full path to the new current selected directory
        public string Path { get { return ShellItem.GetRealPath(item); } }
    }

    #endregion
}