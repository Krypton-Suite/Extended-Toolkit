using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.IO
{
    /// <summary>
    /// A file explorer see: https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/creating-an-explorer-style-interface-with-the-listview-and-treeview
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class KryptonExplorer : UserControl
    {
        #region Designer Code
        private KryptonSplitContainer kryptonSplitContainer1;
        private KryptonTreeView ktvExplorer;
        private ImageList ilExplorer;
        private ColumnHeader colName;
        private ColumnHeader colType;
        private ColumnHeader colLastModified;
        private System.ComponentModel.IContainer components;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonSplitContainer1 = new KryptonSplitContainer();
            this.ktvExplorer = new KryptonTreeView();
            this.ilExplorer = new System.Windows.Forms.ImageList(this.components);
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.ktvExplorer);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(905, 504);
            this.kryptonSplitContainer1.SplitterDistance = 301;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // ktvExplorer
            // 
            this.ktvExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktvExplorer.Location = new System.Drawing.Point(0, 0);
            this.ktvExplorer.Name = "ktvExplorer";
            this.ktvExplorer.Size = new System.Drawing.Size(301, 504);
            this.ktvExplorer.StateImageList = this.ilExplorer;
            this.ktvExplorer.TabIndex = 0;
            this.ktvExplorer.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ktvExplorer_NodeMouseClick);
            this.ktvExplorer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ktvExplorer_MouseClick);
            // 
            // ilExplorer
            // 
            this.ilExplorer.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilExplorer.ImageSize = new System.Drawing.Size(16, 16);
            this.ilExplorer.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 225;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 181;
            // 
            // colLastModified
            // 
            this.colLastModified.Text = "Last Modified";
            this.colLastModified.Width = 212;
            // 
            // KryptonExplorer
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "KryptonExplorer";
            this.Size = new System.Drawing.Size(905, 504);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Color _alternateRowColour, _gradientStartColour, _gradientMiddleColour, _gradientEndColour;
        #endregion

        #region Properties
        public Color AlternateRowColour { get => _alternateRowColour; set { _alternateRowColour = value; Invalidate(); } }

        public Color GradientStartColour { get => _gradientStartColour; set { _gradientStartColour = value; Invalidate(); } }

        public Color GradientMiddleColour { get => _gradientMiddleColour; set { _gradientMiddleColour = value; Invalidate(); } }

        public Color GradientEndColour { get => _gradientEndColour; set { _gradientEndColour = value; Invalidate(); } }
        #endregion

        public KryptonExplorer()
        {
            InitializeComponent();

            //AlternateRowColour = klvFileList.AlternateRowColour;

            //GradientEndColour = klvFileList.GradientEndColour;

            //GradientMiddleColour = klvFileList.GradientMiddleColour;

            //GradientStartColour = klvFileList.GradientStartColour;
        }

        private void ktvExplorer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;

            DirectoryInfo nodeDirectoryInfo = (DirectoryInfo)newSelected.Tag;

            ListViewItem.ListViewSubItem[] subItems;

            ListViewItem item = null;

            foreach (DirectoryInfo directory in nodeDirectoryInfo.GetDirectories())
            {
                item = new ListViewItem(directory.Name, 0);

                subItems = new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(item, "Directory"), new ListViewItem.ListViewSubItem(item, directory.LastAccessTime.ToShortDateString()) };

                item.SubItems.AddRange(subItems);
            }

            foreach (FileInfo file in nodeDirectoryInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);

                subItems = new ListViewItem.ListViewSubItem[] { new ListViewItem.ListViewSubItem(item, "File"), new ListViewItem.ListViewSubItem(item, file.LastAccessTime.ToShortDateString()) };

                item.SubItems.AddRange(subItems);
            }

            //klvFileList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public void PopulateTreeView(string filePath = "")
        {
            KryptonTreeNode rootNode;

            DirectoryInfo directoryInfo = new DirectoryInfo(@"../..");

            if (directoryInfo.Exists)
            {
                rootNode = new KryptonTreeNode(directoryInfo.Name);

                rootNode.Tag = directoryInfo;

                GetDirectories(directoryInfo.GetDirectories(), rootNode);

                ktvExplorer.Nodes.Add(rootNode);
            }
        }

        private void GetDirectories(DirectoryInfo[] subDirectories, KryptonTreeNode nodeToAddTo)
        {
            KryptonTreeNode aNode;

            DirectoryInfo[] subSubDirectories;

            foreach (DirectoryInfo item in subDirectories)
            {
                aNode = new KryptonTreeNode(item.Name, 0, 0);

                aNode.Tag = item;

                aNode.ImageKey = "folder";

                subSubDirectories = item.GetDirectories();

                if (subSubDirectories.Length != 0)
                {
                    GetDirectories(subSubDirectories, aNode);
                }

                nodeToAddTo.Nodes.Add(aNode);
            }
        }

        private void ktvExplorer_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}