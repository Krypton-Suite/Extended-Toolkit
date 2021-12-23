using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataVisualisation.ScottPlot.Demos;

using Krypton.Toolkit;

namespace DataVisualisation.ScottPlot
{
    public partial class ScottPlotDemoForm : KryptonForm
    {
        public ScottPlotDemoForm()
        {
            InitializeComponent();
        }

        private void kbtnAxisLimits_Click(object sender, EventArgs e)
        {
            AxisLimits axisLimits = new AxisLimits();

            axisLimits.Show();
        }

        private void kbtnColourMapViewer_Click(object sender, EventArgs e)
        {
            ColourMapViewer colourMapViewer = new ColourMapViewer();

            colourMapViewer.Show();
        }

        private void kbtnPlotConfiguration_Click(object sender, EventArgs e)
        {
            FormsPlotConfig plotConfig = new FormsPlotConfig();

            plotConfig.Show();
        }

        private void kbtnLayout_Click(object sender, EventArgs e)
        {
            Demos.Layout layout = new Demos.Layout();

            layout.Show();
        }

        private void kbtnLinkedPlots_Click(object sender, EventArgs e)
        {
            LinkedPlots linkedPlots = new LinkedPlots();

            linkedPlots.Show();
        }

        private void kbtnLiveIncomingData_Click(object sender, EventArgs e)
        {
            LiveDataIncoming liveData = new LiveDataIncoming();

            liveData.Show();
        }

        private void kbtnLiveDataUpdate_Click(object sender, EventArgs e)
        {
            LiveDataUpdate liveDataUpdate = new LiveDataUpdate();

            liveDataUpdate.Show();
        }
    }
}
