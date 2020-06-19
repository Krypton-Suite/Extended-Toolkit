using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.IO
{
    public class KryptonFileListing : UserControl
    {
        #region Design Code
        private Panel panel1;
        private Panel panel4;
        private KryptonTextBox ktxtDirectory;
        private Panel panel3;
        private KryptonButton kbtnBrowse;
        private Panel panel2;
        private KryptonListBox klbFileListing;

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ktxtDirectory = new Krypton.Toolkit.KryptonTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.kbtnBrowse = new Krypton.Toolkit.KryptonButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.klbFileListing = new Krypton.Toolkit.KryptonListBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.klbFileListing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klbFileListing.Location = new System.Drawing.Point(0, 0);
            this.klbFileListing.Name = "klbFileListing";
            this.klbFileListing.Size = new System.Drawing.Size(268, 363);
            this.klbFileListing.TabIndex = 0;
            this.klbFileListing.SelectedIndexChanged += new System.EventHandler(this.klbFileListing_SelectedIndexChanged);
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

        #region Constructor
        public KryptonFileListing()
        {
            InitializeComponent();
        }
        #endregion

        private void kbtnBrowse_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog ofd = new CommonOpenFileDialog();

            ofd.IsFolderPicker = true;

            ofd.Title = OpenFileDialogTitle;

            if (ofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                ktxtDirectory.Text = Path.GetFullPath(ofd.FileName);

                PopulateListBox(FileListing, ktxtDirectory.Text);
            }
        }

        private void ktxtDirectory_TextChanged(object sender, EventArgs e)
        {

        }

        private void klbFileListing_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileItem = klbFileListing.SelectedItem;
        }

        #region Methods
        private void PopulateListBox(KryptonListBox container, string directory, string fileType = null, bool useFullPath = false)
        {
            // Get the directory contents
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

            // Populate file list
            FileInfo[] files = directoryInfo.GetFiles();

            foreach (FileInfo file in files)
            {
                container.Items.Add(Path.GetFullPath(file.Name));
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
    }
}