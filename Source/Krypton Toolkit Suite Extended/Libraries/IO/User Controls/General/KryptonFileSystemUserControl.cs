#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Core;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [ToolboxBitmap(typeof(KryptonTreeView)), DefaultEvent("PathChanged")]
    public class KryptonFileSystemUserControl : UserControl
    {
        #region Design Code
        private ImageList ilSystemIcons;
        private IContainer components;
        private ContextMenuStrip cmsShortcuts;
        private Panel pnlTop;
        private Panel panel2;
        private KryptonButton kbtnAdd;
        private KryptonButton kbtnGo;
        private KryptonTextBox ktxtPath;
        private KryptonButton kbtnInfo;
        private KryptonButton kbtnRefresh;
        private KryptonButton ktbnHome;
        private KryptonButton kbtnUp;
        private KryptonButton kbtnBack;
        private KryptonButton kbtnForward;
        private ListView listView1;
        private ColumnHeader clmnPath;
        private ColumnHeader clmnStatus;
        private KryptonTreeView ktvFileSystem;
        private ToolStripMenuItem removeShortcutToolStripMenuItem;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonFileSystemUserControl));
            this.ilSystemIcons = new System.Windows.Forms.ImageList(this.components);
            this.cmsShortcuts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeShortcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.kbtnGo = new Krypton.Toolkit.KryptonButton();
            this.ktxtPath = new Krypton.Toolkit.KryptonTextBox();
            this.kbtnInfo = new Krypton.Toolkit.KryptonButton();
            this.kbtnRefresh = new Krypton.Toolkit.KryptonButton();
            this.ktbnHome = new Krypton.Toolkit.KryptonButton();
            this.kbtnUp = new Krypton.Toolkit.KryptonButton();
            this.kbtnBack = new Krypton.Toolkit.KryptonButton();
            this.kbtnForward = new Krypton.Toolkit.KryptonButton();
            this.kbtnAdd = new Krypton.Toolkit.KryptonButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.clmnPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ktvFileSystem = new Krypton.Toolkit.KryptonTreeView();
            this.cmsShortcuts.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilSystemIcons
            // 
            this.ilSystemIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilSystemIcons.ImageStream")));
            this.ilSystemIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilSystemIcons.Images.SetKeyName(0, "");
            this.ilSystemIcons.Images.SetKeyName(1, "");
            this.ilSystemIcons.Images.SetKeyName(2, "");
            this.ilSystemIcons.Images.SetKeyName(3, "");
            this.ilSystemIcons.Images.SetKeyName(4, "");
            this.ilSystemIcons.Images.SetKeyName(5, "");
            this.ilSystemIcons.Images.SetKeyName(6, "");
            this.ilSystemIcons.Images.SetKeyName(7, "");
            this.ilSystemIcons.Images.SetKeyName(8, "");
            this.ilSystemIcons.Images.SetKeyName(9, "");
            this.ilSystemIcons.Images.SetKeyName(10, "");
            this.ilSystemIcons.Images.SetKeyName(11, "");
            this.ilSystemIcons.Images.SetKeyName(12, "");
            this.ilSystemIcons.Images.SetKeyName(13, "");
            this.ilSystemIcons.Images.SetKeyName(14, "");
            this.ilSystemIcons.Images.SetKeyName(15, "");
            this.ilSystemIcons.Images.SetKeyName(16, "");
            this.ilSystemIcons.Images.SetKeyName(17, "");
            this.ilSystemIcons.Images.SetKeyName(18, "");
            this.ilSystemIcons.Images.SetKeyName(19, "");
            this.ilSystemIcons.Images.SetKeyName(20, "");
            this.ilSystemIcons.Images.SetKeyName(21, "");
            this.ilSystemIcons.Images.SetKeyName(22, "");
            this.ilSystemIcons.Images.SetKeyName(23, "");
            this.ilSystemIcons.Images.SetKeyName(24, "");
            this.ilSystemIcons.Images.SetKeyName(25, "");
            this.ilSystemIcons.Images.SetKeyName(26, "");
            this.ilSystemIcons.Images.SetKeyName(27, "");
            this.ilSystemIcons.Images.SetKeyName(28, "");
            // 
            // cmsShortcuts
            // 
            this.cmsShortcuts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsShortcuts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeShortcutToolStripMenuItem});
            this.cmsShortcuts.Name = "cmsShortcuts";
            this.cmsShortcuts.Size = new System.Drawing.Size(166, 26);
            // 
            // removeShortcutToolStripMenuItem
            // 
            this.removeShortcutToolStripMenuItem.Name = "removeShortcutToolStripMenuItem";
            this.removeShortcutToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.removeShortcutToolStripMenuItem.Text = "&Remove Shortcut";
            this.removeShortcutToolStripMenuItem.Click += new System.EventHandler(this.removeShortcutToolStripMenuItem_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.kbtnGo);
            this.pnlTop.Controls.Add(this.ktxtPath);
            this.pnlTop.Controls.Add(this.kbtnInfo);
            this.pnlTop.Controls.Add(this.kbtnRefresh);
            this.pnlTop.Controls.Add(this.ktbnHome);
            this.pnlTop.Controls.Add(this.kbtnUp);
            this.pnlTop.Controls.Add(this.kbtnBack);
            this.pnlTop.Controls.Add(this.kbtnForward);
            this.pnlTop.Controls.Add(this.kbtnAdd);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(377, 80);
            this.pnlTop.TabIndex = 1;
            // 
            // kbtnGo
            // 
            this.kbtnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnGo.AutoSize = true;
            this.kbtnGo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGo.Location = new System.Drawing.Point(343, 40);
            this.kbtnGo.Name = "kbtnGo";
            this.kbtnGo.Size = new System.Drawing.Size(22, 22);
            this.kbtnGo.TabIndex = 8;
            this.kbtnGo.Values.Image = global::Krypton.Toolkit.Suite.Extended.IO.Properties.Resources.kbtnGo_Values_Image;
            this.kbtnGo.Values.Text = "";
            this.kbtnGo.Click += new System.EventHandler(this.kbtnGo_Click);
            // 
            // ktxtPath
            // 
            this.ktxtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ktxtPath.Hint = "Type a path here... (e.g. C:\\Windows)";
            this.ktxtPath.Location = new System.Drawing.Point(14, 40);
            this.ktxtPath.Name = "ktxtPath";
            this.ktxtPath.Size = new System.Drawing.Size(323, 23);
            this.ktxtPath.TabIndex = 7;
            this.ktxtPath.TextChanged += new System.EventHandler(this.ktxtPath_TextChanged);
            this.ktxtPath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ktxtPath_KeyUp);
            // 
            // kbtnInfo
            // 
            this.kbtnInfo.AutoSize = true;
            this.kbtnInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnInfo.Location = new System.Drawing.Point(182, 12);
            this.kbtnInfo.Name = "kbtnInfo";
            this.kbtnInfo.Size = new System.Drawing.Size(22, 22);
            this.kbtnInfo.TabIndex = 6;
            this.kbtnInfo.Values.Image = global::Krypton.Toolkit.Suite.Extended.IO.Properties.Resources.kbtnInfo_Values_Image;
            this.kbtnInfo.Values.Text = "";
            this.kbtnInfo.Click += new System.EventHandler(this.kbtnInfo_Click);
            // 
            // kbtnRefresh
            // 
            this.kbtnRefresh.AutoSize = true;
            this.kbtnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnRefresh.Location = new System.Drawing.Point(126, 12);
            this.kbtnRefresh.Name = "kbtnRefresh";
            this.kbtnRefresh.Size = new System.Drawing.Size(22, 22);
            this.kbtnRefresh.TabIndex = 5;
            this.kbtnRefresh.Values.Image = global::Krypton.Toolkit.Suite.Extended.IO.Properties.Resources.kbtnRefresh_Values_Image;
            this.kbtnRefresh.Values.Text = "";
            this.kbtnRefresh.Click += new System.EventHandler(this.kbtnRefresh_Click);
            // 
            // ktbnHome
            // 
            this.ktbnHome.AutoSize = true;
            this.ktbnHome.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ktbnHome.Location = new System.Drawing.Point(154, 12);
            this.ktbnHome.Name = "ktbnHome";
            this.ktbnHome.Size = new System.Drawing.Size(22, 22);
            this.ktbnHome.TabIndex = 4;
            this.ktbnHome.Values.Image = global::Krypton.Toolkit.Suite.Extended.IO.Properties.Resources.kbtnHome_Values_Image;
            this.ktbnHome.Values.Text = "";
            this.ktbnHome.Click += new System.EventHandler(this.ktbnHome_Click);
            // 
            // kbtnUp
            // 
            this.kbtnUp.AutoSize = true;
            this.kbtnUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnUp.Location = new System.Drawing.Point(98, 12);
            this.kbtnUp.Name = "kbtnUp";
            this.kbtnUp.Size = new System.Drawing.Size(22, 22);
            this.kbtnUp.TabIndex = 3;
            this.kbtnUp.Values.Image = global::Krypton.Toolkit.Suite.Extended.IO.Properties.Resources.kbtnUp_Values_Image;
            this.kbtnUp.Values.Text = "";
            this.kbtnUp.Click += new System.EventHandler(this.kbtnUp_Click);
            // 
            // kbtnBack
            // 
            this.kbtnBack.AutoSize = true;
            this.kbtnBack.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnBack.Location = new System.Drawing.Point(42, 12);
            this.kbtnBack.Name = "kbtnBack";
            this.kbtnBack.Size = new System.Drawing.Size(22, 22);
            this.kbtnBack.TabIndex = 2;
            this.kbtnBack.Values.Image = global::Krypton.Toolkit.Suite.Extended.IO.Properties.Resources.kbtnBack_Values_Image;
            this.kbtnBack.Values.Text = "";
            this.kbtnBack.Click += new System.EventHandler(this.kbtnBack_Click);
            // 
            // kbtnForward
            // 
            this.kbtnForward.AutoSize = true;
            this.kbtnForward.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnForward.Location = new System.Drawing.Point(70, 12);
            this.kbtnForward.Name = "kbtnForward";
            this.kbtnForward.Size = new System.Drawing.Size(22, 22);
            this.kbtnForward.TabIndex = 1;
            this.kbtnForward.Values.Image = global::Krypton.Toolkit.Suite.Extended.IO.Properties.Resources.kbtnNext_Values_Image;
            this.kbtnForward.Values.Text = "";
            this.kbtnForward.Click += new System.EventHandler(this.kbtnForward_Click);
            // 
            // kbtnAdd
            // 
            this.kbtnAdd.AutoSize = true;
            this.kbtnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnAdd.Location = new System.Drawing.Point(14, 12);
            this.kbtnAdd.Name = "kbtnAdd";
            this.kbtnAdd.Size = new System.Drawing.Size(22, 22);
            this.kbtnAdd.TabIndex = 0;
            this.kbtnAdd.Values.Image = global::Krypton.Toolkit.Suite.Extended.IO.Properties.Resources.kbtnAdd_Values_Image;
            this.kbtnAdd.Values.Text = "";
            this.kbtnAdd.Click += new System.EventHandler(this.kbtnAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Controls.Add(this.ktvFileSystem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 367);
            this.panel2.TabIndex = 2;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnPath,
            this.clmnStatus});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(14, 246);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(285, 71);
            this.listView1.TabIndex = 90;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            // 
            // ktvFileSystem
            // 
            this.ktvFileSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktvFileSystem.Location = new System.Drawing.Point(0, 0);
            this.ktvFileSystem.Name = "ktvFileSystem";
            this.ktvFileSystem.Size = new System.Drawing.Size(377, 367);
            this.ktvFileSystem.TabIndex = 0;
            this.ktvFileSystem.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.ktvFileSystem_AfterExpand);
            this.ktvFileSystem.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ktvFileSystem_AfterSelect);
            this.ktvFileSystem.DoubleClick += new System.EventHandler(this.ktvFileSystem_DoubleClick);
            this.ktvFileSystem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ktvFileSystem_MouseUp);
            // 
            // KryptonFileSystemUserControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlTop);
            this.Name = "KryptonFileSystemUserControl";
            this.Size = new System.Drawing.Size(377, 447);
            this.Load += new System.EventHandler(this.KryptonFileSystemUserControl_Load);
            this.cmsShortcuts.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool goflag = false, showMyDocuments = true, showMyFavorites = true, showMyNetwork = true, showAddressbar = true, showToolbar = true;

        private string selectedPath = "home";

        private KryptonTreeNode node, thisComputerNode, rootNode;
        #endregion

        #region Properties
        private bool GoFlag
        {
            get
            {
                return goflag;
            }
            set
            {
                goflag = value;
            }
        }

        public bool ShowAddressbar
        {
            get
            {
                return showAddressbar;
            }
            set
            {
                showAddressbar = value;
            }
        }

        public bool ShowToolbar
        {
            get
            {
                return showToolbar;
            }
            set
            {
                showToolbar = value;
            }
        }

        public bool ShowMyDocuments
        {
            get
            {
                return showMyDocuments;
            }
            set
            {
                showMyDocuments = value;
                this.Refresh();
            }
        }

        public bool ShowMyFavorites
        {
            get
            {
                return showMyFavorites;
            }
            set
            {
                showMyFavorites = value;
                this.Refresh();
            }
        }

        public bool ShowMyNetwork
        {
            get
            {
                return showMyNetwork;
            }
            set
            {
                showMyNetwork = value;
                this.Refresh();
            }
        }

        [
        Category("Appearance"),
        Description("Selected Path of Image")
        ]
        public string SelectedPath
        {
            get
            {
                return this.selectedPath;
            }
            set
            {
                this.selectedPath = value;
                this.Invalidate();
            }
        }
        #endregion

        #region Custom Event
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void PathChangedEventHandler(object sender, EventArgs e);

        /// <summary>
        /// The path changed event
        /// </summary>
        private PathChangedEventHandler PathChangedEvent;

        /// <summary>
        /// Occurs when [path changed].
        /// </summary>
        public event PathChangedEventHandler PathChanged
        {
            add => PathChangedEvent = (PathChangedEventHandler)Delegate.Combine(PathChangedEvent, value);

            remove => PathChangedEvent = (PathChangedEventHandler)Delegate.Remove(PathChangedEvent, value);
        }
        #endregion

        #region Constructor
        public KryptonFileSystemUserControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Disposal
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null) components.Dispose();
            }

            base.Dispose(disposing);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Refreshes the view.
        /// </summary>
        public void RefreshView()
        {
            if ((!ShowAddressbar) && (!ShowToolbar))
            {
                SetTopVisibility(false);

                ktvFileSystem.Dock = DockStyle.Fill;
            }
            else
            {
                if (ShowToolbar && (!ShowAddressbar))
                {
                    ResizeTopPanel(new Size(519, 43));

                    SetToolbarVisibility(true);

                    ktxtPath.Visible = false;

                    kbtnGo.Visible = false;

                    ktvFileSystem.Size = new Size(519, 499);
                }
                else if (ShowAddressbar && (!ShowToolbar))
                {
                    ResizeTopPanel(new Size(519, 43));

                    SetToolbarVisibility(false);

                    ktxtPath.Visible = true;

                    ktxtPath.Location = new Point(12, 12);

                    kbtnGo.Visible = true;

                    RelocateButton(kbtnGo, new Point(483, 12));

                    ktvFileSystem.Size = new Size(519, 499);
                }
                else
                {
                    ResetKryptonFileSystemUserControlUI();
                }
            }
        }

        public void GetDirectory()
        {
            ktvFileSystem.Nodes.Clear();

            string[] allDrives = Environment.GetLogicalDrives();

            KryptonTreeNode nodeDesktop, nodeDocuments, nodeFavorites, nodeThisPC, nodeNC, nodeNetwork, nodeEN, nodeNN;

            nodeDesktop = new KryptonTreeNode();

            nodeDesktop.Tag = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            nodeDesktop.Text = "Desktop";

            nodeDesktop.ImageIndex = 10;

            nodeDesktop.SelectedImageIndex = 10;

            ktvFileSystem.Nodes.Add(nodeDesktop);

            rootNode = nodeDesktop;

            if (ShowMyDocuments)
            {
                nodeDocuments = new KryptonTreeNode();

                nodeDocuments.Tag = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

                if (Environment.OSVersion.Version.Major >= 6)
                {
                    nodeDocuments.Text = "Documents";
                }
                else if (Environment.OSVersion.Version.Major < 6)
                {
                    nodeDocuments.Text = "My Documents";
                }

                nodeDocuments.ImageIndex = 9;

                nodeDocuments.SelectedImageIndex = 9;

                nodeDesktop.Nodes.Add(nodeDocuments);

                FillFilesAndDirectories(nodeDocuments);
            }

            nodeThisPC = new KryptonTreeNode();

            if (Environment.OSVersion.Version.Major == 10) // Windows 10
            {
                nodeThisPC.Tag = "This PC";

                nodeThisPC.Text = "This PC";
            }
            else if (Environment.OSVersion.Version.Major == 6) // Windows Vista, 7, 8 & 8.1
            {
                nodeThisPC.Tag = "Computer";

                nodeThisPC.Text = "Computer";
            }
            else if (Environment.OSVersion.Version.Major < 6) // Windows XP and earlier
            {
                nodeThisPC.Tag = "My Computer";

                nodeThisPC.Text = "My Computer";
            }

            nodeThisPC.ImageIndex = 12;

            nodeThisPC.SelectedImageIndex = 12;

            nodeDesktop.Nodes.Add(nodeThisPC);

            nodeThisPC.EnsureVisible();

            thisComputerNode = nodeThisPC;

            nodeNC = new KryptonTreeNode();

            nodeNC.Tag = "my Node";

            nodeNC.Text = "my Node";

            nodeNC.ImageIndex = 12;

            nodeNC.SelectedImageIndex = 12;

            nodeThisPC.Nodes.Add(nodeNC);

            if (ShowMyNetwork)
            {

                nodeNetwork = new KryptonTreeNode();
                nodeNetwork.Tag = "My Network Places";
                nodeNetwork.Text = "My Network Places";
                nodeNetwork.ImageIndex = 13;
                nodeNetwork.SelectedImageIndex = 13;
                nodeDesktop.Nodes.Add(nodeNetwork);
                nodeNetwork.EnsureVisible();

                nodeEN = new KryptonTreeNode();
                nodeEN.Tag = "Entire Network";
                nodeEN.Text = "Entire Network";
                nodeEN.ImageIndex = 14;
                nodeEN.SelectedImageIndex = 14;
                nodeNetwork.Nodes.Add(nodeEN);

                nodeNN = new KryptonTreeNode();
                nodeNN.Tag = "Network Node";
                nodeNN.Text = "Network Node";
                nodeNN.ImageIndex = 15;
                nodeNN.SelectedImageIndex = 15;
                nodeEN.Nodes.Add(nodeNN);

                nodeEN.EnsureVisible();
            }

            if (ShowMyFavorites)
            {
                nodeFavorites = new KryptonTreeNode();
                nodeFavorites.Tag = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
                nodeFavorites.Text = "My Favorites";
                nodeFavorites.ImageIndex = 26;
                nodeFavorites.SelectedImageIndex = 26;
                nodeDesktop.Nodes.Add(nodeFavorites);
                FillFilesAndDirectories(nodeFavorites);
            }

            ExploreTreeNode(nodeDesktop);
        }

        private void ExploreTreeNode(KryptonTreeNode node)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                //get dirs
                FillFilesAndDirectories(node);

                //get dirs one more level deep in current dir so user can see there is
                //more dirs underneath current dir
                foreach (KryptonTreeNode nodes in node.Nodes)
                {
                    if (String.Compare(node.Text, "Desktop") == 0)
                    {
                        if ((String.Compare(nodes.Text, "My Documents") == 0) || (String.Compare(nodes.Text, "My Computer") == 0) || (String.Compare(nodes.Text, "Microsoft Windows Network") == 0) || (String.Compare(nodes.Text, "My Network Places") == 0))
                        { }
                        else
                        {
                            FillFilesAndDirectories(nodes);
                        }
                    }
                    else
                    {
                        FillFilesAndDirectories(nodes);
                    }
                }
            }

            catch
            { }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void GetDirectories(KryptonTreeNode parentNode)
        {
            // added after suggestion
            string[] dirList;

            dirList = Directory.GetDirectories(parentNode.Tag.ToString());
            Array.Sort(dirList);

            //check if dir already exists in case click same dir twice
            if (dirList.Length == parentNode.Nodes.Count)
                return;
            //add each dir in selected dir
            for (int i = 0; i < dirList.Length; i++)
            {
                node = new KryptonTreeNode();
                node.Tag = dirList[i]; //store path in tag
                node.Text = dirList[i].Substring(dirList[i].LastIndexOf(@"\") + 1);
                node.ImageIndex = 1;
                parentNode.Nodes.Add(node);
            }
        }

        private void FillFilesAndDirectories(KryptonTreeNode node)
        {
            try
            {
                GetDirectories(node);
            }
            catch (Exception)
            {
                return;
            }
        }

        public void SetCurrentPath(string path)
        {
            SelectedPath = path;

            if (String.Compare(path, "home") == 0)
            {
                ktxtPath.Text = Application.StartupPath;
            }
            else
            {
                DirectoryInfo inf = new DirectoryInfo(path);

                if (inf.Exists)
                {
                    ktxtPath.Text = path;

                }
                else
                {
                    ktxtPath.Text = Application.StartupPath;
                }
            }
        }

        public void RefreshFolders()
        {
            listView1.Items.Clear();

            ktvFileSystem.Nodes.Clear();

            SetCurrentPath(Environment.GetFolderPath(Environment.SpecialFolder.Personal));

            GetDirectory();
        }

        private void ExploreThisPC()
        {
            string[] drives = Environment.GetLogicalDrives();
            string dir2 = "";

            Cursor.Current = Cursors.WaitCursor;
            KryptonTreeNode nodeDrive;

            if (thisComputerNode.GetNodeCount(true) < 2)
            {
                thisComputerNode.FirstNode.Remove();

                foreach (string drive in drives)
                {
                    nodeDrive = new KryptonTreeNode();
                    nodeDrive.Tag = drive;

                    nodeDrive.Text = drive;

                    switch (NativeMethods.GetDriveType(drive))
                    {
                        case 2:
                            nodeDrive.ImageIndex = 17;
                            nodeDrive.SelectedImageIndex = 17;
                            break;
                        case 3:
                            nodeDrive.ImageIndex = 0;
                            nodeDrive.SelectedImageIndex = 0;
                            break;
                        case 4:
                            nodeDrive.ImageIndex = 8;
                            nodeDrive.SelectedImageIndex = 8;
                            break;
                        case 5:
                            nodeDrive.ImageIndex = 7;
                            nodeDrive.SelectedImageIndex = 7;
                            break;
                        default:
                            nodeDrive.ImageIndex = 0;
                            nodeDrive.SelectedImageIndex = 0;
                            break;
                    }

                    thisComputerNode.Nodes.Add(nodeDrive);
                    try
                    {
                        //add dirs under drive
                        if (Directory.Exists(drive))
                        {
                            foreach (string dir in Directory.GetDirectories(drive))
                            {
                                dir2 = dir;
                                node = new KryptonTreeNode();
                                node.Tag = dir;
                                node.Text = dir.Substring(dir.LastIndexOf(@"\") + 1);
                                node.ImageIndex = 1;
                                nodeDrive.Nodes.Add(node);
                            }
                        }


                    }
                    catch (Exception ex)    //error just add blank dir
                    {
                        ExceptionHandler.CaptureException(ex);

                        //KryptonMessageBoxExtended.Show("Error while Filling the Explorer:" + ex.Message);
                    }
                }
            }

            thisComputerNode.Expand();
        }

        private void UpdateListAddCurrent()
        {
            int i = 0;
            int j = 0;

            int icount = 0;
            icount = listView1.Items.Count + 1;

            for (i = 0; i < listView1.Items.Count - 1; i++)
            {
                if (String.Compare(listView1.Items[i].SubItems[1].Text, "Selected") == 0)
                {
                    for (j = listView1.Items.Count - 1; j > i + 1; j--)
                        listView1.Items[j].Remove();
                    break;
                }

            }
        }
        private void UpdateListGoBack()
        {
            if ((listView1.Items.Count > 0) && (String.Compare(listView1.Items[0].SubItems[1].Text, "Selected") == 0))
                return;
            int i = 0;
            for (i = 0; i < listView1.Items.Count; i++)
            {
                if (String.Compare(listView1.Items[i].SubItems[1].Text, "Selected") == 0)
                {
                    if (i != 0)
                    {
                        listView1.Items[i - 1].SubItems[1].Text = "Selected";
                        ktxtPath.Text = listView1.Items[i - 1].Text;
                    }
                }
                if (i != 0)
                {
                    listView1.Items[i].SubItems[1].Text = " -/- ";
                }
            }
        }
        private void UpdateListGoForward()
        {
            if ((listView1.Items.Count > 0) && (String.Compare(listView1.Items[listView1.Items.Count - 1].SubItems[1].Text, "Selected") == 0))
                return;
            int i = 0;
            for (i = listView1.Items.Count - 1; i >= 0; i--)
            {
                if (String.Compare(listView1.Items[i].SubItems[1].Text, "Selected") == 0)
                {
                    if (i != listView1.Items.Count)
                    {
                        listView1.Items[i + 1].SubItems[1].Text = "Selected";
                        ktxtPath.Text = listView1.Items[i + 1].Text;
                    }
                }

                if (i != listView1.Items.Count - 1) listView1.Items[i].SubItems[1].Text = " -/- ";
            }
        }
        private void UpdateList(string f)
        {
            int i = 0;
            ListViewItem listviewitem;      // Used for creating listview items.

            int icount = 0;
            UpdateListAddCurrent();
            icount = listView1.Items.Count + 1;
            try
            {
                if (listView1.Items.Count > 0)
                {
                    if (String.Compare(listView1.Items[listView1.Items.Count - 1].Text, f) == 0)
                    {
                        return;
                    }
                }

                for (i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].SubItems[1].Text = " -/- ";
                }
                listviewitem = new ListViewItem(f);
                listviewitem.SubItems.Add("Selected");
                listviewitem.Tag = f;
                this.listView1.Items.Add(listviewitem);
            }
            catch (Exception e)
            {
                ExceptionHandler.CaptureException(e);
            }
        }

        private void AddFolderNode(string name, string path)
        {

            try
            {
                KryptonTreeNode nodemyC = new KryptonTreeNode();

                nodemyC.Tag = path;
                nodemyC.Text = name;

                nodemyC.ImageIndex = 18;
                nodemyC.SelectedImageIndex = 18;

                rootNode.Nodes.Add(nodemyC);

                try
                {
                    //add dirs under drive
                    if (Directory.Exists(path))
                    {
                        foreach (string dir in Directory.GetDirectories(path))
                        {
                            KryptonTreeNode node = new KryptonTreeNode();
                            node.Tag = dir;
                            node.Text = dir.Substring(dir.LastIndexOf(@"\") + 1);
                            node.ImageIndex = 1;
                            nodemyC.Nodes.Add(node);
                        }
                    }
                }
                catch (Exception ex)    //error just add blank dir
                {
                    ExceptionHandler.CaptureException(ex);

                    //KryptonMessageBoxExtended.Show("Error while Filling the Explorer:" + ex.Message);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.CaptureException(e);
            }
        }

        public void AboutExplorerTree()
        {
            //frmOptions form = new frmOptions(showMyDocuments, showMyFavorites, showMyNetwork, showAddressbar, showToolbar);
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    showMyDocuments = form.myDocument;
            //    showMyNetwork = form.myNetwork;
            //    ShowMyFavorites = form.myFavorite;
            //    ShowAddressbar = form.myAddressbar;
            //    ShowToolbar = form.myToolbar;

            //    btnRefresh_Click(this, null);
            //}
        }

        #region UI Elements
        /// <summary>
        /// Resets the tree location.
        /// </summary>
        private void ResetTreeLocation()
        {
            ktvFileSystem.Dock = DockStyle.Bottom;

            ktvFileSystem.Size = new Size(519, 460);
        }

        /// <summary>
        /// Resets the top panel location.
        /// </summary>
        private void ResetTopPanelLocation() => pnlTop.Size = new Size(519, 82);

        /// <summary>
        /// Relocates the toolbar items.
        /// </summary>
        /// <param name="searchBarLocation">The search bar location.</param>
        /// <param name="goButtonLocation">The go button location.</param>
        /// <param name="topPanelSize">Size of the top panel.</param>
        /// <param name="treeViewSize">Size of the tree view.</param>
        private void RelocateToolbarItems(Point searchBarLocation, Point goButtonLocation, Size topPanelSize, Size treeViewSize)
        {
            pnlTop.Size = topPanelSize;

            ktxtPath.Location = searchBarLocation;

            kbtnGo.Location = goButtonLocation;

            ktvFileSystem.Size = treeViewSize;
        }

        /// <summary>
        /// Sets the toolbar visibility.
        /// </summary>
        /// <param name="visibleValue">if set to <c>true</c> [visible value].</param>
        private void SetToolbarVisibility(bool visibleValue)
        {
            kbtnAdd.Visible = visibleValue;

            kbtnBack.Visible = visibleValue;

            kbtnForward.Visible = visibleValue;

            kbtnUp.Visible = visibleValue;

            kbtnRefresh.Visible = visibleValue;

            ktbnHome.Visible = visibleValue;

            kbtnInfo.Visible = visibleValue;
        }

        private void SetTopVisibility(bool visibleValue) => pnlTop.Visible = visibleValue;

        private void ResizeTopPanel(Size topPanelSize) => pnlTop.Size = topPanelSize;

        private void ResizeTreeView(Size treeViewSize) => ktvFileSystem.Size = treeViewSize;

        /// <summary>
        /// Relocates the button.
        /// </summary>
        /// <param name="targetButton">The target button.</param>
        /// <param name="location">The location.</param>
        private void RelocateButton(KryptonButton targetButton, Point location) => targetButton.Location = location;

        public void ResetKryptonFileSystemUserControlUI()
        {
            #region Toolbar Buttons
            RelocateButton(kbtnAdd, new Point(12, 12));

            RelocateButton(kbtnBack, new Point(51, 12));

            RelocateButton(kbtnForward, new Point(90, 12));

            RelocateButton(kbtnUp, new Point(129, 12));

            RelocateButton(kbtnRefresh, new Point(168, 12));

            RelocateButton(ktbnHome, new Point(207, 12));

            RelocateButton(kbtnInfo, new Point(246, 12));
            #endregion

            #region Top Panel
            ResizeTopPanel(new Size(519, 82));
            #endregion

            #region Search Elements
            ktxtPath.Location = new Point(12, 44);

            RelocateButton(kbtnGo, new Point(483, 44));
            #endregion

            #region Tree View
            ResizeTreeView(new Size(519, 460));
            #endregion
        }
        #endregion

        #endregion

        #region Event Handlers
        private void KryptonFileSystemUserControl_Load(object sender, EventArgs e)
        {
            GetDirectory();

            if (Directory.Exists(SelectedPath))
            {
                SetCurrentPath(SelectedPath);
            }
            else
            {
                SetCurrentPath("home");
            }

            kbtnGo_Click(this, e);

            RefreshView();
        }

        private void kbtnInfo_Click(object sender, EventArgs e)
        {
            AboutExplorerTree();
        }

        private void ktvFileSystem_AfterSelect(object sender, TreeViewEventArgs e)
        {
            KryptonTreeNode node;

            node = (KryptonTreeNode)e.Node;

            try
            {
                if ((String.Compare(node.Text, "My Computer") == 0) || (String.Compare(node.Text, "My Network Places") == 0) || (String.Compare(node.Text, "Entire Network") == 0))
                {
                }
                else
                {
                    ktxtPath.Text = node.Tag.ToString();
                }
            }
            catch { }
        }

        private void ktvFileSystem_DoubleClick(object sender, EventArgs e)
        {
            KryptonTreeNode node;

            node = (KryptonTreeNode)ktvFileSystem.SelectedNode;

            if (!ktvFileSystem.SelectedNode.IsExpanded)
            {
                ktvFileSystem.SelectedNode.Collapse();
            }
            else
            {
                ExploreTreeNode(node);
            }
        }

        private void kbtnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            RefreshView();

            try
            {
                RefreshFolders();
            }
            catch (Exception exc)
            {
                ExceptionHandler.CaptureException(exc);
            }
            finally
            {
                SetCurrentPath("Home");

                Cursor.Current = Cursors.Default;

                ExploreThisPC();
            }
        }

        private void kbtnGo_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ExploreThisPC();
                string myString = "";
                int h = 1;
                myString = ktxtPath.Text.ToLower();
                //if (String.Compare(myString.Substring(myString.Length-1,1),@"\")==0)
                //{
                //	myString = myString.Substring(0,myString.Length-1);
                //	txtPath.Text = myString	;

                //}
                KryptonTreeNode tn = thisComputerNode;

            StartAgain:

                do
                {
                    //Strom = (tvwMain.GetNodeCount(true)).ToString() ;	

                    foreach (KryptonTreeNode t in tn.Nodes)
                    {
                        string mypath = t.Tag.ToString();
                        //mypath =  mypath.Replace("Desktop\\","") ;
                        //mypath =  mypath.Replace("My Computer\\","") ;
                        //mypath =  mypath.Replace(@"\\",@"\") ;

                        //mypath =  mypath.Replace("My Documents\\",Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\") ;
                        mypath = mypath.ToLower();
                        string mypathf = mypath;
                        if (!mypath.EndsWith(@"\"))
                        {
                            if (myString.Length > mypathf.Length) mypathf = mypath + @"\";
                        }

                        if (myString.StartsWith(mypathf))
                        {
                            t.TreeView.Focus();
                            t.TreeView.SelectedNode = t;
                            t.EnsureVisible();
                            t.Expand();
                            if (t.Nodes.Count >= 1)
                            {
                                t.Expand();
                                tn = t;
                            }
                            else
                            {
                                if (String.Compare(myString, mypath) == 0)
                                {
                                    h = -1;
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            if (mypathf.StartsWith(myString))
                            {
                                h = -1;
                                break;
                            }
                            else
                            {
                                goto StartAgain;
                                //return;
                            }
                        }
                    }

                    try
                    {
                        tn = (KryptonTreeNode)tn.NextNode;
                    }
                    catch (Exception)
                    { }

                } while (h >= 0);

            }
            catch (Exception e1)
            {
                ExceptionHandler.CaptureException(e1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ktbnHome_Click(object sender, EventArgs e)
        {
            SetCurrentPath("home");

            ExploreThisPC();

            kbtnGo_Click(sender, e);
        }

        private void kbtnForward_Click(object sender, EventArgs e)
        {
            GoFlag = true;
            string cpath = ktxtPath.Text;
            UpdateListGoForward();

            if (String.Compare(cpath, ktxtPath.Text) == 0)
            { }
            else
            {
                kbtnGo_Click(sender, e);
            }
            GoFlag = false;
        }

        private void kbtnBack_Click(object sender, EventArgs e)
        {
            GoFlag = true;
            string cpath = ktxtPath.Text;
            UpdateListGoBack();

            if (String.Compare(cpath, ktxtPath.Text) == 0)
            { }
            else
            {
                kbtnGo_Click(sender, e);
            }
            GoFlag = false;
        }

        private void ktvFileSystem_AfterExpand(object sender, TreeViewEventArgs e)
        {
            string[] drives = Environment.GetLogicalDrives();

            string dir2 = "";

            Cursor.Current = Cursors.WaitCursor;

            KryptonTreeNode node, nodeNetwork, nodeMN, nodeThisPC, nodeNetworkNode, nodeDrive;

            nodeThisPC = (KryptonTreeNode)e.Node;

            node = (KryptonTreeNode)e.Node;

            if (node.Text.IndexOf(":", 1) > 0)
            {
                ExploreTreeNode(node);
            }
            else
            {//(String.Compare(node.Text ,"My Documents")==0) || (String.Compare(node.Text,"Desktop")==0) || 

                if ((String.Compare(node.Text, "Desktop") == 0) || (String.Compare(node.Text, "Microsoft Windows Network") == 0) || (String.Compare(node.Text, "My Computer") == 0) || (String.Compare(node.Text, "My Network Places") == 0) || (String.Compare(node.Text, "Entire Network") == 0) || ((node.Parent != null) && (String.Compare(node.Parent.Text, "Microsoft Windows Network") == 0)))
                {
                    if ((String.Compare(node.Text, "My Computer") == 0) && (nodeThisPC.GetNodeCount(true) < 2))
                    ///////////
                    //add each drive and files and dirs
                    {
                        nodeThisPC.FirstNode.Remove();

                        foreach (string drive in drives)
                        {

                            nodeDrive = new KryptonTreeNode();
                            nodeDrive.Tag = drive;

                            nodeDrive.Text = drive;

                            //Determine icon to display by drive
                            switch (NativeMethods.GetDriveType(drive))
                            {
                                case 2:
                                    nodeDrive.ImageIndex = 17;
                                    nodeDrive.SelectedImageIndex = 17;
                                    break;
                                case 3:
                                    nodeDrive.ImageIndex = 0;
                                    nodeDrive.SelectedImageIndex = 0;
                                    break;
                                case 4:
                                    nodeDrive.ImageIndex = 8;
                                    nodeDrive.SelectedImageIndex = 8;
                                    break;
                                case 5:
                                    nodeDrive.ImageIndex = 7;
                                    nodeDrive.SelectedImageIndex = 7;
                                    break;
                                default:
                                    nodeDrive.ImageIndex = 0;
                                    nodeDrive.SelectedImageIndex = 0;
                                    break;
                            }

                            nodeThisPC.Nodes.Add(nodeDrive);
                            nodeDrive.EnsureVisible();
                            ktvFileSystem.Refresh();
                            try
                            {
                                //add dirs under drive
                                if (Directory.Exists(drive))
                                {
                                    foreach (string dir in Directory.GetDirectories(drive))
                                    {
                                        dir2 = dir;
                                        node = new KryptonTreeNode();
                                        node.Tag = dir;
                                        node.Text = dir.Substring(dir.LastIndexOf(@"\") + 1);
                                        node.ImageIndex = 1;
                                        nodeDrive.Nodes.Add(node);
                                    }
                                }

                                //fill those dirs
                                //					foreach(TreeNode curNode in 
                                //						tvwMainode.Nodes[tvwMainode.Nodes.Count - 1].Nodes)
                                //					{
                                //						FillFilesandDirs(curNode);
                                //					}
                            }
                            catch (Exception)   //error just add blank dir
                            {
                                // KryptonMessageBoxExtended.Show ("Error while Filling the Explorer:" + ex.Message );
                                //					node = new TreeNode();
                                //					node.Tag = dir2;
                                //					node.Text = dir2.Substring(dir2.LastIndexOf(@"\") + 1);
                                //					node.ImageIndex = 1;
                                //					tvwMainode.Nodes.Add(node);
                            }
                            nodeThisPC.Expand();
                        }

                    }
                    if ((String.Compare(node.Text, "Entire Network") == 0))
                    {
                        if (node.FirstNode.Text == "Network Node")
                        {
                            node.FirstNode.Remove();
                            //NETRESOURCE netRoot = new NETRESOURCE();

                            ServerEnum servers = new ServerEnum(ResourceScope.RESOURCE_GLOBALNET, ResourceType.RESOURCETYPE_DISK, ResourceUsage.RESOURCEUSAGE_ALL, ResourceDisplayType.RESOURCEDISPLAYTYPE_NETWORK, "");

                            foreach (string s1 in servers)
                            {
                                string s2 = "";
                                s2 = s1.Substring(0, s1.IndexOf("|", 1));

                                if (s1.IndexOf("NETWORK", 1) > 0)
                                {
                                    nodeNetwork = new KryptonTreeNode();
                                    nodeNetwork.Tag = s2;
                                    nodeNetwork.Text = s2;//dir.Substring(dir.LastIndexOf(@"\") + 1);
                                    nodeNetwork.ImageIndex = 15;
                                    nodeNetwork.SelectedImageIndex = 15;
                                    node.Nodes.Add(nodeNetwork);
                                }
                                else
                                {
                                    KryptonTreeNode nodemNc;
                                    nodeMN = new KryptonTreeNode();
                                    nodeMN.Tag = s2;//"my Node";
                                    nodeMN.Text = s2;//"my Node";//dir.Substring(dir.LastIndexOf(@"\") + 1);
                                    nodeMN.ImageIndex = 16;
                                    nodeMN.SelectedImageIndex = 16;
                                    node.LastNode.Nodes.Add(nodeMN);

                                    nodemNc = new KryptonTreeNode();
                                    nodemNc.Tag = "my netNode";
                                    nodemNc.Text = "my netNode";//dir.Substring(dir.LastIndexOf(@"\") + 1);
                                    nodemNc.ImageIndex = 12;
                                    nodemNc.SelectedImageIndex = 12;
                                    nodeMN.Nodes.Add(nodemNc);
                                }
                            }
                        }
                    }
                    if ((node.Parent != null) && (String.Compare(node.Parent.Text, "Microsoft Windows Network") == 0))

                    {
                        if (node.FirstNode.Text == "my netNode")
                        {
                            node.FirstNode.Remove();

                            string pS = node.Text;

                            //NETRESOURCE netRoot = new NETRESOURCE();

                            ServerEnum servers = new ServerEnum(ResourceScope.RESOURCE_GLOBALNET,
                                ResourceType.RESOURCETYPE_DISK,
                                ResourceUsage.RESOURCEUSAGE_ALL,
                                ResourceDisplayType.RESOURCEDISPLAYTYPE_SERVER, pS);


                            foreach (string s1 in servers)
                            {
                                string s2 = "";


                                if ((s1.Length < 6) || (String.Compare(s1.Substring(s1.Length - 6, 6), "-share") != 0))
                                {
                                    s2 = s1;//.Substring(s1.IndexOf("\\",2));
                                    nodeNetworkNode = new KryptonTreeNode();
                                    nodeNetworkNode.Tag = s2;
                                    nodeNetworkNode.Text = s2.Substring(2);
                                    nodeNetworkNode.ImageIndex = 12;
                                    nodeNetworkNode.SelectedImageIndex = 12;
                                    node.Nodes.Add(nodeNetworkNode);
                                    foreach (string s1node in servers)
                                    {
                                        if (s1node.Length > 6)
                                        {
                                            if (String.Compare(s1node.Substring(s1node.Length - 6, 6), "-share") == 0)
                                            {
                                                if (s2.Length <= s1node.Length)
                                                {
                                                    try
                                                    {
                                                        if (String.Compare(s1node.Substring(0, s2.Length + 1), s2 + @"\") == 0)
                                                        {
                                                            nodeNetworkNode = new KryptonTreeNode();
                                                            nodeNetworkNode.Tag = s1node.Substring(0, s1node.Length - 6);
                                                            nodeNetworkNode.Text = s1node.Substring(s2.Length + 1, s1node.Length - s2.Length - 7);
                                                            nodeNetworkNode.ImageIndex = 28;
                                                            nodeNetworkNode.SelectedImageIndex = 28;
                                                            nodeNetworkNode.Nodes.Add(nodeNetworkNode);
                                                        }
                                                    }
                                                    catch (Exception)
                                                    { }
                                                }
                                            }
                                        }

                                    }
                                }

                            }
                        }
                    }
                }
                else
                {
                    ExploreTreeNode(node);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void ktvFileSystem_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateList(ktxtPath.Text);

            if (ktvFileSystem.SelectedNode != null)
            {
                if ((ktvFileSystem.SelectedNode.ImageIndex == 18) && (e.Button == MouseButtons.Right))
                {
                    cmsShortcuts.Show(ktvFileSystem, new Point(e.X, e.Y));
                }
            }
        }

        private void kbtnUp_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo MYINFO = new DirectoryInfo(ktxtPath.Text);

                if (MYINFO.Parent.Exists)
                {
                    ktxtPath.Text = MYINFO.Parent.FullName;
                }

                UpdateList(ktxtPath.Text);

                kbtnGo_Click(sender, e);
            }
            catch (Exception exc)
            {
                ExceptionHandler.CaptureException(exc);
            }
        }

        private void kbtnAdd_Click(object sender, EventArgs e)
        {
            string myname = "";
            string mypath = "";


            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Add Folder in Explorer Tree";
            dialog.ShowNewFolderButton = true;
            dialog.SelectedPath = ktxtPath.Text;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                mypath = dialog.SelectedPath;
                myname = mypath.Substring(mypath.LastIndexOf("\\") + 1);

                AddFolderNode(myname, mypath);

            }
        }

        private void removeShortcutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ktvFileSystem.SelectedNode.ImageIndex == 18) ktvFileSystem.SelectedNode.Remove();
        }

        private void ktxtPath_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(ktxtPath.Text))
                {
                    SelectedPath = ktxtPath.Text;
                    PathChangedEvent(this, EventArgs.Empty);
                }
            }
            catch (Exception)
            { }
        }

        private void ktxtPath_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                kbtnGo_Click(sender, e);

                ktxtPath.Focus();
            }
        }
        #endregion

    }
}