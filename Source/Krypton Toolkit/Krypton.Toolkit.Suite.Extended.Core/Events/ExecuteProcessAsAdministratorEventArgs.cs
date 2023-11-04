#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class ExecuteProcessAsAdministratorEventArgs : EventArgs
    {
        /// <summary>Gets or sets the process path.</summary>
        /// <value>The process path.</value>
        public string ProcessPath { get; set; }

        /// <summary>Initializes a new instance of the <see cref="ExecuteProcessAsAdministratorEventArgs"/> class.</summary>
        /// <param name="processPath">The process path.</param>
        public ExecuteProcessAsAdministratorEventArgs(string processPath)
        {
            ProcessPath = processPath;

            ElevateProcessWithAdministrativeRights(ProcessPath);
        }

        /// <summary>Elevates the process with administrative rights.</summary>
        /// <param name="processName">Name of the process.</param>
        /// <exception cref="ArgumentNullException"></exception>
        private void ElevateProcessWithAdministrativeRights(string processName)
        {
            WindowsPrincipal principal = new(WindowsIdentity.GetCurrent());

            bool hasAdministrativeRights = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (string.IsNullOrEmpty(processName))
            {
                throw new ArgumentNullException();
            }

            if (!hasAdministrativeRights)
            {
                ProcessStartInfo process = new();

                process.Verb = "runas";

                process.FileName = processName;

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