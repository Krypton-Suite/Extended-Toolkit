#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Allows bottom sheet content to receive the active sheet reference and passed data.
/// </summary>
public interface IKryptonBottomSheetContent
{
    /// <summary>
    /// Called after the content has been hosted inside an opened bottom sheet.
    /// </summary>
    /// <param name="sheetRef">The active bottom sheet reference.</param>
    /// <param name="data">Optional data supplied through <see cref="KryptonBottomSheetConfig.Data"/>.</param>
    void OnBottomSheetOpened(KryptonBottomSheetRef sheetRef, object? data);
}
