namespace Krypton.Toolkit.Suite.Extended.CheckSum.Tools
{
    public class KryptonComputeFileCheckSum : KryptonForm
    {
        #region Design Code
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tspbHashProgress;
        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnBrowseForFile;
        private KryptonTextBox ktxtFilePath;
        private KryptonLabel kryptonLabel1;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonWrapLabel kwlHash;
        private KryptonButton kbtnCompute;
        private KryptonComboBox kcmbAlgorithimType;
        private KryptonLabel kryptonLabel2;
        private KryptonButton kbtnCancel;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;

        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbHashProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnBrowseForFile = new Krypton.Toolkit.KryptonButton();
            this.ktxtFilePath = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kwlHash = new Krypton.Toolkit.KryptonWrapLabel();
            this.kbtnCompute = new Krypton.Toolkit.KryptonButton();
            this.kcmbAlgorithimType = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbAlgorithimType)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus,
            this.tspbHashProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 258);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(705, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(690, 17);
            this.tsslStatus.Spring = true;
            this.tsslStatus.Text = "Ready";
            this.tsslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tspbHashProgress
            // 
            this.tspbHashProgress.Name = "tspbHashProgress";
            this.tspbHashProgress.Size = new System.Drawing.Size(100, 16);
            this.tspbHashProgress.Visible = false;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 208);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(705, 50);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(705, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel2.Controls.Add(this.kbtnCompute);
            this.kryptonPanel2.Controls.Add(this.kcmbAlgorithimType);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kbtnBrowseForFile);
            this.kryptonPanel2.Controls.Add(this.ktxtFilePath);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(705, 208);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kbtnBrowseForFile
            // 
            this.kbtnBrowseForFile.Location = new System.Drawing.Point(663, 12);
            this.kbtnBrowseForFile.Name = "kbtnBrowseForFile";
            this.kbtnBrowseForFile.Size = new System.Drawing.Size(33, 25);
            this.kbtnBrowseForFile.TabIndex = 5;
            this.kbtnBrowseForFile.Values.Text = ".&..";
            // 
            // ktxtFilePath
            // 
            this.ktxtFilePath.Hint = "Type a file path here...";
            this.ktxtFilePath.Location = new System.Drawing.Point(83, 12);
            this.ktxtFilePath.Name = "ktxtFilePath";
            this.ktxtFilePath.Size = new System.Drawing.Size(574, 23);
            this.ktxtFilePath.TabIndex = 4;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(64, 20);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "File Path:";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(12, 98);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kwlHash);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(684, 95);
            this.kryptonGroupBox1.TabIndex = 10;
            this.kryptonGroupBox1.Values.Heading = "Calculated CheckSum";
            // 
            // kwlHash
            // 
            this.kwlHash.AutoSize = false;
            this.kwlHash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlHash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlHash.Location = new System.Drawing.Point(0, 0);
            this.kwlHash.Name = "kwlHash";
            this.kwlHash.Size = new System.Drawing.Size(680, 71);
            this.kwlHash.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlHash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kbtnCompute
            // 
            this.kbtnCompute.Enabled = false;
            this.kbtnCompute.Location = new System.Drawing.Point(255, 59);
            this.kbtnCompute.Name = "kbtnCompute";
            this.kbtnCompute.Size = new System.Drawing.Size(90, 25);
            this.kbtnCompute.TabIndex = 9;
            this.kbtnCompute.Values.Text = "&Compute";
            this.kbtnCompute.Click += new System.EventHandler(this.kbtnCompute_Click);
            // 
            // kcmbAlgorithimType
            // 
            this.kcmbAlgorithimType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbAlgorithimType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbAlgorithimType.DropDownWidth = 121;
            this.kcmbAlgorithimType.IntegralHeight = false;
            this.kcmbAlgorithimType.Location = new System.Drawing.Point(127, 59);
            this.kcmbAlgorithimType.Name = "kcmbAlgorithimType";
            this.kcmbAlgorithimType.Size = new System.Drawing.Size(121, 21);
            this.kcmbAlgorithimType.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbAlgorithimType.TabIndex = 8;
            this.kcmbAlgorithimType.SelectedIndexChanged += new System.EventHandler(this.kcmbAlgorithimType_SelectedIndexChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 59);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(108, 20);
            this.kryptonLabel2.TabIndex = 7;
            this.kryptonLabel2.Values.Text = "Algorithim Type:";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(603, 12);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // KryptonComputeFileCheckSum
            // 
            this.ClientSize = new System.Drawing.Size(705, 280);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonComputeFileCheckSum";
            this.ShowInTaskbar = false;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbAlgorithimType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Constructor
        public KryptonComputeFileCheckSum()
        {
            InitializeComponent();
        }
        #endregion

        private void kcmbAlgorithimType_SelectedIndexChanged(object sender, EventArgs e) => kbtnCompute.Enabled = MissingFrameWorkAPIs.IsNullOrWhiteSpace(kcmbAlgorithimType.Text);

        private void kbtnCompute_Click(object sender, EventArgs e)
        {

        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}