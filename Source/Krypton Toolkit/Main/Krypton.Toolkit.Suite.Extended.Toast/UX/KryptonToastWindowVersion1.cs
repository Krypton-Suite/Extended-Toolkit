#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    public class KryptonToastWindowVersion1 : KryptonForm, IToastNotificationUIElements
    {
        #region Design Code
        private KryptonPanel kpnlButtons;
        private KryptonButton kbtnDismiss;
        private KryptonPanel kpnlContent;
        private KryptonLabel klblHeader;
        private KryptonWrapLabel kwlContent;
        private PictureBox pbxIcon;
        private KryptonButton kbtnAction;
        private ProgressBar pbTickDown;
        private KryptonBorderEdge kryptonBorderEdge1;

        private void InitializeComponent()
        {
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.kbtnAction = new Krypton.Toolkit.KryptonButton();
            this.kbtnDismiss = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kpnlContent = new Krypton.Toolkit.KryptonPanel();
            this.klblHeader = new Krypton.Toolkit.KryptonLabel();
            this.kwlContent = new Krypton.Toolkit.KryptonWrapLabel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            this.pbTickDown = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).BeginInit();
            this.kpnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.kbtnAction);
            this.kpnlButtons.Controls.Add(this.kbtnDismiss);
            this.kpnlButtons.Controls.Add(this.kryptonBorderEdge1);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 243);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kpnlButtons.Size = new System.Drawing.Size(609, 50);
            this.kpnlButtons.TabIndex = 1;
            // 
            // kbtnAction
            // 
            this.kbtnAction.AutoSize = true;
            this.kbtnAction.Location = new System.Drawing.Point(12, 13);
            this.kbtnAction.Name = "kbtnAction";
            this.kbtnAction.Size = new System.Drawing.Size(153, 25);
            this.kbtnAction.TabIndex = 3;
            this.kbtnAction.Values.Text = "";
            this.kbtnAction.Visible = false;
            this.kbtnAction.Click += new System.EventHandler(this.kbtnAction_Click);
            // 
            // kbtnDismiss
            // 
            this.kbtnDismiss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnDismiss.Location = new System.Drawing.Point(393, 13);
            this.kbtnDismiss.Name = "kbtnDismiss";
            this.kbtnDismiss.Size = new System.Drawing.Size(204, 25);
            this.kbtnDismiss.TabIndex = 1;
            this.kbtnDismiss.Values.Text = "{0} ({1})";
            this.kbtnDismiss.Click += new System.EventHandler(this.kbtnDismiss_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(609, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kpnlContent
            // 
            this.kpnlContent.Controls.Add(this.klblHeader);
            this.kpnlContent.Controls.Add(this.kwlContent);
            this.kpnlContent.Controls.Add(this.pbxIcon);
            this.kpnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlContent.Location = new System.Drawing.Point(0, 0);
            this.kpnlContent.Name = "kpnlContent";
            this.kpnlContent.Size = new System.Drawing.Size(609, 243);
            this.kpnlContent.TabIndex = 2;
            // 
            // klblHeader
            // 
            this.klblHeader.AutoSize = false;
            this.klblHeader.Location = new System.Drawing.Point(145, 13);
            this.klblHeader.Name = "klblHeader";
            this.klblHeader.Size = new System.Drawing.Size(452, 67);
            this.klblHeader.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHeader.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblHeader.TabIndex = 2;
            this.klblHeader.Values.Text = "{0}";
            // 
            // kwlContent
            // 
            this.kwlContent.AutoSize = false;
            this.kwlContent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kwlContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlContent.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlContent.Location = new System.Drawing.Point(145, 83);
            this.kwlContent.Name = "kwlContent";
            this.kwlContent.Size = new System.Drawing.Size(452, 146);
            this.kwlContent.Text = "{0}";
            this.kwlContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcon.Location = new System.Drawing.Point(13, 13);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(128, 128);
            this.pbxIcon.TabIndex = 0;
            this.pbxIcon.TabStop = false;
            // 
            // pbTickDown
            // 
            this.pbTickDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbTickDown.Location = new System.Drawing.Point(0, 238);
            this.pbTickDown.Name = "pbTickDown";
            this.pbTickDown.Size = new System.Drawing.Size(609, 5);
            this.pbTickDown.TabIndex = 3;
            // 
            // KryptonToastWindowVersion1
            // 
            this.ClientSize = new System.Drawing.Size(609, 293);
            this.Controls.Add(this.pbTickDown);
            this.Controls.Add(this.kpnlContent);
            this.Controls.Add(this.kpnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonToastWindowVersion1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.KryptonToastWindowVersion1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            this.kpnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).EndInit();
            this.kpnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private ActionButtonLocation _buttonLocation;
        private ActionType _actionType;
        private bool _fade, _showActionButton, _showProgressBar;
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

        public bool ShowProgressBar {  get => _showProgressBar; set => _showProgressBar = value; }

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

        public string ActionButtonLaunchProcessText {  get => _actionButtonLaunchProcessText; set => _actionButtonLaunchProcessText = value; }

        public string ActionButtonOpenText {  get => _actionButtonOpenText; set => _actionButtonOpenText = value; }

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
        public int Seconds { get =>  _seconds; set => _seconds = value; }

        public float CornerRadius { get => _cornerRadius; set { _cornerRadius = value; Invalidate(); } }

        public PaletteDrawBorders PaletteDrawBorders { get => _drawBorders; set { _drawBorders = value; Invalidate(); } }

        public IconType Type { get => _iconType; set => _iconType = value; }

        public InputBoxSystemSounds InputBoxSystemSound { get => _systemSounds; set => _systemSounds = value; }

        /// <summary>
        /// Gets or sets the right to left support.
        /// </summary>
        /// <value>
        /// The right to left support.
        /// </value>
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
        /// <summary>Initializes a new instance of the <see cref="KryptonToastWindowVersion1" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="icon">The icon.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="showProgressBar">if set to <c>true</c> [show progress bar].</param>
        public KryptonToastWindowVersion1(bool fade, Image icon, string headerText, string contentText,  bool showControlBox = true,  bool showProgressBar = false)
        {
            InitializeComponent();

            Fade = fade;

            pbxIcon.Image = icon;

            HeaderText = headerText;

            ContentText = contentText;

            TopMost = true;

            Resize += KryptonToastWindowVersion1_Resize;

            GotFocus += KryptonToastWindowVersion1_GotFocus;

            DoubleBuffered = true;

            pbTickDown.Visible = showProgressBar;

            ControlBox = showControlBox;
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastWindowVersion1" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="showProgressBar">if set to <c>true</c> [show progress bar].</param>
        public KryptonToastWindowVersion1(bool fade, IconType iconType, string headerText, string contentText,
                                          bool showControlBox = true, bool showProgressBar = false)
        {
            InitializeComponent();

            Fade = fade;

            Type = iconType;

            #region Update Icons
            if (iconType == IconType.NONE)
            {
                pbxIcon.Image = null;

                pbxIcon.Visible = false;
            }
            else if (iconType == IconType.QUESTION)
            {
                pbxIcon.Image = BitmapToImage(Resources.Input_Box_Question_64_x_64);
            }
            else if (iconType == IconType.INFORMATION)
            {
                pbxIcon.Image = BitmapToImage(Resources.Input_Box_Information_64_x_64);
            }
            else if (iconType == IconType.WARNING)
            {
                pbxIcon.Image = BitmapToImage(Resources.Input_Box_Warning_64_x_58);
            }
            else if (iconType == IconType.ERROR)
            {
                pbxIcon.Image = BitmapToImage(Resources.Input_Box_Critical_64_x_64);
            }
            else if (iconType == IconType.HAND)
            {
                pbxIcon.Image = BitmapToImage(Resources.Input_Box_Hand_64_x_64);
            }
            else if (iconType == IconType.STOP)
            {
                pbxIcon.Image = BitmapToImage(Resources.Input_Box_Stop_64_x_64);
            }
            else if (iconType == IconType.OK)
            {
                pbxIcon.Image = BitmapToImage(Resources.Input_Box_Ok_64_x_64);
            }
            #endregion

            HeaderText = headerText;

            ContentText = contentText;

            TopMost = true;

            Resize += KryptonToastWindowVersion1_Resize;

            GotFocus += KryptonToastWindowVersion1_GotFocus;

            DoubleBuffered = true;

            pbTickDown.Visible = showProgressBar;

            ControlBox = showControlBox;
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastWindowVersion1" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="showProgressBar">if set to <c>true</c> [show progress bar].</param>
        public KryptonToastWindowVersion1(bool fade, Image image, string headerText, string contentText, int seconds, bool showControlBox = true,
                                          bool showProgressBar = false) : this(fade, image, headerText, contentText, showControlBox,  showProgressBar)
        {
            Seconds = seconds;
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastWindowVersion1" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="showProgressBar">if set to <c>true</c> [show progress bar].</param>
        public KryptonToastWindowVersion1(bool fade, Image image, string headerText, string contentText, int seconds, 
                                          string soundPath,  bool showControlBox = true,  bool showProgressBar = false) :
                                          this(fade, image, headerText, contentText, seconds, showControlBox,  showProgressBar)
        {
            SoundPath = soundPath;
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastWindowVersion1" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="showProgressBar">if set to <c>true</c> [show progress bar].</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        public KryptonToastWindowVersion1(bool fade, Image image, string headerText, string contentText, string soundPath, bool showProgressBar = true,
                                          bool showControlBox = true) : this(fade, image, headerText, contentText, showControlBox,  showProgressBar)
        {
            SoundPath = soundPath;
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastWindowVersion1" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="showProgressBar">if set to <c>true</c> [show progress bar].</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        public KryptonToastWindowVersion1(bool fade, Image image, string headerText, string contentText, Stream soundStream, bool showProgressBar = true, 
                                          bool showControlBox = true) : this(fade, image, headerText, contentText, showControlBox,  showProgressBar)
        {
            SoundStream = soundStream;
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastWindowVersion1" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="showProgressBar">if set to <c>true</c> [show progress bar].</param>
        public KryptonToastWindowVersion1(bool fade, Image image, string headerText, string contentText, int seconds, 
                                          Stream soundStream,  bool showControlBox = true,  bool showProgressBar = false) : 
                                          this(fade, image, headerText, contentText, seconds, showControlBox,  showProgressBar)
        {
            SoundStream = soundStream;
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastWindowVersion1" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="showActionButton">if set to <c>true</c> [show action button].</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="showProgressBar">if set to <c>true</c> [show progress bar].</param>
        /// <param name="actionButtonLaunchProcessText">The action button launch process text.</param>
        /// <param name="actionButtonOpenText">The action button open text.</param>
        public KryptonToastWindowVersion1(bool fade, Image image, string headerText, string contentText, 
                                          ActionButtonLocation actionButtonLocation, bool showActionButton, ActionType actionType, 
                                          string processName,  bool showControlBox = true,  bool showProgressBar = false, 
                                          string actionButtonLaunchProcessText = "&Launch Process", string actionButtonOpenText = "&Open") : 
                                          this(fade, image, headerText, contentText, showControlBox,  showProgressBar)
        {
            ButtonLocation = actionButtonLocation;

            ShowActionButton = showActionButton;

            Action = actionType;

            ProcessName = processName;

            ActionButtonLaunchProcessText = actionButtonLaunchProcessText;

            ActionButtonOpenText = actionButtonOpenText;

            SetActionText(actionType, actionButtonLaunchProcessText, actionButtonOpenText);
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastWindowVersion1" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="showActionButton">if set to <c>true</c> [show action button].</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="showProgressBar">if set to <c>true</c> [show progress bar].</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="actionButtonLaunchProcessText">The action button launch process text.</param>
        /// <param name="actionButtonOpenText">The action button open text.</param>
        public KryptonToastWindowVersion1(bool fade, Image image, string headerText, string contentText, 
                                          ActionButtonLocation actionButtonLocation, bool showActionButton, 
                                          ActionType actionType, string processName,  bool showControlBox = true,  bool showProgressBar = false, 
                                          float cornerRadius = -1, string actionButtonLaunchProcessText = "&Launch Process", string actionButtonOpenText = "&Open") : 
                                          this(fade, image, headerText, contentText, actionButtonLocation, showActionButton, actionType, processName, showControlBox,  showProgressBar, actionButtonLaunchProcessText, actionButtonOpenText)
        {
            CornerRadius = cornerRadius;
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastWindowVersion1" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="showActionButton">if set to <c>true</c> [show action button].</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="showProgressBar">if set to <c>true</c> [show progress bar].</param>
        /// <param name="actionButtonLaunchProcessText">The action button launch process text.</param>
        /// <param name="actionButtonOpenText">The action button open text.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="borders">The borders.</param>
        public KryptonToastWindowVersion1(bool fade, Image image, string headerText, string contentText, 
                                          ActionButtonLocation actionButtonLocation, bool showActionButton,
                                          ActionType actionType, string processName,  bool showControlBox = true,  bool showProgressBar = false,
                                          string actionButtonLaunchProcessText = "&Launch Process", string actionButtonOpenText = "&Open",
                                          float cornerRadius = -1, PaletteDrawBorders borders = PaletteDrawBorders.All) : 
                                          this(fade, image, headerText, contentText, actionButtonLocation, showActionButton, actionType, processName, showControlBox,  showProgressBar, actionButtonLaunchProcessText, actionButtonOpenText)
        {
            CornerRadius = cornerRadius;

            PaletteDrawBorders = borders;
        }

        /// <summary>Initializes a new instance of the <see cref="KryptonToastWindowVersion1" /> class.</summary>
        /// <param name="fade">if set to <c>true</c> [fade].</param>
        /// <param name="image">The image.</param>
        /// <param name="headerText">The header text.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="showActionButton">if set to <c>true</c> [show action button].</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="showProgressBar">if set to <c>true</c> [show progress bar].</param>
        /// <param name="showControlBox">if set to <c>true</c> [show control box].</param>
        /// <param name="actionButtonLaunchProcessText">The action button launch process text.</param>
        /// <param name="actionButtonOpenText">The action button open text.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="borders">The borders.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="systemSound">The system sound.</param>
        public KryptonToastWindowVersion1(bool fade, Image image, string headerText, string contentText, 
                                          ActionButtonLocation actionButtonLocation, bool showActionButton, 
                                          ActionType actionType, string processName, bool showProgressBar = true,
                                          bool showControlBox = true, string actionButtonLaunchProcessText = "&Launch Process", string actionButtonOpenText = "&Open",
                                          float cornerRadius = -1, PaletteDrawBorders borders = PaletteDrawBorders.All, 
                                          IconType iconType = default, int seconds = 0, InputBoxSystemSounds systemSound = InputBoxSystemSounds.BEEP) :
                                          this(fade, image, headerText, contentText, actionButtonLocation, showActionButton, actionType, processName, showControlBox,  showProgressBar, actionButtonLaunchProcessText, actionButtonOpenText, cornerRadius, borders)
        {
            Type = iconType;

            Seconds = seconds;

            InputBoxSystemSound = systemSound;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Fades the window in.
        /// </summary>
        private void FadeIn()
        {
            System.Windows.Forms.Timer fadeTimer = new System.Windows.Forms.Timer();

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
            System.Windows.Forms.Timer fadeTimer = new System.Windows.Forms.Timer();

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

            if (Type != IconType.NONE)
            {
                UpdateIconType(Type, InputBoxSystemSound);
            }
            else
            {
                pbxIcon.Image = IconImage;
            }

            //switch (ButtonLocation)
            //{
            //    case ActionButtonLocation.LEFT:
            //        UtilityMethods.ChangeControlLocation(kbtnAction, new Point(12, 16));
            //        break;
            //    case ActionButtonLocation.RIGHT:
            //        UtilityMethods.ChangeControlLocation(kbtnAction, new Point(318, 16));
            //        break;
            //}

            klblHeader.Text = HeaderText;

            kwlContent.Text = ContentText;

            kbtnAction.Visible = ShowActionButton;

            if (Seconds != 0)
            {
                kbtnDismiss.Text = $"Dismiss ({ Seconds - _time }s)";

                _timer = new System.Windows.Forms.Timer();

                _timer.Interval = 1000;

                _timer.Tick += (sender, e) =>
                {
                    _time++;

                    kbtnDismiss.Text = $"Dismiss ({ Seconds - _time }s)";

                    if (_showProgressBar)
                    {
                        pbTickDown.Value = Seconds = _time;

                        if (pbTickDown.Value == pbTickDown.Maximum)
                        {
                            _timer.Stop();

                            FadeOutAndClose();
                        }
                    }

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

        /// <summary>
        /// Gets a value indicating whether the window will be activated when it is shown.
        /// </summary>
        protected override bool ShowWithoutActivation { get => true; }


        /// <summary>Updates the type of the icon.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="systemSound">The system sound to play.</param>
        /// <param name="customSoundStream">The custom sound stream.</param>
        /// <param name="customSoundLocation">The custom sound location.</param>
        private void UpdateIconType(IconType iconType, InputBoxSystemSounds systemSound = InputBoxSystemSounds.NONE, Stream customSoundStream = null, string customSoundLocation = null)
        {
            switch (iconType)
            {
                case IconType.NONE:
                    AdjustLayout(new Size(622, 58), new Size(622, 153), new Point(13, 16), new Point(393, 13), false);

                    if (systemSound != InputBoxSystemSounds.NONE)
                    {
                        if (customSoundStream != null)
                        {
                            PlaySound(InputBoxSystemSounds.CUSTOM, customSoundStream);
                        }
                        else if (customSoundLocation != null)
                        {
                            PlaySound(InputBoxSystemSounds.CUSTOM, null, customSoundLocation);
                        }
                        else
                        {
                            PlaySound(systemSound);
                        }
                    }
                    break;
                case IconType.QUESTION:
                    pbxIcon.Image = Resources.Input_Box_Question_64_x_64;

                    if (systemSound != InputBoxSystemSounds.NONE)
                    {
                        if (customSoundStream != null)
                        {
                            PlaySound(InputBoxSystemSounds.CUSTOM, customSoundStream);
                        }
                        else if (customSoundLocation != null)
                        {
                            PlaySound(InputBoxSystemSounds.CUSTOM, null, customSoundLocation);
                        }
                        else
                        {
                            PlaySound(InputBoxSystemSounds.QUESTION);
                        }
                    }
                    break;
                case IconType.INFORMATION:
                    pbxIcon.Image = Resources.Input_Box_Information_64_x_64;

                    if (systemSound != InputBoxSystemSounds.NONE)
                    {
                        if (customSoundStream != null)
                        {
                            PlaySound(InputBoxSystemSounds.CUSTOM, customSoundStream);
                        }
                        else if (customSoundLocation != null)
                        {
                            PlaySound(InputBoxSystemSounds.CUSTOM, null, customSoundLocation);
                        }
                        else
                        {
                            PlaySound(InputBoxSystemSounds.EXCLAMATION);
                        }
                    }
                    break;
                case IconType.WARNING:
                    pbxIcon.Image = Resources.Input_Box_Warning_64_x_58;

                    if (systemSound != InputBoxSystemSounds.NONE)
                    {
                        if (customSoundStream != null)
                        {
                            PlaySound(InputBoxSystemSounds.CUSTOM, customSoundStream);
                        }
                        else if (customSoundLocation != null)
                        {
                            PlaySound(InputBoxSystemSounds.CUSTOM, null, customSoundLocation);
                        }
                        else
                        {
                            PlaySound(InputBoxSystemSounds.EXCLAMATION);
                        }
                    }
                    break;
                case IconType.ERROR:
                    pbxIcon.Image = Resources.Input_Box_Critical_64_x_64;

                    if (systemSound != InputBoxSystemSounds.NONE)
                    {
                        if (customSoundStream != null)
                        {
                            PlaySound(InputBoxSystemSounds.CUSTOM, customSoundStream);
                        }
                        else if (customSoundLocation != null)
                        {
                            PlaySound(InputBoxSystemSounds.CUSTOM, null, customSoundLocation);
                        }
                        else
                        {
                            PlaySound(InputBoxSystemSounds.ASTERISK);
                        }
                    }
                    break;
                case IconType.HAND:
                    pbxIcon.Image = Resources.Input_Box_Hand_64_x_64;

                    if (systemSound != InputBoxSystemSounds.NONE)
                    {
                        if (customSoundStream != null)
                        {
                            PlaySound(InputBoxSystemSounds.CUSTOM, customSoundStream);
                        }
                        else if (customSoundLocation != null)
                        {
                            PlaySound(InputBoxSystemSounds.CUSTOM, null, customSoundLocation);
                        }
                        else
                        {
                            PlaySound(InputBoxSystemSounds.HAND);
                        }
                    }
                    break;
                case IconType.STOP:
                    pbxIcon.Image = Resources.Input_Box_Stop_64_x_64;

                    if (systemSound != InputBoxSystemSounds.NONE)
                    {
                        if (customSoundStream != null)
                        {
                            PlaySound(InputBoxSystemSounds.CUSTOM, customSoundStream);
                        }
                        else if (customSoundLocation != null)
                        {
                            PlaySound(InputBoxSystemSounds.CUSTOM, null, customSoundLocation);
                        }
                        else
                        {
                            PlaySound(InputBoxSystemSounds.ASTERISK);
                        }
                    }
                    break;
                case IconType.OK:
                    pbxIcon.Image = Resources.Input_Box_Ok_64_x_64;

                    if (systemSound != InputBoxSystemSounds.NONE)
                    {
                        if (customSoundStream != null)
                        {
                            PlaySound(InputBoxSystemSounds.CUSTOM, customSoundStream);
                        }
                        else if (customSoundLocation != null)
                        {
                            PlaySound(InputBoxSystemSounds.CUSTOM, null, customSoundLocation);
                        }
                        else
                        {
                            PlaySound(systemSound);
                        }
                    }
                    break;
            }
        }

        /// <summary>Plays the sound.</summary>
        /// <param name="systemSound">The system sound.</param>
        /// <param name="customSoundStream">The custom sound stream.</param>
        /// <param name="customSoundLocation">The custom sound location.</param>
        private void PlaySound(InputBoxSystemSounds systemSound, Stream customSoundStream = null, string customSoundLocation = null)
        {
            switch (systemSound)
            {
                case InputBoxSystemSounds.ASTERISK:
                    SystemSounds.Asterisk.Play();
                    break;
                case InputBoxSystemSounds.BEEP:
                    SystemSounds.Beep.Play();
                    break;
                case InputBoxSystemSounds.EXCLAMATION:
                    SystemSounds.Exclamation.Play();
                    break;
                case InputBoxSystemSounds.HAND:
                    SystemSounds.Hand.Play();
                    break;
                case InputBoxSystemSounds.QUESTION:
                    SystemSounds.Question.Play();
                    break;
                case InputBoxSystemSounds.CUSTOM:
                    if (customSoundStream != null)
                    {
                        SoundPlayer player1 = new SoundPlayer(customSoundStream);

                        player1.Play();
                    }
                    else if (customSoundLocation != null)
                    {
                        SoundPlayer player2 = new SoundPlayer(customSoundLocation);

                        player2.Play();
                    }
                    break;
                case InputBoxSystemSounds.NONE:
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
            UpdateIconType(Type, InputBoxSystemSound);

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

            pbxIcon.Location = new Point(12, 12);

            klblHeader.Location = new Point(147, 12);

            kwlContent.Location = new Point(147, 77);

            //klblContent.RightToLeft = RightToLeft.

            kbtnAction.Location = new Point(13, 16);

            //kbtnLaunch.RightToLeft = RightToLeft.

            kbtnDismiss.Location = new Point(393, 13);

            //kbtnDismiss.RightToLeft = RightToLeft.No;
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
            klblHeader.Size = headerLabelSize;

            kwlContent.Size = contentLabelSize;

            //kbtnAction.Location = actionButtonLocation;

            kbtnDismiss.Location = dismissButtonLocation;

            pbxIcon.Visible = showIcon;
        }

        // TODO: Revisit
        /// <summary>Resets to the default layout.</summary>
        private void ResetDefaultLayout()
        {
            AdjustLayout(new Size(487, 58), new Size(487, 153), new Point(13, 16), new Point(393, 13));
        }

        /// <summary>Sets the action text.</summary>
        /// <param name="type">The action type.</param>
        /// <param name="launchProcessText">The launch process text.</param>
        /// <param name="openText">The open text.</param>
        private void SetActionText(ActionType type, string launchProcessText = "&Launch Process", string openText = "&Open")
        {
            switch (type)
            {
                case ActionType.LAUCHPROCESS:
                    kbtnAction.Text = $"{ launchProcessText }: '{ Path.GetFileName(ProcessName) }'";
                    break;
                case ActionType.OPEN:
                    kbtnAction.Text = $"{ openText }";
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
            FadeOutAndClose();
        }

        private void KryptonToastWindowVersion1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void KryptonToastWindowVersion1_GotFocus(object sender, EventArgs e) => kbtnDismiss.Focus();

        private void KryptonToastWindowVersion1_Load(object sender, EventArgs e)
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

            pbTickDown.Maximum = _seconds;

            //pbTickDown.Value = pbTickDown.Maximum;
        }
        #endregion

        #region IToastNotificationUIElements Implementation
        public KryptonForm BaseWindow { get => this; }
        public KryptonPanel ContentPanel { get => kpnlContent; }
        public KryptonPanel ButtonPanel { get => kpnlButtons; }
        public KryptonLabel HeaderLabel { get => klblHeader; }

        public KryptonWrapLabel ContentLabel { get => kwlContent; }
        public KryptonButton ActionButton { get => null; }
        public KryptonButton DismissButton { get => kbtnDismiss; }
        public PictureBox IconBox { get => pbxIcon; }
        #endregion
    }
}