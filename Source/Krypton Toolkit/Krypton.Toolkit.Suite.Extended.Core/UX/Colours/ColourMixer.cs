#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public partial class ColourMixer : KryptonForm
    {
        #region Designer Code
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColourMixer));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnConvertToRGB = new Krypton.Toolkit.KryptonButton();
            this.cpbColourPreview = new CircularPictureBox();
            this.ktxtHexValue = new Krypton.Toolkit.KryptonTextBox();
            this.kbtnGenerateBlueValue = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateGreenValue = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateRedValue = new Krypton.Toolkit.KryptonButton();
            this.knumBlueChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knumGreenChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knumRedChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knumAlphaChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.pbColourPreview = new System.Windows.Forms.PictureBox();
            this.ktbRed = new Krypton.Toolkit.KryptonTrackBar();
            this.ktbGreen = new Krypton.Toolkit.KryptonTrackBar();
            this.ktbBlue = new Krypton.Toolkit.KryptonTrackBar();
            this.ktbAlpha = new Krypton.Toolkit.KryptonTrackBar();
            this.kbtnGenerateColour = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerate = new Krypton.Toolkit.KryptonButton();
            this.kbtnUtiliseAsBaseColour = new Krypton.Toolkit.KryptonButton();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOptions = new Krypton.Toolkit.KryptonButton();
            this.kcbBaseColour = new Krypton.Toolkit.KryptonColorButton();
            this.kbtnDefineOtherColours = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnConvertToRGB);
            this.kryptonPanel1.Controls.Add(this.cpbColourPreview);
            this.kryptonPanel1.Controls.Add(this.ktxtHexValue);
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateBlueValue);
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateGreenValue);
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateRedValue);
            this.kryptonPanel1.Controls.Add(this.knumBlueChannelValue);
            this.kryptonPanel1.Controls.Add(this.knumGreenChannelValue);
            this.kryptonPanel1.Controls.Add(this.knumRedChannelValue);
            this.kryptonPanel1.Controls.Add(this.knumAlphaChannelValue);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.pbColourPreview);
            this.kryptonPanel1.Controls.Add(this.ktbRed);
            this.kryptonPanel1.Controls.Add(this.ktbGreen);
            this.kryptonPanel1.Controls.Add(this.ktbBlue);
            this.kryptonPanel1.Controls.Add(this.ktbAlpha);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1204, 314);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnConvertToRGB
            // 
            this.kbtnConvertToRGB.AutoSize = true;
            this.kbtnConvertToRGB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnConvertToRGB.Enabled = false;
            this.kbtnConvertToRGB.Location = new System.Drawing.Point(300, 227);
            this.kbtnConvertToRGB.Name = "kbtnConvertToRGB";
            this.kbtnConvertToRGB.Size = new System.Drawing.Size(124, 30);
            this.kbtnConvertToRGB.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnConvertToRGB.TabIndex = 29;
            this.kbtnConvertToRGB.Values.Text = "&Convert to RGB";
            this.kbtnConvertToRGB.Click += new System.EventHandler(this.kbtnConvertToRGB_Click);
            // 
            // cpbColourPreview
            // 
            this.cpbColourPreview.BackColor = System.Drawing.Color.Transparent;
            this.cpbColourPreview.Location = new System.Drawing.Point(13, 12);
            this.cpbColourPreview.Name = "cpbColourPreview";
            this.cpbColourPreview.Size = new System.Drawing.Size(206, 195);
            this.cpbColourPreview.TabIndex = 3;
            this.cpbColourPreview.TabStop = false;
            // 
            // ktxtHexValue
            // 
            this.ktxtHexValue.Location = new System.Drawing.Point(140, 226);
            this.ktxtHexValue.MaxLength = 7;
            this.ktxtHexValue.Name = "ktxtHexValue";
            this.ktxtHexValue.Size = new System.Drawing.Size(154, 29);
            this.ktxtHexValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtHexValue.TabIndex = 10;
            this.ktxtHexValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ktxtHexValue.TextChanged += new System.EventHandler(this.ktxtHexValue_TextChanged);
            // 
            // kbtnGenerateBlueValue
            // 
            this.kbtnGenerateBlueValue.AutoSize = true;
            this.kbtnGenerateBlueValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateBlueValue.Location = new System.Drawing.Point(1066, 148);
            this.kbtnGenerateBlueValue.Name = "kbtnGenerateBlueValue";
            this.kbtnGenerateBlueValue.Size = new System.Drawing.Size(114, 30);
            this.kbtnGenerateBlueValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueValue.TabIndex = 28;
            this.kbtnGenerateBlueValue.Values.Text = "Generate &Blue";
            this.kbtnGenerateBlueValue.Click += new System.EventHandler(this.kbtnGenerateBlueValue_Click);
            // 
            // kbtnGenerateGreenValue
            // 
            this.kbtnGenerateGreenValue.AutoSize = true;
            this.kbtnGenerateGreenValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateGreenValue.Location = new System.Drawing.Point(1066, 104);
            this.kbtnGenerateGreenValue.Name = "kbtnGenerateGreenValue";
            this.kbtnGenerateGreenValue.Size = new System.Drawing.Size(126, 30);
            this.kbtnGenerateGreenValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenValue.TabIndex = 27;
            this.kbtnGenerateGreenValue.Values.Text = "Generate &Green";
            this.kbtnGenerateGreenValue.Click += new System.EventHandler(this.kbtnGenerateGreenValue_Click);
            // 
            // kbtnGenerateRedValue
            // 
            this.kbtnGenerateRedValue.AutoSize = true;
            this.kbtnGenerateRedValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateRedValue.Location = new System.Drawing.Point(1066, 56);
            this.kbtnGenerateRedValue.Name = "kbtnGenerateRedValue";
            this.kbtnGenerateRedValue.Size = new System.Drawing.Size(111, 30);
            this.kbtnGenerateRedValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedValue.TabIndex = 26;
            this.kbtnGenerateRedValue.Values.Text = "Generate &Red";
            this.kbtnGenerateRedValue.Click += new System.EventHandler(this.kbtnGenerateRedValue_Click);
            // 
            // knumBlueChannelValue
            // 
            this.knumBlueChannelValue.Location = new System.Drawing.Point(310, 150);
            this.knumBlueChannelValue.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.knumBlueChannelValue.Name = "knumBlueChannelValue";
            this.knumBlueChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumBlueChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knumBlueChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumBlueChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumBlueChannelValue.TabIndex = 14;
            this.knumBlueChannelValue.ValueChanged += new System.EventHandler(this.knumBlueChannelValue_ValueChanged);
            // 
            // knumGreenChannelValue
            // 
            this.knumGreenChannelValue.Location = new System.Drawing.Point(310, 104);
            this.knumGreenChannelValue.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.knumGreenChannelValue.Name = "knumGreenChannelValue";
            this.knumGreenChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumGreenChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Lime;
            this.knumGreenChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumGreenChannelValue.TabIndex = 13;
            this.knumGreenChannelValue.ValueChanged += new System.EventHandler(this.knumGreenChannelValue_ValueChanged);
            // 
            // knumRedChannelValue
            // 
            this.knumRedChannelValue.Location = new System.Drawing.Point(310, 58);
            this.knumRedChannelValue.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.knumRedChannelValue.Name = "knumRedChannelValue";
            this.knumRedChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumRedChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knumRedChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumRedChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumRedChannelValue.TabIndex = 12;
            this.knumRedChannelValue.ValueChanged += new System.EventHandler(this.knumRedChannelValue_ValueChanged);
            // 
            // knumAlphaChannelValue
            // 
            this.knumAlphaChannelValue.Location = new System.Drawing.Point(310, 12);
            this.knumAlphaChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumAlphaChannelValue.Name = "knumAlphaChannelValue";
            this.knumAlphaChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumAlphaChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumAlphaChannelValue.TabIndex = 11;
            this.knumAlphaChannelValue.ValueChanged += new System.EventHandler(this.knumAlphaChannelValue_ValueChanged);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(13, 227);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(130, 26);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 9;
            this.kryptonLabel5.Values.Text = "Hexadecimal: #";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(242, 150);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(50, 26);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 8;
            this.kryptonLabel4.Values.Text = "Blue:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(242, 104);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(62, 26);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 7;
            this.kryptonLabel3.Values.Text = "Green:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(242, 58);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(46, 26);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 6;
            this.kryptonLabel2.Values.Text = "Red:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(242, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(62, 26);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 5;
            this.kryptonLabel1.Values.Text = "Alpha:";
            // 
            // pbColourPreview
            // 
            this.pbColourPreview.BackColor = System.Drawing.Color.Transparent;
            this.pbColourPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbColourPreview.Location = new System.Drawing.Point(12, 12);
            this.pbColourPreview.Name = "pbColourPreview";
            this.pbColourPreview.Size = new System.Drawing.Size(207, 195);
            this.pbColourPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbColourPreview.TabIndex = 4;
            this.pbColourPreview.TabStop = false;
            this.pbColourPreview.Visible = false;
            // 
            // ktbRed
            // 
            this.ktbRed.DrawBackground = true;
            this.ktbRed.Location = new System.Drawing.Point(436, 63);
            this.ktbRed.Maximum = 255;
            this.ktbRed.Name = "ktbRed";
            this.ktbRed.Size = new System.Drawing.Size(624, 21);
            this.ktbRed.StateCommon.Tick.Color1 = System.Drawing.Color.Red;
            this.ktbRed.StateCommon.Track.Color1 = System.Drawing.Color.Red;
            this.ktbRed.StateCommon.Track.Color2 = System.Drawing.Color.Red;
            this.ktbRed.StateCommon.Track.Color3 = System.Drawing.Color.Red;
            this.ktbRed.StateCommon.Track.Color4 = System.Drawing.Color.Red;
            this.ktbRed.StateCommon.Track.Color5 = System.Drawing.Color.Red;
            this.ktbRed.TabIndex = 3;
            this.ktbRed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktbRed.ValueChanged += new System.EventHandler(this.ktbRed_ValueChanged);
            // 
            // ktbGreen
            // 
            this.ktbGreen.DrawBackground = true;
            this.ktbGreen.Location = new System.Drawing.Point(436, 109);
            this.ktbGreen.Maximum = 255;
            this.ktbGreen.Name = "ktbGreen";
            this.ktbGreen.Size = new System.Drawing.Size(624, 21);
            this.ktbGreen.StateCommon.Tick.Color1 = System.Drawing.Color.Green;
            this.ktbGreen.StateCommon.Track.Color1 = System.Drawing.Color.Green;
            this.ktbGreen.StateCommon.Track.Color2 = System.Drawing.Color.Green;
            this.ktbGreen.StateCommon.Track.Color3 = System.Drawing.Color.Green;
            this.ktbGreen.StateCommon.Track.Color4 = System.Drawing.Color.Green;
            this.ktbGreen.StateCommon.Track.Color5 = System.Drawing.Color.Green;
            this.ktbGreen.TabIndex = 2;
            this.ktbGreen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktbGreen.ValueChanged += new System.EventHandler(this.ktbGreen_ValueChanged);
            // 
            // ktbBlue
            // 
            this.ktbBlue.DrawBackground = true;
            this.ktbBlue.Location = new System.Drawing.Point(436, 155);
            this.ktbBlue.Maximum = 255;
            this.ktbBlue.Name = "ktbBlue";
            this.ktbBlue.Size = new System.Drawing.Size(624, 21);
            this.ktbBlue.StateCommon.Tick.Color1 = System.Drawing.Color.Blue;
            this.ktbBlue.StateCommon.Track.Color1 = System.Drawing.Color.Blue;
            this.ktbBlue.StateCommon.Track.Color2 = System.Drawing.Color.Blue;
            this.ktbBlue.StateCommon.Track.Color3 = System.Drawing.Color.Blue;
            this.ktbBlue.StateCommon.Track.Color4 = System.Drawing.Color.Blue;
            this.ktbBlue.StateCommon.Track.Color5 = System.Drawing.Color.Blue;
            this.ktbBlue.TabIndex = 1;
            this.ktbBlue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktbBlue.ValueChanged += new System.EventHandler(this.ktbBlue_ValueChanged);
            // 
            // ktbAlpha
            // 
            this.ktbAlpha.DrawBackground = true;
            this.ktbAlpha.Location = new System.Drawing.Point(436, 17);
            this.ktbAlpha.Maximum = 255;
            this.ktbAlpha.Name = "ktbAlpha";
            this.ktbAlpha.Size = new System.Drawing.Size(624, 21);
            this.ktbAlpha.TabIndex = 0;
            this.ktbAlpha.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktbAlpha.ValueChanged += new System.EventHandler(this.ktbAlpha_ValueChanged);
            // 
            // kbtnGenerateColour
            // 
            this.kbtnGenerateColour.AutoSize = true;
            this.kbtnGenerateColour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateColour.Location = new System.Drawing.Point(506, 6);
            this.kbtnGenerateColour.Name = "kbtnGenerateColour";
            this.kbtnGenerateColour.Size = new System.Drawing.Size(197, 30);
            this.kbtnGenerateColour.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateColour.TabIndex = 29;
            this.kbtnGenerateColour.Values.Text = "Generate Random &Colour";
            this.kbtnGenerateColour.Visible = false;
            this.kbtnGenerateColour.Click += new System.EventHandler(this.kbtnGenerateColour_Click);
            // 
            // kbtnGenerate
            // 
            this.kbtnGenerate.AutoSize = true;
            this.kbtnGenerate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerate.Location = new System.Drawing.Point(185, 6);
            this.kbtnGenerate.Name = "kbtnGenerate";
            this.kbtnGenerate.Size = new System.Drawing.Size(144, 30);
            this.kbtnGenerate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerate.TabIndex = 16;
            this.kbtnGenerate.Values.Text = "Gener&ate a Colour";
            this.kbtnGenerate.Click += new System.EventHandler(this.kbtnGenerate_Click);
            // 
            // kbtnUtiliseAsBaseColour
            // 
            this.kbtnUtiliseAsBaseColour.AutoSize = true;
            this.kbtnUtiliseAsBaseColour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnUtiliseAsBaseColour.Location = new System.Drawing.Point(12, 6);
            this.kbtnUtiliseAsBaseColour.Name = "kbtnUtiliseAsBaseColour";
            this.kbtnUtiliseAsBaseColour.Size = new System.Drawing.Size(167, 30);
            this.kbtnUtiliseAsBaseColour.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnUtiliseAsBaseColour.TabIndex = 15;
            this.kbtnUtiliseAsBaseColour.Values.Text = "Utilise as Base &Colour";
            this.kbtnUtiliseAsBaseColour.Click += new System.EventHandler(this.kbtnUtiliseAsBaseColour_Click);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Enabled = true;
            this.tmrUpdate.Interval = 250;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnOptions);
            this.kryptonPanel2.Controls.Add(this.kcbBaseColour);
            this.kryptonPanel2.Controls.Add(this.kbtnDefineOtherColours);
            this.kryptonPanel2.Controls.Add(this.kbtnOk);
            this.kryptonPanel2.Controls.Add(this.kbtnUtiliseAsBaseColour);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerateColour);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerate);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 269);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(1204, 45);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kbtnOptions
            // 
            this.kbtnOptions.AutoSize = true;
            this.kbtnOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnOptions.Location = new System.Drawing.Point(711, 6);
            this.kbtnOptions.Name = "kbtnOptions";
            this.kbtnOptions.Size = new System.Drawing.Size(69, 30);
            this.kbtnOptions.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOptions.TabIndex = 77;
            this.kbtnOptions.Values.Text = "&Options";
            this.kbtnOptions.Click += new System.EventHandler(this.kbtnOptions_Click);
            // 
            // kcbBaseColour
            // 
            this.kcbBaseColour.AutoSize = true;
            this.kcbBaseColour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kcbBaseColour.Location = new System.Drawing.Point(506, 6);
            this.kcbBaseColour.Name = "kcbBaseColour";
            this.kcbBaseColour.Size = new System.Drawing.Size(199, 30);
            this.kcbBaseColour.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbBaseColour.TabIndex = 76;
            // TODO: Fix this, line 424
            //this.kcbBaseColour.Values.Image = global::ImageResources.Colour_Wheel_16_x_16;
            this.kcbBaseColour.Values.Text = "&Choose a Base Colour";
            // 
            // kbtnDefineOtherColours
            // 
            this.kbtnDefineOtherColours.AutoSize = true;
            this.kbtnDefineOtherColours.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnDefineOtherColours.Location = new System.Drawing.Point(335, 6);
            this.kbtnDefineOtherColours.Name = "kbtnDefineOtherColours";
            this.kbtnDefineOtherColours.Size = new System.Drawing.Size(165, 30);
            this.kbtnDefineOtherColours.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnDefineOtherColours.TabIndex = 63;
            this.kbtnDefineOtherColours.Values.Text = "Define Other &Colours";
            this.kbtnDefineOtherColours.Click += new System.EventHandler(this.kbtnDefineOtherColours_Click);
            // 
            // kbtnOk
            // 
            this.kbtnOk.AutoSize = true;
            this.kbtnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnOk.Location = new System.Drawing.Point(1160, 6);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(32, 30);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.TabIndex = 60;
            this.kbtnOk.Values.Text = "O&k";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 267);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1204, 2);
            this.panel1.TabIndex = 2;
            // 
            // ColourMixer
            // 
            this.AcceptButton = this.kbtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 314);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColourMixer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Colour Mixer";
            this.Load += new System.EventHandler(this.ColourMixer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonNumericUpDown knumBlueChannelValue;
        private Krypton.Toolkit.KryptonNumericUpDown knumGreenChannelValue;
        private Krypton.Toolkit.KryptonNumericUpDown knumRedChannelValue;
        private Krypton.Toolkit.KryptonNumericUpDown knumAlphaChannelValue;
        private Krypton.Toolkit.KryptonTextBox ktxtHexValue;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.PictureBox pbColourPreview;
        private Krypton.Toolkit.KryptonTrackBar ktbRed;
        private Krypton.Toolkit.KryptonTrackBar ktbGreen;
        private Krypton.Toolkit.KryptonTrackBar ktbBlue;
        private Krypton.Toolkit.KryptonTrackBar ktbAlpha;
        private Krypton.Toolkit.KryptonButton kbtnUtiliseAsBaseColour;
        private System.Windows.Forms.Timer tmrUpdate;
        private Krypton.Toolkit.KryptonButton kbtnGenerate;
        private Krypton.Toolkit.KryptonButton kbtnGenerateBlueValue;
        private Krypton.Toolkit.KryptonButton kbtnGenerateGreenValue;
        private Krypton.Toolkit.KryptonButton kbtnGenerateRedValue;
        private Krypton.Toolkit.KryptonButton kbtnGenerateColour;
        private Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.Panel panel1;
        private Krypton.Toolkit.KryptonButton kbtnOk;
        private Krypton.Toolkit.KryptonButton kbtnDefineOtherColours;
        private CircularPictureBox cpbColourPreview;
        private Krypton.Toolkit.KryptonColorButton kcbBaseColour;
        private Krypton.Toolkit.KryptonButton kbtnOptions;
        private Krypton.Toolkit.KryptonButton kbtnConvertToRGB;
        #endregion

        #region Variables
        private int _alphaChannelValue, _redColourChannelValue, _greenColourChannelValue, _blueColourChannelValue, _max = byte.MaxValue + 1;

        private ConversionMethods _conversionMethods = new ConversionMethods();

        private RandomNumberGenerator _randomNumberGenerator = new RandomNumberGenerator();

        private AllMergedColourSettingsManager _colourSettingsManager = new AllMergedColourSettingsManager();

        private ColourIntegerSettingsManager _colourIntegerSettingsManager = new ColourIntegerSettingsManager();

        private Random randomColour = new Random();

        private ColourUtility _colourUtility = new ColourUtility();

        private bool _paletteColourSelector;
        #endregion

        #region Properties
        public int AlphaChannelValue { get { return _alphaChannelValue; } set { _alphaChannelValue = value; } }

        public int RedColourChannelValue { get { return _redColourChannelValue; } set { _redColourChannelValue = value; } }

        public int GreenColourChannelValue { get { return _greenColourChannelValue; } set { _greenColourChannelValue = value; } }

        public int BlueColourChannelValue { get { return _blueColourChannelValue; } set { _blueColourChannelValue = value; } }

        public bool PaletteColourSelector { get { return _paletteColourSelector; } set { _paletteColourSelector = value; } }
        #endregion

        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="ColourMixer"/> class.
        /// </summary>
        public ColourMixer()
        {
            InitializeComponent();

            SetAlphaChannelValue(_colourIntegerSettingsManager.GetAlphaChannelValue());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColourMixer"/> class.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <param name="red">The red.</param>
        /// <param name="green">The green.</param>
        /// <param name="blue">The blue.</param>
        public ColourMixer(int alpha, int red, int green, int blue)
        {
            InitializeComponent();

            SetAlphaChannelValue(alpha);

            SetRedColourChannelValue(red);

            SetGreenColourChannelValue(green);

            SetBlueColourChannelValue(blue);
        }

        public ColourMixer(Color baseColour)
        {
            InitializeComponent();

            cpbColourPreview.BackColor = baseColour;

            SetAlphaChannelValue(cpbColourPreview.BackColor.A);

            SetRedColourChannelValue(cpbColourPreview.BackColor.R);

            SetGreenColourChannelValue(cpbColourPreview.BackColor.G);

            SetBlueColourChannelValue(cpbColourPreview.BackColor.B);
        }

        public ColourMixer(bool paletteColourSelector)
        {
            InitializeComponent();

            PaletteColourSelector = paletteColourSelector;
        }

        public ColourMixer(bool paletteColourSelector, int alpha, int red, int green, int blue)
        {
            InitializeComponent();

            PaletteColourSelector = paletteColourSelector;

            SetAlphaChannelValue(alpha);

            SetRedColourChannelValue(red);

            SetGreenColourChannelValue(green);

            SetBlueColourChannelValue(blue);
        }

        public ColourMixer(bool paletteColourSelector, Color baseColour)
        {
            InitializeComponent();

            PaletteColourSelector = paletteColourSelector;

            cpbColourPreview.BackColor = baseColour;

            SetAlphaChannelValue(cpbColourPreview.BackColor.A);

            SetRedColourChannelValue(cpbColourPreview.BackColor.R);

            SetGreenColourChannelValue(cpbColourPreview.BackColor.G);

            SetBlueColourChannelValue(cpbColourPreview.BackColor.B);
        }
        #endregion

        #region Setters & Getters        
        /// <summary>
        /// Sets the AlphaChannelValue to value of value.
        /// </summary>
        /// <param name="value">The value of the AlphaChannelValue.</param>
        public void SetAlphaChannelValue(int value)
        {
            AlphaChannelValue = value;
        }

        /// <summary>
        /// Gets the AlphaChannelValue current value.
        /// </summary>
        /// <returns>The AlphaChannelValue current value.</returns>
        public int GetAlphaChannelValue()
        {
            return AlphaChannelValue;
        }

        /// <summary>
        /// Sets the RedColourChannelValue to value of value.
        /// </summary>
        /// <param name="value">The value of the RedColourChannelValue.</param>
        public void SetRedColourChannelValue(int value)
        {
            RedColourChannelValue = value;
        }

        /// <summary>
        /// Gets the RedColourChannelValue current value.
        /// </summary>
        /// <returns>The RedColourChannelValue current value.</returns>
        public int GetRedColourChannelValue()
        {
            return RedColourChannelValue;
        }

        /// <summary>
        /// Sets the GreenColourChannelValue to value of value.
        /// </summary>
        /// <param name="value">The value of the GreenColourChannelValue.</param>
        public void SetGreenColourChannelValue(int value)
        {
            GreenColourChannelValue = value;
        }

        /// <summary>
        /// Gets the GreenColourChannelValue current value.
        /// </summary>
        /// <returns>The GreenColourChannelValue current value.</returns>
        public int GetGreenColourChannelValue()
        {
            return GreenColourChannelValue;
        }

        /// <summary>
        /// Sets the BlueColourChannelValue to value of value.
        /// </summary>
        /// <param name="value">The value of the BlueColourChannelValue.</param>
        public void SetBlueColourChannelValue(int value)
        {
            BlueColourChannelValue = value;
        }

        /// <summary>
        /// Gets the BlueColourChannelValue current value.
        /// </summary>
        /// <returns>The BlueColourChannelValue current value.</returns>
        public int GetBlueColourChannelValue()
        {
            return BlueColourChannelValue;
        }
        #endregion

        #region Event Handlers
        private void ColourMixer_Load(object sender, EventArgs e)
        {
            ktbAlpha.Value = GetAlphaChannelValue();

            ktbRed.Value = GetRedColourChannelValue();

            ktbGreen.Value = GetGreenColourChannelValue();

            ktbBlue.Value = GetGreenColourChannelValue();
        }

        private void ktbAlpha_ValueChanged(object sender, EventArgs e)
        {
            knumAlphaChannelValue.Value = ktbAlpha.Value;

            SetAlphaChannelValue(ktbAlpha.Value);
        }

        private void ktbRed_ValueChanged(object sender, EventArgs e)
        {
            knumRedChannelValue.Value = ktbRed.Value;

            SetRedColourChannelValue(ktbRed.Value);
        }

        private void ktbGreen_ValueChanged(object sender, EventArgs e)
        {
            knumGreenChannelValue.Value = ktbGreen.Value;

            SetGreenColourChannelValue(ktbGreen.Value);
        }

        private void ktbBlue_ValueChanged(object sender, EventArgs e)
        {
            knumBlueChannelValue.Value = ktbBlue.Value;

            SetBlueColourChannelValue(ktbBlue.Value);
        }

        private void knumAlphaChannelValue_ValueChanged(object sender, EventArgs e)
        {
            ktbAlpha.Value = Convert.ToInt32(knumAlphaChannelValue.Value);
        }

        private void knumRedChannelValue_ValueChanged(object sender, EventArgs e)
        {
            ktbRed.Value = Convert.ToInt32(knumRedChannelValue.Value);
        }

        private void knumGreenChannelValue_ValueChanged(object sender, EventArgs e)
        {
            ktbGreen.Value = Convert.ToInt32(knumGreenChannelValue.Value);
        }

        private void knumBlueChannelValue_ValueChanged(object sender, EventArgs e)
        {
            ktbBlue.Value = Convert.ToInt32(knumBlueChannelValue.Value);
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            DisplayColour();

            SetHexadecimalValue();
        }

        #endregion

        #region CONVERSION FROM DECIMAL TO HEXADECIMAL AND VICE VERSA

        private int HexadecimaltoDecimal(string hexadecimal)
        {
            int result = 0;

            for (int i = 0; i < hexadecimal.Length; i++)
            {
                result += Convert.ToInt32(GetNumberFromNotation(hexadecimal[i]) * Math.Pow(16, Convert.ToInt32(hexadecimal.Length) - (i + 1)));
            }

            return Convert.ToInt32(result);
        }

        private string DeciamlToHexadeciaml(int number)
        {
            string[] hexvalues = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };

            string result = null, final = null;

            int rem = 0, div = 0;

            while (true)
            {
                rem = (number % 16);

                result += hexvalues[rem].ToString();

                if (number < 16)
                {
                    break;
                }

                number = (number / 16);

            }

            for (int i = (result.Length - 1); i >= 0; i--)
            {
                final += result[i];
            }

            return final;
        }
        #endregion

        #region Methods
        private void SetHexadecimalValue()
        {
            ktxtHexValue.Text = _conversionMethods.ConvertRGBToHexadecimal(GetRedColourChannelValue(), GetGreenColourChannelValue(), GetBlueColourChannelValue()).ToUpper(); //DeciamlToHexadeciaml(Convert.ToInt32(knumRedChannelValue.Value + knumGreenChannelValue.Value + knumBlueChannelValue.Value));
        }

        private int GetNumberFromNotation(char c)
        {
            if (c == 'A')
            {
                return 10;
            }
            else if (c == 'B')
            {
                return 11;
            }
            else if (c == 'C')
            {
                return 12;
            }
            else if (c == 'D')
            {
                return 13;
            }
            else if (c == 'E')
            {
                return 14;
            }
            else if (c == 'F')
            {
                return 15;
            }

            return Convert.ToInt32(c.ToString());
        }

        private void kbtnGenerate_Click(object sender, EventArgs e)
        {
            kbtnGenerateRedValue.PerformClick();

            kbtnGenerateGreenValue.PerformClick();

            kbtnGenerateBlueValue.PerformClick();
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

        private void kbtnUtiliseAsBaseColour_Click(object sender, EventArgs e)
        {
            PaletteColourCreator paletteColourCreator = new PaletteColourCreator(PaletteColourSelector, Convert.ToInt32(knumAlphaChannelValue.Value), Convert.ToInt32(knumRedChannelValue.Value), Convert.ToInt32(knumGreenChannelValue.Value), Convert.ToInt32(knumBlueChannelValue.Value));

            paletteColourCreator.Show();
        }

        private void kbtnOptions_Click(object sender, EventArgs e)
        {
            ColourBlendingOptions colourBlendingOptions = new ColourBlendingOptions();

            colourBlendingOptions.Show();
        }

        private void kbtnConvertToRGB_Click(object sender, EventArgs e)
        {
            ConversionMethods conversionMethods = new ConversionMethods();

            cpbColourPreview.BackColor = conversionMethods.ConvertHexadecimalToRGB($"#{ ktxtHexValue.Text }");
        }

        private void ktxtHexValue_TextChanged(object sender, EventArgs e)
        {
            if (ktxtHexValue.Text.Length == 6)
            {
                kbtnConvertToRGB.Enabled = true;
            }
        }

        private void kbtnDefineOtherColours_Click(object sender, EventArgs e)
        {
            CustomColours customColours = new CustomColours();

            customColours.Show();
        }

        private void kbtnGenerateColour_Click(object sender, EventArgs e)
        {
            // pbColourPreview.BackColor = _colourUtility.GenerateRandomColour(kchkGenerateAlphaValue.Checked);

            //int a = randomColour.Next(_max), r = randomColour.Next(_max), g = randomColour.Next(_max), b = randomColour.Next(_max); 

            //knumRedChannelValue.Value = r;

            //knumGreenChannelValue.Value = g;

            //knumBlueChannelValue.Value = b;
        }

        private void DisplayColour()
        {
            pbColourPreview.BackColor = Color.FromArgb(ktbAlpha.Value, ktbRed.Value, ktbGreen.Value, ktbBlue.Value);

            cpbColourPreview.BackColor = Color.FromArgb(ktbAlpha.Value, ktbRed.Value, ktbGreen.Value, ktbBlue.Value);
        }
        #endregion

        #region CHECKING TO FORMAT OF THE INPUT THAT WHETHER IT IS IN THE CORRECT FORMAT (DECIAML/HEXADECIMAL)

        private bool IsNumber(string number)
        {
            if (number.Length == 0)
            {
                return false;
            }

            for (int i = 0; i < number.Length; i++)
            {
                if (!(Char.IsDigit(number[i])))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsHexadecimal(string hexadecimal)
        {
            if (hexadecimal.Length == 0)
            {
                return false;
            }

            for (int i = 0; i < hexadecimal.Length; i++)
            {
                if (!((Char.IsDigit(hexadecimal[i])) || (hexadecimal[i] == 'A') || (hexadecimal[i] == 'B') || (hexadecimal[i] == 'C') || (hexadecimal[i] == 'D') || (hexadecimal[i] == 'E') || (hexadecimal[i] == 'F')))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}