namespace Examples
{
    partial class MemoryBoxExample
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
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnShow = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kmbFillText = new Krypton.Toolkit.KryptonButton();
            this.ktxtMessageContent = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtCaption = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.groupBoxIcon = new Krypton.Toolkit.KryptonGroupBox();
            this.kryptonTextBox1 = new Krypton.Toolkit.KryptonTextBox();
            this.bsaBrowse = new Krypton.Toolkit.ButtonSpecAny();
            this.kcmbMemoryBoxIcon = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonThemeComboBox1 = new Krypton.Toolkit.KryptonThemeComboBox();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kcmbMessageBoxButtons = new Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxIcon.Panel)).BeginInit();
            this.groupBoxIcon.Panel.SuspendLayout();
            this.groupBoxIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbMemoryBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonThemeComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbMessageBoxButtons)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnShow);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 294);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(724, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnShow
            // 
            this.kbtnShow.Location = new System.Drawing.Point(622, 13);
            this.kbtnShow.Name = "kbtnShow";
            this.kbtnShow.Size = new System.Drawing.Size(90, 25);
            this.kbtnShow.TabIndex = 1;
            this.kbtnShow.Values.Text = "S&how";
            this.kbtnShow.Click += new System.EventHandler(this.kbtnShow_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(724, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel2.Controls.Add(this.kryptonThemeComboBox1);
            this.kryptonPanel2.Controls.Add(this.groupBoxIcon);
            this.kryptonPanel2.Controls.Add(this.kmbFillText);
            this.kryptonPanel2.Controls.Add(this.ktxtMessageContent);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.ktxtCaption);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(724, 294);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kmbFillText
            // 
            this.kmbFillText.Location = new System.Drawing.Point(12, 65);
            this.kmbFillText.Name = "kmbFillText";
            this.kmbFillText.Size = new System.Drawing.Size(90, 25);
            this.kmbFillText.TabIndex = 22;
            this.kmbFillText.Values.Text = "Fill Text";
            // 
            // ktxtMessageContent
            // 
            this.ktxtMessageContent.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.ktxtMessageContent.Location = new System.Drawing.Point(111, 38);
            this.ktxtMessageContent.Multiline = true;
            this.ktxtMessageContent.Name = "ktxtMessageContent";
            this.ktxtMessageContent.Size = new System.Drawing.Size(285, 137);
            this.ktxtMessageContent.TabIndex = 21;
            this.ktxtMessageContent.Text = "kryptonTextBox2";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 38);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(93, 20);
            this.kryptonLabel2.TabIndex = 20;
            this.kryptonLabel2.Values.Text = "Message Text:";
            // 
            // ktxtCaption
            // 
            this.ktxtCaption.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.ktxtCaption.Location = new System.Drawing.Point(111, 12);
            this.ktxtCaption.Name = "ktxtCaption";
            this.ktxtCaption.Size = new System.Drawing.Size(285, 23);
            this.ktxtCaption.TabIndex = 19;
            this.ktxtCaption.Text = "kryptonTextBox1";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(59, 20);
            this.kryptonLabel1.TabIndex = 18;
            this.kryptonLabel1.Values.Text = "Caption:";
            // 
            // groupBoxIcon
            // 
            this.groupBoxIcon.Location = new System.Drawing.Point(111, 181);
            this.groupBoxIcon.Name = "groupBoxIcon";
            // 
            // groupBoxIcon.Panel
            // 
            this.groupBoxIcon.Panel.Controls.Add(this.kryptonTextBox1);
            this.groupBoxIcon.Panel.Controls.Add(this.kcmbMemoryBoxIcon);
            this.groupBoxIcon.Size = new System.Drawing.Size(285, 92);
            this.groupBoxIcon.TabIndex = 23;
            this.groupBoxIcon.Values.Heading = "Icon";
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.ButtonSpecs.AddRange(new Krypton.Toolkit.ButtonSpecAny[] {
            this.bsaBrowse});
            this.kryptonTextBox1.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.kryptonTextBox1.Enabled = false;
            this.kryptonTextBox1.Location = new System.Drawing.Point(12, 35);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(256, 24);
            this.kryptonTextBox1.TabIndex = 1;
            // 
            // bsaBrowse
            // 
            this.bsaBrowse.Text = "...";
            this.bsaBrowse.UniqueName = "4d6b53a8282b4b7c9a9852c651792c06";
            // 
            // kcmbMemoryBoxIcon
            // 
            this.kcmbMemoryBoxIcon.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.kcmbMemoryBoxIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbMemoryBoxIcon.DropDownWidth = 256;
            this.kcmbMemoryBoxIcon.IntegralHeight = false;
            this.kcmbMemoryBoxIcon.Location = new System.Drawing.Point(12, 10);
            this.kcmbMemoryBoxIcon.Name = "kcmbMemoryBoxIcon";
            this.kcmbMemoryBoxIcon.Size = new System.Drawing.Size(256, 21);
            this.kcmbMemoryBoxIcon.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbMemoryBoxIcon.TabIndex = 0;
            // 
            // kryptonThemeComboBox1
            // 
            this.kryptonThemeComboBox1.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.kryptonThemeComboBox1.DropDownWidth = 311;
            this.kryptonThemeComboBox1.IntegralHeight = false;
            this.kryptonThemeComboBox1.Location = new System.Drawing.Point(402, 12);
            this.kryptonThemeComboBox1.Name = "kryptonThemeComboBox1";
            this.kryptonThemeComboBox1.Size = new System.Drawing.Size(311, 21);
            this.kryptonThemeComboBox1.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonThemeComboBox1.TabIndex = 24;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(402, 38);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kcmbMessageBoxButtons);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(310, 77);
            this.kryptonGroupBox1.TabIndex = 25;
            this.kryptonGroupBox1.Values.Heading = "Buttons";
            // 
            // kcmbMessageBoxButtons
            // 
            this.kcmbMessageBoxButtons.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.kcmbMessageBoxButtons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbMessageBoxButtons.DropDownWidth = 256;
            this.kcmbMessageBoxButtons.IntegralHeight = false;
            this.kcmbMessageBoxButtons.Location = new System.Drawing.Point(12, 14);
            this.kcmbMessageBoxButtons.Name = "kcmbMessageBoxButtons";
            this.kcmbMessageBoxButtons.Size = new System.Drawing.Size(285, 21);
            this.kcmbMessageBoxButtons.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbMessageBoxButtons.TabIndex = 0;
            // 
            // MemoryBoxExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 344);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "MemoryBoxExample";
            this.Text = "MemoryBoxExample";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxIcon.Panel)).EndInit();
            this.groupBoxIcon.Panel.ResumeLayout(false);
            this.groupBoxIcon.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxIcon)).EndInit();
            this.groupBoxIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbMemoryBoxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonThemeComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbMessageBoxButtons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonButton kbtnShow;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kmbFillText;
        private KryptonTextBox ktxtMessageContent;
        private KryptonLabel kryptonLabel2;
        private KryptonTextBox ktxtCaption;
        private KryptonLabel kryptonLabel1;
        private KryptonGroupBox groupBoxIcon;
        private KryptonTextBox kryptonTextBox1;
        private ButtonSpecAny bsaBrowse;
        private KryptonComboBox kcmbMemoryBoxIcon;
        private KryptonThemeComboBox kryptonThemeComboBox1;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonComboBox kcmbMessageBoxButtons;
    }
}