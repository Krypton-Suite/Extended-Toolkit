using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static Krypton.Toolkit.Suite.Extended.Messagebox.KryptonMessageBoxExtended;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    /// <summary>
    ///   <br />
    /// </summary>
    public class ShowMessageBoxEventArgs : EventArgs
    {
        #region Variables
        private AnchorStyles _optionalCheckBoxAnchor;

        private bool _showCtrlCopy, _showOptionalCheckBox, _isOptionalCheckBoxChecked;

        private Font _messageBoxTypeface;

        private MessageBoxButtons _buttons;

        private MessageBoxDefaultButton _defaultButton;

        private MessageBoxOptions _options;

        private ExtendedMessageBoxIcon _messageBoxIcon;

        private HelpNavigator _helpNavigator;

        private Image _customMessageBoxIcon;

        private IWin32Window _owner;

        private string _messageBoxCaption, _messageBoxContentText, _optionalCheckBoxText, _helpPath;

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

        /// <summary>Gets or sets a value indicating whether [show optional CheckBox].</summary>
        /// <value><c>true</c> if [show optional CheckBox]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Shows a optional check box in the message box footer.")]
        public bool ShowOptionalCheckBox { get => _showOptionalCheckBox; set => _showOptionalCheckBox = value; }

        /// <summary>Gets or sets a value indicating whether this instance is optional CheckBox checked.</summary>
        /// <value><c>true</c> if this instance is optional CheckBox checked; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Is the optional check box checked by default?")]
        public bool IsOptionalCheckBoxChecked { get => _isOptionalCheckBoxChecked; set => _isOptionalCheckBoxChecked = value; }

        /// <summary>Gets or sets the message box typeface.</summary>
        /// <value>The message box typeface.</value>
        [DefaultValue(typeof(Font), ""), Description("Gets or sets the message box typeface.")]
        public Font MessageBoxTypeface { get => _messageBoxTypeface; set => _messageBoxTypeface = value; }

        /// <summary>Gets or sets the message box buttons.</summary>
        /// <value>The message box buttons.</value>
        [DefaultValue(typeof(MessageBoxButtons), "MessageBoxButtons.OK"), Description("Gets or sets the message box buttons.")]
        public MessageBoxButtons MessageBoxButtons { get => _buttons; set => _buttons = value; }

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
        [DefaultValue(null), Description("Gets or sets the help navigator.")]
        public HelpNavigator HelpNavigator { get => _helpNavigator; set => _helpNavigator = value; }

        /// <summary>Gets or sets a custom message box icon.</summary>
        /// <value>The custom message box icon.</value>
        [DefaultValue(null), Description("Gets or sets a custom message box icon.")]
        public Image CustomMessageBoxIcon { get => _customMessageBoxIcon; set => _customMessageBoxIcon = value; }

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
        /// <param name="messageboxTypeface">The messagebox typeface.</param>
        /// <param name="showOptionalCheckBox">if set to <c>true</c> [show optional CheckBox].</param>
        /// <param name="optionalCheckBoxText">The optional CheckBox text.</param>
        /// <param name="isOptionalCheckBoxChecked">if set to <c>true</c> [is optional CheckBox checked].</param>
        /// <param name="customMessageBoxIcon">The custom message box icon.</param>
        public ShowMessageBoxEventArgs(IWin32Window owner, string text, string caption,
                                       MessageBoxButtons buttons, ExtendedMessageBoxIcon icon,
                                       MessageBoxDefaultButton defaultButton,
                                       MessageBoxOptions options, string helpPath, 
                                       HelpNavigator helpNavigator, object helpParam,
                                       bool showCtrlCopy, Font messageboxTypeface, bool showOptionalCheckBox,
                                       string optionalCheckBoxText, bool isOptionalCheckBoxChecked,
                                       Image customMessageBoxIcon)
        {
            Owner = owner;

            MessageBoxContentText = text;

            MessageBoxCaption = caption;

            MessageBoxButtons = buttons;

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

            CustomMessageBoxIcon = customMessageBoxIcon;
        }
        #endregion

        #region Methods
        /// <summary>Shows the message box.</summary>
        public void ShowMessageBox() => KryptonMessageBoxExtended.Show(Owner, MessageBoxContentText, MessageBoxCaption, MessageBoxButtons, MessageBoxIcon,
                                                                       MessageBoxDefaultButton, MessageBoxOptions,
                                                                       new HelpInformation(HelpPath, HelpNavigator, HelpParam), ShowCtrlCopy, MessageBoxTypeface,
                                                                       ShowOptionalCheckBox, OptionalCheckBoxText, IsOptionalCheckBoxChecked, CustomMessageBoxIcon);

        /// <summary>Gets the message box dialog result.</summary>
        /// <returns>The message box dialog result.</returns>
        public DialogResult GetMessageBoxResult()
        {
            DialogResult result = KryptonMessageBoxExtended.Show(Owner, MessageBoxContentText, MessageBoxCaption, MessageBoxButtons, MessageBoxIcon,
                                                                       MessageBoxDefaultButton, MessageBoxOptions,
                                                                       new HelpInformation(HelpPath, HelpNavigator, HelpParam), ShowCtrlCopy, MessageBoxTypeface,
                                                                       ShowOptionalCheckBox, OptionalCheckBoxText, IsOptionalCheckBoxChecked, CustomMessageBoxIcon);
            return result;
        }
        #endregion
    }
}