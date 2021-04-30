using Krypton.Toolkit.Suite.Extended.Notifications.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    /// <summary>Adapted from: https://github.com/dotCoefficient/Notification/blob/master/Notification/Notification.cs</summary>
    public class KryptonToastNotification : KryptonForm, IToastNotificationUIElements
    {
        #region Design Code
        private KryptonPanel kpnlButtons;
        private KryptonButton kbtnAction;
        private KryptonButton kbtnDismiss;
        private System.Windows.Forms.Panel pnlSplitter;
        private KryptonPanel kpnlContent;
        private KryptonWrapLabel kwlNotificationMessage;
        private KryptonWrapLabel kwlNotificationHeader;
        private ProgressBar pbTimeout;
        private System.Windows.Forms.PictureBox pbxNotificationIcon;

        private void InitializeComponent()
        {
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.kbtnAction = new Krypton.Toolkit.KryptonButton();
            this.kbtnDismiss = new Krypton.Toolkit.KryptonButton();
            this.pnlSplitter = new System.Windows.Forms.Panel();
            this.kpnlContent = new Krypton.Toolkit.KryptonPanel();
            this.kwlNotificationMessage = new Krypton.Toolkit.KryptonWrapLabel();
            this.kwlNotificationHeader = new Krypton.Toolkit.KryptonWrapLabel();
            this.pbxNotificationIcon = new System.Windows.Forms.PictureBox();
            this.pbTimeout = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).BeginInit();
            this.kpnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNotificationIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.kbtnAction);
            this.kpnlButtons.Controls.Add(this.kbtnDismiss);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 303);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kpnlButtons.Size = new System.Drawing.Size(663, 45);
            this.kpnlButtons.TabIndex = 0;
            // 
            // kbtnAction
            // 
            this.kbtnAction.AutoSize = true;
            this.kbtnAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnAction.Location = new System.Drawing.Point(13, 8);
            this.kbtnAction.Name = "kbtnAction";
            this.kbtnAction.Size = new System.Drawing.Size(6, 6);
            this.kbtnAction.TabIndex = 1;
            this.kbtnAction.Values.Text = "";
            this.kbtnAction.Visible = false;
            this.kbtnAction.Click += new System.EventHandler(this.kbtnAction_Click);
            // 
            // kbtnDismiss
            // 
            this.kbtnDismiss.Location = new System.Drawing.Point(480, 8);
            this.kbtnDismiss.Name = "kbtnDismiss";
            this.kbtnDismiss.Size = new System.Drawing.Size(175, 25);
            this.kbtnDismiss.TabIndex = 0;
            this.kbtnDismiss.Values.Text = "{0} ({1})";
            this.kbtnDismiss.Click += new System.EventHandler(this.kbtnDismiss_Click);
            // 
            // pnlSplitter
            // 
            this.pnlSplitter.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlSplitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSplitter.Location = new System.Drawing.Point(0, 300);
            this.pnlSplitter.Name = "pnlSplitter";
            this.pnlSplitter.Size = new System.Drawing.Size(663, 3);
            this.pnlSplitter.TabIndex = 1;
            // 
            // kpnlContent
            // 
            this.kpnlContent.Controls.Add(this.pbTimeout);
            this.kpnlContent.Controls.Add(this.kwlNotificationMessage);
            this.kpnlContent.Controls.Add(this.kwlNotificationHeader);
            this.kpnlContent.Controls.Add(this.pbxNotificationIcon);
            this.kpnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlContent.Location = new System.Drawing.Point(0, 0);
            this.kpnlContent.Name = "kpnlContent";
            this.kpnlContent.Size = new System.Drawing.Size(663, 300);
            this.kpnlContent.TabIndex = 2;
            // 
            // kwlNotificationMessage
            // 
            this.kwlNotificationMessage.AutoSize = false;
            this.kwlNotificationMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kwlNotificationMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlNotificationMessage.Location = new System.Drawing.Point(83, 80);
            this.kwlNotificationMessage.Name = "kwlNotificationMessage";
            this.kwlNotificationMessage.Size = new System.Drawing.Size(572, 203);
            this.kwlNotificationMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kwlNotificationHeader
            // 
            this.kwlNotificationHeader.AutoSize = false;
            this.kwlNotificationHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlNotificationHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlNotificationHeader.Location = new System.Drawing.Point(83, 13);
            this.kwlNotificationHeader.Name = "kwlNotificationHeader";
            this.kwlNotificationHeader.Size = new System.Drawing.Size(572, 63);
            this.kwlNotificationHeader.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlNotificationHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxNotificationIcon
            // 
            this.pbxNotificationIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxNotificationIcon.Location = new System.Drawing.Point(12, 12);
            this.pbxNotificationIcon.Name = "pbxNotificationIcon";
            this.pbxNotificationIcon.Size = new System.Drawing.Size(64, 64);
            this.pbxNotificationIcon.TabIndex = 0;
            this.pbxNotificationIcon.TabStop = false;
            // 
            // pbTimeout
            // 
            this.pbTimeout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbTimeout.Location = new System.Drawing.Point(0, 290);
            this.pbTimeout.Name = "pbTimeout";
            this.pbTimeout.Size = new System.Drawing.Size(663, 10);
            this.pbTimeout.TabIndex = 2;
            this.pbTimeout.Value = 100;
            // 
            // KryptonToastNotification
            // 
            this.ClientSize = new System.Drawing.Size(663, 348);
            this.ControlBox = false;
            this.Controls.Add(this.kpnlContent);
            this.Controls.Add(this.pnlSplitter);
            this.Controls.Add(this.kpnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonToastNotification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.KryptonToastNotification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            this.kpnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).EndInit();
            this.kpnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxNotificationIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private ActionButtonLocation _buttonLocation;
        private ActionType _actionType;
        private bool _fade, _showActionButton, _showSubScript, _showTimeoutProgress;
        private string _headerText, _contentText, _dismissButtonText, _processName;
        private Image _image;
        private int _time, _cornerRadius, _seconds, _timeOutProgress;
        private Timer _timer;
        private SoundPlayer _player;
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
        /// Gets or sets a value indicating whether this <see cref="KryptonToastNotification"/> is fade.
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
        public Image IconImage { get => _image; set { _image = value; Invalidate(); } }

        /// <summary>
        /// Gets or sets the seconds.
        /// </summary>
        /// <value>
        /// The seconds.
        /// </value>
        public int Seconds { get => _seconds; set => _seconds = value; }

        /// <summary>Gets or sets the corner radius.</summary>
        /// <value>The corner radius.</value>
        public int CornerRadius { get => _cornerRadius; set { _cornerRadius = value; Invalidate(); } }

        public int TimeOutProgress { get => _timeOutProgress; set => _timeOutProgress = value; }

        /// <summary>Gets or sets the palette draw borders.</summary>
        /// <value>The palette draw borders.</value>
        public PaletteDrawBorders PaletteDrawBorders { get => _drawBorders; set { _drawBorders = value; Invalidate(); } }

        /// <summary>Gets or sets the type of the icon.</summary>
        /// <value>The type of the icon.</value>
        public IconType IconType { get => _iconType; set => _iconType = value; }

        /// <summary>Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.</summary>
        public RightToLeftSupport RightToLeft { get => _rightToLeftSupport; set { _rightToLeftSupport = value; Invalidate(); } }
        #endregion

        #region Custom Events

        #region Dismiss
        public delegate void DismissEventHandler(EventArgs e);

        public event DismissEventHandler Dismiss;

        protected virtual void OnDismiss(EventArgs e) => Dismiss?.Invoke(e);
        #endregion
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotification" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="icon">The icon.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="dismissButtonText">The dismiss button text.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="showSubScript">If set to <c>true</c> show seconds subscript.</param>
        public KryptonToastNotification(bool fade, Image icon, string headerText, string contentText, string dismissButtonText = "&Dismiss", bool showControlBox = false, bool showSubScript = false)
        {
            InitializeComponent();

            Fade = fade;

            pbxNotificationIcon.Image = icon;

            HeaderText = headerText;

            ContentText = contentText;

            DismissButtonText = dismissButtonText;

            TopMost = true;

            Resize += KryptonToastNotificationWindow_Resize;

            GotFocus += KryptonToastNotificationWindow_GotFocus;

            DoubleBuffered = true;

            ControlBox = showControlBox;

            ShowSubScript = showSubScript;

            //?SetDismissButtonText(dismissButtonText, seconds, showSubScript);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotification" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="dismissButtonText">The dismiss button text.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="showSubScript">If set to <c>true</c> show seconds subscript.</param>
        public KryptonToastNotification(bool fade, IconType iconType, string headerText, string contentText, string dismissButtonText = "&Dismiss", bool showControlBox = false, bool showSubScript = false)
        {
            InitializeComponent();

            Fade = fade;

            IconType = iconType;

            #region Update Icons
            if (iconType == IconType.NONE)
            {
                pbxNotificationIcon.Image = null;

                pbxNotificationIcon.Visible = false;
            }
            else if (iconType == IconType.QUESTION)
            {
                pbxNotificationIcon.Image = BitmapToImage(Resources.Input_Box_Question_64_x_64);
            }
            else if (iconType == IconType.INFORMATION)
            {
                pbxNotificationIcon.Image = BitmapToImage(Resources.Input_Box_Information_64_x_64);
            }
            else if (iconType == IconType.WARNING)
            {
                pbxNotificationIcon.Image = BitmapToImage(Resources.Input_Box_Warning_64_x_58);
            }
            else if (iconType == IconType.ERROR)
            {
                pbxNotificationIcon.Image = BitmapToImage(Resources.Input_Box_Critical_64_x_64);
            }
            else if (iconType == IconType.HAND)
            {
                pbxNotificationIcon.Image = BitmapToImage(Resources.Input_Box_Hand_64_x_64);
            }
            else if (iconType == IconType.STOP)
            {
                pbxNotificationIcon.Image = BitmapToImage(Resources.Input_Box_Stop_64_x_64);
            }
            else if (iconType == IconType.OK)
            {
                pbxNotificationIcon.Image = BitmapToImage(Resources.Input_Box_Ok_64_x_64);
            }
            #endregion

            HeaderText = headerText;

            ContentText = contentText;

            DismissButtonText = dismissButtonText;

            TopMost = true;

            Resize += KryptonToastNotificationWindow_Resize;

            GotFocus += KryptonToastNotificationWindow_GotFocus;

            DoubleBuffered = true;

            ControlBox = showControlBox;

            ShowSubScript = showSubScript;

            //?SetDismissButtonText(dismissButtonText, seconds, showSubScript);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotification" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="dismissButtonText">The dismiss button text.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="showSubScript">If set to <c>true</c> show seconds subscript.</param>
        public KryptonToastNotification(bool fade, Image image, string headerText, string contentText, string dismissButtonText, int seconds, bool showControlBox = false, bool showSubScript = false) : this(fade, image, headerText, contentText, dismissButtonText, showControlBox, showSubScript)
        {
            Seconds = seconds;

            SetDismissButtonText(dismissButtonText, seconds, showSubScript);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotification" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="dismissButtonText">The dismiss button text.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="showSubScript">If set to <c>true</c> show seconds subscript.</param>
        public KryptonToastNotification(bool fade, Image image, string headerText, string contentText, string dismissButtonText, int seconds, string soundPath, bool showControlBox = false, bool showSubScript = false) : this(fade, image, headerText, contentText, dismissButtonText, seconds, showControlBox, showSubScript)
        {
            SoundPath = soundPath;

            SetDismissButtonText(dismissButtonText, seconds, showSubScript);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotification" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="dismissButtonText">The dismiss button text.</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        public KryptonToastNotification(bool fade, Image image, string headerText, string contentText, string dismissButtonText, string soundPath, bool showControlBox = false) : this(fade, image, headerText, contentText, dismissButtonText, showControlBox)
        {
            SoundPath = soundPath;
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotification" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="dismissButtonText">The dismiss button text.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        public KryptonToastNotification(bool fade, Image image, string headerText, string contentText, string dismissButtonText, Stream soundStream, bool showControlBox = false) : this(fade, image, headerText, contentText, dismissButtonText, showControlBox)
        {
            SoundStream = soundStream;
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotification" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="dismissButtonText">The dismiss button text.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="showSubScript">If set to <c>true</c> show seconds subscript.</param>
        public KryptonToastNotification(bool fade, Image image, string headerText, string contentText, string dismissButtonText, int seconds, Stream soundStream, bool showControlBox = false, bool showSubScript = false) : this(fade, image, headerText, contentText, dismissButtonText, seconds, showControlBox, showSubScript)
        {
            SoundStream = soundStream;

            SetDismissButtonText(dismissButtonText, seconds, showSubScript);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotification" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="dismissButtonText">The dismiss button text.</param>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="showActionButton">if set to <c>true</c> [show action button].</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        public KryptonToastNotification(bool fade, Image image, string headerText, string contentText, string dismissButtonText, ActionButtonLocation actionButtonLocation, bool showActionButton, ActionType actionType, string processName, bool showControlBox = false) : this(fade, image, headerText, contentText, dismissButtonText, showControlBox)
        {
            ButtonLocation = actionButtonLocation;

            ShowActionButton = showActionButton;

            Action = actionType;

            ProcessName = processName;

            SetActionText(actionType);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotification" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="dismissButtonText">The dismiss button text.</param>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="showActionButton">if set to <c>true</c> [show action button].</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="cornerRadius">The corner radius.</param>
        public KryptonToastNotification(bool fade, Image image, string headerText, string contentText, string dismissButtonText, ActionButtonLocation actionButtonLocation, bool showActionButton, ActionType actionType, string processName, bool showControlBox = false, int cornerRadius = -1) : this(fade, image, headerText, contentText, dismissButtonText, actionButtonLocation, showActionButton, actionType, processName, showControlBox)
        {
            CornerRadius = cornerRadius;
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotification" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="dismissButtonText">The dismiss button text.</param>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="showActionButton">if set to <c>true</c> [show action button].</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="borders">The borders.</param>
        public KryptonToastNotification(bool fade, Image image, string headerText, string contentText, string dismissButtonText, ActionButtonLocation actionButtonLocation, bool showActionButton, ActionType actionType, string processName, bool showControlBox = false, int cornerRadius = -1, PaletteDrawBorders borders = PaletteDrawBorders.All) : this(fade, image, headerText, contentText, dismissButtonText, actionButtonLocation, showActionButton, actionType, processName, showControlBox)
        {
            PaletteDrawBorders = borders;
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

        /// <summary>
        /// Displays the control to the user.
        /// </summary>
        public new void Show()
        {
            Opacity = 0;

            ReconfigureUI(RightToLeft);

            if (IconType != IconType.NONE)
            {
                UpdateIconType(IconType);
            }
            else
            {
                pbxNotificationIcon.Image = IconImage;
            }

            switch (ButtonLocation)
            {
                case ActionButtonLocation.LEFT:
                    NotificationUtilityMethods.ChangeControlLocation(kbtnAction, new Point(12, 8));
                    break;
                case ActionButtonLocation.RIGHT:
                    NotificationUtilityMethods.ChangeControlLocation(kbtnAction, new Point(318, 8));
                    break;
            }

            kwlNotificationHeader.Text = HeaderText;

            kwlNotificationMessage.Text = ContentText;

            kbtnAction.Visible = ShowActionButton;

            if (Seconds != 0)
            {
                kbtnDismiss.Text = $"Dismiss ({ Seconds - _time }s)";

                _timer = new Timer();

                _timer.Interval = 1000;

                _timer.Tick += (sender, e) =>
                {
                    _time++;

                    while (_timeOutProgress > 0)
                    {
                        _timeOutProgress--;

                        pbTimeout.Value = _timeOutProgress;
                    }

                    if (pbTimeout.Value == 0)
                    {
                        _timer.Stop();

                        FadeOutAndClose();
                    }

                    kbtnDismiss.Text = $"Dismiss ({ Seconds - _time }s)";

                    if (_time == Seconds)
                    {
                        _timer.Stop();

                        FadeOutAndClose();
                    }
                };
            }

            if (SoundPath != null)
            {
                _player = new SoundPlayer(SoundPath);
            }

            if (SoundStream != null)
            {
                _player = new SoundPlayer(SoundStream);
            }

            base.Show();
        }

        /// <summary>Displays the notification.</summary>
        public void DisplayNotification()
        {
            ImplementInterface(ButtonLocation, Action, Fade, ShowActionButton, SoundPath, SoundStream, HeaderText, ContentText, ProcessName, IconImage, Seconds, CornerRadius, PaletteDrawBorders, IconType, RightToLeft);

            // TODO: Complete code
        }

        private void ImplementInterface(ActionButtonLocation buttonLocation, ActionType action, bool fade, bool showActionButton, string soundPath, Stream soundStream, string headerText, string contentText, string processName, Image iconImage, int seconds, int cornerRadius, PaletteDrawBorders paletteDrawBorders, IconType type, RightToLeftSupport rightToLeft)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a value indicating whether the window will be activated when it is shown.
        /// </summary>
        protected override bool ShowWithoutActivation { get => true; }

        /// <summary>
        /// Updates the type of the icon.
        /// </summary>
        /// <param name="iconType">Type of the icon.</param>
        public void UpdateIconType(IconType iconType)
        {
            switch (iconType)
            {
                case IconType.NONE:
                    AdjustLayout(new Size(622, 58), new Size(622, 153), new Point(12, 6), new Point(470, 6), false);
                    break;
                case IconType.QUESTION:
                    pbxNotificationIcon.Image = Resources.Input_Box_Question_64_x_64;

                    SystemSounds.Question.Play();
                    break;
                case IconType.INFORMATION:
                    pbxNotificationIcon.Image = Resources.Input_Box_Information_64_x_64;

                    SystemSounds.Exclamation.Play();
                    break;
                case IconType.WARNING:
                    pbxNotificationIcon.Image = Resources.Input_Box_Warning_64_x_58;

                    SystemSounds.Exclamation.Play();
                    break;
                case IconType.ERROR:
                    pbxNotificationIcon.Image = Resources.Input_Box_Critical_64_x_64;
                    break;
                case IconType.HAND:
                    pbxNotificationIcon.Image = Resources.Input_Box_Hand_64_x_64;
                    break;
                case IconType.STOP:
                    pbxNotificationIcon.Image = Resources.Input_Box_Stop_64_x_64;
                    break;
                case IconType.OK:
                    pbxNotificationIcon.Image = Resources.Input_Box_Ok_64_x_64;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateIconType(IconType);

            ReconfigureUI(RightToLeft);

            StateCommon.Border.Rounding = CornerRadius;

            StateCommon.Border.DrawBorders = PaletteDrawBorders;

            base.OnPaint(e);
        }

        /// <summary>
        /// Bitmaps to image.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns></returns>
        private Image BitmapToImage(Bitmap bitmap)
        {
            Image tmp = new Bitmap(bitmap);

            return tmp;
        }

        /// <summary>
        /// Reconfigures the UI.
        /// </summary>
        /// <param name="rightToLeft">The right to left.</param>
        private void ReconfigureUI(RightToLeftSupport rightToLeft)
        {
            switch (rightToLeft)
            {
                case RightToLeftSupport.LEFTTORIGHT:
                    ConfigureLeftToRight();
                    break;
                case RightToLeftSupport.RIGHTTOLEFT:
                    ConfigureRightToLeft();
                    break;
                default:
                    ReconfigureUI(RightToLeftSupport.LEFTTORIGHT);
                    break;
            }
        }

        /// <summary>
        /// Configures the UI elements to left to right.
        /// </summary>
        private void ConfigureLeftToRight()
        {
            // TODO: Fix this
            //RightToLeft = RightToLeft.;

            pbxNotificationIcon.Location = new Point(12, 12);

            kwlNotificationHeader.Location = new Point(147, 12);

            kwlNotificationMessage.Location = new Point(147, 77);

            //klblContent.RightToLeft = RightToLeft.

            kbtnAction.Location = new Point(12, 6);

            //kbtnAction.RightToLeft = RightToLeft.

            kbtnDismiss.Location = new Point(470, 6);

            //kbtneDismiss.RightToLeft = RightToLeft.No;
        }

        /// <summary>
        /// Configures the UI to right to left.
        /// </summary>
        private void ConfigureRightToLeft()
        {

        }

        /// <summary>
        /// Launches the process.
        /// </summary>
        /// <param name="process">The process.</param>
        public void LaunchProcess(string process)
        {
            Process.Start(process);

            Debug.WriteLine($"[Launching process]: { Path.GetFullPath(process) } at { DateTime.Now.ToString() }");
        }

        /// <summary>
        /// Adjusts the layout.
        /// </summary>
        /// <param name="headerLabelSize">Size of the header label.</param>
        /// <param name="contentLabelSize">Size of the content label.</param>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="dismissButtonLocation">The dismiss button location.</param>
        /// <param name="showIcon">if set to <c>true</c> [show icon].</param>
        private void AdjustLayout(Size headerLabelSize, Size contentLabelSize, Point actionButtonLocation, Point dismissButtonLocation, bool showIcon = true)
        {
            kwlNotificationHeader.Size = headerLabelSize;

            kwlNotificationMessage.Size = contentLabelSize;

            kbtnAction.Location = actionButtonLocation;

            kbtnDismiss.Location = dismissButtonLocation;

            pbxNotificationIcon.Visible = showIcon;
        }

        /*
        // TODO: Revisit
        private void ResetDefaultLayout()
        {
            AdjustLayout(new Size(487, 58), new Size(487, 153), new Point(12, 6), new Point(470, 6));
        }
        */

        /// <summary>
        /// Sets the action text.
        /// </summary>
        /// <param name="type">The type.</param>
        private void SetActionText(ActionType type)
        {
            switch (type)
            {
                case ActionType.LAUCHPROCESS:
                    kbtnAction.Text = $"&Launch Process { Path.GetFileName(ProcessName) }";
                    break;
                case ActionType.OPEN:
                    kbtnAction.Text = "&Open";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Gets the type of the action.
        /// </summary>
        /// <returns></returns>
        private ActionType GetAction() => Action;

        /// <summary>Opens the in explorer.</summary>
        /// <param name="process">The process.</param>
        private void OpenInExplorer(string process) => Process.Start("explorer.exe", process);

        /// <summary>Sets the dismiss button text.</summary>
        /// <param name="buttonText">The button text.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="showSubScript">if set to <c>true</c> [show sub script].</param>
        /// <exception cref="ArgumentNullException"></exception>
        private void SetDismissButtonText(string buttonText, int seconds = 0, bool showSubScript = false)
        {
            if (!string.IsNullOrEmpty(buttonText))
            {
                if (seconds > 0)
                {
                    kbtnDismiss.Text = $"{ buttonText } ({ seconds })";
                }
                else if (seconds > 0 && showSubScript)
                {
                    kbtnDismiss.Text = $"{ buttonText } ({ seconds }s)";
                }
                else
                {
                    kbtnDismiss.Text = $"{ buttonText }";
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        #endregion

        #region Event Handlers
        private void kbtnAction_Click(object sender, EventArgs e)
        {
            if (GetAction() == ActionType.LAUCHPROCESS)
            {
                LaunchProcess(ProcessName);
            }
            else if (GetAction() == ActionType.OPEN)
            {
                OpenInExplorer(ProcessName);
            }
        }

        private void kbtnDismiss_Click(object sender, EventArgs e)
        {
            if (_fade)
            {
                FadeOutAndClose();
            }
            else
            {
                Hide();
            }
        }

        private void KryptonToastNotificationWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void KryptonToastNotificationWindow_GotFocus(object sender, EventArgs e) => kbtnDismiss.Focus();



        private void KryptonToastNotification_Load(object sender, EventArgs e)
        {
            // Bottom left
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 5, Screen.PrimaryScreen.WorkingArea.Height - Height - 5);

            if (Fade)
            {
                FadeIn();
            }

            if (_timer != null)
            {
                _timer.Start();
            }

            if (_player != null)
            {
                _player.Play();
            }
        }
        #endregion

        #region IToastNotificationUIElements Implementation
        public KryptonForm BaseWindow => this;

        public KryptonPanel ContentPanel => kpnlContent;

        public KryptonPanel ButtonPanel => kpnlButtons;

        public KryptonWrapLabel HeaderLabel => kwlNotificationHeader;

        public KryptonWrapLabel ContentLabel => kwlNotificationMessage;

        public KryptonButton ActionButton => kbtnAction;

        public KryptonButton DismissButton => kbtnDismiss;

        public Panel SplitterPanel => pnlSplitter;

        public PictureBox IconBox => pbxNotificationIcon;
        #endregion
    }
}