namespace Examples
{
    partial class ExtendedProgressBarTest
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
            this.kryptonPropertyGrid1 = new Krypton.Toolkit.KryptonPropertyGrid();
            this.kryptonProgressBarExtended1 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonProgressBarExtendedTest();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonProgressBarExtended1);
            this.kryptonPanel1.Controls.Add(this.kryptonPropertyGrid1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(949, 619);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonPropertyGrid1
            // 
            this.kryptonPropertyGrid1.Location = new System.Drawing.Point(584, 12);
            this.kryptonPropertyGrid1.Name = "kryptonPropertyGrid1";
            this.kryptonPropertyGrid1.Padding = new System.Windows.Forms.Padding(1);
            this.kryptonPropertyGrid1.SelectedObject = this.kryptonProgressBarExtended1;
            this.kryptonPropertyGrid1.Size = new System.Drawing.Size(353, 431);
            this.kryptonPropertyGrid1.TabIndex = 0;
            this.kryptonPropertyGrid1.Text = "kryptonPropertyGrid1";
            // 
            // kryptonProgressBarExtended1
            // 
            this.kryptonProgressBarExtended1.Location = new System.Drawing.Point(12, 12);
            this.kryptonProgressBarExtended1.Name = "kryptonProgressBarExtended1";
            this.kryptonProgressBarExtended1.Size = new System.Drawing.Size(100, 23);
            this.kryptonProgressBarExtended1.TabIndex = 1;
            this.kryptonProgressBarExtended1.Text = "35%";
            this.kryptonProgressBarExtended1.ThreeColorState.UseThreeColorState = true;
            this.kryptonProgressBarExtended1.Value = 35;
            // 
            // ExtendedProgressBarTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 619);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "ExtendedProgressBarTest";
            this.Text = "ExtendedProgressBarTest";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonPropertyGrid kryptonPropertyGrid1;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonProgressBarExtendedTest kryptonProgressBarExtended1;
    }
}