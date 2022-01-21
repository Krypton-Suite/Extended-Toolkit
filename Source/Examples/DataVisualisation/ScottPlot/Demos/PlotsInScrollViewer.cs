using System;
using System.Windows.Forms;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

namespace DataVisualisation.ScottPlot.Demos
{
    public partial class PlotsInScrollViewer : KryptonForm
    {
        public PlotsInScrollViewer()
        {
            InitializeComponent();

            Random rand = new Random();
            formsPlot1.Plot.AddSignal(DataGen.RandomWalk(rand, 100));
            formsPlot2.Plot.AddSignal(DataGen.RandomWalk(rand, 100));
            formsPlot3.Plot.AddSignal(DataGen.RandomWalk(rand, 100));

            formsPlot1.MouseWheel += FormsPlot_MouseWheel;
            formsPlot2.MouseWheel += FormsPlot_MouseWheel;
            formsPlot3.MouseWheel += FormsPlot_MouseWheel;
        }

        private void FormsPlot_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = krbZoom.Checked;
        }

        private void krbScroll_CheckedChanged(object sender, EventArgs e)
        {
            formsPlot1.Configuration.ScrollWheelZoom = false;
            formsPlot2.Configuration.ScrollWheelZoom = false;
            formsPlot3.Configuration.ScrollWheelZoom = false;
        }

        private void krbZoom_CheckedChanged(object sender, EventArgs e)
        {
            formsPlot1.Configuration.ScrollWheelZoom = true;
            formsPlot2.Configuration.ScrollWheelZoom = true;
            formsPlot3.Configuration.ScrollWheelZoom = true;
        }
    }
}
