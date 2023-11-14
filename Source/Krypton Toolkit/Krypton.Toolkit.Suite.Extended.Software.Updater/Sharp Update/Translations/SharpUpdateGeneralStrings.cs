namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SharpUpdateGeneralStrings : GlobalId
    {
        #region Static Fields

        private const string DEFAULT_TITLE = @"Available Update";

        private const string DEFAULT_NEW_VERSION = @"New Version";

        private const string DEFAULT_NEW = @"New";

        private const string DEFAULT_VERSION = @"Version";

        private const string DEFAULT_UPDATE = @"Update";

        #endregion

        #region Identity

        public SharpUpdateGeneralStrings()
        {
            Reset();
        }

        public override string ToString() => !IsDefault ? "Modified" : string.Empty;

        #endregion

        #region Public

        [Browsable(false)]
        public bool IsDefault => Title.Equals(DEFAULT_TITLE) &&
                                 Update.Equals(DEFAULT_UPDATE) &&
                                 NewVersion.Equals(DEFAULT_NEW_VERSION) &&
                                 New.Equals(DEFAULT_NEW) &&
                                 Version.Equals(DEFAULT_VERSION);

        public void Reset()
        {
            Title = DEFAULT_TITLE;

            Update = DEFAULT_UPDATE;

            NewVersion = DEFAULT_NEW_VERSION;

            New = DEFAULT_NEW;

            Version = DEFAULT_VERSION;
        }

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

        #endregion
    }
}