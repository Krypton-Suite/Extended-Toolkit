#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Coordinates creation and lifetime of a single bottom sheet presentation.
/// </summary>
internal sealed class BottomSheetSession : IDisposable
{
    private bool _disposed;

    private BottomSheetSession(
        KryptonBottomSheetHostForm host,
        KryptonBottomSheetRef sheetRef,
        Control content,
        KryptonBottomSheetConfig config)
    {
        Host = host;
        Ref = sheetRef;
        Content = content;
        Config = config;
    }

    public KryptonBottomSheetHostForm Host { get; }

    public KryptonBottomSheetRef Ref { get; }

    public Control Content { get; }

    public KryptonBottomSheetConfig Config { get; }

    public BottomSheetOwnerState? OwnerState { get; set; }

    public static BottomSheetSession Create(
        IWin32Window owner,
        Control content,
        KryptonBottomSheetConfig config)
    {
        KryptonBottomSheetHostForm host = null!;
        KryptonBottomSheetRef sheetRef = new(content, result => host.RequestDismiss(result));
        host = new KryptonBottomSheetHostForm(owner, content, config, sheetRef);
        NotifyContentOpened(content, sheetRef, config);
        return new BottomSheetSession(host, sheetRef, content, config);
    }

    public static BottomSheetSession Create(
        IWin32Window owner,
        Func<KryptonBottomSheetRef, Control> contentFactory,
        KryptonBottomSheetConfig config)
    {
        KryptonBottomSheetHostForm host = null!;
        KryptonBottomSheetRef sheetRef = new(new Panel(), result => host.RequestDismiss(result));
        Control content = contentFactory(sheetRef);
        sheetRef.SetInstance(content);
        host = new KryptonBottomSheetHostForm(owner, content, config, sheetRef);
        NotifyContentOpened(content, sheetRef, config);
        return new BottomSheetSession(host, sheetRef, content, config);
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;
        if (!Host.IsDisposed)
        {
            Host.Dispose();
        }

        if (Config.DisposeContentOnDismiss)
        {
            Content.Dispose();
        }
    }

    private static void NotifyContentOpened(Control content, KryptonBottomSheetRef sheetRef, KryptonBottomSheetConfig config)
    {
        if (config.Data != null)
        {
            foreach (Type iface in content.GetType().GetInterfaces())
            {
                if (!iface.IsGenericType
                    || iface.GetGenericTypeDefinition() != typeof(IKryptonBottomSheetContent<>))
                {
                    continue;
                }

                Type dataType = iface.GetGenericArguments()[0];
                if (!dataType.IsInstanceOfType(config.Data))
                {
                    continue;
                }

                iface.GetMethod("OnBottomSheetOpened")
                    ?.Invoke(content, new object?[] { sheetRef, config.Data });
                return;
            }
        }

        if (content is IKryptonBottomSheetContent untyped)
        {
            untyped.OnBottomSheetOpened(sheetRef, config.Data);
        }
    }
}
