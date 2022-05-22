namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [Description("")]
    public class KryptonThemeComboBox : ToolStripComboBox
    {
        #region Instances

        private KryptonManager _manager = null;

        #endregion

        #region Properties

        public KryptonManager KryptonManager { get => _manager; set => _manager = value; }

        #endregion

        #region Identity

        public KryptonThemeComboBox()
        {
            // Set initial size
            Size = new Size(200, 23);

            // Set drop down width
            DropDownWidth = 200;

            // Set drop down style
            DropDownStyle = ComboBoxStyle.DropDownList;

            // Set autocomplete mode
            AutoCompleteSource = AutoCompleteSource.ListItems;

            AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            ThemeManager.PropagateThemeSelector(this);
        }

        #endregion

        #region Protected

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            ThemeManager.ApplyTheme(Text, KryptonManager);

            base.OnSelectedIndexChanged(e);
        }

        #endregion
    }
}