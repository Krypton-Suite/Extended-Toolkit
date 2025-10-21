namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

public class Arrow : IPlottable
{
    public bool IsVisible { get; set; } = true;
    public IAxes Axes { get; set; } = new Axes();
    public IEnumerable<LegendItem> LegendItems => LegendItem.Single(Label, LineStyle);

    /// <summary>
    /// Label to appear in the legend
    /// </summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>
    /// Position of the base of the arrow in coordinate units
    /// </summary>
    public Coordinates Base = Coordinates.Origin;

    /// <summary>
    /// Position of the base of the arrowhead in coordinate units
    /// </summary>
    public Coordinates Tip = Coordinates.Origin;

    /// <summary>
    /// Advanced styling options
    /// </summary>
    public readonly LineStyle LineStyle = new() { Color = Colors.Gray, Width = 2 };

    /// <summary>
    /// Color of the arrow line and arrowhead
    /// </summary>
    public Color Color
    {
        get => LineStyle.Color;
        set => LineStyle.Color = value;
    }

    /// <summary>
    /// Thickness of the line at the base of the arrow
    /// </summary>
    public float LineWidth
    {
        get => LineStyle.Width;
        set => LineStyle.Width = value;
    }

    /// <summary>
    /// Total width of the arrowhead in pixels
    /// </summary>
    public float ArrowheadWidth { get; set; } = 10;

    /// <summary>
    /// Length of the arrowhead in pixels
    /// </summary>
    public float ArrowheadLength { get; set; } = 16;

    /// <summary>
    /// The base of the arrow will be expanded away from the tip so its length is always at least this number of pixels
    /// </summary>
    public float MinimumLength { get; set; } = 0;

    /// <summary>
    /// Back the arrow away from its tip along its axis by this many pixels
    /// </summary>
    public float Offset { get; set; } = 0;

    public AxisLimits GetAxisLimits() => new(
        Math.Min(Base.X, Tip.X),
        Math.Max(Base.X, Tip.X),
        Math.Min(Base.Y, Tip.Y),
        Math.Max(Base.Y, Tip.Y));

