using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.IO
{
    public class KryptonFileExplorer : UserControl
    {
        private Panel panel1;
        private Panel panel5;
        private KryptonBreadCrumb kryptonBreadCrumb1;
        private Panel panel4;
        private Panel panel7;
        private KryptonButton kryptonButton2;
        private Panel panel6;
        private KryptonButton kryptonButton1;
        private Panel panel2;
        private Panel panel11;
        private KryptonComboBox kryptonComboBox1;
        private Panel panel10;
        private KryptonButton kryptonButton4;
        private Panel panel9;
        private KryptonButton kryptonButton3;
        private Panel panel8;
        private KryptonLabel kryptonLabel1;
        private Panel panel3;
        private KryptonSplitContainer kryptonSplitContainer1;
        private KryptonTreeView kryptonTreeView1;
        private ListView listView1;

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.kryptonSplitContainer1 = new Krypton.Toolkit.KryptonSplitContainer();
            this.kryptonBreadCrumb1 = new Krypton.Toolkit.KryptonBreadCrumb();
            this.kryptonTreeView1 = new Krypton.Toolkit.KryptonTreeView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.kryptonComboBox1 = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonButton3 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton4 = new Krypton.Toolkit.KryptonButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonBreadCrumb1)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 28);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 403);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(724, 25);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.kryptonSplitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(724, 375);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(180, 28);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.kryptonBreadCrumb1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(180, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(544, 28);
            this.panel5.TabIndex = 2;
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonTreeView1);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.listView1);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(724, 375);
            this.kryptonSplitContainer1.SplitterDistance = 241;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // kryptonBreadCrumb1
            // 
            this.kryptonBreadCrumb1.AutoSize = false;
            this.kryptonBreadCrumb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonBreadCrumb1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBreadCrumb1.Name = "kryptonBreadCrumb1";
            // 
            // 
            // 
            this.kryptonBreadCrumb1.RootItem.ShortText = "Root";
            this.kryptonBreadCrumb1.Size = new System.Drawing.Size(544, 28);
            this.kryptonBreadCrumb1.TabIndex = 0;
            // 
            // kryptonTreeView1
            // 
            this.kryptonTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTreeView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTreeView1.Name = "kryptonTreeView1";
            this.kryptonTreeView1.Size = new System.Drawing.Size(241, 375);
            this.kryptonTreeView1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.kryptonButton1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(93, 28);
            this.panel6.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.kryptonButton2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(93, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(87, 28);
            this.panel7.TabIndex = 1;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonButton1.Location = new System.Drawing.Point(0, 0);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(93, 28);
            this.kryptonButton1.TabIndex = 0;
            this.kryptonButton1.Values.Text = "kryptonButton1";
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonButton2.Location = new System.Drawing.Point(0, 0);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(87, 28);
            this.kryptonButton2.TabIndex = 0;
            this.kryptonButton2.Values.Text = "kryptonButton2";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.kryptonLabel1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(93, 25);
            this.panel8.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.kryptonButton3);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(635, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(89, 25);
            this.panel9.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.kryptonButton4);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(551, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(84, 25);
            this.panel10.TabIndex = 2;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.kryptonComboBox1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(93, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(458, 25);
            this.panel11.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(478, 375);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // kryptonComboBox1
            // 
            this.kryptonComboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kryptonComboBox1.DropDownWidth = 458;
            this.kryptonComboBox1.IntegralHeight = false;
            this.kryptonComboBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonComboBox1.Name = "kryptonComboBox1";
            this.kryptonComboBox1.Size = new System.Drawing.Size(458, 21);
            this.kryptonComboBox1.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonComboBox1.TabIndex = 0;
            this.kryptonComboBox1.Text = "kryptonComboBox1";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(93, 25);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "kryptonLabel1";
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonButton3.Location = new System.Drawing.Point(0, 0);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.Size = new System.Drawing.Size(89, 25);
            this.kryptonButton3.TabIndex = 0;
            this.kryptonButton3.Values.Text = "kryptonButton3";
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonButton4.Location = new System.Drawing.Point(0, 0);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(84, 25);
            this.kryptonButton4.TabIndex = 0;
            this.kryptonButton4.Values.Text = "kryptonButton4";
            // 
            // KryptonFileExplorer
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "KryptonFileExplorer";
            this.Size = new System.Drawing.Size(724, 428);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonBreadCrumb1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBox1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}