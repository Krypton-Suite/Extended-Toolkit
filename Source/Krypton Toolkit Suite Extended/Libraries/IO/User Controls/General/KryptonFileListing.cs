using System;
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ktxtDirectory = new Krypton.Toolkit.KryptonTextBox();
            this.kbtnBrowse = new Krypton.Toolkit.KryptonButton();
            this.klbFileListing = new Krypton.Toolkit.KryptonListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.ktxtDirectory.Size = new System.Drawing.Size(224, 20);
            this.ktxtDirectory.TabIndex = 0;
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
            // klbFileListing
            // 
            this.klbFileListing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klbFileListing.Location = new System.Drawing.Point(0, 0);
            this.klbFileListing.Name = "klbFileListing";
            this.klbFileListing.Size = new System.Drawing.Size(268, 363);
            this.klbFileListing.TabIndex = 0;
            // 
            // KryptonFileListing
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "KryptonFileListing";
            this.Size = new System.Drawing.Size(268, 387);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private string _promptText;
        #endregion

        #region Properties
        public string PromptText { get => _promptText; set { _promptText = value; Invalidate(); } }

        public KryptonButton BrowseButton { get => kbtnBrowse; }

        public KryptonTextBox DirectoryPath { get => ktxtDirectory; }

        public KryptonListBox FileListing { get => klbFileListing; }
        #endregion

        #region Constructor
        public KryptonFileListing()
        {
            InitializeComponent();
        }
        #endregion

        private void kbtnBrowse_Click(object sender, EventArgs e)
        {

        }
    }
}