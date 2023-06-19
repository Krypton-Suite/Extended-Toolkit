
namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class UpdateWindowStrings : GlobalId
    {
        #region Static Fields

        private const string DEFAULT_WINDOW_TITLE = @"{0} {1} is available!";

        private const string DEFAULT_DESCRIPTION = @"{0} {1} is now available. You have version {2} installed. Would you like to download it now?";

        private const string DEFAULT_HEADER_TEXT = @"A new version of {0} is available!";

        private const string DEFAULT_RELEASE_NOTES_TEXT = @"Release Notes:";

        private const string DEFAULT_SKIP_BUTTON_TEXT = @"&Skip this version";

        private const string DEFAULT_REMIND_LATER_BUTTON_TEXT = @"R&emind me later";

        private const string DEFAULT_UPDATE_BUTTON_TEXT = @"&Update";

        #endregion

        #region Identity

        public UpdateWindowStrings()
        {
            Reset();
        }

        public override string ToString() => !IsDefault ? "Modified" : string.Empty;

        #endregion

        #region Public

        [Browsable(false)]
        public bool IsDefault => WindowTitle.Equals(DEFAULT_WINDOW_TITLE) &&
                                 Description.Equals(DEFAULT_DESCRIPTION) &&
                                 HeaderText.Equals(DEFAULT_HEADER_TEXT) &&
                                 ReleaseNotesText.Equals(DEFAULT_RELEASE_NOTES_TEXT) &&
                                 SkipButtonText.Equals(DEFAULT_SKIP_BUTTON_TEXT) &&
                                 RemindLaterButtonText.Equals(DEFAULT_REMIND_LATER_BUTTON_TEXT) &&
                                 UpdateButtonText.Equals(DEFAULT_UPDATE_BUTTON_TEXT);

        public void Reset()
        {
            WindowTitle = DEFAULT_WINDOW_TITLE;

            Description = DEFAULT_DESCRIPTION;

            HeaderText = DEFAULT_HEADER_TEXT;

            ReleaseNotesText = DEFAULT_RELEASE_NOTES_TEXT;

            SkipButtonText = DEFAULT_SKIP_BUTTON_TEXT;

            RemindLaterButtonText = DEFAULT_REMIND_LATER_BUTTON_TEXT;

            UpdateButtonText = DEFAULT_UPDATE_BUTTON_TEXT;
        }

        // <summary>Gets or sets the window title string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised window title string.")]
        [DefaultValue(DEFAULT_WINDOW_TITLE)]
        [RefreshProperties(RefreshProperties.All)]
        public string WindowTitle { get; set; }

        // <summary>Gets or sets the description string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised description string.")]
        [DefaultValue(DEFAULT_DESCRIPTION)]
        [RefreshProperties(RefreshProperties.All)]
        public string Description { get; set; }

        // <summary>Gets or sets the header text string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised header text string.")]
        [DefaultValue(DEFAULT_HEADER_TEXT)]
        [RefreshProperties(RefreshProperties.All)]
        public string HeaderText { get; set; }

        // <summary>Gets or sets the release notes text string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised release notes text string.")]
        [DefaultValue(DEFAULT_RELEASE_NOTES_TEXT)]
        [RefreshProperties(RefreshProperties.All)]
        public string ReleaseNotesText { get; set; }

        // <summary>Gets or sets the skip button text string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised skip button text string.")]
        [DefaultValue(DEFAULT_SKIP_BUTTON_TEXT)]
        [RefreshProperties(RefreshProperties.All)]
        public string SkipButtonText { get; set; }

        // <summary>Gets or sets the remind later button text string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised remind later button text string.")]
        [DefaultValue(DEFAULT_REMIND_LATER_BUTTON_TEXT)]
        [RefreshProperties(RefreshProperties.All)]
        public string RemindLaterButtonText { get; set; }

        // <summary>Gets or sets the update button text string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised update button text string.")]
        [DefaultValue(DEFAULT_UPDATE_BUTTON_TEXT)]
        [RefreshProperties(RefreshProperties.All)]
        public string UpdateButtonText { get; set; }

        #endregion
    }
}