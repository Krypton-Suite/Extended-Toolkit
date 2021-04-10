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
                    else if (krbIconWarning.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxIcon.WARNING, messageboxTypeface: testFont);
                    }
                    else if (krbIconInformation.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxIcon.INFORMATION, messageboxTypeface: testFont);
                    }
                    else if (krbIconError.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxIcon.ERROR, messageboxTypeface: testFont);
                    }
                    else if (krbIconQuestion.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxIcon.QUESTION, messageboxTypeface: testFont);
                    }
                    else if (krbIconHand.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxIcon.HAND, messageboxTypeface: testFont);
                    }
                    else if (krbIconStop.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxIcon.STOP, messageboxTypeface: testFont);
                    }
                    else if (krbIconCustom.Checked)
                    {
                        if (!string.IsNullOrEmpty(klblCustomIconPath.Text))
                        {
                            KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxIcon.CUSTOM, messageboxTypeface: testFont, customMessageBoxIcon: new Bitmap(Image.FromFile(klblCustomIconPath.Text)));
                        }
                        else
                        {
                            throw new ArgumentNullException();
                        }
                    }

                    #region Ok Button
                    if (krbIconNone.Checked && krbButtonsOk.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxIcon.NONE, messageboxTypeface: testFont);
                    }
                    else if (krbIconWarning.Checked && krbButtonsOk.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxIcon.WARNING, messageboxTypeface: testFont);
                    }
                    else if (krbIconInformation.Checked && krbButtonsOk.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxIcon.INFORMATION, messageboxTypeface: testFont);
                    }
                    else if (krbIconError.Checked && krbButtonsOk.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxIcon.ERROR, messageboxTypeface: testFont);
                    }
                    else if (krbIconQuestion.Checked && krbButtonsOk.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxIcon.QUESTION, messageboxTypeface: testFont);
                    }
                    else if (krbIconHand.Checked && krbButtonsOk.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxIcon.HAND, messageboxTypeface: testFont);
                    }
                    else if (krbIconStop.Checked && krbButtonsOk.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxIcon.STOP, messageboxTypeface: testFont);
                    }
                    else if (krbIconCustom.Checked && krbButtonsOk.Checked)
                    {
                        if (!string.IsNullOrEmpty(klblCustomIconPath.Text))
                        {
                            KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxIcon.CUSTOM, messageboxTypeface: testFont, customMessageBoxIcon: new Bitmap(Image.FromFile(klblCustomIconPath.Text)));
                        }
                        else
                        {
                            throw new ArgumentNullException();
                        }
                    }
                    #endregion

                    #region Abort Retry Ignore Button
                    else if (krbIconNone.Checked && krbButtonsAbortRetryIgnore.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.ABORTRETRYIGNORE, ExtendedMessageBoxIcon.NONE, messageboxTypeface: testFont);
                    }
                    else if (krbIconWarning.Checked && krbButtonsAbortRetryIgnore.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.ABORTRETRYIGNORE, ExtendedMessageBoxIcon.WARNING, messageboxTypeface: testFont);
                    }
                    else if (krbIconInformation.Checked && krbButtonsAbortRetryIgnore.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.ABORTRETRYIGNORE, ExtendedMessageBoxIcon.INFORMATION, messageboxTypeface: testFont);
                    }
                    else if (krbIconError.Checked && krbButtonsAbortRetryIgnore.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.ABORTRETRYIGNORE, ExtendedMessageBoxIcon.ERROR, messageboxTypeface: testFont);
                    }
                    else if (krbIconQuestion.Checked && krbButtonsAbortRetryIgnore.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.ABORTRETRYIGNORE, ExtendedMessageBoxIcon.QUESTION, messageboxTypeface: testFont);
                    }
                    else if (krbIconHand.Checked && krbButtonsAbortRetryIgnore.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.ABORTRETRYIGNORE, ExtendedMessageBoxIcon.HAND, messageboxTypeface: testFont);
                    }
                    else if (krbIconStop.Checked && krbButtonsAbortRetryIgnore.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.ABORTRETRYIGNORE, ExtendedMessageBoxIcon.STOP, messageboxTypeface: testFont);
                    }
                    else if (krbIconCustom.Checked && krbButtonsAbortRetryIgnore.Checked)
                    {
                        if (!string.IsNullOrEmpty(klblCustomIconPath.Text))
                        {
                            KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, ExtendedMessageBoxButtons.ABORTRETRYIGNORE, ExtendedMessageBoxIcon.CUSTOM, messageboxTypeface: testFont, customMessageBoxIcon: new Bitmap(Image.FromFile(klblCustomIconPath.Text)));
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
    }
}
