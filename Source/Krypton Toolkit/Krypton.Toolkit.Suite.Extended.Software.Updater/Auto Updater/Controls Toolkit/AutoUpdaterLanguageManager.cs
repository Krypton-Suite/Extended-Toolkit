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

        #endregion

        #region Static Strings

        public static AutoUpdaterStrings UpdaterStrings { get; } = new();

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