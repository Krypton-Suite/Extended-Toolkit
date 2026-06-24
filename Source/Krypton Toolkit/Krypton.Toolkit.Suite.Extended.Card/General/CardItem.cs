#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Card;

/// <summary>
/// Represents a data item displayed by <see cref="KryptonCardList"/>.
/// </summary>
public class CardItem
{
    /// <summary>
    /// Gets or sets the card title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the card subtitle.
    /// </summary>
    public string Subtitle { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the optional banner image.
    /// </summary>
    public Image? Image { get; set; }

    /// <summary>
    /// Gets or sets optional body text.
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets optional associated data.
    /// </summary>
    public object? Tag { get; set; }
}
