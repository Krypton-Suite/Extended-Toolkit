#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Specifies which element receives focus when a bottom sheet opens.
/// </summary>
public enum BottomSheetAutoFocusMode
{
    /// <summary>
    /// Focus the first tabbable element in the sheet content.
    /// </summary>
    FirstTabbable,

    /// <summary>
    /// Focus the first header element in the sheet content.
    /// </summary>
    FirstHeader,

    /// <summary>
    /// Focus the root bottom sheet surface.
    /// </summary>
    Sheet,

    /// <summary>
    /// Do not change focus automatically.
    /// </summary>
    None,
}
