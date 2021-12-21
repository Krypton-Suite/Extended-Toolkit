#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public partial class DefineIndividualColoursDialog : KryptonForm
    {
        #region Design Code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kManager = new Krypton.Toolkit.KryptonManager(this.components);
            this.kPal = new Krypton.Toolkit.KryptonPalette(this.components);
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.ktbHexadecimal = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kbtnGenerateAlpha = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateRedValue = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateGreenValue = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateBlueValue = new Krypton.Toolkit.KryptonButton();
            this.kcmbDefinedColour = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnExportSelectedColour = new Krypton.Toolkit.KryptonButton();
            this.ktbRed = new Krypton.Toolkit.KryptonTrackBar();
            this.ktbGreen = new Krypton.Toolkit.KryptonTrackBar();
            this.ktbBlue = new Krypton.Toolkit.KryptonTrackBar();
            this.ktbAlpha = new Krypton.Toolkit.KryptonTrackBar();
            this.knumAlphaChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel10 = new Krypton.Toolkit.KryptonLabel();
            this.knumBlueChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knumGreenChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knumRedChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.cpbLightestColourPreview = new Krypton.Toolkit.Suite.Extended.Core.CircularPictureBox();
            this.cpbLightColourPreview = new Krypton.Toolkit.Suite.Extended.Core.CircularPictureBox();
            this.kryptonLabel16 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel15 = new Krypton.Toolkit.KryptonLabel();
            this.cpbDarkestColourPreview = new Krypton.Toolkit.Suite.Extended.Core.CircularPictureBox();
            this.kryptonLabel12 = new Krypton.Toolkit.KryptonLabel();
            this.cpbMiddleColourPreview = new Krypton.Toolkit.Suite.Extended.Core.CircularPictureBox();
            this.kryptonLabel13 = new Krypton.Toolkit.KryptonLabel();
            this.cpbBaseColourPreview = new Krypton.Toolkit.Suite.Extended.Core.CircularPictureBox();
            this.kryptonLabel14 = new Krypton.Toolkit.KryptonLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ttInformation = new System.Windows.Forms.ToolTip(this.components);
            this.tmrUpdateUI = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbDefinedColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbLightestColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbLightColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbDarkestColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbMiddleColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbBaseColourPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // kManager
            // 
            this.kManager.GlobalPalette = this.kPal;
            this.kManager.GlobalPaletteMode = Krypton.Toolkit.PaletteModeManager.Custom;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.ktbHexadecimal);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 581);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(754, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnOk
            // 
            this.kbtnOk.AutoSize = true;
            this.kbtnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnOk.Location = new System.Drawing.Point(710, 8);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(32, 30);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.TabIndex = 101;
            this.kbtnOk.Values.Text = "&Ok";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // ktbHexadecimal
            // 
            this.ktbHexadecimal.Location = new System.Drawing.Point(210, 11);
            this.ktbHexadecimal.MaxLength = 7;
            this.ktbHexadecimal.Name = "ktbHexadecimal";
            this.ktbHexadecimal.Size = new System.Drawing.Size(176, 29);
            this.ktbHexadecimal.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktbHexadecimal.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktbHexadecimal.TabIndex = 85;
            this.ktbHexadecimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ktbHexadecimal.TextChanged += new System.EventHandler(this.ktbHexadecimal_TextChanged);
            this.ktbHexadecimal.MouseHover += new System.EventHandler(this.ktbHexadecimal_MouseHover);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(17, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(187, 26);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 84;
            this.kryptonLabel1.Values.Text = "Hexadecimal Colour: #";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel2.Controls.Add(this.kcmbDefinedColour);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel2.Controls.Add(this.kbtnExportSelectedColour);
            this.kryptonPanel2.Controls.Add(this.ktbRed);
            this.kryptonPanel2.Controls.Add(this.ktbGreen);
            this.kryptonPanel2.Controls.Add(this.ktbBlue);
            this.kryptonPanel2.Controls.Add(this.ktbAlpha);
            this.kryptonPanel2.Controls.Add(this.knumAlphaChannelValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel10);
            this.kryptonPanel2.Controls.Add(this.knumBlueChannelValue);
            this.kryptonPanel2.Controls.Add(this.knumGreenChannelValue);
            this.kryptonPanel2.Controls.Add(this.knumRedChannelValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.cpbLightestColourPreview);
            this.kryptonPanel2.Controls.Add(this.cpbLightColourPreview);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel16);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel15);
            this.kryptonPanel2.Controls.Add(this.cpbDarkestColourPreview);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel12);
            this.kryptonPanel2.Controls.Add(this.cpbMiddleColourPreview);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel13);
            this.kryptonPanel2.Controls.Add(this.cpbBaseColourPreview);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel14);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(754, 581);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Enabled = false;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(588, 49);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kbtnGenerateAlpha);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kbtnGenerateRedValue);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kbtnGenerateGreenValue);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kbtnGenerateBlueValue);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(154, 197);
            this.kryptonGroupBox1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonGroupBox1.TabIndex = 102;
            this.kryptonGroupBox1.Values.Heading = "Colour Options";
            // 
            // kbtnGenerateAlpha
            // 
            this.kbtnGenerateAlpha.AutoSize = true;
            this.kbtnGenerateAlpha.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateAlpha.Location = new System.Drawing.Point(13, 14);
            this.kbtnGenerateAlpha.Name = "kbtnGenerateAlpha";
            this.kbtnGenerateAlpha.Size = new System.Drawing.Size(125, 30);
            this.kbtnGenerateAlpha.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateAlpha.TabIndex = 101;
            this.kbtnGenerateAlpha.Values.Text = "Generate &Alpha";
            this.kbtnGenerateAlpha.Click += new System.EventHandler(this.kbtnGenerateAlpha_Click);
            // 
            // kbtnGenerateRedValue
            // 
            this.kbtnGenerateRedValue.AutoSize = true;
            this.kbtnGenerateRedValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateRedValue.Location = new System.Drawing.Point(13, 52);
            this.kbtnGenerateRedValue.Name = "kbtnGenerateRedValue";
            this.kbtnGenerateRedValue.Size = new System.Drawing.Size(111, 30);
            this.kbtnGenerateRedValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedValue.TabIndex = 91;
            this.kbtnGenerateRedValue.Values.Text = "Generate &Red";
            this.kbtnGenerateRedValue.Click += new System.EventHandler(this.kbtnGenerateRedValue_Click);
            // 
            // kbtnGenerateGreenValue
            // 
            this.kbtnGenerateGreenValue.AutoSize = true;
            this.kbtnGenerateGreenValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateGreenValue.Location = new System.Drawing.Point(13, 90);
            this.kbtnGenerateGreenValue.Name = "kbtnGenerateGreenValue";
            this.kbtnGenerateGreenValue.Size = new System.Drawing.Size(126, 30);
            this.kbtnGenerateGreenValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenValue.TabIndex = 92;
            this.kbtnGenerateGreenValue.Values.Text = "Generate &Green";
            this.kbtnGenerateGreenValue.Click += new System.EventHandler(this.kbtnGenerateGreenValue_Click);
            // 
            // kbtnGenerateBlueValue
            // 
            this.kbtnGenerateBlueValue.AutoSize = true;
            this.kbtnGenerateBlueValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateBlueValue.Location = new System.Drawing.Point(13, 128);
            this.kbtnGenerateBlueValue.Name = "kbtnGenerateBlueValue";
            this.kbtnGenerateBlueValue.Size = new System.Drawing.Size(114, 30);
            this.kbtnGenerateBlueValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueValue.TabIndex = 93;
            this.kbtnGenerateBlueValue.Values.Text = "Generate &Blue";
            this.kbtnGenerateBlueValue.Click += new System.EventHandler(this.kbtnGenerateBlueValue_Click);
            // 
            // kcmbDefinedColour
            // 
            this.kcmbDefinedColour.AutoCompleteCustomSource.AddRange(new string[] {
            "Base Colour",
            "Darkest Colour",
            "Middle Colour",
            "Light Colour",
            "Lightest Colour"});
            this.kcmbDefinedColour.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbDefinedColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbDefinedColour.DropDownWidth = 173;
            this.kcmbDefinedColour.IntegralHeight = false;
            this.kcmbDefinedColour.Items.AddRange(new object[] {
            "Base Colour",
            "Darkest Colour",
            "Middle Colour",
            "Light Colour",
            "Lightest Colour"});
            this.kcmbDefinedColour.Location = new System.Drawing.Point(291, 531);
            this.kcmbDefinedColour.Name = "kcmbDefinedColour";
            this.kcmbDefinedColour.Size = new System.Drawing.Size(173, 27);
            this.kcmbDefinedColour.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbDefinedColour.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbDefinedColour.TabIndex = 31;
            this.kcmbDefinedColour.SelectedIndexChanged += new System.EventHandler(this.kcmbDefinedColour_SelectedIndexChanged);
            this.kcmbDefinedColour.TextChanged += new System.EventHandler(this.kcmbDefinedColour_TextChanged);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(162, 530);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(123, 26);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 30;
            this.kryptonLabel5.Values.Text = "Define Colour:";
            // 
            // kbtnExportSelectedColour
            // 
            this.kbtnExportSelectedColour.AutoSize = true;
            this.kbtnExportSelectedColour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnExportSelectedColour.Enabled = false;
            this.kbtnExportSelectedColour.Location = new System.Drawing.Point(565, 531);
            this.kbtnExportSelectedColour.Name = "kbtnExportSelectedColour";
            this.kbtnExportSelectedColour.Size = new System.Drawing.Size(177, 30);
            this.kbtnExportSelectedColour.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnExportSelectedColour.TabIndex = 100;
            this.kbtnExportSelectedColour.Values.Text = "&Export Selected Colour";
            this.kbtnExportSelectedColour.Click += new System.EventHandler(this.kbtnExportSelectedColour_Click);
            // 
            // ktbRed
            // 
            this.ktbRed.DrawBackground = true;
            this.ktbRed.Enabled = false;
            this.ktbRed.Location = new System.Drawing.Point(340, 44);
            this.ktbRed.Maximum = 255;
            this.ktbRed.Name = "ktbRed";
            this.ktbRed.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktbRed.Size = new System.Drawing.Size(21, 430);
            this.ktbRed.StateCommon.Tick.Color1 = System.Drawing.Color.Red;
            this.ktbRed.StateCommon.Track.Color1 = System.Drawing.Color.Red;
            this.ktbRed.StateCommon.Track.Color2 = System.Drawing.Color.Red;
            this.ktbRed.StateCommon.Track.Color3 = System.Drawing.Color.Red;
            this.ktbRed.StateCommon.Track.Color4 = System.Drawing.Color.Red;
            this.ktbRed.StateCommon.Track.Color5 = System.Drawing.Color.Red;
            this.ktbRed.TabIndex = 99;
            this.ktbRed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktbRed.ValueChanged += new System.EventHandler(this.ktbRed_ValueChanged);
            // 
            // ktbGreen
            // 
            this.ktbGreen.DrawBackground = true;
            this.ktbGreen.Enabled = false;
            this.ktbGreen.Location = new System.Drawing.Point(438, 44);
            this.ktbGreen.Maximum = 255;
            this.ktbGreen.Name = "ktbGreen";
            this.ktbGreen.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktbGreen.Size = new System.Drawing.Size(21, 430);
            this.ktbGreen.StateCommon.Tick.Color1 = System.Drawing.Color.Green;
            this.ktbGreen.StateCommon.Track.Color1 = System.Drawing.Color.Green;
            this.ktbGreen.StateCommon.Track.Color2 = System.Drawing.Color.Green;
            this.ktbGreen.StateCommon.Track.Color3 = System.Drawing.Color.Green;
            this.ktbGreen.StateCommon.Track.Color4 = System.Drawing.Color.Green;
            this.ktbGreen.StateCommon.Track.Color5 = System.Drawing.Color.Green;
            this.ktbGreen.TabIndex = 98;
            this.ktbGreen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktbGreen.ValueChanged += new System.EventHandler(this.ktbGreen_ValueChanged);
            // 
            // ktbBlue
            // 
            this.ktbBlue.DrawBackground = true;
            this.ktbBlue.Enabled = false;
            this.ktbBlue.Location = new System.Drawing.Point(529, 44);
            this.ktbBlue.Maximum = 255;
            this.ktbBlue.Name = "ktbBlue";
            this.ktbBlue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktbBlue.Size = new System.Drawing.Size(21, 430);
            this.ktbBlue.StateCommon.Tick.Color1 = System.Drawing.Color.Blue;
            this.ktbBlue.StateCommon.Track.Color1 = System.Drawing.Color.Blue;
            this.ktbBlue.StateCommon.Track.Color2 = System.Drawing.Color.Blue;
            this.ktbBlue.StateCommon.Track.Color3 = System.Drawing.Color.Blue;
            this.ktbBlue.StateCommon.Track.Color4 = System.Drawing.Color.Blue;
            this.ktbBlue.StateCommon.Track.Color5 = System.Drawing.Color.Blue;
            this.ktbBlue.TabIndex = 97;
            this.ktbBlue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktbBlue.ValueChanged += new System.EventHandler(this.ktbBlue_ValueChanged);
            // 
            // ktbAlpha
            // 
            this.ktbAlpha.DrawBackground = true;
            this.ktbAlpha.Enabled = false;
            this.ktbAlpha.Location = new System.Drawing.Point(234, 44);
            this.ktbAlpha.Maximum = 255;
            this.ktbAlpha.Name = "ktbAlpha";
            this.ktbAlpha.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktbAlpha.Size = new System.Drawing.Size(21, 430);
            this.ktbAlpha.TabIndex = 96;
            this.ktbAlpha.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktbAlpha.Value = 255;
            this.ktbAlpha.ValueChanged += new System.EventHandler(this.ktbAlpha_ValueChanged);
            // 
            // knumAlphaChannelValue
            // 
            this.knumAlphaChannelValue.Enabled = false;
            this.knumAlphaChannelValue.Location = new System.Drawing.Point(214, 480);
            this.knumAlphaChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumAlphaChannelValue.Name = "knumAlphaChannelValue";
            this.knumAlphaChannelValue.Size = new System.Drawing.Size(62, 28);
            this.knumAlphaChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumAlphaChannelValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumAlphaChannelValue.TabIndex = 95;
            this.knumAlphaChannelValue.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumAlphaChannelValue.ValueChanged += new System.EventHandler(this.knumAlphaChannelValue_ValueChanged);
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Enabled = false;
            this.kryptonLabel10.Location = new System.Drawing.Point(214, 12);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(62, 26);
            this.kryptonLabel10.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel10.TabIndex = 94;
            this.kryptonLabel10.Values.Text = "Alpha:";
            // 
            // knumBlueChannelValue
            // 
            this.knumBlueChannelValue.Enabled = false;
            this.knumBlueChannelValue.Location = new System.Drawing.Point(507, 480);
            this.knumBlueChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumBlueChannelValue.Name = "knumBlueChannelValue";
            this.knumBlueChannelValue.Size = new System.Drawing.Size(62, 28);
            this.knumBlueChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knumBlueChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumBlueChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumBlueChannelValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumBlueChannelValue.TabIndex = 90;
            this.knumBlueChannelValue.ValueChanged += new System.EventHandler(this.knumBlueChannelValue_ValueChanged);
            // 
            // knumGreenChannelValue
            // 
            this.knumGreenChannelValue.Enabled = false;
            this.knumGreenChannelValue.Location = new System.Drawing.Point(415, 480);
            this.knumGreenChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumGreenChannelValue.Name = "knumGreenChannelValue";
            this.knumGreenChannelValue.Size = new System.Drawing.Size(62, 28);
            this.knumGreenChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Lime;
            this.knumGreenChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumGreenChannelValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumGreenChannelValue.TabIndex = 89;
            this.knumGreenChannelValue.ValueChanged += new System.EventHandler(this.knumGreenChannelValue_ValueChanged);
            // 
            // knumRedChannelValue
            // 
            this.knumRedChannelValue.Enabled = false;
            this.knumRedChannelValue.Location = new System.Drawing.Point(324, 480);
            this.knumRedChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumRedChannelValue.Name = "knumRedChannelValue";
            this.knumRedChannelValue.Size = new System.Drawing.Size(62, 28);
            this.knumRedChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knumRedChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumRedChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumRedChannelValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumRedChannelValue.TabIndex = 88;
            this.knumRedChannelValue.ValueChanged += new System.EventHandler(this.knumRedChannelValue_ValueChanged);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Enabled = false;
            this.kryptonLabel4.Location = new System.Drawing.Point(513, 12);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(50, 26);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 87;
            this.kryptonLabel4.Values.Text = "Blue:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Enabled = false;
            this.kryptonLabel3.Location = new System.Drawing.Point(415, 12);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(62, 26);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 86;
            this.kryptonLabel3.Values.Text = "Green:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Enabled = false;
            this.kryptonLabel2.Location = new System.Drawing.Point(327, 12);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(46, 26);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 85;
            this.kryptonLabel2.Values.Text = "Red:";
            // 
            // cpbLightestColourPreview
            // 
            this.cpbLightestColourPreview.BackColor = System.Drawing.Color.White;
            this.cpbLightestColourPreview.Location = new System.Drawing.Point(43, 497);
            this.cpbLightestColourPreview.Name = "cpbLightestColourPreview";
            this.cpbLightestColourPreview.Size = new System.Drawing.Size(64, 64);
            this.cpbLightestColourPreview.TabIndex = 81;
            this.cpbLightestColourPreview.TabStop = false;
            this.cpbLightestColourPreview.ToolTipValues = null;
            this.cpbLightestColourPreview.Click += new System.EventHandler(this.cpbLightestColourPreview_Click);
            this.cpbLightestColourPreview.MouseHover += new System.EventHandler(this.cpbLightestColourPreview_MouseHover);
            // 
            // cpbLightColourPreview
            // 
            this.cpbLightColourPreview.BackColor = System.Drawing.Color.White;
            this.cpbLightColourPreview.Location = new System.Drawing.Point(43, 385);
            this.cpbLightColourPreview.Name = "cpbLightColourPreview";
            this.cpbLightColourPreview.Size = new System.Drawing.Size(64, 64);
            this.cpbLightColourPreview.TabIndex = 84;
            this.cpbLightColourPreview.TabStop = false;
            this.cpbLightColourPreview.ToolTipValues = null;
            this.cpbLightColourPreview.Click += new System.EventHandler(this.cpbLightColourPreview_Click);
            this.cpbLightColourPreview.MouseHover += new System.EventHandler(this.cpbLightColourPreview_MouseHover);
            // 
            // kryptonLabel16
            // 
            this.kryptonLabel16.Location = new System.Drawing.Point(17, 460);
            this.kryptonLabel16.Name = "kryptonLabel16";
            this.kryptonLabel16.Size = new System.Drawing.Size(130, 26);
            this.kryptonLabel16.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel16.TabIndex = 83;
            this.kryptonLabel16.Values.Text = "Lightest Colour";
            // 
            // kryptonLabel15
            // 
            this.kryptonLabel15.Location = new System.Drawing.Point(24, 348);
            this.kryptonLabel15.Name = "kryptonLabel15";
            this.kryptonLabel15.Size = new System.Drawing.Size(108, 26);
            this.kryptonLabel15.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel15.TabIndex = 82;
            this.kryptonLabel15.Values.Text = "Light Colour";
            // 
            // cpbDarkestColourPreview
            // 
            this.cpbDarkestColourPreview.BackColor = System.Drawing.Color.White;
            this.cpbDarkestColourPreview.Location = new System.Drawing.Point(43, 161);
            this.cpbDarkestColourPreview.Name = "cpbDarkestColourPreview";
            this.cpbDarkestColourPreview.Size = new System.Drawing.Size(64, 64);
            this.cpbDarkestColourPreview.TabIndex = 80;
            this.cpbDarkestColourPreview.TabStop = false;
            this.cpbDarkestColourPreview.ToolTipValues = null;
            this.cpbDarkestColourPreview.Click += new System.EventHandler(this.cpbDarkestColourPreview_Click);
            this.cpbDarkestColourPreview.MouseHover += new System.EventHandler(this.cpbDarkestColourPreview_MouseHover);
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Location = new System.Drawing.Point(28, 12);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(104, 26);
            this.kryptonLabel12.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel12.TabIndex = 76;
            this.kryptonLabel12.Values.Text = "Base Colour";
            // 
            // cpbMiddleColourPreview
            // 
            this.cpbMiddleColourPreview.BackColor = System.Drawing.Color.White;
            this.cpbMiddleColourPreview.Location = new System.Drawing.Point(43, 273);
            this.cpbMiddleColourPreview.Name = "cpbMiddleColourPreview";
            this.cpbMiddleColourPreview.Size = new System.Drawing.Size(64, 64);
            this.cpbMiddleColourPreview.TabIndex = 79;
            this.cpbMiddleColourPreview.TabStop = false;
            this.cpbMiddleColourPreview.ToolTipValues = null;
            this.cpbMiddleColourPreview.Click += new System.EventHandler(this.cpbMiddleColourPreview_Click);
            this.cpbMiddleColourPreview.MouseHover += new System.EventHandler(this.cpbMiddleColourPreview_MouseHover);
            // 
            // kryptonLabel13
            // 
            this.kryptonLabel13.Location = new System.Drawing.Point(17, 124);
            this.kryptonLabel13.Name = "kryptonLabel13";
            this.kryptonLabel13.Size = new System.Drawing.Size(127, 26);
            this.kryptonLabel13.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel13.TabIndex = 77;
            this.kryptonLabel13.Values.Text = "Darkest Colour";
            // 
            // cpbBaseColourPreview
            // 
            this.cpbBaseColourPreview.BackColor = System.Drawing.Color.White;
            this.cpbBaseColourPreview.Location = new System.Drawing.Point(43, 49);
            this.cpbBaseColourPreview.Name = "cpbBaseColourPreview";
            this.cpbBaseColourPreview.Size = new System.Drawing.Size(64, 64);
            this.cpbBaseColourPreview.TabIndex = 75;
            this.cpbBaseColourPreview.TabStop = false;
            this.cpbBaseColourPreview.ToolTipValues = null;
            this.cpbBaseColourPreview.Click += new System.EventHandler(this.cpbBaseColourPreview_Click);
            this.cpbBaseColourPreview.MouseHover += new System.EventHandler(this.cpbBaseColourPreview_MouseHover);
            // 
            // kryptonLabel14
            // 
            this.kryptonLabel14.Location = new System.Drawing.Point(17, 236);
            this.kryptonLabel14.Name = "kryptonLabel14";
            this.kryptonLabel14.Size = new System.Drawing.Size(122, 26);
            this.kryptonLabel14.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel14.TabIndex = 78;
            this.kryptonLabel14.Values.Text = "Middle Colour";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 578);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 3);
            this.panel1.TabIndex = 2;
            // 
            // tmrUpdateUI
            // 
            this.tmrUpdateUI.Enabled = true;
            this.tmrUpdateUI.Interval = 250;
            this.tmrUpdateUI.Tick += new System.EventHandler(this.tmrUpdateUI_Tick);
            // 
            // DefineIndividualColoursDialog
            // 
            this.AcceptButton = this.kbtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 631);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DefineIndividualColoursDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Define Individual Colours";
            this.Load += new System.EventHandler(this.DefineIndividualColoursDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbDefinedColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbLightestColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbLightColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbDarkestColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbMiddleColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbBaseColourPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonManager kManager;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.Panel panel1;
        private CircularPictureBox cpbDarkestColourPreview;
        private Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private CircularPictureBox cpbMiddleColourPreview;
        private Krypton.Toolkit.KryptonLabel kryptonLabel13;
        private CircularPictureBox cpbBaseColourPreview;
        private Krypton.Toolkit.KryptonLabel kryptonLabel14;
        private CircularPictureBox cpbLightestColourPreview;
        private CircularPictureBox cpbLightColourPreview;
        private Krypton.Toolkit.KryptonLabel kryptonLabel16;
        private Krypton.Toolkit.KryptonLabel kryptonLabel15;
        private Krypton.Toolkit.KryptonPalette kPal;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonTrackBar ktbRed;
        private Krypton.Toolkit.KryptonTrackBar ktbGreen;
        private Krypton.Toolkit.KryptonTrackBar ktbBlue;
        private Krypton.Toolkit.KryptonTrackBar ktbAlpha;
        private Krypton.Toolkit.KryptonNumericUpDown knumAlphaChannelValue;
        private Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private Krypton.Toolkit.KryptonButton kbtnGenerateBlueValue;
        private Krypton.Toolkit.KryptonButton kbtnGenerateGreenValue;
        private Krypton.Toolkit.KryptonButton kbtnGenerateRedValue;
        private Krypton.Toolkit.KryptonNumericUpDown knumBlueChannelValue;
        private Krypton.Toolkit.KryptonNumericUpDown knumGreenChannelValue;
        private Krypton.Toolkit.KryptonNumericUpDown knumRedChannelValue;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonButton kbtnOk;
        private Krypton.Toolkit.KryptonTextBox ktbHexadecimal;
        private Krypton.Toolkit.KryptonButton kbtnExportSelectedColour;
        private Krypton.Toolkit.KryptonButton kbtnGenerateAlpha;
        private Krypton.Toolkit.KryptonComboBox kcmbDefinedColour;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private System.Windows.Forms.ToolTip ttInformation;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private System.Windows.Forms.Timer tmrUpdateUI;
        #endregion

        #region Variables
        private ConversionMethods _conversionMethods = new ConversionMethods();

        private RandomNumberGenerator _randomNumberGenerator = new RandomNumberGenerator();

        private BasicPaletteColourDefinitions _basicPaletteColourDefinitions;
        #endregion

        #region Properties
        public BasicPaletteColourDefinitions BasicPaletteColourDefinition { get { return _basicPaletteColourDefinitions; } set { _basicPaletteColourDefinitions = value; } }
        #endregion

        public DefineIndividualColoursDialog()
        {
            InitializeComponent();
        }

        #region Event Handlers
        private void DefineIndividualColoursDialog_Load(object sender, EventArgs e)
        {

        }

        private void cpbBaseColourPreview_Click(object sender, EventArgs e)
        {

        }

        private void cpbBaseColourPreview_MouseHover(object sender, EventArgs e)
        {

        }

        private void cpbDarkestColourPreview_Click(object sender, EventArgs e)
        {

        }

        private void cpbDarkestColourPreview_MouseHover(object sender, EventArgs e)
        {

        }

        private void cpbMiddleColourPreview_Click(object sender, EventArgs e)
        {

        }

        private void cpbMiddleColourPreview_MouseHover(object sender, EventArgs e)
        {

        }

        private void cpbLightColourPreview_Click(object sender, EventArgs e)
        {

        }

        private void cpbLightColourPreview_MouseHover(object sender, EventArgs e)
        {

        }

        private void cpbLightestColourPreview_Click(object sender, EventArgs e)
        {

        }

        private void cpbLightestColourPreview_MouseHover(object sender, EventArgs e)
        {

        }

        private void ktbAlpha_ValueChanged(object sender, EventArgs e)
        {
            knumAlphaChannelValue.Value = ktbAlpha.Value;

            SetExportSelectedColourEnabledState(true);
        }

        private void knumAlphaChannelValue_ValueChanged(object sender, EventArgs e)
        {
            ktbAlpha.Value = Convert.ToInt32(knumAlphaChannelValue.Value);

            SetExportSelectedColourEnabledState(true);
        }

        private void ktbRed_ValueChanged(object sender, EventArgs e)
        {
            knumRedChannelValue.Value = ktbRed.Value;

            SetExportSelectedColourEnabledState(true);
        }

        private void knumRedChannelValue_ValueChanged(object sender, EventArgs e)
        {
            ktbRed.Value = Convert.ToInt32(knumRedChannelValue.Value);

            SetExportSelectedColourEnabledState(true);
        }

        private void ktbGreen_ValueChanged(object sender, EventArgs e)
        {
            knumGreenChannelValue.Value = ktbGreen.Value;

            SetExportSelectedColourEnabledState(true);
        }

        private void knumGreenChannelValue_ValueChanged(object sender, EventArgs e)
        {
            ktbGreen.Value = Convert.ToInt32(knumGreenChannelValue.Value);

            SetExportSelectedColourEnabledState(true);
        }

        private void ktbBlue_ValueChanged(object sender, EventArgs e)
        {
            knumBlueChannelValue.Value = ktbBlue.Value;

            SetExportSelectedColourEnabledState(true);
        }

        private void knumBlueChannelValue_ValueChanged(object sender, EventArgs e)
        {
            ktbBlue.Value = Convert.ToInt32(knumBlueChannelValue.Value);

            SetExportSelectedColourEnabledState(true);
        }

        private void kbtnGenerateAlpha_Click(object sender, EventArgs e)
        {
            ktbAlpha.Value = _randomNumberGenerator.RandomlyGenerateAlphaNumberBetween(0, 255);
        }

        private void kbtnGenerateRedValue_Click(object sender, EventArgs e)
        {
            ktbRed.Value = _randomNumberGenerator.RandomlyGenerateARedNumberBetween(0, 255);
        }

        private void kbtnGenerateGreenValue_Click(object sender, EventArgs e)
        {
            ktbGreen.Value = _randomNumberGenerator.RandomlyGenerateAGreenNumberBetween(0, 255);
        }

        private void kbtnGenerateBlueValue_Click(object sender, EventArgs e)
        {
            ktbBlue.Value = _randomNumberGenerator.RandomlyGenerateABlueNumberBetween(0, 255);
        }

        private void kcmbDefinedColour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kcmbDefinedColour.SelectedIndex == 0)
            {
                SetBasicPaletteColourDefinition(BasicPaletteColourDefinitions.BASECOLOUR);
            }
            else if (kcmbDefinedColour.SelectedIndex == 1)
            {
                SetBasicPaletteColourDefinition(BasicPaletteColourDefinitions.DARKESTCOLOUR);
            }
            else if (kcmbDefinedColour.SelectedIndex == 2)
            {
                SetBasicPaletteColourDefinition(BasicPaletteColourDefinitions.MIDDLECOLOUR);
            }
            else if (kcmbDefinedColour.SelectedIndex == 3)
            {
                SetBasicPaletteColourDefinition(BasicPaletteColourDefinitions.LIGHTCOLOUR);
            }
            else if (kcmbDefinedColour.SelectedIndex == 4)
            {
                SetBasicPaletteColourDefinition(BasicPaletteColourDefinitions.LIGHTESTCOLOUR);
            }
        }

        private void kcmbDefinedColour_TextChanged(object sender, EventArgs e)
        {
            if (kcmbDefinedColour.Text == "Basic Colour")
            {
                SetBasicPaletteColourDefinition(BasicPaletteColourDefinitions.BASECOLOUR);
            }
            else if (kcmbDefinedColour.Text == "Darkest Colour")
            {
                SetBasicPaletteColourDefinition(BasicPaletteColourDefinitions.DARKESTCOLOUR);
            }
            else if (kcmbDefinedColour.Text == "Middle Colour")
            {
                SetBasicPaletteColourDefinition(BasicPaletteColourDefinitions.MIDDLECOLOUR);
            }
            else if (kcmbDefinedColour.Text == "Light Colour")
            {
                SetBasicPaletteColourDefinition(BasicPaletteColourDefinitions.LIGHTCOLOUR);
            }
            else if (kcmbDefinedColour.Text == "Lightest Colour")
            {
                SetBasicPaletteColourDefinition(BasicPaletteColourDefinitions.LIGHTESTCOLOUR);
            }
        }

        private void kbtnExportSelectedColour_Click(object sender, EventArgs e)
        {
            if (GetPaletteColourDefinition() == BasicPaletteColourDefinitions.BASECOLOUR)
            {

            }
            else if (GetPaletteColourDefinition() == BasicPaletteColourDefinitions.DARKESTCOLOUR)
            {

            }
            else if (GetPaletteColourDefinition() == BasicPaletteColourDefinitions.MIDDLECOLOUR)
            {

            }
            else if (GetPaletteColourDefinition() == BasicPaletteColourDefinitions.LIGHTCOLOUR)
            {

            }
            else if (GetPaletteColourDefinition() == BasicPaletteColourDefinitions.LIGHTESTCOLOUR)
            {

            }

            SetExportSelectedColourEnabledState(false);
        }

        private void ktbHexadecimal_TextChanged(object sender, EventArgs e)
        {

        }

        private void ktbHexadecimal_MouseHover(object sender, EventArgs e)
        {
            ttInformation.SetToolTip(this, $"Hexadecimal Value: { ktbHexadecimal.Text.ToUpper() }");
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void tmrUpdateUI_Tick(object sender, EventArgs e)
        {
            UpdateUI();
        }
        #endregion

        #region Methods
        private void UpdateUI()
        {
            if (GetPaletteColourDefinition() == BasicPaletteColourDefinitions.BASECOLOUR)
            {

                ktbHexadecimal.Text = _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(knumRedChannelValue.Value), Convert.ToInt32(knumGreenChannelValue.Value), Convert.ToInt32(knumBlueChannelValue.Value)).ToUpper();

                cpbBaseColourPreview.BackColor = Color.FromArgb(Convert.ToInt32(knumAlphaChannelValue.Value), Convert.ToInt32(knumRedChannelValue.Value), Convert.ToInt32(knumGreenChannelValue.Value), Convert.ToInt32(knumBlueChannelValue.Value));
            }
            else if (GetPaletteColourDefinition() == BasicPaletteColourDefinitions.DARKESTCOLOUR)
            {
                ktbHexadecimal.Text = _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(knumRedChannelValue.Value), Convert.ToInt32(knumGreenChannelValue.Value), Convert.ToInt32(knumBlueChannelValue.Value)).ToUpper();

                cpbDarkestColourPreview.BackColor = Color.FromArgb(Convert.ToInt32(knumAlphaChannelValue.Value), Convert.ToInt32(knumRedChannelValue.Value), Convert.ToInt32(knumGreenChannelValue.Value), Convert.ToInt32(knumBlueChannelValue.Value));
            }
            else if (GetPaletteColourDefinition() == BasicPaletteColourDefinitions.MIDDLECOLOUR)
            {
                ktbHexadecimal.Text = _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(knumRedChannelValue.Value), Convert.ToInt32(knumGreenChannelValue.Value), Convert.ToInt32(knumBlueChannelValue.Value)).ToUpper();

                cpbMiddleColourPreview.BackColor = Color.FromArgb(Convert.ToInt32(knumAlphaChannelValue.Value), Convert.ToInt32(knumRedChannelValue.Value), Convert.ToInt32(knumGreenChannelValue.Value), Convert.ToInt32(knumBlueChannelValue.Value));
            }
            else if (GetPaletteColourDefinition() == BasicPaletteColourDefinitions.LIGHTCOLOUR)
            {
                ktbHexadecimal.Text = _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(knumRedChannelValue.Value), Convert.ToInt32(knumGreenChannelValue.Value), Convert.ToInt32(knumBlueChannelValue.Value)).ToUpper();

                cpbLightColourPreview.BackColor = Color.FromArgb(Convert.ToInt32(knumAlphaChannelValue.Value), Convert.ToInt32(knumRedChannelValue.Value), Convert.ToInt32(knumGreenChannelValue.Value), Convert.ToInt32(knumBlueChannelValue.Value));
            }
            else if (GetPaletteColourDefinition() == BasicPaletteColourDefinitions.LIGHTESTCOLOUR)
            {
                ktbHexadecimal.Text = _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(knumRedChannelValue.Value), Convert.ToInt32(knumGreenChannelValue.Value), Convert.ToInt32(knumBlueChannelValue.Value)).ToUpper();

                cpbLightestColourPreview.BackColor = Color.FromArgb(Convert.ToInt32(knumAlphaChannelValue.Value), Convert.ToInt32(knumRedChannelValue.Value), Convert.ToInt32(knumGreenChannelValue.Value), Convert.ToInt32(knumBlueChannelValue.Value));
            }
        }

        private void AlterColours(BasicPaletteColourDefinitions paletteColourDefinitions)
        {
            switch (paletteColourDefinitions)
            {
                case BasicPaletteColourDefinitions.BASECOLOUR:
                    SetBasicPaletteColourDefinition(BasicPaletteColourDefinitions.BASECOLOUR);
                    break;
                case BasicPaletteColourDefinitions.DARKESTCOLOUR:
                    SetBasicPaletteColourDefinition(BasicPaletteColourDefinitions.DARKESTCOLOUR);
                    break;
                case BasicPaletteColourDefinitions.MIDDLECOLOUR:
                    SetBasicPaletteColourDefinition(BasicPaletteColourDefinitions.MIDDLECOLOUR);
                    break;
                case BasicPaletteColourDefinitions.LIGHTCOLOUR:
                    SetBasicPaletteColourDefinition(BasicPaletteColourDefinitions.LIGHTCOLOUR);
                    break;
                case BasicPaletteColourDefinitions.LIGHTESTCOLOUR:
                    SetBasicPaletteColourDefinition(BasicPaletteColourDefinitions.LIGHTESTCOLOUR);
                    break;
                default:
                    break;
            }
        }

        private void SetExportSelectedColourEnabledState(bool enabledState)
        {
            kbtnExportSelectedColour.Enabled = enabledState;
        }
        #endregion

        #region Setters & Getters
        private void SetBasicPaletteColourDefinition(BasicPaletteColourDefinitions colourDefinition)
        {
            BasicPaletteColourDefinition = colourDefinition;
        }

        private BasicPaletteColourDefinitions GetPaletteColourDefinition()
        {
            return BasicPaletteColourDefinition;
        }
        #endregion
    }
}