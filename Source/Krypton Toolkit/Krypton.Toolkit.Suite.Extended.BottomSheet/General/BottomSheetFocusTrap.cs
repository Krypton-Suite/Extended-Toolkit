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
/// Traps keyboard focus inside an open bottom sheet.
/// </summary>
internal sealed class BottomSheetFocusTrap : IMessageFilter, IDisposable
{
    private const int WmKeyDown = 0x0100;
    private readonly Form _host;
    private readonly Control _container;

    public BottomSheetFocusTrap(Form host, Control container)
    {
        _host = host;
        _container = container;
        Application.AddMessageFilter(this);
    }

    public void Dispose() => Application.RemoveMessageFilter(this);

    public bool PreFilterMessage(ref Message m)
    {
        if (m.Msg != WmKeyDown || !_host.Visible || _host.IsDisposed)
        {
            return false;
        }

        Keys key = (Keys)(int)m.WParam | Control.ModifierKeys;
        if (key != Keys.Tab && key != (Keys.Tab | Keys.Shift))
        {
            return false;
        }

        if (!ContainsFocus(_host))
        {
            return false;
        }

        bool backward = (key & Keys.Shift) == Keys.Shift;
        Control? current = _host.ActiveControl ?? _container;
        Control? next = _container.GetNextControl(current, forward: !backward);
        if (next == null || !next.CanSelect)
        {
            next = backward
                ? FindLastTabbable(_container)
                : BottomSheetFocusResolver.FindFirstTabbable(_container);
        }

        next?.Focus();
        return next != null;
    }

    private static bool ContainsFocus(Control root)
    {
        Control? focused = Form.ActiveForm?.ActiveControl;
        while (focused != null)
        {
            if (ReferenceEquals(focused, root) || root.Contains(focused))
            {
                return true;
            }

            focused = focused.Parent;
        }

        return false;
    }

    private static Control? FindLastTabbable(Control root)
    {
        Control? last = null;
        Control? current = null;
        while (true)
        {
            current = root.GetNextControl(current, forward: true);
            if (current == null)
            {
                return last;
            }

            if (current.CanSelect && current.TabStop && current.Enabled && current.Visible)
            {
                last = current;
            }
        }
    }
}
