namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Special column used to enable nodes in the grid.
    /// </summary>
    /// <seealso cref="KryptonDataGridViewTextBoxColumn" />
    public class KryptonDataGridViewTreeTextColumn : KryptonDataGridViewTextBoxColumn
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonDataGridViewTreeTextColumn"/> class.
        /// </summary>
        public KryptonDataGridViewTreeTextColumn()
            : base()
        {
            CellTemplate = new KryptonDataGridViewTreeTextCell();
        }
    }
}