#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    [System.Drawing.ToolboxBitmap(typeof(KryptonButton)), ToolboxItem(false)]
    public class KryptonNavigatorButton : KryptonButton
    {

        private static IPalette _palette;
        private static PaletteRedirect _paletteRedirect;

        public KryptonNavigatorButton()
        {

            // add Palette Handler
            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            KryptonManager.GlobalPaletteChanged += new EventHandler(GlobalPaletteChanged);

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            this.AutoSize = false;
            this.Values.ExtraText = null;
            this.Values.Text = null;
            this.Values.Image = null;
            this.Values.ImageStates.ImageCheckedNormal = null;
            this.Values.ImageStates.ImageCheckedPressed = null;
            this.Values.ImageStates.ImageCheckedTracking = null;

            this.ButtonStyle = ButtonStyle.Standalone;
            this.StateNormal.Back.Color1 = _palette.ColorTable.ToolStripContentPanelGradientEnd;
            this.StateNormal.Back.Color2 = _palette.ColorTable.ToolStripContentPanelGradientEnd;
            this.StateNormal.Back.ColorStyle = PaletteColorStyle.Solid;

            this.StateNormal.Border.Color1 = _palette.ColorTable.ToolStripBorder;
            this.StateCommon.Border.Rounding = 0;
            this.Size = new System.Drawing.Size(23, 23);
            this.StateCommon.Content.ShortText.Color1 = _palette.ColorTable.StatusStripText;
            this.StateCommon.Content.ShortText.TextH = PaletteRelativeAlign.Center;
            this.StateCommon.Content.ShortText.TextV = PaletteRelativeAlign.Center;
            this.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Marlett", 11.00f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)2);
        }
        #region ...Krypton...
        private void GlobalPaletteChanged(object sender, EventArgs e)
        {

            if (_palette != null)
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);


            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;


            if (_palette != null)
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                //repaint with new values
                this.StateNormal.Back.Color1 = _palette.ColorTable.ToolStripContentPanelGradientEnd;
                this.StateNormal.Back.Color2 = _palette.ColorTable.ToolStripContentPanelGradientEnd;

                this.StateNormal.Border.Color1 = _palette.ColorTable.ToolStripBorder;
                this.StateCommon.Content.ShortText.Color1 = _palette.ColorTable.StatusStripText;
            }

            Invalidate();
        }
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

                if (_palette != null)
                {
                    _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                    _palette = null;
                }


                KryptonManager.GlobalPaletteChanged -= new EventHandler(OnGlobalPaletteChanged);
            }

            base.Dispose(disposing);
        }
        #endregion
    }
}