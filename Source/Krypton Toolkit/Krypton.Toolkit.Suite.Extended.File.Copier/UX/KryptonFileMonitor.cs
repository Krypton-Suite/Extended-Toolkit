#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.File.Copier
{
    public class KryptonFileMonitor : KryptonForm, ICopyFileDetails
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnCancel;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonGroupBox kryptonGroupBox2;
        private ProgressBar pbTotalFiles;
        private KryptonLabel klblTotalFiles;
        private KryptonGroupBox kryptonGroupBox1;
        private ProgressBar pbCurrentFile;
        private KryptonLabel klblCurrentFile;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kryptonGroupBox2 = new Krypton.Toolkit.KryptonGroupBox();
            this.klblCurrentFile = new Krypton.Toolkit.KryptonLabel();
            this.klblTotalFiles = new Krypton.Toolkit.KryptonLabel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.pbCurrentFile = new System.Windows.Forms.ProgressBar();
            this.pbTotalFiles = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 271);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(777, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(777, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox2);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(777, 271);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.CaptionStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(13, 13);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.pbCurrentFile);
            this.kryptonGroupBox1.Panel.Controls.Add(this.klblCurrentFile);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(752, 117);
            this.kryptonGroupBox1.TabIndex = 0;
            this.kryptonGroupBox1.Values.Heading = "Current File";
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.CaptionStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonGroupBox2.Location = new System.Drawing.Point(12, 136);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.pbTotalFiles);
            this.kryptonGroupBox2.Panel.Controls.Add(this.klblTotalFiles);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(752, 117);
            this.kryptonGroupBox2.TabIndex = 1;
            this.kryptonGroupBox2.Values.Heading = "Total Files";
            // 
            // klblCurrentFile
            // 
            this.klblCurrentFile.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.klblCurrentFile.Location = new System.Drawing.Point(3, 12);
            this.klblCurrentFile.Name = "klblCurrentFile";
            this.klblCurrentFile.Size = new System.Drawing.Size(27, 20);
            this.klblCurrentFile.TabIndex = 2;
            this.klblCurrentFile.Values.Text = "{0}";
            // 
            // klblTotalFiles
            // 
            this.klblTotalFiles.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.klblTotalFiles.Location = new System.Drawing.Point(3, 12);
            this.klblTotalFiles.Name = "klblTotalFiles";
            this.klblTotalFiles.Size = new System.Drawing.Size(27, 20);
            this.klblTotalFiles.TabIndex = 3;
            this.klblTotalFiles.Values.Text = "{0}";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(343, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 1;
            this.kbtnCancel.Values.Text = "&Cancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // pbCurrentFile
            // 
            this.pbCurrentFile.Location = new System.Drawing.Point(3, 52);
            this.pbCurrentFile.Name = "pbCurrentFile";
            this.pbCurrentFile.Size = new System.Drawing.Size(742, 23);
            this.pbCurrentFile.TabIndex = 3;
            // 
            // pbTotalFiles
            // 
            this.pbTotalFiles.Location = new System.Drawing.Point(3, 52);
            this.pbTotalFiles.Name = "pbTotalFiles";
            this.pbTotalFiles.Size = new System.Drawing.Size(742, 23);
            this.pbTotalFiles.TabIndex = 4;
            // 
            // KryptonFileMonitor
            // 
            this.ClientSize = new System.Drawing.Size(777, 321);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonFileMonitor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KryptonFileMonitor_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
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

            if (totalFiles != 0)
            {
                pbCurrentFile.Value = Convert.ToInt32((100f / (totalFiles / 1024f)) * (copiedBytes / 1024f));
            }

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

        #region Methods
        private void RaiseCancel()
        {
            if (EN_cancelCopy != null)
            {
                EN_cancelCopy();
            }
        }
        #endregion

        private void KryptonFileMonitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            RaiseCancel();
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            RaiseCancel();
        }
    }
}