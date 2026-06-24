#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Specifies the easing curve used for bottom sheet slide animations.
/// </summary>
public enum BottomSheetAnimationEasing
{
    /// <summary>
    /// Cubic ease-out when opening and cubic ease-in when closing.
    /// </summary>
    Standard,

    /// <summary>
    /// Linear interpolation without easing.
    /// </summary>
    Linear,
}
