#region MIT License

/*
 * MIT License
 *
 * Copyright (c) 2026 - 2026 Krypton Suite
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

using Krypton.Toolkit.Suite.Extended.Messagebox;
using System.Windows.Forms;

namespace Examples
{
    /// <summary>
    /// Comprehensive example demonstrating the expandable footer feature of ExtendedKryptonMessageBox.
    /// This example shows various use cases for the footer including error details, stack traces, and additional information.
    /// </summary>
    public partial class MessageBoxFooterExample : KryptonForm
    {
        #region Constructor

        public MessageBoxFooterExample()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void MessageBoxFooterExample_Load(object sender, EventArgs e)
        {
            // Set up the form
            Text = @"ExtendedKryptonMessageBox - Expandable Footer Examples";
        }

        /// <summary>
        /// Example 1: Error message with collapsed footer containing stack trace.
        /// Demonstrates showing error details in a collapsed footer that users can expand if needed.
        /// </summary>
        private void btnErrorWithFooter_Click(object sender, EventArgs e)
        {
            string mainMessage = @"An error occurred while processing your request.";
            string footerText = @"Stack Trace:
   at Examples.MessageBoxFooterExample.btnErrorWithFooter_Click(Object sender, EventArgs e)
   at System.Windows.Forms.Control.OnClick(EventArgs e)
   at System.Windows.Forms.Button.OnClick(EventArgs e)
   at System.Windows.Forms.Button.OnMouseUp(MouseEventArgs mevent)
   at System.Windows.Forms.Control.WmMouseUp(Message& m, MouseButtons button, Int32 clicks)
   at System.Windows.Forms.Control.WndProc(Message& m)
   at System.Windows.Forms.ButtonBase.WndProc(Message& m)
   at System.Windows.Forms.Button.WndProc(Message& m)
   at System.Windows.Forms.NativeWindow.Callback(IntPtr hWnd, Int32 msg, IntPtr wparam, IntPtr lparam)

Exception Details:
   Type: System.InvalidOperationException
   Message: The operation cannot be completed because the object is in an invalid state.
   Source: Examples
   TargetSite: Void btnErrorWithFooter_Click(System.Object, System.EventArgs)";

            KryptonMessageBoxExtended.Show(
                this,
                mainMessage,
                @"Error",
                ExtendedMessageBoxButtons.OK,
                ExtendedKryptonMessageBoxIcon.Error,
                footerText,
                footerExpanded: false  // Footer starts collapsed
            );
        }

        /// <summary>
        /// Example 2: Warning message with expanded footer showing additional context.
        /// Demonstrates showing important information in an expanded footer.
        /// </summary>
        private void btnWarningWithExpandedFooter_Click(object sender, EventArgs e)
        {
            string mainMessage = @"This operation will modify system settings.";
            string footerText = @"Additional Information:
• This change affects all users on this system
• A system restart may be required
• Previous settings will be backed up automatically
• You can restore previous settings from the Settings menu

For more information, visit: https://example.com/help";

            KryptonMessageBoxExtended.Show(
                this,
                mainMessage,
                @"Warning",
                ExtendedMessageBoxButtons.YesNo,
                ExtendedKryptonMessageBoxIcon.Warning,
                footerText,
                footerExpanded: true  // Footer starts expanded
            );
        }

        /// <summary>
        /// Example 3: Information message with technical details in footer.
        /// Demonstrates using the footer for technical information that doesn't clutter the main message.
        /// </summary>
        private void btnInfoWithTechnicalDetails_Click(object sender, EventArgs e)
        {
            string mainMessage = @"Your file has been successfully processed.";
            string footerText = @"Processing Details:
File: C:\\Users\\Documents\\report.pdf
Size: 2.5 MB
Processing Time: 1.2 seconds
Pages Processed: 45
Format: PDF/A-1b
Checksum: A3F9B2C1D4E5F6A7B8C9D0E1F2A3B4C5
Timestamp: 2026-01-15 14:32:18 UTC";

            KryptonMessageBoxExtended.Show(
                this,
                mainMessage,
                @"Information",
                ExtendedMessageBoxButtons.OK,
                ExtendedKryptonMessageBoxIcon.Information,
                footerText,
                footerExpanded: false
            );
        }

        /// <summary>
        /// Example 4: Question dialog with help text in footer.
        /// Demonstrates using the footer to provide additional guidance without overwhelming the main question.
        /// </summary>
        private void btnQuestionWithHelp_Click(object sender, EventArgs e)
        {
            string mainMessage = @"Do you want to save your changes before closing?";
            string footerText = @"Help:
• Click 'Yes' to save your changes and close the document
• Click 'No' to close without saving (changes will be lost)
• Click 'Cancel' to return to the document and continue editing

Keyboard Shortcuts:
• Ctrl+S: Save
• Ctrl+W: Close
• Esc: Cancel";

            KryptonMessageBoxExtended.Show(
                this,
                mainMessage,
                @"Save Changes?",
                ExtendedMessageBoxButtons.YesNoCancel,
                ExtendedKryptonMessageBoxIcon.Question,
                footerText,
                footerExpanded: false
            );
        }

        /// <summary>
        /// Example 5: Exception details with full error information.
        /// Demonstrates showing comprehensive error information in a collapsed footer.
        /// </summary>
        private void btnExceptionDetails_Click(object sender, EventArgs e)
        {
            string mainMessage = @"A database connection error occurred.";
            string footerText = @"Exception Information:
Type: System.Data.SqlClient.SqlException
Message: A network-related or instance-specific error occurred while establishing a connection to SQL Server.
Error Number: 2
State: 0
Class: 20
Server: SQLSERVER01
Line Number: 0

Connection String: Server=SQLSERVER01;Database=MyDB;Integrated Security=True;
Timeout: 30 seconds

Troubleshooting Steps:
1. Verify that the SQL Server instance is running
2. Check network connectivity to the server
3. Verify firewall settings allow connections on port 1433
4. Confirm the database name is correct
5. Check SQL Server authentication settings

For additional help, contact your system administrator.";

            KryptonMessageBoxExtended.Show(
                this,
                mainMessage,
                @"Database Error",
                ExtendedMessageBoxButtons.OK,
                ExtendedKryptonMessageBoxIcon.Error,
                footerText,
                footerExpanded: false
            );
        }

        /// <summary>
        /// Example 6: Validation errors with detailed field information.
        /// Demonstrates using the footer to show multiple validation errors in a structured format.
        /// </summary>
        private void btnValidationErrors_Click(object sender, EventArgs e)
        {
            string mainMessage = @"Please correct the following validation errors:";
            string footerText = @"Validation Errors:
1. Email Address: Invalid format. Expected format: user@example.com
2. Phone Number: Required field cannot be empty
3. Date of Birth: Date cannot be in the future
4. Password: Must be at least 8 characters and contain uppercase, lowercase, and numbers
5. Confirm Password: Passwords do not match

Please review each field and correct the errors before proceeding.";

            KryptonMessageBoxExtended.Show(
                this,
                mainMessage,
                @"Validation Failed",
                ExtendedMessageBoxButtons.OK,
                ExtendedKryptonMessageBoxIcon.Warning,
                footerText,
                footerExpanded: true  // Expanded to show all errors immediately
            );
        }

        /// <summary>
        /// Example 7: System information in footer.
        /// Demonstrates displaying system or diagnostic information in the footer.
        /// </summary>
        private void btnSystemInfo_Click(object sender, EventArgs e)
        {
            string mainMessage = @"Application diagnostic information is available.";
            string footerText = $@"System Information:
Operating System: {System.Environment.OSVersion}
.NET Version: {System.Environment.Version}
Machine Name: {System.Environment.MachineName}
User Name: {System.Environment.UserName}
Working Directory: {System.Environment.CurrentDirectory}
Processor Count: {System.Environment.ProcessorCount}
System Uptime: {TimeSpan.FromMilliseconds(System.Environment.TickCount):dd\:hh\:mm\:ss}

Application Information:
Version: 1.0.0.0
Build Date: {System.DateTime.Now:yyyy-MM-dd}
Configuration: Debug";

            KryptonMessageBoxExtended.Show(
                this,
                mainMessage,
                @"System Information",
                ExtendedMessageBoxButtons.OK,
                ExtendedKryptonMessageBoxIcon.Information,
                footerText,
                footerExpanded: false
            );
        }

        /// <summary>
        /// Example 8: No footer (standard message box).
        /// Demonstrates that the footer is optional - if not provided, the message box behaves normally.
        /// </summary>
        private void btnNoFooter_Click(object sender, EventArgs e)
        {
            KryptonMessageBoxExtended.Show(
                this,
                @"This is a standard message box without a footer.",
                @"Standard Message",
                ExtendedMessageBoxButtons.OK,
                ExtendedKryptonMessageBoxIcon.Information
            );
        }

        #endregion
    }
}
