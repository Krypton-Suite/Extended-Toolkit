#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

public static class BottomSheetRendering
{
    public static GraphicsPath CreateTopRoundRectPath(Rectangle bounds, int radius)
    {
        GraphicsPath path = new();
        if (radius <= 0 || bounds.Width <= 0 || bounds.Height <= 0)
        {
            path.AddRectangle(bounds);
            return path;
        }

        int diameter = Math.Min(radius * 2, Math.Min(bounds.Width, bounds.Height));
        Rectangle topLeft = new(bounds.X, bounds.Y, diameter, diameter);
        Rectangle topRight = new(bounds.Right - diameter, bounds.Y, diameter, diameter);

        path.AddLine(bounds.Left, bounds.Bottom, bounds.Left, bounds.Top + radius);
        path.AddArc(topLeft, 180, 90);
        path.AddArc(topRight, 270, 90);
        path.AddLine(bounds.Right, bounds.Top + radius, bounds.Right, bounds.Bottom);
        path.CloseFigure();
        return path;
    }

    public static void DrawElevationShadow(
        Graphics graphics,
        Rectangle bounds,
        int cornerRadius,
        int elevation,
        Color shadowColor)
    {
        if (elevation <= 0)
        {
            return;
        }

        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        int spread = Math.Max(1, elevation / 2);

        for (int layer = spread; layer >= 1; layer--)
        {
            double factor = (double)layer / spread;
            int offset = layer;
            int alpha = (int)Math.Round(shadowColor.A * 0.35d * factor / spread);
            alpha = Math.Max(1, Math.Min(alpha, 255));

            Rectangle layerBounds = new(
                bounds.X + offset,
                bounds.Y - offset / 2,
                bounds.Width,
                bounds.Height);

            using SolidBrush brush = new(Color.FromArgb(alpha, shadowColor));
            using GraphicsPath path = CreateTopRoundRectPath(layerBounds, cornerRadius);
            graphics.FillPath(brush, path);
        }
    }

    public static void DrawHandle(Graphics graphics, Rectangle bounds, Color handleColor, bool rightToLeft)
    {
        int handleWidth = BottomSheetMetrics.HandleWidth;
        int handleHeight = BottomSheetMetrics.HandleHeight;
        int x = rightToLeft
            ? bounds.X + BottomSheetMetrics.StandardPadding
            : bounds.X + (bounds.Width - handleWidth) / 2;

        Rectangle handleBounds = new(
            x,
            bounds.Y + BottomSheetMetrics.HandleTopMargin,
            handleWidth,
            handleHeight);

        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using SolidBrush brush = new(handleColor);
        using GraphicsPath path = new();
        path.AddArc(handleBounds, 180, 180);
        path.AddArc(handleBounds, 0, 180);
        path.CloseFigure();
        graphics.FillPath(brush, path);
    }

    public static Color ResolveSurfaceColor(BottomSheetSurfaceStyle surfaceStyle) =>
        KryptonManager.CurrentGlobalPalette.GetBackColor1(ToPaletteBackStyle(surfaceStyle), PaletteState.Normal);

    public static PaletteBackStyle ToPaletteBackStyle(BottomSheetSurfaceStyle surfaceStyle) =>
        surfaceStyle switch
        {
            BottomSheetSurfaceStyle.PanelAlternate => PaletteBackStyle.PanelAlternate,
            BottomSheetSurfaceStyle.ControlClient => PaletteBackStyle.ControlClient,
            _ => PaletteBackStyle.PanelClient,
        };
}
