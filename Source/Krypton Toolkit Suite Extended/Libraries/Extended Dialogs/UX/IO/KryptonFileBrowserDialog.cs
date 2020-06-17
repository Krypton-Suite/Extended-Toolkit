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
        private Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser ebcExplorer;
        private KryptonButton kbtnAction;
        private KryptonTextBox kryptonTextBox1;
        private KryptonComboBox kryptonComboBox1;
        private System.Windows.Forms.Panel panel2;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.kbcPath = new Krypton.Toolkit.KryptonBreadCrumb();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.kbtnForward = new Krypton.Toolkit.KryptonButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.kbtnBack = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnAction = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel3 = new Krypton.Toolkit.KryptonPanel();
            this.ebcExplorer = new Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser();
            this.kryptonComboBox1 = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonTextBox1 = new Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kbcPath)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).BeginInit();
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
            this.kbcPath.SelectedItem = this.kbcPath.RootItem;
            this.kbcPath.Size = new System.Drawing.Size(593, 28);
            this.kbcPath.TabIndex = 0;
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
            // panel3
            // 
            this.panel3.Controls.Add(this.kbtnForward);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(60, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(64, 28);
            this.panel3.TabIndex = 1;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.kbtnBack);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(60, 28);
            this.panel2.TabIndex = 0;
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
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonTextBox1);
            this.kryptonPanel2.Controls.Add(this.kryptonComboBox1);
            this.kryptonPanel2.Controls.Add(this.kbtnAction);
            this.kryptonPanel2.Controls.Add(this.kbtnCancel);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 358);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(717, 69);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kbtnAction
            // 
            this.kbtnAction.Location = new System.Drawing.Point(519, 17);
            this.kbtnAction.Name = "kbtnAction";
            this.kbtnAction.Size = new System.Drawing.Size(90, 31);
            this.kbtnAction.TabIndex = 1;
            this.kbtnAction.Values.Text = "{0}";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Location = new System.Drawing.Point(615, 17);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 31);
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.ebcExplorer);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 28);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(717, 330);
            this.kryptonPanel3.TabIndex = 2;
            // 
            // ebcExplorer
            // 
            this.ebcExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ebcExplorer.Location = new System.Drawing.Point(0, 0);
            this.ebcExplorer.Name = "ebcExplorer";
            this.ebcExplorer.PropertyBagName = "Microsoft.WindowsAPICodePack.Controls.WindowsForms.ExplorerBrowser";
            this.ebcExplorer.Size = new System.Drawing.Size(717, 330);
            this.ebcExplorer.TabIndex = 0;
            // 
            // kryptonComboBox1
            // 
            this.kryptonComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kryptonComboBox1.DropDownWidth = 374;
            this.kryptonComboBox1.IntegralHeight = false;
            this.kryptonComboBox1.Location = new System.Drawing.Point(139, 35);
            this.kryptonComboBox1.Name = "kryptonComboBox1";
            this.kryptonComboBox1.Size = new System.Drawing.Size(374, 21);
            this.kryptonComboBox1.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonComboBox1.TabIndex = 2;
            this.kryptonComboBox1.Text = "kryptonComboBox1";
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(139, 6);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(374, 23);
            this.kryptonTextBox1.TabIndex = 3;
            this.kryptonTextBox1.Text = "kryptonTextBox1";
            // 
            // KryptonFileBrowserDialog
            // 
            this.ClientSize = new System.Drawing.Size(717, 427);
            this.Controls.Add(this.kryptonPanel3);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "KryptonFileBrowserDialog";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kbcPath)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}