using Krypton.Toolkit.Extended.Software.Updater.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;

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
            for (var index = 0; index < args.Length; index++)
            {
                var arg = args[index];
                _logBuilder.AppendLine($"[{index}] {arg}");
            }

            _logBuilder.AppendLine();

            if (args.Length >= 4)
            {
                string executablePath = args[3];

                // Extract all the files.
                _worker = new BackgroundWorker
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true
                };

                _worker.DoWork += (o, eventArgs) =>
                {
                    foreach (var process in Process.GetProcesses())
                    {
                        try
                        {
                            if (process.MainModule.FileName.Equals(executablePath))
                            {
                                _logBuilder.AppendLine("Waiting for application process to exit...");

                                _worker.ReportProgress(0, "Waiting for application to exit...");
                                process.WaitForExit();
                            }
                        }
                        catch (Exception exception)
                        {
                            Debug.WriteLine(exception.Message);
                        }
                    }

                    _logBuilder.AppendLine("BackgroundWorker started successfully.");

                    var path = args[2];

                    // Open an existing zip file for reading.
                    ZipStorer zip = ZipStorer.Open(args[1], FileAccess.Read);

                    // Read the central directory collection.
                    List<ZipStorer.ZipFileEntry> dir = zip.ReadCentralDir();

                    _logBuilder.AppendLine($"Found total of {dir.Count} files and folders inside the zip file.");

                    for (var index = 0; index < dir.Count; index++)
                    {
                        if (_worker.CancellationPending)
                        {
                            eventArgs.Cancel = true;
                            zip.Close();
                            return;
                        }

                        ZipStorer.ZipFileEntry entry = dir[index];
                        zip.ExtractFile(entry, Path.Combine(path, entry.FilenameInZip));
                        string currentFile = string.Format(Resources.CurrentFileExtracting, entry.FilenameInZip);
                        int progress = (index + 1) * 100 / dir.Count;
                        _worker.ReportProgress(progress, currentFile);

                        _logBuilder.AppendLine($"{currentFile} [{progress}%]");
                    }

                    zip.Close();
                };

                _worker.ProgressChanged += (o, eventArgs) =>
                {
                    pbProgress.Value = eventArgs.ProgressPercentage;
                    ktxtInformation.Text = eventArgs.UserState.ToString();
                    //? ktxtInformation.SelectionStart = ktxtInformation.Text.Length;
                    //? ktxtInformation.SelectionLength = 0;
                };

                _worker.RunWorkerCompleted += (o, eventArgs) =>
                {
                    try
                    {
                        if (eventArgs.Error != null)
                        {
                            throw eventArgs.Error;
                        }

                        if (!eventArgs.Cancelled)
                        {
                            ktxtInformation.Text = @"Finished";
                            try
                            {
                                ProcessStartInfo processStartInfo = new ProcessStartInfo(executablePath);
                                if (args.Length > 4)
                                {
                                    processStartInfo.Arguments = args[4];
                                }

                                Process.Start(processStartInfo);

                                _logBuilder.AppendLine("Successfully launched the updated application.");
                            }
                            catch (Win32Exception exception)
                            {
                                if (exception.NativeErrorCode != 1223)
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

                        KryptonMessageBox.Show(exception.Message, exception.GetType().ToString(),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        _logBuilder.AppendLine();
                        Application.Exit();
                    }
                };

                _worker.RunWorkerAsync();
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