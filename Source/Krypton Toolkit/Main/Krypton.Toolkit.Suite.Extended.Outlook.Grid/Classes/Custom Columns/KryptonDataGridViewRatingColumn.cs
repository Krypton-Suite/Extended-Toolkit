namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Class for a rating column
    /// </summary>
    public class KryptonDataGridViewRatingColumn : DataGridViewImageColumn
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public KryptonDataGridViewRatingColumn()
        {
            this.CellTemplate = new RatingCell();
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ValueType = typeof(int);
        }
    }
}