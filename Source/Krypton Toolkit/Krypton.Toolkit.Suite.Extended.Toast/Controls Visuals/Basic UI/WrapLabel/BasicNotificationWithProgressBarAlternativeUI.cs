#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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
    public partial class BasicNotificationWithProgressBarAlternativeUI : KryptonForm
    {
        #region Variables
        private bool _showCloseButton;

        private IconType _iconType;

        private int _time, _seconds;

        private Timer _timer;

        private SoundPlayer _soundPlayer;

        private string _title, _contentText, _soundPath, _dismissText;

        private Stream _soundStream;

        private Image _customImage;

        private RightToLeftSupport _rightToLeft;
        #endregion

        #region Properties
        public bool ShowCloseButton { get => _showCloseButton; set => _showCloseButton = value; }

        public IconType IconType { get => _iconType; set => _iconType = value; }

        public int Time { get => _time; set => _time = value; }

        public int Seconds { get => _seconds; set => _seconds = value; }

        public string Title { get => _title; set => _title = value; }

        public string ContentText { get => _contentText; set => _contentText = value; }

        public string SoundPath { get => _soundPath; set => _soundPath = value; }

        public string DismissText { get => _dismissText; set => _dismissText = value; }

        public Stream SoundStream { get => _soundStream; set => _soundStream = value; }

        public Image CustomImage { get => _customImage; set => _customImage = value; }

        public RightToLeftSupport RightToLeftSupport { get => _rightToLeft; set { _rightToLeft = value; Invalidate(); } }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBarAlternativeUI" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        public BasicNotificationWithProgressBarAlternativeUI(IconType iconType, string title, string contentText,
                                                             bool? showCloseButton,
                                                             Image customImage = null, string dismissText = "&Dismiss",
                                                             RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight)
        {
            InitializeComponent();

            SetupBaseUI(iconType, title, contentText, showCloseButton, customImage, dismissText, rightToLeftSupport);
        }

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBarAlternativeUI" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        public BasicNotificationWithProgressBarAlternativeUI(IconType iconType, string title, string contentText,
                                                             bool? showCloseButton,
                                                             int seconds, Image customImage = null,
                                                             string dismissText = "&Dismiss",
                                                             RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight)
            : this(iconType, title, contentText, showCloseButton, customImage, dismissText, rightToLeftSupport)
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

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBarAlternativeUI" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundPath">The sound path.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        public BasicNotificationWithProgressBarAlternativeUI(IconType iconType, string title, string contentText,
                                                             bool? showCloseButton,
                                                             int seconds, string soundPath, Image customImage = null,
                                                             string dismissText = "&Dismiss",
                                                             RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight)
            : this(iconType, title, contentText, showCloseButton, seconds, customImage, dismissText, rightToLeftSupport) => SoundPath = soundPath;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBarAlternativeUI" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        public BasicNotificationWithProgressBarAlternativeUI(IconType iconType, string title, string contentText,
                                                             bool? showCloseButton,
                                                             Stream soundStream, Image customImage = null,
                                                             string dismissText = "&Dismiss",
                                                             RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight)
            : this(iconType, title, contentText, showCloseButton, customImage, dismissText, rightToLeftSupport) => SoundStream = soundStream;

        /// <summary>Initializes a new instance of the <see cref="BasicNotificationWithProgressBarAlternativeUI" /> class.</summary>
        /// <param name="iconType">Type of the icon.</param>
        /// <param name="title">The title.</param>
        /// <param name="contentText">The content text.</param>
        /// <param name="showCloseButton">The show close button.</param>
        /// <param name="seconds">The seconds.</param>
        /// <param name="soundStream">The sound stream.</param>
        /// <param name="customImage">The custom image.</param>
        /// <param name="dismissText">The dismiss text.</param>
        /// <param name="rightToLeftSupport">The right to left support.</param>
        public BasicNotificationWithProgressBarAlternativeUI(IconType iconType, string title, string contentText,
                                                             bool? showCloseButton,
                                                             int seconds, Stream soundStream, Image customImage = null,
                                                             string dismissText = "&Dismiss",
                                                             RightToLeftSupport? rightToLeftSupport = RightToLeftSupport.LeftToRight)
            : this(iconType, title, contentText, showCloseButton, seconds, customImage, dismissText, rightToLeftSupport) => SoundStream = soundStream;
        #endregion

        #region Event Handlers

        private void BasicNotificationWithProgressBarAlternativeUI_Load(object sender, EventArgs e) => SetupUI(RightToLeftSupport);

        private void BasicNotificationWithProgressBarAlternativeUI_GotFocus(object sender, EventArgs e)
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

        private void BasicNotificationWithProgressBarAlternativeUI_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void kbtnDismiss_Click(object sender, EventArgs e) => UtilityMethods.FadeOutAndClose(this);

        private void BasicNotificationWithProgressBarAlternativeUI_MouseLeave(object sender, EventArgs e) => _timer.Enabled = true;

        private void BasicNotificationWithProgressBarAlternativeUI_MouseHover(object sender, EventArgs e) => _timer.Enabled = false;

        private void BasicNotificationWithProgressBarAlternativeUI_MouseEnter(object sender, EventArgs e) => _timer.Enabled = false;

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
        public new void Show()
        {
            int currentValue;

            Opacity = 0;

            UtilityMethods.SetIconType(IconType, CustomImage, pbxToastImage);

            kwlTitle.Text = Title;

            kwlContent.Text = ContentText;

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

        private void SetupBaseUI(IconType iconType, string title, string contentText, bool? showCloseButton, Image customImage,
                                 string dismissText, RightToLeftSupport? rightToLeftSupport)
        {
            IconType = iconType;

            Title = title;

            ContentText = contentText;

            ShowCloseButton = showCloseButton ?? false;

            CustomImage = customImage;

            DismissText = dismissText;

            RightToLeftSupport = rightToLeftSupport ?? RightToLeftSupport.LeftToRight;

            TopMost = true;

            SetControlBoxVisibility(ShowCloseButton);

            Resize += BasicNotificationWithProgressBarAlternativeUI_Resize;

            GotFocus += BasicNotificationWithProgressBarAlternativeUI_GotFocus;

            MouseEnter += BasicNotificationWithProgressBarAlternativeUI_MouseEnter;

            MouseHover += BasicNotificationWithProgressBarAlternativeUI_MouseHover;

            MouseLeave += BasicNotificationWithProgressBarAlternativeUI_MouseLeave;

            DoubleBuffered = true;

            RearrangeUI(rightToLeftSupport);
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
                    UtilityMethods.CalibrateUILayout(this, new Control[] { ktbActionButton1, ktbActionButton2, ktbActionButton3, kwlTitle, kwlContent }, RightToLeft.No);

                    RightToLeftLayout = false;

                    pbxToastImage.Location = new Point(12, 12);

                    kwlTitle.Location = new Point(146, 12);

                    kwlContent.Location = new Point(146, 95);
                    break;
                case RightToLeftSupport.RightToLeft:
                    UtilityMethods.CalibrateUILayout(this, new Control[] { ktbActionButton1, ktbActionButton2, ktbActionButton3, kwlTitle, kwlContent }, RightToLeft.Yes);

                    RightToLeftLayout = true;

                    pbxToastImage.Location = new Point(469, 12);

                    kwlTitle.Location = new Point(12, 12);

                    kwlContent.Location = new Point(12, 95);
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

        #region Overrides
        protected override bool ShowWithoutActivation => true;
        #endregion
    }
}
