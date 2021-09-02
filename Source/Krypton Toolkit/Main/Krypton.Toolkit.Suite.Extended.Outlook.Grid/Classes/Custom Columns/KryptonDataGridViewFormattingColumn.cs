namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Class for a KryptonDataGridViewFormattingColumn : KryptonDataGridViewTextBoxColumn with conditionnal formatting abilities
    /// </summary>
    /// <seealso cref="KryptonDataGridViewTextBoxColumn" />
    public class KryptonDataGridViewFormattingColumn : KryptonDataGridViewTextBoxColumn
    {
        private bool _contrastTextColour;

        /// <summary>
        /// Initializes a new instance of the <see cref="KryptonDataGridViewFormattingColumn"/> class.
        /// </summary>
        public KryptonDataGridViewFormattingColumn()
            : base()
        {
            this.CellTemplate = new FormattingCell();
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ValueType = typeof(FormattingCell);
            ContrastTextColour = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [contrast text color].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [contrast text color]; otherwise, <c>false</c>.
        /// </value>
        public bool ContrastTextColour
        {
            get
            {
                return _contrastTextColour;
            }

            set
            {
                _contrastTextColour = value;
            }
        }
    }

    /// <summary>
    /// Formatting cell
    /// </summary>
    /// <seealso cref="KryptonDataGridViewTextBoxCell" />
    public class FormattingCell : KryptonDataGridViewTextBoxCell
    {

        /// <summary>
        /// Gets or sets the type of the format.
        /// </summary>
        /// <value>
        /// The type of the format.
        /// </value>
        public EnumConditionalFormatType FormatType { get; set; }
        /// <summary>
        /// Gets or sets the format parameters.
        /// </summary>
        /// <value>
        /// The format parameters.
        /// </value>
        public IFormatParams FormatParams { get; set; }


        /// <summary>
        /// Contrasts the color.
        /// </summary>
        /// <param name="colour">The color.</param>
        /// <returns></returns>
        private Color ContrastColour(Color colour)
        {
            int d = 0;
            //  Counting the perceptive luminance - human eye favors green color... 
            double a = (1
                        - (((0.299 * colour.R)
                        + ((0.587 * colour.G) + (0.114 * colour.B)))
                        / 255));
            if ((a < 0.5))
            {
                d = 0;
            }
            else
            {
                //  bright colors - black font
                d = 255;
            }

            //  dark colors - white font
            return Color.FromArgb(d, d, d);
        }

        /// <summary>
        /// Paints the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="clipBounds">The clip bounds.</param>
        /// <param name="cellBounds">The cell bounds.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="cellState">State of the cell.</param>
        /// <param name="value">The value.</param>
        /// <param name="formattedValue">The formatted value.</param>
        /// <param name="errorText">The error text.</param>
        /// <param name="cellStyle">The cell style.</param>
        /// <param name="advancedBorderStyle">The advanced border style.</param>
        /// <param name="paintParts">The paint parts.</param>
        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, System.Windows.Forms.DataGridViewElementStates cellState, object value, object formattedValue, string errorText, System.Windows.Forms.DataGridViewCellStyle cellStyle, System.Windows.Forms.DataGridViewAdvancedBorderStyle advancedBorderStyle,
        System.Windows.Forms.DataGridViewPaintParts paintParts)
        {
            if (FormatParams != null)  // null can happen when cell set to Formatting but no condition has been set !
            {
                switch (FormatType)
                {
                    case EnumConditionalFormatType.Bar:
                        int barWidth;
                        BarParams par = (BarParams)FormatParams;
                        barWidth = (int)((cellBounds.Width - 10) * par.ProportionValue);
                        Style.BackColor = this.DataGridView.DefaultCellStyle.BackColor;
                        Style.ForeColor = this.DataGridView.DefaultCellStyle.ForeColor;

                        if (barWidth > 0) //(double)value > 0 &&
                        {
                            Rectangle r = new Rectangle(cellBounds.X + 3, cellBounds.Y + 3, barWidth, cellBounds.Height - 8);
                            if (par.GradientFill)
                            {
                                using (LinearGradientBrush linearBrush = new LinearGradientBrush(r, par.BarColour, Color.White, LinearGradientMode.Horizontal)) //Color.FromArgb(255, 247, 251, 242)
                                {
                                    graphics.FillRectangle(linearBrush, r);
                                }
                            }
                            else
                            {
                                using (SolidBrush solidBrush = new SolidBrush(par.BarColour)) //Color.FromArgb(255, 247, 251, 242)
                                {
                                    graphics.FillRectangle(solidBrush, r);
                                }
                            }

                            using (Pen pen = new Pen(par.BarColour)) //Color.FromArgb(255, 140, 197, 66)))
                            {
                                graphics.DrawRectangle(pen, r);
                            }
                        }

                        break;
                    case EnumConditionalFormatType.TwoColoursRange:
                        TwoColoursParams TWCpar = (TwoColoursParams)FormatParams;
                        Style.BackColor = TWCpar.ValueColour;
                        //  if (ContrastTextColor)
                        Style.ForeColor = ContrastColour(TWCpar.ValueColour);
                        break;
                    case EnumConditionalFormatType.ThreeColoursRange:
                        ThreeColoursParams THCpar = (ThreeColoursParams)FormatParams;
                        Style.BackColor = THCpar.ValueColour;
                        Style.ForeColor = ContrastColour(THCpar.ValueColour);
                        break;
                    default:
                        Style.BackColor = this.DataGridView.DefaultCellStyle.BackColor;
                        Style.ForeColor = this.DataGridView.DefaultCellStyle.ForeColor;
                        break;
                }
            }
            else
            {
                Style.BackColor = this.DataGridView.DefaultCellStyle.BackColor;
                Style.ForeColor = this.DataGridView.DefaultCellStyle.ForeColor;
            }

            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle,
            DataGridViewPaintParts.None | DataGridViewPaintParts.ContentForeground);
        }
    }
}