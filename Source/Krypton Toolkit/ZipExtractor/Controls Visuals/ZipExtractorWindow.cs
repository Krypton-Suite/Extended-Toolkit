namespace ZipExtractor
{
    public partial class ZipExtractorWindow : KryptonForm
    {
        #region Instance Fields

        private bool _clearApplicationDirectory;

        private readonly StringBuilder _logBuilder;

        private string _zipPath;

        private string _extractionPath;

        private string _currentExe;

        private string _updatedExe;

        private string _commandLineArgs;

        #endregion

        #region Constants

        private const int MAXIMUM_RETRIES = 2;

        #endregion

        #region Identity

        public ZipExtractorWindow()
        {
            InitializeComponent();

            _logBuilder = new();
        }

        #endregion

        private void ZipExtractorWindow_Shown(object sender, EventArgs e)
        {
            // Set up fields
            _clearApplicationDirectory = false;

            _commandLineArgs = string.Empty;

            _currentExe = string.Empty;

            _extractionPath = string.Empty;

            _updatedExe = string.Empty;

            _zipPath = string.Empty;

            _logBuilder.AppendLine(DateTime.Now.ToString(@"F"));

            _logBuilder.AppendLine();

            _logBuilder.AppendLine(@"ZipExtractor started with following command line arguments.");

            string[] args = Environment.GetCommandLineArgs();

            for (var index = 0; index < args.Length; index++)
            {
                string arg = args[index].ToLower();
                switch (arg)
                {
                    case "--input":
                        _zipPath = args[index + 1];
                        break;
                    case "--output":
                        _extractionPath = args[index + 1];
                        break;
                    case "--current-exe":
                        _currentExe = args[index + 1];
                        break;
                    case "--updated-exe":
                        _updatedExe = args[index + 1];
                        break;
                    case "--clear":
                        _clearApplicationDirectory = true;
                        break;
                    case "--args":
                        _commandLineArgs = args[index + 1];
                        break;
                }

                _logBuilder.AppendLine($"[{index}] {arg}");
            }

            _logBuilder.AppendLine();

            if (string.IsNullOrEmpty(_zipPath) || string.IsNullOrEmpty(_extractionPath) || string.IsNullOrEmpty(_currentExe))
            {
                return;
            }

            bgwLoadWorker.RunWorkerAsync();
        }

        private void bgwLoadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentExe))
            {
                foreach (Process process in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(_currentExe)))
                {
                    try
                    {
                        if (process.MainModule is { FileName: not null } && process.MainModule.FileName.Equals(_currentExe))
                        {
                            _logBuilder.AppendLine("Waiting for application process to exit...");

                            bgwLoadWorker.ReportProgress(0, "Waiting for application to exit...");

                            process.WaitForExit();
                        }
                    }
                    catch (Exception exception)
                    {
                        ExceptionCapture.CaptureException(exception);
                    }
                }

                _logBuilder.AppendLine("BackgroundWorker started successfully.");

                // Ensures that the last character on the extraction path
                // is the directory separator char.
                // Without this, a malicious zip file could try to traverse outside of the expected
                // extraction path.
                if (!_extractionPath.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
                {
                    _extractionPath += Path.DirectorySeparatorChar;
                }

                ZipArchive archive = ZipFile.OpenRead(_zipPath);

                ReadOnlyCollection<ZipArchiveEntry> entries = archive.Entries;

                try
                {
                    var progress = 0;

                    if (_clearApplicationDirectory)
                    {
                        _logBuilder.AppendLine($"Removing all files and folders from \"{_extractionPath}\".");
                        var directoryInfo = new DirectoryInfo(_extractionPath);

                        foreach (FileInfo file in directoryInfo.GetFiles())
                        {
                            _logBuilder.AppendLine($"Removing a file located at \"{file.FullName}\".");
                            bgwLoadWorker.ReportProgress(0, string.Format(ZipExtractorLanguageManager.ExtractorStrings.Removing, file.FullName));
                            file.Delete();
                        }

                        foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
                        {
                            _logBuilder.AppendLine(
                                $"Removing a directory located at \"{directory.FullName}\" and all its contents.");
                            bgwLoadWorker.ReportProgress(0, string.Format(ZipExtractorLanguageManager.ExtractorStrings.Removing, directory.FullName));
                            directory.Delete(true);
                        }
                    }

                    _logBuilder.AppendLine($"Found total of {entries.Count} files and folders inside the zip file.");

                    for (var index = 0; index < entries.Count; index++)
                    {
                        if (bgwLoadWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }

                        ZipArchiveEntry entry = entries[index];

                        string currentFile = string.Format(ZipExtractorLanguageManager.ExtractorStrings.CurrentFileExtracting, entry.FullName);
                        bgwLoadWorker.ReportProgress(progress, currentFile);
                        var retries = 0;
                        var notCopied = true;
                        while (notCopied)
                        {
                            var filePath = string.Empty;
                            try
                            {
                                filePath = Path.Combine(_extractionPath, entry.FullName);
                                if (!entry.IsDirectory())
                                {
                                    string? parentDirectory = Path.GetDirectoryName(filePath);
                                    if (parentDirectory != null)
                                    {
                                        if (!Directory.Exists(parentDirectory))
                                        {
                                            Directory.CreateDirectory(parentDirectory);
                                        }
                                    }
                                    else
                                    {
                                        throw new ArgumentNullException($"parentDirectory is null for \"{filePath}\"!");
                                    }

                                    using (Stream destination = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write,
                                               FileShare.None))
                                    {
                                        using Stream stream = entry.Open();
                                        stream.CopyTo(destination);
                                        destination.SetLength(destination.Position);
                                    }

                                    File.SetLastWriteTime(filePath, entry.LastWriteTime.DateTime);
                                }

                                notCopied = false;
                            }
                            catch (IOException exception)
                            {
                                const int errorSharingViolation = 0x20;
                                const int errorLockViolation = 0x21;
                                int errorCode = Marshal.GetHRForException(exception) & 0x0000FFFF;
                                if (errorCode is not (errorSharingViolation or errorLockViolation))
                                {
                                    throw;
                                }

                                retries++;
                                if (retries > MAXIMUM_RETRIES)
                                {
                                    throw;
                                }

                                List<Process>? lockingProcesses = null;
                                if (Environment.OSVersion.Version.Major >= 6 && retries >= 2)
                                {
                                    try
                                    {
                                        lockingProcesses = FileUtilities.WhoIsLocking(filePath);
                                    }
                                    catch (Exception)
                                    {
                                        // ignored
                                    }
                                }

                                if (lockingProcesses == null)
                                {
                                    Thread.Sleep(5000);
                                    continue;
                                }

                                foreach (Process lockingProcess in lockingProcesses)
                                {
                                    DialogResult dialogResult = KryptonMessageBox.Show(this,
                                        string.Format(ZipExtractorLanguageManager.ExtractorStrings.FileStillInUseMessage,
                                            lockingProcess.ProcessName, filePath),
                                        ZipExtractorLanguageManager.ExtractorStrings.FileStillInUseCaption,
                                        KryptonMessageBoxButtons.RetryCancel, KryptonMessageBoxIcon.Error);

                                    if (dialogResult == DialogResult.Cancel)
                                    {
                                        throw;
                                    }
                                }
                            }
                        }

                        progress = (index + 1) * 100 / entries.Count;
                        bgwLoadWorker.ReportProgress(progress, currentFile);

                        _logBuilder.AppendLine($"{currentFile} [{progress}%]");
                    }
                }
                finally
                {
                    archive.Dispose();
                }
            }
        }

        private void bgwLoadWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            kpbExtractingProgress.Value = e.ProgressPercentage;

            kwlHeader.Text = e.UserState?.ToString();

            if (string.IsNullOrEmpty(kwlHeader.Text))
            {
                return;
            }
        }

        private void bgwLoadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    throw e.Error;
                }

                if (e.Cancelled)
                {
                    return;
                }

                kwlHeader.Text = ZipExtractorLanguageManager.ExtractorStrings.Finished;

                try
                {
                    string executablePath = string.IsNullOrWhiteSpace(_updatedExe)
                        ? _currentExe
                        : Path.Combine(_extractionPath, _updatedExe);
                    var processStartInfo = new ProcessStartInfo(executablePath);
                    if (!string.IsNullOrEmpty(_commandLineArgs))
                    {
                        processStartInfo.Arguments = _commandLineArgs;
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
            catch (Exception exception)
            {
                _logBuilder.AppendLine();

                _logBuilder.AppendLine(exception.ToString());

                ExceptionCapture.CaptureException(exception);
            }
            finally
            {
                _logBuilder.AppendLine();

                Application.Exit();
            }
        }

        private void ZipExtractorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            bgwLoadWorker?.CancelAsync();

            File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ZipExtractor.log"), _logBuilder.ToString());
        }
    }
}