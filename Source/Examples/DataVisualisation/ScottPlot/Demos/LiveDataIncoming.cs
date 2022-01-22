using System;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

namespace DataVisualisation.ScottPlot.Demos
{
    public partial class LiveDataIncoming : KryptonForm
    {
        public double[] data = new double[100_000];
        int nextDataIndex = 1;
        SignalPlot signalPlot;
        Random rand = new Random(0);

        public LiveDataIncoming()
        {
            InitializeComponent();

            signalPlot = formsPlot1.Plot.AddSignal(data);
            formsPlot1.Plot.YLabel("Value");
            formsPlot1.Plot.XLabel("Sample Number");

            Closed += (sender, args) =>
            {
                dataTimer?.Stop();
                renderTimer?.Stop();
            };
        }

        private void dataTimer_Tick(object sender, EventArgs e)
        {
            if (nextDataIndex >= data.Length)
            {
                throw new OverflowException("data array isn't long enough to accomodate new data");
                // in this situation the solution would be:
                //   1. clear the plot
                //   2. create a new larger array
                //   3. copy the old data into the start of the larger array
                //   4. plot the new (larger) array
                //   5. continue to update the new array
            }

            double randomValue = Math.Round(rand.NextDouble() - .5, 3);
            double latestValue = data[nextDataIndex - 1] + randomValue;
            data[nextDataIndex] = latestValue;
            ktxtLastValue.Text = (latestValue > 0) ? "+" + latestValue.ToString() : latestValue.ToString();
            ktxtLatestValue.Text = nextDataIndex.ToString();

            signalPlot.MaxRenderIndex = nextDataIndex;

            nextDataIndex += 1;
        }

        private void renderTimer_Tick(object sender, EventArgs e)
        {
            if (kcbAutoAxis.Checked)
                formsPlot1.Plot.AxisAuto();
            formsPlot1.Refresh();
        }

        private void kcbAutoAxis_CheckedChanged(object sender, EventArgs e)
        {
            if (kcbAutoAxis.Checked == false)
            {
                formsPlot1.Plot.AxisAuto(verticalMargin: .5);
                var oldLimits = formsPlot1.Plot.GetAxisLimits();
                formsPlot1.Plot.SetAxisLimits(xMax: oldLimits.XMax + 1000);
            }
        }
    }
}
