using Krypton.Toolkit.Extended.Base;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Colour.Controls
{
    public class KryptonColourButtonCustomColourDialog : KryptonForm
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnOk;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private ColourWheelControl cwColours;
        private CircularPictureBox cpbSelectedColour;
        private KryptonTextBox ktbHexadecimalColourValue;
        private KryptonLabel kryptonLabel1;
        private KryptonAlphaValueNumericBox knumBrightness;
        private KryptonAlphaValueNumericBox knumHue;
        private KryptonAlphaValueNumericBox knumSaturation;
        private KryptonBlueValueNumericBox knumBlue;
        private KryptonGreenValueNumericBox knumGreen;
        private KryptonRedValueNumericBox knumRed;
        private KryptonAlphaValueNumericBox knumAlpha;
        private KryptonLabel kryptonLabel2;
        private KryptonBlueValueLabel kryptonBlueValueLabel1;
        private KryptonGreenValueLabel kryptonGreenValueLabel1;
        private KryptonRedValueLabel kryptonRedValueLabel1;
        private KryptonLabel kryptonLabel6;
        private KryptonLabel kryptonLabel5;
        private KryptonLabel kryptonLabel4;
        private KryptonLabel kryptonLabel3;
        private KryptonAlphaValueNumericBox knumNormalGreen;
        private KryptonAlphaValueNumericBox knumNormalBlue;
        private KryptonAlphaValueNumericBox knumNormalRed;
        private KryptonLabel klblNormalBlue;
        private KryptonLabel klblNormalGreen;
        private KryptonLabel klblNormalRed;
        private KryptonButton kbtnSaveColourPalette;
        private KryptonButton kbtnLoadColourPalette;
        private KryptonButton kbtnCustomColours;
        private KryptonButton kbtnCancel;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnSaveColourPalette = new Krypton.Toolkit.KryptonButton();
            this.kbtnLoadColourPalette = new Krypton.Toolkit.KryptonButton();
            this.knumBlue = new KryptonBlueValueNumericBox();
            this.knumGreen = new KryptonGreenValueNumericBox();
            this.knumNormalGreen = new KryptonAlphaValueNumericBox();
            this.knumNormalBlue = new KryptonAlphaValueNumericBox();
            this.knumRed = new KryptonRedValueNumericBox();
            this.knumNormalRed = new KryptonAlphaValueNumericBox();
            this.kryptonBlueValueLabel1 = new KryptonBlueValueLabel();
            this.kryptonGreenValueLabel1 = new KryptonGreenValueLabel();
            this.kryptonRedValueLabel1 = new KryptonRedValueLabel();
            this.klblNormalBlue = new Krypton.Toolkit.KryptonLabel();
            this.klblNormalGreen = new Krypton.Toolkit.KryptonLabel();
            this.klblNormalRed = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.knumBrightness = new KryptonAlphaValueNumericBox();
            this.knumHue = new KryptonAlphaValueNumericBox();
            this.knumSaturation = new KryptonAlphaValueNumericBox();
            this.knumAlpha = new KryptonAlphaValueNumericBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.ktbHexadecimalColourValue = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.cpbSelectedColour = new CircularPictureBox();
            this.cwColours = new ColourWheelControl();
            this.kbtnCustomColours = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbSelectedColour)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 452);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(611, 48);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(405, 8);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(94, 28);
            this.kbtnOk.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Text = "&Ok";
            this.kbtnOk.Click += new System.EventHandler(this.KbtnOk_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(505, 8);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(94, 28);
            this.kbtnCancel.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.KbtnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 449);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 3);
            this.panel1.TabIndex = 3;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnCustomColours);
            this.kryptonPanel2.Controls.Add(this.kbtnSaveColourPalette);
            this.kryptonPanel2.Controls.Add(this.kbtnLoadColourPalette);
            this.kryptonPanel2.Controls.Add(this.knumBlue);
            this.kryptonPanel2.Controls.Add(this.knumGreen);
            this.kryptonPanel2.Controls.Add(this.knumNormalGreen);
            this.kryptonPanel2.Controls.Add(this.knumNormalBlue);
            this.kryptonPanel2.Controls.Add(this.knumRed);
            this.kryptonPanel2.Controls.Add(this.knumNormalRed);
            this.kryptonPanel2.Controls.Add(this.kryptonBlueValueLabel1);
            this.kryptonPanel2.Controls.Add(this.kryptonGreenValueLabel1);
            this.kryptonPanel2.Controls.Add(this.kryptonRedValueLabel1);
            this.kryptonPanel2.Controls.Add(this.klblNormalBlue);
            this.kryptonPanel2.Controls.Add(this.klblNormalGreen);
            this.kryptonPanel2.Controls.Add(this.klblNormalRed);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel6);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.knumBrightness);
            this.kryptonPanel2.Controls.Add(this.knumHue);
            this.kryptonPanel2.Controls.Add(this.knumSaturation);
            this.kryptonPanel2.Controls.Add(this.knumAlpha);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.ktbHexadecimalColourValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Controls.Add(this.cpbSelectedColour);
            this.kryptonPanel2.Controls.Add(this.cwColours);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(611, 449);
            this.kryptonPanel2.TabIndex = 4;
            // 
            // kbtnSaveColourPalette
            // 
            this.kbtnSaveColourPalette.Location = new System.Drawing.Point(41, 231);
            this.kbtnSaveColourPalette.Name = "kbtnSaveColourPalette";
            this.kbtnSaveColourPalette.Size = new System.Drawing.Size(23, 23);
            this.kbtnSaveColourPalette.TabIndex = 105;
            this.kbtnSaveColourPalette.Values.Image = global::Krypton.Toolkit.Extended.Colour.Controls.Resources.LibraryResources.palette_save;
            this.kbtnSaveColourPalette.Values.Text = "";
            this.kbtnSaveColourPalette.Click += new System.EventHandler(this.KbtnSaveColourPalette_Click);
            // 
            // kbtnLoadColourPalette
            // 
            this.kbtnLoadColourPalette.Location = new System.Drawing.Point(12, 231);
            this.kbtnLoadColourPalette.Name = "kbtnLoadColourPalette";
            this.kbtnLoadColourPalette.Size = new System.Drawing.Size(23, 23);
            this.kbtnLoadColourPalette.TabIndex = 104;
            this.kbtnLoadColourPalette.Values.Image = global::Krypton.Toolkit.Extended.Colour.Controls.Resources.LibraryResources.palette_load;
            this.kbtnLoadColourPalette.Values.Text = "";
            this.kbtnLoadColourPalette.Click += new System.EventHandler(this.KbtnLoadColourPalette_Click);
            // 
            // knumBlue
            // 
            this.knumBlue.Location = new System.Drawing.Point(505, 399);
            this.knumBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumBlue.Name = "knumBlue";
            this.knumBlue.Size = new System.Drawing.Size(94, 26);
            this.knumBlue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knumBlue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumBlue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.knumBlue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumBlue.TabIndex = 5;
            this.knumBlue.ValueChanged += new System.EventHandler(this.KnumBlue_ValueChanged);
            // 
            // knumGreen
            // 
            this.knumGreen.Location = new System.Drawing.Point(505, 336);
            this.knumGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumGreen.Name = "knumGreen";
            this.knumGreen.Size = new System.Drawing.Size(94, 26);
            this.knumGreen.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.knumGreen.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumGreen.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.knumGreen.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumGreen.TabIndex = 90;
            this.knumGreen.ValueChanged += new System.EventHandler(this.KnumGreen_ValueChanged);
            // 
            // knumNormalGreen
            // 
            this.knumNormalGreen.Location = new System.Drawing.Point(505, 336);
            this.knumNormalGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumNormalGreen.Name = "knumNormalGreen";
            this.knumNormalGreen.Size = new System.Drawing.Size(94, 26);
            this.knumNormalGreen.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.knumNormalGreen.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.knumNormalGreen.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.knumNormalGreen.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumNormalGreen.TabIndex = 103;
            this.knumNormalGreen.ValueChanged += new System.EventHandler(this.KnumNormalGreen_ValueChanged);
            // 
            // knumNormalBlue
            // 
            this.knumNormalBlue.Location = new System.Drawing.Point(505, 399);
            this.knumNormalBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumNormalBlue.Name = "knumNormalBlue";
            this.knumNormalBlue.Size = new System.Drawing.Size(94, 26);
            this.knumNormalBlue.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.knumNormalBlue.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.knumNormalBlue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.knumNormalBlue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumNormalBlue.TabIndex = 102;
            this.knumNormalBlue.ValueChanged += new System.EventHandler(this.KnumNormalBlue_ValueChanged);
            // 
            // knumRed
            // 
            this.knumRed.Location = new System.Drawing.Point(505, 283);
            this.knumRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumRed.Name = "knumRed";
            this.knumRed.Size = new System.Drawing.Size(94, 26);
            this.knumRed.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knumRed.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumRed.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.knumRed.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumRed.TabIndex = 89;
            this.knumRed.ValueChanged += new System.EventHandler(this.KnumRed_ValueChanged);
            // 
            // knumNormalRed
            // 
            this.knumNormalRed.Location = new System.Drawing.Point(505, 283);
            this.knumNormalRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumNormalRed.Name = "knumNormalRed";
            this.knumNormalRed.Size = new System.Drawing.Size(94, 26);
            this.knumNormalRed.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.knumNormalRed.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.knumNormalRed.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.knumNormalRed.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumNormalRed.TabIndex = 101;
            this.knumNormalRed.ValueChanged += new System.EventHandler(this.KnumNormalRed_ValueChanged);
            // 
            // kryptonBlueValueLabel1
            // 
            this.kryptonBlueValueLabel1.Location = new System.Drawing.Point(449, 399);
            this.kryptonBlueValueLabel1.Name = "kryptonBlueValueLabel1";
            this.kryptonBlueValueLabel1.RedValue = 255;
            this.kryptonBlueValueLabel1.Size = new System.Drawing.Size(50, 26);
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.TabIndex = 5;
            this.kryptonBlueValueLabel1.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.Values.Text = "Blue:";
            // 
            // kryptonGreenValueLabel1
            // 
            this.kryptonGreenValueLabel1.Location = new System.Drawing.Point(437, 336);
            this.kryptonGreenValueLabel1.Name = "kryptonGreenValueLabel1";
            this.kryptonGreenValueLabel1.RedValue = 255;
            this.kryptonGreenValueLabel1.Size = new System.Drawing.Size(62, 26);
            this.kryptonGreenValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.kryptonGreenValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel1.TabIndex = 5;
            this.kryptonGreenValueLabel1.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonGreenValueLabel1.Values.Text = "Green:";
            // 
            // kryptonRedValueLabel1
            // 
            this.kryptonRedValueLabel1.Location = new System.Drawing.Point(453, 283);
            this.kryptonRedValueLabel1.Name = "kryptonRedValueLabel1";
            this.kryptonRedValueLabel1.RedValue = 255;
            this.kryptonRedValueLabel1.Size = new System.Drawing.Size(46, 26);
            this.kryptonRedValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.TabIndex = 5;
            this.kryptonRedValueLabel1.TextSize = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.Values.Text = "Red:";
            // 
            // klblNormalBlue
            // 
            this.klblNormalBlue.Location = new System.Drawing.Point(449, 399);
            this.klblNormalBlue.Name = "klblNormalBlue";
            this.klblNormalBlue.Size = new System.Drawing.Size(50, 26);
            this.klblNormalBlue.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblNormalBlue.TabIndex = 100;
            this.klblNormalBlue.Values.Text = "Blue:";
            // 
            // klblNormalGreen
            // 
            this.klblNormalGreen.Location = new System.Drawing.Point(437, 336);
            this.klblNormalGreen.Name = "klblNormalGreen";
            this.klblNormalGreen.Size = new System.Drawing.Size(62, 26);
            this.klblNormalGreen.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblNormalGreen.TabIndex = 99;
            this.klblNormalGreen.Values.Text = "Green:";
            // 
            // klblNormalRed
            // 
            this.klblNormalRed.Location = new System.Drawing.Point(449, 283);
            this.klblNormalRed.Name = "klblNormalRed";
            this.klblNormalRed.Size = new System.Drawing.Size(46, 26);
            this.klblNormalRed.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblNormalRed.TabIndex = 98;
            this.klblNormalRed.Values.Text = "Red:";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(437, 231);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(62, 26);
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.TabIndex = 97;
            this.kryptonLabel6.Values.Text = "Alpha:";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(306, 399);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(27, 26);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 96;
            this.kryptonLabel5.Values.Text = "B:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(306, 336);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(26, 26);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 95;
            this.kryptonLabel4.Values.Text = "S:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(306, 283);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(29, 26);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 94;
            this.kryptonLabel3.Values.Text = "H:";
            // 
            // knumBrightness
            // 
            this.knumBrightness.Location = new System.Drawing.Point(341, 399);
            this.knumBrightness.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumBrightness.Name = "knumBrightness";
            this.knumBrightness.Size = new System.Drawing.Size(91, 26);
            this.knumBrightness.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.knumBrightness.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.knumBrightness.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.knumBrightness.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumBrightness.TabIndex = 93;
            this.knumBrightness.ValueChanged += new System.EventHandler(this.KnumBrightness_ValueChanged);
            // 
            // knumHue
            // 
            this.knumHue.Location = new System.Drawing.Point(341, 283);
            this.knumHue.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.knumHue.Name = "knumHue";
            this.knumHue.Size = new System.Drawing.Size(91, 26);
            this.knumHue.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.knumHue.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.knumHue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.knumHue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumHue.TabIndex = 91;
            this.knumHue.ValueChanged += new System.EventHandler(this.KnumHue_ValueChanged);
            // 
            // knumSaturation
            // 
            this.knumSaturation.Location = new System.Drawing.Point(341, 336);
            this.knumSaturation.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumSaturation.Name = "knumSaturation";
            this.knumSaturation.Size = new System.Drawing.Size(91, 26);
            this.knumSaturation.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.knumSaturation.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.knumSaturation.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.knumSaturation.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumSaturation.TabIndex = 92;
            this.knumSaturation.ValueChanged += new System.EventHandler(this.KnumSaturation_ValueChanged);
            // 
            // knumAlpha
            // 
            this.knumAlpha.Location = new System.Drawing.Point(505, 231);
            this.knumAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumAlpha.Name = "knumAlpha";
            this.knumAlpha.Size = new System.Drawing.Size(94, 26);
            this.knumAlpha.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.knumAlpha.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.knumAlpha.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.knumAlpha.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumAlpha.TabIndex = 5;
            this.knumAlpha.ValueChanged += new System.EventHandler(this.KnumAlpha_ValueChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(341, 56);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(138, 26);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 88;
            this.kryptonLabel2.Values.Text = "Selected Colour:";
            // 
            // ktbHexadecimalColourValue
            // 
            this.ktbHexadecimalColourValue.Hint = "#000000";
            this.ktbHexadecimalColourValue.Location = new System.Drawing.Point(423, 152);
            this.ktbHexadecimalColourValue.MaxLength = 7;
            this.ktbHexadecimalColourValue.Name = "ktbHexadecimalColourValue";
            this.ktbHexadecimalColourValue.Size = new System.Drawing.Size(176, 29);
            this.ktbHexadecimalColourValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktbHexadecimalColourValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktbHexadecimalColourValue.TabIndex = 87;
            this.ktbHexadecimalColourValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ktbHexadecimalColourValue.TextChanged += new System.EventHandler(this.KtbHexadecimalColourValue_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(245, 154);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(172, 26);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 86;
            this.kryptonLabel1.Values.Text = "Hexadecimal Colour:";
            // 
            // cpbSelectedColour
            // 
            this.cpbSelectedColour.BackColor = System.Drawing.Color.Transparent;
            this.cpbSelectedColour.Location = new System.Drawing.Point(485, 12);
            this.cpbSelectedColour.Name = "cpbSelectedColour";
            this.cpbSelectedColour.Size = new System.Drawing.Size(114, 114);
            this.cpbSelectedColour.TabIndex = 5;
            this.cpbSelectedColour.TabStop = false;
            this.cpbSelectedColour.BackColorChanged += new System.EventHandler(this.CpbSelectedColour_BackColorChanged);
            // 
            // cwColours
            // 
            this.cwColours.BackColor = System.Drawing.Color.Transparent;
            this.cwColours.Location = new System.Drawing.Point(12, 12);
            this.cwColours.Name = "cwColours";
            this.cwColours.Size = new System.Drawing.Size(247, 190);
            this.cwColours.TabIndex = 5;
            this.cwColours.ColourChanged += new System.EventHandler(this.CwColours_ColourChanged);
            // 
            // kbtnCustomColours
            // 
            this.kbtnCustomColours.Location = new System.Drawing.Point(12, 272);
            this.kbtnCustomColours.Name = "kbtnCustomColours";
            this.kbtnCustomColours.Size = new System.Drawing.Size(190, 28);
            this.kbtnCustomColours.StateCommon.Content.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCustomColours.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCustomColours.TabIndex = 106;
            this.kbtnCustomColours.Values.Text = "C&stom Colours...";
            this.kbtnCustomColours.Click += new System.EventHandler(this.KbtnCustomColours_Click);
            // 
            // KryptonColourButtonCustomColourDialog
            // 
            this.ClientSize = new System.Drawing.Size(611, 500);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonColourButtonCustomColourDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.KryptonColourButtonCustomColourDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbSelectedColour)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Color _colour, _hsbValue;

        private Timer _tmrARGB, _tmrHSB, _tmrFillColourValues;
        #endregion

        #region Properties
        public Color Colour { get => _colour; set => _colour = value; }

        public Color HSBValue { get => _hsbValue; set => _hsbValue = value; }
        #endregion

        #region Constructors
        public KryptonColourButtonCustomColourDialog()
        {
            InitializeComponent();

            cwColours.Colour = Color.White;

            _tmrFillColourValues = new Timer();

            _tmrFillColourValues.Enabled = true;

            _tmrFillColourValues.Interval = 250;

            _tmrFillColourValues.Tick += FillColourValues_Tick;
        }

        public KryptonColourButtonCustomColourDialog(Color colour)
        {
            InitializeComponent();

            cwColours.Colour = colour;

            _tmrFillColourValues = new Timer();

            _tmrFillColourValues.Enabled = true;

            _tmrFillColourValues.Interval = 250;

            _tmrFillColourValues.Tick += FillColourValues_Tick;
        }
        #endregion

        #region Event Handlers
        private void KryptonColourButtonCustomColourDialog_Load(object sender, EventArgs e)
        {

        }

        private void CwColours_ColourChanged(object sender, EventArgs e)
        {
            SetColour(cwColours.Colour);

            SetHSBValue(ColourExtensions.FromAHSB(Colour.A, Colour.GetHue(), Colour.GetSaturation(), Colour.GetBrightness()));

            UpdateColourValues();
        }

        private void CgColours_ColorChanged(object sender, EventArgs e)
        {

        }

        private void KnumAlpha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void KnumRed_ValueChanged(object sender, EventArgs e)
        {

        }

        private void KnumGreen_ValueChanged(object sender, EventArgs e)
        {

        }

        private void KnumBlue_ValueChanged(object sender, EventArgs e)
        {

        }

        private void KnumNormalRed_ValueChanged(object sender, EventArgs e)
        {

        }

        private void KnumNormalGreen_ValueChanged(object sender, EventArgs e)
        {

        }

        private void KnumNormalBlue_ValueChanged(object sender, EventArgs e)
        {

        }

        private void KnumHue_ValueChanged(object sender, EventArgs e)
        {
            cpbSelectedColour.BackColor = CreateHSBColour(knumHue.Value, knumSaturation.Value, knumBrightness.Value);
        }

        private void KnumSaturation_ValueChanged(object sender, EventArgs e)
        {
            cpbSelectedColour.BackColor = CreateHSBColour(knumHue.Value, knumSaturation.Value, knumBrightness.Value);
        }

        private void KnumBrightness_ValueChanged(object sender, EventArgs e)
        {
            cpbSelectedColour.BackColor = CreateHSBColour(knumHue.Value, knumSaturation.Value, knumBrightness.Value);
        }

        private void KbtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }

        private void KbtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void KtbHexadecimalColourValue_TextChanged(object sender, EventArgs e)
        {
            if (ktbHexadecimalColourValue.Text.Length == 4 || ktbHexadecimalColourValue.Text.Length == 7)
            {
                cwColours.Colour = ColourExtensions.ColourFromHexadecimal(ktbHexadecimalColourValue.Text);
            }
        }

        private void KbtnLoadColourPalette_Click(object sender, EventArgs e)
        {

        }

        private void KbtnSaveColourPalette_Click(object sender, EventArgs e)
        {

        }

        private void CpbSelectedColour_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void FillColourValues_Tick(object sender, EventArgs e)
        {
            FillHSB(HSBValue);

            FillRGB();

            _tmrFillColourValues.Stop();
        }

        private void KbtnCustomColours_Click(object sender, EventArgs e)
        {
            ColourGridWindow cgw = new ColourGridWindow(cwColours.Colour);

            cgw.Show();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Populates the R, G and B boxes.
        /// </summary>
        private void FillRGB()
        {
            if (Colour != Color.Empty)
            {
                knumNormalRed.Value = Colour.R;

                knumRed.Value = Colour.R;

                knumNormalGreen.Value = Colour.G;

                knumGreen.Value = Colour.G;

                knumNormalBlue.Value = Colour.B;
            }
        }

        /// <summary>
        /// Fills the HSB.
        /// </summary>
        /// <param name="hSBValue">The HSB value.</param>
        private void FillHSB(Color hSBValue)
        {
            knumAlpha.Value = hSBValue.A;

            knumHue.Value = (decimal)hSBValue.GetHue();

            knumSaturation.Value = (decimal)hSBValue.GetSaturation();

            knumBrightness.Value = (decimal)hSBValue.GetBrightness();
        }

        /// <summary>
        /// Creates the HSB colour.
        /// </summary>
        /// <param name="hue">The hue.</param>
        /// <param name="saturation">The saturation.</param>
        /// <param name="brightness">The brightness.</param>
        /// <returns></returns>
        private Color CreateHSBColour(decimal hue, decimal saturation, decimal brightness)
        {
            int alpha = Convert.ToInt32(knumAlpha.Value);

            float h = Convert.ToSingle(hue), s = Convert.ToSingle(saturation), b = Convert.ToSingle(brightness);

            return ColourExtensions.FromAHSB(alpha, h, s, b);
        }

        private void UpdateColourValues()
        {
            FillHSB(HSBValue);

            FillRGB();
        }
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the Colour.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetColour(Color value) => Colour = value;

        /// <summary>
        /// Gets the Colour.
        /// </summary>
        /// <returns>The value of Colour.</returns>
        public Color GetColour() => Colour;

        /// <summary>
        /// Sets the HSBValue.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetHSBValue(Color value) => HSBValue = value;

        /// <summary>
        /// Gets the HSBValue.
        /// </summary>
        /// <returns>The value of HSBValue.</returns>
        public Color GetHSBValue() => HSBValue;
        #endregion
    }
}