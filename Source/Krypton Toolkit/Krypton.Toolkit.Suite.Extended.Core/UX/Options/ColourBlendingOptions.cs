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
    public partial class ColourBlendingOptions : KryptonForm
    {
        #region Variables
        private ColourIntensitySettingsManager _colourBlendingSettingsManager = new();
        private GlobalBooleanSettingsManager _globalBooleanSettingsManager = new();
        private GlobalStringSettingsManager _globalStringSettingsManager = new();

        private System.Windows.Forms.Timer _updateValues = new();
        #endregion

        #region System
        private KryptonButton kbtnResetValues;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnCancel;
        private KryptonButton kbtnApply;
        private KryptonPanel kryptonPanel2;
        private Krypton.Docking.KryptonDockableNavigator kryptonDockableNavigator1;
        private Krypton.Navigator.KryptonPage kryptonPage1;
        private Krypton.Navigator.KryptonPage kryptonPage2;
        private Krypton.Navigator.KryptonPage kryptonPage3;
        private IContainer components;
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
        private KryptonCheckBox kchkConvertToRGBValue;
        private KryptonCheckBox kcbConvertToHexadecimalValue;
        private KryptonCheckBox kchkGenerateAlphaValue;
        private CircularPictureBox cbxCircular;
        private PictureBox pbxStandard;
        private KryptonComboBox kcmbDisplayType;
        private KryptonLabel kryptonLabel9;
        private KryptonCheckBox kchkAutomaticallyUpdateValues;
        private KryptonMaskedTextBox kmtxtFilePath;
        private ButtonSpecAny bsaReset;
        private ButtonSpecAny bsaBrowse;
        private KryptonLabel kryptonLabel10;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new(typeof(ColourBlendingOptions));
            this.kryptonPanel1 = new();
            this.kbtnResetValues = new();
            this.kbtnOk = new();
            this.kbtnCancel = new();
            this.kbtnApply = new();
            this.kryptonPanel2 = new();
            this.kryptonDockableNavigator1 = new();
            this.kryptonPage1 = new();
            this.kryptonPage2 = new();
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
            this.kchkConvertToRGBValue = new();
            this.kcbConvertToHexadecimalValue = new();
            this.kchkGenerateAlphaValue = new();
            this.cbxCircular = new();
            this.pbxStandard = new();
            this.kcmbDisplayType = new();
            this.kryptonLabel9 = new();
            this.kchkAutomaticallyUpdateValues = new();
            this.kmtxtFilePath = new();
            this.bsaReset = new();
            this.bsaBrowse = new();
            this.kryptonLabel10 = new();
            this.kryptonBorderEdge1 = new();
            ((System.ComponentModel.ISupportInitialize)this.kryptonPanel1).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.kryptonPanel2).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.kryptonDockableNavigator1).BeginInit();
            this.kryptonDockableNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.kryptonPage1).BeginInit();
            this.kryptonPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.kryptonPage2).BeginInit();
            this.kryptonPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.kryptonPage3).BeginInit();
            this.kryptonPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.cbxLightestColourPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.cbxLightColourPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.cbxMediumColourPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.cbxDarkColourPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.cbxCircular).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.pbxStandard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.kcmbDisplayType).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Controls.Add(this.kbtnResetValues);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kbtnApply);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new(0, 464);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new(664, 53);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnResetValues
            // 
            this.kbtnResetValues.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.kbtnResetValues.Enabled = false;
            this.kbtnResetValues.Location = new(12, 16);
            this.kbtnResetValues.Name = "kbtnResetValues";
            this.kbtnResetValues.Size = new(90, 25);
            this.kbtnResetValues.TabIndex = 1;
            this.kbtnResetValues.Values.Text = "Re&set Values";
            this.kbtnResetValues.Click += new(this.kbtnResetValues_Click);
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.kbtnOk.Location = new(370, 16);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new(90, 25);
            this.kbtnOk.TabIndex = 2;
            this.kbtnOk.Values.Text = "&Ok";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.kbtnCancel.Location = new(466, 16);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new(90, 25);
            this.kbtnCancel.TabIndex = 3;
            this.kbtnCancel.Values.Text = "Ca&ncel";
            // 
            // kbtnApply
            // 
            this.kbtnApply.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.kbtnApply.Enabled = false;
            this.kbtnApply.Location = new(562, 16);
            this.kbtnApply.Name = "kbtnApply";
            this.kbtnApply.Size = new(90, 25);
            this.kbtnApply.TabIndex = 0;
            this.kbtnApply.Values.Text = "&Apply";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonDockableNavigator1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new(664, 464);
            this.kryptonPanel2.TabIndex = 2;
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
            this.kryptonDockableNavigator1.Location = new(12, 12);
            this.kryptonDockableNavigator1.Name = "kryptonDockableNavigator1";
            this.kryptonDockableNavigator1.NavigatorMode = Krypton.Navigator.NavigatorMode.BarCheckButtonGroupOutside;
            this.kryptonDockableNavigator1.PageBackStyle = Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.kryptonDockableNavigator1.Pages.AddRange(new Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2,
            this.kryptonPage3});
            this.kryptonDockableNavigator1.SelectedIndex = 2;
            this.kryptonDockableNavigator1.Size = new(640, 444);
            this.kryptonDockableNavigator1.TabIndex = 35;
            this.kryptonDockableNavigator1.Text = "kryptonDockableNavigator1";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new(200, 200);
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
            this.kryptonPage1.MinimumSize = new(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new(638, 415);
            this.kryptonPage1.Text = "Colour Intensity";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "CA84FA1D35D047D920A054A4CAC807D7";
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new(200, 200);
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
            this.kryptonPage2.MinimumSize = new(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new(638, 415);
            this.kryptonPage2.Text = "UI Options";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "FA50690FF4D649BA9E9ED453E8E571B5";
            // 
            // kryptonPage3
            // 
            this.kryptonPage3.AutoHiddenSlideSize = new(200, 200);
            this.kryptonPage3.Controls.Add(this.kmtxtFilePath);
            this.kryptonPage3.Controls.Add(this.kryptonLabel10);
            this.kryptonPage3.Flags = 65534;
            this.kryptonPage3.LastVisibleSet = true;
            this.kryptonPage3.MinimumSize = new(50, 50);
            this.kryptonPage3.Name = "kryptonPage3";
            this.kryptonPage3.Size = new(638, 415);
            this.kryptonPage3.Text = "File Options";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "4FF76322826141100EA9C00D97F3A7A2";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new(88, 20);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new(155, 20);
            this.kryptonLabel1.TabIndex = 62;
            this.kryptonLabel1.Values.Text = "Darkest Colour Intensity:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new(88, 115);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new(151, 20);
            this.kryptonLabel2.TabIndex = 63;
            this.kryptonLabel2.Values.Text = "Middle Colour Intensity:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new(88, 210);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new(140, 20);
            this.kryptonLabel3.TabIndex = 64;
            this.kryptonLabel3.Values.Text = "Light Colour Intensity:";
            // 
            // kcbBaseColour
            // 
            this.kcbBaseColour.CustomColorPreviewShape = Krypton.Toolkit.KryptonColorButtonCustomColorPreviewShape.Circle;
            this.kcbBaseColour.Location = new(88, 376);
            this.kcbBaseColour.Name = "kcbBaseColour";
            this.kcbBaseColour.Size = new(179, 25);
            this.kcbBaseColour.TabIndex = 90;
            this.kcbBaseColour.Values.Image = (System.Drawing.Image)resources.GetObject("kcbBaseColour.Values.Image");
            this.kcbBaseColour.Values.RoundedCorners = 8;
            this.kcbBaseColour.Values.Text = "&Choose a Base Colour";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new(88, 305);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new(157, 20);
            this.kryptonLabel4.TabIndex = 65;
            this.kryptonLabel4.Values.Text = "Lightest Colour Intensity:";
            // 
            // cbxLightestColourPreview
            // 
            this.cbxLightestColourPreview.BackColor = System.Drawing.Color.Black;
            this.cbxLightestColourPreview.Location = new(519, 303);
            this.cbxLightestColourPreview.Name = "cbxLightestColourPreview";
            this.cbxLightestColourPreview.Size = new(32, 32);
            this.cbxLightestColourPreview.TabIndex = 89;
            this.cbxLightestColourPreview.TabStop = false;
            this.cbxLightestColourPreview.ToolTipValues = null;
            // 
            // knumDarkColourIntensityValue
            // 
            this.knumDarkColourIntensityValue.AllowDecimals = true;
            this.knumDarkColourIntensityValue.DecimalPlaces = 2;
            this.knumDarkColourIntensityValue.Location = new(249, 17);
            this.knumDarkColourIntensityValue.Name = "knumDarkColourIntensityValue";
            this.knumDarkColourIntensityValue.Size = new(82, 22);
            this.knumDarkColourIntensityValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.knumDarkColourIntensityValue.TabIndex = 66;
            // 
            // cbxLightColourPreview
            // 
            this.cbxLightColourPreview.BackColor = System.Drawing.Color.Black;
            this.cbxLightColourPreview.Location = new(519, 210);
            this.cbxLightColourPreview.Name = "cbxLightColourPreview";
            this.cbxLightColourPreview.Size = new(32, 32);
            this.cbxLightColourPreview.TabIndex = 88;
            this.cbxLightColourPreview.TabStop = false;
            this.cbxLightColourPreview.ToolTipValues = null;
            // 
            // knumMiddleColourIntensityValue
            // 
            this.knumMiddleColourIntensityValue.AllowDecimals = true;
            this.knumMiddleColourIntensityValue.DecimalPlaces = 2;
            this.knumMiddleColourIntensityValue.Location = new(249, 115);
            this.knumMiddleColourIntensityValue.Name = "knumMiddleColourIntensityValue";
            this.knumMiddleColourIntensityValue.Size = new(82, 22);
            this.knumMiddleColourIntensityValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.knumMiddleColourIntensityValue.TabIndex = 67;
            // 
            // cbxMediumColourPreview
            // 
            this.cbxMediumColourPreview.BackColor = System.Drawing.Color.Black;
            this.cbxMediumColourPreview.Location = new(519, 115);
            this.cbxMediumColourPreview.Name = "cbxMediumColourPreview";
            this.cbxMediumColourPreview.Size = new(32, 32);
            this.cbxMediumColourPreview.TabIndex = 87;
            this.cbxMediumColourPreview.TabStop = false;
            this.cbxMediumColourPreview.ToolTipValues = null;
            // 
            // knumLightColourIntensityValue
            // 
            this.knumLightColourIntensityValue.AllowDecimals = true;
            this.knumLightColourIntensityValue.DecimalPlaces = 2;
            this.knumLightColourIntensityValue.Location = new(249, 210);
            this.knumLightColourIntensityValue.Name = "knumLightColourIntensityValue";
            this.knumLightColourIntensityValue.Size = new(82, 22);
            this.knumLightColourIntensityValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.knumLightColourIntensityValue.TabIndex = 68;
            // 
            // cbxDarkColourPreview
            // 
            this.cbxDarkColourPreview.BackColor = System.Drawing.Color.Black;
            this.cbxDarkColourPreview.Location = new(519, 17);
            this.cbxDarkColourPreview.Name = "cbxDarkColourPreview";
            this.cbxDarkColourPreview.Size = new(32, 32);
            this.cbxDarkColourPreview.TabIndex = 86;
            this.cbxDarkColourPreview.TabStop = false;
            this.cbxDarkColourPreview.ToolTipValues = null;
            // 
            // knumLightestColourIntensityValue
            // 
            this.knumLightestColourIntensityValue.AllowDecimals = true;
            this.knumLightestColourIntensityValue.DecimalPlaces = 2;
            this.knumLightestColourIntensityValue.Location = new(249, 305);
            this.knumLightestColourIntensityValue.Name = "knumLightestColourIntensityValue";
            this.knumLightestColourIntensityValue.Size = new(82, 22);
            this.knumLightestColourIntensityValue.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.knumLightestColourIntensityValue.TabIndex = 69;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel5.Location = new(337, 20);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new(21, 20);
            this.kryptonLabel5.TabIndex = 70;
            this.kryptonLabel5.Values.Text = "%";
            // 
            // klblLightestColourIntensityValueOutput
            // 
            this.klblLightestColourIntensityValueOutput.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.klblLightestColourIntensityValueOutput.Location = new(438, 305);
            this.klblLightestColourIntensityValueOutput.Name = "klblLightestColourIntensityValueOutput";
            this.klblLightestColourIntensityValueOutput.Size = new(75, 20);
            this.klblLightestColourIntensityValueOutput.TabIndex = 85;
            this.klblLightestColourIntensityValueOutput.Values.Text = "Output: {0}";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel6.Location = new(337, 115);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new(21, 20);
            this.kryptonLabel6.TabIndex = 71;
            this.kryptonLabel6.Values.Text = "%";
            // 
            // klblLightColourIntensityValueOutput
            // 
            this.klblLightColourIntensityValueOutput.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.klblLightColourIntensityValueOutput.Location = new(438, 210);
            this.klblLightColourIntensityValueOutput.Name = "klblLightColourIntensityValueOutput";
            this.klblLightColourIntensityValueOutput.Size = new(75, 20);
            this.klblLightColourIntensityValueOutput.TabIndex = 84;
            this.klblLightColourIntensityValueOutput.Values.Text = "Output: {0}";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel7.Location = new(337, 210);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new(21, 20);
            this.kryptonLabel7.TabIndex = 72;
            this.kryptonLabel7.Values.Text = "%";
            // 
            // klblMiddleColourIntensityValueOutput
            // 
            this.klblMiddleColourIntensityValueOutput.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.klblMiddleColourIntensityValueOutput.Location = new(438, 115);
            this.klblMiddleColourIntensityValueOutput.Name = "klblMiddleColourIntensityValueOutput";
            this.klblMiddleColourIntensityValueOutput.Size = new(75, 20);
            this.klblMiddleColourIntensityValueOutput.TabIndex = 83;
            this.klblMiddleColourIntensityValueOutput.Values.Text = "Output: {0}";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel8.Location = new(337, 305);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new(21, 20);
            this.kryptonLabel8.TabIndex = 73;
            this.kryptonLabel8.Values.Text = "%";
            // 
            // klblDarkColourIntensityValueOutput
            // 
            this.klblDarkColourIntensityValueOutput.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.klblDarkColourIntensityValueOutput.Location = new(438, 20);
            this.klblDarkColourIntensityValueOutput.Name = "klblDarkColourIntensityValueOutput";
            this.klblDarkColourIntensityValueOutput.Size = new(75, 20);
            this.klblDarkColourIntensityValueOutput.TabIndex = 82;
            this.klblDarkColourIntensityValueOutput.Values.Text = "Output: {0}";
            // 
            // kbtnDarkColourIntensityValueMinus
            // 
            this.kbtnDarkColourIntensityValueMinus.Location = new(364, 13);
            this.kbtnDarkColourIntensityValueMinus.Name = "kbtnDarkColourIntensityValueMinus";
            this.kbtnDarkColourIntensityValueMinus.Size = new(18, 30);
            this.kbtnDarkColourIntensityValueMinus.StateCommon.Content.ShortText.Font = new("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.kbtnDarkColourIntensityValueMinus.TabIndex = 74;
            this.kbtnDarkColourIntensityValueMinus.Values.Text = "-";
            // 
            // kbtnLightestColourIntensityValuePlus
            // 
            this.kbtnLightestColourIntensityValuePlus.Location = new(400, 305);
            this.kbtnLightestColourIntensityValuePlus.Name = "kbtnLightestColourIntensityValuePlus";
            this.kbtnLightestColourIntensityValuePlus.Size = new(23, 30);
            this.kbtnLightestColourIntensityValuePlus.StateCommon.Content.ShortText.Font = new("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.kbtnLightestColourIntensityValuePlus.TabIndex = 81;
            this.kbtnLightestColourIntensityValuePlus.Values.Text = "+";
            // 
            // kbnDarkestColourIntensityValuePlus
            // 
            this.kbnDarkestColourIntensityValuePlus.Location = new(400, 13);
            this.kbnDarkestColourIntensityValuePlus.Name = "kbnDarkestColourIntensityValuePlus";
            this.kbnDarkestColourIntensityValuePlus.Size = new(23, 30);
            this.kbnDarkestColourIntensityValuePlus.StateCommon.Content.ShortText.Font = new("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.kbnDarkestColourIntensityValuePlus.TabIndex = 75;
            this.kbnDarkestColourIntensityValuePlus.Values.Text = "+";
            // 
            // kbtnLightestColourIntensityValueMinus
            // 
            this.kbtnLightestColourIntensityValueMinus.Location = new(364, 305);
            this.kbtnLightestColourIntensityValueMinus.Name = "kbtnLightestColourIntensityValueMinus";
            this.kbtnLightestColourIntensityValueMinus.Size = new(18, 30);
            this.kbtnLightestColourIntensityValueMinus.StateCommon.Content.ShortText.Font = new("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.kbtnLightestColourIntensityValueMinus.TabIndex = 80;
            this.kbtnLightestColourIntensityValueMinus.Values.Text = "-";
            // 
            // kbtnMiddleColourIntensityValueMinus
            // 
            this.kbtnMiddleColourIntensityValueMinus.Location = new(364, 115);
            this.kbtnMiddleColourIntensityValueMinus.Name = "kbtnMiddleColourIntensityValueMinus";
            this.kbtnMiddleColourIntensityValueMinus.Size = new(18, 30);
            this.kbtnMiddleColourIntensityValueMinus.StateCommon.Content.ShortText.Font = new("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.kbtnMiddleColourIntensityValueMinus.TabIndex = 76;
            this.kbtnMiddleColourIntensityValueMinus.Values.Text = "-";
            // 
            // kbtLightColourIntensityValuePlus
            // 
            this.kbtLightColourIntensityValuePlus.Location = new(400, 210);
            this.kbtLightColourIntensityValuePlus.Name = "kbtLightColourIntensityValuePlus";
            this.kbtLightColourIntensityValuePlus.Size = new(23, 30);
            this.kbtLightColourIntensityValuePlus.StateCommon.Content.ShortText.Font = new("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.kbtLightColourIntensityValuePlus.TabIndex = 79;
            this.kbtLightColourIntensityValuePlus.Values.Text = "+";
            // 
            // kbtnMiddleColourIntensityValuePlus
            // 
            this.kbtnMiddleColourIntensityValuePlus.Location = new(400, 115);
            this.kbtnMiddleColourIntensityValuePlus.Name = "kbtnMiddleColourIntensityValuePlus";
            this.kbtnMiddleColourIntensityValuePlus.Size = new(23, 30);
            this.kbtnMiddleColourIntensityValuePlus.StateCommon.Content.ShortText.Font = new("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.kbtnMiddleColourIntensityValuePlus.TabIndex = 77;
            this.kbtnMiddleColourIntensityValuePlus.Values.Text = "+";
            // 
            // kbtnLightColourIntensityValueMinus
            // 
            this.kbtnLightColourIntensityValueMinus.Location = new(364, 210);
            this.kbtnLightColourIntensityValueMinus.Name = "kbtnLightColourIntensityValueMinus";
            this.kbtnLightColourIntensityValueMinus.Size = new(18, 30);
            this.kbtnLightColourIntensityValueMinus.StateCommon.Content.ShortText.Font = new("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.kbtnLightColourIntensityValueMinus.TabIndex = 78;
            this.kbtnLightColourIntensityValueMinus.Values.Text = "-";
            // 
            // kchkConvertToRGBValue
            // 
            this.kchkConvertToRGBValue.Location = new(65, 250);
            this.kchkConvertToRGBValue.Name = "kchkConvertToRGBValue";
            this.kchkConvertToRGBValue.Size = new(219, 20);
            this.kchkConvertToRGBValue.TabIndex = 58;
            this.kchkConvertToRGBValue.Values.Text = "Automatically Convert to &RGB Value";
            // 
            // kcbConvertToHexadecimalValue
            // 
            this.kcbConvertToHexadecimalValue.Location = new(65, 197);
            this.kcbConvertToHexadecimalValue.Name = "kcbConvertToHexadecimalValue";
            this.kcbConvertToHexadecimalValue.Size = new(266, 20);
            this.kcbConvertToHexadecimalValue.TabIndex = 57;
            this.kcbConvertToHexadecimalValue.Values.Text = "Automatically Convert to &Hexadecimal Value";
            // 
            // kchkGenerateAlphaValue
            // 
            this.kchkGenerateAlphaValue.Location = new(65, 144);
            this.kchkGenerateAlphaValue.Name = "kchkGenerateAlphaValue";
            this.kchkGenerateAlphaValue.Size = new(159, 20);
            this.kchkGenerateAlphaValue.TabIndex = 56;
            this.kchkGenerateAlphaValue.Values.Text = "&Generate an Alpha Value";
            // 
            // cbxCircular
            // 
            this.cbxCircular.BackColor = System.Drawing.Color.Black;
            this.cbxCircular.Location = new(346, 80);
            this.cbxCircular.Name = "cbxCircular";
            this.cbxCircular.Size = new(32, 32);
            this.cbxCircular.TabIndex = 55;
            this.cbxCircular.TabStop = false;
            this.cbxCircular.ToolTipValues = null;
            // 
            // pbxStandard
            // 
            this.pbxStandard.BackColor = System.Drawing.Color.Black;
            this.pbxStandard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxStandard.Location = new(346, 80);
            this.pbxStandard.Name = "pbxStandard";
            this.pbxStandard.Size = new(32, 32);
            this.pbxStandard.TabIndex = 54;
            this.pbxStandard.TabStop = false;
            // 
            // kcmbDisplayType
            // 
            this.kcmbDisplayType.DropDownWidth = 203;
            this.kcmbDisplayType.IntegralHeight = false;
            this.kcmbDisplayType.Items.AddRange(new object[] {
            "Standard",
            "Circular"});
            this.kcmbDisplayType.Location = new(137, 80);
            this.kcmbDisplayType.Name = "kcmbDisplayType";
            this.kcmbDisplayType.Size = new(203, 21);
            this.kcmbDisplayType.TabIndex = 53;
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel9.Location = new(43, 80);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new(88, 20);
            this.kryptonLabel9.TabIndex = 52;
            this.kryptonLabel9.Values.Text = "Display Type:";
            // 
            // kchkAutomaticallyUpdateValues
            // 
            this.kchkAutomaticallyUpdateValues.Location = new(43, 17);
            this.kchkAutomaticallyUpdateValues.Name = "kchkAutomaticallyUpdateValues";
            this.kchkAutomaticallyUpdateValues.Size = new(180, 20);
            this.kchkAutomaticallyUpdateValues.TabIndex = 51;
            this.kchkAutomaticallyUpdateValues.Values.Text = "&Automatically Update Values";
            // 
            // kmtxtFilePath
            // 
            this.kmtxtFilePath.ButtonSpecs.AddRange(new Krypton.Toolkit.ButtonSpecAny[] {
            this.bsaReset,
            this.bsaBrowse});
            this.kmtxtFilePath.Location = new(165, 17);
            this.kmtxtFilePath.Name = "kmtxtFilePath";
            this.kmtxtFilePath.Size = new(366, 26);
            this.kmtxtFilePath.TabIndex = 65;
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
            this.kryptonLabel10.Location = new(43, 17);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new(116, 20);
            this.kryptonLabel10.TabIndex = 64;
            this.kryptonLabel10.Values.Text = "Export Colours to:";
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new(664, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // ColourBlendingOptions
            // 
            this.ClientSize = new(664, 517);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColourBlendingOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Colour Blending Options";
            this.Load += new(this.ColourBlendingOptions_Load);
            ((System.ComponentModel.ISupportInitialize)this.kryptonPanel1).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.kryptonPanel2).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.kryptonDockableNavigator1).EndInit();
            this.kryptonDockableNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.kryptonPage1).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            this.kryptonPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.kryptonPage2).EndInit();
            this.kryptonPage2.ResumeLayout(false);
            this.kryptonPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.kryptonPage3).EndInit();
            this.kryptonPage3.ResumeLayout(false);
            this.kryptonPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.cbxLightestColourPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.cbxLightColourPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.cbxMediumColourPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.cbxDarkColourPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.cbxCircular).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.pbxStandard).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.kcmbDisplayType).EndInit();
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

            _globalStringSettingsManager.SetPaletteExportPath(
                $"{Environment.SpecialFolder.MyDocuments}\\Krypton Palettes");

            kmtxtFilePath.Text = $"{Environment.SpecialFolder.MyDocuments}\\Krypton Palettes";
        }

        private void UpdateValues_Tick(object sender, EventArgs e)
        {
            ColourUtilities.GenerateColourShades(cbxDarkColourPreview, cbxMediumColourPreview, cbxLightColourPreview, cbxLightestColourPreview, Convert.ToSingle(knumDarkColourIntensityValue.Value), Convert.ToSingle(knumMiddleColourIntensityValue.Value), Convert.ToSingle(knumLightColourIntensityValue.Value), Convert.ToSingle(knumLightestColourIntensityValue.Value), kcbBaseColour.SelectedColor);
        }

        #region Methods
        private void UpdateFeedback(KryptonLabel output, decimal intensityPercentage)
        {
            float temp = Decimal.ToSingle(intensityPercentage);

            output.Text = $"Output: {temp.ToString()}";
        }

        private void SetApplyButton(bool enabled)
        {
            kbtnApply.Enabled = enabled;
        }

        private void SetRestoreValuesButton(bool enabled)
        {
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
            CommonOpenFileDialog commonOpenFileDialog = new();

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