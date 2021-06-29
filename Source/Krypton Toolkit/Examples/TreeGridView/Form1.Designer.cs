
namespace TreeGridView
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
            Krypton.Toolkit.Suite.Extended.Tree.Grid.View.TreeGridNode treeGridNode1 = new Krypton.Toolkit.Suite.Extended.Tree.Grid.View.TreeGridNode();
            Krypton.Toolkit.Suite.Extended.Tree.Grid.View.TreeGridNode treeGridNode2 = new Krypton.Toolkit.Suite.Extended.Tree.Grid.View.TreeGridNode();
            Krypton.Toolkit.Suite.Extended.Tree.Grid.View.TreeGridNode treeGridNode3 = new Krypton.Toolkit.Suite.Extended.Tree.Grid.View.TreeGridNode();
            Krypton.Toolkit.Suite.Extended.Tree.Grid.View.TreeGridNode treeGridNode4 = new Krypton.Toolkit.Suite.Extended.Tree.Grid.View.TreeGridNode();
            this.kryptonTreeGridView1 = new Krypton.Toolkit.Suite.Extended.Tree.Grid.View.KryptonTreeGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonTreeGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonTreeGridView1
            // 
            this.kryptonTreeGridView1.AllowUserToAddRows = false;
            this.kryptonTreeGridView1.AllowUserToDeleteRows = false;
            this.kryptonTreeGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.kryptonTreeGridView1.DataSource = null;
            this.kryptonTreeGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTreeGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.kryptonTreeGridView1.FontParentBold = false;
            this.kryptonTreeGridView1.IDColumnName = null;
            this.kryptonTreeGridView1.ImageIndexChild = 0;
            this.kryptonTreeGridView1.ImageList = null;
            this.kryptonTreeGridView1.IsOneLevel = false;
            this.kryptonTreeGridView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTreeGridView1.Name = "kryptonTreeGridView1";
            treeGridNode1.UniqueValue = 2129471220;
            treeGridNode2.UniqueValue = 857821243;
            treeGridNode3.UniqueValue = 356699194;
            treeGridNode4.UniqueValue = 2003060792;
            this.kryptonTreeGridView1.Nodes.Add(treeGridNode1);
            this.kryptonTreeGridView1.Nodes.Add(treeGridNode2);
            this.kryptonTreeGridView1.Nodes.Add(treeGridNode3);
            this.kryptonTreeGridView1.Nodes.Add(treeGridNode4);
            this.kryptonTreeGridView1.ParentIDColumnName = null;
            this.kryptonTreeGridView1.Size = new System.Drawing.Size(527, 477);
            this.kryptonTreeGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 477);
            this.Controls.Add(this.kryptonTreeGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonTreeGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.Tree.Grid.View.KryptonTreeGridView kryptonTreeGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}

