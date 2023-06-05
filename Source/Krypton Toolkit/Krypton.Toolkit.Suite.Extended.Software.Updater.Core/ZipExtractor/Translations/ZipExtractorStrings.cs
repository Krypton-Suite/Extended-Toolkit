using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.Core
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ZipExtractorStrings : GlobalId
    {
        #region Static Fields

        private const string DEFAULT_CURRENT_FILE_EXTRACTING = @"Extracting {0}";

        private const string DEFAULT_FILE_STILL_IN_USE_CAPTION = @"Unable to update file!";

        private const string DEFAULT_FILE_STILL_IN_USE_MESSAGE = @"{0} is still open and it is using ""{1}"". Please close the process manually and press Retry.";

        private const string DEFAULT_REMOVING = @"Removing {0}";

        #endregion

        #region Identity

        public ZipExtractorStrings()
        {
            Reset();
        }

        public override string ToString() => !IsDefault ? "Modified" : string.Empty;

        #endregion

        #region Public

        [Browsable(false)]
        public bool IsDefault => CurrentFileExtracting.Equals(DEFAULT_CURRENT_FILE_EXTRACTING) &&
                                 FileStillInUseCaption.Equals(DEFAULT_FILE_STILL_IN_USE_CAPTION) &&
                                 FileStillInUseMessage.Equals(DEFAULT_FILE_STILL_IN_USE_MESSAGE) && Removing.Equals(DEFAULT_REMOVING);

        public void Reset()
        {
            CurrentFileExtracting = DEFAULT_CURRENT_FILE_EXTRACTING;

            FileStillInUseCaption = DEFAULT_FILE_STILL_IN_USE_CAPTION;

            FileStillInUseMessage = DEFAULT_FILE_STILL_IN_USE_MESSAGE;

            Removing = DEFAULT_REMOVING;
        }

        /// <summary>Gets or sets the current file extracting string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised current file extracting string.")]
        [DefaultValue(DEFAULT_CURRENT_FILE_EXTRACTING)]
        [RefreshProperties(RefreshProperties.All)]
        public string CurrentFileExtracting { get; set; }

        /// <summary>Gets or sets the file still in use caption string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised file still in use caption string.")]
        [DefaultValue(DEFAULT_FILE_STILL_IN_USE_CAPTION)]
        [RefreshProperties(RefreshProperties.All)]
        public string FileStillInUseCaption { get; set; }

        /// <summary>Gets or sets the file still in use message string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised file still in use message string.")]
        [DefaultValue(DEFAULT_FILE_STILL_IN_USE_MESSAGE)]
        public string FileStillInUseMessage { get; set; }

        /// <summary>Gets or sets the removing string.</summary>
        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised removing string.")]
        [DefaultValue(DEFAULT_REMOVING)]
        [RefreshProperties(RefreshProperties.All)]
        public string Removing { get; set; }

        #endregion
    }
}