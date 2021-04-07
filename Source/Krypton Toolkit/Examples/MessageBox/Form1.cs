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
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, MessageBoxButtons.OK, ExtendedMessageBoxIcon.NONE, messageboxTypeface: testFont);
                    }
                    else if (krbIconWarning.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, MessageBoxButtons.OK, ExtendedMessageBoxIcon.WARNING, messageboxTypeface: testFont);
                    }
                    else if (krbIconInformation.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, MessageBoxButtons.OK, ExtendedMessageBoxIcon.INFORMATION, messageboxTypeface: testFont);
                    }
                    else if (krbIconError.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, MessageBoxButtons.OK, ExtendedMessageBoxIcon.ERROR, messageboxTypeface: testFont);
                    }
                    else if (krbIconQuestion.Checked)
                    {
                        KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, MessageBoxButtons.OK, ExtendedMessageBoxIcon.QUESTION, messageboxTypeface: testFont);
                    }
                    else if (krbIconCustom.Checked)
                    {
                        if (!string.IsNullOrEmpty(klblCustomIconPath.Text))
                        {
                            KryptonMessageBoxExtended.Show(ktxtMessage.Text, ktxtCaption.Text, MessageBoxButtons.OK, ExtendedMessageBoxIcon.CUSTOM, messageboxTypeface: testFont, customMessageBoxIcon: new Bitmap(Image.FromFile(klblCustomIconPath.Text)));
                        }
                    }
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
    }
}
