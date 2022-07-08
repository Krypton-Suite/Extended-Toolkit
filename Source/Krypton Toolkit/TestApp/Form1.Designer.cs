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
            this.ktnToolStripItems = new Krypton.Toolkit.KryptonButton();
            this.kbtnButtonItems = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton3 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonButton3);
            this.kryptonPanel1.Controls.Add(this.kryptonButton2);
            this.kryptonPanel1.Controls.Add(this.kryptonButton1);
            this.kryptonPanel1.Controls.Add(this.ktnToolStripItems);
            this.kryptonPanel1.Controls.Add(this.kbtnButtonItems);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(686, 390);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // ktnToolStripItems
            // 
            this.ktnToolStripItems.CornerRoundingRadius = -1F;
            this.ktnToolStripItems.Location = new System.Drawing.Point(12, 38);
            this.ktnToolStripItems.Name = "ktnToolStripItems";
            this.ktnToolStripItems.Size = new System.Drawing.Size(110, 22);
            this.ktnToolStripItems.TabIndex = 1;
            this.ktnToolStripItems.Values.Text = "Tool Strip Items";
            this.ktnToolStripItems.Click += new System.EventHandler(this.ktnToolStripItems_Click);
            // 
            // kbtnButtonItems
            // 
            this.kbtnButtonItems.CornerRoundingRadius = -1F;
            this.kbtnButtonItems.Location = new System.Drawing.Point(10, 10);
            this.kbtnButtonItems.Name = "kbtnButtonItems";
            this.kbtnButtonItems.Size = new System.Drawing.Size(109, 22);
            this.kbtnButtonItems.TabIndex = 0;
            this.kbtnButtonItems.Values.Text = "Button Items";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = -1F;
            this.kryptonButton1.Location = new System.Drawing.Point(358, 10);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(134, 22);
            this.kryptonButton1.TabIndex = 2;
            this.kryptonButton1.Values.Text = "Circular ProgressBar";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.CornerRoundingRadius = -1F;
            this.kryptonButton2.Location = new System.Drawing.Point(125, 10);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(109, 22);
            this.kryptonButton2.TabIndex = 3;
            this.kryptonButton2.Values.Text = "Calendar Items";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.CornerRoundingRadius = -1F;
            this.kryptonButton3.Location = new System.Drawing.Point(240, 10);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.Size = new System.Drawing.Size(109, 22);
            this.kryptonButton3.TabIndex = 4;
            this.kryptonButton3.Values.Text = "CheckSum Tools";
            this.kryptonButton3.Click += new System.EventHandler(this.kryptonButton3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 390);
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
        private Krypton.Toolkit.KryptonButton kryptonButton2;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonButton kryptonButton3;
    }
}