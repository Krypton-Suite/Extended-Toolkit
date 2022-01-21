using System;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

namespace DataVisualisation.ScottPlot.Demos
{
    public partial class FormsPlotConfig : KryptonForm
    {
        public FormsPlotConfig()
        {
            InitializeComponent();
        }

        private void FormsPlotConfig_Load(object sender, EventArgs e)
        {
            int pointCount = 51;
            double[] dataXs = DataGen.Consecutive(pointCount);
            double[] dataSin = DataGen.Sin(pointCount);
            double[] dataCos = DataGen.Cos(pointCount);

            formsPlot1.Plot.AddScatter(dataXs, dataSin);
            formsPlot1.Plot.AddScatter(dataXs, dataCos);

            formsPlot1.Refresh();
        }

        private void kcbPannable_CheckedChanged(object sender, EventArgs e)
        {
            formsPlot1.Configuration.LeftClickDragPan = kcbPannable.Checked;
        }

        private void kcbZoomable_CheckedChanged(object sender, EventArgs e)
        {
            formsPlot1.Configuration.RightClickDragZoom = kcbZoomable.Checked;
            formsPlot1.Configuration.ScrollWheelZoom = kcbZoomable.Checked;
        }

        private void kcbLowQualityWhileDragging_CheckedChanged(object sender, EventArgs e)
        {
            formsPlot1.Configuration.Quality =
                kcbLowQualityWhileDragging.Checked ? QualityMode.LOWWHILEDRAGGING : QualityMode.HIGH;
        }

        private void kcbLockVerticalAxis_CheckedChanged(object sender, EventArgs e)
        {
            formsPlot1.Configuration.LockVerticalAxis = kcbLockVerticalAxis.Checked;
        }

        private void kcbLockHorizontalAxis_CheckedChanged(object sender, EventArgs e)
        {
            formsPlot1.Configuration.LockHorizontalAxis = kcbLockHorizontalAxis.Checked;
        }

        private void kcbEqualAxes_CheckedChanged(object sender, EventArgs e)
        {
            formsPlot1.Plot.AxisScaleLock(kcbEqualAxes.Checked);

            formsPlot1.Refresh();
        }

        private void kcbRightClickMenu_CheckedChanged(object sender, EventArgs e)
        {
            InitializeRightClickMenu();
        }

        private void kcbCustomRightClickAction_CheckedChanged(object sender, EventArgs e)
        {
            InitializeRightClickMenu();
        }

        private void kcbDoubleClickBenchmark_CheckedChanged(object sender, EventArgs e)
        {
            formsPlot1.Configuration.DoubleClickBenchmark = kcbDoubleClickBenchmark.Checked;
        }

        private void InitializeRightClickMenu()
        {
            // remove both possible right-click actions
            formsPlot1.RightClicked -= formsPlot1.DefaultRightClickedEvent;
            formsPlot1.RightClicked -= CustomRightClickEvent;

            if (kcbRightClickMenu.Enabled == false)
            {
                return;
            }

            if (kcbCustomRightClickAction.Checked)
            {
                formsPlot1.RightClicked += CustomRightClickEvent;
            }
            else
            {   
                formsPlot1.RightClicked += formsPlot1.DefaultRightClickedEvent;
            }
        }

        private void CustomRightClickEvent(object sender, EventArgs e) =>
            KryptonMessageBox.Show("This is a custom right-click action");
    }
}
