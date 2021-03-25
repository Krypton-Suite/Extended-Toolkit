﻿namespace Krypton.Toolkit.Suite.Extended.Core
{
    /*
    internal class InternalKryptonPaletteBasicColourCreator : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kryptonButton1;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private CircularPictureBox cpbxLightestColour;
        private CircularPictureBox cpbxLightColour;
        private CircularPictureBox cpbxMediumColour;
        private CircularPictureBox cpbxDarkestColour;
        private CircularPictureBox cpbxBaseColour;
        private KryptonLabel kryptonLabel16;
        private KryptonLabel kryptonLabel15;
        private KryptonLabel kryptonLabel14;
        private KryptonLabel kryptonLabel13;
        private KryptonLabel kryptonLabel12;
        private KryptonColorButton kcbtnChooseBaseColour;
        private KryptonLabel kryptonLabel4;
        private KryptonLabel kryptonLabel3;
        private KryptonLabel kryptonLabel2;
        private KryptonLabel kryptonLabel1;
        private KryptonNumericUpDown knudBlueValue;
        private KryptonNumericUpDown knudGreenValue;
        private KryptonNumericUpDown knudRedValue;
        private KryptonNumericUpDown knudAlphaValue;
        private KryptonTrackBar ktbBlueValue;
        private KryptonTrackBar ktbGreenValue;
        private KryptonTrackBar ktbRedValue;
        private KryptonTrackBar ktbAlphaValue;
        private KryptonButton kbtnDefineCustomTextColours;
        private KryptonButton kbtnGenerateColours;
        private KryptonButton kbtnExportColours;
        private KryptonButton kbtnImportColours;
        private KryptonButton kbtnDebugConsole;
        private KryptonButton kbtnOptions;
        private KryptonTextBox ktxtHexadecimalValue;
        private KryptonLabel kryptonLabel5;
        private KryptonButton kbtnGenerateRandomColour;
        private KryptonButton kbtnGenerateGreen;
        private KryptonButton kbtnGenerateBlue;
        private KryptonButton kbtnGenerateRed;
        private System.ComponentModel.IContainer components;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnDebugConsole = new Krypton.Toolkit.KryptonButton();
            this.kbtnOptions = new Krypton.Toolkit.KryptonButton();
            this.kbtnImportColours = new Krypton.Toolkit.KryptonButton();
            this.kbtnExportColours = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateColours = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.ktxtHexadecimalValue = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnGenerateRandomColour = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateGreen = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateBlue = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateRed = new Krypton.Toolkit.KryptonButton();
            this.kbtnDefineCustomTextColours = new Krypton.Toolkit.KryptonButton();
            this.ktbBlueValue = new Krypton.Toolkit.KryptonTrackBar();
            this.ktbGreenValue = new Krypton.Toolkit.KryptonTrackBar();
            this.ktbRedValue = new Krypton.Toolkit.KryptonTrackBar();
            this.ktbAlphaValue = new Krypton.Toolkit.KryptonTrackBar();
            this.knudBlueValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudGreenValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudRedValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudAlphaValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kcbtnChooseBaseColour = new Krypton.Toolkit.KryptonColorButton();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.cpbxLightestColour = new Krypton.Toolkit.Suite.Extended.Core.CircularPictureBox();
            this.cpbxLightColour = new Krypton.Toolkit.Suite.Extended.Core.CircularPictureBox();
            this.cpbxMediumColour = new Krypton.Toolkit.Suite.Extended.Core.CircularPictureBox();
            this.cpbxDarkestColour = new Krypton.Toolkit.Suite.Extended.Core.CircularPictureBox();
            this.cpbxBaseColour = new Krypton.Toolkit.Suite.Extended.Core.CircularPictureBox();
            this.kryptonLabel16 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel15 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel14 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel13 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel12 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLightestColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLightColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxMediumColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxDarkestColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxBaseColour)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnDebugConsole);
            this.kryptonPanel1.Controls.Add(this.kbtnOptions);
            this.kryptonPanel1.Controls.Add(this.kbtnImportColours);
            this.kryptonPanel1.Controls.Add(this.kbtnExportColours);
            this.kryptonPanel1.Controls.Add(this.kbtnGenerateColours);
            this.kryptonPanel1.Controls.Add(this.kryptonButton1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 389);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(851, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnDebugConsole
            // 
            this.kbtnDebugConsole.Location = new System.Drawing.Point(432, 13);
            this.kbtnDebugConsole.Name = "kbtnDebugConsole";
            this.kbtnDebugConsole.Size = new System.Drawing.Size(96, 25);
            this.kbtnDebugConsole.TabIndex = 5;
            this.kbtnDebugConsole.Values.Text = "&Debug Console";
            this.kbtnDebugConsole.Visible = false;
            // 
            // kbtnOptions
            // 
            this.kbtnOptions.Location = new System.Drawing.Point(335, 13);
            this.kbtnOptions.Name = "kbtnOptions";
            this.kbtnOptions.Size = new System.Drawing.Size(90, 25);
            this.kbtnOptions.TabIndex = 4;
            this.kbtnOptions.Values.Text = "O&ptions";
            // 
            // kbtnImportColours
            // 
            this.kbtnImportColours.Location = new System.Drawing.Point(224, 13);
            this.kbtnImportColours.Name = "kbtnImportColours";
            this.kbtnImportColours.Size = new System.Drawing.Size(104, 25);
            this.kbtnImportColours.TabIndex = 3;
            this.kbtnImportColours.Values.Text = "I&mport Colours";
            // 
            // kbtnExportColours
            // 
            this.kbtnExportColours.Enabled = false;
            this.kbtnExportColours.Location = new System.Drawing.Point(128, 13);
            this.kbtnExportColours.Name = "kbtnExportColours";
            this.kbtnExportColours.Size = new System.Drawing.Size(90, 25);
            this.kbtnExportColours.TabIndex = 2;
            this.kbtnExportColours.Values.Text = "Ex&port Colours";
            // 
            // kbtnGenerateColours
            // 
            this.kbtnGenerateColours.Location = new System.Drawing.Point(13, 13);
            this.kbtnGenerateColours.Name = "kbtnGenerateColours";
            this.kbtnGenerateColours.Size = new System.Drawing.Size(109, 25);
            this.kbtnGenerateColours.TabIndex = 1;
            this.kbtnGenerateColours.Values.Text = "&Generate Colours";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kryptonButton1.Location = new System.Drawing.Point(749, 13);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonButton1.TabIndex = 0;
            this.kryptonButton1.Values.Text = "&Ok";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 386);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.ktxtHexadecimalValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerateRandomColour);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerateGreen);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerateBlue);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerateRed);
            this.kryptonPanel2.Controls.Add(this.kbtnDefineCustomTextColours);
            this.kryptonPanel2.Controls.Add(this.ktbBlueValue);
            this.kryptonPanel2.Controls.Add(this.ktbGreenValue);
            this.kryptonPanel2.Controls.Add(this.ktbRedValue);
            this.kryptonPanel2.Controls.Add(this.ktbAlphaValue);
            this.kryptonPanel2.Controls.Add(this.knudBlueValue);
            this.kryptonPanel2.Controls.Add(this.knudGreenValue);
            this.kryptonPanel2.Controls.Add(this.knudRedValue);
            this.kryptonPanel2.Controls.Add(this.knudAlphaValue);
            this.kryptonPanel2.Controls.Add(this.kcbtnChooseBaseColour);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Controls.Add(this.cpbxLightestColour);
            this.kryptonPanel2.Controls.Add(this.cpbxLightColour);
            this.kryptonPanel2.Controls.Add(this.cpbxMediumColour);
            this.kryptonPanel2.Controls.Add(this.cpbxDarkestColour);
            this.kryptonPanel2.Controls.Add(this.cpbxBaseColour);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel16);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel15);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel14);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel13);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel12);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(851, 386);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // ktxtHexadecimalValue
            // 
            this.ktxtHexadecimalValue.Hint = "000000";
            this.ktxtHexadecimalValue.Location = new System.Drawing.Point(638, 355);
            this.ktxtHexadecimalValue.MaxLength = 6;
            this.ktxtHexadecimalValue.Name = "ktxtHexadecimalValue";
            this.ktxtHexadecimalValue.Size = new System.Drawing.Size(100, 24);
            this.ktxtHexadecimalValue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtHexadecimalValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtHexadecimalValue.TabIndex = 97;
            this.ktxtHexadecimalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(586, 355);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(45, 21);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonLabel5.TabIndex = 96;
            this.kryptonLabel5.Values.Text = "Hex:";
            // 
            // kbtnGenerateRandomColour
            // 
            this.kbtnGenerateRandomColour.Location = new System.Drawing.Point(403, 355);
            this.kbtnGenerateRandomColour.Name = "kbtnGenerateRandomColour";
            this.kbtnGenerateRandomColour.Size = new System.Drawing.Size(177, 25);
            this.kbtnGenerateRandomColour.TabIndex = 95;
            this.kbtnGenerateRandomColour.Values.Text = "Generate a Random &Colour";
            // 
            // kbtnGenerateGreen
            // 
            this.kbtnGenerateGreen.Location = new System.Drawing.Point(719, 267);
            this.kbtnGenerateGreen.Name = "kbtnGenerateGreen";
            this.kbtnGenerateGreen.Size = new System.Drawing.Size(120, 25);
            this.kbtnGenerateGreen.TabIndex = 94;
            this.kbtnGenerateGreen.Values.Text = "Generate &Green";
            // 
            // kbtnGenerateBlue
            // 
            this.kbtnGenerateBlue.Location = new System.Drawing.Point(719, 313);
            this.kbtnGenerateBlue.Name = "kbtnGenerateBlue";
            this.kbtnGenerateBlue.Size = new System.Drawing.Size(119, 25);
            this.kbtnGenerateBlue.TabIndex = 93;
            this.kbtnGenerateBlue.Values.Text = "Generate &Blue";
            // 
            // kbtnGenerateRed
            // 
            this.kbtnGenerateRed.Location = new System.Drawing.Point(719, 227);
            this.kbtnGenerateRed.Name = "kbtnGenerateRed";
            this.kbtnGenerateRed.Size = new System.Drawing.Size(120, 25);
            this.kbtnGenerateRed.TabIndex = 92;
            this.kbtnGenerateRed.Values.Text = "Generate &Red";
            // 
            // kbtnDefineCustomTextColours
            // 
            this.kbtnDefineCustomTextColours.Location = new System.Drawing.Point(217, 355);
            this.kbtnDefineCustomTextColours.Name = "kbtnDefineCustomTextColours";
            this.kbtnDefineCustomTextColours.Size = new System.Drawing.Size(180, 25);
            this.kbtnDefineCustomTextColours.TabIndex = 91;
            this.kbtnDefineCustomTextColours.Values.Text = "Define Custom Text &Colours";
            // 
            // ktbBlueValue
            // 
            this.ktbBlueValue.DrawBackground = true;
            this.ktbBlueValue.Location = new System.Drawing.Point(179, 315);
            this.ktbBlueValue.Maximum = 255;
            this.ktbBlueValue.Name = "ktbBlueValue";
            this.ktbBlueValue.Size = new System.Drawing.Size(533, 21);
            this.ktbBlueValue.StateCommon.Track.Color1 = System.Drawing.Color.Blue;
            this.ktbBlueValue.StateCommon.Track.Color2 = System.Drawing.Color.Blue;
            this.ktbBlueValue.StateCommon.Track.Color3 = System.Drawing.Color.Blue;
            this.ktbBlueValue.StateCommon.Track.Color4 = System.Drawing.Color.Blue;
            this.ktbBlueValue.StateCommon.Track.Color5 = System.Drawing.Color.Blue;
            this.ktbBlueValue.TabIndex = 90;
            this.ktbBlueValue.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // ktbGreenValue
            // 
            this.ktbGreenValue.DrawBackground = true;
            this.ktbGreenValue.Location = new System.Drawing.Point(179, 271);
            this.ktbGreenValue.Maximum = 255;
            this.ktbGreenValue.Name = "ktbGreenValue";
            this.ktbGreenValue.Size = new System.Drawing.Size(533, 21);
            this.ktbGreenValue.StateCommon.Track.Color1 = System.Drawing.Color.Green;
            this.ktbGreenValue.StateCommon.Track.Color2 = System.Drawing.Color.Green;
            this.ktbGreenValue.StateCommon.Track.Color3 = System.Drawing.Color.Green;
            this.ktbGreenValue.StateCommon.Track.Color4 = System.Drawing.Color.Green;
            this.ktbGreenValue.StateCommon.Track.Color5 = System.Drawing.Color.Green;
            this.ktbGreenValue.TabIndex = 89;
            this.ktbGreenValue.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // ktbRedValue
            // 
            this.ktbRedValue.DrawBackground = true;
            this.ktbRedValue.Location = new System.Drawing.Point(179, 227);
            this.ktbRedValue.Maximum = 255;
            this.ktbRedValue.Name = "ktbRedValue";
            this.ktbRedValue.Size = new System.Drawing.Size(533, 21);
            this.ktbRedValue.StateCommon.Track.Color1 = System.Drawing.Color.Red;
            this.ktbRedValue.StateCommon.Track.Color2 = System.Drawing.Color.Red;
            this.ktbRedValue.StateCommon.Track.Color3 = System.Drawing.Color.Red;
            this.ktbRedValue.StateCommon.Track.Color4 = System.Drawing.Color.Red;
            this.ktbRedValue.StateCommon.Track.Color5 = System.Drawing.Color.Red;
            this.ktbRedValue.TabIndex = 88;
            this.ktbRedValue.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // ktbAlphaValue
            // 
            this.ktbAlphaValue.DrawBackground = true;
            this.ktbAlphaValue.Location = new System.Drawing.Point(179, 183);
            this.ktbAlphaValue.Maximum = 255;
            this.ktbAlphaValue.Name = "ktbAlphaValue";
            this.ktbAlphaValue.Size = new System.Drawing.Size(533, 21);
            this.ktbAlphaValue.TabIndex = 87;
            this.ktbAlphaValue.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // knudBlueValue
            // 
            this.knudBlueValue.Location = new System.Drawing.Point(99, 315);
            this.knudBlueValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBlueValue.Name = "knudBlueValue";
            this.knudBlueValue.Size = new System.Drawing.Size(74, 23);
            this.knudBlueValue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knudBlueValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudBlueValue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudBlueValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudBlueValue.TabIndex = 86;
            // 
            // knudGreenValue
            // 
            this.knudGreenValue.Location = new System.Drawing.Point(99, 271);
            this.knudGreenValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudGreenValue.Name = "knudGreenValue";
            this.knudGreenValue.Size = new System.Drawing.Size(74, 23);
            this.knudGreenValue.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.knudGreenValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudGreenValue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudGreenValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudGreenValue.TabIndex = 85;
            // 
            // knudRedValue
            // 
            this.knudRedValue.Location = new System.Drawing.Point(99, 229);
            this.knudRedValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudRedValue.Name = "knudRedValue";
            this.knudRedValue.Size = new System.Drawing.Size(74, 23);
            this.knudRedValue.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knudRedValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knudRedValue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudRedValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudRedValue.TabIndex = 84;
            // 
            // knudAlphaValue
            // 
            this.knudAlphaValue.Location = new System.Drawing.Point(99, 183);
            this.knudAlphaValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudAlphaValue.Name = "knudAlphaValue";
            this.knudAlphaValue.Size = new System.Drawing.Size(74, 23);
            this.knudAlphaValue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudAlphaValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudAlphaValue.TabIndex = 83;
            // 
            // kcbtnChooseBaseColour
            // 
            this.kcbtnChooseBaseColour.Location = new System.Drawing.Point(13, 355);
            this.kcbtnChooseBaseColour.Name = "kcbtnChooseBaseColour";
            this.kcbtnChooseBaseColour.Size = new System.Drawing.Size(197, 25);
            this.kcbtnChooseBaseColour.TabIndex = 82;
            this.kcbtnChooseBaseColour.Values.Text = "Ch&oose a Base Colour";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(22, 183);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(57, 21);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonLabel4.TabIndex = 81;
            this.kryptonLabel4.Values.Text = "Alpha:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(22, 227);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(45, 21);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonLabel3.TabIndex = 80;
            this.kryptonLabel3.Values.Text = "Red:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(22, 271);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(61, 21);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonLabel2.TabIndex = 79;
            this.kryptonLabel2.Values.Text = "Green:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(22, 315);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(48, 21);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonLabel1.TabIndex = 78;
            this.kryptonLabel1.Values.Text = "Blue:";
            // 
            // cpbxLightestColour
            // 
            this.cpbxLightestColour.BackColor = System.Drawing.Color.Transparent;
            this.cpbxLightestColour.Location = new System.Drawing.Point(709, 40);
            this.cpbxLightestColour.Name = "cpbxLightestColour";
            this.cpbxLightestColour.Size = new System.Drawing.Size(128, 128);
            this.cpbxLightestColour.TabIndex = 77;
            this.cpbxLightestColour.TabStop = false;
            this.cpbxLightestColour.ToolTipValues = null;
            // 
            // cpbxLightColour
            // 
            this.cpbxLightColour.BackColor = System.Drawing.Color.Transparent;
            this.cpbxLightColour.Location = new System.Drawing.Point(535, 40);
            this.cpbxLightColour.Name = "cpbxLightColour";
            this.cpbxLightColour.Size = new System.Drawing.Size(128, 128);
            this.cpbxLightColour.TabIndex = 76;
            this.cpbxLightColour.TabStop = false;
            this.cpbxLightColour.ToolTipValues = null;
            // 
            // cpbxMediumColour
            // 
            this.cpbxMediumColour.BackColor = System.Drawing.Color.Transparent;
            this.cpbxMediumColour.Location = new System.Drawing.Point(361, 39);
            this.cpbxMediumColour.Name = "cpbxMediumColour";
            this.cpbxMediumColour.Size = new System.Drawing.Size(128, 128);
            this.cpbxMediumColour.TabIndex = 75;
            this.cpbxMediumColour.TabStop = false;
            this.cpbxMediumColour.ToolTipValues = null;
            // 
            // cpbxDarkestColour
            // 
            this.cpbxDarkestColour.BackColor = System.Drawing.Color.Transparent;
            this.cpbxDarkestColour.Location = new System.Drawing.Point(187, 39);
            this.cpbxDarkestColour.Name = "cpbxDarkestColour";
            this.cpbxDarkestColour.Size = new System.Drawing.Size(128, 128);
            this.cpbxDarkestColour.TabIndex = 74;
            this.cpbxDarkestColour.TabStop = false;
            this.cpbxDarkestColour.ToolTipValues = null;
            // 
            // cpbxBaseColour
            // 
            this.cpbxBaseColour.BackColor = System.Drawing.Color.Transparent;
            this.cpbxBaseColour.Location = new System.Drawing.Point(13, 40);
            this.cpbxBaseColour.Name = "cpbxBaseColour";
            this.cpbxBaseColour.Size = new System.Drawing.Size(128, 128);
            this.cpbxBaseColour.TabIndex = 73;
            this.cpbxBaseColour.TabStop = false;
            this.cpbxBaseColour.ToolTipValues = null;
            // 
            // kryptonLabel16
            // 
            this.kryptonLabel16.Location = new System.Drawing.Point(718, 12);
            this.kryptonLabel16.Name = "kryptonLabel16";
            this.kryptonLabel16.Size = new System.Drawing.Size(120, 21);
            this.kryptonLabel16.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel16.TabIndex = 72;
            this.kryptonLabel16.Values.Text = "Lightest Colour";
            // 
            // kryptonLabel15
            // 
            this.kryptonLabel15.Location = new System.Drawing.Point(555, 12);
            this.kryptonLabel15.Name = "kryptonLabel15";
            this.kryptonLabel15.Size = new System.Drawing.Size(98, 21);
            this.kryptonLabel15.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel15.TabIndex = 71;
            this.kryptonLabel15.Values.Text = "Light Colour";
            // 
            // kryptonLabel14
            // 
            this.kryptonLabel14.Location = new System.Drawing.Point(370, 12);
            this.kryptonLabel14.Name = "kryptonLabel14";
            this.kryptonLabel14.Size = new System.Drawing.Size(120, 21);
            this.kryptonLabel14.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel14.TabIndex = 70;
            this.kryptonLabel14.Values.Text = "Medium Colour";
            // 
            // kryptonLabel13
            // 
            this.kryptonLabel13.Location = new System.Drawing.Point(187, 12);
            this.kryptonLabel13.Name = "kryptonLabel13";
            this.kryptonLabel13.Size = new System.Drawing.Size(118, 21);
            this.kryptonLabel13.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel13.TabIndex = 69;
            this.kryptonLabel13.Values.Text = "Darkest Colour";
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Location = new System.Drawing.Point(22, 12);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(100, 21);
            this.kryptonLabel12.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonLabel12.TabIndex = 68;
            this.kryptonLabel12.Values.Text = "Base Colour";
            // 
            // InternalKryptonPaletteBasicColourCreator
            // 
            this.ClientSize = new System.Drawing.Size(851, 439);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InternalKryptonPaletteBasicColourCreator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Basic Palette Colour Creator";
            this.Load += new System.EventHandler(this.InternalKryptonPaletteBasicColourCreator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLightestColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxLightColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxMediumColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxDarkestColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbxBaseColour)).EndInit();
            this.ResumeLayout(false);

        }
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

        #region Constructor
        public InternalKryptonPaletteBasicColourCreator()
        {
            InitializeComponent();
        }

        public InternalKryptonPaletteBasicColourCreator(int alphaValue, int redValue, int greenValue, int blueValue)
        {
            InitializeComponent();

            knudAlphaValue.Value = alphaValue;

            knudRedValue.Value = redValue;

            knudGreenValue.Value = greenValue;

            knudBlueValue.Value = blueValue;
        }

        public InternalKryptonPaletteBasicColourCreator(Color baseColour)
        {
            InitializeComponent();

            BaseColour = baseColour;

            cpbxBaseColour.BackColor = BaseColour;
        }

        public InternalKryptonPaletteBasicColourCreator(bool paletteColourSelector)
        {
            InitializeComponent();

            PaletteColourSelector = paletteColourSelector;
        }

        public InternalKryptonPaletteBasicColourCreator(bool paletteColourSelector, int alphaValue, int redValue, int greenValue, int blueValue)
        {
            InitializeComponent();

            PaletteColourSelector = paletteColourSelector;

            knudAlphaValue.Value = alphaValue;

            knudRedValue.Value = redValue;

            knudGreenValue.Value = greenValue;

            knudBlueValue.Value = blueValue;
        }

        public InternalKryptonPaletteBasicColourCreator(bool paletteColourSelector, Color baseColour)
        {
            InitializeComponent();

            PaletteColourSelector = paletteColourSelector;

            BaseColour = baseColour;

            cpbxBaseColour.BackColor = BaseColour;
        }
        #endregion

        private void InternalKryptonPaletteBasicColourCreator_Load(object sender, EventArgs e)
        {

        }
    }
    */
}
