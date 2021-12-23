namespace DataVisualisation.ScottPlot.Demos
{
    partial class ShowValueOnHover2
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
            this.klblMessage = new Krypton.Toolkit.KryptonLabel();
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
            this.kryptonPanel2.Controls.Add(this.klblMessage);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(800, 44);
            this.kryptonPanel2.TabIndex = 5;
            // 
            // klblMessage
            // 
            this.klblMessage.Location = new System.Drawing.Point(12, 12);
            this.klblMessage.Name = "klblMessage";
            this.klblMessage.Size = new System.Drawing.Size(59, 20);
            this.klblMessage.TabIndex = 4;
            this.klblMessage.Values.Text = "Message";
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
            this.formsPlot1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formsPlot1_MouseMove);
            // 
            // ShowValueOnHover2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kryptonPanel2);
            this.Name = "ShowValueOnHover2";
            this.Text = "ShowValueOnHover2";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private Krypton.Toolkit.KryptonLabel klblMessage;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot formsPlot1;
    }
}