#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Microsoft.WindowsAPICodePack.Dialogs;

using System.IO;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public partial class ColourBlendingOptions : KryptonForm
    {
        #region Variables
        private ColourIntensitySettingsManager _colourBlendingSettingsManager = new ColourIntensitySettingsManager();
        private GlobalBooleanSettingsManager _globalBooleanSettingsManager = new GlobalBooleanSettingsManager();
        private GlobalStringSettingsManager _globalStringSettingsManager = new GlobalStringSettingsManager();

        private Timer _updateValues = new Timer();
        #endregion

        #region System
        private KryptonButton kbtnResetValues;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnCancel;
        private KryptonButton kbtnApply;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnLightestColourIntensityValuePlus;
        private KryptonButton kbtnLightestColourIntensityValueMinus;
        private KryptonButton kbtLightColourIntensityValuePlus;
        private KryptonButton kbtnLightColourIntensityValueMinus;
        private KryptonButton kbtnMiddleColourIntensityValuePlus;
        private KryptonButton kbtnMiddleColourIntensityValueMinus;
        private KryptonButton kbnDarkestColourIntensityValuePlus;
        private KryptonButton kbtnDarkColourIntensityValueMinus;
        private KryptonLabel kryptonLabel8;
        private KryptonLabel kryptonLabel7;
        private KryptonLabel kryptonLabel6;
        private KryptonLabel kryptonLabel5;
        private KryptonNumericUpDown knumLightestColourIntensityValue;
        private KryptonNumericUpDown knumLightColourIntensityValue;
        private KryptonNumericUpDown knumMiddleColourIntensityValue;
        private KryptonNumericUpDown knumDarkColourIntensityValue;
        private KryptonLabel kryptonLabel4;
        private KryptonLabel kryptonLabel3;
        private KryptonLabel kryptonLabel2;
        private KryptonLabel kryptonLabel1;
        private KryptonLabel klblLightestColourIntensityValueOutput;
        private KryptonLabel klblLightColourIntensityValueOutput;
        private KryptonLabel klblMiddleColourIntensityValueOutput;
        private KryptonLabel klblDarkColourIntensityValueOutput;
        private CircularPictureBox cbxLightestColourPreview;
        private CircularPictureBox cbxLightColourPreview;
        private CircularPictureBox cbxMediumColourPreview;
        private CircularPictureBox cbxDarkColourPreview;
        private KryptonColorButton kcbBaseColour;
        private Krypton.Docking.KryptonDockableNavigator kryptonDockableNavigator1;
        private Krypton.Navigator.KryptonPage kryptonPage1;
        private Krypton.Navigator.KryptonPage kryptonPage2;
        private KryptonComboBox kcmbDisplayType;
        private KryptonLabel kryptonLabel9;
        private KryptonCheckBox kchkAutomaticallyUpdateValues;
        private Krypton.Navigator.KryptonPage kryptonPage3;
        private KryptonButton kbtnRestore;
        private KryptonButton kbtnBrowse;
        private KryptonMaskedTextBox kmtxtFilePath;
        private KryptonLabel kryptonLabel10;
        private CircularPictureBox cbxCircular;
        private PictureBox pbxStandard;
        private KryptonCheckBox kchkGenerateAlphaValue;
        private KryptonCheckBox kcbConvertToHexadecimalValue;
        private KryptonCheckBox kchkConvertToRGBValue;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnResetValues = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnApply = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonDockableNavigator1 = new Krypton.Docking.KryptonDockableNavigator();
            this.kryptonPage1 = new Krypton.Navigator.KryptonPage();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kcbBaseColour = new Krypton.Toolkit.KryptonColorButton();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.cbxLightestColourPreview = new CircularPictureBox();
            this.knumDarkColourIntensityValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.cbxLightColourPreview = new CircularPictureBox();
            this.knumMiddleColourIntensityValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.cbxMediumColourPreview = new CircularPictureBox();
            this.knumLightColourIntensityValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.cbxDarkColourPreview = new CircularPictureBox();
            this.knumLightestColourIntensityValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.klblLightestColourIntensityValueOutput = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.klblLightColourIntensityValueOutput = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            this.klblMiddleColourIntensityValueOutput = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            this.klblDarkColourIntensityValueOutput = new Krypton.Toolkit.KryptonLabel();
            this.kbtnDarkColourIntensityValueMinus = new Krypton.Toolkit.KryptonButton();
            this.kbtnLightestColourIntensityValuePlus = new Krypton.Toolkit.KryptonButton();
            this.kbnDarkestColourIntensityValuePlus = new Krypton.Toolkit.KryptonButton();
            this.kbtnLightestColourIntensityValueMinus = new Krypton.Toolkit.KryptonButton();
            this.kbtnMiddleColourIntensityValueMinus = new Krypton.Toolkit.KryptonButton();
            this.kbtLightColourIntensityValuePlus = new Krypton.Toolkit.KryptonButton();
            this.kbtnMiddleColourIntensityValuePlus = new Krypton.Toolkit.KryptonButton();
            this.kbtnLightColourIntensityValueMinus = new Krypton.Toolkit.KryptonButton();
            this.kryptonPage2 = new Krypton.Navigator.KryptonPage();
            this.kchkConvertToRGBValue = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbConvertToHexadecimalValue = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkGenerateAlphaValue = new Krypton.Toolkit.KryptonCheckBox();
            this.cbxCircular = new CircularPictureBox();
            this.pbxStandard = new System.Windows.Forms.PictureBox();
            this.kcmbDisplayType = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel9 = new Krypton.Toolkit.KryptonLabel();
            this.kchkAutomaticallyUpdateValues = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonPage3 = new Krypton.Navigator.KryptonPage();
            this.kbtnRestore = new Krypton.Toolkit.KryptonButton();
            this.kbtnBrowse = new Krypton.Toolkit.KryptonButton();
            this.kmtxtFilePath = new Krypton.Toolkit.KryptonMaskedTextBox();
            this.kryptonLabel10 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDockableNavigator1)).BeginInit();
            this.kryptonDockableNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxLightestColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxLightColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxMediumColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDarkColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            this.kryptonPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCircular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStandard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbDisplayType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).BeginInit();
            this.kryptonPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnResetValues);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnApply);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 464);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(664, 53);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnResetValues
            // 
            this.kbtnResetValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnResetValues.AutoSize = true;
            this.kbtnResetValues.Enabled = false;
            this.kbtnResetValues.Location = new System.Drawing.Point(12, 11);
            this.kbtnResetValues.Name = "kbtnResetValues";
            this.kbtnResetValues.Size = new System.Drawing.Size(144, 30);
            this.kbtnResetValues.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetValues.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnResetValues.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnResetValues.TabIndex = 1;
            this.kbtnResetValues.Values.Text = "Re&set Values";
            this.kbtnResetValues.Click += new System.EventHandler(this.kbtnResetValues_Click);
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.AutoSize = true;
            this.kbtnOk.Location = new System.Drawing.Point(370, 11);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 30);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnOk.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnOk.TabIndex = 2;
            this.kbtnOk.Values.Text = "&Ok";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.AutoSize = true;
            this.kbtnCancel.Location = new System.Drawing.Point(466, 11);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 30);
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnCancel.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnCancel.TabIndex = 3;
            this.kbtnCancel.Values.Text = "Ca&ncel";
            // 
            // kbtnApply
            // 
            this.kbtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnApply.AutoSize = true;
            this.kbtnApply.Enabled = false;
            this.kbtnApply.Location = new System.Drawing.Point(562, 11);
            this.kbtnApply.Name = "kbtnApply";
            this.kbtnApply.Size = new System.Drawing.Size(90, 30);
            this.kbtnApply.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnApply.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnApply.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnApply.TabIndex = 0;
            this.kbtnApply.Values.Text = "&Apply";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 462);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 2);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonDockableNavigator1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(664, 462);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kryptonDockableNavigator1
            // 
            this.kryptonDockableNavigator1.Button.ButtonDisplayLogic = Krypton.Navigator.ButtonDisplayLogic.NextPrevious;
            this.kryptonDockableNavigator1.Button.CloseButtonAction = Krypton.Navigator.CloseButtonAction.None;
            this.kryptonDockableNavigator1.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonDockableNavigator1.Location = new System.Drawing.Point(12, 12);
            this.kryptonDockableNavigator1.Name = "kryptonDockableNavigator1";
            this.kryptonDockableNavigator1.NavigatorMode = Krypton.Navigator.NavigatorMode.BarCheckButtonGroupOutside;
            this.kryptonDockableNavigator1.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2,
            this.kryptonPage3});
            this.kryptonDockableNavigator1.SelectedIndex = 1;
            this.kryptonDockableNavigator1.Size = new System.Drawing.Size(640, 444);
            this.kryptonDockableNavigator1.TabIndex = 35;
            this.kryptonDockableNavigator1.Text = "kryptonDockableNavigator1";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Controls.Add(this.kryptonLabel1);
            this.kryptonPage1.Controls.Add(this.kryptonLabel2);
            this.kryptonPage1.Controls.Add(this.kryptonLabel3);
            this.kryptonPage1.Controls.Add(this.kcbBaseColour);
            this.kryptonPage1.Controls.Add(this.kryptonLabel4);
            this.kryptonPage1.Controls.Add(this.cbxLightestColourPreview);
            this.kryptonPage1.Controls.Add(this.knumDarkColourIntensityValue);
            this.kryptonPage1.Controls.Add(this.cbxLightColourPreview);
            this.kryptonPage1.Controls.Add(this.knumMiddleColourIntensityValue);
            this.kryptonPage1.Controls.Add(this.cbxMediumColourPreview);
            this.kryptonPage1.Controls.Add(this.knumLightColourIntensityValue);
            this.kryptonPage1.Controls.Add(this.cbxDarkColourPreview);
            this.kryptonPage1.Controls.Add(this.knumLightestColourIntensityValue);
            this.kryptonPage1.Controls.Add(this.kryptonLabel5);
            this.kryptonPage1.Controls.Add(this.klblLightestColourIntensityValueOutput);
            this.kryptonPage1.Controls.Add(this.kryptonLabel6);
            this.kryptonPage1.Controls.Add(this.klblLightColourIntensityValueOutput);
            this.kryptonPage1.Controls.Add(this.kryptonLabel7);
            this.kryptonPage1.Controls.Add(this.klblMiddleColourIntensityValueOutput);
            this.kryptonPage1.Controls.Add(this.kryptonLabel8);
            this.kryptonPage1.Controls.Add(this.klblDarkColourIntensityValueOutput);
            this.kryptonPage1.Controls.Add(this.kbtnDarkColourIntensityValueMinus);
            this.kryptonPage1.Controls.Add(this.kbtnLightestColourIntensityValuePlus);
            this.kryptonPage1.Controls.Add(this.kbnDarkestColourIntensityValuePlus);
            this.kryptonPage1.Controls.Add(this.kbtnLightestColourIntensityValueMinus);
            this.kryptonPage1.Controls.Add(this.kbtnMiddleColourIntensityValueMinus);
            this.kryptonPage1.Controls.Add(this.kbtLightColourIntensityValuePlus);
            this.kryptonPage1.Controls.Add(this.kbtnMiddleColourIntensityValuePlus);
            this.kryptonPage1.Controls.Add(this.kbtnLightColourIntensityValueMinus);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(638, 415);
            this.kryptonPage1.Text = "Colour Intensity";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "CA84FA1D35D047D920A054A4CAC807D7";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(21, 20);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(204, 26);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel1.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Darkest Colour Intensity:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(21, 115);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(199, 26);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel2.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "Middle Colour Intensity:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(21, 210);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(184, 26);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel3.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "Light Colour Intensity:";
            // 
            // kcbBaseColour
            // 
            this.kcbBaseColour.AutoSize = true;
            this.kcbBaseColour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kcbBaseColour.Location = new System.Drawing.Point(21, 362);
            this.kcbBaseColour.Name = "kcbBaseColour";
            this.kcbBaseColour.Size = new System.Drawing.Size(199, 30);
            this.kcbBaseColour.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbBaseColour.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kcbBaseColour.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kcbBaseColour.TabIndex = 32;
            this.kcbBaseColour.Values.Image = global::Krypton.Toolkit.Suite.Extended.Core.Resources.ImageResources.Colour_Wheel_16_x_16;
            this.kcbBaseColour.Values.Text = "&Choose a Base Colour";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(21, 305);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(207, 26);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel4.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel4.TabIndex = 6;
            this.kryptonLabel4.Values.Text = "Lightest Colour Intensity:";
            // 
            // cbxLightestColourPreview
            // 
            this.cbxLightestColourPreview.BackColor = System.Drawing.Color.Black;
            this.cbxLightestColourPreview.Location = new System.Drawing.Point(571, 301);
            this.cbxLightestColourPreview.Name = "cbxLightestColourPreview";
            this.cbxLightestColourPreview.Size = new System.Drawing.Size(32, 32);
            this.cbxLightestColourPreview.TabIndex = 31;
            this.cbxLightestColourPreview.TabStop = false;
            // 
            // knumDarkColourIntensityValue
            // 
            this.knumDarkColourIntensityValue.DecimalPlaces = 2;
            this.knumDarkColourIntensityValue.Location = new System.Drawing.Point(231, 20);
            this.knumDarkColourIntensityValue.Name = "knumDarkColourIntensityValue";
            this.knumDarkColourIntensityValue.Size = new System.Drawing.Size(82, 28);
            this.knumDarkColourIntensityValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumDarkColourIntensityValue.TabIndex = 7;
            this.knumDarkColourIntensityValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.knumDarkColourIntensityValue.ValueChanged += new System.EventHandler(this.knumDarkColourIntensityValue_ValueChanged);
            // 
            // cbxLightColourPreview
            // 
            this.cbxLightColourPreview.BackColor = System.Drawing.Color.Black;
            this.cbxLightColourPreview.Location = new System.Drawing.Point(571, 206);
            this.cbxLightColourPreview.Name = "cbxLightColourPreview";
            this.cbxLightColourPreview.Size = new System.Drawing.Size(32, 32);
            this.cbxLightColourPreview.TabIndex = 30;
            this.cbxLightColourPreview.TabStop = false;
            // 
            // knumMiddleColourIntensityValue
            // 
            this.knumMiddleColourIntensityValue.DecimalPlaces = 2;
            this.knumMiddleColourIntensityValue.Location = new System.Drawing.Point(231, 113);
            this.knumMiddleColourIntensityValue.Name = "knumMiddleColourIntensityValue";
            this.knumMiddleColourIntensityValue.Size = new System.Drawing.Size(82, 28);
            this.knumMiddleColourIntensityValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumMiddleColourIntensityValue.TabIndex = 8;
            this.knumMiddleColourIntensityValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.knumMiddleColourIntensityValue.ValueChanged += new System.EventHandler(this.knumMiddleColourIntensityValue_ValueChanged);
            // 
            // cbxMediumColourPreview
            // 
            this.cbxMediumColourPreview.BackColor = System.Drawing.Color.Black;
            this.cbxMediumColourPreview.Location = new System.Drawing.Point(571, 113);
            this.cbxMediumColourPreview.Name = "cbxMediumColourPreview";
            this.cbxMediumColourPreview.Size = new System.Drawing.Size(32, 32);
            this.cbxMediumColourPreview.TabIndex = 29;
            this.cbxMediumColourPreview.TabStop = false;
            // 
            // knumLightColourIntensityValue
            // 
            this.knumLightColourIntensityValue.DecimalPlaces = 2;
            this.knumLightColourIntensityValue.Location = new System.Drawing.Point(231, 208);
            this.knumLightColourIntensityValue.Name = "knumLightColourIntensityValue";
            this.knumLightColourIntensityValue.Size = new System.Drawing.Size(82, 28);
            this.knumLightColourIntensityValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumLightColourIntensityValue.TabIndex = 9;
            this.knumLightColourIntensityValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.knumLightColourIntensityValue.ValueChanged += new System.EventHandler(this.knumLightColourIntensityValue_ValueChanged);
            // 
            // cbxDarkColourPreview
            // 
            this.cbxDarkColourPreview.BackColor = System.Drawing.Color.Black;
            this.cbxDarkColourPreview.Location = new System.Drawing.Point(571, 20);
            this.cbxDarkColourPreview.Name = "cbxDarkColourPreview";
            this.cbxDarkColourPreview.Size = new System.Drawing.Size(32, 32);
            this.cbxDarkColourPreview.TabIndex = 28;
            this.cbxDarkColourPreview.TabStop = false;
            // 
            // knumLightestColourIntensityValue
            // 
            this.knumLightestColourIntensityValue.DecimalPlaces = 2;
            this.knumLightestColourIntensityValue.Location = new System.Drawing.Point(231, 305);
            this.knumLightestColourIntensityValue.Name = "knumLightestColourIntensityValue";
            this.knumLightestColourIntensityValue.Size = new System.Drawing.Size(82, 28);
            this.knumLightestColourIntensityValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumLightestColourIntensityValue.TabIndex = 10;
            this.knumLightestColourIntensityValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.knumLightestColourIntensityValue.ValueChanged += new System.EventHandler(this.knumLightestColourIntensityValue_ValueChanged);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(319, 20);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(26, 26);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel5.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel5.TabIndex = 11;
            this.kryptonLabel5.Values.Text = "%";
            // 
            // klblLightestColourIntensityValueOutput
            // 
            this.klblLightestColourIntensityValueOutput.Location = new System.Drawing.Point(434, 305);
            this.klblLightestColourIntensityValueOutput.Name = "klblLightestColourIntensityValueOutput";
            this.klblLightestColourIntensityValueOutput.Size = new System.Drawing.Size(98, 26);
            this.klblLightestColourIntensityValueOutput.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblLightestColourIntensityValueOutput.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.klblLightestColourIntensityValueOutput.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.klblLightestColourIntensityValueOutput.TabIndex = 26;
            this.klblLightestColourIntensityValueOutput.Values.Text = "Output: {0}";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(319, 115);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(26, 26);
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel6.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel6.TabIndex = 12;
            this.kryptonLabel6.Values.Text = "%";
            // 
            // klblLightColourIntensityValueOutput
            // 
            this.klblLightColourIntensityValueOutput.Location = new System.Drawing.Point(434, 210);
            this.klblLightColourIntensityValueOutput.Name = "klblLightColourIntensityValueOutput";
            this.klblLightColourIntensityValueOutput.Size = new System.Drawing.Size(98, 26);
            this.klblLightColourIntensityValueOutput.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblLightColourIntensityValueOutput.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.klblLightColourIntensityValueOutput.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.klblLightColourIntensityValueOutput.TabIndex = 25;
            this.klblLightColourIntensityValueOutput.Values.Text = "Output: {0}";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(319, 210);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(26, 26);
            this.kryptonLabel7.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel7.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel7.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel7.TabIndex = 13;
            this.kryptonLabel7.Values.Text = "%";
            // 
            // klblMiddleColourIntensityValueOutput
            // 
            this.klblMiddleColourIntensityValueOutput.Location = new System.Drawing.Point(434, 115);
            this.klblMiddleColourIntensityValueOutput.Name = "klblMiddleColourIntensityValueOutput";
            this.klblMiddleColourIntensityValueOutput.Size = new System.Drawing.Size(98, 26);
            this.klblMiddleColourIntensityValueOutput.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMiddleColourIntensityValueOutput.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.klblMiddleColourIntensityValueOutput.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.klblMiddleColourIntensityValueOutput.TabIndex = 24;
            this.klblMiddleColourIntensityValueOutput.Values.Text = "Output: {0}";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(319, 305);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(26, 26);
            this.kryptonLabel8.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel8.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel8.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel8.TabIndex = 14;
            this.kryptonLabel8.Values.Text = "%";
            // 
            // klblDarkColourIntensityValueOutput
            // 
            this.klblDarkColourIntensityValueOutput.Location = new System.Drawing.Point(434, 20);
            this.klblDarkColourIntensityValueOutput.Name = "klblDarkColourIntensityValueOutput";
            this.klblDarkColourIntensityValueOutput.Size = new System.Drawing.Size(98, 26);
            this.klblDarkColourIntensityValueOutput.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblDarkColourIntensityValueOutput.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.klblDarkColourIntensityValueOutput.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.klblDarkColourIntensityValueOutput.TabIndex = 23;
            this.klblDarkColourIntensityValueOutput.Values.Text = "Output: {0}";
            // 
            // kbtnDarkColourIntensityValueMinus
            // 
            this.kbtnDarkColourIntensityValueMinus.AutoSize = true;
            this.kbtnDarkColourIntensityValueMinus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnDarkColourIntensityValueMinus.Location = new System.Drawing.Point(351, 20);
            this.kbtnDarkColourIntensityValueMinus.Name = "kbtnDarkColourIntensityValueMinus";
            this.kbtnDarkColourIntensityValueMinus.Size = new System.Drawing.Size(18, 30);
            this.kbtnDarkColourIntensityValueMinus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnDarkColourIntensityValueMinus.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnDarkColourIntensityValueMinus.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnDarkColourIntensityValueMinus.TabIndex = 15;
            this.kbtnDarkColourIntensityValueMinus.Values.Text = "-";
            this.kbtnDarkColourIntensityValueMinus.Click += new System.EventHandler(this.kbtnDarkColourIntensityValueMinus_Click);
            // 
            // kbtnLightestColourIntensityValuePlus
            // 
            this.kbtnLightestColourIntensityValuePlus.AutoSize = true;
            this.kbtnLightestColourIntensityValuePlus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnLightestColourIntensityValuePlus.Location = new System.Drawing.Point(387, 301);
            this.kbtnLightestColourIntensityValuePlus.Name = "kbtnLightestColourIntensityValuePlus";
            this.kbtnLightestColourIntensityValuePlus.Size = new System.Drawing.Size(23, 30);
            this.kbtnLightestColourIntensityValuePlus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnLightestColourIntensityValuePlus.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnLightestColourIntensityValuePlus.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnLightestColourIntensityValuePlus.TabIndex = 22;
            this.kbtnLightestColourIntensityValuePlus.Values.Text = "+";
            this.kbtnLightestColourIntensityValuePlus.Click += new System.EventHandler(this.kbtnLightestColourIntensityValuePlus_Click);
            // 
            // kbnDarkestColourIntensityValuePlus
            // 
            this.kbnDarkestColourIntensityValuePlus.AutoSize = true;
            this.kbnDarkestColourIntensityValuePlus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbnDarkestColourIntensityValuePlus.Location = new System.Drawing.Point(387, 20);
            this.kbnDarkestColourIntensityValuePlus.Name = "kbnDarkestColourIntensityValuePlus";
            this.kbnDarkestColourIntensityValuePlus.Size = new System.Drawing.Size(23, 30);
            this.kbnDarkestColourIntensityValuePlus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbnDarkestColourIntensityValuePlus.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbnDarkestColourIntensityValuePlus.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbnDarkestColourIntensityValuePlus.TabIndex = 16;
            this.kbnDarkestColourIntensityValuePlus.Values.Text = "+";
            this.kbnDarkestColourIntensityValuePlus.Click += new System.EventHandler(this.kbnDarkestColourIntensityValuePlus_Click);
            // 
            // kbtnLightestColourIntensityValueMinus
            // 
            this.kbtnLightestColourIntensityValueMinus.AutoSize = true;
            this.kbtnLightestColourIntensityValueMinus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnLightestColourIntensityValueMinus.Location = new System.Drawing.Point(351, 301);
            this.kbtnLightestColourIntensityValueMinus.Name = "kbtnLightestColourIntensityValueMinus";
            this.kbtnLightestColourIntensityValueMinus.Size = new System.Drawing.Size(18, 30);
            this.kbtnLightestColourIntensityValueMinus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnLightestColourIntensityValueMinus.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnLightestColourIntensityValueMinus.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnLightestColourIntensityValueMinus.TabIndex = 21;
            this.kbtnLightestColourIntensityValueMinus.Values.Text = "-";
            this.kbtnLightestColourIntensityValueMinus.Click += new System.EventHandler(this.kbtnLightestColourIntensityValueMinus_Click);
            // 
            // kbtnMiddleColourIntensityValueMinus
            // 
            this.kbtnMiddleColourIntensityValueMinus.AutoSize = true;
            this.kbtnMiddleColourIntensityValueMinus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnMiddleColourIntensityValueMinus.Location = new System.Drawing.Point(351, 111);
            this.kbtnMiddleColourIntensityValueMinus.Name = "kbtnMiddleColourIntensityValueMinus";
            this.kbtnMiddleColourIntensityValueMinus.Size = new System.Drawing.Size(18, 30);
            this.kbtnMiddleColourIntensityValueMinus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnMiddleColourIntensityValueMinus.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnMiddleColourIntensityValueMinus.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnMiddleColourIntensityValueMinus.TabIndex = 17;
            this.kbtnMiddleColourIntensityValueMinus.Values.Text = "-";
            this.kbtnMiddleColourIntensityValueMinus.Click += new System.EventHandler(this.kbtnMiddleColourIntensityValueMinus_Click);
            // 
            // kbtLightColourIntensityValuePlus
            // 
            this.kbtLightColourIntensityValuePlus.AutoSize = true;
            this.kbtLightColourIntensityValuePlus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtLightColourIntensityValuePlus.Location = new System.Drawing.Point(387, 206);
            this.kbtLightColourIntensityValuePlus.Name = "kbtLightColourIntensityValuePlus";
            this.kbtLightColourIntensityValuePlus.Size = new System.Drawing.Size(23, 30);
            this.kbtLightColourIntensityValuePlus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtLightColourIntensityValuePlus.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtLightColourIntensityValuePlus.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtLightColourIntensityValuePlus.TabIndex = 20;
            this.kbtLightColourIntensityValuePlus.Values.Text = "+";
            this.kbtLightColourIntensityValuePlus.Click += new System.EventHandler(this.kbtLightColourIntensityValuePlus_Click);
            // 
            // kbtnMiddleColourIntensityValuePlus
            // 
            this.kbtnMiddleColourIntensityValuePlus.AutoSize = true;
            this.kbtnMiddleColourIntensityValuePlus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnMiddleColourIntensityValuePlus.Location = new System.Drawing.Point(387, 111);
            this.kbtnMiddleColourIntensityValuePlus.Name = "kbtnMiddleColourIntensityValuePlus";
            this.kbtnMiddleColourIntensityValuePlus.Size = new System.Drawing.Size(23, 30);
            this.kbtnMiddleColourIntensityValuePlus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnMiddleColourIntensityValuePlus.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnMiddleColourIntensityValuePlus.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnMiddleColourIntensityValuePlus.TabIndex = 18;
            this.kbtnMiddleColourIntensityValuePlus.Values.Text = "+";
            this.kbtnMiddleColourIntensityValuePlus.Click += new System.EventHandler(this.kbtnMiddleColourIntensityValuePlus_Click);
            // 
            // kbtnLightColourIntensityValueMinus
            // 
            this.kbtnLightColourIntensityValueMinus.AutoSize = true;
            this.kbtnLightColourIntensityValueMinus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnLightColourIntensityValueMinus.Location = new System.Drawing.Point(351, 206);
            this.kbtnLightColourIntensityValueMinus.Name = "kbtnLightColourIntensityValueMinus";
            this.kbtnLightColourIntensityValueMinus.Size = new System.Drawing.Size(18, 30);
            this.kbtnLightColourIntensityValueMinus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnLightColourIntensityValueMinus.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnLightColourIntensityValueMinus.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnLightColourIntensityValueMinus.TabIndex = 19;
            this.kbtnLightColourIntensityValueMinus.Values.Text = "-";
            this.kbtnLightColourIntensityValueMinus.Click += new System.EventHandler(this.kbtnLightColourIntensityValueMinus_Click);
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Controls.Add(this.kchkConvertToRGBValue);
            this.kryptonPage2.Controls.Add(this.kcbConvertToHexadecimalValue);
            this.kryptonPage2.Controls.Add(this.kchkGenerateAlphaValue);
            this.kryptonPage2.Controls.Add(this.cbxCircular);
            this.kryptonPage2.Controls.Add(this.pbxStandard);
            this.kryptonPage2.Controls.Add(this.kcmbDisplayType);
            this.kryptonPage2.Controls.Add(this.kryptonLabel9);
            this.kryptonPage2.Controls.Add(this.kchkAutomaticallyUpdateValues);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(638, 415);
            this.kryptonPage2.Text = "UI Options";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "FA50690FF4D649BA9E9ED453E8E571B5";
            // 
            // kchkConvertToRGBValue
            // 
            this.kchkConvertToRGBValue.Location = new System.Drawing.Point(43, 253);
            this.kchkConvertToRGBValue.Name = "kchkConvertToRGBValue";
            this.kchkConvertToRGBValue.Size = new System.Drawing.Size(286, 26);
            this.kchkConvertToRGBValue.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkConvertToRGBValue.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kchkConvertToRGBValue.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kchkConvertToRGBValue.TabIndex = 42;
            this.kchkConvertToRGBValue.Values.Text = "Automatically Convert to &RGB Value";
            // 
            // kcbConvertToHexadecimalValue
            // 
            this.kcbConvertToHexadecimalValue.Location = new System.Drawing.Point(43, 200);
            this.kcbConvertToHexadecimalValue.Name = "kcbConvertToHexadecimalValue";
            this.kcbConvertToHexadecimalValue.Size = new System.Drawing.Size(348, 26);
            this.kcbConvertToHexadecimalValue.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbConvertToHexadecimalValue.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kcbConvertToHexadecimalValue.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kcbConvertToHexadecimalValue.TabIndex = 41;
            this.kcbConvertToHexadecimalValue.Values.Text = "Automatically Convert to &Hexadecimal Value";
            // 
            // kchkGenerateAlphaValue
            // 
            this.kchkGenerateAlphaValue.Location = new System.Drawing.Point(43, 147);
            this.kchkGenerateAlphaValue.Name = "kchkGenerateAlphaValue";
            this.kchkGenerateAlphaValue.Size = new System.Drawing.Size(205, 26);
            this.kchkGenerateAlphaValue.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkGenerateAlphaValue.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kchkGenerateAlphaValue.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kchkGenerateAlphaValue.TabIndex = 40;
            this.kchkGenerateAlphaValue.Values.Text = "&Generate an Alpha Value";
            // 
            // cbxCircular
            // 
            this.cbxCircular.BackColor = System.Drawing.Color.Black;
            this.cbxCircular.Location = new System.Drawing.Point(351, 84);
            this.cbxCircular.Name = "cbxCircular";
            this.cbxCircular.Size = new System.Drawing.Size(32, 32);
            this.cbxCircular.TabIndex = 39;
            this.cbxCircular.TabStop = false;
            // 
            // pbxStandard
            // 
            this.pbxStandard.BackColor = System.Drawing.Color.Black;
            this.pbxStandard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxStandard.Location = new System.Drawing.Point(351, 84);
            this.pbxStandard.Name = "pbxStandard";
            this.pbxStandard.Size = new System.Drawing.Size(32, 32);
            this.pbxStandard.TabIndex = 38;
            this.pbxStandard.TabStop = false;
            // 
            // kcmbDisplayType
            // 
            this.kcmbDisplayType.DropDownWidth = 203;
            this.kcmbDisplayType.Items.AddRange(new object[] {
            "Standard",
            "Circular"});
            this.kcmbDisplayType.Location = new System.Drawing.Point(142, 84);
            this.kcmbDisplayType.Name = "kcmbDisplayType";
            this.kcmbDisplayType.Size = new System.Drawing.Size(203, 27);
            this.kcmbDisplayType.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbDisplayType.TabIndex = 37;
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(21, 83);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(115, 26);
            this.kryptonLabel9.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel9.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel9.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel9.TabIndex = 36;
            this.kryptonLabel9.Values.Text = "Display Type:";
            // 
            // kchkAutomaticallyUpdateValues
            // 
            this.kchkAutomaticallyUpdateValues.Location = new System.Drawing.Point(21, 20);
            this.kchkAutomaticallyUpdateValues.Name = "kchkAutomaticallyUpdateValues";
            this.kchkAutomaticallyUpdateValues.Size = new System.Drawing.Size(234, 26);
            this.kchkAutomaticallyUpdateValues.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkAutomaticallyUpdateValues.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kchkAutomaticallyUpdateValues.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kchkAutomaticallyUpdateValues.TabIndex = 35;
            this.kchkAutomaticallyUpdateValues.Values.Text = "&Automatically Update Values";
            // 
            // kryptonPage3
            // 
            this.kryptonPage3.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage3.Controls.Add(this.kbtnRestore);
            this.kryptonPage3.Controls.Add(this.kbtnBrowse);
            this.kryptonPage3.Controls.Add(this.kmtxtFilePath);
            this.kryptonPage3.Controls.Add(this.kryptonLabel10);
            this.kryptonPage3.Flags = 65534;
            this.kryptonPage3.LastVisibleSet = true;
            this.kryptonPage3.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage3.Name = "kryptonPage3";
            this.kryptonPage3.Size = new System.Drawing.Size(638, 415);
            this.kryptonPage3.Text = "File Options";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "4FF76322826141100EA9C00D97F3A7A2";
            // 
            // kbtnRestore
            // 
            this.kbtnRestore.AutoSize = true;
            this.kbtnRestore.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnRestore.Enabled = false;
            this.kbtnRestore.Location = new System.Drawing.Point(43, 56);
            this.kbtnRestore.Name = "kbtnRestore";
            this.kbtnRestore.Size = new System.Drawing.Size(133, 30);
            this.kbtnRestore.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnRestore.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnRestore.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnRestore.TabIndex = 61;
            this.kbtnRestore.Values.Text = "&Restore File Path";
            this.kbtnRestore.Click += new System.EventHandler(this.kbtnRestore_Click);
            // 
            // kbtnBrowse
            // 
            this.kbtnBrowse.AutoSize = true;
            this.kbtnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnBrowse.Location = new System.Drawing.Point(573, 24);
            this.kbtnBrowse.Name = "kbtnBrowse";
            this.kbtnBrowse.Size = new System.Drawing.Size(23, 30);
            this.kbtnBrowse.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnBrowse.StateCommon.Content.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kbtnBrowse.StateCommon.Content.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kbtnBrowse.TabIndex = 60;
            this.kbtnBrowse.Values.Text = "...";
            this.kbtnBrowse.Click += new System.EventHandler(this.kbtnBrowse_Click);
            // 
            // kmtxtFilePath
            // 
            this.kmtxtFilePath.Location = new System.Drawing.Point(201, 24);
            this.kmtxtFilePath.Name = "kmtxtFilePath";
            this.kmtxtFilePath.Size = new System.Drawing.Size(366, 29);
            this.kmtxtFilePath.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kmtxtFilePath.TabIndex = 59;
            this.kmtxtFilePath.TextChanged += new System.EventHandler(this.kmtxtFilePath_TextChanged);
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Location = new System.Drawing.Point(43, 24);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(152, 26);
            this.kryptonLabel10.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel10.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonLabel10.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonLabel10.TabIndex = 58;
            this.kryptonLabel10.Values.Text = "Export Colours to:";
            // 
            // ColourBlendingOptions
            // 
            this.ClientSize = new System.Drawing.Size(664, 517);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColourBlendingOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Colour Blending Options";
            this.Load += new System.EventHandler(this.ColourBlendingOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDockableNavigator1)).EndInit();
            this.kryptonDockableNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            this.kryptonPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxLightestColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxLightColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxMediumColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDarkColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            this.kryptonPage2.ResumeLayout(false);
            this.kryptonPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCircular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStandard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbDisplayType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).EndInit();
            this.kryptonPage3.ResumeLayout(false);
            this.kryptonPage3.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Constructors
        public ColourBlendingOptions()
        {
            InitializeComponent();
        }
        #endregion

        private void ColourBlendingOptions_Load(object sender, EventArgs e)
        {
            InitialiseWindow();
        }

        private void knumDarkColourIntensityValue_ValueChanged(object sender, EventArgs e)
        {
            UpdateFeedback(klblDarkColourIntensityValueOutput, knumDarkColourIntensityValue.Value);
        }

        private void knumMiddleColourIntensityValue_ValueChanged(object sender, EventArgs e)
        {
            ToggleButtons(true);
        }

        private void knumLightColourIntensityValue_ValueChanged(object sender, EventArgs e)
        {
            ToggleButtons(true);
        }

        private void knumLightestColourIntensityValue_ValueChanged(object sender, EventArgs e)
        {
            ToggleButtons(true);
        }

        private void kbtnDarkColourIntensityValueMinus_Click(object sender, EventArgs e)
        {
            knumDarkColourIntensityValue.Increment = -1;
        }

        private void kbtnMiddleColourIntensityValueMinus_Click(object sender, EventArgs e)
        {
            knumMiddleColourIntensityValue.Increment = -1;
        }

        private void kbtnLightColourIntensityValueMinus_Click(object sender, EventArgs e)
        {
            knumLightColourIntensityValue.Increment = -1;
        }

        private void kbtnLightestColourIntensityValueMinus_Click(object sender, EventArgs e)
        {
            knumLightestColourIntensityValue.Increment = -1;
        }

        private void kbnDarkestColourIntensityValuePlus_Click(object sender, EventArgs e)
        {
            knumDarkColourIntensityValue.Increment = knumDarkColourIntensityValue.Value + 1;
        }

        private void kbtnMiddleColourIntensityValuePlus_Click(object sender, EventArgs e)
        {
            knumMiddleColourIntensityValue.Increment = knumMiddleColourIntensityValue.Value + 1;
        }

        private void kbtLightColourIntensityValuePlus_Click(object sender, EventArgs e)
        {
            knumLightColourIntensityValue.Increment = knumLightColourIntensityValue.Value + 1;
        }

        private void kbtnLightestColourIntensityValuePlus_Click(object sender, EventArgs e)
        {
            knumLightestColourIntensityValue.Increment = knumLightestColourIntensityValue.Value + 1;
        }

        private void kbtnResetValues_Click(object sender, EventArgs e)
        {
            _colourBlendingSettingsManager.ResetColourBlendingValues(_globalBooleanSettingsManager.GetUsePromptFeedback());

            _globalBooleanSettingsManager.SetAutomaticallyUpdateColours(true);

            _globalStringSettingsManager.SetPaletteExportPath(Environment.SpecialFolder.MyDocuments + "\\Krypton Palettes");

            kmtxtFilePath.Text = Environment.SpecialFolder.MyDocuments + "\\Krypton Palettes";
        }

        private void UpdateValues_Tick(object sender, EventArgs e)
        {
            ColourUtilities.GenerateColourShades(cbxDarkColourPreview, cbxMediumColourPreview, cbxLightColourPreview, cbxLightestColourPreview, Convert.ToSingle(knumDarkColourIntensityValue.Value), Convert.ToSingle(knumMiddleColourIntensityValue.Value), Convert.ToSingle(knumLightColourIntensityValue.Value), Convert.ToSingle(knumLightestColourIntensityValue.Value), kcbBaseColour.SelectedColor);
        }

        #region Methods
        private void UpdateFeedback(KryptonLabel output, decimal intensityPercentage)
        {
            float temp = Decimal.ToSingle(intensityPercentage);

            output.Text = $"Output: { temp.ToString() }";
        }

        private void SetApplyButton(bool enabled)
        {
            kbtnApply.Enabled = enabled;
        }

        private void SetRestoreValuesButton(bool enabled)
        {
            kbtnRestore.Enabled = enabled;
        }

        private void InitialiseWindow()
        {
            _updateValues.Interval = 250;

            _updateValues.Enabled = true;

            _updateValues.Tick += UpdateValues_Tick;

            knumDarkColourIntensityValue.Value = (decimal)_colourBlendingSettingsManager.GetDarkestColourIntensity();

            knumMiddleColourIntensityValue.Value = (decimal)_colourBlendingSettingsManager.GetMediumColourIntensity();

            knumLightColourIntensityValue.Value = (decimal)_colourBlendingSettingsManager.GetLightColourIntensity();

            knumLightestColourIntensityValue.Value = (decimal)_colourBlendingSettingsManager.GetLightestColourIntensity();

            kchkAutomaticallyUpdateValues.Checked = _globalBooleanSettingsManager.GetAutomaticallyUpdateColours();
        }

        private void ToggleButtons(bool enabled)
        {
            SetApplyButton(enabled);

            SetRestoreValuesButton(enabled);
        }
        #endregion

        private void kbtnBrowse_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog();

            commonOpenFileDialog.IsFolderPicker = true;

            if (commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                kmtxtFilePath.Text = Path.GetFullPath(commonOpenFileDialog.FileName);
            }

            ToggleButtons(true);
        }

        private void kbtnRestore_Click(object sender, EventArgs e)
        {

        }

        private void kmtxtFilePath_TextChanged(object sender, EventArgs e)
        {
            kbtnResetValues.Enabled = true;

            ToggleButtons(true);
        }
    }
}