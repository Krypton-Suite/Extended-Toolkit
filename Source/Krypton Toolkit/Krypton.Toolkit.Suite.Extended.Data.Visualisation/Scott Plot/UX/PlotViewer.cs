namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class PlotViewer : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private FormsPlot fpViewer;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.fpViewer = new Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.fpViewer);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(584, 361);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // fpViewer
            // 
            this.fpViewer.BackColor = System.Drawing.Color.Transparent;
            this.fpViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fpViewer.Location = new System.Drawing.Point(0, 0);
            this.fpViewer.Name = "fpViewer";
            this.fpViewer.Size = new System.Drawing.Size(584, 361);
            this.fpViewer.TabIndex = 1;
            // 
            // PlotViewer
            // 
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "PlotViewer";
            this.Text = "ScottPlot Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Property

        public FormsPlot Plot => fpViewer;

        #endregion

        #region Constructor

        public PlotViewer(Plot plot, int windowWidth = 600, int windowHeight = 400, string windowTitle = "ScottPlot Viewer")
        {
            InitializeComponent();

            Width = windowWidth;

            Height = windowHeight;

            Text = windowTitle;

            fpViewer.Reset(plot);

            fpViewer.Refresh();
        }

        #endregion
    }
}
