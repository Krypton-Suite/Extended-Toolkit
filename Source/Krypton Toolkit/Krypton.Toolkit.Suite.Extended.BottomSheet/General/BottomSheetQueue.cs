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
/// Queues bottom sheet open requests until the active sheet is dismissed.
/// </summary>
internal sealed class BottomSheetQueue
{
    private readonly Queue<QueuedSession> _pending = new();

    public void Enqueue(QueuedSession request) => _pending.Enqueue(request);

    public bool TryDequeue(out QueuedSession? request)
    {
        if (_pending.Count == 0)
        {
            request = null;
            return false;
        }

        request = _pending.Dequeue();
        return true;
    }

    public int Count => _pending.Count;

    internal sealed class QueuedSession
    {
        public QueuedSession(
            IWin32Window owner,
            BottomSheetSession session,
            Action<KryptonBottomSheetRef>? configure)
        {
            Owner = owner;
            Session = session;
            Configure = configure;
        }

        public IWin32Window Owner { get; }

        public BottomSheetSession Session { get; }

        public Action<KryptonBottomSheetRef>? Configure { get; }
    }
}
