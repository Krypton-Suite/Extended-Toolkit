using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    [ToolboxBitmap(typeof(KryptonMessageBoxConfigurator), "ToolboxBitmaps.KryptonMessageBox.bmp"),
     DefaultEvent("ShowMessageBox"), DefaultProperty("MessageBoxContentText")]
    public class KryptonMessageBoxConfigurator : Component
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

        #region Custom Event Setup
        public delegate void ShowMessageBoxEvent(object sender, ShowMessageBoxEventArgs e);

        public event ShowMessageBoxEvent ShowMessageBox;

        protected virtual void OnShowMessageBox(object sender, ShowMessageBoxEventArgs e) => ShowMessageBox?.Invoke(sender, e);
        #endregion

        #region Constructor
        public KryptonMessageBoxConfigurator()
        {

        }
        #endregion

        #region Methods
        public void DisplayMessageBox()
        {
            ShowMessageBoxEventArgs e = new ShowMessageBoxEventArgs(_owner, _messageBoxContentText, _messageBoxCaption, _buttons, _messageBoxIcon,
                                                                    _defaultButton, _options, _helpPath, _helpNavigator, _helpParam, _showCtrlCopy,
                                                                    _messageBoxTypeface, _showOptionalCheckBox, _optionalCheckBoxText,
                                                                    _isOptionalCheckBoxChecked, _customMessageBoxIcon);

            e.ShowMessageBox();
        }
        #endregion
    }
}