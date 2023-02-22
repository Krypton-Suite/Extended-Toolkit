using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private Font _cueTypeface;
        private readonly Font? _promptTypeface;
        private Font _buttonTypeface;
        private InputBoxIconType _iconType;
        private readonly KryptonInputBoxResponseType _inputType;
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

        public KryptonInputBoxExtendedExample(KryptonInputBoxResponseType? inputType, Font? promptTypeface)
        {
            _inputType = inputType ?? KryptonInputBoxResponseType.TextBox;
            _promptTypeface = promptTypeface;
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
