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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonInputBoxExtendedForm));
            this._panelMessage = new Krypton.Toolkit.KryptonPanel();
            this.kryptonTableLayoutPanel1 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            this._labelPrompt = new Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this._kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this._buttonOk = new Krypton.Toolkit.KryptonButton();
            this._buttonCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kdtpResponse = new Krypton.Toolkit.KryptonDateTimePicker();
            this.kmtxResponse = new Krypton.Toolkit.KryptonMaskedTextBox();
            this.krtbResponse = new Krypton.Toolkit.KryptonRichTextBox();
            this.ktxtResponse = new Krypton.Toolkit.KryptonTextBox();
            this.kbtnActionButton = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this._panelMessage)).BeginInit();
            this._panelMessage.SuspendLayout();
            this.kryptonTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._kryptonPanel1)).BeginInit();
            this._kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panelMessage
            // 
            this._panelMessage.Controls.Add(this.kryptonTableLayoutPanel1);
            this._panelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelMessage.Location = new System.Drawing.Point(0, 0);
            this._panelMessage.Name = "_panelMessage";
            this._panelMessage.Size = new System.Drawing.Size(350, 109);
            this._panelMessage.TabIndex = 2;
            // 
            // kryptonTableLayoutPanel1
            // 
            this.kryptonTableLayoutPanel1.AutoSize = true;
            this.kryptonTableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonTableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonTableLayoutPanel1.BackgroundImage")));
            this.kryptonTableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.kryptonTableLayoutPanel1.ColumnCount = 2;
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.Controls.Add(this._labelPrompt, 1, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.pbxIcon, 0, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonPanel1, 0, 1);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonBorderEdge1, 0, 2);
            this.kryptonTableLayoutPanel1.Controls.Add(this._kryptonPanel1, 0, 3);
            this.kryptonTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel1.Name = "kryptonTableLayoutPanel1";
            this.kryptonTableLayoutPanel1.RowCount = 4;
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.kryptonTableLayoutPanel1.Size = new System.Drawing.Size(350, 109);
            this.kryptonTableLayoutPanel1.TabIndex = 3;
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxIcon.Location = new System.Drawing.Point(3, 3);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(32, 34);
            this.pbxIcon.TabIndex = 0;
            this.pbxIcon.TabStop = false;
            // 
            // _labelPrompt
            // 
            this._labelPrompt.AutoSize = false;
            this._labelPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this._labelPrompt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._labelPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this._labelPrompt.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this._labelPrompt.Location = new System.Drawing.Point(42, 4);
            this._labelPrompt.Margin = new System.Windows.Forms.Padding(4);
            this._labelPrompt.Name = "_labelPrompt";
            this._labelPrompt.Size = new System.Drawing.Size(304, 32);
            this._labelPrompt.Text = "Prompt";
            this._labelPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kryptonBorderEdge1, 2);
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(3, 76);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(344, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // _kryptonPanel1
            // 
            this.kryptonTableLayoutPanel1.SetColumnSpan(this._kryptonPanel1, 2);
            this._kryptonPanel1.Controls.Add(this.kbtnActionButton);
            this._kryptonPanel1.Controls.Add(this._buttonOk);
            this._kryptonPanel1.Controls.Add(this._buttonCancel);
            this._kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._kryptonPanel1.Location = new System.Drawing.Point(2, 82);
            this._kryptonPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 8);
            this._kryptonPanel1.Name = "_kryptonPanel1";
            this._kryptonPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this._kryptonPanel1.Size = new System.Drawing.Size(346, 26);
            this._kryptonPanel1.TabIndex = 6;
            // 
            // _buttonOk
            // 
            this._buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonOk.AutoSize = true;
            this._buttonOk.CornerRoundingRadius = -1F;
            this._buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._buttonOk.Location = new System.Drawing.Point(213, 0);
            this._buttonOk.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this._buttonOk.MinimumSize = new System.Drawing.Size(50, 26);
            this._buttonOk.Name = "_buttonOk";
            this._buttonOk.Size = new System.Drawing.Size(55, 26);
            this._buttonOk.TabIndex = 1;
            this._buttonOk.Values.Text = "&OK";
            // 
            // _buttonCancel
            // 
            this._buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonCancel.AutoSize = true;
            this._buttonCancel.CornerRoundingRadius = -1F;
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(285, 0);
            this._buttonCancel.Margin = new System.Windows.Forms.Padding(0);
            this._buttonCancel.MinimumSize = new System.Drawing.Size(50, 26);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(55, 26);
            this._buttonCancel.TabIndex = 2;
            this._buttonCancel.Values.Text = "Cance&l";
            // 
            // kryptonPanel1
            // 
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kryptonPanel1, 2);
            this.kryptonPanel1.Controls.Add(this.ktxtResponse);
            this.kryptonPanel1.Controls.Add(this.krtbResponse);
            this.kryptonPanel1.Controls.Add(this.kmtxResponse);
            this.kryptonPanel1.Controls.Add(this.kdtpResponse);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(3, 43);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(344, 27);
            this.kryptonPanel1.TabIndex = 7;
            // 
            // kdtpResponse
            // 
            this.kdtpResponse.CornerRoundingRadius = -1F;
            this.kdtpResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kdtpResponse.Location = new System.Drawing.Point(0, 0);
            this.kdtpResponse.Name = "kdtpResponse";
            this.kdtpResponse.Size = new System.Drawing.Size(344, 27);
            this.kdtpResponse.TabIndex = 0;
            this.kdtpResponse.ValueNullable = new System.DateTime(((long)(0)));
            this.kdtpResponse.Visible = false;
            // 
            // kmtxResponse
            // 
            this.kmtxResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kmtxResponse.Location = new System.Drawing.Point(0, 0);
            this.kmtxResponse.Name = "kmtxResponse";
            this.kmtxResponse.Size = new System.Drawing.Size(344, 23);
            this.kmtxResponse.TabIndex = 1;
            this.kmtxResponse.Visible = false;
            // 
            // krtbResponse
            // 
            this.krtbResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krtbResponse.Location = new System.Drawing.Point(0, 0);
            this.krtbResponse.Name = "krtbResponse";
            this.krtbResponse.Size = new System.Drawing.Size(344, 27);
            this.krtbResponse.TabIndex = 2;
            this.krtbResponse.Text = "";
            this.krtbResponse.Visible = false;
            // 
            // ktxtResponse
            // 
            this.ktxtResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktxtResponse.Location = new System.Drawing.Point(0, 0);
            this.ktxtResponse.Name = "ktxtResponse";
            this.ktxtResponse.Size = new System.Drawing.Size(344, 23);
            this.ktxtResponse.TabIndex = 3;
            // 
            // kbtnActionButton
            // 
            this.kbtnActionButton.AutoSize = true;
            this.kbtnActionButton.CornerRoundingRadius = -1F;
            this.kbtnActionButton.Enabled = false;
            this.kbtnActionButton.Location = new System.Drawing.Point(7, 0);
            this.kbtnActionButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.kbtnActionButton.MinimumSize = new System.Drawing.Size(50, 26);
            this.kbtnActionButton.Name = "kbtnActionButton";
            this.kbtnActionButton.Size = new System.Drawing.Size(55, 26);
            this.kbtnActionButton.TabIndex = 3;
            this.kbtnActionButton.Values.Text = "{0}";
            this.kbtnActionButton.Visible = false;
            // 
            // KryptonInputBoxExtendedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 109);
            this.Controls.Add(this._panelMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonInputBoxExtendedForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            ((System.ComponentModel.ISupportInitialize)(this._panelMessage)).EndInit();
            this._panelMessage.ResumeLayout(false);
            this._panelMessage.PerformLayout();
            this.kryptonTableLayoutPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._kryptonPanel1)).EndInit();
            this._kryptonPanel1.ResumeLayout(false);
            this._kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel _panelMessage;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel1;
        private KryptonWrapLabel _labelPrompt;
        private PictureBox pbxIcon;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel _kryptonPanel1;
        private KryptonButton _buttonOk;
        private KryptonButton _buttonCancel;
        private KryptonPanel kryptonPanel1;
        private KryptonTextBox ktxtResponse;
        private KryptonRichTextBox krtbResponse;
        private KryptonMaskedTextBox kmtxResponse;
        private KryptonDateTimePicker kdtpResponse;
        private KryptonButton kbtnActionButton;
    }
}