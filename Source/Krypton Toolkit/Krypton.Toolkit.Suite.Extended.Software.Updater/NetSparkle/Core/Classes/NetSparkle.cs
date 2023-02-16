﻿#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    /// <summary>
    /// Class to communicate with a sparkle-based appcast to download
    /// and install updates to an application
    /// </summary>
    public partial class SparkleUpdater : IDisposable
    {
        #region Protected/Private Members

        /// <summary>
        /// The <see cref="Process"/> responsible for launching the downloaded update.
        /// Only valid once the application is about to quit and the update is going to
        /// be launched.
        /// </summary>
        protected Process _installerProcess;

        private LogWriter _logWriter;
        private readonly Task _taskWorker;
        private CancellationToken _cancelToken;
        private readonly CancellationTokenSource _cancelTokenSource;
        private readonly SynchronizationContext _syncContext;
        private readonly string _appReferenceAssembly;

        private bool _doInitialCheck;
        private bool _forceInitialCheck;

        private readonly EventWaitHandle _exitHandle;
        private readonly EventWaitHandle _loopingHandle;
        private TimeSpan _checkFrequency;
        private string _tmpDownloadFilePath;
        private string _downloadTempFileName;
        private AppCastItem _itemBeingDownloaded;
        private bool _hasAttemptedFileRedownload;
        private UpdateInfo _latestDownloadedUpdateInfo;
        private IUIFactory _uiFactory;
        private bool _disposed;
        private Configuration _configuration;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SparkleUpdater"/> class with the given appcast URL
        /// </summary>
        /// <param name="appcastUrl">the URL of the appcast file</param>
        public SparkleUpdater(string appcastUrl)
            : this(appcastUrl, SecurityMode.Strict, null)
        { }

        /// <summary>
        /// ctor which needs the appcast url
        /// </summary>
        /// <param name="appcastUrl">the URL of the appcast file</param>
        /// <param name="securityMode">the security mode to be used when checking DSA signatures</param>
        public SparkleUpdater(string appcastUrl, SecurityMode securityMode)
            : this(appcastUrl, securityMode, null)
        { }

        /// <summary>
        /// ctor which needs the appcast url
        /// </summary>
        /// <param name="appcastUrl">the URL of the appcast file</param>
        /// <param name="securityMode">the security mode to be used when checking DSA signatures</param>
        /// <param name="dsaPublicKey">the DSA public key for checking signatures, in XML Signature (&lt;DSAKeyValue&gt;) format.
        /// If null, a file named "NetSparkle_DSA.pub" is used instead.</param>
        public SparkleUpdater(string appcastUrl, SecurityMode securityMode, string dsaPublicKey)
            : this(appcastUrl, securityMode, dsaPublicKey, null)
        { }

        /// <summary>
        /// ctor which needs the appcast url and a referenceassembly
        /// </summary>        
        /// <param name="appcastUrl">the URL of the appcast file</param>
        /// <param name="securityMode">the security mode to be used when checking DSA signatures</param>
        /// <param name="dsaPublicKey">the DSA public key for checking signatures, in XML Signature (&lt;DSAKeyValue&gt;) format.
        /// If null, a file named "NetSparkle_DSA.pub" is used instead.</param>
        /// <param name="referenceAssembly">the name of the assembly to use for comparison when checking update versions</param>
        public SparkleUpdater(string appcastUrl, SecurityMode securityMode, string dsaPublicKey, string referenceAssembly)
            : this(appcastUrl, securityMode, dsaPublicKey, referenceAssembly, null)
        { }

        /// <summary>
        /// ctor which needs the appcast url and a referenceassembly
        /// </summary>        
        /// <param name="appcastUrl">the URL of the appcast file</param>
        /// <param name="securityMode">the security mode to be used when checking DSA signatures</param>
        /// <param name="dsaPublicKey">the DSA public key for checking signatures, in XML Signature (&lt;DSAKeyValue&gt;) format.
        /// If null, a file named "NetSparkle_DSA.pub" is used instead.</param>
        /// <param name="referenceAssembly">the name of the assembly to use for comparison when checking update versions</param>
        /// <param name="factory">a UI factory to use in place of the default UI</param>
        public SparkleUpdater(string appcastUrl, SecurityMode securityMode, string dsaPublicKey, string? referenceAssembly, IUIFactory factory)
        {
            _latestDownloadedUpdateInfo = null;
            _hasAttemptedFileRedownload = false;
            UIFactory = factory;
            SignatureVerifier = new DSAChecker(securityMode, dsaPublicKey);
            // Syncronization Context
            _syncContext = SynchronizationContext.Current;
            if (_syncContext == null)
            {
                _syncContext = new SynchronizationContext();
            }
            // init UI
            UIFactory?.Init();
            _appReferenceAssembly = null;
            // set the reference assembly
            if (referenceAssembly != null)
            {
                _appReferenceAssembly = referenceAssembly;
                LogWriter.PrintMessage("Checking the following file: " + _appReferenceAssembly);
            }

            // adjust the delegates
            _taskWorker = new Task(() =>
            {
                OnWorkerDoWork(null, null);
            });
            _cancelTokenSource = new CancellationTokenSource();
            _cancelToken = _cancelTokenSource.Token;

            // build the wait handle
            _exitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            _loopingHandle = new EventWaitHandle(false, EventResetMode.ManualReset);

            // set the url
            AppCastUrl = appcastUrl;
            LogWriter.PrintMessage("Using the following url: {0}", AppCastUrl);
            UserInteractionMode = UserInteractionMode.NotSilent;
            TmpDownloadFilePath = "";
        }

        #endregion

        #region Properties

        /// <summary>
        /// The security protocol used by NetSparkle. Setting this property will also set this 
        /// for the current AppDomain of the caller. Needs to be set to 
        /// SecurityProtocolType.Tls12 for some cases (such as when downloading from GitHub).
        /// </summary>
        public SecurityProtocolType SecurityProtocolType
        {
            get => ServicePointManager.SecurityProtocol;
            set => ServicePointManager.SecurityProtocol = value;
        }

        /// <summary>
        /// Set the user interaction mode for Sparkle to use when there is a valid update for the software
        /// </summary>
        public UserInteractionMode UserInteractionMode { get; set; }

        /// <summary>
        /// If set, downloads files to this path. If the folder doesn't already exist, creates
        /// the folder at download time (and not before). 
        /// Note that this variable is a path, not a full file name.
        /// </summary>
        public string TmpDownloadFilePath
        {
            get => _tmpDownloadFilePath;
            set => _tmpDownloadFilePath = value?.Trim();
        }

        /// <summary>
        /// Defines if the application needs to be relaunched after executing the downloaded installer
        /// </summary>
        public bool RelaunchAfterUpdate { get; set; }

        /// <summary>
        /// Run the downloaded installer with these arguments
        /// </summary>
        public string CustomInstallerArguments { get; set; }

        /// <summary>
        /// Function that is called asynchronously to clean up old installers that have been
        /// downloaded with SilentModeTypes.DownloadNoInstall or SilentModeTypes.DownloadAndInstall.
        /// </summary>
        public Action ClearOldInstallers { get; set; }

        /// <summary>
        /// Whether or not the update loop is running
        /// </summary>
        public bool IsUpdateLoopRunning => _loopingHandle.WaitOne(0);

        /// <summary>
        /// Factory for creating UI elements like progress window, etc.
        /// </summary>
        public IUIFactory UIFactory
        {
            get => _uiFactory;
            set { _uiFactory = value; _uiFactory?.Init(); }
        }

        /// <summary>
        /// The user interface window that shows the release notes and
        /// asks the user to skip, remind me later, or update
        /// </summary>
        private IUpdateAvailable UpdateAvailableWindow { get; set; }

        /// <summary>
        /// The user interface window that shows a download progress bar,
        /// and then asks to install and relaunch the application
        /// </summary>
        private IDownloadProgress ProgressWindow { get; set; }

        /// <summary>
        /// The user interface window that shows the 'Checking for Updates...'
        /// form.
        /// </summary>
        private ICheckingForUpdates CheckingForUpdatesWindow { get; set; }

        /// <summary>
        /// The NetSparkle configuration object for the current assembly.
        /// </summary>
        public Configuration Configuration
        {
            get
            {
                if (_configuration == null)
                {
#if NETSTANDARD
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        _configuration = new RegistryConfiguration(_appReferenceAssembly);
                    }
                    else
                    {
                        _configuration = new JSONConfiguration(_appReferenceAssembly);
                    }
#else
                    _configuration = new RegistryConfiguration(_appReferenceAssembly);
#endif
                }
                return _configuration;
            }
            set { _configuration = value; }
        }

        /// <summary>
        /// The object that verifies signatures (DSA or otherwise) of downloaded items
        /// </summary>
        public ISignatureVerifier SignatureVerifier { get; set; }

        /// <summary>
        /// Gets or sets the appcast URL
        /// </summary>
        public string AppCastUrl { get; set; }

        /// <summary>
        /// Specifies if you want to use the notification toast
        /// </summary>
        public bool UseNotificationToast { get; set; }

        /// <summary>
        /// WinForms/WPF only. 
        /// If true, tries to run UI code on the main thread using <see cref="SynchronizationContext"/>.
        /// Must be set to true if using NetSparkleUpdater from Avalonia.
        /// </summary>
        public bool ShowsUIOnMainThread { get; set; }

        /// <summary>
        /// Object that handles any diagnostic messages for NetSparkle.
        /// If you want to use your own class for this, you should just
        /// need to override <see cref="LogWriter.PrintMessage"/> in your own class.
        /// Make sure to set this object before calling <see cref="StartLoop(bool)"/> to guarantee
        /// that all messages will get sent to the right place!
        /// </summary>
        public LogWriter LogWriter
        {
            get
            {
                if (_logWriter == null)
                {
                    _logWriter = new LogWriter();
                }
                return _logWriter;
            }
            set => _logWriter = value;
        }

        /// <summary>
        /// Whether or not to check with the online server to verify download
        /// file names.
        /// </summary>
        public bool CheckServerFileName { get; set; } = true;

        /// <summary>
        /// Returns the latest appcast items to the caller. Might be null.
        /// </summary>
        public List<AppCastItem> LatestAppCastItems => _latestDownloadedUpdateInfo?.Updates;

        /// <summary>
        /// Loops through all of the most recently grabbed app cast items
        /// and checks if any of them are marked as critical
        /// </summary>
        public bool UpdateMarkedCritical
        {
            get
            {
                if (LatestAppCastItems != null)
                {
                    foreach (AppCastItem item in LatestAppCastItems)
                    {
                        if (item.IsCriticalUpdate)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// The object responsable for downloading update files for your application
        /// </summary>
        public IUpdateDownloader UpdateDownloader { get; set; }

        /// <summary>
        /// The object responsible for downloading app cast and app cast signature
        /// information for your application
        /// </summary>
        public IAppCastDataDownloader AppCastDataDownloader { get; set; }

        /// <summary>
        /// The object responsible for parsing app cast information and checking to
        /// see if any updates are available in a given app cast
        /// </summary>
        public IAppCastHandler AppCastHandler { get; set; }

        #endregion

        /// <summary>
        /// Starts a NetSparkle background loop to check for updates every 24 hours.
        /// <para>You should only call this function when your app is initialized and shows its main window.</para>
        /// </summary>
        /// <param name="doInitialCheck">whether the first check should happen before or after the first interval</param>
        public void StartLoop(bool doInitialCheck)
        {
            StartLoop(doInitialCheck, false);
        }

        /// <summary>
        /// Starts a NetSparkle background loop to check for updates on a given interval.
        /// <para>You should only call this function when your app is initialized and shows its main window.</para>
        /// </summary>
        /// <param name="doInitialCheck">whether the first check should happen before or after the first interval</param>
        /// <param name="checkFrequency">the interval to wait between update checks</param>
        public void StartLoop(bool doInitialCheck, TimeSpan checkFrequency)
        {
            StartLoop(doInitialCheck, false, checkFrequency);
        }

        /// <summary>
        /// Starts a NetSparkle background loop to check for updates every 24 hours.
        /// <para>You should only call this function when your app is initialized and shows its main window.</para>
        /// </summary>
        /// <param name="doInitialCheck">whether the first check should happen before or after the first interval</param>
        /// <param name="forceInitialCheck">if <paramref name="doInitialCheck"/> is true, whether the first check
        /// should happen even if the last check was less than 24 hours ago</param>
        public void StartLoop(bool doInitialCheck, bool forceInitialCheck)
        {
            StartLoop(doInitialCheck, forceInitialCheck, TimeSpan.FromHours(24));
        }

        /// <summary>
        /// Starts a NetSparkle background loop to check for updates on a given interval.
        /// <para>You should only call this function when your app is initialized and shows its main window.</para>
        /// </summary>
        /// <param name="doInitialCheck">whether the first check should happen before or after the first period</param>
        /// <param name="forceInitialCheck">if <paramref name="doInitialCheck"/> is true, whether the first check
        /// should happen even if the last check was within the last <paramref name="checkFrequency"/> interval</param>
        /// <param name="checkFrequency">the interval to wait between update checks</param>
        public async void StartLoop(bool doInitialCheck, bool forceInitialCheck, TimeSpan checkFrequency)
        {
            if (ClearOldInstallers != null)
            {
                try
                {
                    await Task.Run(ClearOldInstallers);
                }
                catch (Exception e)
                {
                    LogWriter.PrintMessage("ClearOldInstallers threw an exception: {0}", e.Message);
                }
            }
            // first set the event handle
            _loopingHandle.Set();

            // Start the helper thread as a background worker                     

            // store info
            _doInitialCheck = doInitialCheck;
            _forceInitialCheck = forceInitialCheck;
            _checkFrequency = checkFrequency;

            LogWriter.PrintMessage("Starting background worker");

            // start the work
            //var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            //_taskWorker.Start(scheduler);
            _taskWorker.Start();
        }

        /// <summary>
        /// Stops the Sparkle background loop. Called automatically by <see cref="Dispose()"/>.
        /// </summary>
        public void StopLoop()
        {
            // ensure the work will finished
            _exitHandle.Set();
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~SparkleUpdater()
        {
            Dispose(false);
        }

        #region IDisposable

        /// <summary>
        /// Inherited from IDisposable. Stops all background activities.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose of managed and unmanaged resources
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    StopLoop();
                    UnregisterEvents();
                    _cancelTokenSource?.Dispose();
                    _exitHandle?.Dispose();
                    _loopingHandle?.Dispose();
                    UpdateDownloader?.Dispose();
                    _installerProcess?.Dispose();
                }
                // There are no unmanaged resources to release, but
                // if we add them, they need to be released here.
            }
            _disposed = true;
        }

        /// <summary>
        /// Unregisters events so that we don't have multiple items updating
        /// </summary>
        private void UnregisterEvents()
        {
            _cancelTokenSource.Cancel();

            CleanUpUpdateDownloader();

            if (UpdateAvailableWindow != null)
            {
                UpdateAvailableWindow.UserResponded -= OnUserWindowUserResponded;
                UpdateAvailableWindow = null;
            }

            if (ProgressWindow != null)
            {
                ProgressWindow.DownloadProcessCompleted -= ProgressWindowCompleted;
                ProgressWindow = null;
            }
        }

        #endregion

        /// <summary>
        /// This method checks if an update is required. During this process the appcast
        /// will be downloaded and checked against the reference assembly. Ensure that
        /// the calling process has read access to the reference assembly.
        /// This method is also called from the background loops.
        /// </summary>
        /// <param name="config">the NetSparkle configuration for the reference assembly</param>
        /// <returns><see cref="UpdateInfo"/> with information on whether there is an update available or not.</returns>
        protected async Task<UpdateInfo> GetUpdateStatus(Configuration config)
        {
            List<AppCastItem> updates = null;
            // report
            LogWriter.PrintMessage("Downloading and checking appcast");

            // init the appcast
            if (AppCastDataDownloader == null)
            {
                AppCastDataDownloader = new WebRequestAppCastDataDownloader();
            }
            if (AppCastHandler == null)
            {
                AppCastHandler = new XMLAppCast();
            }
            AppCastHandler.SetupAppCastHandler(AppCastDataDownloader, AppCastUrl, config, SignatureVerifier, LogWriter);
            // check if any updates are available
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    LogWriter.PrintMessage("About to start downloading the app cast...");
                    if (AppCastHandler.DownloadAndParse())
                    {
                        LogWriter.PrintMessage("App cast successfully downloaded and parsed. Getting available updates...");
                        updates = AppCastHandler.GetAvailableUpdates();
                    }
                });
            }
            catch (Exception e)
            {
                LogWriter.PrintMessage("Couldn't read/parse the app cast: {0}", e.Message);
                updates = null;
            }

            if (updates == null)
            {
                LogWriter.PrintMessage("No version information in app cast found");
                return new UpdateInfo(UpdateStatus.CouldNotDetermine);
            }

            // set the last check time
            LogWriter.PrintMessage("Touch the last check timestamp");
            config.TouchCheckTime();

            // check if the version will be the same then the installed version
            if (updates.Count == 0)
            {
                LogWriter.PrintMessage("Installed version is valid, no update needed ({0})", config.InstalledVersion);
                return new UpdateInfo(UpdateStatus.UpdateNotAvailable);
            }
            LogWriter.PrintMessage("Latest version on the server is {0}", updates[0].Version);

            // check if the available update has to be skipped
            if (updates[0].Version.Equals(config.LastVersionSkipped))
            {
                LogWriter.PrintMessage("Latest update has to be skipped (user decided to skip version {0})", config.LastVersionSkipped);
                return new UpdateInfo(UpdateStatus.UserSkipped);
            }

            // ok we need an update
            return new UpdateInfo(UpdateStatus.UpdateAvailable, updates);
        }

        /// <summary>
        /// Shows the update needed UI with the given set of updates.
        /// </summary>
        /// <param name="updates">updates to show UI for</param>
        /// <param name="isUpdateAlreadyDownloaded">If true, make sure UI text shows that the user is about to install the file instead of download it.</param>
        public void ShowUpdateNeededUI(List<AppCastItem>? updates, bool isUpdateAlreadyDownloaded = false)
        {
            if (updates != null)
            {
                if (UseNotificationToast && (bool)UIFactory?.CanShowToastMessages())
                {
                    UIFactory?.ShowToast(updates, OnToastClick);
                }
                else
                {
                    ShowUpdateAvailableWindow(updates, isUpdateAlreadyDownloaded);
                }
            }
        }

        /// <summary>
        /// Shows the update UI with the latest downloaded update information.
        /// </summary>
        /// <param name="isUpdateAlreadyDownloaded">If true, make sure UI text shows that the user is about to install the file instead of download it.</param>
        public void ShowUpdateNeededUI(bool isUpdateAlreadyDownloaded = false)
        {
            ShowUpdateNeededUI(_latestDownloadedUpdateInfo?.Updates, isUpdateAlreadyDownloaded);
        }

        private void OnToastClick(List<AppCastItem> updates)
        {
            ShowUpdateAvailableWindow(updates);
        }

        private void ShowUpdateAvailableWindow(List<AppCastItem> updates, bool isUpdateAlreadyDownloaded = false)
        {
            if (UpdateAvailableWindow != null)
            {
                // close old window
                if (ShowsUIOnMainThread)
                {
                    _syncContext.Post((state) =>
                    {
                        UpdateAvailableWindow.Close();
                        UpdateAvailableWindow = null;
                    }, null);
                }
                else
                {
                    UpdateAvailableWindow.Close();
                    UpdateAvailableWindow = null;
                }
            }

            // create the form
            Thread thread = new Thread(() =>
            {
                try
                {
                    // define action
                    Action<object> showSparkleUI = (state) =>
                    {
                        UpdateAvailableWindow = UIFactory?.CreateUpdateAvailableWindow(this, updates, isUpdateAlreadyDownloaded);

                        if (UpdateAvailableWindow != null)
                        {

                            // clear if already set.
                            UpdateAvailableWindow.UserResponded += OnUserWindowUserResponded;
                            UpdateAvailableWindow.Show(ShowsUIOnMainThread);
                        }
                    };

                    // call action
                    if (ShowsUIOnMainThread)
                    {
                        _syncContext.Post((state) => showSparkleUI(state), null);
                    }
                    else
                    {
                        showSparkleUI(null);
                    }
                }
                catch (Exception e)
                {
                    LogWriter.PrintMessage("Error showing sparkle form: {0}", e.Message);
                }
            });
#if NETFRAMEWORK
            thread.SetApartmentState(ApartmentState.STA);
#else
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                thread.SetApartmentState(ApartmentState.STA); // only supported on Windows
            }
