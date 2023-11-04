﻿namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    partial class KryptonToastNotificationVersion2
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
            this.kbtnAction = new Krypton.Toolkit.KryptonButton();
            this.kbtnDismiss = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.pbTimeOut = new System.Windows.Forms.ProgressBar();
            this.klblHeader = new Krypton.Toolkit.KryptonLabel();
            this.kwlContent = new Krypton.Toolkit.KryptonWrapLabel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnAction);
            this.kryptonPanel1.Controls.Add(this.kbtnDismiss);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 263);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(613, 50);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnAction
            // 
            this.kbtnAction.AutoSize = true;
            this.kbtnAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnAction.Location = new System.Drawing.Point(12, 13);
            this.kbtnAction.Name = "kbtnAction";
            this.kbtnAction.Size = new System.Drawing.Size(4, 4);
            this.kbtnAction.TabIndex = 2;
            this.kbtnAction.Values.Text = "";
            this.kbtnAction.Visible = false;
            this.kbtnAction.Click += new System.EventHandler(this.kbtnAction_Click);
            // 
            // kbtnDismiss
            // 
            this.kbtnDismiss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnDismiss.Location = new System.Drawing.Point(397, 13);
            this.kbtnDismiss.Name = "kbtnDismiss";
            this.kbtnDismiss.Size = new System.Drawing.Size(204, 25);
            this.kbtnDismiss.TabIndex = 1;
            this.kbtnDismiss.Values.Text = "{0}";
            this.kbtnDismiss.Click += new System.EventHandler(this.kbtnDismiss_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(613, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.pbTimeOut);
            this.kryptonPanel2.Controls.Add(this.klblHeader);
            this.kryptonPanel2.Controls.Add(this.kwlContent);
            this.kryptonPanel2.Controls.Add(this.pbxIcon);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(613, 263);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // pbTimeOut
            // 
            this.pbTimeOut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbTimeOut.Location = new System.Drawing.Point(0, 253);
            this.pbTimeOut.Name = "pbTimeOut";
            this.pbTimeOut.Size = new System.Drawing.Size(613, 10);
            this.pbTimeOut.TabIndex = 4;
            // 
            // klblHeader
            // 
            this.klblHeader.AutoSize = false;
            this.klblHeader.LabelStyle = Krypton.Toolkit.LabelStyle.NormalPanel;
            this.klblHeader.Location = new System.Drawing.Point(145, 13);
            this.klblHeader.Name = "klblHeader";
            this.klblHeader.Size = new System.Drawing.Size(468, 67);
            this.klblHeader.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHeader.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblHeader.TabIndex = 2;
            this.klblHeader.Values.Text = "{0}";
            // 
            // kwlContent
            // 
            this.kwlContent.AutoSize = false;
            this.kwlContent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kwlContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlContent.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlContent.Location = new System.Drawing.Point(145, 83);
            this.kwlContent.Name = "kwlContent";
            this.kwlContent.Size = new System.Drawing.Size(468, 174);
            this.kwlContent.Text = "{0}";
            this.kwlContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcon.Location = new System.Drawing.Point(13, 13);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(125, 125);
            this.pbxIcon.TabIndex = 0;
            this.pbxIcon.TabStop = false;
            // 
            // KryptonToastNotificationVersion2
            // 
            this.ClientSize = new System.Drawing.Size(613, 313);
            this.ControlBox = false;
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonToastNotificationVersion2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.KryptonToastNotificationVersion2_Load);
            this.Controls.SetChildIndex(this.kryptonPanel1, 0);
            this.Controls.SetChildIndex(this.kryptonPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnAction;
        private KryptonButton kbtnDismiss;
        private KryptonPanel kryptonPanel2;
        private System.Windows.Forms.ProgressBar pbTimeOut;
        private KryptonLabel klblHeader;
        private KryptonWrapLabel kwlContent;
        private System.Windows.Forms.PictureBox pbxIcon;
        private KryptonBorderEdge kryptonBorderEdge1;
    }
}