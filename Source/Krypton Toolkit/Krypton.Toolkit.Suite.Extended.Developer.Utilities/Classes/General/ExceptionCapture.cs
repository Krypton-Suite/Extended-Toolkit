#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Developer.Utilities
{
    /*
    /// <summary>For use in try/catch blocks. Uses the standard <see cref="KryptonMessageBox"/> to display exception messages.</summary>
    public static class ExceptionCapture
    {
        #region Variables
        private static bool? _useDebugConsole, _useExtendedMessageBox, _printStackTrace;

        private static MessageBoxButtons? _buttons;

        private static MessageBoxIcon? _icon;

        private static string _title, _className, _methodSignature, _messageStart, _messageMiddleClass, _messageMiddleMethodSignature;

        private static Exception _exception;
        #endregion       

        #region Methods
        public static void CaptureException(Exception exception, bool? useDebugConsole, bool? useExtendedMessageBox, bool? printStackTrace,
                                            MessageBoxIcon? icon, MessageBoxButtons? buttons, string title, string className,
                                            string methodSignature, string messageStart, string messageMiddleClass,
                                            string messageMiddleMethodSignature)
        {
            #region Store Values
            _useDebugConsole = useDebugConsole ?? false;

            _useExtendedMessageBox = useExtendedMessageBox ?? false;

            _printStackTrace = printStackTrace ?? false;

            _icon = icon ?? MessageBoxIcon.Warning;

            _buttons = buttons ?? MessageBoxButtons.OK;

            _title = title ?? @"Exception Caught";

            _className = className ?? string.Empty;

            _methodSignature = methodSignature ?? string.Empty;

            _messageStart = messageStart ?? "An unexpected error has occurred: ";

            _messageMiddleClass = messageMiddleClass ?? ".\n\nError in class: ";

            _messageMiddleMethodSignature = messageMiddleMethodSignature ?? "\n\nError in method: ";
            #endregion

            #region Logic
            if (className != string.Empty)
            {
                if (useExtendedMessageBox != null)
                {

                }
                else
                {
                    KryptonMessageBox.Show($"{messageStart}{exception.Message}{messageMiddleClass}'{className}.cs'.", title, buttons, icon);
                }
            }
            else if (methodSignature != string.Empty)
            {
                if (useExtendedMessageBox != null)
                {

                }
                else
                {

                }
            }
            else if (className != string.Empty && methodSignature != string.Empty)
            {
                if (useExtendedMessageBox != null)
                {

                }
                else
                {

                }
            }
            else
            {
                if (useExtendedMessageBox != null)
                {

                }
                else
                {

                }
            }
            #endregion

            if (useDebugConsole != null)
            {
                KryptonDeveloperDebugConsole debugConsole = new KryptonDeveloperDebugConsole(exception);

                debugConsole.Show();
            }
        }
        #endregion
    }
    */
}