#endif
            thread.Start();
        }

        /// <summary>
        /// Get the download path for a given app cast item.
        /// If any directories need to be created, this function
        /// will create those directories.
        /// </summary>
        /// <param name="item">The item that you want to generate a download path for</param>
        /// <returns>The download path for an app cast item if item is not null and has valid download link
        /// Otherwise returns null.</returns>
        public async Task<string> GetDownloadPathForAppCastItem(AppCastItem item)
        {
            if (item != null && item.DownloadLink != null)
            {
                string filename = string.Empty;

                // default to using the server's file name as the download file name
                if (CheckServerFileName && UpdateDownloader != null)
                {
                    try
                    {
                        filename = await UpdateDownloader.RetrieveDestinationFileNameAsync(item);
                    }
                    catch (Exception)
                    {
                        // ignore
                    }
                }

                if (string.IsNullOrEmpty(filename))
                {
                    // attempt to get download file name based on download link
                    try
                    {
                        filename = Path.GetFileName(new Uri(item.DownloadLink).LocalPath);
                    }
                    catch (UriFormatException)
                    {
                        // ignore
                    }
                }

                if (!string.IsNullOrEmpty(filename))
                {
                    string tmpPath = string.IsNullOrEmpty(TmpDownloadFilePath) ? Path.GetTempPath() : TmpDownloadFilePath;

                    // Creates all directories and subdirectories in the specific path unless they already exist.
                    Directory.CreateDirectory(tmpPath);

                    return Path.Combine(tmpPath, filename);
                }
            }
            return null;
        }

        /// <summary>
        /// Starts the download process by grabbing the download path for
        /// the app cast item (asynchronous so that it can get the server's
        /// download name in case there is a redirect; cancel this by setting
        /// CheckServerFileName to false), then beginning the download
        /// process if the download file doesn't already exist
        /// </summary>
        /// <param name="item">the appcast item to download</param>
        public async Task InitAndBeginDownload(AppCastItem item)
        {
            if (UpdateDownloader != null && UpdateDownloader.IsDownloading)
            {
                return; // file is already downloading, don't do anything!
            }
            LogWriter.PrintMessage("Preparing to download {0}", item.DownloadLink);
            _itemBeingDownloaded = item;
            CreateUpdateDownloaderIfNeeded();
            _downloadTempFileName = await GetDownloadPathForAppCastItem(item);
            // Make sure the file doesn't already exist on disk. If it's already downloaded and the
            // DSA signature checks out, don't redownload the file!
            bool needsToDownload = true;
            if (File.Exists(_downloadTempFileName))
            {
                ValidationResult result = SignatureVerifier.VerifySignatureOfFile(item.DownloadSignature, _downloadTempFileName);
                if (result == ValidationResult.Valid)
                {
                    LogWriter.PrintMessage("File is already downloaded");
                    // We already have the file! Don't redownload it!
                    needsToDownload = false;
                    // Still need to set up the ProgressWindow for non-silent downloads, though,
                    // so that the user can actually perform the install
                    CreateAndShowProgressWindow(item, true);
                    CallFuncConsideringUIThreads(() => { DownloadFinished?.Invoke(_itemBeingDownloaded, _downloadTempFileName); });
                    bool shouldInstallAndRelaunch = UserInteractionMode == UserInteractionMode.DownloadAndInstall;
                    if (shouldInstallAndRelaunch)
                    {
                        CallFuncConsideringUIThreads(() => { ProgressWindowCompleted(this, new DownloadInstallEventArgs(true)); });
                    }
                }
                else if (!_hasAttemptedFileRedownload)
                {
                    // The file exists but it either has a bad DSA signature or SecurityMode is set to Unsafe.
                    // Redownload it!
                    _hasAttemptedFileRedownload = true;
                    LogWriter.PrintMessage("File is corrupt or DSA signature is Unchecked; deleting file and redownloading...");
                    try
                    {
                        File.Delete(_downloadTempFileName);
                    }
                    catch (Exception e)
                    {
                        LogWriter.PrintMessage("Hm, seems as though we couldn't delete the temporary file even though it is apparently corrupt. {0}",
                            e.Message);
                        // we won't be able to download anyway since we couldn't delete the file :( we'll try next time the
                        // update loop goes around.
                        needsToDownload = false;
                        CallFuncConsideringUIThreads(() =>
                        {
                            DownloadHadError?.Invoke(item, _downloadTempFileName,
                                new Exception(string.Format("Unable to delete old download at {0}", _downloadTempFileName)));
                        });
                    }
                }
                else
                {
                    CallFuncConsideringUIThreads(() => { DownloadedFileIsCorrupt?.Invoke(item, _downloadTempFileName); });
                }
            }
            if (needsToDownload)
            {
                // remove any old event handlers so we don't fire 2x
                UpdateDownloader.DownloadProgressChanged -= OnDownloadProgressChanged;
                UpdateDownloader.DownloadFileCompleted -= OnDownloadFinished;

                CreateAndShowProgressWindow(item, false);
                UpdateDownloader.DownloadProgressChanged += OnDownloadProgressChanged;
                UpdateDownloader.DownloadFileCompleted += OnDownloadFinished;

                Uri url = Utilities.GetAbsoluteURL(item.DownloadLink, AppCastUrl);
                LogWriter.PrintMessage("Starting to download {0} to {1}", item.DownloadLink, _downloadTempFileName);
                UpdateDownloader.StartFileDownload(url, _downloadTempFileName);
                CallFuncConsideringUIThreads(() => { DownloadStarted?.Invoke(item, _downloadTempFileName); });
            }
        }

        private void OnDownloadProgressChanged(object sender, ItemDownloadProgressEventArgs args)
        {
            CallFuncConsideringUIThreads(() =>
            {
                DownloadMadeProgress?.Invoke(sender, _itemBeingDownloaded, args);
            });
        }

        private void CleanUpUpdateDownloader()
        {
            if (UpdateDownloader != null)
            {
                if (ProgressWindow != null)
                {
                    UpdateDownloader.DownloadProgressChanged -= ProgressWindow.OnDownload_ProgressChanged;
                }
                UpdateDownloader.DownloadProgressChanged -= OnDownloadProgressChanged;
                UpdateDownloader.DownloadFileCompleted -= OnDownloadFinished;
                UpdateDownloader?.Dispose();
                UpdateDownloader = null;
            }
        }

        private void CreateUpdateDownloaderIfNeeded()
        {
            if (UpdateDownloader == null)
            {
                UpdateDownloader = new WebClientFileDownloader();
            }
        }

        private void CreateAndShowProgressWindow(AppCastItem castItem, bool shouldShowAsDownloadedAlready)
        {
            if (ProgressWindow != null)
            {
                ProgressWindow.DownloadProcessCompleted -= ProgressWindowCompleted;
                UpdateDownloader.DownloadProgressChanged -= ProgressWindow.OnDownload_ProgressChanged;
                ProgressWindow = null;
            }
            if (ProgressWindow == null && UIFactory != null && !IsDownloadingSilently())
            {
                if (!IsDownloadingSilently() && ProgressWindow == null)
                {
                    // create the form
                    Action<object> showSparkleDownloadUI = (state) =>
                    {
                        ProgressWindow = UIFactory?.CreateProgressWindow(castItem);
                        if (ProgressWindow != null)
                        {
                            ProgressWindow.DownloadProcessCompleted += ProgressWindowCompleted;
                            UpdateDownloader.DownloadProgressChanged += ProgressWindow.OnDownload_ProgressChanged;
                            if (shouldShowAsDownloadedAlready)
                            {
                                ProgressWindow?.FinishedDownloadingFile(true);
                                _syncContext.Post((state2) => OnDownloadFinished(null, new AsyncCompletedEventArgs(null, false, null)), null);
                            }
                        }
                    };
                    Thread thread = new Thread(() =>
                    {
                        // call action
                        if (ShowsUIOnMainThread)
                        {
                            _syncContext.Post((state) =>
                            {
                                showSparkleDownloadUI(null);
                                ProgressWindow?.Show(ShowsUIOnMainThread);
                            }, null);
                        }
                        else
                        {
                            showSparkleDownloadUI(null);
                            ProgressWindow?.Show(ShowsUIOnMainThread);
                        }
                    });
#if NETFRAMEWORK
                    thread.SetApartmentState(ApartmentState.STA);
#else
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        thread.SetApartmentState(ApartmentState.STA); // only supported on Windows
                    }
#endif
                    thread.Start();
                }
            }
        }

        private async void ProgressWindowCompleted(object sender, DownloadInstallEventArgs args)
        {
            if (args.ShouldInstall)
            {
                ProgressWindow?.SetDownloadAndInstallButtonEnabled(false); // disable while we ask if we can close up the software
                if (await AskApplicationToSafelyCloseUp())
                {
                    ProgressWindow?.Close();
                    await RunDownloadedInstaller(_downloadTempFileName);
                }
                else
                {
                    ProgressWindow?.SetDownloadAndInstallButtonEnabled(true);
                }
            }
            else
            {
                CancelFileDownload();
                ProgressWindow?.Close();
            }
        }

        /// <summary>
        /// Called when the installer is downloaded
        /// </summary>
        /// <param name="sender">not used.</param>
        /// <param name="e">used to determine if the download was successful.</param>
        private void OnDownloadFinished(object sender, AsyncCompletedEventArgs e)
        {
            bool shouldShowUIItems = !IsDownloadingSilently();

            if (e.Cancelled)
            {
                DownloadCanceled?.Invoke(_itemBeingDownloaded, _downloadTempFileName);
                _hasAttemptedFileRedownload = false;
                if (File.Exists(_downloadTempFileName))
                {
                    File.Delete(_downloadTempFileName);
                }
                LogWriter.PrintMessage("Download was canceled");
                string errorMessage = "Download canceled";
                if (shouldShowUIItems && ProgressWindow != null && !ProgressWindow.DisplayErrorMessage(errorMessage))
                {
                    UIFactory?.ShowDownloadErrorMessage(errorMessage, AppCastUrl);
                }
                DownloadCanceled?.Invoke(_itemBeingDownloaded, _downloadTempFileName);
                return;
            }
            if (e.Error != null)
            {
                DownloadHadError?.Invoke(_itemBeingDownloaded, _downloadTempFileName, e.Error);
                // Clean temp files on error too
                if (File.Exists(_downloadTempFileName))
                {
                    File.Delete(_downloadTempFileName);
                }
                LogWriter.PrintMessage("Error on download finished: {0}", e.Error.Message);
                if (shouldShowUIItems && ProgressWindow != null && !ProgressWindow.DisplayErrorMessage(e.Error.Message))
                {
                    UIFactory?.ShowDownloadErrorMessage(e.Error.Message, AppCastUrl);
                }
                DownloadHadError?.Invoke(_itemBeingDownloaded, _downloadTempFileName, new NetSparkleException(e.Error.Message));
                return;
            }
            // test the item for DSA signature
            var validationRes = ValidationResult.Invalid;
            if (!e.Cancelled && e.Error == null)
            {
                LogWriter.PrintMessage("Fully downloaded file exists at {0}", _downloadTempFileName);

                LogWriter.PrintMessage("Performing DSA check");

                // get the assembly
                if (File.Exists(_downloadTempFileName))
                {
                    // check if the file was downloaded successfully
                    string absolutePath = Path.GetFullPath(_downloadTempFileName);
                    if (!File.Exists(absolutePath))
                    {
                        var message = "File not found even though it was reported as downloading successfully!";
                        LogWriter.PrintMessage(message);
                        DownloadHadError?.Invoke(_itemBeingDownloaded, _downloadTempFileName, new NetSparkleException(message));
                    }

                    // check the DSA signature
                    validationRes = SignatureVerifier.VerifySignatureOfFile(_itemBeingDownloaded?.DownloadSignature, _downloadTempFileName);
                }
            }

            bool isSignatureInvalid = validationRes == ValidationResult.Invalid; // if Unchecked, we accept download as valid
            if (shouldShowUIItems)
            {
                CallFuncConsideringUIThreads(() => { ProgressWindow?.FinishedDownloadingFile(!isSignatureInvalid); });
            }
            // signature of file isn't valid so exit with error
            if (isSignatureInvalid)
            {
                LogWriter.PrintMessage("Invalid signature for downloaded file for app cast: {0}", _downloadTempFileName);
                string errorMessage = "Downloaded file has invalid signature!";
                DownloadedFileIsCorrupt?.Invoke(_itemBeingDownloaded, _downloadTempFileName);
                // Default to showing errors in the progress window. Only go to the UIFactory to show errors if necessary.
                CallFuncConsideringUIThreads(() =>
                {
                    if (shouldShowUIItems && ProgressWindow != null && !ProgressWindow.DisplayErrorMessage(errorMessage))
                    {
                        UIFactory?.ShowDownloadErrorMessage(errorMessage, AppCastUrl);
                    }
                    DownloadHadError?.Invoke(_itemBeingDownloaded, _downloadTempFileName, new NetSparkleException(e.Error.Message));
                });
            }
            else
            {
                LogWriter.PrintMessage("DSA Signature is valid. File successfully downloaded!");
                DownloadFinished?.Invoke(_itemBeingDownloaded, _downloadTempFileName);
                bool shouldInstallAndRelaunch = UserInteractionMode == UserInteractionMode.DownloadAndInstall;
                if (shouldInstallAndRelaunch)
                {
                    CallFuncConsideringUIThreads(() => { ProgressWindowCompleted(this, new DownloadInstallEventArgs(true)); });
                }
            }
            _itemBeingDownloaded = null;
        }

        /// <summary>
        /// Run the provided app cast item update regardless of what else is going on.
        /// Note that a more up to date download may be taking place, so if you don't
        /// want to run a potentially out-of-date installer, don't use this. This should
        /// only be used if your user wants to update before another update has been
        /// installed AND the file is already downloaded.
        /// This function will verify that the file exists and that the DSA 
        /// signature is valid before running. It will also utilize the
        /// PreparingToExit event to ensure that the application can close.
        /// </summary>
        /// <param name="item">AppCastItem to install</param>
        /// <param name="installPath">Install path to the executable. If not provided, will ask the server for the download path.</param>
        public async void InstallUpdate(AppCastItem item, string? installPath = null)
        {
            ProgressWindow?.SetDownloadAndInstallButtonEnabled(false); // disable while we ask if we can close up the software
            if (await AskApplicationToSafelyCloseUp())
            {
                var path = installPath != null && File.Exists(installPath) ? installPath : await GetDownloadPathForAppCastItem(item);
                if (File.Exists(path))
                {
                    var result = SignatureVerifier.VerifySignatureOfFile(item.DownloadSignature, path);
                    if (result == ValidationResult.Valid || result == ValidationResult.Unchecked)
                    {
                        await RunDownloadedInstaller(path);
                    }
                }
            }
            ProgressWindow?.SetDownloadAndInstallButtonEnabled(true);
        }

        /// <summary>
        /// Checks to see
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool IsDownloadingItem(AppCastItem item)
        {
            return _itemBeingDownloaded?.DownloadSignature == item.DownloadSignature;
        }

        /// <summary>
        /// True if the user has silent updates enabled; false otherwise.
        /// </summary>
        private bool IsDownloadingSilently()
        {
            return UserInteractionMode != UserInteractionMode.NotSilent;
        }

        /// <summary>
        /// Checks to see if two extensions match (this is basically just a 
        /// convenient string comparison). Both extensions should include the
        /// initial . (full-stop/period) in the extension.
        /// </summary>
        /// <param name="extension">first extension to check</param>
        /// <param name="otherExtension">other extension to check</param>
        /// <returns>true if the extensions match; false otherwise</returns>
        protected bool DoExtensionsMatch(string extension, string otherExtension)
        {
            return extension.Equals(otherExtension, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Get the install command for the file at the given path. Figures out which
        /// command to use based on the download file path's file extension.
        /// Currently supports .exe, .msi, and .msp.
        /// </summary>
        /// <param name="downloadFilePath">Path to the downloaded update file</param>
        /// <returns>the installer command if the file has one of the given 
        /// extensions; the initial downloadFilePath if not.</returns>
        protected virtual string GetWindowsInstallerCommand(string downloadFilePath)
        {
            string installerExt = Path.GetExtension(downloadFilePath);
            if (DoExtensionsMatch(installerExt, ".exe"))
            {
                return "\"" + downloadFilePath + "\"";
            }
            if (DoExtensionsMatch(installerExt, ".msi"))
            {
                return "msiexec /i \"" + downloadFilePath + "\"";
            }
            if (DoExtensionsMatch(installerExt, ".msp"))
            {
                return "msiexec /p \"" + downloadFilePath + "\"";
            }
            return downloadFilePath;
        }

        /// <summary>
        /// Get the install command for the file at the given path. Figures out which
        /// command to use based on the download file path's file extension.
        /// <para>Windows: currently supports .exe, .msi, and .msp.</para>
        /// <para>macOS: currently supports .pkg, .dmg, and .zip.</para>
        /// <para>Linux: currently supports .tar.gz, .deb, and .rpm.</para>
        /// </summary>
        /// <param name="downloadFilePath">Path to the downloaded update file</param>
        /// <returns>the installer command if the file has one of the given 
        /// extensions; the initial downloadFilePath if not.</returns>
        protected virtual string GetInstallerCommand(string downloadFilePath)
        {
            // get the file type
#if NETFRAMEWORK
            return GetWindowsInstallerCommand(downloadFilePath);
#else
            //string installerExt = Path.GetExtension(downloadFilePath);
            //if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            //{
            //    return GetWindowsInstallerCommand(downloadFilePath);
            //}
            //else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            //{
            //    if (DoExtensionsMatch(installerExt, ".pkg") ||
            //        DoExtensionsMatch(installerExt, ".dmg"))
            //    {
            //        return "open \"" + downloadFilePath + "\"";
            //    }
            //}
            //else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            //{
            //    if (DoExtensionsMatch(installerExt, ".deb"))
            //    {
            //        return "sudo dpkg -i \"" + downloadFilePath + "\"";
            //    }
            //    if (DoExtensionsMatch(installerExt, ".rpm"))
            //    {
            //        return "sudo rpm -i \"" + downloadFilePath + "\"";
            //    }
            //}
            return downloadFilePath;
#endif
        }

        private bool IsZipDownload(string downloadFilePath)
        {
#if NETCORE
            string installerExt = Path.GetExtension(downloadFilePath);
            bool isMacOS = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            bool isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            if ((isMacOS && DoExtensionsMatch(installerExt, ".zip")) ||
                (isLinux && DoExtensionsMatch(installerExt, ".tar.gz")))
            {
                return true;
            }
#endif
            return false;
        }

        /// <summary>
        /// Updates the application via the file at the given path. Figures out which command needs
        /// to be run, sets up the application so that it will start the downloaded file once the
        /// main application stops, and then waits to start the downloaded update.
        /// </summary>
        /// <param name="downloadFilePath">path to the downloaded installer/updater</param>
        /// <returns>the awaitable <see cref="Task"/> for the application quitting</returns>
        protected virtual async Task RunDownloadedInstaller(string downloadFilePath)
        {
            LogWriter.PrintMessage("Running downloaded installer");
            // get the commandline 
            string cmdLine = Environment.CommandLine;
            string workingDir = Utilities.GetFullBaseDirectory();

            // generate the batch file path
#if NETFRAMEWORK
            bool isWindows = true;
            bool isMacOS = false;
#else
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            bool isMacOS = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
#endif
            var extension = isWindows ? ".cmd" : ".sh";
            string batchFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + extension);
            string installerCmd;
            try
            {
                installerCmd = GetInstallerCommand(downloadFilePath);
                if (!string.IsNullOrEmpty(CustomInstallerArguments))
                {
                    installerCmd += " " + CustomInstallerArguments;
                }
            }
            catch (InvalidDataException)
            {
                UIFactory?.ShowUnknownInstallerFormatMessage(downloadFilePath);
                return;
            }

            // generate the batch file                
            LogWriter.PrintMessage("Generating batch in {0}", Path.GetFullPath(batchFilePath));

            string processID = Process.GetCurrentProcess().Id.ToString();

            using (StreamWriter write = new StreamWriter(batchFilePath))
            {
                if (isWindows)
                {
                    write.WriteLine("@echo off");
                    // We should wait until the host process has died before starting the installer.
                    // This way, any DLLs or other items can be replaced properly.
                    // Code from: http://stackoverflow.com/a/22559462/3938401
                    string relaunchAfterUpdate = "";
                    if (RelaunchAfterUpdate)
                    {
                        relaunchAfterUpdate = $@"
                        cd {workingDir}
                        {cmdLine}";
                    }

                    string output = $@"
                        set /A counter=0                       
                        setlocal ENABLEDELAYEDEXPANSION
                        :loop
                        set /A counter=!counter!+1
                        if !counter! == 90 (
                            goto :afterinstall
                        )
                        tasklist | findstr ""\<{processID}\>"" > nul
                        if not errorlevel 1 (
                            timeout /t 1 > nul
                            goto :loop
                        )
                        :install
                        {installerCmd}
                        {relaunchAfterUpdate}
                        :afterinstall
                        endlocal";
                    write.Write(output);
                    write.Close();
                }
                else
                {
                    // We should wait until the host process has died before starting the installer.
                    var waitForFinish = $@"
                        COUNTER=0;
                        while ps -p {processID} > /dev/null;
                            do sleep 1;
                            COUNTER=$((++COUNTER));
                            if [ $COUNTER -eq 90 ] 
                            then
                                exit -1;
                            fi;
                        done;
                    ";
                    string relaunchAfterUpdate = "";
                    if (RelaunchAfterUpdate)
                    {
                        relaunchAfterUpdate = $@"{Process.GetCurrentProcess().MainModule.FileName}";
                    }
                    if (IsZipDownload(downloadFilePath)) // .zip on macOS or .tar.gz on Linux
                    {
                        // waiting for finish based on http://blog.joncairns.com/2013/03/wait-for-a-unix-process-to-finish/
                        // use tar to extract
                        var tarCommand = isMacOS ? $"tar -x -f {downloadFilePath} -C \"{workingDir}\""
                            : $"tar -xf {downloadFilePath} -C \"{workingDir}\" --overwrite ";
                        var output = $@"
                            {waitForFinish}
                            {tarCommand}
                            {relaunchAfterUpdate}";
                        write.Write(output);
                    }
                    else
                    {
                        string installerExt = Path.GetExtension(downloadFilePath);
                        if (DoExtensionsMatch(installerExt, ".pkg") ||
                            DoExtensionsMatch(installerExt, ".dmg"))
                        {
                            relaunchAfterUpdate = ""; // relaunching not supported for pkg or dmg downloads
                        }
                        var output = $@"
                            {waitForFinish}
                            {installerCmd}
                            {relaunchAfterUpdate}";
                        write.Write(output);
                    }
                    write.Close();
                }
            }

            // report
            LogWriter.PrintMessage("Going to execute script at path: {0}", batchFilePath);

            // init the installer helper
            _installerProcess = new Process
            {
                StartInfo =
                {
                    FileName = batchFilePath,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            // start the installer process. the batch file will wait for the host app to close before starting.
            _installerProcess.Start();
            await QuitApplication();
        }

        /// <summary>
        /// Quits the application (host application) 
        /// </summary>
        /// <returns>Runs asynchrously, so returns a Task</returns>
        public async Task QuitApplication()
        {
            // quit the app
            _exitHandle?.Set(); // make SURE the loop exits!
                                // In case the user has shut the window that started this Sparkle window/instance, don't crash and burn.
                                // If you have better ideas on how to figure out if they've shut all other windows, let me know...
            try
            {
                await CallFuncConsideringUIThreadsAsync(async () =>
                {
                    if (CloseApplicationAsync != null)
                    {
                        await CloseApplicationAsync.Invoke();
                    }
                    else if (CloseApplication != null)
                    {
                        CloseApplication.Invoke();
                    }
                    else
                    {
                        // Because the download/install window is usually on a separate thread,
                        // send dual shutdown messages via both the sync context (kills "main" app)
                        // and the current thread (kills current thread)
                        UIFactory?.Shutdown();
                    }
                });
            }
            catch (Exception e)
            {
                LogWriter.PrintMessage(e.Message);
            }
        }

        /// <summary>
        /// Apps may need, for example, to let user save their work
        /// </summary>
        /// <returns>true if it's OK to run the installer</returns>
        private async Task<bool> AskApplicationToSafelyCloseUp()
        {
            try
            {
                // In case the user has shut the window that started this Sparkle window/instance, don't crash and burn.
                // If you have better ideas on how to figure out if they've shut all other windows, let me know...
                if (PreparingToExitAsync != null)
                {
                    var args = new CancelEventArgs();
                    await PreparingToExitAsync(this, args);
                    return !args.Cancel;
                }
                else if (PreparingToExit != null)
                {
                    var args = new CancelEventArgs();
                    PreparingToExit(this, args);
                    return !args.Cancel;
                }
            }
            catch (Exception e)
            {
                LogWriter.PrintMessage(e.Message);
            }
            return true;
        }


        /// <summary>
        /// Check for updates, using UI interaction appropriate for if the user initiated the update request
        /// </summary>
        public async Task<UpdateInfo> CheckForUpdatesAtUserRequest()
        {
            CheckingForUpdatesWindow = UIFactory?.ShowCheckingForUpdates();
            if (CheckingForUpdatesWindow != null)
            {
                CheckingForUpdatesWindow.UpdatesUIClosing += CheckingForUpdatesWindow_Closing; // to detect canceling
                CheckingForUpdatesWindow.Show();
            }

            UpdateInfo updateData = await CheckForUpdates(); // handles UpdateStatus.UpdateAvailable (in terms of UI)
            if (CheckingForUpdatesWindow != null) // if null, user closed 'Checking for Updates...' window or the UIFactory was null
            {
                CheckingForUpdatesWindow?.Close();
                CallFuncConsideringUIThreads(() =>
                {
                    switch (updateData.Status)
                    {
                        case UpdateStatus.UpdateNotAvailable:
                            UIFactory?.ShowVersionIsUpToDate();
                            break;
                        case UpdateStatus.UserSkipped:
                            UIFactory?.ShowVersionIsSkippedByUserRequest(); // they can get skipped version from Configuration
                            break;
                        case UpdateStatus.CouldNotDetermine:
                            UIFactory?.ShowCannotDownloadAppcast(AppCastUrl);
                            break;
                    }
                });
            }

            return updateData;// in this case, we've already shown UI talking about the new version
        }

        private void CheckingForUpdatesWindow_Closing(object sender, EventArgs e)
        {
            CheckingForUpdatesWindow = null;
        }

        /// <summary>
        /// Check for updates, using interaction appropriate for where the user doesn't know you're doing it, so be polite.
        /// Basically, this checks for updates without showing a UI. However, if a UIFactory is set and an update
        /// is found, an update UI will be shown!
        /// </summary>
        public async Task<UpdateInfo> CheckForUpdatesQuietly()
        {
            return await CheckForUpdates();
        }

        /// <summary>
        /// Does a one-off check for updates
        /// </summary>
        private async Task<UpdateInfo> CheckForUpdates()
        {
            // artificial delay -- if internet is super fast and the update check is super fast, the flash (fast show/hide) of the
            // 'Checking for Updates...' window is very disorienting, so we add an artificial delay
            bool isUserManuallyCheckingForUpdates = CheckingForUpdatesWindow != null;
            if (isUserManuallyCheckingForUpdates)
            {
                await Task.Delay(250);
            }
            UpdateCheckStarted?.Invoke(this);
            Configuration config = Configuration;

            // check if update is required
            _latestDownloadedUpdateInfo = await GetUpdateStatus(config);
            List<AppCastItem> updates = _latestDownloadedUpdateInfo.Updates;
            if (_latestDownloadedUpdateInfo.Status == UpdateStatus.UpdateAvailable)
            {
                // show the update window
                LogWriter.PrintMessage("Update needed from version {0} to version {1}", config.InstalledVersion, updates[0].Version);

                UpdateDetectedEventArgs ev = new UpdateDetectedEventArgs
                {
                    NextAction = NextUpdateAction.ShowStandardUserInterface,
                    ApplicationConfig = config,
                    LatestVersion = updates[0],
                    AppCastItems = updates
                };

                // if the client wants to intercept, send an event
                if (UpdateDetected != null)
                {
                    UpdateDetected(this, ev);
                    // if the client wants the default UI then show them
                    switch (ev.NextAction)
                    {
                        case NextUpdateAction.ShowStandardUserInterface:
                            LogWriter.PrintMessage("Showing standard update UI");
                            OnWorkerProgressChanged(_taskWorker, new ProgressChangedEventArgs(1, updates));
                            break;
                    }
                }
                else
                {
                    // otherwise just go forward with the UI notification
                    if (isUserManuallyCheckingForUpdates && CheckingForUpdatesWindow != null)
                    {
                        ShowUpdateNeededUI(updates);
                    }
                }
            }
            UpdateCheckFinished?.Invoke(this, _latestDownloadedUpdateInfo.Status);
            return _latestDownloadedUpdateInfo;
        }

        /// <summary>
        /// Cancels an in-progress download and deletes the temporary file.
        /// </summary>
        public void CancelFileDownload()
        {
            LogWriter.PrintMessage("Canceling download...");
            if (UpdateDownloader != null && UpdateDownloader.IsDownloading)
            {
                UpdateDownloader.CancelDownload();
            }
        }

        /// <summary>
        /// Events should always be fired on the thread that started the Sparkle object.
        /// Used for events that are fired after coming from an update available window
        /// or the download progress window.
        /// Basically, if ShowsUIOnMainThread, just invokes the action. Otherwise,
        /// uses the SynchronizationContext to call the action. Ensures that the action
        /// is always on the main thread.
        /// </summary>
        /// <param name="action"></param>
        private void CallFuncConsideringUIThreads(Action? action)
        {
            if (ShowsUIOnMainThread)
            {
                action?.Invoke();
            }
            else
            {
                _syncContext.Post((state) => action?.Invoke(), null);
            }
        }

        /// <summary>
        /// Events should always be fired on the thread that started the Sparkle object.
        /// Used for events that are fired after coming from an update available window
        /// or the download progress window.
        /// Basically, if ShowsUIOnMainThread, just invokes the action. Otherwise,
        /// uses the SynchronizationContext to call the action. Ensures that the action
        /// is always on the main thread.
        /// </summary>
        /// <param name="action"></param>
        private async Task CallFuncConsideringUIThreadsAsync(Func<Task>? action)
        {
            if (ShowsUIOnMainThread)
            {
                await action?.Invoke();
            }
            else
            {
                _syncContext.Post(async (state) => await action?.Invoke(), null);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender">not used.</param>
        /// <param name="args">Info on the user response and what update item they responded to</param>
        private async void OnUserWindowUserResponded(object sender, UpdateResponseEventArgs args)
        {
            LogWriter.PrintMessage("Update window response: {0}", args.Result);
            var currentItem = args.UpdateItem;
            var result = args.Result;
            if (string.IsNullOrWhiteSpace(_downloadTempFileName))
            {
                // we need the download file name in order to tell the user the skipped version
                // file path and/or to run the installer
                _downloadTempFileName = await GetDownloadPathForAppCastItem(currentItem);
            }
            if (result == UpdateAvailableResult.SkipUpdate)
            {
                // skip this version
                Configuration.SetVersionToSkip(currentItem.Version);
                CallFuncConsideringUIThreads(() => { UserRespondedToUpdate?.Invoke(this, new UpdateResponseEventArgs(result, currentItem)); });
            }
            else if (result == UpdateAvailableResult.InstallUpdate)
            {
                await CallFuncConsideringUIThreadsAsync(async () =>
                {
                    UserRespondedToUpdate?.Invoke(this, new UpdateResponseEventArgs(result, currentItem));
                    if (UserInteractionMode == UserInteractionMode.DownloadNoInstall && File.Exists(_downloadTempFileName))
                    {
                        // Binary should already be downloaded. Run it!
                        ProgressWindowCompleted(this, new DownloadInstallEventArgs(true));
                    }
                    else
                    {
                        // download the binaries
                        await InitAndBeginDownload(currentItem);
                    }
                });
            }
            else if (result == UpdateAvailableResult.RemindMeLater && currentItem != null)
            {
                CallFuncConsideringUIThreads(() => { UserRespondedToUpdate?.Invoke(this, new UpdateResponseEventArgs(result, currentItem)); });
            }
            UpdateAvailableWindow?.Close();
            UpdateAvailableWindow = null; // done using the window so don't hold onto reference
            CheckingForUpdatesWindow?.Close();
            CheckingForUpdatesWindow = null;
        }

        /// <summary>
        /// This method will be executed as worker thread
        /// </summary>
        private async void OnWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            // store the did run once feature
            bool goIntoLoop = true;
            bool checkTSP = true;
            bool doInitialCheck = _doInitialCheck;
            bool isInitialCheck = true;

            // start our lifecycles
            do
            {
                if (_cancelToken.IsCancellationRequested)
                {
                    break;
                }
                // set state
                bool bUpdateRequired = false;

                // notify
                LoopStarted?.Invoke(this);

                // report status
                if (doInitialCheck)
                {
                    // report status
                    LogWriter.PrintMessage("Starting update loop...");

                    // read the config
                    LogWriter.PrintMessage("Reading config...");
                    Configuration config = Configuration;

                    // calc CheckTasp
                    bool checkTSPInternal = checkTSP;

                    if (isInitialCheck && checkTSPInternal)
                    {
                        checkTSPInternal = !_forceInitialCheck;
                    }

                    // check if it's ok the recheck to software state
                    TimeSpan csp = DateTime.Now - config.LastCheckTime;

                    if (!checkTSPInternal || csp >= _checkFrequency)
                    {
                        checkTSP = true;
                        // when sparkle will be deactivated wait another cycle
                        if (config.CheckForUpdate == true)
                        {
                            // update the runonce feature
                            goIntoLoop = !config.IsFirstRun;

                            // check if update is required
                            if (_cancelToken.IsCancellationRequested || !goIntoLoop)
                            {
                                break;
                            }
                            _latestDownloadedUpdateInfo = await GetUpdateStatus(config);
                            if (_cancelToken.IsCancellationRequested)
                            {
                                break;
                            }
                            bUpdateRequired = _latestDownloadedUpdateInfo.Status == UpdateStatus.UpdateAvailable;
                            if (bUpdateRequired)
                            {
                                List<AppCastItem> updates = _latestDownloadedUpdateInfo.Updates;
                                // show the update window
                                LogWriter.PrintMessage("Update needed from version {0} to version {1}", config.InstalledVersion, updates[0].Version);

                                // send notification if needed
                                UpdateDetectedEventArgs ev = new UpdateDetectedEventArgs
                                {
                                    NextAction = NextUpdateAction.ShowStandardUserInterface,
                                    ApplicationConfig = config,
                                    LatestVersion = updates[0],
                                    AppCastItems = updates
                                };
                                UpdateDetected?.Invoke(this, ev);

                                // check results
                                switch (ev.NextAction)
                                {
                                    case NextUpdateAction.PerformUpdateUnattended:
                                        {
                                            LogWriter.PrintMessage("Unattended update desired from consumer");
                                            UserInteractionMode = UserInteractionMode.DownloadAndInstall;
                                            OnWorkerProgressChanged(_taskWorker, new ProgressChangedEventArgs(1, updates));
                                            break;
                                        }
                                    case NextUpdateAction.ProhibitUpdate:
                                        {
                                            LogWriter.PrintMessage("Update prohibited from consumer");
                                            break;
                                        }
                                    default:
                                        {
                                            LogWriter.PrintMessage("Preparing to show standard update UI");
                                            OnWorkerProgressChanged(_taskWorker, new ProgressChangedEventArgs(1, updates));
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            LogWriter.PrintMessage("Check for updates disabled");
                        }
                    }
                    else
                    {
                        LogWriter.PrintMessage("Update check performed within the last {0} minutes!", _checkFrequency.TotalMinutes);
                    }
                }
                else
                {
                    LogWriter.PrintMessage("Initial check prohibited, going to wait");
                    doInitialCheck = true;
                }

                // checking is done; this is now the "let's wait a while" section

                // reset initial check
                isInitialCheck = false;

                // notify
                LoopFinished?.Invoke(this, bUpdateRequired);

                // report wait statement
                LogWriter.PrintMessage("Sleeping for an other {0} minutes, exit event or force update check event", _checkFrequency.TotalMinutes);

                // wait for
                if (!goIntoLoop || _cancelToken.IsCancellationRequested)
                {
                    break;
                }

                // build the event array
                WaitHandle[] handles = new WaitHandle[1];
                handles[0] = _exitHandle;

                // wait for any
                if (_cancelToken.IsCancellationRequested)
                {
                    break;
                }
                int i = WaitHandle.WaitAny(handles, _checkFrequency);
                if (_cancelToken.IsCancellationRequested)
                {
                    break;
                }
                if (WaitHandle.WaitTimeout == i)
                {
                    LogWriter.PrintMessage("{0} minutes are over", _checkFrequency.TotalMinutes);
                    continue;
                }

                // check the exit handle
                if (i == 0)
                {
                    LogWriter.PrintMessage("Got exit signal");
                    break;
                }

                // check an other check needed
                if (i == 1)
                {
                    LogWriter.PrintMessage("Got force update check signal");
                    checkTSP = false;
                }
                if (_cancelToken.IsCancellationRequested)
                {
                    break;
                }
            } while (goIntoLoop);

            // reset the islooping handle
            _loopingHandle.Reset();
        }

        /// <summary>
        /// This method will be notified by the SparkleUpdater loop when
        /// some update info has been downloaded. If the info has been 
        /// downloaded fully (e.ProgressPercentage == 1), the UI
        /// for downloading updates will be shown (if not downloading silently)
        /// or the download will be performed (if downloading silently).
        /// </summary>
        private void OnWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 1:
                    UpdatesHaveBeenDownloaded(e.UserState as List<AppCastItem>);
                    break;
                case 0:
                    LogWriter.PrintMessage(e.UserState.ToString());
                    break;
            }
        }

        /// <summary>
        /// Updates from appcast have been downloaded from the server
        /// </summary>
        /// <param name="updates">updates to be installed</param>
        private async void UpdatesHaveBeenDownloaded(List<AppCastItem>? updates)
        {
            if (updates != null)
            {
                if (IsDownloadingSilently())
                {
                    await InitAndBeginDownload(updates[0]); // install only latest
                }
                else
                {
                    // show the update UI
                    ShowUpdateNeededUI(updates);
                }
            }
        }
    }
}