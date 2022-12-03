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

namespace Krypton.Toolkit.Suite.Extended.InputBox
{
    public partial class KryptonInputBoxExtendedForm : KryptonForm
    {
        #region Static Values

        private const int GAP = 10;

        #endregion

        #region Instance Fields

        private Color _cueColour;
        private string _prompt;
        private string _caption;
        private string _defaultResponse;
        private string _cueText;
        private Font _cueTypeface, _promptTypeface, _buttonTypeface;
        private InputBoxIconType _iconType;
        private KryptonInputBoxType _inputType;
        private InputBoxTextAlignment _textAlignment;
        private InputBoxWrappedMessageTextAlignment _textWrappedMessageTextAlignment;
        private InputBoxButtons _buttons;
        private InputBoxButtonFocus _focusedButton;
        private Image _customImage;
        private Properties.Resources _resources = new();
        private GlobalTypefaceSettingsManager _typefaceSettings = new();

        #endregion

        #region Properties

        internal string InputResponse => GetInputResponse();

        #endregion

        #region Identity

        public KryptonInputBoxExtendedForm()
        {
            InitializeComponent();
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtendedForm" /> class.</summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="defaultResponse">The default response.</param>
        /// <param name="cueText">The cue text.</param>
        /// <param name="cueColour">The cue colour.</param>
        /// <param name="cueTypeface">The cue typeface.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="inputType">Type of the input.</param>
        /// <param name="textAlignment">The text alignment.</param>
        /// <param name="textWrappedMessageTextAlignment">The text wrapped message text alignment.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="focusedButton">The focused button.</param>
        /// <param name="customImage">The custom image.</param>
        public KryptonInputBoxExtendedForm(string prompt, string caption,
                                           string defaultResponse, string cueText, 
                                           Color cueColour, 
                                           Font? cueTypeface, Font? buttonTypeface, Font? promptTypeface,
                                           InputBoxIconType iconType, KryptonInputBoxType inputType, 
                                           InputBoxTextAlignment textAlignment, 
                                           InputBoxWrappedMessageTextAlignment textWrappedMessageTextAlignment, 
                                           InputBoxButtons buttons = InputBoxButtons.OkCancel, 
                                           InputBoxButtonFocus focusedButton = InputBoxButtonFocus.ButtonFour, 
                                           Image customImage = null)
        {
            InitializeComponent();

            SetupUI(prompt, caption, defaultResponse, cueText, cueColour, cueTypeface, buttonTypeface, promptTypeface,
                    iconType, inputType, textAlignment, textWrappedMessageTextAlignment,
                    buttons, focusedButton, customImage);
        }

        #endregion

        #region Implementation

        /// <summary>Setups the UI.</summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="defaultResponse">The default response.</param>
        /// <param name="cueText">The cue text.</param>
        /// <param name="cueColour">The cue colour.</param>
        /// <param name="cueTypeface">The cue typeface.</param>
        /// <param name="buttonTypeface">The button typeface.</param>
        /// <param name="promptTypeface">The prompt typeface.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="inputType">Type of the input.</param>
        /// <param name="textAlignment">The text alignment.</param>
        /// <param name="textWrappedMessageTextAlignment">The text wrapped message text alignment.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="focusedButton">The focused button.</param>
        /// <param name="customImage">The custom image.</param>
        private void SetupUI(string prompt, string caption, string defaultResponse, string cueText, Color cueColour,
            Font? cueTypeface, Font? buttonTypeface, Font? promptTypeface, InputBoxIconType iconType, KryptonInputBoxType inputType, InputBoxTextAlignment textAlignment,
            InputBoxWrappedMessageTextAlignment textWrappedMessageTextAlignment, InputBoxButtons buttons,
            InputBoxButtonFocus focusedButton, Image customImage)
        {
            StoreValues(cueColour, prompt, caption, defaultResponse, cueText, cueTypeface, buttonTypeface, promptTypeface,
                        iconType, inputType, textAlignment, textWrappedMessageTextAlignment, 
                        buttons, focusedButton, customImage);

            UpdateButtons(_buttons, _focusedButton);

            if (_customImage == null)
            {
                UpdateIcon(_iconType);
            }
            else
            {
                UpdateIcon(_iconType, customImage);
            }

            UpdateResponseType(_inputType);

            UpdateText();

            if (!string.IsNullOrEmpty(_cueText))
            {
                SetPromptText(_cueText);
            }

            SetCueColour(_cueColour);

            SetCueTypeface(_cueTypeface);

            SetButtonTypeface(_buttonTypeface);

            SetPromptTypeface(_promptTypeface);

            SetTextAlignment(_textAlignment);

            SetWrappedMessageTextAlignment(_textWrappedMessageTextAlignment);
        }

        /// <summary>Stores the values.</summary>
        /// <param name="cueColour">The cue colour.</param>
        /// <param name="prompt">The prompt.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="defaultResponse">The default response.</param>
        /// <param name="cueText">The cue text.</param>
        /// <param name="cueTypeface">The cue typeface.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="inputType">Type of the input.</param>
        /// <param name="textAlignment">The text alignment.</param>
        /// <param name="textWrappedMessageTextAlignment">The text wrapped message text alignment.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="focusedButton">The focused button.</param>
        /// <param name="customImage">The custom image.</param>
        private void StoreValues(Color cueColour, string prompt, string caption, string defaultResponse, string cueText,
            Font? cueTypeface, Font? buttonTypeface, Font? promptTypeface, InputBoxIconType? iconType, KryptonInputBoxType? inputType, InputBoxTextAlignment? textAlignment,
            InputBoxWrappedMessageTextAlignment? textWrappedMessageTextAlignment, InputBoxButtons? buttons, InputBoxButtonFocus? focusedButton, Image? customImage)
        {
            _cueColour = cueColour;
            _prompt = prompt;
            _caption = caption;
            _defaultResponse = defaultResponse ?? @"";
            _cueText = cueText ?? @"";
            _cueTypeface = cueTypeface ?? _typefaceSettings.GetCueTypeface();
            _buttonTypeface = buttonTypeface ?? _typefaceSettings.GetNormalTypeface();
            _promptTypeface = promptTypeface ?? _typefaceSettings.GetBoldTypeface();
            _iconType = iconType ?? InputBoxIconType.None;
            _inputType = inputType ?? KryptonInputBoxType.TextBox;
            _textAlignment = textAlignment ?? InputBoxTextAlignment.Left;
            _textWrappedMessageTextAlignment = textWrappedMessageTextAlignment ?? InputBoxWrappedMessageTextAlignment.MiddleLeft;
            _buttons = buttons ?? InputBoxButtons.Ok;
            _focusedButton = focusedButton ?? InputBoxButtonFocus.ButtonFour;
            _customImage = customImage ?? null;
        }

        /// <summary>Updates the type of the response.</summary>
        /// <param name="inputType">Type of the input.</param>
        private void UpdateResponseType(KryptonInputBoxType inputType)
        {
            switch (inputType)
            {
                case KryptonInputBoxType.ComboBox:
                    kcmbResponse.Visible = true;

                    kdtpResponse.Visible = false;

                    kmtxResponse.Visible = false;

                    krtbResponse.Visible = false;

                    ktxtResponse.Visible = false;
                    break;
                case KryptonInputBoxType.DateTimePicker:
                    kcmbResponse.Visible = false;

                    kdtpResponse.Visible = true;

                    kmtxResponse.Visible = false;

                    krtbResponse.Visible = false;

                    ktxtResponse.Visible = false;
                    break;
                case KryptonInputBoxType.MaskedTextBox:
                    kcmbResponse.Visible = false;

                    kdtpResponse.Visible = false;

                    kmtxResponse.Visible = true;

                    krtbResponse.Visible = false;

                    ktxtResponse.Visible = false;
                    break;
                case KryptonInputBoxType.None:
                    kcmbResponse.Visible = false;

                    kdtpResponse.Visible = false;

                    kmtxResponse.Visible = false;

                    krtbResponse.Visible = false;

                    ktxtResponse.Visible = false;

                    kpnResponse.Visible = false;
                    break;
                case KryptonInputBoxType.PasswordBox:
                    kcmbResponse.Visible = false;

                    kdtpResponse.Visible = false;

                    kmtxResponse.Visible = false;

                    krtbResponse.Visible = false;

                    ktxtResponse.Visible = true;

                    ktxtResponse.UseSystemPasswordChar = true;
                    break;
                case KryptonInputBoxType.RichTextBox:
                    kcmbResponse.Visible = false;

                    kdtpResponse.Visible = false;

                    kmtxResponse.Visible = false;

                    krtbResponse.Visible = true;

                    ktxtResponse.Visible = false;
                    break;
                case KryptonInputBoxType.TextBox:
                    kcmbResponse.Visible = false;

                    kdtpResponse.Visible = false;

                    kmtxResponse.Visible = false;

                    krtbResponse.Visible = false;

                    ktxtResponse.Visible = true;
                    break;
            }
        }

        /// <summary>Updates the icon.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="customImage">The custom image.</param>
        private void UpdateIcon(InputBoxIconType iconType, Image customImage = null)
        {
            switch (iconType)
            {
                case InputBoxIconType.Asterisk:
                    pbxIcon.Image = Properties.Resources.Asterisk_Information_Box;
                    break;
                case InputBoxIconType.Critical:
                    pbxIcon.Image = Properties.Resources.Critical_Information_Box;
                    break;
                case InputBoxIconType.Custom:
                    pbxIcon.Image = customImage;
                    break;
                case InputBoxIconType.Error:
                    pbxIcon.Image = Properties.Resources.Critical_Information_Box;
                    break;
                case InputBoxIconType.Exclamation:
                    pbxIcon.Image = Properties.Resources.Warning_Information_Box;
                    break;
                case InputBoxIconType.Hand:
                    pbxIcon.Image = Properties.Resources.Hand_Information_Box;
                    break;
                case InputBoxIconType.Information:
                    pbxIcon.Image = Properties.Resources.Information_Information_Box;
                    break;
                case InputBoxIconType.None:
                    pbxIcon.SizeMode = PictureBoxSizeMode.Normal;

                    pbxIcon.Size = new(0, 0);
                    
                    kryptonTableLayoutPanel1.Controls.Add(_labelPrompt, 0, 0);
                    
                    kryptonTableLayoutPanel1.SetColumnSpan(_labelPrompt, 2);
                    break;
                case InputBoxIconType.Ok:
                    pbxIcon.Image = Properties.Resources.Ok_Information_Box;
                    break;
                case InputBoxIconType.Question:
                    pbxIcon.Image = Properties.Resources.Question_Information_Box;
                    break;
                case InputBoxIconType.Stop:
                    pbxIcon.Image = Properties.Resources.Stop_Information_Box;
                    break;
                case InputBoxIconType.Shield:
                    break;
                case InputBoxIconType.WindowsLogo:
                    break;
            }
        }

        /// <summary>Updates the buttons.</summary>
        /// <param name="buttons">The buttons.</param>
        /// <param name="buttonFocus">The button focus.</param>
        private void UpdateButtons(InputBoxButtons buttons, InputBoxButtonFocus buttonFocus = InputBoxButtonFocus.ButtonOne)
        {
            switch (buttons)
            {
                case InputBoxButtons.Ok:
                    kbtnInputBoxButtonOne.Visible = false;

                    kbtnInputBoxButtonOne.DialogResult = DialogResult.None;

                    kbtnInputBoxButtonTwo.Visible = false;

                    kbtnInputBoxButtonTwo.DialogResult = DialogResult.None;

                    kbtnInputBoxButtonThree.Text = KryptonManager.Strings.OK;

                    kbtnInputBoxButtonThree.DialogResult = DialogResult.OK;

                    AcceptButton = kbtnInputBoxButtonThree;

                    CancelButton = null;
                    break;
                case InputBoxButtons.OkCancel:
                    kbtnInputBoxButtonOne.Visible = false;

                    kbtnInputBoxButtonOne.DialogResult = DialogResult.None;

                    kbtnInputBoxButtonTwo.Text = KryptonManager.Strings.OK;

                    kbtnInputBoxButtonTwo.DialogResult = DialogResult.OK;

                    kbtnInputBoxButtonThree.Text = KryptonManager.Strings.Cancel;

                    kbtnInputBoxButtonThree.DialogResult = DialogResult.Cancel;

                    AcceptButton = kbtnInputBoxButtonTwo;

                    CancelButton = kbtnInputBoxButtonThree;
                    break;
                case InputBoxButtons.YesNo:
                    kbtnInputBoxButtonOne.Visible = false;

                    kbtnInputBoxButtonOne.DialogResult = DialogResult.None;

                    kbtnInputBoxButtonTwo.Text = KryptonManager.Strings.Yes;

                    kbtnInputBoxButtonTwo.DialogResult = DialogResult.Yes;

                    kbtnInputBoxButtonThree.Text = KryptonManager.Strings.No;

                    kbtnInputBoxButtonThree.DialogResult = DialogResult.No;

                    AcceptButton = kbtnInputBoxButtonTwo;

                    CancelButton = kbtnInputBoxButtonThree;
                    break;
                case InputBoxButtons.YesNoCancel:
                    kbtnInputBoxButtonOne.Text = KryptonManager.Strings.Yes;

                    kbtnInputBoxButtonOne.DialogResult = DialogResult.Yes;

                    kbtnInputBoxButtonTwo.Text = KryptonManager.Strings.No;

                    kbtnInputBoxButtonTwo.DialogResult = DialogResult.No;

                    kbtnInputBoxButtonThree.Text = KryptonManager.Strings.Cancel;

                    kbtnInputBoxButtonThree.DialogResult = DialogResult.Cancel;

                    AcceptButton = kbtnInputBoxButtonOne;

                    CancelButton = kbtnInputBoxButtonThree;
                    break;
            }

            switch (buttonFocus)
            {
                case InputBoxButtonFocus.ButtonOne:
                    if (kbtnInputBoxButtonOne.Visible)
                    {
                        kbtnInputBoxButtonOne.Focus();
                    }
                    else
                    {
                        kbtnInputBoxButtonTwo.Focus();
                    }
                    break;
                case InputBoxButtonFocus.ButtonTwo:
                    kbtnInputBoxButtonTwo.Focus();
                    break;
                case InputBoxButtonFocus.ButtonThree:
                    kbtnInputBoxButtonThree.Focus();
                    break;
                case InputBoxButtonFocus.ButtonFour:
                    kbtnInputBoxButtonThree.Focus();
                    break;
            }
        }

        /// <summary>Sets the prompt text.</summary>
        /// <param name="promptText">The prompt text.</param>
        private void SetPromptText(string promptText) => _labelPrompt.Text = promptText;

        /// <summary>Sets the prompt typeface.</summary>
        /// <param name="promptTypeface">The prompt typeface.</param>
        private void SetPromptTypeface(Font promptTypeface) => _labelPrompt.Font = promptTypeface;

        /// <summary>Sets the input typeface.</summary>
        /// <param name="inputTypeface">The input typeface.</param>
        private void SetInputTypeface(Font inputTypeface)
        {
            kcmbResponse.Font = inputTypeface;

            kdtpResponse.StateCommon.Content.Font = inputTypeface;

            kmtxResponse.StateCommon.Content.Font = inputTypeface;

            ktxtResponse.StateCommon.Content.Font = inputTypeface;
        }

        /// <summary>Sets the button typeface.</summary>
        /// <param name="buttonTypeface">The button typeface.</param>
        private void SetButtonTypeface(Font buttonTypeface)
        {
            kbtnInputBoxButtonOne.StateCommon.Content.ShortText.Font = buttonTypeface;

            kbtnInputBoxButtonTwo.StateCommon.Content.ShortText.Font = buttonTypeface;

            kbtnInputBoxButtonThree.StateCommon.Content.ShortText.Font = buttonTypeface;
        }

        /// <summary>Sets the cue colour.</summary>
        /// <param name="cueColour">The cue colour.</param>
        private void SetCueColour(Color cueColour)
        {
            kcmbResponse.CueHint.Color1 = cueColour;

            krtbResponse.CueHint.Color1 = cueColour;

            ktxtResponse.CueHint.Color1 = cueColour;
        }

        /// <summary>Sets the cue typeface.</summary>
        /// <param name="cueTypeface">The cue typeface.</param>
        private void SetCueTypeface(Font cueTypeface)
        {
            kcmbResponse.CueHint.Font = cueTypeface;

            krtbResponse.CueHint.Font = cueTypeface;

            ktxtResponse.CueHint.Font = cueTypeface;
        }

        /// <summary>Gets the input response.</summary>
        /// <returns>The input response string.</returns>
        private string GetInputResponse()
        {
            string output = string.Empty;

            if (_inputType == KryptonInputBoxType.ComboBox)
            {
                output = kcmbResponse.Text;
            }
            else if (_inputType == KryptonInputBoxType.DateTimePicker)
            {
                output = kdtpResponse.Text;
            }
            else if (_inputType == KryptonInputBoxType.MaskedTextBox)
            {
                output = kmtxResponse.Text;
            }
            else if (_inputType == KryptonInputBoxType.None)
            {
                output = string.Empty;
            }
            else if (_inputType == KryptonInputBoxType.PasswordBox)
            {
                output = ktxtResponse.Text;
            }
            else if (_inputType == KryptonInputBoxType.RichTextBox)
            {
                output = krtbResponse.Text;
            }
            else if (_inputType == KryptonInputBoxType.TextBox)
            {
                output = ktxtResponse.Text;
            }

            return output;
        }

        /// <summary>Updates the text.</summary>
        private void UpdateText()
        {
            Text = _caption;

            _labelPrompt.Text = _prompt;

            if (_inputType == KryptonInputBoxType.ComboBox)
            {
                kcmbResponse.Text = _defaultResponse;
            }
            else if (_inputType == KryptonInputBoxType.DateTimePicker)
            {
                kdtpResponse.Value = DateTime.Now;
            }
            else if (_inputType == KryptonInputBoxType.MaskedTextBox)
            {
                kmtxResponse.Text = _defaultResponse;
            }
            else if (_inputType == KryptonInputBoxType.PasswordBox)
            {
                ktxtResponse.Text = _defaultResponse;
            }
            else if (_inputType == KryptonInputBoxType.RichTextBox)
            {
                krtbResponse.Text = _defaultResponse;
            }
            else if (_inputType == KryptonInputBoxType.TextBox)
            {
                ktxtResponse.Text = _defaultResponse;
            }
        }

        /// <summary>Sets the text alignment.</summary>
        /// <param name="textAlignment">The text alignment.</param>
        private void SetTextAlignment(InputBoxTextAlignment textAlignment)
        {
            switch (textAlignment)
            {
                case InputBoxTextAlignment.Left:
                    kcmbResponse.StateCommon.ComboBox.Content.TextH = PaletteRelativeAlign.Near;

                    kdtpResponse.StateCommon.Content.TextH = PaletteRelativeAlign.Near;

                    kmtxResponse.TextAlign = HorizontalAlignment.Left;

                    krtbResponse.StateCommon.Content.TextH = PaletteRelativeAlign.Near;

                    ktxtResponse.StateCommon.Content.TextH = PaletteRelativeAlign.Near;
                    break;
                case InputBoxTextAlignment.Centre:
                    kcmbResponse.StateCommon.ComboBox.Content.TextH = PaletteRelativeAlign.Center;

                    kdtpResponse.StateCommon.Content.TextH = PaletteRelativeAlign.Center;

                    kmtxResponse.TextAlign = HorizontalAlignment.Center;

                    krtbResponse.StateCommon.Content.TextH = PaletteRelativeAlign.Center;

                    ktxtResponse.StateCommon.Content.TextH = PaletteRelativeAlign.Center;
                    break;
                case InputBoxTextAlignment.Right:
                    kcmbResponse.StateCommon.ComboBox.Content.TextH = PaletteRelativeAlign.Far;

                    kdtpResponse.StateCommon.Content.TextH = PaletteRelativeAlign.Far;

                    kmtxResponse.TextAlign = HorizontalAlignment.Right;

                    krtbResponse.StateCommon.Content.TextH = PaletteRelativeAlign.Far;

                    ktxtResponse.StateCommon.Content.TextH = PaletteRelativeAlign.Far;
                    break;
            }
        }

        /// <summary>Sets the wrapped message text alignment.</summary>
        /// <param name="textAlignment">The text alignment.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">textAlignment - null</exception>
        private void SetWrappedMessageTextAlignment(InputBoxWrappedMessageTextAlignment textAlignment)
        {
            switch (textAlignment)
            {
                case InputBoxWrappedMessageTextAlignment.TopLeft:
                    _labelPrompt.TextAlign = ContentAlignment.TopLeft;
                    break;
                case InputBoxWrappedMessageTextAlignment.TopCentre:
                    _labelPrompt.TextAlign = ContentAlignment.TopCenter;
                    break;
                case InputBoxWrappedMessageTextAlignment.TopRight:
                    _labelPrompt.TextAlign = ContentAlignment.TopRight;
                    break;
                case InputBoxWrappedMessageTextAlignment.MiddleLeft:
                    _labelPrompt.TextAlign = ContentAlignment.MiddleLeft;
                    break;
                case InputBoxWrappedMessageTextAlignment.MiddleCentre:
                    _labelPrompt.TextAlign = ContentAlignment.MiddleCenter;
                    break;
                case InputBoxWrappedMessageTextAlignment.MiddleRight:
                    _labelPrompt.TextAlign = ContentAlignment.MiddleRight;
                    break;
                case InputBoxWrappedMessageTextAlignment.BottomLeft:
                    _labelPrompt.TextAlign = ContentAlignment.BottomLeft;
                    break;
                case InputBoxWrappedMessageTextAlignment.BottomCentre:
                    _labelPrompt.TextAlign = ContentAlignment.BottomCenter;
                    break;
                case InputBoxWrappedMessageTextAlignment.BottomRight:
                    _labelPrompt.TextAlign = ContentAlignment.BottomRight;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(textAlignment), textAlignment, null);
            }
        }

