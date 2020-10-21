using System;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonSplashScreen : KryptonForm
    {
        private KryptonProgressBar kpProgress;
        private KryptonPanel kpContent;
        private CircularPictureBox cbApplicationIconCircular;
        private System.Windows.Forms.PictureBox pbxApplicationIconStandard;
        private KryptonMarqueeLabel kryptonMarqueeLabel1;
        private System.ComponentModel.IContainer components;
        private KryptonLabel klblApplicationName;
        private KryptonPanel kpnlProgressBar;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kpnlProgressBar = new Krypton.Toolkit.KryptonPanel();
            this.kpProgress = new Krypton.Toolkit.Suite.Extended.Base.KryptonProgressBar();
            this.kpContent = new Krypton.Toolkit.KryptonPanel();
            this.klblApplicationName = new Krypton.Toolkit.KryptonLabel();
            this.kryptonMarqueeLabel1 = new Krypton.Toolkit.Suite.Extended.Base.KryptonMarqueeLabel();
            this.pbxApplicationIconStandard = new System.Windows.Forms.PictureBox();
            this.cbApplicationIconCircular = new Krypton.Toolkit.Suite.Extended.Base.CircularPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlProgressBar)).BeginInit();
            this.kpnlProgressBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpContent)).BeginInit();
            this.kpContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIconStandard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbApplicationIconCircular)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlProgressBar
            // 
            this.kpnlProgressBar.Controls.Add(this.kpProgress);
            this.kpnlProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlProgressBar.Location = new System.Drawing.Point(0, 341);
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
            this.kpContent.Controls.Add(this.cbApplicationIconCircular);
            this.kpContent.Controls.Add(this.pbxApplicationIconStandard);
            this.kpContent.Controls.Add(this.kryptonMarqueeLabel1);
            this.kpContent.Controls.Add(this.klblApplicationName);
            this.kpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpContent.Location = new System.Drawing.Point(0, 0);
            this.kpContent.Name = "kpContent";
            this.kpContent.Size = new System.Drawing.Size(725, 341);
            this.kpContent.TabIndex = 1;
            // 
            // klblApplicationName
            // 
            this.klblApplicationName.AutoSize = false;
            this.klblApplicationName.Location = new System.Drawing.Point(12, 12);
            this.klblApplicationName.Name = "klblApplicationName";
            this.klblApplicationName.Size = new System.Drawing.Size(701, 41);
            this.klblApplicationName.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblApplicationName.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblApplicationName.TabIndex = 2;
            this.klblApplicationName.Values.Text = "<##APPLICATION-NAME##>";
            // 
            // kryptonMarqueeLabel1
            // 
            this.kryptonMarqueeLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonMarqueeLabel1.Location = new System.Drawing.Point(0, 321);
            this.kryptonMarqueeLabel1.Name = "kryptonMarqueeLabel1";
            this.kryptonMarqueeLabel1.Size = new System.Drawing.Size(725, 20);
            this.kryptonMarqueeLabel1.Speed = 1;
            this.kryptonMarqueeLabel1.TabIndex = 3;
            this.kryptonMarqueeLabel1.Values.Text = "<##SOME-TEXT##>";
            this.kryptonMarqueeLabel1.YOffset = 0;
            // 
            // pbxApplicationIconStandard
            // 
            this.pbxApplicationIconStandard.BackColor = System.Drawing.Color.Transparent;
            this.pbxApplicationIconStandard.Location = new System.Drawing.Point(234, 59);
            this.pbxApplicationIconStandard.Name = "pbxApplicationIconStandard";
            this.pbxApplicationIconStandard.Size = new System.Drawing.Size(256, 256);
            this.pbxApplicationIconStandard.TabIndex = 4;
            this.pbxApplicationIconStandard.TabStop = false;
            // 
            // cbApplicationIconCircular
            // 
            this.cbApplicationIconCircular.BackColor = System.Drawing.Color.Transparent;
            this.cbApplicationIconCircular.Location = new System.Drawing.Point(234, 59);
            this.cbApplicationIconCircular.Name = "cbApplicationIconCircular";
            this.cbApplicationIconCircular.Size = new System.Drawing.Size(256, 256);
            this.cbApplicationIconCircular.TabIndex = 5;
            this.cbApplicationIconCircular.TabStop = false;
            this.cbApplicationIconCircular.ToolTipValues = null;
            // 
            // KryptonSplashScreen
            // 
            this.ClientSize = new System.Drawing.Size(725, 373);
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
            this.kpContent.ResumeLayout(false);
            this.kpContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIconStandard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbApplicationIconCircular)).EndInit();
            this.ResumeLayout(false);

        }

        private void KryptonSplashScreen_Load(object sender, EventArgs e)
        {

        }
    }
}