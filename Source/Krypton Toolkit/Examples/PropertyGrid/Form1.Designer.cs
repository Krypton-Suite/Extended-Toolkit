
namespace PropertyGrid
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.circularPictureBox1);
            this.Controls.Add(this.kpg);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Property Grid";
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.PropertyGrid.KryptonPropertyGrid kpg;
        private Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox circularPictureBox1;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonBorderedLabel kryptonBorderedLabel1;
        private Krypton.Toolkit.Suite.Extended.Buttons.KryptonCommandLinkButton kryptonCommandLinkButton1;
        private Krypton.Toolkit.Suite.Extended.Circular.ProgressBar.CircularProgressBar circularProgressBar1;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}

