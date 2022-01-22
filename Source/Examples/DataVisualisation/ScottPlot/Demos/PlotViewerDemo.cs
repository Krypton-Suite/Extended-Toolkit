using System;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

namespace DataVisualisation.ScottPlot.Demos
{
    public partial class PlotViewerDemo : KryptonForm
    {
        Random rnd = new Random();

        public PlotViewerDemo()
        {
            InitializeComponent();
        }

        private void kbtnLaunchRandomWalk_Click(object sender, EventArgs e)
        {
            int pointCount = (int)knumPoints.Value;
            double[] randomWalkData = DataGen.RandomWalk(rnd, pointCount);

            var plt = new Plot();
            plt.AddSignal(randomWalkData);
            plt.Title($"{pointCount} Random Walk Points");

            var plotViewer = new PlotViewer(plt, 500, 300, "Random Walk Data");
            plotViewer.Plot.Configuration.Quality = QualityMode.HIGH; // customize as desired
            plotViewer.Owner = this; // so it closes if this window closes
            plotViewer.Show(); // or ShowDialog() for a blocking window
        }

        private void kbtnLaunchRandomSine_Click(object sender, EventArgs e)
        {
            int sinCount = (int)knumWaves.Value;
            var plt = new Plot();
            for (int i = 0; i < sinCount; i++)
            {
                double[] randomSinValues = DataGen.Sin(50, rnd.NextDouble() * 10, rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble() * 100);
                plt.AddSignal(randomSinValues);
            }
            plt.Title($"{sinCount} Random Sine Waves");

            var plotViewer = new PlotViewer(plt, 500, 300, "Random Walk Data");
            plotViewer.Plot.Configuration.Quality = QualityMode.HIGH; // customize as desired
            plotViewer.Owner = this; // so it closes if this window closes
            plotViewer.Show(); // or ShowDialog() for a blocking window
        }
    }
}
