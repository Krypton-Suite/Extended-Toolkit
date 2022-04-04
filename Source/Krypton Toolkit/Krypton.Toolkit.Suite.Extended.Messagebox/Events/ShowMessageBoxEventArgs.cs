#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    /// <summary>
    ///   <br />
    /// </summary>
    public class ShowMessageBoxEventArgs : EventArgs
    {
        #region Variables
        private AnchorStyles _optionalCheckBoxAnchor;

        private bool _showCtrlCopy, _fade, _showOptionalCheckBox, _showToolTips, _isOptionalCheckBoxChecked, _showCopyButton, _useBlur, _useYesNoCancelButtonColour;

        private CheckState _optionalCheckBoxCheckState;

        private Color _contentMessageColour, _buttonOneTextColour, _buttonTwoTextColour, _buttonThreeTextColour, _yesButtonColour, _noButtonColour, _textColour, _yesNoButtonTextColour;

        private DialogResult _customButtonOneResult, _customButtonTwoResult, _customButtonThreeResult;

        private Font _messageBoxTypeface;

        private ExtendedMessageBoxButtons _buttons;

        private ExtendedMessageBoxCustomButtonOptions _customButtonOptions;

        private MessageBoxDefaultButton _defaultButton;

        private MessageBoxOptions _options;

        private ExtendedKryptonMessageBoxIcon _messageBoxIcon;

        private HelpNavigator _helpNavigator;

        private Image _customMessageBoxIcon;

        private int _blurRadius, _cornerRadius, _fadeSleepTimer, _timeOut;

        private IWin32Window _owner;

        private string _messageBoxCaption, _messageBoxContentText, _optionalCheckBoxText, _helpPath, _copyButtonText, _messageBoxButtonOneCustomText, _messageBoxButtonTwoCustomText, _messageBoxButtonThreeCustomText;

        private object _helpParam;

        private Point _optionalCheckBoxLocation;

        private KryptonForm _parentWindow;
        #endregion

        #region Properties
        /// <summary>Gets or sets the optional CheckBox anchor.</summary>
        /// <value>The optional CheckBox anchor.</value>
        [DefaultValue(typeof(AnchorStyles), "AnchorStyles.Left"), Description("Gets or sets the optional CheckBox anchor.")]
        public AnchorStyles OptionalCheckBoxAnchor { get => _optionalCheckBoxAnchor; set => _optionalCheckBoxAnchor = value; }

        /// <summary>Gets or sets a value indicating whether [show control copy].</summary>
        /// <value><c>true</c> if [show control copy]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Allows the user to use 'CTRL + C' to copy the message box content.")]
        public bool ShowCtrlCopy { get => _showCtrlCopy; set => _showCtrlCopy = value; }

        /// <summary>Gets or sets a value indicating whether this <see cref="KryptonMessageBoxManagerOld" /> is fade.</summary>
        /// <value><c>true</c> if fade; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Fades the message box in and out. (Under construction)")]
        public bool Fade { get => _fade; set => _fade = value; }

        /// <summary>Gets or sets a value indicating whether [show optional CheckBox].</summary>
        /// <value><c>true</c> if [show optional CheckBox]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Shows a optional check box in the message box footer.")]
        public bool ShowOptionalCheckBox { get => _showOptionalCheckBox; set => _showOptionalCheckBox = value; }

        /// <summary>Gets or sets a value indicating whether [show tool tips].</summary>
        /// <value><c>true</c> if [show tool tips]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Allow tooltips to be shown on the controls.")]
        public bool ShowToolTips { get => _showToolTips; set => _showToolTips = value; }

        /// <summary>Gets or sets a value indicating whether this instance is optional CheckBox checked.</summary>
        /// <value><c>true</c> if this instance is optional CheckBox checked; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Is the optional check box checked by default?")]
        public bool IsOptionalCheckBoxChecked { get => _isOptionalCheckBoxChecked; set => _isOptionalCheckBoxChecked = value; }

        /*
        /// <summary>Gets or sets a value indicating whether [show copy button].</summary>
        /// <value><c>true</c> if [show copy button]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Show the copy button.")]
        public bool ShowCopyButton { get => _showCopyButton; set => _showCopyButton = value; }
        */

        /// <summary>Gets or sets a value indicating whether [use blur].</summary>
        /// <value><c>true</c> if [use blur]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Use the blur functionality on the parent window.")]
        public bool UseBlur { get => _useBlur; set => _useBlur = value; }

        /// <summary>Gets or sets a value indicating whether [use yes no cancel button colour].</summary>
        /// <value><c>true</c> if [use yes no cancel button colour]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Defines a custom colour for abort, cancel, no and yes buttons.")]
        public bool UseYesNoCancelButtonColour { get => _useYesNoCancelButtonColour; set => _useYesNoCancelButtonColour = value; }

        /// <summary>Gets or sets the content message colour.</summary>
        /// <value>The content message colour.</value>
        [DefaultValue(typeof(Color), "Color.Empty"), Description("Gets or sets the content message colour.")]
        public Color ContentMessageColour { get => _contentMessageColour; set => _contentMessageColour = value; }

        /// <summary>Gets or sets the button one text colour.</summary>
        /// <value>The button one text colour.</value>
        [DefaultValue(typeof(Color), "Color.Empty"), Description("Gets or sets the button one text colour.")]
        public Color ButtonOneTextColour { get => _buttonOneTextColour; set => _buttonOneTextColour = value; }

        /// <summary>Gets or sets the button two text colour.</summary>
        /// <value>The button two text colour.</value>
        [DefaultValue(typeof(Color), "Color.Empty"), Description("Gets or sets the button two text colour.")]
        public Color ButtonTwoTextColour { get => _buttonTwoTextColour; set => _buttonTwoTextColour = value; }

        /// <summary>Gets or sets the button three text colour.</summary>
        /// <value>The button three text colour.</value>
        [DefaultValue(typeof(Color), "Color.Empty"), Description("Gets or sets the button three text colour.")]
        public Color ButtonThreeTextColour { get => _buttonThreeTextColour; set => _buttonThreeTextColour = value; }

        /// <summary>Gets or sets the yes button colour.</summary>
        /// <value>The yes button colour.</value>
        [DefaultValue(typeof(Color), "Color.Empty"), Description("Gets or sets the yes button colour.")]
        public Color YesButtonColour { get => _yesButtonColour; set => _yesButtonColour = value; }

        /// <summary>Gets or sets the abort/cancel/no button colour.</summary>
        /// <value>The abort/cancel/no button colour.</value>
        [DefaultValue(typeof(Color), "Color.Empty"), Description("Gets or sets the abort/cancel/no button colour.")]
        public Color NoButtonColour { get => _noButtonColour; set => _noButtonColour = value; }

        /// <summary>Gets or sets the global text colour.</summary>
        /// <value>The global text colour.</value>
        [DefaultValue(typeof(Color), "Color.Empty"), Description("Gets or sets the global text colour.")]
        public Color TextColour { get => _textColour; set => _textColour = value; }

        /// <summary>Gets or sets the yes no button text colour.</summary>
        /// <value>The yes/no button text colour.</value>
        [DefaultValue(typeof(Color), "Color.Empty"), Description("Gets or sets the yes no button text colour.")]
        public Color YesNoButtonTextColour { get => _yesNoButtonTextColour; set => _yesNoButtonTextColour = value; }

        /// <summary>Gets or sets the custom button one result.</summary>
        /// <value>The custom button one result.</value>
        [DefaultValue(typeof(DialogResult), "DialogResult.None"), Description("Gets or sets the custom button one result.")]
        public DialogResult CustomButtonOneResult { get => _customButtonOneResult; set => _customButtonOneResult = value; }

        /// <summary>Gets or sets the custom button two result.</summary>
        /// <value>The custom button two result.</value>
        [DefaultValue(typeof(DialogResult), "DialogResult.None"), Description("Gets or sets the custom button two result.")]
        public DialogResult CustomButtonTwoResult { get => _customButtonTwoResult; set => _customButtonTwoResult = value; }

        /// <summary>Gets or sets the custom button three result.</summary>
        /// <value>The custom button three result.</value>
        [DefaultValue(typeof(DialogResult), "DialogResult.None"), Description("Gets or sets the custom button three result.")]
        public DialogResult CustomButtonThreeResult { get => _customButtonThreeResult; set => _customButtonThreeResult = value; }

        /// <summary>Gets or sets the state of the optional CheckBox check.</summary>
        /// <value>The state of the optional CheckBox check.</value>
        [DefaultValue(typeof(CheckState), "CheckState.Unchecked"), Description("Gets or sets the state of the optional CheckBox check.")]
        public CheckState OptionalCheckBoxCheckState { get => _optionalCheckBoxCheckState; set => _optionalCheckBoxCheckState = value; }

        /// <summary>Gets or sets the message box typeface.</summary>
        /// <value>The message box typeface.</value>
        [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25F"), Description("Gets or sets the message box typeface.")]
        public Font MessageBoxTypeface { get => _messageBoxTypeface; set => _messageBoxTypeface = value; }

        /// <summary>Gets or sets the message box buttons.</summary>
        /// <value>The message box buttons.</value>
        [DefaultValue(typeof(ExtendedMessageBoxButtons), "ExtendedMessageBoxButtons.OK"), Description("Gets or sets the message box buttons.")]
        public ExtendedMessageBoxButtons MessageBoxButtons { get => _buttons; set => _buttons = value; }

        /// <summary>Gets or sets the custom button options.</summary>
        /// <value>The custom button options.</value>
        [DefaultValue(null), Description("Gets or sets the custom button options.")]
        public ExtendedMessageBoxCustomButtonOptions CustomButtonOptions { get => _customButtonOptions; set => _customButtonOptions = value; }

        /// <summary>Gets or sets the message box default button.</summary>
        /// <value>The message box default button.</value>
        [DefaultValue(typeof(MessageBoxDefaultButton), "MessageBoxDefaultButton.Button1"), Description("Gets or sets the message box default button.")]
        public MessageBoxDefaultButton MessageBoxDefaultButton { get => _defaultButton; set => _defaultButton = value; }

        /// <summary>Gets or sets the message box options.</summary>
        /// <value>The message box options.</value>
        [DefaultValue(null), Description("Gets or sets the message box options.")]
        public MessageBoxOptions MessageBoxOptions { get => _options; set => _options = value; }

        /// <summary>Gets or sets the message box icon.</summary>
        /// <value>The message box icon.</value>
        [DefaultValue(typeof(ExtendedKryptonMessageBoxIcon), "ExtendedMessageBoxIcon.NONE"), Description("Gets or sets the message box icon.")]
        public ExtendedKryptonMessageBoxIcon MessageBoxIcon { get => _messageBoxIcon; set => _messageBoxIcon = value; }

        /// <summary>Gets or sets the help navigator.</summary>
        /// <value>The help navigator.</value>
        [DefaultValue(typeof(HelpNavigator), "HelpNavigator.AssociateIndex"), Description("Gets or sets the help navigator.")]
        public HelpNavigator HelpNavigator { get => _helpNavigator; set => _helpNavigator = value; }

        /// <summary>Gets or sets a custom message box icon.</summary>
        /// <value>The custom message box icon.</value>
        [DefaultValue(null), Description("Gets or sets a custom message box icon.")]
        public Image CustomMessageBoxIcon { get => _customMessageBoxIcon; set => _customMessageBoxIcon = value; }

        /// <summary>Gets or sets the blur radius.</summary>
        /// <value>The blur radius.</value>
        [DefaultValue(0), Description("The blur radius of the parent window.")]
        public int BlurRadius { get => _blurRadius; set => _blurRadius = value; }

        /// <summary>Gets or sets the corner radius.</summary>
        /// <value>The corner radius.</value>
        [DefaultValue(-1), Description("The corner radius of the message box.")]
        public int CornerRadius { get => _cornerRadius; set => _cornerRadius = value; }

        /// <summary>Gets or sets the speed of the fading animation in milliseconds.</summary>
        /// <value>The speed of the fading animation in milliseconds.</value>
        [DefaultValue(50), Description("Gets or sets the speed of the fading animation in milliseconds.")]
        public int FadeSleepTimer { get => _fadeSleepTimer; set => _fadeSleepTimer = value; }

        /// <summary>Gets or sets the time out. (This feature is under construction)</summary>
        /// <value>The time out.</value>
        [DefaultValue(60), Description("Gets or sets the time out. (This feature is under construction)")]
        public int TimeOut { get => _timeOut; set => _timeOut = value; }

        /// <summary>Gets or sets the owner of the message box.</summary>
        /// <value>The owner.</value>
        [DefaultValue(null), Description("Gets or sets the owner of the message box.")]
        public IWin32Window Owner { get => _owner; set => _owner = value; }

        /// <summary>Gets or sets the message box caption.</summary>
        /// <value>The message box caption.</value>
        [DefaultValue(null), Description("Gets or sets the message box caption.")]
        public string MessageBoxCaption { get => _messageBoxCaption; set => _messageBoxCaption = value; }

        /// <summary>Gets or sets the message box content text.</summary>
        /// <value>The message box content text.</value>
        [DefaultValue(null), Description("Gets or sets the message box content text.")]
        public string MessageBoxContentText { get => _messageBoxContentText; set => _messageBoxContentText = value; }

        /// <summary>Gets or sets the optional CheckBox text.</summary>
        /// <value>The optional CheckBox text.</value>
        [DefaultValue(null), Description("Gets or sets the optional CheckBox text.")]
        public string OptionalCheckBoxText { get => _optionalCheckBoxText; set => _optionalCheckBoxText = value; }

        /// <summary>Gets or sets the help path.</summary>
        /// <value>The help path.</value>
        [DefaultValue(null), Description("Gets or sets the help path.")]
        public string HelpPath { get => _helpPath; set => _helpPath = value; }

        /*
        /// <summary>Gets or sets the copy button text.</summary>
        /// <value>The copy button text.</value>
        [DefaultValue("&Copy Details"), Description("Gets or sets the copy button text.")]
        public string CopyButtonText { get => _copyButtonText; set => _copyButtonText = value; }
        */

        /// <summary>Gets or sets the button one custom text.</summary>
        /// <value>The button one custom text.</value>
        [DefaultValue(null), Description("Gets or sets the button one custom text.")]
        public string ButtonOneCustomText { get => _messageBoxButtonOneCustomText; set => _messageBoxButtonOneCustomText = value; }

        /// <summary>Gets or sets the button two custom text.</summary>
        /// <value>The button two custom text.</value>
        [DefaultValue(null), Description("Gets or sets the button two custom text.")]
        public string ButtonTwoCustomText { get => _messageBoxButtonTwoCustomText; set => _messageBoxButtonTwoCustomText = value; }

        /// <summary>Gets or sets the button three custom text.</summary>
        /// <value>The button three custom text.</value>
        [DefaultValue(null), Description("Gets or sets the button three custom text.")]
        public string ButtonThreeCustomText { get => _messageBoxButtonThreeCustomText; set => _messageBoxButtonThreeCustomText = value; }

        /// <summary>Gets or sets the help parameters.</summary>
        /// <value>The help parameters.</value>
        [DefaultValue(null), Description("Gets or sets the help parameters.")]
        public object HelpParam { get => _helpParam; set => _helpParam = value; }

        /// <summary>Gets or sets the optional CheckBox location.</summary>
        /// <value>The optional CheckBox location.</value>
        [DefaultValue(typeof(Point), "12, 0"), Description("Gets or sets the optional CheckBox location.")]
        public Point OptionalCheckBoxLocation { get => _optionalCheckBoxLocation; set => _optionalCheckBoxLocation = value; }

        /// <summary>Gets or sets the parent window.</summary>
        /// <value>The parent window.</value>
        [DefaultValue(null), Description("The parent window of the message box.")]
        public KryptonForm ParentWindow { get => _parentWindow; set => _parentWindow = value; }
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="ShowMessageBoxEventArgs" /> class.</summary>
        public ShowMessageBoxEventArgs()
        {

        }

        /// <summary>Initializes a new instance of the <see cref="ShowMessageBoxEventArgs" /> class.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="text">The text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="customButtonOptions">The custom button options.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="options">The options.</param>
        /// <param name="helpPath">The help path.</param>
        /// <param name="helpNavigator">The help navigator.</param>
        /// <param name="helpParam">The help parameter.</param>
        /// <param name="showCtrlCopy">if set to <c>true</c> [show control copy].</param>
        /// <param name="messageboxTypeface">The messagebox typeface.</param>
        /// <param name="showOptionalCheckBox">if set to <c>true</c> [show optional CheckBox].</param>
        /// <param name="optionalCheckBoxText">The optional CheckBox text.</param>
        /// <param name="isOptionalCheckBoxChecked">if set to <c>true</c> [is optional CheckBox checked].</param>
        /// <param name="optionalCheckBoxAnchor">The optional CheckBox anchor.</param>
        /// <param name="optionalCheckBoxLocation">The optional CheckBox location.</param>
        /// <param name="customMessageBoxIcon">The custom message box icon.</param>
        /// <param name="showCopyButton">if set to <c>true</c> [show copy button].</param>
        /// <param name="copyButtonText">The copy button text.</param>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="fadeSleepTimer">The fade sleep timer.</param>
        /// <param name="buttonOneCustomText">The button one custom text.</param>
        /// <param name="buttonTwoCustomText">The button two custom text.</param>
        /// <param name="buttonThreeCustomText">The button three custom text.</param>
        /// <param name="buttonOneCustomDialogResult">The button one custom dialog result.</param>
        /// <param name="buttonTwoCustomDialogResult">The button two custom dialog result.</param>
        /// <param name="buttonThreeCustomDialogResult">The button three custom dialog result.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="showToolTips">The show tool tips.</param>
        /// <param name="useBlur">The use blur.</param>
        /// <param name="useYesNoCancelButtonColour">The use yes no cancel button colour.</param>
        /// <param name="blurRadius">The blur radius.</param>
        /// <param name="contentMessageColour">The content message colour.</param>
        /// <param name="buttonOneTextColour">The button one text colour.</param>
        /// <param name="buttonTwoTextColour">The button two text colour.</param>
        /// <param name="buttonThreeTextColour">The button three text colour.</param>
        /// <param name="yesButtonColour">The yes button colour.</param>
        /// <param name="noButtonColour">The no button colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="yesNoButtonTextColour">The yes no button text colour.</param>
        /// <param name="parentWindow">The parent window.</param>
        public ShowMessageBoxEventArgs(IWin32Window owner, string text, string caption,
                                       ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                       ExtendedKryptonMessageBoxIcon icon,
                                       MessageBoxDefaultButton defaultButton,
                                       MessageBoxOptions options, string helpPath,
                                       HelpNavigator helpNavigator, object helpParam,
                                       bool showCtrlCopy, Font messageboxTypeface, bool showOptionalCheckBox,
                                       string optionalCheckBoxText, bool isOptionalCheckBoxChecked,
                                       AnchorStyles optionalCheckBoxAnchor, Point optionalCheckBoxLocation,
                                       Image customMessageBoxIcon, bool showCopyButton, string copyButtonText,
                                       bool fade, int fadeSleepTimer, string buttonOneCustomText,
                                       string buttonTwoCustomText, string buttonThreeCustomText,
                                       DialogResult? buttonOneCustomDialogResult, DialogResult? buttonTwoCustomDialogResult,
                                       DialogResult? buttonThreeCustomDialogResult, int? cornerRadius,
                                       bool? showToolTips, bool? useBlur, bool? useYesNoCancelButtonColour,
                                       int? blurRadius, Color? contentMessageColour, Color? buttonOneTextColour,
                                       Color? buttonTwoTextColour, Color? buttonThreeTextColour,
                                       Color? yesButtonColour, Color? noButtonColour, Color? textColour,
                                       Color? yesNoButtonTextColour, KryptonForm parentWindow = null)
        {
            Owner = owner;

            MessageBoxContentText = text;

            MessageBoxCaption = caption;

            MessageBoxButtons = buttons;

            CustomButtonOptions = customButtonOptions;

            MessageBoxIcon = icon;

            MessageBoxDefaultButton = defaultButton;

            MessageBoxOptions = options;

            HelpPath = helpPath;

            HelpNavigator = helpNavigator;

            HelpParam = helpParam;

            ShowCtrlCopy = showCtrlCopy;

            MessageBoxTypeface = messageboxTypeface;

            ShowOptionalCheckBox = showOptionalCheckBox;

            OptionalCheckBoxText = optionalCheckBoxText;

            IsOptionalCheckBoxChecked = isOptionalCheckBoxChecked;

            OptionalCheckBoxAnchor = optionalCheckBoxAnchor;

            OptionalCheckBoxLocation = optionalCheckBoxLocation;

            CustomMessageBoxIcon = customMessageBoxIcon;

            //ShowCopyButton = showCopyButton;

            //CopyButtonText = copyButtonText;

            Fade = fade;

            FadeSleepTimer = fadeSleepTimer;

            ButtonOneCustomText = buttonOneCustomText;

            ButtonTwoCustomText = buttonTwoCustomText;

            ButtonThreeCustomText = buttonThreeCustomText;

            CustomButtonOneResult = buttonOneCustomDialogResult ?? DialogResult.None;

            CustomButtonTwoResult = buttonTwoCustomDialogResult ?? DialogResult.None;

            CustomButtonThreeResult = buttonThreeCustomDialogResult ?? DialogResult.None;

            CornerRadius = cornerRadius ?? -1;

            ShowToolTips = showToolTips ?? false;

            UseBlur = useBlur ?? false;

            UseYesNoCancelButtonColour = useYesNoCancelButtonColour ?? false;

            BlurRadius = blurRadius ?? 0;

            ContentMessageColour = contentMessageColour ?? Color.Empty;

            ButtonOneTextColour = buttonOneTextColour ?? Color.Empty;

            ButtonTwoTextColour = buttonTwoTextColour ?? Color.Empty;

            ButtonThreeTextColour = buttonThreeTextColour ?? Color.Empty;

            YesButtonColour = yesButtonColour ?? Color.Empty;

            NoButtonColour = noButtonColour ?? Color.Empty;

            TextColour = textColour ?? Color.Empty;

            YesNoButtonTextColour = yesNoButtonTextColour ?? Color.Empty;

            ParentWindow = parentWindow ?? null;
        }
        #endregion

        #region Methods
        /*
        /// <summary>Shows the message box.</summary>
        public void ShowMessageBox() => InternalKryptonMessageBoxExtended.Show(_owner, _messageBoxContentText, _messageBoxCaption, _buttons,
                                                                               _customButtonOptions, _messageBoxIcon, _defaultButton,
                                                                               _options, _helpPath, _helpNavigator, _helpParam, _showCtrlCopy,
                                                                               _messageBoxTypeface, _showOptionalCheckBox, _optionalCheckBoxText,
                                                                               _isOptionalCheckBoxChecked, _optionalCheckBoxCheckState,
                                                                               _optionalCheckBoxAnchor, _optionalCheckBoxLocation, _customMessageBoxIcon,
                                                                               _showCopyButton, _copyButtonText, _fade, _fadeSleepTimer,
                                                                               _messageBoxButtonOneCustomText, _messageBoxButtonTwoCustomText,
                                                                               _messageBoxButtonThreeCustomText, _customButtonOneResult,
                                                                               _customButtonTwoResult, _customButtonThreeResult, _cornerRadius,
                                                                               _showToolTips, _useBlur, _useYesNoCancelButtonColour,
                                                                               _blurRadius, _contentMessageColour, _buttonOneTextColour,
                                                                               _buttonTwoTextColour, _buttonThreeTextColour, _yesButtonColour,
                                                                               _noButtonColour, _textColour, _yesNoButtonTextColour, _parentWindow);

        /// <summary>Gets the message box dialog result.</summary>
        /// <returns>The message box dialog result.</returns>
        public DialogResult GetMessageBoxResult()
        {
            DialogResult result = InternalKryptonMessageBoxExtended.Show(_owner, _messageBoxContentText, _messageBoxCaption, _buttons,
                                                                               _customButtonOptions, _messageBoxIcon, _defaultButton,
                                                                               _options, _helpPath, _helpNavigator, _helpParam, _showCtrlCopy,
                                                                               _messageBoxTypeface, _showOptionalCheckBox, _optionalCheckBoxText,
                                                                               _isOptionalCheckBoxChecked, _optionalCheckBoxCheckState,
                                                                               _optionalCheckBoxAnchor, _optionalCheckBoxLocation, _customMessageBoxIcon,
                                                                               _showCopyButton, _copyButtonText, _fade, _fadeSleepTimer,
                                                                               _messageBoxButtonOneCustomText, _messageBoxButtonTwoCustomText,
                                                                               _messageBoxButtonThreeCustomText, _customButtonOneResult,
                                                                               _customButtonTwoResult, _customButtonThreeResult, _cornerRadius,
                                                                               _showToolTips, _useBlur, _useYesNoCancelButtonColour,
                                                                               _blurRadius, _contentMessageColour, _buttonOneTextColour,
                                                                               _buttonTwoTextColour, _buttonThreeTextColour, _yesButtonColour,
                                                                               _noButtonColour, _textColour, _yesNoButtonTextColour, _parentWindow);
            return result;
        }*/
        #endregion
    }
}