using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    /// <summary>
    /// This cell is used in SevenDay mode and Month mode
    /// </summary>
    public class DayCell : KryptonDataGridViewTextBoxCell
    {
        private int headerHeight = 16;
        private bool bottomSelected = false;

        public DateMode DateMode
        {
            get
            {
                CalendarControl c = this.OwningColumn.DataGridView as CalendarControl;
                return c.DateMode;
            }
        }

        public DateTime StartTime
        {
            get
            {
                try
                {
                    if (this.DateMode == DateMode.SevenDay)
                    {
                        HalfWeekColumn c = this.OwningColumn as HalfWeekColumn;
                        return c.StartTime.AddDays(this.RowIndex);
                    }
                    else
                    {
                        WeekRow r = this.OwningRow as WeekRow;
                        return r.StartTime.AddDays(this.ColumnIndex);
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    return DateTime.MinValue;
                }
            }
        }

        public DateTime EndTime
        {
            get
            {
                if (this.DateMode == DateMode.SevenDay)
                {
                    if (this.RowIndex == 2 && this.ColumnIndex == 1)
                        return this.StartTime.AddDays(2);
                    else
                        return this.StartTime.AddDays(1);
                }
                else
                {
                    if (this.ColumnIndex == 5)
                        return this.StartTime.AddDays(2);
                    else
                        return this.StartTime.AddDays(1);
                }
            }
        }

        public CalendarControl Calendar
        {
            get
            {
                return this.OwningColumn.DataGridView as CalendarControl;
            }
        }

        public List<CalendarItem> CalendarItems
        {
            get
            {
                try
                {
                    if (this.Calendar.CalendarItems == null || this.Calendar.CalendarItems.Count <= 0)
                        return null;

                    List<CalendarItem> allItems = new List<CalendarItem>();
                    if (this.DateMode == DateMode.SevenDay)
                    {
                        HalfWeekColumn c = this.OwningColumn as HalfWeekColumn;
                        allItems = c.Calendar.CalendarItems;
                    }
                    else
                    {
                        WeekRow r = this.OwningRow as WeekRow;
                        allItems = r.Calendar.CalendarItems;
                    }

                    List<CalendarItem> items = new List<CalendarItem>();
                    for (int i = 0; i < allItems.Count; i++)
                    {
                        DateTime ciStartTime = allItems[i].StartTime;
                        DateTime ciEndTime = allItems[i].EndTime;

                        if (((ciStartTime.CompareTo(this.StartTime) <= 0) && (ciEndTime.CompareTo(this.StartTime) > 0))
                        || ((ciStartTime.CompareTo(this.StartTime) >= 0) && (ciEndTime.CompareTo(this.EndTime) <= 0))
                        || ((ciStartTime.CompareTo(this.EndTime) < 0) && (ciEndTime.CompareTo(this.EndTime) >= 0)))
                        {
                            items.Add(allItems[i]);
                        }
                    }
                    return items;
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    return null;
                }
            }
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (!IsSpecialCell)
                    return;

                int middle = this.Size.Height / 2;
                if (e.Y > middle)
                    bottomSelected = true;
                else
                    bottomSelected = false;


            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            try
            {
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Trimming = StringTrimming.EllipsisCharacter;


                // Paint the Background and Header
                if (this.DateMode == DateMode.SevenDay)
                {
                    // Background
                    graphics.FillRectangle(new SolidBrush(CalendarControl.ct.DayBackColour), cellBounds);

                    // Header
                    if (this.StartTime.Year == DateTime.Now.Year && this.StartTime.Month == DateTime.Now.Month && this.StartTime.Day == DateTime.Now.Day)
                    {
                        // For Today we draw orange gradient
                        LinearGradientBrush lgb = new LinearGradientBrush(new Rectangle(cellBounds.Left, cellBounds.Top, cellBounds.Width, headerHeight), CalendarControl.ct.HeaderLight, CalendarControl.ct.HeaderDark, LinearGradientMode.Vertical);
                        graphics.FillRectangle(lgb, cellBounds.Left, cellBounds.Top, cellBounds.Width, headerHeight);
                    }
                    else
                    {
                        graphics.FillRectangle(new SolidBrush(CalendarControl.ct.BackColour), cellBounds.Left, cellBounds.Top, cellBounds.Width, headerHeight);
                    }
                    graphics.DrawLine(new Pen(new SolidBrush(CalendarControl.ct.SeparatorDark)), cellBounds.Left, cellBounds.Top + headerHeight, cellBounds.Right, cellBounds.Top + headerHeight);
                    RectangleF r = new RectangleF(cellBounds.Left + 1, cellBounds.Top, cellBounds.Width - 2, headerHeight);
                    if (this.Selected && !bottomSelected)
                    {
                        graphics.FillRectangle(new SolidBrush(CalendarControl.ct.SelectionColour), cellBounds.Left, cellBounds.Top, cellBounds.Width, headerHeight);
                        sf.Alignment = StringAlignment.Far;
                        graphics.DrawString(this.StartTime.ToLongDateString(), CalendarControl.ct.FontStd, new SolidBrush(CalendarControl.ct.SelectedForeColour), r, sf);
                    }
                    else
                    {
                        sf.Alignment = StringAlignment.Far;
                        if (this.StartTime.Year == DateTime.Now.Year && this.StartTime.Month == DateTime.Now.Month && this.StartTime.Day == DateTime.Now.Day)
                        {
                            graphics.DrawString(this.StartTime.ToLongDateString(), CalendarControl.ct.FontStd, new SolidBrush(CalendarControl.ct.SelectedForeColour), r, sf);
                        }
                        else
                        {
                            graphics.DrawString(this.StartTime.ToLongDateString(), CalendarControl.ct.FontStd, CalendarControl.ct.ForeBrush, r, sf);
                        }
                    }

                    if (this.RowIndex == 2 && this.ColumnIndex == 1) // If Sat/Sun cell drawing the bottom half
                    {
                        // Draw another cell
                        // Draw the middle line through the cell
                        graphics.DrawLine(new Pen(CalendarControl.ct.BorderBrush), cellBounds.Left, cellBounds.Top + (int)(cellBounds.Height / 2) - 1, cellBounds.Right, cellBounds.Top + (int)(cellBounds.Height / 2) - 1);

                        // Header
                        if (this.StartTime.Year == DateTime.Now.Year && this.StartTime.Month == DateTime.Now.Month && this.StartTime.Day == DateTime.Now.Day)
                        {
                            // For Today we draw orange gradient
                            LinearGradientBrush lgb = new LinearGradientBrush(new Rectangle(cellBounds.Left, cellBounds.Top + (int)(cellBounds.Height / 2), cellBounds.Width, headerHeight), CalendarControl.ct.HeaderLight, CalendarControl.ct.HeaderDark, LinearGradientMode.Vertical);
                            graphics.FillRectangle(lgb, cellBounds.Left, cellBounds.Top + (int)(cellBounds.Height / 2), cellBounds.Width, headerHeight);
                        }
                        else
                        {
                            graphics.FillRectangle(new SolidBrush(CalendarControl.ct.BackColour), cellBounds.Left, cellBounds.Top + (int)(cellBounds.Height / 2), cellBounds.Width, headerHeight);
                        }
                        graphics.DrawLine(new Pen(new SolidBrush(CalendarControl.ct.SeparatorDark)), cellBounds.Left, cellBounds.Top + (int)(cellBounds.Height / 2) + headerHeight, cellBounds.Right, cellBounds.Top + (int)(cellBounds.Height / 2) + headerHeight);
                        r = new RectangleF(cellBounds.Left + 1, cellBounds.Top + (int)(cellBounds.Height / 2), cellBounds.Width - 2, headerHeight);
                        if (this.Selected && bottomSelected)
                        {
                            graphics.FillRectangle(new SolidBrush(CalendarControl.ct.SelectionColour), cellBounds.Left, cellBounds.Top + (int)(cellBounds.Height / 2), cellBounds.Width, headerHeight);
                            sf.Alignment = StringAlignment.Far;
                            graphics.DrawString(this.StartTime.AddDays(1).ToLongDateString(), CalendarControl.ct.FontStd, new SolidBrush(CalendarControl.ct.SelectedForeColour), r, sf);
                        }
                        else
                        {
                            sf.Alignment = StringAlignment.Far;
                            if (this.StartTime.Year == DateTime.Now.Year && this.StartTime.Month == DateTime.Now.Month && this.StartTime.Day == DateTime.Now.Day)
                            {
                                graphics.DrawString(this.StartTime.AddDays(1).ToLongDateString(), CalendarControl.ct.FontStd, new SolidBrush(CalendarControl.ct.SelectedForeColour), r, sf);
                            }
                            else
                            {
                                graphics.DrawString(this.StartTime.AddDays(1).ToLongDateString(), CalendarControl.ct.FontStd, CalendarControl.ct.ForeBrush, r, sf);
                            }
                        }
                    }

                    // Border
                    graphics.DrawRectangle(new Pen(CalendarControl.ct.BorderBrush), cellBounds);
                }
                else // Month mode
                {
                    // Background
                    if (IsNewMonth)
                        graphics.FillRectangle(new SolidBrush(CalendarControl.ct.NewMonth), cellBounds);
                    else
                        graphics.FillRectangle(new SolidBrush(CalendarControl.ct.CurrentMonth), cellBounds);

                    // Header
                    RectangleF r = new RectangleF(cellBounds.Left + 1, cellBounds.Top, cellBounds.Width - 2, headerHeight);
                    string headerText = "";
                    if (this.StartTime.Day == 1 || (this.ColumnIndex == 0 && this.RowIndex == 0))
                        headerText = GetHeaderText(0);
                    else
                        headerText = this.StartTime.Day.ToString();

                    if (this.StartTime.Year == DateTime.Now.Year && this.StartTime.Month == DateTime.Now.Month && this.StartTime.Day == DateTime.Now.Day)
                    {
                        // For Today we draw orange gradient
                        LinearGradientBrush lgb = new LinearGradientBrush(new Rectangle(cellBounds.Left, cellBounds.Top, cellBounds.Width, headerHeight), CalendarControl.ct.HeaderLight, CalendarControl.ct.HeaderDark, LinearGradientMode.Vertical);
                        graphics.FillRectangle(lgb, cellBounds.Left, cellBounds.Top, cellBounds.Width, headerHeight);

                        graphics.DrawLine(new Pen(CalendarControl.ct.TodayGradientBrush), cellBounds.Left, cellBounds.Top + headerHeight, cellBounds.Right, cellBounds.Top + headerHeight);
                    }

                    if (this.Selected && !bottomSelected)
                    {
                        graphics.FillRectangle(new SolidBrush(CalendarControl.ct.SelectionColour), cellBounds.Left, cellBounds.Top, cellBounds.Width, headerHeight);
                        sf.Alignment = StringAlignment.Far;
                        graphics.DrawString(headerText, CalendarControl.ct.FontStd, new SolidBrush(CalendarControl.ct.SelectedForeColour), r, sf);
                        graphics.DrawLine(new Pen(new SolidBrush(CalendarControl.ct.SelectionColour)), cellBounds.Left, cellBounds.Top + headerHeight, cellBounds.Right, cellBounds.Top + headerHeight);
                    }
                    else
                    {
                        sf.Alignment = StringAlignment.Far;
                        if (this.StartTime.Year == DateTime.Now.Year && this.StartTime.Month == DateTime.Now.Month && this.StartTime.Day == DateTime.Now.Day)
                        {
                            graphics.DrawString(headerText, CalendarControl.ct.FontStd, new SolidBrush(CalendarControl.ct.SelectedForeColour), r, sf);
                        }
                        else
                        {
                            graphics.DrawString(headerText, CalendarControl.ct.FontStd, CalendarControl.ct.ForeBrush, r, sf);
                        }
                    }

                    if (this.ColumnIndex == 5) // Sat/Sun column
                    {
                        // Draw another cell
                        // Draw the middle line through the cell
                        graphics.DrawLine(new Pen(CalendarControl.ct.BorderBrush), cellBounds.Left, cellBounds.Top + (int)(cellBounds.Height / 2) - 1, cellBounds.Right, cellBounds.Top + (int)(cellBounds.Height / 2) - 1);

                        // If this is a new month paint the background
                        if (this.StartTime.AddDays(1).Day == 1)
                            graphics.FillRectangle(new SolidBrush(CalendarControl.ct.NewMonth), cellBounds.Left, cellBounds.Top + (int)(cellBounds.Height / 2), cellBounds.Width, (int)(cellBounds.Height / 2));

                        // Header
                        r = new RectangleF(cellBounds.Left + 1, cellBounds.Top + (int)(cellBounds.Height / 2), cellBounds.Width - 2, headerHeight);
                        headerText = "";
                        if (this.StartTime.AddDays(1).Day == 1 || (this.ColumnIndex == 0 && this.RowIndex == 0))
                            headerText = GetHeaderText(1);
                        else
                            headerText = this.StartTime.AddDays(1).Day.ToString();

                        if (this.StartTime.Year == DateTime.Now.Year && this.StartTime.Month == DateTime.Now.Month && this.StartTime.Day == DateTime.Now.Day)
                        {
                            // For Today we draw orange gradient
                            LinearGradientBrush lgb = new LinearGradientBrush(new Rectangle(cellBounds.Left, cellBounds.Top + (int)(cellBounds.Height / 2), cellBounds.Width, headerHeight), CalendarControl.ct.HeaderLight, CalendarControl.ct.HeaderDark, LinearGradientMode.Vertical);
                            graphics.FillRectangle(lgb, cellBounds.Left, cellBounds.Top + (int)(cellBounds.Height / 2), cellBounds.Width, headerHeight);
                            graphics.DrawLine(new Pen(CalendarControl.ct.TodayGradientBrush), cellBounds.Left, cellBounds.Top + (int)(cellBounds.Height / 2) + headerHeight, cellBounds.Right, cellBounds.Top + (int)(cellBounds.Height / 2) + headerHeight);
                        }

                        if (this.Selected && bottomSelected)
                        {
                            graphics.FillRectangle(new SolidBrush(CalendarControl.ct.SelectionColour), cellBounds.Left, cellBounds.Top + (int)(cellBounds.Height / 2), cellBounds.Width, headerHeight);
                            sf.Alignment = StringAlignment.Far;
                            graphics.DrawString(headerText, CalendarControl.ct.FontStd, new SolidBrush(CalendarControl.ct.SelectedForeColour), r, sf);
                            graphics.DrawLine(new Pen(new SolidBrush(CalendarControl.ct.SelectionColour)), cellBounds.Left, cellBounds.Top + (int)(cellBounds.Height / 2) + headerHeight, cellBounds.Right, cellBounds.Top + (int)(cellBounds.Height / 2) + headerHeight);
                        }
                        else
                        {
                            sf.Alignment = StringAlignment.Far;
                            if (this.StartTime.Year == DateTime.Now.Year && this.StartTime.Month == DateTime.Now.Month && this.StartTime.Day == DateTime.Now.Day)
                            {
                                graphics.DrawString(headerText, CalendarControl.ct.FontStd, new SolidBrush(CalendarControl.ct.SelectedForeColour), r, sf);
                            }
                            else
                            {
                                graphics.DrawString(headerText, CalendarControl.ct.FontStd, CalendarControl.ct.ForeBrush, r, sf);
                            }
                        }
                    }

                    // Border
                    graphics.DrawRectangle(new Pen(CalendarControl.ct.BorderBrush), cellBounds);

                } // Paint Background and Header

                // Paint items

                // Sort on StartTime
                List<CalendarItem> items = this.CalendarItems;
                for (int i = 0; i < items.Count; i++)
                {
                    for (int j = i; j < items.Count; j++)
                    {
                        if (items[i].StartTime.CompareTo(items[j].StartTime) > 0)
                        {
                            CalendarItem temp = items[i];
                            items[i] = items[j];
                            items[j] = temp;
                        }
                    }
                }

                if (!IsSpecialCell)
                {
                    // Form the text
                    string text = "";
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (this.DateMode == DateMode.SevenDay)
                            text += String.Format("{0} {1}  {2}\n", items[i].StartTime.ToShortTimeString().ToLower(), items[i].EndTime.ToShortTimeString().ToLower(), items[i].Description);
                        else
                            text += String.Format("{0}  {1}\n", items[i].StartTime.ToShortTimeString().ToLower(), items[i].Description);
                    }

                    RectangleF rect = new RectangleF(cellBounds.Left + 3, cellBounds.Top + headerHeight + 8, cellBounds.Width - 3, cellBounds.Height - headerHeight - 8);

                    //LinearGradientBrush lgb = new LinearGradientBrush(rect, ColorTable.getLightColor(items[i].Color, 110), items[i].Color, LinearGradientMode.Horizontal);
                    //graphics.FillRectangle(lgb, rect);

                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    graphics.DrawString(text, CalendarControl.ct.FontStd, CalendarControl.ct.ForeBrush, rect, sf);
                }
                else
                {
                    string textSaturday = "";
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].StartTime.DayOfWeek != DayOfWeek.Saturday)
                            continue;
                        if (this.DateMode == DateMode.SevenDay)
                            textSaturday += String.Format("{0} {1}  {2}\n", items[i].StartTime.ToShortTimeString().ToLower(), items[i].EndTime.ToShortTimeString().ToLower(), items[i].Description);
                        else
                            textSaturday += String.Format("{0}  {1}\n", items[i].StartTime.ToShortTimeString().ToLower(), items[i].Description);
                    }

                    string textSunday = "";
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].StartTime.DayOfWeek != DayOfWeek.Sunday)
                            continue;
                        if (this.DateMode == DateMode.SevenDay)
                            textSunday += String.Format("{0} {1}  {2}\n", items[i].StartTime.ToShortTimeString().ToLower(), items[i].EndTime.ToShortTimeString().ToLower(), items[i].Description);
                        else
                            textSunday += String.Format("{0}  {1}\n", items[i].StartTime.ToShortTimeString().ToLower(), items[i].Description);
                    }

                    RectangleF rectSaturday = new RectangleF(cellBounds.Left + 3, cellBounds.Top + headerHeight + 8, cellBounds.Width - 3, (int)cellBounds.Height / 2 - headerHeight - 8);
                    RectangleF rectSunday = new RectangleF(cellBounds.Left + 3, cellBounds.Top + (int)cellBounds.Height / 2 + headerHeight + 8, cellBounds.Width - 3, (int)cellBounds.Height / 2 - headerHeight - 8);
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    graphics.DrawString(textSaturday, CalendarControl.ct.FontStd, CalendarControl.ct.ForeBrush, rectSaturday, sf);
                    graphics.DrawString(textSunday, CalendarControl.ct.FontStd, CalendarControl.ct.ForeBrush, rectSunday, sf);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        private string GetHeaderText(int i)
        {
            string text = this.StartTime.AddDays(i).ToLongDateString();
            string[] temp = text.Split(',');
            return temp[1].Trim();
        }

        private bool IsNewMonth
        {
            get
            {
                int minimumDate = this.RowIndex * 7 + this.ColumnIndex;
                if (this.StartTime.Day < minimumDate)
                    return true;
                else
                    return false;
            }
        }

        private bool IsSpecialCell
        {
            get
            {
                if (this.DateMode == DateMode.SevenDay)
                {
                    if (this.RowIndex == 2 && this.ColumnIndex == 1)
                        return true;
                }
                else if (this.DateMode == DateMode.Month)
                {
                    if (this.ColumnIndex == 5)
                        return true;
                }
                return false;
            }
        }

    }// class
}