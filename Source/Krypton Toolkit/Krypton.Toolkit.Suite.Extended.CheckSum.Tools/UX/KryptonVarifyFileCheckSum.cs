#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.CheckSum.Tools
{
    public class KryptonVarifyFileCheckSum : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonLabel kryptonLabel1;
        private KryptonButton kbtnCancel;
        private KryptonButton kbtnImportHash;
        private KryptonButton kbtnBrowseForFile;
        private KryptonTextBox ktxtFilePath;
        private KryptonGroupBox kryptonGroupBox2;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonWrapLabel kwlCalculatedCheckSum;
        private KryptonButton kbtnCompute;
        private KryptonComboBox kcmbAlgorithimType;
        private KryptonLabel kryptonLabel2;
        private KryptonButton kbtnValidate;
        private KryptonTextBox ktxtVarifyCheckSum;
        private KryptonContextMenuItems kryptonContextMenuItems1;
        private KryptonContextMenuItems kryptonContextMenuItems2;
        private ContextMenuStrip cmsCheckSumValidation;
        private IContainer components;
        private ToolStripMenuItem pasteCheckSumToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem clearTextBoxToolStripMenuItem;
        private StatusStrip ss;
        private ToolStripStatusLabel tsslStatus;
        private ToolStripProgressBar tspbHashProgress;
        private BackgroundWorker bgRIPEMD160Hash;
        private BackgroundWorker bgSHA512Hash;
        private BackgroundWorker bgSHA384Hash;
        private BackgroundWorker bgSHA256Hash;
        private BackgroundWorker bgSHA1Hash;
        private BackgroundWorker bgMD5Hash;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnValidate = new Krypton.Toolkit.KryptonButton();
            this.kbtnImportHash = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonGroupBox2 = new Krypton.Toolkit.KryptonGroupBox();
            this.ktxtVarifyCheckSum = new Krypton.Toolkit.KryptonTextBox();
            this.cmsCheckSumValidation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteCheckSumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearTextBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kwlCalculatedCheckSum = new Krypton.Toolkit.KryptonWrapLabel();
            this.kbtnCompute = new Krypton.Toolkit.KryptonButton();
            this.kcmbAlgorithimType = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnBrowseForFile = new Krypton.Toolkit.KryptonButton();
            this.ktxtFilePath = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonContextMenuItems1 = new Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItems2 = new Krypton.Toolkit.KryptonContextMenuItems();
            this.ss = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbHashProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.bgRIPEMD160Hash = new System.ComponentModel.BackgroundWorker();
            this.bgSHA512Hash = new System.ComponentModel.BackgroundWorker();
            this.bgSHA384Hash = new System.ComponentModel.BackgroundWorker();
            this.bgSHA256Hash = new System.ComponentModel.BackgroundWorker();
            this.bgSHA1Hash = new System.ComponentModel.BackgroundWorker();
            this.bgMD5Hash = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            this.cmsCheckSumValidation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbAlgorithimType)).BeginInit();
            this.ss.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnValidate);
            this.kryptonPanel1.Controls.Add(this.kbtnImportHash);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 316);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(709, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnValidate
            // 
            this.kbtnValidate.Enabled = false;
            this.kbtnValidate.Location = new System.Drawing.Point(511, 13);
            this.kbtnValidate.Name = "kbtnValidate";
            this.kbtnValidate.Size = new System.Drawing.Size(90, 25);
            this.kbtnValidate.TabIndex = 4;
            this.kbtnValidate.Values.Text = "&Validate!";
            this.kbtnValidate.Click += new System.EventHandler(this.kbtnValidate_Click);
            // 
            // kbtnImportHash
            // 
            this.kbtnImportHash.Enabled = false;
            this.kbtnImportHash.Location = new System.Drawing.Point(13, 13);
            this.kbtnImportHash.Name = "kbtnImportHash";
            this.kbtnImportHash.Size = new System.Drawing.Size(90, 25);
            this.kbtnImportHash.TabIndex = 3;
            this.kbtnImportHash.Values.Text = "&Import Hash";
            this.kbtnImportHash.Click += new System.EventHandler(this.kbtnImportHash_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(607, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 1;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(709, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox2);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel2.Controls.Add(this.kbtnCompute);
            this.kryptonPanel2.Controls.Add(this.kcmbAlgorithimType);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kbtnBrowseForFile);
            this.kryptonPanel2.Controls.Add(this.ktxtFilePath);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(709, 316);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(13, 213);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.ktxtVarifyCheckSum);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(684, 95);
            this.kryptonGroupBox2.TabIndex = 7;
            this.kryptonGroupBox2.Values.Heading = "Varified CheckSum";
            // 
            // ktxtVarifyCheckSum
            // 
            this.ktxtVarifyCheckSum.ContextMenuStrip = this.cmsCheckSumValidation;
            this.ktxtVarifyCheckSum.Hint = "Type or paste checksum here...";
            this.ktxtVarifyCheckSum.Location = new System.Drawing.Point(6, 23);
            this.ktxtVarifyCheckSum.Name = "ktxtVarifyCheckSum";
            this.ktxtVarifyCheckSum.Size = new System.Drawing.Size(665, 24);
            this.ktxtVarifyCheckSum.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtVarifyCheckSum.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtVarifyCheckSum.TabIndex = 0;
            this.ktxtVarifyCheckSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ktxtVarifyCheckSum.TextChanged += new System.EventHandler(this.ktxtVarifyCheckSum_TextChanged);
            // 
            // cmsCheckSumValidation
            // 
            this.cmsCheckSumValidation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCheckSumValidation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteCheckSumToolStripMenuItem,
            this.toolStripMenuItem1,
            this.clearTextBoxToolStripMenuItem});
            this.cmsCheckSumValidation.Name = "cmsCheckSumValidation";
            this.cmsCheckSumValidation.Size = new System.Drawing.Size(163, 54);
            // 
            // pasteCheckSumToolStripMenuItem
            // 
            this.pasteCheckSumToolStripMenuItem.Name = "pasteCheckSumToolStripMenuItem";
            this.pasteCheckSumToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.pasteCheckSumToolStripMenuItem.Text = "&Paste CheckSum";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(159, 6);
            // 
            // clearTextBoxToolStripMenuItem
            // 
            this.clearTextBoxToolStripMenuItem.Enabled = false;
            this.clearTextBoxToolStripMenuItem.Name = "clearTextBoxToolStripMenuItem";
            this.clearTextBoxToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.clearTextBoxToolStripMenuItem.Text = "Clear &TextBox";
            this.clearTextBoxToolStripMenuItem.Click += new System.EventHandler(this.clearTextBoxToolStripMenuItem_Click);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(13, 102);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kwlCalculatedCheckSum);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(684, 95);
            this.kryptonGroupBox1.TabIndex = 6;
            this.kryptonGroupBox1.Values.Heading = "Calculated CheckSum";
            // 
            // kwlCalculatedCheckSum
            // 
            this.kwlCalculatedCheckSum.AutoSize = false;
            this.kwlCalculatedCheckSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlCalculatedCheckSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlCalculatedCheckSum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlCalculatedCheckSum.Location = new System.Drawing.Point(0, 0);
            this.kwlCalculatedCheckSum.Name = "kwlCalculatedCheckSum";
            this.kwlCalculatedCheckSum.Size = new System.Drawing.Size(680, 71);
            this.kwlCalculatedCheckSum.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlCalculatedCheckSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kbtnCompute
            // 
            this.kbtnCompute.Enabled = false;
            this.kbtnCompute.Location = new System.Drawing.Point(256, 63);
            this.kbtnCompute.Name = "kbtnCompute";
            this.kbtnCompute.Size = new System.Drawing.Size(90, 25);
            this.kbtnCompute.TabIndex = 5;
            this.kbtnCompute.Values.Text = "&Compute";
            this.kbtnCompute.Click += new System.EventHandler(this.kbtnCompute_Click);
            // 
            // kcmbAlgorithimType
            // 
            this.kcmbAlgorithimType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbAlgorithimType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbAlgorithimType.DropDownWidth = 121;
            this.kcmbAlgorithimType.Enabled = false;
            this.kcmbAlgorithimType.IntegralHeight = false;
            this.kcmbAlgorithimType.Location = new System.Drawing.Point(128, 63);
            this.kcmbAlgorithimType.Name = "kcmbAlgorithimType";
            this.kcmbAlgorithimType.Size = new System.Drawing.Size(121, 21);
            this.kcmbAlgorithimType.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbAlgorithimType.TabIndex = 4;
            this.kcmbAlgorithimType.SelectedIndexChanged += new System.EventHandler(this.kcmbAlgorithimType_SelectedIndexChanged);
            this.kcmbAlgorithimType.TextChanged += new System.EventHandler(this.kcmbAlgorithimType_TextChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(13, 63);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(108, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Algorithim Type:";
            // 
            // kbtnBrowseForFile
            // 
            this.kbtnBrowseForFile.Location = new System.Drawing.Point(664, 13);
            this.kbtnBrowseForFile.Name = "kbtnBrowseForFile";
            this.kbtnBrowseForFile.Size = new System.Drawing.Size(33, 25);
            this.kbtnBrowseForFile.TabIndex = 2;
            this.kbtnBrowseForFile.Values.Text = ".&..";
            this.kbtnBrowseForFile.Click += new System.EventHandler(this.kbtnBrowseForFile_Click);
            // 
            // ktxtFilePath
            // 
            this.ktxtFilePath.Hint = "Type a file path here...";
            this.ktxtFilePath.Location = new System.Drawing.Point(84, 13);
            this.ktxtFilePath.Name = "ktxtFilePath";
            this.ktxtFilePath.Size = new System.Drawing.Size(574, 23);
            this.ktxtFilePath.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 13);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(64, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "File Path:";
            // 
            // ss
            // 
            this.ss.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ss.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus,
            this.tspbHashProgress});
            this.ss.Location = new System.Drawing.Point(0, 366);
            this.ss.Name = "ss";
            this.ss.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.ss.Size = new System.Drawing.Size(709, 22);
            this.ss.TabIndex = 2;
            this.ss.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(694, 17);
            this.tsslStatus.Spring = true;
            this.tsslStatus.Text = "Ready";
            this.tsslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tspbHashProgress
            // 
            this.tspbHashProgress.Name = "tspbHashProgress";
            this.tspbHashProgress.Size = new System.Drawing.Size(100, 16);
            this.tspbHashProgress.Visible = false;
            // 
            // bgRIPEMD160Hash
            // 
            this.bgRIPEMD160Hash.WorkerReportsProgress = true;
            this.bgRIPEMD160Hash.WorkerSupportsCancellation = true;
            this.bgRIPEMD160Hash.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgRIPEMD160Hash_DoWork);
            this.bgRIPEMD160Hash.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(ProgressChanged);
            this.bgRIPEMD160Hash.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(RunWorkerCompleted);
            // 
            // bgSHA512Hash
            // 
            this.bgSHA512Hash.WorkerReportsProgress = true;
            this.bgSHA512Hash.WorkerSupportsCancellation = true;
            this.bgSHA512Hash.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSHA512Hash_DoWork);
            this.bgSHA512Hash.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(ProgressChanged);
            this.bgSHA512Hash.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(RunWorkerCompleted);
            // 
            // bgSHA384Hash
            // 
            this.bgSHA384Hash.WorkerReportsProgress = true;
            this.bgSHA384Hash.WorkerSupportsCancellation = true;
            this.bgSHA384Hash.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSHA384Hash_DoWork);
            this.bgSHA384Hash.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(ProgressChanged);
            this.bgSHA384Hash.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(RunWorkerCompleted);
            // 
            // bgSHA256Hash
            // 
            this.bgSHA256Hash.WorkerReportsProgress = true;
            this.bgSHA256Hash.WorkerSupportsCancellation = true;
            this.bgSHA256Hash.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSHA256Hash_DoWork);
            this.bgSHA256Hash.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(ProgressChanged);
            this.bgSHA256Hash.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(RunWorkerCompleted);
            // 
            // bgSHA1Hash
            // 
            this.bgSHA1Hash.WorkerReportsProgress = true;
            this.bgSHA1Hash.WorkerSupportsCancellation = true;
            this.bgSHA1Hash.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSHA1Hash_DoWork);
            this.bgSHA1Hash.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(ProgressChanged);
            this.bgSHA1Hash.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(RunWorkerCompleted);
            // 
            // bgMD5Hash
            // 
            this.bgMD5Hash.WorkerReportsProgress = true;
            this.bgMD5Hash.WorkerSupportsCancellation = true;
            this.bgMD5Hash.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgMD5Hash_DoWork);
            this.bgMD5Hash.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(ProgressChanged);
            this.bgMD5Hash.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(RunWorkerCompleted);
            // 
            // KryptonVarifyFileCheckSum
            // 
            this.ClientSize = new System.Drawing.Size(709, 388);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.ss);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonVarifyFileCheckSum";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Varify File CheckSum";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            this.cmsCheckSumValidation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbAlgorithimType)).EndInit();
            this.ss.ResumeLayout(false);
            this.ss.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Variables
        private string _fileName = string.Empty, _fileNameWithoutExtension = string.Empty;

        private Settings _settings = new Settings();
        #endregion

        #region Properties
        public string FileName { get => _fileName; private set => _fileName = value; }

        public string FileNameWithoutExtension { get => _fileNameWithoutExtension; private set => _fileNameWithoutExtension = value; }
        #endregion

        #region Constructor
        public KryptonVarifyFileCheckSum()
        {
            InitializeComponent();

            HelperMethods.PropagateHashBox(kcmbAlgorithimType);
        }
        #endregion

        #region Hashing Work
        private void bgMD5Hash_DoWork(object sender, DoWorkEventArgs e)
        {
            string filePath = e.Argument.ToString();

            byte[] buffer;

            int bytesRead;

            long size, totalBytesRead = 0;

            using (Stream file = File.OpenRead(filePath))
            {
                size = file.Length;

                using (HashAlgorithm hasher = MD5.Create())
                {
                    do
                    {
                        buffer = new byte[4096];

                        bytesRead = file.Read(buffer, 0, buffer.Length);

                        totalBytesRead += bytesRead;

                        hasher.TransformBlock(buffer, 0, bytesRead, null, 0);

                        bgMD5Hash.ReportProgress((int)((double)totalBytesRead / size * 100));
                    } while (bytesRead != 0);

                    hasher.TransformFinalBlock(buffer, 0, 0);

                    e.Result = HashingHelpers.BuildMD5HashString(hasher.Hash);
                }
            }

            UpdateStatus($"Computing hash for: {FileNameWithoutExtension}");
        }

        private void bgSHA1Hash_DoWork(object sender, DoWorkEventArgs e)
        {
            string filePath = e.Argument.ToString();

            byte[] buffer;

            int bytesRead;

            long size, totalBytesRead = 0;

            using (Stream file = File.OpenRead(filePath))
            {
                size = file.Length;

                using (HashAlgorithm hasher = SHA1.Create())
                {
                    do
                    {
                        buffer = new byte[4096];

                        bytesRead = file.Read(buffer, 0, buffer.Length);

                        totalBytesRead += bytesRead;

                        hasher.TransformBlock(buffer, 0, bytesRead, null, 0);

                        bgSHA1Hash.ReportProgress((int)((double)totalBytesRead / size * 100));
                    } while (bytesRead != 0);

                    hasher.TransformFinalBlock(buffer, 0, 0);

                    e.Result = HashingHelpers.BuildSHA1HashString(hasher.Hash);
                }
            }
        }

        private void bgSHA256Hash_DoWork(object sender, DoWorkEventArgs e)
        {
            string filePath = e.Argument.ToString();

            byte[] buffer;

            int bytesRead;

            long size, totalBytesRead = 0;

            using (Stream file = File.OpenRead(filePath))
            {
                size = file.Length;

                using (HashAlgorithm hasher = SHA256.Create())
                {
                    do
                    {
                        buffer = new byte[4096];

                        bytesRead = file.Read(buffer, 0, buffer.Length);

                        totalBytesRead += bytesRead;

                        hasher.TransformBlock(buffer, 0, bytesRead, null, 0);

                        bgSHA256Hash.ReportProgress((int)((double)totalBytesRead / size * 100));
                    } while (bytesRead != 0);

                    hasher.TransformFinalBlock(buffer, 0, 0);

                    e.Result = HashingHelpers.BuildSHA256HashString(hasher.Hash);
                }
            }
        }

        private void bgSHA384Hash_DoWork(object sender, DoWorkEventArgs e)
        {
            string filePath = e.Argument.ToString();

            byte[] buffer;

            int bytesRead;

            long size, totalBytesRead = 0;

            using (Stream file = File.OpenRead(filePath))
            {
                size = file.Length;

                using (HashAlgorithm hasher = SHA384.Create())
                {
                    do
                    {
                        buffer = new byte[4096];

                        bytesRead = file.Read(buffer, 0, buffer.Length);

                        totalBytesRead += bytesRead;

                        hasher.TransformBlock(buffer, 0, bytesRead, null, 0);

                        bgSHA384Hash.ReportProgress((int)((double)totalBytesRead / size * 100));
                    } while (bytesRead != 0);

                    hasher.TransformFinalBlock(buffer, 0, 0);

                    e.Result = HashingHelpers.BuildSHA384HashString(hasher.Hash);
                }
            }
        }

        private void bgSHA512Hash_DoWork(object sender, DoWorkEventArgs e)
        {
            string filePath = e.Argument.ToString();

            byte[] buffer;

            int bytesRead;

            long size, totalBytesRead = 0;

            using (Stream file = File.OpenRead(filePath))
            {
                size = file.Length;

                using (HashAlgorithm hasher = SHA512.Create())
                {
                    do
                    {
                        buffer = new byte[4096];

                        bytesRead = file.Read(buffer, 0, buffer.Length);

                        totalBytesRead += bytesRead;

                        hasher.TransformBlock(buffer, 0, bytesRead, null, 0);

                        bgSHA512Hash.ReportProgress((int)((double)totalBytesRead / size * 100));
                    } while (bytesRead != 0);

                    hasher.TransformFinalBlock(buffer, 0, 0);

                    e.Result = HashingHelpers.BuildSHA512HashString(hasher.Hash);
                }
            }
        }

        private void bgRIPEMD160Hash_DoWork(object sender, DoWorkEventArgs e)
        {
#if !NETCOREAPP3_0_OR_GREATER
            string filePath = e.Argument.ToString();

            byte[] buffer;

            int bytesRead;

            long size, totalBytesRead = 0;

            using (Stream file = File.OpenRead(filePath))
            {
                size = file.Length;

                using (HashAlgorithm hasher = RIPEMD160Managed.Create())
                {
                    do
                    {
                        buffer = new byte[4096];

                        bytesRead = file.Read(buffer, 0, buffer.Length);

                        totalBytesRead += bytesRead;

                        hasher.TransformBlock(buffer, 0, bytesRead, null, 0);

                        bgRIPEMD160Hash.ReportProgress((int)((double)totalBytesRead / size * 100));
                    } while (bytesRead != 0);

                    hasher.TransformFinalBlock(buffer, 0, 0);

                    e.Result = HashingHelpers.BuildRIPEMD160HashString(hasher.Hash);
                }
            }
#endif
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            kwlCalculatedCheckSum.Text = "Please wait...";

            tspbHashProgress.Value = e.ProgressPercentage;
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            kwlCalculatedCheckSum.Text = e.Result.ToString();

            tspbHashProgress.Value = 0;

            tspbHashProgress.Visible = false;

            UpdateStatus("Ready");
        }
        #endregion

        private string UpdateStatus(string status) => tsslStatus.Text = status;

        private void kbtnBrowseForFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Browse for a File:";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ktxtFilePath.Text = Path.GetFullPath(ofd.FileName);

                FileNameWithoutExtension = Path.GetFileNameWithoutExtension(ofd.FileName);

                kcmbAlgorithimType.Enabled = true;

                kcmbAlgorithimType.Enabled = true;
            }
        }

        private void kbtnValidate_Click(object sender, EventArgs e)
        {
            if (HelperMethods.IsValid(kwlCalculatedCheckSum.Text, ktxtVarifyCheckSum.Text.ToUpper()))
            {
                ktxtVarifyCheckSum.StateCommon.Border.Color1 = _settings.ValidColour;

                ktxtVarifyCheckSum.StateCommon.Border.Color2 = _settings.ValidColour;

                UpdateStatus("Hashes matched!");
            }
            else
            {
                ktxtVarifyCheckSum.StateCommon.Border.Color1 = _settings.InvalidColour;

                ktxtVarifyCheckSum.StateCommon.Border.Color2 = _settings.InvalidColour;

                UpdateStatus("Hashes do not match!");
            }
        }

        private void ktxtVarifyCheckSum_TextChanged(object sender, EventArgs e)
        {
            if (MissingFrameWorkAPIs.IsNullOrWhiteSpace(ktxtVarifyCheckSum.Text))
            {
                ktxtVarifyCheckSum.StateCommon.Border.Color1 = _settings.IntermediateColour;

                ktxtVarifyCheckSum.StateCommon.Border.Color2 = _settings.IntermediateColour;
            }

            kbtnValidate.Enabled = true; // MissingFrameWorkAPIs.IsNullOrWhiteSpace(ktxtVarifyCheckSum.Text);

            clearTextBoxToolStripMenuItem.Enabled = !MissingFrameWorkAPIs.IsNullOrWhiteSpace(ktxtVarifyCheckSum.Text);
        }

        private void kbtnCompute_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateStatus($"Computing hash for: {FileNameWithoutExtension}");

                tspbHashProgress.Visible = true;

                kbtnCompute.Enabled = false;

                CalculateHash();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show($"An error has occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void kcmbAlgorithimType_SelectedIndexChanged(object sender, EventArgs e) => kbtnCompute.Enabled = true; // MissingFrameWorkAPIs.IsNullOrWhiteSpace(kcmbAlgorithimType.Text);

        private void kbtnImportHash_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();

                ofd.Filter = "MD5 Hash Files|*.md5|SHA-1 Hash Files|*.sha1|SHA-256 Hash Files|*.sha256|SHA-384 Hash Files|*.sha384|SHA-512 Hash Files|*.sha512|RIPEMD-160 Hash Files|*.ripemd160";

                ofd.Title = "Import a Hash:";

                ofd.FilterIndex = 0;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader reader = new StreamReader(Path.GetFullPath(ofd.FileName)))
                    {
                        string content = reader.ReadToEnd();

                        ktxtVarifyCheckSum.Text = content;
                    }
                }
            }
            catch (Exception exc)
            {
                KryptonMessageBox.Show($"An error has occurred: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearTextBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = KryptonMessageBox.Show("Do you want to clear the textbox of its contents?", "Clear Hash Box", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ktxtVarifyCheckSum.Text = string.Empty;
            }
        }

        private void CalculateHash()
        {
            try
            {
                if (kcmbAlgorithimType.Text == "MD-5")
                {
                    bgMD5Hash.RunWorkerAsync(ktxtFilePath.Text);
                }
                else if (kcmbAlgorithimType.Text == "SHA-1")
                {
                    bgSHA1Hash.RunWorkerAsync(ktxtFilePath.Text);
                }
                else if (kcmbAlgorithimType.Text == "SHA-256")
                {
                    bgSHA256Hash.RunWorkerAsync(ktxtFilePath.Text);
                }
                else if (kcmbAlgorithimType.Text == "SHA-384")
                {
                    bgSHA384Hash.RunWorkerAsync(ktxtFilePath.Text);
                }
                else if (kcmbAlgorithimType.Text == "SHA-512")
                {
                    bgSHA512Hash.RunWorkerAsync(ktxtFilePath.Text);
                }
                else if (kcmbAlgorithimType.Text == "RIPEMD-160")
                {
                    bgRIPEMD160Hash.RunWorkerAsync(ktxtFilePath.Text);
                }

                kbtnImportHash.Enabled = true;
            }
            catch (Exception e)
            {
                KryptonMessageBox.Show($"An error has occurred: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kcmbAlgorithimType_TextChanged(object sender, EventArgs e) => kbtnCompute.Enabled = MissingFrameWorkAPIs.IsNullOrWhiteSpace(kcmbAlgorithimType.Text);
    }
}