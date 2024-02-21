namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class FormsPlot : FormsPlotBase
    {
        private readonly SKControl _skElement;

        public override GRContext GrContext => null!;

        public FormsPlot()
        {
            _skElement = new SKControl() { Dock = DockStyle.Fill };
            _skElement.PaintSurface += SKElement_PaintSurface; ;
            _skElement.MouseDown += SKElement_MouseDown;
            _skElement.MouseUp += SKElement_MouseUp;
            _skElement.MouseMove += SKElement_MouseMove;
            _skElement.DoubleClick += SKElement_DoubleClick;
            _skElement.MouseWheel += SKElement_MouseWheel;
            _skElement.KeyDown += SKElement_KeyDown;
            _skElement.KeyUp += SKElement_KeyUp;

            Controls.Add(_skElement);

            HandleDestroyed += (s, e) => _skElement.Dispose();
        }

        private void SKElement_PaintSurface(object? sender, SKPaintSurfaceEventArgs e)
        {
            Plot.Render(e.Surface.Canvas, (int)e.Surface.Canvas.LocalClipBounds.Width, (int)e.Surface.Canvas.LocalClipBounds.Height);
        }

        public override void Refresh()
        {
            _skElement.Invalidate();
            base.Refresh();
        }
    }
}