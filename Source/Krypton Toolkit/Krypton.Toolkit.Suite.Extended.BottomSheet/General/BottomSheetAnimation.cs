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
