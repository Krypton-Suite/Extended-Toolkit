﻿namespace Krypton.Toolkit.Suite.Extended.Networking
{
    partial class KryptonNodeViewer
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
            this.kbeEdge = new Krypton.Toolkit.KryptonBorderEdge();
            this.kbtnExportNodeList = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kcmbNodeList = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbNodeList)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbeEdge);
            this.kryptonPanel1.Controls.Add(this.kbtnExportNodeList);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 135);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(445, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbeEdge
            // 
            this.kbeEdge.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kbeEdge.Dock = System.Windows.Forms.DockStyle.Top;
            this.kbeEdge.Location = new System.Drawing.Point(0, 0);
            this.kbeEdge.Name = "kbeEdge";
            this.kbeEdge.Size = new System.Drawing.Size(445, 1);
            this.kbeEdge.Text = "kryptonBorderEdge1";
            // 
            // kbtnExportNodeList
            // 
            this.kbtnExportNodeList.Location = new System.Drawing.Point(12, 13);
            this.kbtnExportNodeList.Name = "kbtnExportNodeList";
            this.kbtnExportNodeList.Size = new System.Drawing.Size(166, 25);
            this.kbtnExportNodeList.TabIndex = 2;
            this.kbtnExportNodeList.Values.Text = "Export Node List to &File...";
            this.kbtnExportNodeList.Click += new System.EventHandler(this.kbtnExportNodeList_Click);
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(343, 13);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Text = "O&k";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kcmbNodeList);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(445, 135);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kcmbNodeList
            // 
            this.kcmbNodeList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbNodeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbNodeList.DropDownWidth = 392;
            this.kcmbNodeList.IntegralHeight = false;
            this.kcmbNodeList.Location = new System.Drawing.Point(31, 58);
            this.kcmbNodeList.Name = "kcmbNodeList";
            this.kcmbNodeList.Size = new System.Drawing.Size(392, 21);
            this.kcmbNodeList.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbNodeList.TabIndex = 1;
            this.kcmbNodeList.SelectedIndexChanged += new System.EventHandler(this.kcmbNodeList_SelectedIndexChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(31, 31);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(148, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Available Network Nodes";
            // 
            // KryptonNodeViewer
            // 
            this.AcceptButton = this.kbtnOk;
            this.ClientSize = new System.Drawing.Size(445, 185);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonNodeViewer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Network Nodes";
            this.Load += new System.EventHandler(this.NodeViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbNodeList)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnExportNodeList;
        private KryptonButton kbtnOk;
        private KryptonPanel kryptonPanel2;
        private KryptonComboBox kcmbNodeList;
        private KryptonBorderEdge kbeEdge;
        private KryptonLabel kryptonLabel1;
    }
}