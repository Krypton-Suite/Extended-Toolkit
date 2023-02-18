namespace Krypton.Toolkit.Suite.Extended.CheckSum.Tools
{
    partial class KryptonComputeFileCheckSum
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ss = new System.Windows.Forms.StatusStrip();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbHashingProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tslHashingProgressPercentageText = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgwMD5 = new System.ComponentModel.BackgroundWorker();
            this.bgwSHA1 = new System.ComponentModel.BackgroundWorker();
            this.bgwSHA256 = new System.ComponentModel.BackgroundWorker();
            this.bgwSHA384 = new System.ComponentModel.BackgroundWorker();
            this.bgwSHA512 = new System.ComponentModel.BackgroundWorker();
            this.bgwRIPEMD160 = new System.ComponentModel.BackgroundWorker();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtFilePath = new Krypton.Toolkit.KryptonTextBox();
            this.kcmbHashTypes = new Krypton.Toolkit.KryptonComboBox();
            this.kbtnCompute = new Krypton.Toolkit.KryptonButton();
            this.kwlHashOutput = new Krypton.Toolkit.KryptonWrapLabel();
            this.bsaReset = new Krypton.Toolkit.ButtonSpecAny();
            this.bsaBrowse = new Krypton.Toolkit.ButtonSpecAny();
            this.kchkToggleCasing = new Krypton.Toolkit.KryptonCheckBox();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnSaveToFile = new Krypton.Toolkit.KryptonButton();
            this.ss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbHashTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // ss
            // 
            this.ss.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ss.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus,
            this.tspbHashingProgress,
            this.tslHashingProgressPercentageText});
            this.ss.Location = new System.Drawing.Point(0, 285);
            this.ss.Name = "ss";
            this.ss.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.ss.Size = new System.Drawing.Size(730, 22);
            this.ss.TabIndex = 0;
            this.ss.Text = "statusStrip1";
            // 
            // tslStatus
            // 
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(715, 17);
            this.tslStatus.Spring = true;
            this.tslStatus.Text = "Ready";
            this.tslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tspbHashingProgress
            // 
            this.tspbHashingProgress.Name = "tspbHashingProgress";
            this.tspbHashingProgress.Size = new System.Drawing.Size(100, 16);
            this.tspbHashingProgress.Visible = false;
            // 
            // tslHashingProgressPercentageText
            // 
            this.tslHashingProgressPercentageText.Name = "tslHashingProgressPercentageText";
            this.tslHashingProgressPercentageText.Size = new System.Drawing.Size(0, 17);
            // 
            // bgwMD5
            // 
            this.bgwMD5.WorkerReportsProgress = true;
            this.bgwMD5.WorkerSupportsCancellation = true;
            this.bgwMD5.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMD5_DoWork);
            this.bgwMD5.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.bgwMD5.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_Completed);
            // 
            // bgwSHA1
            // 
            this.bgwSHA1.WorkerReportsProgress = true;
            this.bgwSHA1.WorkerSupportsCancellation = true;
            this.bgwSHA1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSHA1_DoWork);
            this.bgwSHA1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.bgwSHA1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_Completed);
            // 
            // bgwSHA256
            // 
            this.bgwSHA256.WorkerReportsProgress = true;
            this.bgwSHA256.WorkerSupportsCancellation = true;
            this.bgwSHA256.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSHA256_DoWork);
            this.bgwSHA256.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.bgwSHA256.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_Completed);
            // 
            // bgwSHA384
            // 
            this.bgwSHA384.WorkerReportsProgress = true;
            this.bgwSHA384.WorkerSupportsCancellation = true;
            this.bgwSHA384.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSHA384_DoWork);
            this.bgwSHA384.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.bgwSHA384.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_Completed);
            // 
            // bgwSHA512
            // 
            this.bgwSHA512.WorkerReportsProgress = true;
            this.bgwSHA512.WorkerSupportsCancellation = true;
            this.bgwSHA512.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSHA512_DoWork);
            this.bgwSHA512.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.bgwSHA512.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_Completed);
            // 
            // bgwRIPEMD160
            // 
            this.bgwRIPEMD160.WorkerReportsProgress = true;
            this.bgwRIPEMD160.WorkerSupportsCancellation = true;
            this.bgwRIPEMD160.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRIPEMD160_DoWork);
            this.bgwRIPEMD160.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.bgwRIPEMD160.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_Completed);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnSaveToFile);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kchkToggleCasing);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 235);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(730, 50);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(730, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(730, 235);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.Controls.Add(this.kryptonGroupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ktxtFilePath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.kcmbHashTypes, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.kbtnCompute, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(730, 235);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // kryptonGroupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.kryptonGroupBox1, 3);
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(3, 63);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kwlHashOutput);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(724, 169);
            this.kryptonGroupBox1.TabIndex = 0;
            this.kryptonGroupBox1.Values.Heading = "Hash Output";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(75, 23);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "File Path:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(3, 32);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(75, 25);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Hash Type:";
            // 
            // ktxtFilePath
            // 
            this.ktxtFilePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ktxtFilePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.ktxtFilePath.ButtonSpecs.AddRange(new Krypton.Toolkit.ButtonSpecAny[] {
            this.bsaReset,
            this.bsaBrowse});
            this.tableLayoutPanel1.SetColumnSpan(this.ktxtFilePath, 2);
            this.ktxtFilePath.CueHint.CueHintText = "Enter a file path here...";
            this.ktxtFilePath.CueHint.TextV = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.ktxtFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktxtFilePath.Location = new System.Drawing.Point(84, 3);
            this.ktxtFilePath.Name = "ktxtFilePath";
            this.ktxtFilePath.Size = new System.Drawing.Size(643, 24);
            this.ktxtFilePath.TabIndex = 3;
            // 
            // kcmbHashTypes
            // 
            this.kcmbHashTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kcmbHashTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbHashTypes.DropDownWidth = 210;
            this.kcmbHashTypes.IntegralHeight = false;
            this.kcmbHashTypes.Location = new System.Drawing.Point(84, 32);
            this.kcmbHashTypes.Name = "kcmbHashTypes";
            this.kcmbHashTypes.Size = new System.Drawing.Size(210, 21);
            this.kcmbHashTypes.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbHashTypes.TabIndex = 4;
            // 
            // kbtnCompute
            // 
            this.kbtnCompute.Enabled = false;
            this.kbtnCompute.Location = new System.Drawing.Point(300, 32);
            this.kbtnCompute.Name = "kbtnCompute";
            this.kbtnCompute.Size = new System.Drawing.Size(90, 25);
            this.kbtnCompute.TabIndex = 5;
            this.kbtnCompute.Values.Text = "C&ompute";
            this.kbtnCompute.Click += new System.EventHandler(this.kbtnCompute_Click);
            // 
            // kwlHashOutput
            // 
            this.kwlHashOutput.AutoSize = false;
            this.kwlHashOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlHashOutput.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.kwlHashOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlHashOutput.LabelStyle = Krypton.Toolkit.LabelStyle.TitleControl;
            this.kwlHashOutput.Location = new System.Drawing.Point(0, 0);
            this.kwlHashOutput.Name = "kwlHashOutput";
            this.kwlHashOutput.Size = new System.Drawing.Size(720, 145);
            this.kwlHashOutput.Text = "{0}";
            this.kwlHashOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bsaReset
            // 
            this.bsaReset.Enabled = Krypton.Toolkit.ButtonEnabled.False;
            this.bsaReset.Text = "R";
            this.bsaReset.UniqueName = "cfbb956bf6f7461485a4f8617f8f5a21";
            // 
            // bsaBrowse
            // 
            this.bsaBrowse.Text = "...";
            this.bsaBrowse.UniqueName = "e238d0a40bb9429d9001ad448b7c376c";
            // 
            // kchkToggleCasing
            // 
            this.kchkToggleCasing.Location = new System.Drawing.Point(13, 19);
            this.kchkToggleCasing.Name = "kchkToggleCasing";
            this.kchkToggleCasing.Size = new System.Drawing.Size(101, 20);
            this.kchkToggleCasing.TabIndex = 1;
            this.kchkToggleCasing.Values.Text = "Toggle &Casing";
            this.kchkToggleCasing.CheckedChanged += new System.EventHandler(this.kchkToggleCasing_CheckedChanged);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(628, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "kryptonButton1";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kbtnSaveToFile
            // 
            this.kbtnSaveToFile.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnSaveToFile.Enabled = false;
            this.kbtnSaveToFile.Location = new System.Drawing.Point(489, 13);
            this.kbtnSaveToFile.Name = "kbtnSaveToFile";
            this.kbtnSaveToFile.Size = new System.Drawing.Size(133, 25);
            this.kbtnSaveToFile.TabIndex = 3;
            this.kbtnSaveToFile.Values.Text = "Save to &File";
            this.kbtnSaveToFile.Click += new System.EventHandler(this.kbtnSaveToFile_Click);
            // 
            // KryptonComputeFileCheckSum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(730, 307);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.ss);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonComputeFileCheckSum";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Compute CheckSum";
            this.ss.ResumeLayout(false);
            this.ss.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbHashTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip ss;
        private ToolStripStatusLabel tslStatus;
        private ToolStripProgressBar tspbHashingProgress;
        private ToolStripStatusLabel tslHashingProgressPercentageText;
        private BackgroundWorker bgwMD5;
        private BackgroundWorker bgwSHA1;
        private BackgroundWorker bgwSHA256;
        private BackgroundWorker bgwSHA384;
        private BackgroundWorker bgwSHA512;
        private BackgroundWorker bgwRIPEMD160;
        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private TableLayoutPanel tableLayoutPanel1;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonLabel kryptonLabel1;
        private KryptonLabel kryptonLabel2;
        private KryptonTextBox ktxtFilePath;
        private KryptonComboBox kcmbHashTypes;
        private KryptonButton kbtnCompute;
        private KryptonWrapLabel kwlHashOutput;
        private ButtonSpecAny bsaReset;
        private ButtonSpecAny bsaBrowse;
        private KryptonCheckBox kchkToggleCasing;
        private KryptonButton kbtnCancel;
        private KryptonButton kbtnSaveToFile;
    }
}