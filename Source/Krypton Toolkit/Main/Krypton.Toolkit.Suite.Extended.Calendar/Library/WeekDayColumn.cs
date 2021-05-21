#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Calendar.Library
{
    /// <summary>
    /// This column is used for Month mode
    /// </summary>
    public class WeekDayColumn : DataGridViewColumn
    {
        public WeekDayColumn()
        {
            this.CellTemplate = new DayCell();
            this.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        protected override void OnDataGridViewChanged()
        {
            SetHeaderText();
        }

        private void SetHeaderText()
        {
            try
            {
                this.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DateTime dt = new DateTime(2010, 3, 15);
                dt = dt.AddDays(Index);
                if (this.Index == 0)
                    this.HeaderCell.Value = dt.ToString("dddd");
                else if (this.Index == 1)
                    this.HeaderCell.Value = dt.ToString("dddd");
                else if (this.Index == 2)
                    this.HeaderCell.Value = dt.ToString("dddd");
                else if (this.Index == 3)
                    this.HeaderCell.Value = dt.ToString("dddd");
                else if (this.Index == 4)
                    this.HeaderCell.Value = dt.ToString("dddd");
                else if (this.Index == 5)
                    this.HeaderCell.Value = dt.ToString("ddd") + "/" + dt.AddDays(1).ToString("ddd"); ;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

    }// class
}
