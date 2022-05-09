namespace Krypton.Toolkit.Suite.Extended.Toast
{
    partial class BasicNotificationWithUserResponseWrappedLabel
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
            this.kpnlContent = new Krypton.Toolkit.KryptonPanel();
            this.kwlContent = new Krypton.Toolkit.KryptonWrapLabel();
            this.ktxtUserResponse = new Krypton.Toolkit.KryptonTextBox();
            this.kwlTitle = new Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnDismiss = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.pbxToastImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).BeginInit();
            this.kpnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxToastImage)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlContent
            // 
            this.kpnlContent.Controls.Add(this.kwlContent);
            this.kpnlContent.Controls.Add(this.ktxtUserResponse);
            this.kpnlContent.Controls.Add(this.kwlTitle);
            this.kpnlContent.Controls.Add(this.pbxToastImage);
            this.kpnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlContent.Location = new System.Drawing.Point(0, 0);
            this.kpnlContent.Name = "kpnlContent";
            this.kpnlContent.Size = new System.Drawing.Size(609, 277);
            this.kpnlContent.TabIndex = 5;
            // 
            // kwlContent
            // 
            this.kwlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kwlContent.AutoSize = false;
            this.kwlContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlContent.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlContent.Location = new System.Drawing.Point(146, 90);
            this.kwlContent.Name = "kwlContent";
            this.kwlContent.Size = new System.Drawing.Size(451, 154);
            this.kwlContent.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlContent.Text = "{0}";
            this.kwlContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ktxtUserResponse
            // 
            this.ktxtUserResponse.Location = new System.Drawing.Point(146, 247);
            this.ktxtUserResponse.Name = "ktxtUserResponse";
            this.ktxtUserResponse.Size = new System.Drawing.Size(451, 23);
            this.ktxtUserResponse.TabIndex = 3;
            // 
            // kwlTitle
            // 
            this.kwlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kwlTitle.AutoSize = false;
            this.kwlTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlTitle.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlTitle.Location = new System.Drawing.Point(146, 12);
            this.kwlTitle.Name = "kwlTitle";
            this.kwlTitle.Size = new System.Drawing.Size(451, 74);
            this.kwlTitle.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlTitle.Text = "{0}";
            this.kwlTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnDismiss);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 277);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(609, 50);
            this.kryptonPanel1.TabIndex = 4;
            // 
            // kbtnDismiss
            // 
            this.kbtnDismiss.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnDismiss.Location = new System.Drawing.Point(423, 13);
            this.kbtnDismiss.Name = "kbtnDismiss";
            this.kbtnDismiss.Size = new System.Drawing.Size(174, 25);
            this.kbtnDismiss.TabIndex = 1;
            this.kbtnDismiss.Values.Text = "{0} ({1})";
            this.kbtnDismiss.Click += new System.EventHandler(this.kbtnDismiss_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(609, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // pbxToastImage
            // 
            this.pbxToastImage.BackColor = System.Drawing.Color.Transparent;
            this.pbxToastImage.Location = new System.Drawing.Point(12, 12);
            this.pbxToastImage.Name = "pbxToastImage";
            this.pbxToastImage.Size = new System.Drawing.Size(128, 128);
            this.pbxToastImage.TabIndex = 1;
            this.pbxToastImage.TabStop = false;
            // 
            // BasicNotificationWithUserResponseWrappedLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 327);
            this.Controls.Add(this.kpnlContent);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BasicNotificationWithUserResponseWrappedLabel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.BasicNotificationWithUserResponseWrappedLabel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).EndInit();
            this.kpnlContent.ResumeLayout(false);
            this.kpnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxToastImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kpnlContent;
        private KryptonWrapLabel kwlContent;
        private KryptonTextBox ktxtUserResponse;
        private KryptonWrapLabel kwlTitle;
        private PictureBox pbxToastImage;
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnDismiss;
        private KryptonBorderEdge kryptonBorderEdge1;
    }
}