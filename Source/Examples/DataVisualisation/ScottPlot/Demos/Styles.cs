using System;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

namespace DataVisualisation.ScottPlot.Demos
{
    public partial class Styles : KryptonForm
    {
        public Styles()
        {
            InitializeComponent();

            klbStyles.Items.AddRange(Style.GetStyles());
            klbPalettes.Items.AddRange(Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot.Palette.GetPalettes());

            formsPlot1.Plot.XLabel("Horizontal Axis");
            formsPlot1.Plot.YLabel("Vertical Axis");

            klbStyles.SelectedIndex = 0;
            klbPalettes.SelectedIndex = 0;
        }

        private void UpdatePlot()
        {
            var style = (IStyle)klbStyles.SelectedItem;
            var palette = (ScottPlotPalette)klbPalettes.SelectedItem;

            if (style is null || palette is null)
                return;

            formsPlot1.Plot.Style(style);
            formsPlot1.Plot.Title($"Style: {style}\nPalette: {palette}");
            formsPlot1.Plot.Palette = palette;

            formsPlot1.Plot.Clear();
            for (int i = 0; i < palette.Count(); i++)
            {
                double offset = 1 + i * 1.1;
                double mult = 10 + i;
                double phase = i * .3 / palette.Count();
                double[] ys = DataGen.Sin(51, 1, offset, mult, phase);
                var sig = formsPlot1.Plot.AddSignal(ys);
                sig.LineWidth = 3;
                sig.MarkerSize = 0;
            }

            formsPlot1.Plot.AxisAuto(horizontalMargin: 0);
            formsPlot1.Refresh();
        }

        private void klbStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlot();
        }

        private void klbPalettes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePlot();
        }
    }
}
