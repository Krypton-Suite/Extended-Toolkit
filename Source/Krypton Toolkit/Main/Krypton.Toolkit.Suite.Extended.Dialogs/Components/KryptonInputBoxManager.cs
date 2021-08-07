namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonInputBoxManager : Component
    {
        #region Variables
        private bool _showInTaskBar;

        private Color _cueHintColour;

        private FormStartPosition _startPosition;

        private Font _controlTypeface, _cueHintTypeface, _messageTypeface, _headerTypeface;

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

        private string _cueHintText, _message, _headerText, _title, _okText, _yesText, _noText, _cancelText;

        private string[] _itemList;
        #endregion

        #region Properties
        /// <summary>Gets or sets a value indicating whether to show in task bar.</summary>
        /// <value><c>true</c> if [show in task bar]; otherwise, <c>false</c>.</value>
        public bool ShowInTaskBar { get => _showInTaskBar; set => _showInTaskBar = value; }

        public Color CueHintColour
        {
            get => _cueHintColour;

            set => _cueHintColour = value;
        }

        /// <summary>Gets or sets the start position.</summary>
        /// <value>The start position.</value>
        public FormStartPosition StartPosition { get => _startPosition; set => _startPosition = value; }

        [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25f")]
        public Font ControlTypeface { get => _controlTypeface; set => _controlTypeface = value; }

        [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25f")]
        public Font CueHintTypeface { get => _cueHintTypeface; set => _cueHintTypeface = value; }

        [DefaultValue(typeof(Font), "Microsoft Sans Serif, 11.25f, FontStyle.Bold")]
        public Font HeaderTypeface { get => _headerTypeface; set => _headerTypeface = value; }

        [DefaultValue(typeof(Font), "Microsoft Sans Serif, 8.25f")]
        public Font MessageTypeface { get => _messageTypeface; set => _messageTypeface = value; }

        public InputBoxButtons InputBoxButtons { get => _buttons; set => _buttons = value; }

        public InputBoxIconImageSize InputBoxIconImageSize { get => _imageSize; set => _imageSize = value; }

        public InputBoxIconType InputBoxIconType { get => _iconType; set => _iconType = value; }

        public InputBoxInputType InputBoxInputType { get => _inputType; set => _inputType = value; }

        public InputBoxLanguage InputBoxLanguage { get => _inputBoxLanguage; set => _inputBoxLanguage = value; }

        public InputBoxMessageDisplayType InputBoxMessageDisplayType { get => _displayType; set => _displayType = value; }

        public InputBoxNormalMessageTextAlignment InputBoxNormalMessageTextAlignment { get => _messageTextAlignment; set => _messageTextAlignment = value; }

        public InputBoxTextAlignment InputBoxTextAlignment { get => _textAlignment; set => _textAlignment = value; }

        public InputBoxWrappedMessageTextAlignment InputBoxWrappedMessageTextAlignment { get => _wrappedMessageTextAlignment; set => _wrappedMessageTextAlignment = value; }

        public Image CustomImage
        {
            get => _customImage;

            set
            {
                if (_customImage != value)
                {
                    _customImage = value;

                    _iconType = InputBoxIconType.CUSTOM;
                }
            }
        }

        public Point InputBoxIconLocation { get => _inputBoxIconLocation; set => _inputBoxIconLocation = value; }

        public string Message { get => _message; set => _message = value; }

        public string Title { get => _title; set => _title = value; }

        public string OkText { get => _okText; set => _okText = value; }

        public string YesText { get => _yesText; set => _yesText = value; }

        public string NoText { get => _noText; set => _noText = value; }

        public string CancelText { get => _cancelText; set => _cancelText = value; }

        public string CueHintText { get => _cueHintText; set => _cueHintText = value; }

        public string HeaderText { get => _headerText; set => _headerText = value; }

        public string[] ItemList { get => _itemList; set => _itemList = value; }
        #endregion

        #region Constructor
        public KryptonInputBoxManager()
        {
            _buttons = InputBoxButtons.OK;

            _cancelText = "C&ancel";

            _controlTypeface = new Font("Microsoft Sans Serif", 8.25f);

            _messageTypeface = new Font("Microsoft Sans Serif", 8.25f);

            _headerTypeface = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold);

            _customImage = null;

            _displayType = InputBoxMessageDisplayType.LABEL;

            _cueHintText = "Hint";

            _iconType = InputBoxIconType.NONE;

            _imageSize = InputBoxIconImageSize.SIXTYFOUR;

            _inputBoxIconLocation = new Point(12, 12);

            _inputBoxLanguage = InputBoxLanguage.ENGLISH;

            _inputType = InputBoxInputType.TEXTBOX;

            _itemList = null;

            _message = "Your message here...";

            _messageTextAlignment = InputBoxNormalMessageTextAlignment.CENTRENEAR;

            _noText = "N&o";

            _okText = "&Ok";

            _headerText = "Header Text Here";

            _showInTaskBar = false;

            _startPosition = FormStartPosition.Manual;

            _textAlignment = InputBoxTextAlignment.CENTRE;

            _title = "";

            _wrappedMessageTextAlignment = InputBoxWrappedMessageTextAlignment.MIDDLELEFT;

            _yesText = "Y&es";
        }
        #endregion

        #region Methods
        public void DisplayInputBox()
        {
            KryptonInputBoxExtended kryptonInputBox = new KryptonInputBoxExtended(_inputBoxIconLocation, _message, 
                                                                                  _title, _iconType,
                                                                                  _customImage, _imageSize, _inputBoxLanguage,
                                                                                  _buttons, _inputType, _displayType,
                                                                                  _itemList, _showInTaskBar, _controlTypeface,
                                                                                  _messageTypeface, _headerTypeface, _okText, 
                                                                                  _yesText, _noText, _cancelText,
                                                                                  _headerText, _startPosition, _textAlignment,
                                                                                  _messageTextAlignment, _wrappedMessageTextAlignment, 
                                                                                  _cueHintColour, _cueHintTypeface, _cueHintText);

            kryptonInputBox.Show();
        }
        #endregion
    }
}