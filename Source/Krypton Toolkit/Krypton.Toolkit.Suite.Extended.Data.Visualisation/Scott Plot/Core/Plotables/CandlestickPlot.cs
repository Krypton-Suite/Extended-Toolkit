namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class CandlestickPlot(IOhlcSource data) : IPlottable
    {
        public bool IsVisible { get; set; } = true;

        public IAxes Axes { get; set; } = new Axes();

        private readonly IOhlcSource _data = data;

        /// <summary>
        /// X position of candles is sourced from the OHLC's DateTime by default.
        /// If this option is enabled, X position will be an ascending integers starting at 0 with no gaps.
        /// </summary>
        public bool Sequential { get; set; } = false;

        /// <summary>
        /// Fractional width of the candle symbol relative to its time span
        /// </summary>
        public double SymbolWidth = .8;

        public LineStyle RisingLineStyle { get; } = new()
        {
            Color = Color.FromHex("#089981"),
            Width = 2,
        };

        public LineStyle FallingLineStyle { get; } = new()
        {
            Color = Color.FromHex("#f23645"),
            Width = 2,
        };

        public FillStyle RisingFillStyle { get; } = new()
        {
            Color = Color.FromHex("#089981"),
        };

        public FillStyle FallingFillStyle { get; } = new()
        {
            Color = Color.FromHex("#f23645"),
        };

        public IEnumerable<LegendItem> LegendItems => Enumerable.Empty<LegendItem>();

        public AxisLimits GetAxisLimits()
        {
            AxisLimits limits = _data.GetLimits(); // TODO: Data.GetSequentialLimits()

            if (Sequential)
            {
                limits = new AxisLimits(0, _data.GetOhlCs().Count, limits.Bottom, limits.Top);
            }

            return limits;
        }

        public void Render(RenderPack rp)
        {
            using SKPaint paint = new();

            IList<Ohlc> ohlcs = _data.GetOhlCs();
            for (int i = 0; i < ohlcs.Count; i++)
            {
                Ohlc ohlc = ohlcs[i];
                bool isRising = ohlc.Close >= ohlc.Open;
                LineStyle lineStyle = isRising ? RisingLineStyle : FallingLineStyle;
                FillStyle fillStlye = isRising ? RisingFillStyle : FallingFillStyle;

                float top = Axes.GetPixelY(ohlc.High);
                float bottom = Axes.GetPixelY(ohlc.Low);

                float center, left, right;
                if (Sequential == false)
                {
                    center = Axes.GetPixelX(ohlc.DateTime.ToNumber());
                    TimeSpan halfWidth = new((long)(ohlc.TimeSpan.Ticks * SymbolWidth / 2));
                    DateTime leftTime = ohlc.DateTime - halfWidth;
                    DateTime rightTime = ohlc.DateTime + halfWidth;
                    left = Axes.GetPixelX(leftTime.ToNumber());
                    right = Axes.GetPixelX(rightTime.ToNumber());
                }
                else
                {
                    center = Axes.GetPixelX(i);
                    left = Axes.GetPixelX(i - (float)SymbolWidth / 2);
                    right = Axes.GetPixelX(i + (float)SymbolWidth / 2);
                }

                // do not render OHLCs off the screen
                if (right < rp.DataRect.Left || left > rp.DataRect.Right)
                {
                    continue;
                }

                float open = Axes.GetPixelY(ohlc.Open);
                float close = Axes.GetPixelY(ohlc.Close);

                // center line
                using SKPath path = new();
                path.MoveTo(center, top);
                path.LineTo(center, bottom);

                lineStyle.ApplyToPaint(paint);
                rp.Canvas.DrawPath(path, paint);

                // rectangle
                SKRect rect = new(left, Math.Max(open, close), right, Math.Min(open, close));
                fillStlye.ApplyToPaint(paint);
                rp.Canvas.DrawRect(rect, paint);
            }
        }
    }
}