using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class KryptonFileBrowserDialog : KryptonForm
    {
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private KryptonBreadCrumb kbcPath;
        private KryptonButton kbtnBack;
        private KryptonButton kbtnForward;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnCancel;
        private KryptonPanel kryptonPanel3;
        private KryptonSplitContainer kryptonSplitContainer1;
        private KryptonTreeView ktvFileSystem;
        private KryptonListBox kryptonListBox1;
        private System.Windows.Forms.Panel panel2;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.kbcPath = new Krypton.Toolkit.KryptonBreadCrumb();
            this.kbtnBack = new Krypton.Toolkit.KryptonButton();
            this.kbtnForward = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel3 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonSplitContainer1 = new Krypton.Toolkit.KryptonSplitContainer();
            this.ktvFileSystem = new Krypton.Toolkit.KryptonTreeView();
            this.kryptonListBox1 = new Krypton.Toolkit.KryptonListBox();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kbcPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.panel4);
            this.kryptonPanel1.Controls.Add(this.panel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(717, 28);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 28);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.kbtnBack);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(60, 28);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.kbtnForward);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(60, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(64, 28);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.kbcPath);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(124, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(593, 28);
            this.panel4.TabIndex = 1;
            // 
            // kbcPath
            // 
            this.kbcPath.AutoSize = false;
            this.kbcPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbcPath.Location = new System.Drawing.Point(0, 0);
            this.kbcPath.Name = "kbcPath";
            // 
            // 
            // 
            this.kbcPath.RootItem.ShortText = "Root";
            this.kbcPath.Size = new System.Drawing.Size(593, 28);
            this.kbcPath.TabIndex = 0;
            // 
            // kbtnBack
            // 
            this.kbtnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnBack.Location = new System.Drawing.Point(0, 0);
            this.kbtnBack.Name = "kbtnBack";
            this.kbtnBack.Size = new System.Drawing.Size(60, 28);
            this.kbtnBack.TabIndex = 0;
            this.kbtnBack.Values.Text = "<--";
            // 
            // kbtnForward
            // 
            this.kbtnForward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnForward.Location = new System.Drawing.Point(0, 0);
            this.kbtnForward.Name = "kbtnForward";
            this.kbtnForward.Size = new System.Drawing.Size(64, 28);
            this.kbtnForward.TabIndex = 0;
            this.kbtnForward.Values.Text = "-->";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnCancel);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 347);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(717, 59);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.kryptonSplitContainer1);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 28);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(717, 319);
            this.kryptonPanel3.TabIndex = 2;
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.ktvFileSystem);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonListBox1);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(717, 319);
            this.kryptonSplitContainer1.SplitterDistance = 239;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // ktvFileSystem
            // 
            this.ktvFileSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktvFileSystem.Location = new System.Drawing.Point(0, 0);
            this.ktvFileSystem.Name = "ktvFileSystem";
            this.ktvFileSystem.Size = new System.Drawing.Size(239, 319);
            this.ktvFileSystem.TabIndex = 0;
            // 
            // kryptonListBox1
            // 
            this.kryptonListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonListBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonListBox1.Name = "kryptonListBox1";
            this.kryptonListBox1.Size = new System.Drawing.Size(473, 319);
            this.kryptonListBox1.TabIndex = 0;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Location = new System.Drawing.Point(615, 17);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // KryptonFileBrowserDialog
            // 
            this.ClientSize = new System.Drawing.Size(717, 406);
            this.Controls.Add(this.kryptonPanel3);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "KryptonFileBrowserDialog";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kbcPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}