#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Memory.Box
{
    public partial class KryptonMemoryBox : CommonExtendedKryptonForm
    {
        #region Instance Fields

        private KryptonMemoryBoxDialogResult _defaultDialogResult, _lastResult;

        #endregion

        #region Public

        public KryptonMemoryBoxDialogResult DefaultDialogResult { get => _defaultDialogResult; set => _defaultDialogResult = value; }

        #endregion

        #region Identity

        public KryptonMemoryBox() => InitializeComponent();

        #endregion

        #region Implementation

        private void KryptonMemoryBox_Load(object sender, EventArgs e)
        {

        }

        private void SetupButtonText()
        {
            kbtnButtonOne.Text = KryptonManager.Strings.Yes;

            kbtnButtonTwo.Text = KryptonManager.Strings.YesToAll;

            kbtnButtonThree.Text = KryptonManager.Strings.No;

            kbtnButtonFour.Text = KryptonManager.Strings.NoToAll;

            kbtnButtonFive.Text = KryptonManager.Strings.Cancel;
        }

        /// <summary>Sets the default dialog result.</summary>
        /// <param name="dialogResult">The dialog result.</param>
        private void SetDefaultDialogResult(KryptonMemoryBoxDialogResult dialogResult)
        {
            switch (dialogResult)
            {
                case KryptonMemoryBoxDialogResult.Yes:
                    AcceptButton = kbtnButtonOne;
                    break;
                case KryptonMemoryBoxDialogResult.YesToAll:
                    AcceptButton = kbtnButtonTwo;
                    break;
                case KryptonMemoryBoxDialogResult.No:
                    AcceptButton = kbtnButtonThree;
                    break;
                case KryptonMemoryBoxDialogResult.NoToAll:
                    AcceptButton = kbtnButtonFour;
                    break;
                case KryptonMemoryBoxDialogResult.Cancel:
                    AcceptButton = kbtnButtonFive;
                    break;
            }
        }

        /// <summary>Shows the krypton memory box dialog result.</summary>
        /// <returns></returns>
        private KryptonMemoryBoxDialogResult ShowKryptonMemoryBoxDialogResult()
        {
            _defaultDialogResult = KryptonMemoryBoxDialogResult.Cancel;

            if (_lastResult == KryptonMemoryBoxDialogResult.NoToAll)
            {
                _defaultDialogResult = KryptonMemoryBoxDialogResult.No;
            }
            else if (_lastResult == KryptonMemoryBoxDialogResult.YesToAll)
            {
                _defaultDialogResult = KryptonMemoryBoxDialogResult.Yes;
            }
            else
            {
                base.ShowDialog();
            }

            return _defaultDialogResult;
        }

        /// <summary>Shows the krypton memory box dialog result.</summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="iconPath">The icon path.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="defaultDialogResult">The default dialog result.</param>
        /// <returns></returns>
        private KryptonMemoryBoxDialogResult ShowKryptonMemoryBoxDialogResult(string title, string message, KryptonMemoryBoxIcon icon = KryptonMemoryBoxIcon.None, string iconPath = null, KryptonMemoryBoxDefaultButton defaultButton = KryptonMemoryBoxDefaultButton.ButtonOne, KryptonMemoryBoxDialogResult defaultDialogResult = KryptonMemoryBoxDialogResult.Cancel)
        {
            Text = title;

            kwlBody.Text = message;

            SetupButtonText();

            switch (icon)
            {
                case KryptonMemoryBoxIcon.Custom:
                    pbxIcon.Image = new Bitmap(iconPath);
                    break;
                case KryptonMemoryBoxIcon.OK:
                    pbxIcon.Image = Properties.Resources.Input_Box_Ok_64_x_64;
                    break;
                case KryptonMemoryBoxIcon.Error:
                    pbxIcon.Image = Properties.Resources.Input_Box_Critical_64_x_64;
                    break;
                case KryptonMemoryBoxIcon.Exclamation:
                    pbxIcon.Image = Properties.Resources.Input_Box_Warning_64_x_58;
                    break;
                case KryptonMemoryBoxIcon.Information:
                    pbxIcon.Image = Properties.Resources.Input_Box_Information_64_x_64;
                    break;
                case KryptonMemoryBoxIcon.Question:
                    pbxIcon.Image = Properties.Resources.Input_Box_Question_64_x_64;
                    break;
                case KryptonMemoryBoxIcon.None:
                    pbxIcon.Image = null;

                    UpdateUI();
                    break;
                case KryptonMemoryBoxIcon.Stop:
                    pbxIcon.Image = Properties.Resources.Input_Box_Stop_64_x_64;
                    break;
                case KryptonMemoryBoxIcon.Hand:
                    pbxIcon.Image = Properties.Resources.Input_Box_Hand_64_x_64;
                    break;
            }

            SetDefaultButton(defaultButton);

            SetDefaultDialogResult(defaultDialogResult);

            return ShowKryptonMemoryBoxDialogResult();
        }

        /// <summary>Shows the specified title.</summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="iconPath">The icon path.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="defaultDialogResult">The default dialog result.</param>
        /// <returns></returns>
        public static KryptonMemoryBoxDialogResult Show(string title, string message, KryptonMemoryBoxIcon icon = KryptonMemoryBoxIcon.None, string iconPath = null, KryptonMemoryBoxDefaultButton defaultButton = KryptonMemoryBoxDefaultButton.ButtonOne, KryptonMemoryBoxDialogResult defaultDialogResult = KryptonMemoryBoxDialogResult.Cancel)
        {
            KryptonMemoryBox memoryBox = new();

            return memoryBox.ShowKryptonMemoryBoxDialogResult(title, message, icon, iconPath, defaultButton, defaultDialogResult);
        }

        private void UpdateUI()
        {
            if (pbxIcon.Image != null)
            {
                pbxIcon.Visible = true;

                kwlBody.Size = new Size(404, 211);
            }
            else
            {
                pbxIcon.Visible = false;

                kwlBody.Size = new Size(474, 211);
            }
        }

        private DialogResult ReturnDialogResult(DialogResult result) => result;

        private void SetAcceptButton(KryptonButton button) => AcceptButton = button;

        private void SetDefaultButton(KryptonMemoryBoxDefaultButton defaultButton)
        {
            switch (defaultButton)
            {
                case KryptonMemoryBoxDefaultButton.ButtonOne:
                    SetAcceptButton(kbtnButtonOne);
                    break;
                case KryptonMemoryBoxDefaultButton.ButtonTwo:
                    SetAcceptButton(kbtnButtonTwo);
                    break;
                case KryptonMemoryBoxDefaultButton.ButtonThree:
                    SetAcceptButton(kbtnButtonThree);
                    break;
                case KryptonMemoryBoxDefaultButton.ButtonFour:
                    SetAcceptButton(kbtnButtonFour);
                    break;
                case KryptonMemoryBoxDefaultButton.ButtonFive:
                    SetAcceptButton(kbtnButtonFive);
                    break;
                default:
                    SetAcceptButton(kbtnButtonOne);
                    break;
            }
        }

        private void kbtnButtonOne_Click(object sender, EventArgs e) => SetDialogResult(KryptonMemoryBoxDialogResult.Yes, DialogResult.Yes);

        private void kbtnButtonTwo_Click(object sender, EventArgs e) => SetDialogResult(KryptonMemoryBoxDialogResult.YesToAll, DialogResult.Yes);

        private void kbtnButtonThree_Click(object sender, EventArgs e) => SetDialogResult(KryptonMemoryBoxDialogResult.No, DialogResult.No);

        private void kbtnButtonFour_Click(object sender, EventArgs e) => SetDialogResult(KryptonMemoryBoxDialogResult.NoToAll, DialogResult.No);

        private void kbtnButtonFive_Click(object sender, EventArgs e) => SetDialogResult(KryptonMemoryBoxDialogResult.Cancel, DialogResult.Cancel);

        private void SetDialogResult(KryptonMemoryBoxDialogResult memoryBoxDialogResult, DialogResult dialogResult)
        {
            _defaultDialogResult = memoryBoxDialogResult;

            _lastResult = memoryBoxDialogResult;

            DialogResult = dialogResult;
        }

        #endregion
    }
}