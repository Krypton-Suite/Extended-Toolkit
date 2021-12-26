namespace DataVisualisation.ScottPlot.Demos
{
    partial class TransparentBackground
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
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnRed = new Krypton.Toolkit.KryptonButton();
            this.kbtnGreen = new Krypton.Toolkit.KryptonButton();
            this.kbtnBlue = new Krypton.Toolkit.KryptonButton();
            this.kbtnWhite = new Krypton.Toolkit.KryptonButton();
            this.kbtnControl = new Krypton.Toolkit.KryptonButton();
            this.kbtnImage = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.formsPlot1 = new Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnImage);
            this.kryptonPanel2.Controls.Add(this.kbtnControl);
            this.kryptonPanel2.Controls.Add(this.kbtnWhite);
            this.kryptonPanel2.Controls.Add(this.kbtnBlue);
            this.kryptonPanel2.Controls.Add(this.kbtnGreen);
            this.kryptonPanel2.Controls.Add(this.kbtnRed);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(800, 44);
            this.kryptonPanel2.TabIndex = 6;
            // 
            // kbtnRed
            // 
            this.kbtnRed.Location = new System.Drawing.Point(12, 12);
            this.kbtnRed.Name = "kbtnRed";
            this.kbtnRed.Size = new System.Drawing.Size(72, 25);
            this.kbtnRed.TabIndex = 12;
            this.kbtnRed.Values.Text = "&Red";
            this.kbtnRed.Click += new System.EventHandler(this.kbtnRed_Click);
            // 
            // kbtnGreen
            // 
            this.kbtnGreen.Location = new System.Drawing.Point(90, 12);
            this.kbtnGreen.Name = "kbtnGreen";
            this.kbtnGreen.Size = new System.Drawing.Size(72, 25);
            this.kbtnGreen.TabIndex = 13;
            this.kbtnGreen.Values.Text = "Gree&n";
            this.kbtnGreen.Click += new System.EventHandler(this.kbtnGreen_Click);
            // 
            // kbtnBlue
            // 
            this.kbtnBlue.Location = new System.Drawing.Point(168, 12);
            this.kbtnBlue.Name = "kbtnBlue";
            this.kbtnBlue.Size = new System.Drawing.Size(72, 25);
            this.kbtnBlue.TabIndex = 14;
            this.kbtnBlue.Values.Text = "&Blue";
            this.kbtnBlue.Click += new System.EventHandler(this.kbtnBlue_Click);
            // 
            // kbtnWhite
            // 
            this.kbtnWhite.Location = new System.Drawing.Point(246, 12);
            this.kbtnWhite.Name = "kbtnWhite";
            this.kbtnWhite.Size = new System.Drawing.Size(72, 25);
            this.kbtnWhite.TabIndex = 15;
            this.kbtnWhite.Values.Text = "W&hite";
            this.kbtnWhite.Click += new System.EventHandler(this.kbtnWhite_Click);
            // 
            // kbtnControl
            // 
            this.kbtnControl.Location = new System.Drawing.Point(324, 12);
            this.kbtnControl.Name = "kbtnControl";
            this.kbtnControl.Size = new System.Drawing.Size(72, 25);
            this.kbtnControl.TabIndex = 16;
            this.kbtnControl.Values.Text = "Cont&rol";
            this.kbtnControl.Click += new System.EventHandler(this.kbtnControl_Click);
            // 
            // kbtnImage
            // 
            this.kbtnImage.Location = new System.Drawing.Point(402, 12);
            this.kbtnImage.Name = "kbtnImage";
            this.kbtnImage.Size = new System.Drawing.Size(72, 25);
            this.kbtnImage.TabIndex = 17;
            this.kbtnImage.Values.Text = "I&mage";
            this.kbtnImage.Click += new System.EventHandler(this.kbtnImage_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.formsPlot1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 44);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 406);
            this.kryptonPanel1.TabIndex = 7;
            // 
            // formsPlot1
            // 
            this.formsPlot1.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(0, 0);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(800, 406);
            this.formsPlot1.TabIndex = 0;
            // 
            // TransparentBackground
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kryptonPanel2);
            this.Name = "TransparentBackground";
            this.Text = "TransparentBackground";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private Krypton.Toolkit.KryptonButton kbtnImage;
        private Krypton.Toolkit.KryptonButton kbtnControl;
        private Krypton.Toolkit.KryptonButton kbtnWhite;
        private Krypton.Toolkit.KryptonButton kbtnBlue;
        private Krypton.Toolkit.KryptonButton kbtnGreen;
        private Krypton.Toolkit.KryptonButton kbtnRed;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot formsPlot1;
    }
}