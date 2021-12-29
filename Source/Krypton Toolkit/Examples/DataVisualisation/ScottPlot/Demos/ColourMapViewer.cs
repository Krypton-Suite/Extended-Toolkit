using System;
using System.Drawing;
using System.Linq;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

namespace DataVisualisation.ScottPlot.Demos
{
    public partial class ColourMapViewer : KryptonForm
    {
        ColourMap[] _colourMaps = ColourMap.GetColourMaps();

        public ColourMapViewer()
        {
            InitializeComponent();

            foreach (ColourMap map in _colourMaps)
            {
                klbColourMapNames.Items.Add(map.Name);
            }

            klbColourMapNames.SelectedIndex = klbColourMapNames.Items.IndexOf("Turbo");
        }

        private void ColourMapViewer_Load(object sender, EventArgs e)
        {
            Redraw();
        }

        private void klbColourMapNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            Redraw();
        }

        private void ColourMapViewer_SizeChanged(object sender, EventArgs e)
        {
            Redraw();
        }

        private void krbSampleData_CheckedChanged(object sender, EventArgs e)
        {
            Redraw();
        }

        private void krbSampleImage_CheckedChanged(object sender, EventArgs e)
        {
            Redraw();
        }

        private void Redraw()
        {
            ColourMap map = _colourMaps[klbColourMapNames.SelectedIndex >= 0 ? klbColourMapNames.SelectedIndex : 0];

            klblColourMap.Text = map.Name; pbColormap.Image?.Dispose();
            pbColormap.Image = ColourMap.Colorbar(map, pbColormap.Width, pbColormap.Height);

            PlotColourMapCurves(formsPlot1.Plot, map);
            formsPlot1.Refresh();

            if (krbSampleImage.Checked)
                PlotHeatmapImage(formsPlot2.Plot, map);
            else
                PlotHeatmapGaussianNoise(formsPlot2.Plot, map);
            formsPlot2.Refresh();

            PlotLineSeries(formsPlot3.Plot, map);
            formsPlot3.Refresh();
        }

        private void PlotLineSeries(Plot plot, ColourMap map)
        {
            int lineCount = 7;

            plot.Clear();
            for (int i = 0; i < lineCount; i++)
            {
                double fraction = (double)i / lineCount;
                double[] ys = DataGen.Sin(100, 2, mult: 1 + fraction * 2);
                Color c = map.GetColor(fraction);
                plot.PlotSignal(ys, color: c);
            }
            plot.AxisAuto();
        }

        private void PlotHeatmapGaussianNoise(Plot plot, ColourMap map)
        {
            Random rand = new Random(0);

            int[] xs = DataGen.RandomNormal(rand, 10000, 25, 10).Select(x => (int)x).ToArray();
            int[] ys = DataGen.RandomNormal(rand, 10000, 25, 10).Select(y => (int)y).ToArray();

            double[,] intensities = Tools.XYToIntensities(IntensityMode.Gaussian, xs, ys, 50, 50, 4);

            plot.Clear();
            plot.AddHeatmap(intensities, map);
            plot.AxisAuto();
        }

        private void PlotHeatmapImage(Plot plot, ColourMap map)
        {
            double[,] intensities = DataGen.SampleImageData();
            plot.Clear();
            plot.AddHeatmap(intensities, map);
        }

        private void PlotColourMapCurves(Plot plot, ColourMap map)
        {
            byte[] pixelValueRange = Enumerable.Range(0, 256).Select(x => (byte)x).ToArray();
            double[] xs = pixelValueRange.Select(x => (double)x / 255).ToArray();
            double[] rs = pixelValueRange.Select(x => (double)map.GetRGB(x).r).ToArray();
            double[] gs = pixelValueRange.Select(x => (double)map.GetRGB(x).g).ToArray();
            double[] bs = pixelValueRange.Select(x => (double)map.GetRGB(x).b).ToArray();
            double[] ms = new double[pixelValueRange.Length];
            for (int i = 0; i < ms.Length; i++)
                ms[i] = (rs[i] + gs[i] + bs[i]) / 3.0;

            plot.Clear();
            plot.PlotScatter(xs, rs, Color.Red, markerSize: 0);
            plot.PlotScatter(xs, gs, Color.Green, markerSize: 0);
            plot.PlotScatter(xs, bs, Color.Blue, markerSize: 0);
            plot.PlotScatter(xs, ms, Color.Black, markerSize: 0, lineStyle: LineStyle.Dash);
            plot.AxisAuto();
            plot.YLabel("Pixel Intensity");
            plot.XLabel("Fractional Data Value");
        }
    }
}
