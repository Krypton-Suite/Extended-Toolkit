namespace Krypton.Toolkit.Suite.Extended.Networking
{
    partial class KryptonNetworkUtility
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
            this.ksc = new Krypton.Toolkit.KryptonSplitContainer();
            this.klblPortScan = new Krypton.Toolkit.KryptonLinkLabel();
            this.klblPing = new Krypton.Toolkit.KryptonLinkLabel();
            this.klblNetStatWithoutDNS = new Krypton.Toolkit.KryptonLinkLabel();
            this.klblNetStat = new Krypton.Toolkit.KryptonLinkLabel();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.ksc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksc.Panel1)).BeginInit();
            this.ksc.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ksc.Panel2)).BeginInit();
            this.ksc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // ksc
            // 
            this.ksc.Cursor = System.Windows.Forms.Cursors.Default;
            this.ksc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ksc.Location = new System.Drawing.Point(0, 0);
            this.ksc.Name = "ksc";
            // 
            // ksc.Panel1
            // 
            this.ksc.Panel1.Controls.Add(this.klblPortScan);
            this.ksc.Panel1.Controls.Add(this.klblPing);
            this.ksc.Panel1.Controls.Add(this.klblNetStatWithoutDNS);
            this.ksc.Panel1.Controls.Add(this.klblNetStat);
            this.ksc.Panel1.Controls.Add(this.kryptonPanel1);
            this.ksc.Size = new System.Drawing.Size(808, 437);
            this.ksc.SplitterDistance = 269;
            this.ksc.TabIndex = 0;
            // 
            // klblPortScan
            // 
            this.klblPortScan.AutoSize = false;
            this.klblPortScan.Dock = System.Windows.Forms.DockStyle.Top;
            this.klblPortScan.LinkBehavior = Krypton.Toolkit.KryptonLinkBehavior.HoverUnderline;
            this.klblPortScan.Location = new System.Drawing.Point(0, 168);
            this.klblPortScan.Name = "klblPortScan";
            this.klblPortScan.Size = new System.Drawing.Size(269, 42);
            this.klblPortScan.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.klblPortScan.TabIndex = 4;
            this.klblPortScan.Values.Text = "Port Scan";
            this.klblPortScan.LinkClicked += new System.EventHandler(this.klblPortScan_LinkClicked);
            // 
            // klblPing
            // 
            this.klblPing.AutoSize = false;
            this.klblPing.Dock = System.Windows.Forms.DockStyle.Top;
            this.klblPing.LinkBehavior = Krypton.Toolkit.KryptonLinkBehavior.HoverUnderline;
            this.klblPing.Location = new System.Drawing.Point(0, 126);
            this.klblPing.Name = "klblPing";
            this.klblPing.Size = new System.Drawing.Size(269, 42);
            this.klblPing.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.klblPing.TabIndex = 3;
            this.klblPing.Values.Text = "Ping";
            this.klblPing.LinkClicked += new System.EventHandler(this.klblPing_LinkClicked);
            // 
            // klblNetStatWithoutDNS
            // 
            this.klblNetStatWithoutDNS.AutoSize = false;
            this.klblNetStatWithoutDNS.Dock = System.Windows.Forms.DockStyle.Top;
            this.klblNetStatWithoutDNS.LinkBehavior = Krypton.Toolkit.KryptonLinkBehavior.HoverUnderline;
            this.klblNetStatWithoutDNS.Location = new System.Drawing.Point(0, 84);
            this.klblNetStatWithoutDNS.Name = "klblNetStatWithoutDNS";
            this.klblNetStatWithoutDNS.Size = new System.Drawing.Size(269, 42);
            this.klblNetStatWithoutDNS.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.klblNetStatWithoutDNS.TabIndex = 2;
            this.klblNetStatWithoutDNS.Values.Text = "Net Stat without DNS";
            this.klblNetStatWithoutDNS.LinkClicked += new System.EventHandler(this.klblNetStatWithoutDNS_LinkClicked);
            // 
            // klblNetStat
            // 
            this.klblNetStat.AutoSize = false;
            this.klblNetStat.Dock = System.Windows.Forms.DockStyle.Top;
            this.klblNetStat.LinkBehavior = Krypton.Toolkit.KryptonLinkBehavior.HoverUnderline;
            this.klblNetStat.Location = new System.Drawing.Point(0, 42);
            this.klblNetStat.Name = "klblNetStat";
            this.klblNetStat.Size = new System.Drawing.Size(269, 42);
            this.klblNetStat.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.klblNetStat.TabIndex = 1;
            this.klblNetStat.Values.Text = "Net Stat";
            this.klblNetStat.LinkClicked += new System.EventHandler(this.klblNetStat_LinkClicked);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(269, 42);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // NetworkUtility
            // 
            this.ClientSize = new System.Drawing.Size(808, 437);
            this.Controls.Add(this.ksc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NetworkUtility";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Network Utility";
            this.Load += new System.EventHandler(this.KryptonNetworkUtility_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ksc.Panel1)).EndInit();
            this.ksc.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ksc.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksc)).EndInit();
            this.ksc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private KryptonSplitContainer ksc;
        private KryptonLinkLabel klblPortScan;
        private KryptonLinkLabel klblPing;
        private KryptonLinkLabel klblNetStatWithoutDNS;
        private KryptonLinkLabel klblNetStat;
        private KryptonPanel kryptonPanel1;
    }
}