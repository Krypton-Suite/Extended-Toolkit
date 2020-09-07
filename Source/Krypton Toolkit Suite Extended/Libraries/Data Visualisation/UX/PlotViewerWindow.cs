using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class PlotViewerWindow : KryptonForm
    {
        #region Design Code
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PlotViewerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Name = "PlotViewerWindow";
            this.Text = "PlotViewerWindow";
            this.ResumeLayout(false);

        }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <a onclick="return false;" href="PlotViewerWindow" originaltag="see">PlotViewerWindow</a> class.</summary>
        /// <param name="plot">The plot.</param>
        /// <param name="windowWidth">Width of the window.</param>
        /// <param name="windowHeight">Height of the window.</param>
        /// <param name="windowTitle">The window title.</param>
        public PlotViewerWindow(Plot plot, int windowWidth = 600, int windowHeight = 400, string windowTitle = "ScottPlot Viewer")
        {
            InitializeComponent();

            Width = windowWidth;

            Height = windowHeight;

            Text = windowTitle;
        }
        #endregion
    }
}