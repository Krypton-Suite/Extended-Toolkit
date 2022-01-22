using System;
using System.Drawing;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

namespace DataVisualisation.ScottPlot.Demos
{
    public partial class MultiAxisLock : KryptonForm
    {
        private readonly Axis YAxis3;

        public MultiAxisLock()
        {
            InitializeComponent();

            Random rand = new Random();

            // Add 3 signals each with a different vertical axis index.
            // Each signal defaults to X axis index 0 so their horizontal axis will be shared.

            var plt1 = formsPlot1.Plot.AddSignal(DataGen.RandomWalk(rand, 100, mult: 1));
            plt1.YAxisIndex = 0;
            plt1.LineWidth = 3;
            plt1.Color = Color.Magenta;

            var plt2 = formsPlot1.Plot.AddSignal(DataGen.RandomWalk(rand, 100, mult: 10));
            plt2.YAxisIndex = 1;
            plt2.LineWidth = 3;
            plt2.Color = Color.Green;

            var plt3 = formsPlot1.Plot.AddSignal(DataGen.RandomWalk(rand, 100, mult: 100));
            plt3.YAxisIndex = 2;
            plt3.LineWidth = 3;
            plt3.Color = Color.Navy;

            // The horizontal axis is shared by these signal plots (XAxisIndex defaults to 0)
            formsPlot1.Plot.XAxis.Label("Horizontal Axis");

            // Customize the primary (left) and secondary (right) axes
            formsPlot1.Plot.YAxis.Color(Color.Magenta);
            formsPlot1.Plot.YAxis.Label("Primary Axis");
            formsPlot1.Plot.YAxis2.Color(Color.Green);
            formsPlot1.Plot.YAxis2.Label("Secondary Axis");

            // the secondary (right) axis ticks are hidden by default so enable them
            formsPlot1.Plot.YAxis2.Ticks(true);

            // Create an additional vertical axis and customize it
            YAxis3 = formsPlot1.Plot.AddAxis(Edge.Left, 2);
            YAxis3.Color(Color.Navy);
            YAxis3.Label("Tertiary Axis");

            // adjust axis limits to fit the data once before locking them based on initial check state
            formsPlot1.Plot.AxisAuto();
            SetLocks();
        }

        private void SetLocks()
        {
            formsPlot1.Plot.YAxis.LockLimits(!kcbPrimary.Checked);
            formsPlot1.Plot.YAxis2.LockLimits(!kcbSecondary.Checked);
            YAxis3.LockLimits(!kcbTertiary.Checked);
        }

        private void kcbPrimary_CheckedChanged(object sender, EventArgs e)
        {
            SetLocks();
        }

        private void kcbSecondary_CheckedChanged(object sender, EventArgs e)
        {
            SetLocks();
        }

        private void kcbTertiary_CheckedChanged(object sender, EventArgs e)
        {
            SetLocks();
        }
    }
}
