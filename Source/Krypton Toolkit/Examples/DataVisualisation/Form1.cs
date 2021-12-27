using System;

using DataVisualisation.ScottPlot;

using Krypton.Toolkit;

namespace DataVisualisation
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kbtnScottPlott_Click(object sender, EventArgs e)
        {
            ScottPlotDemoForm scottPlotDemos = new ScottPlotDemoForm();

            scottPlotDemos.ShowDialog();
        }
    }
}
