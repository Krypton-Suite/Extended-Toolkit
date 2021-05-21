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

namespace Krypton.Toolkit.Suite.Extended.Calendar.Library
{
    public class WeekRowHeaderCell : DataGridViewRowHeaderCell
    {
        public int WeekNumber { get; set; }
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            try
            {
                //int marginForDivider = 3;
                int marginForMinutes = 20;

                Pen pen = new Pen(Calendar.ct.BorderBrush);

                // Draw the background
                graphics.FillRectangle(new SolidBrush(Calendar.ct.BackColor), cellBounds);

                // Draw the gradient if it is the current time
                DateTime now = DateTime.Now;
                int hour1 = rowIndex / 2;
                int firstHalf = rowIndex % 2; // 0 means 0 to 30 minutes. 1 means 31 to 59 minutes
                if (now.Hour == hour1 && ((int)(now.Minute / 30) == firstHalf))
                {
                    LinearGradientBrush lgb = new LinearGradientBrush(cellBounds, Calendar.ct.HeaderLight, Calendar.ct.HeaderDark, LinearGradientMode.Vertical);
                    graphics.FillRectangle(lgb, cellBounds);
                    if (firstHalf == 0)
                        graphics.DrawLine(new Pen(Calendar.ct.TodayGradientBrush), cellBounds.Left, cellBounds.Bottom, cellBounds.Right, cellBounds.Bottom);
                }

                // Draw the separator for alternate rows
                // graphics.DrawLine(new Pen(new SolidBrush(Calendar.ct.SeparatorDark)), cellBounds.Left + marginForDivider, cellBounds.Bottom - 1, cellBounds.Right - marginForDivider, cellBounds.Bottom - 1); 

                // Draw the right vertical line for the cell
                graphics.DrawLine(new Pen(new SolidBrush(Calendar.ct.SeparatorDark)), cellBounds.Right - 1, cellBounds.Top, cellBounds.Right - 1, cellBounds.Bottom);

                // Draw the text
                int hour = WeekNumber;// GetHour(rowIndex);
                RectangleF rectHour = RectangleF.Empty;
                RectangleF rectMinutes = RectangleF.Empty;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Center;
                sf.Trimming = StringTrimming.EllipsisCharacter;

                rectHour = new RectangleF(cellBounds.Left + 5, cellBounds.Top, cellBounds.Width - marginForMinutes, cellBounds.Height);
                if (rowIndex == 1)
                    graphics.DrawString(hour.ToString(), new Font("Arial", 15, FontStyle.Regular), Calendar.ct.ForeBrush, rectHour, sf);

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }


        public WeekRowHeaderCell()
        { }

        public WeekRowHeaderCell(int wknr)
        {
            WeekNumber = wknr;
        }
    }// class
}