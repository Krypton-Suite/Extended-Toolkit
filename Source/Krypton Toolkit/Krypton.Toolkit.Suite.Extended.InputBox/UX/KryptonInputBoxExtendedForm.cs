using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private Font _cueTypeface;
        private InputBoxIconType _iconType;
        private KryptonInputBoxType _inputType;
        private InputBoxTextAlignment _textAlignment;
        private InputBoxWrappedMessageTextAlignment _textWrappedMessageTextAlignment;
        private InputBoxButtons _buttons;
        private InputBoxButtonFocus _focusedButton;
        private Image _customImage;
        private Properties.Resources _resources = new Properties.Resources();
        
        #endregion

        #region Identity

        public KryptonInputBoxExtendedForm()
        {
            InitializeComponent();
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtendedForm" /> class.</summary>
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
        public KryptonInputBoxExtendedForm(Color cueColour, string prompt, string caption, string defaultResponse, string cueText, 
                                          Font cueTypeface, InputBoxIconType iconType, KryptonInputBoxType inputType, 
                                          InputBoxTextAlignment textAlignment, InputBoxWrappedMessageTextAlignment textWrappedMessageTextAlignment, 
                                          InputBoxButtons buttons = InputBoxButtons.OkCancel, InputBoxButtonFocus focusedButton = InputBoxButtonFocus.ButtonFour, 
                                          Image customImage = null)
        {
            InitializeComponent();

            StoreValues(cueColour, prompt, caption, defaultResponse, cueText, cueTypeface, iconType, inputType,
                        textAlignment, textWrappedMessageTextAlignment, buttons, focusedButton, customImage);

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
        }

        #endregion

        #region Implementation

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
            Font? cueTypeface, InputBoxIconType? iconType, KryptonInputBoxType? inputType, InputBoxTextAlignment? textAlignment,
            InputBoxWrappedMessageTextAlignment? textWrappedMessageTextAlignment, InputBoxButtons? buttons, InputBoxButtonFocus? focusedButton, Image? customImage)
        {
            _cueColour = cueColour;
            _prompt = prompt;
            _caption = caption;
            _defaultResponse = defaultResponse ?? @"";
            _cueText = cueText ?? @"";
            _cueTypeface = cueTypeface ?? new("", 8f);
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
                    break;
                case InputBoxButtonFocus.ButtonTwo:
                    break;
                case InputBoxButtonFocus.ButtonThree:
                    break;
                case InputBoxButtonFocus.ButtonFour:
                    break;
            }
        }

        private void SetPromptText(string promptText) => _labelPrompt.Text = promptText;

        private void SetTypeface(Font typeface)
        {
            _labelPrompt.Font = typeface;

            kcmbResponse.Font = typeface;

            kdtpResponse.StateCommon.Content.Font = typeface;

            kmtxResponse.StateCommon.Content.Font = typeface;

            ktxtResponse.StateCommon.Content.Font = typeface;

            kbtnInputBoxButtonOne.StateCommon.Content.ShortText.Font = typeface;

            kbtnInputBoxButtonTwo.StateCommon.Content.ShortText.Font = typeface;

            kbtnInputBoxButtonThree.StateCommon.Content.ShortText.Font = typeface;
        }

        private void SetCueColour(Color cueColour)
        {
            kcmbResponse.CueHint.Color1 = cueColour;

            krtbResponse.CueHint.Color1 = cueColour;

            ktxtResponse.CueHint.Color1 = cueColour;
        }

        private void SetCueTypeface(Font cueTypeface)
        {
            kcmbResponse.CueHint.Font = cueTypeface;

            krtbResponse.CueHint.Font = cueTypeface;

            ktxtResponse.CueHint.Font = cueTypeface;
        }

        #endregion
    }
}
