#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Specifies how a new bottom sheet request is handled when another sheet is already open.
/// </summary>
public enum BottomSheetConflictMode
{
    /// <summary>
    /// Throw an exception when a sheet is already open.
    /// </summary>
    Throw,

    /// <summary>
    /// Animate the current sheet closed, then open the new sheet.
    /// </summary>
    Replace,

    /// <summary>
    /// Queue the request and open it after the current sheet is dismissed.
    /// </summary>
    Queue,
}
