using Krypton.Toolkit.Suite.Extended.Dialogs.Resources;
using System;
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
            this.kbtnDismiss = new Krypton.Toolkit.KryptonButton();
            this.kbtnAction = new Krypton.Toolkit.KryptonButton();
            this.pnlSplitter = new System.Windows.Forms.Panel();
            this.kpnlContent = new Krypton.Toolkit.KryptonPanel();
            this.kwlContent = new Krypton.Toolkit.KryptonWrapLabel();
            this.kwlTitle = new Krypton.Toolkit.KryptonWrapLabel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
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
            // kbtnDismiss
            // 
            this.kbtnDismiss.Location = new System.Drawing.Point(456, 7);
            this.kbtnDismiss.Name = "kbtnDismiss";
            this.kbtnDismiss.Size = new System.Drawing.Size(141, 25);
            this.kbtnDismiss.TabIndex = 1;
            this.kbtnDismiss.Values.Text = "Dismiss ({0}s)";
            this.kbtnDismiss.Click += new System.EventHandler(this.kbtnDismiss_Click);
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
            this.kbtnAction.Click += new System.EventHandler(this.kbtnAction_Click);
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
            this.Load += new System.EventHandler(this.KryptonToastNotificationWindow_Load);
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
        private DefaultNotificationButton _defaultNotificationButton;
        private string _headerText, _contentText, _dismissButtonText, _actionButtonText, _processName;
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

        /// <summary>Gets or sets the action button text.</summary>
        /// <value>The action button text.</value>
        public string ActionButtonText { get => _actionButtonText; set => _actionButtonText = value; }

        /// <summary>Gets or sets the dismiss button text.</summary>
        /// <value>The dismiss button text.</value>
        public string DismissButtonText { get => _dismissButtonText; set => _dismissButtonText = value; }

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

        /// <summary>Gets or sets the default notification button.</summary>
        /// <value>The default notification button.</value>
        public DefaultNotificationButton DefaultNotificationButton { get => _defaultNotificationButton; set => _defaultNotificationButton = value; }
        #endregion

        #region Constants
        private const int DEFAULT_Y_AXIS_LOCATION = 7;
        #endregion

        #region Custom Events

        #region Action Event
        /// <summary></summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="LaunchActionEventArgs" /> instance containing the event data.</param>
        public delegate void LaunchActionEventHandler(object sender, LaunchActionEventArgs e);

        /// <summary>Occurs when [launch action].</summary>
        public event LaunchActionEventHandler LaunchAction;

        /// <summary>Called when [launch action].</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="LaunchActionEventArgs" /> instance containing the event data.</param>
        protected virtual void OnLaunchAction(object sender, LaunchActionEventArgs e) => LaunchAction?.Invoke(sender, e);
        #endregion

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
        /// <param name="dismissButtonText">The dismiss button text.</param>
        /// <param name="actionButtonText">The action button text.</param>
        /// <param name="customIconImage">The custom icon image.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="drawBorders">The draw borders.</param>
        /// <param name="actionButtonLocation">The location of the action button.</param>
        /// <param name="dismissButtonLocation">The location of the dismiss button.</param>
        /// <param name="showControlBox">Shows the control box (Minimise, Maximise & Close).</param>
        /// <param name="contentTypeface">The typeface for the content text.</param>
        /// <param name="headerTypeface">The typeface for the header text.</param>
        /// <param name="defaultNotificationButton">The default notification button.</param>
        public KryptonToastNotificationWindow(string headerText, string contentText, string windowTitleText, IconType iconType, bool fade, ActionType actionType,
                                              bool showActionButton, string soundPath, Stream soundStream, ContentAlignment contentTextAlignment,
                                              ContentAlignment headerTextAlignment, string processName, string dismissButtonText, string actionButtonText,
                                              Image customIconImage, int seconds, int cornerRadius, PaletteDrawBorders drawBorders,
                                              Point actionButtonLocation, Point dismissButtonLocation, bool showControlBox,
                                              Font contentTypeface, Font headerTypeface, DefaultNotificationButton defaultNotificationButton)
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

            ActionButtonText = actionButtonText;

            DismissButtonText = dismissButtonText;

            CustomIconImage = customIconImage;

            Seconds = seconds;

            CornerRadius = cornerRadius;

            PaletteDrawBorders = drawBorders;

            DefaultNotificationButton = defaultNotificationButton;
            #endregion

            Text = windowTitleText;

            kbtnAction.Location = actionButtonLocation;

            kbtnDismiss.Location = dismissButtonLocation;

            TopMost = true;

            DoubleBuffered = true;

            ControlBox = showControlBox;

            kwlContent.StateCommon.Font = contentTypeface;

            kwlContent.TextAlign = ContentTextAlignment;

            kwlTitle.StateCommon.Font = headerTypeface;

            kwlTitle.TextAlign = HeaderTextAlignment;

            Resize += KryptonToastNotificationWindow_Resize;

            GotFocus += KryptonToastNotificationWindow_GotFocus;
        }
        #endregion

        #region Internal Method
        /// <summary>Internals the show.</summary>
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
        /// <param name="dismissButtonText">The dismiss button text.</param>
        /// <param name="actionButtonText">The action button text.</param>
        /// <param name="customIconImage">The custom icon image.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="drawBorders">The draw borders.</param>
        /// <param name="actionButtonLocation">The location of the action button.</param>
        /// <param name="dismissButtonLocation">The location of the dismiss button.</param>
        /// <param name="showControlBox">Shows the control box (Minimise, Maximise & Close).</param>
        /// <param name="contentTypeface">The typeface for the content text.</param>
        /// <param name="headerTypeface">The typeface for the header text.</param>
        /// <param name="defaultNotificationButton">The default notification button.</param>
        /// <returns></returns>
        private static DialogResult InternalShow(string headerText, string contentText, string windowTitleText, IconType iconType, bool fade, ActionType actionType,
                                              bool showActionButton, string soundPath, Stream soundStream, ContentAlignment contentTextAlignment,
                                              ContentAlignment headerTextAlignment, string processName, string dismissButtonText, string actionButtonText,
                                              Image customIconImage, int seconds, int cornerRadius, PaletteDrawBorders drawBorders,
                                              Point actionButtonLocation, Point dismissButtonLocation, bool showControlBox,
                                              Font contentTypeface, Font headerTypeface, DefaultNotificationButton defaultNotificationButton)
        {
            using (KryptonToastNotificationWindow ktnw = new KryptonToastNotificationWindow(headerText, contentText, windowTitleText, iconType, fade, actionType, showActionButton, soundPath, soundStream, contentTextAlignment, headerTextAlignment, processName, dismissButtonText, actionButtonText, customIconImage, seconds, cornerRadius, drawBorders, actionButtonLocation, dismissButtonLocation, showControlBox, contentTypeface, headerTypeface, defaultNotificationButton))
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

            kwlContent.Text = ContentText;

            kwlTitle.Text = HeaderText;

            kbtnAction.Visible = ShowActionButton;

            if (Seconds != 0)
            {
                kbtnDismiss.Text = $"{ DismissButtonText } ({ Seconds - _time }s)";

                _timer = new Timer();

                _timer.Interval = 1000;

                _timer.Tick += (sender, e) =>
                {
                    _time++;

                    kbtnDismiss.Text = $"{ DismissButtonText } ({ Seconds - _time }s)";

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

            SetDefaultNotificationButton(DefaultNotificationButton);

            base.Show();
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
                    if (customIconImage != null)
                    {
                        pbxIcon.Image = customIconImage;
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                    break;
                case IconType.NONE:
                    AdjustLayout(new Size(622, 58), new Size(622, 153), new Point(12, 6), new Point(470, 6), false);
                    break;
                case IconType.QUESTION:
                    pbxIcon.Image = InputBoxResources.Input_Box_Question_64_x_64;

                    SystemSounds.Question.Play();
                    break;
                case IconType.INFORMATION:
                    pbxIcon.Image = InputBoxResources.Input_Box_Information_64_x_64;

                    SystemSounds.Exclamation.Play();
                    break;
                case IconType.WARNING:
                    pbxIcon.Image = InputBoxResources.Input_Box_Warning_64_x_58;

                    SystemSounds.Exclamation.Play();
                    break;
                case IconType.ERROR:
                    pbxIcon.Image = InputBoxResources.Input_Box_Critical_64_x_64;
                    break;
                case IconType.HAND:
                    pbxIcon.Image = InputBoxResources.Input_Box_Hand_64_x_64;
                    break;
                case IconType.STOP:
                    pbxIcon.Image = InputBoxResources.Input_Box_Stop_64_x_64;
                    break;
                case IconType.OK:
                    pbxIcon.Image = InputBoxResources.Input_Box_Ok_64_x_64;
                    break;
            }
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
            kwlTitle.Size = headerLabelSize;

            kwlContent.Size = contentLabelSize;

            kbtnAction.Location = actionButtonLocation;

            kbtnDismiss.Location = dismissButtonLocation;

            pbxIcon.Visible = showIcon;
        }

        /// <summary>
        /// Sets the action text.
        /// </summary>
        /// <param name="type">The type.</param>
        private void SetActionText(ActionType type)
        {
            switch (type)
            {
                case ActionType.LAUCHPROCESS:
                    kbtnAction.Text = $"&{ ActionButtonText } { Path.GetFileName(ProcessName) }";
                    break;
                case ActionType.OPEN:
                    kbtnAction.Text = $"&{ ActionButtonText }";
                    break;
            }
        }

        /// <summary>Sets the default notification button.</summary>
        /// <param name="defaultNotificationButton">The default notification button.</param>
        private void SetDefaultNotificationButton(DefaultNotificationButton defaultNotificationButton)
        {
            switch (defaultNotificationButton)
            {
                case DefaultNotificationButton.ACTIONBUTTON:
                    AcceptButton = kbtnAction;
                    break;
                case DefaultNotificationButton.DISMISSBUTTON:
                    AcceptButton = kbtnDismiss;
                    break;
                case DefaultNotificationButton.NONE:
                    AcceptButton = null;
                    break;
            }

            DefaultNotificationButton = defaultNotificationButton;
        }

        private Point PollActionButtonLocation() => kbtnAction.Location;

        private Point PollDismissButtonLocation() => kbtnDismiss.Location;

        private Point DefaultStartLocation() => new Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 5, Screen.PrimaryScreen.WorkingArea.Height - Height - 5);

        private DefaultNotificationButton GetDefaultNotificationButton() => DefaultNotificationButton;
        #endregion

        #region Protected
        protected override bool ShowWithoutActivation => true;

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.Paint">Paint</see> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs">PaintEventArgs</see> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateIconType(IconType);

            StateCommon.Border.Rounding = CornerRadius;

            StateCommon.Border.DrawBorders = PaletteDrawBorders;

            base.OnPaint(e);
        }
        #endregion

        #region Event Handlers
        private void KryptonToastNotificationWindow_GotFocus(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized) WindowState = FormWindowState.Normal;
        }

        private void KryptonToastNotificationWindow_Resize(object sender, EventArgs e) => SetDefaultNotificationButton(GetDefaultNotificationButton());

        private void KryptonToastNotificationWindow_Load(object sender, EventArgs e)
        {
            Location = DefaultStartLocation();

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

        private void kbtnAction_Click(object sender, EventArgs e)
        {
            LaunchActionEventArgs launch = new LaunchActionEventArgs(ProcessName);

            OnLaunchAction(sender, launch);
        }

        private void kbtnDismiss_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}