using System;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class KryptonFolderBrowserDialog : KryptonForm
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnNewFolder;
        private KryptonButton kbtnCancel;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonLabel kryptonLabel1;
        private KryptonTreeView kryptonTreeView1;
        private KryptonTextBox kryptonTextBox1;
        private KryptonButton kbtnOk;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnNewFolder = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonTreeView1 = new Krypton.Toolkit.KryptonTreeView();
            this.kryptonTextBox1 = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnNewFolder);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 394);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(405, 50);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // kbtnNewFolder
            // 
            this.kbtnNewFolder.Enabled = false;
            this.kbtnNewFolder.Location = new System.Drawing.Point(12, 11);
            this.kbtnNewFolder.Name = "kbtnNewFolder";
            this.kbtnNewFolder.Size = new System.Drawing.Size(82, 25);
            this.kbtnNewFolder.TabIndex = 2;
            this.kbtnNewFolder.Values.Text = "&New Folder";
            this.kbtnNewFolder.Visible = false;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(303, 11);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 1;
            this.kbtnCancel.Values.Text = "&Cancel";
            // 
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(207, 11);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 0;
            this.kbtnOk.Values.Text = "&Ok";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 2);
            this.panel1.TabIndex = 3;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Controls.Add(this.kryptonTreeView1);
            this.kryptonPanel2.Controls.Add(this.kryptonTextBox1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(405, 392);
            this.kryptonPanel2.TabIndex = 4;
            // 
            // kryptonTreeView1
            // 
            this.kryptonTreeView1.Location = new System.Drawing.Point(12, 35);
            this.kryptonTreeView1.Name = "kryptonTreeView1";
            this.kryptonTreeView1.Size = new System.Drawing.Size(381, 322);
            this.kryptonTreeView1.TabIndex = 5;
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(12, 363);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(381, 23);
            this.kryptonTextBox1.TabIndex = 0;
            this.kryptonTextBox1.Text = "kryptonTextBox1";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(88, 20);
            this.kryptonLabel1.TabIndex = 5;
            this.kryptonLabel1.Values.Text = "kryptonLabel1";
            // 
            // KryptonFolderBrowserDialog
            // 
            this.ClientSize = new System.Drawing.Size(405, 444);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonFolderBrowserDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Browse For Folder";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _showNewFolderButton;

        private Environment.SpecialFolder _rootDirectory;

        private string _descriptionText, _selectedPath;
        #endregion

        #region Properties
        public bool ShowNewFolderButton { get => _showNewFolderButton; set => _showNewFolderButton = value; }

        public Environment.SpecialFolder RootDirectory { get => _rootDirectory; set => _rootDirectory = value; }
        #endregion

        #region Constructor
        public KryptonFolderBrowserDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Custom Event
        //public new event EventHandler RequestHelp { add => base.HelpRequested = value; }
        #endregion
    }
}