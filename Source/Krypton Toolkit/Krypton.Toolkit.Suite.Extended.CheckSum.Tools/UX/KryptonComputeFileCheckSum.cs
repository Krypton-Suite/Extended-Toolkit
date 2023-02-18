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

// ReSharper disable ReturnValueOfPureMethodIsNotUsed
#pragma warning disable CS8602
namespace Krypton.Toolkit.Suite.Extended.CheckSum.Tools
{
    public partial class KryptonComputeFileCheckSum : KryptonForm
    {
        #region Instance Fields

        private readonly bool _useWindowsAPICodePackFeatures;

        private string _fileName;

        private string _filePath;

        private string _fileNameWithoutExtension;

        #endregion

        #region Public

        public string FileName { get => _fileName; private set => _fileName = value; }

        public string FilePath { get => _filePath; set => _filePath = value; }

        public string FileNameWithoutExtension { get => _fileNameWithoutExtension; private set => _fileNameWithoutExtension = value; }

        #endregion

        #region Identity

        public KryptonComputeFileCheckSum(bool? useWindowsAPICodePackFeatures, string? filePath)
        {
            InitializeComponent();

            Startup();

            _useWindowsAPICodePackFeatures = useWindowsAPICodePackFeatures ?? true;

            _filePath = filePath ?? string.Empty;

            if (!string.IsNullOrEmpty(_filePath))
            {
                ktxtFilePath.Text = _filePath;
            }
        }

        #endregion

        #region Implementation

        private void Startup()
        {
            kbtnCancel.Text = KryptonManager.Strings.Cancel;

#if NETCOREAPP3_1_OR_GREATER
            foreach (string type in Enum.GetNames(typeof(SafeNETCoreAndNewerSupportedHashAlgorithims)))
            {
                kcmbHashTypes.Items.Add(type);
            }
#else
            foreach (string type in Enum.GetNames(typeof(SupportedHashAlgorithims)))
            {
                kcmbHashTypes.Items.Add(type);
            }
#endif

            kcmbHashTypes.SelectedIndex = 0;
        }

        private void ComputeCheckSum()
        {
            try
            {
                UpdateStatus($"Computing hash for: {FileName}");

                tspbHashingProgress.Visible = true;

                kbtnCompute.Enabled = false;

                CalculateHash(kcmbHashTypes.Text);
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(ex);
            }
        }

        private void ToggleHashCasing(bool upperCase)
        {
            string temporaryHashString = kwlHashOutput.Text;

            if (!string.IsNullOrEmpty(temporaryHashString))
            {
                if (upperCase)
                {
                    temporaryHashString.ToUpper();

                    kwlHashOutput.Text = temporaryHashString;
                }
                else
                {
                    temporaryHashString.ToLower();

                    kwlHashOutput.Text += temporaryHashString;
                }
            }
        }

        private void CalculateHash(string hashType)
        {
            try
            {
#if NETCOREAPP3_1_OR_GREATER
                SafeNETCoreAndNewerSupportedHashAlgorithims algorithim =
                    (SafeNETCoreAndNewerSupportedHashAlgorithims)Enum.Parse(
                        typeof(SafeNETCoreAndNewerSupportedHashAlgorithims), hashType);

                HashFile(algorithim);
#else
                SupportedHashAlgorithims algorithim =
                    (SupportedHashAlgorithims)Enum.Parse(typeof(SupportedHashAlgorithims), hashType);

                HashFile(algorithim);
#endif
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);
            }
        }

#if NETCOREAPP3_1_OR_GREATER
        private void HashFile(SafeNETCoreAndNewerSupportedHashAlgorithims algorithim)
        {
            switch (algorithim)
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
                default:
                    throw new ArgumentOutOfRangeException(nameof(algorithim), algorithim, null);
            }
        }
#else
        private void HashFile(SupportedHashAlgorithims algorithim)
        {
            switch (algorithim)
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
                default:
                    throw new ArgumentOutOfRangeException(nameof(algorithim), algorithim, null);
            }
        }
#endif

        private void CancelHashing()
        {
#if NETCOREAPP3_1_OR_GREATER
            if (bgwMD5.IsBusy || bgwSHA1.IsBusy || bgwSHA256.IsBusy || bgwSHA384.IsBusy || bgwSHA512.IsBusy)
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
                    }
                    catch (Exception exc)
                    {
                        ExceptionCapture.CaptureException(exc);
                    }
                }
            }
