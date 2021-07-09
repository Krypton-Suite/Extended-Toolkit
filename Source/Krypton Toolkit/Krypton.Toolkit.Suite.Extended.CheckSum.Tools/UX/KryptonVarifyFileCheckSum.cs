namespace Krypton.Toolkit.Suite.Extended.CheckSum.Tools
{
    public class KryptonVarifyFileCheckSum : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonLabel kryptonLabel1;
        private KryptonButton kbtnCancel;
        private KryptonButton kryptonButton2;
        private KryptonButton kbtnBrowseForFile;
        private KryptonTextBox ktxtFilePath;
        private KryptonGroupBox kryptonGroupBox2;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonWrapLabel kwlCalculatedCheckSum;
        private KryptonButton kbtnCompute;
        private KryptonComboBox kcmbAlgorithimType;
        private KryptonLabel kryptonLabel2;
        private KryptonButton kbtnValidate;
        private KryptonTextBox ktxtVarifyCheckSum;
        private KryptonContextMenuItems kryptonContextMenuItems1;
        private KryptonContextMenuItems kryptonContextMenuItems2;
        private System.Windows.Forms.ContextMenuStrip cmsCheckSumValidation;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolStripMenuItem pasteCheckSumToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearTextBoxToolStripMenuItem;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.ktxtFilePath = new Krypton.Toolkit.KryptonTextBox();
            this.kbtnBrowseForFile = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kcmbAlgorithimType = new Krypton.Toolkit.KryptonComboBox();
            this.kbtnCompute = new Krypton.Toolkit.KryptonButton();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.kwlCalculatedCheckSum = new Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonGroupBox2 = new Krypton.Toolkit.KryptonGroupBox();
            this.ktxtVarifyCheckSum = new Krypton.Toolkit.KryptonTextBox();
            this.kbtnValidate = new Krypton.Toolkit.KryptonButton();
            this.kryptonContextMenuItems1 = new Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItems2 = new Krypton.Toolkit.KryptonContextMenuItems();
            this.cmsCheckSumValidation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteCheckSumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearTextBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbAlgorithimType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            this.cmsCheckSumValidation.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnValidate);
            this.kryptonPanel1.Controls.Add(this.kryptonButton2);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 321);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(709, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(607, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 1;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(709, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox2);
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
            this.kryptonPanel2.Size = new System.Drawing.Size(709, 321);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 13);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(64, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "File Path:";
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(13, 13);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(90, 25);
            this.kryptonButton2.TabIndex = 3;
            this.kryptonButton2.Values.Text = "kryptonButton2";
            this.kryptonButton2.Visible = false;
            // 
            // ktxtFilePath
            // 
            this.ktxtFilePath.Hint = "Type a file path here...";
            this.ktxtFilePath.Location = new System.Drawing.Point(84, 13);
            this.ktxtFilePath.Name = "ktxtFilePath";
            this.ktxtFilePath.Size = new System.Drawing.Size(574, 23);
            this.ktxtFilePath.TabIndex = 1;
            // 
            // kbtnBrowseForFile
            // 
            this.kbtnBrowseForFile.Location = new System.Drawing.Point(664, 13);
            this.kbtnBrowseForFile.Name = "kbtnBrowseForFile";
            this.kbtnBrowseForFile.Size = new System.Drawing.Size(33, 25);
            this.kbtnBrowseForFile.TabIndex = 2;
            this.kbtnBrowseForFile.Values.Text = ".&..";
            this.kbtnBrowseForFile.Click += new System.EventHandler(this.kbtnBrowseForFile_Click);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(13, 63);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(108, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "Algorithim Type:";
            // 
            // kcmbAlgorithimType
            // 
            this.kcmbAlgorithimType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.kcmbAlgorithimType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbAlgorithimType.DropDownWidth = 121;
            this.kcmbAlgorithimType.IntegralHeight = false;
            this.kcmbAlgorithimType.Location = new System.Drawing.Point(128, 63);
            this.kcmbAlgorithimType.Name = "kcmbAlgorithimType";
            this.kcmbAlgorithimType.Size = new System.Drawing.Size(121, 21);
            this.kcmbAlgorithimType.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbAlgorithimType.TabIndex = 4;
            this.kcmbAlgorithimType.SelectedIndexChanged += new System.EventHandler(this.kcmbAlgorithimType_SelectedIndexChanged);
            // 
            // kbtnCompute
            // 
            this.kbtnCompute.Enabled = false;
            this.kbtnCompute.Location = new System.Drawing.Point(256, 63);
            this.kbtnCompute.Name = "kbtnCompute";
            this.kbtnCompute.Size = new System.Drawing.Size(90, 25);
            this.kbtnCompute.TabIndex = 5;
            this.kbtnCompute.Values.Text = "&Compute";
            this.kbtnCompute.Click += new System.EventHandler(this.kbtnCompute_Click);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(13, 102);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kwlCalculatedCheckSum);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(684, 95);
            this.kryptonGroupBox1.TabIndex = 6;
            this.kryptonGroupBox1.Values.Heading = "Calculated CheckSum";
            // 
            // kwlCalculatedCheckSum
            // 
            this.kwlCalculatedCheckSum.AutoSize = false;
            this.kwlCalculatedCheckSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlCalculatedCheckSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlCalculatedCheckSum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlCalculatedCheckSum.Location = new System.Drawing.Point(0, 0);
            this.kwlCalculatedCheckSum.Name = "kwlCalculatedCheckSum";
            this.kwlCalculatedCheckSum.Size = new System.Drawing.Size(680, 71);
            this.kwlCalculatedCheckSum.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlCalculatedCheckSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(13, 213);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.ktxtVarifyCheckSum);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(684, 95);
            this.kryptonGroupBox2.TabIndex = 7;
            this.kryptonGroupBox2.Values.Heading = "Varified CheckSum";
            // 
            // ktxtVarifyCheckSum
            // 
            this.ktxtVarifyCheckSum.ContextMenuStrip = this.cmsCheckSumValidation;
            this.ktxtVarifyCheckSum.Hint = "Type or paste checksum here...";
            this.ktxtVarifyCheckSum.Location = new System.Drawing.Point(6, 23);
            this.ktxtVarifyCheckSum.Name = "ktxtVarifyCheckSum";
            this.ktxtVarifyCheckSum.Size = new System.Drawing.Size(665, 24);
            this.ktxtVarifyCheckSum.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtVarifyCheckSum.StateCommon.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Inherit;
            this.ktxtVarifyCheckSum.TabIndex = 0;
            this.ktxtVarifyCheckSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ktxtVarifyCheckSum.TextChanged += new System.EventHandler(this.ktxtVarifyCheckSum_TextChanged);
            // 
            // kbtnValidate
            // 
            this.kbtnValidate.Enabled = false;
            this.kbtnValidate.Location = new System.Drawing.Point(511, 13);
            this.kbtnValidate.Name = "kbtnValidate";
            this.kbtnValidate.Size = new System.Drawing.Size(90, 25);
            this.kbtnValidate.TabIndex = 4;
            this.kbtnValidate.Values.Text = "&Validate!";
            this.kbtnValidate.Click += new System.EventHandler(this.kbtnValidate_Click);
            // 
            // cmsCheckSumValidation
            // 
            this.cmsCheckSumValidation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsCheckSumValidation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteCheckSumToolStripMenuItem,
            this.toolStripMenuItem1,
            this.clearTextBoxToolStripMenuItem});
            this.cmsCheckSumValidation.Name = "cmsCheckSumValidation";
            this.cmsCheckSumValidation.Size = new System.Drawing.Size(163, 54);
            // 
            // pasteCheckSumToolStripMenuItem
            // 
            this.pasteCheckSumToolStripMenuItem.Name = "pasteCheckSumToolStripMenuItem";
            this.pasteCheckSumToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pasteCheckSumToolStripMenuItem.Text = "&Paste CheckSum";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // clearTextBoxToolStripMenuItem
            // 
            this.clearTextBoxToolStripMenuItem.Name = "clearTextBoxToolStripMenuItem";
            this.clearTextBoxToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearTextBoxToolStripMenuItem.Text = "Clear &TextBox";
            // 
            // KryptonVarifyFileCheckSum
            // 
            this.ClientSize = new System.Drawing.Size(709, 371);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonVarifyFileCheckSum";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbAlgorithimType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            this.cmsCheckSumValidation.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Settings _settings = new Settings();
        #endregion

        #region Constructor
        public KryptonVarifyFileCheckSum()
        {
            InitializeComponent();

            HelperMethods.PropagateHashBox(kcmbAlgorithimType);
        }
        #endregion

        private void kbtnBrowseForFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Browse for a File:";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ktxtFilePath.Text = Path.GetFullPath(ofd.FileName);
            }
        }

        private void kbtnValidate_Click(object sender, EventArgs e)
        {
            if (HelperMethods.IsValid(kwlCalculatedCheckSum.Text, ktxtVarifyCheckSum.Text))
            {
                ktxtVarifyCheckSum.StateCommon.Border.Color1 = _settings.ValidColour;

                ktxtVarifyCheckSum.StateCommon.Border.Color2 = _settings.ValidColour;
            }
            else
            {
                ktxtVarifyCheckSum.StateCommon.Border.Color1 = _settings.InvalidColour;

                ktxtVarifyCheckSum.StateCommon.Border.Color2 = _settings.InvalidColour;
            }
        }

        private void ktxtVarifyCheckSum_TextChanged(object sender, EventArgs e)
        {
            if (MissingFrameWorkAPIs.IsNullOrWhiteSpace(ktxtVarifyCheckSum.Text))
            {
                ktxtVarifyCheckSum.StateCommon.Border.Color1 = _settings.IntermediateColour;

                ktxtVarifyCheckSum.StateCommon.Border.Color2 = _settings.IntermediateColour;
            }

            kbtnValidate.Enabled = MissingFrameWorkAPIs.IsNullOrWhiteSpace(ktxtVarifyCheckSum.Text);
        }

        private void kbtnCompute_Click(object sender, EventArgs e)
        {

        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {

        }

        private void kcmbAlgorithimType_SelectedIndexChanged(object sender, EventArgs e) => kbtnCompute.Enabled = MissingFrameWorkAPIs.IsNullOrWhiteSpace(kcmbAlgorithimType.Text);
    }
}