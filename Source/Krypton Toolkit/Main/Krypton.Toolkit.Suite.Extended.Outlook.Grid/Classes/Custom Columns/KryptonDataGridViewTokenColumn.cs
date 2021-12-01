namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Class for a rating column
    /// </summary>
    public class KryptonDataGridViewTokenColumn : KryptonDataGridViewTextBoxColumn
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public KryptonDataGridViewTokenColumn()
            : base()
        {
            this.CellTemplate = new TokenCell();
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ValueType = typeof(TokenCell);
        }
    }
}