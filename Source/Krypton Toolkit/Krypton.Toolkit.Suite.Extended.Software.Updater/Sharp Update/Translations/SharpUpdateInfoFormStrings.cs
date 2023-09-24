namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SharpUpdateInfoFormStrings : GlobalId
    {
        #region Static Fields

        private const string DEFAULT_DETAILS = @"Details...";

        private const string DEFAULT_HEADER = @"An update is available!\r\nWould you like to update?";

        private const string DEFAULT_TITLE = @"Available Update";

        private const string DEFAULT_UPDATE = @"Update";

        private const string DEFAULT_NEW_VERSION = @"New Version";

        private const string DEFAULT_NEW = @"New";

        private const string DEFAULT_VERSION = @"Version";

        private const string DEFAULT_REMOVE = @"Remove";

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
        public bool IsDefault => Details.Equals(DEFAULT_DETAILS) &&
                                 Header.Equals(DEFAULT_HEADER) &&
                                 Title.Equals(DEFAULT_TITLE) &&
                                 Update.Equals(DEFAULT_UPDATE) &&
                                 NewVersion.Equals(DEFAULT_NEW_VERSION) &&
                                 New.Equals(DEFAULT_NEW) &&
                                 Version.Equals(DEFAULT_VERSION) &&
                                 Remove.Equals(DEFAULT_REMOVE);

        public void Reset()
        {
            Details = DEFAULT_DETAILS;

            Header = DEFAULT_HEADER;

            Title = DEFAULT_TITLE;

            Update = DEFAULT_UPDATE;

            NewVersion = DEFAULT_NEW_VERSION;

            New = DEFAULT_NEW;

            Version = DEFAULT_VERSION;

            Remove = DEFAULT_REMOVE;
        }

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
        [Description(@"Localised title string.")]
        [DefaultValue(DEFAULT_TITLE)]
        [RefreshProperties(RefreshProperties.All)]
        public string Title { get; set; }

        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised update string.")]
        [DefaultValue(DEFAULT_UPDATE)]
        [RefreshProperties(RefreshProperties.All)]
        public string Update { get; set; }

        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised new version string.")]
        [DefaultValue(DEFAULT_NEW_VERSION)]
        [RefreshProperties(RefreshProperties.All)]
        public string NewVersion { get; set; }

        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised new string.")]
        [DefaultValue(DEFAULT_NEW)]
        [RefreshProperties(RefreshProperties.All)]
        public string New { get; set; }

        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised version string.")]
        [DefaultValue(DEFAULT_VERSION)]
        [RefreshProperties(RefreshProperties.All)]
        public string Version { get; set; }

        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised remove string.")]
        [DefaultValue(DEFAULT_REMOVE)]
        [RefreshProperties(RefreshProperties.All)]
        public string Remove { get; set; }

        #endregion
    }
}