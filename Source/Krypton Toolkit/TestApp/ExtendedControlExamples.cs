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

namespace TestApp
{
    public partial class ExtendedControlExamples : KryptonForm
    {
        public ExtendedControlExamples()
        {
            InitializeComponent();
        }

        private void kkTest1_ValueChanged(object sender, Krypton.Toolkit.Suite.Extended.Controls.KnobValueChangedEventArgs e)
        {
            kryptonProgressBarExtendedVersion11.Value = e.Value;

            kryptonProgressBarExtendedVersion11.DisplayText = $"{e.Value}%";
        }

        private void kkTest2_ValueChanged(object sender, Krypton.Toolkit.Suite.Extended.Controls.KnobValueChangedEventArgs e)
        {
            kryptonProgressBarExtendedVersion21.Value = e.Value;
        }

        private void kcbReset_CheckedChanged(object sender, EventArgs e)
        {
            kbbTest.ShowResetButton = kcbReset.Checked;
        }

        private void kcbFolderPicker_CheckedChanged(object sender, EventArgs e)
        {
            kbbTest.IsFolderPicker = kcbFolderPicker.Checked;
        }

        private void kcbExpandedMode_CheckedChanged(object sender, EventArgs e)
        {
            kbbTest.IsExpandedMode = kcbExpandedMode.Checked;
        }

        private void kcbSaveDialog_CheckedChanged(object sender, EventArgs e)
        {
            kbbTest.UseSaveDialog = kcbSaveDialog.Checked;
        }

        private void kcmbAlignment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
