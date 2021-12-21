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
    public class CalendarKryptonRenderer : CalendarSystemRenderer
    {
        #region "Fields"

        public Color HeaderA = Color.Blue;
        public Color HeaderB = Color.Blue;
        public float HeaderBackColourAngle;
        //  Public HeaderD As Color = Color.Blue

        public Color TodayA = Color.Yellow;
        public Color TodayB = Color.Yellow;
        //  Public TodayC As Color = Color.Yellow
        //  Public TodayD As Color = Color.Yellow
        #endregion

        #region "Krypton Members"
        private IPalette _palette;
        //private PaletteRedirect _paletteRedirect;
        #endregion

        #region "Ctor"

        public CalendarKryptonRenderer(KryptonCalendar c)
            : base(c)
        {

            ReloadPalette();
        }

        public override void ReloadPalette()
        {
            base.ReloadPalette();
            _palette = KryptonManager.CurrentGlobalPalette;


            if (_palette != null)
            {
                HeaderA = _palette.GetBackColor2(PaletteBackStyle.HeaderForm, PaletteState.Normal);
                HeaderB = _palette.GetBackColor1(PaletteBackStyle.HeaderForm, PaletteState.Normal);
                TodayA = _palette.GetBackColor1(PaletteBackStyle.ButtonStandalone, PaletteState.CheckedNormal);
                TodayB = _palette.GetBackColor2(PaletteBackStyle.ButtonStandalone, PaletteState.CheckedNormal);
                HeaderBackColourAngle = _palette.GetBackColorAngle(PaletteBackStyle.ButtonStandalone, PaletteState.Normal);

                ColourTable.Background = _palette.GetBackColor1(PaletteBackStyle.PanelClient, PaletteState.Normal);
                ColourTable.DayBackgroundOdd = _palette.GetBackColor1(PaletteBackStyle.TabOneNote, PaletteState.Normal);
                ColourTable.DayBackgroundEven = _palette.GetBackColor1(PaletteBackStyle.PanelClient, PaletteState.Disabled);

                ColourTable.DayBackgroundSelected = _palette.GetBackColor1(PaletteBackStyle.ButtonStandalone, PaletteState.Tracking);
                ColourTable.DayBorder = _palette.GetBorderColor1(PaletteBorderStyle.GridDataCellSheet, PaletteState.Normal);

                ColourTable.DayHeaderBackground = _palette.GetBackColor1(PaletteBackStyle.ButtonStandalone, PaletteState.Normal);

                ColourTable.DayHeaderText = _palette.GetContentShortTextColor2(PaletteContentStyle.HeaderForm, PaletteState.Normal);

                ColourTable.DayHeaderSecondaryText = _palette.GetContentShortTextColor1(PaletteContentStyle.ButtonStandalone, PaletteState.Normal);
                ColourTable.DayTopBorder = ColourTable.DayBorder;

                ColourTable.DayTopSelectedBorder = _palette.GetBorderColor1(PaletteBorderStyle.ButtonStandalone, PaletteState.CheckedPressed);

                ColourTable.DayTopBackground = _palette.GetBackColor1(PaletteBackStyle.InputControlStandalone, PaletteState.Normal);
                ColourTable.DayTopSelectedBackground = _palette.GetBackColor2(PaletteBackStyle.InputControlStandalone, PaletteState.Tracking);

                ColourTable.ItemBorder = _palette.GetBorderColor2(PaletteBorderStyle.InputControlStandalone, PaletteState.Normal);
                ColourTable.ItemBackground = _palette.GetBackColor2(PaletteBackStyle.InputControlStandalone, PaletteState.Normal);
                ColourTable.ItemText = _palette.GetContentShortTextColor1(PaletteContentStyle.InputControlStandalone, PaletteState.Normal);
                ColourTable.ItemShadow = Color.LightGray;

                ColourTable.ItemSecondaryText = Color.Red;
                //palette.GetContentShortTextColor1(PaletteBackStyle.InputControlRibbon, PaletteState.Normal)
                ColourTable.ItemSelectedBorder = _palette.GetBorderColor1(PaletteBorderStyle.InputControlRibbon, PaletteState.Tracking);
                ColourTable.ItemSelectedBackground = _palette.GetBackColor1(PaletteBackStyle.InputControlRibbon, PaletteState.Tracking);

                ColourTable.ItemSelectedText = _palette.GetContentShortTextColor1(PaletteContentStyle.InputControlRibbon, PaletteState.Normal);

                ColourTable.WeekHeaderBackground = Color.Transparent;
                //palette.GetBorderColor1(PaletteBackStyle.InputControlRibbon, PaletteState.Pressed)
                ColourTable.WeekHeaderBorder = Color.Transparent;
                //palette.GetBackColor1(PaletteBackStyle.InputControlRibbon, PaletteState.Normal)
                ColourTable.WeekHeaderText = _palette.GetContentShortTextColor1(PaletteContentStyle.HeaderForm, PaletteState.Normal);
                ColourTable.WeekDayName = _palette.GetContentShortTextColor1(PaletteContentStyle.HeaderForm, PaletteState.Normal);

                ColourTable.TodayBorder = _palette.GetBorderColor1(PaletteBorderStyle.ButtonStandalone, PaletteState.CheckedTracking);

                //ColourTable.TodayTopBackground = Color.Red

                ColourTable.TimeScaleLine = _palette.GetBorderColor1(PaletteBorderStyle.HeaderPrimary, PaletteState.Normal);
                ColourTable.TimeScaleHours = _palette.GetContentShortTextColor1(PaletteContentStyle.HeaderPrimary, PaletteState.Normal);
                //palette.GetBorderColor2(PaletteBorderStyle.GridDataCellSheet, PaletteState.Normal)
                ColourTable.TimeScaleMinutes = _palette.GetContentShortTextColor1(PaletteContentStyle.HeaderPrimary, PaletteState.Normal);

                ColourTable.TimeUnitBackground = _palette.GetBackColor1(PaletteBackStyle.InputControlStandalone, PaletteState.Disabled);
                ColourTable.TimeUnitHighlightedBackground = _palette.GetBackColor1(PaletteBackStyle.InputControlStandalone, PaletteState.Normal);
                ColourTable.TimeUnitSelectedBackground = _palette.GetBackColor1(PaletteBackStyle.ButtonButtonSpec, PaletteState.Tracking);

                ColourTable.TimeUnitBorderLight = _palette.GetBorderColor2(PaletteBorderStyle.GridDataCellSheet, PaletteState.Normal);
                ColourTable.TimeUnitBorderDark = _palette.GetBorderColor1(PaletteBorderStyle.HeaderPrimary, PaletteState.Normal);


                ItemRoundness = _palette.GetBorderRounding(PaletteBorderStyle.ButtonStandalone, PaletteState.Normal);
            }
        }

        #endregion

        #region "Private Method"

        public void GlossyRect(Graphics g, Rectangle bounds, Color a, Color b, float backColorAngle)
        {
            using (LinearGradientBrush backBrush = new LinearGradientBrush(bounds, a, b, HeaderBackColourAngle))
            {
                g.FillRectangle(backBrush, bounds);
            }
        }

        ///' <summary>
        ///' Shortcut to one on CalendarColourTable
        ///' </summary>
        ///' <param name="color"></param>
        ///' <returns></returns>
        //Private Shared Function FromHex(ByVal color As String) As Color
        //    Return CalendarColourTable.FromHex(color)
        //End Function

        #endregion

        #region "Overrides"

        public override void OnInitialize(CalendarRendererEventArgs e)
        {
            if (_palette != null)
                e.Calendar.Font = _palette.GetContentShortTextFont(PaletteContentStyle.InputControlStandalone, PaletteState.Normal);
            base.OnInitialize(e);
        }

        public override void OnDrawDayHeaderBackground(CalendarRendererDayEventArgs e)
        {
            Rectangle r = e.Day.HeaderBounds;

            if (e.Day.Date == DateTime.Today)
            {
                GlossyRect(e.Graphics, e.Day.HeaderBounds, TodayA, TodayB, HeaderBackColourAngle);
            }
            else
            {
                GlossyRect(e.Graphics, e.Day.HeaderBounds, HeaderA, HeaderB, HeaderBackColourAngle);
            }

            if (e.Calendar.DaysMode == CalendarDaysMode.SHORT)
            {
                using (Pen p = new Pen(_palette.ColorTable.ButtonPressedBorder))
                {
                    e.Graphics.DrawLine(p, r.Left, r.Top, r.Right, r.Top);
                    e.Graphics.DrawLine(p, r.Left, r.Bottom, r.Right, r.Bottom);
                }
            }
        }

        public override void OnDrawItemBorder(CalendarRendererItemBoundsEventArgs e)
        {
            base.OnDrawItemBorder(e);

            using (Pen p = new Pen(_palette.ColorTable.MenuItemSelectedGradientBegin))
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
                        e.Graphics.DrawRectangle(Pens.Red, r1);
                    }

                    if (!e.Item.IsOpenEnd && e.IsLast)
                    {
                        e.Graphics.FillRectangle(Brushes.White, r2);
                        e.Graphics.DrawRectangle(Pens.Red, r2);
                    }
                }
            }
        }

        public override void OnDrawDayHeaderText(CalendarRendererBoxEventArgs e)
        {
            if (_palette != null)
                e.TextColour = _palette.GetContentShortTextColor1(PaletteContentStyle.HeaderForm, PaletteState.Normal);
            base.OnDrawDayHeaderText(e);
        }


        #endregion
    }
}