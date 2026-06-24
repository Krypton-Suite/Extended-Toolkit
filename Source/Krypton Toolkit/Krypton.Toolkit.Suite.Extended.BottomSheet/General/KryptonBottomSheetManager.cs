#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Opens and manages Material-inspired bottom sheets.
/// </summary>
public static class KryptonBottomSheetManager
{
    private static BottomSheetSession? _activeSession;
    private static readonly BottomSheetQueue _queue = new();

    /// <summary>
    /// Gets the currently open bottom sheet reference, if any.
    /// </summary>
    public static KryptonBottomSheetRef? ActiveSheet => _activeSession?.Ref;

    /// <summary>
    /// Gets the number of bottom sheets waiting to open.
    /// </summary>
    public static int QueuedCount => _queue.Count;

    /// <summary>
    /// Opens a bottom sheet that hosts a new instance of <typeparamref name="TContent"/>.
    /// </summary>
    public static KryptonBottomSheetRef Open<TContent>(
        IWin32Window owner,
        KryptonBottomSheetConfig? config = null,
        Action<KryptonBottomSheetRef>? configure = null)
        where TContent : Control, new() =>
        Open(owner, new TContent(), config, configure);

    /// <summary>
    /// Opens a bottom sheet that hosts a new instance of <typeparamref name="TContent"/> with typed data.
    /// </summary>
    public static KryptonBottomSheetRef Open<TContent, TData>(
        IWin32Window owner,
        TData data,
        KryptonBottomSheetConfig? config = null,
        Action<KryptonBottomSheetRef>? configure = null)
        where TContent : Control, new()
    {
        KryptonBottomSheetConfig resolved = KryptonBottomSheetDefaultOptions.Resolve(config);
        resolved.Data = data;
        return Open<TContent>(owner, resolved, configure);
    }

    /// <summary>
    /// Opens a bottom sheet that hosts the supplied content control.
    /// </summary>
    public static KryptonBottomSheetRef Open(
        IWin32Window owner,
        Control content,
        KryptonBottomSheetConfig? config = null,
        Action<KryptonBottomSheetRef>? configure = null)
    {
        if (owner is null)
        {
            throw new ArgumentNullException(nameof(owner));
        }

        if (content is null)
        {
            throw new ArgumentNullException(nameof(content));
        }

        return Present(owner, BottomSheetSession.Create(owner, content, ResolveConfig(config)), configure);
    }

    /// <summary>
    /// Opens a bottom sheet using a factory that receives the active sheet reference.
    /// </summary>
    public static KryptonBottomSheetRef Open(
        IWin32Window owner,
        Func<KryptonBottomSheetRef, Control> contentFactory,
        KryptonBottomSheetConfig? config = null,
        Action<KryptonBottomSheetRef>? configure = null)
    {
        if (owner is null)
        {
            throw new ArgumentNullException(nameof(owner));
        }

        if (contentFactory is null)
        {
            throw new ArgumentNullException(nameof(contentFactory));
        }

        return Present(owner, BottomSheetSession.Create(owner, contentFactory, ResolveConfig(config)), configure);
    }

    /// <summary>
    /// Opens a bottom sheet without blocking the owner message loop.
    /// </summary>
    public static KryptonBottomSheetRef OpenNonModal(
        IWin32Window owner,
        Control content,
        KryptonBottomSheetConfig? config = null,
        Action<KryptonBottomSheetRef>? configure = null)
    {
        KryptonBottomSheetConfig resolved = ResolveConfig(config);
        resolved.DisplayMode = BottomSheetDisplayMode.NonModal;
        return Open(owner, content, resolved, configure);
    }

    /// <summary>
    /// Opens a bottom sheet without blocking the caller and returns a task that completes when it is dismissed.
    /// </summary>
    public static Task<object?> OpenAsync(
        IWin32Window owner,
        Control content,
        KryptonBottomSheetConfig? config = null,
        Action<KryptonBottomSheetRef>? configure = null)
    {
        if (owner is null)
        {
            throw new ArgumentNullException(nameof(owner));
        }

        if (content is null)
        {
            throw new ArgumentNullException(nameof(content));
        }

        KryptonBottomSheetConfig resolved = ResolveConfig(config);
        resolved.DisplayMode = BottomSheetDisplayMode.NonModal;
        resolved.DisableOwnerWhileOpen = true;

        TaskCompletionSource<object?> completion = new(TaskCreationOptions.RunContinuationsAsynchronously);
        BottomSheetSession session = BottomSheetSession.Create(owner, content, resolved);

        Action<KryptonBottomSheetRef> combined = sheetRef =>
        {
            configure?.Invoke(sheetRef);
            sheetRef.AfterDismissed += (_, args) => completion.TrySetResult(args.Result);
        };

        if (TryQueueSession(owner, session, combined))
        {
            return completion.Task;
        }

        PresentNonBlocking(owner, session, combined);
        return completion.Task;
    }

