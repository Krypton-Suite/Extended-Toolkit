using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs.Experimental
{
    /// <summary>
    /// Adapted from: https://github.com/dotCoefficient/Notification/blob/master/Notification/Notification.cs
    /// </summary>
    /// <seealso cref="KryptonForm" />
    public class KryptonToastNotificationWindow : KryptonForm
    {
        #region Design Code
        private System.Windows.Forms.Panel pnlSplitter;
        private KryptonPanel kpnlContent;
        private KryptonButton kbtnDismiss;
        private KryptonButton kbtnAction;
        private System.Windows.Forms.PictureBox pbxIcon;
        private KryptonWrapLabel kwlTitle;
        private KryptonWrapLabel kwlContent;
        private KryptonPanel kpnlButtons;

        private void InitializeComponent()
        {
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.pnlSplitter = new System.Windows.Forms.Panel();
            this.kpnlContent = new Krypton.Toolkit.KryptonPanel();
            this.kbtnAction = new Krypton.Toolkit.KryptonButton();
            this.kbtnDismiss = new Krypton.Toolkit.KryptonButton();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            this.kwlTitle = new Krypton.Toolkit.KryptonWrapLabel();
            this.kwlContent = new Krypton.Toolkit.KryptonWrapLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).BeginInit();
            this.kpnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.kbtnDismiss);
            this.kpnlButtons.Controls.Add(this.kbtnAction);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 255);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.Size = new System.Drawing.Size(609, 38);
            this.kpnlButtons.TabIndex = 0;
            // 
            // pnlSplitter
            // 
            this.pnlSplitter.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlSplitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSplitter.Location = new System.Drawing.Point(0, 252);
            this.pnlSplitter.Name = "pnlSplitter";
            this.pnlSplitter.Size = new System.Drawing.Size(609, 3);
            this.pnlSplitter.TabIndex = 0;
            // 
            // kpnlContent
            // 
            this.kpnlContent.Controls.Add(this.kwlContent);
            this.kpnlContent.Controls.Add(this.kwlTitle);
            this.kpnlContent.Controls.Add(this.pbxIcon);
            this.kpnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlContent.Location = new System.Drawing.Point(0, 0);
            this.kpnlContent.Name = "kpnlContent";
            this.kpnlContent.Size = new System.Drawing.Size(609, 252);
            this.kpnlContent.TabIndex = 1;
            // 
            // kbtnAction
            // 
            this.kbtnAction.AutoSize = true;
            this.kbtnAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnAction.Location = new System.Drawing.Point(13, 7);
            this.kbtnAction.Name = "kbtnAction";
            this.kbtnAction.Size = new System.Drawing.Size(25, 24);
            this.kbtnAction.TabIndex = 0;
            this.kbtnAction.Values.Text = "{0}";
            this.kbtnAction.Visible = false;
            // 
            // kbtnDismiss
            // 
            this.kbtnDismiss.Location = new System.Drawing.Point(456, 7);
            this.kbtnDismiss.Name = "kbtnDismiss";
            this.kbtnDismiss.Size = new System.Drawing.Size(141, 25);
            this.kbtnDismiss.TabIndex = 1;
            this.kbtnDismiss.Values.Text = "Dismiss ({0}s)";
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcon.Location = new System.Drawing.Point(12, 12);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(64, 64);
            this.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxIcon.TabIndex = 4;
            this.pbxIcon.TabStop = false;
            // 
            // kwlTitle
            // 
            this.kwlTitle.AutoSize = false;
            this.kwlTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlTitle.Location = new System.Drawing.Point(86, 12);
            this.kwlTitle.Name = "kwlTitle";
            this.kwlTitle.Size = new System.Drawing.Size(511, 64);
            this.kwlTitle.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlTitle.Text = "<##HEADER-TITLE##>";
            this.kwlTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kwlContent
            // 
            this.kwlContent.AutoSize = false;
            this.kwlContent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kwlContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlContent.Location = new System.Drawing.Point(86, 76);
            this.kwlContent.Name = "kwlContent";
            this.kwlContent.Size = new System.Drawing.Size(511, 156);
            this.kwlContent.Text = "<##CONTENT##>";
            this.kwlContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KryptonToastNotificationWindow
            // 
            this.ClientSize = new System.Drawing.Size(609, 293);
            this.Controls.Add(this.kpnlContent);
            this.Controls.Add(this.pnlSplitter);
            this.Controls.Add(this.kpnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonToastNotificationWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            this.kpnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).EndInit();
            this.kpnlContent.ResumeLayout(false);
            this.kpnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private ActionButtonLocation _buttonLocation;
        private ActionType _actionType;
        private bool _fade, _showActionButton;
        private ContentAlignment _headerTextAlignment, _contentTextAlignment;
        private string _headerText, _contentText, _dismissText, _processName;
        private Image _customIconImage;
        private int _time, _cornerRadius, _seconds;
        private Timer _timer;
        private SoundPlayer _player;
        private IconType _iconType;
        private IToastNotification _toastNotificationOptions;
        private RightToLeftSupport _rightToLeftSupport;
        private PaletteDrawBorders _drawBorders;
        #endregion

        #region Properties       
        /// <summary>Gets or sets the action button location.</summary>
        /// <value>The button location.</value>
        public ActionButtonLocation ButtonLocation { get => _buttonLocation; set => _buttonLocation = value; }

        /// <summary>
        /// Gets or sets the type of the action.
        /// </summary>
        /// <value>
        /// The type of the action.
        /// </value>
        public ActionType Action { get => _actionType; set => _actionType = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="KryptonToastNotificationWindow"/> is fade.
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

        /// <summary>Gets or sets the content text alignment.</summary>
        /// <value>The content text alignment.</value>
        public ContentAlignment ContentTextAlignment { get => _contentTextAlignment; set => _contentTextAlignment = value; }

        /// <summary>Gets or sets the header text alignment.</summary>
        /// <value>The header text alignment.</value>
        public ContentAlignment HeaderTextAlignment { get => _headerTextAlignment; set => _headerTextAlignment = value; }

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

        /// <summary>Gets or sets the dismiss text.</summary>
        /// <value>The dismiss text.</value>
        public string DismissText { get => _dismissText; set => _dismissText = value; }

        /// <summary>
        /// Gets or sets the icon image.
        /// </summary>
        /// <value>
        /// The icon image.
        /// </value>
        public Image CustomIconImage { get => _customIconImage; set { _customIconImage = value; Invalidate(); } }

        /// <summary>Gets or sets the seconds.</summary>
        /// <value>The seconds.</value>
        public int Seconds { get => _seconds; set => _seconds = value; }

        /// <summary>Gets or sets the corner radius.</summary>
        /// <value>The corner radius.</value>
        public int CornerRadius { get => _cornerRadius; set { _cornerRadius = value; Invalidate(); } }

        /// <summary>Gets or sets the palette draw borders.</summary>
        /// <value>The palette draw borders.</value>
        public PaletteDrawBorders PaletteDrawBorders { get => _drawBorders; set { _drawBorders = value; Invalidate(); } }

        /// <summary>Gets or sets the type of the icon.</summary>
        /// <value>The type of the icon.</value>
        public IconType IconType { get => _iconType; set => _iconType = value; }

        public RightToLeftSupport RightToLeft { get => _rightToLeftSupport; set { _rightToLeftSupport = value; Invalidate(); } }
        #endregion

        #region Constants
        private const int DEFAULT_Y_AXIS_LOCATION = 7;
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotificationWindow" /> class.</summary>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="windowTitleText">The text on the window title bar.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="showActionButton">if set to <c>true</c> [show action button].</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="contentTextAlignment">The content text alignment.</param>
        /// <param name="headerTextAlignment">The header text alignment.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="customIconImage">The custom icon image.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="drawBorders">The draw borders.</param>
        /// <param name="actionButtonLocation">The location of the action button.</param>
        /// <param name="dismissButtonLocation">The location of the dismiss button.</param>
        /// <param name="showControlBox">Shows the control box (Minimise, Maximise & Close).</param>
        public KryptonToastNotificationWindow(string headerText, string contentText, string windowTitleText, IconType iconType, bool fade, ActionType actionType,
                                              bool showActionButton, string soundPath, Stream soundStream, ContentAlignment contentTextAlignment,
                                              ContentAlignment headerTextAlignment, string processName, string dismissText, Image customIconImage,
                                              int seconds, int cornerRadius, PaletteDrawBorders drawBorders, Point actionButtonLocation,
                                              Point dismissButtonLocation, bool showControlBox)
        {
            InitializeComponent();

            #region Store Values
            HeaderText = headerText;

            ContentText = contentText;

            IconType = iconType;

            Fade = fade;

            Action = actionType;

            ShowActionButton = showActionButton;

            SoundPath = soundPath;

            SoundStream = soundStream;

            ContentTextAlignment = contentTextAlignment;

            HeaderTextAlignment = headerTextAlignment;

            ProcessName = processName;

            DismissText = dismissText;

            CustomIconImage = customIconImage;

            Seconds = seconds;

            CornerRadius = cornerRadius;

            PaletteDrawBorders = drawBorders;
            #endregion

            Text = windowTitleText;

            kbtnAction.Location = actionButtonLocation;

            kbtnDismiss.Location = dismissButtonLocation;

            TopMost = true;

            DoubleBuffered = true;

            ControlBox = showControlBox;
        }
        #endregion

        #region Internal Method
        /// <summary>Internals the show.</summary>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="windowTitleText">The window title text.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="showActionButton">if set to <c>true</c> [show action button].</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="contentTextAlignment">The content text alignment.</param>
        /// <param name="headerTextAlignment">The header text alignment.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="customIconImage">The custom icon image.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="drawBorders">The draw borders.</param>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="dismissButtonLocation">The dismiss button location.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <returns></returns>
        private static DialogResult InternalShow(string headerText, string contentText, string windowTitleText, IconType iconType, bool fade, ActionType actionType,
                                              bool showActionButton, string soundPath, Stream soundStream, ContentAlignment contentTextAlignment,
                                              ContentAlignment headerTextAlignment, string processName, string dismissText, Image customIconImage,
                                              int seconds, int cornerRadius, PaletteDrawBorders drawBorders, Point actionButtonLocation,
                                              Point dismissButtonLocation, bool showControlBox)
        {
            using (KryptonToastNotificationWindow ktnw = new KryptonToastNotificationWindow(headerText, contentText, windowTitleText, iconType, fade, actionType, showActionButton, soundPath, soundStream, contentTextAlignment, headerTextAlignment, processName, dismissText, customIconImage, seconds, cornerRadius, drawBorders, actionButtonLocation, dismissButtonLocation, showControlBox))
            {
                ktnw.Show();

                return DialogResult.None;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Fades the window in.
        /// </summary>
        private void FadeIn()
        {
            Timer fadeTimer = new Timer();

            fadeTimer.Interval = 10;

            fadeTimer.Tick += (sender, e) =>
            {
                if (Opacity == 1d)
                {
                    fadeTimer.Stop();
                }

                Opacity += 0.02d;
            };

            fadeTimer.Start();
        }

        /// <summary>
        /// Fades the window out and close.
        /// </summary>
        private void FadeOutAndClose()
        {
            Timer fadeTimer = new Timer();

            fadeTimer.Interval = 10;

            fadeTimer.Tick += (sender, e) =>
            {
                if (Opacity == 0d)
                {
                    fadeTimer.Stop();

                    Close();
                }

                Opacity -= 0.02d;
            };

            fadeTimer.Start();
        }

        public new void Show()
        {
            Opacity = 0;

            if (IconType != IconType.NONE)
            {
                pbxIcon.Visible = true;

                UpdateIconType(IconType);
            }
            else if (IconType == IconType.CUSTOM)
            {
                pbxIcon.Visible = true;

                pbxIcon.Image = GetIconImage(IconType.CUSTOM, CustomIconImage);
            }
            else
            {
                pbxIcon.Visible = false;
            }
        }

        private Image GetIconImage(IconType type, Image customIconImage)
        {
            if (type == IconType.CUSTOM)
            {
                return customIconImage;
            }
            else
            {
                return null;
            }
        }

        private void UpdateIconType(IconType type, Image customIconImage = null)
        {
            switch (type)
            {
                case IconType.CUSTOM:
                    break;
                case IconType.OK:
                    break;
                case IconType.ERROR:
                    break;
                case IconType.EXCLAMATION:
                    break;
                case IconType.INFORMATION:
                    break;
                case IconType.QUESTION:
                    break;
                case IconType.NOTHING:
                    break;
                case IconType.NONE:
                    break;
                case IconType.STOP:
                    break;
                case IconType.HAND:
                    break;
                case IconType.WARNING:
                    break;
            }
        }

        private Point PollActionButtonLocation() => kbtnAction.Location;

        private Point PollDismissButtonLocation() => kbtnDismiss.Location;
        #endregion
    }
}