#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class GridLines : IRenderable
    {
        public bool Visible = true;
        public bool SnapToNearestPixel = true;

        public Orientation Orientation;
        public float LineWidth = 1;
        public Color Colour = ColorTranslator.FromHtml("#efefef");
        public LineStyle LineStyle = LineStyle.Solid;

        public void Render(Settings settings)
        {
            if ((Visible == false) || (LineWidth == 0))
                return;

            using (Pen pen = GDI.Pen(Colour, LineWidth, LineStyle))
            {
                if (Orientation == Orientation.Horizontal)
                    RenderHorizontalLines(pen, settings);
                else
                    RenderVerticalLines(pen, settings);
            }
        }

        private void RenderHorizontalLines(Pen pen, Settings settings)
        {
            for (int i = 0; i < settings.ticks.y.tickPositionsMajor.Length; i++)
            {
                double value = settings.ticks.y.tickPositionsMajor[i];
                double unitsFromAxisEdge = value - settings.axes.y.Min;
                double yPx = settings.dataSize.Height - unitsFromAxisEdge * settings.yAxisScale;

                if (SnapToNearestPixel)
                    yPx = (int)yPx;

                if ((yPx == 0) && settings.layout.displayFrameByAxis[2])
                    continue; // don't draw a grid line 1px away from frame

                PointF ptLeft = new PointF(0, (float)yPx);
                PointF ptRight = new PointF(settings.dataSize.Width, (float)yPx);
                settings.gfxData.DrawLine(pen, ptLeft, ptRight);
            }
        }

        private void RenderVerticalLines(Pen pen, Settings settings)
        {
            for (int i = 0; i < settings.ticks.x.tickPositionsMajor.Length; i++)
            {
                double value = settings.ticks.x.tickPositionsMajor[i];
                double unitsFromAxisEdge = value - settings.axes.x.Min;
                double xPx = unitsFromAxisEdge * settings.xAxisScale;

                if (SnapToNearestPixel)
                    xPx = (int)xPx;

                if ((xPx == 0) && settings.layout.displayFrameByAxis[0])
                    continue; // don't draw a grid line 1px away from frame

                PointF ptTop = new PointF((float)xPx, 0);
                PointF ptBot = new PointF((float)xPx, settings.dataSize.Height);
                settings.gfxData.DrawLine(pen, ptTop, ptBot);
            }
        }
    }
}