namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    partial class SharpUpdateDownloadForm
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
            this.kpbDownloadProgress = new Krypton.Toolkit.KryptonProgressBar();
            this.klblHeader = new Krypton.Toolkit.KryptonLabel();
            this.klblProgress = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.klblProgress);
            this.kryptonPanel1.Controls.Add(this.kpbDownloadProgress);
            this.kryptonPanel1.Controls.Add(this.klblHeader);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(459, 182);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kpbDownloadProgress
            // 
            this.kpbDownloadProgress.Location = new System.Drawing.Point(58, 109);
            this.kpbDownloadProgress.Name = "kpbDownloadProgress";
            this.kpbDownloadProgress.Size = new System.Drawing.Size(349, 26);
            this.kpbDownloadProgress.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.kpbDownloadProgress.StateDisabled.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            this.kpbDownloadProgress.StateNormal.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            this.kpbDownloadProgress.TabIndex = 1;
            this.kpbDownloadProgress.Text = "0%";
            this.kpbDownloadProgress.UseValueAsText = true;
            this.kpbDownloadProgress.Values.Text = "0%";
            // 
            // klblHeader
            // 
            this.klblHeader.Location = new System.Drawing.Point(58, 35);
            this.klblHeader.Name = "klblHeader";
            this.klblHeader.Size = new System.Drawing.Size(349, 49);
            this.klblHeader.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHeader.TabIndex = 0;
            this.klblHeader.Values.Text = "Downloading Update...";
            // 
            // klblProgress
            // 
            this.klblProgress.AutoSize = false;
            this.klblProgress.Location = new System.Drawing.Point(58, 142);
            this.klblProgress.Name = "klblProgress";
            this.klblProgress.Size = new System.Drawing.Size(349, 25);
            this.klblProgress.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblProgress.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblProgress.TabIndex = 2;
            this.klblProgress.Values.Text = "";
            // 
            // SharpUpdateDownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 182);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SharpUpdateDownloadForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Downloading Update";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonLabel klblHeader;
        private KryptonProgressBar kpbDownloadProgress;
        private KryptonLabel klblProgress;
    }
}