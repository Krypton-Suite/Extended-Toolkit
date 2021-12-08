#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public partial class PaletteColourCreator : KryptonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaletteColourCreator));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kcbBaseColour = new Krypton.Toolkit.KryptonColorButton();
            this.cpbLightestColourPreview = new CircularPictureBox();
            this.cpbDarkestColourPreview = new CircularPictureBox();
            this.cpbMiddleColourPreview = new CircularPictureBox();
            this.cpbLightColourPreview = new CircularPictureBox();
            this.cpbBaseColourPreview = new CircularPictureBox();
            this.ktbRed = new Krypton.Toolkit.KryptonTrackBar();
            this.ktbGreen = new Krypton.Toolkit.KryptonTrackBar();
            this.ktbBlue = new Krypton.Toolkit.KryptonTrackBar();
            this.ktbAlpha = new Krypton.Toolkit.KryptonTrackBar();
            this.kryptonLabel16 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel15 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel14 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel13 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel12 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnDefineCustomColours = new Krypton.Toolkit.KryptonButton();
            this.lblColourOutput = new Krypton.Toolkit.KryptonLabel();
            this.kbtnFileExport = new Krypton.Toolkit.KryptonButton();
            this.knumAlphaChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel10 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnGenerateBlueValue = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateGreenValue = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateRedValue = new Krypton.Toolkit.KryptonButton();
            this.knumBlueChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.pbxDarkColour = new System.Windows.Forms.PictureBox();
            this.knumGreenChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.pbxLightestColour = new System.Windows.Forms.PictureBox();
            this.knumRedChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.pbxLightColour = new System.Windows.Forms.PictureBox();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.pbxMiddleColour = new System.Windows.Forms.PictureBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.pbxBaseColour = new System.Windows.Forms.PictureBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnExport = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerate = new Krypton.Toolkit.KryptonButton();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.ttInformation = new System.Windows.Forms.ToolTip(this.components);
            this.kcsHueValues = new Krypton.Toolkit.KryptonCheckSet(this.components);
            this.tmrUpdateUI = new System.Windows.Forms.Timer(this.components);
            this.tmrAutomateColourSwatchValues = new System.Windows.Forms.Timer(this.components);
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOptions = new Krypton.Toolkit.KryptonButton();
            this.kbtnDefineIndividualColours = new Krypton.Toolkit.KryptonButton();
            this.kbtnImportColours = new Krypton.Toolkit.KryptonButton();
            this.ss = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kbtnDebugConsole = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbLightestColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbDarkestColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbMiddleColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbLightColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbBaseColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDarkColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLightestColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLightColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMiddleColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBaseColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcsHueValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.ss.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kcbBaseColour);
            this.kryptonPanel1.Controls.Add(this.cpbLightestColourPreview);
            this.kryptonPanel1.Controls.Add(this.cpbDarkestColourPreview);
            this.kryptonPanel1.Controls.Add(this.cpbMiddleColourPreview);
            this.kryptonPanel1.Controls.Add(this.cpbLightColourPreview);
            this.kryptonPanel1.Controls.Add(this.cpbBaseColourPreview);
            this.kryptonPanel1.Controls.Add(this.ktbRed);
            this.kryptonPanel1.Controls.Add(this.ktbGreen);
            this.kryptonPanel1.Controls.Add(this.ktbBlue);
            this.kryptonPanel1.Controls.Add(this.ktbAlpha);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel16);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel15);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel14);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel13);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel12);
            this.kryptonPanel1.Controls.Add(this.kbtnDefineCustomColours);
            this.kryptonPanel1.Controls.Add(this.lblColourOutput);
            this.kryptonPanel1.Controls.Add(this.kbtnFileExport);
            this.kryptonPanel1.Controls.Add(this.knumAlphaChannelValue);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel10);
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateBlueValue);
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateGreenValue);
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateRedValue);
            this.kryptonPanel1.Controls.Add(this.knumBlueChannelValue);
            this.kryptonPanel1.Controls.Add(this.pbxDarkColour);
            this.kryptonPanel1.Controls.Add(this.knumGreenChannelValue);
            this.kryptonPanel1.Controls.Add(this.pbxLightestColour);
            this.kryptonPanel1.Controls.Add(this.knumRedChannelValue);
            this.kryptonPanel1.Controls.Add(this.pbxLightColour);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel1.Controls.Add(this.pbxMiddleColour);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.pbxBaseColour);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1028, 496);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kcbBaseColour
            // 
            this.kcbBaseColour.AutoSize = true;
            this.kcbBaseColour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kcbBaseColour.Location = new System.Drawing.Point(14, 372);
            this.kcbBaseColour.Name = "kcbBaseColour";
            this.kcbBaseColour.Size = new System.Drawing.Size(199, 30);
            this.kcbBaseColour.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbBaseColour.TabIndex = 75;
            // TODO: Fix line 145
            //this.kcbBaseColour.Values.Image = global::Core.Properties.Resources.Colour_Wheel_16_x_16;
            this.kcbBaseColour.Values.Text = "&Choose a Base Colour";
            this.kcbBaseColour.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcbBaseColour_SelectedColorChanged);
            // 
            // cpbLightestColourPreview
            // 
            this.cpbLightestColourPreview.BackColor = System.Drawing.Color.Transparent;
            this.cpbLightestColourPreview.Location = new System.Drawing.Point(886, 44);
            this.cpbLightestColourPreview.Name = "cpbLightestColourPreview";
            this.cpbLightestColourPreview.Size = new System.Drawing.Size(128, 128);
            this.cpbLightestColourPreview.TabIndex = 4;
            this.cpbLightestColourPreview.TabStop = false;
            this.cpbLightestColourPreview.Click += new System.EventHandler(this.cpbLightestColourPreview_Click);
            // 
            // cpbDarkestColourPreview
            // 
            this.cpbDarkestColourPreview.BackColor = System.Drawing.Color.Transparent;
            this.cpbDarkestColourPreview.Location = new System.Drawing.Point(232, 44);
            this.cpbDarkestColourPreview.Name = "cpbDarkestColourPreview";
            this.cpbDarkestColourPreview.Size = new System.Drawing.Size(128, 128);
            this.cpbDarkestColourPreview.TabIndex = 74;
            this.cpbDarkestColourPreview.TabStop = false;
            this.cpbDarkestColourPreview.Click += new System.EventHandler(this.cpbDarkestColourPreview_Click);
            // 
            // cpbMiddleColourPreview
            // 
            this.cpbMiddleColourPreview.BackColor = System.Drawing.Color.Transparent;
            this.cpbMiddleColourPreview.Location = new System.Drawing.Point(450, 44);
            this.cpbMiddleColourPreview.Name = "cpbMiddleColourPreview";
            this.cpbMiddleColourPreview.Size = new System.Drawing.Size(128, 128);
            this.cpbMiddleColourPreview.TabIndex = 73;
            this.cpbMiddleColourPreview.TabStop = false;
            this.cpbMiddleColourPreview.Click += new System.EventHandler(this.cpbMiddleColourPreview_Click);
            // 
            // cpbLightColourPreview
            // 
            this.cpbLightColourPreview.BackColor = System.Drawing.Color.Transparent;
            this.cpbLightColourPreview.Location = new System.Drawing.Point(668, 44);
            this.cpbLightColourPreview.Name = "cpbLightColourPreview";
            this.cpbLightColourPreview.Size = new System.Drawing.Size(128, 128);
            this.cpbLightColourPreview.TabIndex = 72;
            this.cpbLightColourPreview.TabStop = false;
            this.cpbLightColourPreview.Click += new System.EventHandler(this.cpbLightColourPreview_Click);
            // 
            // cpbBaseColourPreview
            // 
            this.cpbBaseColourPreview.BackColor = System.Drawing.Color.Transparent;
            this.cpbBaseColourPreview.Location = new System.Drawing.Point(14, 44);
            this.cpbBaseColourPreview.Name = "cpbBaseColourPreview";
            this.cpbBaseColourPreview.Size = new System.Drawing.Size(128, 128);
            this.cpbBaseColourPreview.TabIndex = 3;
            this.cpbBaseColourPreview.TabStop = false;
            this.cpbBaseColourPreview.Click += new System.EventHandler(this.cpbBaseColourPreview_Click);
            // 
            // ktbRed
            // 
            this.ktbRed.DrawBackground = true;
            this.ktbRed.Location = new System.Drawing.Point(208, 240);
            this.ktbRed.Maximum = 255;
            this.ktbRed.Name = "ktbRed";
            this.ktbRed.Size = new System.Drawing.Size(672, 21);
            this.ktbRed.StateCommon.Tick.Color1 = System.Drawing.Color.Red;
            this.ktbRed.StateCommon.Track.Color1 = System.Drawing.Color.Red;
            this.ktbRed.StateCommon.Track.Color2 = System.Drawing.Color.Red;
            this.ktbRed.StateCommon.Track.Color3 = System.Drawing.Color.Red;
            this.ktbRed.StateCommon.Track.Color4 = System.Drawing.Color.Red;
            this.ktbRed.StateCommon.Track.Color5 = System.Drawing.Color.Red;
            this.ktbRed.TabIndex = 71;
            this.ktbRed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktbRed.ValueChanged += new System.EventHandler(this.ktbRed_ValueChanged);
            // 
            // ktbGreen
            // 
            this.ktbGreen.DrawBackground = true;
            this.ktbGreen.Location = new System.Drawing.Point(208, 287);
            this.ktbGreen.Maximum = 255;
            this.ktbGreen.Name = "ktbGreen";
            this.ktbGreen.Size = new System.Drawing.Size(672, 21);
            this.ktbGreen.StateCommon.Tick.Color1 = System.Drawing.Color.Green;
            this.ktbGreen.StateCommon.Track.Color1 = System.Drawing.Color.Green;
            this.ktbGreen.StateCommon.Track.Color2 = System.Drawing.Color.Green;
            this.ktbGreen.StateCommon.Track.Color3 = System.Drawing.Color.Green;
            this.ktbGreen.StateCommon.Track.Color4 = System.Drawing.Color.Green;
            this.ktbGreen.StateCommon.Track.Color5 = System.Drawing.Color.Green;
            this.ktbGreen.TabIndex = 70;
            this.ktbGreen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktbGreen.ValueChanged += new System.EventHandler(this.ktbGreen_ValueChanged);
            // 
            // ktbBlue
            // 
            this.ktbBlue.DrawBackground = true;
            this.ktbBlue.Location = new System.Drawing.Point(208, 332);
            this.ktbBlue.Maximum = 255;
            this.ktbBlue.Name = "ktbBlue";
            this.ktbBlue.Size = new System.Drawing.Size(672, 21);
            this.ktbBlue.StateCommon.Tick.Color1 = System.Drawing.Color.Blue;
            this.ktbBlue.StateCommon.Track.Color1 = System.Drawing.Color.Blue;
            this.ktbBlue.StateCommon.Track.Color2 = System.Drawing.Color.Blue;
            this.ktbBlue.StateCommon.Track.Color3 = System.Drawing.Color.Blue;
            this.ktbBlue.StateCommon.Track.Color4 = System.Drawing.Color.Blue;
            this.ktbBlue.StateCommon.Track.Color5 = System.Drawing.Color.Blue;
            this.ktbBlue.TabIndex = 69;
            this.ktbBlue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktbBlue.ValueChanged += new System.EventHandler(this.ktbBlue_ValueChanged);
            // 
            // ktbAlpha
            // 
            this.ktbAlpha.DrawBackground = true;
            this.ktbAlpha.Location = new System.Drawing.Point(208, 198);
            this.ktbAlpha.Maximum = 255;
            this.ktbAlpha.Name = "ktbAlpha";
            this.ktbAlpha.Size = new System.Drawing.Size(672, 21);
            this.ktbAlpha.TabIndex = 68;
            this.ktbAlpha.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktbAlpha.ValueChanged += new System.EventHandler(this.ktbAlpha_ValueChanged);
            // 
            // kryptonLabel16
            // 
            this.kryptonLabel16.Location = new System.Drawing.Point(886, 12);
            this.kryptonLabel16.Name = "kryptonLabel16";
            this.kryptonLabel16.Size = new System.Drawing.Size(130, 26);
            this.kryptonLabel16.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel16.TabIndex = 67;
            this.kryptonLabel16.Values.Text = "Lightest Colour";
            // 
            // kryptonLabel15
            // 
            this.kryptonLabel15.Location = new System.Drawing.Point(678, 12);
            this.kryptonLabel15.Name = "kryptonLabel15";
            this.kryptonLabel15.Size = new System.Drawing.Size(108, 26);
            this.kryptonLabel15.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel15.TabIndex = 66;
            this.kryptonLabel15.Values.Text = "Light Colour";
            // 
            // kryptonLabel14
            // 
            this.kryptonLabel14.Location = new System.Drawing.Point(453, 12);
            this.kryptonLabel14.Name = "kryptonLabel14";
            this.kryptonLabel14.Size = new System.Drawing.Size(122, 26);
            this.kryptonLabel14.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel14.TabIndex = 65;
            this.kryptonLabel14.Values.Text = "Middle Colour";
            // 
            // kryptonLabel13
            // 
            this.kryptonLabel13.Location = new System.Drawing.Point(232, 12);
            this.kryptonLabel13.Name = "kryptonLabel13";
            this.kryptonLabel13.Size = new System.Drawing.Size(127, 26);
            this.kryptonLabel13.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel13.TabIndex = 64;
            this.kryptonLabel13.Values.Text = "Darkest Colour";
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Location = new System.Drawing.Point(26, 12);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(104, 26);
            this.kryptonLabel12.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel12.TabIndex = 63;
            this.kryptonLabel12.Values.Text = "Base Colour";
            // 
            // kbtnDefineCustomColours
            // 
            this.kbtnDefineCustomColours.AutoSize = true;
            this.kbtnDefineCustomColours.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnDefineCustomColours.Location = new System.Drawing.Point(219, 372);
            this.kbtnDefineCustomColours.Name = "kbtnDefineCustomColours";
            this.kbtnDefineCustomColours.Size = new System.Drawing.Size(215, 30);
            this.kbtnDefineCustomColours.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnDefineCustomColours.TabIndex = 62;
            this.kbtnDefineCustomColours.Values.Text = "Define Custom Text &Colours";
            this.kbtnDefineCustomColours.Click += new System.EventHandler(this.kbtnDefineCustomColours_Click);
            // 
            // lblColourOutput
            // 
            this.lblColourOutput.Location = new System.Drawing.Point(39, 582);
            this.lblColourOutput.Name = "lblColourOutput";
            this.lblColourOutput.Size = new System.Drawing.Size(6, 2);
            this.lblColourOutput.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColourOutput.TabIndex = 61;
            this.lblColourOutput.Values.Text = "";
            // 
            // kbtnFileExport
            // 
            this.kbtnFileExport.AutoSize = true;
            this.kbtnFileExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnFileExport.Location = new System.Drawing.Point(14, 582);
            this.kbtnFileExport.Name = "kbtnFileExport";
            this.kbtnFileExport.Size = new System.Drawing.Size(88, 30);
            this.kbtnFileExport.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnFileExport.TabIndex = 58;
            this.kbtnFileExport.Values.Text = "Export &File";
            this.kbtnFileExport.Visible = false;
            this.kbtnFileExport.Click += new System.EventHandler(this.kbtnFileExport_Click);
            // 
            // knumAlphaChannelValue
            // 
            this.knumAlphaChannelValue.Location = new System.Drawing.Point(82, 193);
            this.knumAlphaChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumAlphaChannelValue.Name = "knumAlphaChannelValue";
            this.knumAlphaChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumAlphaChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumAlphaChannelValue.TabIndex = 53;
            this.knumAlphaChannelValue.ValueChanged += new System.EventHandler(this.knumAlphaChannelValue_ValueChanged);
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Location = new System.Drawing.Point(14, 193);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(62, 26);
            this.kryptonLabel10.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel10.TabIndex = 52;
            this.kryptonLabel10.Values.Text = "Alpha:";
            // 
            // kbtnGenerateBlueValue
            // 
            this.kbtnGenerateBlueValue.AutoSize = true;
            this.kbtnGenerateBlueValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateBlueValue.Location = new System.Drawing.Point(886, 325);
            this.kbtnGenerateBlueValue.Name = "kbtnGenerateBlueValue";
            this.kbtnGenerateBlueValue.Size = new System.Drawing.Size(114, 30);
            this.kbtnGenerateBlueValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueValue.TabIndex = 25;
            this.kbtnGenerateBlueValue.Values.Text = "Generate &Blue";
            this.kbtnGenerateBlueValue.Click += new System.EventHandler(this.kbtnGenerateBlueValue_Click);
            // 
            // kbtnGenerateGreenValue
            // 
            this.kbtnGenerateGreenValue.AutoSize = true;
            this.kbtnGenerateGreenValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateGreenValue.Location = new System.Drawing.Point(886, 282);
            this.kbtnGenerateGreenValue.Name = "kbtnGenerateGreenValue";
            this.kbtnGenerateGreenValue.Size = new System.Drawing.Size(126, 30);
            this.kbtnGenerateGreenValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenValue.TabIndex = 24;
            this.kbtnGenerateGreenValue.Values.Text = "Generate &Green";
            this.kbtnGenerateGreenValue.Click += new System.EventHandler(this.kbtnGenerateGreenValue_Click);
            // 
            // kbtnGenerateRedValue
            // 
            this.kbtnGenerateRedValue.AutoSize = true;
            this.kbtnGenerateRedValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateRedValue.Location = new System.Drawing.Point(886, 238);
            this.kbtnGenerateRedValue.Name = "kbtnGenerateRedValue";
            this.kbtnGenerateRedValue.Size = new System.Drawing.Size(111, 30);
            this.kbtnGenerateRedValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedValue.TabIndex = 23;
            this.kbtnGenerateRedValue.Values.Text = "Generate &Red";
            this.kbtnGenerateRedValue.Click += new System.EventHandler(this.kbtnGenerateRedValue_Click);
            // 
            // knumBlueChannelValue
            // 
            this.knumBlueChannelValue.Location = new System.Drawing.Point(82, 325);
            this.knumBlueChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumBlueChannelValue.Name = "knumBlueChannelValue";
            this.knumBlueChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumBlueChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knumBlueChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumBlueChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumBlueChannelValue.TabIndex = 20;
            this.knumBlueChannelValue.ValueChanged += new System.EventHandler(this.knumBlueChannelValue_ValueChanged);
            // 
            // pbxDarkColour
            // 
            this.pbxDarkColour.BackColor = System.Drawing.Color.Transparent;
            this.pbxDarkColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxDarkColour.Location = new System.Drawing.Point(232, 44);
            this.pbxDarkColour.Name = "pbxDarkColour";
            this.pbxDarkColour.Size = new System.Drawing.Size(128, 128);
            this.pbxDarkColour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxDarkColour.TabIndex = 4;
            this.pbxDarkColour.TabStop = false;
            this.pbxDarkColour.Visible = false;
            this.pbxDarkColour.Click += new System.EventHandler(this.pbxDarkColour_Click);
            this.pbxDarkColour.MouseEnter += new System.EventHandler(this.pbxDarkColour_MouseEnter);
            // 
            // knumGreenChannelValue
            // 
            this.knumGreenChannelValue.Location = new System.Drawing.Point(82, 282);
            this.knumGreenChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumGreenChannelValue.Name = "knumGreenChannelValue";
            this.knumGreenChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumGreenChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Lime;
            this.knumGreenChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumGreenChannelValue.TabIndex = 19;
            this.knumGreenChannelValue.ValueChanged += new System.EventHandler(this.knumGreenChannelValue_ValueChanged);
            // 
            // pbxLightestColour
            // 
            this.pbxLightestColour.BackColor = System.Drawing.Color.Transparent;
            this.pbxLightestColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxLightestColour.Location = new System.Drawing.Point(886, 44);
            this.pbxLightestColour.Name = "pbxLightestColour";
            this.pbxLightestColour.Size = new System.Drawing.Size(128, 128);
            this.pbxLightestColour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxLightestColour.TabIndex = 3;
            this.pbxLightestColour.TabStop = false;
            this.pbxLightestColour.Visible = false;
            this.pbxLightestColour.MouseEnter += new System.EventHandler(this.pbxLightestColour_MouseEnter);
            // 
            // knumRedChannelValue
            // 
            this.knumRedChannelValue.Location = new System.Drawing.Point(82, 238);
            this.knumRedChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumRedChannelValue.Name = "knumRedChannelValue";
            this.knumRedChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumRedChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knumRedChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumRedChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumRedChannelValue.TabIndex = 18;
            this.knumRedChannelValue.ValueChanged += new System.EventHandler(this.knumRedChannelValue_ValueChanged);
            // 
            // pbxLightColour
            // 
            this.pbxLightColour.BackColor = System.Drawing.Color.Transparent;
            this.pbxLightColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxLightColour.Location = new System.Drawing.Point(668, 44);
            this.pbxLightColour.Name = "pbxLightColour";
            this.pbxLightColour.Size = new System.Drawing.Size(128, 128);
            this.pbxLightColour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxLightColour.TabIndex = 2;
            this.pbxLightColour.TabStop = false;
            this.pbxLightColour.Visible = false;
            this.pbxLightColour.MouseEnter += new System.EventHandler(this.pbxLightColour_MouseEnter);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(14, 327);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(50, 26);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 17;
            this.kryptonLabel4.Values.Text = "Blue:";
            // 
            // pbxMiddleColour
            // 
            this.pbxMiddleColour.BackColor = System.Drawing.Color.Transparent;
            this.pbxMiddleColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxMiddleColour.Location = new System.Drawing.Point(450, 44);
            this.pbxMiddleColour.Name = "pbxMiddleColour";
            this.pbxMiddleColour.Size = new System.Drawing.Size(128, 128);
            this.pbxMiddleColour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxMiddleColour.TabIndex = 1;
            this.pbxMiddleColour.TabStop = false;
            this.pbxMiddleColour.Visible = false;
            this.pbxMiddleColour.MouseEnter += new System.EventHandler(this.pbxMiddleColour_MouseEnter);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(14, 282);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(62, 26);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 16;
            this.kryptonLabel3.Values.Text = "Green:";
            // 
            // pbxBaseColour
            // 
            this.pbxBaseColour.BackColor = System.Drawing.Color.Transparent;
            this.pbxBaseColour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxBaseColour.Location = new System.Drawing.Point(14, 44);
            this.pbxBaseColour.Name = "pbxBaseColour";
            this.pbxBaseColour.Size = new System.Drawing.Size(128, 128);
            this.pbxBaseColour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxBaseColour.TabIndex = 0;
            this.pbxBaseColour.TabStop = false;
            this.pbxBaseColour.Visible = false;
            this.pbxBaseColour.MouseEnter += new System.EventHandler(this.pbxBaseColour_MouseEnter);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(14, 240);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(46, 26);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 15;
            this.kryptonLabel2.Values.Text = "Red:";
            // 
            // kbtnExport
            // 
            this.kbtnExport.AutoSize = true;
            this.kbtnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnExport.Enabled = false;
            this.kbtnExport.Location = new System.Drawing.Point(158, 7);
            this.kbtnExport.Name = "kbtnExport";
            this.kbtnExport.Size = new System.Drawing.Size(118, 30);
            this.kbtnExport.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnExport.TabIndex = 22;
            this.kbtnExport.Values.Text = "&Export Colours";
            this.kbtnExport.Click += new System.EventHandler(this.kbtnExport_Click);
            // 
            // kbtnGenerate
            // 
            this.kbtnGenerate.AutoSize = true;
            this.kbtnGenerate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerate.Location = new System.Drawing.Point(14, 7);
            this.kbtnGenerate.Name = "kbtnGenerate";
            this.kbtnGenerate.Size = new System.Drawing.Size(138, 30);
            this.kbtnGenerate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerate.TabIndex = 21;
            this.kbtnGenerate.Values.Text = "Gener&ate Colours";
            this.kbtnGenerate.Click += new System.EventHandler(this.kbtnGenerate_Click);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Enabled = true;
            this.tmrUpdate.Interval = 250;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // tmrUpdateUI
            // 
            this.tmrUpdateUI.Interval = 250;
            this.tmrUpdateUI.Tick += new System.EventHandler(this.tmrUpdateUI_Tick);
            // 
            // tmrAutomateColourSwatchValues
            // 
            this.tmrAutomateColourSwatchValues.Interval = 250;
            this.tmrAutomateColourSwatchValues.Tick += new System.EventHandler(this.tmrAutomateColourSwatchValues_Tick);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnDebugConsole);
            this.kryptonPanel2.Controls.Add(this.kbtnOptions);
            this.kryptonPanel2.Controls.Add(this.kbtnDefineIndividualColours);
            this.kryptonPanel2.Controls.Add(this.kbtnImportColours);
            this.kryptonPanel2.Controls.Add(this.ss);
            this.kryptonPanel2.Controls.Add(this.kbtnOk);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerate);
            this.kryptonPanel2.Controls.Add(this.kbtnExport);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 427);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(1028, 69);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kbtnOptions
            // 
            this.kbtnOptions.AutoSize = true;
            this.kbtnOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnOptions.Location = new System.Drawing.Point(609, 7);
            this.kbtnOptions.Name = "kbtnOptions";
            this.kbtnOptions.Size = new System.Drawing.Size(69, 30);
            this.kbtnOptions.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOptions.TabIndex = 63;
            this.kbtnOptions.Values.Text = "Op&tions";
            this.kbtnOptions.Click += new System.EventHandler(this.kbtnOptions_Click);
            // 
            // kbtnDefineIndividualColours
            // 
            this.kbtnDefineIndividualColours.AutoSize = true;
            this.kbtnDefineIndividualColours.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnDefineIndividualColours.Location = new System.Drawing.Point(409, 7);
            this.kbtnDefineIndividualColours.Name = "kbtnDefineIndividualColours";
            this.kbtnDefineIndividualColours.Size = new System.Drawing.Size(194, 30);
            this.kbtnDefineIndividualColours.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnDefineIndividualColours.TabIndex = 62;
            this.kbtnDefineIndividualColours.Values.Text = "Define Indi&vidual Colours";
            this.kbtnDefineIndividualColours.Click += new System.EventHandler(this.kbtnDefineIndividualColours_Click);
            // 
            // kbtnImportColours
            // 
            this.kbtnImportColours.AutoSize = true;
            this.kbtnImportColours.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnImportColours.Location = new System.Drawing.Point(282, 7);
            this.kbtnImportColours.Name = "kbtnImportColours";
            this.kbtnImportColours.Size = new System.Drawing.Size(121, 30);
            this.kbtnImportColours.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnImportColours.TabIndex = 61;
            this.kbtnImportColours.Values.Text = "&Import Colours";
            this.kbtnImportColours.Click += new System.EventHandler(this.kbtnImportColours_Click);
            // 
            // ss
            // 
            this.ss.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ss.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.ss.Location = new System.Drawing.Point(0, 47);
            this.ss.Name = "ss";
            this.ss.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.ss.Size = new System.Drawing.Size(1028, 22);
            this.ss.TabIndex = 60;
            this.ss.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(39, 17);
            this.tsslStatus.Text = "Ready";
            // 
            // kbtnOk
            // 
            this.kbtnOk.AutoSize = true;
            this.kbtnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnOk.Location = new System.Drawing.Point(984, 7);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(32, 30);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.TabIndex = 59;
            this.kbtnOk.Values.Text = "O&k";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 425);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 2);
            this.panel1.TabIndex = 2;
            // 
            // kbtnDebugConsole
            // 
            this.kbtnDebugConsole.AutoSize = true;
            this.kbtnDebugConsole.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnDebugConsole.Location = new System.Drawing.Point(684, 7);
            this.kbtnDebugConsole.Name = "kbtnDebugConsole";
            this.kbtnDebugConsole.Size = new System.Drawing.Size(124, 30);
            this.kbtnDebugConsole.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnDebugConsole.TabIndex = 64;
            this.kbtnDebugConsole.Values.Text = "&Debug Console";
            this.kbtnDebugConsole.Click += new System.EventHandler(this.kbtnDebugConsole_Click);
            // 
            // PaletteColourCreator
            // 
            this.AcceptButton = this.kbtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 496);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaletteColourCreator";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Palette Colour Creator";
            this.Load += new System.EventHandler(this.PaletteColourCreator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbLightestColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbDarkestColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbMiddleColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbLightColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbBaseColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDarkColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLightestColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLightColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMiddleColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBaseColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcsHueValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ss.ResumeLayout(false);
            this.ss.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.PictureBox pbxDarkColour;
        private System.Windows.Forms.PictureBox pbxLightestColour;
        private System.Windows.Forms.PictureBox pbxLightColour;
        private System.Windows.Forms.PictureBox pbxMiddleColour;
        private System.Windows.Forms.PictureBox pbxBaseColour;
        private Krypton.Toolkit.KryptonNumericUpDown knumBlueChannelValue;
        private Krypton.Toolkit.KryptonNumericUpDown knumGreenChannelValue;
        private Krypton.Toolkit.KryptonNumericUpDown knumRedChannelValue;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonButton kbtnExport;
        private Krypton.Toolkit.KryptonButton kbtnGenerate;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.ToolTip ttInformation;
        private Krypton.Toolkit.KryptonButton kbtnGenerateBlueValue;
        private Krypton.Toolkit.KryptonButton kbtnGenerateGreenValue;
        private Krypton.Toolkit.KryptonButton kbtnGenerateRedValue;
        private Krypton.Toolkit.KryptonCheckSet kcsHueValues;
        private System.Windows.Forms.Timer tmrUpdateUI;
        private Krypton.Toolkit.KryptonNumericUpDown knumAlphaChannelValue;
        private Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private System.Windows.Forms.Timer tmrAutomateColourSwatchValues;
        private Krypton.Toolkit.KryptonButton kbtnFileExport;
        private Krypton.Toolkit.KryptonLabel lblColourOutput;
        private Krypton.Toolkit.KryptonButton kbtnDefineCustomColours;
        private Krypton.Toolkit.KryptonLabel kryptonLabel16;
        private Krypton.Toolkit.KryptonLabel kryptonLabel15;
        private Krypton.Toolkit.KryptonLabel kryptonLabel14;
        private Krypton.Toolkit.KryptonLabel kryptonLabel13;
        private Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private Krypton.Toolkit.KryptonTrackBar ktbRed;
        private Krypton.Toolkit.KryptonTrackBar ktbGreen;
        private Krypton.Toolkit.KryptonTrackBar ktbBlue;
        private Krypton.Toolkit.KryptonTrackBar ktbAlpha;
        private Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private Krypton.Toolkit.KryptonButton kbtnOk;
        private System.Windows.Forms.Panel panel1;
        private CircularPictureBox cpbLightestColourPreview;
        private CircularPictureBox cpbDarkestColourPreview;
        private CircularPictureBox cpbMiddleColourPreview;
        private CircularPictureBox cpbLightColourPreview;
        private CircularPictureBox cpbBaseColourPreview;
        private System.Windows.Forms.StatusStrip ss;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private Krypton.Toolkit.KryptonButton kbtnImportColours;
        private Krypton.Toolkit.KryptonButton kbtnDefineIndividualColours;
        private Krypton.Toolkit.KryptonButton kbtnOptions;
        private Krypton.Toolkit.KryptonColorButton kcbBaseColour;
        private Krypton.Toolkit.KryptonButton kbtnDebugConsole;
        #endregion

        #region Variables
        private ConversionMethods _conversionMethods = new ConversionMethods();

        private RandomNumberGenerator _randomNumberGenerator = new RandomNumberGenerator();

        private HSLColour _hslColour = new HSLColour();

        private ColourControlManager _colourControlManager = new ColourControlManager();

        private GlobalBooleanSettingsManager _globalBooleanSettingsManager = new GlobalBooleanSettingsManager();

        private AllMergedColourSettingsManager _colourSettingsManager = new AllMergedColourSettingsManager();

        private Color _baseColour, _colourDark, _colourNormal, _colourLight, _colourLightness;

        private bool _paletteColourSelector;
        #endregion

        #region Properties
        public Color BaseColour { get { return _baseColour; } set { _baseColour = value; } }

        public bool PaletteColourSelector { get { return _paletteColourSelector; } set { _paletteColourSelector = value; } }
        #endregion

        #region Constructors
        public PaletteColourCreator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteColourCreator"/> class.
        /// </summary>
        /// <param name="alphaValue">The alpha value.</param>
        /// <param name="redValue">The red value.</param>
        /// <param name="greenValue">The green value.</param>
        /// <param name="blueValue">The blue value.</param>
        public PaletteColourCreator(int alphaValue, int redValue, int greenValue, int blueValue)
        {
            InitializeComponent();

            knumAlphaChannelValue.Value = alphaValue;

            knumRedChannelValue.Value = redValue;

            knumGreenChannelValue.Value = greenValue;

            knumBlueChannelValue.Value = blueValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteColourCreator"/> class.
        /// </summary>
        /// <param name="baseColour">The base colour.</param>
        public PaletteColourCreator(Color baseColour)
        {
            InitializeComponent();

            BaseColour = baseColour;

            cpbBaseColourPreview.BackColor = BaseColour;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteColourCreator"/> class.
        /// </summary>
        /// <param name="paletteColourSelector">if set to <c>true</c> [palette colour selector].</param>
        public PaletteColourCreator(bool paletteColourSelector)
        {
            InitializeComponent();

            PaletteColourSelector = paletteColourSelector;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteColourCreator"/> class.
        /// </summary>
        /// <param name="paletteColourSelector">if set to <c>true</c> [palette colour selector].</param>
        /// <param name="alphaValue">The alpha value.</param>
        /// <param name="redValue">The red value.</param>
        /// <param name="greenValue">The green value.</param>
        /// <param name="blueValue">The blue value.</param>
        public PaletteColourCreator(bool paletteColourSelector, int alphaValue, int redValue, int greenValue, int blueValue)
        {
            InitializeComponent();

            PaletteColourSelector = paletteColourSelector;

            knumAlphaChannelValue.Value = alphaValue;

            knumRedChannelValue.Value = redValue;

            knumGreenChannelValue.Value = greenValue;

            knumBlueChannelValue.Value = blueValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteColourCreator"/> class.
        /// </summary>
        /// <param name="paletteColourSelector">if set to <c>true</c> [palette colour selector].</param>
        /// <param name="baseColour">The base colour.</param>
        public PaletteColourCreator(bool paletteColourSelector, Color baseColour)
        {
            InitializeComponent();

            PaletteColourSelector = paletteColourSelector;

            BaseColour = BaseColour;

            cpbBaseColourPreview.BackColor = BaseColour;
        }
        #endregion

        private void PaletteColourCreator_Load(object sender, EventArgs e)
        {
            _colourSettingsManager.ResetToDefaults();

            if (PaletteColourSelector)
            {
                kbtnDefineIndividualColours.Visible = true;

                kbtnDefineIndividualColours.Enabled = true;

                kbtnOptions.Location = new Point(609, 7);

                kbtnDebugConsole.Location = new Point(684, 7);
            }
            else
            {
                kbtnDefineIndividualColours.Visible = false;

                kbtnDefineIndividualColours.Enabled = false;

                kbtnOptions.Location = new Point(409, 7);

                kbtnDebugConsole.Location = new Point(484, 7);
            }

            tmrAutomateColourSwatchValues.Enabled = _globalBooleanSettingsManager.GetAutomaticallyUpdateColours();
        }

        #region Event Handlers
        private void pbxBaseColour_MouseEnter(object sender, EventArgs e)
        {
            ttInformation.SetToolTip(pbxBaseColour, $"Base Colour\nARGB: ({ pbxBaseColour.BackColor.A.ToString() }, { pbxBaseColour.BackColor.R.ToString() }, { pbxBaseColour.BackColor.G.ToString() }, { pbxBaseColour.BackColor.B.ToString() })\nRGB: ({ pbxBaseColour.BackColor.R.ToString() }, { pbxBaseColour.BackColor.G.ToString() }, { pbxBaseColour.BackColor.B.ToString() })\nHexadecimal Value: #{ _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(pbxBaseColour.BackColor.R), Convert.ToInt32(pbxBaseColour.BackColor.G), Convert.ToInt32(pbxBaseColour.BackColor.B)).ToUpper() }");
        }

        private void pbxDarkColour_MouseEnter(object sender, EventArgs e)
        {
            ttInformation.SetToolTip(pbxDarkColour, $"Dark Colour\nARGB: ({ pbxDarkColour.BackColor.A.ToString() }, { pbxDarkColour.BackColor.R.ToString() }, { pbxDarkColour.BackColor.G.ToString() }, { pbxDarkColour.BackColor.B.ToString() })\nRGB: ({ pbxDarkColour.BackColor.R.ToString() }, { pbxDarkColour.BackColor.G.ToString() }, { pbxDarkColour.BackColor.B.ToString() })\nHexadecimal Value: #{ _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(pbxDarkColour.BackColor.R), Convert.ToInt32(pbxDarkColour.BackColor.G), Convert.ToInt32(pbxDarkColour.BackColor.B)).ToUpper() }\nHue: { pbxDarkColour.BackColor.GetHue().ToString() }\nSaturation: { pbxDarkColour.BackColor.GetSaturation().ToString() }\nBrightness: { pbxDarkColour.BackColor.GetBrightness().ToString() }");
        }

        private void pbxMiddleColour_MouseEnter(object sender, EventArgs e)
        {
            ttInformation.SetToolTip(pbxMiddleColour, $"Middle Colour\nARGB: ({ pbxMiddleColour.BackColor.A.ToString() }, { pbxMiddleColour.BackColor.R.ToString() }, { pbxMiddleColour.BackColor.G.ToString() }, { pbxMiddleColour.BackColor.B.ToString() })\nRGB: ({ pbxMiddleColour.BackColor.R.ToString() }, { pbxMiddleColour.BackColor.G.ToString() }, { pbxMiddleColour.BackColor.B.ToString() })\nHexadecimal Value: #{ _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(pbxMiddleColour.BackColor.R), Convert.ToInt32(pbxMiddleColour.BackColor.G), Convert.ToInt32(pbxMiddleColour.BackColor.B)).ToUpper() }\nHue: { pbxMiddleColour.BackColor.GetHue().ToString() }\nSaturation: { pbxMiddleColour.BackColor.GetSaturation().ToString() }\nBrightness: { pbxMiddleColour.BackColor.GetBrightness().ToString() }");
        }

        private void pbxLightColour_MouseEnter(object sender, EventArgs e)
        {
            ttInformation.SetToolTip(pbxLightColour, $"Light Colour\nARGB: ({ pbxLightColour.BackColor.A.ToString() }, { pbxLightColour.BackColor.R.ToString() }, { pbxLightColour.BackColor.G.ToString() }, { pbxLightColour.BackColor.B.ToString() })\nRGB: ({ pbxLightColour.BackColor.R.ToString() }, { pbxLightColour.BackColor.G.ToString() }, { pbxLightColour.BackColor.B.ToString() })\nHexadecimal Value: #{ _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(pbxLightColour.BackColor.R), Convert.ToInt32(pbxLightColour.BackColor.G), Convert.ToInt32(pbxLightColour.BackColor.B)).ToUpper() }\nHue: { pbxLightColour.BackColor.GetHue().ToString() }\nSaturation: { pbxLightColour.BackColor.GetSaturation().ToString() }\nBrightness: { pbxLightColour.BackColor.GetBrightness().ToString() }");
        }

        private void pbxLightestColour_MouseEnter(object sender, EventArgs e)
        {
            ttInformation.SetToolTip(pbxLightestColour, $"Lightest Colour\nARGB: ({ pbxLightestColour.BackColor.A.ToString() }, { pbxLightestColour.BackColor.R.ToString() }, { pbxLightestColour.BackColor.G.ToString() }, { pbxLightestColour.BackColor.B.ToString() })\nRGB: ({ pbxLightestColour.BackColor.R.ToString() }, { pbxLightestColour.BackColor.G.ToString() }, { pbxLightestColour.BackColor.B.ToString() })\nHexadecimal Value: #{ _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(pbxLightestColour.BackColor.R), Convert.ToInt32(pbxLightestColour.BackColor.G), Convert.ToInt32(pbxLightestColour.BackColor.B)).ToUpper() }\nHue: { pbxLightestColour.BackColor.GetHue().ToString() }\nSaturation: { pbxLightestColour.BackColor.GetSaturation().ToString() }\nBrightness: { pbxLightestColour.BackColor.GetBrightness().ToString() }");
        }

        private void pbxNormalTextColour_MouseEnter(object sender, EventArgs e)
        {
            //ttInformation.SetToolTip(pbxNormalTextColour, $"Normal Text Colour\nARGB: ({ pbxNormalTextColour.BackColor.A.ToString() }, { pbxNormalTextColour.BackColor.R.ToString() }, { pbxNormalTextColour.BackColor.G.ToString() }, { pbxNormalTextColour.BackColor.B.ToString() })\nRGB: ({ pbxNormalTextColour.BackColor.R.ToString() }, { pbxNormalTextColour.BackColor.G.ToString() }, { pbxNormalTextColour.BackColor.B.ToString() })\nHexadecimal Value: #{ _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(pbxNormalTextColour.BackColor.R), Convert.ToInt32(pbxNormalTextColour.BackColor.G), Convert.ToInt32(pbxNormalTextColour.BackColor.B)).ToUpper() }");
        }

        private void pbxDisabledTextColour_MouseEnter(object sender, EventArgs e)
        {
            //ttInformation.SetToolTip(pbxDisabledTextColour, $"Disabled Text Colour\nARGB: ({ pbxDisabledTextColour.BackColor.A.ToString() }, { pbxDisabledTextColour.BackColor.R.ToString() }, { pbxDisabledTextColour.BackColor.G.ToString() }, { pbxDisabledTextColour.BackColor.B.ToString() })\nRGB: ({ pbxDisabledTextColour.BackColor.R.ToString() }, { pbxDisabledTextColour.BackColor.G.ToString() }, { pbxDisabledTextColour.BackColor.B.ToString() })\nHexadecimal Value: #{ _conversionMethods.ConvertRGBToHexadecimal(Convert.ToInt32(pbxDisabledTextColour.BackColor.R), Convert.ToInt32(pbxDisabledTextColour.BackColor.G), Convert.ToInt32(pbxDisabledTextColour.BackColor.B)).ToUpper() }");
        }

        private void knumRedChannelValue_ValueChanged(object sender, EventArgs e)
        {
            pbxBaseColour.BackColor = Color.FromArgb(Convert.ToInt32(knumRedChannelValue.Value), Convert.ToInt32(knumGreenChannelValue.Value), Convert.ToInt32(knumBlueChannelValue.Value));

            ktbRed.Value = Convert.ToInt32(knumRedChannelValue.Value);
        }

        private void knumGreenChannelValue_ValueChanged(object sender, EventArgs e)
        {
            pbxBaseColour.BackColor = Color.FromArgb(Convert.ToInt32(knumRedChannelValue.Value), Convert.ToInt32(knumGreenChannelValue.Value), Convert.ToInt32(knumBlueChannelValue.Value));

            ktbGreen.Value = Convert.ToInt32(knumGreenChannelValue.Value);
        }

        private void knumBlueChannelValue_ValueChanged(object sender, EventArgs e)
        {
            pbxBaseColour.BackColor = Color.FromArgb(Convert.ToInt32(knumRedChannelValue.Value), Convert.ToInt32(knumGreenChannelValue.Value), Convert.ToInt32(knumBlueChannelValue.Value));

            ktbBlue.Value = Convert.ToInt32(knumBlueChannelValue.Value);
        }

        private void kbtnGenerateRedValue_Click(object sender, EventArgs e)
        {
            knumRedChannelValue.Value = _randomNumberGenerator.RandomlyGenerateARedNumberBetween(0, 255);
        }

        private void kbtnGenerateGreenValue_Click(object sender, EventArgs e)
        {
            knumGreenChannelValue.Value = _randomNumberGenerator.RandomlyGenerateAGreenNumberBetween(0, 255);
        }

        private void kbtnGenerateBlueValue_Click(object sender, EventArgs e)
        {
            knumBlueChannelValue.Value = _randomNumberGenerator.RandomlyGenerateABlueNumberBetween(0, 255);
        }

        private void kbtnGenerate_Click(object sender, EventArgs e)
        {
            //ColourUtilities.GenerateColourShades(pbxBaseColour.BackColor, pbxDarkColour, pbxMiddleColour, pbxLightColour, pbxLightestColour);

            ColourUtilities.GenerateColourShades(cpbBaseColourPreview.BackColor, cpbDarkestColourPreview, cpbMiddleColourPreview, cpbLightColourPreview, cpbLightestColourPreview);

            kbtnExport.Enabled = true;
        }

        private void kbtnExport_Click(object sender, EventArgs e)
        {
            if (_globalBooleanSettingsManager.GetUseCircularPictureBoxes())
            {
                PaletteColourManagementEngine.SetBasicPaletteColours(cpbBaseColourPreview, cpbDarkestColourPreview, cpbMiddleColourPreview, cpbLightColourPreview, cpbLightestColourPreview);
            }
            else
            {
                PaletteColourManagementEngine.SetBasicPaletteColours(pbxBaseColour, pbxDarkColour, pbxMiddleColour, pbxLightColour, pbxLightestColour);
            }
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            UpdateBaseColour();
        }
        #endregion

        private void tmrUpdateUI_Tick(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void UpdateBaseColour()
        {
            //pbxBaseColour.BackColor = Color.FromArgb(255, Convert.ToInt32(knumRedChannelValue.Value), Convert.ToInt32(knumGreenChannelValue.Value), Convert.ToInt32(knumBlueChannelValue.Value));

            cpbBaseColourPreview.BackColor = Color.FromArgb(255, Convert.ToInt32(knumRedChannelValue.Value), Convert.ToInt32(knumGreenChannelValue.Value), Convert.ToInt32(knumBlueChannelValue.Value));
        }

        private void kchkAutomateColourSwatchValues_CheckedChanged(object sender, EventArgs e)
        {
            tmrAutomateColourSwatchValues.Enabled = _globalBooleanSettingsManager.GetAutomaticallyUpdateColours();
        }

        private void tmrAutomateColourSwatchValues_Tick(object sender, EventArgs e)
        {
            //ColourUtilities.GenerateColourShades(pbxBaseColour.BackColor, pbxDarkColour, pbxMiddleColour, pbxLightColour, pbxLightestColour);

            ColourUtilities.GenerateColourShades(cpbBaseColourPreview.BackColor, cpbDarkestColourPreview, cpbMiddleColourPreview, cpbLightColourPreview, cpbLightestColourPreview);
        }

        private void pbxDarkColour_Click(object sender, EventArgs e)
        {
            //ColourUtilities.PropagateHSBValues(knumHueValue, knumSaturation, knumBrightness, (decimal)Math.Round(pbxDarkColour.BackColor.GetHue()), (decimal)Math.Round(pbxDarkColour.BackColor.GetSaturation()), (decimal)Math.Round(pbxDarkColour.BackColor.GetBrightness()));
        }

        private void kbtnFileExport_Click(object sender, EventArgs e)
        {

        }

        private void kbtnDefineCustomColours_Click(object sender, EventArgs e)
        {
            CustomColours customColours = new CustomColours();

            customColours.Show();
        }

        private void kbtnImportColours_Click(object sender, EventArgs e)
        {
            PaletteImportManager paletteImportManager = new PaletteImportManager();

            paletteImportManager.ImportColourScheme();
        }

        private void knumAlphaChannelValue_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cpbBaseColourPreview_Click(object sender, EventArgs e)
        {
            knumAlphaChannelValue.Value = Convert.ToInt32(cpbBaseColourPreview.BackColor.A);

            knumRedChannelValue.Value = Convert.ToInt32(cpbBaseColourPreview.BackColor.R);

            knumGreenChannelValue.Value = Convert.ToInt32(cpbBaseColourPreview.BackColor.G);

            knumBlueChannelValue.Value = Convert.ToInt32(cpbBaseColourPreview.BackColor.B);
        }

        private void cpbDarkestColourPreview_Click(object sender, EventArgs e)
        {
            knumAlphaChannelValue.Value = Convert.ToInt32(cpbDarkestColourPreview.BackColor.A);

            knumRedChannelValue.Value = Convert.ToInt32(cpbDarkestColourPreview.BackColor.R);

            knumGreenChannelValue.Value = Convert.ToInt32(cpbDarkestColourPreview.BackColor.G);

            knumBlueChannelValue.Value = Convert.ToInt32(cpbDarkestColourPreview.BackColor.B);
        }

        private void cpbMiddleColourPreview_Click(object sender, EventArgs e)
        {
            knumAlphaChannelValue.Value = Convert.ToInt32(cpbMiddleColourPreview.BackColor.A);

            knumRedChannelValue.Value = Convert.ToInt32(cpbMiddleColourPreview.BackColor.R);

            knumGreenChannelValue.Value = Convert.ToInt32(cpbMiddleColourPreview.BackColor.G);

            knumBlueChannelValue.Value = Convert.ToInt32(cpbMiddleColourPreview.BackColor.B);
        }

        private void cpbLightColourPreview_Click(object sender, EventArgs e)
        {
            knumAlphaChannelValue.Value = Convert.ToInt32(cpbLightColourPreview.BackColor.A);

            knumRedChannelValue.Value = Convert.ToInt32(cpbLightColourPreview.BackColor.R);

            knumGreenChannelValue.Value = Convert.ToInt32(cpbLightColourPreview.BackColor.G);

            knumBlueChannelValue.Value = Convert.ToInt32(cpbLightColourPreview.BackColor.B);
        }

        private void cpbLightestColourPreview_Click(object sender, EventArgs e)
        {
            knumAlphaChannelValue.Value = Convert.ToInt32(cpbLightestColourPreview.BackColor.A);

            knumRedChannelValue.Value = Convert.ToInt32(cpbLightestColourPreview.BackColor.R);

            knumGreenChannelValue.Value = Convert.ToInt32(cpbLightestColourPreview.BackColor.G);

            knumBlueChannelValue.Value = Convert.ToInt32(cpbLightestColourPreview.BackColor.B);
        }

        private void kbtnDefineIndividualColours_Click(object sender, EventArgs e)
        {
            DefineIndividualColoursDialog defineIndividualColours = new DefineIndividualColoursDialog();

            defineIndividualColours.Show();
        }

        private void kbtnOptions_Click(object sender, EventArgs e)
        {
            ColourBlendingOptions colourBlendingOptions = new ColourBlendingOptions();

            colourBlendingOptions.Show();
        }

        private void ktbAlpha_ValueChanged(object sender, EventArgs e)
        {
            knumAlphaChannelValue.Value = ktbAlpha.Value;

            ttInformation.SetToolTip(ktbAlpha, ktbAlpha.Value.ToString());
        }

        private void ktbRed_ValueChanged(object sender, EventArgs e)
        {
            knumRedChannelValue.Value = ktbRed.Value;

            ttInformation.SetToolTip(ktbRed, ktbRed.Value.ToString());
        }

        private void ktbGreen_ValueChanged(object sender, EventArgs e)
        {
            knumGreenChannelValue.Value = ktbGreen.Value;

            ttInformation.SetToolTip(ktbGreen, ktbGreen.Value.ToString());
        }

        private void ktbBlue_ValueChanged(object sender, EventArgs e)
        {
            knumBlueChannelValue.Value = ktbBlue.Value;

            ttInformation.SetToolTip(ktbBlue, ktbBlue.Value.ToString());
        }

        private void kcbBaseColour_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            knumRedChannelValue.Value = kcbBaseColour.SelectedColor.R;

            knumGreenChannelValue.Value = kcbBaseColour.SelectedColor.G;

            knumBlueChannelValue.Value = kcbBaseColour.SelectedColor.B;
        }

        private void kbtnDebugConsole_Click(object sender, EventArgs e)
        {
            ColourSettingsViewer colourSettingsViewer = new ColourSettingsViewer();

            colourSettingsViewer.Show();
        }

        private void kbtnSaveValues_Click(object sender, EventArgs e)
        {

        }

        private void kbtnGenerateHue_Click(object sender, EventArgs e)
        {

        }

        private Color SetHue(Color baseColour, double hueValue)
        {
            HSLColour hslColour = new HSLColour(hue: hueValue * 240, saturation: 240, luminosity: 240);

            return hslColour;
        }

        private void UpdateUI()
        {
            cpbBaseColourPreview.BackColor = _colourSettingsManager.GetBaseColour();

            cpbDarkestColourPreview.BackColor = _colourSettingsManager.GetDarkColour();

            cpbMiddleColourPreview.BackColor = _colourSettingsManager.GetMediumColour();

            cpbLightColourPreview.BackColor = _colourSettingsManager.GetLightColour();

            cpbLightestColourPreview.BackColor = _colourSettingsManager.GetLightestColour();

            if (cpbBaseColourPreview.BackColor != Color.Empty || cpbDarkestColourPreview.BackColor != Color.Empty || cpbMiddleColourPreview.BackColor != Color.Empty || cpbLightColourPreview.BackColor != Color.Empty)
            {
                kbtnExport.Enabled = true;
            }
            else
            {
                kbtnExport.Enabled = false;
            }
        }
    }
}