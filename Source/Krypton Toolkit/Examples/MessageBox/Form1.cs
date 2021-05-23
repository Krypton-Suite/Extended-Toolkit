using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Messagebox;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MessageBox
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kbtnTest_Click(object sender, EventArgs e)
        {
            /*
            if (kchkDefineTypeface.Checked)
            {
                FontDialog dialog = new FontDialog();

                Font testFont = null;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    testFont = dialog.Font;

                    if (krbIconNone.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.OK;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.NONE;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconWarning.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.OK;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.WARNING;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconInformation.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.OK;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.INFORMATION;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconError.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.OK;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.ERROR;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconQuestion.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.OK;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.QUESTION;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconHand.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.OK;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.HAND;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconStop.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.OK;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.STOP;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconCustom.Checked)
                    {
                        if (!MissingFrameWorkAPIs.IsNullOrWhiteSpace(klblCustomIconPath.Text))
                        {
                            kmbc.MessageBoxContentText = ktxtMessage.Text;

                            kmbc.MessageBoxCaption = ktxtCaption.Text;

                            kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.OK;

                            kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.CUSTOM;

                            kmbc.CustomMessageBoxIcon = new Bitmap(klblCustomIconPath.Text);

                            kmbc.MessageBoxTypeface = testFont;

                            kmbc.DisplayMessageBox();
                        }
                        else
                        {
                            throw new ArgumentNullException();
                        }
                    }

                    #region Ok Button
                    if (krbIconNone.Checked && krbButtonsOk.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.OK;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.NONE;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconWarning.Checked && krbButtonsOk.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.OK;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.WARNING;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconInformation.Checked && krbButtonsOk.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.OK;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.INFORMATION;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconError.Checked && krbButtonsOk.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.OK;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.ERROR;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconQuestion.Checked && krbButtonsOk.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.OK;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.QUESTION;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconHand.Checked && krbButtonsOk.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.OK;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.HAND;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconStop.Checked && krbButtonsOk.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.OK;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.STOP;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconCustom.Checked && krbButtonsOk.Checked)
                    {
                        if (!MissingFrameWorkAPIs.IsNullOrWhiteSpace(klblCustomIconPath.Text))
                        {
                            kmbc.MessageBoxContentText = ktxtMessage.Text;

                            kmbc.MessageBoxCaption = ktxtCaption.Text;

                            kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.OK;

                            kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.CUSTOM;

                            kmbc.CustomMessageBoxIcon = new Bitmap(klblCustomIconPath.Text);

                            kmbc.MessageBoxTypeface = testFont;

                            kmbc.DisplayMessageBox();
                        }
                        else
                        {
                            throw new ArgumentNullException();
                        }
                    }
                    #endregion

                    #region Abort Retry Ignore Button
                    if (krbIconNone.Checked && krbButtonsAbortRetryIgnore.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.ABORTRETRYIGNORE;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.NONE;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconWarning.Checked && krbButtonsAbortRetryIgnore.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.ABORTRETRYIGNORE;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.WARNING;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconInformation.Checked && krbButtonsAbortRetryIgnore.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.ABORTRETRYIGNORE;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.INFORMATION;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconError.Checked && krbButtonsAbortRetryIgnore.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.ABORTRETRYIGNORE;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.ERROR;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconQuestion.Checked && krbButtonsAbortRetryIgnore.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.ABORTRETRYIGNORE;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.QUESTION;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconHand.Checked && krbButtonsAbortRetryIgnore.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.ABORTRETRYIGNORE;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.HAND;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconStop.Checked && krbButtonsAbortRetryIgnore.Checked)
                    {
                        kmbc.MessageBoxContentText = ktxtMessage.Text;

                        kmbc.MessageBoxCaption = ktxtCaption.Text;

                        kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.ABORTRETRYIGNORE;

                        kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.STOP;

                        kmbc.MessageBoxTypeface = testFont;

                        kmbc.DisplayMessageBox();
                    }
                    if (krbIconCustom.Checked && krbButtonsAbortRetryIgnore.Checked)
                    {
                        if (!MissingFrameWorkAPIs.IsNullOrWhiteSpace(klblCustomIconPath.Text))
                        {
                            kmbc.MessageBoxContentText = ktxtMessage.Text;

                            kmbc.MessageBoxCaption = ktxtCaption.Text;

                            kmbc.MessageBoxButtons = ExtendedMessageBoxButtons.ABORTRETRYIGNORE;

                            kmbc.MessageBoxIcon = ExtendedMessageBoxIcon.CUSTOM;

                            kmbc.CustomMessageBoxIcon = new Bitmap(klblCustomIconPath.Text);

                            kmbc.MessageBoxTypeface = testFont;

                            kmbc.DisplayMessageBox();
                        }
                        else
                        {
                            throw new ArgumentNullException();
                        }
                    }
                    #endregion
                }
            }
            else
            {

            }
            */

                kmbc.DisplayMessageBox();
        }

        private void krbIconCustom_CheckedChanged(object sender, EventArgs e)
        {
            kbtnBrowseForCustomIcon.Enabled = krbIconCustom.Checked;

            klblCustomIconPath.Enabled = krbIconCustom.Checked;
        }

        private void kchkShowOptionalCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void kbtnBrowseForCustomIcon_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Filter = "Portable Network Graphics (*.png) | *.png";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                klblCustomIconPath.Text = Path.GetFullPath(fileDialog.FileName);
            }
        }

        private void kryptonMessageBoxConfigurator1_ShowMessageBox(object sender, ShowMessageBoxEventArgs e)
        {

        }

        private void kbtnTestConfigurator_Click(object sender, EventArgs e)
        {
            //kryptonMessageBoxConfigurator1.DisplayMessageBox();
        }

        private void kchkFadeMessageBox_CheckedChanged(object sender, EventArgs e)
        {
            klblFadeSleepTimer.Enabled = kchkFadeMessageBox.Checked;

            knudFadeSleepTimerValue.Enabled = kchkFadeMessageBox.Checked;
        }
    }
}
