#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    public partial class BasicNotificationWithProgressBar : KryptonForm
    {
        #region Variables

        private ActionButtonLocation _actionButtonLocation;

        private ActionType _actionType;

        private bool _showActionButton, _usePanelColourInTextArea, _showCloseButton, _openProcessInExplorer;

        private IconType _iconType;

        private int _time, _seconds;

        private Timer _timer;

        private SoundPlayer _soundPlayer;

        private string _actionButtonText, _title, _contentText, _soundPath, _dismissText, _processPath;

        private object _optionalParameters;

        private Stream _soundStream;

        private Image _customImage;

        private RightToLeftSupport _rightToLeft;

        private KryptonCommand _actionButtonCommand;

        #endregion

        #region Properties

        public ActionButtonLocation ActionButtonLocation { get => _actionButtonLocation; set => _actionButtonLocation = value; }

        public ActionType ActionType { get => _actionType; set => _actionType = value; }

        public bool ShowActionButton { get => _showActionButton; set => _showActionButton = value; }

        public bool UsePanelColourInTextArea { get => _usePanelColourInTextArea; set => _usePanelColourInTextArea = value; }

        public bool ShowCloseButton { get => _showCloseButton; set => _showCloseButton = value; }

        public bool OpenProcessInExplorer { get => _openProcessInExplorer; set => _openProcessInExplorer = value; }

        public IconType IconType { get => _iconType; set => _iconType = value; }

        public int Time { get => _time; set => _time = value; }

        public int Seconds { get => _seconds; set => _seconds = value; }

        public string ActionButtonText { get => _actionButtonText; set => _actionButtonText = value; }

        public string Title { get => _title; set => _title = value; }

        public string ContentText { get => _contentText; set => _contentText = value; }

        public string SoundPath { get => _soundPath; set => _soundPath = value; }

        public string DismissText { get => _dismissText; set => _dismissText = value; }

        public string ProcessPath { get => _processPath; set => _processPath = value; }

        public object OptionalParameters { get => _optionalParameters; set => _optionalParameters = value; }

        public Stream SoundStream { get => _soundStream; set => _soundStream = value; }

        public Image CustomImage { get => _customImage; set => _customImage = value; }

        public RightToLeftSupport RightToLeftSupport { get => _rightToLeft; set { _rightToLeft = value; Invalidate(); } }

        public KryptonCommand ActionButtonCommand { get => _actionButtonCommand; set => _actionButtonCommand = value; }

        #endregion

        #region Constructor

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBar" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotificationWithProgressBar(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                                IconType iconType, string title, string contentText,
                                                bool? usePanelColourInTextArea, bool? showCloseButton,
                                                bool? showActionButton,
                                                Image customImage = null,
                                                string dismissText = "&Dismiss",
                                                RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                                KryptonCommand actionButtonCommand = null,
                                                bool? openProcessInExplorer = null,
                                                string processPath = null,
                                                object optionalParameters = null)
        {
            InitializeComponent();

            SetupBaseUI(actionButtonLocation, actionType, iconType, title, contentText, usePanelColourInTextArea, showActionButton, showCloseButton, customImage, dismissText, rightToLeftSupport, actionButtonCommand, openProcessInExplorer, processPath, optionalParameters);
        }

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBar" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotificationWithProgressBar(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                                IconType iconType, string title, string contentText,
                                                bool? usePanelColourInTextArea, bool? showCloseButton,
                                                bool? showActionButton, int seconds,
                                                Image customImage = null, string dismissText = "&Dismiss",
                                                RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                                KryptonCommand actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText, 
                   usePanelColourInTextArea, showCloseButton, showActionButton, customImage, dismissText, 
                   rightToLeftSupport, actionButtonCommand)
        {
            Seconds = seconds;

            if (seconds > 0)
            {
                // Setup the timer
                _timer = new Timer();

                _timer.Interval = 1000;

                _timer.Enabled = true;

                _timer.Tick += CountdownTimer_Tick;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBar" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotificationWithProgressBar(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                                IconType iconType, string title, string contentText,
                                                bool? usePanelColourInTextArea, bool? showCloseButton,
                                                bool? showActionButton, int seconds,
                                                string soundPath, Image customImage = null,
                                                string dismissText = "&Dismiss",
                                                RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                                KryptonCommand actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText,
                   usePanelColourInTextArea, showCloseButton, showActionButton, seconds, customImage,
                   dismissText, rightToLeftSupport, actionButtonCommand) => SoundPath = soundPath;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBar" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotificationWithProgressBar(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                                IconType iconType, string title, string contentText,
                                                bool? usePanelColourInTextArea, bool? showCloseButton,
                                                bool? showActionButton, Stream soundStream,
                                                Image customImage = null, string dismissText = "&Dismiss",
                                                RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                                KryptonCommand actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText, 
                   usePanelColourInTextArea, showCloseButton, showActionButton,
                   customImage, dismissText, 
                   rightToLeftSupport, actionButtonCommand) => SoundStream = soundStream;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBar" /> class.</summary>
        /// <param name="actionButtonLocation">The action button location.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="usePanelColourInTextArea">The use panel colour in text area.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        /// <param name="actionButtonCommand">The action button command.</param>
        public BasicNotificationWithProgressBar(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                                IconType iconType, string title, string contentText,
                                                bool? usePanelColourInTextArea, bool? showCloseButton,
                                                bool? showActionButton, int seconds,
                                                Stream soundStream, Image customImage = null,
                                                string dismissText = "&Dismiss",
                                                RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                                KryptonCommand actionButtonCommand = null)
            : this(actionButtonLocation, actionType, iconType, title, contentText, 
                   usePanelColourInTextArea, showCloseButton, showActionButton,
                   seconds, customImage, 
                   dismissText, rightToLeftSupport, actionButtonCommand) => SoundStream = soundStream;
        #endregion

        #region Event Handlers

        private void BasicNotificationWithProgressBar_GotFocus(object sender, EventArgs e)
        {
            if (RightToLeftSupport == RightToLeftSupport.LeftToRight)
            {
                kbtnToastButton3.Focus();
            }
            else
            {
                kbtnToastButton1.Focus();
            }
        }

        private void BasicNotificationWithProgressBar_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void BasicNotificationWithProgressBar_Load(object sender, EventArgs e) => SetupUI(RightToLeftSupport);

        private void kbtnDismiss_Click(object sender, EventArgs e) => UtilityMethods.FadeOutAndClose(this);

        private void BasicNotificationWithProgressBar_MouseLeave(object sender, EventArgs e) => _timer.Enabled = true;

        private void BasicNotificationWithProgressBar_MouseHover(object sender, EventArgs e) => _timer.Enabled = false;
        
        private void BasicNotificationWithProgressBar_MouseEnter(object sender, EventArgs e) => _timer.Enabled = false;

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            _time++;

            if (RightToLeftSupport == RightToLeftSupport.LeftToRight)
            {
                kbtnToastButton3.Text = $"{DismissText} ({Seconds - Time}s)";
            }
            else
            {
                kbtnToastButton1.Text = $"{DismissText} ({Seconds - Time}s)";
            }

            if (_time == Seconds)
            {
                _timer.Stop();

                UtilityMethods.FadeOutAndClose(this);
            }
        }
        #endregion

        #region Methods
        private void SetupTextArea()
        {
            if (!_usePanelColourInTextArea)
            {
                krtbContent.InputControlStyle = InputControlStyle.Standalone;
            }
            else
            {
                if (kpnlContent.PanelBackStyle == PaletteBackStyle.PanelClient)
                {
                    krtbContent.InputControlStyle = InputControlStyle.PanelClient;
                }
                else if (kpnlContent.PanelBackStyle == PaletteBackStyle.PanelAlternate)
                {
                    krtbContent.InputControlStyle = InputControlStyle.PanelAlternate;
                }
                else
                {
                    krtbContent.InputControlStyle = InputControlStyle.Standalone;
                }
            }
        }

        public new void Show()
        {
            int currentValue;

            Opacity = 0;

            UtilityMethods.SetIconType(IconType, CustomImage, pbxToastImage);

            kwlTitle.Text = Title;

            krtbContent.Text = ContentText;

            if (Seconds != 0)
            {
                pbCountdown.Maximum = Seconds;

                currentValue = pbCountdown.Maximum;

                pbCountdown.Value = currentValue;

                if (RightToLeftSupport == RightToLeftSupport.LeftToRight)
                {
                    kbtnToastButton3.Text = $"{DismissText} ({Seconds - Time})";
                }
                else
                {
                    kbtnToastButton1.Text = $"{DismissText} ({Seconds - Time})";
                }
            }
            else
            {
                if (RightToLeftSupport == RightToLeftSupport.LeftToRight)
                {
                    kbtnToastButton3.Text = DismissText;
                }
                else
                {
                    kbtnToastButton1.Text = DismissText;
                }
            }

            if (SoundPath != null)
            {
                _soundPlayer = new SoundPlayer(SoundPath);
            }
            else
            {
                _soundPlayer = null;
            }

            if (SoundStream != null)
            {
                _soundPlayer = new SoundPlayer(SoundStream);
            }
            else
            {
                _soundPlayer = null;
            }

            base.Show();
        }

        private void SetControlBoxVisibility(bool visibilityToggle) => ControlBox = visibilityToggle;

        private void SetWindowBorderStyle(FormBorderStyle borderStyle) => FormBorderStyle = borderStyle;

        private void SetupBaseUI(ActionButtonLocation? actionButtonLocation, ActionType? actionType,
                                 IconType iconType, string title, string contentText,
                                 bool? usePanelColourInTextArea, bool? showCloseButton,
                                 bool? showActionButton,
                                 Image customImage = null,
                                 string dismissText = "&Dismiss",
                                 RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight,
                                 KryptonCommand actionButtonCommand = null,
                                 bool? openProcessInExplorer = null,
                                 string processPath = null,
                                 object optionalParameters = null)
        {
            ActionButtonLocation = actionButtonLocation ?? ActionButtonLocation.Left;

            ActionType = actionType ?? ActionType.Default;

            IconType = iconType;

            Title = title;

            ContentText = contentText;

            ShowActionButton = showActionButton ?? false;

            UsePanelColourInTextArea = usePanelColourInTextArea ?? false;

            ShowCloseButton = showCloseButton ?? false;

            OpenProcessInExplorer = openProcessInExplorer ?? false;

            CustomImage = customImage;

            DismissText = dismissText;

            ProcessPath = processPath ?? string.Empty;

            OptionalParameters = optionalParameters ?? null;

            RightToLeftSupport = rightToLeftSupport ?? RightToLeftSupport.LeftToRight;

            TopMost = true;

            ActionButtonCommand = actionButtonCommand;

            SetControlBoxVisibility(ShowCloseButton);

            Resize += BasicNotificationWithProgressBar_Resize;

            GotFocus += BasicNotificationWithProgressBar_GotFocus;

            MouseEnter += BasicNotificationWithProgressBar_MouseEnter;

            MouseHover += BasicNotificationWithProgressBar_MouseHover;

            MouseLeave += BasicNotificationWithProgressBar_MouseLeave;

            DoubleBuffered = true;

            SetupTextArea();

            RearrangeUI(rightToLeftSupport);

            ConfigureRightToLeftActions(rightToLeftSupport);

            SetupActionButton(showActionButton, actionButtonLocation);
        }

        private void SetupUI(RightToLeftSupport rightToLeft = RightToLeftSupport.LeftToRight)
        {
            //Once loaded, position the form to the bottom left of the screen with added padding
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 5,
                Screen.PrimaryScreen.WorkingArea.Height - Height - 5);

            UtilityMethods.FadeIn(this);

            if (_timer != null)
            {
                _timer.Start();
            }

            if (_soundPlayer != null)
            {
                _soundPlayer.Play();
            }

            RearrangeUI(rightToLeft);

            if (rightToLeft == RightToLeftSupport.LeftToRight)
            {
                kbtnToastButton3.Text = _dismissText;
            }
            else
            {
                kbtnToastButton1.Text = _dismissText;
            }
        }

        private void RearrangeUI(RightToLeftSupport? rightToLeft)
        {
            switch (rightToLeft)
            {
                case RightToLeftSupport.Inherit:
                    // Note: Come back to this
                    break;
                case RightToLeftSupport.LeftToRight:
                    UtilityMethods.CalibrateUILayout(this, new Control[] { ktbActionButton1, ktbActionButton2, ktbActionButton3, kwlTitle, krtbContent }, RightToLeft.No);

                    RightToLeftLayout = false;

                    UtilityMethods.ChangeControlLocation(pbxToastImage, new Point(12, 12));

                    UtilityMethods.ChangeControlLocation(kwlTitle, new Point(146, 12));

                    UtilityMethods.ChangeControlLocation(krtbContent, new Point(146, 89));
                    break;
                case RightToLeftSupport.RightToLeft:
                    UtilityMethods.CalibrateUILayout(this, new Control[] { ktbActionButton1, ktbActionButton2, ktbActionButton3, kwlTitle, krtbContent }, RightToLeft.Yes);

                    RightToLeftLayout = true;

                    UtilityMethods.ChangeControlLocation(pbxToastImage, new Point(469, 12));

                    UtilityMethods.ChangeControlLocation(kwlTitle, new Point(12, 12));

                    UtilityMethods.ChangeControlLocation(krtbContent, new Point(12, 89));
                    break;
            }
        }

        /// <summary>Configures the right to left action buttons.</summary>
        /// <param name="rightToLeftSupport">The layout of the toast window.</param>
        private void ConfigureRightToLeftActions(RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight)
        {
            switch (rightToLeftSupport)
            {
                case RightToLeftSupport.Inherit:
                    break;
                case RightToLeftSupport.LeftToRight:
                    UtilityMethods.ConfigureToastNotificationButton(ktbActionButton1, _actionType, false, false, _openProcessInExplorer, _optionalParameters, _processPath, _actionButtonText);

                    UtilityMethods.ConfigureToastNotificationButton(ktbActionButton3, ActionType.Default, false, false, false, null, null, _dismissText);
                    break;
                case RightToLeftSupport.RightToLeft:
                    UtilityMethods.ConfigureToastNotificationButton(ktbActionButton1, ActionType.Default, false, false, false, null, null, _dismissText);

                    UtilityMethods.ConfigureToastNotificationButton(ktbActionButton3, _actionType, false, false, _openProcessInExplorer, _optionalParameters, _processPath, _actionButtonText);
                    break;
            }
        }

        /// <summary>Setups the action button.</summary>
        /// <param name="showActionButton">if set to <c>true</c> [show action button].</param>
        /// <param name="actionButtonLocation">The action button location.</param>
        private void SetupActionButton(bool? showActionButton, ActionButtonLocation? actionButtonLocation)
        {
            if (showActionButton != null)
            {
                if (_rightToLeft == RightToLeftSupport.LeftToRight)
                {
                    if (actionButtonLocation == ActionButtonLocation.Left)
                    {
                        kbtnToastButtonPanel1.Visible = true;

                        ktbActionButton1.Visible = true;
                    }
                    else
                    {
                        kbtnToastButtonPanel2.Visible = true;

                        ktbActionButton2.Visible = true;
                    }
                }
                else if (_rightToLeft == RightToLeftSupport.RightToLeft)
                {
                    if (actionButtonLocation == ActionButtonLocation.Right)
                    {
                        tlpButtons.ColumnStyles[0].SizeType = SizeType.Percent;

                        tlpButtons.ColumnStyles[0].Width = 100F;

                        tlpButtons.ColumnStyles[2].SizeType = SizeType.AutoSize;

                        kbtnToastButtonPanel3.Visible = true;

                        ktbActionButton3.Visible = true;
                    }
                    else
                    {
                        tlpButtons.ColumnStyles[0].SizeType = SizeType.Percent;

                        tlpButtons.ColumnStyles[0].Width = 100F;

                        tlpButtons.ColumnStyles[2].SizeType = SizeType.AutoSize;

                        kbtnToastButtonPanel3.Visible = false;

                        ktbActionButton3.Visible = false;

                        kbtnToastButtonPanel1.Visible = true;

                        ktbActionButton1.Visible = true;
                    }
                }
            }
            else
            {
                if (_rightToLeft == RightToLeftSupport.LeftToRight)
                {
                    kbtnToastButtonPanel1.Visible = false;

                    kbtnToastButtonPanel2.Visible = false;
                }
                else if (_rightToLeft == RightToLeftSupport.RightToLeft)
                {
                    kbtnToastButtonPanel2.Visible = false;

                    kbtnToastButtonPanel3.Visible = false;

                    kbtnToastButtonPanel1.Visible = true;

                    ktbActionButton1.Visible = true;
                }
            }
        }

        #endregion
    }
}