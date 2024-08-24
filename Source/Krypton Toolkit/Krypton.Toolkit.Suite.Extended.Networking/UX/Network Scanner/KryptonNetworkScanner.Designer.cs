#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    partial class KryptonNetworkScanner
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
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnScan = new Krypton.Toolkit.KryptonButton();
            this.ktxtWorkGroupName = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kdgvNodes = new Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdgvNodes)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnScan);
            this.kryptonPanel1.Controls.Add(this.ktxtWorkGroupName);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(589, 44);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnScan
            // 
            this.kbtnScan.Enabled = false;
            this.kbtnScan.Location = new System.Drawing.Point(472, 12);
            this.kbtnScan.Name = "kbtnScan";
            this.kbtnScan.Size = new System.Drawing.Size(101, 25);
            this.kbtnScan.TabIndex = 2;
            this.kbtnScan.Values.Text = "St&art Scan";
            this.kbtnScan.Click += new System.EventHandler(this.kbtnScan_Click);
            // 
            // ktxtWorkGroupName
            // 
            this.ktxtWorkGroupName.CueHint.CueHintText = "Type a domain or workgroup name here...";
            this.ktxtWorkGroupName.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.ktxtWorkGroupName.Location = new System.Drawing.Point(178, 12);
            this.ktxtWorkGroupName.Name = "ktxtWorkGroupName";
            this.ktxtWorkGroupName.Size = new System.Drawing.Size(287, 23);
            this.ktxtWorkGroupName.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(159, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Domain/Workgroup Name:";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kdgvNodes);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 44);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(589, 398);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kdgvNodes
            // 
            this.kdgvNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kdgvNodes.Location = new System.Drawing.Point(0, 0);
            this.kdgvNodes.Name = "kdgvNodes";
            this.kdgvNodes.Size = new System.Drawing.Size(589, 398);
            this.kdgvNodes.TabIndex = 1;
            // 
            // KryptonNetworkScanner
            // 
            this.ClientSize = new System.Drawing.Size(589, 442);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonNetworkScanner";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scan Network";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kdgvNodes)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnScan;
        private KryptonTextBox ktxtWorkGroupName;
        private KryptonLabel kryptonLabel1;
        private KryptonPanel kryptonPanel2;
        private KryptonDataGridView kdgvNodes;
    }
}