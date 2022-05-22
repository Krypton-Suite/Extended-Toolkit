#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
        public static void CaptureException(Exception exception, string title = @"Exception Caught", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Error, string className = "", string methodSignature = "", bool useDebugConsole = false)
        {
            if (className != "")
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: { exception.Message }.\n\nError in class: '{ className }.cs'.", title, buttons, icon);
            }
            else if (methodSignature != "")
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: { exception.Message }.\n\nError in method: '{ methodSignature }'.", title, buttons, icon);
            }
            else if (className != "" && methodSignature != "")
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: { exception.Message }.\n\nError in class: '{ className }.cs'.\n\nError in method: '{ methodSignature }'.", title, buttons, icon);
            }
            else
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: { exception.Message }.", title, buttons, icon);
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
        public static void CaptureException(Exception exception, KryptonForm currentWindow, Control control = null, string title = @"Exception Caught", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Error, string className = "", string methodSignature = "")
        {
            if (className != "")
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: { exception.Message }.\n\nError in class: '{ className }.cs'.", title, buttons, icon);
            }
            else if (methodSignature != "")
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: { exception.Message }.\n\nError in method: '{ methodSignature }'.", title, buttons, icon);
            }
            else if (className != "" && methodSignature != "")
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: { exception.Message }.\n\nError in class: '{ className }.cs'.\n\nError in method: '{ methodSignature }'.", title, buttons, icon);
            }
            else
            {
                KryptonMessageBox.Show($"An unexpected error has occurred: { exception.Message }.", title, buttons, icon);
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
        public void CaptureException(string exceptionMessage, bool useKryptonMessageBox = false, bool useExtendedKryptonMessageBox = false, bool useWin32MessageBox = false, bool useConsole = false, bool useToolStripLabel = false, ToolStripLabel toolStripLabel = null, object args = null, string caption = "Exception Caught", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button3, MessageBoxIcon icon = MessageBoxIcon.Exclamation, MessageBoxOptions options = MessageBoxOptions.DefaultDesktopOnly)
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
                MessageBox.Show(exceptionMessage, caption, buttons, icon, defaultButton, options);
            }
            else if (useConsole)
            {
                Console.WriteLine($"[ { DateTime.Now } ]: { exceptionMessage }");
            }
        }

        /// <summary>Captures the exception.</summary>
        /// <param name="exceptionMessage">The exception message.</param>
        /// <param name="title">The title.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        public static void CaptureException(string exceptionMessage, string title, MessageBoxButtons buttons,
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
        #endregion

        #region Destruction
        /// <summary>Finalizes an instance of the <see cref="ExceptionCapture" /> class.</summary>
        ~ExceptionCapture() => GC.SuppressFinalize(this);
        #endregion
    }
}