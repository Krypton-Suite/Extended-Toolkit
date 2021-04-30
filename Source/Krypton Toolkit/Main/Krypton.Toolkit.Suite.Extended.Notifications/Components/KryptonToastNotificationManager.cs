using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    public class KryptonToastNotificationManager : Component
    {
        #region Variables
        private ActionButtonLocation _buttonLocation;
        private ActionType _actionType;
        private bool _fade, _showActionButton, _showSubScript, _showTimeoutProgress;
        private string _headerText, _contentText, _dismissButtonText, _processName;
        private Image _image;
        private int _cornerRadius, _seconds, _timeOutProgress;
        private IconType _iconType;
        private IToastNotification _toastNotificationOptions;
        private RightToLeftSupport _rightToLeftSupport;
        private PaletteDrawBorders _drawBorders;
        #endregion

        #region Properties       
        /// <summary>Gets or sets the aaction button location.</summary>
        /// <value>The action button location.</value>
        public ActionButtonLocation ButtonLocation { get => _buttonLocation; set => _buttonLocation = value; }

        /// <summary>
        /// Gets or sets the type of the action.
        /// </summary>
        /// <value>
        /// The type of the action.
        /// </value>
        public ActionType Action { get => _actionType; set => _actionType = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="KryptonToastNotificationVersion2"/> is fade.
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

        /// <summary>Gets or sets a value indicating whether show the seconds subscript.</summary>
        /// <value><c>true</c> if [show sub script]; otherwise, <c>false</c>.</value>
        public bool ShowSubScript { get => _showSubScript; set => _showSubScript = value; }

        public bool ShowTimeOutProgress { get => _showTimeoutProgress; set => _showTimeoutProgress = value; }

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

        /// <summary>Gets or sets the dismiss button text.</summary>
        /// <value>The dismiss button text.</value>
        public string DismissButtonText { get => _dismissButtonText; set => _dismissButtonText = value; }

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

        /// <summary>Gets or sets the corner radius.</summary>
        /// <value>The corner radius.</value>
        public int CornerRadius { get => _cornerRadius; set => _cornerRadius = value; }

        public int TimeOutProgress { get => _timeOutProgress; set => _timeOutProgress = value; }

        /// <summary>Gets or sets the palette draw borders.</summary>
        /// <value>The palette draw borders.</value>
        public PaletteDrawBorders PaletteDrawBorders { get => _drawBorders; set => _drawBorders = value; }

        /// <summary>Gets or sets the type of the icon.</summary>
        /// <value>The type of the icon.</value>
        public IconType IconType { get => _iconType; set => _iconType = value; }

        /// <summary>Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.</summary>
        public RightToLeftSupport RightToLeft { get => _rightToLeftSupport; set => _rightToLeftSupport = value; }
        #endregion
    }
}