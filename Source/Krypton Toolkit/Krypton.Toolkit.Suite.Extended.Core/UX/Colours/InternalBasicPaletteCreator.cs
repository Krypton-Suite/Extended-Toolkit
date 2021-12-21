#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class InternalBasicPaletteCreator : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnDebugConsole;
        private KryptonButton kbtnOptions;
        private KryptonButton kbtnImportColours;
        private KryptonButton kbtnExportColours;
        private KryptonButton kbtnGenerateColours;
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
        private KryptonLabel kryptonLabel4;
        private KryptonLabel kryptonLabel3;
        private KryptonLabel kryptonLabel2;
        private KryptonLabel kryptonLabel1;
        private KryptonTrackBar ktbBlueValue;
        private KryptonTrackBar ktbGreenValue;
        private KryptonTrackBar ktbRedValue;
        private KryptonTrackBar ktbAlphaValue;
        private KryptonNumericUpDown knudBlueValue;
        private KryptonNumericUpDown knudGreenValue;
        private KryptonNumericUpDown knudRedValue;
        private KryptonNumericUpDown knudAlphaValue;
        private KryptonButton kbtnGenerateGreen;
        private KryptonButton kbtnGenerateBlue;
        private KryptonButton kbtnGenerateRed;
        private KryptonTextBox ktxtHexadecimalValue;
        private KryptonLabel kryptonLabel5;
        private KryptonButton kbtnGenerateRandomColour;
        private KryptonColorButton kcbtnChooseBaseColour;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;

        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnDebugConsole = new Krypton.Toolkit.KryptonButton();
            this.kbtnOptions = new Krypton.Toolkit.KryptonButton();
            this.kbtnImportColours = new Krypton.Toolkit.KryptonButton();
            this.kbtnExportColours = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateColours = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.ktbBlueValue = new Krypton.Toolkit.KryptonTrackBar();
            this.ktbGreenValue = new Krypton.Toolkit.KryptonTrackBar();
            this.ktbRedValue = new Krypton.Toolkit.KryptonTrackBar();
            this.ktbAlphaValue = new Krypton.Toolkit.KryptonTrackBar();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel16 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel15 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel14 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel13 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel12 = new Krypton.Toolkit.KryptonLabel();
            this.knudBlueValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudGreenValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudRedValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudAlphaValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kbtnGenerateGreen = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateBlue = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateRed = new Krypton.Toolkit.KryptonButton();
            this.ktxtHexadecimalValue = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnGenerateRandomColour = new Krypton.Toolkit.KryptonButton();
            this.kcbtnChooseBaseColour = new Krypton.Toolkit.KryptonColorButton();
            this.cpbxLightestColour = new Krypton.Toolkit.Suite.Extended.Core.CircularPictureBox();
            this.cpbxLightColour = new Krypton.Toolkit.Suite.Extended.Core.CircularPictureBox();
            this.cpbxMediumColour = new Krypton.Toolkit.Suite.Extended.Core.CircularPictureBox();
            this.cpbxDarkestColour = new Krypton.Toolkit.Suite.Extended.Core.CircularPictureBox();
            this.cpbxBaseColour = new Krypton.Toolkit.Suite.Extended.Core.CircularPictureBox();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
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
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 563);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(735, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
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
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 513);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(735, 50);
            this.kryptonPanel1.TabIndex = 1;
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
            this.kryptonButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kryptonButton1.Location = new System.Drawing.Point(633, 13);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonButton1.TabIndex = 0;
            this.kryptonButton1.Values.Text = "&Ok";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 510);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(735, 3);
            this.panel1.TabIndex = 2;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.ktxtHexadecimalValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerateRandomColour);
            this.kryptonPanel2.Controls.Add(this.kcbtnChooseBaseColour);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerateGreen);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerateBlue);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerateRed);
            this.kryptonPanel2.Controls.Add(this.knudBlueValue);
            this.kryptonPanel2.Controls.Add(this.knudGreenValue);
            this.kryptonPanel2.Controls.Add(this.knudRedValue);
            this.kryptonPanel2.Controls.Add(this.knudAlphaValue);
            this.kryptonPanel2.Controls.Add(this.ktbBlueValue);
            this.kryptonPanel2.Controls.Add(this.ktbGreenValue);
            this.kryptonPanel2.Controls.Add(this.ktbRedValue);
            this.kryptonPanel2.Controls.Add(this.ktbAlphaValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel16);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel15);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel14);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel13);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel12);
            this.kryptonPanel2.Controls.Add(this.cpbxLightestColour);
            this.kryptonPanel2.Controls.Add(this.cpbxLightColour);
            this.kryptonPanel2.Controls.Add(this.cpbxMediumColour);
            this.kryptonPanel2.Controls.Add(this.cpbxDarkestColour);
            this.kryptonPanel2.Controls.Add(this.cpbxBaseColour);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(735, 510);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // ktbBlueValue
            // 
            this.ktbBlueValue.DrawBackground = true;
            this.ktbBlueValue.Location = new System.Drawing.Point(666, 39);
            this.ktbBlueValue.Maximum = 255;
            this.ktbBlueValue.Name = "ktbBlueValue";
            this.ktbBlueValue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktbBlueValue.Size = new System.Drawing.Size(21, 330);
            this.ktbBlueValue.StateCommon.Track.Color1 = System.Drawing.Color.Blue;
            this.ktbBlueValue.StateCommon.Track.Color2 = System.Drawing.Color.Blue;
            this.ktbBlueValue.StateCommon.Track.Color3 = System.Drawing.Color.Blue;
            this.ktbBlueValue.StateCommon.Track.Color4 = System.Drawing.Color.Blue;
            this.ktbBlueValue.StateCommon.Track.Color5 = System.Drawing.Color.Blue;
            this.ktbBlueValue.TabIndex = 95;
            this.ktbBlueValue.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // ktbGreenValue
            // 
            this.ktbGreenValue.DrawBackground = true;
            this.ktbGreenValue.Location = new System.Drawing.Point(517, 39);
            this.ktbGreenValue.Maximum = 255;
            this.ktbGreenValue.Name = "ktbGreenValue";
            this.ktbGreenValue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktbGreenValue.Size = new System.Drawing.Size(21, 330);
            this.ktbGreenValue.StateCommon.Track.Color1 = System.Drawing.Color.Green;
            this.ktbGreenValue.StateCommon.Track.Color2 = System.Drawing.Color.Green;
            this.ktbGreenValue.StateCommon.Track.Color3 = System.Drawing.Color.Green;
            this.ktbGreenValue.StateCommon.Track.Color4 = System.Drawing.Color.Green;
            this.ktbGreenValue.StateCommon.Track.Color5 = System.Drawing.Color.Green;
            this.ktbGreenValue.TabIndex = 94;
            this.ktbGreenValue.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // ktbRedValue
            // 
            this.ktbRedValue.DrawBackground = true;
            this.ktbRedValue.Location = new System.Drawing.Point(361, 39);
            this.ktbRedValue.Maximum = 255;
            this.ktbRedValue.Name = "ktbRedValue";
            this.ktbRedValue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktbRedValue.Size = new System.Drawing.Size(21, 330);
            this.ktbRedValue.StateCommon.Track.Color1 = System.Drawing.Color.Red;
            this.ktbRedValue.StateCommon.Track.Color2 = System.Drawing.Color.Red;
            this.ktbRedValue.StateCommon.Track.Color3 = System.Drawing.Color.Red;
            this.ktbRedValue.StateCommon.Track.Color4 = System.Drawing.Color.Red;
            this.ktbRedValue.StateCommon.Track.Color5 = System.Drawing.Color.Red;
            this.ktbRedValue.TabIndex = 93;
            this.ktbRedValue.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // ktbAlphaValue
            // 
            this.ktbAlphaValue.DrawBackground = true;
            this.ktbAlphaValue.Location = new System.Drawing.Point(211, 39);
            this.ktbAlphaValue.Maximum = 255;
            this.ktbAlphaValue.Name = "ktbAlphaValue";
            this.ktbAlphaValue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ktbAlphaValue.Size = new System.Drawing.Size(21, 330);
            this.ktbAlphaValue.TabIndex = 92;
            this.ktbAlphaValue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ktbAlphaValue.Value = 255;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(193, 12);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(57, 21);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonLabel4.TabIndex = 91;
            this.kryptonLabel4.Values.Text = "Alpha:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(350, 12);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(45, 21);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonLabel3.TabIndex = 90;
            this.kryptonLabel3.Values.Text = "Red:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(495, 12);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(61, 21);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonLabel2.TabIndex = 89;
            this.kryptonLabel2.Values.Text = "Green:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(656, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(48, 21);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonLabel1.TabIndex = 88;
            this.kryptonLabel1.Values.Text = "Blue:";
            // 
            // kryptonLabel16
            // 
            this.kryptonLabel16.Location = new System.Drawing.Point(20, 400);
            this.kryptonLabel16.Name = "kryptonLabel16";
            this.kryptonLabel16.Size = new System.Drawing.Size(120, 21);
            this.kryptonLabel16.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel16.TabIndex = 87;
            this.kryptonLabel16.Values.Text = "Lightest Colour";
            // 
            // kryptonLabel15
            // 
            this.kryptonLabel15.Location = new System.Drawing.Point(31, 303);
            this.kryptonLabel15.Name = "kryptonLabel15";
            this.kryptonLabel15.Size = new System.Drawing.Size(98, 21);
            this.kryptonLabel15.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel15.TabIndex = 86;
            this.kryptonLabel15.Values.Text = "Light Colour";
            // 
            // kryptonLabel14
            // 
            this.kryptonLabel14.Location = new System.Drawing.Point(20, 206);
            this.kryptonLabel14.Name = "kryptonLabel14";
            this.kryptonLabel14.Size = new System.Drawing.Size(120, 21);
            this.kryptonLabel14.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel14.TabIndex = 85;
            this.kryptonLabel14.Values.Text = "Medium Colour";
            // 
            // kryptonLabel13
            // 
            this.kryptonLabel13.Location = new System.Drawing.Point(21, 109);
            this.kryptonLabel13.Name = "kryptonLabel13";
            this.kryptonLabel13.Size = new System.Drawing.Size(118, 21);
            this.kryptonLabel13.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel13.TabIndex = 84;
            this.kryptonLabel13.Values.Text = "Darkest Colour";
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Location = new System.Drawing.Point(30, 12);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(100, 21);
            this.kryptonLabel12.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonLabel12.TabIndex = 83;
            this.kryptonLabel12.Values.Text = "Base Colour";
            // 
            // knudBlueValue
            // 
            this.knudBlueValue.Location = new System.Drawing.Point(643, 375);
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
            this.knudBlueValue.TabIndex = 99;
            // 
            // knudGreenValue
            // 
            this.knudGreenValue.Location = new System.Drawing.Point(493, 375);
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
            this.knudGreenValue.TabIndex = 98;
            // 
            // knudRedValue
            // 
            this.knudRedValue.Location = new System.Drawing.Point(343, 375);
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
            this.knudRedValue.TabIndex = 97;
            // 
            // knudAlphaValue
            // 
            this.knudAlphaValue.Location = new System.Drawing.Point(193, 375);
            this.knudAlphaValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudAlphaValue.Name = "knudAlphaValue";
            this.knudAlphaValue.Size = new System.Drawing.Size(74, 23);
            this.knudAlphaValue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knudAlphaValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knudAlphaValue.TabIndex = 96;
            this.knudAlphaValue.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // kbtnGenerateGreen
            // 
            this.kbtnGenerateGreen.Location = new System.Drawing.Point(468, 404);
            this.kbtnGenerateGreen.Name = "kbtnGenerateGreen";
            this.kbtnGenerateGreen.Size = new System.Drawing.Size(120, 25);
            this.kbtnGenerateGreen.TabIndex = 102;
            this.kbtnGenerateGreen.Values.Text = "Generate &Green";
            // 
            // kbtnGenerateBlue
            // 
            this.kbtnGenerateBlue.Location = new System.Drawing.Point(604, 404);
            this.kbtnGenerateBlue.Name = "kbtnGenerateBlue";
            this.kbtnGenerateBlue.Size = new System.Drawing.Size(119, 25);
            this.kbtnGenerateBlue.TabIndex = 101;
            this.kbtnGenerateBlue.Values.Text = "Generate &Blue";
            // 
            // kbtnGenerateRed
            // 
            this.kbtnGenerateRed.Location = new System.Drawing.Point(324, 404);
            this.kbtnGenerateRed.Name = "kbtnGenerateRed";
            this.kbtnGenerateRed.Size = new System.Drawing.Size(120, 25);
            this.kbtnGenerateRed.TabIndex = 100;
            this.kbtnGenerateRed.Values.Text = "Generate &Red";
            // 
            // ktxtHexadecimalValue
            // 
            this.ktxtHexadecimalValue.CueHint.CueHintText = "000000";
            this.ktxtHexadecimalValue.Location = new System.Drawing.Point(623, 450);
            this.ktxtHexadecimalValue.MaxLength = 6;
            this.ktxtHexadecimalValue.Name = "ktxtHexadecimalValue";
            this.ktxtHexadecimalValue.Size = new System.Drawing.Size(100, 24);
            this.ktxtHexadecimalValue.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtHexadecimalValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtHexadecimalValue.TabIndex = 107;
            this.ktxtHexadecimalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(571, 450);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(45, 21);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.kryptonLabel5.TabIndex = 106;
            this.kryptonLabel5.Values.Text = "Hex:";
            // 
            // kbtnGenerateRandomColour
            // 
            this.kbtnGenerateRandomColour.Location = new System.Drawing.Point(331, 450);
            this.kbtnGenerateRandomColour.Name = "kbtnGenerateRandomColour";
            this.kbtnGenerateRandomColour.Size = new System.Drawing.Size(177, 25);
            this.kbtnGenerateRandomColour.TabIndex = 105;
            this.kbtnGenerateRandomColour.Values.Text = "Generate a Random &Colour";
            // 
            // kcbtnChooseBaseColour
            // 
            this.kcbtnChooseBaseColour.Location = new System.Drawing.Point(128, 450);
            this.kcbtnChooseBaseColour.Name = "kcbtnChooseBaseColour";
            this.kcbtnChooseBaseColour.Size = new System.Drawing.Size(197, 25);
            this.kcbtnChooseBaseColour.TabIndex = 103;
            this.kcbtnChooseBaseColour.Values.Text = "Ch&oose a Base Colour";
            // 
            // cpbxLightestColour
            // 
            this.cpbxLightestColour.BackColor = System.Drawing.Color.White;
            this.cpbxLightestColour.Location = new System.Drawing.Point(47, 427);
            this.cpbxLightestColour.Name = "cpbxLightestColour";
            this.cpbxLightestColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLightestColour.TabIndex = 82;
            this.cpbxLightestColour.TabStop = false;
            this.cpbxLightestColour.ToolTipValues = null;
            // 
            // cpbxLightColour
            // 
            this.cpbxLightColour.BackColor = System.Drawing.Color.White;
            this.cpbxLightColour.Location = new System.Drawing.Point(47, 330);
            this.cpbxLightColour.Name = "cpbxLightColour";
            this.cpbxLightColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxLightColour.TabIndex = 81;
            this.cpbxLightColour.TabStop = false;
            this.cpbxLightColour.ToolTipValues = null;
            // 
            // cpbxMediumColour
            // 
            this.cpbxMediumColour.BackColor = System.Drawing.Color.White;
            this.cpbxMediumColour.Location = new System.Drawing.Point(47, 233);
            this.cpbxMediumColour.Name = "cpbxMediumColour";
            this.cpbxMediumColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxMediumColour.TabIndex = 80;
            this.cpbxMediumColour.TabStop = false;
            this.cpbxMediumColour.ToolTipValues = null;
            // 
            // cpbxDarkestColour
            // 
            this.cpbxDarkestColour.BackColor = System.Drawing.Color.White;
            this.cpbxDarkestColour.Location = new System.Drawing.Point(47, 136);
            this.cpbxDarkestColour.Name = "cpbxDarkestColour";
            this.cpbxDarkestColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxDarkestColour.TabIndex = 79;
            this.cpbxDarkestColour.TabStop = false;
            this.cpbxDarkestColour.ToolTipValues = null;
            // 
            // cpbxBaseColour
            // 
            this.cpbxBaseColour.BackColor = System.Drawing.Color.White;
            this.cpbxBaseColour.Location = new System.Drawing.Point(47, 39);
            this.cpbxBaseColour.Name = "cpbxBaseColour";
            this.cpbxBaseColour.Size = new System.Drawing.Size(64, 64);
            this.cpbxBaseColour.TabIndex = 78;
            this.cpbxBaseColour.TabStop = false;
            this.cpbxBaseColour.ToolTipValues = null;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // InternalBasicPaletteCreator
            // 
            this.ClientSize = new System.Drawing.Size(735, 585);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InternalBasicPaletteCreator";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.InternalBasicPaletteCreator_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
            this.PerformLayout();

        }

        #endregion

        #region Variables
        private ConversionMethods _conversionMethods = new ConversionMethods();

        private RandomNumberGenerator _randomNumberGenerator = new RandomNumberGenerator();

        private HSLColour _hslColour = new HSLColour();

        private ColourControlManager _colourControlManager = new ColourControlManager();

        private GlobalBooleanSettingsManager _globalBooleanSettingsManager = new GlobalBooleanSettingsManager();

        private AllMergedPaletteColourSettingsManager _colourSettingsManager = new AllMergedPaletteColourSettingsManager();

        private Color _baseColour, _colourDark, _colourNormal, _colourLight, _colourLightness;

        private bool _paletteColourSelector;
        #endregion

        #region Properties
        public Color BaseColour { get { return _baseColour; } set { _baseColour = value; } }

        public bool PaletteColourSelector { get { return _paletteColourSelector; } set { _paletteColourSelector = value; } }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="InternalBasicPaletteCreator" /> class.</summary>
        public InternalBasicPaletteCreator()
        {
            InitializeComponent();
        }

        /// <summary>Initializes a new instance of the <see cref="InternalBasicPaletteCreator" /> class.</summary>
        /// <param name="alphaValue">The alpha value.</param>
        /// <param name="redValue">The red value.</param>
        /// <param name="greenValue">The green value.</param>
        /// <param name="blueValue">The blue value.</param>
        public InternalBasicPaletteCreator(int alphaValue, int redValue, int greenValue, int blueValue)
        {
            InitializeComponent();

            knudAlphaValue.Value = alphaValue;

            knudRedValue.Value = redValue;

            knudGreenValue.Value = greenValue;

            knudBlueValue.Value = blueValue;
        }

        /// <summary>Initializes a new instance of the <see cref="InternalBasicPaletteCreator" /> class.</summary>
        /// <param name="baseColour">The base colour.</param>
        public InternalBasicPaletteCreator(Color baseColour)
        {
            InitializeComponent();

            BaseColour = baseColour;

            cpbxBaseColour.BackColor = BaseColour;
        }

        /// <summary>Initializes a new instance of the <see cref="InternalBasicPaletteCreator" /> class.</summary>
        /// <param name="paletteColourSelector">if set to <c>true</c> [palette colour selector].</param>
        public InternalBasicPaletteCreator(bool paletteColourSelector)
        {
            InitializeComponent();

            PaletteColourSelector = paletteColourSelector;
        }

        /// <summary>Initializes a new instance of the <see cref="InternalBasicPaletteCreator" /> class.</summary>
        /// <param name="paletteColourSelector">if set to <c>true</c> [palette colour selector].</param>
        /// <param name="alphaValue">The alpha value.</param>
        /// <param name="redValue">The red value.</param>
        /// <param name="greenValue">The green value.</param>
        /// <param name="blueValue">The blue value.</param>
        public InternalBasicPaletteCreator(bool paletteColourSelector, int alphaValue, int redValue, int greenValue, int blueValue)
        {
            InitializeComponent();

            PaletteColourSelector = paletteColourSelector;

            knudAlphaValue.Value = alphaValue;

            knudRedValue.Value = redValue;

            knudGreenValue.Value = greenValue;

            knudBlueValue.Value = blueValue;
        }

        /// <summary>Initializes a new instance of the <see cref="InternalBasicPaletteCreator" /> class.</summary>
        /// <param name="paletteColourSelector">if set to <c>true</c> [palette colour selector].</param>
        /// <param name="baseColour">The base colour.</param>
        public InternalBasicPaletteCreator(bool paletteColourSelector, Color baseColour)
        {
            InitializeComponent();

            PaletteColourSelector = paletteColourSelector;

            BaseColour = baseColour;

            cpbxBaseColour.BackColor = BaseColour;
        }
        #endregion

        private void InternalBasicPaletteCreator_Load(object sender, EventArgs e)
        {

        }
    }
}