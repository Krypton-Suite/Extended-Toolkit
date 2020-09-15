using Krypton.Toolkit.Suite.Extended.Base;
using Krypton.Toolkit.Suite.Extended.Common;
using Krypton.Toolkit.Suite.Extended.Software.Updater.Properties;
using Krypton.Toolkit.Suite.Extended.Software.Updater.ZipExtractor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
#if NET45
using System.IO.Compression;
#endif

namespace Krypton.Toolkit.Extended.Software.Updater.ZipExtractor
{
    public class MainWindow : KryptonForm
    {
        #region Design Code
        private System.Windows.Forms.PictureBox pbxIcon;
        private KryptonLabel ktxtInformation;
        private System.Windows.Forms.ProgressBar pbProgress;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.ktxtInformation = new Krypton.Toolkit.KryptonLabel();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.pbxIcon);
            this.kryptonPanel1.Controls.Add(this.ktxtInformation);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(624, 100);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // ktxtInformation
            // 
            this.ktxtInformation.Location = new System.Drawing.Point(69, 27);
            this.ktxtInformation.Name = "ktxtInformation";
            this.ktxtInformation.Size = new System.Drawing.Size(72, 20);
            this.ktxtInformation.TabIndex = 0;
            this.ktxtInformation.Values.Text = "Extracting...";
            // 
            // pbProgress
            // 
            this.pbProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbProgress.Location = new System.Drawing.Point(0, 77);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(624, 23);
            this.pbProgress.TabIndex = 1;
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcon.Location = new System.Drawing.Point(13, 13);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(50, 50);
            this.pbxIcon.TabIndex = 1;
            this.pbxIcon.TabStop = false;
            // 
            // MainWindow
            // 
            this.ClientSize = new System.Drawing.Size(624, 100);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Installing Update ...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private BackgroundWorker _worker;

        private StringBuilder _logBuilder = new StringBuilder();

        private string _executablePath;

        private string[] _arguments;
        #endregion

        #region Constants
        private const int MAX_RETRIES = 2;
        #endregion

        #region Properties
        public string ExecutablePath { get => _executablePath; private set => _executablePath = value; }

        public string[] Arguments { get => _arguments; private set => _arguments = value; }
        #endregion

        #region Constructor
        public MainWindow(Icon appIcon, Bitmap applicationIcon)
        {
            InitializeComponent();

            if (appIcon != null)
            {
                Icon = appIcon;
            }
            else
            {
                Icon = Resources.ZipExtractor;
            }

            if (applicationIcon != null)
            {
                pbxIcon.Image = applicationIcon;
            }
            else
            {
                pbxIcon.SizeMode = PictureBoxSizeMode.CenterImage;

                pbxIcon.Image = Resources.ZipExtractor.ToBitmap();
            }
        }
        #endregion

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            _logBuilder.AppendLine(DateTime.Now.ToString("F"));

            _logBuilder.AppendLine();

            _logBuilder.AppendLine("ZipExtractor started with following command line arguments.");

            string[] args = Environment.GetCommandLineArgs();

            Arguments = args;

            for (var index = 0; index < Arguments.Length; index++)
            {
                var arg = Arguments[index];

                _logBuilder.AppendLine($"[{ index }]: { arg }");
            }

            _logBuilder.AppendLine();

            if (Arguments.Length >= 4)
            {
                string executablePath = Arguments[3];

                ExecutablePath = executablePath;

                _worker = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = true };

                _worker.DoWork += Worker_DoWork;

                _worker.ProgressChanged += Worker_ProgressChanged;

                _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

