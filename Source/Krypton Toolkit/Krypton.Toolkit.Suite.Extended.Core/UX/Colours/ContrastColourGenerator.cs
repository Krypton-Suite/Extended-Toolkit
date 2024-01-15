#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public partial class ContrastColourGenerator : KryptonForm
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
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kchkKeepOpacityValues = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkAutomateColourContrastValues = new Krypton.Toolkit.KryptonCheckBox();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnUtiliseContrastColour = new Krypton.Toolkit.KryptonButton();
            this.kbtnUtiliseBaseColour = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton3 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton4 = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateBaseAlphaValue = new Krypton.Toolkit.KryptonButton();
            this.kbtnInvertColours = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateComplementaryColour = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateBlueValue = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateGreenValue = new Krypton.Toolkit.KryptonButton();
            this.kbtnGenerateRedValue = new Krypton.Toolkit.KryptonButton();
            this.knumContrastAlphaChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.knumContrastBlueChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knumContrastGreenChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knumContrastRedChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            this.knumBaseAlphaChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel10 = new Krypton.Toolkit.KryptonLabel();
            this.knumBaseBlueChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knumBaseGreenChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knumBaseRedChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.cpbContrastColour = new Krypton.Toolkit.Suite.Extended.Core.CircularPictureBox();
            this.cpbBaseColour = new Krypton.Toolkit.Suite.Extended.Core.CircularPictureBox();
            this.kryptonLabel12 = new Krypton.Toolkit.KryptonLabel();
            this.tmrUpdateUI = new System.Windows.Forms.Timer(this.components);
            this.ttInformation = new System.Windows.Forms.ToolTip(this.components);
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbContrastColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbBaseColour)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Controls.Add(this.kchkKeepOpacityValues);
            this.kryptonPanel1.Controls.Add(this.kchkAutomateColourContrastValues);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 560);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(879, 52);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kchkKeepOpacityValues
            // 
            this.kchkKeepOpacityValues.Location = new System.Drawing.Point(222, 20);
            this.kchkKeepOpacityValues.Name = "kchkKeepOpacityValues";
            this.kchkKeepOpacityValues.Size = new System.Drawing.Size(135, 20);
            this.kchkKeepOpacityValues.TabIndex = 94;
            this.kchkKeepOpacityValues.Values.Text = "Keep &Opacity Values";
            // 
            // kchkAutomateColourContrastValues
            // 
            this.kchkAutomateColourContrastValues.Location = new System.Drawing.Point(12, 20);
            this.kchkAutomateColourContrastValues.Name = "kchkAutomateColourContrastValues";
            this.kchkAutomateColourContrastValues.Size = new System.Drawing.Size(206, 20);
            this.kchkAutomateColourContrastValues.TabIndex = 93;
            this.kchkAutomateColourContrastValues.Values.Text = "&Automate Colour Contrast Values";
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.Location = new System.Drawing.Point(777, 15);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 92;
            this.kbtnOk.Values.Text = "&Ok";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnUtiliseContrastColour);
            this.kryptonPanel2.Controls.Add(this.kbtnUtiliseBaseColour);
            this.kryptonPanel2.Controls.Add(this.kryptonButton1);
            this.kryptonPanel2.Controls.Add(this.kryptonButton3);
            this.kryptonPanel2.Controls.Add(this.kryptonButton4);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerateBaseAlphaValue);
            this.kryptonPanel2.Controls.Add(this.kbtnInvertColours);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerateComplementaryColour);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerateBlueValue);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerateGreenValue);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerateRedValue);
            this.kryptonPanel2.Controls.Add(this.knumContrastAlphaChannelValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel5);
            this.kryptonPanel2.Controls.Add(this.knumContrastBlueChannelValue);
            this.kryptonPanel2.Controls.Add(this.knumContrastGreenChannelValue);
            this.kryptonPanel2.Controls.Add(this.knumContrastRedChannelValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel6);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel7);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel8);
            this.kryptonPanel2.Controls.Add(this.knumBaseAlphaChannelValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel10);
            this.kryptonPanel2.Controls.Add(this.knumBaseBlueChannelValue);
            this.kryptonPanel2.Controls.Add(this.knumBaseGreenChannelValue);
            this.kryptonPanel2.Controls.Add(this.knumBaseRedChannelValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Controls.Add(this.cpbContrastColour);
            this.kryptonPanel2.Controls.Add(this.cpbBaseColour);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel12);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(879, 560);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kbtnUtiliseContrastColour
            // 
            this.kbtnUtiliseContrastColour.Location = new System.Drawing.Point(580, 516);
            this.kbtnUtiliseContrastColour.Name = "kbtnUtiliseContrastColour";
            this.kbtnUtiliseContrastColour.Size = new System.Drawing.Size(203, 25);
            this.kbtnUtiliseContrastColour.TabIndex = 93;
            this.ttInformation.SetToolTip(this.kbtnUtiliseContrastColour, "Utilise Contrast Colour for Palette Generation");
            this.kbtnUtiliseContrastColour.Values.Text = "Utilise &Contrast Colour for Palette";
            // 
            // kbtnUtiliseBaseColour
            // 
            this.kbtnUtiliseBaseColour.Location = new System.Drawing.Point(57, 516);
            this.kbtnUtiliseBaseColour.Name = "kbtnUtiliseBaseColour";
            this.kbtnUtiliseBaseColour.Size = new System.Drawing.Size(227, 25);
            this.kbtnUtiliseBaseColour.TabIndex = 92;
            this.ttInformation.SetToolTip(this.kbtnUtiliseBaseColour, "Utilise Base Colour for Palette Generation");
            this.kbtnUtiliseBaseColour.Values.Text = "Utilise &Base Colour for Palette";
            this.kbtnUtiliseBaseColour.Click += new System.EventHandler(this.kbtnUtiliseBaseColour_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(713, 470);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(117, 25);
            this.kryptonButton1.TabIndex = 91;
            this.kryptonButton1.Values.Text = "Generate &Blue";
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.Location = new System.Drawing.Point(713, 437);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.Size = new System.Drawing.Size(117, 25);
            this.kryptonButton3.TabIndex = 90;
            this.kryptonButton3.Values.Text = "Generate &Green";
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.Location = new System.Drawing.Point(713, 393);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(117, 25);
            this.kryptonButton4.TabIndex = 89;
            this.kryptonButton4.Values.Text = "Generate &Red";
            // 
            // kbtnGenerateBaseAlphaValue
            // 
            this.kbtnGenerateBaseAlphaValue.Location = new System.Drawing.Point(222, 348);
            this.kbtnGenerateBaseAlphaValue.Name = "kbtnGenerateBaseAlphaValue";
            this.kbtnGenerateBaseAlphaValue.Size = new System.Drawing.Size(135, 25);
            this.kbtnGenerateBaseAlphaValue.TabIndex = 88;
            this.kbtnGenerateBaseAlphaValue.Values.Text = "Generate &Alpha";
            this.kbtnGenerateBaseAlphaValue.Click += new System.EventHandler(this.kbtnGenerateBaseAlphaValue_Click);
            // 
            // kbtnInvertColours
            // 
            this.kbtnInvertColours.Location = new System.Drawing.Point(430, 173);
            this.kbtnInvertColours.Name = "kbtnInvertColours";
            this.kbtnInvertColours.Size = new System.Drawing.Size(90, 25);
            this.kbtnInvertColours.TabIndex = 87;
            this.ttInformation.SetToolTip(this.kbtnInvertColours, "Inverse Colours");
            this.kbtnInvertColours.Values.Text = "<&--";
            this.kbtnInvertColours.Click += new System.EventHandler(this.kbtnInvertColours_Click);
            // 
            // kbtnGenerateComplementaryColour
            // 
            this.kbtnGenerateComplementaryColour.Location = new System.Drawing.Point(430, 109);
            this.kbtnGenerateComplementaryColour.Name = "kbtnGenerateComplementaryColour";
            this.kbtnGenerateComplementaryColour.Size = new System.Drawing.Size(90, 25);
            this.kbtnGenerateComplementaryColour.TabIndex = 86;
            this.ttInformation.SetToolTip(this.kbtnGenerateComplementaryColour, "Generate Contrast Colours");
            this.kbtnGenerateComplementaryColour.Values.Text = "--&>";
            this.kbtnGenerateComplementaryColour.Click += new System.EventHandler(this.kbtnGenerateComplementaryColour_Click);
            // 
            // kbtnGenerateBlueValue
            // 
            this.kbtnGenerateBlueValue.Location = new System.Drawing.Point(222, 470);
            this.kbtnGenerateBlueValue.Name = "kbtnGenerateBlueValue";
            this.kbtnGenerateBlueValue.Size = new System.Drawing.Size(135, 25);
            this.kbtnGenerateBlueValue.TabIndex = 85;
            this.kbtnGenerateBlueValue.Values.Text = "Generate &Blue";
            this.kbtnGenerateBlueValue.Click += new System.EventHandler(this.kbtnGenerateBlueValue_Click);
            // 
            // kbtnGenerateGreenValue
            // 
            this.kbtnGenerateGreenValue.Location = new System.Drawing.Point(222, 437);
            this.kbtnGenerateGreenValue.Name = "kbtnGenerateGreenValue";
            this.kbtnGenerateGreenValue.Size = new System.Drawing.Size(135, 25);
            this.kbtnGenerateGreenValue.TabIndex = 84;
            this.kbtnGenerateGreenValue.Values.Text = "Generate &Green";
            this.kbtnGenerateGreenValue.Click += new System.EventHandler(this.kbtnGenerateGreenValue_Click);
            // 
            // kbtnGenerateRedValue
            // 
            this.kbtnGenerateRedValue.Location = new System.Drawing.Point(222, 393);
            this.kbtnGenerateRedValue.Name = "kbtnGenerateRedValue";
            this.kbtnGenerateRedValue.Size = new System.Drawing.Size(135, 25);
            this.kbtnGenerateRedValue.TabIndex = 83;
            this.kbtnGenerateRedValue.Values.Text = "Generate &Red";
            this.kbtnGenerateRedValue.Click += new System.EventHandler(this.kbtnGenerateRedValue_Click);
            // 
            // knumContrastAlphaChannelValue
            // 
            this.knumContrastAlphaChannelValue.Location = new System.Drawing.Point(614, 348);
            this.knumContrastAlphaChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumContrastAlphaChannelValue.Name = "knumContrastAlphaChannelValue";
            this.knumContrastAlphaChannelValue.Size = new System.Drawing.Size(68, 22);
            this.knumContrastAlphaChannelValue.TabIndex = 82;
            this.knumContrastAlphaChannelValue.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel5.Location = new System.Drawing.Point(546, 348);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(48, 20);
            this.kryptonLabel5.TabIndex = 81;
            this.kryptonLabel5.Values.Text = "Alpha:";
            // 
            // knumContrastBlueChannelValue
            // 
            this.knumContrastBlueChannelValue.Location = new System.Drawing.Point(614, 470);
            this.knumContrastBlueChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumContrastBlueChannelValue.Name = "knumContrastBlueChannelValue";
            this.knumContrastBlueChannelValue.Size = new System.Drawing.Size(68, 22);
            this.knumContrastBlueChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knumContrastBlueChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumContrastBlueChannelValue.TabIndex = 80;
            // 
            // knumContrastGreenChannelValue
            // 
            this.knumContrastGreenChannelValue.Location = new System.Drawing.Point(614, 437);
            this.knumContrastGreenChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumContrastGreenChannelValue.Name = "knumContrastGreenChannelValue";
            this.knumContrastGreenChannelValue.Size = new System.Drawing.Size(68, 22);
            this.knumContrastGreenChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Lime;
            this.knumContrastGreenChannelValue.TabIndex = 79;
            // 
            // knumContrastRedChannelValue
            // 
            this.knumContrastRedChannelValue.Location = new System.Drawing.Point(614, 393);
            this.knumContrastRedChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumContrastRedChannelValue.Name = "knumContrastRedChannelValue";
            this.knumContrastRedChannelValue.Size = new System.Drawing.Size(68, 22);
            this.knumContrastRedChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knumContrastRedChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumContrastRedChannelValue.TabIndex = 78;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel6.Location = new System.Drawing.Point(546, 482);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(39, 20);
            this.kryptonLabel6.TabIndex = 77;
            this.kryptonLabel6.Values.Text = "Blue:";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel7.Location = new System.Drawing.Point(546, 437);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(48, 20);
            this.kryptonLabel7.TabIndex = 76;
            this.kryptonLabel7.Values.Text = "Green:";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel8.Location = new System.Drawing.Point(546, 395);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel8.TabIndex = 75;
            this.kryptonLabel8.Values.Text = "Red:";
            // 
            // knumBaseAlphaChannelValue
            // 
            this.knumBaseAlphaChannelValue.Location = new System.Drawing.Point(96, 346);
            this.knumBaseAlphaChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumBaseAlphaChannelValue.Name = "knumBaseAlphaChannelValue";
            this.knumBaseAlphaChannelValue.Size = new System.Drawing.Size(68, 22);
            this.knumBaseAlphaChannelValue.TabIndex = 74;
            this.knumBaseAlphaChannelValue.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel10.Location = new System.Drawing.Point(28, 346);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(48, 20);
            this.kryptonLabel10.TabIndex = 73;
            this.kryptonLabel10.Values.Text = "Alpha:";
            // 
            // knumBaseBlueChannelValue
            // 
            this.knumBaseBlueChannelValue.Location = new System.Drawing.Point(96, 478);
            this.knumBaseBlueChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumBaseBlueChannelValue.Name = "knumBaseBlueChannelValue";
            this.knumBaseBlueChannelValue.Size = new System.Drawing.Size(68, 22);
            this.knumBaseBlueChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knumBaseBlueChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumBaseBlueChannelValue.TabIndex = 72;
            // 
            // knumBaseGreenChannelValue
            // 
            this.knumBaseGreenChannelValue.Location = new System.Drawing.Point(96, 435);
            this.knumBaseGreenChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumBaseGreenChannelValue.Name = "knumBaseGreenChannelValue";
            this.knumBaseGreenChannelValue.Size = new System.Drawing.Size(68, 22);
            this.knumBaseGreenChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Lime;
            this.knumBaseGreenChannelValue.TabIndex = 71;
            // 
            // knumBaseRedChannelValue
            // 
            this.knumBaseRedChannelValue.Location = new System.Drawing.Point(96, 391);
            this.knumBaseRedChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumBaseRedChannelValue.Name = "knumBaseRedChannelValue";
            this.knumBaseRedChannelValue.Size = new System.Drawing.Size(68, 22);
            this.knumBaseRedChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knumBaseRedChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumBaseRedChannelValue.TabIndex = 70;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(28, 470);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(39, 20);
            this.kryptonLabel4.TabIndex = 69;
            this.kryptonLabel4.Values.Text = "Blue:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(28, 435);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(48, 20);
            this.kryptonLabel3.TabIndex = 68;
            this.kryptonLabel3.Values.Text = "Green:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(28, 393);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel2.TabIndex = 67;
            this.kryptonLabel2.Values.Text = "Red:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(633, 21);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(150, 29);
            this.kryptonLabel1.TabIndex = 66;
            this.kryptonLabel1.Values.Text = "Contrast Colour";
            // 
            // cpbContrastColour
            // 
            this.cpbContrastColour.BackColor = System.Drawing.Color.Transparent;
            this.cpbContrastColour.Location = new System.Drawing.Point(598, 71);
            this.cpbContrastColour.Name = "cpbContrastColour";
            this.cpbContrastColour.Size = new System.Drawing.Size(256, 256);
            this.cpbContrastColour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.cpbContrastColour.TabIndex = 65;
            this.cpbContrastColour.TabStop = false;
            this.cpbContrastColour.ToolTipValues = null;
            this.cpbContrastColour.BackColorChanged += new System.EventHandler(this.cpbContrastColour_BackColorChanged);
            // 
            // cpbBaseColour
            // 
            this.cpbBaseColour.BackColor = System.Drawing.Color.Transparent;
            this.cpbBaseColour.Location = new System.Drawing.Point(28, 71);
            this.cpbBaseColour.Name = "cpbBaseColour";
            this.cpbBaseColour.Size = new System.Drawing.Size(256, 256);
            this.cpbBaseColour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.cpbBaseColour.TabIndex = 3;
            this.cpbBaseColour.TabStop = false;
            this.cpbBaseColour.ToolTipValues = null;
            this.cpbBaseColour.BackColorChanged += new System.EventHandler(this.cpbBaseColour_BackColorChanged);
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.LabelStyle = Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonLabel12.Location = new System.Drawing.Point(82, 21);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(116, 29);
            this.kryptonLabel12.TabIndex = 64;
            this.kryptonLabel12.Values.Text = "Base Colour";
            // 
            // tmrUpdateUI
            // 
            this.tmrUpdateUI.Enabled = true;
            this.tmrUpdateUI.Interval = 250;
            this.tmrUpdateUI.Tick += new System.EventHandler(this.tmrUpdateUI_Tick);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(879, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // ContrastColourGenerator
            // 
            this.AcceptButton = this.kbtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 612);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ContrastColourGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contrast Colour Generator";
            this.TextExtra = "(Beta)";
            this.Load += new System.EventHandler(this.ContrastColourGenerator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbContrastColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbBaseColour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private CircularPictureBox cpbContrastColour;
        private CircularPictureBox cpbBaseColour;
        private Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonNumericUpDown knumContrastAlphaChannelValue;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonNumericUpDown knumContrastBlueChannelValue;
        private Krypton.Toolkit.KryptonNumericUpDown knumContrastGreenChannelValue;
        private Krypton.Toolkit.KryptonNumericUpDown knumContrastRedChannelValue;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private Krypton.Toolkit.KryptonNumericUpDown knumBaseAlphaChannelValue;
        private Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private Krypton.Toolkit.KryptonNumericUpDown knumBaseBlueChannelValue;
        private Krypton.Toolkit.KryptonNumericUpDown knumBaseGreenChannelValue;
        private Krypton.Toolkit.KryptonNumericUpDown knumBaseRedChannelValue;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonButton kbtnGenerateBaseAlphaValue;
        private Krypton.Toolkit.KryptonButton kbtnInvertColours;
        private Krypton.Toolkit.KryptonButton kbtnGenerateComplementaryColour;
        private Krypton.Toolkit.KryptonButton kbtnGenerateBlueValue;
        private Krypton.Toolkit.KryptonButton kbtnGenerateGreenValue;
        private Krypton.Toolkit.KryptonButton kbtnGenerateRedValue;
        private Krypton.Toolkit.KryptonButton kbtnOk;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonButton kryptonButton3;
        private Krypton.Toolkit.KryptonButton kryptonButton4;
        private System.Windows.Forms.Timer tmrUpdateUI;
        private Krypton.Toolkit.KryptonCheckBox kchkAutomateColourContrastValues;
        private Krypton.Toolkit.KryptonCheckBox kchkKeepOpacityValues;
        private Krypton.Toolkit.KryptonButton kbtnUtiliseContrastColour;
        private System.Windows.Forms.ToolTip ttInformation;
        private Krypton.Toolkit.KryptonButton kbtnUtiliseBaseColour;
        private KryptonBorderEdge kryptonBorderEdge1;
        #endregion

        #region Variables
        private RandomNumberGenerator _rng = new();
        #endregion

        #region Constructors
        public ContrastColourGenerator()
        {
            InitializeComponent();
        }

        public ContrastColourGenerator(Color baseColour)
        {
            InitializeComponent();

            cpbBaseColour.BackColor = baseColour;
        }
        #endregion

        private void ContrastColourGenerator_Load(object sender, EventArgs e)
        {

        }

        private void kbtnGenerateComplementaryColour_Click(object sender, EventArgs e)
        {
            cpbContrastColour.BackColor = ColourExtensions.GetContrast(cpbBaseColour.BackColor, kchkKeepOpacityValues.Checked);
        }

        private void tmrUpdateUI_Tick(object sender, EventArgs e)
        {
            cpbBaseColour.BackColor = Color.FromArgb(Convert.ToInt32(knumBaseAlphaChannelValue.Value), Convert.ToInt32(knumBaseRedChannelValue.Value), Convert.ToInt32(knumBaseGreenChannelValue.Value), Convert.ToInt32(knumBaseBlueChannelValue.Value));

            if (kchkAutomateColourContrastValues.Checked)
            {
                cpbContrastColour.BackColor = ColourExtensions.GetContrast(cpbBaseColour.BackColor, kchkKeepOpacityValues.Checked);
            }
        }

        private void cpbContrastColour_BackColorChanged(object sender, EventArgs e)
        {
            knumContrastAlphaChannelValue.Value = cpbContrastColour.BackColor.A;

            knumContrastRedChannelValue.Value = cpbContrastColour.BackColor.R;

            knumContrastGreenChannelValue.Value = cpbContrastColour.BackColor.G;

            knumContrastBlueChannelValue.Value = cpbContrastColour.BackColor.B;
        }

        private void kbtnInvertColours_Click(object sender, EventArgs e)
        {
            cpbBaseColour.BackColor = cpbContrastColour.BackColor;
        }

        private void cpbBaseColour_BackColorChanged(object sender, EventArgs e)
        {
            knumBaseAlphaChannelValue.Value = cpbBaseColour.BackColor.A;

            knumBaseRedChannelValue.Value = cpbBaseColour.BackColor.R;

            knumBaseGreenChannelValue.Value = cpbBaseColour.BackColor.G;

            knumBaseBlueChannelValue.Value = cpbBaseColour.BackColor.B;
        }

        private void kbtnGenerateBaseAlphaValue_Click(object sender, EventArgs e)
        {
            knumBaseAlphaChannelValue.Value = _rng.RandomlyGenerateAlphaNumberBetween(0, 255);
        }

        private void kbtnGenerateRedValue_Click(object sender, EventArgs e)
        {
            knumBaseRedChannelValue.Value = _rng.RandomlyGenerateARedNumberBetween(0, 255);
        }

        private void kbtnGenerateGreenValue_Click(object sender, EventArgs e)
        {
            knumBaseGreenChannelValue.Value = _rng.RandomlyGenerateAGreenNumberBetween(0, 255);
        }

        private void kbtnGenerateBlueValue_Click(object sender, EventArgs e)
        {
            knumBaseBlueChannelValue.Value = _rng.RandomlyGenerateABlueNumberBetween(0, 255);
        }

        private void kbtnUtiliseBaseColour_Click(object sender, EventArgs e)
        {
            PaletteColourCreator paletteColourCreator = new(cpbBaseColour.BackColor);

            paletteColourCreator.Show();
        }
    }
}