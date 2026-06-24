#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Easing helpers for bottom sheet animations.
/// </summary>
internal static class BottomSheetAnimation
{
    public const int DefaultDurationMilliseconds = BottomSheetMetrics.AnimationDurationMilliseconds;

    public static double EaseOutCubic(double t) => 1d - Math.Pow(1d - t, 3d);

    public static double EaseInCubic(double t) => t * t * t;

    public static double CalculateProgress(int elapsedMilliseconds, int durationMilliseconds)
    {
        if (durationMilliseconds <= 0)
        {
            return 1d;
        }

        return Clamp((double)elapsedMilliseconds / durationMilliseconds, 0d, 1d);
    }

    public static double ResolveEasing(double progress, bool closing, BottomSheetAnimationEasing easing)
    {
        if (easing == BottomSheetAnimationEasing.Linear)
        {
            return progress;
        }

        return ResolveEasing(progress, closing);
    }

    public static double ResolveEasing(double progress, bool closing) =>
        closing ? EaseInCubic(progress) : EaseOutCubic(progress);

    public static int Interpolate(int from, int to, double progress)
    {
        progress = Clamp(progress, 0d, 1d);
        return from + (int)Math.Round((to - from) * progress);
    }

    public static double Interpolate(double from, double to, double progress)
    {
        progress = Clamp(progress, 0d, 1d);
        return from + ((to - from) * progress);
    }

    public static double Clamp(double value, double min, double max) =>
        Math.Max(min, Math.Min(max, value));
}
