using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Calendar.Library
{
    public class HalfHourRowHeaderCell : DataGridViewRowHeaderCell
    {

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            try
            {
                int marginForDivider = 3;
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
                if (rowIndex % 2 != 0)
                    graphics.DrawLine(new Pen(new SolidBrush(Calendar.ct.SeparatorDark)), cellBounds.Left + marginForDivider, cellBounds.Bottom - 1, cellBounds.Right - marginForDivider, cellBounds.Bottom - 1);

                // Draw the right vertical line for the cell
                graphics.DrawLine(new Pen(new SolidBrush(Calendar.ct.SeparatorDark)), cellBounds.Right - 1, cellBounds.Top, cellBounds.Right - 1, cellBounds.Bottom);

                // Draw the text
                int hour = GetHour(rowIndex);
                RectangleF rectHour = RectangleF.Empty;
                RectangleF rectMinutes = RectangleF.Empty;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Center;
                sf.Trimming = StringTrimming.EllipsisCharacter;
                if (rowIndex % 2 == 0)
                {
                    // Draw hour
                    rectHour = new RectangleF(cellBounds.Left, cellBounds.Top, cellBounds.Width - marginForMinutes, cellBounds.Height * 2);
                    graphics.DrawString(hour.ToString(), new Font("Arial", 15, FontStyle.Regular), Calendar.ct.ForeBrush, rectHour, sf);

                    // Draw minutes
                    sf.Alignment = StringAlignment.Near;
                    rectMinutes = new RectangleF(cellBounds.Right - marginForMinutes, cellBounds.Top, marginForMinutes, cellBounds.Height);
                    graphics.DrawString(GetMinutes(rowIndex), new Font("Arial", 8, FontStyle.Regular), Calendar.ct.ForeBrush, rectMinutes, sf);
                }
                else
                {
                    // Draw hour
                    rectHour = new RectangleF(cellBounds.Left, cellBounds.Top - cellBounds.Height, cellBounds.Width - marginForMinutes, cellBounds.Height * 2);
                    graphics.DrawString(hour.ToString(), new Font("Arial", 15, FontStyle.Regular), Calendar.ct.ForeBrush, rectHour, sf);
                    if (this.OwningColumn.DataGridView.FirstDisplayedScrollingRowIndex == rowIndex)
                    {
                        // TODO: Need to take care of TopLeftHeaderCell
                    }
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        private int GetHour(int rowIndex)
        {
            try
            {
                int hour = rowIndex / 2;
                if (hour == 0)
                    hour = 12;
                //else if (hour > 12)
                //    hour = hour;

                return hour;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return 0;
            }
        }

        private string GetMinutes(int rowIndex)
        {
            try
            {
                string minutes = "";

                int hour = rowIndex / 2;

                if (rowIndex % 2 == 0)
                    minutes = "00";
                else
                    minutes = "30";

                //if (hour == 0 && (rowIndex % 2 == 0))
                //{
                //    minutes = "am";
                //}
                //else if (hour == 12 && (rowIndex % 2 == 0))
                //{
                //    minutes = "pm";
                //}

                //if (this.OwningRow.DataGridView.FirstDisplayedScrollingRowIndex == rowIndex)
                //{
                //    if (hour < 12)
                //        minutes = "am";
                //    else
                //        minutes = "pm";
                //}

                return minutes;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return "";
            }
        }

    }// class
}