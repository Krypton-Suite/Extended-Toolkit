#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Enables and restores the owner form while a modal bottom sheet is displayed.
/// </summary>
internal sealed class BottomSheetOwnerState : IDisposable
{
    private readonly Form? _ownerForm;
    private readonly bool _wasEnabled;

    public BottomSheetOwnerState(IWin32Window? owner, bool disableOwner)
    {
        _ownerForm = owner as Form;
        if (_ownerForm == null || !disableOwner)
        {
            return;
        }

        _wasEnabled = _ownerForm.Enabled;
        _ownerForm.Enabled = false;
    }

    public void Dispose()
    {
        if (_ownerForm == null || _ownerForm.IsDisposed)
        {
            return;
        }

        _ownerForm.Enabled = _wasEnabled;
    }
}
