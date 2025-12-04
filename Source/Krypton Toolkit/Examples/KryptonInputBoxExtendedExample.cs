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
using Krypton.Toolkit.Suite.Extended.InputBox;

using KryptonInputBoxResponseType = Krypton.Toolkit.Suite.Extended.InputBox.KryptonInputBoxResponseType;

namespace Examples
{
    public partial class KryptonInputBoxExtendedExample : KryptonForm
    {
        #region Instance Fields

        private Color _cueColour;
        private string _prompt;
        private string _caption;
        private string _defaultResponse;
        private string _cueText;
        private Font _cueTypeface, _promptTypeface, _buttonTypeface;
        private InputBoxIconType _iconType;
        private KryptonInputBoxResponseType _inputType;
        private InputBoxTextAlignment _textAlignment;
        private InputBoxWrappedMessageTextAlignment _textWrappedMessageTextAlignment;
        private InputBoxButtons _buttons;
        private InputBoxButtonFocus _focusedButton;

        private Image _customImage;

        #endregion

        private void kcbtnCueColour_SelectedColorChanged(object sender, ColorEventArgs e) => _cueColour = e.Color;

        private void kbtnCueTypeface_Click(object sender, EventArgs e)
        {
            KryptonFontDialog cueTypefaceDialog = new();

            if (cueTypefaceDialog.ShowDialog() == DialogResult.OK)
            {
                _cueTypeface = cueTypefaceDialog.Font;
            }
        }

        private void ktxtCaption_TextChanged(object sender, EventArgs e) => _caption = ktxtCaption.Text;

        private void ktxtPromptText_TextChanged(object sender, EventArgs e) => _prompt = ktxtPromptText.Text;

        private void ktxtCueText_TextChanged(object sender, EventArgs e) => _cueText = ktxtCueText.Text;

        private void ktxtDefaultResponseText_TextChanged(object sender, EventArgs e) => _defaultResponse = ktxtDefaultResponseText.Text;

        private void kcmbButtonType_SelectedIndexChanged(object sender, EventArgs e) => _buttons = (InputBoxButtons)Enum.Parse(typeof(InputBoxButtons), kcmbButtonType.Text);

        private void kcmbFocusedButton_SelectedIndexChanged(object sender, EventArgs e) => _focusedButton = (InputBoxButtonFocus)Enum.Parse(typeof(InputBoxButtonFocus), kcmbFocusedButton.Text);

        private void kcmbTextAlignment_SelectedIndexChanged(object sender, EventArgs e) => _textAlignment = (InputBoxTextAlignment)Enum.Parse(typeof(InputBoxTextAlignment), kcmbTextAlignment.Text);

        private void kcmbWrappedTextAlignment_SelectedIndexChanged(object sender, EventArgs e) =>
            _textWrappedMessageTextAlignment =
                (InputBoxWrappedMessageTextAlignment)Enum.Parse(typeof(InputBoxWrappedMessageTextAlignment),
                    kcmbWrappedTextAlignment.Text);

        private void kbtnQuickTest_Click(object sender, EventArgs e) => kibemQuickTest.Show();

        public KryptonInputBoxExtendedExample()
        {
            InitializeComponent();
        }

        private void kbtnShow_Click(object sender, EventArgs e)
        {
            kibemTest.ShowInputBox(this, _prompt, _caption, _defaultResponse, _cueText,
                _cueColour, _cueTypeface, _buttonTypeface,
                _promptTypeface, _iconType, _inputType,
                _textAlignment, _textWrappedMessageTextAlignment,
                _buttons, _focusedButton, _customImage);
        }
    }
}
