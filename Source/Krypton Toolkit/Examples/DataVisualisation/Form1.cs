using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
