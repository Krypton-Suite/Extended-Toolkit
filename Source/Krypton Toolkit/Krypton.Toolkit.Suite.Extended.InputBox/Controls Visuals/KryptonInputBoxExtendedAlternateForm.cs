﻿#region MIT License
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

using ContentAlignment = System.Drawing.ContentAlignment;

namespace Krypton.Toolkit.Suite.Extended.InputBox
{
    public partial class KryptonInputBoxExtendedAlternateForm : KryptonForm
    {
        #region Variables

        private static DialogResult _response;

        private static string[] _buttonTextArray = new string[4];

        private Image[] _iconImageArray = new Image[7];

        private Image _customImage;

        private DialogResult _buttonOneResult, _buttonTwoResult, _buttonThreeResult, _buttonFourResult;

        #endregion

        #region Properties
        public static DialogResult Response { get => _response; set => _response = value; }

        public Image[] IconImages { get => _iconImageArray; private set => _iconImageArray = value; }

        public Image CustomImage { get => _customImage; set => _customImage = value; }

        [DefaultValue(typeof(DialogResult), "DialogResult.None"), Description("")]
        public DialogResult ButtonOneResult { get => _buttonOneResult; set => _buttonOneResult = value; }

        [DefaultValue(typeof(DialogResult), "DialogResult.None"), Description("")]
        public DialogResult ButtonTwoResult { get => _buttonTwoResult; set => _buttonTwoResult = value; }

        [DefaultValue(typeof(DialogResult), "DialogResult.None"), Description("")]
        public DialogResult ButtonThreeResult { get => _buttonThreeResult; set => _buttonThreeResult = value; }

        [DefaultValue(typeof(DialogResult), "DialogResult.None"), Description("")]
        public DialogResult ButtonFourResult { get => _buttonFourResult; set => _buttonFourResult = value; }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtendedAlternateForm"/> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="language">The language.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        public KryptonInputBoxExtendedAlternateForm(string message, string title = "", InputBoxLanguage language = InputBoxLanguage.English,
            InputBoxInputType type = InputBoxInputType.None, string[]? listItems = null, bool showInTaskBar = false,
            Font? controlTypeface = null, Font? messageTypeface = null, string okText = "&Ok", string yesText = "&Yes",
            string noText = "N&o", string cancelText = "&Cancel", string hintText = "")
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(InputBoxIconType.None);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(InputBoxButtons.Ok, language);

