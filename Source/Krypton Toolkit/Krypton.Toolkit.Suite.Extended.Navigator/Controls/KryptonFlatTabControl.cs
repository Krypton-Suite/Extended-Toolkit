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
    [ToolboxBitmap(typeof(System.Windows.Forms.TabControl))]
    public partial class KryptonFlatTabControl : FlatTabControl
    {
        #region Designer Code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

        }

        #endregion

        #endregion

        private PaletteBase? _palette;
        private PaletteRedirect _paletteRedirect;

        public KryptonFlatTabControl()
        {
            InitializeComponent();
            // add Palette Handler
            if (_palette != null)
            {
                _palette.PalettePaint += OnPalettePaint;
            }

            KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            InitColours();
        }

        public KryptonFlatTabControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            // add Palette Handler
            if (_palette != null)
            {
                _palette.PalettePaint += OnPalettePaint;
            }

            KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            InitColours();

        }

        #region ... Krypton ...
        //Krypton Palette Events
        private void OnGlobalPaletteChanged(object sender, EventArgs e)
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
                {
                    InitColours();
                }
            }

            Invalidate();
        }

        //Krypton Palette Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }

        private void InitColours()
        {
            HotTrack = true;

            if (_palette != null)
            {
                StandardBackColour = _palette.ColorTable.ToolStripContentPanelGradientEnd;
                BorderColour = _palette.ColorTable.ToolStripBorder;

                ButtonsBackColour = _palette.ColorTable.ToolStripContentPanelGradientEnd;
                ButtonsBorderColour = _palette.ColorTable.ToolStripBorder;

                TabColourHotDark = _palette.ColorTable.MenuItemSelectedGradientBegin;
                TabColourHotLight = _palette.ColorTable.MenuItemSelectedGradientBegin;

                TabColourSelectedDark = _palette.ColorTable.ButtonPressedGradientEnd;
                TabColourSelectedLight = _palette.ColorTable.ButtonPressedGradientMiddle;

                TabForeColour = _palette.ColorTable.MenuItemText;
                TabHotForeColour = _palette.ColorTable.MenuItemText;

                TabColourDefaultDark = _palette.ColorTable.ToolStripGradientBegin;
                TabColourDefaultLight = _palette.ColorTable.ToolStripGradientBegin;
            }

            Invalidate();

        }

        #endregion
    }
}