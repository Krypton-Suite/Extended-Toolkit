namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    [Category(@"Code")]
    [Description(@"Access 'Global' Krypton string settings.")]
    [ToolboxItem(true)]
    public class SharpUpdateLanguageManager : Component
    {
        #region Public

        [Category(@"Visuals")]
        [Description(@"Collection of SharpUpdateInfoForm strings.")]
        [MergableProperty(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        public SharpUpdateInfoFormStrings SharpUpdateInfoFormStrings => InfoFormStrings;

        private bool ShouldSerializeSharpUpdateInfoFormStringsStrings() => !InfoFormStrings.IsDefault;

        /// <summary>Resets the color strings.</summary>
        public void ResetSharpUpdateInfoFormStringsStrings() => InfoFormStrings.Reset();

        #endregion

        #region Static Strings

        public static SharpUpdateInfoFormStrings InfoFormStrings { get; } = new SharpUpdateInfoFormStrings();

        #endregion
    }
}