            ChangeButtonVisibility(InputBoxButtons.Ok);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);

            SetDialogResult(DialogResult.OK, DialogResult.None, DialogResult.None, DialogResult.None);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtendedAlternateForm"/> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <param name="language">The language.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        public KryptonInputBoxExtendedAlternateForm(string message, string title = "", InputBoxIconType icon = InputBoxIconType.None,
            Image? image = null, InputBoxLanguage language = InputBoxLanguage.English,
            InputBoxInputType type = InputBoxInputType.None, string[]? listItems = null,
            bool showInTaskBar = false, Font? controlTypeface = null, Font? messageTypeface = null,
            string okText = "&Ok", string yesText = "&Yes", string noText = "N&o",
            string cancelText = "&Cancel", string hintText = "")
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(icon, image);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(InputBoxButtons.Ok, language);

            ChangeButtonVisibility(InputBoxButtons.Ok);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);

            SetDialogResult(DialogResult.None, DialogResult.None, DialogResult.None, DialogResult.OK);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtendedAlternateForm"/> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <param name="language">The language.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        public KryptonInputBoxExtendedAlternateForm(string message, string title = "", InputBoxIconType icon = InputBoxIconType.Information,
            Image? image = null, InputBoxLanguage language = InputBoxLanguage.English, InputBoxButtons buttons = InputBoxButtons.Ok,
            InputBoxInputType type = InputBoxInputType.None, string[]? listItems = null, bool showInTaskBar = false,
            Font? controlTypeface = null, Font? messageTypeface = null, string okText = "&Ok", string yesText = "&Yes",
            string noText = "N&o", string cancelText = "&Cancel", string hintText = "",
            DialogResult buttonOneResult = DialogResult.None, DialogResult buttonTwoResult = DialogResult.None,
            DialogResult buttonThreeResult = DialogResult.None, DialogResult buttonFourResult = DialogResult.None)
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(icon, image);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(buttons, language);

            ChangeButtonVisibility(buttons);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);

            SetDialogResult(buttonOneResult, buttonTwoResult, buttonThreeResult, buttonFourResult);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtendedAlternateForm"/> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <param name="language">The language.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        /// <param name="startPosition">The start position.</param>
        public KryptonInputBoxExtendedAlternateForm(string message, string title = "", InputBoxIconType icon = InputBoxIconType.Information,
            Image image = null, InputBoxLanguage language = InputBoxLanguage.English,
            InputBoxButtons buttons = InputBoxButtons.Ok, InputBoxInputType type = InputBoxInputType.None, string[] listItems = null,
            bool showInTaskBar = false, Font controlTypeface = null, Font messageTypeface = null, string okText = "&Ok",
            string yesText = "&Yes", string noText = "N&o", string cancelText = "&Cancel", string hintText = "",
            FormStartPosition startPosition = FormStartPosition.WindowsDefaultLocation,
            DialogResult buttonOneResult = DialogResult.None, DialogResult buttonTwoResult = DialogResult.None,
            DialogResult buttonThreeResult = DialogResult.None, DialogResult buttonFourResult = DialogResult.None)
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(icon, image);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(buttons, language);

            ChangeButtonVisibility(buttons);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);

            SetStartPosition(startPosition);

            SetDialogResult(buttonOneResult, buttonTwoResult, buttonThreeResult, buttonFourResult);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtendedAlternateForm"/> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <param name="language">The language.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        /// <param name="textAlignment">The text alignment.</param>
        public KryptonInputBoxExtendedAlternateForm(string message, string title = "", InputBoxIconType icon = InputBoxIconType.Information,
            Image? image = null, InputBoxLanguage language = InputBoxLanguage.English, InputBoxButtons buttons = InputBoxButtons.Ok,
            InputBoxInputType type = InputBoxInputType.None, string[]? listItems = null, bool showInTaskBar = false,
            Font? controlTypeface = null, Font? messageTypeface = null, string okText = "&Ok", string yesText = "&Yes",
            string noText = "N&o", string cancelText = "&Cancel", string hintText = "",
            InputBoxWrappedMessageTextAlignment textAlignment = InputBoxWrappedMessageTextAlignment.MiddleLeft,
            DialogResult buttonOneResult = DialogResult.None, DialogResult buttonTwoResult = DialogResult.None,
            DialogResult buttonThreeResult = DialogResult.None, DialogResult buttonFourResult = DialogResult.None)
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(icon, image);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(buttons, language);

            ChangeButtonVisibility(buttons);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);

            SetMessageTextAlignment(textAlignment);

            SetDialogResult(buttonOneResult, buttonTwoResult, buttonThreeResult, buttonFourResult);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtendedAlternateForm"/> class.</summary>
        /// <param name="iconLocation">The icon location.</param>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <param name="language">The language.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        /// <param name="startPosition">The start position.</param>
        /// <param name="textAlignment">The text alignment.</param>
        public KryptonInputBoxExtendedAlternateForm(Point iconLocation, string message, string title = "",
            InputBoxIconType icon = InputBoxIconType.Information, Image? image = null,
            InputBoxLanguage language = InputBoxLanguage.English, InputBoxButtons buttons = InputBoxButtons.Ok,
            InputBoxInputType type = InputBoxInputType.None, string[]? listItems = null, bool showInTaskBar = false,
            Font? controlTypeface = null, Font? messageTypeface = null, string okText = "&Ok", string yesText = "&Yes",
            string noText = "N&o", string cancelText = "&Cancel", string hintText = "",
            FormStartPosition startPosition = FormStartPosition.WindowsDefaultLocation,
            InputBoxTextAlignment textAlignment = InputBoxTextAlignment.Left,
            DialogResult buttonOneResult = DialogResult.None, DialogResult buttonTwoResult = DialogResult.None,
            DialogResult buttonThreeResult = DialogResult.None, DialogResult buttonFourResult = DialogResult.None)
        {
            InitializeComponent();

            PropagateIconImageArray(IconImages);

            SetMessage(message);

            SetTitle(title);

            SetIconType(icon, image);

            SetLanguage(language, okText, yesText, noText, cancelText);

            AdaptButtons(buttons, language);

            ChangeButtonVisibility(buttons);

            AdaptUI(type, listItems);

            SetShowInTaskbar(showInTaskBar);

            SetControlTypeface(controlTypeface);

            SetMessageTypeface(messageTypeface);

            SetHint(hintText);

            RelocateIcon(iconLocation);

            SetTextAlignment(textAlignment);

            SetStartPosition(startPosition);

            SetDialogResult(buttonOneResult, buttonTwoResult, buttonThreeResult, buttonFourResult);
        }

        #endregion

        #region Methods
        /// <summary>
        /// Sets the message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void SetMessage(string message) => kwlMessage.Text = message;

        /// <summary>Sets the title.</summary>
        /// <param name="title">The title.</param>
        private void SetTitle(string title) => Text = title;

        /// <summary>Sets the message typeface.</summary>
        /// <param name="typeface">The typeface.</param>
        private void SetMessageTypeface(Font typeface) => kwlMessage.StateCommon.Font = typeface;

        /// <summary>Sets the show in taskbar.</summary>
        /// <param name="showInTaskbar">if set to <c>true</c> [show in taskbar].</param>
        private void SetShowInTaskbar(bool showInTaskbar) => ShowInTaskbar = showInTaskbar;

        /// <summary>
        /// Sets the hint.
        /// </summary>
        /// <param name="hintText">The hint text.</param>
        private void SetHint(string hintText) => ktxtInput.CueHint.CueHintText = hintText;

        /// <summary>Sets the control typeface.</summary>
        /// <param name="typeface">The typeface.</param>
        private void SetControlTypeface(Font typeface)
        {
            kbtnButtonThree.StateCommon.Content.ShortText.Font = typeface;

            kbtnButtonFour.StateCommon.Content.ShortText.Font = typeface;

            kbtnButtonOne.StateCommon.Content.ShortText.Font = typeface;

            kbtnButtonTwo.StateCommon.Content.ShortText.Font = typeface;
        }

        /// <summary>
        /// Sets the language.
        /// </summary>
        /// <param name="language">The language.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        private void SetLanguage(InputBoxLanguage language, string okText = "", string yesText = "", string noText = "", string cancelText = "")
        {
            switch (language)
            {
                case InputBoxLanguage.Czech:
                    _buttonTextArray = "OK,Ano,Ne,Storno".Split(',');
                    break;
                case InputBoxLanguage.Français:
                    _buttonTextArray = "OK,Oui,Non,Annuler".Split(',');
                    break;
                case InputBoxLanguage.Deutsch:
                    _buttonTextArray = "OK,Ja,Nein,Stornieren".Split(',');
                    break;
                case InputBoxLanguage.Slovakian:
                    _buttonTextArray = "OK,Áno,Nie,Zrušiť".Split(',');
                    break;
                case InputBoxLanguage.Español:
                    _buttonTextArray = "OK,Sí,No,Cancelar".Split(',');
                    break;
                case InputBoxLanguage.Custom:
                    _buttonTextArray = SetCustomText(okText, yesText, noText, cancelText);
                    break;
                default:
                    _buttonTextArray = "OK,Yes,No,Cancel".Split(',');
                    break;
            }
        }

        /// <summary>
        /// Sets the custom text.
        /// </summary>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <returns></returns>
        private static string[] SetCustomText(string okText, string yesText, string noText, string cancelText)
        {
            string[] tempArray = new string[4];

            tempArray = $"{okText},{yesText},{noText},{cancelText}".Split(',');

            return tempArray;
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, EventArgs e)
        {
            KryptonButton button = (KryptonButton)sender;

            switch (button.Name)
            {
                case "kbtnButtonOne":
                    SetResponse(DialogResult.Yes);
                    break;
                case "kbtnButtonTwo":
                    SetResponse(DialogResult.No);
                    break;
                case "kbtnButtonThree":
                    SetResponse(DialogResult.Cancel);
                    break;
                case "kbtnButtonFour":
                    SetResponse(DialogResult.OK);
                    break;
                default:
                    SetResponse(DialogResult.None);
                    break;
            }
        }

        /// <summary>Sets the type of the icon.</summary>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <exception cref="ArgumentNullException"></exception>
        private void SetIconType(InputBoxIconType icon, Image? image = null)
        {
            switch (icon)
            {
                case InputBoxIconType.Custom:
                    if (image != null)
                    {
                        AdaptUI(true);

                        SetIconImage(image);
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                    break;
                case InputBoxIconType.Ok:
                    AdaptUI(true);

                    SetIconImage(Properties.Resources.Ok);
                    break;
                case InputBoxIconType.Error:
                    AdaptUI(true);

                    SetIconImage(Properties.Resources.Critical);
                    break;
                case InputBoxIconType.Exclamation:
                    AdaptUI(true);

                    SetIconImage(Properties.Resources.Warning);
                    break;
                case InputBoxIconType.Information:
                    AdaptUI(true);

                    SetIconImage(Properties.Resources.Information);
                    break;
                case InputBoxIconType.Question:
                    AdaptUI(true);

                    SetIconImage(Properties.Resources.Question);
                    break;
                case InputBoxIconType.None:
                    AdaptUI(false);
                    break;
                case InputBoxIconType.Stop:
                    AdaptUI(true);

                    SetIconImage(Properties.Resources.Stop);
                    break;
                case InputBoxIconType.Hand:
                    AdaptUI(true);

                    SetIconImage(Properties.Resources.Hand);
                    break;
            }
        }

        /// <summary>Sets the icon image.</summary>
        /// <param name="image">The image.</param>
        private void SetIconImage(Image image) => pbxInputBoxIcon.Image = image;

        /// <summary>Adapts the buttons.</summary>
        /// <param name="buttons">The buttons.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        private KryptonButton[] AdaptButtons(InputBoxButtons buttons, InputBoxLanguage language)
        {
            KryptonButton[] buttonArray = new KryptonButton[3];

            #region Set Button Text
            kbtnButtonOne.Text = _buttonTextArray[0];

            kbtnButtonTwo.Text = _buttonTextArray[1];

            kbtnButtonFour.Text = _buttonTextArray[2];

            kbtnButtonThree.Text = _buttonTextArray[3];
            #endregion

            // TODO: Review locations

            switch (buttons)
            {
                case InputBoxButtons.Ok:
                    kbtnButtonOne.Location = new Point(483, 9);

                    buttonArray[0] = kbtnButtonOne;
                    break;
                case InputBoxButtons.OkCancel:
                    kbtnButtonOne.Location = new Point(388, 9);

                    buttonArray[0] = kbtnButtonOne;

                    kbtnButtonThree.Location = new Point(483, 9);

                    buttonArray[1] = kbtnButtonThree;
                    break;
                case InputBoxButtons.YesNo:
                    kbtnButtonTwo.Location = new Point(388, 9);

                    buttonArray[0] = kbtnButtonTwo;

                    kbtnButtonFour.Location = new Point(483, 9);

                    buttonArray[1] = kbtnButtonFour;
                    break;
                case InputBoxButtons.YesNoCancel:
                    kbtnButtonTwo.Location = new Point(293, 9);

                    buttonArray[0] = kbtnButtonTwo;

                    kbtnButtonFour.Location = new Point(388, 9);

                    buttonArray[1] = kbtnButtonFour;

                    kbtnButtonThree.Location = new Point(483, 9);

                    buttonArray[2] = kbtnButtonThree;
                    break;
            }

            foreach (KryptonButton button in buttonArray)
            {
                if (button != null)
                {
                    button.Size = new Size(89, 28);

                    button.Click += Button_Click;
                }
            }

            return buttonArray;
        }

        /// <summary>Adapts the UI.</summary>
        /// <param name="showIconBox">if set to <c>true</c> [show icon box].</param>
        private void AdaptUI(bool showIconBox)
        {
            if (showIconBox)
            {
                pbxInputBoxIcon.Visible = true;

                ResizeControls(new Size(425, 125), new Size(425, 23), new Size(425, 23));
            }
            else
            {
                pbxInputBoxIcon.Visible = false;

                ResizeControls(new Size(559, 126), new Size(560, 23), new Size(560, 23));
            }
        }

        /// <summary>Adapts the UI.</summary>
        /// <param name="type">The type.</param>
        /// <param name="itemList">The item list.</param>
        private void AdaptUI(InputBoxInputType type, string[] itemList)
        {
            if (itemList != null)
            {
                foreach (string item in itemList)
                {
                    kcmbInput.Items.Add(item);
                }

                kcmbInput.SelectedIndex = 0;
            }

            switch (type)
            {
                case InputBoxInputType.ComboBox:
                    ktxtInput.Visible = false;

                    kmtxtInput.Visible = false;

                    kcmbInput.Visible = true;
                    break;
                case InputBoxInputType.TextBox:
                    ktxtInput.Visible = true;

                    kmtxtInput.Visible = false;

                    kcmbInput.Visible = false;
                    break;
                case InputBoxInputType.MaskedTextBox:
                    ktxtInput.Visible = false;

                    kmtxtInput.Visible = true;

                    kcmbInput.Visible = false;
                    break;
            }
        }

        /// <summary>Adapts the display type of the message.</summary>
        /// <param name="displayType">The display type.</param>
        private void AdaptMessageDisplayType(InputBoxMessageDisplayType displayType)
        {
            switch (displayType)
            {
                case InputBoxMessageDisplayType.BorderedLabel:
                    kblMessage.Visible = true;

                    kwlMessage.Visible = false;
                    break;
                case InputBoxMessageDisplayType.Label:
                    kblMessage.Visible = false;

                    kwlMessage.Visible = true;

                    kwlMessage.Visible = false;
                    break;
                case InputBoxMessageDisplayType.WrappedLabel:
                    kblMessage.Visible = false;

                    kwlMessage.Visible = false;

                    kwlMessage.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Resizes the controls.
        /// </summary>
        /// <param name="messageLabelSize">Size of the message label.</param>
        /// <param name="userSelectionSize">Size of the user selection.</param>
        /// <param name="userInputSize">Size of the user input.</param>
        /// <returns></returns>
        private void ResizeControls(Size messageLabelSize, Size userSelectionSize, Size userInputSize)
        {
            kblMessage.Size = messageLabelSize;

            klblMessage.Size = messageLabelSize;

            kwlMessage.Size = messageLabelSize;

            kcmbInput.Size = userSelectionSize;

            kmtxtInput.Size = userInputSize;

            ktxtInput.Size = userInputSize;
        }

        /// <summary>
        /// Sets the text alignment.
        /// </summary>
        /// <param name="textAlignment">The text alignment.</param>
        private void SetTextAlignment(InputBoxTextAlignment textAlignment)
        {
            switch (textAlignment)
            {
                case InputBoxTextAlignment.Left:
                    ktxtInput.TextAlign = HorizontalAlignment.Left;
                    break;
                case InputBoxTextAlignment.Centre:
                    ktxtInput.TextAlign = HorizontalAlignment.Center;
                    break;
                case InputBoxTextAlignment.Right:
                    ktxtInput.TextAlign = HorizontalAlignment.Right;
                    break;
            }
        }

        /// <summary>
        /// Gets the user response.
        /// </summary>
        /// <returns></returns>
        public string GetUserResponse() => ktxtInput.Text;

        /// <summary>
        /// Gets the user choice.
        /// </summary>
        /// <returns></returns>
        public string GetUserChoice() => kcmbInput.Text;

        /// <summary>Relocates the icon.</summary>
        /// <param name="newPoint">The new point.</param>
        private void RelocateIcon(Point newPoint) => pbxInputBoxIcon.Location = newPoint;

        private void SetStartPosition(FormStartPosition startPosition) => StartPosition = startPosition;

        /// <summary>
        /// Changes the button visibility.
        /// </summary>
        /// <param name="buttons">The buttons.</param>
        private void ChangeButtonVisibility(InputBoxButtons buttons)
        {
            switch (buttons)
            {
                case InputBoxButtons.Ok:
                    kbtnButtonOne.Visible = true;

                    kbtnButtonThree.Visible = false;

                    kbtnButtonFour.Visible = false;

                    kbtnButtonTwo.Visible = false;
                    break;
                case InputBoxButtons.OkCancel:
                    kbtnButtonOne.Visible = true;

                    kbtnButtonThree.Visible = true;

                    kbtnButtonFour.Visible = false;

                    kbtnButtonTwo.Visible = false;
                    break;
                case InputBoxButtons.YesNo:
                    kbtnButtonOne.Visible = false;

                    kbtnButtonThree.Visible = false;

                    kbtnButtonFour.Visible = true;

                    kbtnButtonTwo.Visible = true;
                    break;
                case InputBoxButtons.YesNoCancel:
                    kbtnButtonOne.Visible = false;

                    kbtnButtonThree.Visible = true;

                    kbtnButtonFour.Visible = true;

                    kbtnButtonTwo.Visible = true;
                    break;
            }
        }

        /// <summary>Sets the mask.</summary>
        /// <param name="maskText">The mask text.</param>
        private void SetMask(string maskText) => kmtxtInput.Mask = maskText;

        /// <summary>Sets the masked textbox text alignment.</summary>
        /// <param name="alignment">The alignment.</param>
        private void SetMaskedTextboxTextAlignment(InputBoxTextAlignment alignment)
        {
            switch (alignment)
            {
                case InputBoxTextAlignment.Left:
                    kmtxtInput.TextAlign = HorizontalAlignment.Left;
                    break;
                case InputBoxTextAlignment.Centre:
                    kmtxtInput.TextAlign = HorizontalAlignment.Center;
                    break;
                case InputBoxTextAlignment.Right:
                    kmtxtInput.TextAlign = HorizontalAlignment.Right;
                    break;
            }
        }

        /*
        /// <summary>Sets the message text alignment.</summary>
        /// <param name="alignment">The alignment.</param>
        private void SetMessageTextAlignment(MessageTextAlignment alignment)
        {
            switch (alignment)
            {
                case MessageTextAlignment.INHERIT:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
                case MessageTextAlignment.NEARNEAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
                    break;
                case MessageTextAlignment.NEARCENTRE:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
                    break;
                case MessageTextAlignment.NEARFAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
                    break;
                case MessageTextAlignment.CENTRENEAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
                    break;
                case MessageTextAlignment.CENTRECENTRE:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
                    break;
                case MessageTextAlignment.CENTREFAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
                    break;
                case MessageTextAlignment.FARNEAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
                    break;
                case MessageTextAlignment.FARCENTRE:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
                    break;
                case MessageTextAlignment.FARFAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
                    break;
                case MessageTextAlignment.INHERITNEAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
                    break;
                case MessageTextAlignment.INHERITCENTRE:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Center;
                    break;
                case MessageTextAlignment.INHERITFAR:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Inherit;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
                    break;
                case MessageTextAlignment.NEARINHERIT:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Near;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
                case MessageTextAlignment.CENTREINHERIT:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Center;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
                case MessageTextAlignment.FARINHERIT:
                    kwlMessage.StateCommon.ShortText.TextH = PaletteRelativeAlign.Far;

                    kwlMessage.StateCommon.ShortText.TextV = PaletteRelativeAlign.Inherit;
                    break;
            }
        }
        */

        /// <summary>Sets the message text alignment.</summary>
        /// <param name="alignment">The alignment.</param>
        private void SetMessageTextAlignment(InputBoxWrappedMessageTextAlignment alignment)
        {
            switch (alignment)
            {
                case InputBoxWrappedMessageTextAlignment.TopLeft:
                    kwlMessage.TextAlign = ContentAlignment.TopLeft;
                    break;
                case InputBoxWrappedMessageTextAlignment.TopCentre:
                    kwlMessage.TextAlign = ContentAlignment.TopCenter;
                    break;
                case InputBoxWrappedMessageTextAlignment.TopRight:
                    kwlMessage.TextAlign = ContentAlignment.TopRight;
                    break;
                case InputBoxWrappedMessageTextAlignment.MiddleLeft:
                    kwlMessage.TextAlign = ContentAlignment.MiddleLeft;
                    break;
                case InputBoxWrappedMessageTextAlignment.MiddleCentre:
                    kwlMessage.TextAlign = ContentAlignment.MiddleCenter;
                    break;
                case InputBoxWrappedMessageTextAlignment.MiddleRight:
                    kwlMessage.TextAlign = ContentAlignment.MiddleRight;
                    break;
                case InputBoxWrappedMessageTextAlignment.BottomLeft:
                    kwlMessage.TextAlign = ContentAlignment.BottomLeft;
                    break;
                case InputBoxWrappedMessageTextAlignment.BottomCentre:
                    kwlMessage.TextAlign = ContentAlignment.BottomCenter;
                    break;
                case InputBoxWrappedMessageTextAlignment.BottomRight:
                    kwlMessage.TextAlign = ContentAlignment.BottomRight;
                    break;
                default:
                    kwlMessage.TextAlign = ContentAlignment.MiddleLeft;
                    break;
            }
        }

        private void PropagateIconImageArray(Image[] imageArray)
        {
            imageArray[0] = Properties.Resources.Critical;

            imageArray[1] = Properties.Resources.Hand;

            imageArray[2] = Properties.Resources.Information;

            imageArray[3] = Properties.Resources.Ok;

            imageArray[4] = Properties.Resources.Question;

            imageArray[5] = Properties.Resources.Stop;

            imageArray[6] = Properties.Resources.Warning;
        }

        private Image[] ReturnIconImageArray() => IconImages;

        private void SetResponse(DialogResult response) => Response = response;

        /// <summary>Sets the dialog result.</summary>
        /// <param name="buttonOneResult">The button one result.</param>
        /// <param name="buttonTwoResult">The button two result.</param>
        /// <param name="buttonThreeResult">The button three result.</param>
        /// <param name="buttonFourResult">The button four result.</param>
        private void SetDialogResult(DialogResult buttonOneResult, DialogResult buttonTwoResult, DialogResult buttonThreeResult, DialogResult buttonFourResult)
        {
            kbtnButtonOne.DialogResult = buttonOneResult;

            kbtnButtonTwo.DialogResult = buttonTwoResult;

            kbtnButtonThree.DialogResult = buttonThreeResult;

            kbtnButtonFour.DialogResult = buttonFourResult;
        }

        /// <summary>Sets the button focus.</summary>
        /// <param name="buttons">The buttons.</param>
        private void SetButtonFocus(InputBoxButtonFocus buttons)
        {
            switch (buttons)
            {
                case InputBoxButtonFocus.ButtonOne:
                    kbtnButtonOne.Focus();
                    break;
                case InputBoxButtonFocus.ButtonTwo:
                    kbtnButtonTwo.Focus();
                    break;
                case InputBoxButtonFocus.ButtonThree:
                    kbtnButtonThree.Focus();
                    break;
                case InputBoxButtonFocus.ButtonFour:
                    kbtnButtonFour.Focus();
                    break;
            }
        }

        /// <summary>Sets the input type focus.</summary>
        /// <param name="inputType">Type of the input.</param>
        private void SetInputTypeFocus(InputBoxInputType inputType)
        {
            switch (inputType)
            {
                case InputBoxInputType.ComboBox:
                    kcmbInput.Focus();
                    break;
                case InputBoxInputType.MaskedTextBox:
                    kmtxtInput.Focus();
                    break;
                case InputBoxInputType.TextBox:
                    ktxtInput.Focus();
                    break;
                case InputBoxInputType.None:
                    kwlMessage.Focus();
                    break;
            }
        }

        private void ResultKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;

                Close();
            }
        }
        #endregion

        #region Event Handlers
        private void KryptonInputBoxExtendedAlternateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Response != DialogResult.None)
            {
                Response = DialogResult;
            }
            else
            {
                DialogResult = Response;
            }
        }

        private void ktxtInput_KeyDown(object sender, KeyEventArgs e) => ResultKeyDown(e);

        private void kbtnButtonOne_Click(object sender, EventArgs e) => kbtnButtonOne.DialogResult = _buttonOneResult;

        private void kbtnButtonTwo_Click(object sender, EventArgs e) => kbtnButtonTwo.DialogResult = _buttonTwoResult;

        private void kbtnButtonThree_Click(object sender, EventArgs e) => kbtnButtonThree.DialogResult = _buttonThreeResult;

        private void kbtnButtonFour_Click(object sender, EventArgs e) => kbtnButtonFour.DialogResult = _buttonFourResult;

        private void kmtxtInput_KeyDown(object sender, KeyEventArgs e) => ResultKeyDown(e);

        private void kcmbInput_KeyDown(object sender, KeyEventArgs e) => ResultKeyDown(e);
        #endregion
    }
}