
namespace TreeGridViewApp
{
    partial class MainForm1
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
            this.groupBoxPalette = new System.Windows.Forms.GroupBox();
            this.rbOffice2010Blue = new System.Windows.Forms.RadioButton();
            this.rbSparkle = new System.Windows.Forms.RadioButton();
            this.rbSystem = new System.Windows.Forms.RadioButton();
            this.rbOffice2003 = new System.Windows.Forms.RadioButton();
            this.rbOffice2007Black = new System.Windows.Forms.RadioButton();
            this.rbOffice2007Blue = new System.Windows.Forms.RadioButton();
            this.treeGridView1 = new Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridView();
            this.Column2 = new Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridColumn();
            this.Column3 = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.Column4 = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.imageStrip = new System.Windows.Forms.ImageList(this.components);
            this.kryptonPalette = new Krypton.Toolkit.KryptonPalette(this.components);
            this.kryptonManager1 = new Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.groupBoxPalette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxPalette
            // 
            this.groupBoxPalette.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPalette.Controls.Add(this.rbOffice2010Blue);
            this.groupBoxPalette.Controls.Add(this.rbSparkle);
            this.groupBoxPalette.Controls.Add(this.rbSystem);
            this.groupBoxPalette.Controls.Add(this.rbOffice2003);
            this.groupBoxPalette.Controls.Add(this.rbOffice2007Black);
            this.groupBoxPalette.Controls.Add(this.rbOffice2007Blue);
            this.groupBoxPalette.Location = new System.Drawing.Point(882, 11);
            this.groupBoxPalette.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxPalette.Name = "groupBoxPalette";
            this.groupBoxPalette.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxPalette.Size = new System.Drawing.Size(179, 137);
            this.groupBoxPalette.TabIndex = 2;
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
            this.rbOffice2010Blue.CheckedChanged += new System.EventHandler(this.rbOffice2010Blue_CheckedChanged);
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
            this.rbSparkle.CheckedChanged += new System.EventHandler(this.rbSparkle_CheckedChanged);
            // 
            // rbSystem
            // 
            this.rbSystem.AutoSize = true;
            this.rbSystem.Location = new System.Drawing.Point(16, 113);
            this.rbSystem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbSystem.Name = "rbSystem";
            this.rbSystem.Size = new System.Drawing.Size(75, 21);
            this.rbSystem.TabIndex = 5;
            this.rbSystem.Text = "System";
            this.rbSystem.UseVisualStyleBackColor = true;
            this.rbSystem.CheckedChanged += new System.EventHandler(this.rbSystem_CheckedChanged);
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
            this.rbOffice2003.CheckedChanged += new System.EventHandler(this.rbOffice2003_CheckedChanged);
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
            this.rbOffice2007Black.CheckedChanged += new System.EventHandler(this.rbOffice2007Black_CheckedChanged);
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
            this.rbOffice2007Blue.CheckedChanged += new System.EventHandler(this.rbOffice2007Blue_CheckedChanged);
            // 
            // treeGridView1
            // 
            this.treeGridView1.AllowUserToAddRows = false;
            this.treeGridView1.AllowUserToDeleteRows = false;
            this.treeGridView1.AllowUserToOrderColumns = true;
            this.treeGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.treeGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.treeGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4});
            this.treeGridView1.DataSource = null;
            this.treeGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.treeGridView1.ImageList = this.imageStrip;
            this.treeGridView1.Location = new System.Drawing.Point(13, 13);
            this.treeGridView1.Name = "treeGridView1";
            this.treeGridView1.RowHeadersVisible = false;
            this.treeGridView1.RowHeadersWidth = 51;
            this.treeGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.treeGridView1.Size = new System.Drawing.Size(843, 513);
            this.treeGridView1.TabIndex = 3;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Subject";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 738;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "From";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 53;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Date";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 51;
            // 
            // imageStrip
            // 
            this.imageStrip.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageStrip.ImageSize = new System.Drawing.Size(16, 16);
            this.imageStrip.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPalette = this.kryptonPalette;
            this.kryptonManager1.GlobalPaletteMode = Krypton.Toolkit.PaletteModeManager.Custom;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(898, 368);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(143, 58);
            this.kryptonButton1.StateCommon.Content.ShortText.MultiLine = Krypton.Toolkit.InheritBool.True;
            this.kryptonButton1.StateCommon.Content.ShortText.MultiLineH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonButton1.TabIndex = 4;
            this.kryptonButton1.Values.Text = "Open DataSource\r\nExample";
            this.kryptonButton1.Click += new System.EventHandler(this.KryptonButton1_Click);
            // 
            // MainForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 538);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.treeGridView1);
            this.Controls.Add(this.groupBoxPalette);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm1";
            this.Text = "TreeGridView Demo App";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBoxPalette.ResumeLayout(false);
            this.groupBoxPalette.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPalette;
        private System.Windows.Forms.RadioButton rbOffice2010Blue;
        private System.Windows.Forms.RadioButton rbSparkle;
        private System.Windows.Forms.RadioButton rbSystem;
        private System.Windows.Forms.RadioButton rbOffice2003;
        private System.Windows.Forms.RadioButton rbOffice2007Black;
        private System.Windows.Forms.RadioButton rbOffice2007Blue;
        private Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridView treeGridView1;
        private Krypton.Toolkit.KryptonPalette kryptonPalette;
        private Krypton.Toolkit.KryptonManager kryptonManager1;
        private System.Windows.Forms.ImageList imageStrip;
        private Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridColumn Column2;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column3;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Column4;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
    }
}

