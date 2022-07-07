namespace TestApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnButtonItems = new Krypton.Toolkit.KryptonButton();
            this.ktnToolStripItems = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.ktnToolStripItems);
            this.kryptonPanel1.Controls.Add(this.kbtnButtonItems);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 450);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnButtonItems
            // 
            this.kbtnButtonItems.CornerRoundingRadius = -1F;
            this.kbtnButtonItems.Location = new System.Drawing.Point(12, 12);
            this.kbtnButtonItems.Name = "kbtnButtonItems";
            this.kbtnButtonItems.Size = new System.Drawing.Size(90, 25);
            this.kbtnButtonItems.TabIndex = 0;
            this.kbtnButtonItems.Values.Text = "Button Items";
            // 
            // ktnToolStripItems
            // 
            this.ktnToolStripItems.CornerRoundingRadius = -1F;
            this.ktnToolStripItems.Location = new System.Drawing.Point(108, 12);
            this.ktnToolStripItems.Name = "ktnToolStripItems";
            this.ktnToolStripItems.Size = new System.Drawing.Size(128, 25);
            this.ktnToolStripItems.TabIndex = 1;
            this.ktnToolStripItems.Values.Text = "Tool Strip Items";
            this.ktnToolStripItems.Click += new System.EventHandler(this.ktnToolStripItems_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Landing";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton ktnToolStripItems;
        private Krypton.Toolkit.KryptonButton kbtnButtonItems;
    }
}