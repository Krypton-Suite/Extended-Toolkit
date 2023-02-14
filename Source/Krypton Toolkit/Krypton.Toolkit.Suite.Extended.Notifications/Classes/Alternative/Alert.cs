#region MIT License
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

            alertWindow.DisplayAlert(message, AlertType.Sucess, interval, headerText: headerText);
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

            alertWindow.DisplayAlert(message, AlertType.Information, interval, headerText: headerText);
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

            alertWindow.DisplayAlert(message, AlertType.Warning, interval, headerText: headerText);
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

            alertWindow.DisplayAlert(message, AlertType.Error, interval, headerText: headerText);
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

            alertWindow.DisplayAlert(message, AlertType.Custom, interval, image, backColour == default ? Color.FromArgb(83, 92, 104) : backColour, textColour == default ? Color.White : textColour, headerText);
        }

        #endregion
    }
}