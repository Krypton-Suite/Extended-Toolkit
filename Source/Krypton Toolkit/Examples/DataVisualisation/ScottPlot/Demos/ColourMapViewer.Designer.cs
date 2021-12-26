namespace DataVisualisation.ScottPlot.Demos
{
    partial class ColourMapViewer
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
            this.formsPlot3 = new Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot();
            this.formsPlot2 = new Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot();
            this.formsPlot1 = new Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot();
            this.krbSampleData = new Krypton.Toolkit.KryptonRadioButton();
            this.krbSampleImage = new Krypton.Toolkit.KryptonRadioButton();
            this.pbColormap = new System.Windows.Forms.PictureBox();
            this.klblColourMap = new Krypton.Toolkit.KryptonLabel();
            this.klbColourMapNames = new Krypton.Toolkit.KryptonListBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbColormap)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.formsPlot3);
            this.kryptonPanel1.Controls.Add(this.formsPlot2);
            this.kryptonPanel1.Controls.Add(this.formsPlot1);
            this.kryptonPanel1.Controls.Add(this.krbSampleData);
            this.kryptonPanel1.Controls.Add(this.krbSampleImage);
            this.kryptonPanel1.Controls.Add(this.pbColormap);
            this.kryptonPanel1.Controls.Add(this.klblColourMap);
            this.kryptonPanel1.Controls.Add(this.klbColourMapNames);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1292, 657);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // formsPlot3
            // 
            this.formsPlot3.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot3.Location = new System.Drawing.Point(605, 94);
            this.formsPlot3.Name = "formsPlot3";
            this.formsPlot3.Size = new System.Drawing.Size(671, 336);
            this.formsPlot3.TabIndex = 8;
            // 
            // formsPlot2
            // 
            this.formsPlot2.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot2.Location = new System.Drawing.Point(171, 431);
            this.formsPlot2.Name = "formsPlot2";
            this.formsPlot2.Size = new System.Drawing.Size(1109, 215);
            this.formsPlot2.TabIndex = 7;
            // 
            // formsPlot1
            // 
            this.formsPlot1.BackColor = System.Drawing.Color.Transparent;
            this.formsPlot1.Location = new System.Drawing.Point(167, 94);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(432, 336);
            this.formsPlot1.TabIndex = 6;
            // 
            // krbSampleData
            // 
            this.krbSampleData.Location = new System.Drawing.Point(980, 13);
            this.krbSampleData.Name = "krbSampleData";
            this.krbSampleData.Size = new System.Drawing.Size(140, 32);
            this.krbSampleData.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.krbSampleData.TabIndex = 5;
            this.krbSampleData.Values.Text = "Sample &Data";
            this.krbSampleData.CheckedChanged += new System.EventHandler(this.krbSampleData_CheckedChanged);
            // 
            // krbSampleImage
            // 
            this.krbSampleImage.Checked = true;
            this.krbSampleImage.Location = new System.Drawing.Point(1126, 13);
            this.krbSampleImage.Name = "krbSampleImage";
            this.krbSampleImage.Size = new System.Drawing.Size(154, 32);
            this.krbSampleImage.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.krbSampleImage.TabIndex = 4;
            this.krbSampleImage.Values.Text = "&Sample Image";
            this.krbSampleImage.CheckedChanged += new System.EventHandler(this.krbSampleImage_CheckedChanged);
            // 
            // pbColormap
            // 
            this.pbColormap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbColormap.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbColormap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbColormap.Location = new System.Drawing.Point(167, 51);
            this.pbColormap.Name = "pbColormap";
            this.pbColormap.Size = new System.Drawing.Size(432, 37);
            this.pbColormap.TabIndex = 3;
            this.pbColormap.TabStop = false;
            // 
            // klblColourMap
            // 
            this.klblColourMap.Location = new System.Drawing.Point(167, 13);
            this.klblColourMap.Name = "klblColourMap";
            this.klblColourMap.Size = new System.Drawing.Size(143, 32);
            this.klblColourMap.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.klblColourMap.TabIndex = 1;
            this.klblColourMap.Values.Text = "kryptonLabel1";
            // 
            // klbColourMapNames
            // 
            this.klbColourMapNames.Location = new System.Drawing.Point(12, 12);
            this.klbColourMapNames.Name = "klbColourMapNames";
            this.klbColourMapNames.Size = new System.Drawing.Size(148, 633);
            this.klbColourMapNames.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.klbColourMapNames.TabIndex = 0;
            this.klbColourMapNames.SelectedIndexChanged += new System.EventHandler(this.klbColourMapNames_SelectedIndexChanged);
            // 
            // ColourMapViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 657);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ColourMapViewer";
            this.Text = "ColourMapViewer";
            this.Load += new System.EventHandler(this.ColourMapViewer_Load);
            this.SizeChanged += new System.EventHandler(this.ColourMapViewer_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbColormap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.PictureBox pbColormap;
        private Krypton.Toolkit.KryptonLabel klblColourMap;
        private Krypton.Toolkit.KryptonListBox klbColourMapNames;
        private Krypton.Toolkit.KryptonRadioButton krbSampleData;
        private Krypton.Toolkit.KryptonRadioButton krbSampleImage;
        private Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot formsPlot3;
        private Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot formsPlot2;
        private Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot formsPlot1;
    }
}