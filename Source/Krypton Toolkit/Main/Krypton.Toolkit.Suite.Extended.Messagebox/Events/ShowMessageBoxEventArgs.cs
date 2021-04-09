using System;
using System.Drawing;
using System.Windows.Forms;
using static Krypton.Toolkit.Suite.Extended.Messagebox.KryptonMessageBoxExtended;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    public class ShowMessageBoxEventArgs : EventArgs
    {
        #region Variables
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
        #endregion

        #region Properties
        public bool ShowCtrlCopy { get => _showCtrlCopy; set => _showCtrlCopy = value; }

        public bool ShowOptionalCheckBox { get => _showOptionalCheckBox; set => _showOptionalCheckBox = value; }

        public bool IsOptionalCheckBoxChecked { get => _isOptionalCheckBoxChecked; set => _isOptionalCheckBoxChecked = value; }

        public Font MessageBoxTypeface { get => _messageBoxTypeface; set => _messageBoxTypeface = value; }

        public MessageBoxButtons MessageBoxButtons { get => _buttons; set => _buttons = value; }

        public MessageBoxDefaultButton MessageBoxDefaultButton { get => _defaultButton; set => _defaultButton = value; }

        public MessageBoxOptions MessageBoxOptions { get => _options; set => _options = value; }

        public ExtendedMessageBoxIcon MessageBoxIcon { get => _messageBoxIcon; set => _messageBoxIcon = value; }

        public HelpNavigator HelpNavigator { get => _helpNavigator; set => _helpNavigator = value; }

        public Image CustomMessageBoxIcon { get => _customMessageBoxIcon; set => _customMessageBoxIcon = value; }

        public IWin32Window Owner { get => _owner; set => _owner = value; }

        public string MessageBoxCaption { get => _messageBoxCaption; set => _messageBoxCaption = value; }

        public string MessageBoxContentText { get => _messageBoxContentText; set => _messageBoxContentText = value; }

        public string OptionalCheckBoxText { get => _optionalCheckBoxText; set => _optionalCheckBoxText = value; }

        public string HelpPath { get => _helpPath; set => _helpPath = value; }

        public object HelpParam { get => _helpParam; set => _helpParam = value; }
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