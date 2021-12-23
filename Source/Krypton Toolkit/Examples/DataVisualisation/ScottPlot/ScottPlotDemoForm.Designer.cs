namespace DataVisualisation.ScottPlot
{
    partial class ScottPlotDemoForm
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
            this.kbtnLiveIncomingData = new Krypton.Toolkit.KryptonButton();
            this.kbtnLinkedPlots = new Krypton.Toolkit.KryptonButton();
            this.kbtnLayout = new Krypton.Toolkit.KryptonButton();
            this.kbtnPlotConfiguration = new Krypton.Toolkit.KryptonButton();
            this.kbtnColourMapViewer = new Krypton.Toolkit.KryptonButton();
            this.kbtnAxisLimits = new Krypton.Toolkit.KryptonButton();
            this.kbtnLiveDataUpdate = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnLiveDataUpdate);
            this.kryptonPanel1.Controls.Add(this.kbtnLiveIncomingData);
            this.kryptonPanel1.Controls.Add(this.kbtnLinkedPlots);
            this.kryptonPanel1.Controls.Add(this.kbtnLayout);
            this.kryptonPanel1.Controls.Add(this.kbtnPlotConfiguration);
            this.kryptonPanel1.Controls.Add(this.kbtnColourMapViewer);
            this.kryptonPanel1.Controls.Add(this.kbtnAxisLimits);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(759, 450);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnLiveIncomingData
            // 
            this.kbtnLiveIncomingData.Location = new System.Drawing.Point(616, 12);
            this.kbtnLiveIncomingData.Name = "kbtnLiveIncomingData";
            this.kbtnLiveIncomingData.Size = new System.Drawing.Size(130, 25);
            this.kbtnLiveIncomingData.TabIndex = 5;
            this.kbtnLiveIncomingData.Values.Text = "&Live Incoming Data";
            this.kbtnLiveIncomingData.Click += new System.EventHandler(this.kbtnLiveIncomingData_Click);
            // 
            // kbtnLinkedPlots
            // 
            this.kbtnLinkedPlots.Location = new System.Drawing.Point(520, 12);
            this.kbtnLinkedPlots.Name = "kbtnLinkedPlots";
            this.kbtnLinkedPlots.Size = new System.Drawing.Size(90, 25);
            this.kbtnLinkedPlots.TabIndex = 4;
            this.kbtnLinkedPlots.Values.Text = "L&inked Plots";
            this.kbtnLinkedPlots.Click += new System.EventHandler(this.kbtnLinkedPlots_Click);
            // 
            // kbtnLayout
            // 
            this.kbtnLayout.Location = new System.Drawing.Point(424, 12);
            this.kbtnLayout.Name = "kbtnLayout";
            this.kbtnLayout.Size = new System.Drawing.Size(90, 25);
            this.kbtnLayout.TabIndex = 3;
            this.kbtnLayout.Values.Text = "&Layout";
            this.kbtnLayout.Click += new System.EventHandler(this.kbtnLayout_Click);
            // 
            // kbtnPlotConfiguration
            // 
            this.kbtnPlotConfiguration.Location = new System.Drawing.Point(266, 12);
            this.kbtnPlotConfiguration.Name = "kbtnPlotConfiguration";
            this.kbtnPlotConfiguration.Size = new System.Drawing.Size(152, 25);
            this.kbtnPlotConfiguration.TabIndex = 2;
            this.kbtnPlotConfiguration.Values.Text = "Pl&ot Configuration";
            this.kbtnPlotConfiguration.Click += new System.EventHandler(this.kbtnPlotConfiguration_Click);
            // 
            // kbtnColourMapViewer
            // 
            this.kbtnColourMapViewer.Location = new System.Drawing.Point(108, 12);
            this.kbtnColourMapViewer.Name = "kbtnColourMapViewer";
            this.kbtnColourMapViewer.Size = new System.Drawing.Size(152, 25);
            this.kbtnColourMapViewer.TabIndex = 1;
            this.kbtnColourMapViewer.Values.Text = "&ColourMap Viewer";
            this.kbtnColourMapViewer.Click += new System.EventHandler(this.kbtnColourMapViewer_Click);
            // 
            // kbtnAxisLimits
            // 
            this.kbtnAxisLimits.Location = new System.Drawing.Point(12, 12);
            this.kbtnAxisLimits.Name = "kbtnAxisLimits";
            this.kbtnAxisLimits.Size = new System.Drawing.Size(90, 25);
            this.kbtnAxisLimits.TabIndex = 0;
            this.kbtnAxisLimits.Values.Text = "Axis &Limits";
            this.kbtnAxisLimits.Click += new System.EventHandler(this.kbtnAxisLimits_Click);
            // 
            // kbtnLiveDataUpdate
            // 
            this.kbtnLiveDataUpdate.Location = new System.Drawing.Point(12, 43);
            this.kbtnLiveDataUpdate.Name = "kbtnLiveDataUpdate";
            this.kbtnLiveDataUpdate.Size = new System.Drawing.Size(130, 25);
            this.kbtnLiveDataUpdate.TabIndex = 6;
            this.kbtnLiveDataUpdate.Values.Text = "Live &Data Update";
            this.kbtnLiveDataUpdate.Click += new System.EventHandler(this.kbtnLiveDataUpdate_Click);
            // 
            // ScottPlotDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 450);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "ScottPlotDemoForm";
            this.Text = "DemoForm";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonButton kbtnAxisLimits;
        private Krypton.Toolkit.KryptonButton kbtnColourMapViewer;
        private Krypton.Toolkit.KryptonButton kbtnPlotConfiguration;
        private Krypton.Toolkit.KryptonButton kbtnLayout;
        private Krypton.Toolkit.KryptonButton kbtnLinkedPlots;
        private Krypton.Toolkit.KryptonButton kbtnLiveIncomingData;
        private Krypton.Toolkit.KryptonButton kbtnLiveDataUpdate;
    }
}