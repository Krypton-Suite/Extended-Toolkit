namespace Krypton.Toolkit.Suite.Extended.InputBox
{
    partial class KryptonInputBoxExtendedForm
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
            this.kpnlMain = new Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            this.kwlPrompt = new Krypton.Toolkit.KryptonWrapLabel();
            this.kpnlResponse = new Krypton.Toolkit.KryptonPanel();
            this.kcmbResponse = new Krypton.Toolkit.KryptonComboBox();
            this.kdtpResponse = new Krypton.Toolkit.KryptonDateTimePicker();
            this.kdudResponse = new Krypton.Toolkit.KryptonDomainUpDown();
            this.kmtxtResponse = new Krypton.Toolkit.KryptonMaskedTextBox();
            this.knudResponse = new Krypton.Toolkit.KryptonNumericUpDown();
            this.krtbResponse = new Krypton.Toolkit.KryptonRichTextBox();
            this.ktxtResponse = new Krypton.Toolkit.KryptonTextBox();
            this.kbeSplitter = new Krypton.Toolkit.KryptonBorderEdge();
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.kbtnButtonThree = new Krypton.Toolkit.KryptonButton();
            this.kbtnButtonTwo = new Krypton.Toolkit.KryptonButton();
            this.kbtnInputBoxActionButton = new Krypton.Toolkit.KryptonButton();
            this.kbtnButtonOne = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).BeginInit();
            this.kpnlMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlResponse)).BeginInit();
            this.kpnlResponse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbResponse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // kpnlMain
            // 
            this.kpnlMain.Controls.Add(this.tableLayoutPanel1);
            this.kpnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlMain.Location = new System.Drawing.Point(0, 0);
            this.kpnlMain.Name = "kpnlMain";
            this.kpnlMain.Size = new System.Drawing.Size(350, 109);
            this.kpnlMain.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pbxIcon, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.kwlPrompt, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.kpnlResponse, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.kbeSplitter, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.kpnlButtons, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(350, 109);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pbxIcon
            // 
            this.pbxIcon.Location = new System.Drawing.Point(3, 3);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(64, 28);
            this.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxIcon.TabIndex = 0;
            this.pbxIcon.TabStop = false;
            // 
            // kwlPrompt
            // 
            this.kwlPrompt.AutoSize = false;
            this.kwlPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlPrompt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.kwlPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlPrompt.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kwlPrompt.Location = new System.Drawing.Point(73, 0);
            this.kwlPrompt.Name = "kwlPrompt";
            this.kwlPrompt.Size = new System.Drawing.Size(274, 34);
            this.kwlPrompt.Text = "kryptonWrapLabel1";
            this.kwlPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kpnlResponse
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.kpnlResponse, 2);
            this.kpnlResponse.Controls.Add(this.ktxtResponse);
            this.kpnlResponse.Controls.Add(this.krtbResponse);
            this.kpnlResponse.Controls.Add(this.knudResponse);
            this.kpnlResponse.Controls.Add(this.kmtxtResponse);
            this.kpnlResponse.Controls.Add(this.kdudResponse);
            this.kpnlResponse.Controls.Add(this.kdtpResponse);
            this.kpnlResponse.Controls.Add(this.kcmbResponse);
            this.kpnlResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlResponse.Location = new System.Drawing.Point(3, 37);
            this.kpnlResponse.Name = "kpnlResponse";
            this.kpnlResponse.Size = new System.Drawing.Size(344, 28);
            this.kpnlResponse.TabIndex = 2;
            // 
            // kcmbResponse
            // 
            this.kcmbResponse.CornerRoundingRadius = -1F;
            this.kcmbResponse.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.kcmbResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kcmbResponse.DropDownWidth = 344;
            this.kcmbResponse.IntegralHeight = false;
            this.kcmbResponse.Location = new System.Drawing.Point(0, 0);
            this.kcmbResponse.Name = "kcmbResponse";
            this.kcmbResponse.Size = new System.Drawing.Size(344, 21);
            this.kcmbResponse.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbResponse.TabIndex = 0;
            // 
            // kdtpResponse
            // 
            this.kdtpResponse.CornerRoundingRadius = -1F;
            this.kdtpResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kdtpResponse.Location = new System.Drawing.Point(0, 0);
            this.kdtpResponse.Name = "kdtpResponse";
            this.kdtpResponse.Size = new System.Drawing.Size(344, 21);
            this.kdtpResponse.TabIndex = 1;
            // 
            // kdudResponse
            // 
            this.kdudResponse.CornerRoundingRadius = -1F;
            this.kdudResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kdudResponse.Location = new System.Drawing.Point(0, 0);
            this.kdudResponse.Name = "kdudResponse";
            this.kdudResponse.Size = new System.Drawing.Size(344, 22);
            this.kdudResponse.TabIndex = 2;
            this.kdudResponse.Text = "kryptonDomainUpDown1";
            // 
            // kmtxtResponse
            // 
            this.kmtxtResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kmtxtResponse.Location = new System.Drawing.Point(0, 0);
            this.kmtxtResponse.Name = "kmtxtResponse";
            this.kmtxtResponse.Size = new System.Drawing.Size(344, 23);
            this.kmtxtResponse.TabIndex = 3;
            this.kmtxtResponse.Text = "kryptonMaskedTextBox1";
            // 
            // knudResponse
            // 
            this.knudResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knudResponse.Location = new System.Drawing.Point(0, 0);
            this.knudResponse.Name = "knudResponse";
            this.knudResponse.Size = new System.Drawing.Size(344, 22);
            this.knudResponse.TabIndex = 4;
            // 
            // krtbResponse
            // 
            this.krtbResponse.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.krtbResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krtbResponse.Location = new System.Drawing.Point(0, 0);
            this.krtbResponse.Name = "krtbResponse";
            this.krtbResponse.Size = new System.Drawing.Size(344, 28);
            this.krtbResponse.TabIndex = 5;
            this.krtbResponse.Text = "kryptonRichTextBox1";
            // 
            // ktxtResponse
            // 
            this.ktxtResponse.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.ktxtResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktxtResponse.Location = new System.Drawing.Point(0, 0);
            this.ktxtResponse.Name = "ktxtResponse";
            this.ktxtResponse.Size = new System.Drawing.Size(344, 23);
            this.ktxtResponse.TabIndex = 6;
            this.ktxtResponse.Text = "kryptonTextBox1";
            // 
            // kbeSplitter
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.kbeSplitter, 2);
            this.kbeSplitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.kbeSplitter.Location = new System.Drawing.Point(3, 71);
            this.kbeSplitter.Name = "kbeSplitter";
            this.kbeSplitter.Size = new System.Drawing.Size(344, 1);
            this.kbeSplitter.Text = "kryptonBorderEdge1";
            // 
            // kpnlButtons
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.kpnlButtons, 2);
            this.kpnlButtons.Controls.Add(this.kbtnInputBoxActionButton);
            this.kpnlButtons.Controls.Add(this.kbtnButtonOne);
            this.kpnlButtons.Controls.Add(this.kbtnButtonTwo);
            this.kpnlButtons.Controls.Add(this.kbtnButtonThree);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlButtons.Location = new System.Drawing.Point(3, 78);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.Size = new System.Drawing.Size(344, 28);
            this.kpnlButtons.TabIndex = 4;
            // 
            // kbtnButtonThree
            // 
            this.kbtnButtonThree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnButtonThree.AutoSize = true;
            this.kbtnButtonThree.CornerRoundingRadius = -1F;
            this.kbtnButtonThree.Location = new System.Drawing.Point(280, 1);
            this.kbtnButtonThree.MinimumSize = new System.Drawing.Size(50, 26);
            this.kbtnButtonThree.Name = "kbtnButtonThree";
            this.kbtnButtonThree.Size = new System.Drawing.Size(55, 26);
            this.kbtnButtonThree.TabIndex = 0;
            this.kbtnButtonThree.Values.Text = "{0}";
            // 
            // kbtnButtonTwo
            // 
            this.kbtnButtonTwo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnButtonTwo.AutoSize = true;
            this.kbtnButtonTwo.CornerRoundingRadius = -1F;
            this.kbtnButtonTwo.Location = new System.Drawing.Point(219, 1);
            this.kbtnButtonTwo.MinimumSize = new System.Drawing.Size(50, 26);
            this.kbtnButtonTwo.Name = "kbtnButtonTwo";
            this.kbtnButtonTwo.Size = new System.Drawing.Size(55, 26);
            this.kbtnButtonTwo.TabIndex = 1;
            this.kbtnButtonTwo.Values.Text = "{0}";
            // 
            // kbtnInputBoxActionButton
            // 
            this.kbtnInputBoxActionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnInputBoxActionButton.AutoSize = true;
            this.kbtnInputBoxActionButton.CornerRoundingRadius = -1F;
            this.kbtnInputBoxActionButton.Location = new System.Drawing.Point(9, 1);
            this.kbtnInputBoxActionButton.Name = "kbtnInputBoxActionButton";
            this.kbtnInputBoxActionButton.Size = new System.Drawing.Size(90, 25);
            this.kbtnInputBoxActionButton.TabIndex = 2;
            this.kbtnInputBoxActionButton.Values.Text = "{0}";
            this.kbtnInputBoxActionButton.Visible = false;
            // 
            // kbtnButtonOne
            // 
            this.kbtnButtonOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnButtonOne.AutoSize = true;
            this.kbtnButtonOne.CornerRoundingRadius = -1F;
            this.kbtnButtonOne.Location = new System.Drawing.Point(158, 1);
            this.kbtnButtonOne.MinimumSize = new System.Drawing.Size(50, 26);
            this.kbtnButtonOne.Name = "kbtnButtonOne";
            this.kbtnButtonOne.Size = new System.Drawing.Size(55, 26);
            this.kbtnButtonOne.TabIndex = 3;
            this.kbtnButtonOne.Values.Text = "{0}";
            this.kbtnButtonOne.Visible = false;
            // 
            // KryptonInputBoxExtendedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 109);
            this.Controls.Add(this.kpnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonInputBoxExtendedForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).EndInit();
            this.kpnlMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlResponse)).EndInit();
            this.kpnlResponse.ResumeLayout(false);
            this.kpnlResponse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbResponse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            this.kpnlButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kpnlMain;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pbxIcon;
        private KryptonWrapLabel kwlPrompt;
        private KryptonPanel kpnlResponse;
        private KryptonComboBox kcmbResponse;
        private KryptonDateTimePicker kdtpResponse;
        private KryptonDomainUpDown kdudResponse;
        private KryptonMaskedTextBox kmtxtResponse;
        private KryptonNumericUpDown knudResponse;
        private KryptonRichTextBox krtbResponse;
        private KryptonTextBox ktxtResponse;
        private KryptonBorderEdge kbeSplitter;
        private KryptonPanel kpnlButtons;
        private KryptonButton kbtnButtonThree;
        private KryptonButton kbtnInputBoxActionButton;
        private KryptonButton kbtnButtonTwo;
        private KryptonButton kbtnButtonOne;
    }
}