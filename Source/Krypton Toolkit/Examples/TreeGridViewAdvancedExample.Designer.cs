namespace Examples
{
    partial class TreeGridViewAdvancedExample
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeGridViewAdvancedExample));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnDataSource = new Krypton.Toolkit.KryptonButton();
            this.kryptonThemeComboBox1 = new Krypton.Toolkit.KryptonThemeComboBox();
            this.kryptonTreeGridView1 = new Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridView();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageStrip = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonThemeComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonTreeGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnDataSource);
            this.kryptonPanel1.Controls.Add(this.kryptonThemeComboBox1);
            this.kryptonPanel1.Controls.Add(this.kryptonTreeGridView1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 450);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnDataSource
            // 
            this.kbtnDataSource.CornerRoundingRadius = -1F;
            this.kbtnDataSource.Location = new System.Drawing.Point(576, 41);
            this.kbtnDataSource.Name = "kbtnDataSource";
            this.kbtnDataSource.Size = new System.Drawing.Size(212, 31);
            this.kbtnDataSource.TabIndex = 2;
            this.kbtnDataSource.Values.Text = "Open DataSourceExample";
            this.kbtnDataSource.Click += new System.EventHandler(this.kbtnDataSource_Click);
            // 
            // kryptonThemeComboBox1
            // 
            this.kryptonThemeComboBox1.CornerRoundingRadius = -1F;
            this.kryptonThemeComboBox1.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.kryptonThemeComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kryptonThemeComboBox1.DropDownWidth = 212;
            this.kryptonThemeComboBox1.IntegralHeight = false;
            this.kryptonThemeComboBox1.Location = new System.Drawing.Point(576, 13);
            this.kryptonThemeComboBox1.Name = "kryptonThemeComboBox1";
            this.kryptonThemeComboBox1.Size = new System.Drawing.Size(212, 21);
            this.kryptonThemeComboBox1.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonThemeComboBox1.TabIndex = 1;
            // 
            // kryptonTreeGridView1
            // 
            this.kryptonTreeGridView1.AllowUserToAddRows = false;
            this.kryptonTreeGridView1.AllowUserToDeleteRows = false;
            this.kryptonTreeGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonTreeGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.kryptonTreeGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Subject,
            this.From,
            this.Date});
            this.kryptonTreeGridView1.DataSource = null;
            this.kryptonTreeGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.kryptonTreeGridView1.ImageList = null;
            this.kryptonTreeGridView1.Location = new System.Drawing.Point(13, 13);
            this.kryptonTreeGridView1.Name = "kryptonTreeGridView1";
            this.kryptonTreeGridView1.Size = new System.Drawing.Size(556, 425);
            this.kryptonTreeGridView1.TabIndex = 0;
            // 
            // Subject
            // 
            this.Subject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Subject.HeaderText = "Subject";
            this.Subject.Name = "Subject";
            this.Subject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // From
            // 
            this.From.HeaderText = "From";
            this.From.Name = "From";
            this.From.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.From.Width = 45;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Date.Width = 41;
            // 
            // imageStrip
            // 
            this.imageStrip.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageStrip.ImageSize = new System.Drawing.Size(16, 16);
            this.imageStrip.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // TreeGridViewAdvancedExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TreeGridViewAdvancedExample";
            this.Text = "TreeGridView Example";
            this.Shown += new System.EventHandler(this.TreeGridViewAdvancedExample_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonThemeComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonTreeGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridView kryptonTreeGridView1;
        private KryptonButton kbtnDataSource;
        private KryptonThemeComboBox kryptonThemeComboBox1;
        private DataGridViewTextBoxColumn Subject;
        private DataGridViewTextBoxColumn From;
        private DataGridViewTextBoxColumn Date;
        private ImageList imageStrip;
    }
}