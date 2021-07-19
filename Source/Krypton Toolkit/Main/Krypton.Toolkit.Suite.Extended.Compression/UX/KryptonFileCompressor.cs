namespace Krypton.Toolkit.Suite.Extended.Compression
{
    public class KryptonFileCompressor : KryptonForm
    {
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripProgressBar toolStripProgressBar1;
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnCompress;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;
        private KryptonTextBox ktxtTarget;
        private KryptonButton kbtnBrowseTarget;
        private KryptonTextBox ktxtSource;
        private KryptonLabel kryptonLabel2;
        private KryptonLabel kryptonLabel1;
        private KryptonButton kbtnBrowseSource;

        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.kbtnBrowseSource = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtSource = new Krypton.Toolkit.KryptonTextBox();
            this.ktxtTarget = new Krypton.Toolkit.KryptonTextBox();
            this.kbtnBrowseTarget = new Krypton.Toolkit.KryptonButton();
            this.kbtnCompress = new Krypton.Toolkit.KryptonButton();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 142);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(516, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnCompress);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 92);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(516, 50);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(516, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.ktxtTarget);
            this.kryptonPanel2.Controls.Add(this.kbtnBrowseTarget);
            this.kryptonPanel2.Controls.Add(this.ktxtSource);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Controls.Add(this.kbtnBrowseSource);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(516, 92);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(399, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // kbtnBrowseSource
            // 
            this.kbtnBrowseSource.Location = new System.Drawing.Point(460, 13);
            this.kbtnBrowseSource.Name = "kbtnBrowseSource";
            this.kbtnBrowseSource.Size = new System.Drawing.Size(44, 25);
            this.kbtnBrowseSource.TabIndex = 0;
            this.kbtnBrowseSource.Values.Text = "...";
            this.kbtnBrowseSource.Click += new System.EventHandler(this.kbtnBrowseSource_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 13);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Source:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(13, 51);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(52, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Target:";
            // 
            // ktxtSource
            // 
            this.ktxtSource.Location = new System.Drawing.Point(72, 13);
            this.ktxtSource.Name = "ktxtSource";
            this.ktxtSource.Size = new System.Drawing.Size(382, 23);
            this.ktxtSource.TabIndex = 3;
            // 
            // ktxtTarget
            // 
            this.ktxtTarget.Location = new System.Drawing.Point(72, 51);
            this.ktxtTarget.Name = "ktxtTarget";
            this.ktxtTarget.Size = new System.Drawing.Size(382, 23);
            this.ktxtTarget.TabIndex = 5;
            // 
            // kbtnBrowseTarget
            // 
            this.kbtnBrowseTarget.Location = new System.Drawing.Point(460, 51);
            this.kbtnBrowseTarget.Name = "kbtnBrowseTarget";
            this.kbtnBrowseTarget.Size = new System.Drawing.Size(44, 25);
            this.kbtnBrowseTarget.TabIndex = 4;
            this.kbtnBrowseTarget.Values.Text = "...";
            this.kbtnBrowseTarget.Click += new System.EventHandler(this.kbtnBrowseTarget_Click);
            // 
            // kbtnCompress
            // 
            this.kbtnCompress.Location = new System.Drawing.Point(414, 11);
            this.kbtnCompress.Name = "kbtnCompress";
            this.kbtnCompress.Size = new System.Drawing.Size(90, 25);
            this.kbtnCompress.TabIndex = 1;
            this.kbtnCompress.Values.Text = "C&ompress";
            this.kbtnCompress.Click += new System.EventHandler(this.kbtnCompress_Click);
            // 
            // KryptonFileCompressor
            // 
            this.ClientSize = new System.Drawing.Size(516, 164);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "KryptonFileCompressor";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public KryptonFileCompressor()
        {
            InitializeComponent();
        }

        private void kbtnCompress_Click(object sender, EventArgs e)
        {
            try
            {
                if (MissingFrameWorkAPIs.IsNullOrWhiteSpace(ktxtTarget.Text))
                {

                }
                else
                {
                    string path = ktxtTarget.Text;

                    Thread thread = new Thread(t =>
                   {
                       using (ZipFile zip = new ZipFile())
                       {
                           zip.AddDirectory(path);

                           DirectoryInfo di = new DirectoryInfo(path);

                           zip.SaveProgress += Zip_SaveProgress;

                           zip.Save($"{di.Parent.FullName}{di.Name}.zip");
                       }
                   })
                    { IsBackground = true };

                    thread.Start();
                }
            }
            catch (Exception exc)
            {
                ExceptionCapture.CaptureException(exc);
            }
        }

        private void Zip_SaveProgress(object sender, SaveProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Saving_BeforeWriteEntry)
            {
                toolStripProgressBar1.Maximum = e.EntriesTotal;

                toolStripProgressBar1.Value = e.EntriesSaved + 1;
            }
        }

        private void kbtnBrowseSource_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Select a path:";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                kbtnBrowseSource.Text = Path.GetFullPath(fbd.SelectedPath);
            }
        }

        private void kbtnBrowseTarget_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Zip Files|.zip", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    kbtnBrowseTarget.Text = Path.GetFullPath(ofd.FileName);
                }
            }
        }
    }
}