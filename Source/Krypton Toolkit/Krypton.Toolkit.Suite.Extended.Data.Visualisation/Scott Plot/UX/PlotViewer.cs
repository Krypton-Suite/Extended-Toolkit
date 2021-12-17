using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class PlotViewer : KryptonForm
    {
        #region Design Code
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PlotViewer
            // 
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Name = "PlotViewer";
            this.Text = "ScottPlot Viewer";
            this.ResumeLayout(false);

        }
        #endregion

        #region Constructor

        public PlotViewer(Plot plot, int windowWidth = 600, int windowHeight = 400, string windowTitle = "ScottPlot Viewer")
        {
            InitializeComponent();

            Width = windowWidth;

            Height = windowHeight;

            Text = windowTitle;
        }

        #endregion
    }
}
