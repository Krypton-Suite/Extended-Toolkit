﻿#region MIT License
/*
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

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>Handles the user account control event for the <see cref="T:KryptonUACElevatedButton" />.</summary>
    public class ExecuteProcessAsAdministratorEventArgs : EventArgs
    {
        /// <summary></summary>
        public Assembly AssemblyProcess { get; set; }

        /// <summary>Gets or sets the process path to execute.</summary>
        /// <value>The process path.</value>
        public string? ProcessPath { get; set; }

        /// <summary>Gets or sets the extra arguments.</summary>
        /// <value>The extra arguments.</value>
        public string? ExtraArguments { get; set; }

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
        public ExecuteProcessAsAdministratorEventArgs(string? processPath)
        {
            ProcessPath = processPath;

            ElevateProcessWithAdministrativeRights(ProcessPath);
        }

        /// <summary>Initializes a new instance of the <see cref="ExecuteProcessAsAdministratorEventArgs" /> class.</summary>
        /// <param name="processPath">The process path.</param>
        /// <param name="extraArguments">The extra arguments.</param>
        public ExecuteProcessAsAdministratorEventArgs(string? processPath, string? extraArguments)
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

        /// <summary>Elevates the process with administrative rights.</summary>
        /// <param name="objectToElevate">The object to elevate.</param>
        /// <param name="arguments">The arguments.</param>
        private void ElevateProcessWithAdministrativeRights(object objectToElevate, string? arguments = null)
        {
            try
            {
                WindowsPrincipal principal = new(WindowsIdentity.GetCurrent());

                bool hasAdministrativeRights = principal.IsInRole(WindowsBuiltInRole.Administrator);

                //if (object == null)

                if (!hasAdministrativeRights)
                {
                    ProcessStartInfo psi = new()
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
        public void ElevateProcessWithAdministrativeRights(string? processName, string? arguments = null)
        {
            WindowsPrincipal principal = new(WindowsIdentity.GetCurrent());

            bool hasAdministrativeRights = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (string.IsNullOrWhiteSpace(processName))
            {
                throw new ArgumentNullException();
            }

            if (!hasAdministrativeRights)
            {
                ProcessStartInfo process = new()
                {
                    Verb = "runas",
                    Arguments = arguments,
                    FileName = processName
                };

                try
                {
                    GlobalToolkitUtilities.LaunchProcess(process);
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