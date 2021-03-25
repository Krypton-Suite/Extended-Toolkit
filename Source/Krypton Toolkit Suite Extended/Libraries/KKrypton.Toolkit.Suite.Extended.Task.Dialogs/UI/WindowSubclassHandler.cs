﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Task.Dialogs.UI
{
    internal class WindowSubclassHandler : IDisposable
    {
        private readonly IntPtr _handle;

        private bool _opened;

        private bool _disposed;

        private IntPtr _originalWindowProc;

        /// <summary>
        /// The delegate for the callback handler (that calls
        /// <see cref="WndProc(int, IntPtr, IntPtr)"/> from which the native function
        /// pointer <see cref="_windowProcDelegatePtr"/> is created. 
        /// </summary>
        /// <remarks>
        /// We must store this delegate (and prevent it from being garbage-collected)
        /// to ensure the function pointer doesn't become invalid.
        /// 
        /// Note: We create a new delegate (and native function pointer) for each
        /// instance because even though creation will be slower (and requires a
        /// bit of memory to store the native code) it will be faster when the window
        /// procedure is invoked, because otherwise we would need to use a dictionary
        /// to map the hWnd to the instance, as the window procedure doesn't allow
        /// to store reference data. However, this is also the way that the
        /// NativeWindow class of WinForms does it.
        /// </remarks>
        private readonly WindowSubclassHandlerNativeMethods.WindowProc _windowProcDelegate;

        /// <summary>
        /// The function pointer created from <see cref="_windowProcDelegate"/>.
        /// </summary>
        private readonly IntPtr _windowProcDelegatePtr;

        public WindowSubclassHandler(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                throw new ArgumentNullException(nameof(handle));

            _handle = handle;

            // Create a delegate for our window procedure, and get a function
            // pointer for it.
            _windowProcDelegate = (hWnd, msg, wParam, lParam) =>
            {
                Debug.Assert(hWnd == _handle);
                return WndProc(msg, wParam, lParam);
            };

            _windowProcDelegatePtr = Marshal.GetFunctionPointerForDelegate(
                    _windowProcDelegate);
        }

        /// <summary>
        /// Subclasses the window.
        /// </summary>
        /// <remarks>
        /// You must call <see cref="Dispose()"/> to undo the subclassing before
        /// the window is destroyed.
        /// </remarks>
        /// <returns></returns>
        public void Open()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(WindowSubclassHandler));
            if (_opened)
                throw new InvalidOperationException();

            // Replace the existing window procedure with our one
            // ("instance subclassing").
            // We need to explicitely clear the last Win32 error and then retrieve
            // it, to check if the call succeeded.
            WindowSubclassHandlerNativeMethods.SetLastError(0);
            _originalWindowProc = WindowSubclassHandlerNativeMethods.SetWindowLongPtr(
                    _handle,
                    WindowSubclassHandlerNativeMethods.GWLP_WNDPROC,
                    _windowProcDelegatePtr);
            if (_originalWindowProc == IntPtr.Zero && Marshal.GetLastWin32Error() != 0)
                throw new Win32Exception();

            Debug.Assert(_originalWindowProc != _windowProcDelegatePtr);

            _opened = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void KeepCallbackDelegateAlive()
        {
            GC.KeepAlive(_windowProcDelegate);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                // We cannot do anything from the finalizer thread since we have
                // resoures that must only be accessed from the GUI thread.
                if (disposing && _opened)
                {
                    // Check if the current window procedure is the correct one.
                    // We need to explicitely clear the last Win32 error and then
                    // retrieve it, to check if the call succeeded.
                    WindowSubclassHandlerNativeMethods.SetLastError(0);
                    IntPtr currentWindowProcedure = WindowSubclassHandlerNativeMethods.GetWindowLongPtr(
                            _handle,
                            WindowSubclassHandlerNativeMethods.GWLP_WNDPROC);
                    if (currentWindowProcedure == IntPtr.Zero && Marshal.GetLastWin32Error() != 0)
                        throw new Win32Exception();

                    if (currentWindowProcedure != _windowProcDelegatePtr)
                        throw new InvalidOperationException(
                                "The current window procedure is not the expected one.");

                    // Undo the subclassing by restoring the original window
                    // procedure.
                    WindowSubclassHandlerNativeMethods.SetLastError(0);
                    if (WindowSubclassHandlerNativeMethods.SetWindowLongPtr(
                            _handle,
                            WindowSubclassHandlerNativeMethods.GWLP_WNDPROC,
                            _originalWindowProc) == IntPtr.Zero &&
                            Marshal.GetLastWin32Error() != 0)
                        throw new Win32Exception();

                    // Ensure to keep the delegate alive up to the point after we
                    // have undone the subclassing.
                    KeepCallbackDelegateAlive();
                }

                _disposed = true;
            }
        }

        protected virtual IntPtr WndProc(
                int msg,
                IntPtr wParam,
                IntPtr lParam)
        {
            // Call the original window procedure to process the message.
            if (_originalWindowProc != IntPtr.Zero)
            {
                return WindowSubclassHandlerNativeMethods.CallWindowProc(
                        _originalWindowProc,
                        _handle,
                        msg,
                        wParam,
                        lParam);
            }

            return IntPtr.Zero;
        }
    }
}