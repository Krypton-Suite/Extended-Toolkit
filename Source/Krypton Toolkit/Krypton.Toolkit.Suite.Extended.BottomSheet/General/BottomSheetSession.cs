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
