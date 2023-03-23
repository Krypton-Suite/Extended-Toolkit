namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    partial class CustomFormatRule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomFormatRule));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonGroup1 = new Krypton.Toolkit.KryptonGroup();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kcolbtnMinimumColour = new Krypton.Toolkit.KryptonColorButton();
            this.kcolbtnIntermediateColour = new Krypton.Toolkit.KryptonColorButton();
            this.kcolbtnMaximumColour = new Krypton.Toolkit.KryptonColorButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kcmbFormatStyle = new Krypton.Toolkit.KryptonComboBox();
            this.pbxPreview = new System.Windows.Forms.PictureBox();
            this.kcmbFillMode = new Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).BeginInit();
            this.kryptonGroup1.Panel.SuspendLayout();
            this.kryptonGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbFormatStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbFillMode)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 150);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(638, 50);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(638, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kcmbFillMode);
            this.kryptonPanel2.Controls.Add(this.pbxPreview);
            this.kryptonPanel2.Controls.Add(this.kcmbFormatStyle);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.kryptonGroup1);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(638, 150);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 13);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(56, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Format:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(13, 40);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(60, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Preview:";
            // 
            // kryptonGroup1
            // 
            this.kryptonGroup1.GroupBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonGroup1.Location = new System.Drawing.Point(13, 67);
            this.kryptonGroup1.Name = "kryptonGroup1";
            // 
            // kryptonGroup1.Panel
            // 
            this.kryptonGroup1.Panel.Controls.Add(this.kcolbtnMaximumColour);
            this.kryptonGroup1.Panel.Controls.Add(this.kcolbtnIntermediateColour);
            this.kryptonGroup1.Panel.Controls.Add(this.kcolbtnMinimumColour);
            this.kryptonGroup1.Size = new System.Drawing.Size(613, 36);
            this.kryptonGroup1.TabIndex = 2;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel3.Location = new System.Drawing.Point(13, 115);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(28, 20);
            this.kryptonLabel3.TabIndex = 3;
            this.kryptonLabel3.Values.Text = "Fill:";
            // 
            // kcolbtnMinimumColour
            // 
            this.kcolbtnMinimumColour.CustomColorPreviewShape = Krypton.Toolkit.KryptonColorButtonCustomColorPreviewShape.Circle;
            this.kcolbtnMinimumColour.Location = new System.Drawing.Point(4, 4);
            this.kcolbtnMinimumColour.Name = "kcolbtnMinimumColour";
            this.kcolbtnMinimumColour.SelectedColor = System.Drawing.Color.Transparent;
            this.kcolbtnMinimumColour.Size = new System.Drawing.Size(171, 25);
            this.kcolbtnMinimumColour.TabIndex = 0;
            this.kcolbtnMinimumColour.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonColorButton1.Values.Image")));
            this.kcolbtnMinimumColour.Values.RoundedCorners = 8;
            this.kcolbtnMinimumColour.Values.Text = "M&inimum Colour";
            // 
            // kcolbtnIntermediateColour
            // 
            this.kcolbtnIntermediateColour.CustomColorPreviewShape = Krypton.Toolkit.KryptonColorButtonCustomColorPreviewShape.Circle;
            this.kcolbtnIntermediateColour.Location = new System.Drawing.Point(181, 4);
            this.kcolbtnIntermediateColour.Name = "kcolbtnIntermediateColour";
            this.kcolbtnIntermediateColour.SelectedColor = System.Drawing.Color.Transparent;
            this.kcolbtnIntermediateColour.Size = new System.Drawing.Size(185, 25);
            this.kcolbtnIntermediateColour.TabIndex = 1;
            this.kcolbtnIntermediateColour.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonColorButton2.Values.Image1")));
            this.kcolbtnIntermediateColour.Values.RoundedCorners = 8;
            this.kcolbtnIntermediateColour.Values.Text = "Inter&mediate Colour";
            // 
            // kcolbtnMaximumColour
            // 
            this.kcolbtnMaximumColour.CustomColorPreviewShape = Krypton.Toolkit.KryptonColorButtonCustomColorPreviewShape.Circle;
            this.kcolbtnMaximumColour.Location = new System.Drawing.Point(373, 4);
            this.kcolbtnMaximumColour.Name = "kcolbtnMaximumColour";
            this.kcolbtnMaximumColour.SelectedColor = System.Drawing.Color.Transparent;
            this.kcolbtnMaximumColour.Size = new System.Drawing.Size(182, 25);
            this.kcolbtnMaximumColour.TabIndex = 2;
            this.kcolbtnMaximumColour.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonColorButton2.Values.Image")));
            this.kcolbtnMaximumColour.Values.RoundedCorners = 8;
            this.kcolbtnMaximumColour.Values.Text = "Ma&ximum Colour";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(471, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(155, 25);
            this.kbtnCancel.TabIndex = 1;
            this.kbtnCancel.Values.Text = "kryptonButton1";
            // 
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Enabled = false;
            this.kbtnOk.Location = new System.Drawing.Point(310, 13);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(155, 25);
            this.kbtnOk.TabIndex = 2;
            this.kbtnOk.Values.Text = "kryptonButton2";
            // 
            // kcmbFormatStyle
            // 
            this.kcmbFormatStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbFormatStyle.DropDownWidth = 318;
            this.kcmbFormatStyle.IntegralHeight = false;
            this.kcmbFormatStyle.Location = new System.Drawing.Point(79, 12);
            this.kcmbFormatStyle.Name = "kcmbFormatStyle";
            this.kcmbFormatStyle.Size = new System.Drawing.Size(318, 21);
            this.kcmbFormatStyle.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbFormatStyle.TabIndex = 4;
            // 
            // pbxPreview
            // 
            this.pbxPreview.BackColor = System.Drawing.Color.Transparent;
            this.pbxPreview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbxPreview.Location = new System.Drawing.Point(79, 40);
            this.pbxPreview.Name = "pbxPreview";
            this.pbxPreview.Size = new System.Drawing.Size(318, 22);
            this.pbxPreview.TabIndex = 6;
            this.pbxPreview.TabStop = false;
            // 
            // kcmbFillMode
            // 
            this.kcmbFillMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbFillMode.DropDownWidth = 208;
            this.kcmbFillMode.IntegralHeight = false;
            this.kcmbFillMode.Location = new System.Drawing.Point(48, 115);
            this.kcmbFillMode.Name = "kcmbFillMode";
            this.kcmbFillMode.Size = new System.Drawing.Size(208, 21);
            this.kcmbFillMode.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbFillMode.TabIndex = 7;
            // 
            // CustomFormatRule
            // 
            this.AcceptButton = this.kbtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(638, 200);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CustomFormatRule";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Rule";
            this.Controls.SetChildIndex(this.kryptonPanel1, 0);
            this.Controls.SetChildIndex(this.kryptonPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).EndInit();
            this.kryptonGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).EndInit();
            this.kryptonGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbFormatStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbFillMode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonLabel kryptonLabel3;
        private KryptonGroup kryptonGroup1;
        private KryptonColorButton kcolbtnIntermediateColour;
        private KryptonColorButton kcolbtnMinimumColour;
        private KryptonLabel kryptonLabel2;
        private KryptonLabel kryptonLabel1;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnCancel;
        private KryptonComboBox kcmbFillMode;
        private PictureBox pbxPreview;
        private KryptonComboBox kcmbFormatStyle;
        private KryptonColorButton kcolbtnMaximumColour;
    }
}