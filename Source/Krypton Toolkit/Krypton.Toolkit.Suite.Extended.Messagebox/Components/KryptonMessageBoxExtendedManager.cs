namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    /// <summary>Allows the creation of a <see cref="KryptonMessageBoxExtended"/> through the designer.</summary>
    /// <seealso cref="Component" />
    [ToolboxBitmap(typeof(KryptonMessageBoxManager), "ToolboxBitmaps.KryptonMessageBox.bmp"),
     DefaultEvent("ShowMessageBox"), DefaultProperty("MessageBoxContentText"),
     Description("Allows the creation of a KryptonMessageBoxExtended through the designer.")] //, Designer(typeof(KryptonMessageBoxConfiguratorDesigner))]
    public class KryptonMessageBoxManager : Component
    {
        #region Fields

        private bool _showCtrlCopy, _showOptionalCheckBox, _isOptionalCheckBoxChecked;

        private CheckState _optionalCheckBoxCheckState;

        private ExtendedMessageBoxButtons _buttons;

        private ExtendedKryptonMessageBoxIcon _icon;

        private MessageBoxDefaultButton _defaultButton;

        private MessageBoxOptions _options;

        private Font _messageBoxTypeface;

        private Image _customImageIcon;

        private string _text, _captionText, _helpFilePath, _optionalCheckBoxText;

        private object _parameters;

        private HelpNavigator _helpNavigator;

        private IWin32Window _owner;

        #endregion

        #region Properties
        /// <summary>Gets or sets a value indicating whether [show control copy].</summary>
        /// <value><c>true</c> if [show control copy]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description(@"Show control, copy shortcut. (Ctrl + C)")]
        public bool ShowCtrlCopy { get => _showCtrlCopy; set => _showCtrlCopy = value; }

        /// <summary>Gets or sets a value indicating whether [show optional CheckBox].</summary>
        /// <value><c>true</c> if [show optional CheckBox]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description(@"Displays the optional checkbox.")]
        public bool ShowOptionalCheckBox { get => _showOptionalCheckBox; set => _showOptionalCheckBox = value; }

        /// <summary>Gets or sets a value indicating whether this instance is optional CheckBox checked.</summary>
        /// <value><c>true</c> if this instance is optional CheckBox checked; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description(@"Sets whether the optional check box is checked or not.")]
        public bool IsOptionalCheckBoxChecked { get => _isOptionalCheckBoxChecked; set => _isOptionalCheckBoxChecked = value; }

        [DefaultValue(typeof(CheckState), "CheckState.Unchecked"), Description(@"Sets the optional check box check state.")]
        public CheckState OptionalCheckBoxCheckState { get => _optionalCheckBoxCheckState; set => _optionalCheckBoxCheckState = value; }

        [DefaultValue(typeof(ExtendedKryptonMessageBoxIcon), "ExtendedKryptonMessageBoxIcon.NONE"), Description(@"Set the message box icon.")]
        public ExtendedKryptonMessageBoxIcon MessageBoxIcon { get => _icon; set => _icon = value; }

        [DefaultValue(typeof(ExtendedMessageBoxButtons), "ExtendedMessageBoxButtons.OK"), Description(@"Sets the message button layout.")]
        public ExtendedMessageBoxButtons MessageBoxButtons { get => _buttons; set => _buttons = value; }

        [DefaultValue(typeof(MessageBoxDefaultButton), "MessageBoxDefaultButton.Button1"), Description(@"The default selected message box button.")]
        public MessageBoxDefaultButton DefaultButton { get => _defaultButton; set => _defaultButton = value; }

        [DefaultValue(typeof(MessageBoxOptions), "MessageBoxOptions.DefaultDesktopOnly"), Description(@"Specifies extra message box options.")]
        public MessageBoxOptions Options { get => _options; set => _options = value; }

        [DefaultValue(typeof(Font), "Segoe UI, 8.25F"), Description(@"Specifies the font on all text surfaces.Specifies")]
        public Font MessageBoxTypeface { get => _messageBoxTypeface; set => _messageBoxTypeface = value; }

        [DefaultValue(null), Description(@"Specifies a custom message box icon. Note, you'll need to set the MessageBoxIcon to 'CUSTOM' for this to work.")]
        public Image CustomImageIcon { get => _customImageIcon; set => _customImageIcon = value; }

        [DefaultValue(null), Description(@"Specifies the message box content text.")]
        public string Text { get => _text; set => _text = value; }

        [DefaultValue(null), Description(@"Specifies the message box window title text.")]
        public string CaptionText { get => _captionText; set => _captionText = value; }

        [DefaultValue(null), Description(@"The path and name of the Help file to display when the user clicks the Help button.")]
        public string HelpFilePath { get => _helpFilePath; set => _helpFilePath = value; }

        [DefaultValue(null), Description(@"Specifies the message box optional check box text.")]
        public string OptionalCheckBoxText { get => _optionalCheckBoxText; set => _optionalCheckBoxText = value; }

        [DefaultValue(null), Description(@"The numeric ID of the Help topic to display when the user clicks the Help button.")]
        public object Parameters { get => _parameters; set => _parameters = value; }

        [DefaultValue(0), Description(@"One of the System.Windows.Forms.HelpNavigator values.")]
        public HelpNavigator HelpNavigator { get => _helpNavigator; set => _helpNavigator = value; }

        [DefaultValue(0), Description(@"Owner of the modal dialog box.")]
        public IWin32Window Owner { get => _owner; set => _owner = value; }

        #endregion

        #region Constructor

        public KryptonMessageBoxManager(IWin32Window owner, string text, string caption,
                                        ExtendedMessageBoxButtons buttons,
                                        ExtendedKryptonMessageBoxIcon icon,
                                        MessageBoxDefaultButton defaultButton,
                                        MessageBoxOptions options,
                                        string helpFilePath,
                                        HelpNavigator navigator,
                                        object param, bool? showCtrlCopy,
                                        Font messageBoxTypeface,
                                        Image customImageIcon,
                                        bool showOptionalCheckBox,
                                        bool isOptionalCheckBoxChecked,
                                        CheckState optionalCheckBoxCheckState,
                                        string optionalCheckBoxText)
        {
            Owner = owner;

            Text = text;

            CaptionText = caption;

            MessageBoxButtons = buttons;

            MessageBoxIcon = icon;

            DefaultButton = defaultButton;

            Options = options;

            HelpFilePath = helpFilePath;

            HelpNavigator = navigator;

            Parameters = param;

            MessageBoxTypeface = messageBoxTypeface;

            CustomImageIcon = customImageIcon;

            ShowOptionalCheckBox = showOptionalCheckBox;

            OptionalCheckBoxCheckState = optionalCheckBoxCheckState;

            OptionalCheckBoxText = optionalCheckBoxText;

            IsOptionalCheckBoxChecked = isOptionalCheckBoxChecked;

            ShowCtrlCopy = showCtrlCopy ?? false;
        }

        #endregion

        #region Virtual

        public virtual DialogResult ShowMessageBox()
        {
            return KryptonMessageBoxExtended.InternalShow(_owner, _text, _captionText,
                                                          _buttons, _icon, _defaultButton,
                                                          _options,
                                                          new HelpInfo(_helpFilePath,
                                                                       _helpNavigator,
                                                                       _parameters),
                                                          _showCtrlCopy, _messageBoxTypeface,
                                                          _customImageIcon,
                                                          _showOptionalCheckBox,
                                                          _isOptionalCheckBoxChecked,
                                                          _optionalCheckBoxCheckState,
                                                          _optionalCheckBoxText);
        }

        #endregion
    }
}
