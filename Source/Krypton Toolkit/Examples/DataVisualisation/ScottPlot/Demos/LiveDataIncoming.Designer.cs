namespace DataVisualisation.ScottPlot.Demos
{
    partial class LiveDataIncoming
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
            this.components = new System.ComponentModel.Container();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtLastValue = new Krypton.Toolkit.KryptonTextBox();
            this.ktxtLatestValue = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kcbAutoAxis = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.formsPlot1 = new Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot();
            this.dataTimer = new System.Windows.Forms.Timer(this.components);
            this.renderTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kcbAutoAxis);
            this.kryptonPanel2.Controls.Add(this.ktxtLatestValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.ktxtLastValue);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(800, 100);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(315, 20);
            this.kryptonLabel1.TabIndex = 4;
            this.kryptonLabel1.Values.Text = "This example simulates live display of a growing dataset";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(13, 49);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Values.Text = "Readings:";
            // 
            // ktxtLastValue
            // 
            this.ktxtLastValue.Location = new System.Drawing.Point(83, 48);
            this.ktxtLastValue.Name = "ktxtLastValue";
            this.ktxtLastValue.Size = new System.Drawing.Size(100, 23);
            this.ktxtLastValue.TabIndex = 6;
            this.ktxtLastValue.Text = "123";
            this.ktxtLastValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ktxtLatestValue
            // 
            this.ktxtLatestValue.Location = new System.Drawing.Point(288, 48);
            this.ktxtLatestValue.Name = "ktxtLatestValue";
            this.ktxtLatestValue.Size = new System.Drawing.Size(100, 23);
            this.ktxtLatestValue.TabIndex = 8;
            this.ktxtLatestValue.Text = "+123.4";
            this.ktxtLatestValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(203, 49);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(79, 20);
            this.kryptonLabel3.TabIndex = 7;
            this.kryptonLabel3.Values.Text = "Latest Value:";
            // 
            // kcbAutoAxis
            // 
            this.kcbAutoAxis.Checked = true;
            this.kcbAutoAxis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.kcbAutoAxis.Location = new System.Drawing.Point(395, 48);
            this.kcbAutoAxis.Name = "kcbAutoAxis";
            this.kcbAutoAxis.Size = new System.Drawing.Size(166, 20);
            this.kcbAutoAxis.TabIndex = 9;
            this.kcbAutoAxis.Values.Text = "&Auto-Axis on Each Update";
            this.kcbAutoAxis.CheckedChanged += new System.EventHandler(this.kcbAutoAxis_CheckedChanged);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.formsPlot1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 100);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(800, 350);
            this.kryptonPanel1.TabIndex = 4;
            // 
            // formsPlot1
            // 
            this.formsPlot1.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(0, 0);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(800, 350);
            this.formsPlot1.TabIndex = 0;
            // 
            // dataTimer
            // 
            this.dataTimer.Enabled = true;
            this.dataTimer.Interval = 1;
            this.dataTimer.Tick += new System.EventHandler(this.dataTimer_Tick);
            // 
            // renderTimer
            // 
            this.renderTimer.Enabled = true;
            this.renderTimer.Interval = 20;
            this.renderTimer.Tick += new System.EventHandler(this.renderTimer_Tick);
            // 
            // LiveDataIncoming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kryptonPanel2);
            this.Name = "LiveDataIncoming";
            this.Text = "LiveDataIncoming";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private Krypton.Toolkit.KryptonCheckBox kcbAutoAxis;
        private Krypton.Toolkit.KryptonTextBox ktxtLatestValue;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonTextBox ktxtLastValue;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.Timer dataTimer;
        private System.Windows.Forms.Timer renderTimer;
    }
}