#region MIT License

/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */

#endregion
namespace Examples
{
    partial class DockExtenderExample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockExtenderExample));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.kpnlLeft = new Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.ksLeft = new Krypton.Toolkit.KryptonSeparator();
            this.kpnlBottom = new Krypton.Toolkit.KryptonPanel();
            this.ksBottom = new Krypton.Toolkit.KryptonSeparator();
            this.kryptonListView1 = new Krypton.Toolkit.KryptonListView();
            this.kryptonTableLayoutPanel1 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.kbtnLeftClose = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonTableLayoutPanel2 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.kbtnBottomClose = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kpnlBottomInner = new Krypton.Toolkit.KryptonPanel();
            this.kryptonMonthCalendar1 = new Krypton.Toolkit.KryptonMonthCalendar();
            this.kryptonSeparator3 = new Krypton.Toolkit.KryptonSeparator();
            this.kryptonTreeView1 = new Krypton.Toolkit.KryptonTreeView();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlLeft)).BeginInit();
            this.kpnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ksLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBottom)).BeginInit();
            this.kpnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ksBottom)).BeginInit();
            this.kryptonTableLayoutPanel1.SuspendLayout();
            this.kryptonTableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBottomInner)).BeginInit();
            this.kpnlBottomInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSeparator3)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "C&lose";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "Vie&w";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripComboBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(876, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel1.Text = "Drag Me!";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.Location = new System.Drawing.Point(0, 489);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(876, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // kpnlLeft
            // 
            this.kpnlLeft.Controls.Add(this.kryptonTreeView1);
            this.kpnlLeft.Controls.Add(this.kryptonSeparator3);
            this.kpnlLeft.Controls.Add(this.kryptonTableLayoutPanel1);
            this.kpnlLeft.Controls.Add(this.kryptonLabel3);
            this.kpnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.kpnlLeft.Location = new System.Drawing.Point(0, 49);
            this.kpnlLeft.Name = "kpnlLeft";
            this.kpnlLeft.Size = new System.Drawing.Size(247, 440);
            this.kpnlLeft.TabIndex = 3;
            this.kpnlLeft.VisibleChanged += new System.EventHandler(this.kpnlLeft_VisibleChanged);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.AutoSize = false;
            this.kryptonLabel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonLabel3.LabelStyle = Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel3.Location = new System.Drawing.Point(0, 303);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(247, 137);
            this.kryptonLabel3.TabIndex = 9;
            this.kryptonLabel3.Values.Text = "";
            // 
            // ksLeft
            // 
            this.ksLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ksLeft.Location = new System.Drawing.Point(247, 49);
            this.ksLeft.Name = "ksLeft";
            this.ksLeft.Size = new System.Drawing.Size(5, 440);
            this.ksLeft.TabIndex = 4;
            // 
            // kpnlBottom
            // 
            this.kpnlBottom.Controls.Add(this.kpnlBottomInner);
            this.kpnlBottom.Controls.Add(this.kryptonTableLayoutPanel2);
            this.kpnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlBottom.Location = new System.Drawing.Point(252, 286);
            this.kpnlBottom.Name = "kpnlBottom";
            this.kpnlBottom.Size = new System.Drawing.Size(624, 203);
            this.kpnlBottom.TabIndex = 5;
            // 
            // ksBottom
            // 
            this.ksBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ksBottom.Location = new System.Drawing.Point(252, 281);
            this.ksBottom.Name = "ksBottom";
            this.ksBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ksBottom.Size = new System.Drawing.Size(624, 5);
            this.ksBottom.TabIndex = 6;
            // 
            // kryptonListView1
            // 
            this.kryptonListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonListView1.FullRowSelect = true;
            this.kryptonListView1.HideSelection = false;
            this.kryptonListView1.Location = new System.Drawing.Point(252, 49);
            this.kryptonListView1.Name = "kryptonListView1";
            this.kryptonListView1.Size = new System.Drawing.Size(624, 232);
            this.kryptonListView1.TabIndex = 7;
            this.kryptonListView1.View = System.Windows.Forms.View.SmallIcon;
            // 
            // kryptonTableLayoutPanel1
            // 
            this.kryptonTableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonTableLayoutPanel1.BackgroundImage")));
            this.kryptonTableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.kryptonTableLayoutPanel1.ColumnCount = 2;
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.kryptonTableLayoutPanel1.Controls.Add(this.kbtnLeftClose, 1, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonLabel2, 0, 0);
            this.kryptonTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel1.Name = "kryptonTableLayoutPanel1";
            this.kryptonTableLayoutPanel1.RowCount = 1;
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.Size = new System.Drawing.Size(247, 20);
            this.kryptonTableLayoutPanel1.TabIndex = 10;
            // 
            // kbtnLeftClose
            // 
            this.kbtnLeftClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnLeftClose.Location = new System.Drawing.Point(230, 3);
            this.kbtnLeftClose.Name = "kbtnLeftClose";
            this.kbtnLeftClose.Size = new System.Drawing.Size(14, 14);
            this.kbtnLeftClose.TabIndex = 0;
            this.kbtnLeftClose.Values.Text = "X";
            this.kbtnLeftClose.Click += new System.EventHandler(this.kbtnLeftClose_Click);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel2.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(221, 14);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Left Panel";
            this.kryptonLabel2.VisibleChanged += new System.EventHandler(this.kryptonLabel2_VisibleChanged);
            // 
            // kryptonTableLayoutPanel2
            // 
            this.kryptonTableLayoutPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonTableLayoutPanel2.BackgroundImage")));
            this.kryptonTableLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.kryptonTableLayoutPanel2.ColumnCount = 2;
            this.kryptonTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.kryptonTableLayoutPanel2.Controls.Add(this.kbtnBottomClose, 1, 0);
            this.kryptonTableLayoutPanel2.Controls.Add(this.kryptonLabel1, 0, 0);
            this.kryptonTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonTableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel2.Name = "kryptonTableLayoutPanel2";
            this.kryptonTableLayoutPanel2.RowCount = 1;
            this.kryptonTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel2.Size = new System.Drawing.Size(624, 20);
            this.kryptonTableLayoutPanel2.TabIndex = 12;
            // 
            // kbtnBottomClose
            // 
            this.kbtnBottomClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnBottomClose.Location = new System.Drawing.Point(607, 3);
            this.kbtnBottomClose.Name = "kbtnBottomClose";
            this.kbtnBottomClose.Size = new System.Drawing.Size(14, 14);
            this.kbtnBottomClose.TabIndex = 0;
            this.kbtnBottomClose.Values.Text = "X";
            this.kbtnBottomClose.Click += new System.EventHandler(this.kbtnBottomClose_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(598, 14);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Bottom Panel";
            this.kryptonLabel1.VisibleChanged += new System.EventHandler(this.kryptonLabel1_VisibleChanged);
            // 
            // kpnlBottomInner
            // 
            this.kpnlBottomInner.Controls.Add(this.kryptonMonthCalendar1);
            this.kpnlBottomInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlBottomInner.Location = new System.Drawing.Point(0, 20);
            this.kpnlBottomInner.Name = "kpnlBottomInner";
            this.kpnlBottomInner.Size = new System.Drawing.Size(624, 183);
            this.kpnlBottomInner.TabIndex = 13;
            // 
            // kryptonMonthCalendar1
            // 
            this.kryptonMonthCalendar1.CalendarDimensions = new System.Drawing.Size(2, 1);
            this.kryptonMonthCalendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonMonthCalendar1.Location = new System.Drawing.Point(0, 0);
            this.kryptonMonthCalendar1.Name = "kryptonMonthCalendar1";
            this.kryptonMonthCalendar1.Size = new System.Drawing.Size(456, 182);
            this.kryptonMonthCalendar1.TabIndex = 0;
            // 
            // kryptonSeparator3
            // 
            this.kryptonSeparator3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonSeparator3.Location = new System.Drawing.Point(0, 298);
            this.kryptonSeparator3.Name = "kryptonSeparator3";
            this.kryptonSeparator3.Size = new System.Drawing.Size(247, 5);
            this.kryptonSeparator3.TabIndex = 12;
            // 
            // kryptonTreeView1
            // 
            this.kryptonTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTreeView1.Location = new System.Drawing.Point(0, 20);
            this.kryptonTreeView1.Name = "kryptonTreeView1";
            this.kryptonTreeView1.Size = new System.Drawing.Size(247, 278);
            this.kryptonTreeView1.TabIndex = 13;
            // 
            // DockExtenderExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 511);
            this.Controls.Add(this.kryptonListView1);
            this.Controls.Add(this.ksBottom);
            this.Controls.Add(this.kpnlBottom);
            this.Controls.Add(this.ksLeft);
            this.Controls.Add(this.kpnlLeft);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DockExtenderExample";
            this.Text = "Dock Extender Example";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlLeft)).EndInit();
            this.kpnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ksLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBottom)).EndInit();
            this.kpnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ksBottom)).EndInit();
            this.kryptonTableLayoutPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.PerformLayout();
            this.kryptonTableLayoutPanel2.ResumeLayout(false);
            this.kryptonTableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBottomInner)).EndInit();
            this.kpnlBottomInner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSeparator3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripComboBox toolStripComboBox1;
        private StatusStrip statusStrip1;
        private KryptonPanel kpnlLeft;
        private KryptonSeparator ksLeft;
        private KryptonPanel kpnlBottom;
        private KryptonSeparator ksBottom;
        private KryptonListView kryptonListView1;
        private KryptonLabel kryptonLabel3;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel1;
        private KryptonButton kbtnLeftClose;
        private KryptonLabel kryptonLabel2;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel2;
        private KryptonButton kbtnBottomClose;
        private KryptonLabel kryptonLabel1;
        private KryptonPanel kpnlBottomInner;
        private KryptonMonthCalendar kryptonMonthCalendar1;
        private KryptonSeparator kryptonSeparator3;
        private KryptonTreeView kryptonTreeView1;
    }
}