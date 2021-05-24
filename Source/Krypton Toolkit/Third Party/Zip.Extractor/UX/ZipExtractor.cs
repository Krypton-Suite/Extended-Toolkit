using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Krypton.Toolkit;

namespace Zip.Extractor
{
    public class ZipExtractor : KryptonForm
    {
        private KryptonPanel kryptonPanel1;
        private KryptonLabel klblCurentStatus;
        private System.Windows.Forms.ProgressBar pbExtractionProgress;
        private System.Windows.Forms.PictureBox pbxExtractIcon;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZipExtractor));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.pbxExtractIcon = new System.Windows.Forms.PictureBox();
            this.klblCurentStatus = new Krypton.Toolkit.KryptonLabel();
            this.pbExtractionProgress = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxExtractIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.pbExtractionProgress);
            this.kryptonPanel1.Controls.Add(this.klblCurentStatus);
            this.kryptonPanel1.Controls.Add(this.pbxExtractIcon);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(543, 93);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // pbxExtractIcon
            // 
            this.pbxExtractIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxExtractIcon.Location = new System.Drawing.Point(12, 12);
            this.pbxExtractIcon.Name = "pbxExtractIcon";
            this.pbxExtractIcon.Size = new System.Drawing.Size(64, 64);
            this.pbxExtractIcon.TabIndex = 1;
            this.pbxExtractIcon.TabStop = false;
            // 
            // klblCurentStatus
            // 
            this.klblCurentStatus.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.klblCurentStatus.Location = new System.Drawing.Point(83, 34);
            this.klblCurentStatus.Name = "klblCurentStatus";
            this.klblCurentStatus.Size = new System.Drawing.Size(94, 20);
            this.klblCurentStatus.TabIndex = 2;
            this.klblCurentStatus.Values.Text = "kryptonLabel1";
            // 
            // pbExtractionProgress
            // 
            this.pbExtractionProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbExtractionProgress.Location = new System.Drawing.Point(0, 88);
            this.pbExtractionProgress.Name = "pbExtractionProgress";
            this.pbExtractionProgress.Size = new System.Drawing.Size(543, 5);
            this.pbExtractionProgress.TabIndex = 3;
            // 
            // ZipExtractor
            // 
            this.ClientSize = new System.Drawing.Size(543, 93);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZipExtractor";
            this.ShowInTaskbar = false;
            this.Text = "Zip Extraction";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxExtractIcon)).EndInit();
            this.ResumeLayout(false);

        }
    }
}