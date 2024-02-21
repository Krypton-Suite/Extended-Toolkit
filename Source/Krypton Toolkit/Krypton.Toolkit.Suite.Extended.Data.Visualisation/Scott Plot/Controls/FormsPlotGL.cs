using System.Xml.Linq;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class FormsPlotGL : FormsPlotBase
    {
        #region Instance Fields

        private readonly SKGLControl _skElement;

        #endregion

        #region Public

        public override GRContext? GrContext => _skElement.GRContext;

        #endregion

        #region Identity

        public FormsPlotGL()
        {
            _skElement = new SKGLControl() { Dock = DockStyle.Fill, VSync = true };
            _skElement.PaintSurface += SKControl_PaintSurface;
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

        #endregion

        #region Implementation

        private void SKControl_PaintSurface(object? sender, SKPaintGLSurfaceEventArgs e)
        {
            Plot.Render(e.Surface.Canvas, (int)e.Surface.Canvas.LocalClipBounds.Width, (int)e.Surface.Canvas.LocalClipBounds.Height);
        }

        public override void Refresh()
        {
            _skElement.Invalidate();
            base.Refresh();
        }

        #endregion
    }
}