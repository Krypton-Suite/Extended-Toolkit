#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    /// <summary>
    /// A wrapper for exception handling.
    /// </summary>
    public class ExceptionHandler
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandler"/> class.
        /// </summary>
        public ExceptionHandler()
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
        public static void CaptureException(Exception exception, string title = @"Exception Caught", MessageBoxButtons buttons = MessageBoxButtons.OK, KryptonMessageBoxIcon icon = KryptonMessageBoxIcon.Error, string className = "", string methodSignature = "")
        {
            if (className != "")
            {
                ExtendedKryptonMessageBox.Show($"An unexpected error has occurred: {exception.Message}.\n\nError in class: '{className}.cs'.", title, buttons, icon);
            }
            else if (methodSignature != "")
            {
                ExtendedKryptonMessageBox.Show($"An unexpected error has occurred: {exception.Message}.\n\nError in method: '{methodSignature}'.", title, buttons, icon);
            }
            else if (className != "" && methodSignature != "")
            {
                ExtendedKryptonMessageBox.Show($"An unexpected error has occurred: {exception.Message}.\n\nError in class: '{className}.cs'.\n\nError in method: '{methodSignature}'.", title, buttons, icon);
            }
            else
            {
                ExtendedKryptonMessageBox.Show($"An unexpected error has occurred: {exception.Message}.", title, buttons, icon);
            }
        }

        /// <summary>
        /// Shows the exception.
        /// </summary>
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
        public void ShowException(string exceptionMessage, bool useKryptonMessageBox = false, bool useExtendedKryptonMessageBox = false, bool useWin32MessageBox = false, bool useConsole = false, bool useToolStripLabel = false, ToolStripLabel? toolStripLabel = null, object? args = null, string caption = "Exception Caught", KryptonMessageBoxButtons buttons = KryptonMessageBoxButtons.OK, KryptonMessageBoxDefaultButton defaultButton = KryptonMessageBoxDefaultButton.Button4, KryptonMessageBoxIcon icon = KryptonMessageBoxIcon.Exclamation, MessageBoxOptions options = MessageBoxOptions.DefaultDesktopOnly, MessageBoxDefaultButton winFormsDefaultButton = MessageBoxDefaultButton.Button3)
        {
            if (useKryptonMessageBox)
            {
                KryptonMessageBox.Show(exceptionMessage, caption, buttons, icon, defaultButton, options);
            }
            else if (useExtendedKryptonMessageBox)
            {

            }
            else if (useWin32MessageBox)
            {
                //MessageBox.Show(exceptionMessage, caption, buttons, icon, winFormsDefaultButton, options);
            }
            else if (useConsole)
            {
                Console.WriteLine($"[ {DateTime.Now.ToString()} ]: {exceptionMessage}");
            }
        }

        /// <summary>
        /// Captures a stacktrace of the exception.
        /// </summary>
        /// <param name="exc">The incoming exception.</param>
        /// <param name="fileName">The file to write the exception stacktrace to.</param>
        public static void PrintStackTrace(Exception exc, string fileName)
        {
            try
            {
                ExceptionDispatchInfo exceptionInfo = null;

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
                ExceptionCapture.CaptureException(ex);
            }
        }

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
                ExceptionCapture.CaptureException(e);
            }
        }
        #endregion
    }
}