using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    [ToolboxBitmap(typeof(Timer))]
    public class KryptonAquaGauge : AquaGauge
    {
        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;

        #region ... Constructor ...
        public KryptonAquaGauge()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            UpdateStyles();
            // add Palette Handler
            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            InitColors();


        }
        #endregion

        private void InitColors()
        {
            DialColour = _palette.ColorTable.ToolStripGradientBegin;

            ForeColor = _palette.ColorTable.StatusStripText;

            DigitColour = _palette.ColorTable.StatusStripText;
            /*
            this.ThickCalibrationColor = _palette.ColorTable.StatusStripGradientEnd;
            this.ThinCalibrationColor = _palette.ColorTable.ToolStripGradientEnd;
            this.HandColor = _palette.ColorTable.MenuStripGradientEnd;
            this.CenterPointColor = _palette.ColorTable.MenuStripGradientEnd;
            */
        }


        #region Krypton

        //Kripton Palette Events
        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (_palette != null)
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;

            if (_palette != null)
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                //repaint with new values

                InitColors();

            }

            Invalidate();
        }

        //Kripton Palette Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }
        #endregion

    }
}