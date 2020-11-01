using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonFileFolderBrowser : UserControl
    {
        private KryptonComboBox kcbDriveList;
        private KryptonTreeView ktvFolders;
        private Panel panel1;
        private Panel panel3;
        private KryptonListBox klbFiles;
        private Panel panel2;

        private void InitializeComponent()
        {
            this.kcbDriveList = new Krypton.Toolkit.KryptonComboBox();
            this.ktvFolders = new Krypton.Toolkit.KryptonTreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.klbFiles = new Krypton.Toolkit.KryptonListBox();
            ((System.ComponentModel.ISupportInitialize)(this.kcbDriveList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // kcbDriveList
            // 
            this.kcbDriveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kcbDriveList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcbDriveList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcbDriveList.DropDownWidth = 200;
            this.kcbDriveList.IntegralHeight = false;
            this.kcbDriveList.Location = new System.Drawing.Point(0, 0);
            this.kcbDriveList.Name = "kcbDriveList";
            this.kcbDriveList.Size = new System.Drawing.Size(200, 21);
            this.kcbDriveList.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcbDriveList.TabIndex = 0;
            this.kcbDriveList.SelectedIndexChanged += new System.EventHandler(this.kcbDriveList_SelectedIndexChanged);
            // 
            // ktvFolders
            // 
            this.ktvFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktvFolders.Location = new System.Drawing.Point(0, 0);
            this.ktvFolders.Name = "ktvFolders";
            this.ktvFolders.Size = new System.Drawing.Size(200, 382);
            this.ktvFolders.TabIndex = 1;
            this.ktvFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ktvFolders_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 403);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.kcbDriveList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 21);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ktvFolders);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 382);
            this.panel3.TabIndex = 3;
            // 
            // klbFiles
            // 
            this.klbFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klbFiles.Location = new System.Drawing.Point(200, 0);
            this.klbFiles.Name = "klbFiles";
            this.klbFiles.Size = new System.Drawing.Size(525, 403);
            this.klbFiles.TabIndex = 3;
            // 
            // KryptonFileFolderBrowser
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.klbFiles);
            this.Controls.Add(this.panel1);
            this.Name = "KryptonFileFolderBrowser";
            this.Size = new System.Drawing.Size(725, 403);
            ((System.ComponentModel.ISupportInitialize)(this.kcbDriveList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #region Constructor
        public KryptonFileFolderBrowser()
        {
            InitializeComponent();

            kcbDriveList.DataSource = Environment.GetLogicalDrives();
        }
        #endregion

        private void ktvFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void kcbDriveList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(kcbDriveList.Text);

            BuildTree(directoryInfo, ktvFolders.Nodes);
        }

        private void BuildTree(DirectoryInfo di, TreeNodeCollection col)
        {
            KryptonTreeNode node = (KryptonTreeNode)col.Add(di.Name);

            foreach (FileInfo file in di.GetFiles())
            {
                node.Nodes.Add(file.FullName, file.Name);
            }

            foreach (DirectoryInfo directoryInfo in di.GetDirectories())
            {
                BuildTree(directoryInfo, node.Nodes);
            }
        }
    }
}