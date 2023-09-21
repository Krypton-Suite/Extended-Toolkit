namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    partial class SharpUpdateAcceptForm
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
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnDetails = new Krypton.Toolkit.KryptonButton();
            this.kbtnNo = new Krypton.Toolkit.KryptonButton();
            this.kbtnYes = new Krypton.Toolkit.KryptonButton();
            this.kwlUpdateAvailable = new Krypton.Toolkit.KryptonWrapLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kwlNewVersion = new Krypton.Toolkit.KryptonWrapLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnYes);
            this.kryptonPanel1.Controls.Add(this.kbtnNo);
            this.kryptonPanel1.Controls.Add(this.kbtnDetails);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 203);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(382, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(382, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kwlNewVersion);
            this.kryptonPanel2.Controls.Add(this.pictureBox1);
            this.kryptonPanel2.Controls.Add(this.kwlUpdateAvailable);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(382, 203);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kbtnDetails
            // 
            this.kbtnDetails.Location = new System.Drawing.Point(280, 13);
            this.kbtnDetails.Name = "kbtnDetails";
            this.kbtnDetails.Size = new System.Drawing.Size(90, 25);
            this.kbtnDetails.TabIndex = 1;
            this.kbtnDetails.Values.Text = "kryptonButton1";
            this.kbtnDetails.Click += new System.EventHandler(this.kbtnDetails_Click);
            // 
            // kbtnNo
            // 
            this.kbtnNo.Location = new System.Drawing.Point(184, 13);
            this.kbtnNo.Name = "kbtnNo";
            this.kbtnNo.Size = new System.Drawing.Size(90, 25);
            this.kbtnNo.TabIndex = 2;
            this.kbtnNo.Values.Text = "kryptonButton2";
            this.kbtnNo.Click += new System.EventHandler(this.kbtnNo_Click);
            // 
            // kbtnYes
            // 
            this.kbtnYes.Location = new System.Drawing.Point(88, 13);
            this.kbtnYes.Name = "kbtnYes";
            this.kbtnYes.Size = new System.Drawing.Size(90, 25);
            this.kbtnYes.TabIndex = 3;
            this.kbtnYes.Values.Text = "kryptonButton3";
            this.kbtnYes.Click += new System.EventHandler(this.kbtnYes_Click);
            // 
            // kwlUpdateAvailable
            // 
            this.kwlUpdateAvailable.AutoSize = false;
            this.kwlUpdateAvailable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlUpdateAvailable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlUpdateAvailable.LabelStyle = Krypton.Toolkit.LabelStyle.AlternateControl;
            this.kwlUpdateAvailable.Location = new System.Drawing.Point(88, 13);
            this.kwlUpdateAvailable.Name = "kwlUpdateAvailable";
            this.kwlUpdateAvailable.Size = new System.Drawing.Size(282, 64);
            this.kwlUpdateAvailable.StateCommon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlUpdateAvailable.Text = "An update is available!\r\nWould you like to update?";
            this.kwlUpdateAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Krypton.Toolkit.Suite.Extended.Software.Updater.Properties.Resources.update2;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // kwlNewVersion
            // 
            this.kwlNewVersion.AutoSize = false;
            this.kwlNewVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlNewVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlNewVersion.LabelStyle = Krypton.Toolkit.LabelStyle.AlternateControl;
            this.kwlNewVersion.Location = new System.Drawing.Point(88, 81);
            this.kwlNewVersion.Name = "kwlNewVersion";
            this.kwlNewVersion.Size = new System.Drawing.Size(282, 107);
            this.kwlNewVersion.StateCommon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlNewVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SharpUpdateAcceptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 253);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SharpUpdateAcceptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnDetails;
        private KryptonButton kbtnNo;
        private KryptonButton kbtnYes;
        private KryptonWrapLabel kwlUpdateAvailable;
        private PictureBox pictureBox1;
        private KryptonWrapLabel kwlNewVersion;
    }
}