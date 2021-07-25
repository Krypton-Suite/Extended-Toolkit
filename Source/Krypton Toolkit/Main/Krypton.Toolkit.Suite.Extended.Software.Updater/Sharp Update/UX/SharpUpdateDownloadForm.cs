namespace Krypton.Toolkit.Suite.Extended.Software.Updater.SharpUpdate
{
    internal class SharpUpdateDownloadForm : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private ProgressBar progressBarAll;
        private KryptonLabel klblProgress;
        private ProgressBar progressBar;
        private KryptonLabel klblDownloading;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.progressBarAll = new System.Windows.Forms.ProgressBar();
            this.klblProgress = new Krypton.Toolkit.KryptonLabel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.klblDownloading = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.progressBarAll);
            this.kryptonPanel1.Controls.Add(this.klblProgress);
            this.kryptonPanel1.Controls.Add(this.progressBar);
            this.kryptonPanel1.Controls.Add(this.klblDownloading);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(413, 196);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // progressBarAll
            // 
            this.progressBarAll.Location = new System.Drawing.Point(34, 151);
            this.progressBarAll.Name = "progressBarAll";
            this.progressBarAll.Size = new System.Drawing.Size(344, 23);
            this.progressBarAll.TabIndex = 4;
            // 
            // klblProgress
            // 
            this.klblProgress.AutoSize = false;
            this.klblProgress.Location = new System.Drawing.Point(34, 122);
            this.klblProgress.Name = "klblProgress";
            this.klblProgress.Size = new System.Drawing.Size(344, 23);
            this.klblProgress.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblProgress.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.klblProgress.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblProgress.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.klblProgress.TabIndex = 3;
            this.klblProgress.Values.Text = "";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(34, 83);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(344, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 2;
            // 
            // klblDownloading
            // 
            this.klblDownloading.AutoSize = false;
            this.klblDownloading.Location = new System.Drawing.Point(12, 21);
            this.klblDownloading.Name = "klblDownloading";
            this.klblDownloading.Size = new System.Drawing.Size(389, 45);
            this.klblDownloading.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblDownloading.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.klblDownloading.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblDownloading.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.klblDownloading.TabIndex = 0;
            this.klblDownloading.Values.Text = "Downloading update...";
            // 
            // SharpUpdateDownloadForm
            // 
            this.ClientSize = new System.Drawing.Size(413, 196);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SharpUpdateDownloadForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Downloading Update";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        /// <summary>
        /// The web client to download the update
        /// </summary>
        private WebClient _webClient;

        /// <summary>
        /// The thread to hash the file on
        /// </summary>
        private BackgroundWorker _bgWorker;

        /// <summary>
        /// Iterating variable in the events
        /// </summary>
        private int _count = 0;

        /// <summary>
        /// Counting recieved bytes over multiple files
        /// </summary>
        private int _bytesRecievedLastTime = 0;

        /// <summary>
        /// Holds all paths to the tempfiles
        /// </summary>
        private List<SharpUpdateFileInfo> _files;
        #endregion

        #region Property
        /// <summary>
        /// Gets the list of all temp file paths for the downloaded files
        /// </summary>
        internal List<SharpUpdateFileInfo> TempFilesPath => _files;
        #endregion

        #region Constructor
        internal SharpUpdateDownloadForm(List<SharpUpdateFileInfo> files, Icon applicationIcon)
        {
            InitializeComponent();

            if (applicationIcon != null) Icon = applicationIcon;

            _files = files;

            klblDownloading.Text = LanguageEN.SharpUpdateDownloadForm_lblDownloading;

            Text = LanguageEN.SharpUpdateDownloadForm_Title;

            // Calculate the overall size and save it to progressBarAll
            progressBarAll.Maximum = 0;

            foreach (SharpUpdateFileInfo fi in _files)
            {
                progressBarAll.Maximum += Convert.ToInt32(GetSizeOfFile(fi.Url));
            }

            // Set the first file to download
            files[_count].TempFile = Path.GetTempFileName();

            // Set up WebClient to download file
            _webClient = new WebClient();
            _webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
            _webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);

            // Set up backgroundworker to hash file
            _bgWorker = new BackgroundWorker();
            _bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            _bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);

            // Download file
            try
            {
                _webClient.DownloadFileAsync(new Uri(files[_count].Url), files[_count++].TempFile);
            }
            catch
            {
                DialogResult = DialogResult.No;

                Close();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get the size of a file
        /// </summary>
        /// <param name="location">URL to the file</param>
        /// <returns>Size of file in bytes</returns>
        private static long GetSizeOfFile(string location)
        {
            try
            {
                WebRequest req = HttpWebRequest.Create(location);
                req.Method = "HEAD";
                WebResponse resp = req.GetResponse();
                long ContentLength;
                if (long.TryParse(resp.Headers.Get("Content-Length"), out ContentLength))
                {
                    resp.Close();
                    return ContentLength;
                }
                resp.Close();
                return 0;
            }
            catch { return 0; }
        }

        /// <summary>
        /// Formats the byte _count to closest byte type
        /// </summary>
        /// <param name="bytes">The amount of bytes</param>
        /// <param name="decimalPlaces">How many decimal places to show</param>
        /// <param name="showByteType">Add the byte type on the end of the string</param>
        /// <returns>The bytes formatted as specified</returns>
        private string FormatBytes(long bytes, int decimalPlaces, bool showByteType)
        {
            double newBytes = bytes;
            string formatString = "{0";
            string byteType = "B";

            // Check if best size in KB
            if (newBytes > 1024 && newBytes < 1048576)
            {
                newBytes /= 1024;
                byteType = "KB";
            }
            else if (newBytes > 1048576 && newBytes < 1073741824)
            {
                // Check if best size in MB
                newBytes /= 1048576;
                byteType = "MB";
            }
            else
            {
                // Best size in GB
                newBytes /= 1073741824;
                byteType = "GB";
            }

            // Show decimals
            if (decimalPlaces > 0)
                formatString += ":0.";

            // Add decimals
            for (int i = 0; i < decimalPlaces; i++)
                formatString += "0";

            // Close placeholder
            formatString += "}";

            // Add byte type
            if (showByteType)
                formatString += byteType;

            return String.Format(formatString, newBytes);
        }
        #endregion
    }
}