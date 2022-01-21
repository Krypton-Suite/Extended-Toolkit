using System;
using System.Windows.Forms;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Wizard;

namespace Wizard
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kawExample_Finish(object sender, EventArgs e)
        {
            DialogResult result = KryptonMessageBox.Show("You have clicked finish!", "Finish Button Pressed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                Close();
            }
        }

        private void kawExample_Cancel(object sender, EventArgs e)
        {
            DialogResult result = KryptonMessageBox.Show("You have clicked cancel!", "Cancel Button Pressed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                Close();
            }
        }

        private void kawExample_Help(object sender, EventArgs e)
        {

        }

        private void kradDefaultLayout_CheckedChanged(object sender, EventArgs e)
        {
            kawExample.ButtonLayout = ButtonLayoutKind.DEFAULT;

            kchkCancelButton.Checked = kchkHelpButton.Checked = kchkFinishButton.Checked = true;
        }

        private void kradOffice97Layout_CheckedChanged(object sender, EventArgs e)
        {
            kawExample.ButtonLayout = ButtonLayoutKind.OFFICE97;

            kchkCancelButton.Checked = kchkHelpButton.Checked = kchkFinishButton.Checked = true;
        }

        private void kchkHelpButton_CheckedChanged(object sender, EventArgs e)
        {
            kawExample.HelpButton = kchkHelpButton.Checked;
        }

        private void kchkCancelButton_CheckedChanged(object sender, EventArgs e)
        {
            kawExample.CancelButton = kchkCancelButton.Checked;
        }

        private void kchkFinishButton_CheckedChanged(object sender, EventArgs e)
        {
            kawExample.FinishButton = kchkFinishButton.Checked;
        }
    }
}
