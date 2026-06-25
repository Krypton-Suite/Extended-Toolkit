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
/// Resolves drag snap targets for bottom sheet height detents.
/// </summary>
public static class BottomSheetSnapResolver
{
    public static int ResolveTargetHeight(
        int currentHeight,
        int hostHeight,
        int minimumHeight,
        int maximumHeight,
        IReadOnlyList<int> snapHeights)
    {
        if (snapHeights.Count == 0)
        {
            return Clamp(currentHeight, minimumHeight, maximumHeight);
        }

        int best = snapHeights[0];
        int bestDistance = Math.Abs(currentHeight - best);

        foreach (int snap in snapHeights)
        {
            int clamped = Clamp(snap, minimumHeight, Math.Min(maximumHeight, hostHeight - 48));
            int distance = Math.Abs(currentHeight - clamped);
            if (distance < bestDistance)
            {
                best = clamped;
                bestDistance = distance;
            }
        }

        return best;
    }

    public static IReadOnlyList<int> NormalizeSnapHeights(
        IEnumerable<int>? snapHeights,
        IEnumerable<double>? snapHeightPercentages,
        int hostHeight,
        int minimumHeight,
        int maximumHeight)
    {
        List<int> resolved = new();

        if (snapHeights != null)
        {
            resolved.AddRange(
                snapHeights.Select(height => Clamp(height, minimumHeight, maximumHeight)));
        }

        if (snapHeightPercentages != null && hostHeight > 0)
        {
            foreach (double percentage in snapHeightPercentages)
            {
                double clampedPercent = BottomSheetAnimation.Clamp(percentage, 0.05d, 1d);
                int height = (int)Math.Round(hostHeight * clampedPercent);
                resolved.Add(Clamp(height, minimumHeight, maximumHeight));
            }
        }

        return resolved
            .Distinct()
            .OrderBy(height => height)
            .ToArray();
    }

    public static IReadOnlyList<int> NormalizeSnapHeights(
        IEnumerable<int>? snapHeights,
        int minimumHeight,
        int maximumHeight) =>
        NormalizeSnapHeights(snapHeights, null, maximumHeight, minimumHeight, maximumHeight);

    private static int Clamp(int value, int min, int max) =>
        Math.Max(min, Math.Min(max, value));
}
