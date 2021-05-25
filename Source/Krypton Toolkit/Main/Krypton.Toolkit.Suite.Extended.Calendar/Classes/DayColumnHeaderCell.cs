#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    public class DayColumnHeaderCell : DataGridViewColumnHeaderCell
    {

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            try
            {
                DayColumn dc = this.OwningColumn as DayColumn;
                DateTime now = DateTime.Now;
                SolidBrush HeaderColorBrush = CalendarControl.ct.ForeBrush;

                if (now.CompareTo(dc.StartTime) >= 0 && now.CompareTo(dc.EndTime) <= 0)
                {
                    LinearGradientBrush lgb = new LinearGradientBrush(cellBounds, CalendarControl.ct.HeaderLight, CalendarControl.ct.HeaderDark, LinearGradientMode.Vertical);
                    graphics.FillRectangle(lgb, cellBounds);
                    HeaderColorBrush = new SolidBrush(CalendarControl.ct.SelectedForeColour);
                }
                else
                {
                    graphics.FillRectangle(new SolidBrush(CalendarControl.ct.BackColour), cellBounds);
                }

                graphics.DrawRectangle(new Pen(new SolidBrush(CalendarControl.ct.SeparatorDark)), cellBounds);
                graphics.DrawLine(new Pen(new SolidBrush(CalendarControl.ct.SeparatorDark)), cellBounds.Left, cellBounds.Bottom - 1, cellBounds.Right, cellBounds.Bottom - 1);

                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                sf.Trimming = StringTrimming.EllipsisCharacter;

                RectangleF rect = new RectangleF(cellBounds.Left, cellBounds.Top, cellBounds.Width, cellBounds.Height);
                graphics.DrawString(this.Value.ToString(), CalendarControl.ct.FontStd, HeaderColorBrush, rect, sf);

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }
    }
}