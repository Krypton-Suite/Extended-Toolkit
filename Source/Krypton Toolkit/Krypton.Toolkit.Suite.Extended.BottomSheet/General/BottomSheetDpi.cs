#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Scales bottom sheet metrics for the current DPI context.
/// </summary>
internal static class BottomSheetDpi
{
    public static float GetScaleFactor(Control? context)
    {
        if (context?.IsHandleCreated == true)
        {
            using Graphics graphics = context.CreateGraphics();
            return graphics.DpiY / 96f;
        }

        return 1f;
    }

    public static int Scale(int value, float scaleFactor) =>
        Math.Max(1, (int)Math.Round(value * scaleFactor));
}
