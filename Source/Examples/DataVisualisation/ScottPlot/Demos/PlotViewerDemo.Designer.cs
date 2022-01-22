namespace DataVisualisation.ScottPlot.Demos
{
    partial class PlotViewerDemo
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
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.knumPoints = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kbtnLaunchRandomWalk = new Krypton.Toolkit.KryptonButton();
            this.kryptonGroupBox2 = new Krypton.Toolkit.KryptonGroupBox();
            this.kbtnLaunchRandomSine = new Krypton.Toolkit.KryptonButton();
            this.knumWaves = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox3 = new Krypton.Toolkit.KryptonGroupBox();
            this.krbSampleCode = new Krypton.Toolkit.KryptonRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).BeginInit();
            this.kryptonGroupBox3.Panel.SuspendLayout();
            this.kryptonGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox3);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox2);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(508, 318);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(395, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "The PlotViewer lets you launch a plot in an interactive pop-up window.";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 38);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(475, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "You can focus on generating interesting data, and the PlotViewer will handle the " +
    "GUI!";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(13, 65);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kbtnLaunchRandomWalk);
            this.kryptonGroupBox1.Panel.Controls.Add(this.knumPoints);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel3);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(180, 104);
            this.kryptonGroupBox1.TabIndex = 2;
            this.kryptonGroupBox1.Values.Heading = "Random Walk Generator";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(13, 15);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(44, 20);
            this.kryptonLabel3.TabIndex = 1;
            this.kryptonLabel3.Values.Text = "Points";
            // 
            // knumPoints
            // 
            this.knumPoints.Location = new System.Drawing.Point(13, 42);
            this.knumPoints.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.knumPoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.knumPoints.Name = "knumPoints";
            this.knumPoints.Size = new System.Drawing.Size(72, 22);
            this.knumPoints.TabIndex = 2;
            this.knumPoints.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // kbtnLaunchRandomWalk
            // 
            this.kbtnLaunchRandomWalk.Location = new System.Drawing.Point(92, 31);
            this.kbtnLaunchRandomWalk.Name = "kbtnLaunchRandomWalk";
            this.kbtnLaunchRandomWalk.Size = new System.Drawing.Size(72, 25);
            this.kbtnLaunchRandomWalk.TabIndex = 3;
            this.kbtnLaunchRandomWalk.Values.Text = "&Launch";
            this.kbtnLaunchRandomWalk.Click += new System.EventHandler(this.kbtnLaunchRandomWalk_Click);
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(199, 65);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.kbtnLaunchRandomSine);
            this.kryptonGroupBox2.Panel.Controls.Add(this.knumWaves);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(180, 104);
            this.kryptonGroupBox2.TabIndex = 3;
            this.kryptonGroupBox2.Values.Heading = "Random Sine Generator";
            // 
            // kbtnLaunchRandomSine
            // 
            this.kbtnLaunchRandomSine.Location = new System.Drawing.Point(92, 31);
            this.kbtnLaunchRandomSine.Name = "kbtnLaunchRandomSine";
            this.kbtnLaunchRandomSine.Size = new System.Drawing.Size(72, 25);
            this.kbtnLaunchRandomSine.TabIndex = 3;
            this.kbtnLaunchRandomSine.Values.Text = "&Launch";
            this.kbtnLaunchRandomSine.Click += new System.EventHandler(this.kbtnLaunchRandomSine_Click);
            // 
            // knumWaves
            // 
            this.knumWaves.Location = new System.Drawing.Point(13, 42);
            this.knumWaves.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.knumWaves.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.knumWaves.Name = "knumWaves";
            this.knumWaves.Size = new System.Drawing.Size(72, 22);
            this.knumWaves.TabIndex = 2;
            this.knumWaves.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(13, 15);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(46, 20);
            this.kryptonLabel4.TabIndex = 1;
            this.kryptonLabel4.Values.Text = "Waves";
            // 
            // kryptonGroupBox3
            // 
            this.kryptonGroupBox3.Location = new System.Drawing.Point(13, 175);
            this.kryptonGroupBox3.Name = "kryptonGroupBox3";
            // 
            // kryptonGroupBox3.Panel
            // 
            this.kryptonGroupBox3.Panel.Controls.Add(this.krbSampleCode);
            this.kryptonGroupBox3.Size = new System.Drawing.Size(483, 131);
            this.kryptonGroupBox3.TabIndex = 4;
            this.kryptonGroupBox3.Values.Heading = "Sample Code";
            // 
            // krbSampleCode
            // 
            this.krbSampleCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krbSampleCode.Location = new System.Drawing.Point(0, 0);
            this.krbSampleCode.Name = "krbSampleCode";
            this.krbSampleCode.ReadOnly = true;
            this.krbSampleCode.Size = new System.Drawing.Size(479, 107);
            this.krbSampleCode.TabIndex = 1;
            this.krbSampleCode.Text = "// Create a new ScottPlot\nvar plt = new Plot();\nplt.PlotSignal(dataArray);\n\n// La" +
    "unch it in a PlotViewer\nnew PlotViewer(plt).Show();\n";
            // 
            // PlotViewerDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 318);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "PlotViewerDemo";
            this.Text = "PlotViewerDemo";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).EndInit();
            this.kryptonGroupBox3.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).EndInit();
            this.kryptonGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox3;
        private Krypton.Toolkit.KryptonRichTextBox krbSampleCode;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        private Krypton.Toolkit.KryptonButton kbtnLaunchRandomSine;
        private Krypton.Toolkit.KryptonNumericUpDown knumWaves;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private Krypton.Toolkit.KryptonButton kbtnLaunchRandomWalk;
        private Krypton.Toolkit.KryptonNumericUpDown knumPoints;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}