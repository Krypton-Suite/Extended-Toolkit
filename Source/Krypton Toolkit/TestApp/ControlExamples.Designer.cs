namespace TestApp
{
    partial class ControlExamples
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
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonProgressBarExtendedVersion21 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonProgressBarExtendedVersion2();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonProgressBarExtendedVersion21);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 450);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonProgressBarExtendedVersion21
            // 
            this.kryptonProgressBarExtendedVersion21.Location = new System.Drawing.Point(639, 286);
            this.kryptonProgressBarExtendedVersion21.Name = "kryptonProgressBarExtendedVersion21";
            this.kryptonProgressBarExtendedVersion21.Size = new System.Drawing.Size(100, 23);
            this.kryptonProgressBarExtendedVersion21.TabIndex = 0;
            this.kryptonProgressBarExtendedVersion21.Text = "0%";
            this.kryptonProgressBarExtendedVersion21.UseKryptonRender = true;
            // 
            // ControlExamples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "ControlExamples";
            this.Text = "ControlExamples";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonProgressBarExtendedVersion2 kryptonProgressBarExtendedVersion21;
    }
}