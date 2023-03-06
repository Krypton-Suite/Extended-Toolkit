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

        public KryptonVerifyFileCheckSum(bool? useAPICodePackFeatures)
        {
            InitializeComponent();

            CancelButton = kbtnCancel;

            kbtnCalculate.Text = KryptonManager.Strings.Cancel;

            _useAPICodePackFeatures = useAPICodePackFeatures ?? true;

            UpdateStatus(CheckSumStatus.Ready);
        }

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
                case CheckSumStatus.Saving:
                    break;
            }
        }
    }
}
