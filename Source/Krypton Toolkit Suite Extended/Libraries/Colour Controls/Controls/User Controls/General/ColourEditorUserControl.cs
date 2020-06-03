using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Colour.Controls
{
    public class ColourEditorUserControl : UserControl, IColourEditor
    {
        #region Designer Code
        private KryptonAlphaValueLabel klblRed;
        private KryptonAlphaValueLabel klblGreen;
        private KryptonAlphaValueLabel klblBlue;
        private KryptonAlphaValueLabel klblHex;
        private KryptonAlphaValueLabel klblHSL;
        private KryptonAlphaValueLabel klblLuminosity;
        private KryptonAlphaValueLabel klblSaturation;
        private KryptonAlphaValueLabel klblHue;
        private KryptonAlphaValueLabel klblAlpha;
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
        private KryptonNumericUpDown knudAlpha;
        private KryptonAlphaValueLabel klblRGB;

        private void InitializeComponent()
        {
            this.kcmbHex = new Krypton.Toolkit.KryptonComboBox();
            this.knudHue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudSaturation = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudLuminosity = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudAlpha = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudBlue = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonBlueValueNumericBox();
            this.knudGreen = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonGreenValueNumericBox();
            this.knudRed = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonRedValueNumericBox();
            this.aColourBar = new Krypton.Toolkit.Suite.Extended.Colour.Controls.RGBAColourSliderControl();
            this.hColourBar = new Krypton.Toolkit.Suite.Extended.Colour.Controls.HueColourSliderControl();
            this.sColourBar = new Krypton.Toolkit.Suite.Extended.Colour.Controls.SaturationColourSliderControl();
            this.lColourBar = new Krypton.Toolkit.Suite.Extended.Colour.Controls.LightnessColourSliderControl();
            this.rColourBar = new Krypton.Toolkit.Suite.Extended.Colour.Controls.RGBAColourSliderControl();
            this.gColourBar = new Krypton.Toolkit.Suite.Extended.Colour.Controls.RGBAColourSliderControl();
            this.bColourBar = new Krypton.Toolkit.Suite.Extended.Colour.Controls.RGBAColourSliderControl();
            this.klblAlpha = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonAlphaValueLabel();
            this.klblLuminosity = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonAlphaValueLabel();
            this.klblSaturation = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonAlphaValueLabel();
            this.klblHue = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonAlphaValueLabel();
            this.klblHSL = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonAlphaValueLabel();
            this.klblHex = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonAlphaValueLabel();
            this.klblBlue = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonAlphaValueLabel();
            this.klblGreen = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonAlphaValueLabel();
            this.klblRed = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonAlphaValueLabel();
            this.klblRGB = new Krypton.Toolkit.Suite.Extended.Colour.Controls.KryptonAlphaValueLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbHex)).BeginInit();
            this.SuspendLayout();
            // 
            // kcmbHex
            // 
            this.kcmbHex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kcmbHex.DropDownWidth = 58;
            this.kcmbHex.IntegralHeight = false;
            this.kcmbHex.Location = new System.Drawing.Point(54, 141);
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
            this.knudHue.Location = new System.Drawing.Point(200, 209);
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
            this.knudSaturation.Location = new System.Drawing.Point(200, 246);
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
            this.knudLuminosity.Location = new System.Drawing.Point(200, 284);
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
            this.knudAlpha.Location = new System.Drawing.Point(200, 323);
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
            // knudBlue
            // 
            this.knudBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudBlue.Location = new System.Drawing.Point(200, 103);
            this.knudBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBlue.Name = "knudBlue";
            this.knudBlue.Size = new System.Drawing.Size(58, 23);
            this.knudBlue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knudBlue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudBlue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudBlue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBlue.TabIndex = 28;
            // 
            // knudGreen
            // 
            this.knudGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudGreen.Location = new System.Drawing.Point(200, 65);
            this.knudGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudGreen.Name = "knudGreen";
            this.knudGreen.Size = new System.Drawing.Size(58, 23);
            this.knudGreen.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.knudGreen.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudGreen.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.knudGreen.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudGreen.TabIndex = 27;
            // 
            // knudRed
            // 
            this.knudRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.knudRed.Location = new System.Drawing.Point(200, 28);
            this.knudRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudRed.Name = "knudRed";
            this.knudRed.Size = new System.Drawing.Size(58, 23);
            this.knudRed.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knudRed.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudRed.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudRed.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudRed.TabIndex = 26;
            // 
            // aColourBar
            // 
            this.aColourBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aColourBar.BackColor = System.Drawing.Color.Transparent;
            this.aColourBar.Channel = Krypton.Toolkit.Suite.Extended.Colour.Controls.RGBAChannel.Alpha;
            this.aColourBar.Location = new System.Drawing.Point(66, 326);
            this.aColourBar.Name = "aColourBar";
            this.aColourBar.Size = new System.Drawing.Size(128, 20);
            this.aColourBar.TabIndex = 25;
            // 
            // hColourBar
            // 
            this.hColourBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.hColourBar.BackColor = System.Drawing.Color.Transparent;
            this.hColourBar.Location = new System.Drawing.Point(47, 212);
            this.hColourBar.Name = "hColourBar";
            this.hColourBar.Size = new System.Drawing.Size(147, 20);
            this.hColourBar.TabIndex = 22;
            // 
            // sColourBar
            // 
            this.sColourBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sColourBar.BackColor = System.Drawing.Color.Transparent;
            this.sColourBar.Location = new System.Drawing.Point(47, 249);
            this.sColourBar.Name = "sColourBar";
            this.sColourBar.Size = new System.Drawing.Size(147, 20);
            this.sColourBar.TabIndex = 23;
            // 
            // lColourBar
            // 
            this.lColourBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lColourBar.BackColor = System.Drawing.Color.Transparent;
            this.lColourBar.Location = new System.Drawing.Point(47, 287);
            this.lColourBar.Name = "lColourBar";
            this.lColourBar.Size = new System.Drawing.Size(147, 20);
            this.lColourBar.TabIndex = 24;
            // 
            // rColourBar
            // 
            this.rColourBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rColourBar.BackColor = System.Drawing.Color.Transparent;
            this.rColourBar.Location = new System.Drawing.Point(47, 31);
            this.rColourBar.Name = "rColourBar";
            this.rColourBar.Size = new System.Drawing.Size(147, 20);
            this.rColourBar.TabIndex = 17;
            // 
            // gColourBar
            // 
            this.gColourBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gColourBar.BackColor = System.Drawing.Color.Transparent;
            this.gColourBar.Channel = Krypton.Toolkit.Suite.Extended.Colour.Controls.RGBAChannel.Green;
            this.gColourBar.Location = new System.Drawing.Point(47, 68);
            this.gColourBar.Name = "gColourBar";
            this.gColourBar.Size = new System.Drawing.Size(147, 20);
            this.gColourBar.TabIndex = 18;
            // 
            // bColourBar
            // 
            this.bColourBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bColourBar.BackColor = System.Drawing.Color.Transparent;
            this.bColourBar.Channel = Krypton.Toolkit.Suite.Extended.Colour.Controls.RGBAChannel.Blue;
            this.bColourBar.Location = new System.Drawing.Point(47, 106);
            this.bColourBar.Name = "bColourBar";
            this.bColourBar.Size = new System.Drawing.Size(147, 20);
            this.bColourBar.TabIndex = 19;
            // 
            // klblAlpha
            // 
            this.klblAlpha.AlphaValue = 255;
            this.klblAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblAlpha.Location = new System.Drawing.Point(3, 325);
            this.klblAlpha.Name = "klblAlpha";
            this.klblAlpha.Size = new System.Drawing.Size(57, 21);
            this.klblAlpha.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblAlpha.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblAlpha.TabIndex = 16;
            this.klblAlpha.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblAlpha.Values.Text = "Alpha:";
            // 
            // klblLuminosity
            // 
            this.klblLuminosity.AlphaValue = 255;
            this.klblLuminosity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblLuminosity.Location = new System.Drawing.Point(13, 286);
            this.klblLuminosity.Name = "klblLuminosity";
            this.klblLuminosity.Size = new System.Drawing.Size(25, 21);
            this.klblLuminosity.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblLuminosity.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblLuminosity.TabIndex = 15;
            this.klblLuminosity.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblLuminosity.Values.Text = "L:";
            // 
            // klblSaturation
            // 
            this.klblSaturation.AlphaValue = 255;
            this.klblSaturation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblSaturation.Location = new System.Drawing.Point(13, 248);
            this.klblSaturation.Name = "klblSaturation";
            this.klblSaturation.Size = new System.Drawing.Size(27, 21);
            this.klblSaturation.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblSaturation.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblSaturation.TabIndex = 14;
            this.klblSaturation.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblSaturation.Values.Text = "S:";
            // 
            // klblHue
            // 
            this.klblHue.AlphaValue = 255;
            this.klblHue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblHue.Location = new System.Drawing.Point(13, 211);
            this.klblHue.Name = "klblHue";
            this.klblHue.Size = new System.Drawing.Size(28, 21);
            this.klblHue.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblHue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblHue.TabIndex = 13;
            this.klblHue.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblHue.Values.Text = "H:";
            // 
            // klblHSL
            // 
            this.klblHSL.AlphaValue = 255;
            this.klblHSL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblHSL.Location = new System.Drawing.Point(3, 184);
            this.klblHSL.Name = "klblHSL";
            this.klblHSL.Size = new System.Drawing.Size(47, 21);
            this.klblHSL.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblHSL.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblHSL.TabIndex = 12;
            this.klblHSL.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblHSL.Values.Text = "HSL:";
            // 
            // klblHex
            // 
            this.klblHex.AlphaValue = 255;
            this.klblHex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblHex.Location = new System.Drawing.Point(3, 141);
            this.klblHex.Name = "klblHex";
            this.klblHex.Size = new System.Drawing.Size(45, 21);
            this.klblHex.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblHex.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblHex.TabIndex = 11;
            this.klblHex.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblHex.Values.Text = "Hex:";
            // 
            // klblBlue
            // 
            this.klblBlue.AlphaValue = 255;
            this.klblBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblBlue.Location = new System.Drawing.Point(13, 105);
            this.klblBlue.Name = "klblBlue";
            this.klblBlue.Size = new System.Drawing.Size(27, 21);
            this.klblBlue.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBlue.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblBlue.TabIndex = 10;
            this.klblBlue.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblBlue.Values.Text = "B:";
            // 
            // klblGreen
            // 
            this.klblGreen.AlphaValue = 255;
            this.klblGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblGreen.Location = new System.Drawing.Point(13, 67);
            this.klblGreen.Name = "klblGreen";
            this.klblGreen.Size = new System.Drawing.Size(28, 21);
            this.klblGreen.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblGreen.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblGreen.TabIndex = 9;
            this.klblGreen.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblGreen.Values.Text = "G:";
            // 
            // klblRed
            // 
            this.klblRed.AlphaValue = 255;
            this.klblRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblRed.Location = new System.Drawing.Point(13, 30);
            this.klblRed.Name = "klblRed";
            this.klblRed.Size = new System.Drawing.Size(28, 21);
            this.klblRed.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblRed.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblRed.TabIndex = 8;
            this.klblRed.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblRed.Values.Text = "R:";
            // 
            // klblRGB
            // 
            this.klblRGB.AlphaValue = 255;
            this.klblRGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.klblRGB.Location = new System.Drawing.Point(3, 3);
            this.klblRGB.Name = "klblRGB";
            this.klblRGB.Size = new System.Drawing.Size(51, 21);
            this.klblRGB.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblRGB.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.klblRGB.TabIndex = 7;
            this.klblRGB.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.klblRGB.Values.Text = "RGB:";
            // 
            // ColourEditorUserControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.knudAlpha);
            this.Controls.Add(this.knudLuminosity);
            this.Controls.Add(this.knudSaturation);
            this.Controls.Add(this.knudHue);
            this.Controls.Add(this.kcmbHex);
            this.Controls.Add(this.knudBlue);
            this.Controls.Add(this.knudGreen);
            this.Controls.Add(this.knudRed);
            this.Controls.Add(this.aColourBar);
            this.Controls.Add(this.hColourBar);
            this.Controls.Add(this.sColourBar);
            this.Controls.Add(this.lColourBar);
            this.Controls.Add(this.rColourBar);
            this.Controls.Add(this.gColourBar);
            this.Controls.Add(this.bColourBar);
            this.Controls.Add(this.klblAlpha);
            this.Controls.Add(this.klblLuminosity);
            this.Controls.Add(this.klblSaturation);
            this.Controls.Add(this.klblHue);
            this.Controls.Add(this.klblHSL);
            this.Controls.Add(this.klblHex);
            this.Controls.Add(this.klblBlue);
            this.Controls.Add(this.klblGreen);
            this.Controls.Add(this.klblRed);
            this.Controls.Add(this.klblRGB);
            this.Name = "ColourEditorUserControl";
            this.Size = new System.Drawing.Size(261, 359);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbHex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        private bool _showAlphaChannel, _showColourSpaceLabels;

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
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
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

        [Category("Property Changed")]
        public event EventHandler ColourChanged
        {
            add => this.Events.AddHandler(_eventColourChanged, value);

            remove => Events.RemoveHandler(_eventColourChanged, value);
        }

        #endregion
    }
}