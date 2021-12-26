#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Krypton.Toolkit.Suite.Extended.DataGridView
{
    /// <summary>
    /// DO NOT use in your application code base: This is a base class to allows passthrough
    /// Class to hold the image list resource
    /// </summary>
    public abstract class MasterDetailGridViewBase : KryptonDataGridView
    {
        internal MasterDetailGridViewBase()
        {
            var components = new Container();
            var resources = new ComponentResourceManager(typeof(MasterDetailGridViewBase));
            RowHeaderIconList = new ImageList(components)
            {
#pragma warning disable CA1304 // Specify CultureInfo
                ImageStream = (ImageListStreamer)resources.GetObject(@"RowHeaderIconList.ImageStream"),
#pragma warning restore CA1304 // Specify CultureInfo
                TransparentColor = Color.Transparent
            };
            RowHeaderIconList.Images.SetKeyName(0, @"expand.png");
            RowHeaderIconList.Images.SetKeyName(1, @"collapse.png");

            RowHeaderMouseClick += MasterDetailGridView_RowHeaderMouseClick;
            RowPostPaint += MasterDetailGridView_RowPostPaint;
            Scroll += MasterDetailGridView_Scroll;
            SelectionChanged += MasterDetailGridView_SelectionChanged;
            CellClick += MasterDetailGridViewBase_CellClick;
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
            private set => throw new NotSupportedException(@"Not allowed to set externally!");
        }

        /// <summary>
        /// Specify which table is to be used for the master from within the Dataset
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="masterColumn">The foreign key fieldname to be used for the master -> child relationship</param>
        /// <param name="columns">optional columns if not already added via designer</param>
        public void SetMasterSource(string tableName, string masterColumn, DataGridViewColumn[] columns = null)
        {
            if (DataSet == null)
            {
                throw new MissingFieldException(@"DataSet has not been initialised first");
            }

            if (columns != null)
            {
                AutoGenerateColumns = false;
                Columns.Clear();
                Columns.AddRange(columns);
            }

            base.DataSource = new DataView(DataSet.Tables[tableName]);
            ForeignKey = masterColumn;
            var keyType = DataSet.Tables[tableName].Columns[masterColumn].GetType();
            if ((keyType == typeof(int))
                || (keyType == typeof(float))
                || (keyType == typeof(double))
                || (keyType == typeof(decimal))
                )
            {
                FilterFormat = @"={0}";
            }
            else
            {
                FilterFormat = @"='{0}'";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="masterColumn">The foreign key fieldname to be used for the master -> child relationship</param>
        /// <param name="columns">optional columns if not already added via designer</param>
        public void SetMasterSource(BindingSource source, string masterColumn, DataGridViewColumn[] columns = null)
        {
            if (columns != null)
            {
                RowCurrent.Clear();
                CollapseRow = true;
                AutoGenerateColumns = false;
                Columns.Clear();
                Columns.AddRange(columns);
            }
            base.DataSource = source;
            ForeignKey = masterColumn;
            FilterFormat = @"={0}";
            if (SelectionMode == DataGridViewSelectionMode.FullRowSelect)
            {
                ClearSelection();
            }

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected string ForeignKey;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected string FilterFormat;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                RowHeaderIconList?.Dispose();
                RowHeaderMouseClick -= MasterDetailGridView_RowHeaderMouseClick;
                RowPostPaint -= MasterDetailGridView_RowPostPaint;
                Scroll -= MasterDetailGridView_Scroll;
                SelectionChanged -= MasterDetailGridView_SelectionChanged;
                CellClick -= MasterDetailGridViewBase_CellClick;
            }
            base.Dispose(disposing);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected readonly ImageList RowHeaderIconList;

        protected enum RowHeaderIcons
        {
            Expand = 0,
            Collapse = 1
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected bool CollapseRow;

        private void MasterDetailGridViewBase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((SelectionMode == DataGridViewSelectionMode.FullRowSelect)
                && ExpandDetailsWhenFullRowSelectClicked
                && (e.ColumnIndex >= 0)
                && (e.RowIndex >= 0)
                )
            {
                ExpandAndCollapseOther(e.RowIndex);
            }
        }

        private void ExpandAndCollapseOther(int rowIndex)
        {
            if (RowCurrent.TryGetValue(rowIndex, out var refValues))
            {
                // Restore the row to it's original
                RowCurrent.Clear();
                Rows[rowIndex].Height = refValues.Height;
                Rows[rowIndex].DividerHeight = refValues.divider;
            }
            else
            {
                // Was not expanded here
                if (RowCurrent.Count != 0)
                {
                    var eRow = RowCurrent.First().Key;
                    refValues = RowCurrent.First().Value;
                    RowCurrent.Clear();
                    Rows[eRow].Height = refValues.Height;
                    Rows[eRow].DividerHeight = refValues.divider;
                    ClearSelection();
                    CollapseRow = true;
                    Rows[eRow].Selected = true;
                }

                RowCurrent[rowIndex] = (Rows[rowIndex].Height, Rows[rowIndex].DividerHeight);
                if (ShouldDisplayChildDetails(rowIndex))
                {
                    Rows[rowIndex].Height = DetailRowExpandedMaxHeight;
                    Rows[rowIndex].DividerHeight = DetailRowExpandedMaxHeight - Rows[rowIndex].DividerHeight;
                }
                else
                {
                    // Need to show some difference to visually indicate an empty child
                    Rows[rowIndex].Height += 4;
                    Rows[rowIndex].DividerHeight += 4;
                }
            }

            ClearSelection();
            CollapseRow = true;
            Rows[rowIndex].Selected = true;
        }

        private void MasterDetailGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!RowCurrent.TryGetValue(e.RowIndex, out var refValues))
            {
                refValues = (Rows[e.RowIndex].Height, Rows[e.RowIndex].DividerHeight);
            }

            var scale = (refValues.Height - 16) / 2;
            var rect = new Rectangle(16, scale, 16, 16);
            if (rect.Contains(e.Location))
            {
                ExpandAndCollapseOther(e.RowIndex);
            }
            else
            {
                CollapseRow = false;
            }
        }

        // Should the row display the icon and allow Details view
        private protected bool ShouldDisplayChildDetails(int rowIndex)
        {
            return AllowUserToAddRows
                   || !HasNoChildDetails(rowIndex);
        }

        private protected abstract bool HasNoChildDetails(int rowIndex);

        private protected abstract void MasterDetailGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e);

        private protected abstract void MasterDetailGridView_SelectionChanged(object sender, EventArgs e);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected readonly Dictionary<int, (int Height, int divider)> RowCurrent = new();

        private int rowExpandedHeight = 300;

        private void MasterDetailGridView_Scroll(object sender, ScrollEventArgs e)
        {
            if (RowCurrent.Count != 0)
            {
                CollapseRow = true;
                ClearSelection();
                Rows[RowCurrent.First().Key].Selected = true;
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
            newGrid.BorderStyle = BorderStyle;
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
            newGrid.RowHeadersVisible = DetailsRowHeadersVisible;
        }

        #region Details Appearance Designer variables
        /// <summary>
        /// Detail DataGridView ColumnHeaders Visibility
        /// </summary>
        [Category("Details Appearance")]
        [DefaultValue(true)]
        [Description("Detail DataGridView ColumnHeaders Visibility")]
        public bool DetailsColumnHeadersVisible { get; set; } = true;

        /// <summary>
        /// Detail DataGridView ColumnHeaders Visibility
        /// </summary>
        [Category("Details Appearance")]
        [DefaultValue(true)]
        [Description("Expand Details when FullRowSelect Clicked")]
        public bool ExpandDetailsWhenFullRowSelectClicked { get; set; } = true;

        /// <summary>
        /// Detail DataGridView RowHeaders Visibility
        /// </summary>
        [Category("Details Appearance")]
        [DefaultValue(false)]
        [Description("Detail DataGridView RowHeaders Visibility")]
        public bool DetailsRowHeadersVisible { get; set; }

        /// <summary>
        /// Detail DataGridView RowHeaders Visibility
        /// </summary>
        [Category("Details Appearance")]
        [DefaultValue(300)]
        [Description("Detail DataGridView MaxHeight, Min is 100")]
        public int DetailRowExpandedMaxHeight
        {
            get => rowExpandedHeight;
            set
            {
                if (value < 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(DetailRowExpandedMaxHeight));
                }

                rowExpandedHeight = value;
            }
        }

        #endregion Details Appearance Designer variables

        #region Existing DataGridView Designer Modifiers
        /// <summary>
        /// Override the Master RowHeaders to be always visible
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(true)]
        [Description("DataGridView RowHeaders Visible (Will always be true!")]
        public new bool RowHeadersVisible
        {
            get => true;
            // ReSharper disable once ValueParameterNotUsed
            set => base.RowHeadersVisible = true;
        }

        /// <summary>
        /// Make sure the RowHeaders have enough room to display the Drop restore image
        /// </summary>
        [Category("Layout")]
        [Description("DataGridView RowHeaders Width")]
        public new int RowHeadersWidth
        {
            get => base.RowHeadersWidth;
            set
            {
                if (value < 32) // Leave room for the Default Selected icon and then drawing the Expand / collapse icon
                {
                    throw new ArgumentOutOfRangeException(nameof(RowHeadersWidth));
                }

                base.RowHeadersWidth = value;
            }
        }
        #endregion Existing DataGridView Designer Modifiers

    }

}