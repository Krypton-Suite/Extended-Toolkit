namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SharpUpdateAcceptFormStrings : GlobalId
    {
        #region Static Fields

        private const string DEFAULT_REMOVE = @"Remove";

        #endregion

        #region Identity

        public SharpUpdateAcceptFormStrings()
        {
            Reset();
        }

        public override string ToString() => !IsDefault ? "Modified" : string.Empty;

        #endregion

        #region Public

        [Browsable(false)]
        public bool IsDefault => Remove.Equals(DEFAULT_REMOVE);

        public void Reset()
        {
            Remove = DEFAULT_REMOVE;
        }

        [Localizable(true)]
        [Category(@"Visuals")]
        [Description(@"Localised remove string.")]
        [DefaultValue(DEFAULT_REMOVE)]
        [RefreshProperties(RefreshProperties.All)]
        public string Remove { get; set; }

        #endregion
    }
}