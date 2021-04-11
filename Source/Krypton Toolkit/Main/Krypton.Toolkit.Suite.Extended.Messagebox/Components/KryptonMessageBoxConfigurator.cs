using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    /// <summary>Allows the creation of a <see cref="KryptonMessageBoxExtended"/> through the designer.</summary>
    /// <seealso cref="System.ComponentModel.Component" />
    [ToolboxBitmap(typeof(KryptonMessageBoxConfigurator), "ToolboxBitmaps.KryptonMessageBox.bmp"),
     DefaultEvent("ShowMessageBox"), DefaultProperty("MessageBoxContentText"),
     Description("Allows the creation of a KryptonMessageBoxExtended through the designer.")] //, Designer(typeof(KryptonMessageBoxConfiguratorDesigner))]
    public class KryptonMessageBoxConfigurator : Component
    {
        #region Variables
        private AnchorStyles _optionalCheckBoxAnchor;

        private bool _showCtrlCopy, _showOptionalCheckBox, _isOptionalCheckBoxChecked, _showCopyButton;

        private CheckState _optionalCheckBoxCheckState;

        private Font _messageBoxTypeface;

        private ExtendedMessageBoxButtons _buttons;

        private MessageBoxDefaultButton _defaultButton;

        private MessageBoxOptions _options;

        private ExtendedMessageBoxIcon _messageBoxIcon;

        private HelpNavigator _helpNavigator;

        private Image _customMessageBoxIcon;

        private int _timeout;

        private IWin32Window _owner;

        private string _messageBoxCaption, _messageBoxContentText, _optionalCheckBoxText, _helpPath, _copyButtonText;

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

        /*
        /// <summary>Gets or sets a value indicating whether [show copy button].</summary>
        /// <value><c>true</c> if [show copy button]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Show the copy button.")]
        public bool ShowCopyButton { get => _showCopyButton; set => _showCopyButton = value; }
        */

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

        /*
        /// <summary>Gets or sets the copy button text.</summary>
        /// <value>The copy button text.</value>
        [DefaultValue("&Copy Details"), Description("Gets or sets the copy button text.")]
        public string CopyButtonText { get => _copyButtonText; set => _copyButtonText = value; }
        */

        /// <summary>Gets or sets the help parameters.</summary>
        /// <value>The help parameters.</value>
        [DefaultValue(null), Description("Gets or sets the help parameters.")]
        public object HelpParam { get => _helpParam; set => _helpParam = value; }

        /// <summary>Gets or sets the optional CheckBox location.</summary>
        /// <value>The optional CheckBox location.</value>
        [DefaultValue(typeof(Point), "12, 0"), Description("Gets or sets the optional CheckBox location.")]
        public Point OptionalCheckBoxLocation { get => _optionalCheckBoxLocation; set => _optionalCheckBoxLocation = value; }
        #endregion

        #region Custom Event Setup
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
        /// <summary>Initializes a new instance of the <see cref="KryptonMessageBoxConfigurator" /> class.</summary>
        public KryptonMessageBoxConfigurator()
        {
            OptionalCheckBoxAnchor = AnchorStyles.Left;

            OptionalCheckBoxCheckState = CheckState.Unchecked;

            OptionalCheckBoxLocation = new Point(12, 0);

            MessageBoxTypeface = new Font("Microsoft Sans Serif", 8.25f);

            HelpNavigator = HelpNavigator.AssociateIndex;

            MessageBoxIcon = ExtendedMessageBoxIcon.NONE;
        }
        #endregion

        #region Methods
        /// <summary>Displays the message box.</summary>
        public void DisplayMessageBox()
        {
            ShowMessageBoxEventArgs e = new ShowMessageBoxEventArgs(_owner, _messageBoxContentText, _messageBoxCaption, _buttons, _messageBoxIcon,
                                                                    _defaultButton, _options, _helpPath, _helpNavigator, _helpParam, _showCtrlCopy,
                                                                    _messageBoxTypeface, _showOptionalCheckBox, _optionalCheckBoxText,
                                                                    _isOptionalCheckBoxChecked, _optionalCheckBoxAnchor, _optionalCheckBoxLocation,
                                                                    _customMessageBoxIcon, _showCopyButton, _copyButtonText);

            e.ShowMessageBox();
        }
        #endregion
    }
}