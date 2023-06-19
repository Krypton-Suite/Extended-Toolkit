using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class RemindLaterWindowStrings : GlobalId
    {
        #region Static Fields

        private const string DEFAULT_WINDOW_TITLE = @"Remind me later to update";

        private const string DEFAULT_DESCRIPTION = @"You should download updates now. This only takes few minutes depending on your internet connection and ensures you have latest version of the application.";

        private const string DEFAULT_HEADER_TEXT = @"Do you want to download updates later?";

        private const string DEFAULT_YES_TEXT = @"Yes, please remind me later :";

        private const string DEFAULT_NO_TEXT = @"No, download updates now (recommended)";

        #endregion

        #region Identity

        public RemindLaterWindowStrings()
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
                                 YesText.Equals(DEFAULT_YES_TEXT) &&
                                 NoText.Equals(DEFAULT_NO_TEXT);

        public void Reset()
        {
            WindowTitle = DEFAULT_WINDOW_TITLE;

            Description = DEFAULT_DESCRIPTION;

            HeaderText = DEFAULT_HEADER_TEXT;

            YesText = DEFAULT_YES_TEXT;

            NoText = DEFAULT_NO_TEXT;
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

        // <summary>Gets or sets the yes radio button text string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised yes radio button text string.")]
        [DefaultValue(DEFAULT_YES_TEXT)]
        [RefreshProperties(RefreshProperties.All)]
        public string YesText { get; set; }

        // <summary>Gets or sets the no radio button text string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised no radio button text string.")]
        [DefaultValue(DEFAULT_NO_TEXT)]
        [RefreshProperties(RefreshProperties.All)]
        public string NoText { get; set; }

        #endregion
    }
}