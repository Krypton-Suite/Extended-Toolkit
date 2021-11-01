
namespace Toast
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
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnVersion2 = new Krypton.Toolkit.KryptonButton();
            this.kbtnVersion1 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnVersion2);
            this.kryptonPanel1.Controls.Add(this.kbtnVersion1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(256, 156);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnVersion2
            // 
            this.kbtnVersion2.Location = new System.Drawing.Point(13, 44);
            this.kbtnVersion2.Name = "kbtnVersion2";
            this.kbtnVersion2.Size = new System.Drawing.Size(231, 25);
            this.kbtnVersion2.TabIndex = 1;
            this.kbtnVersion2.Values.Text = "Show Version 2";
            this.kbtnVersion2.Click += new System.EventHandler(this.kbtnVersion2_Click);
            // 
            // kbtnVersion1
            // 
            this.kbtnVersion1.Location = new System.Drawing.Point(13, 13);
            this.kbtnVersion1.Name = "kbtnVersion1";
            this.kbtnVersion1.Size = new System.Drawing.Size(231, 25);
            this.kbtnVersion1.TabIndex = 0;
            this.kbtnVersion1.Values.Text = "Show Version 1";
            this.kbtnVersion1.Click += new System.EventHandler(this.kbtnVersion1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 156);
            this.Controls.Add(this.kryptonPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton kbtnVersion1;
        private Krypton.Toolkit.KryptonButton kbtnVersion2;
    }
}

