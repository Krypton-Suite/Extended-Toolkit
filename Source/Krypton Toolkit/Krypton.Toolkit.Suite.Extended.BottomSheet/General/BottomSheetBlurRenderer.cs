#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Captures and blurs owner content for frosted-glass backdrops.
/// </summary>
public static class BottomSheetBlurRenderer
{
    public static Bitmap? CaptureControl(Control? control)
    {
        if (control == null || control.Width <= 0 || control.Height <= 0 || !control.IsHandleCreated)
        {
            return null;
        }

        var bitmap = new Bitmap(control.Width, control.Height);
        control.DrawToBitmap(bitmap, new Rectangle(Point.Empty, control.Size));
        return bitmap;
    }

    public static Bitmap ApplyBlur(Bitmap source, int radius, double opacity)
    {
        int scale = Math.Max(2, Math.Min(12, radius));
        int smallWidth = Math.Max(1, source.Width / scale);
        int smallHeight = Math.Max(1, source.Height / scale);

        using var downscaled = new Bitmap(smallWidth, smallHeight);
        using (Graphics downscaleGraphics = Graphics.FromImage(downscaled))
        {
            downscaleGraphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            downscaleGraphics.DrawImage(source, 0, 0, smallWidth, smallHeight);
        }

        var blurred = new Bitmap(source.Width, source.Height);
        using (Graphics graphics = Graphics.FromImage(blurred))
        {
            graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            graphics.DrawImage(downscaled, 0, 0, blurred.Width, blurred.Height);

            int alpha = (int)Math.Round(BottomSheetAnimation.Clamp(opacity, 0d, 1d) * 160d);
            if (alpha > 0)
            {
                using SolidBrush dim = new(Color.FromArgb(alpha, Color.Black));
                graphics.FillRectangle(dim, new Rectangle(Point.Empty, blurred.Size));
            }
        }

        return blurred;
    }
}
