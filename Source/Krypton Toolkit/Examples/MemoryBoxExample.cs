using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Krypton.Toolkit.Suite.Extended.Memory.Box;

using Microsoft.WindowsAPICodePack.Dialogs;

namespace Examples
{
    public partial class MemoryBoxExample : KryptonForm
    {
        #region Instance Fields

        private string _title;

        private string _messageText;

        private string _iconPath;

        private KryptonMemoryBoxIcon _icon = KryptonMemoryBoxIcon.None;

        private KryptonMemoryBoxDefaultButton _defaultButton = KryptonMemoryBoxDefaultButton.ButtonOne;

        private KryptonMemoryBoxDialogResult _dialogResult = KryptonMemoryBoxDialogResult.Yes;

        #endregion

        public MemoryBoxExample()
        {
            InitializeComponent();
        }

        private void ShowBox()
        {
            KryptonMemoryBoxDialogResult result = KryptonMemoryBox.Show(ktxtTitle.Text, ktxtMessageContent.Text, _icon,
                _iconPath, _defaultButton, _dialogResult);

            kwlMemoryBoxResult.Text = $@"Memory Box Result = {result}";
        }

        private void kbtnShow_Click(object sender, EventArgs e) => ShowBox();

        private void MemoryBoxExample_Load(object sender, EventArgs e)
        {
            foreach (string icon in Enum.GetNames(typeof(KryptonMemoryBoxIcon)))
            {
                kcmbMessageBoxIcon.Items.Add(icon);
            }

            kcmbMessageBoxIcon.SelectedIndex = 1;

            foreach (string button in Enum.GetNames(typeof(KryptonMemoryBoxDefaultButton)))
            {
                kcmbMemoryBoxDefaultButton.Items.Add(button);
            }

            kcmbMemoryBoxDefaultButton.SelectedIndex = 0;

            foreach (string result in Enum.GetNames(typeof(KryptonMemoryBoxDialogResult)))
            {
                kcmbMemoryBoxDefaultDialogResult.Items.Add(result);
            }

            kcmbMemoryBoxDefaultDialogResult.SelectedIndex = 0;
        }

        private void kcmbMessageBoxIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kcmbMessageBoxIcon.SelectedIndex == 0)
            {
                ktxtCustomIconPath.Enabled = true;
            }
            else
            {
                ktxtCustomIconPath.Enabled = false;
            }

            _icon = (KryptonMemoryBoxIcon)Enum.Parse(typeof(KryptonMemoryBoxIcon), kcmbMessageBoxIcon.Text);
        }

        private void kcmbMemoryBoxDefaultButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            _defaultButton = (KryptonMemoryBoxDefaultButton)Enum.Parse(typeof(KryptonMemoryBoxDefaultButton),
                kcmbMemoryBoxDefaultButton.Text);
        }

        private void kcmbMemoryBoxDefaultDialogResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dialogResult = (KryptonMemoryBoxDialogResult)Enum.Parse(typeof(KryptonMemoryBoxDialogResult),
                kcmbMemoryBoxDefaultDialogResult.Text);
        }

        private void bsaBrowse_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog iconDialog = new()
            {
                Title = @"Select a image:",
                //Filters = new CommonFileDialogFilterCollection()
            };

            if (iconDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                ktxtCustomIconPath.Text = Path.GetFullPath(iconDialog.FileName);
            }
        }

        private void ktxtCustomIconPath_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ktxtCustomIconPath.Text))
            {
                _iconPath = ktxtCustomIconPath.Text;
            }
        }
    }
}
