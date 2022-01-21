using System;

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

        private void kbtnMouseTracker_Click(object sender, EventArgs e)
        {
            MouseTracker mouseTracker = new MouseTracker();

            mouseTracker.Show();
        }

        private void kbtnMultiAxisLock_Click(object sender, EventArgs e)
        {
            MultiAxisLock multiAxisLock = new MultiAxisLock();

            multiAxisLock.Show();
        }

        private void kbtnPlotsInScrollViewer_Click(object sender, EventArgs e)
        {
            PlotsInScrollViewer plotsInScrollViewer = new PlotsInScrollViewer();

            plotsInScrollViewer.Show();
        }

        private void kbtnPlotViewer_Click(object sender, EventArgs e)
        {
            PlotViewerDemo plotViewer = new PlotViewerDemo();

            plotViewer.Show();
        }

        private void kbtnRightClickMenu_Click(object sender, EventArgs e)
        {
            RightClickMenu rightClickMenu = new RightClickMenu();

            rightClickMenu.Show();
        }

        private void kbtnShowValueOnHover_Click(object sender, EventArgs e)
        {
            ShowValueOnHover2 showValueOnHover = new ShowValueOnHover2();

            showValueOnHover.Show();
        }

        private void kbtnStyles_Click(object sender, EventArgs e)
        {
            Styles styles = new Styles();

            styles.Show();
        }

        private void kbtnToggleVisibility_Click(object sender, EventArgs e)
        {
            ToggleVisibility toggleVisibility = new ToggleVisibility();

            toggleVisibility.Show();
        }

        private void kbtnTransparentBackground_Click(object sender, EventArgs e)
        {
            TransparentBackground transparentBackground = new TransparentBackground();

            transparentBackground.Show();
        }
    }
}
