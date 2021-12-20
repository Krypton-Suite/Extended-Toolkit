namespace DataVisualisation.ScottPlot.Demos
{
    partial class Layout
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
            this.rightPlot = new Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot();
            this.lowerPlot = new Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot();
            this.mainPlot = new Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.rightPlot);
            this.kryptonPanel1.Controls.Add(this.lowerPlot);
            this.kryptonPanel1.Controls.Add(this.mainPlot);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1120, 742);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // rightPlot
            // 
            this.rightPlot.BackColor = System.Drawing.Color.Transparent;
            this.rightPlot.Location = new System.Drawing.Point(818, 12);
            this.rightPlot.Name = "rightPlot";
            this.rightPlot.Size = new System.Drawing.Size(288, 450);
            this.rightPlot.TabIndex = 2;
            // 
            // lowerPlot
            // 
            this.lowerPlot.BackColor = System.Drawing.Color.Transparent;
            this.lowerPlot.Location = new System.Drawing.Point(12, 468);
            this.lowerPlot.Name = "lowerPlot";
            this.lowerPlot.Size = new System.Drawing.Size(800, 248);
            this.lowerPlot.TabIndex = 1;
            // 
            // mainPlot
            // 
            this.mainPlot.BackColor = System.Drawing.Color.Transparent;
            this.mainPlot.Location = new System.Drawing.Point(12, 12);
            this.mainPlot.Name = "mainPlot";
            this.mainPlot.Size = new System.Drawing.Size(800, 450);
            this.mainPlot.TabIndex = 0;
            this.mainPlot.AxesChanged += new System.EventHandler(this.mainPlot_AxesChanged);
            // 
            // Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 742);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Layout";
            this.Text = "Layout";
            this.SizeChanged += new System.EventHandler(this.Layout_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot mainPlot;
        private Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot rightPlot;
        private Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot lowerPlot;
    }
}