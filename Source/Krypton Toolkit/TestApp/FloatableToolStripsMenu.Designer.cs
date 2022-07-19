namespace TestApp
{
    partial class FloatableToolStripsMenu
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
            this.kbtnFloatableMenuStrip = new Krypton.Toolkit.KryptonButton();
            this.kbtnFloatableToolStrip = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnFloatableToolStrip);
            this.kryptonPanel1.Controls.Add(this.kbtnFloatableMenuStrip);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(338, 145);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnFloatableMenuStrip
            // 
            this.kbtnFloatableMenuStrip.CornerRoundingRadius = -1F;
            this.kbtnFloatableMenuStrip.Location = new System.Drawing.Point(56, 35);
            this.kbtnFloatableMenuStrip.Name = "kbtnFloatableMenuStrip";
            this.kbtnFloatableMenuStrip.Size = new System.Drawing.Size(231, 25);
            this.kbtnFloatableMenuStrip.TabIndex = 0;
            this.kbtnFloatableMenuStrip.Values.Text = "Floatable Menu Strip";
            this.kbtnFloatableMenuStrip.Click += new System.EventHandler(this.kbtnFloatableMenuStrip_Click);
            // 
            // kbtnFloatableToolStrip
            // 
            this.kbtnFloatableToolStrip.CornerRoundingRadius = -1F;
            this.kbtnFloatableToolStrip.Location = new System.Drawing.Point(56, 85);
            this.kbtnFloatableToolStrip.Name = "kbtnFloatableToolStrip";
            this.kbtnFloatableToolStrip.Size = new System.Drawing.Size(231, 25);
            this.kbtnFloatableToolStrip.TabIndex = 1;
            this.kbtnFloatableToolStrip.Values.Text = "Floatable Tool Strip";
            this.kbtnFloatableToolStrip.Click += new System.EventHandler(this.kbtnFloatableToolStrip_Click);
            // 
            // FloatableToolStripsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 145);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.Name = "FloatableToolStripsMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FloatableToolStrips";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton kbtnFloatableMenuStrip;
        private Krypton.Toolkit.KryptonButton kbtnFloatableToolStrip;
    }
}