#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Paints configurable backdrop scrims behind the bottom sheet.
/// </summary>
internal sealed class BottomSheetBackdropPanel : Panel
{
    private BottomSheetBackdropStyle _style = BottomSheetBackdropStyle.Dim;
    private double _opacity = BottomSheetMetrics.DefaultBackdropOpacity;
    private Image? _blurImage;

    public BottomSheetBackdropPanel()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint
                 | ControlStyles.OptimizedDoubleBuffer
                 | ControlStyles.UserPaint, true);
        BackColor = Color.Black;
        TabStop = false;
    }

    public BottomSheetBackdropStyle BackdropStyle
    {
        get => _style;
        set
        {
            if (_style != value)
            {
                _style = value;
                Invalidate();
            }
        }
    }

    public double BackdropOpacity
    {
        get => _opacity;
        set
        {
            double opacity = BottomSheetAnimation.Clamp(value, 0.05d, 1d);
            if (Math.Abs(_opacity - opacity) > 0.001d)
            {
                _opacity = opacity;
                Invalidate();
            }
        }
    }

    public double AnimationOpacity { get; set; } = 1d;

    public Image? BlurImage
    {
        get => _blurImage;
        set
        {
            _blurImage = value;
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Rectangle bounds = ClientRectangle;
        if (bounds.Width <= 0 || bounds.Height <= 0)
        {
            return;
        }

        double effectiveOpacity = _opacity * AnimationOpacity;
        switch (_style)
        {
            case BottomSheetBackdropStyle.Blur when _blurImage != null:
                PaintBlur(e.Graphics, bounds, effectiveOpacity);
                break;
            case BottomSheetBackdropStyle.EnhancedDim:
                PaintLayer(e.Graphics, bounds, effectiveOpacity * 0.45d);
                PaintLayer(e.Graphics, bounds, effectiveOpacity * 0.25d, offsetY: 8);
                break;
            case BottomSheetBackdropStyle.SoftGradient:
                PaintGradient(e.Graphics, bounds, effectiveOpacity);
                break;
            default:
                PaintLayer(e.Graphics, bounds, effectiveOpacity);
                break;
        }
    }

    private void PaintBlur(Graphics graphics, Rectangle bounds, double opacity)
    {
        graphics.DrawImage(_blurImage!, bounds);
        PaintLayer(graphics, bounds, opacity * 0.35d);
    }

    private static void PaintLayer(Graphics graphics, Rectangle bounds, double opacity, int offsetY = 0)
    {
        int alpha = (int)Math.Round(BottomSheetAnimation.Clamp(opacity, 0d, 1d) * 255d);
        if (alpha <= 0)
        {
            return;
        }

        Rectangle layer = bounds;
        layer.Y += offsetY;
        using SolidBrush brush = new(Color.FromArgb(alpha, Color.Black));
        graphics.FillRectangle(brush, layer);
    }

    private static void PaintGradient(Graphics graphics, Rectangle bounds, double opacity)
    {
        int topAlpha = (int)Math.Round(opacity * 120d);
        int bottomAlpha = (int)Math.Round(opacity * 220d);
        using LinearGradientBrush brush = new(
            bounds,
            Color.FromArgb(topAlpha, Color.Black),
            Color.FromArgb(bottomAlpha, Color.Black),
            LinearGradientMode.Vertical);
        graphics.FillRectangle(brush, bounds);
    }
}
