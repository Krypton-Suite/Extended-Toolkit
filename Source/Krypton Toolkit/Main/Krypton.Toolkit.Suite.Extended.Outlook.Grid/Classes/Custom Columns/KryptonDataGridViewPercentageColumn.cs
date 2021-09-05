namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Hosts a collection of KryptonDataGridViewPercentageColumn cells.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.DataGridViewColumn" />
    public class KryptonDataGridViewPercentageColumn : DataGridViewColumn// KryptonDataGridViewTextBoxColumn
    {
        #region Identity
        /// <summary>
        /// Initialize a new instance of the KryptonDataGridViewPercentageColumn class.
        /// </summary>
        public KryptonDataGridViewPercentageColumn()
            : base(new DataGridViewPercentageCell()) => this.DefaultCellStyle.Format = "P";

        /// <summary>
        /// Returns a standard compact string representation of the column.
        /// </summary>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(0x40);
            builder.Append("KryptonDataGridViewPercentageColumn { Name=");
            builder.Append(base.Name);
            builder.Append(", Index=");
            builder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
            builder.Append(" }");
            return builder.ToString();
        }

        #endregion

        /// <summary>
        /// Overrides CellTemplate
        /// </summary>
        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }

            set
            {
                // Ensure that the cell used for the template is a DataGridViewPercentageCell.
                if ((value != null) && !value.GetType().IsAssignableFrom(typeof(DataGridViewPercentageCell)))
                {
                    throw new InvalidCastException("Must be a DataGridViewPercentageCell");
                }
                base.CellTemplate = value;

            }
        }

    }
}