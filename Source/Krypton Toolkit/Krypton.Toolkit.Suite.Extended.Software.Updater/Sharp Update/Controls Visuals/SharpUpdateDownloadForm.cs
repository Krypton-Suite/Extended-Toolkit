namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    public partial class SharpUpdateDownloadForm : KryptonForm
    {
        #region Instance Fields

        /// <summary>
        /// The web client to download the update
        /// </summary>
        private WebClient _webClient;

        /// <summary>
        /// The thread to hash the file on
        /// </summary>
        private BackgroundWorker _bgWorker;

        /// <summary>
        /// The MD5 hash of the file to download
        /// </summary>
        private string _md5;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the temp file path for the downloaded file
        /// </summary>
        internal string TempFilePath { get; }

        #endregion

        public SharpUpdateDownloadForm(Uri location, string md5, Icon? programIcon)
        {
            InitializeComponent();

            if (programIcon != null)
            {
                Icon = programIcon;
            }

            TempFilePath = Path.GetTempFileName();

            _md5 = md5;

            _webClient = new WebClient();

            _webClient.DownloadProgressChanged += DownloadProgressChanged;

            _webClient.DownloadFileCompleted += DownloadFileCompleted;

            _bgWorker = new BackgroundWorker();

            _bgWorker.DoWork += DoWork;

            _bgWorker.RunWorkerCompleted += RunWorkerCompleted;

            try
            {
                _webClient.DownloadFileAsync(location, TempFilePath);
            }
            catch (Exception e)
            {
                DialogResult = DialogResult.No;

                Close();
            }
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                DialogResult = DialogResult.No;

                Close();
            }
            else if (e.Cancelled)
            {
                DialogResult = DialogResult.Abort;

                Close();
            }
            else
            {
                // Show the "Hashing" label and set the progressbar to marquee
                klblProgress.Text = ;

                kpbDownloadProgress.Style = ProgressBarStyle.Marquee;

                // Start the hashing
                _bgWorker.RunWorkerAsync(new string[] { TempFilePath, _md5 });
            }
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            klblProgress.Text =
                $"{} {FormatBytes(e.BytesReceived, 1, true)} {} {FormatBytes(e.TotalBytesToReceive, 1, true)}";

            kpbDownloadProgress.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Formats the byte count to closest byte type
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

            return string.Format(formatString, newBytes);
        }
    }
}
