using System;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

namespace DataVisualisation.ScottPlot.Demos
{
    public partial class ToggleVisibility : KryptonForm
    {
        ScatterPlot sinPlot, cosPlot;
        VLine vline1, vline2;

        private void kchkSin_CheckedChanged(object sender, EventArgs e)
        {
            sinPlot.IsVisible = kchkSin.Checked;

            formsPlot1.Refresh();
        }

        private void kchkCos_CheckedChanged(object sender, EventArgs e)
        {
            cosPlot.IsVisible = kchkCos.Checked;

            formsPlot1.Refresh();
        }

        private void kchkLines_CheckedChanged(object sender, EventArgs e)
        {
            vline1.IsVisible = kchkLines.Checked;

            vline2.IsVisible = kchkLines.Checked;

            formsPlot1.Refresh();
        }

        private void ToggleVisibility_Load(object sender, EventArgs e)
        {
            int pointCount = 51;
            double[] dataXs = DataGen.Consecutive(pointCount);
            double[] dataSin = DataGen.Sin(pointCount);
            double[] dataCos = DataGen.Cos(pointCount);

            sinPlot = formsPlot1.Plot.AddScatter(dataXs, dataSin);
            cosPlot = formsPlot1.Plot.AddScatter(dataXs, dataCos);
            vline1 = formsPlot1.Plot.AddVerticalLine(0);
            vline2 = formsPlot1.Plot.AddVerticalLine(50);

            formsPlot1.Refresh();
        }

        public ToggleVisibility()
        {
            InitializeComponent();
        }
    }
}
