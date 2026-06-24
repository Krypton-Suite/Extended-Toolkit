#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Strongly typed bottom sheet content contract.
/// </summary>
/// <typeparam name="TData">The data type passed through configuration.</typeparam>
public interface IKryptonBottomSheetContent<TData>
{
    /// <summary>
    /// Called after the content has been hosted inside an opened bottom sheet.
    /// </summary>
    void OnBottomSheetOpened(KryptonBottomSheetRef sheetRef, TData data);
}
