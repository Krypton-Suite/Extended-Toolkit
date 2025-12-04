#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Core;

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
    private KryptonBorderEdge kryptonBorderEdge1;
    private KryptonTableLayoutPanel kryptonTableLayoutPanel1;
    private System.Windows.Forms.StatusStrip statusStrip1;

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new(typeof(InternalBasicPaletteCreator));
        this.statusStrip1 = new();
        this.toolStripStatusLabel1 = new();
        this.kryptonPanel1 = new();
        this.kbtnDebugConsole = new();
        this.kbtnOptions = new();
        this.kbtnImportColours = new();
        this.kbtnExportColours = new();
        this.kbtnGenerateColours = new();
        this.kryptonButton1 = new();
        this.kryptonPanel2 = new();
        this.ktxtHexadecimalValue = new();
        this.kryptonLabel5 = new();
        this.kbtnGenerateRandomColour = new();
        this.kcbtnChooseBaseColour = new();
        this.kbtnGenerateGreen = new();
        this.kbtnGenerateBlue = new();
        this.kbtnGenerateRed = new();
        this.knudBlueValue = new();
        this.knudGreenValue = new();
        this.knudRedValue = new();
        this.knudAlphaValue = new();
        this.ktbBlueValue = new();
        this.ktbGreenValue = new();
        this.ktbRedValue = new();
        this.ktbAlphaValue = new();
        this.kryptonLabel4 = new();
        this.kryptonLabel3 = new();
        this.kryptonLabel2 = new();
        this.kryptonLabel1 = new();
        this.kryptonLabel16 = new();
        this.kryptonLabel15 = new();
        this.kryptonLabel14 = new();
        this.kryptonLabel13 = new();
        this.kryptonLabel12 = new();
        this.cpbxLightestColour = new();
        this.cpbxLightColour = new();
        this.cpbxMediumColour = new();
        this.cpbxDarkestColour = new();
        this.cpbxBaseColour = new();
        this.kryptonBorderEdge1 = new();
        this.kryptonTableLayoutPanel1 = new();
        this.statusStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.kryptonPanel1).BeginInit();
        this.kryptonPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.kryptonPanel2).BeginInit();
        this.kryptonPanel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.cpbxLightestColour).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.cpbxLightColour).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.cpbxMediumColour).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.cpbxDarkestColour).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.cpbxBaseColour).BeginInit();
        this.kryptonTableLayoutPanel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // statusStrip1
        // 
        this.statusStrip1.Font = new("Segoe UI", 9F);
        this.statusStrip1.Items.AddRange([
            this.toolStripStatusLabel1
        ]);
        this.statusStrip1.Location = new(0, 627);
        this.statusStrip1.Name = "statusStrip1";
        this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
        this.statusStrip1.Size = new(854, 22);
        this.statusStrip1.TabIndex = 0;
        this.statusStrip1.Text = "statusStrip1";
        // 
        // toolStripStatusLabel1
        // 
        this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
        this.toolStripStatusLabel1.Size = new(118, 17);
        this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
        // 
        // kryptonPanel1
        // 
        this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
        this.kryptonPanel1.Controls.Add(this.kbtnDebugConsole);
        this.kryptonPanel1.Controls.Add(this.kbtnOptions);
        this.kryptonPanel1.Controls.Add(this.kbtnImportColours);
        this.kryptonPanel1.Controls.Add(this.kbtnExportColours);
        this.kryptonPanel1.Controls.Add(this.kbtnGenerateColours);
        this.kryptonPanel1.Controls.Add(this.kryptonButton1);
        this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.kryptonPanel1.Location = new(0, 577);
        this.kryptonPanel1.Name = "kryptonPanel1";
        this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
        this.kryptonPanel1.Size = new(854, 50);
        this.kryptonPanel1.TabIndex = 1;
        // 
        // kbtnDebugConsole
        // 
        this.kbtnDebugConsole.Location = new(432, 13);
        this.kbtnDebugConsole.Name = "kbtnDebugConsole";
        this.kbtnDebugConsole.Size = new(96, 25);
        this.kbtnDebugConsole.TabIndex = 5;
        this.kbtnDebugConsole.Values.Text = "&Debug Console";
        this.kbtnDebugConsole.Visible = false;
        // 
        // kbtnOptions
        // 
        this.kbtnOptions.Location = new(335, 13);
        this.kbtnOptions.Name = "kbtnOptions";
        this.kbtnOptions.Size = new(90, 25);
        this.kbtnOptions.TabIndex = 4;
        this.kbtnOptions.Values.Text = "O&ptions";
        // 
        // kbtnImportColours
        // 
        this.kbtnImportColours.Location = new(224, 13);
        this.kbtnImportColours.Name = "kbtnImportColours";
        this.kbtnImportColours.Size = new(104, 25);
        this.kbtnImportColours.TabIndex = 3;
        this.kbtnImportColours.Values.Text = "I&mport Colours";
        // 
        // kbtnExportColours
        // 
        this.kbtnExportColours.Enabled = false;
        this.kbtnExportColours.Location = new(128, 13);
        this.kbtnExportColours.Name = "kbtnExportColours";
        this.kbtnExportColours.Size = new(90, 25);
        this.kbtnExportColours.TabIndex = 2;
        this.kbtnExportColours.Values.Text = "Ex&port Colours";
        // 
        // kbtnGenerateColours
        // 
        this.kbtnGenerateColours.Location = new(13, 13);
        this.kbtnGenerateColours.Name = "kbtnGenerateColours";
        this.kbtnGenerateColours.Size = new(109, 25);
        this.kbtnGenerateColours.TabIndex = 1;
        this.kbtnGenerateColours.Values.Text = "&Generate Colours";
        // 
        // kryptonButton1
        // 
        this.kryptonButton1.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        this.kryptonButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.kryptonButton1.Location = new(752, 13);
        this.kryptonButton1.Name = "kryptonButton1";
        this.kryptonButton1.Size = new(90, 25);
        this.kryptonButton1.TabIndex = 0;
        this.kryptonButton1.Values.Text = "&Ok";
        // 
        // kryptonPanel2
        // 
        this.kryptonPanel2.Controls.Add(this.kryptonTableLayoutPanel1);
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
        this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.kryptonPanel2.Location = new(0, 0);
        this.kryptonPanel2.Name = "kryptonPanel2";
        this.kryptonPanel2.Size = new(854, 577);
        this.kryptonPanel2.TabIndex = 3;
        // 
        // ktxtHexadecimalValue
        // 
        this.ktxtHexadecimalValue.CueHint.CueHintText = "000000";
        this.ktxtHexadecimalValue.Location = new(742, 537);
        this.ktxtHexadecimalValue.MaxLength = 6;
        this.ktxtHexadecimalValue.Name = "ktxtHexadecimalValue";
        this.ktxtHexadecimalValue.Size = new(100, 24);
        this.ktxtHexadecimalValue.StateCommon.Content.Font = new("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        this.ktxtHexadecimalValue.TabIndex = 107;
        this.ktxtHexadecimalValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        // 
        // kryptonLabel5
        // 
        this.kryptonLabel5.Location = new(678, 537);
        this.kryptonLabel5.Name = "kryptonLabel5";
        this.kryptonLabel5.Size = new(45, 21);
        this.kryptonLabel5.StateCommon.ShortText.Font = new("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
        this.kryptonLabel5.TabIndex = 106;
        this.kryptonLabel5.Values.Text = "Hex:";
        // 
        // kbtnGenerateRandomColour
        // 
        this.kbtnGenerateRandomColour.Location = new(493, 537);
        this.kbtnGenerateRandomColour.Name = "kbtnGenerateRandomColour";
        this.kbtnGenerateRandomColour.Size = new(177, 25);
        this.kbtnGenerateRandomColour.TabIndex = 105;
        this.kbtnGenerateRandomColour.Values.Text = "Generate a Random &Colour";
        // 
        // kcbtnChooseBaseColour
        // 
        this.kcbtnChooseBaseColour.CustomColorPreviewShape = Krypton.Toolkit.KryptonColorButtonCustomColorPreviewShape.Circle;
        this.kcbtnChooseBaseColour.Location = new(290, 537);
        this.kcbtnChooseBaseColour.Name = "kcbtnChooseBaseColour";
        this.kcbtnChooseBaseColour.Size = new(197, 25);
        this.kcbtnChooseBaseColour.TabIndex = 103;
        this.kcbtnChooseBaseColour.Values.Image = (System.Drawing.Image)resources.GetObject("kcbtnChooseBaseColour.Values.Image");
        this.kcbtnChooseBaseColour.Values.RoundedCorners = 8;
        this.kcbtnChooseBaseColour.Values.Text = "Ch&oose a Base Colour";
        // 
        // kbtnGenerateGreen
        // 
        this.kbtnGenerateGreen.Location = new(589, 409);
        this.kbtnGenerateGreen.Name = "kbtnGenerateGreen";
        this.kbtnGenerateGreen.Size = new(120, 25);
        this.kbtnGenerateGreen.TabIndex = 102;
        this.kbtnGenerateGreen.Values.Text = "Generate &Green";
        // 
        // kbtnGenerateBlue
        // 
        this.kbtnGenerateBlue.Location = new(725, 409);
        this.kbtnGenerateBlue.Name = "kbtnGenerateBlue";
        this.kbtnGenerateBlue.Size = new(119, 25);
        this.kbtnGenerateBlue.TabIndex = 101;
        this.kbtnGenerateBlue.Values.Text = "Generate &Blue";
        // 
        // kbtnGenerateRed
        // 
        this.kbtnGenerateRed.Location = new(445, 409);
        this.kbtnGenerateRed.Name = "kbtnGenerateRed";
        this.kbtnGenerateRed.Size = new(120, 25);
        this.kbtnGenerateRed.TabIndex = 100;
        this.kbtnGenerateRed.Values.Text = "Generate &Red";
        // 
        // knudBlueValue
        // 
        this.knudBlueValue.Location = new(764, 380);
        this.knudBlueValue.Maximum = new([
            255,
            0,
            0,
            0
        ]);
        this.knudBlueValue.Name = "knudBlueValue";
        this.knudBlueValue.Size = new(74, 23);
        this.knudBlueValue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
        this.knudBlueValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
        this.knudBlueValue.StateCommon.Content.Font = new("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        this.knudBlueValue.TabIndex = 99;
        // 
        // knudGreenValue
        // 
        this.knudGreenValue.Location = new(614, 380);
        this.knudGreenValue.Maximum = new([
            255,
            0,
            0,
            0
        ]);
        this.knudGreenValue.Name = "knudGreenValue";
        this.knudGreenValue.Size = new(74, 23);
        this.knudGreenValue.StateCommon.Back.Color1 = System.Drawing.Color.Green;
        this.knudGreenValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
        this.knudGreenValue.StateCommon.Content.Font = new("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        this.knudGreenValue.TabIndex = 98;
        // 
        // knudRedValue
        // 
        this.knudRedValue.Location = new(464, 380);
        this.knudRedValue.Maximum = new([
            255,
            0,
            0,
            0
        ]);
        this.knudRedValue.Name = "knudRedValue";
        this.knudRedValue.Size = new(74, 23);
        this.knudRedValue.StateCommon.Back.Color1 = System.Drawing.Color.Red;
        this.knudRedValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
        this.knudRedValue.StateCommon.Content.Font = new("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        this.knudRedValue.TabIndex = 97;
        // 
        // knudAlphaValue
        // 
        this.knudAlphaValue.Location = new(314, 380);
        this.knudAlphaValue.Maximum = new([
            255,
            0,
            0,
            0
        ]);
        this.knudAlphaValue.Name = "knudAlphaValue";
        this.knudAlphaValue.Size = new(74, 23);
        this.knudAlphaValue.StateCommon.Content.Font = new("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        this.knudAlphaValue.TabIndex = 96;
        this.knudAlphaValue.Value = new([
            255,
            0,
            0,
            0
        ]);
        // 
        // ktbBlueValue
        // 
        this.ktbBlueValue.Location = new(787, 44);
        this.ktbBlueValue.Maximum = 255;
        this.ktbBlueValue.Name = "ktbBlueValue";
        this.ktbBlueValue.Orientation = System.Windows.Forms.Orientation.Vertical;
        this.ktbBlueValue.Size = new(21, 330);
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
        this.ktbGreenValue.Location = new(638, 44);
        this.ktbGreenValue.Maximum = 255;
        this.ktbGreenValue.Name = "ktbGreenValue";
        this.ktbGreenValue.Orientation = System.Windows.Forms.Orientation.Vertical;
        this.ktbGreenValue.Size = new(21, 330);
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
        this.ktbRedValue.Location = new(482, 44);
        this.ktbRedValue.Maximum = 255;
        this.ktbRedValue.Name = "ktbRedValue";
        this.ktbRedValue.Orientation = System.Windows.Forms.Orientation.Vertical;
        this.ktbRedValue.Size = new(21, 330);
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
        this.ktbAlphaValue.Location = new(332, 44);
        this.ktbAlphaValue.Maximum = 255;
        this.ktbAlphaValue.Name = "ktbAlphaValue";
        this.ktbAlphaValue.Orientation = System.Windows.Forms.Orientation.Vertical;
        this.ktbAlphaValue.Size = new(21, 330);
        this.ktbAlphaValue.TabIndex = 92;
        this.ktbAlphaValue.TickStyle = System.Windows.Forms.TickStyle.None;
        this.ktbAlphaValue.Value = 255;
        // 
        // kryptonLabel4
        // 
        this.kryptonLabel4.Location = new(314, 17);
        this.kryptonLabel4.Name = "kryptonLabel4";
        this.kryptonLabel4.Size = new(57, 21);
        this.kryptonLabel4.StateCommon.ShortText.Font = new("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
        this.kryptonLabel4.TabIndex = 91;
        this.kryptonLabel4.Values.Text = "Alpha:";
        // 
        // kryptonLabel3
        // 
        this.kryptonLabel3.Location = new(471, 17);
        this.kryptonLabel3.Name = "kryptonLabel3";
        this.kryptonLabel3.Size = new(45, 21);
        this.kryptonLabel3.StateCommon.ShortText.Font = new("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
        this.kryptonLabel3.TabIndex = 90;
        this.kryptonLabel3.Values.Text = "Red:";
        // 
        // kryptonLabel2
        // 
        this.kryptonLabel2.Location = new(616, 17);
        this.kryptonLabel2.Name = "kryptonLabel2";
        this.kryptonLabel2.Size = new(61, 21);
        this.kryptonLabel2.StateCommon.ShortText.Font = new("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
        this.kryptonLabel2.TabIndex = 89;
        this.kryptonLabel2.Values.Text = "Green:";
        // 
        // kryptonLabel1
        // 
        this.kryptonLabel1.Location = new(777, 17);
        this.kryptonLabel1.Name = "kryptonLabel1";
        this.kryptonLabel1.Size = new(48, 21);
        this.kryptonLabel1.StateCommon.ShortText.Font = new("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
        this.kryptonLabel1.TabIndex = 88;
        this.kryptonLabel1.Values.Text = "Blue:";
        // 
        // kryptonLabel16
        // 
        this.kryptonLabel16.LabelStyle = Krypton.Toolkit.LabelStyle.TitleControl;
        this.kryptonLabel16.Location = new(3, 423);
        this.kryptonLabel16.Name = "kryptonLabel16";
        this.kryptonLabel16.Size = new(146, 29);
        this.kryptonLabel16.TabIndex = 87;
        this.kryptonLabel16.Values.Text = "Lightest Colour";
        // 
        // kryptonLabel15
        // 
        this.kryptonLabel15.LabelStyle = Krypton.Toolkit.LabelStyle.TitleControl;
        this.kryptonLabel15.Location = new(3, 318);
        this.kryptonLabel15.Name = "kryptonLabel15";
        this.kryptonLabel15.Size = new(120, 29);
        this.kryptonLabel15.TabIndex = 86;
        this.kryptonLabel15.Values.Text = "Light Colour";
        // 
        // kryptonLabel14
        // 
        this.kryptonLabel14.LabelStyle = Krypton.Toolkit.LabelStyle.TitleControl;
        this.kryptonLabel14.Location = new(3, 213);
        this.kryptonLabel14.Name = "kryptonLabel14";
        this.kryptonLabel14.Size = new(148, 29);
        this.kryptonLabel14.TabIndex = 85;
        this.kryptonLabel14.Values.Text = "Medium Colour";
        // 
        // kryptonLabel13
        // 
        this.kryptonLabel13.LabelStyle = Krypton.Toolkit.LabelStyle.TitleControl;
        this.kryptonLabel13.Location = new(3, 108);
        this.kryptonLabel13.Name = "kryptonLabel13";
        this.kryptonLabel13.Size = new(142, 29);
        this.kryptonLabel13.TabIndex = 84;
        this.kryptonLabel13.Values.Text = "Darkest Colour";
        // 
        // kryptonLabel12
        // 
        this.kryptonLabel12.LabelStyle = Krypton.Toolkit.LabelStyle.TitleControl;
        this.kryptonLabel12.Location = new(3, 3);
        this.kryptonLabel12.Name = "kryptonLabel12";
        this.kryptonLabel12.Size = new(116, 29);
        this.kryptonLabel12.TabIndex = 83;
        this.kryptonLabel12.Values.Text = "Base Colour";
        // 
        // cpbxLightestColour
        // 
        this.cpbxLightestColour.BackColor = System.Drawing.Color.White;
        this.cpbxLightestColour.Dock = System.Windows.Forms.DockStyle.Fill;
        this.cpbxLightestColour.Location = new(3, 458);
        this.cpbxLightestColour.Name = "cpbxLightestColour";
        this.cpbxLightestColour.Size = new(183, 116);
        this.cpbxLightestColour.TabIndex = 82;
        this.cpbxLightestColour.TabStop = false;
        this.cpbxLightestColour.ToolTipValues = null;
        // 
        // cpbxLightColour
        // 
        this.cpbxLightColour.BackColor = System.Drawing.Color.White;
        this.cpbxLightColour.Dock = System.Windows.Forms.DockStyle.Fill;
        this.cpbxLightColour.Location = new(3, 353);
        this.cpbxLightColour.Name = "cpbxLightColour";
        this.cpbxLightColour.Size = new(183, 64);
        this.cpbxLightColour.TabIndex = 81;
        this.cpbxLightColour.TabStop = false;
        this.cpbxLightColour.ToolTipValues = null;
        // 
        // cpbxMediumColour
        // 
        this.cpbxMediumColour.BackColor = System.Drawing.Color.White;
        this.cpbxMediumColour.Dock = System.Windows.Forms.DockStyle.Fill;
        this.cpbxMediumColour.Location = new(3, 248);
        this.cpbxMediumColour.Name = "cpbxMediumColour";
        this.cpbxMediumColour.Size = new(183, 64);
        this.cpbxMediumColour.TabIndex = 80;
        this.cpbxMediumColour.TabStop = false;
        this.cpbxMediumColour.ToolTipValues = null;
        // 
        // cpbxDarkestColour
        // 
        this.cpbxDarkestColour.BackColor = System.Drawing.Color.White;
        this.cpbxDarkestColour.Dock = System.Windows.Forms.DockStyle.Fill;
        this.cpbxDarkestColour.Location = new(3, 143);
        this.cpbxDarkestColour.Name = "cpbxDarkestColour";
        this.cpbxDarkestColour.Size = new(183, 64);
        this.cpbxDarkestColour.TabIndex = 79;
        this.cpbxDarkestColour.TabStop = false;
        this.cpbxDarkestColour.ToolTipValues = null;
        // 
        // cpbxBaseColour
        // 
        this.cpbxBaseColour.BackColor = System.Drawing.Color.White;
        this.cpbxBaseColour.Dock = System.Windows.Forms.DockStyle.Fill;
        this.cpbxBaseColour.Location = new(3, 38);
        this.cpbxBaseColour.Name = "cpbxBaseColour";
        this.cpbxBaseColour.Size = new(183, 64);
        this.cpbxBaseColour.TabIndex = 78;
        this.cpbxBaseColour.TabStop = false;
        this.cpbxBaseColour.ToolTipValues = null;
        // 
        // kryptonBorderEdge1
        // 
        this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
        this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
        this.kryptonBorderEdge1.Location = new(0, 0);
        this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
        this.kryptonBorderEdge1.Size = new(854, 1);
        this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
        // 
        // kryptonTableLayoutPanel1
        // 
        this.kryptonTableLayoutPanel1.BackgroundImage = (System.Drawing.Image)resources.GetObject("kryptonTableLayoutPanel1.BackgroundImage");
        this.kryptonTableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.kryptonTableLayoutPanel1.ColumnCount = 1;
        this.kryptonTableLayoutPanel1.ColumnStyles.Add(new(System.Windows.Forms.SizeType.Percent, 100F));
        this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonLabel12, 0, 0);
        this.kryptonTableLayoutPanel1.Controls.Add(this.cpbxBaseColour, 0, 1);
        this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonLabel13, 0, 2);
        this.kryptonTableLayoutPanel1.Controls.Add(this.cpbxDarkestColour, 0, 3);
        this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonLabel14, 0, 4);
        this.kryptonTableLayoutPanel1.Controls.Add(this.cpbxMediumColour, 0, 5);
        this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonLabel15, 0, 6);
        this.kryptonTableLayoutPanel1.Controls.Add(this.cpbxLightColour, 0, 7);
        this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonLabel16, 0, 8);
        this.kryptonTableLayoutPanel1.Controls.Add(this.cpbxLightestColour, 0, 9);
        this.kryptonTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
        this.kryptonTableLayoutPanel1.Location = new(0, 0);
        this.kryptonTableLayoutPanel1.Name = "kryptonTableLayoutPanel1";
        this.kryptonTableLayoutPanel1.RowCount = 10;
        this.kryptonTableLayoutPanel1.RowStyles.Add(new());
        this.kryptonTableLayoutPanel1.RowStyles.Add(new());
        this.kryptonTableLayoutPanel1.RowStyles.Add(new());
        this.kryptonTableLayoutPanel1.RowStyles.Add(new());
        this.kryptonTableLayoutPanel1.RowStyles.Add(new());
        this.kryptonTableLayoutPanel1.RowStyles.Add(new());
        this.kryptonTableLayoutPanel1.RowStyles.Add(new());
        this.kryptonTableLayoutPanel1.RowStyles.Add(new());
        this.kryptonTableLayoutPanel1.RowStyles.Add(new());
        this.kryptonTableLayoutPanel1.RowStyles.Add(new());
        this.kryptonTableLayoutPanel1.Size = new(189, 577);
        this.kryptonTableLayoutPanel1.TabIndex = 108;
        // 
        // InternalBasicPaletteCreator
        // 
        this.ClientSize = new(854, 649);
        this.Controls.Add(this.kryptonPanel2);
        this.Controls.Add(this.kryptonPanel1);
        this.Controls.Add(this.statusStrip1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "InternalBasicPaletteCreator";
        this.ShowInTaskbar = false;
        this.Load += new(this.InternalBasicPaletteCreator_Load);
        this.statusStrip1.ResumeLayout(false);
        this.statusStrip1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.kryptonPanel1).EndInit();
        this.kryptonPanel1.ResumeLayout(false);
        this.kryptonPanel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.kryptonPanel2).EndInit();
        this.kryptonPanel2.ResumeLayout(false);
        this.kryptonPanel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.cpbxLightestColour).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.cpbxLightColour).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.cpbxMediumColour).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.cpbxDarkestColour).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.cpbxBaseColour).EndInit();
        this.kryptonTableLayoutPanel1.ResumeLayout(false);
        this.kryptonTableLayoutPanel1.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    #region Variables
    private ConversionMethods _conversionMethods = new();

    private RandomNumberGenerator _randomNumberGenerator = new();

    private HSLColour _hslColour = new();

    private ColourControlManager _colourControlManager = new();

    private GlobalBooleanSettingsManager _globalBooleanSettingsManager = new();

    private AllMergedPaletteColourSettingsManager _colourSettingsManager = new();

    private Color _baseColour, _colourDark, _colourNormal, _colourLight, _colourLightness;

    private bool _paletteColourSelector;
    #endregion

    #region Properties
    public Color BaseColour
    {
        get => _baseColour;
        set => _baseColour = value;
    }

    public bool PaletteColourSelector
    {
        get => _paletteColourSelector;
        set => _paletteColourSelector = value;
    }
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