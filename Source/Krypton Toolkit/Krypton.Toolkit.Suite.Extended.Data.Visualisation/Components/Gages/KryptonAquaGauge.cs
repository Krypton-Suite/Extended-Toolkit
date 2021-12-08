#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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
            this.DialColor = _palette.ColorTable.ToolStripGradientBegin;
            this.ForeColor = _palette.ColorTable.StatusStripText;
            this.DigitColor = _palette.ColorTable.StatusStripText;
            /*
            this.ThickCalibrationColor = _palette.ColorTable.StatusStripGradientEnd;
            this.ThinCalibrationColor = _palette.ColorTable.ToolStripGradientEnd;
            this.HandColor = _palette.ColorTable.MenuStripGradientEnd;
            this.CenterPointColor = _palette.ColorTable.MenuStripGradientEnd;
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