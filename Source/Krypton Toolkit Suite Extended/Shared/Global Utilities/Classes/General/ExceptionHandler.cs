using System;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Global.Utilities
{
    /// <summary>
    /// A wrapper for exception handling.
    /// </summary>
    internal class ExceptionHandler
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
        public static void CaptureException(Exception exception, string title = @"Exception Caught", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Error, string className = "", string methodSignature = "")
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
        public void ShowException(string exceptionMessage, bool useKryptonMessageBox = false, bool useExtendedKryptonMessageBox = false, bool useWin32MessageBox = false, bool useConsole = false, bool useToolStripLabel = false, ToolStripLabel toolStripLabel = null, object args = null, string caption = "Exception Caught", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button3, MessageBoxIcon icon = MessageBoxIcon.Exclamation, MessageBoxOptions options = MessageBoxOptions.DefaultDesktopOnly)
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
                MessageBox.Show(exceptionMessage, caption, buttons, icon, defaultButton, options);
            }
            else if (useConsole)
            {
                Console.WriteLine($"[ { DateTime.Now.ToString() } ]: { exceptionMessage }");
            }
        }
        #endregion
    }
}