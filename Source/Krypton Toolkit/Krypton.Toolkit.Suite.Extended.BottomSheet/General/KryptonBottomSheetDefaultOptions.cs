#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Application-wide default options for bottom sheets.
/// </summary>
public static class KryptonBottomSheetDefaultOptions
{
    private static KryptonBottomSheetConfig _default = new();

    /// <summary>
    /// Gets or sets the default configuration merged into each opened bottom sheet.
    /// </summary>
    public static KryptonBottomSheetConfig Default
    {
        get => _default;
        set => _default = value ?? new KryptonBottomSheetConfig();
    }

    /// <summary>
    /// Creates a resolved configuration by merging <see cref="Default"/> with optional overrides.
    /// </summary>
    public static KryptonBottomSheetConfig Resolve(KryptonBottomSheetConfig? overrides)
    {
        KryptonBottomSheetConfig resolved = _default.Clone();
        if (overrides != null)
        {
            resolved.ApplyPartialOverrides(overrides);
        }

        return resolved;
    }
}
