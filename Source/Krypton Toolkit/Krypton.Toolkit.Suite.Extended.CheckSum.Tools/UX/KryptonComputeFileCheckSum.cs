#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Developer.Utilities;

namespace Krypton.Toolkit.Suite.Extended.CheckSum.Tools
{
    public class KryptonComputeFileCheckSum : KryptonForm
    {
        #region Design Code
        private StatusStrip statusStrip1;
        private ToolStripProgressBar tspbHashProgress;
        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnBrowseForFile;
        private KryptonTextBox ktxtFilePath;
        private KryptonLabel kryptonLabel1;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonWrapLabel kwlHash;
        private KryptonButton kbtnCompute;
        private KryptonComboBox kcmbAlgorithimType;
        private KryptonLabel kryptonLabel2;
        private KryptonButton kbtnCancel;
        private BackgroundWorker bgMD5Hash;
        private KryptonCheckBox kcbToggleCase;
        private KryptonButton kbtnSaveToFile;
        private BackgroundWorker bgSHA1Hash;
        private BackgroundWorker bgSHA256Hash;
        private BackgroundWorker bgSHA384Hash;
        private BackgroundWorker bgSHA512Hash;
        private BackgroundWorker bgRIPEMD160Hash;
        private ToolStripStatusLabel tsslStatus;

        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbHashProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kcbToggleCase = new Krypton.Toolkit.KryptonCheckBox();
            this.kbtnSaveToFile = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kwlHash = new Krypton.Toolkit.KryptonWrapLabel();
            this.kbtnCompute = new Krypton.Toolkit.KryptonButton();
            this.kcmbAlgorithimType = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnBrowseForFile = new Krypton.Toolkit.KryptonButton();
            this.ktxtFilePath = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.bgMD5Hash = new System.ComponentModel.BackgroundWorker();
            this.bgSHA1Hash = new System.ComponentModel.BackgroundWorker();
            this.bgSHA256Hash = new System.ComponentModel.BackgroundWorker();
            this.bgSHA384Hash = new System.ComponentModel.BackgroundWorker();
            this.bgSHA512Hash = new System.ComponentModel.BackgroundWorker();
            this.bgRIPEMD160Hash = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbAlgorithimType)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus,
            this.tspbHashProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 258);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(705, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(690, 17);
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
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kcbToggleCase);
            this.kryptonPanel1.Controls.Add(this.kbtnSaveToFile);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 208);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(705, 50);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kcbToggleCase
            // 
            this.kcbToggleCase.Location = new System.Drawing.Point(14, 17);
            this.kcbToggleCase.Name = "kcbToggleCase";
            this.kcbToggleCase.Size = new System.Drawing.Size(90, 20);
            this.kcbToggleCase.TabIndex = 4;
            this.kcbToggleCase.Values.Text = "Toggle &Case";
            this.kcbToggleCase.CheckedChanged += new System.EventHandler(this.kcbToggleCase_CheckedChanged);
            // 
            // kbtnSaveToFile
            // 
            this.kbtnSaveToFile.Enabled = false;
            this.kbtnSaveToFile.Location = new System.Drawing.Point(507, 12);
            this.kbtnSaveToFile.Name = "kbtnSaveToFile";
            this.kbtnSaveToFile.Size = new System.Drawing.Size(90, 25);
            this.kbtnSaveToFile.TabIndex = 3;
            this.kbtnSaveToFile.Values.Text = "Save to &File";
            this.kbtnSaveToFile.Click += new System.EventHandler(this.kbtnSaveToFile_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(603, 12);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(705, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
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
            this.kryptonPanel2.Size = new System.Drawing.Size(705, 208);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(12, 98);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kwlHash);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(684, 95);
            this.kryptonGroupBox1.TabIndex = 10;
            this.kryptonGroupBox1.Values.Heading = "Calculated CheckSum";
            // 
            // kwlHash
            // 
            this.kwlHash.AutoSize = false;
            this.kwlHash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlHash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlHash.Location = new System.Drawing.Point(0, 0);
            this.kwlHash.Name = "kwlHash";
            this.kwlHash.Size = new System.Drawing.Size(680, 71);
            this.kwlHash.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlHash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kbtnCompute
            // 
            this.kbtnCompute.Enabled = false;
            this.kbtnCompute.Location = new System.Drawing.Point(255, 59);
            this.kbtnCompute.Name = "kbtnCompute";
            this.kbtnCompute.Size = new System.Drawing.Size(90, 25);
            this.kbtnCompute.TabIndex = 9;
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
            this.kcmbAlgorithimType.Location = new System.Drawing.Point(127, 59);
            this.kcmbAlgorithimType.Name = "kcmbAlgorithimType";
            this.kcmbAlgorithimType.Size = new System.Drawing.Size(121, 21);
            this.kcmbAlgorithimType.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbAlgorithimType.TabIndex = 8;
            this.kcmbAlgorithimType.SelectedIndexChanged += new System.EventHandler(this.kcmbAlgorithimType_SelectedIndexChanged);
            this.kcmbAlgorithimType.TextChanged += new System.EventHandler(this.kcmbAlgorithimType_TextChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 59);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(108, 20);
            this.kryptonLabel2.TabIndex = 7;
            this.kryptonLabel2.Values.Text = "Algorithim Type:";
            // 
            // kbtnBrowseForFile
            // 
            this.kbtnBrowseForFile.Location = new System.Drawing.Point(663, 12);
            this.kbtnBrowseForFile.Name = "kbtnBrowseForFile";
            this.kbtnBrowseForFile.Size = new System.Drawing.Size(33, 25);
            this.kbtnBrowseForFile.TabIndex = 5;
            this.kbtnBrowseForFile.Values.Text = ".&..";
            this.kbtnBrowseForFile.Click += new System.EventHandler(this.kbtnBrowseForFile_Click);
            // 
            // ktxtFilePath
            // 
            this.ktxtFilePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ktxtFilePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.ktxtFilePath.Hint = "Type a file path here...";
            this.ktxtFilePath.Location = new System.Drawing.Point(83, 12);
            this.ktxtFilePath.Name = "ktxtFilePath";
            this.ktxtFilePath.Size = new System.Drawing.Size(574, 23);
            this.ktxtFilePath.TabIndex = 4;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(64, 20);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "File Path:";
            // 
            // bgMD5Hash
            // 
            this.bgMD5Hash.WorkerReportsProgress = true;
            this.bgMD5Hash.WorkerSupportsCancellation = true;
            this.bgMD5Hash.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgMD5Hash_DoWork);
            this.bgMD5Hash.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ProgressChanged);
            this.bgMD5Hash.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
            // 
            // bgSHA1Hash
            // 
            this.bgSHA1Hash.WorkerReportsProgress = true;
            this.bgSHA1Hash.WorkerSupportsCancellation = true;
            this.bgSHA1Hash.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSHA1Hash_DoWork);
            this.bgSHA1Hash.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ProgressChanged);
            this.bgSHA1Hash.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
            // 
            // bgSHA256Hash
            // 
            this.bgSHA256Hash.WorkerReportsProgress = true;
            this.bgSHA256Hash.WorkerSupportsCancellation = true;
            this.bgSHA256Hash.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSHA256Hash_DoWork);
            this.bgSHA256Hash.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ProgressChanged);
            this.bgSHA256Hash.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
            // 
            // bgSHA384Hash
            // 
            this.bgSHA384Hash.WorkerReportsProgress = true;
            this.bgSHA384Hash.WorkerSupportsCancellation = true;
            this.bgSHA384Hash.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSHA384Hash_DoWork);
            this.bgSHA384Hash.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ProgressChanged);
            this.bgSHA384Hash.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
            // 
            // bgSHA512Hash
            // 
            this.bgSHA512Hash.WorkerReportsProgress = true;
            this.bgSHA512Hash.WorkerSupportsCancellation = true;
            this.bgSHA512Hash.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSHA512Hash_DoWork);
            this.bgSHA512Hash.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ProgressChanged);
            this.bgSHA512Hash.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
            // 
            // bgRIPEMD160Hash
            // 
            this.bgRIPEMD160Hash.WorkerReportsProgress = true;
            this.bgRIPEMD160Hash.WorkerSupportsCancellation = true;
            this.bgRIPEMD160Hash.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgRIPEMD160Hash_DoWork);
            this.bgRIPEMD160Hash.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ProgressChanged);
            this.bgRIPEMD160Hash.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RunWorkerCompleted);
            // 
            // KryptonComputeFileCheckSum
            // 
            this.ClientSize = new System.Drawing.Size(705, 280);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonComputeFileCheckSum";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Calculate CheckSum";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbAlgorithimType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Variables
        private string _fileName = string.Empty, _fileNameWithoutExtension = string.Empty;
        #endregion

        #region Properties
        public string FileName { get => _fileName; private set => _fileName = value; }

        public string FileNameWithoutExtension { get => _fileNameWithoutExtension; private set => _fileNameWithoutExtension = value; }
        #endregion

        #region Constructor
        public KryptonComputeFileCheckSum()
        {
            InitializeComponent();

            HelperMethods.PropagateHashBox(kcmbAlgorithimType);
        }
        #endregion

        private void kcmbAlgorithimType_SelectedIndexChanged(object sender, EventArgs e) => kbtnCompute.Enabled = true;

        private void kbtnCompute_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateStatus($"Computing hash for: {FileName}");

                tspbHashProgress.Visible = true;

                kbtnCompute.Enabled = false;

                CalculateHash();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show($"An error has occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateHash()
        {
            try
            {
#if NETCOREAPP3_1_OR_GREATER
                HashFile((SafeNETCoreAndNewerSupportedHashAlgorithims)Enum.Parse(typeof(SafeNETCoreAndNewerSupportedHashAlgorithims), kcmbAlgorithimType.Text));
#else
                HashFile((SupportedHashAlgorithims)Enum.Parse(typeof(SupportedHashAlgorithims), kcmbAlgorithimType.Text));
#endif
            }
            catch (Exception e)
            {
                KryptonMessageBox.Show($"An error has occurred: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            if (bgMD5Hash.IsBusy || bgSHA1Hash.IsBusy || bgSHA256Hash.IsBusy || bgSHA384Hash.IsBusy || bgSHA512Hash.IsBusy || bgRIPEMD160Hash.IsBusy)
            {
                DialogResult result = KryptonMessageBox.Show("File hashing is still in progress.\nDo you want to cancel?", "Hashing in Progress", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bgMD5Hash.CancelAsync();

                        bgMD5Hash.Dispose();

                        bgSHA1Hash.CancelAsync();

                        bgSHA1Hash.Dispose();

                        bgSHA256Hash.CancelAsync();

                        bgSHA256Hash.Dispose();

                        bgSHA384Hash.CancelAsync();

                        bgSHA384Hash.Dispose();

                        bgSHA512Hash.CancelAsync();

                        bgSHA512Hash.Dispose();

                        bgRIPEMD160Hash.CancelAsync();

                        bgRIPEMD160Hash.Dispose();
                    }
                    catch (Exception exc)
                    {
                        ExceptionCapture.CaptureException(exc);
                    }
                }
            }
        }

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

            UpdateStatus($"Computing hash for: {FileName}");
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
            kwlHash.Text = "Please wait...";

            tspbHashProgress.Value = e.ProgressPercentage;
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            kwlHash.Text = e.Result.ToString();

            tspbHashProgress.Value = 0;

            tspbHashProgress.Visible = false;

            kbtnSaveToFile.Enabled = true; kbtnSaveToFile.Enabled = true;

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

                FileName = Path.GetFileName(ofd.FileName);

                FileNameWithoutExtension = Path.GetFileNameWithoutExtension(ofd.FileName);

                kcmbAlgorithimType.Enabled = true;
            }
        }

        private void kcmbAlgorithimType_TextChanged(object sender, EventArgs e)
        {
            kbtnCancel.Enabled = MissingFrameWorkAPIs.IsNullOrWhiteSpace(kcmbAlgorithimType.Text);
        }

        private void kcbToggleCase_CheckedChanged(object sender, EventArgs e)
        {
            string tempHashString = kwlHash.Text;

            if (kcbToggleCase.Checked)
            {
                tempHashString.ToUpper();

                kwlHash.Text = tempHashString;
            }
            else
            {
                tempHashString.ToLower();

                kwlHash.Text = tempHashString;
            }
        }

        private void kbtnSaveToFile_Click(object sender, EventArgs e)
        {
            SaveHashToFile(kwlHash.Text, kcbToggleCase.Checked);
        }

        #region Methods
        private void SaveHashToFile(string text, bool toUpper)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();

                if (kcmbAlgorithimType.Text == "MD-5")
                {
                    dlg.Filter = "MD5 Hash Files|*.md5";

                    dlg.Title = "Save to File:";

                    dlg.FileName = $"{FileNameWithoutExtension} MD5 Hash";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        WriteToFile(dlg.FileName, text, toUpper);
                    }
                }
                else if (kcmbAlgorithimType.Text == "SHA-1")
                {
                    dlg.Filter = "SHA-1 Hash Files|*.sha1";

                    dlg.Title = "Save to File:";

                    dlg.FileName = $"{FileNameWithoutExtension} SHA1 Hash";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        WriteToFile(dlg.FileName, text, toUpper);
                    }
                }
                else if (kcmbAlgorithimType.Text == "SHA-256")
                {
                    dlg.Filter = "SHA-256 Hash Files|*.sha256";

                    dlg.Title = "Save to File:";

                    dlg.FileName = $"{FileNameWithoutExtension} SHA256 Hash";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        WriteToFile(dlg.FileName, text, toUpper);
                    }
                }
                else if (kcmbAlgorithimType.Text == "SHA-384")
                {
                    dlg.Filter = "SHA-384 Hash Files|*.sha384";

                    dlg.Title = "Save to File:";

                    dlg.FileName = $"{FileNameWithoutExtension} SHA384 Hash";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        WriteToFile(dlg.FileName, text, toUpper);
                    }
                }
                else if (kcmbAlgorithimType.Text == "SHA-512")
                {
                    dlg.Filter = "SHA-512 Hash Files|*.sha512";

                    dlg.Title = "Save to File:";

                    dlg.FileName = $"{FileNameWithoutExtension} SHA512 Hash";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        WriteToFile(dlg.FileName, text, toUpper);
                    }
                }
                else if (kcmbAlgorithimType.Text == "RIPEMD-160")
                {
                    dlg.Filter = "RIPEMD-160 Hash Files|*.ripemd160";

                    dlg.Title = "Save to File:";

                    dlg.FileName = $"{FileNameWithoutExtension} RIPEMD160 Hash";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        WriteToFile(dlg.FileName, text, toUpper);
                    }
                }
            }
            catch (Exception e)
            {
                KryptonMessageBox.Show($"An error has occurred: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WriteToFile(string fileName, string text, bool toUpper)
        {
            try
            {
                string pathToFile = Path.GetFullPath(fileName);

                using (StreamWriter writer = new StreamWriter(pathToFile))
                {
                    if (toUpper)
                    {
                        writer.Write(text.ToUpper());
                    }
                    else
                    {
                        writer.Write(text.ToLower());
                    }
                }
            }
            catch (Exception e)
            {
                KryptonMessageBox.Show($"An error has occurred: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

#if NETCOREAPP3_1_OR_GREATER
        private void HashFile(SafeNETCoreAndNewerSupportedHashAlgorithims hashType)
        {
            switch (hashType)
            {
                case SafeNETCoreAndNewerSupportedHashAlgorithims.MD5:
                    bgMD5Hash.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SafeNETCoreAndNewerSupportedHashAlgorithims.SHA1:
                    bgSHA1Hash.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SafeNETCoreAndNewerSupportedHashAlgorithims.SHA256:
                    bgSHA256Hash.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SafeNETCoreAndNewerSupportedHashAlgorithims.SHA384:
                    bgSHA384Hash.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SafeNETCoreAndNewerSupportedHashAlgorithims.SHA512:
                    bgSHA512Hash.RunWorkerAsync(ktxtFilePath.Text);
                    break;
            }
        }
#else
        private void HashFile(SupportedHashAlgorithims hashType)
        {
            switch (hashType)
            {
                case SupportedHashAlgorithims.MD5:
                    bgMD5Hash.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SupportedHashAlgorithims.SHA1:
                    bgSHA1Hash.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SupportedHashAlgorithims.SHA256:
                    bgSHA256Hash.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SupportedHashAlgorithims.SHA384:
                    bgSHA384Hash.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SupportedHashAlgorithims.SHA512:
                    bgSHA512Hash.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SupportedHashAlgorithims.RIPEMD160:
                    bgRIPEMD160Hash.RunWorkerAsync(ktxtFilePath.Text);
                    break;
            }
        }
#endif
        #endregion
    }
}