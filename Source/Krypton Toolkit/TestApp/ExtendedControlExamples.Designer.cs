﻿namespace TestApp
{
    partial class ExtendedControlExamples
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtendedControlExamples));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kcbSaveDialog = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbExpandedMode = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbFolderPicker = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbReset = new Krypton.Toolkit.KryptonCheckBox();
            this.kcmbAlignment = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonRichTextBoxExtended1 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonRichTextBoxExtended();
            this.kryptonProgressBarExtendedVersion21 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonProgressBarExtendedVersion2();
            this.kryptonProgressBarExtendedVersion11 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonProgressBarExtendedVersion1();
            this.kkTest2 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonKnobControlVersion2();
            this.kkTest1 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonKnobControlVersion1();
            this.kbbTest = new Krypton.Toolkit.Suite.Extended.Controls.KryptonBrowseBox();
            this.kryptonBorderedLabel1 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonBorderedLabel();
            this.circularPictureBox1 = new Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbAlignment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kcbSaveDialog);
            this.kryptonPanel1.Controls.Add(this.kcbExpandedMode);
            this.kryptonPanel1.Controls.Add(this.kcbFolderPicker);
            this.kryptonPanel1.Controls.Add(this.kcbReset);
            this.kryptonPanel1.Controls.Add(this.kcmbAlignment);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.kryptonRichTextBoxExtended1);
            this.kryptonPanel1.Controls.Add(this.kryptonProgressBarExtendedVersion21);
            this.kryptonPanel1.Controls.Add(this.kryptonProgressBarExtendedVersion11);
            this.kryptonPanel1.Controls.Add(this.kkTest2);
            this.kryptonPanel1.Controls.Add(this.kkTest1);
            this.kryptonPanel1.Controls.Add(this.kbbTest);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderedLabel1);
            this.kryptonPanel1.Controls.Add(this.circularPictureBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1314, 759);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kcbSaveDialog
            // 
            this.kcbSaveDialog.Location = new System.Drawing.Point(358, 229);
            this.kcbSaveDialog.Name = "kcbSaveDialog";
            this.kcbSaveDialog.Size = new System.Drawing.Size(108, 20);
            this.kcbSaveDialog.TabIndex = 13;
            this.kcbSaveDialog.Values.Text = "Use save dialog";
            this.kcbSaveDialog.CheckedChanged += new System.EventHandler(this.kcbSaveDialog_CheckedChanged);
            // 
            // kcbExpandedMode
            // 
            this.kcbExpandedMode.Location = new System.Drawing.Point(358, 203);
            this.kcbExpandedMode.Name = "kcbExpandedMode";
            this.kcbExpandedMode.Size = new System.Drawing.Size(124, 20);
            this.kcbExpandedMode.TabIndex = 12;
            this.kcbExpandedMode.Values.Text = "Is expanded mode";
            this.kcbExpandedMode.CheckedChanged += new System.EventHandler(this.kcbExpandedMode_CheckedChanged);
            // 
            // kcbFolderPicker
            // 
            this.kcbFolderPicker.Location = new System.Drawing.Point(357, 176);
            this.kcbFolderPicker.Name = "kcbFolderPicker";
            this.kcbFolderPicker.Size = new System.Drawing.Size(104, 20);
            this.kcbFolderPicker.TabIndex = 11;
            this.kcbFolderPicker.Values.Text = "Is folder picker";
            this.kcbFolderPicker.CheckedChanged += new System.EventHandler(this.kcbFolderPicker_CheckedChanged);
            // 
            // kcbReset
            // 
            this.kcbReset.Checked = true;
            this.kcbReset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kcbReset.Location = new System.Drawing.Point(357, 149);
            this.kcbReset.Name = "kcbReset";
            this.kcbReset.Size = new System.Drawing.Size(123, 20);
            this.kcbReset.TabIndex = 10;
            this.kcbReset.Values.Text = "Show reset option";
            this.kcbReset.CheckedChanged += new System.EventHandler(this.kcbReset_CheckedChanged);
            // 
            // kcmbAlignment
            // 
            this.kcmbAlignment.CornerRoundingRadius = -1F;
            this.kcmbAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbAlignment.DropDownWidth = 121;
            this.kcmbAlignment.IntegralHeight = false;
            this.kcmbAlignment.Items.AddRange(new object[] {
            "Left",
            "Centre",
            "Right",
            "Justify"});
            this.kcmbAlignment.Location = new System.Drawing.Point(95, 262);
            this.kcmbAlignment.Name = "kcmbAlignment";
            this.kcmbAlignment.Size = new System.Drawing.Size(121, 21);
            this.kcmbAlignment.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbAlignment.TabIndex = 9;
            this.kcmbAlignment.SelectedIndexChanged += new System.EventHandler(this.kcmbAlignment_SelectedIndexChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 262);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel1.TabIndex = 8;
            this.kryptonLabel1.Values.Text = "Alignment:";
            // 
            // kryptonRichTextBoxExtended1
            // 
            this.kryptonRichTextBoxExtended1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonRichTextBoxExtended1.Location = new System.Drawing.Point(13, 13);
            this.kryptonRichTextBoxExtended1.Multiline = true;
            this.kryptonRichTextBoxExtended1.Name = "kryptonRichTextBoxExtended1";
            this.kryptonRichTextBoxExtended1.Size = new System.Drawing.Size(338, 242);
            this.kryptonRichTextBoxExtended1.TabIndex = 7;
            this.kryptonRichTextBoxExtended1.Text = "kryptonRichTextBoxExtended1";
            // 
            // kryptonProgressBarExtendedVersion21
            // 
            this.kryptonProgressBarExtendedVersion21.Location = new System.Drawing.Point(860, 13);
            this.kryptonProgressBarExtendedVersion21.Name = "kryptonProgressBarExtendedVersion21";
            this.kryptonProgressBarExtendedVersion21.Size = new System.Drawing.Size(241, 32);
            this.kryptonProgressBarExtendedVersion21.TabIndex = 6;
            this.kryptonProgressBarExtendedVersion21.Text = "0%";
            // 
            // kryptonProgressBarExtendedVersion11
            // 
            this.kryptonProgressBarExtendedVersion11.BackColor = System.Drawing.Color.Transparent;
            this.kryptonProgressBarExtendedVersion11.Location = new System.Drawing.Point(590, 13);
            this.kryptonProgressBarExtendedVersion11.Name = "kryptonProgressBarExtendedVersion11";
            this.kryptonProgressBarExtendedVersion11.Size = new System.Drawing.Size(264, 32);
            this.kryptonProgressBarExtendedVersion11.TabIndex = 5;
            // 
            // kkTest2
            // 
            this.kkTest2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkTest2.EndAngle = 405F;
            this.kkTest2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kkTest2.KnobBackColour = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkTest2.LargeChange = 5;
            this.kkTest2.Location = new System.Drawing.Point(860, 51);
            this.kkTest2.Maximum = 100;
            this.kkTest2.Minimum = 0;
            this.kkTest2.Name = "kkTest2";
            this.kkTest2.PointerColour = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(157)))), ((int)(((byte)(189)))));
            this.kkTest2.PointerStyle = Krypton.Toolkit.Suite.Extended.Controls.KryptonKnobControlVersion2.KnobPointerStyles.CIRCLE;
            this.kkTest2.ScaleColour = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kkTest2.ScaleDivisions = 11;
            this.kkTest2.ScaleSubDivisions = 4;
            this.kkTest2.ScaleTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kkTest2.ShowLargeScale = true;
            this.kkTest2.ShowSmallScale = true;
            this.kkTest2.Size = new System.Drawing.Size(241, 241);
            this.kkTest2.SmallChange = 1;
            this.kkTest2.StartAngle = 135F;
            this.kkTest2.TabIndex = 4;
            this.kkTest2.Value = 0;
            this.kkTest2.ValueChanged += new Krypton.Toolkit.Suite.Extended.Controls.ValueChangedEventHandler(this.kkTest2_ValueChanged);
            // 
            // kkTest1
            // 
            this.kkTest1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kkTest1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.kkTest1.KnobIndicatorBorderColour = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.kkTest1.KnobIndicatorColourBegin = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkTest1.KnobIndicatorColourEnd = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kkTest1.LargeChange = 20;
            this.kkTest1.Location = new System.Drawing.Point(590, 51);
            this.kkTest1.Maximum = 100;
            this.kkTest1.Minimum = 0;
            this.kkTest1.Name = "kkTest1";
            this.kkTest1.ShowLargeScale = true;
            this.kkTest1.ShowSmallScale = true;
            this.kkTest1.Size = new System.Drawing.Size(264, 183);
            this.kkTest1.SizeLargeScaleMarker = 6;
            this.kkTest1.SizeSmallScaleMarker = 3;
            this.kkTest1.SmallChange = 5;
            this.kkTest1.TabIndex = 3;
            this.kkTest1.Value = 0;
            this.kkTest1.ValueChanged += new Krypton.Toolkit.Suite.Extended.Controls.ValueChangedEventHandler(this.kkTest1_ValueChanged);
            // 
            // kbbTest
            // 
            this.kbbTest.LargeResetImage = ((System.Drawing.Image)(resources.GetObject("kbbTest.LargeResetImage")));
            this.kbbTest.Location = new System.Drawing.Point(357, 118);
            this.kbbTest.Name = "kbbTest";
            this.kbbTest.ResetText = null;
            this.kbbTest.ResetTextToolTipDescription = null;
            this.kbbTest.ResetTextToolTipHeading = null;
            this.kbbTest.ShowResetButton = true;
            this.kbbTest.Size = new System.Drawing.Size(192, 24);
            this.kbbTest.SmallResetImage = ((System.Drawing.Image)(resources.GetObject("kbbTest.SmallResetImage")));
            this.kbbTest.TabIndex = 2;
            this.kbbTest.Text = "kryptonBrowseBox1";
            // 
            // kryptonBorderedLabel1
            // 
            this.kryptonBorderedLabel1.BackColor = System.Drawing.Color.Transparent;
            this.kryptonBorderedLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kryptonBorderedLabel1.Location = new System.Drawing.Point(357, 83);
            this.kryptonBorderedLabel1.Name = "kryptonBorderedLabel1";
            this.kryptonBorderedLabel1.Size = new System.Drawing.Size(139, 20);
            this.kryptonBorderedLabel1.TabIndex = 1;
            this.kryptonBorderedLabel1.Values.Text = "kryptonBorderedLabel1";
            // 
            // circularPictureBox1
            // 
            this.circularPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.circularPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("circularPictureBox1.Image")));
            this.circularPictureBox1.Location = new System.Drawing.Point(357, 13);
            this.circularPictureBox1.Name = "circularPictureBox1";
            this.circularPictureBox1.Size = new System.Drawing.Size(64, 64);
            this.circularPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.circularPictureBox1.TabIndex = 0;
            this.circularPictureBox1.TabStop = false;
            // 
            // ExtendedControlExamples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 759);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "ExtendedControlExamples";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExtendedControlExamples";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbAlignment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonComboBox kcmbAlignment;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonRichTextBoxExtended kryptonRichTextBoxExtended1;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonProgressBarExtendedVersion2 kryptonProgressBarExtendedVersion21;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonProgressBarExtendedVersion1 kryptonProgressBarExtendedVersion11;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonKnobControlVersion2 kkTest2;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonKnobControlVersion1 kkTest1;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonBrowseBox kbbTest;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonBorderedLabel kryptonBorderedLabel1;
        private Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox circularPictureBox1;
        private Krypton.Toolkit.KryptonCheckBox kcbExpandedMode;
        private Krypton.Toolkit.KryptonCheckBox kcbFolderPicker;
        private Krypton.Toolkit.KryptonCheckBox kcbReset;
        private Krypton.Toolkit.KryptonCheckBox kcbSaveDialog;
    }
}