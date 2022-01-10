#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    public class KryptonToastNotificationVersion1Manager : Component
    {
        #region Variables
        private ActionButtonLocation _buttonLocation;
        private ActionType _actionType;
        private bool _fade, _showActionButton, _showControlBox, _showProgressBar;
        private string _headerText, _contentText, _processName, _actionButtonLaunchProcessText, _actionButtonOpenText;
        private Image _image;
        private int _time, _seconds;
        private float _cornerRadius;
        private System.Windows.Forms.Timer _timer;
        private SoundPlayer _player;
        private IconType _iconType;
        private IToastNotification _toastNotificationOptions;
        private RightToLeftSupport _rightToLeftSupport;
        private InputBoxSystemSounds _systemSounds;
        private PaletteDrawBorders _drawBorders;
        #endregion

        #region Properties       
        public ActionButtonLocation ButtonLocation { get => _buttonLocation; set => _buttonLocation = value; }

        /// <summary>
        /// Gets or sets the type of the action.
        /// </summary>
        /// <value>
        /// The type of the action.
        /// </value>
        public ActionType Action { get => _actionType; set => _actionType = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="KryptonToastWindowVersion1"/> is fade.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fade; otherwise, <c>false</c>.
        /// </value>
        public bool Fade { get => _fade; set => _fade = value; }

        /// <summary>
        /// Gets or sets a value indicating whether [show action button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show action button]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowActionButton { get => _showActionButton; set => _showActionButton = value; }

        public bool ShowControlBox { get => _showControlBox; set => _showControlBox = value; }

        public bool ShowProgressBar { get => _showProgressBar; set => _showProgressBar = value; }

        /// <summary>
        /// Gets or sets the sound path.
        /// </summary>
        /// <value>
        /// The sound path.
        /// </value>
        public string SoundPath { get; set; }

        /// <summary>
        /// Gets or sets the sound stream.
        /// </summary>
        /// <value>
        /// The sound stream.
        /// </value>
        public Stream SoundStream { get; set; }

        /// <summary>
        /// Gets or sets the header text.
        /// </summary>
        /// <value>
        /// The header text.
        /// </value>
        public string HeaderText { get => _headerText; set => _headerText = value; }

        /// <summary>
        /// Gets or sets the content text.
        /// </summary>
        /// <value>
        /// The content text.
        /// </value>
        public string ContentText { get => _contentText; set => _contentText = value; }

        /// <summary>
        /// Gets or sets the name of the process.
        /// </summary>
        /// <value>
        /// The name of the process.
        /// </value>
        public string ProcessName { get => _processName; set => _processName = value; }

        public string ActionButtonLaunchProcessText { get => _actionButtonLaunchProcessText; set => _actionButtonLaunchProcessText = value; }

        public string ActionButtonOpenText { get => _actionButtonOpenText; set => _actionButtonOpenText = value; }

        /// <summary>
        /// Gets or sets the icon image.
        /// </summary>
        /// <value>
        /// The icon image.
        /// </value>
        public Image IconImage { get => _image; set => _image = value; }

        /// <summary>
        /// Gets or sets the seconds.
        /// </summary>
        /// <value>
        /// The seconds.
        /// </value>
        public int Seconds { get => _seconds; set => _seconds = value; }

        public float CornerRadius { get => _cornerRadius; set => _cornerRadius = value; }

        public PaletteDrawBorders PaletteDrawBorders { get => _drawBorders; set => _drawBorders = value; }

        public IconType Type { get => _iconType; set => _iconType = value; }

        public InputBoxSystemSounds InputBoxSystemSound { get => _systemSounds; set => _systemSounds = value; }

        /// <summary>
        /// Gets or sets the right to left support.
        /// </summary>
        /// <value>
        /// The right to left support.
        /// </value>
        public RightToLeftSupport RightToLeft { get => _rightToLeftSupport; set => _rightToLeftSupport = value; }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotificationVersion1Manager" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="showActionButton">if set to <c>true</c> [show action button].</param>
        /// <param name="showProgressBar">if set to <c>true</c> [show progress bar].</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="iconImage">The icon image.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="actionButtonLaunchProcessText">The action button launch process text.</param>
        /// <param name="actionButtonOpenText">The action button open text.</param>
        /// <param name="drawBorders">The draw borders.</param>
        /// <param name="systemSounds">The system sounds.</param>
        public KryptonToastNotificationVersion1Manager(ActionButtonLocation actionButtonLocation, ActionType actionType,
                                                       bool fade, bool showActionButton, bool showProgressBar, bool showControlBox,
                                                       string soundPath, Stream soundStream,
                                                       string headerText, string contentText, string processName,
                                                       IconType iconType, Image iconImage, int seconds, float cornerRadius,
                                                       string actionButtonLaunchProcessText, string actionButtonOpenText,
                                                       PaletteDrawBorders drawBorders, InputBoxSystemSounds systemSounds)
        {
            ButtonLocation = actionButtonLocation;

            Action = actionType;

            Fade = fade;

            ShowActionButton = showActionButton;

            ShowProgressBar = showProgressBar;

            ShowControlBox = showControlBox;

            SoundPath = soundPath;

            SoundStream = soundStream;

            HeaderText = headerText;

            ContentText = contentText;

            ProcessName = processName;

            Type = iconType;

            IconImage = iconImage;

            Seconds = seconds;

            CornerRadius = cornerRadius;

            PaletteDrawBorders = drawBorders;

            InputBoxSystemSound = systemSounds;

            ActionButtonLaunchProcessText = actionButtonLaunchProcessText;

            ActionButtonOpenText = actionButtonOpenText;
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotificationVersion1Manager" /> class.</summary>
        public KryptonToastNotificationVersion1Manager() {}
        #endregion

        #region Methods

        public void DisplayToastNotification()
        {
            KryptonToastWindowVersion1 toast = new KryptonToastWindowVersion1(_fade, _image, _headerText, _contentText,
                                                                              _buttonLocation, _showActionButton, _actionType,
                                                                              _processName, _showProgressBar, _showControlBox,
                                                                              _actionButtonLaunchProcessText, _actionButtonOpenText, 
                                                                              _cornerRadius, _drawBorders,
                                                                              _iconType, _seconds, _systemSounds);

            toast.Show();
        }
        #endregion
    }
}