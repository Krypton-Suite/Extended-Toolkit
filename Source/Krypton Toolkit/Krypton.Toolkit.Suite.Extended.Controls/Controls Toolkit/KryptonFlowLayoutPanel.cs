#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    [ToolboxBitmap(typeof(FlowLayoutPanel)), Obsolete("Please use the FlowLayoutPanel as provided in Krypton.Toolkit.")]
    public class KryptonFlowLayoutPanel : FlowLayoutPanel
    {
        #region Variables
        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;
        private PaletteBackInheritRedirect _paletteBack;
        private PaletteBorderInheritRedirect _paletteBorder;
        private PaletteContentInheritRedirect _paletteContent;
        #endregion

        #region Constructor
        public KryptonFlowLayoutPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            _palette = KryptonManager.CurrentGlobalPalette;

            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);


            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);

            _paletteRedirect = new PaletteRedirect(_palette);
            _paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);
            _paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);
            _paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);
        }
        #endregion

        #region Protected
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        #endregion

        #region Event Handlers
        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {

            if (_palette != null)
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);


            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;


            if (_palette != null)
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

                BackColor = _palette.ColorTable.ToolStripGradientBegin;
            }

            Invalidate();
        }

        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }
        #endregion
    }
}