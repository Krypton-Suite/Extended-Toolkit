using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Messagebox;

namespace MessageBox
{
    public partial class Form1 : KryptonForm
    {
        private ExtendedMessageBoxCustomButtonVisibility _buttonVisibility;
        private ExtendedKryptonMessageBoxIcon _icon;
        private ExtendedMessageBoxButtons _buttons;
        private MessageBoxOptions _options = 0;
        private MessageBoxDefaultButton _defaultButton;
        private Font _buttonTypeface, _textTypeface;
        private float _buttonCornerRounding, _windowCornerRounding;
        private Color _contentMessageColour, _buttonOneBackColourOne, _buttonOneBackColourTwo, _buttonOneTextColourOne,
                      _buttonOneTextColourTwo, _buttonTwoTextColourOne, _buttonTwoTextColourTwo, _buttonTwoBackColourOne,
                      _buttonTwoBackColourTwo, _buttonThreeTextColourOne, _buttonThreeTextColourTwo, _buttonThreeBackColourOne,
                      _buttonThreeBackColourTwo, _yesButtonBackColourOne, _yesButtonBackColourTwo, _yesButtonTextColourOne,
                      _yesButtonTextColourTwo, _noButtonBackColourOne, _noButtonBackColourTwo, _noButtonTextColourOne,
                      _noButtonTextColourTwo;

        private DialogResult _customDialogResultOne, _customDialogResultTwo, _customDialogResultThree;

        private HelpNavigator _helpNavigator;

        private string _customButtonOneText, _customButtonTwoText, _customButtonThreeText;

        public Form1()
        {
            InitializeComponent();
        }

        private void kbtnTest_Click(object sender, EventArgs e)
        {
            KryptonMessageBoxExtended.Show(null, ktxtMessageText.Text, ktxtCaption.Text, GetButtons(), GetIcon(),
                                           GetDefaultButton(), GetMessageBoxOptions(), kcbShowHelpButton.Checked,
                                           null, HelpNavigator.AssociateIndex, null, GetCustomDialogResultOne(),
                                           GetCustomDialogResultTwo(), GetCustomDialogResultThree(),
                                           kcbShowCtrlCopy.Checked, GetButtonTypeface(), GetTextTypeface(),
                                           GetButtonVisibility(), GetCustomButtonOneText(),
                                           GetCustomButtonTwoText(), GetCustomButtonThreeText(),
                                           kcbUseYesNoOrCancelColours.Checked, GetContentMessageColour(),
                                           GetButtonOneBackColourOne(), GetButtonOneBackColourTwo(),
                                           GetButtonOneTextColourOne(), GetButtonOneTextColourTwo(),
                                           GetButtonTwoTextColourOne(), GetButtonTwoTextColourTwo(),
                                           GetButtonTwoBackColourOne(), GetButtonTwoBackColourTwo(),
                                           GetButtonThreeTextColourOne(), GetButtonThreeTextColourTwo(),
                                           GetButtonThreeBackColourOne(), GetButtonThreeBackColourTwo(),
                                           GetYesButtonBackColourOne(), GetYesButtonBackColourTwo(),
                                           GetYesButtonTextColourOne(), GetYesButtonTextColourTwo(),
                                           GetNoButtonBackColourOne(), GetNoButtonBackColourTwo(),
                                           GetNoButtonTextColourOne(), GetNoButtonTextColourTwo(),
                                           GetButtonCornerRounding(), GetWindowCornerRounding(),
                                           kcbShowUACShieldOnAcceptButton.Checked);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThemeManager.PropagateThemeSelector(kcmbSelectedTheme);

            PropagateDialogResults(kcmbButtonOneResult);

            PropagateDialogResults(kcmbButtonTwoResult);

            PropagateDialogResults(kcmbButtonThreeResult);

            kcmbButtonOneResult.SelectedIndex = 0;

            kcmbButtonTwoResult.SelectedIndex = 0;

            kcmbButtonThreeResult.SelectedIndex = 0;

            kcmbSelectedTheme.SelectedIndex = 27;

            kcmbDefaultButton.SelectedIndex = 0;
        }

        private void kcmbSelectedTheme_SelectedIndexChanged(object sender, EventArgs e) => ThemeManager.ApplyTheme(kcmbSelectedTheme.Text, kryptonManager1);

        private void kcmbDefaultButton_SelectedIndexChanged(object sender, EventArgs e) => SetDefaultButtonFromText(kcmbDefaultButton.Text);

        private void kcbShowCtrlCopy_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void kcmbButtonOneResult_SelectedIndexChanged(object sender, EventArgs e) => SetCustomButtonOneResult(kcmbButtonOneResult.Text);

        private void kcmbButtonTwoResult_SelectedIndexChanged(object sender, EventArgs e) => SetCustomButtonTwoResult(kcmbButtonTwoResult.Text);

        private void kcmbButtonThreeResult_SelectedIndexChanged(object sender, EventArgs e) => SetCustomButtonThreeResult(kcmbButtonThreeResult.Text);

