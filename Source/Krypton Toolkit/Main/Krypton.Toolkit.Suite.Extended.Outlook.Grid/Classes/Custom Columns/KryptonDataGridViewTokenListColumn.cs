namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Class for a rating column
    /// </summary>
    public class KryptonDataGridViewTokenListColumn : KryptonDataGridViewTextBoxColumn
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public KryptonDataGridViewTokenListColumn()
            : base()
        {
            this.CellTemplate = new TokenListCell();
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ValueType = typeof(List<TokenListCell>);
        }
    }
}