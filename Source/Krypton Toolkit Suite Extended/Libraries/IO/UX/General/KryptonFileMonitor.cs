using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.IO
{
    public class KryptonFileMonitor : KryptonForm, ICopyFileDetails
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private System.Windows.Forms.ProgressBar pbTotalFiles;
        private KryptonLabel klblTotalFiles;
        private System.Windows.Forms.ProgressBar pbCurrentFile;
        private KryptonLabel klblCurrentFile;
        private KryptonButton kdbtnCancel;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kdbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.pbCurrentFile = new System.Windows.Forms.ProgressBar();
            this.klblCurrentFile = new Krypton.Toolkit.KryptonLabel();
            this.pbTotalFiles = new System.Windows.Forms.ProgressBar();
            this.klblTotalFiles = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kdbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 159);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(675, 43);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // kdbtnCancel
            // 
            this.kdbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kdbtnCancel.Location = new System.Drawing.Point(292, 6);
            this.kdbtnCancel.Name = "kdbtnCancel";
            this.kdbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kdbtnCancel.TabIndex = 3;
            this.kdbtnCancel.Values.Text = "C&ancel";
            this.kdbtnCancel.Click += new System.EventHandler(this.kdbtnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 3);
            this.panel1.TabIndex = 4;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.pbCurrentFile);
            this.kryptonPanel2.Controls.Add(this.klblCurrentFile);
            this.kryptonPanel2.Controls.Add(this.pbTotalFiles);
            this.kryptonPanel2.Controls.Add(this.klblTotalFiles);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(675, 156);
            this.kryptonPanel2.TabIndex = 5;
            // 
            // pbCurrentFile
            // 
            this.pbCurrentFile.Location = new System.Drawing.Point(12, 118);
            this.pbCurrentFile.Name = "pbCurrentFile";
            this.pbCurrentFile.Size = new System.Drawing.Size(651, 23);
            this.pbCurrentFile.TabIndex = 7;
            // 
            // klblCurrentFile
            // 
            this.klblCurrentFile.Location = new System.Drawing.Point(12, 92);
            this.klblCurrentFile.Name = "klblCurrentFile";
            this.klblCurrentFile.Size = new System.Drawing.Size(73, 20);
            this.klblCurrentFile.TabIndex = 8;
            this.klblCurrentFile.Values.Text = "Current File";
            // 
            // pbTotalFiles
            // 
            this.pbTotalFiles.Location = new System.Drawing.Point(12, 38);
            this.pbTotalFiles.Name = "pbTotalFiles";
            this.pbTotalFiles.Size = new System.Drawing.Size(651, 23);
            this.pbTotalFiles.TabIndex = 6;
            // 
            // klblTotalFiles
            // 
            this.klblTotalFiles.Location = new System.Drawing.Point(12, 12);
            this.klblTotalFiles.Name = "klblTotalFiles";
            this.klblTotalFiles.Size = new System.Drawing.Size(65, 20);
            this.klblTotalFiles.TabIndex = 6;
            this.klblTotalFiles.Values.Text = "Total Files";
            // 
            // KryptonFileMonitor
            // 
            this.ClientSize = new System.Drawing.Size(675, 202);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonFileMonitor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KryptonFileMonitor_FormClosed);
            this.Load += new System.EventHandler(this.KryptonFileMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region ICopyFileDetails Implementation
        public ISynchronizeInvoke SynchronizationObject { get; set; }

        public event CopyFiles.DEL_cancelCopy EN_cancelCopy;

        public void Update(int totalFiles, int copiedFiles, long totalBytes, long copiedBytes, string currentFilename)
        {
            pbTotalFiles.Maximum = totalFiles;

            pbTotalFiles.Value = copiedFiles;

            pbCurrentFile.Maximum = 100;

            if (totalFiles != 0) pbCurrentFile.Value = Convert.ToInt32((100f / (totalFiles / 1024f)) * (copiedBytes / 1024f));

            klblTotalFiles.Text = $"Total Files: ({ copiedFiles } / { totalFiles })";

            klblCurrentFile.Text = $"Current File: { currentFilename }";
        }
        #endregion

        #region Constructor
        public KryptonFileMonitor()
        {
            InitializeComponent();
        }
        #endregion

        private void kdbtnCancel_Click(object sender, EventArgs e)
        {
            RaiseCancel();
        }

        private void RaiseCancel()
        {
            if (EN_cancelCopy != null)
            {
                EN_cancelCopy();
            }
        }

        private void KryptonFileMonitor_Load(object sender, EventArgs e)
        {

        }

        private void KryptonFileMonitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            RaiseCancel();
        }
    }
}