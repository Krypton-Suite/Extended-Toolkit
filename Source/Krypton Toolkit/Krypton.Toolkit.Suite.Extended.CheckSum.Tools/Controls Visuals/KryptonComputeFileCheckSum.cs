namespace Krypton.Toolkit.Suite.Extended.CheckSum.Tools
{
    public partial class KryptonComputeFileCheckSum : KryptonForm
    {
        #region Instance Fields

        private readonly bool _useAPICodePackFeatures;

        private string _fileName;

        #endregion

        #region Identity

        public KryptonComputeFileCheckSum(bool? useAPICodePackFeatures)
        {
            InitializeComponent();

            CancelButton = kbtnCancel;

            kbtnCancel.Text = KryptonManager.Strings.Cancel;

            _useAPICodePackFeatures = useAPICodePackFeatures ?? true;

            UpdateStatus(CheckSumStatus.Ready);
        }

        #endregion

        #region Implementation

        private void KryptonComputeFileCheckSum_Load(object sender, EventArgs e)
        {
#if NETCOREAPP3_0_OR_GREATER
            foreach (string hash in Enum.GetNames(typeof(SafeNETCoreAndNewerSupportedHashAlgorithims)))
            {
                kcmbHashType.Items.Add(hash);
            }

            kcmbHashType.SelectedIndex = 0;

            kbtnCalculate.Enabled = true;
#else
            foreach (string hashType in Enum.GetNames(typeof(SupportedHashAlgorithims)))
            {
                kcmbHashType.Items.Add(hashType);
            }

            kcmbHashType.SelectedIndex = 0;

            kbtnCalculate.Enabled = true;
#endif
        }

        private void kchkToggleCasing_CheckedChanged(object sender, EventArgs e)
        {
            string tempHashString = kwlHashOutput.Text;

            if (kchkToggleCasing.Checked)
            {
                tempHashString.ToUpper();

                kwlHashOutput.Text = tempHashString;
            }
            else
            {
                tempHashString.ToLower();

                kwlHashOutput.Text = tempHashString;
            }
        }

        private void bsaBrowse_Click(object sender, EventArgs e)
        {
            if (_useAPICodePackFeatures)
            {
                CommonOpenFileDialog openFileDialog = new() { Title = @"Browse for a file:" };

                if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    if (openFileDialog.FileName != null)
                    {
                        ktxtFilePath.Text = Path.GetFullPath(openFileDialog.FileName);

                        _fileName = openFileDialog.FileName;
                    }
                }
            }
            else
            {
                OpenFileDialog openFileDialog = new() { Title = @"Browse for a file:" };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.FileName != null)
                    {
                        ktxtFilePath.Text = Path.GetFullPath(openFileDialog.FileName);

                        _fileName = openFileDialog.FileName;
                    }
                }
            }
        }

        private void UpdateStatus(CheckSumStatus status, string? extraText = null, string? hashType = null)
        {
            switch (status)
            {
                case CheckSumStatus.Canceled:
                    tslStatus.Text = @"Hash canceled ...";
                    break;
                case CheckSumStatus.Cancelling:
                    tslStatus.Text = $@"Cancelling hashing progress ...";
                    break;
                case CheckSumStatus.Computing:
                    if (extraText != null)
                    {
                        if (hashType != null)
                        {
                            tslStatus.Text = $@"Computing {hashType} hash for: {extraText}";
                        }
                        else
                        {
                            tslStatus.Text = $@"Computing hash for: {extraText}";
                        }
                    }
                    else
                    {
                        tslStatus.Text = $@"Computing hash...";
                    }

                    break;
                case CheckSumStatus.Ready:
                    tslStatus.Text = @"Ready...";
                    break;
                case CheckSumStatus.Saving:
                    break;
            }
        }

        private void kbtnSaveToFile_Click(object sender, EventArgs e) => SaveHashFile();

        private void SaveHashFile()
        {
            if (_useAPICodePackFeatures)
            {
                CommonSaveFileDialog saveFileDialog = new()
                {
                    Title = @"Save hash to:",
                    DefaultFileName = $@"Hash for {_fileName}"
                };

                saveFileDialog.Filters.Add(new CommonFileDialogFilter("Text Files", "*.txt"));

                if (saveFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    if (!File.Exists(Path.GetFullPath(saveFileDialog.FileName)))
                    {
                        File.Create(Path.GetFullPath(saveFileDialog.FileName));

                        StreamWriter writer = new(Path.GetFullPath(saveFileDialog.FileName));

                        if (!string.IsNullOrEmpty(kwlHashOutput.Text))
                        {
                            writer.Write(kwlHashOutput.Text);

                            writer.Flush();

                            writer.Dispose();

                            writer.Close();
                        }
                    }
                    else
                    {
                        StreamWriter writer = new(Path.GetFullPath(saveFileDialog.FileName));

                        if (!string.IsNullOrEmpty(kwlHashOutput.Text))
                        {
                            writer.Write(kwlHashOutput.Text);

                            writer.Flush();

                            writer.Dispose();

                            writer.Close();
                        }
                    }
                }
                else
                {
                    SaveFileDialog sfd = new()
                    {
                        Title = @"Save hash to:",
                        FileName = $@"Hash for {_fileName}",
                        Filter = @"Text Files|*.txt"
                    };

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (!File.Exists(Path.GetFullPath(sfd.FileName)))
                        {
                            File.Create(Path.GetFullPath(sfd.FileName));

                            StreamWriter writer = new(Path.GetFullPath(sfd.FileName));

                            if (!string.IsNullOrEmpty(kwlHashOutput.Text))
                            {
                                writer.Write(kwlHashOutput.Text);

                                writer.Flush();

                                writer.Dispose();

                                writer.Close();
                            }
                        }
                        else
                        {
                            StreamWriter writer = new(Path.GetFullPath(sfd.FileName));

                            if (!string.IsNullOrEmpty(kwlHashOutput.Text))
                            {
                                writer.Write(kwlHashOutput.Text);

                                writer.Flush();

                                writer.Dispose();

                                writer.Close();
                            }
                        }
                    }
                }
            }
        }

        private void CalculateHash()
        {
            try
            {
#if NETCOREAPP3_1_OR_GREATER
                HashFile((SafeNETCoreAndNewerSupportedHashAlgorithims)Enum.Parse(typeof(SafeNETCoreAndNewerSupportedHashAlgorithims), kcmbHashType.Text));
#else
                HashFile((SupportedHashAlgorithims)Enum.Parse(typeof(SupportedHashAlgorithims), kcmbHashType.Text));
#endif
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
                    bgwMD5.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SafeNETCoreAndNewerSupportedHashAlgorithims.SHA1:
                    bgwSHA1.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SafeNETCoreAndNewerSupportedHashAlgorithims.SHA256:
                    bgwSHA256.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SafeNETCoreAndNewerSupportedHashAlgorithims.SHA384:
                    bgwSHA384.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SafeNETCoreAndNewerSupportedHashAlgorithims.SHA512:
                    bgwSHA512.RunWorkerAsync(ktxtFilePath.Text);
                    break;
            }
        }
