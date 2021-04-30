using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonInputBoxManager : Component
    {
        #region Variables
        private bool _showInTaskBar;

        private FormStartPosition _startPosition;

        private Font _controlTypeface, _messageTypeface;

        private InputBoxButtons _buttons;

        private InputBoxIconImageSize _imageSize;

        private InputBoxIconType _iconType;

        private InputBoxInputType _inputType;

        private InputBoxLanguage _inputBoxLanguage;

        private InputBoxMessageDisplayType _displayType;

        private InputBoxNormalMessageTextAlignment _messageTextAlignment;

        private InputBoxTextAlignment _textAlignment;

        private InputBoxWrappedMessageTextAlignment _wrappedMessageTextAlignment;

        private Image _customImage;

        private Point _inputBoxIconLocation;

        private string _message, _title, _okText, _yesText, _noText, _cancelText, _hintText;

        private string[] _itemList;
        #endregion

        #region Properties
        public bool ShowInTaskBar { get => _showInTaskBar; set => _showInTaskBar = value; }
        #endregion

        #region Constructor
        public KryptonInputBoxManager()
        {

        }
        #endregion

        #region Methods
        public void DisplayMessageBox()
        {
            KryptonInputBoxExtended kryptonInputBox = new KryptonInputBoxExtended(_inputBoxIconLocation, _message, _title, _iconType,
                                                                                  _customImage, _imageSize, _inputBoxLanguage,
                                                                                  _buttons, _inputType, _displayType,
                                                                                  _itemList, _showInTaskBar, _controlTypeface,
                                                                                  _messageTypeface, _okText, _yesText, _noText, _cancelText,
                                                                                  _hintText, _startPosition, _textAlignment,
                                                                                  _messageTextAlignment, _wrappedMessageTextAlignment);

            kryptonInputBox.Show();
        }
        #endregion
    }
}