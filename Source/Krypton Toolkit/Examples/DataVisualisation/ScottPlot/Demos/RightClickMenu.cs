using System;
using System.Windows.Forms;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

namespace DataVisualisation.ScottPlot.Demos
{
    public partial class RightClickMenu : KryptonForm
    {
        public RightClickMenu()
        {
            InitializeComponent();

            formsPlot1.RightClicked -= formsPlot1.DefaultRightClickedEvent;
            formsPlot1.RightClicked += CustomRightClickEvent;

            formsPlot1.Plot.AddSignal(DataGen.Sin(51));
            formsPlot1.Plot.AddSignal(DataGen.Cos(51));
            formsPlot1.Refresh();
        }

        private void CustomRightClickEvent(object sender, EventArgs e)
        {
            ContextMenuStrip customMenu = new ContextMenuStrip();
            customMenu.Items.Add(new ToolStripMenuItem("Add Sine Wave", null, new EventHandler(AddSine)));
            customMenu.Items.Add(new ToolStripMenuItem("Clear Plot", null, new EventHandler(ClearPlot)));
            formsPlot1.ContextMenuStrip = customMenu;
            //customMenu.Show(System.Windows.Forms.Cursor.Position);
        }

        private void AddSine(object sender, EventArgs e)
        {
            Random rand = new Random();
            double[] data = DataGen.Sin(51, phase: rand.NextDouble() * 1000);
            formsPlot1.Plot.AddSignal(data);
            formsPlot1.Plot.AxisAuto();
            formsPlot1.Refresh();
        }

        private void ClearPlot(object sender, EventArgs e)
        {
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.AxisAuto();
            formsPlot1.Refresh();
        }
    }
}
