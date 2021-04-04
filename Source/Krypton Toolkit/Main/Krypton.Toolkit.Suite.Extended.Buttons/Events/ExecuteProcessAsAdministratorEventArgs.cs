using Krypton.Toolkit.Suite.Extended.Developer.Utilities;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Principal;

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    /// <summary>Handles the user account control event for the <see cref="KryptonUACElevatedButton" />.</summary>
    public class ExecuteProcessAsAdministratorEventArgs : EventArgs
    {
        /// <summary>Gets or sets the process path to execute.</summary>
        /// <value>The process path.</value>
        public string ProcessPath { get; set; }

        public object ObjectToElevate { get; set; }

        /// <summary>Initializes a new instance of the <see cref="ExecuteProcessAsAdministratorEventArgs"/> class.</summary>
        /// <param name="processPath">The process path.</param>
        public ExecuteProcessAsAdministratorEventArgs(string processPath)
        {
            ProcessPath = processPath;

            ElevateProcessWithAdministrativeRights(ProcessPath);
        }

        public ExecuteProcessAsAdministratorEventArgs(object objectToElevate)
        {
            ObjectToElevate = objectToElevate;

            ElevateProcessWithAdministrativeRights(ObjectToElevate);
        }

        private void ElevateProcessWithAdministrativeRights(object objectToElevate)
        {
            WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

            bool hasAdministrativeRights = principal.IsInRole(WindowsBuiltInRole.Administrator);

            //if (object == null)

            if (!hasAdministrativeRights)
            {
                ProcessStartInfo psi = new ProcessStartInfo()
                {
                    Verb = "runas",
                    //Arguments = objectToElevate
                };
            }
        }

        /// <summary>Elevates the process with administrative rights.</summary>
        /// <param name="processName">Name of the process.</param>
        /// <param name="arguments">Extra arguments to execute.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void ElevateProcessWithAdministrativeRights(string processName, string arguments = null)
        {
            WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

            bool hasAdministrativeRights = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (string.IsNullOrEmpty(processName)) throw new ArgumentNullException();

            if (!hasAdministrativeRights)
            {
                ProcessStartInfo process = new ProcessStartInfo()
                {
                    Verb = "runas",
                    Arguments = arguments,
                    FileName = processName
                };

                try
                {
                    Process.Start(process);
                }
                catch (Win32Exception e)
                {
                    ExceptionCapture.CaptureException(e);

                    //KryptonMessageBoxExtended.Show($"Error: { e.Message }", "An Error has Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }
        }
    }
}