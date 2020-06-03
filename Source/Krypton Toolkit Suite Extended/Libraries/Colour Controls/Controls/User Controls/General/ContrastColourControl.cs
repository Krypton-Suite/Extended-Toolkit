using Krypton.Toolkit.Suite.Extended.Base;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Colour.Controls
{
    public class ContrastColourControl : UserControl
    {
        #region Designer Code
        private Krypton.Toolkit.KryptonButton kbtnContrastColourGenerateAlpha;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private CircularPictureBox cpbContrastColour;
        private Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private CircularPictureBox cpbBaseColour;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonButton kbtnUtiliseContrastColour;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonButton kbtnUtiliseBaseColour;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonButton kbtnContrastColourGenerateBlue;
        private Krypton.Toolkit.KryptonNumericUpDown knumBaseRedChannelValue;
        private Krypton.Toolkit.KryptonButton kbtnContrastColourGenerateGreen;
        private Krypton.Toolkit.KryptonNumericUpDown knumBaseGreenChannelValue;
        private Krypton.Toolkit.KryptonButton kbtnContrastColourGenerateRed;
        private Krypton.Toolkit.KryptonNumericUpDown knumBaseBlueChannelValue;
        private Krypton.Toolkit.KryptonButton kbtnGenerateBaseAlphaValue;
        private Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private Krypton.Toolkit.KryptonButton kbtnInvertColours;
        private Krypton.Toolkit.KryptonNumericUpDown knumBaseAlphaChannelValue;
        private Krypton.Toolkit.KryptonButton kbtnGenerateComplementaryColour;
        private Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private Krypton.Toolkit.KryptonButton kbtnGenerateBlueValue;
        private Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private Krypton.Toolkit.KryptonButton kbtnGenerateGreenValue;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonButton kbtnGenerateRedValue;
        private Krypton.Toolkit.KryptonNumericUpDown knumContrastRedChannelValue;
        private Krypton.Toolkit.KryptonNumericUpDown knumContrastAlphaChannelValue;
        private Krypton.Toolkit.KryptonNumericUpDown knumContrastGreenChannelValue;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonNumericUpDown knumContrastBlueChannelValue;
        private KryptonBlueValueLabel kryptonBlueValueLabel1;
        private KryptonRedValueLabel kryptonRedValueLabel1;
        private Krypton.Toolkit.KryptonPanel kpnlContent;

        private void InitializeComponent()
        {
            this.kpnlContent = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBlueValueLabel1 = new KryptonBlueValueLabel();
            this.kryptonRedValueLabel1 = new KryptonRedValueLabel();
            this.kbtnContrastColourGenerateAlpha = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.cpbContrastColour = new CircularPictureBox();
            this.kryptonLabel12 = new Krypton.Toolkit.KryptonLabel();
            this.cpbBaseColour = new CircularPictureBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnUtiliseContrastColour = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnUtiliseBaseColour = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnContrastColourGenerateBlue = new Krypton.Toolkit.KryptonButton();
            this.knumBaseRedChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kbtnContrastColourGenerateGreen = new Krypton.Toolkit.KryptonButton();
            this.knumBaseGreenChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kbtnContrastColourGenerateRed = new Krypton.Toolkit.KryptonButton();
            this.knumBaseBlueChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kbtnGenerateBaseAlphaValue = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel10 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnInvertColours = new Krypton.Toolkit.KryptonButton();
            this.knumBaseAlphaChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kbtnGenerateComplementaryColour = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnGenerateBlueValue = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnGenerateGreenValue = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnGenerateRedValue = new Krypton.Toolkit.KryptonButton();
            this.knumContrastRedChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knumContrastAlphaChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knumContrastGreenChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.knumContrastBlueChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).BeginInit();
            this.kpnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbContrastColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbBaseColour)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlContent
            // 
            this.kpnlContent.Controls.Add(this.kryptonBlueValueLabel1);
            this.kpnlContent.Controls.Add(this.kryptonRedValueLabel1);
            this.kpnlContent.Controls.Add(this.kbtnContrastColourGenerateAlpha);
            this.kpnlContent.Controls.Add(this.kryptonLabel1);
            this.kpnlContent.Controls.Add(this.cpbContrastColour);
            this.kpnlContent.Controls.Add(this.kryptonLabel12);
            this.kpnlContent.Controls.Add(this.cpbBaseColour);
            this.kpnlContent.Controls.Add(this.kryptonLabel2);
            this.kpnlContent.Controls.Add(this.kbtnUtiliseContrastColour);
            this.kpnlContent.Controls.Add(this.kryptonLabel3);
            this.kpnlContent.Controls.Add(this.kbtnUtiliseBaseColour);
            this.kpnlContent.Controls.Add(this.kryptonLabel4);
            this.kpnlContent.Controls.Add(this.kbtnContrastColourGenerateBlue);
            this.kpnlContent.Controls.Add(this.knumBaseRedChannelValue);
            this.kpnlContent.Controls.Add(this.kbtnContrastColourGenerateGreen);
            this.kpnlContent.Controls.Add(this.knumBaseGreenChannelValue);
            this.kpnlContent.Controls.Add(this.kbtnContrastColourGenerateRed);
            this.kpnlContent.Controls.Add(this.knumBaseBlueChannelValue);
            this.kpnlContent.Controls.Add(this.kbtnGenerateBaseAlphaValue);
            this.kpnlContent.Controls.Add(this.kryptonLabel10);
            this.kpnlContent.Controls.Add(this.kbtnInvertColours);
            this.kpnlContent.Controls.Add(this.knumBaseAlphaChannelValue);
            this.kpnlContent.Controls.Add(this.kbtnGenerateComplementaryColour);
            this.kpnlContent.Controls.Add(this.kryptonLabel8);
            this.kpnlContent.Controls.Add(this.kbtnGenerateBlueValue);
            this.kpnlContent.Controls.Add(this.kryptonLabel7);
            this.kpnlContent.Controls.Add(this.kbtnGenerateGreenValue);
            this.kpnlContent.Controls.Add(this.kryptonLabel6);
            this.kpnlContent.Controls.Add(this.kbtnGenerateRedValue);
            this.kpnlContent.Controls.Add(this.knumContrastRedChannelValue);
            this.kpnlContent.Controls.Add(this.knumContrastAlphaChannelValue);
            this.kpnlContent.Controls.Add(this.knumContrastGreenChannelValue);
            this.kpnlContent.Controls.Add(this.kryptonLabel5);
            this.kpnlContent.Controls.Add(this.knumContrastBlueChannelValue);
            this.kpnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlContent.Location = new System.Drawing.Point(0, 0);
            this.kpnlContent.Name = "kpnlContent";
            this.kpnlContent.Size = new System.Drawing.Size(883, 561);
            this.kpnlContent.TabIndex = 0;
            // 
            // kryptonBlueValueLabel1
            // 
            this.kryptonBlueValueLabel1.Location = new System.Drawing.Point(330, 49);
            this.kryptonBlueValueLabel1.Name = "kryptonBlueValueLabel1";
            this.kryptonBlueValueLabel1.BlueValue = 255;
            this.kryptonBlueValueLabel1.Size = new System.Drawing.Size(201, 26);
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Blue;
            this.kryptonBlueValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.TabIndex = 128;
            this.kryptonBlueValueLabel1.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonBlueValueLabel1.Values.Text = "kryptonBlueValueLabel1";
            this.kryptonBlueValueLabel1.Visible = false;
            // 
            // kryptonRedValueLabel1
            // 
            this.kryptonRedValueLabel1.Location = new System.Drawing.Point(330, 3);
            this.kryptonRedValueLabel1.Name = "kryptonRedValueLabel1";
            this.kryptonRedValueLabel1.RedValue = 255;
            this.kryptonRedValueLabel1.Size = new System.Drawing.Size(46, 26);
            this.kryptonRedValueLabel1.StateCommon.LongText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.LongText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.ShortText.Color2 = System.Drawing.Color.Red;
            this.kryptonRedValueLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.TabIndex = 127;
            this.kryptonRedValueLabel1.Typeface = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.kryptonRedValueLabel1.Values.Text = "Red:";
            this.kryptonRedValueLabel1.Visible = false;
            // 
            // kbtnContrastColourGenerateAlpha
            // 
            this.kbtnContrastColourGenerateAlpha.AutoSize = true;
            this.kbtnContrastColourGenerateAlpha.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnContrastColourGenerateAlpha.Location = new System.Drawing.Point(734, 352);
            this.kbtnContrastColourGenerateAlpha.Name = "kbtnContrastColourGenerateAlpha";
            this.kbtnContrastColourGenerateAlpha.Size = new System.Drawing.Size(125, 30);
            this.kbtnContrastColourGenerateAlpha.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnContrastColourGenerateAlpha.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnContrastColourGenerateAlpha.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnContrastColourGenerateAlpha.TabIndex = 126;
            this.kbtnContrastColourGenerateAlpha.Values.Text = "Generate &Alpha";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(627, 25);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(174, 33);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel1.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel1.TabIndex = 98;
            this.kryptonLabel1.Values.Text = "Contrast Colour";
            // 
            // cpbContrastColour
            // 
            this.cpbContrastColour.BackColor = System.Drawing.SystemColors.Control;
            this.cpbContrastColour.Location = new System.Drawing.Point(574, 64);
            this.cpbContrastColour.Name = "cpbContrastColour";
            this.cpbContrastColour.Size = new System.Drawing.Size(285, 280);
            this.cpbContrastColour.TabIndex = 96;
            this.cpbContrastColour.TabStop = false;
            this.cpbContrastColour.BackColorChanged += new System.EventHandler(this.CpbContrastColour_BackColorChanged);
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Location = new System.Drawing.Point(90, 25);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(134, 33);
            this.kryptonLabel12.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel12.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel12.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel12.TabIndex = 97;
            this.kryptonLabel12.Values.Text = "Base Colour";
            // 
            // cpbBaseColour
            // 
            this.cpbBaseColour.BackColor = System.Drawing.SystemColors.Control;
            this.cpbBaseColour.Location = new System.Drawing.Point(22, 64);
            this.cpbBaseColour.Name = "cpbBaseColour";
            this.cpbBaseColour.Size = new System.Drawing.Size(285, 280);
            this.cpbBaseColour.TabIndex = 95;
            this.cpbBaseColour.TabStop = false;
            this.cpbBaseColour.BackColorChanged += new System.EventHandler(this.CpbBaseColour_BackColorChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(22, 397);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(46, 26);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel2.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel2.TabIndex = 99;
            this.kryptonLabel2.Values.Text = "Red:";
            // 
            // kbtnUtiliseContrastColour
            // 
            this.kbtnUtiliseContrastColour.AutoSize = true;
            this.kbtnUtiliseContrastColour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnUtiliseContrastColour.Location = new System.Drawing.Point(574, 520);
            this.kbtnUtiliseContrastColour.Name = "kbtnUtiliseContrastColour";
            this.kbtnUtiliseContrastColour.Size = new System.Drawing.Size(255, 30);
            this.kbtnUtiliseContrastColour.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnUtiliseContrastColour.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnUtiliseContrastColour.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnUtiliseContrastColour.TabIndex = 125;
            this.kbtnUtiliseContrastColour.Values.Text = "Utilise &Contrast Colour for Palette";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(22, 439);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(62, 26);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel3.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel3.TabIndex = 100;
            this.kryptonLabel3.Values.Text = "Green:";
            // 
            // kbtnUtiliseBaseColour
            // 
            this.kbtnUtiliseBaseColour.AutoSize = true;
            this.kbtnUtiliseBaseColour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnUtiliseBaseColour.Location = new System.Drawing.Point(51, 520);
            this.kbtnUtiliseBaseColour.Name = "kbtnUtiliseBaseColour";
            this.kbtnUtiliseBaseColour.Size = new System.Drawing.Size(227, 30);
            this.kbtnUtiliseBaseColour.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnUtiliseBaseColour.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnUtiliseBaseColour.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnUtiliseBaseColour.TabIndex = 124;
            this.kbtnUtiliseBaseColour.Values.Text = "Utilise &Base Colour for Palette";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(22, 484);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(50, 26);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel4.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel4.TabIndex = 101;
            this.kryptonLabel4.Values.Text = "Blue:";
            // 
            // kbtnContrastColourGenerateBlue
            // 
            this.kbtnContrastColourGenerateBlue.AutoSize = true;
            this.kbtnContrastColourGenerateBlue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnContrastColourGenerateBlue.Location = new System.Drawing.Point(734, 484);
            this.kbtnContrastColourGenerateBlue.Name = "kbtnContrastColourGenerateBlue";
            this.kbtnContrastColourGenerateBlue.Size = new System.Drawing.Size(114, 30);
            this.kbtnContrastColourGenerateBlue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnContrastColourGenerateBlue.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnContrastColourGenerateBlue.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnContrastColourGenerateBlue.TabIndex = 123;
            this.kbtnContrastColourGenerateBlue.Values.Text = "Generate &Blue";
            // 
            // knumBaseRedChannelValue
            // 
            this.knumBaseRedChannelValue.Location = new System.Drawing.Point(90, 395);
            this.knumBaseRedChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumBaseRedChannelValue.Name = "knumBaseRedChannelValue";
            this.knumBaseRedChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumBaseRedChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knumBaseRedChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumBaseRedChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumBaseRedChannelValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumBaseRedChannelValue.TabIndex = 102;
            // 
            // kbtnContrastColourGenerateGreen
            // 
            this.kbtnContrastColourGenerateGreen.AutoSize = true;
            this.kbtnContrastColourGenerateGreen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnContrastColourGenerateGreen.Location = new System.Drawing.Point(734, 441);
            this.kbtnContrastColourGenerateGreen.Name = "kbtnContrastColourGenerateGreen";
            this.kbtnContrastColourGenerateGreen.Size = new System.Drawing.Size(126, 30);
            this.kbtnContrastColourGenerateGreen.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnContrastColourGenerateGreen.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnContrastColourGenerateGreen.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnContrastColourGenerateGreen.TabIndex = 122;
            this.kbtnContrastColourGenerateGreen.Values.Text = "Generate &Green";
            // 
            // knumBaseGreenChannelValue
            // 
            this.knumBaseGreenChannelValue.Location = new System.Drawing.Point(90, 439);
            this.knumBaseGreenChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumBaseGreenChannelValue.Name = "knumBaseGreenChannelValue";
            this.knumBaseGreenChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumBaseGreenChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Lime;
            this.knumBaseGreenChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumBaseGreenChannelValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumBaseGreenChannelValue.TabIndex = 103;
            // 
            // kbtnContrastColourGenerateRed
            // 
            this.kbtnContrastColourGenerateRed.AutoSize = true;
            this.kbtnContrastColourGenerateRed.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnContrastColourGenerateRed.Location = new System.Drawing.Point(734, 397);
            this.kbtnContrastColourGenerateRed.Name = "kbtnContrastColourGenerateRed";
            this.kbtnContrastColourGenerateRed.Size = new System.Drawing.Size(111, 30);
            this.kbtnContrastColourGenerateRed.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnContrastColourGenerateRed.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnContrastColourGenerateRed.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnContrastColourGenerateRed.TabIndex = 121;
            this.kbtnContrastColourGenerateRed.Values.Text = "Generate &Red";
            // 
            // knumBaseBlueChannelValue
            // 
            this.knumBaseBlueChannelValue.Location = new System.Drawing.Point(90, 482);
            this.knumBaseBlueChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumBaseBlueChannelValue.Name = "knumBaseBlueChannelValue";
            this.knumBaseBlueChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumBaseBlueChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knumBaseBlueChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumBaseBlueChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumBaseBlueChannelValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumBaseBlueChannelValue.TabIndex = 104;
            // 
            // kbtnGenerateBaseAlphaValue
            // 
            this.kbtnGenerateBaseAlphaValue.AutoSize = true;
            this.kbtnGenerateBaseAlphaValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateBaseAlphaValue.Location = new System.Drawing.Point(216, 352);
            this.kbtnGenerateBaseAlphaValue.Name = "kbtnGenerateBaseAlphaValue";
            this.kbtnGenerateBaseAlphaValue.Size = new System.Drawing.Size(125, 30);
            this.kbtnGenerateBaseAlphaValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBaseAlphaValue.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnGenerateBaseAlphaValue.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnGenerateBaseAlphaValue.TabIndex = 120;
            this.kbtnGenerateBaseAlphaValue.Values.Text = "Generate &Alpha";
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Location = new System.Drawing.Point(22, 350);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(62, 26);
            this.kryptonLabel10.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel10.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel10.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel10.TabIndex = 105;
            this.kryptonLabel10.Values.Text = "Alpha:";
            // 
            // kbtnInvertColours
            // 
            this.kbtnInvertColours.AutoSize = true;
            this.kbtnInvertColours.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnInvertColours.Location = new System.Drawing.Point(424, 177);
            this.kbtnInvertColours.Name = "kbtnInvertColours";
            this.kbtnInvertColours.Size = new System.Drawing.Size(36, 30);
            this.kbtnInvertColours.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnInvertColours.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnInvertColours.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnInvertColours.TabIndex = 119;
            this.kbtnInvertColours.Values.Text = "<&--";
            this.kbtnInvertColours.Click += new System.EventHandler(this.KbtnInvertColours_Click);
            // 
            // knumBaseAlphaChannelValue
            // 
            this.knumBaseAlphaChannelValue.Location = new System.Drawing.Point(90, 350);
            this.knumBaseAlphaChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumBaseAlphaChannelValue.Name = "knumBaseAlphaChannelValue";
            this.knumBaseAlphaChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumBaseAlphaChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumBaseAlphaChannelValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumBaseAlphaChannelValue.TabIndex = 106;
            this.knumBaseAlphaChannelValue.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // kbtnGenerateComplementaryColour
            // 
            this.kbtnGenerateComplementaryColour.AutoSize = true;
            this.kbtnGenerateComplementaryColour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateComplementaryColour.Location = new System.Drawing.Point(424, 113);
            this.kbtnGenerateComplementaryColour.Name = "kbtnGenerateComplementaryColour";
            this.kbtnGenerateComplementaryColour.Size = new System.Drawing.Size(36, 30);
            this.kbtnGenerateComplementaryColour.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateComplementaryColour.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnGenerateComplementaryColour.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnGenerateComplementaryColour.TabIndex = 118;
            this.kbtnGenerateComplementaryColour.Values.Text = "--&>";
            this.kbtnGenerateComplementaryColour.Click += new System.EventHandler(this.KbtnGenerateComplementaryColour_Click);
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(540, 399);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(46, 26);
            this.kryptonLabel8.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel8.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel8.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel8.TabIndex = 107;
            this.kryptonLabel8.Values.Text = "Red:";
            // 
            // kbtnGenerateBlueValue
            // 
            this.kbtnGenerateBlueValue.AutoSize = true;
            this.kbtnGenerateBlueValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateBlueValue.Location = new System.Drawing.Point(216, 484);
            this.kbtnGenerateBlueValue.Name = "kbtnGenerateBlueValue";
            this.kbtnGenerateBlueValue.Size = new System.Drawing.Size(114, 30);
            this.kbtnGenerateBlueValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateBlueValue.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnGenerateBlueValue.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnGenerateBlueValue.TabIndex = 117;
            this.kbtnGenerateBlueValue.Values.Text = "Generate &Blue";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(540, 441);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(62, 26);
            this.kryptonLabel7.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel7.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel7.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel7.TabIndex = 108;
            this.kryptonLabel7.Values.Text = "Green:";
            // 
            // kbtnGenerateGreenValue
            // 
            this.kbtnGenerateGreenValue.AutoSize = true;
            this.kbtnGenerateGreenValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateGreenValue.Location = new System.Drawing.Point(216, 441);
            this.kbtnGenerateGreenValue.Name = "kbtnGenerateGreenValue";
            this.kbtnGenerateGreenValue.Size = new System.Drawing.Size(126, 30);
            this.kbtnGenerateGreenValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateGreenValue.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnGenerateGreenValue.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnGenerateGreenValue.TabIndex = 116;
            this.kbtnGenerateGreenValue.Values.Text = "Generate &Green";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(540, 486);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(50, 26);
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel6.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel6.TabIndex = 109;
            this.kryptonLabel6.Values.Text = "Blue:";
            // 
            // kbtnGenerateRedValue
            // 
            this.kbtnGenerateRedValue.AutoSize = true;
            this.kbtnGenerateRedValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateRedValue.Location = new System.Drawing.Point(216, 397);
            this.kbtnGenerateRedValue.Name = "kbtnGenerateRedValue";
            this.kbtnGenerateRedValue.Size = new System.Drawing.Size(111, 30);
            this.kbtnGenerateRedValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateRedValue.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnGenerateRedValue.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnGenerateRedValue.TabIndex = 115;
            this.kbtnGenerateRedValue.Values.Text = "Generate &Red";
            // 
            // knumContrastRedChannelValue
            // 
            this.knumContrastRedChannelValue.Location = new System.Drawing.Point(608, 397);
            this.knumContrastRedChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumContrastRedChannelValue.Name = "knumContrastRedChannelValue";
            this.knumContrastRedChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumContrastRedChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knumContrastRedChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumContrastRedChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumContrastRedChannelValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumContrastRedChannelValue.TabIndex = 110;
            // 
            // knumContrastAlphaChannelValue
            // 
            this.knumContrastAlphaChannelValue.Location = new System.Drawing.Point(608, 352);
            this.knumContrastAlphaChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumContrastAlphaChannelValue.Name = "knumContrastAlphaChannelValue";
            this.knumContrastAlphaChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumContrastAlphaChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumContrastAlphaChannelValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumContrastAlphaChannelValue.TabIndex = 114;
            this.knumContrastAlphaChannelValue.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // knumContrastGreenChannelValue
            // 
            this.knumContrastGreenChannelValue.Location = new System.Drawing.Point(608, 441);
            this.knumContrastGreenChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumContrastGreenChannelValue.Name = "knumContrastGreenChannelValue";
            this.knumContrastGreenChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumContrastGreenChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Lime;
            this.knumContrastGreenChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumContrastGreenChannelValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumContrastGreenChannelValue.TabIndex = 111;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(540, 352);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(62, 26);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel5.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel5.TabIndex = 113;
            this.kryptonLabel5.Values.Text = "Alpha:";
            // 
            // knumContrastBlueChannelValue
            // 
            this.knumContrastBlueChannelValue.Location = new System.Drawing.Point(608, 484);
            this.knumContrastBlueChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumContrastBlueChannelValue.Name = "knumContrastBlueChannelValue";
            this.knumContrastBlueChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumContrastBlueChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knumContrastBlueChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumContrastBlueChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumContrastBlueChannelValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.knumContrastBlueChannelValue.TabIndex = 112;
            // 
            // ContrastColourControl
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kpnlContent);
            this.Name = "ContrastColourControl";
            this.Size = new System.Drawing.Size(883, 561);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).EndInit();
            this.kpnlContent.ResumeLayout(false);
            this.kpnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbContrastColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbBaseColour)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _automateContrastColour, _useForPalettes, _keepOpacityValues;

        private Color _baseColour, _contrastColour;

        private Timer _updateUI;
        #endregion

        #region Properties
        public bool AutomateContrastColour { get => _automateContrastColour; set => _automateContrastColour = value; }

        public bool UseForPalettes { get => _useForPalettes; set => _useForPalettes = value; }

        public bool KeepOpacityValues { get => _keepOpacityValues; set => _keepOpacityValues = value; }

        public Color BaseColour { get => _baseColour; set => _baseColour = value; }

        public Color ContrastColour { get => _contrastColour; set => _contrastColour = value; }
        #endregion

        #region Constructor
        public ContrastColourControl()
        {
            InitializeComponent();

            SetAutomateContrastColour(true);

            SetUseForPalettes(false);

            SetKeepOpacityValues(true);

            SetBaseColour(Color.Transparent);

            SetContrastColour(Color.Transparent);

            _updateUI = new Timer();

            _updateUI.Enabled = true;

            _updateUI.Interval = 256;

            _updateUI.Tick += UpdateUI_Tick;
        }
        #endregion

        #region Event Handlers
        private void CpbBaseColour_BackColorChanged(object sender, EventArgs e)
        {
            knumContrastAlphaChannelValue.Value = cpbContrastColour.BackColor.A;

            knumContrastRedChannelValue.Value = cpbContrastColour.BackColor.R;

            knumContrastGreenChannelValue.Value = cpbContrastColour.BackColor.G;

            knumContrastBlueChannelValue.Value = cpbContrastColour.BackColor.B;
        }

        private void CpbContrastColour_BackColorChanged(object sender, EventArgs e)
        {
            knumBaseAlphaChannelValue.Value = cpbBaseColour.BackColor.A;

            knumBaseRedChannelValue.Value = cpbBaseColour.BackColor.R;

            knumBaseGreenChannelValue.Value = cpbBaseColour.BackColor.G;

            knumBaseBlueChannelValue.Value = cpbBaseColour.BackColor.B;
        }

        private void KbtnGenerateComplementaryColour_Click(object sender, EventArgs e)
        {
            cpbContrastColour.BackColor = ColourExtensions.GetContrast(cpbBaseColour.BackColor, GetKeepOpacityValues());
        }

        private void KbtnInvertColours_Click(object sender, EventArgs e)
        {
            cpbBaseColour.BackColor = cpbContrastColour.BackColor;
        }

        private void UpdateUI_Tick(object sender, EventArgs e)
        {
            cpbBaseColour.BackColor = Color.FromArgb(Convert.ToInt32(knumBaseAlphaChannelValue.Value), Convert.ToInt32(knumBaseRedChannelValue.Value), Convert.ToInt32(knumBaseGreenChannelValue.Value), Convert.ToInt32(knumBaseBlueChannelValue.Value));

            if (GetAutomateContrastColour())
            {
                cpbContrastColour.BackColor = ColourExtensions.GetContrast(cpbBaseColour.BackColor, GetKeepOpacityValues());
            }
        }
        #endregion

        #region Methods
        public void FireTimer(bool fire)
        {
            if (fire)
            {
                _updateUI.Start();
            }
            else
            {
                _updateUI.Stop();
            }
        }

        public void ShowPaletteButtons(bool visible)
        {
            kbtnUtiliseBaseColour.Visible = visible;

            kbtnUtiliseContrastColour.Visible = visible;
        }

        public void Refresh() => Invalidate();
        #endregion

        #region Setters and Getters
        /// <summary>
        /// Sets the AutomateContrastColour.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetAutomateContrastColour(bool value) => AutomateContrastColour = value;

        /// <summary>
        /// Gets the AutomateContrastColour.
        /// </summary>
        /// <returns>The value of AutomateContrastColour.</returns>
        public bool GetAutomateContrastColour() => AutomateContrastColour;

        /// <summary>
        /// Sets the UseForPalettes.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetUseForPalettes(bool value) => UseForPalettes = value;

        /// <summary>
        /// Gets the UseForPalettes.
        /// </summary>
        /// <returns>The value of UseForPalettes.</returns>
        public bool GetUseForPalettes() => UseForPalettes;

        /// <summary>
        /// Sets the KeepOpacityValues.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetKeepOpacityValues(bool value) => KeepOpacityValues = value;

        /// <summary>
        /// Gets the KeepOpacityValues.
        /// </summary>
        /// <returns>The value of KeepOpacityValues.</returns>
        public bool GetKeepOpacityValues() => KeepOpacityValues;

        /// <summary>
        /// Sets the BaseColour.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetBaseColour(Color value) => BaseColour = value;

        /// <summary>
        /// Gets the BaseColour.
        /// </summary>
        /// <returns>The value of BaseColour.</returns>
        public Color GetBaseColour() => BaseColour;

        /// <summary>
        /// Sets the ContrastColour.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetContrastColour(Color value) => ContrastColour = value;

        /// <summary>
        /// Gets the ContrastColour.
        /// </summary>
        /// <returns>The value of ContrastColour.</returns>
        public Color GetContrastColour() => ContrastColour;
        #endregion
    }
}