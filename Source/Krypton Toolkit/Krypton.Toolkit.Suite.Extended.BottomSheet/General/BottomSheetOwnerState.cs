#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2026 - 2026 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
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
