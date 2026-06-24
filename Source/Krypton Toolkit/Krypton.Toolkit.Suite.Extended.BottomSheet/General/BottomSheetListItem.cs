#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Represents a selectable action row in a <see cref="KryptonBottomSheetList"/>.
/// </summary>
public sealed class BottomSheetListItem
{
    /// <summary>
    /// Gets or sets the primary text shown for the action.
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets optional secondary text shown below the primary text.
    /// </summary>
    public string? Subtitle { get; set; }

    /// <summary>
    /// Gets or sets the optional result returned when the item is selected.
    /// </summary>
    public object? Result { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the item is enabled.
    /// </summary>
    public bool Enabled { get; set; } = true;
}
