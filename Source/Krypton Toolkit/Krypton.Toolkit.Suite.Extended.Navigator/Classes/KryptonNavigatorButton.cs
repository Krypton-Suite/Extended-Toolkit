#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    [ToolboxBitmap(typeof(KryptonButton)), ToolboxItem(false)]
    public class KryptonNavigatorButton : KryptonButton
    {

        private static PaletteBase? _palette;
        private static PaletteRedirect _paletteRedirect;

        public KryptonNavigatorButton()
        {

            // add Palette Handler
            if (_palette != null)
            {
                _palette.PalettePaint += OnPalettePaint;
            }

            KryptonManager.GlobalPaletteChanged += GlobalPaletteChanged;

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            AutoSize = false;
            Values.ExtraText = null;
            Values.Text = null;
            Values.Image = null;
            Values.ImageStates.ImageCheckedNormal = null;
            Values.ImageStates.ImageCheckedPressed = null;
            Values.ImageStates.ImageCheckedTracking = null;

            ButtonStyle = ButtonStyle.Standalone;
            if (_palette != null)
            {
                StateNormal.Back.Color1 = _palette.ColorTable.ToolStripContentPanelGradientEnd;
                StateNormal.Back.Color2 = _palette.ColorTable.ToolStripContentPanelGradientEnd;
                StateNormal.Back.ColorStyle = PaletteColorStyle.Solid;

                StateNormal.Border.Color1 = _palette.ColorTable.ToolStripBorder;
                StateCommon.Border.Rounding = 0;
                Size = new Size(23, 23);
                StateCommon.Content.ShortText.Color1 = _palette.ColorTable.StatusStripText;
            }

            StateCommon.Content.ShortText.TextH = PaletteRelativeAlign.Center;
            StateCommon.Content.ShortText.TextV = PaletteRelativeAlign.Center;
            StateCommon.Content.ShortText.Font = new Font("Marlett", 11.00f, FontStyle.Regular, GraphicsUnit.Point, 2);
        }
        #region ...Krypton...
        private new void GlobalPaletteChanged(object? sender, EventArgs e)
        {

            if (_palette != null)
            {
                _palette.PalettePaint -= OnPalettePaint;
            }


            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;


            if (_palette != null)
            {
                _palette.PalettePaint += OnPalettePaint;
                //repaint with new values
                StateNormal.Back.Color1 = _palette.ColorTable.ToolStripContentPanelGradientEnd;
                StateNormal.Back.Color2 = _palette.ColorTable.ToolStripContentPanelGradientEnd;

                StateNormal.Border.Color1 = _palette.ColorTable.ToolStripBorder;
                StateCommon.Content.ShortText.Color1 = _palette.ColorTable.StatusStripText;
            }

            Invalidate();
        }
        private void OnPalettePaint(object? sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

                if (_palette != null)
                {
                    _palette.PalettePaint -= OnPalettePaint;
                    _palette = null;
                }


                KryptonManager.GlobalPaletteChanged -= OnGlobalPaletteChanged;
            }

            base.Dispose(disposing);
        }
        #endregion
    }
}