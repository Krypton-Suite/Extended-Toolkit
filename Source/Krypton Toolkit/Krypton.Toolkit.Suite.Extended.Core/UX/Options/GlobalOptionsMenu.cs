#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public partial class GlobalOptionsMenu : KryptonForm
    {
        #region System
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private Krypton.Navigator.KryptonPage kryptonPage1;
        private Krypton.Navigator.KryptonPage kpTheme;
        private KryptonUACElevatedButton kbtnUACApply;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnCancel;
        private Krypton.Docking.KryptonDockableNavigator kryptonDockableNavigator1;
        private Krypton.Navigator.KryptonPage kryptonPage3;
        private Krypton.Navigator.KryptonPage kryptonPage4;
        private Krypton.Navigator.KryptonPage kryptonPage5;
        private KryptonLabel kryptonLabel1;
        private KryptonLabel kryptonLabel2;
        private KryptonLabel kryptonLabel3;
        private KryptonColorButton kcbBaseColour;
        private KryptonLabel kryptonLabel4;
        private CircularPictureBox cbxLightestColourPreview;
        private KryptonNumericUpDown knumDarkColourIntensityValue;
        private CircularPictureBox cbxLightColourPreview;
        private KryptonNumericUpDown knumMiddleColourIntensityValue;
        private CircularPictureBox cbxMediumColourPreview;
        private KryptonNumericUpDown knumLightColourIntensityValue;
        private CircularPictureBox cbxDarkColourPreview;
        private KryptonNumericUpDown knumLightestColourIntensityValue;
        private KryptonLabel kryptonLabel5;
        private KryptonLabel klblLightestColourIntensityValueOutput;
        private KryptonLabel kryptonLabel6;
        private KryptonLabel klblLightColourIntensityValueOutput;
        private KryptonLabel kryptonLabel7;
        private KryptonLabel klblMiddleColourIntensityValueOutput;
        private KryptonLabel kryptonLabel8;
        private KryptonLabel klblDarkColourIntensityValueOutput;
        private KryptonButton kbtnDarkColourIntensityValueMinus;
        private KryptonButton kbtnLightestColourIntensityValuePlus;
        private KryptonButton kbnDarkestColourIntensityValuePlus;
        private KryptonButton kbtnLightestColourIntensityValueMinus;
        private KryptonButton kbtnMiddleColourIntensityValueMinus;
        private KryptonButton kbtLightColourIntensityValuePlus;
        private KryptonButton kbtnMiddleColourIntensityValuePlus;
        private KryptonButton kbtnLightColourIntensityValueMinus;
        private KryptonButton kbtnResetColourBlendingValues;
        private KryptonCheckBox kchkConvertToRGBValue;
        private KryptonCheckBox kcbConvertToHexadecimalValue;
        private KryptonCheckBox kchkGenerateAlphaValue;
        private CircularPictureBox cbxCircular;
        private System.Windows.Forms.PictureBox pbxStandard;
        private KryptonComboBox kcmbDisplayType;
        private KryptonLabel kryptonLabel9;
        private KryptonCheckBox kchkAutomaticallyUpdateValues;
        private KryptonButton kbtnRestore;
        private KryptonButton kbtnBrowse;
        private KryptonMaskedTextBox kmtxtFilePath;
        private KryptonLabel kryptonLabel10;
        private KryptonTextBox ktxtCustomPath;
        private KryptonLabel klblCustomTheme;
        private KryptonComboBox kcmbPaletteTheme;
        private KryptonLabel kryptonLabel11;
        private KryptonButton kbtnLoadTheme;
        private KryptonButton kbtnImportPalette;
        private KryptonButton kbtnResetThemeValues;
        private Krypton.Navigator.KryptonPage kpSettings;
        private KryptonButton kbtnResetPaletteTypefaceSettings;
        private KryptonButton kbtnResetGlobalStringSettings;
        private KryptonButton kbtnResetGlobalBooleanSettings;
        private KryptonButton kbtnResetColourStringSettings;
        private KryptonButton kbtnResetColourSettings;
        private KryptonButton kbtnResetColourIntegerSettings;
        private KryptonButton kbtnResetColourBlendingSettings;
        private KryptonButton kbtnNukeAllSettings;
        private KryptonCheckBox kchkAskForConfirmation;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalOptionsMenu));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnResetThemeValues = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetColourBlendingValues = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnUACApply = new KryptonUACElevatedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonNavigator1 = new Krypton.Navigator.KryptonNavigator();
            this.kryptonPage1 = new Krypton.Navigator.KryptonPage();
            this.kryptonDockableNavigator1 = new Krypton.Docking.KryptonDockableNavigator();
            this.kryptonPage3 = new Krypton.Navigator.KryptonPage();
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
            this.kryptonPage4 = new Krypton.Navigator.KryptonPage();
            this.kchkConvertToRGBValue = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbConvertToHexadecimalValue = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkGenerateAlphaValue = new Krypton.Toolkit.KryptonCheckBox();
            this.cbxCircular = new CircularPictureBox();
            this.pbxStandard = new System.Windows.Forms.PictureBox();
            this.kcmbDisplayType = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel9 = new Krypton.Toolkit.KryptonLabel();
            this.kchkAutomaticallyUpdateValues = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonPage5 = new Krypton.Navigator.KryptonPage();
            this.kbtnRestore = new Krypton.Toolkit.KryptonButton();
            this.kbtnBrowse = new Krypton.Toolkit.KryptonButton();
            this.kmtxtFilePath = new Krypton.Toolkit.KryptonMaskedTextBox();
            this.kryptonLabel10 = new Krypton.Toolkit.KryptonLabel();
            this.kpTheme = new Krypton.Navigator.KryptonPage();
            this.kbtnLoadTheme = new Krypton.Toolkit.KryptonButton();
            this.kbtnImportPalette = new Krypton.Toolkit.KryptonButton();
            this.ktxtCustomPath = new Krypton.Toolkit.KryptonTextBox();
            this.klblCustomTheme = new Krypton.Toolkit.KryptonLabel();
            this.kcmbPaletteTheme = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel11 = new Krypton.Toolkit.KryptonLabel();
            this.kpSettings = new Krypton.Navigator.KryptonPage();
            this.kchkAskForConfirmation = new Krypton.Toolkit.KryptonCheckBox();
            this.kbtnResetPaletteTypefaceSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetGlobalStringSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetGlobalBooleanSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetColourStringSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetColourSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetColourIntegerSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnResetColourBlendingSettings = new Krypton.Toolkit.KryptonButton();
            this.kbtnNukeAllSettings = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDockableNavigator1)).BeginInit();
            this.kryptonDockableNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).BeginInit();
            this.kryptonPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxLightestColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxLightColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxMediumColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDarkColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).BeginInit();
            this.kryptonPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCircular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStandard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbDisplayType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage5)).BeginInit();
            this.kryptonPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpTheme)).BeginInit();
            this.kpTheme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbPaletteTheme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpSettings)).BeginInit();
            this.kpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnResetThemeValues);
            this.kryptonPanel1.Controls.Add(this.kbtnResetColourBlendingValues);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnUACApply);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 537);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(690, 52);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnResetThemeValues
            // 
            this.kbtnResetThemeValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnResetThemeValues.AutoSize = true;
            this.kbtnResetThemeValues.Enabled = false;
            this.kbtnResetThemeValues.Location = new System.Drawing.Point(12, 10);
            this.kbtnResetThemeValues.Name = "kbtnResetThemeValues";
            this.kbtnResetThemeValues.Size = new System.Drawing.Size(144, 30);
            this.kbtnResetThemeValues.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetThemeValues.TabIndex = 63;
            this.kbtnResetThemeValues.Values.Text = "Re&set Values";
            // 
            // kbtnResetColourBlendingValues
            // 
            this.kbtnResetColourBlendingValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnResetColourBlendingValues.AutoSize = true;
            this.kbtnResetColourBlendingValues.Enabled = false;
            this.kbtnResetColourBlendingValues.Location = new System.Drawing.Point(12, 10);
            this.kbtnResetColourBlendingValues.Name = "kbtnResetColourBlendingValues";
            this.kbtnResetColourBlendingValues.Size = new System.Drawing.Size(144, 30);
            this.kbtnResetColourBlendingValues.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetColourBlendingValues.TabIndex = 62;
            this.kbtnResetColourBlendingValues.Values.Text = "Re&set Values";
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.AutoSize = true;
            this.kbtnOk.Location = new System.Drawing.Point(414, 10);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 30);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.TabIndex = 4;
            this.kbtnOk.Values.Text = "&Ok";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.AutoSize = true;
            this.kbtnCancel.Location = new System.Drawing.Point(510, 10);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 30);
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.TabIndex = 5;
            this.kbtnCancel.Values.Text = "Ca&ncel";
            // 
            // kbtnUACApply
            // 
            this.kbtnUACApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnUACApply.AutoSize = true;
            this.kbtnUACApply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnUACApply.Enabled = false;
            this.kbtnUACApply.Location = new System.Drawing.Point(606, 10);
            this.kbtnUACApply.Name = "kbtnUACApply";
            this.kbtnUACApply.Size = new System.Drawing.Size(71, 30);
            this.kbtnUACApply.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnUACApply.TabIndex = 0;
            this.kbtnUACApply.Values.Image = ((System.Drawing.Image)(resources.GetObject("kbtnUACApply.Values.Image")));
            this.kbtnUACApply.Values.Text = "&Apply";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 534);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonNavigator1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(690, 534);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Button.ButtonDisplayLogic = Krypton.Navigator.ButtonDisplayLogic.NextPrevious;
            this.kryptonNavigator1.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Location = new System.Drawing.Point(12, 12);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.NavigatorMode = Krypton.Navigator.NavigatorMode.BarCheckButtonGroupOutside;
            this.kryptonNavigator1.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kpTheme,
            this.kpSettings});
            this.kryptonNavigator1.SelectedIndex = 1;
            this.kryptonNavigator1.Size = new System.Drawing.Size(663, 511);
            this.kryptonNavigator1.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonNavigator1.TabIndex = 0;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Controls.Add(this.kryptonDockableNavigator1);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(661, 482);
            this.kryptonPage1.Text = "C&olour Blending";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "5B92D5986C334B5ADFAF98FE8EEA16E1";
            // 
            // kryptonDockableNavigator1
            // 
            this.kryptonDockableNavigator1.Button.ButtonDisplayLogic = Krypton.Navigator.ButtonDisplayLogic.NextPrevious;
            this.kryptonDockableNavigator1.Button.CloseButtonAction = Krypton.Navigator.CloseButtonAction.None;
            this.kryptonDockableNavigator1.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonDockableNavigator1.Location = new System.Drawing.Point(15, 19);
            this.kryptonDockableNavigator1.Name = "kryptonDockableNavigator1";
            this.kryptonDockableNavigator1.NavigatorMode = Krypton.Navigator.NavigatorMode.BarCheckButtonGroupOutside;
            this.kryptonDockableNavigator1.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage3,
            this.kryptonPage4,
            this.kryptonPage5});
            this.kryptonDockableNavigator1.SelectedIndex = 0;
            this.kryptonDockableNavigator1.Size = new System.Drawing.Size(627, 450);
            this.kryptonDockableNavigator1.TabIndex = 36;
            this.kryptonDockableNavigator1.Text = "kryptonDockableNavigator1";
            // 
            // kryptonPage3
            // 
            this.kryptonPage3.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage3.Controls.Add(this.kryptonLabel1);
            this.kryptonPage3.Controls.Add(this.kryptonLabel2);
            this.kryptonPage3.Controls.Add(this.kryptonLabel3);
            this.kryptonPage3.Controls.Add(this.kcbBaseColour);
            this.kryptonPage3.Controls.Add(this.kryptonLabel4);
            this.kryptonPage3.Controls.Add(this.cbxLightestColourPreview);
            this.kryptonPage3.Controls.Add(this.knumDarkColourIntensityValue);
            this.kryptonPage3.Controls.Add(this.cbxLightColourPreview);
            this.kryptonPage3.Controls.Add(this.knumMiddleColourIntensityValue);
            this.kryptonPage3.Controls.Add(this.cbxMediumColourPreview);
            this.kryptonPage3.Controls.Add(this.knumLightColourIntensityValue);
            this.kryptonPage3.Controls.Add(this.cbxDarkColourPreview);
            this.kryptonPage3.Controls.Add(this.knumLightestColourIntensityValue);
            this.kryptonPage3.Controls.Add(this.kryptonLabel5);
            this.kryptonPage3.Controls.Add(this.klblLightestColourIntensityValueOutput);
            this.kryptonPage3.Controls.Add(this.kryptonLabel6);
            this.kryptonPage3.Controls.Add(this.klblLightColourIntensityValueOutput);
            this.kryptonPage3.Controls.Add(this.kryptonLabel7);
            this.kryptonPage3.Controls.Add(this.klblMiddleColourIntensityValueOutput);
            this.kryptonPage3.Controls.Add(this.kryptonLabel8);
            this.kryptonPage3.Controls.Add(this.klblDarkColourIntensityValueOutput);
            this.kryptonPage3.Controls.Add(this.kbtnDarkColourIntensityValueMinus);
            this.kryptonPage3.Controls.Add(this.kbtnLightestColourIntensityValuePlus);
            this.kryptonPage3.Controls.Add(this.kbnDarkestColourIntensityValuePlus);
            this.kryptonPage3.Controls.Add(this.kbtnLightestColourIntensityValueMinus);
            this.kryptonPage3.Controls.Add(this.kbtnMiddleColourIntensityValueMinus);
            this.kryptonPage3.Controls.Add(this.kbtLightColourIntensityValuePlus);
            this.kryptonPage3.Controls.Add(this.kbtnMiddleColourIntensityValuePlus);
            this.kryptonPage3.Controls.Add(this.kbtnLightColourIntensityValueMinus);
            this.kryptonPage3.Flags = 65534;
            this.kryptonPage3.LastVisibleSet = true;
            this.kryptonPage3.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage3.Name = "kryptonPage3";
            this.kryptonPage3.Size = new System.Drawing.Size(625, 421);
            this.kryptonPage3.Text = "Colour Intensity";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "CA84FA1D35D047D920A054A4CAC807D7";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(17, 27);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(204, 26);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.TabIndex = 33;
            this.kryptonLabel1.Values.Text = "Darkest Colour Intensity:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(17, 122);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(199, 26);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 34;
            this.kryptonLabel2.Values.Text = "Middle Colour Intensity:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(17, 217);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(184, 26);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 35;
            this.kryptonLabel3.Values.Text = "Light Colour Intensity:";
            // 
            // kcbBaseColour
            // 
            this.kcbBaseColour.AutoSize = true;
            this.kcbBaseColour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kcbBaseColour.Location = new System.Drawing.Point(17, 369);
            this.kcbBaseColour.Name = "kcbBaseColour";
            this.kcbBaseColour.Size = new System.Drawing.Size(199, 30);
            this.kcbBaseColour.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbBaseColour.TabIndex = 61;
            this.kcbBaseColour.Values.Image = global::Krypton.Toolkit.Suite.Extended.Core.Resources.ImageResources.Colour_Wheel_16_x_16;
            this.kcbBaseColour.Values.Text = "&Choose a Base Colour";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(17, 312);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(207, 26);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 36;
            this.kryptonLabel4.Values.Text = "Lightest Colour Intensity:";
            // 
            // cbxLightestColourPreview
            // 
            this.cbxLightestColourPreview.BackColor = System.Drawing.Color.Black;
            this.cbxLightestColourPreview.Location = new System.Drawing.Point(567, 308);
            this.cbxLightestColourPreview.Name = "cbxLightestColourPreview";
            this.cbxLightestColourPreview.Size = new System.Drawing.Size(32, 32);
            this.cbxLightestColourPreview.TabIndex = 60;
            this.cbxLightestColourPreview.TabStop = false;
            // 
            // knumDarkColourIntensityValue
            // 
            this.knumDarkColourIntensityValue.DecimalPlaces = 2;
            this.knumDarkColourIntensityValue.Location = new System.Drawing.Point(227, 27);
            this.knumDarkColourIntensityValue.Name = "knumDarkColourIntensityValue";
            this.knumDarkColourIntensityValue.Size = new System.Drawing.Size(82, 28);
            this.knumDarkColourIntensityValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumDarkColourIntensityValue.TabIndex = 37;
            this.knumDarkColourIntensityValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbxLightColourPreview
            // 
            this.cbxLightColourPreview.BackColor = System.Drawing.Color.Black;
            this.cbxLightColourPreview.Location = new System.Drawing.Point(567, 213);
            this.cbxLightColourPreview.Name = "cbxLightColourPreview";
            this.cbxLightColourPreview.Size = new System.Drawing.Size(32, 32);
            this.cbxLightColourPreview.TabIndex = 59;
            this.cbxLightColourPreview.TabStop = false;
            // 
            // knumMiddleColourIntensityValue
            // 
            this.knumMiddleColourIntensityValue.DecimalPlaces = 2;
            this.knumMiddleColourIntensityValue.Location = new System.Drawing.Point(227, 120);
            this.knumMiddleColourIntensityValue.Name = "knumMiddleColourIntensityValue";
            this.knumMiddleColourIntensityValue.Size = new System.Drawing.Size(82, 28);
            this.knumMiddleColourIntensityValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumMiddleColourIntensityValue.TabIndex = 38;
            this.knumMiddleColourIntensityValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbxMediumColourPreview
            // 
            this.cbxMediumColourPreview.BackColor = System.Drawing.Color.Black;
            this.cbxMediumColourPreview.Location = new System.Drawing.Point(567, 120);
            this.cbxMediumColourPreview.Name = "cbxMediumColourPreview";
            this.cbxMediumColourPreview.Size = new System.Drawing.Size(32, 32);
            this.cbxMediumColourPreview.TabIndex = 58;
            this.cbxMediumColourPreview.TabStop = false;
            // 
            // knumLightColourIntensityValue
            // 
            this.knumLightColourIntensityValue.DecimalPlaces = 2;
            this.knumLightColourIntensityValue.Location = new System.Drawing.Point(227, 215);
            this.knumLightColourIntensityValue.Name = "knumLightColourIntensityValue";
            this.knumLightColourIntensityValue.Size = new System.Drawing.Size(82, 28);
            this.knumLightColourIntensityValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumLightColourIntensityValue.TabIndex = 39;
            this.knumLightColourIntensityValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbxDarkColourPreview
            // 
            this.cbxDarkColourPreview.BackColor = System.Drawing.Color.Black;
            this.cbxDarkColourPreview.Location = new System.Drawing.Point(567, 27);
            this.cbxDarkColourPreview.Name = "cbxDarkColourPreview";
            this.cbxDarkColourPreview.Size = new System.Drawing.Size(32, 32);
            this.cbxDarkColourPreview.TabIndex = 57;
            this.cbxDarkColourPreview.TabStop = false;
            // 
            // knumLightestColourIntensityValue
            // 
            this.knumLightestColourIntensityValue.DecimalPlaces = 2;
            this.knumLightestColourIntensityValue.Location = new System.Drawing.Point(227, 312);
            this.knumLightestColourIntensityValue.Name = "knumLightestColourIntensityValue";
            this.knumLightestColourIntensityValue.Size = new System.Drawing.Size(82, 28);
            this.knumLightestColourIntensityValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumLightestColourIntensityValue.TabIndex = 40;
            this.knumLightestColourIntensityValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(315, 27);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(26, 26);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.TabIndex = 41;
            this.kryptonLabel5.Values.Text = "%";
            // 
            // klblLightestColourIntensityValueOutput
            // 
            this.klblLightestColourIntensityValueOutput.Location = new System.Drawing.Point(430, 312);
            this.klblLightestColourIntensityValueOutput.Name = "klblLightestColourIntensityValueOutput";
            this.klblLightestColourIntensityValueOutput.Size = new System.Drawing.Size(98, 26);
            this.klblLightestColourIntensityValueOutput.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblLightestColourIntensityValueOutput.TabIndex = 56;
            this.klblLightestColourIntensityValueOutput.Values.Text = "Output: {0}";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(315, 122);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(26, 26);
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.TabIndex = 42;
            this.kryptonLabel6.Values.Text = "%";
            // 
            // klblLightColourIntensityValueOutput
            // 
            this.klblLightColourIntensityValueOutput.Location = new System.Drawing.Point(430, 217);
            this.klblLightColourIntensityValueOutput.Name = "klblLightColourIntensityValueOutput";
            this.klblLightColourIntensityValueOutput.Size = new System.Drawing.Size(98, 26);
            this.klblLightColourIntensityValueOutput.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblLightColourIntensityValueOutput.TabIndex = 55;
            this.klblLightColourIntensityValueOutput.Values.Text = "Output: {0}";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(315, 217);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(26, 26);
            this.kryptonLabel7.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel7.TabIndex = 43;
            this.kryptonLabel7.Values.Text = "%";
            // 
            // klblMiddleColourIntensityValueOutput
            // 
            this.klblMiddleColourIntensityValueOutput.Location = new System.Drawing.Point(430, 122);
            this.klblMiddleColourIntensityValueOutput.Name = "klblMiddleColourIntensityValueOutput";
            this.klblMiddleColourIntensityValueOutput.Size = new System.Drawing.Size(98, 26);
            this.klblMiddleColourIntensityValueOutput.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMiddleColourIntensityValueOutput.TabIndex = 54;
            this.klblMiddleColourIntensityValueOutput.Values.Text = "Output: {0}";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(315, 312);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(26, 26);
            this.kryptonLabel8.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel8.TabIndex = 44;
            this.kryptonLabel8.Values.Text = "%";
            // 
            // klblDarkColourIntensityValueOutput
            // 
            this.klblDarkColourIntensityValueOutput.Location = new System.Drawing.Point(430, 27);
            this.klblDarkColourIntensityValueOutput.Name = "klblDarkColourIntensityValueOutput";
            this.klblDarkColourIntensityValueOutput.Size = new System.Drawing.Size(98, 26);
            this.klblDarkColourIntensityValueOutput.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblDarkColourIntensityValueOutput.TabIndex = 53;
            this.klblDarkColourIntensityValueOutput.Values.Text = "Output: {0}";
            // 
            // kbtnDarkColourIntensityValueMinus
            // 
            this.kbtnDarkColourIntensityValueMinus.AutoSize = true;
            this.kbtnDarkColourIntensityValueMinus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnDarkColourIntensityValueMinus.Location = new System.Drawing.Point(347, 27);
            this.kbtnDarkColourIntensityValueMinus.Name = "kbtnDarkColourIntensityValueMinus";
            this.kbtnDarkColourIntensityValueMinus.Size = new System.Drawing.Size(18, 30);
            this.kbtnDarkColourIntensityValueMinus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnDarkColourIntensityValueMinus.TabIndex = 45;
            this.kbtnDarkColourIntensityValueMinus.Values.Text = "-";
            // 
            // kbtnLightestColourIntensityValuePlus
            // 
            this.kbtnLightestColourIntensityValuePlus.AutoSize = true;
            this.kbtnLightestColourIntensityValuePlus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnLightestColourIntensityValuePlus.Location = new System.Drawing.Point(383, 308);
            this.kbtnLightestColourIntensityValuePlus.Name = "kbtnLightestColourIntensityValuePlus";
            this.kbtnLightestColourIntensityValuePlus.Size = new System.Drawing.Size(23, 30);
            this.kbtnLightestColourIntensityValuePlus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnLightestColourIntensityValuePlus.TabIndex = 52;
            this.kbtnLightestColourIntensityValuePlus.Values.Text = "+";
            // 
            // kbnDarkestColourIntensityValuePlus
            // 
            this.kbnDarkestColourIntensityValuePlus.AutoSize = true;
            this.kbnDarkestColourIntensityValuePlus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbnDarkestColourIntensityValuePlus.Location = new System.Drawing.Point(383, 27);
            this.kbnDarkestColourIntensityValuePlus.Name = "kbnDarkestColourIntensityValuePlus";
            this.kbnDarkestColourIntensityValuePlus.Size = new System.Drawing.Size(23, 30);
            this.kbnDarkestColourIntensityValuePlus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbnDarkestColourIntensityValuePlus.TabIndex = 46;
            this.kbnDarkestColourIntensityValuePlus.Values.Text = "+";
            // 
            // kbtnLightestColourIntensityValueMinus
            // 
            this.kbtnLightestColourIntensityValueMinus.AutoSize = true;
            this.kbtnLightestColourIntensityValueMinus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnLightestColourIntensityValueMinus.Location = new System.Drawing.Point(347, 308);
            this.kbtnLightestColourIntensityValueMinus.Name = "kbtnLightestColourIntensityValueMinus";
            this.kbtnLightestColourIntensityValueMinus.Size = new System.Drawing.Size(18, 30);
            this.kbtnLightestColourIntensityValueMinus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnLightestColourIntensityValueMinus.TabIndex = 51;
            this.kbtnLightestColourIntensityValueMinus.Values.Text = "-";
            // 
            // kbtnMiddleColourIntensityValueMinus
            // 
            this.kbtnMiddleColourIntensityValueMinus.AutoSize = true;
            this.kbtnMiddleColourIntensityValueMinus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnMiddleColourIntensityValueMinus.Location = new System.Drawing.Point(347, 118);
            this.kbtnMiddleColourIntensityValueMinus.Name = "kbtnMiddleColourIntensityValueMinus";
            this.kbtnMiddleColourIntensityValueMinus.Size = new System.Drawing.Size(18, 30);
            this.kbtnMiddleColourIntensityValueMinus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnMiddleColourIntensityValueMinus.TabIndex = 47;
            this.kbtnMiddleColourIntensityValueMinus.Values.Text = "-";
            // 
            // kbtLightColourIntensityValuePlus
            // 
            this.kbtLightColourIntensityValuePlus.AutoSize = true;
            this.kbtLightColourIntensityValuePlus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtLightColourIntensityValuePlus.Location = new System.Drawing.Point(383, 213);
            this.kbtLightColourIntensityValuePlus.Name = "kbtLightColourIntensityValuePlus";
            this.kbtLightColourIntensityValuePlus.Size = new System.Drawing.Size(23, 30);
            this.kbtLightColourIntensityValuePlus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtLightColourIntensityValuePlus.TabIndex = 50;
            this.kbtLightColourIntensityValuePlus.Values.Text = "+";
            // 
            // kbtnMiddleColourIntensityValuePlus
            // 
            this.kbtnMiddleColourIntensityValuePlus.AutoSize = true;
            this.kbtnMiddleColourIntensityValuePlus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnMiddleColourIntensityValuePlus.Location = new System.Drawing.Point(383, 118);
            this.kbtnMiddleColourIntensityValuePlus.Name = "kbtnMiddleColourIntensityValuePlus";
            this.kbtnMiddleColourIntensityValuePlus.Size = new System.Drawing.Size(23, 30);
            this.kbtnMiddleColourIntensityValuePlus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnMiddleColourIntensityValuePlus.TabIndex = 48;
            this.kbtnMiddleColourIntensityValuePlus.Values.Text = "+";
            // 
            // kbtnLightColourIntensityValueMinus
            // 
            this.kbtnLightColourIntensityValueMinus.AutoSize = true;
            this.kbtnLightColourIntensityValueMinus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnLightColourIntensityValueMinus.Location = new System.Drawing.Point(347, 213);
            this.kbtnLightColourIntensityValueMinus.Name = "kbtnLightColourIntensityValueMinus";
            this.kbtnLightColourIntensityValueMinus.Size = new System.Drawing.Size(18, 30);
            this.kbtnLightColourIntensityValueMinus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnLightColourIntensityValueMinus.TabIndex = 49;
            this.kbtnLightColourIntensityValueMinus.Values.Text = "-";
            // 
            // kryptonPage4
            // 
            this.kryptonPage4.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage4.Controls.Add(this.kchkConvertToRGBValue);
            this.kryptonPage4.Controls.Add(this.kcbConvertToHexadecimalValue);
            this.kryptonPage4.Controls.Add(this.kchkGenerateAlphaValue);
            this.kryptonPage4.Controls.Add(this.cbxCircular);
            this.kryptonPage4.Controls.Add(this.pbxStandard);
            this.kryptonPage4.Controls.Add(this.kcmbDisplayType);
            this.kryptonPage4.Controls.Add(this.kryptonLabel9);
            this.kryptonPage4.Controls.Add(this.kchkAutomaticallyUpdateValues);
            this.kryptonPage4.Flags = 65534;
            this.kryptonPage4.LastVisibleSet = true;
            this.kryptonPage4.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage4.Name = "kryptonPage4";
            this.kryptonPage4.Size = new System.Drawing.Size(625, 421);
            this.kryptonPage4.Text = "UI Options";
            this.kryptonPage4.ToolTipTitle = "Page ToolTip";
            this.kryptonPage4.UniqueName = "FA50690FF4D649BA9E9ED453E8E571B5";
            // 
            // kchkConvertToRGBValue
            // 
            this.kchkConvertToRGBValue.Location = new System.Drawing.Point(39, 257);
            this.kchkConvertToRGBValue.Name = "kchkConvertToRGBValue";
            this.kchkConvertToRGBValue.Size = new System.Drawing.Size(286, 26);
            this.kchkConvertToRGBValue.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkConvertToRGBValue.TabIndex = 50;
            this.kchkConvertToRGBValue.Values.Text = "Automatically Convert to &RGB Value";
            // 
            // kcbConvertToHexadecimalValue
            // 
            this.kcbConvertToHexadecimalValue.Location = new System.Drawing.Point(39, 204);
            this.kcbConvertToHexadecimalValue.Name = "kcbConvertToHexadecimalValue";
            this.kcbConvertToHexadecimalValue.Size = new System.Drawing.Size(348, 26);
            this.kcbConvertToHexadecimalValue.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbConvertToHexadecimalValue.TabIndex = 49;
            this.kcbConvertToHexadecimalValue.Values.Text = "Automatically Convert to &Hexadecimal Value";
            // 
            // kchkGenerateAlphaValue
            // 
            this.kchkGenerateAlphaValue.Location = new System.Drawing.Point(39, 151);
            this.kchkGenerateAlphaValue.Name = "kchkGenerateAlphaValue";
            this.kchkGenerateAlphaValue.Size = new System.Drawing.Size(205, 26);
            this.kchkGenerateAlphaValue.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkGenerateAlphaValue.TabIndex = 48;
            this.kchkGenerateAlphaValue.Values.Text = "&Generate an Alpha Value";
            // 
            // cbxCircular
            // 
            this.cbxCircular.BackColor = System.Drawing.Color.Black;
            this.cbxCircular.Location = new System.Drawing.Point(347, 88);
            this.cbxCircular.Name = "cbxCircular";
            this.cbxCircular.Size = new System.Drawing.Size(32, 32);
            this.cbxCircular.TabIndex = 47;
            this.cbxCircular.TabStop = false;
            // 
            // pbxStandard
            // 
            this.pbxStandard.BackColor = System.Drawing.Color.Black;
            this.pbxStandard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxStandard.Location = new System.Drawing.Point(347, 88);
            this.pbxStandard.Name = "pbxStandard";
            this.pbxStandard.Size = new System.Drawing.Size(32, 32);
            this.pbxStandard.TabIndex = 46;
            this.pbxStandard.TabStop = false;
            // 
            // kcmbDisplayType
            // 
            this.kcmbDisplayType.DropDownWidth = 203;
            this.kcmbDisplayType.Items.AddRange(new object[] {
            "Standard",
            "Circular"});
            this.kcmbDisplayType.Location = new System.Drawing.Point(138, 88);
            this.kcmbDisplayType.Name = "kcmbDisplayType";
            this.kcmbDisplayType.Size = new System.Drawing.Size(203, 27);
            this.kcmbDisplayType.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbDisplayType.TabIndex = 45;
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(17, 87);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(115, 26);
            this.kryptonLabel9.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel9.TabIndex = 44;
            this.kryptonLabel9.Values.Text = "Display Type:";
            // 
            // kchkAutomaticallyUpdateValues
            // 
            this.kchkAutomaticallyUpdateValues.Location = new System.Drawing.Point(17, 24);
            this.kchkAutomaticallyUpdateValues.Name = "kchkAutomaticallyUpdateValues";
            this.kchkAutomaticallyUpdateValues.Size = new System.Drawing.Size(234, 26);
            this.kchkAutomaticallyUpdateValues.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkAutomaticallyUpdateValues.TabIndex = 43;
            this.kchkAutomaticallyUpdateValues.Values.Text = "&Automatically Update Values";
            // 
            // kryptonPage5
            // 
            this.kryptonPage5.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage5.Controls.Add(this.kbtnRestore);
            this.kryptonPage5.Controls.Add(this.kbtnBrowse);
            this.kryptonPage5.Controls.Add(this.kmtxtFilePath);
            this.kryptonPage5.Controls.Add(this.kryptonLabel10);
            this.kryptonPage5.Flags = 65534;
            this.kryptonPage5.LastVisibleSet = true;
            this.kryptonPage5.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage5.Name = "kryptonPage5";
            this.kryptonPage5.Size = new System.Drawing.Size(625, 421);
            this.kryptonPage5.Text = "File Options";
            this.kryptonPage5.ToolTipTitle = "Page ToolTip";
            this.kryptonPage5.UniqueName = "4FF76322826141100EA9C00D97F3A7A2";
            // 
            // kbtnRestore
            // 
            this.kbtnRestore.AutoSize = true;
            this.kbtnRestore.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnRestore.Enabled = false;
            this.kbtnRestore.Location = new System.Drawing.Point(17, 56);
            this.kbtnRestore.Name = "kbtnRestore";
            this.kbtnRestore.Size = new System.Drawing.Size(133, 30);
            this.kbtnRestore.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnRestore.TabIndex = 65;
            this.kbtnRestore.Values.Text = "&Restore File Path";
            // 
            // kbtnBrowse
            // 
            this.kbtnBrowse.AutoSize = true;
            this.kbtnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnBrowse.Location = new System.Drawing.Point(547, 24);
            this.kbtnBrowse.Name = "kbtnBrowse";
            this.kbtnBrowse.Size = new System.Drawing.Size(23, 30);
            this.kbtnBrowse.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnBrowse.TabIndex = 64;
            this.kbtnBrowse.Values.Text = "...";
            // 
            // kmtxtFilePath
            // 
            this.kmtxtFilePath.Location = new System.Drawing.Point(175, 24);
            this.kmtxtFilePath.Name = "kmtxtFilePath";
            this.kmtxtFilePath.Size = new System.Drawing.Size(366, 29);
            this.kmtxtFilePath.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kmtxtFilePath.TabIndex = 63;
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Location = new System.Drawing.Point(17, 24);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(152, 26);
            this.kryptonLabel10.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel10.TabIndex = 62;
            this.kryptonLabel10.Values.Text = "Export Colours to:";
            // 
            // kpTheme
            // 
            this.kpTheme.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpTheme.Controls.Add(this.kbtnLoadTheme);
            this.kpTheme.Controls.Add(this.kbtnImportPalette);
            this.kpTheme.Controls.Add(this.ktxtCustomPath);
            this.kpTheme.Controls.Add(this.klblCustomTheme);
            this.kpTheme.Controls.Add(this.kcmbPaletteTheme);
            this.kpTheme.Controls.Add(this.kryptonLabel11);
            this.kpTheme.Flags = 65534;
            this.kpTheme.LastVisibleSet = true;
            this.kpTheme.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpTheme.Name = "kpTheme";
            this.kpTheme.Size = new System.Drawing.Size(661, 482);
            this.kpTheme.Text = "&Theme";
            this.kpTheme.ToolTipTitle = "Page ToolTip";
            this.kpTheme.UniqueName = "DACF4417245246D33A84C27025B0D112";
            // 
            // kbtnLoadTheme
            // 
            this.kbtnLoadTheme.AutoSize = true;
            this.kbtnLoadTheme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnLoadTheme.Enabled = false;
            this.kbtnLoadTheme.Location = new System.Drawing.Point(597, 103);
            this.kbtnLoadTheme.Name = "kbtnLoadTheme";
            this.kbtnLoadTheme.Size = new System.Drawing.Size(47, 30);
            this.kbtnLoadTheme.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnLoadTheme.TabIndex = 9;
            this.kbtnLoadTheme.Values.Text = "&Load";
            this.kbtnLoadTheme.Visible = false;
            // 
            // kbtnImportPalette
            // 
            this.kbtnImportPalette.AutoSize = true;
            this.kbtnImportPalette.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnImportPalette.Enabled = false;
            this.kbtnImportPalette.Location = new System.Drawing.Point(621, 62);
            this.kbtnImportPalette.Name = "kbtnImportPalette";
            this.kbtnImportPalette.Size = new System.Drawing.Size(23, 30);
            this.kbtnImportPalette.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnImportPalette.TabIndex = 8;
            this.kbtnImportPalette.Values.Text = ".&..";
            this.kbtnImportPalette.Click += new System.EventHandler(this.kbtnImportPalette_Click);
            // 
            // ktxtCustomPath
            // 
            this.ktxtCustomPath.Enabled = false;
            this.ktxtCustomPath.Location = new System.Drawing.Point(251, 62);
            this.ktxtCustomPath.Name = "ktxtCustomPath";
            this.ktxtCustomPath.Size = new System.Drawing.Size(364, 29);
            this.ktxtCustomPath.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtCustomPath.TabIndex = 7;
            // 
            // klblCustomTheme
            // 
            this.klblCustomTheme.Enabled = false;
            this.klblCustomTheme.Location = new System.Drawing.Point(41, 65);
            this.klblCustomTheme.Name = "klblCustomTheme";
            this.klblCustomTheme.Size = new System.Drawing.Size(204, 26);
            this.klblCustomTheme.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblCustomTheme.TabIndex = 6;
            this.klblCustomTheme.Values.Text = "Custom Theme File Path:";
            // 
            // kcmbPaletteTheme
            // 
            this.kcmbPaletteTheme.DropDownWidth = 216;
            this.kcmbPaletteTheme.Location = new System.Drawing.Point(150, 22);
            this.kcmbPaletteTheme.Name = "kcmbPaletteTheme";
            this.kcmbPaletteTheme.Size = new System.Drawing.Size(216, 27);
            this.kcmbPaletteTheme.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbPaletteTheme.TabIndex = 5;
            this.kcmbPaletteTheme.SelectedIndexChanged += new System.EventHandler(this.kcmbPaletteTheme_SelectedIndexChanged);
            this.kcmbPaletteTheme.TextChanged += new System.EventHandler(this.kcmbPaletteTheme_TextChanged);
            // 
            // kryptonLabel11
            // 
            this.kryptonLabel11.Location = new System.Drawing.Point(15, 22);
            this.kryptonLabel11.Name = "kryptonLabel11";
            this.kryptonLabel11.Size = new System.Drawing.Size(128, 26);
            this.kryptonLabel11.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel11.TabIndex = 4;
            this.kryptonLabel11.Values.Text = "Palette Theme:";
            // 
            // kpSettings
            // 
            this.kpSettings.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpSettings.Controls.Add(this.kchkAskForConfirmation);
            this.kpSettings.Controls.Add(this.kbtnResetPaletteTypefaceSettings);
            this.kpSettings.Controls.Add(this.kbtnResetGlobalStringSettings);
            this.kpSettings.Controls.Add(this.kbtnResetGlobalBooleanSettings);
            this.kpSettings.Controls.Add(this.kbtnResetColourStringSettings);
            this.kpSettings.Controls.Add(this.kbtnResetColourSettings);
            this.kpSettings.Controls.Add(this.kbtnResetColourIntegerSettings);
            this.kpSettings.Controls.Add(this.kbtnResetColourBlendingSettings);
            this.kpSettings.Controls.Add(this.kbtnNukeAllSettings);
            this.kpSettings.Flags = 65534;
            this.kpSettings.LastVisibleSet = true;
            this.kpSettings.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpSettings.Name = "kpSettings";
            this.kpSettings.Size = new System.Drawing.Size(661, 482);
            this.kpSettings.Text = "Se&ttings";
            this.kpSettings.ToolTipTitle = "Page ToolTip";
            this.kpSettings.UniqueName = "D086C4F6C5234FC02DA044DBB946AE2F";
            // 
            // kchkAskForConfirmation
            // 
            this.kchkAskForConfirmation.Location = new System.Drawing.Point(469, 440);
            this.kchkAskForConfirmation.Name = "kchkAskForConfirmation";
            this.kchkAskForConfirmation.Size = new System.Drawing.Size(175, 26);
            this.kchkAskForConfirmation.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kchkAskForConfirmation.TabIndex = 80;
            this.kchkAskForConfirmation.Values.Text = "&Ask for Confirmation";
            // 
            // kbtnResetPaletteTypefaceSettings
            // 
            this.kbtnResetPaletteTypefaceSettings.AutoSize = true;
            this.kbtnResetPaletteTypefaceSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnResetPaletteTypefaceSettings.Location = new System.Drawing.Point(18, 370);
            this.kbtnResetPaletteTypefaceSettings.Name = "kbtnResetPaletteTypefaceSettings";
            this.kbtnResetPaletteTypefaceSettings.Size = new System.Drawing.Size(238, 30);
            this.kbtnResetPaletteTypefaceSettings.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetPaletteTypefaceSettings.TabIndex = 79;
            this.kbtnResetPaletteTypefaceSettings.Values.Text = "Reset &Palette Typeface Settings";
            // 
            // kbtnResetGlobalStringSettings
            // 
            this.kbtnResetGlobalStringSettings.AutoSize = true;
            this.kbtnResetGlobalStringSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnResetGlobalStringSettings.Location = new System.Drawing.Point(18, 312);
            this.kbtnResetGlobalStringSettings.Name = "kbtnResetGlobalStringSettings";
            this.kbtnResetGlobalStringSettings.Size = new System.Drawing.Size(214, 30);
            this.kbtnResetGlobalStringSettings.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetGlobalStringSettings.TabIndex = 78;
            this.kbtnResetGlobalStringSettings.Values.Text = "Reset &Global String Settings";
            // 
            // kbtnResetGlobalBooleanSettings
            // 
            this.kbtnResetGlobalBooleanSettings.AutoSize = true;
            this.kbtnResetGlobalBooleanSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnResetGlobalBooleanSettings.Location = new System.Drawing.Point(18, 254);
            this.kbtnResetGlobalBooleanSettings.Name = "kbtnResetGlobalBooleanSettings";
            this.kbtnResetGlobalBooleanSettings.Size = new System.Drawing.Size(230, 30);
            this.kbtnResetGlobalBooleanSettings.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetGlobalBooleanSettings.TabIndex = 77;
            this.kbtnResetGlobalBooleanSettings.Values.Text = "Reset Global B&oolean Settings";
            // 
            // kbtnResetColourStringSettings
            // 
            this.kbtnResetColourStringSettings.AutoSize = true;
            this.kbtnResetColourStringSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnResetColourStringSettings.Location = new System.Drawing.Point(18, 196);
            this.kbtnResetColourStringSettings.Name = "kbtnResetColourStringSettings";
            this.kbtnResetColourStringSettings.Size = new System.Drawing.Size(215, 30);
            this.kbtnResetColourStringSettings.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetColourStringSettings.TabIndex = 76;
            this.kbtnResetColourStringSettings.Values.Text = "Reset Colour &String Settings";
            // 
            // kbtnResetColourSettings
            // 
            this.kbtnResetColourSettings.AutoSize = true;
            this.kbtnResetColourSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnResetColourSettings.Location = new System.Drawing.Point(18, 138);
            this.kbtnResetColourSettings.Name = "kbtnResetColourSettings";
            this.kbtnResetColourSettings.Size = new System.Drawing.Size(168, 30);
            this.kbtnResetColourSettings.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetColourSettings.TabIndex = 75;
            this.kbtnResetColourSettings.Values.Text = "Reset &Colour Settings";
            // 
            // kbtnResetColourIntegerSettings
            // 
            this.kbtnResetColourIntegerSettings.AutoSize = true;
            this.kbtnResetColourIntegerSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnResetColourIntegerSettings.Location = new System.Drawing.Point(18, 80);
            this.kbtnResetColourIntegerSettings.Name = "kbtnResetColourIntegerSettings";
            this.kbtnResetColourIntegerSettings.Size = new System.Drawing.Size(224, 30);
            this.kbtnResetColourIntegerSettings.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetColourIntegerSettings.TabIndex = 74;
            this.kbtnResetColourIntegerSettings.Values.Text = "Reset Colour &Integer Settings";
            // 
            // kbtnResetColourBlendingSettings
            // 
            this.kbtnResetColourBlendingSettings.AutoSize = true;
            this.kbtnResetColourBlendingSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnResetColourBlendingSettings.Location = new System.Drawing.Point(18, 22);
            this.kbtnResetColourBlendingSettings.Name = "kbtnResetColourBlendingSettings";
            this.kbtnResetColourBlendingSettings.Size = new System.Drawing.Size(236, 30);
            this.kbtnResetColourBlendingSettings.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnResetColourBlendingSettings.TabIndex = 73;
            this.kbtnResetColourBlendingSettings.Values.Text = "Reset Colour &Blending Settings";
            // 
            // kbtnNukeAllSettings
            // 
            this.kbtnNukeAllSettings.AutoSize = true;
            this.kbtnNukeAllSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnNukeAllSettings.Location = new System.Drawing.Point(18, 428);
            this.kbtnNukeAllSettings.Name = "kbtnNukeAllSettings";
            this.kbtnNukeAllSettings.Size = new System.Drawing.Size(137, 30);
            this.kbtnNukeAllSettings.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnNukeAllSettings.TabIndex = 72;
            this.kbtnNukeAllSettings.Values.Text = "&Nuke All Settings";
            // 
            // GlobalOptionsMenu
            // 
            this.ClientSize = new System.Drawing.Size(690, 589);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GlobalOptionsMenu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Global Options Menu";
            this.TextExtra = "(For Development Use Only)";
            this.Load += new System.EventHandler(this.GlobalOptionsMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDockableNavigator1)).EndInit();
            this.kryptonDockableNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).EndInit();
            this.kryptonPage3.ResumeLayout(false);
            this.kryptonPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxLightestColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxLightColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxMediumColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDarkColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).EndInit();
            this.kryptonPage4.ResumeLayout(false);
            this.kryptonPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxCircular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStandard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbDisplayType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage5)).EndInit();
            this.kryptonPage5.ResumeLayout(false);
            this.kryptonPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpTheme)).EndInit();
            this.kpTheme.ResumeLayout(false);
            this.kpTheme.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbPaletteTheme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpSettings)).EndInit();
            this.kpSettings.ResumeLayout(false);
            this.kpSettings.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private KryptonManager _manager = new KryptonManager();
        private KryptonPalette _palette = new KryptonPalette();
        private ThemeManager _themeManager = new ThemeManager();
        private ThemingLogic _themingLogic = new ThemingLogic();
        private PaletteThemeSettingsManager _paletteThemeSettingsManager = new PaletteThemeSettingsManager();
        #endregion

        public GlobalOptionsMenu()
        {
            InitializeComponent();
        }

        private void GlobalOptionsMenu_Load(object sender, EventArgs e)
        {
            InitialiseWindow();
        }

        private void InitialiseWindow()
        {
            DialogResult result = KryptonMessageBox.Show("This is for developmental use only. Do you want to continue?", "Global Options", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                Hide();
            }

            _themeManager.PropagateThemes(kcmbPaletteTheme);

            kcmbPaletteTheme.Text = _paletteThemeSettingsManager.GetTheme().ToString();
        }

        private void kbtnImportPalette_Click(object sender, EventArgs e)
        {
            _palette.Import();

            ktxtCustomPath.Text = _palette.GetCustomisedKryptonPaletteFilePath();

            ThemeManager.SetCustomTheme(_manager, _palette, ktxtCustomPath.Text);
        }

        private void kcmbPaletteTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            _manager = new KryptonManager();

            if (kcmbPaletteTheme.Text == "Professional System")
            {
                ThemeManager.SwitchTheme(PaletteModeManager.ProfessionalSystem, _manager);
            }
            else if (kcmbPaletteTheme.Text == "Professional Office 2003")
            {
                ThemeManager.SwitchTheme(PaletteModeManager.ProfessionalOffice2003, _manager);
            }
            else if (kcmbPaletteTheme.Text == "Office 2007 Black")
            {
                ThemeManager.SwitchTheme(PaletteModeManager.Office2007Black, _manager);
            }
            else if (kcmbPaletteTheme.Text == "Office 2007 Blue")
            {
                ThemeManager.SwitchTheme(PaletteModeManager.Office2007Blue, _manager);
            }
            else if (kcmbPaletteTheme.Text == "Office 2007 Silver")
            {
                ThemeManager.SwitchTheme(PaletteModeManager.Office2007Silver, _manager);
            }
            else if (kcmbPaletteTheme.Text == "Office 2010 Black")
            {
                ThemeManager.SwitchTheme(PaletteModeManager.Office2010Black, _manager);
            }
            else if (kcmbPaletteTheme.Text == "Office 2010 Blue")
            {
                ThemeManager.SwitchTheme(PaletteModeManager.Office2010Blue, _manager);
            }
            else if (kcmbPaletteTheme.Text == "Office 2010 Silver")
            {
                ThemeManager.SwitchTheme(PaletteModeManager.Office2010Silver, _manager);
            }
            else if (kcmbPaletteTheme.Text == "Office 2013 White")
            {
                ThemeManager.SwitchTheme(PaletteModeManager.Office2013White, _manager);
            }
            else if (kcmbPaletteTheme.Text == "Sparkle Blue")
            {
                ThemeManager.SwitchTheme(PaletteModeManager.SparkleBlue, _manager);
            }
            else if (kcmbPaletteTheme.Text == "Sparkle Orange")
            {
                ThemeManager.SwitchTheme(PaletteModeManager.SparkleOrange, _manager);
            }
            else if (kcmbPaletteTheme.Text == "Sparkle Purple")
            {
                ThemeManager.SwitchTheme(PaletteModeManager.SparklePurple, _manager);
            }
            else if (kcmbPaletteTheme.Text == "Custom")
            {
                ThemeManager.EnableCustomThemeControls(klblCustomTheme, ktxtCustomPath, kbtnImportPalette, true);

                ThemeManager.SwitchTheme(PaletteModeManager.Custom, _manager);
            }
        }

        private void kcmbPaletteTheme_TextChanged(object sender, EventArgs e)
        {

        }
    }
}