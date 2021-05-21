using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Calendar.Library
{
    [System.Drawing.ToolboxBitmapAttribute(typeof(System.Windows.Forms.MonthCalendar))]
    public class KryptonCalendar : Calendar
    {
        //Palette State
        private KryptonManager k_manager = new KryptonManager();
        private PaletteBackInheritRedirect m_paletteBack;
        private PaletteBorderInheritRedirect m_paletteBorder;
        private PaletteContentInheritRedirect m_paletteContent;
        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;

        private Library.ColourTable ColorTable = new Library.ColourTable();


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

            ColorTable = KryptonCalendar.ct;

            this.InitColors();

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
                this.InitColors();
            }
            base.Invalidate();

        }

        private void InitColors()
        {
            //Colors
            ColorTable.BorderColor = _palette.ColorTable.ToolStripBorder;
            ColorTable.BorderBrush = new SolidBrush(ColorTable.BorderColor);

            ColorTable.FontStd = _palette.ColorTable.MenuStripFont;

            ColorTable.SeparatorDark = _palette.ColorTable.SeparatorDark;

            ColorTable.ForeColor = _palette.ColorTable.MenuStripText;
            ColorTable.ForeBrush = new SolidBrush(ColorTable.ForeColor);

            ColorTable.HeaderText = _palette.ColorTable.MenuStripText;
            ColorTable.HeaderBrush = new SolidBrush(ColorTable.HeaderText);

            ColorTable.HeaderLight = m_paletteBack.GetBackColor1(PaletteState.CheckedNormal);
            ColorTable.HeaderDark = m_paletteBack.GetBackColor2(PaletteState.CheckedNormal);

            ColorTable.SelectedForeColor = _palette.ColorTable.MenuItemText;

            ColorTable.SelectionColor = m_paletteBack.GetBackColor1(PaletteState.CheckedTracking);
            ColorTable.SelectedBackColor = m_paletteBack.GetBackColor1(PaletteState.Tracking);

            ColorTable.HalfHourEndingColor = _palette.ColorTable.GripDark;
            ColorTable.HourEndingColor = _palette.ColorTable.ToolStripGradientMiddle;

            ColorTable.BackColor = _palette.ColorTable.ToolStripContentPanelGradientBegin;

            ColorTable.CurrentMonth = _palette.ColorTable.SeparatorLight;
            ColorTable.DayBackColor = _palette.ColorTable.SeparatorLight;

            ColorTable.TodayGradient = m_paletteBack.GetBackColor1(PaletteState.Pressed);
            ColorTable.TodayGradientBrush = new SolidBrush(ColorTable.TodayGradient);

            ColorTable.WorkingColor = _palette.ColorTable.SeparatorLight;

            ColorTable.NonWorkingColor = _palette.ColorTable.StatusStripGradientBegin;
            ColorTable.NewMonth = _palette.ColorTable.StatusStripGradientBegin;


            this.ColumnHeadersDefaultCellStyle.BackColor = _palette.ColorTable.MenuStripGradientBegin;
            this.ColumnHeadersDefaultCellStyle.ForeColor = _palette.ColorTable.MenuStripText;
            this.ColumnHeadersDefaultCellStyle.Font = ColorTable.FontStd;
            this.GridColor = ColorTable.SeparatorDark;
            this.BackgroundColor = ColorTable.BackColor;
        }


    }



}
