
namespace Scrollbars
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
            this.components = new System.ComponentModel.Container();
            this.kryptonScrollBar1 = new Krypton.Toolkit.Suite.Extended.Scroll.Bars.KryptonScrollBar();
            this.kryptonScrollBar2 = new Krypton.Toolkit.Suite.Extended.Scroll.Bars.KryptonScrollBar();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonScrollBar1
            // 
            this.kryptonScrollBar1.Location = new System.Drawing.Point(12, 36);
            this.kryptonScrollBar1.Name = "kryptonScrollBar1";
            this.kryptonScrollBar1.Size = new System.Drawing.Size(19, 200);
            this.kryptonScrollBar1.TabIndex = 0;
            // 
            // kryptonScrollBar2
            // 
            this.kryptonScrollBar2.Location = new System.Drawing.Point(12, 12);
            this.kryptonScrollBar2.Name = "kryptonScrollBar2";
            this.kryptonScrollBar2.Orientation = Krypton.Toolkit.Suite.Extended.Scroll.Bars.ScrollBarOrientation.HORIZONTAL;
            this.kryptonScrollBar2.Size = new System.Drawing.Size(200, 19);
            this.kryptonScrollBar2.TabIndex = 1;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(266, 248);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 248);
            this.Controls.Add(this.kryptonScrollBar2);
            this.Controls.Add(this.kryptonScrollBar1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Scrollbars";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.Suite.Extended.Scroll.Bars.KryptonScrollBar kryptonScrollBar1;
        private Krypton.Toolkit.Suite.Extended.Scroll.Bars.KryptonScrollBar kryptonScrollBar2;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}

