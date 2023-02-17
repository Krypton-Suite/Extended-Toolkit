#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

// ReSharper disable InconsistentNaming
// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable ArrangeRedundantParentheses
#pragma warning disable CS8622
#pragma warning disable CS8600
#pragma warning disable CS8602

namespace Krypton.Toolkit.Suite.Extended.CheckSum.Tools
{
    public class KryptonComputeFileCheckSumOld : KryptonForm
    {
        #region Design Code
        private StatusStrip statusStrip1;
        private ToolStripProgressBar tspbHashProgress;
        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonLabel kryptonLabel1;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonWrapLabel kwlHash;
        private KryptonButton kbtnCompute;
        private KryptonComboBox? kcmbAlgorithimType;
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
        private KryptonTextBox kbbFilePath;
        private ToolStripStatusLabel tsslStatus;

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(KryptonComputeFileCheckSumOld));
            statusStrip1 = new StatusStrip();
            tsslStatus = new ToolStripStatusLabel();
            tspbHashProgress = new ToolStripProgressBar();
            kryptonPanel1 = new KryptonPanel();
            kcbToggleCase = new KryptonCheckBox();
            kbtnSaveToFile = new KryptonButton();
            kbtnCancel = new KryptonButton();
            kryptonBorderEdge1 = new KryptonBorderEdge();
            kryptonPanel2 = new KryptonPanel();
            kbbFilePath = new KryptonBrowseBox();
            kryptonGroupBox1 = new KryptonGroupBox();
            kwlHash = new KryptonWrapLabel();
            kbtnCompute = new KryptonButton();
            kcmbAlgorithimType = new KryptonComboBox();
            kryptonLabel2 = new KryptonLabel();
            kryptonLabel1 = new KryptonLabel();
            bgMD5Hash = new BackgroundWorker();
            bgSHA1Hash = new BackgroundWorker();
            bgSHA256Hash = new BackgroundWorker();
            bgSHA384Hash = new BackgroundWorker();
            bgSHA512Hash = new BackgroundWorker();
            bgRIPEMD160Hash = new BackgroundWorker();
            statusStrip1.SuspendLayout();
            ((ISupportInitialize)(kryptonPanel1)).BeginInit();
            kryptonPanel1.SuspendLayout();
            ((ISupportInitialize)(kryptonPanel2)).BeginInit();
            kryptonPanel2.SuspendLayout();
            ((ISupportInitialize)(kryptonGroupBox1)).BeginInit();
            ((ISupportInitialize)(kryptonGroupBox1.Panel)).BeginInit();
            kryptonGroupBox1.Panel.SuspendLayout();
            kryptonGroupBox1.SuspendLayout();
            ((ISupportInitialize)(kcmbAlgorithimType)).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Font = new Font("Segoe UI", 9F);
            statusStrip1.Items.AddRange(new ToolStripItem[] {
            tsslStatus,
            tspbHashProgress});
            statusStrip1.Location = new Point(0, 258);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            statusStrip1.Size = new Size(705, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            tsslStatus.Name = "tsslStatus";
            tsslStatus.Size = new Size(690, 17);
            tsslStatus.Spring = true;
            tsslStatus.Text = "Ready";
            tsslStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tspbHashProgress
            // 
            tspbHashProgress.Name = "tspbHashProgress";
            tspbHashProgress.Size = new Size(100, 16);
            tspbHashProgress.Visible = false;
            // 
            // kryptonPanel1
            // 
            kryptonPanel1.Controls.Add(kcbToggleCase);
            kryptonPanel1.Controls.Add(kbtnSaveToFile);
            kryptonPanel1.Controls.Add(kbtnCancel);
            kryptonPanel1.Controls.Add(kryptonBorderEdge1);
            kryptonPanel1.Dock = DockStyle.Bottom;
            kryptonPanel1.Location = new Point(0, 208);
            kryptonPanel1.Name = "kryptonPanel1";
            kryptonPanel1.PanelBackStyle = PaletteBackStyle.PanelAlternate;
            kryptonPanel1.Size = new Size(705, 50);
            kryptonPanel1.TabIndex = 1;
            // 
            // kcbToggleCase
            // 
            kcbToggleCase.Location = new Point(14, 17);
            kcbToggleCase.Name = "kcbToggleCase";
            kcbToggleCase.Size = new Size(90, 20);
            kcbToggleCase.TabIndex = 4;
            kcbToggleCase.Values.Text = "Toggle &Case";
            kcbToggleCase.CheckedChanged += kcbToggleCase_CheckedChanged;
            // 
            // kbtnSaveToFile
            // 
            kbtnSaveToFile.CornerRoundingRadius = -1F;
            kbtnSaveToFile.Enabled = false;
            kbtnSaveToFile.Location = new Point(507, 12);
            kbtnSaveToFile.Name = "kbtnSaveToFile";
            kbtnSaveToFile.Size = new Size(90, 25);
            kbtnSaveToFile.TabIndex = 3;
            kbtnSaveToFile.Values.Text = "Save to &File";
            kbtnSaveToFile.Click += kbtnSaveToFile_Click;
            // 
            // kbtnCancel
            // 
            kbtnCancel.CornerRoundingRadius = -1F;
            kbtnCancel.DialogResult = DialogResult.Cancel;
            kbtnCancel.Location = new Point(603, 12);
            kbtnCancel.Name = "kbtnCancel";
            kbtnCancel.Size = new Size(90, 25);
            kbtnCancel.TabIndex = 2;
            kbtnCancel.Values.Text = "C&ancel";
            kbtnCancel.Click += kbtnCancel_Click;
            // 
            // kryptonBorderEdge1
            // 
            kryptonBorderEdge1.BorderStyle = PaletteBorderStyle.HeaderSecondary;
            kryptonBorderEdge1.Dock = DockStyle.Top;
            kryptonBorderEdge1.Location = new Point(0, 0);
            kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            kryptonBorderEdge1.Size = new Size(705, 1);
            kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            kryptonPanel2.Controls.Add(kbbFilePath);
            kryptonPanel2.Controls.Add(kryptonGroupBox1);
            kryptonPanel2.Controls.Add(kbtnCompute);
            kryptonPanel2.Controls.Add(kcmbAlgorithimType);
            kryptonPanel2.Controls.Add(kryptonLabel2);
            kryptonPanel2.Controls.Add(kryptonLabel1);
            kryptonPanel2.Dock = DockStyle.Fill;
            kryptonPanel2.Location = new Point(0, 0);
            kryptonPanel2.Name = "kryptonPanel2";
            kryptonPanel2.Size = new Size(705, 208);
            kryptonPanel2.TabIndex = 2;
            // 
            // kbbFilePath
            // 
            kbbFilePath.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            kbbFilePath.AutoCompleteSource = AutoCompleteSource.FileSystem;
            kbbFilePath.CueHint.CueHintText = "Type a file path here...";
            kbbFilePath.CueHint.Padding = new Padding(0);
            kbbFilePath.Location = new Point(82, 12);
            kbbFilePath.Name = "kbbFilePath";
            kbbFilePath.Size = new Size(614, 24);
            kbbFilePath.TabIndex = 11;
            // 
            // kryptonGroupBox1
            // 
            kryptonGroupBox1.Location = new Point(12, 98);
            kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            kryptonGroupBox1.Panel.Controls.Add(kwlHash);
            kryptonGroupBox1.Size = new Size(684, 95);
            kryptonGroupBox1.TabIndex = 10;
            kryptonGroupBox1.Values.Heading = "Calculated CheckSum";
            // 
            // kwlHash
            // 
            kwlHash.AutoSize = false;
            kwlHash.Dock = DockStyle.Fill;
            kwlHash.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            kwlHash.ForeColor = Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            kwlHash.LabelStyle = LabelStyle.NormalControl;
            kwlHash.Location = new Point(0, 0);
            kwlHash.Name = "kwlHash";
            kwlHash.Size = new Size(680, 71);
            kwlHash.StateCommon.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            kwlHash.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // kbtnCompute
            // 
            kbtnCompute.CornerRoundingRadius = -1F;
            kbtnCompute.Enabled = false;
            kbtnCompute.Location = new Point(255, 59);
            kbtnCompute.Name = "kbtnCompute";
            kbtnCompute.Size = new Size(90, 25);
            kbtnCompute.TabIndex = 9;
            kbtnCompute.Values.Text = "&Compute";
            kbtnCompute.Click += kbtnCompute_Click;
            // 
            // kcmbAlgorithimType
            // 
            kcmbAlgorithimType.CornerRoundingRadius = -1F;
            kcmbAlgorithimType.DropDownStyle = ComboBoxStyle.DropDownList;
            kcmbAlgorithimType.DropDownWidth = 121;
            kcmbAlgorithimType.Enabled = false;
            kcmbAlgorithimType.IntegralHeight = false;
            kcmbAlgorithimType.Location = new Point(127, 59);
            kcmbAlgorithimType.Name = "kcmbAlgorithimType";
            kcmbAlgorithimType.Size = new Size(121, 21);
            kcmbAlgorithimType.StateCommon.ComboBox.Content.TextH = PaletteRelativeAlign.Near;
            kcmbAlgorithimType.TabIndex = 8;
            kcmbAlgorithimType.SelectedIndexChanged += kcmbAlgorithimType_SelectedIndexChanged;
            kcmbAlgorithimType.TextChanged += kcmbAlgorithimType_TextChanged;
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.LabelStyle = LabelStyle.BoldControl;
            kryptonLabel2.Location = new Point(12, 59);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(108, 20);
            kryptonLabel2.TabIndex = 7;
            kryptonLabel2.Values.Text = "Algorithim Type:";
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.LabelStyle = LabelStyle.BoldControl;
            kryptonLabel1.Location = new Point(12, 12);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(64, 20);
            kryptonLabel1.TabIndex = 3;
            kryptonLabel1.Values.Text = "File Path:";
            // 
            // bgMD5Hash
            // 
            bgMD5Hash.WorkerReportsProgress = true;
            bgMD5Hash.WorkerSupportsCancellation = true;
            bgMD5Hash.DoWork += bgMD5Hash_DoWork;
            bgMD5Hash.ProgressChanged += ProgressChanged;
            bgMD5Hash.RunWorkerCompleted += RunWorkerCompleted;
            // 
            // bgSHA1Hash
            // 
            bgSHA1Hash.WorkerReportsProgress = true;
            bgSHA1Hash.WorkerSupportsCancellation = true;
            bgSHA1Hash.DoWork += bgSHA1Hash_DoWork;
            bgSHA1Hash.ProgressChanged += ProgressChanged;
            bgSHA1Hash.RunWorkerCompleted += RunWorkerCompleted;
            // 
            // bgSHA256Hash
            // 
            bgSHA256Hash.WorkerReportsProgress = true;
            bgSHA256Hash.WorkerSupportsCancellation = true;
            bgSHA256Hash.DoWork += bgSHA256Hash_DoWork;
            bgSHA256Hash.ProgressChanged += ProgressChanged;
            bgSHA256Hash.RunWorkerCompleted += RunWorkerCompleted;
            // 
            // bgSHA384Hash
            // 
            bgSHA384Hash.WorkerReportsProgress = true;
            bgSHA384Hash.WorkerSupportsCancellation = true;
            bgSHA384Hash.DoWork += bgSHA384Hash_DoWork;
            bgSHA384Hash.ProgressChanged += ProgressChanged;
            bgSHA384Hash.RunWorkerCompleted += RunWorkerCompleted;
            // 
            // bgSHA512Hash
            // 
            bgSHA512Hash.WorkerReportsProgress = true;
            bgSHA512Hash.WorkerSupportsCancellation = true;
            bgSHA512Hash.DoWork += bgSHA512Hash_DoWork;
            bgSHA512Hash.ProgressChanged += ProgressChanged;
            bgSHA512Hash.RunWorkerCompleted += RunWorkerCompleted;
            // 
            // bgRIPEMD160Hash
            // 
            bgRIPEMD160Hash.WorkerReportsProgress = true;
            bgRIPEMD160Hash.WorkerSupportsCancellation = true;
            bgRIPEMD160Hash.DoWork += bgRIPEMD160Hash_DoWork;
            bgRIPEMD160Hash.ProgressChanged += ProgressChanged;
            bgRIPEMD160Hash.RunWorkerCompleted += RunWorkerCompleted;
            // 
            // KryptonComputeFileCheckSum
            // 
            ClientSize = new Size(705, 280);
            Controls.Add(kryptonPanel2);
            Controls.Add(kryptonPanel1);
            Controls.Add(statusStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "KryptonComputeFileCheckSum";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Calculate CheckSum";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((ISupportInitialize)(kryptonPanel1)).EndInit();
            kryptonPanel1.ResumeLayout(false);
            kryptonPanel1.PerformLayout();
            ((ISupportInitialize)(kryptonPanel2)).EndInit();
            kryptonPanel2.ResumeLayout(false);
            kryptonPanel2.PerformLayout();
            ((ISupportInitialize)(kryptonGroupBox1.Panel)).EndInit();
            kryptonGroupBox1.Panel.ResumeLayout(false);
            ((ISupportInitialize)(kryptonGroupBox1)).EndInit();
            kryptonGroupBox1.ResumeLayout(false);
            ((ISupportInitialize)(kcmbAlgorithimType)).EndInit();
            ResumeLayout(false);
            PerformLayout();

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
        public KryptonComputeFileCheckSumOld()
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
                ExceptionCapture.CaptureException(ex);
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
                ExceptionCapture.CaptureException(e);
            }
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            if (bgMD5Hash.IsBusy || bgSHA1Hash.IsBusy || bgSHA256Hash.IsBusy || bgSHA384Hash.IsBusy || bgSHA512Hash.IsBusy || bgRIPEMD160Hash.IsBusy)
            {
                DialogResult result = KryptonMessageBox.Show("File hashing is still in progress.\nDo you want to cancel?", "Hashing in Progress", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

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

                using (HashAlgorithm hasher = RIPEMD160.Create())
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

        private void kcmbAlgorithimType_TextChanged(object sender, EventArgs e)
        {
            kbtnCancel.Enabled = string.IsNullOrWhiteSpace(kcmbAlgorithimType.Text);
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

                    dlg.Title = @"Save to File:";

                    dlg.FileName = $"{FileNameWithoutExtension} SHA256 Hash";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        WriteToFile(dlg.FileName, text, toUpper);
                    }
                }
                else if (kcmbAlgorithimType.Text == @"SHA-384")
                {
                    dlg.Filter = @"SHA-384 Hash Files|*.sha384";

                    dlg.Title = @"Save to File:";

                    dlg.FileName = $"{FileNameWithoutExtension} SHA384 Hash";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        WriteToFile(dlg.FileName, text, toUpper);
                    }
                }
                else if (kcmbAlgorithimType.Text == @"SHA-512")
                {
                    dlg.Filter = @"SHA-512 Hash Files|*.sha512";

                    dlg.Title = @"Save to File:";

                    dlg.FileName = $"{FileNameWithoutExtension} SHA512 Hash";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        WriteToFile(dlg.FileName, text, toUpper);
                    }
                }
                else if (kcmbAlgorithimType.Text == @"RIPEMD-160")
                {
                    dlg.Filter = @"RIPEMD-160 Hash Files|*.ripemd160";

                    dlg.Title = @"Save to File:";

                    dlg.FileName = $"{FileNameWithoutExtension} RIPEMD160 Hash";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        WriteToFile(dlg.FileName, text, toUpper);
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);
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
                ExceptionCapture.CaptureException(e);
            }
        }

