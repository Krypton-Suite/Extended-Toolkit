#region BSD License
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
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.DataGridView
{
    /// <summary>
    /// DO NOT use in your application code base: This is a base class to allows pass-through to the master KryptonDataGridView
    /// </summary>
    /// <remarks>
    /// Abstract implementation class to allow access to the Control Constraint here only.
    /// </remarks>
    public abstract class MasterDetailGridView<T> : MasterDetailGridViewBase where T : Control
    {

        internal abstract IDetailView<T> ChildView { get; }

        private protected override void MasterDetailGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = (System.Windows.Forms.DataGridView)sender;
            bool found = true;
            if (!RowCurrent.TryGetValue(e.RowIndex, out var refValues))
            {
                refValues = (Rows[e.RowIndex].Height, Rows[e.RowIndex].DividerHeight);
                found = false;
            }

            // set childview control
            var scale = (refValues.Height - 16) / 2;
            var rect = new Rectangle(e.RowBounds.X + 16, e.RowBounds.Y + scale, 16, 16);
            var childView = (Control)ChildView; // allowed due to where constraint on <T>
            if (CollapseRow)
            {
                if (found)
                {
                    grid.Rows[e.RowIndex].DividerHeight = grid.Rows[e.RowIndex].Height - refValues.Height;
                    e.Graphics.DrawImage(RowHeaderIconList.Images[(int)RowHeaderIcons.Collapse], rect);
                    if (ShouldDisplayChildDetails(e.RowIndex))
                    {
                        childView.Location = new Point(e.RowBounds.Left + grid.RowHeadersWidth,
                            e.RowBounds.Top + refValues.Height + 5);
                        childView.Width = e.RowBounds.Right - grid.RowHeadersWidth;
                        childView.Height = grid.Rows[e.RowIndex].DividerHeight - 10;
                        childView.Visible = true;
                    }
                }
                else
                {
                    childView.Visible = false;
                    e.Graphics.DrawImage(RowHeaderIconList.Images[(int)RowHeaderIcons.Expand], rect);
                }

                CollapseRow = false;
            }
            else if (found)
            {
                grid.Rows[e.RowIndex].DividerHeight = grid.Rows[e.RowIndex].Height - refValues.Height;
                e.Graphics.DrawImage(RowHeaderIconList.Images[(int)RowHeaderIcons.Collapse], rect);
                if (ShouldDisplayChildDetails(e.RowIndex))
                {
                    childView.Location = new Point(e.RowBounds.Left + grid.RowHeadersWidth,
                        e.RowBounds.Top + refValues.Height + 5);
                    childView.Width = e.RowBounds.Right - grid.RowHeadersWidth;
                    childView.Height = grid.Rows[e.RowIndex].DividerHeight - 10;
                    childView.Visible = true;
                }
            }
            else
            {
                e.Graphics.DrawImage(RowHeaderIconList.Images[(int)RowHeaderIcons.Expand], rect);
            }
        }

        private protected override void MasterDetailGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (RowCount == 0
                || CurrentRow == null
            )
            {
                return;
            }

            if (RowCurrent.TryGetValue(CurrentRow.Index, out _))
            {
                var s = string.Format(CultureInfo.InvariantCulture, FilterFormat, this[ForeignKey, CurrentRow.Index].Value);
                foreach (var cGrid in ChildView.ChildGrids)
                {
                    ((IBindingListView)cGrid.Key.DataSource).Filter = $@"{cGrid.Value}{s}";
                    if (SelectionMode == DataGridViewSelectionMode.FullRowSelect)
                    {
                        cGrid.Key.ClearSelection();
                    }
                }
            }
        }

        private protected override bool HasNoChildDetails(int rowIndex)
        {
            if (RowCount == 0
            || rowIndex < 0)
            {
                return true;
            }

            var noDetails = true;
            var s = string.Format( CultureInfo.InvariantCulture, FilterFormat, this[ForeignKey, rowIndex].Value);
            foreach (var cGrid in ChildView.ChildGrids)
            {
                var bindingListView = (IBindingListView)cGrid.Key.DataSource;
                //var filterBefore = bindingListView.Filter;
                bindingListView.Filter = $@"{cGrid.Value}{s}";
                //noDetails = (bindingListView.Count <= 0);
                noDetails = cGrid.Key.RowCount <= 0;

                //bindingListView.Filter = filterBefore;
                if (!noDetails)
                {
                    break;
                }
            }

            return noDetails;
        }

        /// <summary>
        /// The current active Details View cell
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewCell DetailsCurrentCell
        {
            get => ChildView.DetailsCurrentCell;
            set => ChildView.DetailsCurrentCell = value;
        }

        /// <summary>
        /// Current active Details View row
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewRow DetailsCurrentRow => ChildView.DetailsCurrentRow;

        /// <summary>
        /// Route the Details mouse click through to the 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event DataGridViewCellMouseEventHandler DetailsCellMouseClick
        {
            add => ChildView.DetailsCellMouseClick += value;
            remove => ChildView.DetailsCellMouseClick -= value;
        }

    }
}
