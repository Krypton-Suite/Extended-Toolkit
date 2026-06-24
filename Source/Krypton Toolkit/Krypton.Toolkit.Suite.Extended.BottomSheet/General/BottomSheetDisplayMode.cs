#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Specifies whether a bottom sheet blocks the owner window.
/// </summary>
public enum BottomSheetDisplayMode
{
    /// <summary>
    /// Blocks the owner with a modal dialog loop.
    /// </summary>
    Modal,

    /// <summary>
    /// Shows the sheet without blocking the owner message loop.
    /// </summary>
    NonModal,
}
