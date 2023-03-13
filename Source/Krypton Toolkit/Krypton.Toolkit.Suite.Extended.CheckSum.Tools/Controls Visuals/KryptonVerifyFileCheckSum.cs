using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.CheckSum.Tools
{
    public partial class KryptonVerifyFileCheckSum : KryptonForm
    {
        #region Instance Fields

        private readonly bool _useAPICodePackFeatures;

        private string _fileName;

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="KryptonVerifyFileCheckSum" /> class.</summary>
        /// <param name="useAPICodePackFeatures">The use API code pack features.</param>
        public KryptonVerifyFileCheckSum(bool? useAPICodePackFeatures)
        {
            InitializeComponent();

            CancelButton = kbtnCancel;

            kbtnCalculate.Text = KryptonManager.Strings.Cancel;

            _useAPICodePackFeatures = useAPICodePackFeatures ?? true;

            UpdateStatus(CheckSumStatus.Ready);
        }

        #endregion

        private void KryptonVerifyFileCheckSum_Load(object sender, EventArgs e)
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
                case CheckSumStatus.Invalid:
                    break;
                case CheckSumStatus.Valid:
                    break;
                case CheckSumStatus.Verifying:
                    break;
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

        private bool VerifyCheckSum(string fileCheckSum, string importedCheckSum) => fileCheckSum.Equals(importedCheckSum);

        private void ImportCheckSumFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    StreamReader reader = new(File.OpenRead(filePath));

                    ktxtVarifyCheckSum.Text = reader.ReadToEnd();

                    reader.Close();

                    reader.Dispose();

                    kbtnVerify.Enabled = true;
                }
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);
            }
        }

        private void kbtnVerify_Click(object sender, EventArgs e)
        {
            if (VerifyCheckSum(kwlHashOutput.Text, ktxtVarifyCheckSum.Text))
            {
                ktxtVarifyCheckSum.StateCommon.Border.Color1 = Color.Green;

                ktxtVarifyCheckSum.StateCommon.Border.Color2 = Color.Green;
            }
            else
            {
                ktxtVarifyCheckSum.StateCommon.Border.Color1 = Color.Red;

                ktxtVarifyCheckSum.StateCommon.Border.Color2 = Color.Red;
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

        private void bsaVerifyBrowse_Click(object sender, EventArgs e)
        {
            if (_useAPICodePackFeatures)
            {
                CommonOpenFileDialog cofd = new() { Title = @"Browse for a file:" };

                if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    if (cofd.FileName != null)
                    {
                        ImportCheckSumFromFile(Path.GetFullPath(cofd.FileName));
                    }
                }
            }
            else
            {
                OpenFileDialog ofd = new() { Title = @"Browse for a file:" };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (ofd.FileName != null)
                    {
                        ImportCheckSumFromFile(Path.GetFullPath(ofd.FileName));
                    }
                }
            }
        }
    }
}