#else
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
#endif
        }

        private void UpdateStatus(string message) => tslStatus.Text = message;

        private void SaveHashToFile(string text, bool toUpper)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();

                if (kcmbHashTypes.Text == @"MD5")
                {
                    dlg.Filter = @"MD5 Hash Files|*.md5";

                    dlg.Title = @"Save to File:";

                    dlg.FileName = $"{FileNameWithoutExtension} MD5 Hash";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        WriteToFile(dlg.FileName, text, toUpper);
                    }
                }
                else if (kcmbHashTypes.Text == @"SHA1")
                {
                    dlg.Filter = @"SHA-1 Hash Files|*.sha1";

                    dlg.Title = @"Save to File:";

                    dlg.FileName = $"{FileNameWithoutExtension} SHA1 Hash";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        WriteToFile(dlg.FileName, text, toUpper);
                    }
                }
                else if (kcmbHashTypes.Text == @"SHA256")
                {
                    dlg.Filter = @"SHA-256 Hash Files|*.sha256";

                    dlg.Title = @"Save to File:";

                    dlg.FileName = $"{FileNameWithoutExtension} SHA256 Hash";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        WriteToFile(dlg.FileName, text, toUpper);
                    }
                }
                else if (kcmbHashTypes.Text == @"SHA384")
                {
                    dlg.Filter = @"SHA-384 Hash Files|*.sha384";

                    dlg.Title = @"Save to File:";

                    dlg.FileName = $"{FileNameWithoutExtension} SHA384 Hash";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        WriteToFile(dlg.FileName, text, toUpper);
                    }
                }
                else if (kcmbHashTypes.Text == @"SHA512")
                {
                    dlg.Filter = @"SHA-512 Hash Files|*.sha512";

                    dlg.Title = @"Save to File:";

                    dlg.FileName = $"{FileNameWithoutExtension} SHA512 Hash";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        WriteToFile(dlg.FileName, text, toUpper);
                    }
                }
                else if (kcmbHashTypes.Text == @"RIPEMD160")
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

        #region MD5 Worker

        private void bgwMD5_DoWork(object sender, DoWorkEventArgs e)
        {
            string? filePath = e.Argument.ToString();

            byte[] buffer;

            int bytesRead;

            long size, totalBytesRead = 0;

            if (filePath != null)
            {
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

            UpdateStatus($"Computing hash for: {FileName}");
        }

        #endregion

        #region SHA-1 Worker

        private void bgwSHA1_DoWork(object sender, DoWorkEventArgs e)
        {
            string? filePath = e.Argument.ToString();

            byte[] buffer;

            int bytesRead;

            long size, totalBytesRead = 0;

            if (filePath != null)
            {
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
        }

        #endregion

        #region SHA-256 Worker

        private void bgwSHA256_DoWork(object sender, DoWorkEventArgs e)
        {
            string? filePath = e.Argument.ToString();

            byte[] buffer;

            int bytesRead;

            long size, totalBytesRead = 0;

            if (filePath != null)
            {
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
        }

        #endregion

        #region SHA-384 Worker

        private void bgwSHA384_DoWork(object sender, DoWorkEventArgs e)
        {
            string? filePath = e.Argument.ToString();

            byte[] buffer;

            int bytesRead;

            long size, totalBytesRead = 0;

            if (filePath != null)
            {
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
        }

        #endregion

        #region SHA-512 Worker

        private void bgwSHA512_DoWork(object sender, DoWorkEventArgs e)
        {
            string? filePath = e.Argument.ToString();

            byte[] buffer;

            int bytesRead;

            long size, totalBytesRead = 0;

            if (filePath != null)
            {
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
        }

        #endregion

        #region RIPEMD-160 Worker

        private void bgwRIPEMD160_DoWork(object sender, DoWorkEventArgs e)
        {
#if !NETCOREAPP3_1_OR_GREATER
            string? filePath = e.Argument.ToString();

            byte[] buffer;

            int bytesRead;

            long size, totalBytesRead = 0;

            if (filePath != null)
            {
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

                            bgwRIPEMD160.ReportProgress((int)((double)totalBytesRead / size * 100));
                        } while (bytesRead != 0);

                        hasher.TransformFinalBlock(buffer, 0, 0);

                        e.Result = HashingHelpers.BuildRIPEMD160HashString(hasher.Hash);
                    }
                }
            }
#endif
        }

        #endregion

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            kwlHashOutput.Text = @"Please wait ...";

            tspbHashingProgress.Value = e.ProgressPercentage;

            tslHashingProgressPercentageText.Text = $@"{e.ProgressPercentage}%";

            if (_useWindowsAPICodePackFeatures)
            {
                if (TaskbarManager.IsPlatformSupported)
                {
                    TaskbarManager.Instance.SetProgressValue(e.ProgressPercentage, 100);
                }
            }
        }

        private void Worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void kbtnCancel_Click(object sender, EventArgs e) => CancelHashing();

        private void kbtnSaveToFile_Click(object sender, EventArgs e) => SaveHashToFile(kwlHashOutput.Text, kchkToggleCasing.Checked);

        private void kbtnCompute_Click(object sender, EventArgs e) => ComputeCheckSum();

        private void kchkToggleCasing_CheckedChanged(object sender, EventArgs e) => ToggleHashCasing(kchkToggleCasing.Checked);

        #endregion
    }
}
