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

using Microsoft.WindowsAPICodePack.Dialogs;

namespace TestApp
{
    public partial class KryptonMessageBoxExtendedExample : KryptonForm
    {
        #region Instance Fields

        private Color _messageTextColour;

        private Color[] _buttonTextColours = new Color[4];

        private ExtendedMessageBoxDefaultButton _defaultButton = ExtendedMessageBoxDefaultButton.Button4;

        private ExtendedMessageBoxButtons _messageBoxButtons = ExtendedMessageBoxButtons.OK;

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
                Font = new Font("Segoe UI", 8.25F),
                ShowColor = false
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _customFont = dlg.Font;

                kwlDefinedFont.Text = $"Selected font: {dlg.Font}";
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

            EnableCustomImageUI(krbCustom.Checked);
        }

        private void buttons_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOK.Checked)
            {
                _messageBoxButtons = ExtendedMessageBoxButtons.OK;
            }
            else if (radioButtonOKCancel.Checked)
            {
                _messageBoxButtons = ExtendedMessageBoxButtons.OKCANCEL;
            }
            else if (radioButtonRetryCancel.Checked)
            {
                _messageBoxButtons = ExtendedMessageBoxButtons.RETRYCANCEL;
            }
            else if (radioButtonAbortRetryIgnore.Checked)
            {
                _messageBoxButtons = ExtendedMessageBoxButtons.ABORTRETRYIGNORE;
            }
            else if (radioButtonYesNo.Checked)
            {
                _messageBoxButtons = ExtendedMessageBoxButtons.YESNO;
            }
            else if (radioButtonYesNoCancel.Checked)
            {
                _messageBoxButtons = ExtendedMessageBoxButtons.YESNOCANCEL;
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

        private void EnableCustomImageUI(bool enabled)
        {
            ktxtCustomImagePath.Enabled = enabled;

            kbtnBrowseForCustomImagePath.Enabled = enabled;
        }

        private void kbtnBrowseForCustomImagePath_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();

            cofd.Filters.Add(CommonFileDialogStandardFilters.PictureFiles);

            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                ktxtCustomImagePath.Text = Path.GetFullPath(cofd.FileName);
            }
        }

        private void kbtnShow_Click(object sender, EventArgs e)
        {
            KryptonMessageBoxExtended.Show(this, ktxtMessageText.Text, ktxtCaption.Text,
                                           _messageBoxButtons, _icon, _defaultButton,
                                           _options, "", _helpNavigator, null, 
                                           false, false, _customFont,
                                           _customImage, false, _messageTextColour, 
                                           _buttonTextColours);
        }
    }
}
