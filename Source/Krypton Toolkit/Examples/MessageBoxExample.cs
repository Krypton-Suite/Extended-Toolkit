#region MIT License

/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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
using Krypton.Toolkit.Suite.Extended.Developer.Utilities;
using Krypton.Toolkit.Suite.Extended.Messagebox;

using ExtendedKryptonMessageBoxIcon = Krypton.Toolkit.Suite.Extended.Messagebox.ExtendedKryptonMessageBoxIcon;
using ExtendedMessageBoxButtons = Krypton.Toolkit.Suite.Extended.Messagebox.ExtendedMessageBoxButtons;

namespace Examples
{
    public partial class MessageBoxExample : KryptonForm
    {
        #region Static Fields

        private static string SEED_TEXT = @"/*
                                             * MIT License
                                             *
                                             * Copyright (c) 2017 - 2026 Krypton Suite
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

        #region Standard Options

        private bool _showCloseBox;

        private string _caption;

        private string _message;

        private KryptonMessageBoxDefaultButton _defaultButton = KryptonMessageBoxDefaultButton.Button1;

        private ExtendedKryptonMessageBoxIcon _icon = ExtendedKryptonMessageBoxIcon.Information;

        private KryptonMessageBoxButtons _button = KryptonMessageBoxButtons.OK;

        private MessageBoxOptions _options = 0;

        private ContentAlignment _messageTextAlignment = ContentAlignment.MiddleLeft;

        private Image _customImage;

        #endregion

        #endregion

        #region Identity

        public MessageBoxExample()
        {
            InitializeComponent();
        }

        #endregion

        #region Implementation

        private void MessageBoxExample_Load(object sender, EventArgs e)
        {
            foreach (string value in Enum.GetNames(typeof(ExtendedKryptonMessageBoxIcon)))
            {
                kcmbMessageBoxIcon.Items.Add(value);
            }

            kcmbMessageBoxIcon.SelectedIndex = 1;

            foreach (string name in Enum.GetNames(typeof(ExtendedMessageBoxButtons)))
            {
                kcmbMessageBoxButtons.Items.Add(name);
            }

            kcmbMessageBoxButtons.SelectedIndex = 1;

            foreach (string value in Enum.GetNames(typeof(ExtendedKryptonMessageBoxMessageContainerType)))
            {
                kcmbMessageContentType.Items.Add(value);
            }

            kcmbMessageContentType.SelectedIndex = 1;

            EnableHyperlinkControls(false);

            SetupLinkAreaLengthValues();

            bsaReset.Enabled = ButtonEnabled.False;
        }

        private void ktxtMessageContent_TextChanged(object sender, EventArgs e) => SetupLinkAreaLengthValues();

        private void SetupLinkAreaLengthValues()
        {
            knudLinkAreaStart.Maximum = ktxtMessageContent.Text.Length;

            knudLinkAreaEnd.Maximum = ktxtMessageContent.Text.Length;

            knudLinkAreaEnd.Value = ktxtMessageContent.Text.Length;
        }

        private void kcmbMessageContentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kcmbMessageContentType.SelectedIndex == 2)
            {
                EnableHyperlinkControls(true);
            }
            else
            {
                EnableHyperlinkControls(false);
            }
        }

        private void EnableHyperlinkControls(bool b)
        {
            ktxtHyperlinkDestination.Enabled = b;

            kryptonLabel3.Enabled = b;

            knudLinkAreaStart.Enabled = b;

            kryptonLabel4.Enabled = b;

            knudLinkAreaEnd.Enabled = b;
        }

        private void ktxtHyperlinkDestination_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ktxtHyperlinkDestination.Text))
            {
                bsaReset.Enabled = ButtonEnabled.False;
            }
            else
            {
                bsaReset.Enabled = ButtonEnabled.True;
            }
        }

        private void bsaReset_Click(object sender, EventArgs e)
        {
            ktxtHyperlinkDestination.Text = null;
        }

        private void bsaBrowseForResource_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new()
            {
                Title = @"Browse for a resource:"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ktxtHyperlinkDestination.Text = Path.GetFullPath(ofd.FileName);
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string dummyText = LoremIpsumGenerator.Paragraph(5, 6, 4, 10);

            ktxtMessageContent.Text = SEED_TEXT;
        }

        private void kbtnShow_Click(object sender, EventArgs e)
        {
            //KryptonMessageBoxExtended.Show(this, _message, _caption, _button, _icon, _defaultButton, _options);

            //DialogResult result = KryptonMessageBoxExtended.Show(_message, _caption, _button, _icon, _defaultButton, _options);

            //if (result == DialogResult.OK)
            //{
            //    MessageBox.Show($@"{KryptonMessageBoxExtended.ReturnCheckBoxCheckedValue()}");
            //}
        }

        #endregion
    }
}
