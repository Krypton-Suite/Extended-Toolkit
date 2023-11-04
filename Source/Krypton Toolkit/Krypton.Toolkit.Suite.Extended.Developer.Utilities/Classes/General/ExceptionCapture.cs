﻿#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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