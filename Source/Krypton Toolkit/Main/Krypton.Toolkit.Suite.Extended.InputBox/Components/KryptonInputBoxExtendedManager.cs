namespace Krypton.Toolkit.Suite.Extended.InputBox
{
    public class KryptonInputBoxExtendedManager : Component
    {
        #region Variables
        private Point _iconLocation;
        private string _message, _title, _okText, _yesText, _noText, _cancelText, _hintText;
        private InputBoxIconType _icon;
        private Image _image;
        private InputBoxLanguage _language;
        private InputBoxButtons _buttons;
        private InputBoxInputType _type;
        private string[] _listItems;
        private bool _showInTaskBar;
        private Font _controlTypeface, _messageTypeface;
        private FormStartPosition _startPosition;
        private InputBoxTextAlignment _textAlignment;
        private InputBoxMessageDisplayType _displayType;
        private InputBoxWrappedMessageTextAlignment _wrappedMessageTextAlignment;

        #endregion

        #region Properties

        public bool ShowInTaskBar
        {
            get => _showInTaskBar;

            set => _showInTaskBar = value;
        }

        public Font ControlTypeface
        {
            get => _controlTypeface;

            set => _controlTypeface = value;
        }

        public Font MessageTypeface
        {
            get => _messageTypeface;

            set => _messageTypeface = value;
        }

        public InputBoxWrappedMessageTextAlignment WrappedMessageTextAlignment
        {
            get => _wrappedMessageTextAlignment;

            set => _wrappedMessageTextAlignment = value;
        }

        public Image Image
        {
            get => _image;

            set => _image = value;
        }

        public InputBoxTextAlignment TextAlignment
        {
            get => _textAlignment;

            set => _textAlignment = value;
        }

        public string[] ListItems
        {
            get => _listItems;

            set => _listItems = value;
        }

        public string OkText
        {
            get => _okText;

            set => _okText = value;
        }

        public string CancelText
        {
            get => _cancelText;

            set => _cancelText = value;
        }

        public string NoText
        {
            get => _noText;

            set => _noText = value;
        }

        public string YesText
        {
            get => _yesText;

            set => _yesText = value;
        }

        public string Title
        {
            get => _title;

            set => _title = value;
        }

        public string Message
        {
            get => _message;

            set => _message = value;
        }

        public string HintText
        {
            get => _hintText;

            set => _hintText = value;
        }

        public Point IconLocation
        {
            get => _iconLocation;

            set => _iconLocation = value;
        }

        public InputBoxIconType IconType
        {
            get => _icon;

            set => _icon = value;
        }

        public InputBoxInputType IconInputType
        {
            get => _type;

            set => _type = value;
        }

        public InputBoxLanguage InputBoxLanguage
        {
            get => _language;

            set => _language = value;
        }

        public InputBoxButtons InputBoxButtons
        {
            get => _buttons;

            set => _buttons = value;
        }

        public FormStartPosition StartPosition
        {
            get => _startPosition;

            set => _startPosition = value;
        }
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="KryptonInputBoxExtendedManager" /> class.</summary>
        /// <param name="iconLocation">The icon location.</param>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="image">The image.</param>
        /// <param name="language">The language.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="type">The type.</param>
        /// <param name="listItems">The list items.</param>
        /// <param name="showInTaskBar">if set to <c>true</c> [show in task bar].</param>
        /// <param name="controlTypeface">The control typeface.</param>
        /// <param name="messageTypeface">The message typeface.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="hintText">The hint text.</param>
        /// <param name="startPosition">The start position.</param>
        /// <param name="textAlignment">The text alignment.</param>
        public KryptonInputBoxExtendedManager(Point iconLocation, string message, string title, InputBoxIconType icon, Image image, InputBoxLanguage language, InputBoxButtons buttons, InputBoxInputType type, string[] listItems, bool showInTaskBar, Font controlTypeface, Font messageTypeface, string okText, string yesText, string noText, string cancelText, string hintText, FormStartPosition startPosition, InputBoxTextAlignment textAlignment)
        {
            _iconLocation = iconLocation;

            _message = message;

            _title = title;

            _icon = icon;

            _image = image;

            _language = language;

            _buttons = buttons;

            _title = title;

            _icon = icon;

            _image = image;

            _language = language;

            _buttons = buttons;

            _type = type;

            _listItems = listItems;

            _showInTaskBar = showInTaskBar;

            _controlTypeface = controlTypeface;

            _messageTypeface = messageTypeface;

            _okText = okText;

            _yesText = yesText;

            _noText = noText;

            _hintText = hintText;

            _cancelText = cancelText;

            _startPosition = startPosition;

            _textAlignment = textAlignment;
        }

        public KryptonInputBoxExtendedManager()
        {

        }
        #endregion

        #region Methods
        public void DisplayInputBox()
        {
            KryptonInputBoxExtended kryptonInputBox = new KryptonInputBoxExtended(_iconLocation, _message, _title, _icon, _image,
                                                                                  _language, _buttons, _type, _listItems,
                                                                                  _showInTaskBar, _controlTypeface, _messageTypeface,
                                                                                  _okText, _yesText, _noText, _cancelText, _hintText,
                                                                                  _startPosition, _textAlignment);

            kryptonInputBox.Show();
        }
        #endregion
    }
}