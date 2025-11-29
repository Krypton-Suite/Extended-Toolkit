#region MIT License

/*
 * MIT License
 *
 * Copyright (c) 2024 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.ToastNotification;

internal partial class VisualToastNotificationBasicPBForm : KryptonForm
{
    #region Instance Fields

    private int _time, _countdownValue;

    private Timer _timer;

    private SoundPlayer? _soundPlayer;

    private PaletteBase _palette;

    private readonly KryptonBasicToastNotificationData _toastNotificationData;

    #endregion

    public VisualToastNotificationBasicPBForm(KryptonBasicToastNotificationData toastNotificationData)
    {
        InitializeComponent();

        _toastNotificationData = toastNotificationData;

        GotFocus += VisualToastNotificationBasicWithProgressBarForm_GotFocus;

        DoubleBuffered = true;
    }

    private void VisualToastNotificationBasicWithProgressBarForm_Load(object sender, EventArgs e)
    {
        UpdateLocation();

        ShowCloseButton();

        _timer.Start();

        _soundPlayer?.Play();

        kbtnDismiss.Text = KryptonManager.Strings.ToastNotificationStrings.Dismiss;
    }

    private void kbtnClose_Click(object sender, EventArgs e) => Close();

    private void kbtnDismiss_Click(object sender, EventArgs e) => Close();

    private void kbtnExtraAction_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception exception)
        {
            KryptonMessageBox.Show($"An error has occurred: {exception}", @"Error", KryptonMessageBoxButtons.OK,
                KryptonMessageBoxIcon.Error);
        }
    }

    private void VisualToastNotificationBasicWithProgressBarForm_GotFocus(object sender, EventArgs e)
    {
        kbtnDismiss.Focus();
    }

    private void UpdateText()
    {
        krtbNotificationContent.Text = _toastNotificationData.NotificationContent ?? string.Empty;

        klblNotificationTitle.Text = _toastNotificationData.NotificationTitle;

        klblNotificationTitle.StateCommon.ShortText.TextH =
            _toastNotificationData.TitleAlignment ?? PaletteRelativeAlign.Inherit;
    }

    private void UpdateFonts()
    {
        krtbNotificationContent.Font = _toastNotificationData.NotificationContentFont ??
                                       KryptonManager.CurrentGlobalPalette.BaseFont;

        if (_toastNotificationData.NotificationTitleFont != null)
        {
            krtbNotificationContent.InputControlStyle = InputControlStyle.PanelClient;

            klblNotificationTitle.Font =
                _toastNotificationData.NotificationTitleFont ?? _palette.Header1ShortFont;
        }
        else
        {
            klblNotificationTitle.LabelStyle = LabelStyle.TitleControl;
        }
    }

    private void UpdateIcon()
    {
        switch (_toastNotificationData.NotificationIcon)
        {
            case KryptonToastNotificationIcon.None:
                SetIcon(null);
                break;
            case KryptonToastNotificationIcon.Hand:
                SetIcon(Resources.Toast_Notification_Hand_128_x_128);
                break;
            case KryptonToastNotificationIcon.SystemHand:
#if NET8_0_OR_GREATER
                    //SetIcon(GraphicsExtensions.ScaleImage());
#else
                SetIcon(GraphicsExtensions.ScaleImage(SystemIcons.Hand.ToBitmap(), 128, 128));
#endif
                break;
            case KryptonToastNotificationIcon.Question:
                SetIcon(Resources.Toast_Notification_Question_128_x_128);
                break;
            case KryptonToastNotificationIcon.SystemQuestion:
                break;
            case KryptonToastNotificationIcon.Exclamation:
                SetIcon(Resources.Toast_Notification_Warning_128_x_115);
                break;
            case KryptonToastNotificationIcon.SystemExclamation:
                break;
            case KryptonToastNotificationIcon.Asterisk:
                SetIcon(Resources.Toast_Notification_Asterisk_128_x_128);
                break;
            case KryptonToastNotificationIcon.SystemAsterisk:
                break;
            case KryptonToastNotificationIcon.Stop:
                SetIcon(Resources.Toast_Notification_Stop_128_x_128);
                break;
            case KryptonToastNotificationIcon.Error:
                SetIcon(Resources.Toast_Notification_Critical_128_x_128);
                break;
            case KryptonToastNotificationIcon.Warning:
                SetIcon(Resources.Toast_Notification_Warning_128_x_115);
                break;
            case KryptonToastNotificationIcon.Information:
                SetIcon(Resources.Toast_Notification_Information_128_x_128);
                break;
            case KryptonToastNotificationIcon.Shield:
                if (OSUtilities.IsAtLeastWindowsEleven)
                {
                    SetIcon(Resources.Toast_Notification_UAC_Shield_Windows_11_128_x_128);
                }
                else if (OSUtilities.IsWindowsTen)
                {
                    SetIcon(Resources.Toast_Notification_UAC_Shield_Windows_10_128_x_128);
                }
                else
                {
                    SetIcon(Resources.Toast_Notification_UAC_Shield_Windows_7_and_8_128_x_128);
                }
                break;
            case KryptonToastNotificationIcon.WindowsLogo:
                break;
            case KryptonToastNotificationIcon.Application:
                break;
            case KryptonToastNotificationIcon.SystemApplication:
                break;
            case KryptonToastNotificationIcon.Ok:
                SetIcon(Resources.Toast_Notification_Ok_128_x_128);
                break;
            case KryptonToastNotificationIcon.Custom:
                SetIcon(_toastNotificationData.CustomImage != null
                    ? new Bitmap(_toastNotificationData.CustomImage)
                    : null);
                break;
            case null:
                SetIcon(null);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void SetIcon(Bitmap? image) => pbxNotificationIcon.Image = image;

    private void UpdateLocation()
    {
        //Once loaded, position the form, or position it to the bottom left of the screen with added padding
        Location = _toastNotificationData.NotificationLocation ?? new Point(Screen.PrimaryScreen!.WorkingArea.Width - Width - 5,
            Screen.PrimaryScreen!.WorkingArea.Height - Height - 5);
    }

    private void ShowCloseButton() => kbtnClose.Visible = _toastNotificationData.ShowCloseButton ?? false;

    private void UpdateProgressBarText() => kpbCountDown.Text = _toastNotificationData.ShowCountDownSecondsOnProgressBar ? $@"{_toastNotificationData.CountDownSeconds - _time}" : string.Empty;

    public new void Show()
    {
        TopMost = _toastNotificationData.TopMost ?? true;

        UpdateText();

        UpdateIcon();

        if (_toastNotificationData.CountDownSeconds != 0)
        {
            _countdownValue = _toastNotificationData.CountDownSeconds ?? 60;

            kpbCountDown.Maximum = _countdownValue;

            kpbCountDown.Value = _countdownValue;

            UpdateProgressBarText();

            _timer = new Timer();

            _timer.Interval = _toastNotificationData.CountDownTimerInterval ?? 1000;

            _timer.Tick += (sender, args) =>
            {
                _time++;

                kpbCountDown.Value -= 1;

                UpdateProgressBarText();

                if (kpbCountDown.Value == kpbCountDown.Minimum)
                {
                    _timer.Stop();

                    Close();
                }
            };
        }


        base.Show();
    }

    public new DialogResult ShowDialog()
    {
        TopMost = _toastNotificationData.TopMost ?? true;

        UpdateText();

        UpdateIcon();

        //if (_toastNotificationData.IsDoNotShowAgainOptionChecked)
        //{
        //    UpdateDoNotShowAgainOptionChecked();
        //}

        //if (_toastNotificationData.DoNotShowAgainOptionCheckState != null)
        //{
        //    UpdateDoNotShowAgainOptionCheckState();
        //}

        if (_toastNotificationData.CountDownSeconds != 0)
        {
            _countdownValue = _toastNotificationData.CountDownSeconds ?? 60;

            kpbCountDown.Maximum = _countdownValue;

            kpbCountDown.Value = _countdownValue;

            UpdateProgressBarText();

            kbtnDismiss.Text = $@"{KryptonManager.Strings.ToastNotificationStrings.Dismiss}";

            _timer = new Timer();

            _timer.Interval = _toastNotificationData.CountDownTimerInterval ?? 1000;

            _timer.Tick += (sender, args) =>
            {
                _time++;

                kpbCountDown.Value -= 1;

                UpdateProgressBarText();

                kbtnDismiss.Text = $@"{KryptonManager.Strings.ToastNotificationStrings.Dismiss}";

                if (_time == _toastNotificationData.CountDownSeconds)
                {
                    _timer.Stop();

                    Close();
                }
            };
        }

        return base.ShowDialog();
    }

    internal static void InternalShow(KryptonBasicToastNotificationData toastNotificationData)
    {
        var kt = new VisualToastNotificationBasicPBForm(toastNotificationData);

        kt.Show();
    }
}