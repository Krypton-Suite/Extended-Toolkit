﻿#region MIT License
/*
 *
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

namespace Krypton.Toolkit.Suite.Extended.Developer.Utilities
{
    // TODO: Rewrite this class!
    /// <summary>For use in try/catch blocks. Uses the standard <see cref="KryptonMessageBox"/> to display exception messages.</summary>
    public class ExceptionCapture
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="ExceptionCapture" /> class.</summary>
        public ExceptionCapture()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Captures the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="title">The title.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="methodSignature">The method signature.</param>
        /// <param name="useDebugConsole">Use the debug console.</param>
        /// <param name="dumpException">Dumps the exception data to a file.</param>
        public static void CaptureException(Exception exception, string title = @"Exception Caught", KryptonMessageBoxButtons buttons = KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon icon = KryptonMessageBoxIcon.Error, string className = "", string methodSignature = "", bool useDebugConsole = false, bool dumpException = false, MessageBoxButtons win32Buttons = MessageBoxButtons.OK)
        {
            if (className != "")
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: {exception.Message}.\n\nError in class: '{className}.cs'.", title, buttons, icon);
            }
            else if (methodSignature != "")
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: {exception.Message}.\n\nError in method: '{methodSignature}'.", title, buttons, icon);
            }
            else if (className != "" && methodSignature != "")
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: {exception.Message}.\n\nError in class: '{className}.cs'.\n\nError in method: '{methodSignature}'.", title, buttons, icon);
            }
            else
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: {exception.Message}.", title, buttons, icon);
            }

            if (useDebugConsole)
            {
                KryptonDeveloperDebugConsole debugConsole = new KryptonDeveloperDebugConsole(exception);

                debugConsole.Show();
            }
        }

        /// <summary>Captures the exception.</summary>
        /// <param name="exception">The exception.</param>
        /// <param name="currentWindow">The current window.</param>
        /// <param name="control">The control.</param>
        /// <param name="title">The title.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="methodSignature">The method signature.</param>
        public static void CaptureException(Exception exception, KryptonForm currentWindow, Control control = null, string title = @"Exception Caught", KryptonMessageBoxButtons buttons = KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon icon = KryptonMessageBoxIcon.Error, string className = "", string methodSignature = "", MessageBoxButtons win32Buttons = MessageBoxButtons.OK)
        {
            if (className != "")
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: {exception.Message}.\n\nError in class: '{className}.cs'.", title, buttons, icon);
            }
            else if (methodSignature != "")
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: {exception.Message}.\n\nError in method: '{methodSignature}'.", title, buttons, icon);
            }
            else if (className != "" && methodSignature != "")
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: {exception.Message}.\n\nError in class: '{className}.cs'.\n\nError in method: '{methodSignature}'.", title, buttons, icon);
            }
            else
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: {exception.Message}.", title, buttons, icon);
            }
        }

        /// <summary>Captures the exception.</summary>
        /// <param name="exceptionMessage">The exception message.</param>
        /// <param name="useKryptonMessageBox">if set to <c>true</c> [use krypton message box].</param>
        /// <param name="useExtendedKryptonMessageBox">if set to <c>true</c> [use extended krypton message box].</param>
        /// <param name="useWin32MessageBox">if set to <c>true</c> [use win32 message box].</param>
        /// <param name="useConsole">if set to <c>true</c> [use console].</param>
        /// <param name="useToolStripLabel">if set to <c>true</c> [use tool strip label].</param>
        /// <param name="toolStripLabel">The tool strip label.</param>
        /// <param name="args">The arguments.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="defaultButton">The default button.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="options">The options.</param>
        public void CaptureException(string exceptionMessage, bool useKryptonMessageBox = false, bool useExtendedKryptonMessageBox = false, bool useWin32MessageBox = false, bool useConsole = false, bool useToolStripLabel = false, ToolStripLabel toolStripLabel = null, object args = null, string caption = "Exception Caught", KryptonMessageBoxButtons buttons = KryptonMessageBoxButtons.OK, KryptonMessageBoxDefaultButton defaultButton = KryptonMessageBoxDefaultButton.Button4, KryptonMessageBoxIcon icon = KryptonMessageBoxIcon.Error, MessageBoxOptions options = MessageBoxOptions.DefaultDesktopOnly, MessageBoxIcon winFormsIcon = MessageBoxIcon.Error, MessageBoxDefaultButton winFormsDefaultButton = MessageBoxDefaultButton.Button3, MessageBoxButtons win32Buttons = MessageBoxButtons.OK)
        {
            if (useKryptonMessageBox)
            {
                KryptonMessageBox.Show(exceptionMessage, caption, buttons, icon, defaultButton, options);
            }
            else if (useExtendedKryptonMessageBox)
            {
                // Note: Enter code
            }
            else if (useWin32MessageBox)
            {
                MessageBox.Show(exceptionMessage, caption, win32Buttons, winFormsIcon, winFormsDefaultButton, options);
            }
            else if (useConsole)
            {
                Console.WriteLine($@"[ {DateTime.Now} ]: {exceptionMessage}");
            }
        }

        /// <summary>Captures the exception.</summary>
        /// <param name="exceptionMessage">The exception message.</param>
        /// <param name="title">The title.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        public static void CaptureException(string exceptionMessage, string title, KryptonMessageBoxButtons buttons,
                                     KryptonMessageBoxIcon icon) => KryptonMessageBox.Show(exceptionMessage, title, buttons, icon);

        /*
#if !NET40_OR_GREATER
        /// <summary>
        /// Captures a stacktrace of the exception.
        /// </summary>
        /// <param name="exc">The incoming exception.</param>
        /// <param name="fileName">The file to write the exception stacktrace to.</param>
        public static void PrintStackTrace(Exception exc, string fileName)
        {
            try
            {
                System.Runtime.ExceptionServices.ExceptionDispatchInfo exceptionInfo = null;

                if (!File.Exists(fileName))
                {
                    File.Create(fileName);
                }

                exceptionInfo = ExceptionDispatchInfo.Capture(exc);

                StreamWriter writer = new StreamWriter(fileName);

                writer.Write(exc.ToString());

                writer.Close();

                writer.Dispose();
            }
            catch (Exception ex)
            {
                CaptureException(ex);
            }
        }
#endif
        */

        /// <summary>
        /// Captures a stacktrace of the exception.
        /// </summary>
        /// <param name="exc">The incoming exception.</param>
        /// <param name="fileName">The file to write the exception stacktrace to.</param>
        public static void PrintExceptionStackTrace(Exception exc, string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    File.Create(fileName);
                }

                StreamWriter writer = new StreamWriter(fileName);

                writer.Write(exc.StackTrace);

                writer.Close();

                writer.Dispose();
            }
            catch (Exception e)
            {
                CaptureException(e);
            }
        }

        private void DumpException(Exception e)
        {
            try
            {
                string fileName = $"Exception Log - {CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern}.log";

                File.Create(fileName);

                StreamWriter writer = new StreamWriter(fileName);

                writer.Write(e.Data.ToString());

                writer.Close();

                writer.Dispose();

                DialogResult result = KryptonMessageBox.Show($"Log file created at: '{Path.GetFullPath(fileName)}'. Open now?", "Log File Created", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Process.Start(@"Notepad.exe", Path.GetFullPath(fileName));
                }
            }
            catch (Exception exception)
            {
                CaptureException(e);
            }
        }

        #endregion

        #region Destruction
        /// <summary>Finalizes an instance of the <see cref="ExceptionCapture" /> class.</summary>
        ~ExceptionCapture() => GC.SuppressFinalize(this);
        #endregion
    }
}