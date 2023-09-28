namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    [Category(@"Code")]
    [Description(@"Access 'Global' Krypton string settings.")]
    [ToolboxItem(true)]
    public class SharpUpdateLanguageManager : Component
    {
        #region Public

        [Category(@"Visuals")]
        [Description(@"Collection of SharpUpdateAcceptForm strings.")]
        [MergableProperty(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        public SharpUpdateAcceptFormStrings SharpUpdateAcceptFormStrings => AcceptFormStrings;

        private bool ShouldSerializeSharpUpdateAcceptFormStringsStrings() => !AcceptFormStrings.IsDefault;

        /// <summary>Resets the accept form strings.</summary>
        public void ResetSharpUpdateAcceptFormStringsStrings() => AcceptFormStrings.Reset();

        [Category(@"Visuals")]
        [Description(@"Collection of SharpUpdateDownloadForm strings.")]
        [MergableProperty(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        public SharpUpdateDownloadFormStrings SharpUpdateDownloadFormStrings => DownloadFormStrings;

        private bool ShouldSerializeSharpUpdateDownloadFormStringsStrings() => !DownloadFormStrings.IsDefault;

        /// <summary>Resets the download form strings.</summary>
        public void ResetSharpUpdateDownloadFormStringsStrings() => DownloadFormStrings.Reset();

        [Category(@"Visuals")]
        [Description(@"Collection of SharpUpdateGeneral strings.")]
        [MergableProperty(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        public SharpUpdateGeneralStrings SharpUpdateGeneralStrings => GeneralStrings;

        private bool ShouldSerializeSharpUpdateGeneralStringsStrings() => !GeneralStrings.IsDefault;

        /// <summary>Resets the accept form strings.</summary>
        public void ResetSharpUpdateGeneralStringsStrings() => GeneralStrings.Reset();

        [Category(@"Visuals")]
        [Description(@"Collection of SharpUpdateInfoForm strings.")]
        [MergableProperty(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        public SharpUpdateInfoFormStrings SharpUpdateInfoFormStrings => InfoFormStrings;

        private bool ShouldSerializeSharpUpdateInfoFormStringsStrings() => !InfoFormStrings.IsDefault;

        /// <summary>Resets the info form strings.</summary>
        public void ResetSharpUpdateInfoFormStringsStrings() => InfoFormStrings.Reset();

        #endregion

        #region Static Strings

        public static SharpUpdateAcceptFormStrings AcceptFormStrings { get; } = new SharpUpdateAcceptFormStrings();

        public static SharpUpdateDownloadFormStrings DownloadFormStrings { get; } = new SharpUpdateDownloadFormStrings();

        public static SharpUpdateGeneralStrings GeneralStrings { get; } = new SharpUpdateGeneralStrings();

        public static SharpUpdateInfoFormStrings InfoFormStrings { get; } = new SharpUpdateInfoFormStrings();

        #endregion

        #region Identity

        public SharpUpdateLanguageManager()
        {

        }

        #endregion

        #region Implementation

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDefault => !(ShouldSerializeSharpUpdateAcceptFormStringsStrings() ||
                                   ShouldSerializeSharpUpdateDownloadFormStringsStrings() ||
                                   ShouldSerializeSharpUpdateGeneralStringsStrings() ||
                                   ShouldSerializeSharpUpdateInfoFormStringsStrings());

        public void Reset()
        {
            ResetSharpUpdateAcceptFormStringsStrings();

            ResetSharpUpdateDownloadFormStringsStrings();

            ResetSharpUpdateGeneralStringsStrings();

            ResetSharpUpdateInfoFormStringsStrings();
        }

        #endregion
    }
}