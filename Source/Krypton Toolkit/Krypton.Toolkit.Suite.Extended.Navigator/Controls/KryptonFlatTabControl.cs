#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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

        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;

        public KryptonFlatTabControl()
        {
            InitializeComponent();
            // add Palette Handler
            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);

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
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            InitColours();

        }

        #region ... Krypton ...
        //Krypton Palette Events
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
            this.HotTrack = true;

            this.StandardBackColour = _palette.ColorTable.ToolStripContentPanelGradientEnd;
            this.BorderColour = _palette.ColorTable.ToolStripBorder;

            this.ButtonsBackColour = _palette.ColorTable.ToolStripContentPanelGradientEnd;
            this.ButtonsBorderColour = _palette.ColorTable.ToolStripBorder;

            this.TabColourHotDark = _palette.ColorTable.MenuItemSelectedGradientBegin;
            this.TabColourHotLight = _palette.ColorTable.MenuItemSelectedGradientBegin;

            this.TabColourSelectedDark = _palette.ColorTable.ButtonPressedGradientEnd;
            this.TabColourSelectedLight = _palette.ColorTable.ButtonPressedGradientMiddle;

            this.TabForeColour = _palette.ColorTable.MenuItemText;
            this.TabHotForeColour = _palette.ColorTable.MenuItemText;

            this.TabColourDefaultDark = _palette.ColorTable.ToolStripGradientBegin;
            this.TabColourDefaultLight = _palette.ColorTable.ToolStripGradientBegin;

            Invalidate();

        }

        #endregion
    }
}