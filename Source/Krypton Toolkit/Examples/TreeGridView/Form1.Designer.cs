
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
            /*Krypton.Toolkit.Suite.Extended.TreeGridView..TreeGridNode treeGridNode1 = new Krypton.Toolkit.Suite.Extended.TreeGridView.TreeGridNode();
            Krypton.Toolkit.Suite.Extended.TreeGridView.TreeGridNode treeGridNode2 = new Krypton.Toolkit.Suite.Extended.TreeGridView.TreeGridNode();
            Krypton.Toolkit.Suite.Extended.TreeGridView.TreeGridNode treeGridNode3 = new Krypton.Toolkit.Suite.Extended.TreeGridView.TreeGridNode();
            Krypton.Toolkit.Suite.Extended.TreeGridView.TreeGridNode treeGridNode4 = new Krypton.Toolkit.Suite.Extended.TreeGridView.TreeGridNode();
            Krypton.Toolkit.Suite.Extended.TreeGridView.TreeGridNode treeGridNode5 = new Krypton.Toolkit.Suite.Extended.TreeGridView.TreeGridNode();
            Krypton.Toolkit.Suite.Extended.TreeGridView.TreeGridNode treeGridNode6 = new Krypton.Toolkit.Suite.Extended.TreeGridView.TreeGridNode();
            Krypton.Toolkit.Suite.Extended.TreeGridView.TreeGridNode treeGridNode7 = new Krypton.Toolkit.Suite.Extended.TreeGridView.TreeGridNode();
            Krypton.Toolkit.Suite.Extended.TreeGridView.TreeGridNode treeGridNode8 = new Krypton.Toolkit.Suite.Extended.TreeGridView.TreeGridNode();*/
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kryptonTreeGridView1 = new Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonTreeGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colFirstName
            // 
            this.colFirstName.HeaderText = "First Name";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colLastName
            // 
            this.colLastName.HeaderText = "Last Name";
            this.colLastName.Name = "colLastName";
            this.colLastName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCountry
            // 
            this.colCountry.HeaderText = "Country";
            this.colCountry.Name = "colCountry";
            this.colCountry.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPhone
            // 
            this.colPhone.HeaderText = "Phone";
            this.colPhone.Name = "colPhone";
            this.colPhone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // kryptonTreeGridView1
            // 
            this.kryptonTreeGridView1.AllowUserToAddRows = false;
            this.kryptonTreeGridView1.AllowUserToDeleteRows = false;
            this.kryptonTreeGridView1.DataSource = null;
            this.kryptonTreeGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTreeGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.kryptonTreeGridView1.FontParentBold = false;
            /*treeGridNode1.Height = 25;
            treeGridNode2.Height = 25;
            treeGridNode2.UniqueValue = 1027317378;
            treeGridNode3.Height = 25;
            treeGridNode3.UniqueValue = 1057748041;
            treeGridNode1.Nodes.Add(treeGridNode2);
            treeGridNode1.Nodes.Add(treeGridNode3);
            treeGridNode1.UniqueValue = 413721102;
            treeGridNode4.Height = 25;
            treeGridNode4.UniqueValue = 1978116688;
            treeGridNode5.Height = 25;
            treeGridNode5.UniqueValue = 1088269265;
            treeGridNode6.Height = 25;
            treeGridNode6.UniqueValue = 160900246;
            treeGridNode7.Height = 25;
            treeGridNode7.UniqueValue = 535611867;
            treeGridNode8.Height = 25;
            treeGridNode8.UniqueValue = 491167451;
            this.kryptonTreeGridView1.GridNode.Add(treeGridNode1);
            this.kryptonTreeGridView1.GridNode.Add(treeGridNode4);
            this.kryptonTreeGridView1.GridNode.Add(treeGridNode5);
            this.kryptonTreeGridView1.GridNode.Add(treeGridNode6);
            this.kryptonTreeGridView1.GridNode.Add(treeGridNode7);
            this.kryptonTreeGridView1.GridNode.Add(treeGridNode8);
            this.kryptonTreeGridView1.IDColumnName = null;*/
            this.kryptonTreeGridView1.ImageIndexChild = 0;
            this.kryptonTreeGridView1.ImageList = null;
            this.kryptonTreeGridView1.IsOneLevel = false;
            this.kryptonTreeGridView1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTreeGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.kryptonTreeGridView1.Name = "kryptonTreeGridView1";
            //this.kryptonTreeGridView1.ParentIDColumnName = null;
            this.kryptonTreeGridView1.Size = new System.Drawing.Size(1103, 479);
            this.kryptonTreeGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 479);
            this.Controls.Add(this.kryptonTreeGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "TreeGridView";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonTreeGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private Krypton.Toolkit.Suite.Extended.TreeGridView.KryptonTreeGridView kryptonTreeGridView1;
    }
}

