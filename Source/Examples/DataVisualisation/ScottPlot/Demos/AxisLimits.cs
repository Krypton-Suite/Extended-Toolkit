using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

namespace DataVisualisation.ScottPlot.Demos
{
    public partial class AxisLimits : KryptonForm
    {
        public AxisLimits()
        {
            InitializeComponent();

            formsPlot1.Plot.AddSignal(DataGen.Sin(51));

            formsPlot1.Plot.AddSignal(DataGen.Cos(51));
            
            formsPlot1.Plot.AxisAuto();
            
            formsPlot1.Plot.SetOuterViewLimits(0, 50, -1, 1);
            
            formsPlot1.Refresh();
        }
    }
}
