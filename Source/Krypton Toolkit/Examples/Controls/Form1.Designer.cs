
namespace Controls
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
            this.circularPictureBox1 = new Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox();
            this.kryptonBorderedLabel1 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonBorderedLabel();
            this.kryptonButtonPanel1 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonButtonPanel();
            this.kryptonFlowLayoutPanel1 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonFlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // circularPictureBox1
            // 
            this.circularPictureBox1.BackColor = System.Drawing.Color.DarkRed;
            this.circularPictureBox1.Location = new System.Drawing.Point(14, 14);
            this.circularPictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.circularPictureBox1.Name = "circularPictureBox1";
            this.circularPictureBox1.Size = new System.Drawing.Size(158, 151);
            this.circularPictureBox1.TabIndex = 0;
            this.circularPictureBox1.TabStop = false;
            // 
            // kryptonBorderedLabel1
            // 
            this.kryptonBorderedLabel1.BackColor = System.Drawing.Color.Transparent;
            this.kryptonBorderedLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kryptonBorderedLabel1.Location = new System.Drawing.Point(180, 14);
            this.kryptonBorderedLabel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.kryptonBorderedLabel1.Name = "kryptonBorderedLabel1";
            this.kryptonBorderedLabel1.Size = new System.Drawing.Size(140, 20);
            this.kryptonBorderedLabel1.TabIndex = 1;
            this.kryptonBorderedLabel1.Values.Text = "Krypton Bordered Label";
            // 
            // kryptonButtonPanel1
            // 
            this.kryptonButtonPanel1.BackColor = System.Drawing.Color.Transparent;
            this.kryptonButtonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonButtonPanel1.Location = new System.Drawing.Point(0, 461);
            this.kryptonButtonPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.kryptonButtonPanel1.Name = "kryptonButtonPanel1";
            this.kryptonButtonPanel1.Size = new System.Drawing.Size(603, 58);
            this.kryptonButtonPanel1.TabIndex = 2;
            // 
            // kryptonFlowLayoutPanel1
            // 
            this.kryptonFlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.kryptonFlowLayoutPanel1.Location = new System.Drawing.Point(350, 14);
            this.kryptonFlowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.kryptonFlowLayoutPanel1.Name = "kryptonFlowLayoutPanel1";
            this.kryptonFlowLayoutPanel1.Size = new System.Drawing.Size(233, 115);
            this.kryptonFlowLayoutPanel1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 519);
            this.Controls.Add(this.kryptonFlowLayoutPanel1);
            this.Controls.Add(this.kryptonButtonPanel1);
            this.Controls.Add(this.kryptonBorderedLabel1);
            this.Controls.Add(this.circularPictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Controls";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox circularPictureBox1;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonBorderedLabel kryptonBorderedLabel1;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonButtonPanel kryptonButtonPanel1;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonFlowLayoutPanel kryptonFlowLayoutPanel1;
    }
}

