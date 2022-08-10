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
    public partial class MessageBoxExample : KryptonForm
    {
        public MessageBoxExample()
        {
            InitializeComponent();
        }

        private void kbtnQuickTest_Click(object sender, EventArgs e)
        {
            KryptonMessageBoxManager manager = new()
            {
                Text = @"This is an example message box.",
                CaptionText = @"Example",
                Owner = this,
                ShowCtrlCopy = false,
                ShowHelpButton = false,
                UseMoreDetailsUI = true,
                MessageBoxButtons = ExtendedMessageBoxButtons.OK,
                MessageBoxIcon = ExtendedKryptonMessageBoxIcon.Information,
                DefaultButton = KryptonMessageBoxDefaultButton.Button4,
                Options = MessageBoxOptions.DefaultDesktopOnly,
                MessageBoxTypeface = new Font("Segoe UI", 12F),
                MaximumMoreDetailsDropDownHeight = 250,
                CustomImageIcon = null,
                HelpFilePath = null,
                OptionalCheckBoxText = null,
                MoreDetailsText = @"Does this work?",
                CollapseText = @"Co&llapse",
                ExpandText = @"E&xpand",
                Parameters = null,
                HelpNavigator = 0,
            };

            manager.ShowMessageBox();
        }
    }
}
