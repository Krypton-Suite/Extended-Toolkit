#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.SharpUpdate
{
    /// <summary>
    /// Provides application update support in C#
    /// </summary>
    public class SharpUpdater : IDisposable
    {
        /// <summary>
        /// Holds the program-to-update's info
        /// </summary>
        private ISharpUpdatable applicationInfo;

        /// <summary>
        /// Thread to find update
        /// </summary>
        private BackgroundWorker bgWorker;

        private bool doUpdate;

        /// Creates a new SharpUpdater object
        /// </summary>
        /// <param name="applicationInfo">The info about the application so it can be displayed on dialog boxes to user</param>
        /// <param name="doUpdate">Set weather the update should be applied or show ony</param>
        public SharpUpdater(ISharpUpdatable applicationInfo, bool doUpdate = true)
        {
            this.applicationInfo = applicationInfo;
            this.doUpdate = doUpdate;

            // Set up backgroundworker
            this.bgWorker = new BackgroundWorker();
            this.bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
        }

        /// <summary>
        /// Checks for an update for the program passed.
        /// If there is an update, a dialog asking to download will appear
        /// </summary>
        public void DoUpdate()
        {
            if (!this.bgWorker.IsBusy)
                this.bgWorker.RunWorkerAsync(this.applicationInfo);
        }

        /// <summary>
        /// Checks for/parses update.xml on server
        /// </summary>
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ISharpUpdatable application = (ISharpUpdatable)e.Argument;

            // Check for update on server
            if (!SharpUpdateXML.ExistsOnServer(application.UpdateXmlLocation))
                e.Cancel = true;
            else // Parse update xml
                e.Result = SharpUpdateXML.Parse(application.UpdateXmlLocation, application.ApplicationID);
        }

        /// <summary>
        /// Get the drirectory of the application
        /// </summary>
        /// <returns>Full path to the application to update</returns>
        private string AssemblyDirectory()
        {
            //get the full location of the assembly with DaoTests in it
            string fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            //get the folder that's in
            return Path.GetDirectoryName(fullPath);
        }

        /// <summary>
        /// After the background worker is done, prompt to update if there is one
        /// </summary>
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // If there is a file on the server
            if (!e.Cancelled)
            {
                SharpUpdateXML update = (SharpUpdateXML)e.Result;

                // Check if the update is not null and is a newer version than the current application
                if (update != null)
                {
                    //Check for missing files
                    if (!update.HasAllFiles(AssemblyDirectory()))
                        this.DownloadUpdate(update);
                    else if (update.IsNewerThan(this.applicationInfo.ApplicationAssembly.GetName().Version))
                    {
                        // Ask to accept the update
                        if (new SharpUpdateAcceptDialog(this.applicationInfo, update).ShowDialog(this.applicationInfo.Context) == DialogResult.Yes)
                        {
                            if (doUpdate)
                                this.DownloadUpdate(update); // Do the update                            
                            else
                            {//This is not the only instance
                                KryptonMessageBox.Show(Language.LanguageEN.SharpUpdater_DoubleInstanceWarning,
                                                Language.LanguageEN.SharpUpdater_DoubleInstanceWarningTitle,
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Downloads update and installs the update
        /// </summary>
        /// <param name="update">The update xml info</param>
        private void DownloadUpdate(SharpUpdateXML update)
        {
            SharpUpdateDownloadDialog form = new SharpUpdateDownloadDialog(update.UpdateFiles, this.applicationInfo.ApplicationIcon);
            DialogResult result = form.ShowDialog(this.applicationInfo.Context);

            // Download update
            if (result == DialogResult.OK)
            {
                string currentPath = this.applicationInfo.ApplicationAssembly.Location;
                // "Install" it
                UpdateApplication(form.TempFilesPath, currentPath, update.LaunchArgs);

                Application.Exit();
            }
            else if (result == DialogResult.Abort)
            {
                KryptonMessageBox.Show(Language.LanguageEN.SharpUpdater_DownloadCancelled, Language.LanguageEN.SharpUpdater_DownloadCancelledTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                KryptonMessageBox.Show(Language.LanguageEN.SharpUpdater_DownloadProblem, Language.LanguageEN.SharpUpdater_DownloadProblemTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Hack to close program, delete original, move the new one to that location
        /// </summary>
        /// <param name="tempFilePath">The temporary file's path</param>
        /// <param name="currentPath">The path of the current application</param>
        /// <param name="launchArgs">The launch arguments</param>
        private void UpdateApplication(List<SharpUpdateFileInfo> tempFilePath, string currentPath, string launchArgs)
        {
            //Wait 4 seceonds to close the application
            string argument = "/C choice /C Y /N /D Y /T 4 & ";

            //Delete all file that will be updated
            foreach (SharpUpdateFileInfo fi in tempFilePath)
            {
                argument += string.Format("Del /F /Q \"{0}\" & ", Path.GetDirectoryName(currentPath) + "\\" + fi.FileName);
            }

            //Wait 2 seconds
            argument += "choice /C Y /N /D Y /T 2 & ";

            //Move all downloaded files from temporarily path to installed path 
            foreach (SharpUpdateFileInfo fi in tempFilePath)
            {
                argument += string.Format("Move /Y \"{0}\" \"{1}\" & ", fi.TempFile, Path.GetDirectoryName(currentPath) + "\\" + fi.FileName);
            }

            //Start the application after updateing all files
            argument += "Start \"\" /D \"{0}\" \"{1}\" {2}";

            //Start the process to do above tasks
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = String.Format(argument, Path.GetDirectoryName(currentPath), Path.GetFileName(tempFilePath[0].FileName), launchArgs);
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            Process.Start(Info);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (bgWorker.IsBusy)
                bgWorker.CancelAsync();
        }
    }
}