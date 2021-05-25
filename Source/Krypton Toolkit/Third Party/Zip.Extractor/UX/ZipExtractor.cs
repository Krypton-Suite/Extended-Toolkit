#region MIT License
/**
 * MIT License
 *
 * Copyright (c) 2012 - 2020 RBSoft
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
 */
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Krypton.Toolkit;

using Zip.Extractor.Properties;
using Zip.Storer;

namespace Zip.Extractor
{
    public class ZipExtractor : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonLabel klblCurentStatus;
        private System.Windows.Forms.ProgressBar pbExtractionProgress;
        private System.Windows.Forms.PictureBox pbxExtractIcon;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZipExtractor));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.pbExtractionProgress = new System.Windows.Forms.ProgressBar();
            this.klblCurentStatus = new Krypton.Toolkit.KryptonLabel();
            this.pbxExtractIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxExtractIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.pbExtractionProgress);
            this.kryptonPanel1.Controls.Add(this.klblCurentStatus);
            this.kryptonPanel1.Controls.Add(this.pbxExtractIcon);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(543, 93);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // pbExtractionProgress
            // 
            this.pbExtractionProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbExtractionProgress.Location = new System.Drawing.Point(0, 88);
            this.pbExtractionProgress.Name = "pbExtractionProgress";
            this.pbExtractionProgress.Size = new System.Drawing.Size(543, 5);
            this.pbExtractionProgress.TabIndex = 3;
            // 
            // klblCurentStatus
            // 
            this.klblCurentStatus.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.klblCurentStatus.Location = new System.Drawing.Point(83, 34);
            this.klblCurentStatus.Name = "klblCurentStatus";
            this.klblCurentStatus.Size = new System.Drawing.Size(94, 20);
            this.klblCurentStatus.TabIndex = 2;
            this.klblCurentStatus.Values.Text = "kryptonLabel1";
            // 
            // pbxExtractIcon
            // 
            this.pbxExtractIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxExtractIcon.Location = new System.Drawing.Point(12, 12);
            this.pbxExtractIcon.Name = "pbxExtractIcon";
            this.pbxExtractIcon.Size = new System.Drawing.Size(64, 64);
            this.pbxExtractIcon.TabIndex = 1;
            this.pbxExtractIcon.TabStop = false;
            // 
            // ZipExtractor
            // 
            this.ClientSize = new System.Drawing.Size(543, 93);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZipExtractor";
            this.ShowInTaskbar = false;
            this.Text = "Zip Extraction";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZipExtractor_FormClosing);
            this.Shown += new System.EventHandler(this.ZipExtractor_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxExtractIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private BackgroundWorker _worker;

        private StringBuilder _logBuilder = new StringBuilder();
        #endregion

        #region Constructor
        public ZipExtractor(Icon appIcon = null, Bitmap applicationIcon = null)
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
                pbxExtractIcon.Image = applicationIcon;
            }
            else
            {
                pbxExtractIcon.SizeMode = PictureBoxSizeMode.CenterImage;

                pbxExtractIcon.Image = Resources.ZipExtractor.ToBitmap();
            }
        }
        #endregion

        #region Event Handlers
        private void ZipExtractor_Shown(object sender, EventArgs e)
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
                        string currentFile = string.Format(Resources.CurrentExtractingFile, entry.FilenameInZip);
                        int progress = (index + 1) * 100 / dir.Count;
                        _worker.ReportProgress(progress, currentFile);

                        _logBuilder.AppendLine($"{currentFile} [{progress}%]");
                    }

                    zip.Close();
                };

                _worker.ProgressChanged += (o, eventArgs) =>
                {
                    pbExtractionProgress.Value = eventArgs.ProgressPercentage;
                    klblCurentStatus.Text = eventArgs.UserState.ToString();
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
                            klblCurentStatus.Text = @"Finished";
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

        private void ZipExtractor_FormClosing(object sender, FormClosingEventArgs e)
        {
            _worker?.CancelAsync();

            _logBuilder.AppendLine();
            
            File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ZipExtractor.log"),
                
            _logBuilder.ToString());
        }
        #endregion

    }
}