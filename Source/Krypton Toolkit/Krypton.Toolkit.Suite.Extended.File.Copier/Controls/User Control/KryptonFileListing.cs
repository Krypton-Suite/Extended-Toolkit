#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.File.Copier
{
    [ToolboxItem(false)]
    public class KryptonFileListing : UserControl
    {
        #region Design Code
        private Panel panel1;
        private Panel panel4;
        private KryptonTextBox ktxtDirectory;
        private Panel panel3;
        private KryptonButton kbtnBrowse;
        private Panel panel2;
        private ContextMenuStrip ctxActions;
        private IContainer components;
        private ToolStripMenuItem openInExplorerToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem renameFileToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem deleteFileToolStripMenuItem;
        private KryptonListBox klbFileListing;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ktxtDirectory = new Krypton.Toolkit.KryptonTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.kbtnBrowse = new Krypton.Toolkit.KryptonButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.klbFileListing = new Krypton.Toolkit.KryptonListBox();
            this.ctxActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.renameFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ctxActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 24);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.ktxtDirectory);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(224, 24);
            this.panel4.TabIndex = 2;
            // 
            // ktxtDirectory
            // 
            this.ktxtDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktxtDirectory.Hint = "Please enter or browse to a directory...";
            this.ktxtDirectory.Location = new System.Drawing.Point(0, 0);
            this.ktxtDirectory.Name = "ktxtDirectory";
            this.ktxtDirectory.Size = new System.Drawing.Size(224, 23);
            this.ktxtDirectory.TabIndex = 0;
            this.ktxtDirectory.TextChanged += new System.EventHandler(this.ktxtDirectory_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.kbtnBrowse);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(224, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(44, 24);
            this.panel3.TabIndex = 1;
            // 
            // kbtnBrowse
            // 
            this.kbtnBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnBrowse.Location = new System.Drawing.Point(0, 0);
            this.kbtnBrowse.Name = "kbtnBrowse";
            this.kbtnBrowse.Size = new System.Drawing.Size(44, 24);
            this.kbtnBrowse.TabIndex = 0;
            this.kbtnBrowse.Values.Text = "&...";
            this.kbtnBrowse.Click += new System.EventHandler(this.kbtnBrowse_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.klbFileListing);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 363);
            this.panel2.TabIndex = 1;
            // 
            // klbFileListing
            // 
            this.klbFileListing.ContextMenuStrip = this.ctxActions;
            this.klbFileListing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klbFileListing.Location = new System.Drawing.Point(0, 0);
            this.klbFileListing.Name = "klbFileListing";
            this.klbFileListing.Size = new System.Drawing.Size(268, 363);
            this.klbFileListing.TabIndex = 0;
            this.klbFileListing.SelectedIndexChanged += new System.EventHandler(this.klbFileListing_SelectedIndexChanged);
            // 
            // ctxActions
            // 
            this.ctxActions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ctxActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openInExplorerToolStripMenuItem,
            this.toolStripMenuItem1,
            this.renameFileToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteFileToolStripMenuItem});
            this.ctxActions.Name = "ctxActions";
            this.ctxActions.Size = new System.Drawing.Size(181, 104);
            // 
            // openInExplorerToolStripMenuItem
            // 
            this.openInExplorerToolStripMenuItem.Name = "openInExplorerToolStripMenuItem";
            this.openInExplorerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openInExplorerToolStripMenuItem.Text = "Open in &Explorer";
            this.openInExplorerToolStripMenuItem.Click += new System.EventHandler(this.openInExplorerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // renameFileToolStripMenuItem
            // 
            this.renameFileToolStripMenuItem.Name = "renameFileToolStripMenuItem";
            this.renameFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.renameFileToolStripMenuItem.Text = "&Rename File...";
            this.renameFileToolStripMenuItem.Click += new System.EventHandler(this.renameFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // deleteFileToolStripMenuItem
            // 
            this.deleteFileToolStripMenuItem.Name = "deleteFileToolStripMenuItem";
            this.deleteFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteFileToolStripMenuItem.Text = "Delete &File...";
            this.deleteFileToolStripMenuItem.Click += new System.EventHandler(this.deleteFileToolStripMenuItem_Click);
            // 
            // KryptonFileListing
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "KryptonFileListing";
            this.Size = new System.Drawing.Size(268, 387);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ctxActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private string _promptText, _openFileDialogTitle;

        private List<string> _directoryContents = new List<string>();

        private object _fileListItem;
        #endregion

        #region Properties
        [DefaultValue("Please enter or browse to a directory...")]
        public string PromptText { get => _promptText; set { _promptText = value; Invalidate(); } }

        [DefaultValue("Browse to a directory:")]
        public string OpenFileDialogTitle { get => _openFileDialogTitle; set => _openFileDialogTitle = value; }

        public KryptonButton BrowseButton { get => kbtnBrowse; }

        public KryptonTextBox DirectoryPath { get => ktxtDirectory; }

        public KryptonListBox FileListing { get => klbFileListing; }

        public List<string> DirectoryContents { get => _directoryContents; private set => _directoryContents = value; }

        public object FileItem { get => _fileListItem; private set => _fileListItem = value; }
        #endregion

        #region Custom Events
        public delegate void DirectoryPathChangedEventHandler(object sender, DirectoryPathChangedEventArgs e);

        public delegate void FileGathererEventHandler(object sender, FileGathererEventArgs e);

        public event DirectoryPathChangedEventHandler DirectoryPathChanged;

        public event FileGathererEventHandler GatherFiles;

        /// <summary>Called when [directory path changed].</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DirectoryPathChangedEventArgs" /> instance containing the event data.</param>
        protected virtual void OnDirectoryPathChanged(object sender, DirectoryPathChangedEventArgs e) => DirectoryPathChanged?.Invoke(sender, e);

        /// <summary>Called when [gather files].</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="FileGathererEventArgs" /> instance containing the event data.</param>
        protected virtual void OnGatherFiles(object sender, FileGathererEventArgs e) => GatherFiles?.Invoke(sender, e);
        #endregion

        #region Constructor
        public KryptonFileListing()
        {
            InitializeComponent();
        }
        #endregion       

        #region Methods
        /// <summary>Populates the ListBox.</summary>
        /// <param name="container">The container.</param>
        /// <param name="directory">The directory.</param>
        /// <param name="fileType">Type of the file.</param>
        /// <param name="useFullPath">if set to <c>true</c> [use full path].</param>
        /// <param name="propagateList">if set to <c>true</c> [propagate list].</param>
        /// <param name="searchOption">The search option.</param>
        private void PopulateListBox(KryptonListBox container, string directory, string fileType = "*.*", bool useFullPath = false, bool propagateList = true, SearchOption searchOption = SearchOption.AllDirectories)
        {
            // Get the directory contents
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

            // Populate file list
            FileInfo[] files = directoryInfo.GetFiles();

            // Create a temporary list
            List<string> temporaryList = new List<string>();

            int index1 = 0, index2 = 0, numberOfFiles = Directory.GetFiles(directory, fileType, searchOption).Count(), numberOfDirectories = Directory.GetDirectories(directory, "*", searchOption).Count(), totalNumberOfContents;

            totalNumberOfContents = numberOfDirectories + numberOfFiles;

            foreach (FileInfo file in files)
            {
                container.Items.Add(Path.GetFullPath(file.Name));

                index1++;
            }

            if (propagateList)
            {
                foreach (string item in container.Items)
                {
                    temporaryList.Add(item);

                    index2++;
                }

                FileGathererEventArgs fileGatherer = new FileGathererEventArgs(temporaryList);

                OnGatherFiles(this, fileGatherer);
            }
        }

        private void OpenInExplorer(string item)
        {
            try
            {
                Process.Start("explorer.exe", item);
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(ex);
            }
        }

        private void PropagateFileList(List<string> directoryContents, string directory, string fileType = null)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

            FileInfo[] files = directoryInfo.GetFiles("*.*");

            foreach (FileInfo file in files)
            {
                directoryContents.Add(Path.GetFullPath(file.Name));
            }
        }
        #endregion

        private void ktxtDirectory_TextChanged(object sender, EventArgs e)
        {

        }

        private void kbtnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                CommonOpenFileDialog cofd = new CommonOpenFileDialog();

                cofd.IsFolderPicker = true;

                cofd.Title = OpenFileDialogTitle;

                if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    ktxtDirectory.Text = Path.GetFullPath(cofd.FileName);

                    PopulateListBox(FileListing, ktxtDirectory.Text);

                    DirectoryPathChangedEventArgs directoryPathChanged = new DirectoryPathChangedEventArgs(Path.GetFullPath(cofd.FileName));

                    OnDirectoryPathChanged(this, directoryPathChanged);
                }
            }
            catch (Exception exc)
            {
                ExceptionCapture.CaptureException(exc);
            }
        }

        private void klbFileListing_SelectedIndexChanged(object sender, EventArgs e) => FileItem = klbFileListing.SelectedItem;

        private void openInExplorerToolStripMenuItem_Click(object sender, EventArgs e) => OpenInExplorer(klbFileListing.SelectedItem.ToString());

        private void renameFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}