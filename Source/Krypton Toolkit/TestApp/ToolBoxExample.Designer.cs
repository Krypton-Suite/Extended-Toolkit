namespace TestApp
{
    partial class ToolBoxExample
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
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonToolBox1 = new Krypton.Toolkit.Suite.Extended.Tool.Box.KryptonToolBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonToolBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 450);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonToolBox1
            // 
            this.kryptonToolBox1.AllowDrop = true;
            this.kryptonToolBox1.AllowSwappingByDragDrop = true;
            this.kryptonToolBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.kryptonToolBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonToolBox1.InitialScrollDelay = 500;
            this.kryptonToolBox1.ItemBackgroundColour = System.Drawing.Color.Empty;
            this.kryptonToolBox1.ItemBorderColour = System.Drawing.Color.Empty;
            this.kryptonToolBox1.ItemHeight = 20;
            this.kryptonToolBox1.ItemHoverColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(107)))));
            this.kryptonToolBox1.ItemHoverTextColour = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(242)))), ((int)(((byte)(215)))));
            this.kryptonToolBox1.ItemNormalColour = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(157)))), ((int)(((byte)(189)))));
            this.kryptonToolBox1.ItemNormalTextColour = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonToolBox1.ItemSelectedColour = System.Drawing.Color.White;
            this.kryptonToolBox1.ItemSelectedTextColour = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(242)))), ((int)(((byte)(215)))));
            this.kryptonToolBox1.ItemSpacing = 2;
            this.kryptonToolBox1.LargeItemSize = new System.Drawing.Size(64, 64);
            this.kryptonToolBox1.LayoutDelay = 10;
            this.kryptonToolBox1.Location = new System.Drawing.Point(12, 12);
            this.kryptonToolBox1.Name = "kryptonToolBox1";
            this.kryptonToolBox1.ScrollDelay = 60;
            this.kryptonToolBox1.SelectAllTextWhileRenaming = true;
            this.kryptonToolBox1.SelectedTabIndex = -1;
            this.kryptonToolBox1.ShowOnlyOneItemPerRow = false;
            this.kryptonToolBox1.Size = new System.Drawing.Size(274, 426);
            this.kryptonToolBox1.SmallItemSize = new System.Drawing.Size(32, 32);
            this.kryptonToolBox1.TabHeight = 18;
            this.kryptonToolBox1.TabHoverTextColour = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(242)))), ((int)(((byte)(215)))));
            this.kryptonToolBox1.TabIndex = 0;
            this.kryptonToolBox1.TabNormalTextColour = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonToolBox1.TabSelectedTextColour = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonToolBox1.TabSpacing = 1;
            this.kryptonToolBox1.UseItemColorInRename = false;
            // 
            // ToolBoxExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "ToolBoxExample";
            this.Text = "ToolBoxExample";
            this.Load += new System.EventHandler(this.ToolBoxExample_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.Tool.Box.KryptonToolBox kryptonToolBox1;
    }
}