    public void Render(RenderPack rp)
    {
        if (!IsVisible)
        {
            return;
        }

        using SKPaint paint = new();
        LineStyle.ApplyToPaint(paint);

        var pxBase = Axes.GetPixel(Base);
        var pxTip = Axes.GetPixel(Tip);
        var dist0 = CalcDistance(ref pxTip, ref pxBase);
        var dist = dist0;

        double angle;
        SKPoint skptTipOffset;

        // Line
        {
            Pixel pxEdgeBase, pxEdgeTip;
            if (dist < 1)
            {
                // To avoid getting incorrect angle when zooming far out, extend both base and tip to edges.

                var coordEdgeBase = Coordinates.NaN;
                var coordEdgeTip = Coordinates.NaN;

                var xDif = Base.X - Tip.X;
                var yDif = Base.Y - Tip.Y;

                // Dot product
                var dp1 = xDif * (Axes.XAxis.Max - Axes.XAxis.Min) + yDif * (Axes.YAxis.Max - Axes.YAxis.Min);
                var dp2 = xDif * (Axes.XAxis.Min - Axes.XAxis.Max) + yDif * (Axes.YAxis.Max - Axes.YAxis.Min);

                if (dp1 > 0)
                {
                    if (dp2 > 0) // Top
                    {
                        coordEdgeBase.X = Tip.X + xDif * (Axes.YAxis.Max - Tip.Y) / yDif;
                        coordEdgeBase.Y = Axes.YAxis.Max;

                        coordEdgeTip.X = Tip.X - xDif * (Tip.Y - Axes.YAxis.Min) / yDif;
                        coordEdgeTip.Y = Axes.YAxis.Min;
                    }
                    else // Right
                    {
                        coordEdgeBase.X = Axes.XAxis.Max;
                        coordEdgeBase.Y = Tip.Y + yDif * (Axes.XAxis.Max - Tip.X) / xDif;

                        coordEdgeTip.X = Axes.XAxis.Min;
                        coordEdgeTip.Y = Tip.Y - yDif * (Tip.X - Axes.XAxis.Min) / xDif;
                    }
                }
                else
                {
                    if (dp2 > 0) // Left
                    {
                        coordEdgeBase.X = Axes.XAxis.Min;
                        coordEdgeBase.Y = Tip.Y - yDif * (Tip.X - Axes.XAxis.Min) / xDif;

                        coordEdgeTip.X = Axes.XAxis.Max;
                        coordEdgeTip.Y = Tip.Y + yDif * (Axes.XAxis.Max - Tip.X) / xDif;
                    }
                    else // Bottom
                    {
                        coordEdgeBase.X = Tip.X - xDif * (Tip.Y - Axes.YAxis.Min) / yDif;
                        coordEdgeBase.Y = Axes.YAxis.Min;

                        coordEdgeTip.X = Tip.X + xDif * (Axes.YAxis.Max - Tip.Y) / yDif;
                        coordEdgeTip.Y = Axes.YAxis.Max;
                    }
                }

                pxEdgeBase = Axes.GetPixel(coordEdgeBase);
                pxEdgeTip = Axes.GetPixel(coordEdgeTip);
            }
            else
            {
                pxEdgeBase = pxBase;
                pxEdgeTip = pxTip;
            }

            angle = Math.Atan2(pxEdgeTip.Y - pxEdgeBase.Y, pxEdgeTip.X - pxEdgeBase.X);

            if (Offset == 0)
            {
                skptTipOffset = pxTip.ToSkPoint();
            }
            else
            {
                skptTipOffset = Rotate(pxTip.X - Offset, pxTip.Y, pxTip.X, pxTip.Y, angle);
                dist -= Offset;
            }

            SKPoint skptBaseExtended;
            if (dist < MinimumLength)
            {
                var m = MinimumLength / CalcDistance(ref pxEdgeBase, ref pxEdgeTip);
                skptBaseExtended = new(
                    skptTipOffset.X - (pxEdgeTip.X - pxEdgeBase.X) * m,
                    skptTipOffset.Y - (pxEdgeTip.Y - pxEdgeBase.Y) * m);
                dist = MinimumLength;
            }
            else
            {
                skptBaseExtended = pxBase.ToSkPoint();
            }

            if (dist - ArrowheadLength >= 1)
            {
                var skptHeadBottom = Rotate(
                    skptTipOffset.X - ArrowheadLength,
                    skptTipOffset.Y,
                    skptTipOffset.X,
                    skptTipOffset.Y,
                    angle);
                rp.Canvas.DrawLine(skptBaseExtended, skptHeadBottom, paint);
            }
        }

        // Head
        if (ArrowheadLength >= 1)
        {
            using SKPath path = new();
            path.MoveTo(skptTipOffset);
            path.LineTo(Rotate(
                skptTipOffset.X - ArrowheadLength - 1,
                skptTipOffset.Y + ArrowheadWidth / 2,
                skptTipOffset.X,
                skptTipOffset.Y,
                angle));
            path.LineTo(Rotate(
                skptTipOffset.X - ArrowheadLength - 1,
                skptTipOffset.Y - ArrowheadWidth / 2,
                skptTipOffset.X,
                skptTipOffset.Y,
                angle));
            path.LineTo(skptTipOffset);

            paint.Style = SKPaintStyle.Fill;
            rp.Canvas.DrawPath(path, paint);
        }

        static float CalcDistance(ref Pixel px1, ref Pixel px2)
            => (float)Math.Sqrt(Math.Pow(px1.X - px2.X, 2) + Math.Pow(px1.Y - px2.Y, 2));

        static SKPoint Rotate(float x, float y, float xCenter, float yCenter, double angleRadians)
        {
            var sin = Math.Sin(angleRadians);
            var cos = Math.Cos(angleRadians);
            var dx = x - xCenter;
            var dy = y - yCenter;

            return new SKPoint((float)(dx * cos - dy * sin + xCenter), (float)(dy * cos + dx * sin + yCenter));
        }
    }
}