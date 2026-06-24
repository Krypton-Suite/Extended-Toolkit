#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Reference to an opened <see cref="KryptonBottomSheet"/> instance.
/// </summary>
public sealed class KryptonBottomSheetRef
{
    private readonly TaskCompletionSource<object?> _dismissedSource = new(TaskCreationOptions.RunContinuationsAsynchronously);
    private Control _instance;
    private bool _isDismissed;
    private bool _isOpened;

    /// <summary>
    /// Initializes a new reference for the hosted bottom sheet content.
    /// </summary>
    public KryptonBottomSheetRef(Control instance, Action<object?> dismissAction)
    {
        _instance = instance;
        DismissAction = dismissAction;
    }

    internal Action<object?> DismissAction { get; }

    /// <summary>
    /// Gets the hosted content control instance.
    /// </summary>
    public Control Instance => _instance;

    /// <summary>
    /// Gets a value indicating whether the sheet has completed its open animation.
    /// </summary>
    public bool IsOpened => _isOpened;

    /// <summary>
    /// Gets a value indicating whether the sheet has been dismissed.
    /// </summary>
    public bool IsDismissed => _isDismissed;

    /// <summary>
    /// Occurs after the bottom sheet open animation completes.
    /// </summary>
    public event EventHandler? AfterOpened;

    /// <summary>
    /// Occurs after the bottom sheet has finished its dismiss animation and closed.
    /// </summary>
    public event EventHandler<KryptonBottomSheetDismissedEventArgs>? AfterDismissed;

    /// <summary>
    /// Returns a task that completes when the bottom sheet has been dismissed.
    /// </summary>
    public Task<object?> AfterDismissedAsync() => _dismissedSource.Task;

    /// <summary>
    /// Closes the bottom sheet and optionally returns a result to subscribers.
    /// </summary>
    public void Dismiss(object? result = null)
    {
        if (_isDismissed)
        {
            return;
        }

        DismissAction(result);
    }

    internal void SetInstance(Control instance) => _instance = instance;

    internal void NotifyOpened()
    {
        if (_isOpened)
        {
            return;
        }

        _isOpened = true;
        AfterOpened?.Invoke(this, EventArgs.Empty);
    }

    internal void NotifyDismissed(object? result)
    {
        if (_isDismissed)
        {
            return;
        }

        _isDismissed = true;
        KryptonBottomSheetDismissedEventArgs args = new(result);
        AfterDismissed?.Invoke(this, args);
        _dismissedSource.TrySetResult(result);
    }
}
