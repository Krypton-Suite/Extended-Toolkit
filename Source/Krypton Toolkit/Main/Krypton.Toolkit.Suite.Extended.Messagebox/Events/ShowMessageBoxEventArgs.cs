using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    /// <summary>
    ///   <br />
    /// </summary>
    public class ShowMessageBoxEventArgs : EventArgs
    {
        #region Variables
        private AnchorStyles _optionalCheckBoxAnchor;

        private bool _showCtrlCopy, _fade, _showOptionalCheckBox, _isOptionalCheckBoxChecked, _showCopyButton;

        private CheckState _optionalCheckBoxCheckState;

        private DialogResult _customButtonOneResult, _customButtonTwoResult, _customButtonThreeResult;

        private Font _messageBoxTypeface;

        private ExtendedMessageBoxButtons _buttons;

        private ExtendedMessageBoxCustomButtonOptions _customButtonOptions;

        private MessageBoxDefaultButton _defaultButton;

        private MessageBoxOptions _options;

        private ExtendedMessageBoxIcon _messageBoxIcon;

        private HelpNavigator _helpNavigator;

        private Image _customMessageBoxIcon;

        private int _fadeSleepTimer, _timeout;

        private IWin32Window _owner;

        private string _messageBoxCaption, _messageBoxContentText, _optionalCheckBoxText, _helpPath, _copyButtonText, _messageBoxButtonOneCustomText, _messageBoxButtonTwoCustomText, _messageBoxButtonThreeCustomText;

        private object _helpParam;

        private Point _optionalCheckBoxLocation;
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

        /// <summary>Gets or sets a value indicating whether this <see cref="KryptonMessageBoxManager" /> is fade.</summary>
        /// <value>
        ///   <c>true</c> if fade; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Fades the message box in and out. (Under construction)")]
        public bool Fade { get => _fade; set => _fade = value; }

        /// <summary>Gets or sets a value indicating whether [show optional CheckBox].</summary>
        /// <value><c>true</c> if [show optional CheckBox]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Shows a optional check box in the message box footer.")]
        public bool ShowOptionalCheckBox { get => _showOptionalCheckBox; set => _showOptionalCheckBox = value; }

        /// <summary>Gets or sets a value indicating whether this instance is optional CheckBox checked.</summary>
        /// <value><c>true</c> if this instance is optional CheckBox checked; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Is the optional check box checked by default?")]
        public bool IsOptionalCheckBoxChecked { get => _isOptionalCheckBoxChecked; set => _isOptionalCheckBoxChecked = value; }

        /// <summary>Gets or sets a value indicating whether [show copy button].</summary>
        /// <value><c>true</c> if [show copy button]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Show the copy button.")]
        public bool ShowCopyButton { get => _showCopyButton; set => _showCopyButton = value; }

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
        [DefaultValue(typeof(ExtendedMessageBoxIcon), "ExtendedMessageBoxIcon.NONE"), Description("Gets or sets the message box icon.")]
        public ExtendedMessageBoxIcon MessageBoxIcon { get => _messageBoxIcon; set => _messageBoxIcon = value; }

        /// <summary>Gets or sets the help navigator.</summary>
        /// <value>The help navigator.</value>
        [DefaultValue(typeof(HelpNavigator), "HelpNavigator.AssociateIndex"), Description("Gets or sets the help navigator.")]
        public HelpNavigator HelpNavigator { get => _helpNavigator; set => _helpNavigator = value; }

        /// <summary>Gets or sets a custom message box icon.</summary>
        /// <value>The custom message box icon.</value>
        [DefaultValue(null), Description("Gets or sets a custom message box icon.")]
        public Image CustomMessageBoxIcon { get => _customMessageBoxIcon; set => _customMessageBoxIcon = value; }

        /// <summary>Gets or sets the speed of the fading animation in milliseconds.</summary>
        /// <value>The speed of the fading animation in milliseconds.</value>
        [DefaultValue(50), Description("Gets or sets the speed of the fading animation in milliseconds.")]
        public int FadeSleepTimer { get => _fadeSleepTimer; set => _fadeSleepTimer = value; }

        /// <summary>Gets or sets the time out. (This feature is under construction)</summary>
        /// <value>The time out.</value>
        [DefaultValue(60), Description("Gets or sets the time out. (This feature is under construction)")]
        public int TimeOut { get => _timeout; set => _timeout = value; }

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

        /// <summary>Gets or sets the copy button text.</summary>
        /// <value>The copy button text.</value>
        [DefaultValue("&Copy Details"), Description("Gets or sets the copy button text.")]
        public string CopyButtonText { get => _copyButtonText; set => _copyButtonText = value; }

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
        /// <param name="icon">The icon.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="options">The options.</param>
        /// <param name="helpNavigator">The help information.</param>
        /// <param name="showCtrlCopy">if set to <c>true</c> [show control copy].</param>
        /// <param name="messageboxTypeface">The message box typeface.</param>
        /// <param name="showOptionalCheckBox">if set to <c>true</c> [show optional CheckBox].</param>
        /// <param name="optionalCheckBoxText">The optional CheckBox text.</param>
        /// <param name="isOptionalCheckBoxChecked">if set to <c>true</c> [is optional CheckBox checked].</param>
        /// <param name="customMessageBoxIcon">The custom message box icon.</param>
        public ShowMessageBoxEventArgs(IWin32Window owner, string text, string caption,
                                       ExtendedMessageBoxButtons buttons, ExtendedMessageBoxCustomButtonOptions customButtonOptions,
                                       ExtendedMessageBoxIcon icon,
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
                                       DialogResult? buttonThreeCustomDialogResult)
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

            ShowCopyButton = showCopyButton;

            CopyButtonText = copyButtonText;

            Fade = fade;

            FadeSleepTimer = fadeSleepTimer;

            ButtonOneCustomText = buttonOneCustomText;

            ButtonTwoCustomText = buttonTwoCustomText;

            ButtonThreeCustomText = buttonThreeCustomText;

            CustomButtonOneResult = buttonOneCustomDialogResult ?? DialogResult.None;

            CustomButtonTwoResult = buttonTwoCustomDialogResult ?? DialogResult.None;

            CustomButtonThreeResult = buttonThreeCustomDialogResult ?? DialogResult.None;
        }
        #endregion

        #region Methods
        /// <summary>Shows the message box.</summary>
        public void ShowMessageBox() => InternalKryptonMessageBoxExtended.Show(Owner, MessageBoxContentText, MessageBoxCaption, MessageBoxButtons,
                                                                               CustomButtonOptions, MessageBoxIcon, MessageBoxDefaultButton,
                                                                               MessageBoxOptions, HelpPath, HelpNavigator, HelpParam,
                                                                               ShowCtrlCopy, MessageBoxTypeface, ShowOptionalCheckBox, OptionalCheckBoxText,
                                                                               IsOptionalCheckBoxChecked, OptionalCheckBoxCheckState, OptionalCheckBoxAnchor,
                                                                               OptionalCheckBoxLocation, CustomMessageBoxIcon, ShowCopyButton, CopyButtonText,
                                                                               Fade, FadeSleepTimer, ButtonOneCustomText, ButtonTwoCustomText, ButtonThreeCustomText,
                                                                               CustomButtonOneResult, CustomButtonTwoResult, CustomButtonThreeResult);

        /// <summary>Gets the message box dialog result.</summary>
        /// <returns>The message box dialog result.</returns>
        public DialogResult GetMessageBoxResult()
        {
            DialogResult result = InternalKryptonMessageBoxExtended.Show(Owner, MessageBoxContentText, MessageBoxCaption, MessageBoxButtons,
                                                                               CustomButtonOptions, MessageBoxIcon, MessageBoxDefaultButton,
                                                                               MessageBoxOptions, HelpPath, HelpNavigator, HelpParam,
                                                                               ShowCtrlCopy, MessageBoxTypeface, ShowOptionalCheckBox, OptionalCheckBoxText,
                                                                               IsOptionalCheckBoxChecked, OptionalCheckBoxCheckState, OptionalCheckBoxAnchor,
                                                                               OptionalCheckBoxLocation, CustomMessageBoxIcon, ShowCopyButton, CopyButtonText,
                                                                               Fade, FadeSleepTimer, ButtonOneCustomText, ButtonTwoCustomText, ButtonThreeCustomText,
                                                                               CustomButtonOneResult, CustomButtonTwoResult, CustomButtonThreeResult);
            return result;
        }
        #endregion
    }
}