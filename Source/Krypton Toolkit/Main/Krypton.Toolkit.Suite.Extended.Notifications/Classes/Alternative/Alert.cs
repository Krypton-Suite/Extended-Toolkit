#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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
        /// <summary>Displays a success message.</summary>
        /// <param name="message">The message.</param>
        /// <param name="headerText">The header text.</param>
        public static void DisplaySuccessMessage(string message, string headerText = null) => DisplaySuccessMessage(message, IntervalDefault, headerText);

        private static void DisplaySuccessMessage(string message, int interval, string headerText = null)
        {
            KryptonAlertWindow alertWindow = new KryptonAlertWindow();

            alertWindow.DisplayAlert(message, AlertType.SUCESS, interval, headerText: headerText);
        }
        #endregion

        #region Information

        /// <summary>Shows a information message.</summary>
        /// <param name="message">The message.</param>
        /// <param name="headerText">The header text.</param>
        public static void ShowInformationMessage(string message, string headerText = null) => ShowInformationMessage(message, IntervalDefault, headerText);

        private static void ShowInformationMessage(string message, int interval, string headerText = null)
        {
            KryptonAlertWindow alertWindow = new KryptonAlertWindow();

            alertWindow.DisplayAlert(message, AlertType.INFORMATION, interval, headerText: headerText);
        }

        #endregion

        #region Warning

        /// <summary>Shows a warning message.</summary>
        /// <param name="message">The message.</param>
        /// <param name="headerText">The header text.</param>
        public static void ShowWarningMessage(string message, string headerText = null) => ShowWarningMessage(message, IntervalDefault, headerText);

        private static void ShowWarningMessage(string message, int interval, string headerText = null)
        {
            KryptonAlertWindow alertWindow = new KryptonAlertWindow();

            alertWindow.DisplayAlert(message, AlertType.WARNING, interval, headerText: headerText);
        }

        #endregion

        #region Error

        /// <summary>Shows a error message.</summary>
        /// <param name="message">The message.</param>
        /// <param name="headerText">The header text.</param>
        public static void ShowErrorMessage(string message, string headerText = null) => ShowErrorMessage(message, IntervalDefault, headerText);

        private static void ShowErrorMessage(string message, int interval, string headerText = null)
        {
            KryptonAlertWindow alertWindow = new KryptonAlertWindow();

            alertWindow.DisplayAlert(message, AlertType.ERROR, interval, headerText: headerText);
        }

        #endregion

        #region Custom

        /// <summary>Shows a custom message.</summary>
        /// <param name="message">The message.</param>
        /// <param name="image">The image.</param>
        /// <param name="backColour">The back colour.</param>
        /// <param name="textColour">The text colour.</param>
        /// <param name="headerText">The header text.</param>
        public static void ShowCustomMessage(string message, Image image = null, Color backColour = default, Color textColour = default, string headerText = null) => ShowCustomMessage(message, IntervalDefault, image, backColour, textColour, headerText);

        private static void ShowCustomMessage(string message, int interval, Image image = null, Color backColour = default, Color textColour = default, string headerText = null)
        {
            KryptonAlertWindow alertWindow = new KryptonAlertWindow();

            alertWindow.DisplayAlert(message, AlertType.CUSTOM, interval, image, backColour == default ? Color.FromArgb(83, 92, 104) : backColour, textColour == default ? Color.White : textColour, headerText);
        }

        #endregion
    }
}