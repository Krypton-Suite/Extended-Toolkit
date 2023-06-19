namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    [Category(@"code")]
    [Description(@"")]
    [ToolboxItem(true)]
    public class AutoUpdaterLanguageManager : Component
    {
        #region Public

        public AutoUpdaterStrings AutoUpdaterStrings => UpdaterStrings;

        private bool ShouldSerializeAutoUpdaterStrings() => !UpdaterStrings.IsDefault;

        public void ResetAutoUpdaterStrings() => UpdaterStrings.Reset();

        public DownloadUpdateDialogStrings DownloadUpdateDialogStrings => UpdateDialogStrings;

        private bool ShouldSerializeDownloadUpdateDialogStrings() => !UpdateDialogStrings.IsDefault;

        public void ResetDownloadUpdateDialogStrings() => UpdateDialogStrings.Reset();

        public RemindLaterTimingStrings RemindLaterTimingStrings => TimingStrings;

        private bool ShouldSerializeRemindLaterTimingStrings() => !TimingStrings.IsDefault;

        public void ResetRemindLaterTimingStrings() => TimingStrings.Reset();

        public RemindLaterWindowStrings RemindLaterWindowStrings => LaterWindowStrings;

        private bool ShouldSerializeRemindLaterWindowStrings() => !LaterWindowStrings.IsDefault;

        public void ResetRemindLaterWindowStrings() => LaterWindowStrings.Reset();

        public UpdateWindowStrings UpdateWindowStrings => WindowStrings;

        private bool ShouldSerializeUpdateWindowStrings() => !WindowStrings.IsDefault;

        public void ResetUpdateWindowStrings() => WindowStrings.Reset();

        #endregion

        #region Static Strings

        public static AutoUpdaterStrings UpdaterStrings
        { get; } = new();

        public static DownloadUpdateDialogStrings UpdateDialogStrings { get; } = new();

        public static RemindLaterTimingStrings TimingStrings { get; } = new();

        public static RemindLaterWindowStrings LaterWindowStrings { get; } = new();

        public static UpdateWindowStrings WindowStrings { get; } = new();

        #endregion

        #region Identity

        public AutoUpdaterLanguageManager()
        {

        }

        #endregion

        #region Implementation

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDefault => !(ShouldSerializeAutoUpdaterStrings());

        public void Reset()
        {
            ResetAutoUpdaterStrings();
        }

        #endregion
    }
}