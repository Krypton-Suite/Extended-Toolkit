namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonInformationBoxWindow : KryptonForm
    {
        private KryptonPanel kpnlMain;
        private System.Windows.Forms.Timer tmrAutoClose;
        private System.ComponentModel.IContainer components;
        private KryptonLabel klblTitle;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kpnlMain = new Krypton.Toolkit.KryptonPanel();
            this.klblTitle = new Krypton.Toolkit.KryptonLabel();
            this.tmrAutoClose = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).BeginInit();
            this.kpnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // kpnlMain
            // 
            this.kpnlMain.Controls.Add(this.klblTitle);
            this.kpnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlMain.Location = new System.Drawing.Point(0, 0);
            this.kpnlMain.Name = "kpnlMain";
            this.kpnlMain.Size = new System.Drawing.Size(351, 192);
            this.kpnlMain.TabIndex = 0;
            // 
            // klblTitle
            // 
            this.klblTitle.AutoSize = false;
            this.klblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.klblTitle.Location = new System.Drawing.Point(0, 0);
            this.klblTitle.Name = "klblTitle";
            this.klblTitle.Size = new System.Drawing.Size(351, 31);
            this.klblTitle.TabIndex = 0;
            this.klblTitle.Values.Text = "kryptonLabel1";
            // 
            // KryptonInformationBoxWindow
            // 
            this.ClientSize = new System.Drawing.Size(351, 192);
            this.Controls.Add(this.kpnlMain);
            this.Name = "KryptonInformationBoxWindow";
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).EndInit();
            this.kpnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}