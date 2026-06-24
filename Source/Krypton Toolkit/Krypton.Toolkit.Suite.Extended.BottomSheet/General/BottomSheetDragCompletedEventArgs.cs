#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Event data raised when a drag gesture completes without dismissing the sheet.
/// </summary>
public sealed class BottomSheetDragCompletedEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BottomSheetDragCompletedEventArgs"/> class.
    /// </summary>
    /// <param name="targetHeight">The resolved sheet height after snapping.</param>
    public BottomSheetDragCompletedEventArgs(int targetHeight) => TargetHeight = targetHeight;

    /// <summary>
    /// Gets the resolved sheet height after snapping.
    /// </summary>
    public int TargetHeight { get; }
}
