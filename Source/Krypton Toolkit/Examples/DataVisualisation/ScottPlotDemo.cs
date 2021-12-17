using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Krypton.Toolkit;

namespace DataVisualisation
{
    public class ScottPlotDemo : KryptonForm
    {
        private KryptonPanel kryptonPanel1;
        private KryptonPanel kpContent;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kpContent = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpContent)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 605);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(1030, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kpContent
            // 
            this.kpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpContent.Location = new System.Drawing.Point(0, 0);
            this.kpContent.Name = "kpContent";
            this.kpContent.Size = new System.Drawing.Size(1030, 605);
            this.kpContent.TabIndex = 1;
            // 
            // ScottPlotDemo
            // 
            this.ClientSize = new System.Drawing.Size(1030, 655);
            this.Controls.Add(this.kpContent);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "ScottPlotDemo";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpContent)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
