
namespace ComboBox
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node8");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node9");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node10");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node5");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node6");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node7");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Node4", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10});
            this.kryptonComboBox1 = new Krypton.Toolkit.Suite.Extended.ComboBox.KryptonComboBox();
            this.kryptonComboBoxEnhanced1 = new Krypton.Toolkit.Suite.Extended.ComboBox.KryptonComboBoxEnhanced();
            this.kryptonComboBoxTree1 = new Krypton.Toolkit.Suite.Extended.ComboBox.KryptonComboBoxTree();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBoxEnhanced1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonComboBox1
            // 
            this.kryptonComboBox1.DisableBorderColour = false;
            this.kryptonComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kryptonComboBox1.FormattingEnabled = true;
            this.kryptonComboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.kryptonComboBox1.Location = new System.Drawing.Point(12, 12);
            this.kryptonComboBox1.Name = "kryptonComboBox1";
            this.kryptonComboBox1.PersistentColours = false;
            this.kryptonComboBox1.Size = new System.Drawing.Size(201, 21);
            this.kryptonComboBox1.TabIndex = 0;
            this.kryptonComboBox1.UseStyledColours = false;
            // 
            // kryptonComboBoxEnhanced1
            // 
            this.kryptonComboBoxEnhanced1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kryptonComboBoxEnhanced1.DropDownWidth = 201;
            this.kryptonComboBoxEnhanced1.IntegralHeight = false;
            this.kryptonComboBoxEnhanced1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.kryptonComboBoxEnhanced1.Location = new System.Drawing.Point(12, 39);
            this.kryptonComboBoxEnhanced1.Name = "kryptonComboBoxEnhanced1";
            this.kryptonComboBoxEnhanced1.PersistentColours = false;
            this.kryptonComboBoxEnhanced1.Size = new System.Drawing.Size(201, 21);
            this.kryptonComboBoxEnhanced1.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonComboBoxEnhanced1.TabIndex = 1;
            this.kryptonComboBoxEnhanced1.UseStyledColours = false;
            // 
            // kryptonComboBoxTree1
            // 
            this.kryptonComboBoxTree1.AbsoluteChildrenSelectableOnly = true;
            this.kryptonComboBoxTree1.BranchSeparator = null;
            this.kryptonComboBoxTree1.Imagelist = null;
            this.kryptonComboBoxTree1.Location = new System.Drawing.Point(12, 66);
            this.kryptonComboBoxTree1.Name = "kryptonComboBoxTree1";
            treeNode1.Name = "Node8";
            treeNode1.Text = "Node8";
            treeNode2.Name = "Node9";
            treeNode2.Text = "Node9";
            treeNode3.Name = "Node10";
            treeNode3.Text = "Node10";
            treeNode4.Name = "Node1";
            treeNode4.Text = "Node1";
            treeNode5.Name = "Node2";
            treeNode5.Text = "Node2";
            treeNode6.Name = "Node3";
            treeNode6.Text = "Node3";
            treeNode7.Name = "Node0";
            treeNode7.Text = "Node0";
            treeNode8.Name = "Node5";
            treeNode8.Text = "Node5";
            treeNode9.Name = "Node6";
            treeNode9.Text = "Node6";
            treeNode10.Name = "Node7";
            treeNode10.Text = "Node7";
            treeNode11.Name = "Node4";
            treeNode11.Text = "Node4";
            this.kryptonComboBoxTree1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode11});
            this.kryptonComboBoxTree1.SelectedNode = null;
            this.kryptonComboBoxTree1.Size = new System.Drawing.Size(201, 24);
            this.kryptonComboBoxTree1.TabIndex = 2;
            this.kryptonComboBoxTree1.Text = "kryptonComboBoxTree1";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonComboBoxTree1);
            this.kryptonPanel1.Controls.Add(this.kryptonComboBox1);
            this.kryptonPanel1.Controls.Add(this.kryptonComboBoxEnhanced1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(256, 99);
            this.kryptonPanel1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 99);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "ComboBoxes";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonComboBoxEnhanced1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.ComboBox.KryptonComboBox kryptonComboBox1;
        private Krypton.Toolkit.Suite.Extended.ComboBox.KryptonComboBoxEnhanced kryptonComboBoxEnhanced1;
        private Krypton.Toolkit.Suite.Extended.ComboBox.KryptonComboBoxTree kryptonComboBoxTree1;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}

