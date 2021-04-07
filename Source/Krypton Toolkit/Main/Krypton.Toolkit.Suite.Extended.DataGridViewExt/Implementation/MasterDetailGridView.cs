#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.DataGridViewExt.Implementation
{
    /// <summary>
    /// DO NOT use in your application code base: This is a base class to allows passthrough to the master KryptonDataGridView
    /// </summary>
    /// <remarks>
    /// Abstract implementation class to allow access to the Control Constraint here only.
    /// </remarks>
    public abstract class MasterDetailGridView<T> : MasterDetailGridViewBase where T : Control
    {

        internal abstract IDetailView<T> ChildView { get; }

        private protected override void MasterDetailGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = (DataGridView)sender;
            bool found = true;
            if (!RowCurrent.TryGetValue(e.RowIndex, out var refValues))
            {
                refValues = (Rows[e.RowIndex].Height, Rows[e.RowIndex].DividerHeight);
                found = false;
            }

            // set childview control
            var scale = (refValues.Height - 16) / 2;
            var rect = new Rectangle(e.RowBounds.X + scale, e.RowBounds.Y + scale, 16, 16);
            var childView = (Control)ChildView; // allowed due to where constraint on <T>
            if (CollapseRow)
            {
                if (found)
                {
                    grid.Rows[e.RowIndex].DividerHeight = grid.Rows[e.RowIndex].Height - refValues.Height;
                    e.Graphics.DrawImage(RowHeaderIconList.Images[(int)RowHeaderIcons.Collapse], rect);
                    childView.Location = new Point(e.RowBounds.Left + grid.RowHeadersWidth, e.RowBounds.Top + refValues.Height + 5);
                    childView.Width = e.RowBounds.Right - grid.RowHeadersWidth;
                    childView.Height = grid.Rows[e.RowIndex].DividerHeight - 10;
                    childView.Visible = true;
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
                childView.Location = new Point(e.RowBounds.Left + grid.RowHeadersWidth, e.RowBounds.Top + refValues.Height + 5);
                childView.Width = e.RowBounds.Right - grid.RowHeadersWidth;
                childView.Height = grid.Rows[e.RowIndex].DividerHeight - 10;
                childView.Visible = true;
            }
            else
            {
                e.Graphics.DrawImage(RowHeaderIconList.Images[(int)RowHeaderIcons.Expand], rect);
            }
        }

        private protected override void MasterDetailGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (RowCount != 0
                && CurrentRow != null
            )
            {
                if (RowCurrent.TryGetValue(CurrentRow.Index, out _))
                {
                    foreach (var cGrid in ChildView.ChildGrids)
                    {
                        ((IBindingListView)cGrid.Key.DataSource).Filter = $@"{cGrid.Value}{string.Format(FilterFormat, this[ForeignKey, CurrentRow.Index].Value)}";
                        if (base.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
                        {
                            cGrid.Key.ClearSelection();
                        }
                    }
                }
            }
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
