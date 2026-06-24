#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Measures hosted content to support auto-height bottom sheets.
/// </summary>
internal static class BottomSheetLayout
{
    public static int MeasureContentHeight(Control content, KryptonBottomSheet sheet, KryptonBottomSheetConfig config, float dpiScale)
    {
        int horizontalPadding = BottomSheetDpi.Scale(BottomSheetMetrics.StandardPadding * 2, dpiScale);
        int chromePadding = sheet.ShowHandle
            ? BottomSheetDpi.Scale(
                BottomSheetMetrics.HandleTopMargin
                + BottomSheetMetrics.HandleHeight
                + BottomSheetMetrics.HandleBottomMargin
                + BottomSheetMetrics.StandardPadding,
                dpiScale)
            : BottomSheetDpi.Scale(BottomSheetMetrics.StandardPadding * 2, dpiScale);

        int availableWidth = Math.Max(120, sheet.Width - horizontalPadding);
        Size preferred = content.GetPreferredSize(new Size(availableWidth, 0));
        int measured = preferred.Height + chromePadding;
        return Math.Max(config.MinimumSheetHeight, Math.Min(config.MaximumSheetHeight, measured));
    }
}
