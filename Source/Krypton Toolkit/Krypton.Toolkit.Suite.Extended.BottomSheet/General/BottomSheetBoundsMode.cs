#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Specifies the screen region covered by the bottom sheet host overlay.
/// </summary>
public enum BottomSheetBoundsMode
{
    /// <summary>
    /// Cover the owner control client area.
    /// </summary>
    OwnerClient,

    /// <summary>
    /// Cover the monitor working area containing the owner.
    /// </summary>
    WorkingArea,
}