    /// <summary>
    /// Dismisses the currently active bottom sheet, if any.
    /// </summary>
    public static void DismissActive(object? result = null) =>
        _activeSession?.Ref.Dismiss(result);

    private static KryptonBottomSheetRef Present(
        IWin32Window owner,
        BottomSheetSession session,
        Action<KryptonBottomSheetRef>? configure)
    {
        if (TryQueueSession(owner, session, configure))
        {
            return session.Ref;
        }

        PrepareActiveSession(session);
        return PresentInternal(owner, session, configure, modal: session.Config.DisplayMode == BottomSheetDisplayMode.Modal);
    }

    private static bool TryQueueSession(
        IWin32Window owner,
        BottomSheetSession session,
        Action<KryptonBottomSheetRef>? configure)
    {
        if (_activeSession == null || _activeSession.Ref.IsDismissed)
        {
            return false;
        }

        if (session.Config.GetEffectiveConflictMode() != BottomSheetConflictMode.Queue)
        {
            return false;
        }

        _queue.Enqueue(new BottomSheetQueue.QueuedSession(owner, session, configure));
        return true;
    }

    private static void PrepareActiveSession(BottomSheetSession session)
    {
        if (_activeSession == null || _activeSession.Ref.IsDismissed)
        {
            _activeSession = session;
            return;
        }

        switch (session.Config.GetEffectiveConflictMode())
        {
            case BottomSheetConflictMode.Replace:
                DismissActiveSessionAnimated();
                _activeSession = session;
                break;
            case BottomSheetConflictMode.Throw:
                throw new InvalidOperationException("Only one bottom sheet can be open at a time.");
            default:
                _activeSession = session;
                break;
        }
    }

    private static void DismissActiveSessionAnimated()
    {
        if (_activeSession == null)
        {
            return;
        }

        BottomSheetSession previous = _activeSession;
        _activeSession = null;
        previous.Host.AnimateDismissAndWait(null);
    }

    private static KryptonBottomSheetRef PresentInternal(
        IWin32Window owner,
        BottomSheetSession session,
        Action<KryptonBottomSheetRef>? configure,
        bool modal)
    {
        _activeSession = session;
        configure?.Invoke(session.Ref);
        WireSessionClosed(session);

        session.OwnerState = new BottomSheetOwnerState(owner, ShouldDisableOwner(session.Config, modal));
        session.Host.FormClosed += (_, _) => session.OwnerState.Dispose();

        if (modal)
        {
            session.Host.ShowDialog(owner);
        }
        else
        {
            Form? ownerForm = owner as Form ?? Form.ActiveForm;
            session.Host.Show(ownerForm);
        }

        return session.Ref;
    }

    private static void PresentNonBlocking(
        IWin32Window owner,
        BottomSheetSession session,
        Action<KryptonBottomSheetRef>? configure)
    {
        PrepareActiveSession(session);
        PresentInternal(owner, session, configure, modal: false);
    }

    private static void WireSessionClosed(BottomSheetSession session)
    {
        session.Host.FormClosed += (_, _) =>
        {
            if (ReferenceEquals(_activeSession, session))
            {
                _activeSession = null;
            }

            session.Dispose();
            TryPresentQueuedSession();
        };
    }

    private static void TryPresentQueuedSession()
    {
        if (_activeSession != null || !_queue.TryDequeue(out BottomSheetQueue.QueuedSession? queued) || queued == null)
        {
            return;
        }

        PresentInternal(queued.Owner, queued.Session, queued.Configure, modal: queued.Session.Config.DisplayMode == BottomSheetDisplayMode.Modal);
    }

    private static bool ShouldDisableOwner(KryptonBottomSheetConfig config, bool modal) =>
        config.DisableOwnerWhileOpen && modal;

    private static KryptonBottomSheetConfig ResolveConfig(KryptonBottomSheetConfig? config) =>
        KryptonBottomSheetDefaultOptions.Resolve(config);
}
