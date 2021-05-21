using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Calendar.Library
{
    /// <summary>
    /// This class is used with DayColumn
    /// </summary>
    public class HalfHourCell : DataGridViewTextBoxCell
    {
        private int m_rowIndex = 0;

        public HalfHourCell() : base()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem item = new ToolStripMenuItem("New Appointment");
            contextMenuStrip.Items.Add(item);
            item.Click += new EventHandler(item_Click);
            //this.ContextMenuStrip = contextMenuStrip;
        }

        private void item_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        public DateTime StartTime
        {
            get
            {
                try
                {
                    // Each cell represent 30 minutes starting from 12 am
                    DayColumn dc = this.OwningColumn as DayColumn;
                    DateTime startTime = dc.StartTime;
                    int rowIndex = (this.RowIndex < 0) ? m_rowIndex : this.RowIndex;
                    int minutes = (rowIndex) * 30;
                    return startTime.AddMinutes(minutes);
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
                return this.StartTime.AddMinutes(30);
            }
        }

        public bool IsWorkingTime
        {
            get
            {
                DayColumn dc = this.OwningColumn as DayColumn;
                if (dc.IsWeekend)
                    return false;

                DateTime workingHourStartTime = dc.StartTime.AddHours(dc.WorkingHourStart);
                DateTime workingHourEndTime = dc.StartTime.AddHours(dc.WorkingHourEnd);

                if (this.StartTime.CompareTo(workingHourStartTime) >= 0 && this.EndTime.CompareTo(workingHourEndTime) <= 0)
                    return true;
                else
                    return false;
            }
        }

        public DayColumn DayColumn
        {
            get
            {
                return this.OwningColumn as DayColumn;
            }
        }

        public List<CalendarItem> CalendarItems
        {
            get
            {
                try
                {
                    if (this.DayColumn.CalendarItems == null || this.DayColumn.CalendarItems.Count <= 0)
                        return null;

                    List<CalendarItem> items = new List<CalendarItem>();
                    for (int i = 0; i < this.DayColumn.CalendarItems.Count; i++)
                    {
                        DateTime ciStartTime = this.DayColumn.CalendarItems[i].StartTime;
                        DateTime ciEndTime = this.DayColumn.CalendarItems[i].EndTime;

                        if (((ciStartTime.CompareTo(this.StartTime) <= 0) && (ciEndTime.CompareTo(this.StartTime) > 0))
                        || ((ciStartTime.CompareTo(this.StartTime) >= 0) && (ciEndTime.CompareTo(this.EndTime) <= 0))
                        || ((ciStartTime.CompareTo(this.EndTime) < 0) && (ciEndTime.CompareTo(this.EndTime) >= 0)))
                        {
                            items.Add(this.DayColumn.CalendarItems[i]);
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

        private int CountOfItemsOverlappingWithThisItem(CalendarItem item, ref int order)
        {
            try
            {
                // Find out how many maximum items this item overlaps with
                // for a given cell
                int overlapCount = 0;
                List<CalendarItem> list = new List<CalendarItem>();
                DateTime startTime = item.StartTime;
                while (startTime.CompareTo(item.EndTime) < 0)
                {
                    HalfHourCell cell = this.DayColumn.GetHalfHourCell(startTime);
                    List<CalendarItem> items = cell.CalendarItems;
                    if (items == null)
                        continue;
                    if (items.Count - 1 > overlapCount)
                    {
                        overlapCount = items.Count - 1;
                        list = items;
                    }
                    startTime = startTime.AddMinutes(30);
                }

                //// Now check this list to see the correct overlapCount -> this is
                //// bacause the items in the list may be overlapping already and
                //// we need to account for this.
                //for (int i = 0; i < list.Count; i++)
                //{
                //    // Only check items whose index is less that that of this item
                //    int indexOfThisItem = this.DayColumn.Calendar.CalendarItems.IndexOf(item);
                //    int indexOfOtherItem = this.DayColumn.Calendar.CalendarItems.IndexOf(list[i]);
                //    if (indexOfOtherItem >= indexOfThisItem)
                //        continue;

                //    int otherOverlap = this.DayColumn.Calendar.OverlapCount[list[i]];
                //    if (overlapCount <= otherOverlap)
                //        overlapCount = otherOverlap + 1;
                //}

                // Now overlapCount has the maximum number of items this item overlaps with.
                this.DayColumn.Calendar.OverlapCount[item] = overlapCount;

                if (overlapCount == 0)
                {
                    order = 0;
                    this.DayColumn.Calendar.OrderCount[item] = 0;
                    return 0;
                }

                // To find the order of this item we will go through the list
                // and figure out the order
                bool[] orders = new bool[overlapCount + 1];
                for (int i = 0; i < list.Count; i++)
                {
                    // Only check items whose index is less that that of this item
                    int indexOfThisItem = this.DayColumn.Calendar.CalendarItems.IndexOf(item);
                    int indexOfOtherItem = this.DayColumn.Calendar.CalendarItems.IndexOf(list[i]);
                    if (indexOfOtherItem >= indexOfThisItem)
                        continue;

                    // If other item already has an order note it. If a previous
                    // order is available then take that
                    if (this.DayColumn.Calendar.OrderCount.ContainsKey(list[i]))
                    {
                        int itemOrder = this.DayColumn.Calendar.OrderCount[list[i]];
                        orders[itemOrder] = true;
                        for (int k = 0; k < itemOrder; k++)
                        {
                            if (!orders[k])
                            {
                                order = k;
                                orders[k] = true;
                                this.DayColumn.Calendar.OrderCount[item] = k;
                                return overlapCount;
                            }
                        }
                    }
                    else
                    {
                        // Item does not have an order. Give it the first available order
                        for (int k = 0; k < orders.Length; k++)
                        {
                            if (!orders[k])
                            {
                                this.DayColumn.Calendar.OrderCount[list[i]] = k;
                                orders[k] = true;
                            }
                        }
                    }
                }// for

                // Now take the first available spot in orders
                for (int k = 0; k < orders.Length; k++)
                {
                    if (!orders[k])
                    {
                        order = k;
                        orders[k] = true;
                        this.DayColumn.Calendar.OrderCount[item] = k;
                        return overlapCount;
                    }
                }
                return 0;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.ToString());
                order = 0;
                return 0;
            }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            try
            {
                m_rowIndex = rowIndex;


                if (IsWorkingTime)
                    graphics.FillRectangle(new SolidBrush(Calendar.ct.WorkingColor), cellBounds);
                else
                    graphics.FillRectangle(new SolidBrush(Calendar.ct.NonWorkingColor), cellBounds);

                if (this.Selected)
                    graphics.FillRectangle(new SolidBrush(Calendar.ct.SelectedBackColor), cellBounds);

                int leftMargin = 4;
                int rightMargin = 3;

                // Draw the left margin vertical line and fill
                Pen pen = new Pen(new SolidBrush(Calendar.ct.BorderColor));
                graphics.DrawLine(pen, cellBounds.Left + leftMargin, cellBounds.Top, cellBounds.Left + leftMargin, cellBounds.Bottom);
                graphics.FillRectangle(new SolidBrush(Calendar.ct.LeftMarginFillColor), cellBounds.Left, cellBounds.Top, leftMargin, cellBounds.Height);

                // Draw the bottom end of cell
                if (this.EndTime.Minute == 0)
                    graphics.DrawLine(new Pen(new SolidBrush(Calendar.ct.HourEndingColor)), cellBounds.Left + leftMargin + 1, cellBounds.Bottom - 1, cellBounds.Right, cellBounds.Bottom - 1);
                else
                    graphics.DrawLine(new Pen(new SolidBrush(Calendar.ct.HalfHourEndingColor)), cellBounds.Left + leftMargin + 1, cellBounds.Bottom - 1, cellBounds.Right, cellBounds.Bottom - 1);

                // Draw the right end of the cell
                graphics.DrawLine(pen, cellBounds.Right - 1, cellBounds.Top, cellBounds.Right - 1, cellBounds.Bottom);

                List<CalendarItem> items = this.CalendarItems;
                if (items == null || items.Count <= 0)
                    return;

                for (int i = 0; i < items.Count; i++)
                {
                    int order = 0;
                    int numberOfItemsOverlapping = this.CountOfItemsOverlappingWithThisItem(items[i], ref order);

                    int widthForMargins = (leftMargin + rightMargin) * (numberOfItemsOverlapping + 1);
                    int widthForItem = (int)((cellBounds.Width - widthForMargins) / (numberOfItemsOverlapping + 1));

                    int startX = ((leftMargin + widthForItem + rightMargin) * order) + cellBounds.X;

                    // Draw the end of cell for item's portion of the cell
                    if (this.EndTime.Minute == 0)
                        graphics.DrawLine(new Pen(new SolidBrush(Calendar.ct.HourEndingColor)), startX + leftMargin + 1, cellBounds.Bottom - 1, startX + leftMargin + widthForItem + rightMargin, cellBounds.Bottom - 1);
                    else
                        graphics.DrawLine(new Pen(new SolidBrush(Calendar.ct.HalfHourEndingColor)), startX + leftMargin + 1, cellBounds.Bottom - 1, startX + leftMargin + widthForItem + rightMargin, cellBounds.Bottom - 1);

                    // Fill the back color (Gradient) for the item
                    Rectangle ItemRect = new Rectangle(startX + leftMargin, cellBounds.Top, widthForItem, cellBounds.Height);
                    LinearGradientBrush lgb = new LinearGradientBrush(ItemRect, ColourTable.getLightColor(items[i].Color, 110), items[i].Color, LinearGradientMode.Horizontal);
                    graphics.FillRectangle(lgb, ItemRect);
                    //graphics.FillRectangle(new SolidBrush(items[i].Color), startX + leftMargin, cellBounds.Top, widthForItem, cellBounds.Height);

                    // Fill the left margin
                    if (items[i].IsTentative)
                    {
                        HatchBrush hb = new HatchBrush(HatchStyle.WideUpwardDiagonal, Calendar.ct.LeftMarginFillColor, Calendar.ct.ItemLeftMarginColor);
                        graphics.FillRectangle(hb, startX, cellBounds.Top, leftMargin, cellBounds.Height);
                    }
                    else
                    {
                        graphics.FillRectangle(new SolidBrush(Calendar.ct.ItemLeftMarginColor), startX, cellBounds.Top, leftMargin, cellBounds.Height);
                    }

                    // Draw the top horizontal line and draw description
                    if (items[i].StartTime.Equals(this.StartTime))
                    {
                        graphics.DrawLine(pen, startX, cellBounds.Top, startX + leftMargin + widthForItem, cellBounds.Top);
                        PointF p = new PointF((float)(startX + leftMargin + 2), (float)(cellBounds.Top + 2));
                        graphics.DrawString(items[i].Description, new Font("Arial", 8), Calendar.ct.ForeBrush, p);
                    }

                    // Draw the startX (left most) vertical line
                    graphics.DrawLine(pen, startX, cellBounds.Top, startX, cellBounds.Bottom);

                    // Draw the left margin vertical line
                    graphics.DrawLine(pen, startX + leftMargin, cellBounds.Top, startX + leftMargin, cellBounds.Bottom);

                    // Draw the right vertical line
                    graphics.DrawLine(pen, startX + leftMargin + widthForItem, cellBounds.Top, startX + leftMargin + widthForItem, cellBounds.Bottom);

                    // Draw the bottom horizontal line of the item
                    if (items[i].EndTime.Equals(this.EndTime))
                        graphics.DrawLine(pen, startX, cellBounds.Bottom - 1, startX + leftMargin + widthForItem, cellBounds.Bottom - 1);

                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

    }// class
}