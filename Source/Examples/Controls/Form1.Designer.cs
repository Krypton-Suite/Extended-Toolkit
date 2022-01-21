
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
            this.kryptonValidationBox1 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonValidationBox();
            this.kryptonFlowLayoutPanel1 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonFlowLayoutPanel();
            this.kryptonButtonPanel1 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonButtonPanel();
            this.kryptonBorderedLabel1 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonBorderedLabel();
            this.circularPictureBox1 = new Krypton.Toolkit.Suite.Extended.Controls.CircularPictureBox();
            this.ktxtValidationText = new Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.circularPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonValidationBox1
            // 
            this.kryptonValidationBox1.IntermediateColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.kryptonValidationBox1.Location = new System.Drawing.Point(300, 147);
            this.kryptonValidationBox1.ModifyBackgroundColour = false;
            this.kryptonValidationBox1.Name = "kryptonValidationBox1";
            this.kryptonValidationBox1.Size = new System.Drawing.Size(200, 23);
            this.kryptonValidationBox1.TabIndex = 4;
            this.kryptonValidationBox1.Text = "kryptonValidationBox1";
            this.kryptonValidationBox1.UseAccessibilityColours = false;
            this.kryptonValidationBox1.UseIntermediateColour = false;
            this.kryptonValidationBox1.ValidateEntry = false;
            // 
            // kryptonFlowLayoutPanel1
            // 
            this.kryptonFlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.kryptonFlowLayoutPanel1.Location = new System.Drawing.Point(300, 12);
            this.kryptonFlowLayoutPanel1.Name = "kryptonFlowLayoutPanel1";
            this.kryptonFlowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.kryptonFlowLayoutPanel1.TabIndex = 3;
            // 
            // kryptonButtonPanel1
            // 
            this.kryptonButtonPanel1.BackColor = System.Drawing.Color.Transparent;
            this.kryptonButtonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonButtonPanel1.Location = new System.Drawing.Point(0, 400);
            this.kryptonButtonPanel1.Name = "kryptonButtonPanel1";
            this.kryptonButtonPanel1.Size = new System.Drawing.Size(517, 50);
            this.kryptonButtonPanel1.TabIndex = 2;
            // 
            // kryptonBorderedLabel1
            // 
            this.kryptonBorderedLabel1.BackColor = System.Drawing.Color.Transparent;
            this.kryptonBorderedLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.kryptonBorderedLabel1.Location = new System.Drawing.Point(154, 12);
            this.kryptonBorderedLabel1.Name = "kryptonBorderedLabel1";
            this.kryptonBorderedLabel1.Size = new System.Drawing.Size(140, 20);
            this.kryptonBorderedLabel1.TabIndex = 1;
            this.kryptonBorderedLabel1.Values.Text = "Krypton Bordered Label";
            // 
            // circularPictureBox1
            // 
            this.circularPictureBox1.BackColor = System.Drawing.Color.DarkRed;
            this.circularPictureBox1.Location = new System.Drawing.Point(12, 12);
            this.circularPictureBox1.Name = "circularPictureBox1";
            this.circularPictureBox1.Size = new System.Drawing.Size(135, 131);
            this.circularPictureBox1.TabIndex = 0;
            this.circularPictureBox1.TabStop = false;
            // 
            // ktxtValidationText
            // 
            this.ktxtValidationText.Location = new System.Drawing.Point(300, 177);
            this.ktxtValidationText.Name = "ktxtValidationText";
            this.ktxtValidationText.Size = new System.Drawing.Size(200, 23);
            this.ktxtValidationText.TabIndex = 5;
            this.ktxtValidationText.Text = "kryptonTextBox1";
            this.ktxtValidationText.TextChanged += new System.EventHandler(this.ktxtValidationText_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 450);
            this.Controls.Add(this.ktxtValidationText);
            this.Controls.Add(this.kryptonValidationBox1);
            this.Controls.Add(this.kryptonFlowLayoutPanel1);
            this.Controls.Add(this.kryptonButtonPanel1);
            this.Controls.Add(this.kryptonBorderedLabel1);
            this.Controls.Add(this.circularPictureBox1);
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
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonValidationBox kryptonValidationBox1;
        private Krypton.Toolkit.KryptonTextBox ktxtValidationText;
    }
}

