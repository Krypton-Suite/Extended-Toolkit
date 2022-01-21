using System;
using System.Windows.Forms;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

namespace DataVisualisation.ScottPlot.Demos
{
    public partial class MouseTracker : KryptonForm
    {
        private readonly Crosshair _crosshair;

        public MouseTracker()
        {
            InitializeComponent();

            formsPlot1.Plot.AddSignal(DataGen.RandomWalk(null, 100));

            _crosshair = formsPlot1.Plot.AddCrosshair(0, 0);
        }

        private void formsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            (double coordinateX, double coordinateY) = formsPlot1.GetMouseCoordinates();

            klblXPixel.Text = $"{e.X:0.000}";
            klblYPixel.Text = $"{e.Y:0.000}";

            klblXCoordinate.Text = $"{coordinateX:0.00000000}";
            klblYCoordinate.Text = $"{coordinateY:0.00000000}";

            _crosshair.X = coordinateX;
            _crosshair.Y = coordinateY;

            formsPlot1.Refresh();
        }

        private void formsPlot1_MouseEnter(object sender, EventArgs e)
        {
            klblMouse.Text = "Mouse ENTERED the plot";
            _crosshair.IsVisible = true;
        }

        private void formsPlot1_MouseLeave(object sender, EventArgs e)
        {
            klblMouse.Text = "Mouse LEFT the plot";

            klblXPixel.Text = $"--";
            klblYPixel.Text = $"--";
            klblXCoordinate.Text = $"--";
            klblYCoordinate.Text = $"--";

            _crosshair.IsVisible = false;
            formsPlot1.Refresh();
        }
    }
}
