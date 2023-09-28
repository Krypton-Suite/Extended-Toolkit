namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SharpUpdateDownloadFormStrings : GlobalId
    {
        #region Static Fields

        private const string DEFAULT_DOWNLOADED = @"Downloaded";

        private const string DEFAULT_OF = @"of";

        private const string DEFAULT_VARIFYING_DOWNLOAD = @"Varifying Download";

        #endregion

        #region Identity

        public SharpUpdateDownloadFormStrings()
        {
            Reset();
        }

        public override string ToString() => !IsDefault ? "Modified" : string.Empty;

        #endregion

        #region Public

        [Browsable(false)]
        public bool IsDefault => Downloaded.Equals(DEFAULT_DOWNLOADED) &&
                                 Of.Equals(DEFAULT_OF) &&
                                 VarifyingDownload.Equals(DEFAULT_VARIFYING_DOWNLOAD);

        public void Reset()
        {
            Downloaded = DEFAULT_DOWNLOADED;

            Of = DEFAULT_OF;

            VarifyingDownload = DEFAULT_VARIFYING_DOWNLOAD;
        }

        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised downloaded string.")]
        [DefaultValue(DEFAULT_DOWNLOADED)]
        [RefreshProperties(RefreshProperties.All)]
        public string Downloaded { get; set; }

        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised 'of' string.")]
        [DefaultValue(DEFAULT_OF)]
        [RefreshProperties(RefreshProperties.All)]
        public string Of { get; set; }

        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised varifying download string.")]
        [DefaultValue(DEFAULT_VARIFYING_DOWNLOAD)]
        [RefreshProperties(RefreshProperties.All)]
        public string VarifyingDownload { get; set; }

        #endregion
    }
}