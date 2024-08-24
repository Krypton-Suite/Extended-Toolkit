namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SharpUpdateInfoFormStrings : GlobalId
    {
        #region Static Fields

        private const string DEFAULT_BACK = @"Back";

        private const string DEFAULT_DETAILS = @"Details...";

        private const string DEFAULT_HEADER = @"An update is available!\r\nWould you like to update?";

        private const string DEFAULT_REMOVE = @"Remove";

        private const string DEFAULT_WINDOW_TITLE = @"Update Info";

        private const string DEFAULT_CURRENT_VERSION = @"Current Version";

        private const string DEFAULT_UPDATE_VERSION = @"Update Version";

        private const string DEFAULT_VERSION = @"Version";

        #endregion

        #region Identity

        public SharpUpdateInfoFormStrings()
        {
            Reset();
        }

        public override string ToString() => !IsDefault ? "Modified" : string.Empty;

        #endregion

        #region Public

        [Browsable(false)]
        public bool IsDefault => Back.Equals(DEFAULT_BACK) &&
                                 Details.Equals(DEFAULT_DETAILS) &&
                                 Header.Equals(DEFAULT_HEADER) &&
                                 Remove.Equals(DEFAULT_REMOVE) &&
                                 WindowTitle.Equals(DEFAULT_WINDOW_TITLE) &&
                                 CurrentVersion.Equals(DEFAULT_CURRENT_VERSION) &&
                                 UpdateVersion.Equals(DEFAULT_UPDATE_VERSION) &&
                                 Version.Equals(DEFAULT_VERSION);

        public void Reset()
        {
            Back = DEFAULT_BACK;

            Details = DEFAULT_DETAILS;

            Header = DEFAULT_HEADER;

            Remove = DEFAULT_REMOVE;

            WindowTitle = DEFAULT_WINDOW_TITLE;

            CurrentVersion = DEFAULT_CURRENT_VERSION;

            UpdateVersion = DEFAULT_UPDATE_VERSION;

            Version = DEFAULT_VERSION;
        }

        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised back string.")]
        [DefaultValue(DEFAULT_BACK)]
        [RefreshProperties(RefreshProperties.All)]
        public string Back { get; set; }

        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised details string.")]
        [DefaultValue(DEFAULT_DETAILS)]
        [RefreshProperties(RefreshProperties.All)]
        public string Details { get; set; }

        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised header string.")]
        [DefaultValue(DEFAULT_HEADER)]
        [RefreshProperties(RefreshProperties.All)]
        public string Header { get; set; }

        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised remove string.")]
        [DefaultValue(DEFAULT_REMOVE)]
        [RefreshProperties(RefreshProperties.All)]
        public string Remove { get; set; }

        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised window title string.")]
        [DefaultValue(DEFAULT_WINDOW_TITLE)]
        [RefreshProperties(RefreshProperties.All)]
        public string WindowTitle { get; set; }

        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised current version string.")]
        [DefaultValue(DEFAULT_CURRENT_VERSION)]
        [RefreshProperties(RefreshProperties.All)]
        public string CurrentVersion { get; set; }

        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised update version string.")]
        [DefaultValue(DEFAULT_UPDATE_VERSION)]
        [RefreshProperties(RefreshProperties.All)]
        public string UpdateVersion { get; set; }

        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised version string.")]
        [DefaultValue(DEFAULT_VERSION)]
        [RefreshProperties(RefreshProperties.All)]
        public string Version { get; set; }

        #endregion
    }
}