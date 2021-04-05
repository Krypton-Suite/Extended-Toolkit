using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.DataGridView.Implementation
{
    /// <summary>
    /// DO NOT use in your application code base: This is a base class to allows passthrough
    /// Class to hold the image list resource
    /// </summary>
    public abstract class MasterDetailGridViewBase : KryptonDataGridView
    {
        internal MasterDetailGridViewBase()
        {
            var components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterDetailGridViewBase));
            rowHeaderIconList = new ImageList(components)
            {
                ImageStream = (ImageListStreamer)resources.GetObject("RowHeaderIconList.ImageStream"),
                TransparentColor = Color.Transparent
            };
            rowHeaderIconList.Images.SetKeyName(0, "expand.png");
            rowHeaderIconList.Images.SetKeyName(1, "collapse.png");

            RowHeaderMouseClick += MasterDetailGridView_RowHeaderMouseClick;
            RowPostPaint += MasterDetailGridView_RowPostPaint;
            Scroll += MasterDetailGridView_Scroll;
            SelectionChanged += MasterDetailGridView_SelectionChanged;
            DetailsColumnHeadersVisible = true;
        }

        /// <summary>
        /// Required to allow Master Detail relationships
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataSet DataSet { get; set; }

        /// <inheritdoc />
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new object DataSource
        {
            get => base.DataSource;
            private set => throw new AccessViolationException(@"Not allowed to set externally!");
        }

        /// <summary>
        /// Specify which table is to be used for the master from within the Dataset
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="masterColumn">The foreign key fieldname to be used for the master -> child relationship</param>
        /// <param name="willBeEditable">Add extra width to the RowHeader</param>
        public void SetMasterSource(string tableName, string masterColumn, bool willBeEditable = false)
        {
            if (DataSet == null)
                throw new MissingFieldException(@"DataSet has not been initialised first");
            base.DataSource = new DataView(DataSet.Tables[tableName]);
            foreignKey = masterColumn;
            var keyType = DataSet.Tables[tableName].Columns[masterColumn].GetType();
            if ((keyType == typeof(int))
                || (keyType == typeof(float))
                || (keyType == typeof(double))
                || (keyType == typeof(decimal))
                )
            {
                filterFormat = @"={0}";
            }
            else
            {
                filterFormat = @"='{0}'";
            }

            ConvertToExtKryptonColumns(this);
        }

        protected internal static void ConvertToExtKryptonColumns(KryptonDataGridView dgv)
        {
            if (dgv.AutoGenerateColumns)
            {
                // TODO: replace the Columns with the Krypton Ext Equivalents
                List<DataGridViewColumn> replaceColumns = new(dgv.Columns.Count);
                foreach (DataGridViewColumn cCol in dgv.Columns)
                {
                    // Columns will already be the Krypton.Toolkit versions
                    var colType = cCol.ValueType;
                    if (colType == typeof(DateTime))
                    {
                        replaceColumns.Add(new KryptonDataGridViewDateTimePickerColumn
                        {
                            DataPropertyName = cCol.DataPropertyName,
                            HeaderText = cCol.HeaderText,
                            Name = cCol.Name
                        });
                    }
                    // TODO: System.Int64 to NumericUpDowner ??
                    else if (colType == typeof(bool))
                    {
                        replaceColumns.Add(new KryptonDataGridViewBinaryColumn
                        {
                            DataPropertyName = cCol.DataPropertyName,
                            HeaderText = cCol.HeaderText,
                            Name = cCol.Name
                        });
                    }
                    else
                    {
                        replaceColumns.Add(cCol);
                    }
                }
                dgv.Columns.Clear();
                dgv.Columns.AddRange(replaceColumns.ToArray());
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected string foreignKey;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected string filterFormat;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                RowHeaderMouseClick -= MasterDetailGridView_RowHeaderMouseClick;
                RowPostPaint -= MasterDetailGridView_RowPostPaint;
                Scroll -= MasterDetailGridView_Scroll;
                SelectionChanged -= MasterDetailGridView_SelectionChanged;
            }
            base.Dispose(disposing);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected readonly ImageList rowHeaderIconList;

        protected enum RowHeaderIcons
        {
            Expand = 0,
            Collapse = 1
        }

        protected readonly Dictionary<int, (int Height, int divider)> rowCurrent = new();
        private readonly int rowExpandedHeight = 300;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool collapseRow;

        private void MasterDetailGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!rowCurrent.TryGetValue(e.RowIndex, out var refValues))
                refValues = (Rows[e.RowIndex].Height, Rows[e.RowIndex].DividerHeight);

            var scale = (refValues.Height - 16) / 2;
            var rect = new Rectangle(scale, scale, 16, 16);
            if (rect.Contains(e.Location))
            {
                // Clicked on the Expand area
                if (rowCurrent.TryGetValue(e.RowIndex, out refValues))
                {
                    // Restore the row to it's original
                    rowCurrent.Clear();
                    Rows[e.RowIndex].Height = refValues.Height;
                    Rows[e.RowIndex].DividerHeight = refValues.divider;
                }
                else
                {
                    // Was not expanded here
                    if (rowCurrent.Count != 0)
                    {
                        var eRow = rowCurrent.First().Key;
                        refValues = rowCurrent.First().Value;
                        rowCurrent.Clear();
                        Rows[eRow].Height = refValues.Height;
                        Rows[eRow].DividerHeight = refValues.divider;
                        ClearSelection();
                        collapseRow = true;
                        Rows[eRow].Selected = true;
                    }

                    rowCurrent[e.RowIndex] = (Rows[e.RowIndex].Height, Rows[e.RowIndex].DividerHeight);
                    Rows[e.RowIndex].Height = rowExpandedHeight;
                    Rows[e.RowIndex].DividerHeight = rowExpandedHeight - Rows[e.RowIndex].DividerHeight;
                }

                ClearSelection();
                collapseRow = true;
                Rows[e.RowIndex].Selected = true;
            }
            else
            {
                collapseRow = false;
            }
        }

        private protected abstract void MasterDetailGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e);

        private protected abstract void MasterDetailGridView_SelectionChanged(object sender, EventArgs e);

        private void MasterDetailGridView_Scroll(object sender, ScrollEventArgs e)
        {
            if (rowCurrent.Count != 0)
            {
                collapseRow = true;
                ClearSelection();
                Rows[rowCurrent.First().Key].Selected = true;
            }
        }

        /// <summary>
        /// Align the styles of the Child Detail views with the Master.
        /// This saves having to combine designers for the same look'n'feel
        /// </summary>
        /// <param name="newGrid"></param>
        protected void SetStyles(KryptonDataGridView newGrid)
        {
            //ColumnCount = ColumnCount;
            //BackColor = BackColor;
            newGrid.BackgroundColor = BackgroundColor;
            newGrid.ForeColor = ForeColor;
            newGrid.Font = Font;
            newGrid.GridColor = GridColor;
            //BorderStyle = BorderStyle;
            newGrid.CellBorderStyle = CellBorderStyle;
            newGrid.ColumnHeadersBorderStyle = ColumnHeadersBorderStyle;
            newGrid.ColumnHeadersDefaultCellStyle = ColumnHeadersDefaultCellStyle;
            newGrid.DefaultCellStyle = DefaultCellStyle;
            newGrid.EnableHeadersVisualStyles = EnableHeadersVisualStyles;
            newGrid.GridColor = GridColor;
            newGrid.RowHeadersBorderStyle = RowHeadersBorderStyle;
            newGrid.RowHeadersDefaultCellStyle = RowHeadersDefaultCellStyle;
            newGrid.ShowCellToolTips = ShowCellToolTips;
            newGrid.ContextMenuStrip = ContextMenuStrip;
            newGrid.KryptonContextMenu = KryptonContextMenu;
            newGrid.HideOuterBorders = HideOuterBorders;
            newGrid.PaletteMode = PaletteMode;
            newGrid.Palette = Palette;
            newGrid.AllowUserToAddRows = AllowUserToAddRows;
            newGrid.AllowUserToDeleteRows = AllowUserToDeleteRows;
            newGrid.AllowUserToOrderColumns = AllowUserToOrderColumns;
            newGrid.AllowUserToResizeColumns = AllowUserToResizeColumns;
            newGrid.AllowUserToResizeRows = AllowUserToResizeRows;
            newGrid.AlternatingRowsDefaultCellStyle = AlternatingRowsDefaultCellStyle;
            newGrid.AutoGenerateColumns = AutoGenerateColumns;
            newGrid.AutoSize = AutoSize;
            newGrid.AutoSizeColumnsMode = AutoSizeColumnsMode;
            newGrid.AutoSizeRowsMode = AutoSizeRowsMode;
            newGrid.BackgroundImage = BackgroundImage;
            newGrid.BackgroundImageLayout = BackgroundImageLayout;
            newGrid.ClipboardCopyMode = ClipboardCopyMode;
            newGrid.ColumnHeadersHeight = ColumnHeadersHeight;
            newGrid.ColumnHeadersHeightSizeMode = ColumnHeadersHeightSizeMode;
            newGrid.ColumnHeadersVisible = DetailsColumnHeadersVisible;
            newGrid.EditMode = EditMode;
            newGrid.MultiSelect = MultiSelect;
            newGrid.ReadOnly = ReadOnly;
            newGrid.RowsDefaultCellStyle = RowsDefaultCellStyle;
            newGrid.RowTemplate = RowTemplate;
            newGrid.ScrollBars = ScrollBars;
            newGrid.SelectionMode = SelectionMode;
            newGrid.ShowCellErrors = ShowCellErrors;
            newGrid.ShowCellToolTips = ShowCellToolTips;
            newGrid.ShowEditingIcon = ShowEditingIcon;
            newGrid.ShowRowErrors = ShowRowErrors;
            newGrid.StandardTab = StandardTab;
            newGrid.RowHeadersVisible = true;   // TODO: This could be passed from the parent value
        }

        [Category("Details Appearance")]
        [DefaultValue(true)]
        [Description("Detail DataGridView ColumnHeaders Visibilty")]
        public bool DetailsColumnHeadersVisible { get; set; }

        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("DataGridView RowHeaders Visible (Will always be true!")]
        public new bool RowHeadersVisible
        {
            get => true;
            set => base.RowHeadersVisible = true;
        }

        [Category("Layout")]
        [Description("DataGridView RowHeaders Width")]
        public new int RowHeadersWidth
        {
            get => base.RowHeadersWidth;
            set
            {
                if (value < 18)
                    throw new ArgumentOutOfRangeException(nameof(RowHeadersWidth));
                base.RowHeadersWidth = value;
            }
        }

    }

}