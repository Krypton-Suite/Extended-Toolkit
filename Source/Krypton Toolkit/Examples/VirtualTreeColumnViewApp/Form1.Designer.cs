
namespace VirtualTreeColumnViewApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView.VirtualTreeColumn virtualTreeColumn3 = new Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView.VirtualTreeColumn();
            Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView.VirtualTreeColumn virtualTreeColumn4 = new Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView.VirtualTreeColumn();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.btnAddMillion = new Krypton.Toolkit.KryptonButton();
            this.groupBoxPalette = new System.Windows.Forms.GroupBox();
            this.rbOffice2010Blue = new System.Windows.Forms.RadioButton();
            this.rbSparkle = new System.Windows.Forms.RadioButton();
            this.rbOffice365Blue = new System.Windows.Forms.RadioButton();
            this.rbOffice2003 = new System.Windows.Forms.RadioButton();
            this.rbOffice2007Black = new System.Windows.Forms.RadioButton();
            this.rbOffice2007Blue = new System.Windows.Forms.RadioButton();
            this.kryptonManager1 = new Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPalette = new Krypton.Toolkit.KryptonPalette(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.kryptonVirtualTreeColumnView1 = new Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView.KryptonVirtualTreeColumnView();
            this.btnExpandAll = new Krypton.Toolkit.KryptonButton();
            this.btnCollapseAll = new Krypton.Toolkit.KryptonButton();
            this.lblTimeTaken = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.groupBoxPalette.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.lblTimeTaken);
            this.kryptonPanel1.Controls.Add(this.btnCollapseAll);
            this.kryptonPanel1.Controls.Add(this.btnExpandAll);
            this.kryptonPanel1.Controls.Add(this.btnAddMillion);
            this.kryptonPanel1.Controls.Add(this.kryptonVirtualTreeColumnView1);
            this.kryptonPanel1.Controls.Add(this.groupBoxPalette);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(858, 595);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // btnAddMillion
            // 
            this.btnAddMillion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMillion.Location = new System.Drawing.Point(667, 175);
            this.btnAddMillion.Name = "btnAddMillion";
            this.btnAddMillion.Size = new System.Drawing.Size(179, 25);
            this.btnAddMillion.TabIndex = 5;
            this.btnAddMillion.Values.Text = "Add 1 Million";
            this.btnAddMillion.Click += new System.EventHandler(this.BtnAddMillion_Click);
            // 
            // groupBoxPalette
            // 
            this.groupBoxPalette.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPalette.Controls.Add(this.rbOffice2010Blue);
            this.groupBoxPalette.Controls.Add(this.rbSparkle);
            this.groupBoxPalette.Controls.Add(this.rbOffice365Blue);
            this.groupBoxPalette.Controls.Add(this.rbOffice2003);
            this.groupBoxPalette.Controls.Add(this.rbOffice2007Black);
            this.groupBoxPalette.Controls.Add(this.rbOffice2007Blue);
            this.groupBoxPalette.Location = new System.Drawing.Point(667, 11);
            this.groupBoxPalette.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxPalette.Name = "groupBoxPalette";
            this.groupBoxPalette.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxPalette.Size = new System.Drawing.Size(179, 137);
            this.groupBoxPalette.TabIndex = 3;
            this.groupBoxPalette.TabStop = false;
            this.groupBoxPalette.Text = "Palette";
            // 
            // rbOffice2010Blue
            // 
            this.rbOffice2010Blue.AutoSize = true;
            this.rbOffice2010Blue.Checked = true;
            this.rbOffice2010Blue.Location = new System.Drawing.Point(16, 21);
            this.rbOffice2010Blue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbOffice2010Blue.Name = "rbOffice2010Blue";
            this.rbOffice2010Blue.Size = new System.Drawing.Size(143, 21);
            this.rbOffice2010Blue.TabIndex = 6;
            this.rbOffice2010Blue.TabStop = true;
            this.rbOffice2010Blue.Text = "Office 2010 - Blue";
            this.rbOffice2010Blue.UseVisualStyleBackColor = true;
            this.rbOffice2010Blue.CheckedChanged += new System.EventHandler(this.RbOffice2010Blue_CheckedChanged);
            // 
            // rbSparkle
            // 
            this.rbSparkle.AutoSize = true;
            this.rbSparkle.Location = new System.Drawing.Point(16, 94);
            this.rbSparkle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbSparkle.Name = "rbSparkle";
            this.rbSparkle.Size = new System.Drawing.Size(118, 21);
            this.rbSparkle.TabIndex = 4;
            this.rbSparkle.Text = "Sparkle - Blue";
            this.rbSparkle.UseVisualStyleBackColor = true;
            this.rbSparkle.CheckedChanged += new System.EventHandler(this.RbSparkle_CheckedChanged);
            // 
            // rbOffice365Blue
            // 
            this.rbOffice365Blue.AutoSize = true;
            this.rbOffice365Blue.Location = new System.Drawing.Point(16, 113);
            this.rbOffice365Blue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbOffice365Blue.Name = "rbOffice365Blue";
            this.rbOffice365Blue.Size = new System.Drawing.Size(135, 21);
            this.rbOffice365Blue.TabIndex = 5;
            this.rbOffice365Blue.Text = "Office 365 - Blue";
            this.rbOffice365Blue.UseVisualStyleBackColor = true;
            this.rbOffice365Blue.CheckedChanged += new System.EventHandler(this.RbOffice365Blue_CheckedChanged);
            // 
            // rbOffice2003
            // 
            this.rbOffice2003.AutoSize = true;
            this.rbOffice2003.Location = new System.Drawing.Point(16, 76);
            this.rbOffice2003.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbOffice2003.Name = "rbOffice2003";
            this.rbOffice2003.Size = new System.Drawing.Size(102, 21);
            this.rbOffice2003.TabIndex = 3;
            this.rbOffice2003.Text = "Office 2003";
            this.rbOffice2003.UseVisualStyleBackColor = true;
            this.rbOffice2003.CheckedChanged += new System.EventHandler(this.RbOffice2003_CheckedChanged);
            // 
            // rbOffice2007Black
            // 
            this.rbOffice2007Black.AutoSize = true;
            this.rbOffice2007Black.Location = new System.Drawing.Point(16, 58);
            this.rbOffice2007Black.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbOffice2007Black.Name = "rbOffice2007Black";
            this.rbOffice2007Black.Size = new System.Drawing.Size(149, 21);
            this.rbOffice2007Black.TabIndex = 2;
            this.rbOffice2007Black.Text = "Office 2007 - Black";
            this.rbOffice2007Black.UseVisualStyleBackColor = true;
            this.rbOffice2007Black.CheckedChanged += new System.EventHandler(this.RbOffice2007Black_CheckedChanged);
            // 
            // rbOffice2007Blue
            // 
            this.rbOffice2007Blue.AutoSize = true;
            this.rbOffice2007Blue.Location = new System.Drawing.Point(16, 39);
            this.rbOffice2007Blue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbOffice2007Blue.Name = "rbOffice2007Blue";
            this.rbOffice2007Blue.Size = new System.Drawing.Size(143, 21);
            this.rbOffice2007Blue.TabIndex = 0;
            this.rbOffice2007Blue.Text = "Office 2007 - Blue";
            this.rbOffice2007Blue.UseVisualStyleBackColor = true;
            this.rbOffice2007Blue.CheckedChanged += new System.EventHandler(this.RbOffice2007Blue_CheckedChanged);
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPalette = this.kryptonPalette;
            this.kryptonManager1.GlobalPaletteMode = Krypton.Toolkit.PaletteModeManager.Custom;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // kryptonVirtualTreeColumnView1
            // 
            this.kryptonVirtualTreeColumnView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonVirtualTreeColumnView1.BackStyle = Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            virtualTreeColumn3.Fill = true;
            virtualTreeColumn3.Name = "Add an Auto Header";
            virtualTreeColumn3.Width = 624;
            virtualTreeColumn4.Name = "Image";
            virtualTreeColumn4.Width = 20;
            this.kryptonVirtualTreeColumnView1.Header.Columns.Add(virtualTreeColumn3);
            this.kryptonVirtualTreeColumnView1.Header.Columns.Add(virtualTreeColumn4);
            this.kryptonVirtualTreeColumnView1.Location = new System.Drawing.Point(13, 11);
            this.kryptonVirtualTreeColumnView1.MultiSelect = true;
            this.kryptonVirtualTreeColumnView1.Name = "kryptonVirtualTreeColumnView1";
            this.kryptonVirtualTreeColumnView1.Size = new System.Drawing.Size(648, 572);
            this.kryptonVirtualTreeColumnView1.TabIndex = 4;
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpandAll.Location = new System.Drawing.Point(667, 220);
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(179, 25);
            this.btnExpandAll.TabIndex = 6;
            this.btnExpandAll.Values.Text = "Expand All";
            this.btnExpandAll.Click += new System.EventHandler(this.BtnExpandAll_Click);
            // 
            // btnCollapseAll
            // 
            this.btnCollapseAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollapseAll.Location = new System.Drawing.Point(667, 263);
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.Size = new System.Drawing.Size(179, 25);
            this.btnCollapseAll.TabIndex = 7;
            this.btnCollapseAll.Values.Text = "Collapse All";
            this.btnCollapseAll.Click += new System.EventHandler(this.BtnCollapseAll_Click);
            // 
            // lblTimeTaken
            // 
            this.lblTimeTaken.Location = new System.Drawing.Point(683, 327);
            this.lblTimeTaken.Name = "lblTimeTaken";
            this.lblTimeTaken.Size = new System.Drawing.Size(109, 24);
            this.lblTimeTaken.TabIndex = 8;
            this.lblTimeTaken.Values.Text = "kryptonLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 595);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "Form1";
            this.Text = "VirtualTreeColumnView App";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.groupBoxPalette.ResumeLayout(false);
            this.groupBoxPalette.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView.KryptonVirtualTreeColumnView kryptonVirtualTreeColumnView1;
        private System.Windows.Forms.GroupBox groupBoxPalette;
        private System.Windows.Forms.RadioButton rbOffice2010Blue;
        private System.Windows.Forms.RadioButton rbSparkle;
        private System.Windows.Forms.RadioButton rbOffice365Blue;
        private System.Windows.Forms.RadioButton rbOffice2003;
        private System.Windows.Forms.RadioButton rbOffice2007Black;
        private System.Windows.Forms.RadioButton rbOffice2007Blue;
        private Krypton.Toolkit.KryptonManager kryptonManager1;
        private Krypton.Toolkit.KryptonPalette kryptonPalette;
        private Krypton.Toolkit.KryptonButton btnAddMillion;
        private System.Windows.Forms.ImageList imageList1;
        private Krypton.Toolkit.KryptonLabel lblTimeTaken;
        private Krypton.Toolkit.KryptonButton btnCollapseAll;
        private Krypton.Toolkit.KryptonButton btnExpandAll;
    }
}
