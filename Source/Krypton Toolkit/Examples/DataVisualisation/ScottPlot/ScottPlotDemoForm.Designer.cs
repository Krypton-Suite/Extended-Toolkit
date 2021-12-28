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
            this.kbtnStyles = new Krypton.Toolkit.KryptonButton();
            this.kbtnShowValueOnHover = new Krypton.Toolkit.KryptonButton();
            this.kbtnRightClickMenu = new Krypton.Toolkit.KryptonButton();
            this.kbtnPlotViewer = new Krypton.Toolkit.KryptonButton();
            this.kbtnPlotsInScrollViewer = new Krypton.Toolkit.KryptonButton();
            this.kbtnMultiAxisLock = new Krypton.Toolkit.KryptonButton();
            this.kbtnMouseTracker = new Krypton.Toolkit.KryptonButton();
            this.kbtnLiveDataUpdate = new Krypton.Toolkit.KryptonButton();
            this.kbtnLiveIncomingData = new Krypton.Toolkit.KryptonButton();
            this.kbtnLinkedPlots = new Krypton.Toolkit.KryptonButton();
            this.kbtnLayout = new Krypton.Toolkit.KryptonButton();
            this.kbtnPlotConfiguration = new Krypton.Toolkit.KryptonButton();
            this.kbtnColourMapViewer = new Krypton.Toolkit.KryptonButton();
            this.kbtnAxisLimits = new Krypton.Toolkit.KryptonButton();
            this.kbtnToggleVisibility = new Krypton.Toolkit.KryptonButton();
            this.kbtnTransparentBackground = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnTransparentBackground);
            this.kryptonPanel1.Controls.Add(this.kbtnToggleVisibility);
            this.kryptonPanel1.Controls.Add(this.kbtnStyles);
            this.kryptonPanel1.Controls.Add(this.kbtnShowValueOnHover);
            this.kryptonPanel1.Controls.Add(this.kbtnRightClickMenu);
            this.kryptonPanel1.Controls.Add(this.kbtnPlotViewer);
            this.kryptonPanel1.Controls.Add(this.kbtnPlotsInScrollViewer);
            this.kryptonPanel1.Controls.Add(this.kbtnMultiAxisLock);
            this.kryptonPanel1.Controls.Add(this.kbtnMouseTracker);
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
            this.kryptonPanel1.Size = new System.Drawing.Size(759, 116);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnStyles
            // 
            this.kbtnStyles.Location = new System.Drawing.Point(284, 74);
            this.kbtnStyles.Name = "kbtnStyles";
            this.kbtnStyles.Size = new System.Drawing.Size(130, 25);
            this.kbtnStyles.TabIndex = 13;
            this.kbtnStyles.Values.Text = "St&yles";
            this.kbtnStyles.Click += new System.EventHandler(this.kbtnStyles_Click);
            // 
            // kbtnShowValueOnHover
            // 
            this.kbtnShowValueOnHover.Location = new System.Drawing.Point(148, 74);
            this.kbtnShowValueOnHover.Name = "kbtnShowValueOnHover";
            this.kbtnShowValueOnHover.Size = new System.Drawing.Size(130, 25);
            this.kbtnShowValueOnHover.TabIndex = 12;
            this.kbtnShowValueOnHover.Values.Text = "Show Value on &Hover";
            this.kbtnShowValueOnHover.Click += new System.EventHandler(this.kbtnShowValueOnHover_Click);
            // 
            // kbtnRightClickMenu
            // 
            this.kbtnRightClickMenu.Location = new System.Drawing.Point(12, 74);
            this.kbtnRightClickMenu.Name = "kbtnRightClickMenu";
            this.kbtnRightClickMenu.Size = new System.Drawing.Size(130, 25);
            this.kbtnRightClickMenu.TabIndex = 11;
            this.kbtnRightClickMenu.Values.Text = "Right &Click Menu";
            this.kbtnRightClickMenu.Click += new System.EventHandler(this.kbtnRightClickMenu_Click);
            // 
            // kbtnPlotViewer
            // 
            this.kbtnPlotViewer.Location = new System.Drawing.Point(556, 43);
            this.kbtnPlotViewer.Name = "kbtnPlotViewer";
            this.kbtnPlotViewer.Size = new System.Drawing.Size(130, 25);
            this.kbtnPlotViewer.TabIndex = 10;
            this.kbtnPlotViewer.Values.Text = "Plot &Viewer";
            this.kbtnPlotViewer.Click += new System.EventHandler(this.kbtnPlotViewer_Click);
            // 
            // kbtnPlotsInScrollViewer
            // 
            this.kbtnPlotsInScrollViewer.Location = new System.Drawing.Point(420, 43);
            this.kbtnPlotsInScrollViewer.Name = "kbtnPlotsInScrollViewer";
            this.kbtnPlotsInScrollViewer.Size = new System.Drawing.Size(130, 25);
            this.kbtnPlotsInScrollViewer.TabIndex = 9;
            this.kbtnPlotsInScrollViewer.Values.Text = "Plots in &Scroll Viewer";
            this.kbtnPlotsInScrollViewer.Click += new System.EventHandler(this.kbtnPlotsInScrollViewer_Click);
            // 
            // kbtnMultiAxisLock
            // 
            this.kbtnMultiAxisLock.Location = new System.Drawing.Point(284, 43);
            this.kbtnMultiAxisLock.Name = "kbtnMultiAxisLock";
            this.kbtnMultiAxisLock.Size = new System.Drawing.Size(130, 25);
            this.kbtnMultiAxisLock.TabIndex = 8;
            this.kbtnMultiAxisLock.Values.Text = "Multi &Axis Lock";
            this.kbtnMultiAxisLock.Click += new System.EventHandler(this.kbtnMultiAxisLock_Click);
            // 
            // kbtnMouseTracker
            // 
            this.kbtnMouseTracker.Location = new System.Drawing.Point(148, 43);
            this.kbtnMouseTracker.Name = "kbtnMouseTracker";
            this.kbtnMouseTracker.Size = new System.Drawing.Size(130, 25);
            this.kbtnMouseTracker.TabIndex = 7;
            this.kbtnMouseTracker.Values.Text = "&Mouse Tracker";
            this.kbtnMouseTracker.Click += new System.EventHandler(this.kbtnMouseTracker_Click);
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
            // kbtnToggleVisibility
            // 
            this.kbtnToggleVisibility.Location = new System.Drawing.Point(420, 74);
            this.kbtnToggleVisibility.Name = "kbtnToggleVisibility";
            this.kbtnToggleVisibility.Size = new System.Drawing.Size(130, 25);
            this.kbtnToggleVisibility.TabIndex = 14;
            this.kbtnToggleVisibility.Values.Text = "Toggle Visibilit&y";
            this.kbtnToggleVisibility.Click += new System.EventHandler(this.kbtnToggleVisibility_Click);
            // 
            // kbtnTransparentBackground
            // 
            this.kbtnTransparentBackground.Location = new System.Drawing.Point(556, 74);
            this.kbtnTransparentBackground.Name = "kbtnTransparentBackground";
            this.kbtnTransparentBackground.Size = new System.Drawing.Size(172, 25);
            this.kbtnTransparentBackground.TabIndex = 15;
            this.kbtnTransparentBackground.Values.Text = "Transparent &Background";
            this.kbtnTransparentBackground.Click += new System.EventHandler(this.kbtnTransparentBackground_Click);
            // 
            // ScottPlotDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 116);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
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
        private Krypton.Toolkit.KryptonButton kbtnMouseTracker;
        private Krypton.Toolkit.KryptonButton kbtnMultiAxisLock;
        private Krypton.Toolkit.KryptonButton kbtnPlotViewer;
        private Krypton.Toolkit.KryptonButton kbtnPlotsInScrollViewer;
        private Krypton.Toolkit.KryptonButton kbtnRightClickMenu;
        private Krypton.Toolkit.KryptonButton kbtnShowValueOnHover;
        private Krypton.Toolkit.KryptonButton kbtnStyles;
        private Krypton.Toolkit.KryptonButton kbtnToggleVisibility;
        private Krypton.Toolkit.KryptonButton kbtnTransparentBackground;
    }
}