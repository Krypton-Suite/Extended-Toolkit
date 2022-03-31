#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    public class ColourEditorUserControl : UserControl, IColourEditor
    {
        #region Designer Code
        private RGBAColourSliderControl rColourBar;
        private RGBAColourSliderControl gColourBar;
        private RGBAColourSliderControl bColourBar;
        private HueColourSliderControl hColourBar;
        private SaturationColourSliderControl sColourBar;
        private LightnessColourSliderControl lColourBar;
        private RGBAColourSliderControl aColourBar;
        private KryptonRedValueNumericBox knudRed;
        private KryptonGreenValueNumericBox knudGreen;
        private KryptonBlueValueNumericBox knudBlue;
        private KryptonComboBox kcmbHex;
        private KryptonNumericUpDown knudHue;
        private KryptonNumericUpDown knudSaturation;
        private KryptonNumericUpDown knudLuminosity;
        private KryptonLabel klblRGB;
        private KryptonLabel klblBlue;
        private KryptonLabel klblGreen;
        private KryptonLabel klblRed;
        private KryptonLabel klblHex;
        private KryptonLabel klblHSL;
        private KryptonLabel klblHue;
        private KryptonLabel klblSaturation;
        private KryptonLabel klblLuminosity;
        private KryptonLabel klblAlpha;
        private Panel pnlRGB;
        private Panel pnlRed;
        private Panel pnlGreen;
        private Panel pnlBlue;
        private Panel pnlHexadecimal;
        private Panel pnlHSL;
        private Panel pnlAlpha;
        private Panel pnlLuminosity;
        private Panel pnlSaturation;
        private Panel pnlHue;
        private Panel panel1;
        private Panel pnlHSLUI;
        private KryptonNumericUpDown knudAlpha;

        private void InitializeComponent()
        {
            this.kcmbHex = new Krypton.Toolkit.KryptonComboBox();
            this.knudHue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudSaturation = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudLuminosity = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudAlpha = new Krypton.Toolkit.KryptonNumericUpDown();
            this.klblRGB = new Krypton.Toolkit.KryptonLabel();
            this.klblBlue = new Krypton.Toolkit.KryptonLabel();
            this.klblGreen = new Krypton.Toolkit.KryptonLabel();
            this.klblRed = new Krypton.Toolkit.KryptonLabel();
            this.klblHex = new Krypton.Toolkit.KryptonLabel();
            this.klblHSL = new Krypton.Toolkit.KryptonLabel();
            this.klblHue = new Krypton.Toolkit.KryptonLabel();
            this.klblSaturation = new Krypton.Toolkit.KryptonLabel();
            this.klblLuminosity = new Krypton.Toolkit.KryptonLabel();
            this.klblAlpha = new Krypton.Toolkit.KryptonLabel();
            this.pnlRGB = new System.Windows.Forms.Panel();
            this.pnlRed = new System.Windows.Forms.Panel();
            this.rColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.RGBAColourSliderControl();
            this.knudRed = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonRedValueNumericBox();
            this.pnlGreen = new System.Windows.Forms.Panel();
            this.gColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.RGBAColourSliderControl();
            this.knudGreen = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonGreenValueNumericBox();
            this.pnlBlue = new System.Windows.Forms.Panel();
            this.bColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.RGBAColourSliderControl();
            this.knudBlue = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.KryptonBlueValueNumericBox();
            this.pnlHexadecimal = new System.Windows.Forms.Panel();
            this.pnlHSL = new System.Windows.Forms.Panel();
            this.pnlAlpha = new System.Windows.Forms.Panel();
            this.aColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.RGBAColourSliderControl();
            this.pnlLuminosity = new System.Windows.Forms.Panel();
            this.lColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.LightnessColourSliderControl();
            this.pnlSaturation = new System.Windows.Forms.Panel();
            this.sColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.SaturationColourSliderControl();
            this.pnlHue = new System.Windows.Forms.Panel();
            this.hColourBar = new Krypton.Toolkit.Suite.Extended.Drawing.Utilities.HueColourSliderControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlHSLUI = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbHex)).BeginInit();
            this.pnlRGB.SuspendLayout();
            this.pnlRed.SuspendLayout();
            this.pnlGreen.SuspendLayout();
            this.pnlBlue.SuspendLayout();
            this.pnlHexadecimal.SuspendLayout();
            this.pnlHSL.SuspendLayout();
            this.pnlAlpha.SuspendLayout();
            this.pnlLuminosity.SuspendLayout();
            this.pnlSaturation.SuspendLayout();
            this.pnlHue.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlHSLUI.SuspendLayout();
            this.SuspendLayout();
            // 
            // kcmbHex
            // 
            this.kcmbHex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kcmbHex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbHex.DropDownWidth = 58;
            this.kcmbHex.IntegralHeight = false;
            this.kcmbHex.Location = new System.Drawing.Point(54, 0);
            this.kcmbHex.Name = "kcmbHex";
            this.kcmbHex.Size = new System.Drawing.Size(204, 27);
            this.kcmbHex.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbHex.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbHex.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbHex.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbHex.TabIndex = 29;
            this.kcmbHex.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.kcmbHex_DrawItem);
            this.kcmbHex.DropDown += new System.EventHandler(this.kcmbHex_DropDown);
            this.kcmbHex.SelectedIndexChanged += new System.EventHandler(this.kcmbHex_SelectedIndexChanged);
            this.kcmbHex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kcmbHex_KeyDown);
            // 
            // knudHue
            // 
            this.knudHue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudHue.Location = new System.Drawing.Point(200, 3);
            this.knudHue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudHue.Name = "knudHue";
            this.knudHue.Size = new System.Drawing.Size(58, 23);
            this.knudHue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudHue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudHue.TabIndex = 30;
            // 
            // knudSaturation
            // 
            this.knudSaturation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudSaturation.Location = new System.Drawing.Point(200, 3);
            this.knudSaturation.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudSaturation.Name = "knudSaturation";
            this.knudSaturation.Size = new System.Drawing.Size(58, 23);
            this.knudSaturation.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudSaturation.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudSaturation.TabIndex = 31;
            // 
            // knudLuminosity
            // 
            this.knudLuminosity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudLuminosity.Location = new System.Drawing.Point(200, 6);
            this.knudLuminosity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudLuminosity.Name = "knudLuminosity";
            this.knudLuminosity.Size = new System.Drawing.Size(58, 23);
            this.knudLuminosity.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudLuminosity.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudLuminosity.TabIndex = 32;
            // 
            // knudAlpha
            // 
            this.knudAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudAlpha.Location = new System.Drawing.Point(200, 3);
            this.knudAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudAlpha.Name = "knudAlpha";
            this.knudAlpha.Size = new System.Drawing.Size(58, 23);
            this.knudAlpha.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudAlpha.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudAlpha.TabIndex = 33;
            // 
            // klblRGB
            // 
            this.klblRGB.Dock = System.Windows.Forms.DockStyle.Left;
            this.klblRGB.Location = new System.Drawing.Point(0, 0);
            this.klblRGB.Name = "klblRGB";
            this.klblRGB.Size = new System.Drawing.Size(51, 27);
            this.klblRGB.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRGB.TabIndex = 34;
            this.klblRGB.Values.Text = "RGB:";
            // 
            // klblBlue
            // 
            this.klblBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblBlue.Location = new System.Drawing.Point(13, 6);
            this.klblBlue.Name = "klblBlue";
            this.klblBlue.Size = new System.Drawing.Size(27, 21);
            this.klblBlue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBlue.TabIndex = 35;
            this.klblBlue.Values.Text = "B:";
            // 
            // klblGreen
            // 
            this.klblGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblGreen.Location = new System.Drawing.Point(14, 5);
            this.klblGreen.Name = "klblGreen";
            this.klblGreen.Size = new System.Drawing.Size(28, 21);
            this.klblGreen.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblGreen.TabIndex = 36;
            this.klblGreen.Values.Text = "G:";
            // 
            // klblRed
            // 
            this.klblRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblRed.Location = new System.Drawing.Point(14, 6);
            this.klblRed.Name = "klblRed";
            this.klblRed.Size = new System.Drawing.Size(28, 21);
            this.klblRed.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblRed.TabIndex = 37;
            this.klblRed.Values.Text = "R:";
            // 
            // klblHex
            // 
            this.klblHex.Dock = System.Windows.Forms.DockStyle.Left;
            this.klblHex.Location = new System.Drawing.Point(0, 0);
            this.klblHex.Name = "klblHex";
            this.klblHex.Size = new System.Drawing.Size(45, 27);
            this.klblHex.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHex.TabIndex = 38;
            this.klblHex.Values.Text = "Hex:";
            // 
            // klblHSL
            // 
            this.klblHSL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblHSL.Location = new System.Drawing.Point(4, 6);
            this.klblHSL.Name = "klblHSL";
            this.klblHSL.Size = new System.Drawing.Size(47, 21);
            this.klblHSL.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHSL.TabIndex = 39;
            this.klblHSL.Values.Text = "HSL:";
            // 
            // klblHue
            // 
            this.klblHue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblHue.Location = new System.Drawing.Point(13, 5);
            this.klblHue.Name = "klblHue";
            this.klblHue.Size = new System.Drawing.Size(28, 21);
            this.klblHue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHue.TabIndex = 40;
            this.klblHue.Values.Text = "H:";
            // 
            // klblSaturation
            // 
            this.klblSaturation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblSaturation.Location = new System.Drawing.Point(13, 5);
            this.klblSaturation.Name = "klblSaturation";
            this.klblSaturation.Size = new System.Drawing.Size(27, 21);
            this.klblSaturation.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblSaturation.TabIndex = 41;
            this.klblSaturation.Values.Text = "S:";
            // 
            // klblLuminosity
            // 
            this.klblLuminosity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblLuminosity.Location = new System.Drawing.Point(14, 6);
            this.klblLuminosity.Name = "klblLuminosity";
            this.klblLuminosity.Size = new System.Drawing.Size(25, 21);
            this.klblLuminosity.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblLuminosity.TabIndex = 42;
            this.klblLuminosity.Values.Text = "L:";
            // 
            // klblAlpha
            // 
            this.klblAlpha.Dock = System.Windows.Forms.DockStyle.Left;
            this.klblAlpha.Location = new System.Drawing.Point(0, 0);
            this.klblAlpha.Name = "klblAlpha";
            this.klblAlpha.Size = new System.Drawing.Size(57, 27);
            this.klblAlpha.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblAlpha.TabIndex = 43;
            this.klblAlpha.Values.Text = "Alpha:";
            // 
            // pnlRGB
            // 
            this.pnlRGB.BackColor = System.Drawing.Color.Transparent;
            this.pnlRGB.Controls.Add(this.klblRGB);
            this.pnlRGB.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRGB.Location = new System.Drawing.Point(0, 0);
            this.pnlRGB.Name = "pnlRGB";
            this.pnlRGB.Size = new System.Drawing.Size(261, 27);
            this.pnlRGB.TabIndex = 44;
            // 
            // pnlRed
            // 
            this.pnlRed.BackColor = System.Drawing.Color.Transparent;
            this.pnlRed.Controls.Add(this.klblRed);
            this.pnlRed.Controls.Add(this.rColourBar);
            this.pnlRed.Controls.Add(this.knudRed);
            this.pnlRed.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRed.Location = new System.Drawing.Point(0, 27);
            this.pnlRed.Name = "pnlRed";
            this.pnlRed.Size = new System.Drawing.Size(261, 32);
            this.pnlRed.TabIndex = 35;
            // 
            // rColourBar
            // 
            this.rColourBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rColourBar.BackColor = System.Drawing.Color.Transparent;
            this.rColourBar.Location = new System.Drawing.Point(47, 6);
            this.rColourBar.Name = "rColourBar";
            this.rColourBar.Size = new System.Drawing.Size(147, 20);
            this.rColourBar.TabIndex = 17;
            // 
            // knudRed
            // 
            this.knudRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudRed.Location = new System.Drawing.Point(200, 3);
            this.knudRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudRed.Name = "knudRed";
            this.knudRed.Size = new System.Drawing.Size(58, 22);
            this.knudRed.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knudRed.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudRed.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudRed.TabIndex = 26;
            this.knudRed.Typeface = null;
            this.knudRed.UseAccessibleUI = false;
            // 
            // pnlGreen
            // 
            this.pnlGreen.Controls.Add(this.klblGreen);
            this.pnlGreen.Controls.Add(this.gColourBar);
            this.pnlGreen.Controls.Add(this.knudGreen);
            this.pnlGreen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGreen.Location = new System.Drawing.Point(0, 59);
            this.pnlGreen.Name = "pnlGreen";
            this.pnlGreen.Size = new System.Drawing.Size(261, 32);
            this.pnlGreen.TabIndex = 38;
            // 
            // gColourBar
            // 
            this.gColourBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gColourBar.BackColor = System.Drawing.Color.Transparent;
            this.gColourBar.Channel = Krypton.Toolkit.Suite.Extended.Drawing.Utilities.RGBAChannel.Green;
            this.gColourBar.Location = new System.Drawing.Point(47, 3);
            this.gColourBar.Name = "gColourBar";
            this.gColourBar.Size = new System.Drawing.Size(147, 27);
            this.gColourBar.TabIndex = 18;
            // 
            // knudGreen
            // 
            this.knudGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudGreen.Location = new System.Drawing.Point(200, 6);
            this.knudGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudGreen.Name = "knudGreen";
            this.knudGreen.Size = new System.Drawing.Size(58, 22);
            this.knudGreen.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.knudGreen.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudGreen.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudGreen.TabIndex = 27;
            this.knudGreen.Typeface = null;
            this.knudGreen.UseAccessibleUI = false;
            // 
            // pnlBlue
            // 
            this.pnlBlue.Controls.Add(this.klblBlue);
            this.pnlBlue.Controls.Add(this.bColourBar);
            this.pnlBlue.Controls.Add(this.knudBlue);
            this.pnlBlue.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBlue.Location = new System.Drawing.Point(0, 91);
            this.pnlBlue.Name = "pnlBlue";
            this.pnlBlue.Size = new System.Drawing.Size(261, 32);
            this.pnlBlue.TabIndex = 37;
            // 
            // bColourBar
            // 
            this.bColourBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bColourBar.BackColor = System.Drawing.Color.Transparent;
            this.bColourBar.Channel = Krypton.Toolkit.Suite.Extended.Drawing.Utilities.RGBAChannel.Blue;
            this.bColourBar.Location = new System.Drawing.Point(47, 3);
            this.bColourBar.Name = "bColourBar";
            this.bColourBar.Size = new System.Drawing.Size(148, 25);
            this.bColourBar.TabIndex = 19;
            // 
            // knudBlue
            // 
            this.knudBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudBlue.Location = new System.Drawing.Point(200, 6);
            this.knudBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBlue.Name = "knudBlue";
            this.knudBlue.Size = new System.Drawing.Size(58, 22);
            this.knudBlue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knudBlue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudBlue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBlue.TabIndex = 28;
            this.knudBlue.Typeface = null;
            this.knudBlue.UseAccessibleUI = false;
            // 
            // pnlHexadecimal
            // 
            this.pnlHexadecimal.BackColor = System.Drawing.Color.Transparent;
            this.pnlHexadecimal.Controls.Add(this.klblHex);
            this.pnlHexadecimal.Controls.Add(this.kcmbHex);
            this.pnlHexadecimal.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHexadecimal.Location = new System.Drawing.Point(0, 122);
            this.pnlHexadecimal.Name = "pnlHexadecimal";
            this.pnlHexadecimal.Size = new System.Drawing.Size(261, 27);
            this.pnlHexadecimal.TabIndex = 45;
            // 
            // pnlHSL
            // 
            this.pnlHSL.BackColor = System.Drawing.Color.Transparent;
            this.pnlHSL.Controls.Add(this.klblHSL);
            this.pnlHSL.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHSL.Location = new System.Drawing.Point(0, 0);
            this.pnlHSL.Name = "pnlHSL";
            this.pnlHSL.Size = new System.Drawing.Size(261, 50);
            this.pnlHSL.TabIndex = 39;
            // 
            // pnlAlpha
            // 
            this.pnlAlpha.Controls.Add(this.klblAlpha);
            this.pnlAlpha.Controls.Add(this.aColourBar);
            this.pnlAlpha.Controls.Add(this.knudAlpha);
            this.pnlAlpha.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlpha.Location = new System.Drawing.Point(0, 276);
            this.pnlAlpha.Name = "pnlAlpha";
            this.pnlAlpha.Size = new System.Drawing.Size(261, 27);
            this.pnlAlpha.TabIndex = 46;
            // 
            // aColourBar
            // 
            this.aColourBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aColourBar.BackColor = System.Drawing.Color.Transparent;
            this.aColourBar.Channel = Krypton.Toolkit.Suite.Extended.Drawing.Utilities.RGBAChannel.Alpha;
            this.aColourBar.Location = new System.Drawing.Point(65, 6);
            this.aColourBar.Name = "aColourBar";
            this.aColourBar.Size = new System.Drawing.Size(130, 20);
            this.aColourBar.TabIndex = 25;
            // 
            // pnlLuminosity
            // 
            this.pnlLuminosity.Controls.Add(this.klblLuminosity);
            this.pnlLuminosity.Controls.Add(this.lColourBar);
            this.pnlLuminosity.Controls.Add(this.knudLuminosity);
            this.pnlLuminosity.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLuminosity.Location = new System.Drawing.Point(0, 94);
            this.pnlLuminosity.Name = "pnlLuminosity";
            this.pnlLuminosity.Size = new System.Drawing.Size(261, 32);
            this.pnlLuminosity.TabIndex = 47;
            // 
            // lColourBar
            // 
            this.lColourBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lColourBar.BackColor = System.Drawing.Color.Transparent;
            this.lColourBar.Location = new System.Drawing.Point(45, 9);
            this.lColourBar.Name = "lColourBar";
            this.lColourBar.Size = new System.Drawing.Size(150, 20);
            this.lColourBar.TabIndex = 24;
            // 
            // pnlSaturation
            // 
            this.pnlSaturation.Controls.Add(this.klblSaturation);
            this.pnlSaturation.Controls.Add(this.sColourBar);
            this.pnlSaturation.Controls.Add(this.knudSaturation);
            this.pnlSaturation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSaturation.Location = new System.Drawing.Point(0, 62);
            this.pnlSaturation.Name = "pnlSaturation";
            this.pnlSaturation.Size = new System.Drawing.Size(261, 32);
            this.pnlSaturation.TabIndex = 43;
            // 
            // sColourBar
            // 
            this.sColourBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sColourBar.BackColor = System.Drawing.Color.Transparent;
            this.sColourBar.Location = new System.Drawing.Point(47, 5);
            this.sColourBar.Name = "sColourBar";
            this.sColourBar.Size = new System.Drawing.Size(147, 20);
            this.sColourBar.TabIndex = 23;
            // 
            // pnlHue
            // 
            this.pnlHue.Controls.Add(this.klblHue);
            this.pnlHue.Controls.Add(this.hColourBar);
            this.pnlHue.Controls.Add(this.knudHue);
            this.pnlHue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHue.Location = new System.Drawing.Point(0, 30);
            this.pnlHue.Name = "pnlHue";
            this.pnlHue.Size = new System.Drawing.Size(261, 32);
            this.pnlHue.TabIndex = 48;
            // 
            // hColourBar
            // 
            this.hColourBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hColourBar.BackColor = System.Drawing.Color.Transparent;
            this.hColourBar.Location = new System.Drawing.Point(47, 5);
            this.hColourBar.Name = "hColourBar";
            this.hColourBar.Size = new System.Drawing.Size(147, 20);
            this.hColourBar.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlBlue);
            this.panel1.Controls.Add(this.pnlGreen);
            this.panel1.Controls.Add(this.pnlRed);
            this.panel1.Controls.Add(this.pnlRGB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 122);
            this.panel1.TabIndex = 49;
            // 
            // pnlHSLUI
            // 
            this.pnlHSLUI.Controls.Add(this.pnlHue);
            this.pnlHSLUI.Controls.Add(this.pnlSaturation);
            this.pnlHSLUI.Controls.Add(this.pnlHSL);
            this.pnlHSLUI.Controls.Add(this.pnlLuminosity);
            this.pnlHSLUI.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHSLUI.Location = new System.Drawing.Point(0, 150);
            this.pnlHSLUI.Name = "pnlHSLUI";
            this.pnlHSLUI.Size = new System.Drawing.Size(261, 126);
            this.pnlHSLUI.TabIndex = 50;
            // 
            // ColourEditorUserControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlHSLUI);
            this.Controls.Add(this.pnlAlpha);
            this.Controls.Add(this.pnlHexadecimal);
            this.Controls.Add(this.panel1);
            this.Name = "ColourEditorUserControl";
            this.Size = new System.Drawing.Size(261, 303);
            this.Load += new System.EventHandler(this.ColourEditorUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbHex)).EndInit();
            this.pnlRGB.ResumeLayout(false);
            this.pnlRGB.PerformLayout();
            this.pnlRed.ResumeLayout(false);
            this.pnlRed.PerformLayout();
            this.pnlGreen.ResumeLayout(false);
            this.pnlGreen.PerformLayout();
            this.pnlBlue.ResumeLayout(false);
            this.pnlBlue.PerformLayout();
            this.pnlHexadecimal.ResumeLayout(false);
            this.pnlHexadecimal.PerformLayout();
            this.pnlHSL.ResumeLayout(false);
            this.pnlHSL.PerformLayout();
            this.pnlAlpha.ResumeLayout(false);
            this.pnlAlpha.PerformLayout();
            this.pnlLuminosity.ResumeLayout(false);
            this.pnlLuminosity.PerformLayout();
            this.pnlSaturation.ResumeLayout(false);
            this.pnlSaturation.PerformLayout();
            this.pnlHue.ResumeLayout(false);
            this.pnlHue.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlHSLUI.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Constants

        private static readonly object _eventColourChanged = new object();

        private static readonly object _eventOrientationChanged = new object();

        private static readonly object _eventShowAlphaChannelChanged = new object();

        private static readonly object _eventShowColourSpaceLabelsChanged = new object();

        private const int _minimumBarWidth = 30;

        #endregion

        #region Fields

        private Color _colour;

        private HSLColour _hslColour;

        private Orientation _orientation;

        private bool _showAlphaChannel, _showColourSpaceLabels, _showLabelsInColour, _showHSLUI, _showHexadecimalUI;

        #endregion

        #region Constructor
        public ColourEditorUserControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);

            _colour = Color.Black;

            _orientation = Orientation.Vertical;

            Size = new Size(261, 359);

            _showAlphaChannel = true;

            _showColourSpaceLabels = true;
        }
        #endregion

        #region Events

        [Category("Property Changed")]
        public event EventHandler OrientationChanged
        {
            add { this.Events.AddHandler(_eventOrientationChanged, value); }
            remove { this.Events.RemoveHandler(_eventOrientationChanged, value); }
        }

        [Category("Property Changed")]
        public event EventHandler ShowAlphaChannelChanged
        {
            add { this.Events.AddHandler(_eventShowAlphaChannelChanged, value); }
            remove { this.Events.RemoveHandler(_eventShowAlphaChannelChanged, value); }
        }

        /// <summary>
        /// Occurs when the ShowColourSpaceLabels property value changes
        /// </summary>
        [Category("Property Changed")]
        public event EventHandler ShowColourSpaceLabelsChanged
        {
            add { this.Events.AddHandler(_eventShowColourSpaceLabelsChanged, value); }
            remove { this.Events.RemoveHandler(_eventShowColourSpaceLabelsChanged, value); }
        }

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the component colour as a HSL structure.
        /// </summary>
        /// <value>The component colour.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual HSLColour HslColour
        {
            get { return _hslColour; }
            set
            {
                if (this.HslColour != value)
                {
                    _hslColour = value;

                    if (!this.LockUpdates)
                    {
                        this.LockUpdates = true;
                        this.Colour = value.ToRgbColour();
                        this.LockUpdates = false;
                        this.UpdateFields(false);
                    }
                    else
                    {
                        this.OnColourChanged(EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the orientation of the editor.
        /// </summary>
        /// <value>The orientation.</value>
        [Category("Appearance")]
        [DefaultValue(typeof(Orientation), "Vertical")]
        public virtual Orientation Orientation
        {
            get { return _orientation; }
            set
            {
                if (this.Orientation != value)
                {
                    _orientation = value;

                    this.OnOrientationChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public virtual bool ShowAlphaChannel
        {
            get { return _showAlphaChannel; }
            set
            {
                if (_showAlphaChannel != value)
                {
                    _showAlphaChannel = value;

                    this.OnShowAlphaChannelChanged(EventArgs.Empty);

                    Invalidate();
                }
            }
        }

        [Category("Appearance"), DefaultValue(true)]
        public bool ShowColourSpaceLabels
        {
            get { return _showColourSpaceLabels; }
            set
            {
                if (_showColourSpaceLabels != value)
                {
                    _showColourSpaceLabels = value;

                    this.OnShowColourSpaceLabelsChanged(EventArgs.Empty);
                }
            }
        }

        [Category("Appearence"), DefaultValue(false)]
        public bool ShowLabelsInColour { get => _showLabelsInColour; set { _showLabelsInColour = value; Invalidate(); } }

        [Category("Appearence"), DefaultValue(true)]
        public bool ShowHSL { get => _showHSLUI; set { _showHSLUI = value; Invalidate(); } }

        [Category("Appearence"), DefaultValue(true)]
        public bool ShowHexadecimal { get => _showHexadecimalUI; set { _showHexadecimalUI = value; Invalidate(); } }

        /// <summary>
        /// Gets or sets a value indicating whether input changes should be processed.
        /// </summary>
        /// <value><c>true</c> if input changes should be processed; otherwise, <c>false</c>.</value>
        protected bool LockUpdates { get; set; }

        #endregion

        #region Override Voids
        /// <summary>
        /// Raises the <see cref="ColourChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColourChanged(EventArgs e)
        {
            EventHandler handler;

            this.UpdateFields(false);

            handler = (EventHandler)this.Events[_eventColourChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="OrientationChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnOrientationChanged(EventArgs e)
        {
            EventHandler handler;

            //ResizeComponents();

            handler = (EventHandler)this.Events[_eventOrientationChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ShowAlphaChannelChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowAlphaChannelChanged(EventArgs e)
        {
            EventHandler handler;

            this.SetControlStates();

            //ResizeComponents();

            handler = (EventHandler)this.Events[_eventShowAlphaChannelChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="ShowColourSpaceLabelsChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnShowColourSpaceLabelsChanged(EventArgs e)
        {
            EventHandler handler;

            this.SetControlStates();

            //ResizeComponents();

            handler = (EventHandler)this.Events[_eventShowColourSpaceLabelsChanged];

            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Resizes the editing components.
        /// </summary>
        protected virtual void ResizeComponents()
        {
            try
            {
                int group1HeaderLeft;
                int group1BarLeft;
                int group1EditLeft;
                int group2HeaderLeft;
                int group2BarLeft;
                int group2EditLeft;
                int barWidth;
                int editWidth;
                int top;
                int innerMargin;
                int columnWidth;
                int rowHeight;
                int labelOffset;
                int colourBarOffset;
                int editOffset;
                int barHorizontalOffset;

                top = this.Padding.Top;
                innerMargin = 3;
                editWidth = TextRenderer.MeasureText("0000W", this.Font).Width + 6; // magic 6 for interior spacing+borders
                rowHeight = Math.Max(Math.Max(klblRed.Height, rColourBar.Height), knudRed.Height);
                labelOffset = (rowHeight - klblRed.Height) >> 1;
                colourBarOffset = (rowHeight - rColourBar.Height) >> 1;
                editOffset = (rowHeight - knudRed.Height) >> 1;
                barHorizontalOffset = _showAlphaChannel ? klblAlpha.Width : klblHue.Width;

                switch (this.Orientation)
                {
                    case Orientation.Horizontal:
                        columnWidth = (this.ClientSize.Width - (this.Padding.Horizontal + innerMargin)) >> 1;
                        break;
                    default:
                        columnWidth = this.ClientSize.Width - this.Padding.Horizontal;
                        break;
                }

                group1HeaderLeft = this.Padding.Left;
                group1EditLeft = columnWidth - editWidth;
                group1BarLeft = group1HeaderLeft + barHorizontalOffset + innerMargin;

                if (this.Orientation == Orientation.Horizontal)
                {
                    group2HeaderLeft = this.Padding.Left + columnWidth + innerMargin;
                    group2EditLeft = this.ClientSize.Width - (this.Padding.Right + editWidth);
                    group2BarLeft = group2HeaderLeft + barHorizontalOffset + innerMargin;
                }
                else
                {
                    group2HeaderLeft = group1HeaderLeft;
                    group2EditLeft = group1EditLeft;
                    group2BarLeft = group1BarLeft;
                }

                barWidth = group1EditLeft - (group1BarLeft + innerMargin);

                this.SetBarStates(barWidth >= _minimumBarWidth);

                /*
                   // RGB header
                   if (_showColourSpaceLabels)
                   {
                       klblRGB.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                       top += rowHeight + innerMargin;
                   }

                   // R row
                   klblRed.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                   rColourBar.SetBounds(group1BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                   knudRed.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                   top += rowHeight + innerMargin;

                   // G row
                   klblGreen.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                   gColourBar.SetBounds(group1BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                   knudGreen.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                   top += rowHeight + innerMargin;

                   // B row
                   klblBlue.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                   bColourBar.SetBounds(group1BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                   knudBlue.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                   top += rowHeight + innerMargin;
                   */

                // Hex row
                klblHex.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                kcmbHex.SetBounds(klblHex.Right + innerMargin, top + colourBarOffset, barWidth + editOffset + editWidth - (klblHex.Right - group1BarLeft), 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // reset top
                if (this.Orientation == Orientation.Horizontal)
                {
                    top = this.Padding.Top;
                }

                /*
                // HSL header
                if (_showColourSpaceLabels)
                {
                    klblHSL.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                    top += rowHeight + innerMargin;
                }

                // H row
                klblHue.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                hColourBar.SetBounds(group2BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudHue.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // S row
                klblSaturation.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                sColourBar.SetBounds(group2BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudSaturation.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // L row
                klblLuminosity.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                lColourBar.SetBounds(group2BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudLuminosity.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                top += rowHeight + innerMargin;

                // A row
                klblAlpha.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
                aColourBar.SetBounds(group2BarLeft, top + colourBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                knudAlpha.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
                */
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch
            // ReSharper restore EmptyGeneralCatchClause
            {
                // ignore errors
            }
        }

        /// <summary>
        /// Updates the editing field values.
        /// </summary>
        /// <param name="userAction">if set to <c>true</c> the update is due to user interaction.</param>
        protected virtual void UpdateFields(bool userAction)
        {
            if (!this.LockUpdates)
            {
                try
                {
                    this.LockUpdates = true;

                    // RGB
                    if (!(userAction && knudRed.Focused))
                    {
                        knudRed.Value = this.Colour.R;
                    }
                    if (!(userAction && knudGreen.Focused))
                    {
                        knudGreen.Value = this.Colour.G;
                    }
                    if (!(userAction && knudBlue.Focused))
                    {
                        knudBlue.Value = this.Colour.B;
                    }
                    rColourBar.Value = this.Colour.R;
                    rColourBar.Colour = this.Colour;
                    gColourBar.Value = this.Colour.G;
                    gColourBar.Colour = this.Colour;
                    bColourBar.Value = this.Colour.B;
                    bColourBar.Colour = this.Colour;

                    // HTML
                    if (!(userAction && kcmbHex.Focused))
                    {
                        kcmbHex.Text = this.Colour.IsNamedColor ? this.Colour.Name : string.Format("{0:X2}{1:X2}{2:X2}", this.Colour.R, this.Colour.G, this.Colour.B);
                    }

                    // HSL
                    if (!(userAction && knudHue.Focused))
                    {
                        knudHue.Value = (int)this.HslColour.H;
                    }
                    if (!(userAction && knudSaturation.Focused))
                    {
                        knudSaturation.Value = (int)(this.HslColour.S * 100);
                    }
                    if (!(userAction && knudLuminosity.Focused))
                    {
                        knudLuminosity.Value = (int)(this.HslColour.L * 100);
                    }
                    hColourBar.Value = (int)this.HslColour.H;
                    sColourBar.Colour = this.Colour;
                    sColourBar.Value = (int)(this.HslColour.S * 100);
                    lColourBar.Colour = this.Colour;
                    lColourBar.Value = (int)(this.HslColour.L * 100);

                    // Alpha
                    if (!(userAction && knudAlpha.Focused))
                    {
                        knudAlpha.Value = this.Colour.A;
                    }
                    aColourBar.Colour = this.Colour;
                    aColourBar.Value = this.Colour.A;
                }
                finally
                {
                    this.LockUpdates = false;
                }
            }
        }
        #endregion

        #region Overrides
        protected override void OnDockChanged(EventArgs e)
        {
            //ResizeComponents();

            base.OnDockChanged(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            //SetDropDownWidth();

            base.OnFontChanged(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            //ResizeComponents();

            base.OnLoad(e);
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            //ResizeComponents();

            base.OnPaddingChanged(e);
        }

        protected override void OnResize(EventArgs e)
        {
            //ResizeComponents();

            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SetColouredLabels(ShowLabelsInColour);

            ShowHexadecimalUI(ShowHexadecimal);

            ShowHSLUI(ShowHSL);

            ShowAlphaUI(ShowAlphaChannel);

            base.OnPaint(e);
        }
        #endregion

        #region Methods
#if !NETCOREAPP
        private void AddColourProperties<T>()
        {
            Type type;
            Type colourType;

            type = typeof(T);
            colourType = typeof(Color);

            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Static))
            {
                if (property.PropertyType == colourType)
                {
                    Color colour;

                    colour = (Color)property.GetValue(type, null);
                    if (!colour.IsEmpty)
                    {
                        kcmbHex.Items.Add(colour.Name);
                    }
                }
            }
        }
#endif

        private string AddSpaces(string text)
        {
            string result;

            //http://stackoverflow.com/a/272929/148962

            if (!string.IsNullOrEmpty(text))
            {
                StringBuilder newText;

                newText = new StringBuilder(text.Length * 2);
                newText.Append(text[0]);
                for (int i = 1; i < text.Length; i++)
                {
                    if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                    {
                        newText.Append(' ');
                    }
                    newText.Append(text[i]);
                }

                result = newText.ToString();
            }
            else
            {
                result = null;
            }

            return result;
        }

#if !NETCOREAPP
        private void FillNamedColours()
        {
            this.AddColourProperties<SystemColors>();
            this.AddColourProperties<Color>();
            this.SetDropDownWidth();
        }
#endif
        #endregion

        #region Event Handlers
        private void kcmbHex_DrawItem(object sender, DrawItemEventArgs e)
        {
            // TODO: Really, this should be another control - ColourComboBox or ColourListBox etc.

            if (e.Index != -1)
            {
                Rectangle colourBox;
                string name;
                Color colour;

                e.DrawBackground();

                name = (string)kcmbHex.Items[e.Index];
                colour = Color.FromName(name);
                colourBox = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1, e.Bounds.Height - 3, e.Bounds.Height - 3);

                using (Brush brush = new SolidBrush(colour))
                {
                    e.Graphics.FillRectangle(brush, colourBox);
                }
                e.Graphics.DrawRectangle(SystemPens.ControlText, colourBox);

                TextRenderer.DrawText(e.Graphics, this.AddSpaces(name), this.Font, new Point(colourBox.Right + 3, colourBox.Top), e.ForeColor);

                //if (colour == Colour.Transparent && (e.State & DrawItemState.Selected) != DrawItemState.Selected)
                //  e.Graphics.DrawLine(SystemPens.ControlText, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Top);

                e.DrawFocusRectangle();
            }
        }

        private void kcmbHex_DropDown(object sender, EventArgs e)
        {
#if !NETCOREAPP
            if (kcmbHex.Items.Count == 0)
            {
                this.FillNamedColours();
            }
#endif
        }

        private void kcmbHex_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.PageUp:
                case Keys.PageDown:
#if !NETCOREAPP
                    if (kcmbHex.Items.Count == 0)
                    {
                        this.FillNamedColours();
                    }
#endif
                    break;
            }
        }

        private void kcmbHex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kcmbHex.SelectedIndex != -1)
            {
                this.LockUpdates = true;
                this.Colour = Color.FromName((string)kcmbHex.SelectedItem);
                this.LockUpdates = false;
            }
        }
        #endregion

        #region Methods
        private void SetBarStates(bool visible)
        {
            rColourBar.Visible = visible;
            gColourBar.Visible = visible;
            bColourBar.Visible = visible;
            hColourBar.Visible = visible;
            sColourBar.Visible = visible;
            lColourBar.Visible = visible;
            aColourBar.Visible = _showAlphaChannel && visible;
        }

        private void SetControlStates()
        {
            klblAlpha.Visible = _showAlphaChannel;
            aColourBar.Visible = _showAlphaChannel;
            knudAlpha.Visible = _showAlphaChannel;

            klblRed.Visible = _showColourSpaceLabels;
            klblHSL.Visible = _showColourSpaceLabels;
        }

        private void SetDropDownWidth()
        {
            if (kcmbHex.Items.Count != 0)
            {
                kcmbHex.DropDownWidth = kcmbHex.ItemHeight * 2 + kcmbHex.Items.Cast<string>().Max(s => TextRenderer.MeasureText(s, this.Font).Width);
            }
        }

        /// <summary>
        /// Change handler for editing components.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ValueChangedHandler(object sender, EventArgs e)
        {
            if (!this.LockUpdates)
            {
                bool useHsl;
                bool useRgb;
                bool useNamed;

                useHsl = false;
                useRgb = false;
                useNamed = false;

                this.LockUpdates = true;

                if (sender == kcmbHex)
                {
                    string text;
                    int namedIndex;

                    text = kcmbHex.Text;
                    if (text.StartsWith("#"))
                    {
                        text = text.Substring(1);
                    }

#if !NETCOREAPP
                    if (kcmbHex.Items.Count == 0)
                    {
                        this.FillNamedColours();
                    }
#endif

                    namedIndex = kcmbHex.FindStringExact(text);

                    if (namedIndex != -1 || text.Length == 6 || text.Length == 8)
                    {
                        try
                        {
                            Color colour;

                            colour = namedIndex != -1 ? Color.FromName(text) : ColorTranslator.FromHtml("#" + text);
                            knudAlpha.Value = colour.A;
                            knudRed.Value = colour.R;
                            knudBlue.Value = colour.B;
                            knudGreen.Value = colour.G;

                            useRgb = true;
                        }
                        // ReSharper disable EmptyGeneralCatchClause
                        catch
                        { }
                        // ReSharper restore EmptyGeneralCatchClause
                    }
                    else
                    {
                        useNamed = true;
                    }
                }
                else if (sender == aColourBar || sender == rColourBar || sender == gColourBar || sender == bColourBar)
                {
                    knudAlpha.Value = (int)aColourBar.Value;
                    knudRed.Value = (int)rColourBar.Value;
                    knudGreen.Value = (int)gColourBar.Value;
                    knudBlue.Value = (int)bColourBar.Value;

                    useRgb = true;
                }
                else if (sender == knudAlpha || sender == knudRed || sender == knudGreen || sender == knudBlue)
                {
                    useRgb = true;
                }
                else if (sender == hColourBar || sender == lColourBar || sender == sColourBar)
                {
                    knudHue.Value = (int)hColourBar.Value;
                    knudSaturation.Value = (int)sColourBar.Value;
                    knudLuminosity.Value = (int)lColourBar.Value;

                    useHsl = true;
                }
                else if (sender == knudHue || sender == knudSaturation || sender == knudLuminosity)
                {
                    useHsl = true;
                }

                if (useRgb || useNamed)
                {
                    Color colour;

                    colour = useNamed ? Color.FromName(kcmbHex.Text) : Color.FromArgb((int)knudAlpha.Value, (int)knudRed.Value, (int)knudGreen.Value, (int)knudBlue.Value);

                    this.Colour = colour;
                    this.HslColour = new HSLColour(colour);
                }
                else if (useHsl)
                {
                    HSLColour colour;

                    colour = new HSLColour((int)knudAlpha.Value, (double)knudHue.Value, (double)knudSaturation.Value / 100, (double)knudLuminosity.Value / 100);
                    this.HslColour = colour;
                    this.Colour = colour.ToRgbColour();
                }

                this.LockUpdates = false;
                this.UpdateFields(true);
            }
        }

        private void SetColouredLabels(bool value)
        {
            if (value)
            {
                klblRed.StateCommon.ShortText.Color1 = Color.Red;

                klblRed.StateCommon.ShortText.Color2 = Color.Red;

                klblGreen.StateCommon.ShortText.Color1 = Color.Green;

                klblGreen.StateCommon.ShortText.Color2 = Color.Green;

                klblBlue.StateCommon.ShortText.Color1 = Color.Blue;

                klblBlue.StateCommon.ShortText.Color2 = Color.Blue;
            }
            else
            {
                klblRed.StateCommon.ShortText.Color1 = Color.Empty;

                klblRed.StateCommon.ShortText.Color2 = Color.Empty;

                klblGreen.StateCommon.ShortText.Color1 = Color.Empty;

                klblGreen.StateCommon.ShortText.Color2 = Color.Empty;

                klblBlue.StateCommon.ShortText.Color1 = Color.Empty;

                klblBlue.StateCommon.ShortText.Color2 = Color.Empty;
            }
        }

        private void ShowHSLUI(bool value)
        {
            pnlHSL.Visible = value;

            pnlHue.Visible = value;

            pnlSaturation.Visible = value;

            pnlLuminosity.Visible = value;

            AdjustUI();
        }

        private void ShowAlphaUI(bool value) { pnlAlpha.Visible = value; AdjustUI(); }

        private void ShowHexadecimalUI(bool value) { pnlHexadecimal.Visible = value; AdjustUI(); }

        private void AdjustUI()
        {
            int height;

            if (ShowAlphaChannel && ShowHexadecimal && ShowHSL)
            {
                height = pnlRGB.Height + pnlRed.Height + pnlBlue.Height + pnlHexadecimal.Height + pnlHSL.Height + pnlHue.Height + pnlSaturation.Height + pnlLuminosity.Height + pnlAlpha.Height;

                Height = height;
            }
            else if (ShowAlphaChannel && ShowHexadecimal)
            {
                height = pnlRGB.Height + pnlRed.Height + pnlBlue.Height + pnlHexadecimal.Height + pnlAlpha.Height;

                Height = height;
            }
            else if (ShowAlphaChannel && ShowHSL)
            {
                height = pnlRGB.Height + pnlRed.Height + pnlBlue.Height + pnlHSL.Height + pnlHue.Height + pnlSaturation.Height + pnlLuminosity.Height + pnlAlpha.Height;

                Height = height;
            }
        }
        #endregion

        #region IColourEditor Implementation
        [Category("Appearance"), DefaultValue(typeof(Color), "0, 0, 0")]
        public Color Colour
        {
            get => _colour;

            set
            {
                if (value.A != 255 && !_showAlphaChannel)
                {
                    value = Color.FromArgb(255, value);
                }

                if (_colour != value)
                {
                    _colour = value;

                    if (!LockUpdates)
                    {
                        LockUpdates = true;

                        HslColour = new HSLColour(value);

                        LockUpdates = false;

                        UpdateFields(false);
                    }
                    else
                    {
                        OnColourChanged(EventArgs.Empty);
                    }
                }
            }
        }

        private void ColourEditorUserControl_Load(object sender, EventArgs e)
        {

        }

        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add => this.Events.AddHandler(_eventColourChanged, value);

            remove => Events.RemoveHandler(_eventColourChanged, value);
        }

        #endregion
    }
}