#if NETCOREAPP3_1_OR_GREATER
        private void HashFile(SafeNETCoreAndNewerSupportedHashAlgorithims hashType)
        {
            switch (hashType)
            {
                case SafeNETCoreAndNewerSupportedHashAlgorithims.MD5:
                    bgMD5Hash.RunWorkerAsync(kbbFilePath.Text);
                    break;
                case SafeNETCoreAndNewerSupportedHashAlgorithims.SHA1:
                    bgSHA1Hash.RunWorkerAsync(kbbFilePath.Text);
                    break;
                case SafeNETCoreAndNewerSupportedHashAlgorithims.SHA256:
                    bgSHA256Hash.RunWorkerAsync(kbbFilePath.Text);
                    break;
                case SafeNETCoreAndNewerSupportedHashAlgorithims.SHA384:
                    bgSHA384Hash.RunWorkerAsync(kbbFilePath.Text);
                    break;
                case SafeNETCoreAndNewerSupportedHashAlgorithims.SHA512:
                    bgSHA512Hash.RunWorkerAsync(kbbFilePath.Text);
                    break;
            }
        }
#else
        private void HashFile(SupportedHashAlgorithims hashType)
        {
            switch (hashType)
            {
                case SupportedHashAlgorithims.MD5:
                    bgMD5Hash.RunWorkerAsync(kbbFilePath.Text);
                    break;
                case SupportedHashAlgorithims.SHA1:
                    bgSHA1Hash.RunWorkerAsync(kbbFilePath.Text);
                    break;
                case SupportedHashAlgorithims.SHA256:
                    bgSHA256Hash.RunWorkerAsync(kbbFilePath.Text);
                    break;
                case SupportedHashAlgorithims.SHA384:
                    bgSHA384Hash.RunWorkerAsync(kbbFilePath.Text);
                    break;
                case SupportedHashAlgorithims.SHA512:
                    bgSHA512Hash.RunWorkerAsync(kbbFilePath.Text);
                    break;
                case SupportedHashAlgorithims.RIPEMD160:
                    bgRIPEMD160Hash.RunWorkerAsync(kbbFilePath.Text);
                    break;
            }
        }
#endif
        #endregion
    }
}