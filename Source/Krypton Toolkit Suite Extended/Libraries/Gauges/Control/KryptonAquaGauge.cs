using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Gauges
{
    [ToolboxBitmap(typeof(Timer))]
    public class KryptonAquaGauge : AquaGauge
    {
        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;

        #region ... Constructor ...
        public KryptonAquaGauge()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
            // add Palette Handler
            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            InitColours();


        }
        #endregion

        private void InitColours()
        {
            DialColour = _palette.ColorTable.ToolStripGradientBegin;
            ForeColor = _palette.ColorTable.StatusStripText;
            DigitColour = _palette.ColorTable.StatusStripText;
            /*
            ThickCalibrationColor = _palette.ColorTable.StatusStripGradientEnd;
            ThinCalibrationColor = _palette.ColorTable.ToolStripGradientEnd;
            HandColor = _palette.ColorTable.MenuStripGradientEnd;
            CenterPointColor = _palette.ColorTable.MenuStripGradientEnd;
            */
        }


        #region ... Krypton ...

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

                InitColours();

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