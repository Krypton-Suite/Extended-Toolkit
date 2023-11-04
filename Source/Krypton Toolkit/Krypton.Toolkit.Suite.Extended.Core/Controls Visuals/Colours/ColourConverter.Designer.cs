namespace Krypton.Toolkit.Suite.Extended.Core
{
    partial class ColourConverter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColourConverter));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.ccpbxPreview = new Krypton.Toolkit.Suite.Extended.Common.CommonCircularPictureBox();
            this.kbtnConvertToRGB = new Krypton.Toolkit.KryptonButton();
            this.kbtnConvertToHexadecimal = new Krypton.Toolkit.KryptonButton();
            this.ktxtHexValue = new Krypton.Toolkit.KryptonTextBox();
            this.knudBlueValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudRedValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.knudGreenValue = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kchkUpdateColourValues = new Krypton.Toolkit.KryptonCheckBox();
            this.kbtnUseColour = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kcbtnSelectBaseColour = new Krypton.Toolkit.KryptonColorButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.tmrUpdateColourValues = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ccpbxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.ccpbxPreview);
            this.kryptonPanel1.Controls.Add(this.kbtnConvertToRGB);
            this.kryptonPanel1.Controls.Add(this.kbtnConvertToHexadecimal);
            this.kryptonPanel1.Controls.Add(this.ktxtHexValue);
            this.kryptonPanel1.Controls.Add(this.knudBlueValue);
            this.kryptonPanel1.Controls.Add(this.knudRedValue);
            this.kryptonPanel1.Controls.Add(this.knudGreenValue);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(603, 230);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // ccpbxPreview
            // 
            this.ccpbxPreview.BackColor = System.Drawing.Color.Transparent;
            this.ccpbxPreview.Location = new System.Drawing.Point(437, 13);
            this.ccpbxPreview.Name = "ccpbxPreview";
            this.ccpbxPreview.Size = new System.Drawing.Size(150, 150);
            this.ccpbxPreview.TabIndex = 10;
            this.ccpbxPreview.TabStop = false;
            // 
            // kbtnConvertToRGB
            // 
            this.kbtnConvertToRGB.CornerRoundingRadius = -1F;
            this.kbtnConvertToRGB.Location = new System.Drawing.Point(236, 90);
            this.kbtnConvertToRGB.Name = "kbtnConvertToRGB";
            this.kbtnConvertToRGB.Size = new System.Drawing.Size(154, 25);
            this.kbtnConvertToRGB.TabIndex = 9;
            this.kbtnConvertToRGB.Values.Text = "Convert &Hex to RGB";
            this.kbtnConvertToRGB.Click += new System.EventHandler(this.kbtnConvertToRGB_Click);
            // 
            // kbtnConvertToHexadecimal
            // 
            this.kbtnConvertToHexadecimal.CornerRoundingRadius = -1F;
            this.kbtnConvertToHexadecimal.Location = new System.Drawing.Point(236, 48);
            this.kbtnConvertToHexadecimal.Name = "kbtnConvertToHexadecimal";
            this.kbtnConvertToHexadecimal.Size = new System.Drawing.Size(154, 25);
            this.kbtnConvertToHexadecimal.TabIndex = 8;
            this.kbtnConvertToHexadecimal.Values.Text = "Convert &RGB to Hex";
            this.kbtnConvertToHexadecimal.Click += new System.EventHandler(this.kbtnConvertToHexadecimal_Click);
            // 
            // ktxtHexValue
            // 
            this.ktxtHexValue.CueHint.CueHintText = "000000";
            this.ktxtHexValue.Location = new System.Drawing.Point(109, 147);
            this.ktxtHexValue.MaxLength = 7;
            this.ktxtHexValue.Name = "ktxtHexValue";
            this.ktxtHexValue.Size = new System.Drawing.Size(100, 23);
            this.ktxtHexValue.TabIndex = 7;
            // 
            // knudBlueValue
            // 
            this.knudBlueValue.Location = new System.Drawing.Point(68, 90);
            this.knudBlueValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudBlueValue.Name = "knudBlueValue";
            this.knudBlueValue.Size = new System.Drawing.Size(71, 22);
            this.knudBlueValue.TabIndex = 6;
            // 
            // knudRedValue
            // 
            this.knudRedValue.Location = new System.Drawing.Point(68, 13);
            this.knudRedValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudRedValue.Name = "knudRedValue";
            this.knudRedValue.Size = new System.Drawing.Size(71, 22);
            this.knudRedValue.TabIndex = 5;
            // 
            // knudGreenValue
            // 
            this.knudGreenValue.Location = new System.Drawing.Point(68, 48);
            this.knudGreenValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.knudGreenValue.Name = "knudGreenValue";
            this.knudGreenValue.Size = new System.Drawing.Size(71, 22);
            this.knudGreenValue.TabIndex = 4;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(13, 147);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(89, 20);
            this.kryptonLabel4.TabIndex = 3;
            this.kryptonLabel4.Values.Text = "Hexadecimal:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(13, 48);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(48, 20);
            this.kryptonLabel3.TabIndex = 2;
            this.kryptonLabel3.Values.Text = "Green:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(13, 90);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(39, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Blue:";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 13);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Red:";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kchkUpdateColourValues);
            this.kryptonPanel2.Controls.Add(this.kbtnUseColour);
            this.kryptonPanel2.Controls.Add(this.kbtnCancel);
            this.kryptonPanel2.Controls.Add(this.kcbtnSelectBaseColour);
            this.kryptonPanel2.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 180);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel2.Size = new System.Drawing.Size(603, 50);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kchkUpdateColourValues
            // 
            this.kchkUpdateColourValues.Location = new System.Drawing.Point(202, 18);
            this.kchkUpdateColourValues.Name = "kchkUpdateColourValues";
            this.kchkUpdateColourValues.Size = new System.Drawing.Size(142, 20);
            this.kchkUpdateColourValues.TabIndex = 4;
            this.kchkUpdateColourValues.Values.Text = "Update C&olour Values";
            this.kchkUpdateColourValues.CheckedChanged += new System.EventHandler(this.kchkUpdateColourValues_CheckedChanged);
            // 
            // kbtnUseColour
            // 
            this.kbtnUseColour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnUseColour.CornerRoundingRadius = -1F;
            this.kbtnUseColour.Location = new System.Drawing.Point(405, 13);
            this.kbtnUseColour.Name = "kbtnUseColour";
            this.kbtnUseColour.Size = new System.Drawing.Size(90, 25);
            this.kbtnUseColour.TabIndex = 3;
            this.kbtnUseColour.Values.Text = "Use &Colour";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.CornerRoundingRadius = -1F;
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(501, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "&Cancel";
            // 
            // kcbtnSelectBaseColour
            // 
            this.kcbtnSelectBaseColour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kcbtnSelectBaseColour.CustomColorPreviewShape = Krypton.Toolkit.KryptonColorButtonCustomColorPreviewShape.Circle;
            this.kcbtnSelectBaseColour.Location = new System.Drawing.Point(13, 13);
            this.kcbtnSelectBaseColour.Name = "kcbtnSelectBaseColour";
            this.kcbtnSelectBaseColour.Size = new System.Drawing.Size(183, 25);
            this.kcbtnSelectBaseColour.Splitter = false;
            this.kcbtnSelectBaseColour.TabIndex = 1;
            this.kcbtnSelectBaseColour.Values.Image = ((System.Drawing.Image)(resources.GetObject("kcbtnSelectBaseColour.Values.Image")));
            this.kcbtnSelectBaseColour.Values.RoundedCorners = 8;
            this.kcbtnSelectBaseColour.Values.Text = "Choose Base &Colour";
            this.kcbtnSelectBaseColour.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcbtnSelectBaseColour_SelectedColorChanged);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(603, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // tmrUpdateColourValues
            // 
            this.tmrUpdateColourValues.Interval = 1000;
            this.tmrUpdateColourValues.Tick += new System.EventHandler(this.tmrUpdateColourValues_Tick);
            // 
            // ColourConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 230);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColourConverter";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ColourConverter";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ccpbxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private CommonCircularPictureBox ccpbxPreview;
        private KryptonButton kbtnConvertToRGB;
        private KryptonButton kbtnConvertToHexadecimal;
        private KryptonTextBox ktxtHexValue;
        private KryptonNumericUpDown knudBlueValue;
        private KryptonNumericUpDown knudRedValue;
        private KryptonNumericUpDown knudGreenValue;
        private KryptonLabel kryptonLabel4;
        private KryptonLabel kryptonLabel3;
        private KryptonLabel kryptonLabel2;
        private KryptonLabel kryptonLabel1;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnUseColour;
        private KryptonButton kbtnCancel;
        private KryptonColorButton kcbtnSelectBaseColour;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonCheckBox kchkUpdateColourValues;
        private System.Windows.Forms.Timer tmrUpdateColourValues;
    }
}