﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    public partial class BasicNotificationAlternativeUIRTL : KryptonForm
    {
        #region Variables
        private IconType _iconType;

        private int _time, _seconds;

        private Timer _timer;

        private SoundPlayer _soundPlayer;

        private string _title, _contentText, _soundPath, _dismissText;

        private Stream _soundStream;

        private Image _customImage;
        #endregion

        #region Properties
        public IconType IconType { get => _iconType; set => _iconType = value; }

        public int Time { get => _time; set => _time = value; }

        public int Seconds { get => _seconds; set => _seconds = value; }

        public string Title { get => _title; set => _title = value; }

        public string ContentText { get => _contentText; set => _contentText = value; }

        public string SoundPath { get => _soundPath; set => _soundPath = value; }

        public string DismissText { get => _dismissText; set => _dismissText = value; }

        public Stream SoundStream { get => _soundStream; set => _soundStream = value; }

        public Image CustomImage { get => _customImage; set => _customImage = value; }
        #endregion

        #region Constructor
        public BasicNotificationAlternativeUIRTL(IconType iconType, string title, string contentText, Image customImage = null, string dismissText = "&Dismiss")
        {
            InitializeComponent();

            IconType = iconType;

            Title = title;

            ContentText = contentText;

            CustomImage = customImage;

            DismissText = dismissText;

            TopMost = true;

            Resize += BasicNotificationAlternativeUIRTL_Resize;

            GotFocus += BasicNotificationAlternativeUIRTL_GotFocus;

            DoubleBuffered = true;
        }

        public BasicNotificationAlternativeUIRTL(IconType iconType, string title, string contentText, int seconds, Image customImage = null, string dismissText = "&Dismiss")
            : this(iconType, title, contentText, customImage, dismissText) => Seconds = seconds;

        public BasicNotificationAlternativeUIRTL(IconType iconType, string title, string contentText, int seconds, string soundPath, Image customImage = null, string dismissText = "&Dismiss")
            : this(iconType, title, contentText, seconds, customImage, dismissText) => SoundPath = soundPath;

        public BasicNotificationAlternativeUIRTL(IconType iconType, string title, string contentText, Stream soundStream, Image customImage = null, string dismissText = "&Dismiss")
            : this(iconType, title, contentText, customImage, dismissText) => SoundStream = soundStream;

        public BasicNotificationAlternativeUIRTL(IconType iconType, string title, string contentText, int seconds, Stream soundStream, Image customImage = null, string dismissText = "&Dismiss")
            : this(iconType, title, contentText, seconds, customImage, dismissText) => SoundStream = soundStream;
        #endregion

        #region Event Handlers
        private void BasicNotificationAlternativeUIRTL_Load(object sender, EventArgs e)
        {
            //Once loaded, position the form to the bottom left of the screen with added padding
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 5, Screen.PrimaryScreen.WorkingArea.Height - Height - 5);

            UtilityMethods.FadeIn(this);

            if (_timer != null)
            {
                _timer.Start();
            }

            if (_soundPlayer != null)
            {
                _soundPlayer.Play();
            }

            kbtnDismiss.Text = _dismissText;
        }

        private void BasicNotificationAlternativeUIRTL_GotFocus(object sender, EventArgs e) => kbtnDismiss.Focus();

        private void BasicNotificationAlternativeUIRTL_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void kbtnDismiss_Click(object sender, EventArgs e) => UtilityMethods.FadeOutAndClose(this);
        #endregion

        #region Methods
        public new void Show()
        {
            Opacity = 0;

            UtilityMethods.SetIconType(IconType, CustomImage, pbxToastImage);

            kwlTitle.Text = Title;

            kwlContent.Text = ContentText;

            if (Seconds != 0)
            {
                kbtnDismiss.Text = $"{DismissText} ({Seconds - Time})";

                _timer = new Timer();

                _timer.Interval = 1000;

                _timer.Tick += (sender, e) =>
                {
                    _time++;

                    kbtnDismiss.Text = $"{DismissText} ({Seconds - Time}s)";

                    if (_time == Seconds)
                    {
                        _timer.Stop();

                        UtilityMethods.FadeOutAndClose(this);
                    }
                };
            }
            else
            {
                kbtnDismiss.Text = DismissText;
            }

            if (SoundPath != null)
            {
                _soundPlayer = new SoundPlayer(SoundPath);
            }

            if (SoundStream != null)
            {
                _soundPlayer = new SoundPlayer(SoundStream);
            }

            base.Show();
        }
        #endregion

        #region Overrides
        protected override bool ShowWithoutActivation => true;
        #endregion
    }
}
