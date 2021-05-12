#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Krypton.Toolkit.Suite.Extended.Developer.Utilities;

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    public class KryptonToastNotificationVersion1 : KryptonForm
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonButton kbtnDismiss;
        private KryptonButton kbtnAction;
        private KryptonLabel klblHeader;
        private KryptonWrapLabel kwlContent;
        private System.Windows.Forms.PictureBox pbxIcon;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnDismiss = new Krypton.Toolkit.KryptonButton();
            this.kbtnAction = new Krypton.Toolkit.KryptonButton();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            this.kwlContent = new Krypton.Toolkit.KryptonWrapLabel();
            this.klblHeader = new Krypton.Toolkit.KryptonLabel();
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
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 269);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(625, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(625, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.klblHeader);
            this.kryptonPanel2.Controls.Add(this.kwlContent);
            this.kryptonPanel2.Controls.Add(this.pbxIcon);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(625, 269);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kbtnDismiss
            // 
            this.kbtnDismiss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnDismiss.Location = new System.Drawing.Point(409, 13);
            this.kbtnDismiss.Name = "kbtnDismiss";
            this.kbtnDismiss.Size = new System.Drawing.Size(204, 25);
            this.kbtnDismiss.TabIndex = 1;
            this.kbtnDismiss.Values.Text = "{0} ({1})";
            this.kbtnDismiss.Click += new System.EventHandler(this.kbtnDismiss_Click);
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
            this.kbtnAction.Click += new System.EventHandler(this.kbtnAction_Click);
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
            // KryptonToastNotificationVersion1
            // 
            this.ClientSize = new System.Drawing.Size(625, 319);
            this.ControlBox = false;
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonToastNotificationVersion1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.KryptonToastNotificationVersion1_Load);
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

        private Timer _timer;

        private SoundPlayer _player;

        private string _title, _text;        
        #endregion

        #region Properties
        private ActionButtonType ActionButtonType { get => _actionButtonType; set => _actionButtonType = value; }

        public ActionType ActionType { get => _actionType; set => _actionType = value; }

        public bool ShowActionButton { get => _showActionButton; set => _showActionButton = value; }

        public string SoundPath { get; set; }

        public Stream SoundStream { get; set; }
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
        #endregion

        #region Constructors
        public KryptonToastNotificationVersion1(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton)
        {
            InitializeComponent();

            IconImage = image;

            Title = header;

            DisplayText = message;

            BorderColourOne = borderColourOne ?? Color.Empty;

            BorderColourTwo = borderColourTwo ?? Color.Empty;

            CornerRadius = cornerRadius ?? -1;

            ActionButtonType = actionButtonType ?? ActionButtonType.NORMAL;

            ActionType = actionType ?? ActionType.DEFAULT;

            ShowActionButton = showActionButton ?? false;

            TopMost = true;

            DoubleBuffered = true;

            Resize += ToastNotification_Resize;

            GotFocus += ToastNotification_GotFocus;
        }

        public KryptonToastNotificationVersion1(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton, int seconds) : this(image, header, message, borderColourOne, borderColourTwo, cornerRadius, actionButtonType, actionType, showActionButton)
        {
            Seconds = seconds;
        }

        public KryptonToastNotificationVersion1(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton, int seconds, string soundPath) : this(image, header, message, borderColourOne, borderColourTwo, cornerRadius, actionButtonType, actionType, showActionButton, seconds)
        {
            SoundPath = soundPath;
        }

        public KryptonToastNotificationVersion1(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton, string soundPath) : this(image, header, message, borderColourOne, borderColourTwo, cornerRadius, actionButtonType, actionType, showActionButton)
        {
            SoundPath = soundPath;
        }

        public KryptonToastNotificationVersion1(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton, Stream soundStream) : this(image, header, message, borderColourOne, borderColourTwo, cornerRadius, actionButtonType, actionType, showActionButton)
        {
            SoundStream = soundStream;
        }

        public KryptonToastNotificationVersion1(Image image, string header, string message, Color? borderColourOne, Color? borderColourTwo, int? cornerRadius, ActionButtonType? actionButtonType, ActionType? actionType, bool? showActionButton, int seconds, Stream soundStream) : this(image, header, message, borderColourOne, borderColourTwo, cornerRadius, actionButtonType, actionType, showActionButton, seconds)
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
            switch (_actionType)
            {
                case ActionType.DEFAULT:
                    break;
                case ActionType.LAUCHPROCESS:
                    break;
                case ActionType.OPEN:
                    break;
                default:
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
            Timer timer = new Timer();

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
            Timer timer = new Timer();
            
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

            pbxIcon.Image = IconImage;

            klblHeader.Text = Title;

            kwlContent.Text = DisplayText;

            _borderColourOne = BorderColourOne;

            StateCommon.Border.Color1 = _borderColourOne;

            _borderColourTwo = BorderColourTwo;

            StateCommon.Border.Color2 = _borderColourTwo;

            if (Seconds != 0)
            {
                kbtnDismiss.Text = $"Dismiss ({Seconds - _time}s)";

                _timer = new Timer();

                _timer.Interval = 1000;

                _timer.Tick += (sender, args) =>
                {
                    _time++;

                    kbtnDismiss.Text = $"Dismiss ({Seconds - _time}s)";

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
        #endregion

        #region Overrides
        protected override bool ShowWithoutActivation => true;
        #endregion
    }
}