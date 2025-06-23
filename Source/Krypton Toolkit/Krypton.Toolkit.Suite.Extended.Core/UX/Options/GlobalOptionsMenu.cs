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

namespace Krypton.Toolkit.Suite.Extended.Core;

public partial class GlobalOptionsMenu : KryptonForm
{
    #region System

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
    private KryptonMaskedTextBox kmtxtFilePath;
    private KryptonLabel kryptonLabel10;
    private KryptonLabel klblCustomTheme;
    private KryptonLabel kryptonLabel11;
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
    private KryptonBorderEdge kryptonBorderEdge1;
    private ButtonSpecAny bsaReset;
    private ButtonSpecAny bsaBrowse;
    private KryptonThemeComboBox ktcmbTheme;
    private KryptonButton kbtnLoadTheme;
    private KryptonTextBox ktxtCustomPath;
    private ButtonSpecAny buttonSpecAny1;
    private ButtonSpecAny buttonSpecAny2;
    private KryptonPanel kryptonPanel1;

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new(typeof(GlobalOptionsMenu));
        this.kryptonPanel1 = new();
        this.kryptonBorderEdge1 = new();
        this.kbtnResetThemeValues = new();
        this.kbtnResetColourBlendingValues = new();
        this.kbtnOk = new();
        this.kbtnCancel = new();
        this.kbtnUACApply = new();
        this.kryptonPanel2 = new();
        this.kryptonNavigator1 = new();
        this.kryptonPage1 = new();
        this.kryptonDockableNavigator1 = new();
        this.kryptonPage3 = new();
        this.kryptonLabel1 = new();
        this.kryptonLabel2 = new();
        this.kryptonLabel3 = new();
        this.kcbBaseColour = new();
        this.kryptonLabel4 = new();
        this.cbxLightestColourPreview = new();
        this.knumDarkColourIntensityValue = new();
        this.cbxLightColourPreview = new();
        this.knumMiddleColourIntensityValue = new();
        this.cbxMediumColourPreview = new();
        this.knumLightColourIntensityValue = new();
        this.cbxDarkColourPreview = new();
        this.knumLightestColourIntensityValue = new();
        this.kryptonLabel5 = new();
        this.klblLightestColourIntensityValueOutput = new();
        this.kryptonLabel6 = new();
        this.klblLightColourIntensityValueOutput = new();
        this.kryptonLabel7 = new();
        this.klblMiddleColourIntensityValueOutput = new();
        this.kryptonLabel8 = new();
        this.klblDarkColourIntensityValueOutput = new();
        this.kbtnDarkColourIntensityValueMinus = new();
        this.kbtnLightestColourIntensityValuePlus = new();
        this.kbnDarkestColourIntensityValuePlus = new();
        this.kbtnLightestColourIntensityValueMinus = new();
        this.kbtnMiddleColourIntensityValueMinus = new();
        this.kbtLightColourIntensityValuePlus = new();
        this.kbtnMiddleColourIntensityValuePlus = new();
        this.kbtnLightColourIntensityValueMinus = new();
        this.kryptonPage4 = new();
        this.kchkConvertToRGBValue = new();
        this.kcbConvertToHexadecimalValue = new();
        this.kchkGenerateAlphaValue = new();
        this.cbxCircular = new();
        this.pbxStandard = new();
        this.kcmbDisplayType = new();
        this.kryptonLabel9 = new();
        this.kchkAutomaticallyUpdateValues = new();
        this.kryptonPage5 = new();
        this.kmtxtFilePath = new();
        this.bsaReset = new();
        this.bsaBrowse = new();
        this.kryptonLabel10 = new();
        this.kpTheme = new();
        this.ktcmbTheme = new();
        this.kbtnLoadTheme = new();
        this.ktxtCustomPath = new();
        this.buttonSpecAny1 = new();
        this.buttonSpecAny2 = new();
        this.klblCustomTheme = new();
        this.kryptonLabel11 = new();
        this.kpSettings = new();
        this.kchkAskForConfirmation = new();
        this.kbtnResetPaletteTypefaceSettings = new();
        this.kbtnResetGlobalStringSettings = new();
        this.kbtnResetGlobalBooleanSettings = new();
        this.kbtnResetColourStringSettings = new();
        this.kbtnResetColourSettings = new();
        this.kbtnResetColourIntegerSettings = new();
        this.kbtnResetColourBlendingSettings = new();
        this.kbtnNukeAllSettings = new();
        ((System.ComponentModel.ISupportInitialize)this.kryptonPanel1).BeginInit();
        this.kryptonPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.kryptonPanel2).BeginInit();
        this.kryptonPanel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.kryptonNavigator1).BeginInit();
        this.kryptonNavigator1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.kryptonPage1).BeginInit();
        this.kryptonPage1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.kryptonDockableNavigator1).BeginInit();
        this.kryptonDockableNavigator1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.kryptonPage3).BeginInit();
        this.kryptonPage3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.cbxLightestColourPreview).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.cbxLightColourPreview).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.cbxMediumColourPreview).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.cbxDarkColourPreview).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.kryptonPage4).BeginInit();
        this.kryptonPage4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.cbxCircular).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.pbxStandard).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.kcmbDisplayType).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.kryptonPage5).BeginInit();
        this.kryptonPage5.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.kpTheme).BeginInit();
        this.kpTheme.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.ktcmbTheme).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.kpSettings).BeginInit();
        this.kpSettings.SuspendLayout();
        this.SuspendLayout();
        // 
        // kryptonPanel1
        // 
        this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
        this.kryptonPanel1.Controls.Add(this.kbtnResetThemeValues);
        this.kryptonPanel1.Controls.Add(this.kbtnResetColourBlendingValues);
        this.kryptonPanel1.Controls.Add(this.kbtnOk);
        this.kryptonPanel1.Controls.Add(this.kbtnCancel);
        this.kryptonPanel1.Controls.Add(this.kbtnUACApply);
        this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.kryptonPanel1.Location = new(0, 537);
        this.kryptonPanel1.Name = "kryptonPanel1";
        this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
        this.kryptonPanel1.Size = new(690, 52);
        this.kryptonPanel1.TabIndex = 0;
        // 
        // kryptonBorderEdge1
        // 
        this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
        this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
        this.kryptonBorderEdge1.Location = new(0, 0);
        this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
        this.kryptonBorderEdge1.Size = new(690, 1);
        this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
        // 
        // kbtnResetThemeValues
        // 
        this.kbtnResetThemeValues.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.kbtnResetThemeValues.Enabled = false;
        this.kbtnResetThemeValues.Location = new(12, 15);
        this.kbtnResetThemeValues.Name = "kbtnResetThemeValues";
        this.kbtnResetThemeValues.Size = new(90, 25);
        this.kbtnResetThemeValues.TabIndex = 63;
        this.kbtnResetThemeValues.Values.Text = "Re&set Values";
        // 
        // kbtnResetColourBlendingValues
        // 
        this.kbtnResetColourBlendingValues.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
        this.kbtnResetColourBlendingValues.Enabled = false;
        this.kbtnResetColourBlendingValues.Location = new(12, 15);
        this.kbtnResetColourBlendingValues.Name = "kbtnResetColourBlendingValues";
        this.kbtnResetColourBlendingValues.Size = new(90, 25);
        this.kbtnResetColourBlendingValues.TabIndex = 62;
        this.kbtnResetColourBlendingValues.Values.Text = "Re&set Values";
        // 
        // kbtnOk
        // 
        this.kbtnOk.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        this.kbtnOk.Location = new(396, 15);
        this.kbtnOk.Name = "kbtnOk";
        this.kbtnOk.Size = new(90, 25);
        this.kbtnOk.TabIndex = 4;
        this.kbtnOk.Values.Text = "&Ok";
        // 
        // kbtnCancel
        // 
        this.kbtnCancel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        this.kbtnCancel.Location = new(492, 15);
        this.kbtnCancel.Name = "kbtnCancel";
        this.kbtnCancel.Size = new(90, 25);
        this.kbtnCancel.TabIndex = 5;
        this.kbtnCancel.Values.Text = "Ca&ncel";
        // 
        // kbtnUACApply
        // 
        this.kbtnUACApply.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        this.kbtnUACApply.Enabled = false;
        this.kbtnUACApply.Location = new(588, 15);
        this.kbtnUACApply.Name = "kbtnUACApply";
        this.kbtnUACApply.ProcessToElevate = null;
        this.kbtnUACApply.ShowUACShield = true;
        this.kbtnUACApply.Size = new(90, 25);
        this.kbtnUACApply.TabIndex = 0;
        this.kbtnUACApply.Values.Text = "&Apply";
        // 
        // kryptonPanel2
        // 
        this.kryptonPanel2.Controls.Add(this.kryptonNavigator1);
        this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.kryptonPanel2.Location = new(0, 0);
        this.kryptonPanel2.Name = "kryptonPanel2";
        this.kryptonPanel2.Size = new(690, 537);
        this.kryptonPanel2.TabIndex = 2;
        // 
        // kryptonNavigator1
        // 
        this.kryptonNavigator1.Button.ButtonDisplayLogic = Krypton.Navigator.ButtonDisplayLogic.NextPrevious;
        this.kryptonNavigator1.Button.CloseButtonAction = Krypton.Navigator.CloseButtonAction.RemovePageAndDispose;
        this.kryptonNavigator1.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
        this.kryptonNavigator1.Button.ContextButtonAction = Krypton.Navigator.ContextButtonAction.SelectPage;
        this.kryptonNavigator1.Button.ContextButtonDisplay = Krypton.Navigator.ButtonDisplay.Logic;
        this.kryptonNavigator1.Button.ContextMenuMapImage = Krypton.Navigator.MapKryptonPageImage.Small;
        this.kryptonNavigator1.Button.ContextMenuMapText = Krypton.Navigator.MapKryptonPageText.TextTitle;
        this.kryptonNavigator1.Button.NextButtonAction = Krypton.Navigator.DirectionButtonAction.ModeAppropriateAction;
        this.kryptonNavigator1.Button.NextButtonDisplay = Krypton.Navigator.ButtonDisplay.Logic;
        this.kryptonNavigator1.Button.PreviousButtonAction = Krypton.Navigator.DirectionButtonAction.ModeAppropriateAction;
        this.kryptonNavigator1.Button.PreviousButtonDisplay = Krypton.Navigator.ButtonDisplay.Logic;
        this.kryptonNavigator1.Location = new(12, 12);
        this.kryptonNavigator1.Name = "kryptonNavigator1";
        this.kryptonNavigator1.NavigatorMode = Krypton.Navigator.NavigatorMode.BarCheckButtonGroupOutside;
        this.kryptonNavigator1.PageBackStyle = Krypton.Toolkit.PaletteBackStyle.ControlClient;
        this.kryptonNavigator1.Pages.AddRange([
            this.kryptonPage1,
            this.kpTheme,
            this.kpSettings
        ]);
        this.kryptonNavigator1.SelectedIndex = 0;
        this.kryptonNavigator1.Size = new(663, 511);
        this.kryptonNavigator1.TabIndex = 0;
        this.kryptonNavigator1.Text = "kryptonNavigator1";
        // 
        // kryptonPage1
        // 
        this.kryptonPage1.AutoHiddenSlideSize = new(200, 200);
        this.kryptonPage1.Controls.Add(this.kryptonDockableNavigator1);
        this.kryptonPage1.Flags = 65534;
        this.kryptonPage1.LastVisibleSet = true;
        this.kryptonPage1.MinimumSize = new(50, 50);
        this.kryptonPage1.Name = "kryptonPage1";
        this.kryptonPage1.Size = new(661, 482);
        this.kryptonPage1.Text = "C&olour Blending";
        this.kryptonPage1.ToolTipTitle = "Page ToolTip";
        this.kryptonPage1.UniqueName = "5B92D5986C334B5ADFAF98FE8EEA16E1";
        // 
        // kryptonDockableNavigator1
        // 
        this.kryptonDockableNavigator1.Button.ButtonDisplayLogic = Krypton.Navigator.ButtonDisplayLogic.NextPrevious;
        this.kryptonDockableNavigator1.Button.CloseButtonAction = Krypton.Navigator.CloseButtonAction.None;
        this.kryptonDockableNavigator1.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
        this.kryptonDockableNavigator1.Button.ContextButtonAction = Krypton.Navigator.ContextButtonAction.SelectPage;
        this.kryptonDockableNavigator1.Button.ContextButtonDisplay = Krypton.Navigator.ButtonDisplay.Logic;
        this.kryptonDockableNavigator1.Button.ContextMenuMapImage = Krypton.Navigator.MapKryptonPageImage.Small;
        this.kryptonDockableNavigator1.Button.ContextMenuMapText = Krypton.Navigator.MapKryptonPageText.TextTitle;
        this.kryptonDockableNavigator1.Button.NextButtonAction = Krypton.Navigator.DirectionButtonAction.ModeAppropriateAction;
        this.kryptonDockableNavigator1.Button.NextButtonDisplay = Krypton.Navigator.ButtonDisplay.Logic;
        this.kryptonDockableNavigator1.Button.PreviousButtonAction = Krypton.Navigator.DirectionButtonAction.ModeAppropriateAction;
        this.kryptonDockableNavigator1.Button.PreviousButtonDisplay = Krypton.Navigator.ButtonDisplay.Logic;
        this.kryptonDockableNavigator1.Location = new(15, 19);
        this.kryptonDockableNavigator1.Name = "kryptonDockableNavigator1";
        this.kryptonDockableNavigator1.NavigatorMode = Krypton.Navigator.NavigatorMode.BarCheckButtonGroupOutside;
        this.kryptonDockableNavigator1.PageBackStyle = Krypton.Toolkit.PaletteBackStyle.ControlClient;
        this.kryptonDockableNavigator1.Pages.AddRange([
            this.kryptonPage3,
            this.kryptonPage4,
            this.kryptonPage5
        ]);
        this.kryptonDockableNavigator1.SelectedIndex = 2;
        this.kryptonDockableNavigator1.Size = new(627, 450);
        this.kryptonDockableNavigator1.TabIndex = 36;
        this.kryptonDockableNavigator1.Text = "kryptonDockableNavigator1";
        // 
        // kryptonPage3
        // 
        this.kryptonPage3.AutoHiddenSlideSize = new(200, 200);
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
        this.kryptonPage3.MinimumSize = new(50, 50);
        this.kryptonPage3.Name = "kryptonPage3";
        this.kryptonPage3.Size = new(625, 421);
        this.kryptonPage3.Text = "Colour Intensity";
        this.kryptonPage3.ToolTipTitle = "Page ToolTip";
        this.kryptonPage3.UniqueName = "CA84FA1D35D047D920A054A4CAC807D7";
        // 
        // kryptonLabel1
        // 
        this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
        this.kryptonLabel1.Location = new(17, 27);
        this.kryptonLabel1.Name = "kryptonLabel1";
        this.kryptonLabel1.Size = new(155, 20);
        this.kryptonLabel1.TabIndex = 33;
        this.kryptonLabel1.Values.Text = "Darkest Colour Intensity:";
        // 
        // kryptonLabel2
        // 
        this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
        this.kryptonLabel2.Location = new(17, 122);
        this.kryptonLabel2.Name = "kryptonLabel2";
        this.kryptonLabel2.Size = new(151, 20);
        this.kryptonLabel2.TabIndex = 34;
        this.kryptonLabel2.Values.Text = "Middle Colour Intensity:";
        // 
        // kryptonLabel3
        // 
        this.kryptonLabel3.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
        this.kryptonLabel3.Location = new(17, 217);
        this.kryptonLabel3.Name = "kryptonLabel3";
        this.kryptonLabel3.Size = new(140, 20);
        this.kryptonLabel3.TabIndex = 35;
        this.kryptonLabel3.Values.Text = "Light Colour Intensity:";
        // 
        // kcbBaseColour
        // 
        this.kcbBaseColour.CustomColorPreviewShape = Krypton.Toolkit.KryptonColorButtonCustomColorPreviewShape.Circle;
        this.kcbBaseColour.Location = new(17, 383);
        this.kcbBaseColour.Name = "kcbBaseColour";
        this.kcbBaseColour.Size = new(179, 25);
        this.kcbBaseColour.TabIndex = 61;
        this.kcbBaseColour.Values.Image = (System.Drawing.Image)resources.GetObject("kcbBaseColour.Values.Image");
        this.kcbBaseColour.Values.RoundedCorners = 8;
        this.kcbBaseColour.Values.Text = "&Choose a Base Colour";
        // 
        // kryptonLabel4
        // 
        this.kryptonLabel4.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
        this.kryptonLabel4.Location = new(17, 312);
        this.kryptonLabel4.Name = "kryptonLabel4";
        this.kryptonLabel4.Size = new(157, 20);
        this.kryptonLabel4.TabIndex = 36;
        this.kryptonLabel4.Values.Text = "Lightest Colour Intensity:";
        // 
        // cbxLightestColourPreview
        // 
        this.cbxLightestColourPreview.BackColor = System.Drawing.Color.Black;
        this.cbxLightestColourPreview.Location = new(448, 310);
        this.cbxLightestColourPreview.Name = "cbxLightestColourPreview";
        this.cbxLightestColourPreview.Size = new(32, 32);
        this.cbxLightestColourPreview.TabIndex = 60;
        this.cbxLightestColourPreview.TabStop = false;
        this.cbxLightestColourPreview.ToolTipValues = null;
        // 
        // knumDarkColourIntensityValue
        // 
        this.knumDarkColourIntensityValue.AllowDecimals = true;
        this.knumDarkColourIntensityValue.DecimalPlaces = 2;
        this.knumDarkColourIntensityValue.Location = new(178, 24);
        this.knumDarkColourIntensityValue.Name = "knumDarkColourIntensityValue";
        this.knumDarkColourIntensityValue.Size = new(82, 22);
        this.knumDarkColourIntensityValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
        this.knumDarkColourIntensityValue.TabIndex = 37;
        // 
        // cbxLightColourPreview
        // 
        this.cbxLightColourPreview.BackColor = System.Drawing.Color.Black;
        this.cbxLightColourPreview.Location = new(448, 217);
        this.cbxLightColourPreview.Name = "cbxLightColourPreview";
        this.cbxLightColourPreview.Size = new(32, 32);
        this.cbxLightColourPreview.TabIndex = 59;
        this.cbxLightColourPreview.TabStop = false;
        this.cbxLightColourPreview.ToolTipValues = null;
        // 
        // knumMiddleColourIntensityValue
        // 
        this.knumMiddleColourIntensityValue.AllowDecimals = true;
        this.knumMiddleColourIntensityValue.DecimalPlaces = 2;
        this.knumMiddleColourIntensityValue.Location = new(178, 122);
        this.knumMiddleColourIntensityValue.Name = "knumMiddleColourIntensityValue";
        this.knumMiddleColourIntensityValue.Size = new(82, 22);
        this.knumMiddleColourIntensityValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
        this.knumMiddleColourIntensityValue.TabIndex = 38;
        // 
        // cbxMediumColourPreview
        // 
        this.cbxMediumColourPreview.BackColor = System.Drawing.Color.Black;
        this.cbxMediumColourPreview.Location = new(448, 122);
        this.cbxMediumColourPreview.Name = "cbxMediumColourPreview";
        this.cbxMediumColourPreview.Size = new(32, 32);
        this.cbxMediumColourPreview.TabIndex = 58;
        this.cbxMediumColourPreview.TabStop = false;
        this.cbxMediumColourPreview.ToolTipValues = null;
        // 
        // knumLightColourIntensityValue
        // 
        this.knumLightColourIntensityValue.AllowDecimals = true;
        this.knumLightColourIntensityValue.DecimalPlaces = 2;
        this.knumLightColourIntensityValue.Location = new(178, 217);
        this.knumLightColourIntensityValue.Name = "knumLightColourIntensityValue";
        this.knumLightColourIntensityValue.Size = new(82, 22);
        this.knumLightColourIntensityValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
        this.knumLightColourIntensityValue.TabIndex = 39;
        // 
        // cbxDarkColourPreview
        // 
        this.cbxDarkColourPreview.BackColor = System.Drawing.Color.Black;
        this.cbxDarkColourPreview.Location = new(448, 24);
        this.cbxDarkColourPreview.Name = "cbxDarkColourPreview";
        this.cbxDarkColourPreview.Size = new(32, 32);
        this.cbxDarkColourPreview.TabIndex = 57;
        this.cbxDarkColourPreview.TabStop = false;
        this.cbxDarkColourPreview.ToolTipValues = null;
        // 
        // knumLightestColourIntensityValue
        // 
        this.knumLightestColourIntensityValue.AllowDecimals = true;
        this.knumLightestColourIntensityValue.DecimalPlaces = 2;
        this.knumLightestColourIntensityValue.Location = new(178, 312);
        this.knumLightestColourIntensityValue.Name = "knumLightestColourIntensityValue";
        this.knumLightestColourIntensityValue.Size = new(82, 22);
        this.knumLightestColourIntensityValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
        this.knumLightestColourIntensityValue.TabIndex = 40;
        // 
        // kryptonLabel5
        // 
        this.kryptonLabel5.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
        this.kryptonLabel5.Location = new(266, 27);
        this.kryptonLabel5.Name = "kryptonLabel5";
        this.kryptonLabel5.Size = new(21, 20);
        this.kryptonLabel5.TabIndex = 41;
        this.kryptonLabel5.Values.Text = "%";
        // 
        // klblLightestColourIntensityValueOutput
        // 
        this.klblLightestColourIntensityValueOutput.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
        this.klblLightestColourIntensityValueOutput.Location = new(367, 312);
        this.klblLightestColourIntensityValueOutput.Name = "klblLightestColourIntensityValueOutput";
        this.klblLightestColourIntensityValueOutput.Size = new(75, 20);
        this.klblLightestColourIntensityValueOutput.TabIndex = 56;
        this.klblLightestColourIntensityValueOutput.Values.Text = "Output: {0}";
        // 
        // kryptonLabel6
        // 
        this.kryptonLabel6.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
        this.kryptonLabel6.Location = new(266, 122);
        this.kryptonLabel6.Name = "kryptonLabel6";
        this.kryptonLabel6.Size = new(21, 20);
        this.kryptonLabel6.TabIndex = 42;
        this.kryptonLabel6.Values.Text = "%";
        // 
        // klblLightColourIntensityValueOutput
        // 
        this.klblLightColourIntensityValueOutput.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
        this.klblLightColourIntensityValueOutput.Location = new(367, 217);
        this.klblLightColourIntensityValueOutput.Name = "klblLightColourIntensityValueOutput";
        this.klblLightColourIntensityValueOutput.Size = new(75, 20);
        this.klblLightColourIntensityValueOutput.TabIndex = 55;
        this.klblLightColourIntensityValueOutput.Values.Text = "Output: {0}";
        // 
        // kryptonLabel7
        // 
        this.kryptonLabel7.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
        this.kryptonLabel7.Location = new(266, 217);
        this.kryptonLabel7.Name = "kryptonLabel7";
        this.kryptonLabel7.Size = new(21, 20);
        this.kryptonLabel7.TabIndex = 43;
        this.kryptonLabel7.Values.Text = "%";
        // 
        // klblMiddleColourIntensityValueOutput
        // 
        this.klblMiddleColourIntensityValueOutput.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
        this.klblMiddleColourIntensityValueOutput.Location = new(367, 122);
        this.klblMiddleColourIntensityValueOutput.Name = "klblMiddleColourIntensityValueOutput";
        this.klblMiddleColourIntensityValueOutput.Size = new(75, 20);
        this.klblMiddleColourIntensityValueOutput.TabIndex = 54;
        this.klblMiddleColourIntensityValueOutput.Values.Text = "Output: {0}";
        // 
        // kryptonLabel8
        // 
        this.kryptonLabel8.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
        this.kryptonLabel8.Location = new(266, 312);
        this.kryptonLabel8.Name = "kryptonLabel8";
        this.kryptonLabel8.Size = new(21, 20);
        this.kryptonLabel8.TabIndex = 44;
        this.kryptonLabel8.Values.Text = "%";
        // 
        // klblDarkColourIntensityValueOutput
        // 
        this.klblDarkColourIntensityValueOutput.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
        this.klblDarkColourIntensityValueOutput.Location = new(367, 27);
        this.klblDarkColourIntensityValueOutput.Name = "klblDarkColourIntensityValueOutput";
        this.klblDarkColourIntensityValueOutput.Size = new(75, 20);
        this.klblDarkColourIntensityValueOutput.TabIndex = 53;
        this.klblDarkColourIntensityValueOutput.Values.Text = "Output: {0}";
        // 
        // kbtnDarkColourIntensityValueMinus
        // 
        this.kbtnDarkColourIntensityValueMinus.Location = new(293, 20);
        this.kbtnDarkColourIntensityValueMinus.Name = "kbtnDarkColourIntensityValueMinus";
        this.kbtnDarkColourIntensityValueMinus.Size = new(18, 30);
        this.kbtnDarkColourIntensityValueMinus.StateCommon.Content.ShortText.Font = new("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        this.kbtnDarkColourIntensityValueMinus.TabIndex = 45;
        this.kbtnDarkColourIntensityValueMinus.Values.Text = "-";
        // 
        // kbtnLightestColourIntensityValuePlus
        // 
        this.kbtnLightestColourIntensityValuePlus.Location = new(329, 312);
        this.kbtnLightestColourIntensityValuePlus.Name = "kbtnLightestColourIntensityValuePlus";
        this.kbtnLightestColourIntensityValuePlus.Size = new(23, 30);
        this.kbtnLightestColourIntensityValuePlus.StateCommon.Content.ShortText.Font = new("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        this.kbtnLightestColourIntensityValuePlus.TabIndex = 52;
        this.kbtnLightestColourIntensityValuePlus.Values.Text = "+";
        // 
        // kbnDarkestColourIntensityValuePlus
        // 
        this.kbnDarkestColourIntensityValuePlus.Location = new(329, 20);
        this.kbnDarkestColourIntensityValuePlus.Name = "kbnDarkestColourIntensityValuePlus";
        this.kbnDarkestColourIntensityValuePlus.Size = new(23, 30);
        this.kbnDarkestColourIntensityValuePlus.StateCommon.Content.ShortText.Font = new("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        this.kbnDarkestColourIntensityValuePlus.TabIndex = 46;
        this.kbnDarkestColourIntensityValuePlus.Values.Text = "+";
        // 
        // kbtnLightestColourIntensityValueMinus
        // 
        this.kbtnLightestColourIntensityValueMinus.Location = new(293, 312);
        this.kbtnLightestColourIntensityValueMinus.Name = "kbtnLightestColourIntensityValueMinus";
        this.kbtnLightestColourIntensityValueMinus.Size = new(18, 30);
        this.kbtnLightestColourIntensityValueMinus.StateCommon.Content.ShortText.Font = new("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        this.kbtnLightestColourIntensityValueMinus.TabIndex = 51;
        this.kbtnLightestColourIntensityValueMinus.Values.Text = "-";
        // 
        // kbtnMiddleColourIntensityValueMinus
        // 
        this.kbtnMiddleColourIntensityValueMinus.Location = new(293, 122);
        this.kbtnMiddleColourIntensityValueMinus.Name = "kbtnMiddleColourIntensityValueMinus";
        this.kbtnMiddleColourIntensityValueMinus.Size = new(18, 30);
        this.kbtnMiddleColourIntensityValueMinus.StateCommon.Content.ShortText.Font = new("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        this.kbtnMiddleColourIntensityValueMinus.TabIndex = 47;
        this.kbtnMiddleColourIntensityValueMinus.Values.Text = "-";
        // 
        // kbtLightColourIntensityValuePlus
        // 
        this.kbtLightColourIntensityValuePlus.Location = new(329, 217);
        this.kbtLightColourIntensityValuePlus.Name = "kbtLightColourIntensityValuePlus";
        this.kbtLightColourIntensityValuePlus.Size = new(23, 30);
        this.kbtLightColourIntensityValuePlus.StateCommon.Content.ShortText.Font = new("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        this.kbtLightColourIntensityValuePlus.TabIndex = 50;
        this.kbtLightColourIntensityValuePlus.Values.Text = "+";
        // 
        // kbtnMiddleColourIntensityValuePlus
        // 
        this.kbtnMiddleColourIntensityValuePlus.Location = new(329, 122);
        this.kbtnMiddleColourIntensityValuePlus.Name = "kbtnMiddleColourIntensityValuePlus";
        this.kbtnMiddleColourIntensityValuePlus.Size = new(23, 30);
        this.kbtnMiddleColourIntensityValuePlus.StateCommon.Content.ShortText.Font = new("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        this.kbtnMiddleColourIntensityValuePlus.TabIndex = 48;
        this.kbtnMiddleColourIntensityValuePlus.Values.Text = "+";
        // 
        // kbtnLightColourIntensityValueMinus
        // 
        this.kbtnLightColourIntensityValueMinus.Location = new(293, 217);
        this.kbtnLightColourIntensityValueMinus.Name = "kbtnLightColourIntensityValueMinus";
        this.kbtnLightColourIntensityValueMinus.Size = new(18, 30);
        this.kbtnLightColourIntensityValueMinus.StateCommon.Content.ShortText.Font = new("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
        this.kbtnLightColourIntensityValueMinus.TabIndex = 49;
        this.kbtnLightColourIntensityValueMinus.Values.Text = "-";
        // 
        // kryptonPage4
        // 
        this.kryptonPage4.AutoHiddenSlideSize = new(200, 200);
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
        this.kryptonPage4.MinimumSize = new(50, 50);
        this.kryptonPage4.Name = "kryptonPage4";
        this.kryptonPage4.Size = new(625, 421);
        this.kryptonPage4.Text = "UI Options";
        this.kryptonPage4.ToolTipTitle = "Page ToolTip";
        this.kryptonPage4.UniqueName = "FA50690FF4D649BA9E9ED453E8E571B5";
        // 
        // kchkConvertToRGBValue
        // 
        this.kchkConvertToRGBValue.Location = new(39, 257);
        this.kchkConvertToRGBValue.Name = "kchkConvertToRGBValue";
        this.kchkConvertToRGBValue.Size = new(219, 20);
        this.kchkConvertToRGBValue.TabIndex = 50;
        this.kchkConvertToRGBValue.Values.Text = "Automatically Convert to &RGB Value";
        // 
        // kcbConvertToHexadecimalValue
        // 
        this.kcbConvertToHexadecimalValue.Location = new(39, 204);
        this.kcbConvertToHexadecimalValue.Name = "kcbConvertToHexadecimalValue";
        this.kcbConvertToHexadecimalValue.Size = new(266, 20);
        this.kcbConvertToHexadecimalValue.TabIndex = 49;
        this.kcbConvertToHexadecimalValue.Values.Text = "Automatically Convert to &Hexadecimal Value";
        // 
        // kchkGenerateAlphaValue
        // 
        this.kchkGenerateAlphaValue.Location = new(39, 151);
        this.kchkGenerateAlphaValue.Name = "kchkGenerateAlphaValue";
        this.kchkGenerateAlphaValue.Size = new(159, 20);
        this.kchkGenerateAlphaValue.TabIndex = 48;
        this.kchkGenerateAlphaValue.Values.Text = "&Generate an Alpha Value";
        // 
        // cbxCircular
        // 
        this.cbxCircular.BackColor = System.Drawing.Color.Black;
        this.cbxCircular.Location = new(320, 87);
        this.cbxCircular.Name = "cbxCircular";
        this.cbxCircular.Size = new(32, 32);
        this.cbxCircular.TabIndex = 47;
        this.cbxCircular.TabStop = false;
        this.cbxCircular.ToolTipValues = null;
        // 
        // pbxStandard
        // 
        this.pbxStandard.BackColor = System.Drawing.Color.Black;
        this.pbxStandard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.pbxStandard.Location = new(320, 87);
        this.pbxStandard.Name = "pbxStandard";
        this.pbxStandard.Size = new(32, 32);
        this.pbxStandard.TabIndex = 46;
        this.pbxStandard.TabStop = false;
        // 
        // kcmbDisplayType
        // 
        this.kcmbDisplayType.DropDownWidth = 203;
        this.kcmbDisplayType.IntegralHeight = false;
        this.kcmbDisplayType.Items.AddRange([
            "Standard",
            "Circular"
        ]);
        this.kcmbDisplayType.Location = new(111, 87);
        this.kcmbDisplayType.Name = "kcmbDisplayType";
        this.kcmbDisplayType.Size = new(203, 21);
        this.kcmbDisplayType.TabIndex = 45;
        // 
        // kryptonLabel9
        // 
        this.kryptonLabel9.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
        this.kryptonLabel9.Location = new(17, 87);
        this.kryptonLabel9.Name = "kryptonLabel9";
        this.kryptonLabel9.Size = new(88, 20);
        this.kryptonLabel9.TabIndex = 44;
        this.kryptonLabel9.Values.Text = "Display Type:";
        // 
        // kchkAutomaticallyUpdateValues
        // 
        this.kchkAutomaticallyUpdateValues.Location = new(17, 24);
        this.kchkAutomaticallyUpdateValues.Name = "kchkAutomaticallyUpdateValues";
        this.kchkAutomaticallyUpdateValues.Size = new(180, 20);
        this.kchkAutomaticallyUpdateValues.TabIndex = 43;
        this.kchkAutomaticallyUpdateValues.Values.Text = "&Automatically Update Values";
        // 
        // kryptonPage5
        // 
        this.kryptonPage5.AutoHiddenSlideSize = new(200, 200);
        this.kryptonPage5.Controls.Add(this.kmtxtFilePath);
        this.kryptonPage5.Controls.Add(this.kryptonLabel10);
        this.kryptonPage5.Flags = 65534;
        this.kryptonPage5.LastVisibleSet = true;
        this.kryptonPage5.MinimumSize = new(50, 50);
        this.kryptonPage5.Name = "kryptonPage5";
        this.kryptonPage5.Size = new(625, 421);
        this.kryptonPage5.Text = "File Options";
        this.kryptonPage5.ToolTipTitle = "Page ToolTip";
        this.kryptonPage5.UniqueName = "4FF76322826141100EA9C00D97F3A7A2";
        // 
        // kmtxtFilePath
        // 
        this.kmtxtFilePath.ButtonSpecs.AddRange([
            this.bsaReset,
            this.bsaBrowse
        ]);
        this.kmtxtFilePath.Location = new(139, 24);
        this.kmtxtFilePath.Name = "kmtxtFilePath";
        this.kmtxtFilePath.Size = new(366, 26);
        this.kmtxtFilePath.TabIndex = 63;
        // 
        // bsaReset
        // 
        this.bsaReset.Image = (System.Drawing.Image)resources.GetObject("bsaReset.Image");
        this.bsaReset.UniqueName = "e5d4e65c1b2f460a80f02567f0a10106";
        // 
        // bsaBrowse
        // 
        this.bsaBrowse.Text = "...";
        this.bsaBrowse.UniqueName = "46b7621accf547c4a510c9694fcf3207";
        // 
        // kryptonLabel10
        // 
        this.kryptonLabel10.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
        this.kryptonLabel10.Location = new(17, 24);
        this.kryptonLabel10.Name = "kryptonLabel10";
        this.kryptonLabel10.Size = new(116, 20);
        this.kryptonLabel10.TabIndex = 62;
        this.kryptonLabel10.Values.Text = "Export Colours to:";
        // 
        // kpTheme
        // 
        this.kpTheme.AutoHiddenSlideSize = new(200, 200);
        this.kpTheme.Controls.Add(this.ktcmbTheme);
        this.kpTheme.Controls.Add(this.kbtnLoadTheme);
        this.kpTheme.Controls.Add(this.ktxtCustomPath);
        this.kpTheme.Controls.Add(this.klblCustomTheme);
        this.kpTheme.Controls.Add(this.kryptonLabel11);
        this.kpTheme.Flags = 65534;
        this.kpTheme.LastVisibleSet = true;
        this.kpTheme.MinimumSize = new(50, 50);
        this.kpTheme.Name = "kpTheme";
        this.kpTheme.Size = new(661, 482);
        this.kpTheme.Text = "&Theme";
        this.kpTheme.ToolTipTitle = "Page ToolTip";
        this.kpTheme.UniqueName = "DACF4417245246D33A84C27025B0D112";
        // 
        // ktcmbTheme
        // 
        this.ktcmbTheme.DropDownWidth = 198;
        this.ktcmbTheme.IntegralHeight = false;
        this.ktcmbTheme.Location = new(118, 22);
        this.ktcmbTheme.Name = "ktcmbTheme";
        this.ktcmbTheme.Size = new(198, 21);
        this.ktcmbTheme.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
        this.ktcmbTheme.TabIndex = 9;
        // 
        // kbtnLoadTheme
        // 
        this.kbtnLoadTheme.Enabled = false;
        this.kbtnLoadTheme.Location = new(554, 97);
        this.kbtnLoadTheme.Name = "kbtnLoadTheme";
        this.kbtnLoadTheme.Size = new(90, 25);
        this.kbtnLoadTheme.TabIndex = 8;
        this.kbtnLoadTheme.Values.Text = "&Load";
        // 
        // ktxtCustomPath
        // 
        this.ktxtCustomPath.ButtonSpecs.AddRange([
            this.buttonSpecAny1,
            this.buttonSpecAny2
        ]);
        this.ktxtCustomPath.Enabled = false;
        this.ktxtCustomPath.Location = new(219, 65);
        this.ktxtCustomPath.Name = "ktxtCustomPath";
        this.ktxtCustomPath.Size = new(425, 26);
        this.ktxtCustomPath.TabIndex = 7;
        // 
        // buttonSpecAny1
        // 
        this.buttonSpecAny1.Image = (System.Drawing.Image)resources.GetObject("buttonSpecAny1.Image");
        this.buttonSpecAny1.UniqueName = "1f0247d059a64ff792fa7879355b8bf1";
        // 
        // buttonSpecAny2
        // 
        this.buttonSpecAny2.Enabled = Krypton.Toolkit.ButtonEnabled.False;
        this.buttonSpecAny2.Text = "...";
        this.buttonSpecAny2.UniqueName = "71736a3a0e124395bcca501caca11870";
        // 
        // klblCustomTheme
        // 
        this.klblCustomTheme.Enabled = false;
        this.klblCustomTheme.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
        this.klblCustomTheme.Location = new(41, 65);
        this.klblCustomTheme.Name = "klblCustomTheme";
        this.klblCustomTheme.Size = new(154, 20);
        this.klblCustomTheme.TabIndex = 6;
        this.klblCustomTheme.Values.Text = "Custom Theme File Path:";
        // 
        // kryptonLabel11
        // 
        this.kryptonLabel11.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
        this.kryptonLabel11.Location = new(15, 22);
        this.kryptonLabel11.Name = "kryptonLabel11";
        this.kryptonLabel11.Size = new(97, 20);
        this.kryptonLabel11.TabIndex = 4;
        this.kryptonLabel11.Values.Text = "Palette Theme:";
        // 
        // kpSettings
        // 
        this.kpSettings.AutoHiddenSlideSize = new(200, 200);
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
        this.kpSettings.MinimumSize = new(50, 50);
        this.kpSettings.Name = "kpSettings";
        this.kpSettings.Size = new(661, 482);
        this.kpSettings.Text = "Se&ttings";
        this.kpSettings.ToolTipTitle = "Page ToolTip";
        this.kpSettings.UniqueName = "D086C4F6C5234FC02DA044DBB946AE2F";
        // 
        // kchkAskForConfirmation
        // 
        this.kchkAskForConfirmation.Location = new(469, 440);
        this.kchkAskForConfirmation.Name = "kchkAskForConfirmation";
        this.kchkAskForConfirmation.Size = new(136, 20);
        this.kchkAskForConfirmation.TabIndex = 80;
        this.kchkAskForConfirmation.Values.Text = "&Ask for Confirmation";
        // 
        // kbtnResetPaletteTypefaceSettings
        // 
        this.kbtnResetPaletteTypefaceSettings.Location = new(18, 370);
        this.kbtnResetPaletteTypefaceSettings.Name = "kbtnResetPaletteTypefaceSettings";
        this.kbtnResetPaletteTypefaceSettings.Size = new(256, 25);
        this.kbtnResetPaletteTypefaceSettings.TabIndex = 79;
        this.kbtnResetPaletteTypefaceSettings.Values.Text = "Reset &Palette Typeface Settings";
        // 
        // kbtnResetGlobalStringSettings
        // 
        this.kbtnResetGlobalStringSettings.Location = new(18, 312);
        this.kbtnResetGlobalStringSettings.Name = "kbtnResetGlobalStringSettings";
        this.kbtnResetGlobalStringSettings.Size = new(256, 25);
        this.kbtnResetGlobalStringSettings.TabIndex = 78;
        this.kbtnResetGlobalStringSettings.Values.Text = "Reset &Global String Settings";
        // 
        // kbtnResetGlobalBooleanSettings
        // 
        this.kbtnResetGlobalBooleanSettings.Location = new(18, 254);
        this.kbtnResetGlobalBooleanSettings.Name = "kbtnResetGlobalBooleanSettings";
        this.kbtnResetGlobalBooleanSettings.Size = new(256, 25);
        this.kbtnResetGlobalBooleanSettings.TabIndex = 77;
        this.kbtnResetGlobalBooleanSettings.Values.Text = "Reset Global B&oolean Settings";
        // 
        // kbtnResetColourStringSettings
        // 
        this.kbtnResetColourStringSettings.Location = new(18, 196);
        this.kbtnResetColourStringSettings.Name = "kbtnResetColourStringSettings";
        this.kbtnResetColourStringSettings.Size = new(256, 25);
        this.kbtnResetColourStringSettings.TabIndex = 76;
        this.kbtnResetColourStringSettings.Values.Text = "Reset Colour &String Settings";
        // 
        // kbtnResetColourSettings
        // 
        this.kbtnResetColourSettings.Location = new(18, 138);
        this.kbtnResetColourSettings.Name = "kbtnResetColourSettings";
        this.kbtnResetColourSettings.Size = new(256, 25);
        this.kbtnResetColourSettings.TabIndex = 75;
        this.kbtnResetColourSettings.Values.Text = "Reset &Colour Settings";
        // 
        // kbtnResetColourIntegerSettings
        // 
        this.kbtnResetColourIntegerSettings.Location = new(18, 80);
        this.kbtnResetColourIntegerSettings.Name = "kbtnResetColourIntegerSettings";
        this.kbtnResetColourIntegerSettings.Size = new(256, 25);
        this.kbtnResetColourIntegerSettings.TabIndex = 74;
        this.kbtnResetColourIntegerSettings.Values.Text = "Reset Colour &Integer Settings";
        // 
        // kbtnResetColourBlendingSettings
        // 
        this.kbtnResetColourBlendingSettings.Location = new(18, 22);
        this.kbtnResetColourBlendingSettings.Name = "kbtnResetColourBlendingSettings";
        this.kbtnResetColourBlendingSettings.Size = new(256, 25);
        this.kbtnResetColourBlendingSettings.TabIndex = 73;
        this.kbtnResetColourBlendingSettings.Values.Text = "Reset Colour &Blending Settings";
        // 
        // kbtnNukeAllSettings
        // 
        this.kbtnNukeAllSettings.Location = new(18, 428);
        this.kbtnNukeAllSettings.Name = "kbtnNukeAllSettings";
        this.kbtnNukeAllSettings.Size = new(256, 25);
        this.kbtnNukeAllSettings.TabIndex = 72;
        this.kbtnNukeAllSettings.Values.Text = "&Nuke All Settings";
        // 
        // GlobalOptionsMenu
        // 
        this.ClientSize = new(690, 589);
        this.Controls.Add(this.kryptonPanel2);
        this.Controls.Add(this.kryptonPanel1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "GlobalOptionsMenu";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Global Options Menu";
        this.TextExtra = "(For Development Use Only)";
        this.Load += new(this.GlobalOptionsMenu_Load);
        ((System.ComponentModel.ISupportInitialize)this.kryptonPanel1).EndInit();
        this.kryptonPanel1.ResumeLayout(false);
        this.kryptonPanel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.kryptonPanel2).EndInit();
        this.kryptonPanel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.kryptonNavigator1).EndInit();
        this.kryptonNavigator1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.kryptonPage1).EndInit();
        this.kryptonPage1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.kryptonDockableNavigator1).EndInit();
        this.kryptonDockableNavigator1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.kryptonPage3).EndInit();
        this.kryptonPage3.ResumeLayout(false);
        this.kryptonPage3.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.cbxLightestColourPreview).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.cbxLightColourPreview).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.cbxMediumColourPreview).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.cbxDarkColourPreview).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.kryptonPage4).EndInit();
        this.kryptonPage4.ResumeLayout(false);
        this.kryptonPage4.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.cbxCircular).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.pbxStandard).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.kcmbDisplayType).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.kryptonPage5).EndInit();
        this.kryptonPage5.ResumeLayout(false);
        this.kryptonPage5.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.kpTheme).EndInit();
        this.kpTheme.ResumeLayout(false);
        this.kpTheme.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.ktcmbTheme).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.kpSettings).EndInit();
        this.kpSettings.ResumeLayout(false);
        this.kpSettings.PerformLayout();
        this.ResumeLayout(false);

    }

    #endregion

    #region Variables

    private KryptonManager _manager = new();
    private KryptonCustomPaletteBase _palette = new();
    private ThemeManager _themeManager = new();
    private ThemingLogic _themingLogic = new();
    private PaletteThemeSettingsManager _paletteThemeSettingsManager = new();

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
        DialogResult result = KryptonMessageBox.Show("This is for developmental use only. Do you want to continue?",
            "Global Options", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

        if (result == DialogResult.No)
        {
            Hide();
        }
    }
}