namespace Examples
{
    partial class CoreDialogExamples
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
            this.kbtnColourDialogExamples = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnColourDialogExamples);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(533, 410);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnColourDialogExamples
            // 
            this.kbtnColourDialogExamples.CornerRoundingRadius = -1F;
            this.kbtnColourDialogExamples.Location = new System.Drawing.Point(12, 12);
            this.kbtnColourDialogExamples.Name = "kbtnColourDialogExamples";
            this.kbtnColourDialogExamples.Size = new System.Drawing.Size(154, 25);
            this.kbtnColourDialogExamples.TabIndex = 0;
            this.kbtnColourDialogExamples.Values.Text = "Colour Dialog Examples";
            // 
            // CoreDialogExamples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 410);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "CoreDialogExamples";
            this.Text = "CoreDialogExamples";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnColourDialogExamples;
    }
}