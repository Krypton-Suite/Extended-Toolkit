#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Card;

/// <summary>
/// Specifies the visual appearance of a <see cref="KryptonCard"/>.
/// </summary>
public enum CardAppearance
{
    /// <summary>
    /// Elevated card with optional drop shadow.
    /// </summary>
    Elevated = 0,

    /// <summary>
    /// Flat card with an outline border.
    /// </summary>
    Outlined = 1,

    /// <summary>
    /// Filled card with a solid themed background and no shadow.
    /// </summary>
    Filled = 2,
}