#else
        private void HashFile(SupportedHashAlgorithims hashType)
        {
            switch (hashType)
            {
                case SupportedHashAlgorithims.MD5:
                    bgwMD5.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SupportedHashAlgorithims.SHA1:
                    bgwSHA1.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SupportedHashAlgorithims.SHA256:
                    bgwSHA256.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SupportedHashAlgorithims.SHA384:
                    bgwSHA384.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SupportedHashAlgorithims.SHA512:
                    bgwSHA512.RunWorkerAsync(ktxtFilePath.Text);
                    break;
                case SupportedHashAlgorithims.RIPEMD160:
                    bgwRIPEMD160.RunWorkerAsync(ktxtFilePath.Text);
                    break;
            }
        }
#endif

        private void kbtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                CalculateHash();
            }
            catch (Exception exc)
            {
                ExceptionCapture.CaptureException(exc);
            }
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            if (bgwMD5.IsBusy || bgwSHA1.IsBusy || bgwSHA256.IsBusy || bgwSHA384.IsBusy || bgwSHA512.IsBusy || bgwRIPEMD160.IsBusy)
            {
                DialogResult result = KryptonMessageBox.Show("File hashing is still in progress.\nDo you want to cancel?", "Hashing in Progress", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bgwMD5.CancelAsync();

                        bgwMD5.Dispose();

                        bgwSHA1.CancelAsync();

                        bgwSHA1.Dispose();

                        bgwSHA256.CancelAsync();

                        bgwSHA256.Dispose();

                        bgwSHA384.CancelAsync();

                        bgwSHA384.Dispose();

                        bgwSHA512.CancelAsync();

                        bgwSHA512.Dispose();

                        bgwRIPEMD160.CancelAsync();

                        bgwRIPEMD160.Dispose();
                    }
                    catch (Exception exc)
                    {
                        ExceptionCapture.CaptureException(exc);
                    }
                }
            }
        }

        #endregion

        private void bgwMD5_DoWork(object sender, DoWorkEventArgs e)
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

                        bgwMD5.ReportProgress((int)((double)totalBytesRead / size * 100));
                    } while (bytesRead != 0);

                    hasher.TransformFinalBlock(buffer, 0, 0);

                    e.Result = HashingHelpers.BuildMD5HashString(hasher.Hash);
                }
            }
        }

        private void bgwSHA1_DoWork(object sender, DoWorkEventArgs e)
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

                        bgwSHA1.ReportProgress((int)((double)totalBytesRead / size * 100));
                    } while (bytesRead != 0);

                    hasher.TransformFinalBlock(buffer, 0, 0);

                    e.Result = HashingHelpers.BuildSHA1HashString(hasher.Hash);
                }
            }
        }

        private void bgwSHA256_DoWork(object sender, DoWorkEventArgs e)
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

                        bgwSHA256.ReportProgress((int)((double)totalBytesRead / size * 100));
                    } while (bytesRead != 0);

                    hasher.TransformFinalBlock(buffer, 0, 0);

                    e.Result = HashingHelpers.BuildSHA256HashString(hasher.Hash);
                }
            }
        }

        private void bgwSHA384_DoWork(object sender, DoWorkEventArgs e)
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

                        bgwSHA384.ReportProgress((int)((double)totalBytesRead / size * 100));
                    } while (bytesRead != 0);

                    hasher.TransformFinalBlock(buffer, 0, 0);

                    e.Result = HashingHelpers.BuildSHA384HashString(hasher.Hash);
                }
            }
        }

        private void bgwSHA512_DoWork(object sender, DoWorkEventArgs e)
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

                        bgwSHA512.ReportProgress((int)((double)totalBytesRead / size * 100));
                    } while (bytesRead != 0);

                    hasher.TransformFinalBlock(buffer, 0, 0);

                    e.Result = HashingHelpers.BuildSHA512HashString(hasher.Hash);
                }
            }
        }

        private void bgwRIPEMD160_DoWork(object sender, DoWorkEventArgs e)
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

                        bgwRIPEMD160.ReportProgress((int)((double)totalBytesRead / size * 100));
                    } while (bytesRead != 0);

                    hasher.TransformFinalBlock(buffer, 0, 0);

                    e.Result = HashingHelpers.BuildRIPEMD160HashString(hasher.Hash);
                }
            }
#endif
        }

        private void Calculation_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (_useAPICodePackFeatures && TaskbarManager.IsPlatformSupported)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);

                TaskbarManager.Instance.SetProgressValue(e.ProgressPercentage, null);
            }

            tspbCalculationProgress.Visible = true;

            tspbCalculationProgress.Value = e.ProgressPercentage;

            tslCalculationProgress.Text = $@"{e.ProgressPercentage}%";

            kwlHashOutput.Text = @"Please wait ...";

            UpdateStatus(CheckSumStatus.Computing);
        }

        private void Calculation_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_useAPICodePackFeatures && TaskbarManager.IsPlatformSupported)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);

                TaskbarManager.Instance.SetProgressValue(0, null);
            }

            tspbCalculationProgress.Visible = false;

            tspbCalculationProgress.Value = 0;

            tslCalculationProgress.Text = string.Empty;

            kwlHashOutput.Text = $@"{e.Result}";

            kbtnSaveToFile.Enabled = true;

            UpdateStatus(CheckSumStatus.Ready);
        }

        private void bsaReset_Click(object sender, EventArgs e) => ktxtFilePath.Text = string.Empty;
    }
}