        /// <summary>Shows the <see cref="KryptonInputBoxExtendedForm"/>, and returns the input string.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="prompt">The prompt.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="defaultResponse">The default response.</param>
        /// <param name="cueText">The cue text.</param>
        /// <param name="cueColour">The cue colour.</param>
        /// <param name="cueTypeface">The cue typeface.</param>
        /// <param name="buttonTypeface">The button typeface.</param>
        /// <param name="promptTypeface">The prompt typeface.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="inputType">Type of the input.</param>
        /// <param name="textAlignment">The text alignment.</param>
        /// <param name="textWrappedMessageTextAlignment">The text wrapped message text alignment.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="focusedButton">The focused button.</param>
        /// <param name="customImage">The custom image.</param>
        /// <returns>The users input string.</returns>
        internal static string InternalShow(IWin32Window owner, string prompt, string caption,
                                            string defaultResponse, string cueText, Color cueColour,
                                            Font? cueTypeface, Font? buttonTypeface, Font? promptTypeface,
                                            InputBoxIconType iconType,
                                            KryptonInputBoxType inputType,
                                            InputBoxTextAlignment textAlignment,
                                            InputBoxWrappedMessageTextAlignment textWrappedMessageTextAlignment,
                                            InputBoxButtons buttons = InputBoxButtons.OkCancel,
                                            InputBoxButtonFocus focusedButton = InputBoxButtonFocus.ButtonFour,
                                            Image customImage = null)
        {
            IWin32Window showOwner = owner ?? FromHandle(PlatformInvoke.GetActiveWindow());

            using KryptonInputBoxExtendedForm kibe = new(prompt, caption, defaultResponse, cueText, cueColour,
                                                         cueTypeface, buttonTypeface, promptTypeface,
                                                         iconType, inputType, textAlignment,
                                                         textWrappedMessageTextAlignment, buttons,
                                                         focusedButton, customImage);

            kibe.StartPosition = showOwner == null ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent;

            return kibe.ShowDialog(showOwner) == DialogResult.OK ? kibe.InputResponse : string.Empty;
        }

        private void Response_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                kbtnInputBoxButtonTwo.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                kbtnInputBoxButtonThree.PerformClick();
            }
        }

        #endregion
    }
}