        private void kcbtnTextColor_SelectedColorChanged(object sender, ColorEventArgs e) => SetContentMessageColour(kcbtnTextColor.SelectedColor);

        private void kbtnTextTypeface_Click(object sender, EventArgs e)
        {
            KryptonFontDialog kfd = new KryptonFontDialog();

            if (kfd.ShowDialog() == DialogResult.OK)
            {
                SetTextTypeface(kfd.Font);
            }
        }

        private void kbtnButtonTypeface_Click(object sender, EventArgs e)
        {
            KryptonFontDialog kfd = new KryptonFontDialog();

            if (kfd.ShowDialog() == DialogResult.OK)
            {
                SetButtonTypeface(kfd.Font);
            }
        }

        private void kbtnBrowseForCustomIcon_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Portable Network Graphics|*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ktxtCustomIconLocation.Text = Path.GetFullPath(ofd.FileName);
            }
        }

        private void kcbUseYesNoOrCancelColours_CheckedChanged(object sender, EventArgs e) => kgrpYesNoAndCancelButtonOptions.Enabled = kcbUseYesNoOrCancelColours.Checked;

        private void ktxtCustomButtonOneText_TextChanged(object sender, EventArgs e) => SetCustomButtonOneText(ktxtCustomButtonOneText.Text);

        private void ktxtCustomButtonTwoText_TextChanged(object sender, EventArgs e) => SetCustomButtonTwoText(ktxtCustomButtonTwoText.Text);

        private void ktxtCustomButtonThreeText_TextChanged(object sender, EventArgs e) => SetCustomButtonThreeText(ktxtCustomButtonThreeText.Text);

        private void knudButtonRounding_ValueChanged(object sender, EventArgs e)
        {
            SetButtonCornerRounding((float)knudButtonRounding.Value);

            kbtnRoundingTest.StateCommon.Border.Rounding = (float)knudButtonRounding.Value;
        }

        #region Button Options
        private void krbButtonRetryCancel_CheckedChanged(object sender, EventArgs e) => SetButtons(ExtendedMessageBoxButtons.RETRYCANCEL);

        private void krbButtonYesNo_CheckedChanged(object sender, EventArgs e) => SetButtons(ExtendedMessageBoxButtons.YESNO);

        private void krbButtonYesNoCancel_CheckedChanged(object sender, EventArgs e) => SetButtons(ExtendedMessageBoxButtons.YESNOCANCEL);

        private void krbButtonAbortRetryIgnore_CheckedChanged(object sender, EventArgs e) => SetButtons(ExtendedMessageBoxButtons.ABORTRETRYIGNORE);

        private void krbButtonOkCancel_CheckedChanged(object sender, EventArgs e) => SetButtons(ExtendedMessageBoxButtons.OKCANCEL);

        private void krbButtonOk_CheckedChanged(object sender, EventArgs e) => SetButtons(ExtendedMessageBoxButtons.OK);

        private void krbButtonCustom_CheckedChanged(object sender, EventArgs e)
        {
            EnableCustomButtonFeatures(krbButtonCustom.Checked);

            SetButtons(ExtendedMessageBoxButtons.CUSTOM);
        }
        #endregion

        #region Icon Type
        private void krbInformationIcon_CheckedChanged(object sender, EventArgs e) => SetIcon(ExtendedKryptonMessageBoxIcon.INFORMATION);

        private void krbShieldIcon_CheckedChanged(object sender, EventArgs e) => SetIcon(ExtendedKryptonMessageBoxIcon.SHIELD);

        private void krbWindowsLogoIcon_CheckedChanged(object sender, EventArgs e) => SetIcon(ExtendedKryptonMessageBoxIcon.WINDOWSLOGO);

        private void krbWarningIcon_CheckedChanged(object sender, EventArgs e) => SetIcon(ExtendedKryptonMessageBoxIcon.WARNING);

        private void krbErrorIcon_CheckedChanged(object sender, EventArgs e) => SetIcon(ExtendedKryptonMessageBoxIcon.ERROR);

        private void krbStopIcon_CheckedChanged(object sender, EventArgs e) => SetIcon(ExtendedKryptonMessageBoxIcon.STOP);

        private void krbAsteriskIcon_CheckedChanged(object sender, EventArgs e) => SetIcon(ExtendedKryptonMessageBoxIcon.ASTERISK);

        private void krbExclamationIcon_CheckedChanged(object sender, EventArgs e) => SetIcon(ExtendedKryptonMessageBoxIcon.EXCLAMATION);

        private void krbQuestionIcon_CheckedChanged(object sender, EventArgs e) => SetIcon(ExtendedKryptonMessageBoxIcon.QUESTION);

        private void krbHandIcon_CheckedChanged(object sender, EventArgs e) => SetIcon(ExtendedKryptonMessageBoxIcon.HAND);

        private void krbNoIcon_CheckedChanged(object sender, EventArgs e) => SetIcon(ExtendedKryptonMessageBoxIcon.NONE);

        private void krbCustomIcon_CheckedChanged(object sender, EventArgs e)
        {
            SetIcon(ExtendedKryptonMessageBoxIcon.CUSTOM);
        }
        #endregion

        #region Custom Button Visibility
        private void krbNoButtons_CheckedChanged(object sender, EventArgs e) => SetButtonVisibility(ExtendedMessageBoxCustomButtonVisibility.NONE);

        private void krbOneButton_CheckedChanged(object sender, EventArgs e) => SetButtonVisibility(ExtendedMessageBoxCustomButtonVisibility.ONEBUTTON);

        private void krbTwoButtons_CheckedChanged(object sender, EventArgs e) => SetButtonVisibility(ExtendedMessageBoxCustomButtonVisibility.TWOBUTTONS);

        private void krbThreeButtons_CheckedChanged(object sender, EventArgs e) => SetButtonVisibility(ExtendedMessageBoxCustomButtonVisibility.THREEBUTTONS);

        #endregion

        #region Custom Button Colours
        private void kcbtnButtonOneTextColorOne_SelectedColorChanged(object sender, ColorEventArgs e) => SetButtonOneTextColourOne(kcbtnButtonOneTextColorOne.SelectedColor);

        private void kcbtnButtonOneTextColorTwo_SelectedColorChanged(object sender, ColorEventArgs e) => SetButtonOneTextColourTwo(kcbtnButtonOneTextColorTwo.SelectedColor);

        private void kcbtnButtonOneBackColorOne_SelectedColorChanged(object sender, ColorEventArgs e) => SetButtonOneBackColourOne(kcbtnButtonOneBackColorOne.SelectedColor);

        private void kcbtnButtonOneBackColorTwo_SelectedColorChanged(object sender, ColorEventArgs e) => SetButtonOneBackColourTwo(kcbtnButtonOneBackColorTwo.SelectedColor);

        private void kcbtnButtonTwoTextColorOne_SelectedColorChanged(object sender, ColorEventArgs e) => SetButtonTwoTextColourOne(kcbtnButtonTwoTextColorOne.SelectedColor);

        private void kcbtnButtonTwoTextColorTwo_SelectedColorChanged(object sender, ColorEventArgs e) => SetButtonTwoTextColourTwo(kcbtnButtonTwoTextColorTwo.SelectedColor);

        private void kcbtnButtonTwoBackColorOne_SelectedColorChanged(object sender, ColorEventArgs e) => SetButtonTwoBackColourOne(kcbtnButtonTwoBackColorOne.SelectedColor);

        private void kcbtnButtonTwoBackColorTwo_SelectedColorChanged(object sender, ColorEventArgs e) => SetButtonTwoBackColourTwo(kcbtnButtonTwoBackColorTwo.SelectedColor);

        private void kcbtnButtonThreeTextColorOne_SelectedColorChanged(object sender, ColorEventArgs e) => SetButtonThreeTextColourOne(kcbtnButtonThreeTextColorOne.SelectedColor);

        private void kcbtnButtonThreeTextColorTwo_SelectedColorChanged(object sender, ColorEventArgs e) => SetButtonThreeTextColourTwo(kcbtnButtonTwoTextColorOne.SelectedColor);

        private void kcbtnButtonThreeBackColorOne_SelectedColorChanged(object sender, ColorEventArgs e) => SetButtonThreeBackColourOne(kcbtnButtonThreeBackColorOne.SelectedColor);

        private void kcbtnButtonThreeBackColorTwo_SelectedColorChanged(object sender, ColorEventArgs e) => SetButtonThreeBackColourTwo(kcbtnButtonThreeBackColorTwo.SelectedColor);
        #endregion

        #region Yes, No & Cancel Button Colours
        private void kcbtnYesTextOne_SelectedColorChanged(object sender, ColorEventArgs e) => SetYesButtonTextColourOne(kcbtnYesTextOne.SelectedColor);

        private void kcbtnYesTextTwo_SelectedColorChanged(object sender, ColorEventArgs e) => SetYesButtonTextColourTwo(kcbtnYesTextTwo.SelectedColor);

        private void kcbtnYesBackOne_SelectedColorChanged(object sender, ColorEventArgs e) => SetYesButtonBackColourOne(kcbtnYesBackOne.SelectedColor);

        private void kcbtnYesBackTwo_SelectedColorChanged(object sender, ColorEventArgs e) => SetYesButtonBackColourTwo(kcbtnYesBackTwo.SelectedColor);

        private void kcbtnNoTextOne_SelectedColorChanged(object sender, ColorEventArgs e) => SetNoButtonTextColourOne(kcbtnNoTextOne.SelectedColor);

        private void kcbtnNoTextTwo_SelectedColorChanged(object sender, ColorEventArgs e) => SetNoButtonTextColourTwo(kcbtnNoTextTwo.SelectedColor);

        private void kcbtnNoBackOne_SelectedColorChanged(object sender, ColorEventArgs e) => SetNoButtonBackColourOne(kcbtnNoBackOne.SelectedColor);

        private void kcbtnNoBackTwo_SelectedColorChanged(object sender, ColorEventArgs e) => SetNoButtonBackColourTwo(kcbtnNoBackTwo.SelectedColor);

        private void kcbtnCancelTextOne_SelectedColorChanged(object sender, ColorEventArgs e)
        {

        }

        private void kcbtnCancelTextTwo_SelectedColorChanged(object sender, ColorEventArgs e)
        {

        }

        private void kcbtnCancelBackOne_SelectedColorChanged(object sender, ColorEventArgs e)
        {

        }

        private void kcbtnCancelBackTwo_SelectedColorChanged(object sender, ColorEventArgs e)
        {

        }
        #endregion

        #region Setters & Getters
        /// <summary>
        /// Sets the ButtonVisibility to the value of value.
        /// </summary><param name="value">The desired value of ButtonVisibility.</param>
        private void SetButtonVisibility(ExtendedMessageBoxCustomButtonVisibility value) => _buttonVisibility = value;

        /// <summary>
        /// Returns the value of the ButtonVisibility.
        /// </summary><returns>The value of the ButtonVisibility.</returns>
        private ExtendedMessageBoxCustomButtonVisibility GetButtonVisibility() => _buttonVisibility;

        /// <summary>Sets the icon.</summary>
        /// <param name="icon">The icon.</param>
        private void SetIcon(ExtendedKryptonMessageBoxIcon icon) => _icon = icon;

        /// <summary>Gets the icon.</summary>
        /// <returns></returns>
        private ExtendedKryptonMessageBoxIcon GetIcon() => _icon;

        /// <summary>Sets the buttons.</summary>
        /// <param name="buttons">The buttons.</param>
        private void SetButtons(ExtendedMessageBoxButtons buttons) => _buttons = buttons;

        /// <summary>Gets the buttons.</summary>
        /// <returns></returns>
        private ExtendedMessageBoxButtons GetButtons() => _buttons;

        /// <summary>Sets the message box options.</summary>
        /// <param name="options">The options.</param>
        private void SetMessageBoxOptions(MessageBoxOptions options) => _options = options;

        /// <summary>Gets the message box options.</summary>
        /// <returns></returns>
        private MessageBoxOptions GetMessageBoxOptions() => _options;

        /// <summary>Sets the button typeface.</summary>
        /// <param name="buttonTypeface">The button typeface.</param>
        private void SetButtonTypeface(Font buttonTypeface) => _buttonTypeface = buttonTypeface;

        /// <summary>Gets the button typeface.</summary>
        /// <returns></returns>
        private Font GetButtonTypeface() => _buttonTypeface;

        /// <summary>Sets the text typeface.</summary>
        /// <param name="textTypeface">The text typeface.</param>
        private void SetTextTypeface(Font textTypeface) => _textTypeface = textTypeface;

        /// <summary>Gets the text typeface.</summary>
        /// <returns></returns>
        private Font GetTextTypeface() => _textTypeface;

        /// <summary>Sets the content message colour.</summary>
        /// <param name="contentMessageColour">The content message colour.</param>
        private void SetContentMessageColour(Color contentMessageColour) => _contentMessageColour = contentMessageColour;

        /// <summary>Gets the content message colour.</summary>
        /// <returns></returns>
        private Color GetContentMessageColour() => _contentMessageColour;

        /// <summary>Sets the button one back colour one.</summary>
        /// <param name="buttonOneBackColourOne">The button one back colour one.</param>
        private void SetButtonOneBackColourOne(Color buttonOneBackColourOne) => _buttonOneBackColourOne = buttonOneBackColourOne;

        /// <summary>Gets the button one back colour one.</summary>
        /// <returns></returns>
        private Color GetButtonOneBackColourOne() => _buttonOneBackColourOne;

        /// <summary>Sets the button one back colour two.</summary>
        /// <param name="buttonOneBackColourTwo">The button one back colour two.</param>
        private void SetButtonOneBackColourTwo(Color buttonOneBackColourTwo) => _buttonOneBackColourTwo = buttonOneBackColourTwo;

        /// <summary>Gets the button one back colour two.</summary>
        /// <returns></returns>
        private Color GetButtonOneBackColourTwo() => _buttonOneBackColourTwo;

        /// <summary>Sets the button one text colour one.</summary>
        /// <param name="buttonOneTextColourOne">The button one text colour one.</param>
        private void SetButtonOneTextColourOne(Color buttonOneTextColourOne) => _buttonOneTextColourOne = buttonOneTextColourOne;

        /// <summary>Gets the button one text colour one.</summary>
        /// <returns></returns>
        private Color GetButtonOneTextColourOne() => _buttonOneTextColourOne;

        /// <summary>Sets the button one text colour two.</summary>
        /// <param name="buttonOneTextColourTwo">The button one text colour two.</param>
        private void SetButtonOneTextColourTwo(Color buttonOneTextColourTwo) => _buttonOneTextColourTwo = buttonOneTextColourTwo;

        /// <summary>Gets the button one text colour two.</summary>
        /// <returns></returns>
        private Color GetButtonOneTextColourTwo() => _buttonOneTextColourTwo;

        /// <summary>Sets the button two text colour one.</summary>
        /// <param name="buttonTwoTextColourOne">The button two text colour one.</param>
        private void SetButtonTwoTextColourOne(Color buttonTwoTextColourOne) => _buttonTwoTextColourOne = buttonTwoTextColourOne;

        /// <summary>Gets the button two text colour one.</summary>
        /// <returns></returns>
        private Color GetButtonTwoTextColourOne() => _buttonTwoTextColourOne;

        /// <summary>
        /// Sets the ButtonTwoTextColourTwo to the value of buttonTwoTextColourTwo.
        /// </summary>
        /// <param name="buttonTwoTextColourTwo">The desired value of ButtonTwoTextColourTwo.</param>
        private void SetButtonTwoTextColourTwo(Color buttonTwoTextColourTwo) => _buttonTwoTextColourTwo = buttonTwoTextColourTwo;

        /// <summary>
        /// Returns the value of the ButtonTwoTextColourTwo.
        /// </summary>
        /// <returns>The value of the ButtonTwoTextColourTwo.</returns>
        private Color GetButtonTwoTextColourTwo() => _buttonTwoTextColourTwo;

        /// <summary>
        /// Sets the ButtonTwoBackColourOne to the value of buttonTwoBackColourOne.
        /// </summary>
        /// <param name="buttonTwoBackColourOne">The desired value of ButtonTwoBackColourOne.</param>
        private void SetButtonTwoBackColourOne(Color buttonTwoBackColourOne) => _buttonTwoBackColourOne = buttonTwoBackColourOne;

        /// <summary>
        /// Returns the value of the ButtonTwoBackColourOne.
        /// </summary>
        /// <returns>The value of the ButtonTwoBackColourOne.</returns>
        private Color GetButtonTwoBackColourOne() => _buttonTwoBackColourOne;

        /// <summary>
        /// Sets the ButtonTwoBackColourTwo to the value of _buttonTwoBackColourTwo.
        /// </summary>
        /// <param name="buttonTwoBackColourTwo">The desired value of ButtonTwoBackColourTwo.</param>
        private void SetButtonTwoBackColourTwo(Color buttonTwoBackColourTwo) => _buttonTwoBackColourTwo = buttonTwoBackColourTwo;

        /// <summary>
        /// Returns the value of the ButtonTwoBackColourTwo.
        /// </summary>
        /// <returns>The value of the ButtonTwoBackColourTwo.</returns>
        private Color GetButtonTwoBackColourTwo() => _buttonTwoBackColourTwo;

        /// <summary>
        /// Sets the ButtonThreeTextColourOne to the value of buttonThreeTextColourOne.
        /// </summary>
        /// <param name="buttonThreeTextColourOne">The desired value of ButtonThreeTextColourOne.</param>
        private void SetButtonThreeTextColourOne(Color buttonThreeTextColourOne) => _buttonThreeTextColourOne = buttonThreeTextColourOne;

        /// <summary>
        /// Returns the value of the ButtonThreeTextColourOne.
        /// </summary>
        /// <returns>The value of the ButtonThreeTextColourOne.</returns>
        private Color GetButtonThreeTextColourOne() => _buttonThreeTextColourOne;

        /// <summary>
        /// Sets the ButtonThreeTextColourTwo to the value of buttonThreeTextColourTwo.
        /// </summary>
        /// <param name="buttonThreeTextColourTwo">The desired value of ButtonThreeTextColourTwo.</param>
        private void SetButtonThreeTextColourTwo(Color buttonThreeTextColourTwo) => _buttonThreeTextColourTwo = buttonThreeTextColourTwo;

        /// <summary>
        /// Returns the value of the ButtonThreeTextColourTwo.
        /// </summary>
        /// <returns>The value of the ButtonThreeTextColourTwo.</returns>
        private Color GetButtonThreeTextColourTwo() => _buttonThreeTextColourTwo;

        /// <summary>
        /// Sets the ButtonThreeBackColourOne to the value of buttonThreeBackColourOne.
        /// </summary>
        /// <param name="buttonThreeBackColourOne">The desired value of ButtonThreeBackColourOne.</param>
        private void SetButtonThreeBackColourOne(Color buttonThreeBackColourOne) => _buttonThreeBackColourOne = buttonThreeBackColourOne;

        /// <summary>
        /// Returns the value of the ButtonThreeBackColourOne.
        /// </summary>
        /// <returns>The value of the ButtonThreeBackColourOne.</returns>
        private Color GetButtonThreeBackColourOne() => _buttonThreeBackColourOne;

        /// <summary>
        /// Sets the ButtonThreeBackColourTwo to the value of buttonThreeBackColourTwo.
        /// </summary>
        /// <param name="buttonThreeBackColourTwo">The desired value of ButtonThreeBackColourTwo.</param>
        private void SetButtonThreeBackColourTwo(Color buttonThreeBackColourTwo) => _buttonThreeBackColourTwo = buttonThreeBackColourTwo;

        /// <summary>
        /// Returns the value of the ButtonThreeBackColourTwo.
        /// </summary>
        /// <returns>The value of the ButtonThreeBackColourTwo.</returns>
        private Color GetButtonThreeBackColourTwo() => _buttonThreeBackColourTwo;

        /// <summary>
        /// Sets the YesButtonBackColourOne to the value of yesButtonBackColourOne.
        /// </summary>
        /// <param name="yesButtonBackColourOne">The desired value of YesButtonBackColourOne.</param>
        private void SetYesButtonBackColourOne(Color yesButtonBackColourOne) => _yesButtonBackColourOne = yesButtonBackColourOne;

        /// <summary>
        /// Returns the value of the YesButtonBackColourOne.
        /// </summary>
        /// <returns>The value of the YesButtonBackColourOne.</returns>
        private Color GetYesButtonBackColourOne() => _yesButtonBackColourOne;

        /// <summary>
        /// Sets the YesButtonBackColourTwo to the value of yesButtonBackColourTwo.
        /// </summary>
        /// <param name="yesButtonBackColourTwo">The desired value of YesButtonBackColourTwo.</param>
        private void SetYesButtonBackColourTwo(Color yesButtonBackColourTwo) => _yesButtonBackColourTwo = yesButtonBackColourTwo;

        /// <summary>
        /// Returns the value of the YesButtonBackColourTwo.
        /// </summary>
        /// <returns>The value of the YesButtonBackColourTwo.</returns>
        private Color GetYesButtonBackColourTwo() => _yesButtonBackColourTwo;

        /// <summary>
        /// Sets the YesButtonTextColourOne to the value of yesButtonTextColourOne.
        /// </summary>
        /// <param name="yesButtonTextColourOne">The desired value of YesButtonTextColourOne.</param>
        private void SetYesButtonTextColourOne(Color yesButtonTextColourOne) => _yesButtonTextColourOne = yesButtonTextColourOne;

        /// <summary>
        /// Returns the value of the YesButtonTextColourOne.
        /// </summary>
        /// <returns>The value of the YesButtonTextColourOne.</returns>
        private Color GetYesButtonTextColourOne() => _yesButtonTextColourOne;

        /// <summary>
        /// Sets the YesButtonTextColourTwo to the value of yesButtonTextColourTwo.
        /// </summary>
        /// <param name="yesButtonTextColourTwo">The desired value of YesButtonTextColourTwo.</param>
        private void SetYesButtonTextColourTwo(Color yesButtonTextColourTwo) => _yesButtonTextColourTwo = yesButtonTextColourTwo;

        /// <summary>
        /// Returns the value of the YesButtonTextColourTwo.
        /// </summary>
        /// <returns>The value of the YesButtonTextColourTwo.</returns>
        private Color GetYesButtonTextColourTwo() => _yesButtonTextColourTwo;

        /// <summary>
        /// Sets the NoButtonBackColourOne to the value of noButtonBackColourOne.
        /// </summary>
        /// <param name="noButtonBackColourOne">The desired value of NoButtonBackColourOne.</param>
        private void SetNoButtonBackColourOne(Color noButtonBackColourOne) => _noButtonBackColourOne = noButtonBackColourOne;

        /// <summary>
        /// Returns the value of the NoButtonBackColourOne.
        /// </summary>
        /// <returns>The value of the NoButtonBackColourOne.</returns>
        private Color GetNoButtonBackColourOne() => _noButtonBackColourOne;

        /// <summary>
        /// Sets the NoButtonBackColourTwo to the value of noButtonBackColourTwo.
        /// </summary>
        /// <param name="noButtonBackColourTwo">The desired value of NoButtonBackColourTwo.</param>
        private void SetNoButtonBackColourTwo(Color noButtonBackColourTwo) => _noButtonBackColourTwo = noButtonBackColourTwo;

        /// <summary>
        /// Returns the value of the NoButtonBackColourTwo.
        /// </summary>
        /// <returns>The value of the NoButtonBackColourTwo.</returns>
        private Color GetNoButtonBackColourTwo() => _noButtonBackColourTwo;

        /// <summary>
        /// Sets the NoButtonTextColourOne to the value of noButtonTextColourOne.
        /// </summary>
        /// <param name="noButtonTextColourOne">The desired value of NoButtonTextColourOne.</param>
        private void SetNoButtonTextColourOne(Color noButtonTextColourOne) => _noButtonTextColourOne = noButtonTextColourOne;

        /// <summary>
        /// Returns the value of the NoButtonTextColourOne.
        /// </summary>
        /// <returns>The value of the NoButtonTextColourOne.</returns>
        private Color GetNoButtonTextColourOne() => _noButtonTextColourOne;

        /// <summary>
        /// Sets the NoButtonTextColourTwo to the value of noButtonTextColourTwo.
        /// </summary>
        /// <param name="noButtonTextColourTwo">The desired value of NoButtonTextColourTwo.</param>
        private void SetNoButtonTextColourTwo(Color noButtonTextColourTwo) => _noButtonTextColourTwo = noButtonTextColourTwo;

        /// <summary>
        /// Returns the value of the NoButtonTextColourTwo.
        /// </summary>
        /// <returns>The value of the NoButtonTextColourTwo.</returns>
        private Color GetNoButtonTextColourTwo() => _noButtonTextColourTwo;

        /// <summary>
        /// Sets the DefaultButton to the value of defaultButton.
        /// </summary>
        /// <param name="defaultButton">The desired value of DefaultButton.</param>
        private void SetDefaultButton(MessageBoxDefaultButton defaultButton) => _defaultButton = defaultButton;

        /// <summary>
        /// Returns the value of the DefaultButton.
        /// </summary>
        /// <returns>The value of the DefaultButton.</returns>
        private MessageBoxDefaultButton GetDefaultButton() => _defaultButton;

        /// <summary>
        /// Sets the CustomDialogResultOne to the value of customDialogResultOne.
        /// </summary>
        /// <param name="customDialogResultOne">The desired value of CustomDialogResultOne.</param>
        private void SetCustomDialogResultOne(DialogResult customDialogResultOne) => _customDialogResultOne = customDialogResultOne;

        /// <summary>
        /// Returns the value of the CustomDialogResultOne.
        /// </summary>
        /// <returns>The value of the CustomDialogResultOne.</returns>
        private DialogResult GetCustomDialogResultOne() => _customDialogResultOne;

        /// <summary>
        /// Sets the CustomDialogResultTwo to the value of customDialogResultTwo.
        /// </summary>
        /// <param name="customDialogResultTwo">The desired value of CustomDialogResultTwo.</param>
        private void SetCustomDialogResultTwo(DialogResult customDialogResultTwo) => _customDialogResultTwo = customDialogResultTwo;

        /// <summary>
        /// Returns the value of the CustomDialogResultTwo.
        /// </summary>
        /// <returns>The value of the CustomDialogResultTwo.</returns>
        private DialogResult GetCustomDialogResultTwo() => _customDialogResultTwo;

        /// <summary>
        /// Sets the CustomDialogResultThree to the value of customDialogResultThree.
        /// </summary>
        /// <param name="customDialogResultThree">The desired value of CustomDialogResultThree.</param>
        private void SetCustomDialogResultThree(DialogResult customDialogResultThree) => _customDialogResultThree = customDialogResultThree;

        /// <summary>
        /// Returns the value of the CustomDialogResultThree.
        /// </summary>
        /// <returns>The value of the CustomDialogResultThree.</returns>
        private DialogResult GetCustomDialogResultThree() => _customDialogResultThree;

        /// <summary>
        /// Sets the HelpNavigator to the value of helpNavigator.
        /// </summary>
        /// <param name="helpNavigator">The desired value of HelpNavigator.</param>
        private void SetHelpNavigator(HelpNavigator helpNavigator) => _helpNavigator = helpNavigator;

        /// <summary>
        /// Returns the value of the HelpNavigator.
        /// </summary>
        /// <returns>The value of the HelpNavigator.</returns>
        private HelpNavigator GetHelpNavigator() => _helpNavigator;

        /// <summary>
        /// Sets the CustomButtonOneText to the value of customButtonOneText.
        /// </summary>
        /// <param name="customButtonOneText">The desired value of CustomButtonOneText.</param>
        private void SetCustomButtonOneText(string customButtonOneText) => _customButtonOneText = customButtonOneText;

        /// <summary>
        /// Returns the value of the CustomButtonOneText.
        /// </summary>
        /// <returns>The value of the CustomButtonOneText.</returns>
        private string GetCustomButtonOneText() => _customButtonOneText;

        /// <summary>
        /// Sets the CustomButtonTwoText to the value of customButtonTwoText.
        /// </summary>
        /// <param name="customButtonTwoText">The desired value of CustomButtonTwoText.</param>
        private void SetCustomButtonTwoText(string customButtonTwoText) => _customButtonTwoText = customButtonTwoText;

        /// <summary>
        /// Returns the value of the CustomButtonTwoText.
        /// </summary>
        /// <returns>The value of the CustomButtonTwoText.</returns>
        private string GetCustomButtonTwoText() => _customButtonTwoText;

        /// <summary>
        /// Sets the CustomButtonThreeText to the value of customButtonThreeText.
        /// </summary>
        /// <param name="customButtonThreeText">The desired value of CustomButtonThreeText.</param>
        private void SetCustomButtonThreeText(string customButtonThreeText) => _customButtonThreeText = customButtonThreeText;

        /// <summary>
        /// Returns the value of the CustomButtonThreeText.
        /// </summary>
        /// <returns>The value of the CustomButtonThreeText.</returns>
        private string GetCustomButtonThreeText() => _customButtonThreeText;

        /// <summary>
        /// Sets the ButtonCornerRounding to the value of buttonCornerRounding.
        /// </summary>
        /// <param name="buttonCornerRounding">The desired value of ButtonCornerRounding.</param>
        private void SetButtonCornerRounding(float buttonCornerRounding) => _buttonCornerRounding = buttonCornerRounding;

        /// <summary>
        /// Returns the value of the ButtonCornerRounding.
        /// </summary>
        /// <returns>The value of the ButtonCornerRounding.</returns>
        private float GetButtonCornerRounding() => _buttonCornerRounding;

        /// <summary>
        /// Sets the WindowCornerRounding to the value of windowCornerRounding.
        /// </summary>
        /// <param name="windowCornerRounding">The desired value of WindowCornerRounding.</param>
        private void SetWindowCornerRounding(float windowCornerRounding) => _windowCornerRounding = windowCornerRounding;

        /// <summary>
        /// Returns the value of the WindowCornerRounding.
        /// </summary>
        /// <returns>The value of the WindowCornerRounding.</returns>
        private float GetWindowCornerRounding() => _windowCornerRounding;

        #endregion

        private void EnableCustomButtonFeatures(bool enabled)
        {
            kgrpCustomButtonColors.Enabled = enabled;

            kgrpCustomButtonOptions.Enabled = enabled;

            kgrpCustomButtonResult.Enabled = enabled;

            kgrpCustomButtonVisibility.Enabled = enabled;
        }

        private void SetDefaultButtonFromText(string option)
        {
            if (option == "Button1")
            {
                SetDefaultButton(MessageBoxDefaultButton.Button1);
            }
            else if (option == "Button2")
            {
                SetDefaultButton(MessageBoxDefaultButton.Button2);
            }
            else if (option == "Button3")
            {
                SetDefaultButton(MessageBoxDefaultButton.Button3);
            }
        }

        private void PropagateDialogResults(KryptonComboBox target)
        {
            string[] values = Enum.GetNames(typeof(DialogResult));

            foreach (string value in values)
            {
                target.Items.Add(value);
            }
        }

        private void PropagateHelpNavigatorValues(KryptonComboBox target)
        {
            string[] values = Enum.GetNames(typeof(HelpNavigator));

            foreach (string value in values)
            {
                target.Items.Add(value);
            }
        }

        private void SetCustomButtonOneResult(string value)
        {
            if (value == "None")
            {
                SetCustomDialogResultOne(DialogResult.None);
            }
            else if (value == "OK")
            {
                SetCustomDialogResultOne(DialogResult.OK);
            }
            else if (value == "Cancel")
            {
                SetCustomDialogResultOne(DialogResult.Cancel);
            }
            else if (value == "Abort")
            {
                SetCustomDialogResultOne(DialogResult.Abort);
            }
            else if (value == "Retry")
            {
                SetCustomDialogResultOne(DialogResult.Retry);
            }
            else if (value == "Ignore")
            {
                SetCustomDialogResultOne(DialogResult.Ignore);
            }
            else if (value == "Yes")
            {
                SetCustomDialogResultOne(DialogResult.Yes);
            }
            else if (value == "No")
            {
                SetCustomDialogResultOne(DialogResult.No);
            }
        }

        private void SetCustomButtonTwoResult(string value)
        {
            if (value == "None")
            {
                SetCustomDialogResultTwo(DialogResult.None);
            }
            else if (value == "OK")
            {
                SetCustomDialogResultTwo(DialogResult.OK);
            }
            else if (value == "Cancel")
            {
                SetCustomDialogResultTwo(DialogResult.Cancel);
            }
            else if (value == "Abort")
            {
                SetCustomDialogResultTwo(DialogResult.Abort);
            }
            else if (value == "Retry")
            {
                SetCustomDialogResultTwo(DialogResult.Retry);
            }
            else if (value == "Ignore")
            {
                SetCustomDialogResultTwo(DialogResult.Ignore);
            }
            else if (value == "Yes")
            {
                SetCustomDialogResultTwo(DialogResult.Yes);
            }
            else if (value == "No")
            {
                SetCustomDialogResultTwo(DialogResult.No);
            }
        }

        private void SetCustomButtonThreeResult(string value)
        {
            if (value == "None")
            {
                SetCustomDialogResultThree(DialogResult.None);
            }
            else if (value == "OK")
            {
                SetCustomDialogResultThree(DialogResult.OK);
            }
            else if (value == "Cancel")
            {
                SetCustomDialogResultThree(DialogResult.Cancel);
            }
            else if (value == "Abort")
            {
                SetCustomDialogResultThree(DialogResult.Abort);
            }
            else if (value == "Retry")
            {
                SetCustomDialogResultThree(DialogResult.Retry);
            }
            else if (value == "Ignore")
            {
                SetCustomDialogResultThree(DialogResult.Ignore);
            }
            else if (value == "Yes")
            {
                SetCustomDialogResultThree(DialogResult.Yes);
            }
            else if (value == "No")
            {
                SetCustomDialogResultThree(DialogResult.No);
            }
        }
    }
}
