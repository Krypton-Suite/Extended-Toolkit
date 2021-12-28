#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    public class KryptonToastNotificationVersion2Manager : Component
    {
        #region Variables
        private bool _fade;
        private string _headerText, _contentText, _processName;
        private Image _image;
        private int _time;
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
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="KryptonToastWindowVersion2"/> is fade.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fade; otherwise, <c>false</c>.
        /// </value>
        public bool Fade { get => _fade; set => _fade = value; }

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
        public int Seconds { get; set; }

        public float CornerRadius { get => _cornerRadius; set => _cornerRadius = value; }

        public PaletteDrawBorders PaletteDrawBorders { get => _drawBorders; set => _drawBorders = value; }

        public IconType Type { get => _iconType; set => _iconType = value; }

        public InputBoxSystemSounds InputBoxSystemSound { get => _systemSounds; set => _systemSounds = value; }
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotificationVersion2Manager" /> class.</summary>
        public KryptonToastNotificationVersion2Manager()
        {
            
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotificationVersion2Manager" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="customIcon">The custom icon.</param>
        /// <param name="sound">The sound.</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="drawBorders">The draw borders.</param>
        public KryptonToastNotificationVersion2Manager(bool fade, string contentText, string headerText,
                                                       IconType iconType, Image customIcon, InputBoxSystemSounds sound,
                                                       string soundPath, Stream soundStream, int seconds, float cornerRadius,
                                                       PaletteDrawBorders drawBorders)
        {
            Fade = fade;

            ContentText = contentText;

            HeaderText = headerText;

            Type = iconType;

            IconImage = customIcon;

            InputBoxSystemSound = sound;

            SoundPath = soundPath;

            SoundStream = soundStream;

            Seconds = seconds;

            CornerRadius = cornerRadius;

            PaletteDrawBorders = drawBorders;
        }
        #endregion

        #region Methods

        /// <summary>Displays the notification.</summary>
        public void DisplayNotification()
        {
            KryptonToastWindowVersion2 toast = new KryptonToastWindowVersion2(_fade, _contentText, _headerText,
                                                                              _iconType, _image, _systemSounds, SoundPath, SoundStream,
                                                                              Seconds, _cornerRadius, _drawBorders);

            toast.Show();
        }
        #endregion
    }
}