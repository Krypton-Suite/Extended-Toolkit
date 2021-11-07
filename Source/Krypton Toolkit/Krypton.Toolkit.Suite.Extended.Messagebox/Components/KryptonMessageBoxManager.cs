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
    [/*ToolboxBitmap(typeof(KryptonMessageBoxManager), "ToolboxBitmaps.KryptonMessageBox.bmp"),*/
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
                     _isOptionalCheckBoxChecked, _showCtrlCopy;
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

        /// <summary>Gets or sets MessageBoxIcon.</summary>
        /// <value>The value of _kryptonMessageBoxIcon.</value>
        public ExtendedKryptonMessageBoxIcon MessageBoxIcon { get => _kryptonMessageBoxIcon; set => _kryptonMessageBoxIcon = value; }

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

        /// <summary>Gets or sets ShowCtrlCopy.</summary>
        /// <value>The value of _showCtrlCopy.</value>
        public bool ShowCtrlCopy { get => _showCtrlCopy; set => _showCtrlCopy = value; }


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

        /// <summary>Gets or sets OptionalCheckBoxCheckState.</summary>
        /// <value>The value of _optionalCheckBoxCheckState.</value>
        public CheckState OptionalCheckBoxCheckState { get => _optionalCheckBoxCheckState; set => _optionalCheckBoxCheckState = value; }

        /// <summary>Gets or sets ButtonOneCustomDialogResult.</summary>
        /// <value>The value of _buttonOneCustomDialogResult.</value>
        public DialogResult ButtonOneCustomDialogResult { get => _buttonOneCustomDialogResult; set => _buttonOneCustomDialogResult = value; }

        /// <summary>Gets or sets ButtonTwoCustomDialogResult.</summary>
        /// <value>The value of _buttonTwoCustomDialogResult.</value>
        public DialogResult ButtonTwoCustomDialogResult { get => _buttonTwoCustomDialogResult; set => _buttonTwoCustomDialogResult = value; }

        /// <summary>Gets or sets ButtonThreeCustomDialogResult.</summary>
        /// <value>The value of _buttonThreeCustomDialogResult.</value>
        public DialogResult ButtonThreeCustomDialogResult { get => _buttonThreeCustomDialogResult; set => _buttonThreeCustomDialogResult = value; }

        /// <summary>Gets or sets ButtonVisibility.</summary>
        /// <value>The value of _visibility.</value>
        public ExtendedMessageBoxCustomButtonVisibility ButtonVisibility { get => _visibility; set => _visibility = value; }

        /// <summary>Gets or sets MessageBoxButtonTypeface.</summary>
        /// <value>The value of _messageBoxButtonTypeface.</value>
        public Font MessageBoxButtonTypeface { get => _messageBoxButtonTypeface; set => _messageBoxButtonTypeface = value; }

        /// <summary>Gets or sets MessageBoxTypeface.</summary>
        /// <value>The value of _messageBoxTypeface.</value>
        public Font MessageBoxTypeface { get => _messageBoxTypeface; set => _messageBoxTypeface = value; }

        /// <summary>Gets or sets OptionalCheckBoxTypeface.</summary>
        /// <value>The value of _optionalCheckBoxTypeface.</value>
        public Font OptionalCheckBoxTypeface { get => _optionalCheckBoxTypeface; set => _optionalCheckBoxTypeface = value; }

        /// <summary>Gets or sets ButtonCornerRounding.</summary>
        /// <value>The value of _buttonCornerRounding.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public float ButtonCornerRounding { get => _buttonCornerRounding; set => _buttonCornerRounding = value; }

        /// <summary>Gets or sets WindowCornerRounding.</summary>
        /// <value>The value of _windowCornerRounding.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public float WindowCornerRounding { get => _windowCornerRounding; set => _windowCornerRounding = value; }

        /// <summary>Gets or sets OptionalCheckBoxText.</summary>
        /// <value>The value of _optionalCheckBoxText.</value>
        public string OptionalCheckBoxText { get => _optionalCheckBoxText; set => _optionalCheckBoxText = value; }

        /// <summary>Gets or sets CopyButtonText.</summary>
        /// <value>The value of _copyButtonText.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public string CopyButtonText { get => _copyButtonText; set => _copyButtonText = value; }

        /// <summary>Gets or sets ButtonOneText.</summary>
        /// <value>The value of _buttonOneText.</value>
        public string ButtonOneText { get => _buttonOneText; set => _buttonOneText = value; }

        /// <summary>Gets or sets ButtonTwoText.</summary>
        /// <value>The value of _buttonTwoText.</value>
        public string ButtonTwoText { get => _buttonTwoText; set => _buttonTwoText = value; }

        /// <summary>Gets or sets ButtonThreeText.</summary>
        /// <value>The value of _buttonThreeText.</value>
        public string ButtonThreeText { get => _buttonThreeText; set => _buttonThreeText = value; }

        /// <summary>Gets or sets CustomMessageBoxIcon.</summary>
        /// <value>The value of _customMessageBoxIcon.</value>
        public Image CustomMessageBoxIcon { get => _customMessageBoxIcon; set => _customMessageBoxIcon = value; }

        /// <summary>Gets or sets Player.</summary>
        /// <value>The value of _player.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public SoundPlayer Player { get => _player; set => _player = value; }

        /// <summary>Gets or sets SoundStream.</summary>
        /// <value>The value of _soundStream.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Stream SoundStream { get => _soundStream; set => _soundStream = value; }

        /// <summary>Gets or sets TimeoutSeconds.</summary>
        /// <value>The value of _timeoutSeconds.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DefaultValue(60)]
        public int TimeoutSeconds { get => _timeoutSeconds; set => _timeoutSeconds = value; }

        /// <summary>Gets or sets Timer.</summary>
        /// <value>The value of _timer.</value>
        public Timer Timer { get => _timer; private set => _timer = value; }

        /// <summary>Gets or sets ButtonOneCommand.</summary>
        /// <value>The value of _buttonCommandOne.</value>
        public KryptonCommand ButtonOneCommand { get => _buttonCommandOne; set => _buttonCommandOne = value; }

        /// <summary>Gets or sets ButtonTwoCommand.</summary>
        /// <value>The value of _buttonCommandTwo.</value>
        public KryptonCommand ButtonTwoCommand { get => _buttonCommandTwo; set => _buttonCommandTwo = value; }

        /// <summary>Gets or sets ButtonThreeCommand.</summary>
        /// <value>The value of _buttonCommandThree.</value>
        public KryptonCommand ButtonThreeCommand { get => _buttonCommandThree; set => _buttonCommandThree = value; }

        #endregion

        #endregion

        #region Custom Event
        /// <summary>Shows a messagebox.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ShowMessageBoxEventArgs" /> instance containing the event data.</param>
        public delegate void ShowMessageBoxEvent(object sender, ShowMessageBoxEventArgs e);

        /// <summary>Occurs when [show message box].</summary>
        public event ShowMessageBoxEvent ShowMessageBox;

        /// <summary>Called when [show message box].</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ShowMessageBoxEventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowMessageBox(object sender, ShowMessageBoxEventArgs e) => ShowMessageBox?.Invoke(sender, e);
        #endregion

        #region Constructor

        public KryptonMessageBoxManager()
        {
            Text = string.Empty;

            Caption = string.Empty;

            Buttons = ExtendedMessageBoxButtons.OK;

            MessageBoxIcon = ExtendedKryptonMessageBoxIcon.NONE;

            DefaultButton = MessageBoxDefaultButton.Button1;

            Owner = null;

            ShowCtrlCopy = false;

            DisplayHelpButton = false;

            HelpFilePath = string.Empty;

            Navigator = HelpNavigator.AssociateIndex;

            Param = null;

            Options = MessageBoxOptions.DefaultDesktopOnly;

            ShowUACShieldOnAcceptButton = false;

            UseYesNoOrCancelButtonColours = false;

            ShowOptionalCheckBox = false;

            ContentMessageColour = Color.Empty;

            ButtonOneBackColourOne = Color.Empty;

            ButtonOneBackColourTwo = Color.Empty;

            ButtonOneTextColourOne = Color.Empty;

            ButtonOneTextColourTwo = Color.Empty;

            ButtonTwoBackColourOne = Color.Empty;

            ButtonTwoBackColourTwo = Color.Empty;

            ButtonTwoTextColourOne = Color.Empty;

            ButtonTwoTextColourTwo = Color.Empty;

            ButtonThreeBackColourOne = Color.Empty;

            ButtonThreeBackColourTwo = Color.Empty;

            ButtonThreeTextColourOne = Color.Empty;

            ButtonThreeTextColourTwo = Color.Empty;

            YesButtonBackColourOne = Color.Empty;

            YesButtonBackColourTwo = Color.Empty;

            YesButtonTextColourOne = Color.Empty;

            YesButtonTextColourTwo = Color.Empty;

            NoButtonBackColourOne = Color.Empty;

            NoButtonBackColourTwo = Color.Empty;

            NoButtonTextColourOne = Color.Empty;

            NoButtonTextColourTwo = Color.Empty;

            OptionalCheckBoxTextColourOne = Color.Empty;

            OptionalCheckBoxTextColourTwo = Color.Empty;

            OptionalCheckBoxCheckState = CheckState.Unchecked;

            OptionalCheckBoxText = string.Empty;

            ButtonOneCustomDialogResult = DialogResult.None;

            ButtonTwoCustomDialogResult = DialogResult.None;

            ButtonThreeCustomDialogResult = DialogResult.None;

            ButtonVisibility = ExtendedMessageBoxCustomButtonVisibility.NONE;

            MessageBoxButtonTypeface = new Font("Segoe UI", 8.25f);

            MessageBoxTypeface = new Font("Segoe UI", 8.25f);

            OptionalCheckBoxTypeface = new Font("Segoe UI", 8.25f);

            ButtonCornerRounding = -1;

            WindowCornerRounding = -1;

            CopyButtonText = string.Empty;

            ButtonOneText = string.Empty;

            ButtonTwoText = string.Empty;

            ButtonThreeText = string.Empty;

            CustomMessageBoxIcon = null;

            Player = new SoundPlayer();

            SoundStream = Stream.Null;

            TimeoutSeconds = 60;

            Timer = new Timer();

            ButtonOneCommand = null;

            ButtonTwoCommand = null;

            ButtonThreeCommand = null;
        }
        #endregion

        #region Methods

        public void ShowMessagebox() => InternalKryptonMessageBoxExtended.Show(_showOwner, _text, _caption, _buttons,
            _kryptonMessageBoxIcon, _defaultButton,
            _options, _displayHelpButton, _helpFilePath,
            _navigator, _param, _buttonOneCustomDialogResult,
            _buttonTwoCustomDialogResult, _buttonThreeCustomDialogResult,
            _showCtrlCopy, _messageBoxButtonTypeface,
            _messageBoxTypeface, _visibility,
            _buttonOneText, _buttonTwoText, _buttonThreeText,
            _useYesNoOrCancelButtonColours, _contentMessageColour,
            _buttonOneBackColourOne, _buttonTwoBackColourTwo,
            _buttonOneTextColourOne, _buttonOneTextColourTwo,
            _buttonThreeTextColourOne, _buttonTwoTextColourTwo,
            _buttonTwoBackColourOne, _buttonTwoBackColourTwo,
            _buttonThreeTextColourOne, _buttonThreeTextColourTwo,
            _buttonThreeBackColourOne, _buttonThreeTextColourTwo,
            _yesButtonBackColourOne, _yesButtonBackColourTwo,
            _yesButtonTextColourOne, _yesButtonTextColourTwo,
            _noButtonBackColourOne, _noButtonBackColourTwo,
            _noButtonTextColourOne, _noButtonTextColourTwo,
            _buttonCornerRounding, _windowCornerRounding,
            _showUACShieldOnAcceptButton, _showOptionalCheckBox,
            _isOptionalCheckBoxChecked, _optionalCheckBoxTextColourOne,
            _optionalCheckBoxTextColourTwo, _optionalCheckBoxTypeface,
            _optionalCheckBoxText, _optionalCheckBoxCheckState);


        public DialogResult ShowMessageboxResult()
        {
            DialogResult result = InternalKryptonMessageBoxExtended.Show(_showOwner, _text, _caption, _buttons,
                _kryptonMessageBoxIcon, _defaultButton,
                _options, _displayHelpButton, _helpFilePath,
                _navigator, _param, _buttonOneCustomDialogResult,
                _buttonTwoCustomDialogResult, _buttonThreeCustomDialogResult,
                _showCtrlCopy, _messageBoxButtonTypeface,
                _messageBoxTypeface, _visibility,
                _buttonOneText, _buttonTwoText, _buttonThreeText,
                _useYesNoOrCancelButtonColours, _contentMessageColour,
                _buttonOneBackColourOne, _buttonTwoBackColourTwo,
                _buttonOneTextColourOne, _buttonOneTextColourTwo,
                _buttonThreeTextColourOne, _buttonTwoTextColourTwo,
                _buttonTwoBackColourOne, _buttonTwoBackColourTwo,
                _buttonThreeTextColourOne, _buttonThreeTextColourTwo,
                _buttonThreeBackColourOne, _buttonThreeTextColourTwo,
                _yesButtonBackColourOne, _yesButtonBackColourTwo,
                _yesButtonTextColourOne, _yesButtonTextColourTwo,
                _noButtonBackColourOne, _noButtonBackColourTwo,
                _noButtonTextColourOne, _noButtonTextColourTwo,
                _buttonCornerRounding, _windowCornerRounding,
                _showUACShieldOnAcceptButton, _showOptionalCheckBox,
                _isOptionalCheckBoxChecked, _optionalCheckBoxTextColourOne,
                _optionalCheckBoxTextColourTwo, _optionalCheckBoxTypeface,
                _optionalCheckBoxText, _optionalCheckBoxCheckState);

            return result;
        }
        #endregion
    }
}