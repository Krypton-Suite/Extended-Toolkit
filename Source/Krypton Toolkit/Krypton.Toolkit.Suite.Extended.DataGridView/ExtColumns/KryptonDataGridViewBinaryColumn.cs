﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

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
