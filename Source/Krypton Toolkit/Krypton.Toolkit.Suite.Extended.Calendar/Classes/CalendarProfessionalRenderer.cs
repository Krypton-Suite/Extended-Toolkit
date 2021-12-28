#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    public class CalendarProfessionalRenderer : CalendarSystemRenderer
    {
        #region Fields

        public Color HeaderA = FromHex("#E4ECF6");
        public Color HeaderB = FromHex("#D6E2F1");
        public Color HeaderC = FromHex("#C2D4EB");
        public Color HeaderD = FromHex("#D0DEEF");

        public Color TodayA = FromHex("#F8D478");
        public Color TodayB = FromHex("#F8D478");
        public Color TodayC = FromHex("#F2AA36");
        public Color TodayD = FromHex("#F7C966");

        #endregion

        #region Ctor

        public CalendarProfessionalRenderer(KryptonCalendar c) : base(c)
        {

            ColourTable.Background = FromHex("#E3EFFF");
            ColourTable.DayBackgroundEven = FromHex("#A5BFE1");
            ColourTable.DayBackgroundOdd = FromHex("#FFFFFF");
            ColourTable.DayBackgroundSelected = FromHex("#E6EDF7");
            ColourTable.DayBorder = FromHex("#5D8CC9");
            ColourTable.DayHeaderBackground = FromHex("#DFE8F5");
            ColourTable.DayHeaderText = Color.Black;
            ColourTable.DayHeaderSecondaryText = Color.Black;
            ColourTable.DayTopBorder = FromHex("#5D8CC9");
            ColourTable.DayTopSelectedBorder = FromHex("#5D8CC9");
            ColourTable.DayTopBackground = FromHex("#A5BFE1");
            ColourTable.DayTopSelectedBackground = FromHex("#294C7A");
            ColourTable.ItemBorder = FromHex("#5D8CC9");
            ColourTable.ItemBackground = FromHex("#C0D3EA");
            ColourTable.ItemText = Color.Black;
            ColourTable.ItemSecondaryText = FromHex("#294C7A");
            ColourTable.ItemSelectedBorder = Color.Black;
            ColourTable.ItemSelectedBackground = FromHex("#C0D3EA");
            ColourTable.ItemSelectedText = Color.Black;
            ColourTable.WeekHeaderBackground = FromHex("#DFE8F5");
            ColourTable.WeekHeaderBorder = FromHex("#5D8CC9");
            ColourTable.WeekHeaderText = FromHex("#5D8CC9");
            ColourTable.TodayBorder = FromHex("#EE9311");
            ColourTable.TodayTopBackground = FromHex("#EE9311");
            ColourTable.TimeScaleLine = FromHex("#6593CF");
            ColourTable.TimeScaleHours = FromHex("#6593CF");
            ColourTable.TimeScaleMinutes = FromHex("#6593CF");
            ColourTable.TimeUnitBackground = FromHex("#E6EDF7");
            ColourTable.TimeUnitHighlightedBackground = Color.White;
            ColourTable.TimeUnitSelectedBackground = FromHex("#294C7A");
            ColourTable.TimeUnitBorderLight = FromHex("#D5E1F1");
            ColourTable.TimeUnitBorderDark = FromHex("#A5BFE1");
            ColourTable.WeekDayName = FromHex("#6593CF");

            SelectedItemBorder = 2f;
            ItemRoundness = 5;
        }

        #endregion

        #region Private Method

        public static void GradientRect(Graphics g, Rectangle bounds, Color a, Color b)
        {
            using (LinearGradientBrush br = new LinearGradientBrush(bounds, b, a, -90))
            {
                g.FillRectangle(br, bounds);
            }
        }

        public static void GlossyRect(Graphics g, Rectangle bounds, Color a, Color b, Color c, Color d)
        {
            Rectangle top = new Rectangle(bounds.Left, bounds.Top, bounds.Width, bounds.Height / 2);
            Rectangle bot = Rectangle.FromLTRB(bounds.Left, top.Bottom, bounds.Right, bounds.Bottom);

            GradientRect(g, top, a, b);
            GradientRect(g, bot, c, d);

        }

        /// <summary>
        /// Shortcut to one on CalendarColorTable
        /// </summary>
        /// <param name="colour"></param>
        /// <returns></returns>
        private static Color FromHex(string colour)
        {
            return CalendarColourTable.FromHex(colour);
        }

        #endregion

        #region Overrides

        public override void OnInitialize(CalendarRendererEventArgs e)
        {
            base.OnInitialize(e);

            e.Calendar.Font = SystemFonts.CaptionFont;
        }

        public override void OnDrawDayHeaderBackground(CalendarRendererDayEventArgs e)
        {
            Rectangle r = e.Day.HeaderBounds;

            if (e.Day.Date == DateTime.Today)
            {
                GlossyRect(e.Graphics, e.Day.HeaderBounds, TodayA, TodayB, TodayC, TodayD);
            }
            else
            {
                GlossyRect(e.Graphics, e.Day.HeaderBounds, HeaderA, HeaderB, HeaderC, HeaderD);
            }

            if (e.Calendar.DaysMode == CalendarDaysMode.SHORT)
            {
                using (Pen p = new Pen(ColourTable.DayBorder))
                {
                    e.Graphics.DrawLine(p, r.Left, r.Top, r.Right, r.Top);
                    e.Graphics.DrawLine(p, r.Left, r.Bottom, r.Right, r.Bottom);
                }
            }
        }

        public override void OnDrawItemBorder(CalendarRendererItemBoundsEventArgs e)
        {
            base.OnDrawItemBorder(e);

            using (Pen p = new Pen(Color.FromArgb(150, Color.White)))
            {
                e.Graphics.DrawLine(p, e.Bounds.Left + ItemRoundness, e.Bounds.Top + 1, e.Bounds.Right - ItemRoundness, e.Bounds.Top + 1);
            }

            if (e.Item.Selected && !e.Item.IsDragging)
            {
                bool horizontal = false;
                bool vertical = false;
                Rectangle r1 = new Rectangle(0, 0, 5, 5);
                Rectangle r2 = new Rectangle(0, 0, 5, 5);

                horizontal = e.Item.IsOnDayTop;
                vertical = !e.Item.IsOnDayTop && e.Calendar.DaysMode == CalendarDaysMode.EXPANDED;

                if (horizontal)
                {
                    r1.X = e.Bounds.Left - 2;
                    r2.X = e.Bounds.Right - r1.Width + 2;
                    r1.Y = e.Bounds.Top + (e.Bounds.Height - r1.Height) / 2;
                    r2.Y = r1.Y;
                }

                if (vertical)
                {
                    r1.Y = e.Bounds.Top - 2;
                    r2.Y = e.Bounds.Bottom - r1.Height + 2;
                    r1.X = e.Bounds.Left + (e.Bounds.Width - r1.Width) / 2;
                    r2.X = r1.X;
                }

                if ((horizontal || vertical) && Calendar.AllowItemResize)
                {
                    if (!e.Item.IsOpenStart && e.IsFirst)
                    {
                        e.Graphics.FillRectangle(Brushes.White, r1);
                        e.Graphics.DrawRectangle(Pens.Black, r1);
                    }

                    if (!e.Item.IsOpenEnd && e.IsLast)
                    {
                        e.Graphics.FillRectangle(Brushes.White, r2);
                        e.Graphics.DrawRectangle(Pens.Black, r2);
                    }
                }
            }
        }

        #endregion
    }
}