#region MIT License

/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */

#endregion
using Krypton.Toolkit.Suite.Extended.Memory.Box;

using Microsoft.WindowsAPICodePack.Dialogs;

namespace Examples
{
    public partial class MemoryBoxExample : KryptonForm
    {
        #region Static Fields

        private const string SEED_TEXT = @"/*
                                             * MIT License
                                             *
                                             * Copyright (c) 2017 - 2024 Krypton Suite
                                             *
                                             * Permission is hereby granted, free of charge, to any person obtaining a copy
                                             * of this software and associated documentation files (the ""Software""), to deal
                                             * in the Software without restriction, including without limitation the rights
                                             * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
                                             * copies of the Software, and to permit persons to whom the Software is
                                             * furnished to do so, subject to the following conditions:
                                             *
                                             * The above copyright notice and this permission notice shall be included in all
                                             * copies or substantial portions of the Software.
                                             *
                                             * THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
                                             * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                                             * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
                                             * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
                                             * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
                                             * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
                                             * SOFTWARE.
                                             *
                                             */";

        #endregion

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

        private void kbtnDummyText_Click(object sender, EventArgs e)
        {
            ktxtMessageContent.Text = string.Empty;

            ktxtMessageContent.Text = SEED_TEXT;
        }
    }
}
