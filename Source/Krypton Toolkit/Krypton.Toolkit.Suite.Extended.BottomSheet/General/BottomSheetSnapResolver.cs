#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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
