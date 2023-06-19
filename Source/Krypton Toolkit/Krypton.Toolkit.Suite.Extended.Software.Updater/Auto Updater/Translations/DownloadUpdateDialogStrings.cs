using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class DownloadUpdateDialogStrings : GlobalId
    {
        #region Static Fields

        private const string DEFAULT_WINDOW_TITLE = @"Software Update";

        private const string DEFAULT_DESCRIPTION = @"Downloading update, please wait...";

        #endregion

        #region Identity

        public DownloadUpdateDialogStrings()
        {
            Reset();
        }

        public override string ToString() => !IsDefault ? "Modified" : string.Empty;

        #endregion

        #region Public

        [Browsable(false)]
        public bool IsDefault => WindowTitle.Equals(DEFAULT_WINDOW_TITLE) &&
                                 Description.Equals(DEFAULT_DESCRIPTION);

        public void Reset()
        {
            WindowTitle = DEFAULT_WINDOW_TITLE;

            Description = DEFAULT_DESCRIPTION;
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

        #endregion
    }
}