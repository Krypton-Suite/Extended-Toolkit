#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Card;

/// <summary>
/// Specifies how an image is displayed inside <see cref="KryptonCardImage"/>.
/// </summary>
public enum CardImageSizeMode
{
    /// <summary>
    /// Stretch the image to fill the section.
    /// </summary>
    Stretch = 0,

    /// <summary>
    /// Scale the image proportionally to fit.
    /// </summary>
    Zoom = 1,

    /// <summary>
    /// Crop the image to fill the section while preserving aspect ratio.
    /// </summary>
    Crop = 2,
}
