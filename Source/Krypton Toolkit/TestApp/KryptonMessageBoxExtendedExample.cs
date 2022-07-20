using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Messagebox;

namespace TestApp
{
    public partial class KryptonMessageBoxExtendedExample : KryptonForm
    {
        #region Instance Fields

        private ExtendedMessageBoxDefaultButton _defaultButton = ExtendedMessageBoxDefaultButton.Button4;

        private MessageBoxButtons _messageBoxButtons = MessageBoxButtons.OK;

        private MessageBoxOptions _options = 0;

        private HelpNavigator _helpNavigator = 0;

        private ExtendedKryptonMessageBoxIcon _icon = ExtendedKryptonMessageBoxIcon.NONE;

        private Image _customImage = null;

        private Font _customFont = new Font("Segoe UI", 8.25F);

        #endregion

        public KryptonMessageBoxExtendedExample()
        {
            InitializeComponent();
        }

        private void kbtnDefineFont_Click(object sender, EventArgs e)
        {
            KryptonFontDialog dlg = new KryptonFontDialog()
            {
                Font = new Font("Segoe UI", 8.25F)
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _customFont = dlg.Font;
            }
        }

        private void KryptonMessageBoxExtendedExample_Load(object sender, EventArgs e)
        {
            if (_customFont != null)
            {
                kwlDefinedFont.Text = $"Selected font: {_customFont}";
            }
        }

        private void icon_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNone.Checked)
            {
                _icon = ExtendedKryptonMessageBoxIcon.NONE;
            }
            else if (krbCustom.Checked)
            {
                _icon = ExtendedKryptonMessageBoxIcon.CUSTOM;
            }
            else if (radioButtonError.Checked)
            {
                _icon = ExtendedKryptonMessageBoxIcon.ERROR;
            }
            else if (radioButtonQuestion.Checked)
            {
                _icon = ExtendedKryptonMessageBoxIcon.QUESTION;
            }
            else if (radioButtonWarning.Checked)
            {
                _icon = ExtendedKryptonMessageBoxIcon.WARNING;
            }
            else if (radioButtonInformation.Checked)
            {
                _icon = ExtendedKryptonMessageBoxIcon.INFORMATION;
            }
            else if (radioButtonWinLogo.Checked)
            {
                _icon = ExtendedKryptonMessageBoxIcon.WINDOWSLOGO;
            }
        }

        private void buttons_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOK.Checked)
            {
                _messageBoxButtons = MessageBoxButtons.OK;
            }
            else if (radioButtonOKCancel.Checked)
            {
                _messageBoxButtons = MessageBoxButtons.OKCancel;
            }
            else if (radioButtonRetryCancel.Checked)
            {
                _messageBoxButtons = MessageBoxButtons.RetryCancel;
            }
            else if (radioButtonAbortRetryIgnore.Checked)
            {
                _messageBoxButtons = MessageBoxButtons.AbortRetryIgnore;
            }
            else if (radioButtonYesNo.Checked)
            {
                _messageBoxButtons = MessageBoxButtons.YesNo;
            }
            else if (radioButtonYesNoCancel.Checked)
            {
                _messageBoxButtons = MessageBoxButtons.YesNoCancel;
            }
        }

        private void defaultButton_CheckedChanged(object sender, EventArgs e)
        {
            if (krbDefaultButton1.Checked)
            {
                _defaultButton = ExtendedMessageBoxDefaultButton.Button1;
            }
            else if (krbDefaultButton2.Checked)
            {
                _defaultButton = ExtendedMessageBoxDefaultButton.Button2;
            }
            else if (krbDefaultButton3.Checked)
            {
                _defaultButton = ExtendedMessageBoxDefaultButton.Button3;
            }
            else if (krbDefaultButton4.Checked)
            {
                _defaultButton = ExtendedMessageBoxDefaultButton.Button4;
            }
        }

        private void messageBoxOptions_CheckedChanged(object sender, EventArgs e)
        {
            if (kchkMessageBoxOptionsDefaultDesktopOnly.Checked)
            {
                _options |= MessageBoxOptions.DefaultDesktopOnly;
            }
            else if (!kchkMessageBoxOptionsDefaultDesktopOnly.Checked)
            {
                _options &= ~MessageBoxOptions.DefaultDesktopOnly;
            }
            else if (kchkMessageBoxOptionsRightAlign.Checked)
            {
                _options |= MessageBoxOptions.RightAlign;
            }
            else if (!kchkMessageBoxOptionsRightAlign.Checked)
            {
                _options &= ~MessageBoxOptions.RightAlign;
            }
            else if (kchkMessageBoxOptionsRTLReading.Checked)
            {
                _options |= MessageBoxOptions.RtlReading;
            }
            else if (!kchkMessageBoxOptionsRTLReading.Checked)
            {
                _options &= ~MessageBoxOptions.RtlReading;
            }
            else if (kchkMessageBoxOptionsServiceNotification.Checked)
            {
                _options |= MessageBoxOptions.ServiceNotification;
            }
            else if (!kchkMessageBoxOptionsServiceNotification.Checked)
            {
                _options &= ~MessageBoxOptions.ServiceNotification;
            }
        }
    }
}
