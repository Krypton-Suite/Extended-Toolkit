using Application = System.Windows.Forms.Application;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    /// <summary>
    /// Provides application update support in C#
    /// </summary>
    public class SharpUpdater
    {
        /// <summary>
        /// Parent form
        /// </summary>
        private KryptonForm _parentForm;

        /// <summary>
        /// Parent assembly
        /// </summary>
        private Assembly _parentAssembly;

        /// <summary>
        /// Parent name
        /// </summary>
        private string _parentPath;

        /// <summary>
        /// Holds the program-to-update's info
        /// </summary>
        private SharpUpdateLocalAppInfo[] _localApplicationInfos;

        /// <summary>
        /// Holds all the jobs defined in update xml
        /// </summary>
        private SharpUpdateXml[] _jobsFromXml;

        /// <summary>
        /// Total number of jobs
        /// </summary>
        private int _numJobs = 0;

        /// <summary>
        /// Lists containing all informtion for files update
        /// </summary>
        private List<string> _tempFilePaths = new List<string>();
        private List<string> _currentPaths = new List<string>();
        private List<string> _newPaths = new List<string>();
        private List<string> _launchArgss = new List<string>();
        private List<JobType> _jobtypes = new List<JobType>();

        private int _acceptJobs = 0;

        /// <summary>
        /// Thread to find update
        /// </summary>
        private BackgroundWorker _bgWorker;

        /// <summary>
        /// Uri of the update xml on the server
        /// </summary>
        private Uri _updateXmlLocation;
        //private readonly Uri UpdateXmlLocation = new Uri("https://raw.githubusercontent.com/henryxrl/SharpUpdate/master/project.xml");
        //private readonly Uri UpdateXmlLocation = new Uri(new FileInfo(@"..\..\..\project.xml").FullName);       // for local testing

        /// <summary>
        /// Creates a new SharpUpdater object
        /// </summary>
        /// <param name="a">Parent assembly to be attached</param>
        /// <param name="owner">Parent form to be attached</param>
        /// <param name="xmlOnServer">Uri of the update xml on the server</param>
        public SharpUpdater(Assembly a, KryptonForm owner, Uri xmlOnServer)
        {
            _parentForm = owner;
            _parentAssembly = a;
            _parentPath = a.Location;

            _updateXmlLocation = xmlOnServer;

            // Set up backgroundworker
            _bgWorker = new BackgroundWorker();
            _bgWorker.DoWork += new DoWorkEventHandler(BgWorker_DoWork);
            _bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BgWorker_RunWorkerCompleted);
        }

        /// <summary>
        /// Checks for an update for the files passed.
        /// If there is an update, a dialog asking to download will appear
        /// </summary>
        public void DoUpdate()
        {
            if (!_bgWorker.IsBusy)
                _bgWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Checks for/parses update.xml on server
        /// </summary>
        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Check for update on server
            if (!SharpUpdateXml.ExistsOnServer(_updateXmlLocation))
                e.Cancel = true;
            else // Parse update xml
                e.Result = SharpUpdateXml.Parse(_updateXmlLocation);
        }

        /// <summary>
        /// After the background worker is done, prompt to update if there is one
        /// </summary>
        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // If there is a file on the server
            if (!e.Cancelled)
            {
                _jobsFromXml = (SharpUpdateXml[])e.Result;

                // Check if the update is not null and is a newer version than the current application
                if (_jobsFromXml != null)
                {
                    Console.WriteLine("Number of updates from XML: " + _jobsFromXml.Length);

                    // create local app info according to update xml
                    _numJobs = _jobsFromXml.Length;
                    _localApplicationInfos = new SharpUpdateLocalAppInfo[_numJobs];
                    for (int i = 0; i < _numJobs; ++i)
                    {
                        if (Path.GetFileName(_parentPath).CompareTo(Path.GetFileName(_jobsFromXml[i].FilePath)) == 0)
                        {
                            _localApplicationInfos[i] = new SharpUpdateLocalAppInfo(_jobsFromXml[i], _parentAssembly, _parentForm);
                        }
                        else
                        {
                            _localApplicationInfos[i] = new SharpUpdateLocalAppInfo(_jobsFromXml[i]);
                        }
                        _localApplicationInfos[i].Print();
                    }

                    // validate all update jobs
                    List<int> validJobs = new List<int>();
                    for (int i = 0; i < _numJobs; ++i)
                    {
                        if (_jobsFromXml[i].Tag == JobType.UPDATE)
                        {
                            if (!_jobsFromXml[i].IsNewerThan(_localApplicationInfos[i].Version))
                                continue;
                        }
                        validJobs.Add(i);
                    }

                    // let user choose to accept update jobs
                    bool showMsgBox = true;
                    int count = 0;
                    foreach (int i in validJobs)
                    {
                        count++;
                        showMsgBox = false;

                        // Ask to accept the update
                        if (new SharpUpdateAcceptForm(_localApplicationInfos[i], _jobsFromXml[i], count, validJobs.Count).ShowDialog(_localApplicationInfos[0].Context) == DialogResult.Yes)
                        {
                            _acceptJobs++;
                            DownloadUpdate(_jobsFromXml[i], _localApplicationInfos[i]); // Do the update
                        }
                    }

                    if (showMsgBox)
                    {
                        KryptonMessageBox.Show(_parentForm, "You have the latest versions already!");
                    }
                    else
                    {
                        if (_acceptJobs > 0)
                            InstallUpdate();
                    }
                }
                else
                    KryptonMessageBox.Show(_parentForm, "You have the latest versions already!");
            }
            else
                KryptonMessageBox.Show(_parentForm, "No update information found!");
        }

        /// <summary>
        /// Download the update
        /// </summary>
        /// <param name="update">The update xml info</param>
        /// <param name="applicationInfo">An SharpUpdateInfo object containing application's info</param>
        private void DownloadUpdate(SharpUpdateXml update, SharpUpdateLocalAppInfo applicationInfo)
        {
            if (update.Tag == JobType.REMOVE)
            {
                _tempFilePaths.Add("");
                _currentPaths.Add("");
                _newPaths.Add(Path.GetFullPath(applicationInfo.ApplicationPath));
                _launchArgss.Add(update.LaunchArgs);
                _jobtypes.Add(update.Tag);
                return;
            }

            SharpUpdateDownloadForm form = new SharpUpdateDownloadForm(update.Uri, update.MD5, applicationInfo.ApplicationIcon);
            DialogResult result = form.ShowDialog(applicationInfo.Context);

            if (result == DialogResult.OK)
            {
                string currentPath = (update.Tag == JobType.UPDATE) ? applicationInfo.ApplicationAssembly.Location : "";
                string newPath = (update.Tag == JobType.UPDATE) ? Path.GetFullPath(Path.GetDirectoryName(currentPath).ToString() + update.FilePath) : Path.GetFullPath(applicationInfo.ApplicationPath);
                Directory.CreateDirectory(Path.GetDirectoryName(newPath));

                _tempFilePaths.Add(form.TempFilePath);
                _currentPaths.Add(currentPath);
                _newPaths.Add(newPath);
                _launchArgss.Add(update.LaunchArgs);
                _jobtypes.Add(update.Tag);
            }
            else if (result == DialogResult.Abort)
            {
                KryptonMessageBox.Show(_parentForm, "The update download was cancelled.\nThis program has not been modified.", "Update Download Cancelled", KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon.Information);
            }
            else
            {
                KryptonMessageBox.Show(_parentForm, "There was a problem downloading the update.\nPlease try again later.", "Update Download Error", KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Install all the updates
        /// </summary>
        private void InstallUpdate()
        {
            // ToDo: Uncomment once timeouts are supported
            //MessageBoxEx.Show(_parentForm, "Application restarts in 5 seconds", "Success", 5000);
            UpdateApplications();
            Application.Exit();
        }

        /// <summary>
        /// Hack to close program, delete original, move the new one to that location
        /// </summary>
        private void UpdateApplications()
        {
            string argumentStart = "/C choice /C Y /N /D Y /T 4 & Start \"\" /D \"{0}\" \"{1}\"";
            string argumentUpdate = "/C choice /C Y /N /D Y /T 4 & Del /F /Q \"{0}\" & choice /C Y /N /D Y /T 2 & Move /Y \"{1}\" \"{2}\"";
            string argumentUpdateStart = argumentUpdate + " & Start \"\" /D \"{3}\" \"{4}\" {5}";
            string argumentAdd = "/C choice /C Y /N /D Y /T 4 & Move /Y \"{0}\" \"{1}\"";
            string argumentRemove = "/C choice /C Y /N /D Y /T 4 & Del /F /Q \"{0}\"";
            string argumentComplete = "";

            int curAppidx = -1;
            for (int i = 0; i < _acceptJobs; ++i)
            {
                string curName = Path.GetFileName(_currentPaths[i]);
                if (curName.CompareTo("") != 0 && Path.GetFileName(_parentPath).CompareTo(curName) == 0)
                {
                    curAppidx = i;
                    continue;
                }

                if (_jobtypes[i] == JobType.ADD)
                {
                    argumentComplete = string.Format(argumentAdd, _tempFilePaths[i], _newPaths[i]);
                    Console.WriteLine("add: " + argumentComplete);
                }
                else if (_jobtypes[i] == JobType.UPDATE)
                {
                    argumentComplete = string.Format(argumentUpdate, _currentPaths[i], _tempFilePaths[i], _newPaths[i]);
                    Console.WriteLine("update: " + argumentComplete);
                }
                else
                {
                    argumentComplete = string.Format(argumentRemove, _newPaths[i]);
                    Console.WriteLine("remove: " + argumentComplete);
                }

                ProcessStartInfo cmd = new ProcessStartInfo
                {
                    Arguments = argumentComplete,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName = "cmd.exe"
                };
                Process.Start(cmd);
            }

            if (curAppidx > -1)
            {
                argumentComplete = string.Format(argumentUpdateStart, _currentPaths[curAppidx], _tempFilePaths[curAppidx], _newPaths[curAppidx], Path.GetDirectoryName(_newPaths[curAppidx]), Path.GetFileName(_newPaths[curAppidx]), _launchArgss[curAppidx]);
                Console.WriteLine("Update and run main app: " + argumentComplete);
            }
            else
            {
                argumentComplete = string.Format(argumentStart, Path.GetDirectoryName(_parentPath), Path.GetFileName(_parentPath));
                Console.WriteLine("Run main app: " + argumentComplete);
            }

            ProcessStartInfo cmdMain = new ProcessStartInfo
            {
                Arguments = argumentComplete,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            };
            Process.Start(cmdMain);
        }
    }
}