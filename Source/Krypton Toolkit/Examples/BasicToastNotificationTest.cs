using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examples
{
    public partial class BasicToastNotificationTest : KryptonForm
    {
        #region Instance Fields

        private bool _showCloseBox;
        private bool _topMost;
        private bool _useFade;
        private bool _reportToastLocation;
        private bool _showDoNotShowAgainOption;
        private bool _enableHyperLinks;
        private KryptonUseRTLLayout _useRtlReading;
        private Color _borderColor1;
        private Color _borderColor2;
        private PaletteRelativeAlign _titleAlignment;
        private Font _contentFont;
        private Font _titleFont;
        private int _countDownSeconds;
        private KryptonToastNotificationIcon _notificationIcon;
        private string _notificationTitleText;
        private string _notificationContentText;

        #endregion

        #region Constants

        private const string SEED_TEXT = @"MIT License

Copyright (c) 2017 - 2024 Krypton Suite

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the ""Software""), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.";

        #endregion

        public BasicToastNotificationTest()
        {
            InitializeComponent();
        }

        private void BasicToastNotificationTest_Load(object sender, EventArgs e)
        {
            // Set defaults
            _showCloseBox = false;
            _topMost = true;
            _useFade = false;
            _reportToastLocation = false;
            _showDoNotShowAgainOption = false;
            _enableHyperLinks = true;
            _titleAlignment = PaletteRelativeAlign.Inherit;
            _countDownSeconds = 60;
            _notificationIcon = KryptonToastNotificationIcon.Information;
            _notificationTitleText = ktxtNotificationTitle.Text;
            _notificationContentText = krtbNotificationMessage.Text;
            _borderColor1 = Color.Empty;
            _borderColor2 = Color.Empty;
            _useRtlReading = KryptonUseRTLLayout.No;

            kcbtnBorderColor1.SelectedColor = Color.Empty;
            kcbtnBorderColor2.SelectedColor = Color.Empty;

            foreach (var value in Enum.GetValues(typeof(KryptonToastNotificationIcon)))
            {
                kcmbNotificationIconType.Items.Add(value.ToString());
            }

            kcmbNotificationIconType.SelectedIndex = 8;

            foreach (var value in Enum.GetValues(typeof(PaletteRelativeAlign)))
            {
                kcmbTitleAlignment.Items.Add(value.ToString());
            }

            kcmbTitleAlignment.SelectedIndex = 3;

            //knudStartLocationX.Maximum = GraphicsExtensions.GetWorkingArea().Width;

            //knudStartLocationX.Value = GraphicsExtensions.GetWorkingArea().Width - Width - 5;

            //knudStartLocationY.Maximum = GraphicsExtensions.GetWorkingArea().Height;

            //knudStartLocationY.Value = GraphicsExtensions.GetWorkingArea().Height - Height - 5;
        }

        private void kbtnShow_Click(object sender, EventArgs e)
        {
            Krypton.Toolkit.Suite.Extended.ToastNotification.KryptonBasicToastNotificationData notificationData = new Krypton.Toolkit.Suite.Extended.ToastNotification.KryptonBasicToastNotificationData()
            {
                CountDownSeconds = _countDownSeconds,
                CustomImage = null,
                NotificationContent = _notificationContentText,
                NotificationTitle = _notificationTitleText,
                NotificationContentFont = _contentFont,
                NotificationTitleFont = _titleFont,
                NotificationIcon = _notificationIcon,
                EnableHyperLinks = _enableHyperLinks,
                NotificationLocation = null,
                ShowDoNotShowAgainOption = _showDoNotShowAgainOption,
                TopMost = _topMost,
                UseFade = _useFade,
                ShowCloseButton = _showCloseBox,
                ReportToastLocation = _reportToastLocation,
                TitleAlignment = _titleAlignment,
                BorderColor1 = _borderColor1,
                BorderColor2 = _borderColor2,
                UseRtlReading = _useRtlReading
            };

            Krypton.Toolkit.Suite.Extended.ToastNotification.KryptonBasicToastNotificationData notificationDataWithLocation = new Krypton.Toolkit.Suite.Extended.ToastNotification.KryptonBasicToastNotificationData()
            {
                CountDownSeconds = _countDownSeconds,
                CustomImage = null,
                NotificationContent = _notificationContentText,
                NotificationTitle = _notificationTitleText,
                NotificationContentFont = _contentFont,
                NotificationTitleFont = _titleFont,
                NotificationIcon = _notificationIcon,
                NotificationLocation = new Point((int)knudStartLocationX.Value, (int)knudStartLocationY.Value),
                TitleAlignment  = _titleAlignment,
                TopMost = _topMost,
                UseFade = _useFade,
                ShowCloseButton = _showCloseBox,
                EnableHyperLinks = _enableHyperLinks
            };

            if (kchkUseProgressBar.Checked)
            {
                Krypton.Toolkit.Suite.Extended.ToastNotification.KryptonToastNotification.ShowBasicProgressBarNotification(notificationData);
            }
            else
            {
                Krypton.Toolkit.Suite.Extended.ToastNotification.KryptonToastNotification.ShowBasicToastNotification(notificationData);
            }
        }

        private void kchkShowCloseButton_CheckedChanged(object sender, EventArgs e)
        {
            _showCloseBox = kchkShowCloseButton.Checked;
        }

        private void kchkTopMost_CheckedChanged(object sender, EventArgs e)
        {
            _topMost = kchkTopMost.Checked;
        }

        private void kchkDoNotShowAgain_CheckedChanged(object sender, EventArgs e)
        {
            _showDoNotShowAgainOption = kchkDoNotShowAgain.Checked;
        }

        private void kchkUseDoNotShowAgainOptionThreeState_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void kchkIsDoNotShowAgainOptionChecked_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void kchkUseProgressBar_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void kchkShowCountDownSecondsOnProgressBar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void kchkReportLocation_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void kchkUseRTL_CheckedChanged(object sender, EventArgs e)
        {
            _useRtlReading = kchkUseRTL.Checked ? KryptonUseRTLLayout.Yes : KryptonUseRTLLayout.No;
        }

        private void kchkSetDefaultLocation_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void kcbtnBorderColor1_SelectedColorChanged(object sender, ColorEventArgs e)
        {

        }

        private void kcbtnBorderColor2_SelectedColorChanged(object sender, ColorEventArgs e)
        {

        }

        private void kbtnTestText_Click(object sender, EventArgs e)
        {
            krtbNotificationMessage.Text = SEED_TEXT;
        }

        private void knudCountdownSeconds_ValueChanged(object sender, EventArgs e)
        {
            _countDownSeconds = Convert.ToInt32(knudCountdownSeconds.Value);
        }

        private void kchkEnableHyperLinks_CheckedChanged(object sender, EventArgs e)
        {
            _enableHyperLinks = kchkEnableHyperLinks.Checked;
        }

        private void krtbNotificationMessage_TextChanged(object sender, EventArgs e)
        {
            _notificationContentText = krtbNotificationMessage.Text;
        }

        private void kcmbNotificationIconType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _notificationIcon = (KryptonToastNotificationIcon)Enum.Parse(typeof(KryptonToastNotificationIcon),
                kcmbNotificationIconType.Text);
        }
    }
}
