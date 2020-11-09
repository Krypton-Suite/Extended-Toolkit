using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    public class Alert
    {
        #region Variables
        private int _timeOut;
        #endregion

        #region Properties
        public int TimeOut { get => _timeOut; set => _timeOut = value; }
        #endregion

        #region Read Only
        private static readonly int IntervalDefault = 1850;
        #endregion

        #region Success
        public static void DisplaySuccess(string message) => DisplaySuccess(message, IntervalDefault);

        private static void DisplaySuccess(string message, int interval)
        {
            KryptonAlertWindow alertWindow = new KryptonAlertWindow();

            alertWindow.DisplayAlert(message, AlertType.SUCESS, interval);
        }
        #endregion

        #region Information

        public static void ShowInformation(string message)
        {
            ShowInformation(message, IntervalDefault);
        }

        public static void ShowInformation(string message, int interval)
        {
            KryptonAlertWindow alertWindow = new KryptonAlertWindow();

            alertWindow.DisplayAlert(message, AlertType.INFORMATION, interval);
        }

        #endregion

        #region Warning

        public static void ShowWarning(string message)
        {
            ShowWarning(message, IntervalDefault);
        }

        public static void ShowWarning(string message, int interval)
        {
            KryptonAlertWindow alertWindow = new KryptonAlertWindow();

            alertWindow.DisplayAlert(message, AlertType.WARNING, interval);
        }

        #endregion

        #region Error

        public static void ShowError(string message)
        {
            ShowError(message, IntervalDefault);
        }

        public static void ShowError(string message, int interval)
        {
            KryptonAlertWindow alertWindow = new KryptonAlertWindow();

            alertWindow.DisplayAlert(message, AlertType.ERROR, interval);
        }

        #endregion

        #region Custom

        public static void ShowCustom(string message, Image image = null, Color backColour = default, Color textColour = default)
        {
            ShowCustom(message, IntervalDefault, image, backColour, textColour);
        }

        public static void ShowCustom(string message, int interval, Image image = null, Color backColour = default, Color textColour = default)
        {
            KryptonAlertWindow alertWindow = new KryptonAlertWindow();

            alertWindow.DisplayAlert(message, AlertType.CUSTOM, interval, image, backColour == default ? Color.FromArgb(83, 92, 104) : backColour, textColour == default ? Color.White : textColour);
        }

        #endregion
    }
}