#region MIT License

/*
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoryBoxExample));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnShow = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonGroupBox2 = new Krypton.Toolkit.KryptonGroupBox();
            this.kwlMemoryBoxResult = new Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kcmbMemoryBoxDefaultDialogResult = new Krypton.Toolkit.KryptonComboBox();
            this.kcmbMemoryBoxDefaultButton = new Krypton.Toolkit.KryptonComboBox();
            this.groupBoxIcon = new Krypton.Toolkit.KryptonGroupBox();
            this.ktxtCustomIconPath = new Krypton.Toolkit.KryptonTextBox();
            this.bsaBrowse = new Krypton.Toolkit.ButtonSpecAny();
            this.kcmbMessageBoxIcon = new Krypton.Toolkit.KryptonComboBox();
            this.ktxtMessageContent = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtTitle = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnDummyText = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbMemoryBoxDefaultDialogResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbMemoryBoxDefaultButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxIcon.Panel)).BeginInit();
            this.groupBoxIcon.Panel.SuspendLayout();
            this.groupBoxIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbMessageBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnDummyText);
            this.kryptonPanel1.Controls.Add(this.kbtnShow);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 609);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(1406, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnShow
            // 
            this.kbtnShow.Location = new System.Drawing.Point(1304, 13);
            this.kbtnShow.Name = "kbtnShow";
            this.kbtnShow.Size = new System.Drawing.Size(90, 25);
            this.kbtnShow.TabIndex = 1;
            this.kbtnShow.Values.Text = "&Show";
            this.kbtnShow.Click += new System.EventHandler(this.kbtnShow_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(1406, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox2);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel2.Controls.Add(this.groupBoxIcon);
            this.kryptonPanel2.Controls.Add(this.ktxtMessageContent);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.ktxtTitle);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(1406, 609);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(403, 154);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.kwlMemoryBoxResult);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(475, 119);
            this.kryptonGroupBox2.TabIndex = 15;
            this.kryptonGroupBox2.Values.Heading = "Result";
            // 
            // kwlMemoryBoxResult
            // 
            this.kwlMemoryBoxResult.AutoSize = false;
            this.kwlMemoryBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlMemoryBoxResult.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.kwlMemoryBoxResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlMemoryBoxResult.LabelStyle = Krypton.Toolkit.LabelStyle.TitleControl;
            this.kwlMemoryBoxResult.Location = new System.Drawing.Point(0, 0);
            this.kwlMemoryBoxResult.Name = "kwlMemoryBoxResult";
            this.kwlMemoryBoxResult.Size = new System.Drawing.Size(471, 95);
            this.kwlMemoryBoxResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(402, 12);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel3);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kcmbMemoryBoxDefaultDialogResult);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kcmbMemoryBoxDefaultButton);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(476, 135);
            this.kryptonGroupBox1.TabIndex = 14;
            this.kryptonGroupBox1.Values.Heading = "Buttons";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(12, 65);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(138, 20);
            this.kryptonLabel4.TabIndex = 6;
            this.kryptonLabel4.Values.Text = "Default Dialog Result:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(13, 14);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(100, 20);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "Default Button:";
            // 
            // kcmbMemoryBoxDefaultDialogResult
            // 
            this.kcmbMemoryBoxDefaultDialogResult.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.kcmbMemoryBoxDefaultDialogResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbMemoryBoxDefaultDialogResult.DropDownWidth = 256;
            this.kcmbMemoryBoxDefaultDialogResult.IntegralHeight = false;
            this.kcmbMemoryBoxDefaultDialogResult.Location = new System.Drawing.Point(147, 65);
            this.kcmbMemoryBoxDefaultDialogResult.Name = "kcmbMemoryBoxDefaultDialogResult";
            this.kcmbMemoryBoxDefaultDialogResult.Size = new System.Drawing.Size(312, 21);
            this.kcmbMemoryBoxDefaultDialogResult.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbMemoryBoxDefaultDialogResult.TabIndex = 1;
            this.kcmbMemoryBoxDefaultDialogResult.SelectedIndexChanged += new System.EventHandler(this.kcmbMemoryBoxDefaultDialogResult_SelectedIndexChanged);
            // 
            // kcmbMemoryBoxDefaultButton
            // 
            this.kcmbMemoryBoxDefaultButton.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.kcmbMemoryBoxDefaultButton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbMemoryBoxDefaultButton.DropDownWidth = 256;
            this.kcmbMemoryBoxDefaultButton.IntegralHeight = false;
            this.kcmbMemoryBoxDefaultButton.Location = new System.Drawing.Point(147, 14);
            this.kcmbMemoryBoxDefaultButton.Name = "kcmbMemoryBoxDefaultButton";
            this.kcmbMemoryBoxDefaultButton.Size = new System.Drawing.Size(312, 21);
            this.kcmbMemoryBoxDefaultButton.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbMemoryBoxDefaultButton.TabIndex = 0;
            this.kcmbMemoryBoxDefaultButton.SelectedIndexChanged += new System.EventHandler(this.kcmbMemoryBoxDefaultButton_SelectedIndexChanged);
            // 
            // groupBoxIcon
            // 
            this.groupBoxIcon.Location = new System.Drawing.Point(111, 181);
            this.groupBoxIcon.Name = "groupBoxIcon";
            // 
            // groupBoxIcon.Panel
            // 
            this.groupBoxIcon.Panel.Controls.Add(this.ktxtCustomIconPath);
            this.groupBoxIcon.Panel.Controls.Add(this.kcmbMessageBoxIcon);
            this.groupBoxIcon.Size = new System.Drawing.Size(285, 92);
            this.groupBoxIcon.TabIndex = 13;
            this.groupBoxIcon.Values.Heading = "Icon";
            // 
            // ktxtCustomIconPath
            // 
            this.ktxtCustomIconPath.ButtonSpecs.Add(this.bsaBrowse);
            this.ktxtCustomIconPath.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.ktxtCustomIconPath.Enabled = false;
            this.ktxtCustomIconPath.Location = new System.Drawing.Point(12, 35);
            this.ktxtCustomIconPath.Name = "ktxtCustomIconPath";
            this.ktxtCustomIconPath.Size = new System.Drawing.Size(256, 24);
            this.ktxtCustomIconPath.TabIndex = 1;
            this.ktxtCustomIconPath.TextChanged += new System.EventHandler(this.ktxtCustomIconPath_TextChanged);
            // 
            // bsaBrowse
            // 
            this.bsaBrowse.Text = "...";
            this.bsaBrowse.UniqueName = "4d6b53a8282b4b7c9a9852c651792c06";
            this.bsaBrowse.Click += new System.EventHandler(this.bsaBrowse_Click);
            // 
            // kcmbMessageBoxIcon
            // 
            this.kcmbMessageBoxIcon.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.kcmbMessageBoxIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbMessageBoxIcon.DropDownWidth = 256;
            this.kcmbMessageBoxIcon.IntegralHeight = false;
            this.kcmbMessageBoxIcon.Location = new System.Drawing.Point(12, 10);
            this.kcmbMessageBoxIcon.Name = "kcmbMessageBoxIcon";
            this.kcmbMessageBoxIcon.Size = new System.Drawing.Size(256, 21);
            this.kcmbMessageBoxIcon.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbMessageBoxIcon.TabIndex = 0;
            this.kcmbMessageBoxIcon.SelectedIndexChanged += new System.EventHandler(this.kcmbMessageBoxIcon_SelectedIndexChanged);
            // 
            // ktxtMessageContent
            // 
            this.ktxtMessageContent.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.ktxtMessageContent.Location = new System.Drawing.Point(111, 38);
            this.ktxtMessageContent.Multiline = true;
            this.ktxtMessageContent.Name = "ktxtMessageContent";
            this.ktxtMessageContent.Size = new System.Drawing.Size(285, 137);
            this.ktxtMessageContent.TabIndex = 7;
            this.ktxtMessageContent.Text = "This is a example of a KryptonMemoryBox.";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 38);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(93, 20);
            this.kryptonLabel2.TabIndex = 6;
            this.kryptonLabel2.Values.Text = "Message Text:";
            // 
            // ktxtTitle
            // 
            this.ktxtTitle.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.ktxtTitle.Location = new System.Drawing.Point(111, 12);
            this.ktxtTitle.Name = "ktxtTitle";
            this.ktxtTitle.Size = new System.Drawing.Size(285, 23);
            this.ktxtTitle.TabIndex = 5;
            this.ktxtTitle.Text = "Example Menory Box";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(40, 20);
            this.kryptonLabel1.TabIndex = 4;
            this.kryptonLabel1.Values.Text = "Title:";
            // 
            // kbtnDummyText
            // 
            this.kbtnDummyText.Location = new System.Drawing.Point(12, 13);
            this.kbtnDummyText.Name = "kbtnDummyText";
            this.kbtnDummyText.Size = new System.Drawing.Size(153, 25);
            this.kbtnDummyText.TabIndex = 3;
            this.kbtnDummyText.Values.Text = "I&nsert Dummy Text";
            this.kbtnDummyText.Click += new System.EventHandler(this.kbtnDummyText_Click);
            // 
            // MemoryBoxExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 659);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MemoryBoxExample";
            this.Text = "MemoryBoxExample";
            this.Load += new System.EventHandler(this.MemoryBoxExample_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbMemoryBoxDefaultDialogResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbMemoryBoxDefaultButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxIcon.Panel)).EndInit();
            this.groupBoxIcon.Panel.ResumeLayout(false);
            this.groupBoxIcon.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBoxIcon)).EndInit();
            this.groupBoxIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbMessageBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnShow;
        private KryptonTextBox ktxtMessageContent;
        private KryptonLabel kryptonLabel2;
        private KryptonTextBox ktxtTitle;
        private KryptonLabel kryptonLabel1;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonComboBox kcmbMemoryBoxDefaultButton;
        private KryptonGroupBox groupBoxIcon;
        private KryptonTextBox ktxtCustomIconPath;
        private ButtonSpecAny bsaBrowse;
        private KryptonComboBox kcmbMessageBoxIcon;
        private KryptonGroupBox kryptonGroupBox2;
        private KryptonWrapLabel kwlMemoryBoxResult;
        private KryptonComboBox kcmbMemoryBoxDefaultDialogResult;
        private KryptonLabel kryptonLabel3;
        private KryptonLabel kryptonLabel4;
        private KryptonButton kbtnDummyText;
    }
}