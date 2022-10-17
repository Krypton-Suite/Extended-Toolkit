#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    /// <summary>Handles the user account control event for the <see cref="KryptonUACElevatedButton" />.</summary>
    public class ExecuteProcessAsAdministratorEventArgs : EventArgs
    {
        /// <summary></summary>
        public Assembly AssemblyProcess { get; set; }

        /// <summary>Gets or sets the process path to execute.</summary>
        /// <value>The process path.</value>
        public string ProcessPath { get; set; }

        /// <summary>Gets or sets the extra arguments.</summary>
        /// <value>The extra arguments.</value>
        public string ExtraArguments { get; set; }

        /// <summary>Gets or sets the object to elevate.</summary>
        /// <value>The object to elevate.</value>
        public object ObjectToElevate { get; set; }

        public ExecuteProcessAsAdministratorEventArgs(Assembly assemblyProcess)
        {
            AssemblyProcess = assemblyProcess;

            ElevateProcessWithAdministrativeRights(Path.GetFullPath(AssemblyProcess.Location));
        }

        /// <summary>Initializes a new instance of the <see cref="ExecuteProcessAsAdministratorEventArgs"/> class.</summary>
        /// <param name="processPath">The process path.</param>
        public ExecuteProcessAsAdministratorEventArgs(string processPath)
        {
            ProcessPath = processPath;

            ElevateProcessWithAdministrativeRights(ProcessPath);
        }

        /// <summary>Initializes a new instance of the <see cref="ExecuteProcessAsAdministratorEventArgs" /> class.</summary>
        /// <param name="processPath">The process path.</param>
        /// <param name="extraArguments">The extra arguments.</param>
        public ExecuteProcessAsAdministratorEventArgs(string processPath, string extraArguments)
        {
            ProcessPath = processPath;

            ExtraArguments = extraArguments;

            ElevateProcessWithAdministrativeRights(processPath, extraArguments);
        }

        /// <summary>Initializes a new instance of the <see cref="ExecuteProcessAsAdministratorEventArgs" /> class.</summary>
        /// <param name="objectToElevate">The object to elevate.</param>
        public ExecuteProcessAsAdministratorEventArgs(object objectToElevate)
        {
            ObjectToElevate = objectToElevate;

            ElevateProcessWithAdministrativeRights(ObjectToElevate);
        }

        private void ElevateProcessWithAdministrativeRights(object objectToElevate, string arguments = null)
        {
            try
            {
                WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

                bool hasAdministrativeRights = principal.IsInRole(WindowsBuiltInRole.Administrator);

                //if (object == null)

                if (!hasAdministrativeRights)
                {
                    ProcessStartInfo psi = new ProcessStartInfo()
                    {
                        Verb = "runas",
                        Arguments = arguments,
                        //FileName = objectToElevate
                    };
                }
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);
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

            if (MissingFrameWorkAPIs.IsNullOrWhiteSpace(processName)) throw new ArgumentNullException();

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
                }

                return;
            }
        }
    }
}