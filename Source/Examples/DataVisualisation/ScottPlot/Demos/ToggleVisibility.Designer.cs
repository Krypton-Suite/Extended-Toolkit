namespace DataVisualisation.ScottPlot.Demos
{
    partial class ToggleVisibility
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
            this.kchkSin = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkCos = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.formsPlot1 = new Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot();
            this.kchkLines = new Krypton.Toolkit.KryptonCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kchkLines);
            this.kryptonPanel2.Controls.Add(this.kchkSin);
            this.kryptonPanel2.Controls.Add(this.kchkCos);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(800, 44);
            this.kryptonPanel2.TabIndex = 5;
            // 
            // kchkSin
            // 
            this.kchkSin.Checked = true;
            this.kchkSin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kchkSin.Location = new System.Drawing.Point(12, 12);
            this.kchkSin.Name = "kchkSin";
            this.kchkSin.Size = new System.Drawing.Size(40, 20);
            this.kchkSin.TabIndex = 10;
            this.kchkSin.Values.Text = "S&in";
            this.kchkSin.CheckedChanged += new System.EventHandler(this.kchkSin_CheckedChanged);
            // 
            // kchkCos
            // 
            this.kchkCos.Checked = true;
            this.kchkCos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kchkCos.Location = new System.Drawing.Point(58, 12);
            this.kchkCos.Name = "kchkCos";
            this.kchkCos.Size = new System.Drawing.Size(44, 20);
            this.kchkCos.TabIndex = 9;
            this.kchkCos.Values.Text = "&Cos";
            this.kchkCos.CheckedChanged += new System.EventHandler(this.kchkCos_CheckedChanged);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.formsPlot1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 44);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 406);
            this.kryptonPanel1.TabIndex = 6;
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
            // kchkLines
            // 
            this.kchkLines.Checked = true;
            this.kchkLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kchkLines.Location = new System.Drawing.Point(108, 12);
            this.kchkLines.Name = "kchkLines";
            this.kchkLines.Size = new System.Drawing.Size(51, 20);
            this.kchkLines.TabIndex = 11;
            this.kchkLines.Values.Text = "Lin&es";
            this.kchkLines.CheckedChanged += new System.EventHandler(this.kchkLines_CheckedChanged);
            // 
            // ToggleVisibility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kryptonPanel2);
            this.Name = "ToggleVisibility";
            this.Text = "ToggleVisibility";
            this.Load += new System.EventHandler(this.ToggleVisibility_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private Krypton.Toolkit.KryptonCheckBox kchkSin;
        private Krypton.Toolkit.KryptonCheckBox kchkCos;
        private Krypton.Toolkit.KryptonCheckBox kchkLines;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot formsPlot1;
    }
}