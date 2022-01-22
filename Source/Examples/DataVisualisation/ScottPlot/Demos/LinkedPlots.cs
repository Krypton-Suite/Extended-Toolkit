using System;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

namespace DataVisualisation.ScottPlot.Demos
{
    public partial class LinkedPlots : KryptonForm
    {
        private readonly FormsPlot[] formsPlots;

        public LinkedPlots()
        {
            InitializeComponent();

            formsPlot1.Plot.AddSignal(DataGen.Sin(51));
            formsPlot2.Plot.AddSignal(DataGen.Cos(51));

            // create a list of plot controls we can easily iterate through later
            formsPlots = new FormsPlot[] { formsPlot1, formsPlot2 };
            foreach (var fp in formsPlots)
                fp.AxesChanged += OnAxesChanged;
        }

        private void OnAxesChanged(object sender, EventArgs e)
        {
            if (kcbLinkAxes.Checked == false)
                return;

            FormsPlot changedPlot = (FormsPlot)sender;
            var newAxisLimits = changedPlot.Plot.GetAxisLimits();

            foreach (var fp in formsPlots)
            {
                if (fp == changedPlot)
                    continue;

                // disable events briefly to avoid an infinite loop
                fp.Configuration.AxesChangedEventEnabled = false;
                fp.Plot.SetAxisLimits(newAxisLimits);
                fp.Refresh();
                fp.Configuration.AxesChangedEventEnabled = true;
            }

            //formsPlot1.Refresh();
        }
    }
}
