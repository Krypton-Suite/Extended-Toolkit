namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    partial class OutlookBarNavigationPaneOptions
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
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnReset = new Krypton.Toolkit.KryptonButton();
            this.kbtnMoveDown = new Krypton.Toolkit.KryptonButton();
            this.kbtnMoveUp = new Krypton.Toolkit.KryptonButton();
            this.kclbItems = new Krypton.Toolkit.KryptonCheckedListBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.clbItems = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 222);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(411, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(213, 13);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 2;
            this.kbtnOk.Values.Text = "&OK";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(309, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 1;
            this.kbtnCancel.Values.Text = "&Cancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(411, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.clbItems);
            this.kryptonPanel2.Controls.Add(this.kbtnReset);
            this.kryptonPanel2.Controls.Add(this.kbtnMoveDown);
            this.kryptonPanel2.Controls.Add(this.kbtnMoveUp);
            this.kryptonPanel2.Controls.Add(this.kclbItems);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(411, 222);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kbtnReset
            // 
            this.kbtnReset.Enabled = false;
            this.kbtnReset.Location = new System.Drawing.Point(309, 183);
            this.kbtnReset.Name = "kbtnReset";
            this.kbtnReset.Size = new System.Drawing.Size(90, 25);
            this.kbtnReset.TabIndex = 4;
            this.kbtnReset.Values.Text = "R&eset";
            this.kbtnReset.Click += new System.EventHandler(this.kbtnReset_Click);
            // 
            // kbtnMoveDown
            // 
            this.kbtnMoveDown.Location = new System.Drawing.Point(309, 70);
            this.kbtnMoveDown.Name = "kbtnMoveDown";
            this.kbtnMoveDown.Size = new System.Drawing.Size(90, 25);
            this.kbtnMoveDown.TabIndex = 3;
            this.kbtnMoveDown.Values.Text = "Move Do&wn";
            this.kbtnMoveDown.Click += new System.EventHandler(this.kbtnMoveDown_Click);
            // 
            // kbtnMoveUp
            // 
            this.kbtnMoveUp.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnMoveUp.Location = new System.Drawing.Point(310, 39);
            this.kbtnMoveUp.Name = "kbtnMoveUp";
            this.kbtnMoveUp.Size = new System.Drawing.Size(90, 25);
            this.kbtnMoveUp.TabIndex = 2;
            this.kbtnMoveUp.Values.Text = "Move &Up";
            this.kbtnMoveUp.Click += new System.EventHandler(this.kbtnMoveUp_Click);
            // 
            // kclbItems
            // 
            this.kclbItems.Location = new System.Drawing.Point(13, 39);
            this.kclbItems.Name = "kclbItems";
            this.kclbItems.Size = new System.Drawing.Size(290, 169);
            this.kclbItems.TabIndex = 1;
            this.kclbItems.SelectedIndexChanged += new System.EventHandler(this.kclbItems_SelectedIndexChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 13);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(176, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Display buttons in this order";
            // 
            // clbItems
            // 
            this.clbItems.FormattingEnabled = true;
            this.clbItems.Location = new System.Drawing.Point(13, 39);
            this.clbItems.Name = "clbItems";
            this.clbItems.Size = new System.Drawing.Size(290, 169);
            this.clbItems.TabIndex = 2;
            // 
            // OutlookBarNavigationPaneOptions
            // 
            this.AcceptButton = this.kbtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(411, 272);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OutlookBarNavigationPaneOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OutlookBarNavigationPaneOptions";
            this.Load += new System.EventHandler(this.OutlookBarNavigationPaneOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnCancel;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonLabel kryptonLabel1;
        private KryptonButton kbtnMoveUp;
        private KryptonCheckedListBox kclbItems;
        private KryptonButton kbtnReset;
        private KryptonButton kbtnMoveDown;
        private CheckedListBox clbItems;
    }
}