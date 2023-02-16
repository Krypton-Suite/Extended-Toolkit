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
        private DateTime _initialDateTime;
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
        /// <param name="buttonTypeface">The button typeface.</param>
        /// <param name="promptTypeface">The prompt typeface.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="inputType">Type of the input.</param>
        /// <param name="textAlignment">The text alignment.</param>
        /// <param name="textWrappedMessageTextAlignment">The text wrapped message text alignment.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="focusedButton">The focused button.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="initialDateTime">The initial date time.</param>
        public KryptonInputBoxExtendedForm(string prompt, string caption,
                                           string defaultResponse, string cueText,
                                           Color cueColour,
                                           Font cueTypeface, Font buttonTypeface, Font promptTypeface,
                                           InputBoxIconType iconType, KryptonInputBoxResponseType inputType,
                                           InputBoxTextAlignment textAlignment,
                                           InputBoxWrappedMessageTextAlignment textWrappedMessageTextAlignment,
                                           InputBoxButtons buttons = InputBoxButtons.OkCancel,
                                           InputBoxButtonFocus focusedButton = InputBoxButtonFocus.ButtonFour,
                                           Image customImage = null, DateTime? initialDateTime = null)
        {
            InitializeComponent();

            SetupUI(prompt, caption, defaultResponse, cueText, cueColour, cueTypeface, buttonTypeface, promptTypeface,
                    iconType, inputType, textAlignment, textWrappedMessageTextAlignment,
                    buttons, focusedButton, customImage, initialDateTime);
        }

        #endregion

        #region Implementation

        /// <summary>Setup the UI.</summary>
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
        /// <param name="initialDateTime">The initial date time.</param>
        private void SetupUI(string prompt, string caption, string defaultResponse, string cueText, Color cueColour,
                             Font cueTypeface, Font buttonTypeface, Font promptTypeface,
                             InputBoxIconType iconType, KryptonInputBoxResponseType inputType,
                             InputBoxTextAlignment textAlignment,
                             InputBoxWrappedMessageTextAlignment textWrappedMessageTextAlignment, InputBoxButtons buttons,
                             InputBoxButtonFocus focusedButton, Image customImage, DateTime? initialDateTime = null)
        {
            StoreValues(cueColour, prompt, caption, defaultResponse, cueText, cueTypeface, buttonTypeface, promptTypeface,
                        iconType, inputType, textAlignment, textWrappedMessageTextAlignment,
                        buttons, focusedButton, customImage, initialDateTime);

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
        /// <param name="buttonTypeface">The button typeface.</param>
        /// <param name="promptTypeface">The prompt typeface.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="inputType">Type of the input.</param>
        /// <param name="textAlignment">The text alignment.</param>
        /// <param name="textWrappedMessageTextAlignment">The text wrapped message text alignment.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="focusedButton">The focused button.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="initialDateTime">The initial date time.</param>
        private void StoreValues(Color cueColour, string prompt, string caption, string? defaultResponse, string? cueText,
                                 Font? cueTypeface, Font? buttonTypeface, Font? promptTypeface,
                                 InputBoxIconType? iconType, KryptonInputBoxResponseType? inputType,
                                 InputBoxTextAlignment? textAlignment,
                                 InputBoxWrappedMessageTextAlignment? textWrappedMessageTextAlignment,
                                 InputBoxButtons? buttons, InputBoxButtonFocus? focusedButton,
                                 Image? customImage, DateTime? initialDateTime)
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
            _inputType = inputType ?? KryptonInputBoxResponseType.TextBox;
            _textAlignment = textAlignment ?? InputBoxTextAlignment.Left;
            _textWrappedMessageTextAlignment = textWrappedMessageTextAlignment ?? InputBoxWrappedMessageTextAlignment.MiddleLeft;
            _buttons = buttons ?? InputBoxButtons.Ok;
            _focusedButton = focusedButton ?? InputBoxButtonFocus.ButtonFour;
            _customImage = customImage ?? null;
            _initialDateTime = initialDateTime ?? DateTime.Now;
        }

        /// <summary>Updates the type of the response.</summary>
        /// <param name="inputType">Type of the input.</param>
        private void UpdateResponseType(KryptonInputBoxResponseType inputType)
        {
            switch (inputType)
            {
                case KryptonInputBoxResponseType.ComboBox:
                    kcmbResponse.Visible = true;

                    kdudResponse.Visible = false;

                    kdtpResponse.Visible = false;

                    kmtxtResponse.Visible = false;

                    krtbResponse.Visible = false;

                    ktxtResponse.Visible = false;

                    knudResponse.Visible = false;
                    break;
                case KryptonInputBoxResponseType.DomainUpDown:
                    kcmbResponse.Visible = false;

                    kdudResponse.Visible = true;

                    kdtpResponse.Visible = false;

                    kmtxtResponse.Visible = false;

                    krtbResponse.Visible = false;

                    ktxtResponse.Visible = false;

                    knudResponse.Visible = false;
                    break;
                case KryptonInputBoxResponseType.DateTimePicker:
                    kcmbResponse.Visible = false;

                    kdudResponse.Visible = false;

                    kdtpResponse.Visible = true;

                    kmtxtResponse.Visible = false;

                    krtbResponse.Visible = false;

                    ktxtResponse.Visible = false;

                    knudResponse.Visible = false;
                    break;
                case KryptonInputBoxResponseType.MaskedTextBox:
                    kcmbResponse.Visible = false;

                    kdudResponse.Visible = false;

                    kdtpResponse.Visible = false;

                    kmtxtResponse.Visible = true;

                    krtbResponse.Visible = false;

                    ktxtResponse.Visible = false;

                    knudResponse.Visible = false;
                    break;
                case KryptonInputBoxResponseType.None:
                    kcmbResponse.Visible = false;

                    kdudResponse.Visible = false;

                    kdtpResponse.Visible = false;

                    kmtxtResponse.Visible = false;

                    krtbResponse.Visible = false;

                    ktxtResponse.Visible = false;

                    knudResponse.Visible = false;

                    kpnlResponse.Visible = false;
                    break;
                case KryptonInputBoxResponseType.PasswordBox:
                    kcmbResponse.Visible = false;

                    kdudResponse.Visible = false;

                    kdtpResponse.Visible = false;

                    kmtxtResponse.Visible = false;

                    krtbResponse.Visible = false;

                    ktxtResponse.Visible = true;

                    ktxtResponse.UseSystemPasswordChar = true;

                    knudResponse.Visible = false;
                    break;
                case KryptonInputBoxResponseType.RichTextBox:
                    kcmbResponse.Visible = false;

                    kdudResponse.Visible = false;

                    kdtpResponse.Visible = false;

                    kmtxtResponse.Visible = false;

                    krtbResponse.Visible = true;

                    ktxtResponse.Visible = false;

                    knudResponse.Visible = false;
                    break;
                case KryptonInputBoxResponseType.TextBox:
                    kcmbResponse.Visible = false;

                    kdudResponse.Visible = false;

                    kdtpResponse.Visible = false;

                    kmtxtResponse.Visible = false;

                    krtbResponse.Visible = false;

                    ktxtResponse.Visible = true;

                    kdudResponse.Visible = false;
                    break;
                case KryptonInputBoxResponseType.NumericUpDown:
                    kcmbResponse.Visible = true;

                    kdudResponse.Visible = false;

                    kdtpResponse.Visible = false;

                    kmtxtResponse.Visible = false;

                    krtbResponse.Visible = false;

                    ktxtResponse.Visible = false;

                    knudResponse.Visible = true;
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

                    tableLayoutPanel1.Controls.Add(kwlPrompt, 0, 0);

                    tableLayoutPanel1.SetColumnSpan(kwlPrompt, 2);
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
                    if (OSUtilities.IsWindowsEleven)
                    {
                        pbxIcon.Image = Properties.Resources.UAC_Shield_Windows_11_Information_Box;
                    }
                    else if (OSUtilities.IsWindowsTen)
                    {
                        pbxIcon.Image = Properties.Resources.UAC_Shield_Windows_10_Information_Box;
                    }
                    else
                    {
                        pbxIcon.Image = Properties.Resources.UAC_Shield_Windows_7_Information_Box;
                    }
                    break;
                case InputBoxIconType.WindowsLogo:
                    if (OSUtilities.IsWindowsEleven)
                    {
                        pbxIcon.Image = Properties.Resources.Windows11_Information_Box;
                    }
                    else if (OSUtilities.IsWindowsTen || OSUtilities.IsWindowsEightPointOne || OSUtilities.IsWindowsEight)
                    {
                        pbxIcon.Image = Properties.Resources.Windows_8_and_10_Logo_Information_Box;
                    }
                    else if (OSUtilities.IsWindowsSeven)
                    {
                        pbxIcon.Image = Properties.Resources.Windows_7_Information_Box;
                    }
                    else
                    {
                        pbxIcon.Image = SystemIcons.WinLogo.ToBitmap();
                    }
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
                    kbtnButtonOne.Visible = false;

                    kbtnButtonOne.DialogResult = DialogResult.None;

                    kbtnButtonTwo.Visible = false;

                    kbtnButtonTwo.DialogResult = DialogResult.None;

                    kbtnButtonThree.Text = KryptonManager.Strings.OK;

                    kbtnButtonThree.DialogResult = DialogResult.OK;

                    AcceptButton = kbtnButtonThree;

                    CancelButton = null;
                    break;
                case InputBoxButtons.OkCancel:
                    kbtnButtonOne.Visible = false;

                    kbtnButtonOne.DialogResult = DialogResult.None;

                    kbtnButtonTwo.Text = KryptonManager.Strings.OK;

                    kbtnButtonTwo.DialogResult = DialogResult.OK;

                    kbtnButtonThree.Text = KryptonManager.Strings.Cancel;

                    kbtnButtonThree.DialogResult = DialogResult.Cancel;

                    AcceptButton = kbtnButtonTwo;

                    CancelButton = kbtnButtonThree;
                    break;
                case InputBoxButtons.YesNo:
                    kbtnButtonOne.Visible = false;

                    kbtnButtonOne.DialogResult = DialogResult.None;

                    kbtnButtonTwo.Text = KryptonManager.Strings.Yes;

                    kbtnButtonTwo.DialogResult = DialogResult.Yes;

                    kbtnButtonThree.Text = KryptonManager.Strings.No;

                    kbtnButtonThree.DialogResult = DialogResult.No;

                    AcceptButton = kbtnButtonTwo;

                    CancelButton = kbtnButtonThree;
                    break;
                case InputBoxButtons.YesNoCancel:
                    kbtnButtonOne.Text = KryptonManager.Strings.Yes;

                    kbtnButtonOne.DialogResult = DialogResult.Yes;

                    kbtnButtonTwo.Text = KryptonManager.Strings.No;

                    kbtnButtonTwo.DialogResult = DialogResult.No;

                    kbtnButtonThree.Text = KryptonManager.Strings.Cancel;

                    kbtnButtonThree.DialogResult = DialogResult.Cancel;

                    AcceptButton = kbtnButtonOne;

                    CancelButton = kbtnButtonThree;
                    break;
            }

            switch (buttonFocus)
            {
                case InputBoxButtonFocus.ButtonOne:
                    if (kbtnButtonOne.Visible)
                    {
                        kbtnButtonOne.Focus();
                    }
                    else
                    {
                        kbtnButtonTwo.Focus();
                    }
                    break;
                case InputBoxButtonFocus.ButtonTwo:
                    kbtnButtonTwo.Focus();
                    break;
                case InputBoxButtonFocus.ButtonThree:
                    kbtnButtonThree.Focus();
                    break;
                case InputBoxButtonFocus.ButtonFour:
                    kbtnButtonThree.Focus();
                    break;
            }
        }

        /// <summary>Sets the prompt text.</summary>
        /// <param name="promptText">The prompt text.</param>
        private void SetPromptText(string promptText) => kwlPrompt.Text = promptText;

        /// <summary>Sets the prompt typeface.</summary>
        /// <param name="promptTypeface">The prompt typeface.</param>
        private void SetPromptTypeface(Font promptTypeface) => kwlPrompt.Font = promptTypeface;

        /// <summary>Sets the input typeface.</summary>
        /// <param name="inputTypeface">The input typeface.</param>
        private void SetInputTypeface(Font inputTypeface)
        {
            kcmbResponse.Font = inputTypeface;

            kdtpResponse.StateCommon.Content.Font = inputTypeface;

            kmtxtResponse.StateCommon.Content.Font = inputTypeface;

            ktxtResponse.StateCommon.Content.Font = inputTypeface;
        }

        /// <summary>Sets the button typeface.</summary>
        /// <param name="buttonTypeface">The button typeface.</param>
        private void SetButtonTypeface(Font buttonTypeface)
        {
            kbtnButtonOne.StateCommon.Content.ShortText.Font = buttonTypeface;

            kbtnButtonTwo.StateCommon.Content.ShortText.Font = buttonTypeface;

            kbtnButtonThree.StateCommon.Content.ShortText.Font = buttonTypeface;
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

            if (_inputType == KryptonInputBoxResponseType.ComboBox)
            {
                output = kcmbResponse.Text;
            }
            else if (_inputType == KryptonInputBoxResponseType.DateTimePicker)
            {
                output = kdtpResponse.Text;
            }
            else if (_inputType == KryptonInputBoxResponseType.MaskedTextBox)
            {
                output = kmtxtResponse.Text;
            }
            else if (_inputType == KryptonInputBoxResponseType.None)
            {
                output = string.Empty;
            }
            else if (_inputType == KryptonInputBoxResponseType.PasswordBox)
            {
                output = ktxtResponse.Text;
            }
            else if (_inputType == KryptonInputBoxResponseType.RichTextBox)
            {
                output = krtbResponse.Text;
            }
            else if (_inputType == KryptonInputBoxResponseType.TextBox)
            {
                output = ktxtResponse.Text;
            }
            else if (_inputType == KryptonInputBoxResponseType.DomainUpDown)
            {
                output = kdudResponse.Text;
            }
            else if (_inputType == KryptonInputBoxResponseType.NumericUpDown)
            {
                output = knudResponse.Text;
            }

            return output;
        }

        /// <summary>Updates the text.</summary>
        private void UpdateText()
        {
            Text = _caption;

            kwlPrompt.Text = _prompt;

            if (_inputType == KryptonInputBoxResponseType.ComboBox)
            {
                kcmbResponse.Text = _defaultResponse;
            }
            else if (_inputType == KryptonInputBoxResponseType.DateTimePicker)
            {
                kdtpResponse.Value = GetInitialDateTime();
            }
            else if (_inputType == KryptonInputBoxResponseType.MaskedTextBox)
            {
                kmtxtResponse.Text = _defaultResponse;
            }
            else if (_inputType == KryptonInputBoxResponseType.PasswordBox)
            {
                ktxtResponse.Text = _defaultResponse;
            }
            else if (_inputType == KryptonInputBoxResponseType.RichTextBox)
            {
                krtbResponse.Text = _defaultResponse;
            }
            else if (_inputType == KryptonInputBoxResponseType.TextBox)
            {
                ktxtResponse.Text = _defaultResponse;
            }
        }

        private DateTime GetInitialDateTime() => _initialDateTime;

        /// <summary>Sets the text alignment.</summary>
        /// <param name="textAlignment">The text alignment.</param>
        private void SetTextAlignment(InputBoxTextAlignment textAlignment)
        {
            switch (textAlignment)
            {
                case InputBoxTextAlignment.Left:
                    kcmbResponse.StateCommon.ComboBox.Content.TextH = PaletteRelativeAlign.Near;

                    kdtpResponse.StateCommon.Content.TextH = PaletteRelativeAlign.Near;

                    kmtxtResponse.TextAlign = HorizontalAlignment.Left;

                    krtbResponse.StateCommon.Content.TextH = PaletteRelativeAlign.Near;

                    ktxtResponse.StateCommon.Content.TextH = PaletteRelativeAlign.Near;
                    break;
                case InputBoxTextAlignment.Centre:
                    kcmbResponse.StateCommon.ComboBox.Content.TextH = PaletteRelativeAlign.Center;

                    kdtpResponse.StateCommon.Content.TextH = PaletteRelativeAlign.Center;

                    kmtxtResponse.TextAlign = HorizontalAlignment.Center;

                    krtbResponse.StateCommon.Content.TextH = PaletteRelativeAlign.Center;

                    ktxtResponse.StateCommon.Content.TextH = PaletteRelativeAlign.Center;
                    break;
                case InputBoxTextAlignment.Right:
                    kcmbResponse.StateCommon.ComboBox.Content.TextH = PaletteRelativeAlign.Far;

                    kdtpResponse.StateCommon.Content.TextH = PaletteRelativeAlign.Far;

                    kmtxtResponse.TextAlign = HorizontalAlignment.Right;

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
                    kwlPrompt.TextAlign = ContentAlignment.TopLeft;
                    break;
                case InputBoxWrappedMessageTextAlignment.TopCentre:
                    kwlPrompt.TextAlign = ContentAlignment.TopCenter;
                    break;
                case InputBoxWrappedMessageTextAlignment.TopRight:
                    kwlPrompt.TextAlign = ContentAlignment.TopRight;
                    break;
                case InputBoxWrappedMessageTextAlignment.MiddleLeft:
                    kwlPrompt.TextAlign = ContentAlignment.MiddleLeft;
                    break;
                case InputBoxWrappedMessageTextAlignment.MiddleCentre:
                    kwlPrompt.TextAlign = ContentAlignment.MiddleCenter;
                    break;
                case InputBoxWrappedMessageTextAlignment.MiddleRight:
                    kwlPrompt.TextAlign = ContentAlignment.MiddleRight;
                    break;
                case InputBoxWrappedMessageTextAlignment.BottomLeft:
                    kwlPrompt.TextAlign = ContentAlignment.BottomLeft;
                    break;
                case InputBoxWrappedMessageTextAlignment.BottomCentre:
                    kwlPrompt.TextAlign = ContentAlignment.BottomCenter;
                    break;
                case InputBoxWrappedMessageTextAlignment.BottomRight:
                    kwlPrompt.TextAlign = ContentAlignment.BottomRight;
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
        /// <param name="initialDateTime">The initial date time.</param>
        /// <returns>The users input string.</returns>
        internal static string InternalShow(IWin32Window? owner, string prompt, string caption,
                                            string defaultResponse, string cueText, Color cueColour,
                                            Font cueTypeface, Font buttonTypeface, Font promptTypeface,
                                            InputBoxIconType iconType,
                                            KryptonInputBoxResponseType inputType,
                                            InputBoxTextAlignment textAlignment,
                                            InputBoxWrappedMessageTextAlignment textWrappedMessageTextAlignment,
                                            InputBoxButtons buttons = InputBoxButtons.OkCancel,
                                            InputBoxButtonFocus focusedButton = InputBoxButtonFocus.ButtonFour,
                                            Image customImage = null, DateTime? initialDateTime = null)
        {
            IWin32Window showOwner = owner ?? FromHandle(PlatformInvoke.GetActiveWindow());

            using KryptonInputBoxExtendedForm kibe = new(prompt, caption, defaultResponse, cueText, cueColour,
                                                         cueTypeface, buttonTypeface, promptTypeface,
                                                         iconType, inputType, textAlignment,
                                                         textWrappedMessageTextAlignment, buttons,
                                                         focusedButton, customImage, initialDateTime);

            kibe.StartPosition = showOwner == null ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent;

            return kibe.ShowDialog(showOwner) == DialogResult.OK ? kibe.InputResponse : string.Empty;
        }

        private void Response_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                kbtnButtonThree.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                kbtnButtonThree.PerformClick();
            }
        }

        #endregion
    }
}