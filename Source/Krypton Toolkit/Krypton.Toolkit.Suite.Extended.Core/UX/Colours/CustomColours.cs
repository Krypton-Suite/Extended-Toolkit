#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public partial class CustomColours : KryptonForm
    {
        #region System

        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnOk;
        private System.Windows.Forms.Panel panel1;
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
        private KryptonButton kbtnSaveColour;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomColours));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnUtiliseAsBaseColour = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kbtnSaveColour = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.klstCustomColourSelector = new Krypton.Toolkit.KryptonListBox();
            this.pbxColourPreview = new System.Windows.Forms.PictureBox();
            this.kcmbNormalTextSystemColours = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel22 = new Krypton.Toolkit.KryptonLabel();
            this.kcmbNormalTextColour = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel21 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnGenerateNormalTextBlueValue = new Krypton.Toolkit.KryptonButton();
            this.knumBlueChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnGenerateNormalTextGreenValue = new Krypton.Toolkit.KryptonButton();
            this.knumGreenChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnGenerateNormalTextRedValue = new Krypton.Toolkit.KryptonButton();
            this.knumRedChannelValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColourPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbNormalTextSystemColours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbNormalTextColour)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnUtiliseAsBaseColour);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnSaveColour);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 338);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1023, 49);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnUtiliseAsBaseColour
            // 
            this.kbtnUtiliseAsBaseColour.AutoSize = true;
            this.kbtnUtiliseAsBaseColour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnUtiliseAsBaseColour.Location = new System.Drawing.Point(183, 7);
            this.kbtnUtiliseAsBaseColour.Name = "kbtnUtiliseAsBaseColour";
            this.kbtnUtiliseAsBaseColour.Size = new System.Drawing.Size(167, 30);
            this.kbtnUtiliseAsBaseColour.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnUtiliseAsBaseColour.TabIndex = 79;
            this.kbtnUtiliseAsBaseColour.Values.Text = "Utilise as Base &Colour";
            this.kbtnUtiliseAsBaseColour.Click += new System.EventHandler(this.kbtnUtiliseAsBaseColour_Click);
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.AutoSize = true;
            this.kbtnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnOk.Location = new System.Drawing.Point(979, 7);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(32, 30);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.TabIndex = 77;
            this.kbtnOk.Values.Text = "O&k";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kbtnSaveColour
            // 
            this.kbtnSaveColour.AutoSize = true;
            this.kbtnSaveColour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnSaveColour.Enabled = false;
            this.kbtnSaveColour.Location = new System.Drawing.Point(12, 7);
            this.kbtnSaveColour.Name = "kbtnSaveColour";
            this.kbtnSaveColour.Size = new System.Drawing.Size(165, 30);
            this.kbtnSaveColour.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnSaveColour.TabIndex = 78;
            this.kbtnSaveColour.Values.Text = "Save &Selected Colour";
            this.kbtnSaveColour.Click += new System.EventHandler(this.kbtnSaveColour_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 336);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1023, 2);
            this.panel1.TabIndex = 2;
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
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(1023, 336);
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
            this.klstCustomColourSelector.Location = new System.Drawing.Point(12, 12);
            this.klstCustomColourSelector.Name = "klstCustomColourSelector";
            this.klstCustomColourSelector.Size = new System.Drawing.Size(335, 257);
            this.klstCustomColourSelector.Sorted = true;
            this.klstCustomColourSelector.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klstCustomColourSelector.TabIndex = 156;
            // 
            // pbxColourPreview
            // 
            this.pbxColourPreview.BackColor = System.Drawing.Color.Transparent;
            this.pbxColourPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxColourPreview.Location = new System.Drawing.Point(353, 12);
            this.pbxColourPreview.Name = "pbxColourPreview";
            this.pbxColourPreview.Size = new System.Drawing.Size(650, 180);
            this.pbxColourPreview.TabIndex = 155;
            this.pbxColourPreview.TabStop = false;
            this.pbxColourPreview.BackColorChanged += new System.EventHandler(this.pbxColourPreview_BackColorChanged);
            this.pbxColourPreview.Click += new System.EventHandler(this.pbxColourPreview_Click);
            this.pbxColourPreview.MouseEnter += new System.EventHandler(this.pbxColourPreview_MouseEnter);
            // 
            // kcmbNormalTextSystemColours
            // 
            this.kcmbNormalTextSystemColours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbNormalTextSystemColours.DropDownWidth = 173;
            this.kcmbNormalTextSystemColours.Location = new System.Drawing.Point(830, 215);
            this.kcmbNormalTextSystemColours.Name = "kcmbNormalTextSystemColours";
            this.kcmbNormalTextSystemColours.Size = new System.Drawing.Size(173, 27);
            this.kcmbNormalTextSystemColours.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbNormalTextSystemColours.TabIndex = 154;
            this.kcmbNormalTextSystemColours.SelectedIndexChanged += new System.EventHandler(this.kcmbNormalTextSystemColours_SelectedIndexChanged);
            // 
            // kryptonLabel22
            // 
            this.kryptonLabel22.Location = new System.Drawing.Point(688, 216);
            this.kryptonLabel22.Name = "kryptonLabel22";
            this.kryptonLabel22.Size = new System.Drawing.Size(136, 26);
            this.kryptonLabel22.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel22.TabIndex = 153;
            this.kryptonLabel22.Values.Text = "System Colours:";
            // 
            // kcmbNormalTextColour
            // 
            this.kcmbNormalTextColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbNormalTextColour.DropDownWidth = 173;
            this.kcmbNormalTextColour.Location = new System.Drawing.Point(509, 215);
            this.kcmbNormalTextColour.Name = "kcmbNormalTextColour";
            this.kcmbNormalTextColour.Size = new System.Drawing.Size(173, 27);
            this.kcmbNormalTextColour.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcmbNormalTextColour.TabIndex = 152;
            this.kcmbNormalTextColour.SelectedIndexChanged += new System.EventHandler(this.kcmbNormalTextColour_SelectedIndexChanged);
            // 
            // kryptonLabel21
            // 
            this.kryptonLabel21.Location = new System.Drawing.Point(353, 216);
            this.kryptonLabel21.Name = "kryptonLabel21";
            this.kryptonLabel21.Size = new System.Drawing.Size(150, 26);
            this.kryptonLabel21.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel21.TabIndex = 151;
            this.kryptonLabel21.Values.Text = "Standard Colours:";
            // 
            // kbtnGenerateNormalTextBlueValue
            // 
            this.kbtnGenerateNormalTextBlueValue.AutoSize = true;
            this.kbtnGenerateNormalTextBlueValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateNormalTextBlueValue.Location = new System.Drawing.Point(843, 282);
            this.kbtnGenerateNormalTextBlueValue.Name = "kbtnGenerateNormalTextBlueValue";
            this.kbtnGenerateNormalTextBlueValue.Size = new System.Drawing.Size(114, 30);
            this.kbtnGenerateNormalTextBlueValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateNormalTextBlueValue.TabIndex = 150;
            this.kbtnGenerateNormalTextBlueValue.Values.Text = "Generate &Blue";
            this.kbtnGenerateNormalTextBlueValue.Click += new System.EventHandler(this.kbtnGenerateNormalTextBlueValue_Click);
            // 
            // knumBlueChannelValue
            // 
            this.knumBlueChannelValue.Location = new System.Drawing.Point(717, 282);
            this.knumBlueChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumBlueChannelValue.Name = "knumBlueChannelValue";
            this.knumBlueChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumBlueChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Blue;
            this.knumBlueChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumBlueChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumBlueChannelValue.TabIndex = 149;
            this.knumBlueChannelValue.ValueChanged += new System.EventHandler(this.knumBlueChannelValue_ValueChanged);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(649, 284);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(50, 26);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.TabIndex = 148;
            this.kryptonLabel4.Values.Text = "Blue:";
            // 
            // kbtnGenerateNormalTextGreenValue
            // 
            this.kbtnGenerateNormalTextGreenValue.AutoSize = true;
            this.kbtnGenerateNormalTextGreenValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateNormalTextGreenValue.Location = new System.Drawing.Point(517, 284);
            this.kbtnGenerateNormalTextGreenValue.Name = "kbtnGenerateNormalTextGreenValue";
            this.kbtnGenerateNormalTextGreenValue.Size = new System.Drawing.Size(126, 30);
            this.kbtnGenerateNormalTextGreenValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateNormalTextGreenValue.TabIndex = 147;
            this.kbtnGenerateNormalTextGreenValue.Values.Text = "Generate &Green";
            this.kbtnGenerateNormalTextGreenValue.Click += new System.EventHandler(this.kbtnGenerateNormalTextGreenValue_Click);
            // 
            // knumGreenChannelValue
            // 
            this.knumGreenChannelValue.Location = new System.Drawing.Point(391, 284);
            this.knumGreenChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumGreenChannelValue.Name = "knumGreenChannelValue";
            this.knumGreenChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumGreenChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Lime;
            this.knumGreenChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumGreenChannelValue.TabIndex = 146;
            this.knumGreenChannelValue.ValueChanged += new System.EventHandler(this.knumGreenChannelValue_ValueChanged);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(323, 284);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(62, 26);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.TabIndex = 145;
            this.kryptonLabel3.Values.Text = "Green:";
            // 
            // kbtnGenerateNormalTextRedValue
            // 
            this.kbtnGenerateNormalTextRedValue.AutoSize = true;
            this.kbtnGenerateNormalTextRedValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnGenerateNormalTextRedValue.Location = new System.Drawing.Point(206, 284);
            this.kbtnGenerateNormalTextRedValue.Name = "kbtnGenerateNormalTextRedValue";
            this.kbtnGenerateNormalTextRedValue.Size = new System.Drawing.Size(111, 30);
            this.kbtnGenerateNormalTextRedValue.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnGenerateNormalTextRedValue.TabIndex = 144;
            this.kbtnGenerateNormalTextRedValue.Values.Text = "Generate &Red";
            this.kbtnGenerateNormalTextRedValue.Click += new System.EventHandler(this.kbtnGenerateNormalTextRedValue_Click);
            // 
            // knumRedChannelValue
            // 
            this.knumRedChannelValue.Location = new System.Drawing.Point(80, 283);
            this.knumRedChannelValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knumRedChannelValue.Name = "knumRedChannelValue";
            this.knumRedChannelValue.Size = new System.Drawing.Size(120, 28);
            this.knumRedChannelValue.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.knumRedChannelValue.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.knumRedChannelValue.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.knumRedChannelValue.TabIndex = 143;
            this.knumRedChannelValue.ValueChanged += new System.EventHandler(this.knumRedChannelValue_ValueChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 284);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(46, 26);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.TabIndex = 142;
            this.kryptonLabel2.Values.Text = "Red:";
            // 
            // CustomColours
            // 
            this.AcceptButton = this.kbtnOk;
            this.ClientSize = new System.Drawing.Size(1023, 387);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomColours";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Define Custom Colours";
            this.Load += new System.EventHandler(this.CustomColours_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColourPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbNormalTextSystemColours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbNormalTextColour)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private RandomNumberGenerator _randomNumberGenerator = new RandomNumberGenerator();
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
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.BORDERCOLOUR, pbxColourPreview.BackColor);

                //if (_globalBooleanSettingsManager.GetDisableListItem())
                //{

                //}
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Alternative Normal Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.ALTERNATIVENORMALTEXTCOLOUR, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Normal Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.NORMALTEXTCOLOUR, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Disabled Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.DISABLEDTEXTCOLOUR, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Focused Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.FOCUSEDTEXTCOLOUR, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Pressed Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.PRESSEDTEXTCOLOUR, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Link Normal Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.LINKNORMALTEXTCOLOUR, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Link Hover Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.LINKHOVERTEXTCOLOUR, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Link Visited Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.LINKVISITEDTEXTCOLOUR, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Disabled Control Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.DISABLEDCONTROLCOLOUR, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Colour One")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CUSTOMCOLOURONE, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Colour Two")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CUSTOMCOLOURTWO, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Colour Three")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CUSTOMCOLOURTHREE, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Colour Four")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CUSTOMCOLOURFOUR, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Colour Five")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CUSTOMCOLOURFIVE, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Menu Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.MENUTEXTCOLOUR, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Text Colour One")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CUSTOMTEXTCOLOURONE, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Text Colour Two")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CUSTOMTEXTCOLOURTWO, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Text Colour Three")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CUSTOMTEXTCOLOURTHREE, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Text Colour Four")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CUSTOMTEXTCOLOURFOUR, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Custom Text Colour Five")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.CUSTOMTEXTCOLOURFIVE, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Status Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.STATUSTEXTCOLOUR, pbxColourPreview.BackColor);
            }
            else if (klstCustomColourSelector.SelectedItem.ToString() == "Ribbon Tab Text Colour")
            {
                ColourUtilities.DefineCustomColour(MiscellaneousColourDefinitions.RIBBONTABTEXTCOLOUR, pbxColourPreview.BackColor);
            }

            kbtnSaveColour.Enabled = false;
        }

        private void kbtnGenerateNormalTextRedValue_Click(object sender, EventArgs e)
        {
            knumRedChannelValue.Value = _randomNumberGenerator.RandomlyGenerateARedNumberBetween(0, 255);
        }

        private void kbtnGenerateNormalTextGreenValue_Click(object sender, EventArgs e)
        {
            knumGreenChannelValue.Value = _randomNumberGenerator.RandomlyGenerateAGreenNumberBetween(0, 255);
        }

        private void kbtnGenerateNormalTextBlueValue_Click(object sender, EventArgs e)
        {
            knumBlueChannelValue.Value = _randomNumberGenerator.RandomlyGenerateABlueNumberBetween(0, 255);
        }

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

        private void pbxColourPreview_BackColorChanged(object sender, EventArgs e)
        {
            kbtnSaveColour.Enabled = true;
        }

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
                PaletteColourCreator colourCreator = new PaletteColourCreator(pbxColourPreview.BackColor);

                colourCreator.Show();
            }
            else
            {
                KryptonMessageBox.Show("You must select another colour other than 'Transparent' in order to utilise this feature.", "Invalid Base Colour Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void knumRedChannelValue_ValueChanged(object sender, EventArgs e)
        {
            pbxColourPreview.BackColor = ColourManager.ChangeColour(255, knumRedChannelValue.Value, knumGreenChannelValue.Value, knumBlueChannelValue.Value);
        }

        private void knumGreenChannelValue_ValueChanged(object sender, EventArgs e)
        {
            pbxColourPreview.BackColor = ColourManager.ChangeColour(255, knumRedChannelValue.Value, knumGreenChannelValue.Value, knumBlueChannelValue.Value);
        }

        private void knumBlueChannelValue_ValueChanged(object sender, EventArgs e)
        {
            pbxColourPreview.BackColor = ColourManager.ChangeColour(255, knumRedChannelValue.Value, knumGreenChannelValue.Value, knumBlueChannelValue.Value);
        }
    }
}