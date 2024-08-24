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
    public partial class CustomColours : KryptonForm
    {
        #region System

        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnOk;
        private KryptonPanel kryptonPanel2;
        private KryptonListBox klstCustomColourSelector;
        private System.Windows.Forms.PictureBox pbxColourPreview;
        private KryptonComboBox kcmbNormalTextSystemColours;
        private KryptonLabel kryptonLabel22;
        private KryptonComboBox kcmbNormalTextColour;
        private KryptonLabel kryptonLabel21;
        private KryptonButton kbtnGenerateNormalTextBlueValue;
        private KryptonNumericUpDown knumBlueChannelValue;
        private KryptonLabel kryptonLabel4;
        private KryptonButton kbtnGenerateNormalTextGreenValue;
        private KryptonNumericUpDown knumGreenChannelValue;
        private KryptonLabel kryptonLabel3;
        private KryptonButton kbtnGenerateNormalTextRedValue;
        private KryptonNumericUpDown knumRedChannelValue;
        private KryptonLabel kryptonLabel2;
        private KryptonButton kbtnUtiliseAsBaseColour;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonButton kbtnSaveColour;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new();
            this.kbtnUtiliseAsBaseColour = new();
            this.kbtnOk = new();
            this.kbtnSaveColour = new();
            this.kryptonPanel2 = new();
            this.klstCustomColourSelector = new();
            this.pbxColourPreview = new();
            this.kcmbNormalTextSystemColours = new();
            this.kryptonLabel22 = new();
            this.kcmbNormalTextColour = new();
            this.kryptonLabel21 = new();
            this.kbtnGenerateNormalTextBlueValue = new();
            this.knumBlueChannelValue = new();
            this.kryptonLabel4 = new();
            this.kbtnGenerateNormalTextGreenValue = new();
            this.knumGreenChannelValue = new();
            this.kryptonLabel3 = new();
            this.kbtnGenerateNormalTextRedValue = new();
            this.knumRedChannelValue = new();
            this.kryptonLabel2 = new();
            this.kryptonBorderEdge1 = new();
            ((System.ComponentModel.ISupportInitialize)this.kryptonPanel1).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.kryptonPanel2).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pbxColourPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.kcmbNormalTextSystemColours).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.kcmbNormalTextColour).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Controls.Add(this.kbtnUtiliseAsBaseColour);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnSaveColour);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new(0, 338);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new(1023, 49);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnUtiliseAsBaseColour
            // 
            this.kbtnUtiliseAsBaseColour.Location = new(155, 12);
            this.kbtnUtiliseAsBaseColour.Name = "kbtnUtiliseAsBaseColour";
            this.kbtnUtiliseAsBaseColour.Size = new(142, 25);
            this.kbtnUtiliseAsBaseColour.TabIndex = 79;
            this.kbtnUtiliseAsBaseColour.Values.Text = "Utilise as Base &Colour";
            this.kbtnUtiliseAsBaseColour.Click += new(this.kbtnUtiliseAsBaseColour_Click);
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.kbtnOk.Location = new(921, 12);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new(90, 25);
            this.kbtnOk.TabIndex = 77;
            this.kbtnOk.Values.Text = "O&k";
            this.kbtnOk.Click += new(this.kbtnOk_Click);
            // 
            // kbtnSaveColour
            // 
            this.kbtnSaveColour.Enabled = false;
            this.kbtnSaveColour.Location = new(12, 12);
            this.kbtnSaveColour.Name = "kbtnSaveColour";
            this.kbtnSaveColour.Size = new(137, 25);
            this.kbtnSaveColour.TabIndex = 78;
            this.kbtnSaveColour.Values.Text = "Save &Selected Colour";
            this.kbtnSaveColour.Click += new(this.kbtnSaveColour_Click);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.klstCustomColourSelector);
            this.kryptonPanel2.Controls.Add(this.pbxColourPreview);
            this.kryptonPanel2.Controls.Add(this.kcmbNormalTextSystemColours);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel22);
            this.kryptonPanel2.Controls.Add(this.kcmbNormalTextColour);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel21);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerateNormalTextBlueValue);
            this.kryptonPanel2.Controls.Add(this.knumBlueChannelValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerateNormalTextGreenValue);
            this.kryptonPanel2.Controls.Add(this.knumGreenChannelValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.kbtnGenerateNormalTextRedValue);
            this.kryptonPanel2.Controls.Add(this.knumRedChannelValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new(1023, 338);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // klstCustomColourSelector
            // 
            this.klstCustomColourSelector.Items.AddRange(new object[] {
            "Alternative Normal Text Colour",
            "Border Colour",
            "Custom Colour Five",
            "Custom Colour Four",
            "Custom Colour One",
            "Custom Colour Three",
            "Custom Colour Two",
            "Custom Text Colour Five",
            "Custom Text Colour Four",
            "Custom Text Colour One",
            "Custom Text Colour Two",
            "Custom TextColour Three",
            "Disabled Control Colour",
            "Disabled Text Colour",
            "Focused Text Colour",
            "Link Hover Text Colour",
            "Link Normal Text Colour",
            "Link Visited Text Colour",
            "Menu Text Colour",
            "Normal Text Colour",
            "Pressed Text Colour",
            "Ribbon Tab Text Colour",
            "Status Text Colour"});
            this.klstCustomColourSelector.Location = new(12, 12);
            this.klstCustomColourSelector.Name = "klstCustomColourSelector";
            this.klstCustomColourSelector.Size = new(335, 257);
            this.klstCustomColourSelector.Sorted = true;
            this.klstCustomColourSelector.TabIndex = 156;
            // 
            // pbxColourPreview
            // 
            this.pbxColourPreview.BackColor = System.Drawing.Color.Transparent;
            this.pbxColourPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxColourPreview.Location = new(353, 12);
            this.pbxColourPreview.Name = "pbxColourPreview";
            this.pbxColourPreview.Size = new(650, 180);
            this.pbxColourPreview.TabIndex = 155;
            this.pbxColourPreview.TabStop = false;
            this.pbxColourPreview.BackColorChanged += new(this.pbxColourPreview_BackColorChanged);
            this.pbxColourPreview.Click += new(this.pbxColourPreview_Click);
            this.pbxColourPreview.MouseEnter += new(this.pbxColourPreview_MouseEnter);
            // 
            // kcmbNormalTextSystemColours
            // 
            this.kcmbNormalTextSystemColours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbNormalTextSystemColours.DropDownWidth = 173;
            this.kcmbNormalTextSystemColours.IntegralHeight = false;
            this.kcmbNormalTextSystemColours.Location = new(797, 215);
            this.kcmbNormalTextSystemColours.Name = "kcmbNormalTextSystemColours";
            this.kcmbNormalTextSystemColours.Size = new(173, 21);
            this.kcmbNormalTextSystemColours.TabIndex = 154;
            this.kcmbNormalTextSystemColours.SelectedIndexChanged += new(this.kcmbNormalTextSystemColours_SelectedIndexChanged);
            // 
            // kryptonLabel22
            // 
            this.kryptonLabel22.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel22.Location = new(688, 216);
            this.kryptonLabel22.Name = "kryptonLabel22";
            this.kryptonLabel22.Size = new(103, 20);
            this.kryptonLabel22.TabIndex = 153;
            this.kryptonLabel22.Values.Text = "System Colours:";
            // 
            // kcmbNormalTextColour
            // 
            this.kcmbNormalTextColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbNormalTextColour.DropDownWidth = 173;
            this.kcmbNormalTextColour.IntegralHeight = false;
            this.kcmbNormalTextColour.Location = new(473, 215);
            this.kcmbNormalTextColour.Name = "kcmbNormalTextColour";
            this.kcmbNormalTextColour.Size = new(173, 21);
            this.kcmbNormalTextColour.TabIndex = 152;
            this.kcmbNormalTextColour.SelectedIndexChanged += new(this.kcmbNormalTextColour_SelectedIndexChanged);
            // 
            // kryptonLabel21
            // 
            this.kryptonLabel21.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel21.Location = new(353, 216);
            this.kryptonLabel21.Name = "kryptonLabel21";
            this.kryptonLabel21.Size = new(114, 20);
            this.kryptonLabel21.TabIndex = 151;
            this.kryptonLabel21.Values.Text = "Standard Colours:";
            // 
            // kbtnGenerateNormalTextBlueValue
            // 
            this.kbtnGenerateNormalTextBlueValue.Location = new(780, 282);
            this.kbtnGenerateNormalTextBlueValue.Name = "kbtnGenerateNormalTextBlueValue";
            this.kbtnGenerateNormalTextBlueValue.Size = new(90, 25);
            this.kbtnGenerateNormalTextBlueValue.TabIndex = 150;
            this.kbtnGenerateNormalTextBlueValue.Values.Text = "Generate &Blue";
            this.kbtnGenerateNormalTextBlueValue.Click += new(this.kbtnGenerateNormalTextBlueValue_Click);
            // 
            // knumBlueChannelValue
            // 
            this.knumBlueChannelValue.Location = new(694, 282);
            this.knumBlueChannelValue.Maximum = new(new int[] {
            255,
            0,
            0,
            0});
            this.knumBlueChannelValue.Name = "knumBlueChannelValue";
            this.knumBlueChannelValue.Size = new(80, 22);
            this.knumBlueChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knumBlueChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumBlueChannelValue.TabIndex = 149;
            this.knumBlueChannelValue.ValueChanged += new(this.knumBlueChannelValue_ValueChanged);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new(649, 284);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new(39, 20);
            this.kryptonLabel4.TabIndex = 148;
            this.kryptonLabel4.Values.Text = "Blue:";
            // 
            // kbtnGenerateNormalTextGreenValue
            // 
            this.kbtnGenerateNormalTextGreenValue.Location = new(463, 282);
            this.kbtnGenerateNormalTextGreenValue.Name = "kbtnGenerateNormalTextGreenValue";
            this.kbtnGenerateNormalTextGreenValue.Size = new(106, 25);
            this.kbtnGenerateNormalTextGreenValue.TabIndex = 147;
            this.kbtnGenerateNormalTextGreenValue.Values.Text = "Generate &Green";
            this.kbtnGenerateNormalTextGreenValue.Click += new(this.kbtnGenerateNormalTextGreenValue_Click);
            // 
            // knumGreenChannelValue
            // 
            this.knumGreenChannelValue.Location = new(377, 282);
            this.knumGreenChannelValue.Maximum = new(new int[] {
            255,
            0,
            0,
            0});
            this.knumGreenChannelValue.Name = "knumGreenChannelValue";
            this.knumGreenChannelValue.Size = new(80, 22);
            this.knumGreenChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Lime;
            this.knumGreenChannelValue.TabIndex = 146;
            this.knumGreenChannelValue.ValueChanged += new(this.knumGreenChannelValue_ValueChanged);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new(323, 284);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new(48, 20);
            this.kryptonLabel3.TabIndex = 145;
            this.kryptonLabel3.Values.Text = "Green:";
            // 
            // kbtnGenerateNormalTextRedValue
            // 
            this.kbtnGenerateNormalTextRedValue.Location = new(140, 282);
            this.kbtnGenerateNormalTextRedValue.Name = "kbtnGenerateNormalTextRedValue";
            this.kbtnGenerateNormalTextRedValue.Size = new(90, 25);
            this.kbtnGenerateNormalTextRedValue.TabIndex = 144;
            this.kbtnGenerateNormalTextRedValue.Values.Text = "Generate &Red";
            this.kbtnGenerateNormalTextRedValue.Click += new(this.kbtnGenerateNormalTextRedValue_Click);
            // 
            // knumRedChannelValue
            // 
            this.knumRedChannelValue.Location = new(54, 282);
            this.knumRedChannelValue.Maximum = new(new int[] {
            255,
            0,
            0,
            0});
            this.knumRedChannelValue.Name = "knumRedChannelValue";
            this.knumRedChannelValue.Size = new(80, 22);
            this.knumRedChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knumRedChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumRedChannelValue.TabIndex = 143;
            this.knumRedChannelValue.ValueChanged += new(this.knumRedChannelValue_ValueChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new(12, 284);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new(36, 20);
            this.kryptonLabel2.TabIndex = 142;
            this.kryptonLabel2.Values.Text = "Red:";
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new(1023, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // CustomColours
            // 
            this.AcceptButton = this.kbtnOk;
            this.ClientSize = new(1023, 387);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomColours";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Define Custom Colours";
            this.Load += new(this.CustomColours_Load);
            ((System.ComponentModel.ISupportInitialize)this.kryptonPanel1).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.kryptonPanel2).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.pbxColourPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.kcmbNormalTextSystemColours).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.kcmbNormalTextColour).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private RandomNumberGenerator _randomNumberGenerator = new();
        #endregion

        public CustomColours()
        {
            InitializeComponent();
        }

        private void CustomColours_Load(object sender, EventArgs e)
        {
            ColourUtilities.PropagateStandardColours(kcmbNormalTextColour);

            ColourUtilities.PropagateSystemColours(kcmbNormalTextSystemColours);
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {

        }

        private void kbtnSaveColour_Click(object sender, EventArgs e)
        {
            if (klstCustomColourSelector.SelectedItem.ToString() == "Border Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.BorderColour, pbxColourPreview.BackColor);

                //if (_globalBooleanSettingsManager.GetDisableListItem())
                //{

                //}
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Alternative Normal Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.AlternativeNormalTextColour, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Normal Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.NormalTextColour, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Disabled Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.DisabledTextColour, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Focused Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.FocusedTextColour, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Pressed Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.PressedTextColour, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Link Normal Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.LinkNormalTextColour, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Link Hover Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.LinkHoverTextColour, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Link Visited Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.LinkVisitedTextColour, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Disabled Control Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.DisabledControlColour, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Colour One")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CustomColourOne, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Colour Two")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CustomColourTwo, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Colour Three")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CustomColourThree, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Colour Four")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CustomColourFour, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Colour Five")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CustomColourFive, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Colour Six")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CustomColourSix, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Menu Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.MenuTextColour, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Text Colour One")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CustomTextColourOne, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Text Colour Two")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CustomTextColourTwo, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Text Colour Three")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CustomTextColourThree, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Text Colour Four")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CustomTextColourFour, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Text Colour Five")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CustomTextColourFive, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Text Colour Six")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CustomTextColourSix, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Status Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.StatusTextColour, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Ribbon Tab Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.RibbonTabTextColour, pbxColourPreview.BackColor);
            }

            kbtnSaveColour.Enabled = false;
        }

        private void kbtnGenerateNormalTextRedValue_Click(object sender, EventArgs e) => knumRedChannelValue.Value = _randomNumberGenerator.RandomlyGenerateARedNumberBetween(0, 255);

        private void kbtnGenerateNormalTextGreenValue_Click(object sender, EventArgs e) => knumGreenChannelValue.Value = _randomNumberGenerator.RandomlyGenerateAGreenNumberBetween(0, 255);

        private void kbtnGenerateNormalTextBlueValue_Click(object sender, EventArgs e)
        => knumBlueChannelValue.Value = _randomNumberGenerator.RandomlyGenerateABlueNumberBetween(0, 255);

        private void pbxColourPreview_MouseEnter(object sender, EventArgs e)
        {
            //InformationControlManager.DisplayColourInformation(pbxColourPreview, false, "Colour Preview");
        }

        private void kcmbNormalTextColour_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color temporyColour = Color.FromName(kcmbNormalTextColour.Text);

            pbxColourPreview.BackColor = Color.FromName(kcmbNormalTextColour.Text);

            knumRedChannelValue.Value = temporyColour.R;

            knumGreenChannelValue.Value = temporyColour.G;

            knumBlueChannelValue.Value = temporyColour.B;
        }

        private void kcmbNormalTextSystemColours_SelectedIndexChanged(object sender, EventArgs e)
        {
            pbxColourPreview.BackColor = Color.FromName(kcmbNormalTextSystemColours.Text);

            knumRedChannelValue.Value = pbxColourPreview.BackColor.R;

            knumGreenChannelValue.Value = pbxColourPreview.BackColor.G;

            knumBlueChannelValue.Value = pbxColourPreview.BackColor.B;
        }

        private void pbxColourPreview_BackColorChanged(object sender, EventArgs e) => kbtnSaveColour.Enabled = true;

        private void pbxColourPreview_Click(object sender, EventArgs e)
        {
            knumRedChannelValue.Value = pbxColourPreview.BackColor.R;

            knumBlueChannelValue.Value = pbxColourPreview.BackColor.B;

            knumGreenChannelValue.Value = pbxColourPreview.BackColor.G;
        }

        private void kbtnUtiliseAsBaseColour_Click(object sender, EventArgs e)
        {
            if (pbxColourPreview.BackColor != Color.Transparent)
            {
                PaletteColourCreator colourCreator = new(pbxColourPreview.BackColor);

                colourCreator.Show();
            }
            else
            {
                KryptonMessageBox.Show("You must select another colour other than 'Transparent' in order to utilise this feature.", "Invalid Base Colour Detected", KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon.Information);
            }
        }

        private void knumRedChannelValue_ValueChanged(object sender, EventArgs e)
        => pbxColourPreview.BackColor = ColourManager.ChangeColour(255, knumRedChannelValue.Value, knumGreenChannelValue.Value, knumBlueChannelValue.Value);

        private void knumGreenChannelValue_ValueChanged(object sender, EventArgs e)
        => pbxColourPreview.BackColor = ColourManager.ChangeColour(255, knumRedChannelValue.Value, knumGreenChannelValue.Value, knumBlueChannelValue.Value);

        private void knumBlueChannelValue_ValueChanged(object sender, EventArgs e)
        => pbxColourPreview.BackColor = ColourManager.ChangeColour(255, knumRedChannelValue.Value, knumGreenChannelValue.Value, knumBlueChannelValue.Value);
    }
}