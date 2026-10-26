namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

/// <summary>
/// Common methods which legends may choose to use for rendering
/// </summary>
public static class Common
{
    /// <summary>
    /// Render a leger item: its label, symbol, and all its children
    /// </summary>
    public static void RenderItem(
        SKCanvas canvas,
        SKPaint paint,
        SKFont font,
        SizedLegendItem sizedItem,
        float x,
        float y,
        float symbolWidth,
        float symbolPadRight,
        PixelPadding itemPadding)
    {
        LegendItem item = sizedItem.Item;

        SKPoint textPoint = new(x, y + font.Size);
        float ownHeight = sizedItem.Size.OwnSize.Height;

        if (item.HasSymbol)
        {
            RenderSymbol(
                canvas: canvas,
                item: item,
                x: x,
                y: y + itemPadding.Bottom,
                height: ownHeight - itemPadding.Vertical,
                symbolWidth: symbolWidth);

            textPoint.X += symbolWidth + symbolPadRight;
        }

        using SKAutoCanvasRestore _ = new(canvas);
        if (!string.IsNullOrEmpty(item.Label))
        {
            canvas.DrawText(item.Label, textPoint, SKTextAlign.Left, font, paint);
            canvas.Translate(itemPadding.Left, 0);
        }

        y += ownHeight;
        foreach (var curr in sizedItem.Children)
        {
            RenderItem(canvas, paint, font, curr, x, y, symbolWidth, symbolPadRight, itemPadding);
            y += curr.Size.WithChildren.Height;
        }
    }

    /// <summary>
    /// Render just the symbol of a legend
    /// </summary>
    public static void RenderSymbol(
        SKCanvas canvas,
        LegendItem item,
        float x,
        float y,
        float height,
        float symbolWidth)
    {
        // TODO: make LegendSymbol its own object that include size and padding

        PixelRect rect = new(x, x + symbolWidth, y + height, y);

        using SKPaint paint = new();

        if (item.Line is not null)
        {
            item.Line.ApplyToPaint(paint);
            canvas.DrawLine(new(rect.Left, rect.VerticalCenter), new(rect.Right, rect.VerticalCenter), paint);
        }

        if (item.Marker.IsVisible)
        {
            Pixel px = new(rect.HorizontalCenter, rect.VerticalCenter);
            Drawing.DrawMarker(canvas, paint, px, item.Marker);
        }

        if (item.Fill.HasValue)
        {
            item.Fill.ApplyToPaint(paint);
            canvas.DrawRect(rect.ToSkRect(), paint);
        }
    }

    /// <summary>
    /// Return the size of the given item including all its children
    /// </summary>
    public static LegendItemSize Measure(
        LegendItem item,
        SKPaint paint,
        SKFont font,
        SizedLegendItem[] children,
        float symbolWidth,
        float symbolPadRight,
        PixelPadding padding,
        PixelPadding itemPadding)
    {
        PixelSize labelRect = !string.IsNullOrWhiteSpace(item.Label)
            ? Drawing.MeasureString(item.Label ?? string.Empty, font)
            : new(0, 0);

        float width2 = item.HasSymbol ? symbolWidth : 0;
        float width = width2 + symbolPadRight + labelRect.Width + itemPadding.Horizontal;
        float height = font.Size + padding.Vertical;

        PixelSize ownSize = new(width, height);

        foreach (SizedLegendItem childItem in children)
        {
            width = Math.Max(width, padding.Left + childItem.Size.WithChildren.Width);
            height += childItem.Size.WithChildren.Height;
        }

        return new LegendItemSize(ownSize, new(width, height));
    }
}