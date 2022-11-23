namespace Krypton.Toolkit.Suite.Extended.Dialogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonInputBoxExtendedForm));
            this._panelMessage = new Krypton.Toolkit.KryptonPanel();
            this.ktlpContents = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            this.kpnlInput = new Krypton.Toolkit.KryptonPanel();
            this.ktxtInput = new Krypton.Toolkit.KryptonTextBox();
            this.kdtpInput = new Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonTableLayoutPanel1 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnActiveButton = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel3 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel4 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kpnlPrompt = new Krypton.Toolkit.KryptonPanel();
            this.kwlPrompt = new Krypton.Toolkit.KryptonWrapLabel();
            ((System.ComponentModel.ISupportInitialize)(this._panelMessage)).BeginInit();
            this._panelMessage.SuspendLayout();
            this.ktlpContents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlInput)).BeginInit();
            this.kpnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.kryptonTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel4)).BeginInit();
            this.kryptonPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlPrompt)).BeginInit();
            this.kpnlPrompt.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panelMessage
            // 
            this._panelMessage.Controls.Add(this.ktlpContents);
            this._panelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelMessage.Location = new System.Drawing.Point(0, 0);
            this._panelMessage.Name = "_panelMessage";
            this._panelMessage.Size = new System.Drawing.Size(350, 106);
            this._panelMessage.TabIndex = 2;
            // 
            // ktlpContents
            // 
            this.ktlpContents.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ktlpContents.BackgroundImage")));
            this.ktlpContents.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ktlpContents.ColumnCount = 2;
            this.ktlpContents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ktlpContents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ktlpContents.Controls.Add(this.pbxIcon, 0, 0);
            this.ktlpContents.Controls.Add(this.kpnlInput, 0, 1);
            this.ktlpContents.Controls.Add(this.kryptonPanel1, 1, 1);
            this.ktlpContents.Controls.Add(this.kpnlPrompt, 1, 0);
            this.ktlpContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktlpContents.Location = new System.Drawing.Point(0, 0);
            this.ktlpContents.Name = "ktlpContents";
            this.ktlpContents.RowCount = 3;
            this.ktlpContents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ktlpContents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ktlpContents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ktlpContents.Size = new System.Drawing.Size(350, 106);
            this.ktlpContents.TabIndex = 0;
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcon.Location = new System.Drawing.Point(3, 3);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(32, 29);
            this.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxIcon.TabIndex = 0;
            this.pbxIcon.TabStop = false;
            // 
            // kpnlInput
            // 
            this.ktlpContents.SetColumnSpan(this.kpnlInput, 2);
            this.kpnlInput.Controls.Add(this.ktxtInput);
            this.kpnlInput.Controls.Add(this.kdtpInput);
            this.kpnlInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlInput.Location = new System.Drawing.Point(3, 38);
            this.kpnlInput.Name = "kpnlInput";
            this.kpnlInput.Size = new System.Drawing.Size(344, 29);
            this.kpnlInput.TabIndex = 3;
            // 
            // ktxtInput
            // 
            this.ktxtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktxtInput.Location = new System.Drawing.Point(0, 0);
            this.ktxtInput.Name = "ktxtInput";
            this.ktxtInput.Size = new System.Drawing.Size(344, 23);
            this.ktxtInput.TabIndex = 1;
            // 
            // kdtpInput
            // 
            this.kdtpInput.CornerRoundingRadius = -1F;
            this.kdtpInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kdtpInput.Location = new System.Drawing.Point(0, 0);
            this.kdtpInput.Name = "kdtpInput";
            this.kdtpInput.Size = new System.Drawing.Size(344, 29);
            this.kdtpInput.TabIndex = 0;
            // 
            // kryptonPanel1
            // 
            this.ktlpContents.SetColumnSpan(this.kryptonPanel1, 2);
            this.kryptonPanel1.Controls.Add(this.kryptonTableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(3, 73);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(344, 30);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // kryptonTableLayoutPanel1
            // 
            this.kryptonTableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonTableLayoutPanel1.BackgroundImage")));
            this.kryptonTableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.kryptonTableLayoutPanel1.ColumnCount = 3;
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonBorderEdge1, 0, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonPanel2, 0, 1);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonPanel3, 2, 1);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonPanel4, 1, 1);
            this.kryptonTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel1.Name = "kryptonTableLayoutPanel1";
            this.kryptonTableLayoutPanel1.RowCount = 2;
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.Size = new System.Drawing.Size(344, 30);
            this.kryptonTableLayoutPanel1.TabIndex = 0;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kryptonBorderEdge1, 3);
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(3, 3);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(338, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnActiveButton);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(3, 10);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(100, 17);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kbtnActiveButton
            // 
            this.kbtnActiveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnActiveButton.CornerRoundingRadius = -1F;
            this.kbtnActiveButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.kbtnActiveButton.Enabled = false;
            this.kbtnActiveButton.Location = new System.Drawing.Point(0, 0);
            this.kbtnActiveButton.Name = "kbtnActiveButton";
            this.kbtnActiveButton.Size = new System.Drawing.Size(90, 17);
            this.kbtnActiveButton.TabIndex = 0;
            this.kbtnActiveButton.Values.Text = "kryptonButton1";
            this.kbtnActiveButton.Visible = false;
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.kbtnCancel);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(215, 10);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(126, 17);
            this.kryptonPanel3.TabIndex = 2;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.CornerRoundingRadius = -1F;
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnCancel.Location = new System.Drawing.Point(0, 0);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(126, 17);
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "Cance&l";
            // 
            // kryptonPanel4
            // 
            this.kryptonPanel4.Controls.Add(this.kbtnOk);
            this.kryptonPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel4.Location = new System.Drawing.Point(109, 10);
            this.kryptonPanel4.Name = "kryptonPanel4";
            this.kryptonPanel4.Size = new System.Drawing.Size(100, 17);
            this.kryptonPanel4.TabIndex = 3;
            // 
            // kbtnOk
            // 
            this.kbtnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnOk.CornerRoundingRadius = -1F;
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.kbtnOk.Location = new System.Drawing.Point(10, 0);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 17);
            this.kbtnOk.TabIndex = 0;
            this.kbtnOk.Values.Text = "O&K";
            // 
            // kpnlPrompt
            // 
            this.kpnlPrompt.Controls.Add(this.kwlPrompt);
            this.kpnlPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlPrompt.Location = new System.Drawing.Point(41, 3);
            this.kpnlPrompt.Name = "kpnlPrompt";
            this.kpnlPrompt.Size = new System.Drawing.Size(306, 29);
            this.kpnlPrompt.TabIndex = 4;
            // 
            // kwlPrompt
            // 
            this.kwlPrompt.AutoSize = false;
            this.kwlPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlPrompt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.kwlPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlPrompt.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kwlPrompt.Location = new System.Drawing.Point(0, 0);
            this.kwlPrompt.Name = "kwlPrompt";
            this.kwlPrompt.Size = new System.Drawing.Size(306, 29);
            this.kwlPrompt.Text = "Prompt";
            this.kwlPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KryptonInputBoxExtendedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 106);
            this.Controls.Add(this._panelMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonInputBoxExtendedForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this._panelMessage)).EndInit();
            this._panelMessage.ResumeLayout(false);
            this.ktlpContents.ResumeLayout(false);
            this.ktlpContents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlInput)).EndInit();
            this.kpnlInput.ResumeLayout(false);
            this.kpnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel4)).EndInit();
            this.kryptonPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlPrompt)).EndInit();
            this.kpnlPrompt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel _panelMessage;
        private KryptonTableLayoutPanel ktlpContents;
        private PictureBox pbxIcon;
        private KryptonPanel kpnlInput;
        private KryptonTextBox ktxtInput;
        private KryptonDateTimePicker kdtpInput;
        private KryptonPanel kryptonPanel1;
        private KryptonPanel kpnlPrompt;
        private KryptonWrapLabel kwlPrompt;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonPanel kryptonPanel3;
        private KryptonButton kbtnCancel;
        private KryptonPanel kryptonPanel4;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnActiveButton;
    }
}