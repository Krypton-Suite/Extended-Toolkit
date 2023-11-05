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

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    public partial class KryptonToastNotificationVersion1 : KryptonForm
    {
        #region Variables
        private ActionButtonType _actionButtonType;

        private ActionType _actionType;

        private bool _showActionButton;

        private Color _borderColourOne, _borderColourTwo;

        private int _time, _cornerRadius;

        private Image _iconImage;

        private IconType _iconType;

        private Timer _timer;

        private SoundPlayer _player;

        private string? _actionButtonText, _dismissButtonText, _title, _text, _process;
        #endregion

        #region Properties
        private ActionButtonType ActionButtonType { get => _actionButtonType; set => _actionButtonType = value; }

        public ActionType ActionType { get => _actionType; set => _actionType = value; }

        public bool ShowActionButton { get => _showActionButton; set => _showActionButton = value; }

        public string? SoundPath { get; set; }

        public Stream? SoundStream { get; set; }
        public int Seconds { get; set; }

        public int CornerRadius
        {
            get => _cornerRadius;

            set
            {
                _cornerRadius = value;

                StateCommon.Border.Rounding = value;
            }
        }

        public string ActionButtonText { get => _actionButtonText; set => _actionButtonText = value; }

        public string DismissButtonText { get => _dismissButtonText; set => _dismissButtonText = value; }

        public string Title
        {
            get => _title;

            set
            {
                _title = value;

                klblHeader.Text = value;
            }
        }

        public string DisplayText
        {
            get => _text;

            set
            {
                _text = value;

                kwlContent.Text = _text;
            }
        }

        public string ProcessToStart { get => _process; set => _process = value; }

        public Color BorderColourOne
        {
            get => _borderColourOne;

            set
            {
                _borderColourOne = value;

                Invalidate();
            }
        }

        public Color BorderColourTwo
        {
            get => _borderColourTwo;

            set
            {
                _borderColourTwo = value;

                Invalidate();
            }
        }

        public Image? IconImage
        {
            get => _iconImage;

            set
            {
                _iconImage = value;

                Invalidate();
            }
        }

        public IconType IconType
        {
            get => _iconType;

            set
            {
                if (_iconType != value)
                {
                    _iconType = value;

                    SetIconType(value);
                }
            }
        }
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotificationVersion1" /> class.</summary>
        /// <param name="image">The image.</param>
        /// <param name="header">The header.</param>
        /// <param name="message">The message.</param>
        /// <param name="borderColourOne">The border colour one.</param>
        /// <param name="borderColourTwo">The border colour two.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="actionButtonType">Type of the action button.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="showActionButton">The show action button.</param>
        public KryptonToastNotificationVersion1(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton, string actionButtonText, string dismissButtonText, IconType? iconType)
        {
            InitializeComponent();

            IconImage = image;

            ActionButtonText = actionButtonText ?? string.Empty;

            DismissButtonText = dismissButtonText ?? string.Empty;

            Title = header;

            DisplayText = message;

            BorderColourOne = borderColourOne ?? Color.Empty;

            BorderColourTwo = borderColourTwo ?? Color.Empty;

            CornerRadius = cornerRadius ?? -1;

            ActionButtonType = actionButtonType ?? ActionButtonType.Normal;

            ActionType = actionType ?? ActionType.Default;

            ShowActionButton = showActionButton ?? false;

            IconType = iconType ?? IconType.Custom;

            TopMost = true;

            DoubleBuffered = true;

            Resize += ToastNotification_Resize;

            GotFocus += ToastNotification_GotFocus;

            SetActionText(actionType, actionButtonText);
        }

        public KryptonToastNotificationVersion1(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton, string actionButtonText, string dismissButtonText, IconType? iconType, int seconds) : this(image, header, message, borderColourOne, borderColourTwo, cornerRadius, actionButtonType, actionType, showActionButton, actionButtonText, dismissButtonText, iconType)
        {
            Seconds = seconds;
        }

        public KryptonToastNotificationVersion1(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton, string actionButtonText, string dismissButtonText, IconType? iconType, int seconds, string soundPath) : this(image, header, message, borderColourOne, borderColourTwo, cornerRadius, actionButtonType, actionType, showActionButton, actionButtonText, dismissButtonText, iconType, seconds)
        {
            SoundPath = soundPath;
        }

        public KryptonToastNotificationVersion1(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton, string actionButtonText, string dismissButtonText, IconType? iconType, string soundPath) : this(image, header, message, borderColourOne, borderColourTwo, cornerRadius, actionButtonType, actionType, showActionButton, actionButtonText, dismissButtonText, iconType)
        {
            SoundPath = soundPath;
        }

        public KryptonToastNotificationVersion1(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton, string actionButtonText, string dismissButtonText, IconType? iconType, Stream soundStream) : this(image, header, message, borderColourOne, borderColourTwo, cornerRadius, actionButtonType, actionType, showActionButton, actionButtonText, dismissButtonText, iconType)
        {
            SoundStream = soundStream;
        }

        public KryptonToastNotificationVersion1(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton, string actionButtonText, string dismissButtonText, IconType? iconType, int seconds, Stream soundStream) : this(image, header, message, borderColourOne, borderColourTwo, cornerRadius, actionButtonType, actionType, showActionButton, actionButtonText, dismissButtonText, iconType, seconds)
        {
            SoundStream = soundStream;
        }
        #endregion

        #region Event Handlers
        private void ToastNotification_GotFocus(object sender, EventArgs e)
        {
            kbtnDismiss.Focus();
        }

        private void ToastNotification_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void KryptonToastNotificationVersion1_Load(object sender, EventArgs e)
        {
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 5, Screen.PrimaryScreen.WorkingArea.Height - Height - 5);

            FadeIn();

            if (_timer != null)
            {
                _timer.Start();
            }

            if (_player != null)
            {
                _player.Play();
            }

            switch (_actionButtonType)
            {
                case ActionButtonType.Normal:
                    kbtnAction.Values.Image = null;
                    break;
                case ActionButtonType.UACElevated:
                    kbtnAction.Values.Image = IconExtractor.LoadIcon(IconExtractor.IconType.Shield, SystemInformation.SmallIconSize).ToBitmap();
                    break;
                default:
                    break;
            }
        }

        private void kbtnAction_Click(object sender, EventArgs e)
        {
            switch (_actionButtonType)
            {
                case ActionButtonType.Normal:
                    switch (_actionType)
                    {
                        case ActionType.Default:
                            StartProcess(ProcessToStart);
                            break;
                        case ActionType.LaunchProcess:
                            break;
                        case ActionType.Open:
                            break;
                    }
                    break;
                case ActionButtonType.UACElevated:
                    switch (_actionType)
                    {
                        case ActionType.Default:
                            break;
                        case ActionType.LaunchProcess:
                            break;
                        case ActionType.Open:
                            break;
                    }
                    break;
            }
        }

        private void kbtnDismiss_Click(object sender, EventArgs e)
        {
            FadeOutAndClose();
        }
        #endregion

        #region Methods
        private void FadeIn()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

            timer.Interval = 10;

            timer.Tick += (sender, args) =>
            {
                if (Opacity == 1d)
                {
                    timer.Stop();
                }

                Opacity += 0.2d;
            };

            timer.Start();
        }

        private void FadeOutAndClose()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

            timer.Interval = 10;

            timer.Tick += (sender, args) =>
            {
                if (Opacity == 0d)
                {
                    timer.Stop();

                    Close();
                }

                Opacity -= 0.02d;
            };

            timer.Start();
        }

        public new void Show()
        {
            Opacity = 0;

            if (IconImage != null)
            {
                SetIconType(IconType.Custom, IconImage);
            }
            else
            {
                SetIconType(_iconType);
            }

            klblHeader.Text = Title;

            kwlContent.Text = DisplayText;

            _borderColourOne = BorderColourOne;

            StateCommon.Border.Color1 = _borderColourOne;

            _borderColourTwo = BorderColourTwo;

            StateCommon.Border.Color2 = _borderColourTwo;

            if (Seconds != 0)
            {
                if (_dismissButtonText != null)
                {
                    kbtnDismiss.Text = $@"{_dismissButtonText} ({Seconds - _time}s)";
                }
                else
                {
                    kbtnDismiss.Text = $@"&Dismiss ({Seconds - _time}s)";
                }

                _timer = new Timer();

                _timer.Interval = 1000;

                _timer.Tick += (sender, args) =>
                {
                    _time++;

                    if (_dismissButtonText != null)
                    {
                        kbtnDismiss.Text = $@"{_dismissButtonText} ({Seconds - _time}s)";
                    }
                    else
                    {
                        kbtnDismiss.Text = $@"&Dismiss ({Seconds - _time}s)";
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

        private void StartProcess(string process) => GlobalToolkitUtilities.LaunchProcess(process);

        private void StartProcess(string process, string args, bool elevate = false)
        {
            if (elevate)
            {
                ProcessStartInfo psi = new ProcessStartInfo()
                {
                    Verb = "runas",
                    Arguments = args,
                    FileName = process
                };

                try
                {
                    GlobalToolkitUtilities.LaunchProcess(psi);
                }
                catch (Exception e)
                {
                    ExceptionCapture.CaptureException(e);
                }
            }
            else
            {
                ProcessStartInfo psi = new ProcessStartInfo()
                {
                    Arguments = args,
                    FileName = process
                };

                try
                {
                    GlobalToolkitUtilities.LaunchProcess(psi);
                }
                catch (Exception e)
                {
                    ExceptionCapture.CaptureException(e);
                }
            }
        }

        private void StartProcessInExplorer(string process) => GlobalToolkitUtilities.LaunchProcess("explorer.exe", process);

        private void SetIconType(IconType iconType, Image? customImage = null)
        {
            switch (iconType)
            {
                case IconType.Custom:
                    if (customImage != null)
                    {
                        pbxIcon.Image = customImage;
                    }
                    else
                    {
                        pbxIcon.Image = Properties.Resources.Information_128_x_128;
                    }
                    break;
                case IconType.Ok:
                    pbxIcon.Image = Properties.Resources.Ok_128_x_128;
                    break;
                case IconType.Error:
                    pbxIcon.Image = Properties.Resources.Critical_128_x_128;
                    break;
                case IconType.Exclamation:
                    pbxIcon.Image = Properties.Resources.Warning_128_x_128;
                    break;
                case IconType.Information:
                    pbxIcon.Image = Properties.Resources.Information_128_x_128;
                    break;
                case IconType.Question:
                    pbxIcon.Image = Properties.Resources.Question_128_x_128;
                    break;
                case IconType.None:
                    pbxIcon.Image = null;
                    break;
                case IconType.Stop:
                    pbxIcon.Image = Properties.Resources.Stop_128_x_128;
                    break;
                case IconType.Hand:
                    pbxIcon.Image = Properties.Resources.Hand_128_x_128;
                    break;
                case IconType.Warning:
                    pbxIcon.Image = Properties.Resources.Input_Box_Warning_128_x_115;
                    break;
                case IconType.Asterisk:
                    break;
                case IconType.Shield:
                    break;
                case IconType.WindowsLogo:
                    break;
            }
        }

        private void SetActionText(ActionType? type, string? buttonText = null)
        {
            switch (type)
            {
                case ActionType.Default:
                    if (buttonText != null)
                    {
                        kbtnAction.Text = $@"{buttonText} {Path.GetFileName(ProcessToStart)}";
                    }
                    else
                    {
                        kbtnAction.Text = $@"&Open {Path.GetFileName(ProcessToStart)}";
                    }
                    break;
                case ActionType.LaunchProcess:
                    if (buttonText != null)
                    {
                        kbtnAction.Text = $@"{buttonText} {Path.GetFileName(ProcessToStart)}";
                    }
                    else
                    {
                        kbtnAction.Text = $@"L&aunch {Path.GetFileName(ProcessToStart)}";
                    }
                    break;
                case ActionType.Open:
                    if (buttonText != null)
                    {
                        kbtnAction.Text = $@"{buttonText} {Path.GetFileName(ProcessToStart)}";
                    }
                    else
                    {
                        kbtnAction.Text = $@"&Open {Path.GetFileName(ProcessToStart)}";
                    }
                    break;
            }
        }
        #endregion

        #region Overrides
        protected override bool ShowWithoutActivation => true;
        #endregion
    }
}