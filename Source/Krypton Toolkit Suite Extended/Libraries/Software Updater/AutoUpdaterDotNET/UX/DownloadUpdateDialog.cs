#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Software.Updater.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.AutoUpdaterDotNET
{
    internal class DownloadUpdateDialog : KryptonForm
    {
        #region Design Code
        private System.Windows.Forms.ProgressBar pbDownload;
        private System.Windows.Forms.PictureBox pbxIcon;
        private KryptonLabel klblInformation;
        private KryptonLabel klblSize;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadUpdateDialog));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.klblSize = new Krypton.Toolkit.KryptonLabel();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            this.klblInformation = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.klblSize);
            this.kryptonPanel1.Controls.Add(this.pbDownload);
            this.kryptonPanel1.Controls.Add(this.pbxIcon);
            this.kryptonPanel1.Controls.Add(this.klblInformation);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(413, 90);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // klblSize
            // 
            this.klblSize.AutoSize = false;
            this.klblSize.Location = new System.Drawing.Point(266, 12);
            this.klblSize.Name = "klblSize";
            this.klblSize.Size = new System.Drawing.Size(135, 20);
            this.klblSize.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblSize.TabIndex = 4;
            this.klblSize.Values.Text = "";
            // 
            // pbDownload
            // 
            this.pbDownload.Location = new System.Drawing.Point(77, 41);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(324, 23);
            this.pbDownload.TabIndex = 3;
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcon.ErrorImage = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.download_32;
            this.pbxIcon.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.download_32;
            this.pbxIcon.InitialImage = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.download_32;
            this.pbxIcon.Location = new System.Drawing.Point(12, 12);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(59, 62);
            this.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxIcon.TabIndex = 2;
            this.pbxIcon.TabStop = false;
            // 
            // klblInformation
            // 
            this.klblInformation.Location = new System.Drawing.Point(77, 12);
            this.klblInformation.Name = "klblInformation";
            this.klblInformation.Size = new System.Drawing.Size(135, 20);
            this.klblInformation.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblInformation.TabIndex = 1;
            this.klblInformation.Values.Text = "Downloading Update...";
            // 
            // DownloadUpdateDialog
            // 
            this.ClientSize = new System.Drawing.Size(413, 90);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloadUpdateDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Software Update";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadUpdateDialog_FormClosing);
            this.Load += new System.EventHandler(this.DownloadUpdateDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private readonly UpdateInfoEventArgs _args;

        private string _tempFile;

        private MyWebClient _webClient;

        private DateTime _startedAt;
        #endregion

        #region Constructor
        public DownloadUpdateDialog(UpdateInfoEventArgs args)
        {
            InitializeComponent();

            _args = args;

            if (AutoUpdater.Mandatory && AutoUpdater.UpdateMode == Mode.FORCEDDOWNLOAD)
            {
                ControlBox = false;
            }
        }
        #endregion

        private void DownloadUpdateDialog_Load(object sender, EventArgs e)
        {
            var uri = new Uri(_args.DownloadURL);

            _webClient = AutoUpdater.GetWebClient(uri, AutoUpdater.BasicAuthDownload);

            if (string.IsNullOrEmpty(AutoUpdater.DownloadPath))
            {
                _tempFile = Path.GetTempFileName();
            }
            else
            {
                _tempFile = Path.Combine(AutoUpdater.DownloadPath, $"{Guid.NewGuid().ToString()}.tmp");
                if (!Directory.Exists(AutoUpdater.DownloadPath))
                {
                    Directory.CreateDirectory(AutoUpdater.DownloadPath);
                }
            }

            _webClient.DownloadProgressChanged += OnDownloadProgressChanged;

            _webClient.DownloadFileCompleted += WebClientOnDownloadFileCompleted;

            _webClient.DownloadFileAsync(uri, _tempFile);
        }

        private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (_startedAt == default(DateTime))
            {
                _startedAt = DateTime.Now;
            }
            else
            {
                var timeSpan = DateTime.Now - _startedAt;
                long totalSeconds = (long)timeSpan.TotalSeconds;
                if (totalSeconds > 0)
                {
                    var bytesPerSecond = e.BytesReceived / totalSeconds;
                    klblInformation.Text =
                        string.Format(Resources.DownloadSpeedMessage, BytesToString(bytesPerSecond));
                }
            }

            klblSize.Text = $@"{BytesToString(e.BytesReceived)} / {BytesToString(e.TotalBytesToReceive)}";
            pbDownload.Value = e.ProgressPercentage;
        }

        private void WebClientOnDownloadFileCompleted(object sender, AsyncCompletedEventArgs asyncCompletedEventArgs)
        {
            if (asyncCompletedEventArgs.Cancelled)
            {
                return;
            }

            try
            {
                if (asyncCompletedEventArgs.Error != null)
                {
                    throw asyncCompletedEventArgs.Error;
                }

                if (_args.CheckSum != null)
                {
                    CompareChecksum(_tempFile, _args.CheckSum);
                }

                ContentDisposition contentDisposition = null;
                if (_webClient.ResponseHeaders["Content-Disposition"] != null)
                {
                    contentDisposition = new ContentDisposition(_webClient.ResponseHeaders["Content-Disposition"]);
                }

                var fileName = string.IsNullOrEmpty(contentDisposition?.FileName)
                    ? Path.GetFileName(_webClient.ResponseUri.LocalPath)
                    : contentDisposition.FileName;

                var tempPath =
                    Path.Combine(
                        string.IsNullOrEmpty(AutoUpdater.DownloadPath) ? Path.GetTempPath() : AutoUpdater.DownloadPath,
                        fileName);

                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }

                File.Move(_tempFile, tempPath);

                string installerArgs = null;
                if (!string.IsNullOrEmpty(_args.InstallerArgs))
                {
                    installerArgs = _args.InstallerArgs.Replace("%path%",
                        Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName));
                }

                var processStartInfo = new ProcessStartInfo
                {
                    FileName = tempPath,
                    UseShellExecute = true,
                    Arguments = installerArgs
                };

                var extension = Path.GetExtension(tempPath);
                if (extension.Equals(".zip", StringComparison.OrdinalIgnoreCase))
                {
                    string installerPath = Path.Combine(Path.GetDirectoryName(tempPath), "ZipExtractor.exe");

                    File.WriteAllBytes(installerPath, Resources.Zip_Extractor);

                    string executablePath = Process.GetCurrentProcess().MainModule.FileName;
                    string extractionPath = Path.GetDirectoryName(executablePath);

                    if (!string.IsNullOrEmpty(AutoUpdater.InstallationPath) &&
                        Directory.Exists(AutoUpdater.InstallationPath))
                    {
                        extractionPath = AutoUpdater.InstallationPath;
                    }

                    StringBuilder arguments =
                        new StringBuilder($"\"{tempPath}\" \"{extractionPath}\" \"{executablePath}\"");
                    string[] args = Environment.GetCommandLineArgs();
                    for (int i = 1; i < args.Length; i++)
                    {
                        if (i.Equals(1))
                        {
                            arguments.Append(" \"");
                        }

                        arguments.Append(args[i]);
                        arguments.Append(i.Equals(args.Length - 1) ? "\"" : " ");
                    }

                    processStartInfo = new ProcessStartInfo
                    {
                        FileName = installerPath,
                        UseShellExecute = true,
                        Arguments = arguments.ToString()
                    };
                }
                else if (extension.Equals(".msi", StringComparison.OrdinalIgnoreCase))
                {
                    processStartInfo = new ProcessStartInfo
                    {
                        FileName = "msiexec",
                        Arguments = $"/i \"{tempPath}\""
                    };
                    if (!string.IsNullOrEmpty(installerArgs))
                    {
                        processStartInfo.Arguments += " " + installerArgs;
                    }
                }

                if (AutoUpdater.RunUpdateAsAdmin)
                {
                    processStartInfo.Verb = "runas";
                }

                try
                {
                    Process.Start(processStartInfo);
                }
                catch (Win32Exception exception)
                {
                    if (exception.NativeErrorCode == 1223)
                    {
                        _webClient = null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                KryptonMessageBox.Show(e.Message, e.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                _webClient = null;
            }
            finally
            {
                Close();
            }
        }

        private static string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return $"{(Math.Sign(byteCount) * num).ToString(CultureInfo.InvariantCulture)} {suf[place]}";
        }

        private static void CompareChecksum(string fileName, CheckSum checksum)
        {
            using (var hashAlgorithm =
                HashAlgorithm.Create(string.IsNullOrEmpty(checksum.HashingAlgorithm) ? "MD5" : checksum.HashingAlgorithm))
            {
                using (var stream = File.OpenRead(fileName))
                {
                    if (hashAlgorithm != null)
                    {
                        var hash = hashAlgorithm.ComputeHash(stream);
                        var fileChecksum = BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();

                        if (fileChecksum == checksum.Value.ToLower()) return;

                        throw new Exception(Resources.FileIntegrityCheckFailedMessage);
                    }

                    throw new Exception(Resources.HashAlgorithmNotSupportedMessage);
                }
            }
        }

        private void DownloadUpdateDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_webClient == null)
            {
                DialogResult = DialogResult.Cancel;
            }
            else if (_webClient.IsBusy)
            {
                _webClient.CancelAsync();
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}