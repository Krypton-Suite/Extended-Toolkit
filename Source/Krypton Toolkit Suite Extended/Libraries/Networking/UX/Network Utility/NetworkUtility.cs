using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public class NetworkUtility : KryptonForm
    {
        private KryptonSplitContainer kryptonSplitContainer1;
        private KryptonLinkLabel klblPortScan;
        private KryptonLinkLabel klblPing;
        private KryptonLinkLabel klblNetStatWithoutDNS;
        private KryptonLinkLabel klblNetStat;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonSplitContainer1 = new Krypton.Toolkit.KryptonSplitContainer();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.klblNetStat = new Krypton.Toolkit.KryptonLinkLabel();
            this.klblNetStatWithoutDNS = new Krypton.Toolkit.KryptonLinkLabel();
            this.klblPing = new Krypton.Toolkit.KryptonLinkLabel();
            this.klblPortScan = new Krypton.Toolkit.KryptonLinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.klblPortScan);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.klblPing);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.klblNetStatWithoutDNS);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.klblNetStat);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonPanel1);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(808, 437);
            this.kryptonSplitContainer1.SplitterDistance = 269;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(269, 42);
            this.kryptonPanel1.TabIndex = 0;
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
            // 
            // NetworkUtility
            // 
            this.ClientSize = new System.Drawing.Size(808, 437);
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Name = "NetworkUtility";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}