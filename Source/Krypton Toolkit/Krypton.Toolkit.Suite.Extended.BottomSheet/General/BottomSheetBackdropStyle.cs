#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Specifies how the bottom sheet backdrop is rendered.
/// </summary>
public enum BottomSheetBackdropStyle
{
    /// <summary>
    /// Standard dimmed backdrop.
    /// </summary>
    Dim,

    /// <summary>
    /// Stronger multi-layer scrim for additional depth.
    /// </summary>
    EnhancedDim,

    /// <summary>
    /// Soft scrim with a subtle vertical gradient.
    /// </summary>
    SoftGradient,

    /// <summary>
    /// Captures and blurs the owner surface behind the sheet.
    /// </summary>
    Blur,
}