                _worker.RunWorkerAsync();
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    throw e.Error;
                }

                if (!e.Cancelled)
                {
                    ktxtInformation.Text = @"Finished";

                    try
                    {
                        ProcessStartInfo psi = new ProcessStartInfo(ExecutablePath);

                        if (Arguments.Length >= 4)
                        {
                            psi.Arguments = Arguments[4];
                        }

                        Process.Start(psi);

                        _logBuilder.AppendLine("Successfully launched the updated application.");
                    }
                    catch (Win32Exception exc)
                    {
                        if (exc.ErrorCode != 1223)
                        {
                            throw;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                _logBuilder.AppendLine();

                _logBuilder.AppendLine(exception.ToString());

                KryptonMessageBoxExtended.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _logBuilder.AppendLine();

                Application.Exit();
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbProgress.Value = e.ProgressPercentage;

            ktxtInformation.Text = e.UserState.ToString();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var process in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(ExecutablePath)))
            {
                try
                {
                    if (process.MainModule != null && process.MainModule.FileName.Equals(ExecutablePath))
                    {
                        _logBuilder.AppendLine("Waiting for application process to exit...");

                        _worker.ReportProgress(0, "Waiting for application to exit...");

                        process.WaitForExit();
                    }
                }
                catch (Exception exc)
                {
                    ExceptionHandler.CaptureException(exc);

                    Debug.WriteLine(exc.Message);
                }

                _logBuilder.AppendLine("BackgroundWorker started successfully.");

                var path = Arguments[2];

                // Ensures that the last character on the extraction path
                // is the directory separator char.
                // Without this, a malicious zip file could try to traverse outside of the expected
                // extraction path.
                if (!path.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
                {
                    path += Path.DirectorySeparatorChar;
                }

#if NET45
                var archive = ZipFile.OpenRead(Arguments[1]);

                var entries = archive.Entries;
#else
                var zip = ZipStorer.Open(Arguments[1], FileAccess.Read);

                var entries = zip.ReadCentralDir();
#endif

                _logBuilder.AppendLine($"Found total of { entries.Count } files and folders inside the zip file.");

                try
                {
                    int progress = 0;

                    for (int index = 0; index < entries.Count; index++)
                    {
                        if (_worker.CancellationPending)
                        {
                            e.Cancel = true;

                            break;
                        }

                        var entry = entries[index];

#if NET45
                        string currentFile = string.Format(Resources.CurrentFileExtracting, entry.FullName);
#else
                        string currentFile = string.Format(Resources.CurrentFileExtracting, entry.FilenameInZip);
#endif

                        _worker.ReportProgress(progress, currentFile);

                        int retries = 0;

                        bool notCopied = true;

                        while (notCopied)
                        {
                            string filePath = string.Empty;

                            try
                            {
#if NET45
                                filePath = Path.Combine(path, entry.FullName);

                                if (!entry.IsDirectory())
	                            {
                                    var parentDirectory = Path.GetDirectoryName(filePath);

                                    if (!Directory.Exists(parentDirectory))
                                    {
                                        Directory.CreateDirectory(parentDirectory);
                                    }

                                    entry.ExtractToFile(filePath, true);
	                            }
#else
                                filePath = Path.Combine(path, entry.FilenameInZip);

                                zip.ExtractFile(entry, filePath);
#endif

                                notCopied = false;
                            }
                            catch (IOException ioe)
                            {
                                const int ERROR_SHARING_VIOLATION = 0x20, ERROR_LOCK_VIOLATION = 0x21;

                                var errorCode = Marshal.GetHRForException(ioe) & 0x0000FFFF;

                                if (errorCode == ERROR_SHARING_VIOLATION || errorCode == ERROR_LOCK_VIOLATION)
                                {
                                    retries++;

                                    if (retries > MAX_RETRIES)
                                    {
                                        throw;
                                    }

                                    List<Process> lockingProcesses = null;

                                    if (Environment.OSVersion.Version.Major >= 6 && retries >= 2)
                                    {
                                        try
                                        {
                                            lockingProcesses = Suite.Extended.Software.Updater.ZipExtractor.FileUtilities.WhoIsLocking(filePath);
                                        }
                                        catch (Exception)
                                        {

                                        }
                                    }

                                    if (lockingProcesses == null)
                                    {
                                        Thread.Sleep(5000);
                                    }
                                    else
                                    {
                                        foreach (var lockingProcess in lockingProcesses)
                                        {
                                            var result = KryptonMessageBoxExtended.Show(string.Format(Resources.FileStillInUseMessage, lockingProcess.ProcessName, filePath), Resources.FileStillInUseCaption, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                                            if (result == DialogResult.Cancel)
                                            {
                                                throw;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    throw;
                                }
                            }
                        }

                        progress = (index + 1) * 100 / entries.Count;

                        _worker.ReportProgress(progress, currentFile);

                        _logBuilder.AppendLine($"{ currentFile } [{ progress }%]");
                    }
                }
                finally
                {
#if NET45
                    archive.Dispose();
#else
                    zip.Close();
#endif
                }
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _worker?.CancelAsync();

            _logBuilder.AppendLine();
            File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ZipExtractor.log"),
                _logBuilder.ToString());
        }
    }
}