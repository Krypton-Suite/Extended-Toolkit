using System;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonSplashScreen : KryptonForm
    {
        private KryptonProgressBar kpProgress;
        private KryptonPanel kpContent;
        private KryptonPanel kpnlProgressBar;

        private void InitializeComponent()
        {
            this.kpnlProgressBar = new Krypton.Toolkit.KryptonPanel();
            this.kpProgress = new Krypton.Toolkit.Suite.Extended.Base.KryptonProgressBar();
            this.kpContent = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlProgressBar)).BeginInit();
            this.kpnlProgressBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpContent)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlProgressBar
            // 
            this.kpnlProgressBar.Controls.Add(this.kpProgress);
            this.kpnlProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlProgressBar.Location = new System.Drawing.Point(0, 334);
            this.kpnlProgressBar.Name = "kpnlProgressBar";
            this.kpnlProgressBar.Size = new System.Drawing.Size(725, 32);
            this.kpnlProgressBar.TabIndex = 0;
            // 
            // kpProgress
            // 
            this.kpProgress.BackColor = System.Drawing.Color.Transparent;
            this.kpProgress.BackgroundColour = System.Drawing.Color.Transparent;
            this.kpProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpProgress.EndColour = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(224)))), ((int)(((byte)(135)))));
            this.kpProgress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kpProgress.ForeColour = System.Drawing.Color.Empty;
            this.kpProgress.Location = new System.Drawing.Point(0, 0);
            this.kpProgress.Name = "kpProgress";
            this.kpProgress.Size = new System.Drawing.Size(725, 32);
            this.kpProgress.StartColour = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(224)))), ((int)(((byte)(135)))));
            this.kpProgress.TabIndex = 1;
            // 
            // kpContent
            // 
            this.kpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpContent.Location = new System.Drawing.Point(0, 0);
            this.kpContent.Name = "kpContent";
            this.kpContent.Size = new System.Drawing.Size(725, 334);
            this.kpContent.TabIndex = 1;
            // 
            // KryptonSplashScreen
            // 
            this.ClientSize = new System.Drawing.Size(725, 366);
            this.ControlBox = false;
            this.Controls.Add(this.kpContent);
            this.Controls.Add(this.kpnlProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonSplashScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.KryptonSplashScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlProgressBar)).EndInit();
            this.kpnlProgressBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpContent)).EndInit();
            this.ResumeLayout(false);

        }

        private void KryptonSplashScreen_Load(object sender, EventArgs e)
        {

        }
    }
}