namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    /// <summary>Exposes a set of strings, used by AutoUpdater.</summary>
    /// <seealso cref="GlobalId" />
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class AutoUpdaterStrings : GlobalId
    {
        #region Static Fields

        private const string DEFAULT_DOWNLOAD_SPEED_MESSAGE = @"Downloading at {0}/s";

        private const string DEFAULT_FILE_INTEGRITY_CHECK_FAILED_CAPTION = @"Checksum differs";

        private const string DEFAULT_FILE_INTEGRITY_CHECK_FAILED_MESSAGE = @"File integrity check failed and reported some errors.";

        private const string DEFAULT_HASH_ALGORITHM_NOT_SUPPORTED_CAPTION = @"Unsupported Hash Algorithm";

        private const string DEFAULT_HASH_ALGORITHM_NOT_SUPPORTED_MESSAGE = @"Hash algorithm provided in the XML file is not supported.";

        private const string DEFAULT_UNABLE_TO_DETERMINE_FILENAME_MESSAGE = @"Unable to determine the filename of the update file!";

        private const string DEFAULT_UPDATE_CHECK_FAILED_CAPTION = @"Update Check Failed";

        private const string DEFAULT_UPDATE_CHECK_FAILED_MESSAGE = @"There is a problem reaching update server. Please check your internet connection and try again later.";

        private const string DEFAULT_UPDATE_UNAVAILABLE_CAPTION = @"Update Unvailable";

        private const string DEFAULT_UPDATE_UNAVAILABLE_MESSAGE = @"There is no update available. Please try again later.";

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="AutoUpdaterStrings" /> class.</summary>
        public AutoUpdaterStrings()
        {
            Reset();
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() => !IsDefault ? "Modified" : string.Empty;

        #endregion

        #region Public

        /// <summary>Gets a value indicating whether this instance is default.</summary>
        /// <value><c>true</c> if this instance is default; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsDefault => DownloadSpeedMessage.Equals(DEFAULT_DOWNLOAD_SPEED_MESSAGE) &&
                                 FileIntegrityCheckFailedCaption.Equals(DEFAULT_FILE_INTEGRITY_CHECK_FAILED_CAPTION) &&
                                 FileIntegrityCheckFailedMessage.Equals(DEFAULT_FILE_INTEGRITY_CHECK_FAILED_MESSAGE) &&
                                 HashAlgorithmNotSupportedCaption.Equals(DEFAULT_HASH_ALGORITHM_NOT_SUPPORTED_CAPTION) &&
                                 HashAlgorithmNotSupportedMessage.Equals(DEFAULT_HASH_ALGORITHM_NOT_SUPPORTED_MESSAGE) &&
                                 UnableToDetermineFilenameMessage.Equals(DEFAULT_UNABLE_TO_DETERMINE_FILENAME_MESSAGE) &&
                                 UpdateCheckFailedCaption.Equals(DEFAULT_UPDATE_CHECK_FAILED_CAPTION) &&
                                 UpdateCheckFailedMessage.Equals(DEFAULT_UPDATE_CHECK_FAILED_MESSAGE) &&
                                 UpdateUnavailableCaption.Equals(DEFAULT_UPDATE_UNAVAILABLE_CAPTION) &&
                                 UpdateUnavailableMessage.Equals(DEFAULT_UPDATE_UNAVAILABLE_MESSAGE);

        /// <summary>Resets this instance.</summary>
        public void Reset()
        {
            DownloadSpeedMessage = DEFAULT_DOWNLOAD_SPEED_MESSAGE;

            FileIntegrityCheckFailedCaption = DEFAULT_FILE_INTEGRITY_CHECK_FAILED_CAPTION;

            FileIntegrityCheckFailedMessage = DEFAULT_FILE_INTEGRITY_CHECK_FAILED_MESSAGE;

            HashAlgorithmNotSupportedCaption = DEFAULT_HASH_ALGORITHM_NOT_SUPPORTED_CAPTION;

            HashAlgorithmNotSupportedMessage = DEFAULT_HASH_ALGORITHM_NOT_SUPPORTED_MESSAGE;

            UnableToDetermineFilenameMessage = DEFAULT_UNABLE_TO_DETERMINE_FILENAME_MESSAGE;

            UpdateCheckFailedCaption = DEFAULT_UPDATE_CHECK_FAILED_CAPTION;

            UpdateCheckFailedMessage = DEFAULT_UPDATE_CHECK_FAILED_MESSAGE;

            UpdateUnavailableCaption = DEFAULT_UPDATE_UNAVAILABLE_CAPTION;

            UpdateUnavailableMessage = DEFAULT_UPDATE_UNAVAILABLE_MESSAGE;
        }

        // <summary>Gets or sets the download speed message string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised download speed message string.")]
        [DefaultValue(DEFAULT_DOWNLOAD_SPEED_MESSAGE)]
        [RefreshProperties(RefreshProperties.All)]
        public string DownloadSpeedMessage { get; set; }

        // <summary>Gets or sets the file integrity check failed caption string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised file integrity check failed caption string.")]
        [DefaultValue(DEFAULT_FILE_INTEGRITY_CHECK_FAILED_CAPTION)]
        [RefreshProperties(RefreshProperties.All)]
        public string FileIntegrityCheckFailedCaption { get; set; }

        // <summary>Gets or sets the file integrity check failed message string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised file integrity check failed message string.")]
        [DefaultValue(DEFAULT_FILE_INTEGRITY_CHECK_FAILED_MESSAGE)]
        [RefreshProperties(RefreshProperties.All)]
        public string FileIntegrityCheckFailedMessage { get; set; }

        // <summary>Gets or sets the hash algorithm not supported caption string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised hash algorithm not supported caption string.")]
        [DefaultValue(DEFAULT_HASH_ALGORITHM_NOT_SUPPORTED_CAPTION)]
        [RefreshProperties(RefreshProperties.All)]
        public string HashAlgorithmNotSupportedCaption { get; set; }

        // <summary>Gets or sets the hash algorithm not supported message string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised hash algorithm not supported message string.")]
        [DefaultValue(DEFAULT_HASH_ALGORITHM_NOT_SUPPORTED_MESSAGE)]
        [RefreshProperties(RefreshProperties.All)]
        public string HashAlgorithmNotSupportedMessage { get; set; }

        // <summary>Gets or sets the unable to determine file name string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised unable to determine file name string.")]
        [DefaultValue(DEFAULT_UNABLE_TO_DETERMINE_FILENAME_MESSAGE)]
        [RefreshProperties(RefreshProperties.All)]
        public string UnableToDetermineFilenameMessage { get; set; }

        // <summary>Gets or sets the update check failed caption string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised update check failed caption string.")]
        [DefaultValue(DEFAULT_UPDATE_CHECK_FAILED_CAPTION)]
        [RefreshProperties(RefreshProperties.All)]
        public string UpdateCheckFailedCaption { get; set; }

        // <summary>Gets or sets the update check failed message string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised update check failed message string.")]
        [DefaultValue(DEFAULT_UPDATE_CHECK_FAILED_MESSAGE)]
        [RefreshProperties(RefreshProperties.All)]
        public string UpdateCheckFailedMessage { get; set; }

        // <summary>Gets or sets the update unavailable caption string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised update unavailable caption string.")]
        [DefaultValue(DEFAULT_UPDATE_UNAVAILABLE_CAPTION)]
        [RefreshProperties(RefreshProperties.All)]
        public string UpdateUnavailableCaption { get; set; }

        // <summary>Gets or sets the update unavailable message string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised update unavailable message string.")]
        [DefaultValue(DEFAULT_UPDATE_UNAVAILABLE_MESSAGE)]
        [RefreshProperties(RefreshProperties.All)]
        public string UpdateUnavailableMessage { get; set; }

        #endregion
    }
}