namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    public partial class DownloadUpdateDialog : KryptonForm
    {
        #region Instance Fields

        private readonly UpdateInfoEventArgs _updateInfo;

        private DateTime _startTime;

        private string _tempFile;

        private MyWebClient _webClient;

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="DownloadUpdateDialog" /> class.</summary>
        /// <param name="args">The <see cref="UpdateInfoEventArgs" /> instance containing the event data.</param>
        public DownloadUpdateDialog(UpdateInfoEventArgs args)
        {
            InitializeComponent();

            _updateInfo = args;

            TopMost = AutoUpdater.TopMost;

            if (AutoUpdater.Icon != null)
            {
                Icon = Icon.FromHandle(AutoUpdater.Icon.GetHicon());
            }

            if (AutoUpdater.Mandatory && AutoUpdater.UpdateMode == Mode.ForcedDownload)
            {
                ControlBox = false;
            }
        }


        #endregion

        #region Implementation

        private void DownloadUpdateDialog_Load(object sender, EventArgs e)
        {
            var uri = new Uri(_updateInfo.DownloadURL);

            _webClient = AutoUpdater.GetWebClient(uri, AutoUpdater.BasicAuthDownload);

            if (string.IsNullOrEmpty(AutoUpdater.DownloadPath))
            {
                _tempFile = Path.GetTempFileName();
            }
            else
            {
                _tempFile = Path.Combine(AutoUpdater.DownloadPath, $"{Guid.NewGuid()}.tmp");
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
            if (_startTime == default)
            {
                _startTime = DateTime.Now;
            }
            else
            {
                TimeSpan timeSpan = DateTime.Now - _startTime;
                var totalSeconds = (long)timeSpan.TotalSeconds;
                if (totalSeconds > 0)
                {
                    long bytesPerSecond = e.BytesReceived / totalSeconds;
                    kwlInformation.Text =
                        string.Format(AutoUpdaterLanguageManager.UpdaterStrings.DownloadSpeedMessage, BytesToString(bytesPerSecond));
                }
            }

            kwlSize.Text = $@"{BytesToString(e.BytesReceived)} / {BytesToString(e.TotalBytesToReceive)}";
            kpbDownloadProgress.Value = e.ProgressPercentage;
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

                if (_updateInfo.CheckSum != null)
                {
                    CompareChecksum(_tempFile, _updateInfo.CheckSum);
                }

                // Try to parse the content disposition header if it exists.
                ContentDisposition contentDisposition = null;
                if (!string.IsNullOrWhiteSpace(_webClient.ResponseHeaders?["Content-Disposition"]))
                {
                    try
                    {
                        contentDisposition =
                            new ContentDisposition(_webClient.ResponseHeaders["Content-Disposition"]);
                    }
                    catch (FormatException)
                    {
                        // Ignore content disposition header if it is wrongly formatted.
                        contentDisposition = null;
                    }
                }

                string fileName = string.IsNullOrEmpty(contentDisposition?.FileName)
                    ? Path.GetFileName(_webClient.ResponseUri.LocalPath)
                    : contentDisposition.FileName;

                if (string.IsNullOrWhiteSpace(fileName))
                {
                    throw new WebException(AutoUpdaterLanguageManager.UpdaterStrings.UnableToDetermineFilenameMessage);
                }

                string tempPath =
                    Path.Combine(
                        string.IsNullOrEmpty(AutoUpdater.DownloadPath)
                            ? Path.GetTempPath()
                            : AutoUpdater.DownloadPath,
                        fileName);

                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }

                File.Move(_tempFile, tempPath);

                string? installerArgs = null;
                if (!string.IsNullOrEmpty(_updateInfo.InstallerArgs))
                {
                    installerArgs = _updateInfo.InstallerArgs.Replace("%path%",
                        Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName));
                }

                var processStartInfo = new ProcessStartInfo
                {
                    FileName = tempPath,
                    UseShellExecute = true,
                    Arguments = installerArgs ?? string.Empty
                };

                string extension = Path.GetExtension(tempPath);
                if (extension.Equals(".zip", StringComparison.OrdinalIgnoreCase))
                {
                    string installerPath =
                        Path.Combine(Path.GetDirectoryName(tempPath) ?? throw new InvalidOperationException(),
                            "ZipExtractor.exe");

                    File.WriteAllBytes(installerPath, Resources.ZipExtractor1);

                    string? currentExe = Process.GetCurrentProcess().MainModule?.FileName;
                    string? updatedExe = _updateInfo.ExecutablePath;
                    string? extractionPath = Path.GetDirectoryName(currentExe);

                    if (string.IsNullOrWhiteSpace(updatedExe) &&
                        !string.IsNullOrWhiteSpace(AutoUpdater.ExecutablePath))
                    {
                        updatedExe = AutoUpdater.ExecutablePath;
                    }

                    if (!string.IsNullOrWhiteSpace(AutoUpdater.InstallationPath) &&
                        Directory.Exists(AutoUpdater.InstallationPath))
                    {
                        extractionPath = AutoUpdater.InstallationPath;
                    }

                    processStartInfo = new ProcessStartInfo
                    {
                        FileName = installerPath,
                        UseShellExecute = true
                    };

                    var arguments = new Collection<string?>
                    {
                        "--input",
                        tempPath,
                        "--output",
                        extractionPath,
                        "--current-exe",
                        currentExe
                    };

                    if (!string.IsNullOrWhiteSpace(updatedExe))
                    {
                        arguments.Add("--updated-exe");
                        arguments.Add(updatedExe);
                    }

                    if (AutoUpdater.ClearAppDirectory)
                    {
                        arguments.Add("--clear");
                    }

                    string[] args = Environment.GetCommandLineArgs();
                    if (args.Length > 1)
                    {
                        arguments.Add("--args");
                        arguments.Add(string.Join(" ", args.Skip(1).Select(arg => $"\"{arg}\"")));
                    }

                    processStartInfo.Arguments = Utilities.BuildArguments(arguments);
                }
                else if (extension.Equals(".msi", StringComparison.OrdinalIgnoreCase))
                {
                    processStartInfo = new ProcessStartInfo
                    {
                        FileName = "msiexec"
                    };

                    var arguments = new Collection<string?>
                    {
                        "/i",
                        tempPath
                    };

                    if (!string.IsNullOrEmpty(installerArgs))
                    {
                        arguments.Add(installerArgs);
                    }

                    processStartInfo.Arguments = Utilities.BuildArguments(arguments);
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
                KryptonMessageBox.Show(this, e.Message, e.GetType().ToString(), KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon.Error);
                _webClient = null;
            }
            finally
            {
                DialogResult = _webClient == null ? DialogResult.Cancel : DialogResult.OK;
                FormClosing -= DownloadUpdateDialog_FormClosing;
                Close();
            }
        }

        private static string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0)
            {
                return "0" + suf[0];
            }

            long bytes = Math.Abs(byteCount);
            var place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return $"{(Math.Sign(byteCount) * num).ToString(CultureInfo.InvariantCulture)} {suf[place]}";
        }

        private static void CompareChecksum(string fileName, CheckSum checksum)
        {
            using var hashAlgorithm =
                HashAlgorithm.Create(
                    string.IsNullOrEmpty(checksum.HashingAlgorithm) ? "MD5" : checksum.HashingAlgorithm);
            using FileStream stream = File.OpenRead(fileName);

            if (hashAlgorithm == null)
            {
                throw new Exception(AutoUpdaterLanguageManager.UpdaterStrings.HashAlgorithmNotSupportedMessage);
            }

            byte[] hash = hashAlgorithm.ComputeHash(stream);
            string fileChecksum = BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();

            if (fileChecksum == checksum.Value.ToLower())
            {
                return;
            }

            throw new Exception(AutoUpdaterLanguageManager.UpdaterStrings.FileIntegrityCheckFailedMessage);
        }

        private void DownloadUpdateDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AutoUpdater.Mandatory && AutoUpdater.UpdateMode == Mode.ForcedDownload)
            {
                AutoUpdater.Exit();
                return;
            }

            if (_webClient is not { IsBusy: true })
            {
                return;
            }

            _webClient.CancelAsync();
            DialogResult = DialogResult.Cancel;
        }

        #endregion

    }
}