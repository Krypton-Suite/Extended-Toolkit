﻿#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    public class KryptonToastNotificationVersion2 : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnAction;
        private KryptonButton kbtnDismiss;
        private KryptonPanel kryptonPanel2;
        private System.Windows.Forms.ProgressBar pbTimeOut;
        private KryptonLabel klblHeader;
        private KryptonWrapLabel kwlContent;
        private System.Windows.Forms.PictureBox pbxIcon;
        private KryptonBorderEdge kryptonBorderEdge1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnAction = new Krypton.Toolkit.KryptonButton();
            this.kbtnDismiss = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.pbTimeOut = new System.Windows.Forms.ProgressBar();
            this.klblHeader = new Krypton.Toolkit.KryptonLabel();
            this.kwlContent = new Krypton.Toolkit.KryptonWrapLabel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnAction);
            this.kryptonPanel1.Controls.Add(this.kbtnDismiss);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 271);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(621, 50);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnAction
            // 
            this.kbtnAction.AutoSize = true;
            this.kbtnAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnAction.Location = new System.Drawing.Point(12, 13);
            this.kbtnAction.Name = "kbtnAction";
            this.kbtnAction.Size = new System.Drawing.Size(6, 6);
            this.kbtnAction.TabIndex = 2;
            this.kbtnAction.Values.Text = "";
            this.kbtnAction.Visible = false;
            // 
            // kbtnDismiss
            // 
            this.kbtnDismiss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnDismiss.Location = new System.Drawing.Point(405, 13);
            this.kbtnDismiss.Name = "kbtnDismiss";
            this.kbtnDismiss.Size = new System.Drawing.Size(204, 25);
            this.kbtnDismiss.TabIndex = 1;
            this.kbtnDismiss.Values.Text = "{0}";
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(621, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.pbTimeOut);
            this.kryptonPanel2.Controls.Add(this.klblHeader);
            this.kryptonPanel2.Controls.Add(this.kwlContent);
            this.kryptonPanel2.Controls.Add(this.pbxIcon);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(621, 271);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // pbTimeOut
            // 
            this.pbTimeOut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbTimeOut.Location = new System.Drawing.Point(0, 261);
            this.pbTimeOut.Name = "pbTimeOut";
            this.pbTimeOut.Size = new System.Drawing.Size(621, 10);
            this.pbTimeOut.TabIndex = 4;
            // 
            // klblHeader
            // 
            this.klblHeader.AutoSize = false;
            this.klblHeader.Location = new System.Drawing.Point(145, 13);
            this.klblHeader.Name = "klblHeader";
            this.klblHeader.Size = new System.Drawing.Size(468, 67);
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
            this.kwlContent.Location = new System.Drawing.Point(145, 83);
            this.kwlContent.Name = "kwlContent";
            this.kwlContent.Size = new System.Drawing.Size(468, 174);
            this.kwlContent.Text = "{0}";
            this.kwlContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcon.Location = new System.Drawing.Point(13, 13);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(125, 125);
            this.pbxIcon.TabIndex = 0;
            this.pbxIcon.TabStop = false;
            // 
            // KryptonToastNotificationVersion2
            // 
            this.ClientSize = new System.Drawing.Size(621, 321);
            this.ControlBox = false;
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonToastNotificationVersion2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private ActionButtonType _actionButtonType;

        private ActionType _actionType;

        private bool _showActionButton;

        private Color _borderColourOne, _borderColourTwo;

        private int _time, _cornerRadius;

        private Image _iconImage;

        private IconType _iconType;

        private System.Windows.Forms.Timer _timer;

        private SoundPlayer _player;

        private string _actionButtonText, _dismissButtonText, _title, _text, _process;
        #endregion

        #region Properties
        private ActionButtonType ActionButtonType { get => _actionButtonType; set => _actionButtonType = value; }

        public ActionType ActionType { get => _actionType; set => _actionType = value; }

        public bool ShowActionButton { get => _showActionButton; set => _showActionButton = value; }

        public string SoundPath { get; set; }

        public Stream SoundStream { get; set; }
        public int TimeOut { get; set; }

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

        public Image IconImage
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
        /// <summary>Initializes a new instance of the <see cref="KryptonToastNotificationVersion2" /> class.</summary>
        /// <param name="image">The image.</param>
        /// <param name="header">The header.</param>
        /// <param name="message">The message.</param>
        /// <param name="borderColourOne">The border colour one.</param>
        /// <param name="borderColourTwo">The border colour two.</param>
        /// <param name="cornerRadius">The corner radius.</param>
        /// <param name="actionButtonType">Type of the action button.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="showActionButton">The show action button.</param>
        public KryptonToastNotificationVersion2(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton, string actionButtonText, string dismissButtonText, IconType? iconType)
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

            ActionButtonType = actionButtonType ?? ActionButtonType.NORMAL;

            ActionType = actionType ?? ActionType.Default;

            ShowActionButton = showActionButton ?? false;

            IconType = iconType ?? IconType.Custom;

            TopMost = true;

            DoubleBuffered = true;

            Resize += ToastNotification_Resize;

            GotFocus += ToastNotification_GotFocus;

            SetActionText(actionType, actionButtonText);
        }

        public KryptonToastNotificationVersion2(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton, string actionButtonText, string dismissButtonText, IconType? iconType, int timeOut) : this(image, header, message, borderColourOne, borderColourTwo, cornerRadius, actionButtonType, actionType, showActionButton, actionButtonText, dismissButtonText, iconType)
        {
            TimeOut = timeOut;
        }

        public KryptonToastNotificationVersion2(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton, string actionButtonText, string dismissButtonText, IconType? iconType, int timeOut, string soundPath) : this(image, header, message, borderColourOne, borderColourTwo, cornerRadius, actionButtonType, actionType, showActionButton, actionButtonText, dismissButtonText, iconType, timeOut)
        {
            SoundPath = soundPath;
        }

        public KryptonToastNotificationVersion2(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton, string actionButtonText, string dismissButtonText, IconType? iconType, string soundPath) : this(image, header, message, borderColourOne, borderColourTwo, cornerRadius, actionButtonType, actionType, showActionButton, actionButtonText, dismissButtonText, iconType)
        {
            SoundPath = soundPath;
        }

        public KryptonToastNotificationVersion2(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton, string actionButtonText, string dismissButtonText, IconType? iconType, Stream soundStream) : this(image, header, message, borderColourOne, borderColourTwo, cornerRadius, actionButtonType, actionType, showActionButton, actionButtonText, dismissButtonText, iconType)
        {
            SoundStream = soundStream;
        }

        public KryptonToastNotificationVersion2(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton, string actionButtonText, string dismissButtonText, IconType? iconType, int timeOut, Stream soundStream) : this(image, header, message, borderColourOne, borderColourTwo, cornerRadius, actionButtonType, actionType, showActionButton, actionButtonText, dismissButtonText, iconType, timeOut)
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
                case ActionButtonType.NORMAL:
                    kbtnAction.Values.Image = null;
                    break;
                case ActionButtonType.UACELEVATED:
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
                case ActionButtonType.NORMAL:
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
                case ActionButtonType.UACELEVATED:
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

            if (TimeOut != 0)
            {
                if (_dismissButtonText != null)
                {
                    kbtnDismiss.Text = $"{_dismissButtonText}";
                }
                else
                {
                    kbtnDismiss.Text = $"&Dismiss";
                }

                _timer = new System.Windows.Forms.Timer();

                _timer.Interval = 1000;

                _timer.Tick += (sender, args) =>
                {
                    _time++;

                    pbTimeOut.Value = TimeOut - _time;

                    if (_dismissButtonText != null)
                    {
                        kbtnDismiss.Text = $"{_dismissButtonText}";
                    }
                    else
                    {
                        kbtnDismiss.Text = $"&Dismiss";
                    }

                    if (_time == TimeOut)
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

        private void StartProcess(string process) => Process.Start(process);

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
                    Process.Start(psi);
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
                    Process.Start(psi);
                }
                catch (Exception e)
                {
                    ExceptionCapture.CaptureException(e);
                }
            }
        }

        private void StartProcessInExplorer(string process) => Process.Start("explorer.exe", process);

        private void SetIconType(IconType iconType, Image customImage = null)
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

        private void SetActionText(ActionType? type, string buttonText = null)
        {
            switch (type)
            {
                case ActionType.Default:
                    if (buttonText != null)
                    {
                        kbtnAction.Text = $"{buttonText} {Path.GetFileName(ProcessToStart)}";
                    }
                    else
                    {
                        kbtnAction.Text = $"&Open {Path.GetFileName(ProcessToStart)}";
                    }
                    break;
                case ActionType.LaunchProcess:
                    if (buttonText != null)
                    {
                        kbtnAction.Text = $"{buttonText} {Path.GetFileName(ProcessToStart)}";
                    }
                    else
                    {
                        kbtnAction.Text = $"L&aunch {Path.GetFileName(ProcessToStart)}";
                    }
                    break;
                case ActionType.Open:
                    if (buttonText != null)
                    {
                        kbtnAction.Text = $"{buttonText} {Path.GetFileName(ProcessToStart)}";
                    }
                    else
                    {
                        kbtnAction.Text = $"&Open {Path.GetFileName(ProcessToStart)}";
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