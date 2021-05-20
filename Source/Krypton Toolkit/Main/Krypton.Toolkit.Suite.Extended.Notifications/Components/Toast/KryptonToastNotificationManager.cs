#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    public class KryptonToastNotificationManager : Component
    {
        #region Variables
        private ActionButtonType _actionButtonType;
        private ActionType _actionType;
        private Color _borderColourOne, _borderColourTwo;
        private bool _fade, _showActionButton, _showSubScript, _showTimeoutProgress, _showControlBox;
        private string _headerText, _contentText, _dismissButtonText, _processPath, _actionButtonText, _soundPath;
        private Stream _soundStream;
        private Image _customIconImage;
        private int _cornerRadius, _seconds, _timeOutProgress;
        private IconType _iconType;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the type of the action.
        /// </summary>
        /// <value>
        /// The type of the action.
        /// </value>
        public ActionType Action { get => _actionType; set => _actionType = value; }

        /// <summary>
        /// Gets or sets a value indicating whether [show action button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show action button]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowActionButton { get => _showActionButton; set => _showActionButton = value; }

        /// <summary>Gets or sets a value indicating whether show the seconds subscript.</summary>
        /// <value><c>true</c> if [show sub script]; otherwise, <c>false</c>.</value>
        public bool ShowSubScript { get => _showSubScript; set => _showSubScript = value; }

        /// <summary>Gets or sets the border colour one.</summary>
        /// <value>The border colour one.</value>
        public Color BorderColourOne { get => _borderColourOne; set => _borderColourOne = value; }

        /// <summary>Gets or sets the border colour two.</summary>
        /// <value>The border colour two.</value>
        public Color BorderColourTwo { get => _borderColourTwo; set => _borderColourTwo = value; }

        /// <summary>Gets or sets a value indicating whether [show time out progress].</summary>
        /// <value><c>true</c> if [show time out progress]; otherwise, <c>false</c>.</value>
        public bool ShowTimeOutProgress { get => _showTimeoutProgress; set => _showTimeoutProgress = value; }

        /// <summary>Gets or sets a value indicating whether [show control box].</summary>
        /// <value>
        ///   <c>true</c> if [show control box]; otherwise, <c>false</c>.</value>
        public bool ShowControlBox { get => _showControlBox; set => _showControlBox = value; }

        /// <summary>
        /// Gets or sets the sound path.
        /// </summary>
        /// <value>
        /// The sound path.
        /// </value>
        public string SoundPath { get => _soundPath; set => _soundPath = value; }

        /// <summary>
        /// Gets or sets the sound stream.
        /// </summary>
        /// <value>
        /// The sound stream.
        /// </value>
        public Stream SoundStream { get => _soundStream; set => _soundStream = value; }

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
        public string ContentText { get; set; } //? { get => _contentText; set => _contentText = value; }

        /// <summary>
        /// Gets or sets the name of the process.
        /// </summary>
        /// <value>
        /// The name of the process.
        /// </value>
        public string ProcessPath { get => _processPath; set => _processPath = value; }

        /// <summary>Gets or sets the dismiss button text.</summary>
        /// <value>The dismiss button text.</value>
        public string DismissButtonText { get => _dismissButtonText; set => _dismissButtonText = value; }

        /// <summary>
        /// Gets or sets the icon image.
        /// </summary>
        /// <value>
        /// The icon image.
        /// </value>
        public Image CustomIconImage { get => _customIconImage; set => _customIconImage = value; }

        /// <summary>
        /// Gets or sets the seconds.
        /// </summary>
        /// <value>
        /// The seconds.
        /// </value>
        public int Seconds { get => _seconds; set => _seconds = value; }

        /// <summary>Gets or sets the corner radius.</summary>
        /// <value>The corner radius.</value>
        public int CornerRadius { get => _cornerRadius; set => _cornerRadius = value; }

        public int TimeOutProgress { get => _timeOutProgress; set => _timeOutProgress = value; }

        public string ActionButtonText { get => _actionButtonText; set => _actionButtonText = value; }

        /// <summary>Gets or sets the type of the icon.</summary>
        /// <value>The type of the icon.</value>
        public IconType IconType { get => _iconType; set => _iconType = value; }
        #endregion

        #region Constructor
        public KryptonToastNotificationManager()
        {

        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotificationManager" /> class.</summary>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="showActionButton">if set to <c>true</c> [show action button].</param>
        /// <param name="showSubScript">The show sub script.</param>
        /// <param name="showControlBox">The show control box.</param>
        /// <param name="showTimeOutProgress">The show time out progress.</param>
        /// <param name="borderColourOne">The border colour one.</param>
        /// <param name="borderColourTwo">The border colour two.</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="actionButtonText">The action button text.</param>
        /// <param name="dismissButtonText">The dismiss button text.</param>
        /// <param name="processPath">The process path.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customIconImage">The custom icon image.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="timeOutProgress">The time out progress.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        public KryptonToastNotificationManager(ActionType actionType, bool showActionButton, bool? showSubScript, bool? showControlBox,
                                               bool? showTimeOutProgress, Color? borderColourOne, Color? borderColourTwo,
                                               string soundPath, string contentText, string headerText, string actionButtonText,
                                               string dismissButtonText, string processPath, Stream soundStream, 
                                               Image customIconImage, IconType iconType, int? seconds, int? timeOutProgress, 
                                               int? cornerRadius)
        {
            // Store values
            _actionType = actionType;

            _showActionButton = showActionButton;

            _showSubScript = showSubScript ?? true;

            _showControlBox = showControlBox ?? false;

            _showTimeoutProgress = showTimeOutProgress ?? false;

            _borderColourOne = borderColourOne ?? Color.Empty;

            _borderColourTwo = borderColourTwo ?? Color.Empty;

            _soundPath = soundPath;

            _contentText = contentText;

            _headerText = headerText;

            _actionButtonText = actionButtonText;

            _dismissButtonText = dismissButtonText;

            _processPath = processPath;

            _soundStream = soundStream;

            _customIconImage = customIconImage;

            _iconType = iconType;

            _seconds = seconds ?? 60;

            _timeOutProgress = timeOutProgress ?? 100;

            _cornerRadius = cornerRadius ?? -1;
        }
        #endregion

        #region Methods
        /// <summary>Displays the notification.</summary>
        public void DisplayNotification()
        {
            if (_showTimeoutProgress)
            {
                KryptonToastNotificationVersion2 kryptonToast = new KryptonToastNotificationVersion2(_customIconImage, _headerText, _contentText,
                                                                                                     _borderColourOne, _borderColourTwo,
                                                                                                     _cornerRadius, _actionButtonType,
                                                                                                     _actionType, _showActionButton,
                                                                                                     _actionButtonText, _dismissButtonText,
                                                                                                     _iconType, _timeOutProgress, _soundPath);

                kryptonToast.Show();
            }
            else
            {
                KryptonToastNotificationVersion1 kryptonToast = new KryptonToastNotificationVersion1(_customIconImage, _headerText, _contentText,
                                                                                                     _borderColourOne, _borderColourTwo,
                                                                                                     _cornerRadius, _actionButtonType,
                                                                                                     _actionType, _showActionButton,
                                                                                                     _actionButtonText, _dismissButtonText,
                                                                                                     _iconType, _seconds, _soundPath);

                kryptonToast.Show();
            }
        }
        #endregion
    }
}