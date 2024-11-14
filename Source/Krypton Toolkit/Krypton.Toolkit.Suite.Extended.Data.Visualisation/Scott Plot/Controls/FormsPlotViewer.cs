namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public static class FormsPlotViewer
    {
        public static void Launch(Plot plot, string title = "", int width = 600, int height = 400)
        {
            FormsPlot formsPlot = new() { Dock = DockStyle.Fill };
            formsPlot.Reset(plot);

            KryptonForm form = new KryptonForm()
            {
                StartPosition = FormStartPosition.CenterScreen,
                Width = width,
                Height = height,
                Text = title,
            };
            form.Controls.Add(formsPlot);
            form.ShowDialog();
        }
    }
}