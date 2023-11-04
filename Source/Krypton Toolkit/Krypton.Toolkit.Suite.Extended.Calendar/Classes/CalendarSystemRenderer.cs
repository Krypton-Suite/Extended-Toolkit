﻿#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

// ReSharper disable RedundantOverriddenMember
namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    /// <summary>
    /// CalendarRenderer that renders low-intensity calendar for slow computers
    /// </summary>
    public class CalendarSystemRenderer : CalendarRenderer
    {
        #region Fields
        private CalendarColourTable _colourTable;
        private float _selectedItemBorder;
        #endregion

        #region Ctor

        public CalendarSystemRenderer(KryptonCalendar calendar) : base(calendar)
        {
            ColourTable = new CalendarColourTable();
            SelectedItemBorder = 1;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="CalendarColourTable"/> for this renderer
        /// </summary>
        public CalendarColourTable ColourTable
        {
            get => _colourTable;
            set => _colourTable = value;
        }

        /// <summary>
        /// Gets or sets the size of the border of selected items
        /// </summary>
        public float SelectedItemBorder
        {
            get => _selectedItemBorder;
            set => _selectedItemBorder = value;
        }


        #endregion

        #region Overrides

        public override void OnDrawBackground(CalendarRendererEventArgs e)
        {
            e.Graphics?.Clear(ColourTable.Background);
        }

        public override void OnDrawDay(CalendarRendererDayEventArgs e)
        {
            if (e.Day != null)
            {
                Rectangle r = e.Day.Bounds;

                if (e.Day.Selected)
                {
                    using (Brush b = new SolidBrush(ColourTable.DayBackgroundSelected))
                    {
                        if (e.Graphics != null)
                        {
                            e.Graphics.FillRectangle(b, r);
                        }
                    }
                }
                else if (e.Day.Date.Month % 2 == 0)
                {
                    using (Brush b = new SolidBrush(ColourTable.DayBackgroundEven))
                    {
                        if (e.Graphics != null)
                        {
                            e.Graphics.FillRectangle(b, r);
                        }
                    }
                }
                else
                {
                    using (Brush b = new SolidBrush(ColourTable.DayBackgroundOdd))
                    {
                        if (e.Graphics != null)
                        {
                            e.Graphics.FillRectangle(b, r);
                        }
                    }
                }
            }

            base.OnDrawDay(e);
        }

        public override void OnDrawDayBorder(CalendarRendererDayEventArgs e)
        {
            base.OnDrawDayBorder(e);

            if (e.Day != null)
            {
                Rectangle r = e.Day.Bounds;
                bool today = e.Day.Date.Date.Equals(DateTime.Today.Date);

                using (Pen p = new Pen(today ? ColourTable.TodayBorder : ColourTable.DayBorder, today ? 2 : 1))
                {
                    if (e.Calendar?.DaysMode == CalendarDaysMode.Short)
                    {
                        if (e.Graphics != null)
                        {
                            e.Graphics.DrawLine(p, r.Right, r.Top, r.Right, r.Bottom);
                        }
                        e.Graphics!.DrawLine(p, r.Left, r.Bottom, r.Right, r.Bottom);

                        if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday || today)
                        {
                            if (e.Graphics != null)
                            {
                                e.Graphics.DrawLine(p, r.Left, r.Top, r.Left, r.Bottom);
                            }
                        }
                    }
                    else
                    {
                        if (e.Graphics != null)
                        {
                            e.Graphics.DrawRectangle(p, r);
                        }
                    }
                }
            }
        }

        public override void OnDrawDayTop(CalendarRendererDayEventArgs e)
        {
            bool s = e.Day != null && e.Day.DayTop != null && e.Day.DayTop.Selected;

            using (Brush b = new SolidBrush(s ? ColourTable.DayTopSelectedBackground : ColourTable.DayTopBackground))
            {
                if (e.Day != null && e.Day.DayTop != null)
                {
                    if (e.Graphics != null)
                    {
                        e.Graphics.FillRectangle(b, e.Day.DayTop.Bounds);
                    }
                }
            }

            using (Pen p = new Pen(s ? ColourTable.DayTopSelectedBorder : ColourTable.DayTopBorder))
            {
                if (e.Day != null && e.Day.DayTop != null)
                {
                    if (e.Graphics != null)
                    {
                        e.Graphics.DrawRectangle(p, e.Day.DayTop.Bounds);
                    }
                }
            }

            base.OnDrawDayTop(e);
        }

        public override void OnDrawDayHeaderBackground(CalendarRendererDayEventArgs e)
        {
            bool today = e.Day != null && e.Day.Date.Date.Equals(DateTime.Today.Date);

            using (Brush b = new SolidBrush(today ? ColourTable.TodayTopBackground : ColourTable.DayHeaderBackground))
            {
                if (e.Day != null)
                {
                    if (e.Graphics != null)
                    {
                        e.Graphics.FillRectangle(b, e.Day.HeaderBounds);
                    }
                }
            }

            base.OnDrawDayHeaderBackground(e);
        }

        public override void OnDrawWeekHeader(CalendarRendererBoxEventArgs e)
        {
            using (Brush b = new SolidBrush(ColourTable.WeekHeaderBackground))
            {
                if (e.Graphics != null)
                {
                    e.Graphics.FillRectangle(b, e.Bounds);
                }
            }

            using (Pen p = new Pen(ColourTable.WeekHeaderBorder))
            {
                if (e.Graphics != null)
                {
                    e.Graphics.DrawRectangle(p, e.Bounds);
                }
            }

            e.TextColour = ColourTable.WeekHeaderText;

            base.OnDrawWeekHeader(e);
        }

        public override void OnDrawDayTimeUnit(CalendarRendererTimeUnitEventArgs e)
        {
            base.OnDrawDayTimeUnit(e);

            using (SolidBrush b = new SolidBrush(ColourTable.TimeUnitBackground))
            {
                if (e.Unit != null && e.Unit.Selected)
                {
                    b.Color = ColourTable.TimeUnitSelectedBackground;
                }
                else if (e.Unit != null && e.Unit.Highlighted)
                {
                    b.Color = ColourTable.TimeUnitHighlightedBackground;
                }

                if (e.Unit != null)
                {
                    if (e.Graphics != null)
                    {
                        e.Graphics.FillRectangle(b, e.Unit.Bounds);
                    }
                }
            }

            using (Pen p = new Pen(e.Unit != null && e.Unit.Minutes == 0 ? ColourTable.TimeUnitBorderDark : ColourTable.TimeUnitBorderLight))
            {
                if (e.Unit != null)
                {
                    if (e.Graphics != null)
                    {
                        e.Graphics.DrawLine(p, e.Unit.Bounds.Location, new Point(e.Unit.Bounds.Right, e.Unit.Bounds.Top));
                    }
                }
            }

            //TextRenderer.DrawText(e.Graphics, e.Unit.PassingItems.Count.ToString(), e.Calendar.Font, e.Unit.Bounds, Color.Black);
        }

        public override void OnDrawTimeScale(CalendarRendererEventArgs e)
        {
            int margin = 5;
            int largeX1 = TimeScaleBounds.Left + margin;
            int largeX2 = TimeScaleBounds.Right - margin;
            int shortX1 = TimeScaleBounds.Left + TimeScaleBounds.Width / 2;
            int shortX2 = largeX2;
            int top;
            Pen p = new Pen(ColourTable.TimeScaleLine);

            for (int i = 0; i < e.Calendar?.Days[0]!.TimeUnits.Length; i++)
            {
                CalendarTimeScaleUnit? unit = e.Calendar?.Days[0]!.TimeUnits[i];

                if (unit != null && !unit.Visible)
                {
                    continue;
                }

                if (unit != null)
                {
                    top = unit.Bounds.Top;

                    if (unit.Minutes == 0)
                    {
                        if (e.Graphics != null)
                        {
                            e.Graphics.DrawLine(p, largeX1, top, largeX2, top);
                        }
                    }
                    else
                    {
                        if (e.Graphics != null)
                        {
                            e.Graphics.DrawLine(p, shortX1, top, shortX2, top);
                        }
                    }
                }
            }

            if (e.Calendar!.DaysMode == CalendarDaysMode.Expanded
                && e.Calendar?.Days != null
                && e.Calendar?.Days.Length > 0
                && e.Calendar?.Days[0]?.TimeUnits != null
                && e.Calendar?.Days[0]?.TimeUnits.Length > 0
                )
            {
                top = e.Calendar!.Days[0]!.BodyBounds.Top;

                //Timescale top line is full
                e.Graphics?.DrawLine(p, TimeScaleBounds.Left, top, TimeScaleBounds.Right, top);
            }

            p.Dispose();

            base.OnDrawTimeScale(e);
        }

        public override void OnDrawTimeScaleHour(CalendarRendererBoxEventArgs e)
        {
            e.TextColour = ColourTable.TimeScaleHours;
            base.OnDrawTimeScaleHour(e);
        }

        public override void OnDrawTimeScaleMinutes(CalendarRendererBoxEventArgs e)
        {
            e.TextColour = ColourTable.TimeScaleMinutes;
            base.OnDrawTimeScaleMinutes(e);
        }

        public override void OnDrawItemBackground(CalendarRendererItemBoundsEventArgs e)
        {
            base.OnDrawItemBackground(e);

            int alpha = 255;

            if (e.Item != null && e.Item.IsDragging)
            {
                alpha = 120;
            }
            else if (e.Calendar?.DaysMode == CalendarDaysMode.Short)
            {
                alpha = 200;
            }

            Color colour1 = Color.White;
            Color colour2 = e.Item != null && e.Item.Selected ? ColourTable.ItemSelectedBackground : ColourTable.ItemBackground;

            if (e.Item != null && !e.Item.BackgroundColourLighter.IsEmpty)
            {
                if (e.Item != null)
                {
                    colour1 = e.Item.BackgroundColourLighter;
                }
            }

            if (e.Item != null && !e.Item.BackgroundColour.IsEmpty)
            {
                if (e.Item != null)
                {
                    colour2 = e.Item.BackgroundColour;
                }
            }

            ItemFill(e, e.Bounds, Color.FromArgb(alpha, colour1), Color.FromArgb(alpha, colour2));

        }

        public override void OnDrawItemShadow(CalendarRendererItemBoundsEventArgs e)
        {
            base.OnDrawItemShadow(e);

            if (e.Item != null && (e.Item.IsOnDayTop || e.Calendar?.DaysMode == CalendarDaysMode.Short || e.Item.IsDragging))
            {
                return;
            }

            Rectangle r = e.Bounds;
            r.Offset(ItemShadowPadding, ItemShadowPadding);

            using (SolidBrush b = new SolidBrush(ColourTable.ItemShadow))
            {
                ItemFill(e, r, ColourTable.ItemShadow, ColourTable.ItemShadow);
            }
        }

        public override void OnDrawItemBorder(CalendarRendererItemBoundsEventArgs e)
        {
            base.OnDrawItemBorder(e);

            Color a = e.Item != null && e.Item.BorderColour.IsEmpty ? ColourTable.ItemBorder : e.Item!.BorderColour;
            Color b = e.Item.Selected && !e.Item.IsDragging ? ColourTable.ItemSelectedBorder : a;
            Color c = Color.FromArgb(e.Item.IsDragging ? 120 : 255, b);

            ItemBorder(e, e.Bounds, c, e.Item.Selected && !e.Item.IsDragging ? SelectedItemBorder : 1f);

        }

        public override void OnDrawItemStartTime(CalendarRendererBoxEventArgs e)
        {
            if (e.TextColour.IsEmpty)
            {
                e.TextColour = ColourTable.ItemSecondaryText;
            }

            base.OnDrawItemStartTime(e);
        }

        public override void OnDrawItemEndTime(CalendarRendererBoxEventArgs e)
        {
            if (e.TextColour.IsEmpty)
            {
                e.TextColour = ColourTable.ItemSecondaryText;
            }

            base.OnDrawItemEndTime(e);
        }

        public override void OnDrawItemText(CalendarRendererBoxEventArgs e)
        {
            CalendarItemAlternative? item = e.Tag as CalendarItemAlternative;

            if (item != null)
            {
                if (item.IsDragging)
                {
                    e.TextColour = Color.FromArgb(120, e.TextColour);
                }
            }

            base.OnDrawItemText(e);
        }

        public override void OnDrawWeekHeaders(CalendarRendererEventArgs e)
        {
            base.OnDrawWeekHeaders(e);
        }

        public override void OnDrawDayNameHeader(CalendarRendererBoxEventArgs e)
        {
            e.TextColour = ColourTable.WeekDayName;

            base.OnDrawDayNameHeader(e);

            using (Pen p = new Pen(ColourTable.WeekDayName))
            {
                if (e.Graphics != null)
                {
                    e.Graphics.DrawLine(p, e.Bounds.Right, e.Bounds.Top, e.Bounds.Right, e.Bounds.Bottom);
                }
            }
        }

        public override void OnDrawDayOverflowEnd(CalendarRendererDayEventArgs e)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                if (e.Day != null)
                {
                    int top = e.Day.OverflowEndBounds.Top + e.Day.OverflowEndBounds.Height / 2;
                    path.AddPolygon(new Point[] {
                        new(e.Day.OverflowEndBounds.Left, top),
                        new(e.Day.OverflowEndBounds.Right, top),
                        new(e.Day.OverflowEndBounds.Left + e.Day.OverflowEndBounds.Width / 2, e.Day.OverflowEndBounds.Bottom),
                    });
                }

                using (Brush b = new SolidBrush(e.Day != null && e.Day.OverflowEndSelected ? ColourTable.DayOverflowSelectedBackground : ColourTable.DayOverflowBackground))
                {
                    if (e.Graphics != null)
                    {
                        e.Graphics.FillPath(b, path);
                    }
                }

                using (Pen p = new Pen(ColourTable.DayOverflowBorder))
                {
                    if (e.Graphics != null)
                    {
                        e.Graphics.DrawPath(p, path);
                    }
                }
            }
        }

        #endregion
    }
}