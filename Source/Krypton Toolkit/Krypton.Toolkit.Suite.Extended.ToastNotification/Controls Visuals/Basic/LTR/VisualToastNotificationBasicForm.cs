using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.ToastNotification
{
    internal partial class VisualToastNotificationBasicForm : KryptonForm
    {
        #region Instance Fields

        private int _time;

        private Timer _timer;

        private SoundPlayer? _soundPlayer;

        private PaletteBase _palette;

        private readonly KryptonBasicToastNotificationData _toastNotificationData;

        #endregion

        #region Identity

        public VisualToastNotificationBasicForm(KryptonBasicToastNotificationData toastNotificationData)
        {
            InitializeComponent();

            _toastNotificationData = toastNotificationData;

            GotFocus += VisualToastNotificationBasicForm_GotFocus;

            LocationChanged += VisualToastNotificationBasicForm_LocationChanged;

            DoubleBuffered = true;
        }

        #endregion

        private void VisualToastNotificationBasicForm_LocationChanged(object sender, EventArgs e)
        {
            
        }

        private void VisualToastNotificationBasicForm_GotFocus(object sender, EventArgs e) => kbtnDismiss.Focus();

        private void VisualToastNotificationBasicForm_Load(object sender, EventArgs e)
        {
            UpdateSizing();

            UpdateLocation();

            ReportToastLocation();

            ShowCloseButton();

            _timer?.Start();

            _soundPlayer?.Play();
        }

        private void kbtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kbtnDismiss_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kbtnExtraAction_Click(object sender, EventArgs e)
        {

        }

        private void UpdateText()
        {
            krtbNotificationContent.Text = _toastNotificationData.NotificationContent ?? string.Empty;

            klblNotificationTitle.Text = _toastNotificationData.NotificationTitle;

            klblNotificationTitle.StateCommon.ShortText.TextH = _toastNotificationData.TitleAlignment ?? PaletteRelativeAlign.Inherit;

            krtbNotificationContent.DetectUrls = _toastNotificationData.EnableHyperLinks ?? true;
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

        private void ShowCloseButton() => kbtnClose.Visible = _toastNotificationData.ShowCloseButton ?? false;

        private void ReportToastLocation()
        {
            
        }

        private void UpdateLocation() =>
            // Once loaded, position the form, or position it to the bottom left of the screen with added padding
            Location = _toastNotificationData.NotificationLocation ?? new Point(Screen.PrimaryScreen!.WorkingArea.Width - Width - 5,
                Screen.PrimaryScreen.WorkingArea.Height - Height - 5);

        private void UpdateSizing()
        {
            
        }

        #region Show

        public new void Show()
        {
            TopMost = _toastNotificationData.TopMost ?? true;

            UpdateText();

            UpdateIcon();

            if (_toastNotificationData.CountDownSeconds != 0)
            {
                kbtnDismiss.Text = $@"{KryptonManager.Strings.ToastNotificationStrings.Dismiss} ({_toastNotificationData.CountDownSeconds - _time})";

                kbtnDismiss.Text = $@"{KryptonManager.Strings.ToastNotificationStrings.Dismiss} ({_toastNotificationData.CountDownSeconds - _time})";

                _timer = new Timer();

                _timer.Interval = _toastNotificationData.CountDownTimerInterval ?? 1000;

                _timer.Tick += (sender, args) =>
                {
                    _time++;

                    kbtnDismiss.Text = $@"{KryptonManager.Strings.ToastNotificationStrings.Dismiss} ({_toastNotificationData.CountDownSeconds - _time})";

                    kbtnDismiss.Text = $@"{KryptonManager.Strings.ToastNotificationStrings.Dismiss} ({_toastNotificationData.CountDownSeconds - _time})";

                    if (_time == _toastNotificationData.CountDownSeconds)
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

            if (_toastNotificationData.IsDoNotShowAgainOptionChecked)
            {
                //UpdateDoNotShowAgainOptionChecked();
            }

            if (_toastNotificationData.DoNotShowAgainOptionCheckState != null)
            {
                //UpdateDoNotShowAgainOptionCheckState();
            }

            if (_toastNotificationData.CountDownSeconds != 0)
            {
                kbtnDismiss.Text = $@"{KryptonManager.Strings.ToastNotificationStrings.Dismiss} ({_toastNotificationData.CountDownSeconds - _time})";

                kbtnDismiss.Text = $@"{KryptonManager.Strings.ToastNotificationStrings.Dismiss} ({_toastNotificationData.CountDownSeconds - _time})";

                _timer = new Timer();

                _timer.Interval = _toastNotificationData.CountDownTimerInterval ?? 1000;

                _timer.Tick += (sender, args) =>
                {
                    _time++;

                    kbtnDismiss.Text = $@"{KryptonManager.Strings.ToastNotificationStrings.Dismiss} ({_toastNotificationData.CountDownSeconds - _time})";

                    kbtnDismiss.Text = $@"{KryptonManager.Strings.ToastNotificationStrings.Dismiss} ({_toastNotificationData.CountDownSeconds - _time})";

                    if (_time == _toastNotificationData.CountDownSeconds)
                    {
                        _timer.Stop();

                        Close();
                    }
                };
            }

            return base.ShowDialog();
        }

        #endregion

        #region Internal Show Methods

        internal static bool InternalShowWithBooleanReturnValue(KryptonBasicToastNotificationData toastNotificationData)
        {
            using var toast = new VisualToastNotificationBasicForm(toastNotificationData);

            if (toast.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static CheckState InternalShowWithCheckStateReturnValue(
            KryptonBasicToastNotificationData toastNotificationData)
        {
            using var toast = new VisualToastNotificationBasicForm(toastNotificationData);

            return toast.ShowDialog() == DialogResult.OK
                ? /*toast.ReturnCheckBoxStateValue*/ CheckState.Checked
                : CheckState.Unchecked;
        }

        internal static void InternalShow(KryptonBasicToastNotificationData toastNotificationData)
        {
            var toast = new VisualToastNotificationBasicForm(toastNotificationData);

            toast.Show();
        }

        #endregion
    }
}
