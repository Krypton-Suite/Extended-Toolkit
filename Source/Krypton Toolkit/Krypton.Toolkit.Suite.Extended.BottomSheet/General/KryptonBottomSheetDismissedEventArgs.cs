#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Event data raised when a bottom sheet is dismissed.
/// </summary>
public sealed class KryptonBottomSheetDismissedEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="KryptonBottomSheetDismissedEventArgs"/> class.
    /// </summary>
    /// <param name="result">Optional result passed to <see cref="KryptonBottomSheetRef.Dismiss"/>.</param>
    public KryptonBottomSheetDismissedEventArgs(object? result) => Result = result;

    /// <summary>
    /// Gets the optional result supplied when the sheet was dismissed.
    /// </summary>
    public object? Result { get; }
}
