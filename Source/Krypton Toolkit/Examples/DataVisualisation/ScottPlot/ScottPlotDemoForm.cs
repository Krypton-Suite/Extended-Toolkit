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
    }
}
