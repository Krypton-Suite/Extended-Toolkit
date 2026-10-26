#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2026 - 2026 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Card;

public static class CardRendering
{
    public static GraphicsPath CreateRoundRectPath(Rectangle bounds, int radius)
    {
        GraphicsPath path = new();
        if (radius <= 0 || bounds.Width <= 0 || bounds.Height <= 0)
        {
            path.AddRectangle(bounds);
            return path;
        }

        int diameter = Math.Min(radius * 2, Math.Min(bounds.Width, bounds.Height));
        Rectangle arc = new(bounds.X, bounds.Y, diameter, diameter);

        path.AddArc(arc, 180, 90);
        arc.X = bounds.Right - diameter;
        path.AddArc(arc, 270, 90);
        arc.Y = bounds.Bottom - diameter;
        path.AddArc(arc, 0, 90);
        arc.X = bounds.Left;
        path.AddArc(arc, 90, 90);
        path.CloseFigure();
        return path;
    }

    public static void DrawElevationShadow(
        Graphics graphics,
        Rectangle bounds,
        int cornerRadius,
        int elevation,
        Color shadowColor,
        bool useBlur)
    {
        if (elevation <= 0)
        {
            return;
        }

        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        int spread = Math.Max(1, elevation / 2);
        int layers = useBlur ? spread * 2 : spread;

        for (int layer = layers; layer >= 1; layer--)
        {
            double factor = (double)layer / layers;
            int offset = useBlur
                ? (int)Math.Round(spread * factor)
                : layer;

            int alpha = useBlur
                ? (int)Math.Round(shadowColor.A * 0.35d * factor / layers)
                : (int)Math.Round(shadowColor.A * factor / spread);

            alpha = Math.Max(1, Math.Min(alpha, 255));
            Rectangle layerBounds = new(
                bounds.X + offset,
                bounds.Y + offset,
                bounds.Width,
                bounds.Height);

            using SolidBrush brush = new(Color.FromArgb(alpha, shadowColor));
            using GraphicsPath path = CreateRoundRectPath(layerBounds, cornerRadius);
            graphics.FillPath(brush, path);
        }
    }

    public static void DrawOutline(
        Graphics graphics,
        Rectangle bounds,
        int cornerRadius,
        Color borderColor,
        float width = 1f)
    {
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        Rectangle inset = bounds;
        inset.Width = Math.Max(0, inset.Width - 1);
        inset.Height = Math.Max(0, inset.Height - 1);

        using Pen pen = new(borderColor, width);
        using GraphicsPath path = CreateRoundRectPath(inset, cornerRadius);
        graphics.DrawPath(pen, path);
    }

    public static void DrawSelectionAccent(
        Graphics graphics,
        Rectangle bounds,
        int cornerRadius,
        Color accentColor)
    {
        DrawOutline(graphics, bounds, cornerRadius, accentColor, 2f);
    }

    public static void DrawRipple(
        Graphics graphics,
        Rectangle bounds,
        Point center,
        int rippleRadius,
        Color rippleColor)
    {
        if (rippleRadius <= 0)
        {
            return;
        }

        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        Rectangle rippleBounds = new(
            center.X - rippleRadius,
            center.Y - rippleRadius,
            rippleRadius * 2,
            rippleRadius * 2);

        using SolidBrush brush = new(rippleColor);
        graphics.SetClip(bounds);
        graphics.FillEllipse(brush, rippleBounds);
        graphics.ResetClip();
    }

    public static Color ResolveShadowColor(Control control)
    {
        if (control.BackColor != Color.Transparent)
        {
            return ControlPaint.Dark(control.BackColor);
        }

        return Color.FromArgb(90, 0, 0, 0);
    }

    public static Rectangle GetCroppedImageBounds(Image image, Rectangle target)
    {
        if (image.Width <= 0 || image.Height <= 0 || target.Width <= 0 || target.Height <= 0)
        {
            return target;
        }

        double imageRatio = (double)image.Width / image.Height;
        double targetRatio = (double)target.Width / target.Height;

        if (imageRatio > targetRatio)
        {
            int height = image.Height;
            int width = (int)Math.Round(height * targetRatio);
            int x = (image.Width - width) / 2;
            return new Rectangle(x, 0, width, height);
        }

        int cropWidth = image.Width;
        int cropHeight = (int)Math.Round(cropWidth / targetRatio);
        int y = (image.Height - cropHeight) / 2;
        return new Rectangle(0, y, cropWidth, cropHeight);
    }
}
