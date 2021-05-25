#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    [ToolboxBitmap(typeof(MonthCalendar))]
    public class KryptonCalendar : CalendarControl
    {
        //Palette State
        private KryptonManager k_manager = new KryptonManager();
        private PaletteBackInheritRedirect m_paletteBack;
        private PaletteBorderInheritRedirect m_paletteBorder;
        private PaletteContentInheritRedirect m_paletteContent;
        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;

        private ColourTable _colourTable = new ColourTable();


        public KryptonCalendar()
        {
            //To remove flicker we use double buffering for drawing
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);

            //Create redirection object to the base palette
            if (((this._palette != null)))
            {
                this._palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(this.OnPalettePaint);
            }
            KryptonManager.GlobalPaletteChanged += new EventHandler(this.OnGlobalPaletteChanged);
            this._palette = KryptonManager.CurrentGlobalPalette;
            this._paletteRedirect = new PaletteRedirect(this._palette);

            //Create accessor objects for the back, border and content
            m_paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);
            m_paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);
            m_paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

            _colourTable = KryptonCalendar.ct;

            this.InitColours();

        }

        //Krypton Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            base.Invalidate();
        }

        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (((this._palette != null)))
            {
                this._palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(this.OnPalettePaint);
            }
            this._palette = KryptonManager.CurrentGlobalPalette;
            this._paletteRedirect.Target = this._palette;
            if (((this._palette != null)))
            {
                this._palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(this.OnPalettePaint);
                this.InitColours();
            }
            base.Invalidate();

        }

        private void InitColours()
        {
            //Colors
            _colourTable.BorderColour = _palette.ColorTable.ToolStripBorder;
            _colourTable.BorderBrush = new SolidBrush(_colourTable.BorderColour);

            _colourTable.FontStd = _palette.ColorTable.MenuStripFont;

            _colourTable.SeparatorDark = _palette.ColorTable.SeparatorDark;

            _colourTable.ForeColour = _palette.ColorTable.MenuStripText;
            _colourTable.ForeBrush = new SolidBrush(_colourTable.ForeColour);

            _colourTable.HeaderText = _palette.ColorTable.MenuStripText;
            _colourTable.HeaderBrush = new SolidBrush(_colourTable.HeaderText);

            _colourTable.HeaderLight = m_paletteBack.GetBackColor1(PaletteState.CheckedNormal);
            _colourTable.HeaderDark = m_paletteBack.GetBackColor2(PaletteState.CheckedNormal);

            _colourTable.SelectedForeColour = _palette.ColorTable.MenuItemText;

            _colourTable.SelectionColour = m_paletteBack.GetBackColor1(PaletteState.CheckedTracking);
            _colourTable.SelectedBackColour = m_paletteBack.GetBackColor1(PaletteState.Tracking);

            _colourTable.HalfHourEndingColour = _palette.ColorTable.GripDark;
            _colourTable.HourEndingColour = _palette.ColorTable.ToolStripGradientMiddle;

            _colourTable.BackColour = _palette.ColorTable.ToolStripContentPanelGradientBegin;

            _colourTable.CurrentMonth = _palette.ColorTable.SeparatorLight;
            _colourTable.DayBackColour = _palette.ColorTable.SeparatorLight;

            _colourTable.TodayGradient = m_paletteBack.GetBackColor1(PaletteState.Pressed);
            _colourTable.TodayGradientBrush = new SolidBrush(_colourTable.TodayGradient);

            _colourTable.WorkingColour = _palette.ColorTable.SeparatorLight;

            _colourTable.NonWorkingColour = _palette.ColorTable.StatusStripGradientBegin;
            _colourTable.NewMonth = _palette.ColorTable.StatusStripGradientBegin;


            this.ColumnHeadersDefaultCellStyle.BackColor = _palette.ColorTable.MenuStripGradientBegin;
            this.ColumnHeadersDefaultCellStyle.ForeColor = _palette.ColorTable.MenuStripText;
            this.ColumnHeadersDefaultCellStyle.Font = _colourTable.FontStd;
            this.GridColor = _colourTable.SeparatorDark;
            this.BackgroundColor = _colourTable.BackColour;
        }


    }



}