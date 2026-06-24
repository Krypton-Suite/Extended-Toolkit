#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Specifies how the bottom sheet height is determined.
/// </summary>
public enum BottomSheetHeightMode
{
    /// <summary>
    /// Use the configured <see cref="KryptonBottomSheetConfig.SheetHeight"/> value.
    /// </summary>
    Fixed,

    /// <summary>
    /// Measure hosted content and clamp to configured minimum and maximum heights.
    /// </summary>
    Auto,
}
