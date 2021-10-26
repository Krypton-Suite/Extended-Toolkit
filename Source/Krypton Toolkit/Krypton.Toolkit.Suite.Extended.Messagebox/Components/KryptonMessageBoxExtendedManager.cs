#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion


namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    /// <summary>Allows the creation of a <see cref="KryptonMessageBoxExtended"/> through the designer.</summary>
    /// <seealso cref="Component" />
    [ToolboxBitmap(typeof(KryptonMessageBoxManager), "ToolboxBitmaps.KryptonMessageBox.bmp"),
     DefaultEvent("ShowMessageBox"), DefaultProperty("MessageBoxContentText"),
     Description("Allows the creation of a KryptonMessageBoxExtended through the designer.")] //, Designer(typeof(KryptonMessageBoxConfiguratorDesigner))]
    public class KryptonMessageBoxManager : Component
    {
        #region Instance Fields

        #region Basic Fields
        private string _text, _caption, _helpFilePath;
        private HelpNavigator _navigator;
        private object _param;
        private ExtendedMessageBoxButtons _buttons;
        private ExtendedKryptonMessageBoxIcon _kryptonMessageBoxIcon;

        private MessageBoxDefaultButton _defaultButton;
        private MessageBoxOptions _options; // https://github.com/Krypton-Suite/Standard-Toolkit/issues/313
        // If help information provided or we are not a service/default desktop application then grab an owner for showing the message box
        private IWin32Window _showOwner;
        private bool _displayHelpButton;
        #endregion

        #region Extended Fields

        private bool _showUACShieldOnAcceptButton, _useYesNoOrCancelButtonColours, _showOptionalCheckBox,
                     _isOptionalCheckBoxChecked;
        private Color _contentMessageColour, _buttonOneBackColourOne, _buttonOneBackColourTwo,
                      _buttonOneTextColourOne, _buttonOneTextColourTwo,
                      _buttonTwoBackColourOne, _buttonTwoBackColourTwo,
                      _buttonTwoTextColourOne, _buttonTwoTextColourTwo,
                      _buttonThreeBackColourOne, _buttonThreeBackColourTwo,
                      _buttonThreeTextColourOne, _buttonThreeTextColourTwo,
                      _yesButtonBackColourOne, _yesButtonBackColourTwo,
                      _yesButtonTextColourOne, _yesButtonTextColourTwo,
                      _noButtonBackColourOne, _noButtonBackColourTwo,
                      _noButtonTextColourOne, _noButtonTextColourTwo,
                      _optionalCheckBoxTextColourOne, _optionalCheckBoxTextColourTwo;
        private CheckState _optionalCheckBoxCheckState;
        private DialogResult _buttonOneCustomDialogResult, _buttonTwoCustomDialogResult, _buttonThreeCustomDialogResult;
        private ExtendedMessageBoxCustomButtonVisibility _visibility;
        private Font _messageBoxButtonTypeface, _messageBoxTypeface, _optionalCheckBoxTypeface;
        private float _buttonCornerRounding, _windowCornerRounding;
        private string _optionalCheckBoxText, _copyButtonText, _buttonOneText, _buttonTwoText, _buttonThreeText;
        private Image _customMessageBoxIcon;
        private SoundPlayer _player;
        private Stream _soundStream;
        private int _timeoutSeconds;
        private Timer _timer;
        private KryptonCommand _buttonCommandOne, _buttonCommandTwo, _buttonCommandThree;
        #endregion

        #endregion

        #region Properties

        #region Basic Options

        /// <summary>Gets or sets Text.</summary>
        /// <value>The value of _text.</value>
        public string Text { get => _text; set => _text = value; }

        /// <summary>Gets or sets Caption.</summary>
        /// <value>The value of _caption.</value>
        public string Caption { get => _caption; set => _caption = value; }

        /// <summary>Gets or sets Buttons.</summary>
        /// <value>The value of _buttons.</value>
        public ExtendedMessageBoxButtons Buttons { get => _buttons; set => _buttons = value; }

        /// <summary>Gets or sets KryptonMessageBoxIcon.</summary>
        /// <value>The value of _kryptonMessageBoxIcon.</value>
        public ExtendedKryptonMessageBoxIcon KryptonMessageBoxIcon { get => _kryptonMessageBoxIcon; set => _kryptonMessageBoxIcon = value; }

        /// <summary>Gets or sets DefaultButton.</summary>
        /// <value>The value of _defaultButton.</value>
        public MessageBoxDefaultButton DefaultButton { get => _defaultButton; set => _defaultButton = value; }

        /// <summary>Gets or sets Owner.</summary>
        /// <value>The value of _showOwner.</value>
        public IWin32Window Owner { get => _showOwner; set => _showOwner = value; }

        /// <summary>Gets or sets DisplayHelpButton.</summary>
        /// <value>The value of _displayHelpButton.</value>
        public bool DisplayHelpButton { get => _displayHelpButton; set => _displayHelpButton = value; }

        /// <summary>Gets or sets HelpFilePath.</summary>
        /// <value>The value of _helpFilePath.</value>
        public string HelpFilePath { get => _helpFilePath; set => _helpFilePath = value; }

        /// <summary>Gets or sets Navigator.</summary>
        /// <value>The value of _navigator.</value>
        public HelpNavigator Navigator { get => _navigator; set => _navigator = value; }

        /// <summary>Gets or sets Param.</summary>
        /// <value>The value of _param.</value>
        public object Param { get => _param; set => _param = value; }

        /// <summary>Gets or sets Options.</summary>
        /// <value>The value of _options.</value>
        public MessageBoxOptions Options { get => _options; set => _options = value; }

        #endregion

        #region Extended Options

        /// <summary>Gets or sets ShowUACShieldOnAcceptButton.</summary>
        /// <value>The value of _showUACShieldOnAcceptButton.</value>
        public bool ShowUACShieldOnAcceptButton { get => _showUACShieldOnAcceptButton; set => _showUACShieldOnAcceptButton = value; }

        /// <summary>Gets or sets UseYesNoOrCancelButtonColours.</summary>
        /// <value>The value of _useYesNoOrCancelButtonColours.</value>
        public bool UseYesNoOrCancelButtonColours { get => _useYesNoOrCancelButtonColours; set => _useYesNoOrCancelButtonColours = value; }

        /// <summary>Gets or sets ShowOptionalCheckBox.</summary>
        /// <value>The value of _showOptionalCheckBox.</value>
        public bool ShowOptionalCheckBox { get => _showOptionalCheckBox; set => _showOptionalCheckBox = value; }

        /// <summary>Gets or sets IsOptionalCheckBoxChecked.</summary>
        /// <value>The value of _isOptionalCheckBoxChecked.</value>
        public bool IsOptionalCheckBoxChecked { get => _isOptionalCheckBoxChecked; set => _isOptionalCheckBoxChecked = value; }

        /// <summary>Gets or sets the content message colour.</summary>
        /// <value>The content message colour.</value>
        public Color ContentMessageColour { get => _contentMessageColour; set => _contentMessageColour = value; }

        /// <summary>Gets or sets the button one back colour one.</summary>
        /// <value>The button one back colour one.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color ButtonOneBackColourOne { get => _buttonOneBackColourOne; set => _buttonOneBackColourOne = value; }

        /// <summary>Gets or sets the button one back colour two.</summary>
        /// <value>The button one back colour two.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color ButtonOneBackColourTwo { get => _buttonOneBackColourTwo; set => _buttonOneBackColourTwo = value; }

        /// <summary>Gets or sets the button one text colour one.</summary>
        /// <value>The button one text colour one.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color ButtonOneTextColourOne { get => _buttonOneTextColourOne; set => _buttonOneTextColourOne = value; }

        /// <summary>Gets or sets the button one text colour two.</summary>
        /// <value>The button one text colour two.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color ButtonOneTextColourTwo { get => _buttonOneTextColourTwo; set => _buttonOneTextColourTwo = value; }

        /// <summary>Gets or sets the button two back colour one.</summary>
        /// <value>The button two back colour one.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color ButtonTwoBackColourOne { get => _buttonTwoBackColourOne; set => _buttonTwoBackColourTwo = value; }

        /// <summary>Gets or sets the button two back colour two.</summary>
        /// <value>The button two back colour two.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color ButtonTwoBackColourTwo { get => _buttonTwoBackColourTwo; set => _buttonTwoBackColourTwo = value; }

        /// <summary>Gets or sets the button two text colour one.</summary>
        /// <value>The button two text colour one.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color ButtonTwoTextColourOne { get => _buttonTwoTextColourOne; set => _buttonTwoTextColourOne = value; }

        /// <summary>Gets or sets the button two text colour two.</summary>
        /// <value>The button two text colour two.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color ButtonTwoTextColourTwo { get => _buttonTwoTextColourTwo; set => _buttonTwoTextColourTwo = value; }

        /// <summary>Gets or sets the button three back colour one.</summary>
        /// <value>The button three back colour one.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color ButtonThreeBackColourOne { get => _buttonThreeBackColourOne; set => _buttonThreeBackColourOne = value; }

        /// <summary>Gets or sets the button three back colour two.</summary>
        /// <value>The button three back colour two.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color ButtonThreeBackColourTwo { get => _buttonThreeBackColourTwo; set => _buttonThreeBackColourTwo = value; }

        /// <summary>Gets or sets the button three text colour one.</summary>
        /// <value>The button three text colour one.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color ButtonThreeTextColourOne { get => _buttonThreeTextColourOne; set => _buttonThreeTextColourOne = value; }

        /// <summary>Gets or sets the button three text colour two.</summary>
        /// <value>The button three text colour two.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color ButtonThreeTextColourTwo { get => _buttonThreeTextColourTwo; set => _buttonThreeTextColourTwo = value; }

        /// <summary>Gets or sets the yes button back colour one.</summary>
        /// <value>The yes button back colour one.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color YesButtonBackColourOne { get => _yesButtonBackColourOne; set => _yesButtonBackColourOne = value; }

        /// <summary>Gets or sets the yes button back colour two.</summary>
        /// <value>The yes button back colour two.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color YesButtonBackColourTwo { get => _yesButtonBackColourTwo; set => _yesButtonBackColourTwo = value; }

        /// <summary>Gets or sets the yes button text colour one.</summary>
        /// <value>The yes button text colour one.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color YesButtonTextColourOne { get => _yesButtonTextColourOne; set => _yesButtonTextColourOne = value; }

        /// <summary>Gets or sets the yes button text colour two.</summary>
        /// <value>The yes button text colour two.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color YesButtonTextColourTwo { get => _yesButtonTextColourTwo; set => _yesButtonBackColourTwo = value; }

        /// <summary>Gets or sets the no button back colour one.</summary>
        /// <value>The no button back colour one.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color NoButtonBackColourOne { get => _noButtonBackColourOne; set => _noButtonBackColourOne = value; }

        /// <summary>Gets or sets the no button back colour two.</summary>
        /// <value>The no button back colour two.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color NoButtonBackColourTwo { get => _noButtonBackColourTwo; set => _noButtonBackColourTwo = value; }

        /// <summary>Gets or sets the no button text colour one.</summary>
        /// <value>The no button text colour one.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color NoButtonTextColourOne { get => _noButtonTextColourOne; set => _noButtonTextColourOne = value; }

        /// <summary>Gets or sets the no button text colour two.</summary>
        /// <value>The no button text colour two.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Color NoButtonTextColourTwo { get => _noButtonTextColourTwo; set => _noButtonTextColourTwo = value; }

        /// <summary>Gets or sets the optional CheckBox text colour one.</summary>
        /// <value>The optional CheckBox text colour one.</value>
        public Color OptionalCheckBoxTextColourOne { get => _optionalCheckBoxTextColourOne; set => _optionalCheckBoxTextColourOne = value; }

        /// <summary>Gets or sets the optional CheckBox text colour two.</summary>
        /// <value>The optional CheckBox text colour two.</value>
        public Color OptionalCheckBoxTextColourTwo { get => _optionalCheckBoxTextColourTwo; set => _optionalCheckBoxTextColourTwo = value; }
        #endregion

        #endregion
    }
}