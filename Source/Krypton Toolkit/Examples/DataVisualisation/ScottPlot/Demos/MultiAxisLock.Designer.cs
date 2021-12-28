namespace DataVisualisation.ScottPlot.Demos
{
    partial class MultiAxisLock
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
            this.kcbPrimary = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbTertiary = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbSecondary = new Krypton.Toolkit.KryptonCheckBox();
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
            this.kryptonPanel2.Controls.Add(this.kcbSecondary);
            this.kryptonPanel2.Controls.Add(this.kcbTertiary);
            this.kryptonPanel2.Controls.Add(this.kcbPrimary);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(800, 44);
            this.kryptonPanel2.TabIndex = 5;
            // 
            // kcbPrimary
            // 
            this.kcbPrimary.Checked = true;
            this.kcbPrimary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kcbPrimary.Location = new System.Drawing.Point(12, 12);
            this.kcbPrimary.Name = "kcbPrimary";
            this.kcbPrimary.Size = new System.Drawing.Size(64, 16);
            this.kcbPrimary.StateCommon.ShortText.Color1 = System.Drawing.Color.Magenta;
            this.kcbPrimary.StateCommon.ShortText.Color2 = System.Drawing.Color.Magenta;
            this.kcbPrimary.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbPrimary.TabIndex = 10;
            this.kcbPrimary.Values.Text = "P&rimary";
            this.kcbPrimary.CheckedChanged += new System.EventHandler(this.kcbPrimary_CheckedChanged);
            // 
            // kcbTertiary
            // 
            this.kcbTertiary.Location = new System.Drawing.Point(167, 12);
            this.kcbTertiary.Name = "kcbTertiary";
            this.kcbTertiary.Size = new System.Drawing.Size(63, 16);
            this.kcbTertiary.StateCommon.ShortText.Color1 = System.Drawing.Color.Navy;
            this.kcbTertiary.StateCommon.ShortText.Color2 = System.Drawing.Color.Navy;
            this.kcbTertiary.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbTertiary.TabIndex = 11;
            this.kcbTertiary.Values.Text = "Tertiar&y";
            this.kcbTertiary.CheckedChanged += new System.EventHandler(this.kcbTertiary_CheckedChanged);
            // 
            // kcbSecondary
            // 
            this.kcbSecondary.Location = new System.Drawing.Point(82, 12);
            this.kcbSecondary.Name = "kcbSecondary";
            this.kcbSecondary.Size = new System.Drawing.Size(79, 16);
            this.kcbSecondary.StateCommon.ShortText.Color1 = System.Drawing.Color.Green;
            this.kcbSecondary.StateCommon.ShortText.Color2 = System.Drawing.Color.Green;
            this.kcbSecondary.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kcbSecondary.TabIndex = 12;
            this.kcbSecondary.Values.Text = "&Secondary";
            this.kcbSecondary.CheckedChanged += new System.EventHandler(this.kcbSecondary_CheckedChanged);
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
            // MultiAxisLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kryptonPanel2);
            this.Name = "MultiAxisLock";
            this.Text = "MultiAxisLock";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private Krypton.Toolkit.KryptonCheckBox kcbPrimary;
        private Krypton.Toolkit.KryptonCheckBox kcbSecondary;
        private Krypton.Toolkit.KryptonCheckBox kcbTertiary;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot formsPlot1;
    }
}