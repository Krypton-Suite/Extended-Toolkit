#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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
