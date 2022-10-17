#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.DataGridView
{
    /// <summary>
    /// Hosts a collection of KryptonDataGridViewBinaryCell cells.
    /// </summary>
    [ToolboxBitmap(typeof(KryptonDataGridViewBinaryColumn), "ToolboxBitmaps.KryptonTextBox.bmp")]
    public class KryptonDataGridViewBinaryColumn : KryptonDataGridViewIconColumn
    {
        #region Static Fields

        private static readonly Font _defaultFont = new("Consolas", 9.75f);

        #endregion

        #region Instance Fields

        private Type _editorType;

        #endregion

        #region Identity

        /// <summary>
        /// Initialize a new instance of the KryptonDataGridViewCustomColumn class.
        /// </summary>
        public KryptonDataGridViewBinaryColumn()
            : base(new KryptonDataGridViewBinaryCell())
        {
            SortMode = DataGridViewColumnSortMode.Automatic;
            DefaultCellStyle = new DataGridViewCellStyle()
            {
                Font = _defaultFont
            };
        }

        /// <summary>
        /// Returns a String that represents the current Object.
        /// </summary>
        /// <returns>A String that represents the current Object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new(0x40);
            builder.Append("KryptonDataGridViewBinaryColumn { Name=");
            builder.Append(Name);
            builder.Append(", Index=");
            builder.Append(Index.ToString(CultureInfo.CurrentCulture));
            builder.Append(" }");
            return builder.ToString();
        }

        /// <summary>
        /// Create a cloned copy of the column.
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            KryptonDataGridViewBinaryColumn cloned = base.Clone() as KryptonDataGridViewBinaryColumn;

            // Move the button specs over to the new clone
            cloned._editorType = _editorType;
            return cloned;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }

            base.Dispose(disposing);
        }

        #endregion

        #region Public

        /// <summary>
        /// Gets or sets the sort mode for the column.
        /// </summary>
        [DefaultValue(typeof(DataGridViewColumnSortMode), "Automatic")]
        public new DataGridViewColumnSortMode SortMode
        {
            get => base.SortMode;
            set => base.SortMode = value;
        }

        /// <summary>
        /// Gets or sets the template used to model cell appearance.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override DataGridViewCell CellTemplate
        {
            get => base.CellTemplate;

            set
            {
                if ((value != null) && value is not KryptonDataGridViewBinaryCell)
                {
                    throw new InvalidCastException("Can only assign a object of type KryptonDataGridViewBinaryCell");
                }

                base.CellTemplate = value;
            }
        }

        /// <summary>
        /// Replicates the EditorType property of the KryptonDataGridViewBinaryCell cell type.
        /// </summary>
        [Category("Data")]
        [DefaultValue(null)]
        [Description("The type of the editor widget to bring up when editing a cell's content.")]
        public Type EditorType
        {
            get =>
                BinaryCellTemplate == null
                    ? throw new InvalidOperationException(
                        "Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.")
                    : BinaryCellTemplate.EditorType;
            set
            {
                if (BinaryCellTemplate == null)
                    throw new InvalidOperationException(
                        "Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                BinaryCellTemplate.EditorType = value;
                if (DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        if (dataGridViewRow.Cells[Index] is KryptonDataGridViewBinaryCell dataGridViewCell)
                            dataGridViewCell.SetEditorType(rowIndex, value);
                    }

                    DataGridView.InvalidateColumn(Index);
                }
            }
        }


        #endregion

        #region Private

        private KryptonDataGridViewBinaryCell BinaryCellTemplate => (KryptonDataGridViewBinaryCell)CellTemplate;

        #endregion

    }
}
