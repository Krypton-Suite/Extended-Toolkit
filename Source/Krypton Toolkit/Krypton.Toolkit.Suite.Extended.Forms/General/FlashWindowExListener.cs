namespace Krypton.Toolkit.Suite.Extended.Forms
{
    /// <summary>
    /// https://stackoverflow.com/questions/25681443/how-to-detect-if-window-is-flashing
    /// </summary>
    internal static class FlashWindowExListener
    {
        private static readonly Dictionary<IntPtr, Form> _forms = new Dictionary<IntPtr, Form>();
        private static readonly IntPtr _hHook;
        // Keep the HookProc delegate alive manually, such as using a class member as shown below,
        // otherwise the garbage collector will clean up the hook delegate eventually,
        // resulting in the code throwing a System.NullReferenceException.
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private static readonly PlatformInvoke.HookProc _hookProc;

        /// <summary>
        /// Make sure there is something to call first
        /// </summary>
        public static event FlashWindowExEventHandler FlashEvent = delegate { };

        /// <summary>
        /// the callback that is expected to be used
        /// </summary>
        /// <param name="f"></param>
        /// <param name="isFlashing"></param>
        public delegate void FlashWindowExEventHandler(Form f, bool isFlashing);

        static FlashWindowExListener()
        {
            var processId = PlatformInvoke.GetCurrentThreadId();
            // create an instance of the delegate that
            // won't be garbage collected to avoid:
            //   Managed Debugging Assistant 'CallbackOnCollectedDelegate' :** 
            //   'A callback was made on a garbage collected delegate of type 
            //   'WpfApp1!WpfApp1.MainWindow+NativeMethods+CBTProc::Invoke'. 
            //   This may cause application crashes, corruption and data loss. 
            //   When passing delegates to unmanaged code, they must be 
            //   kept alive by the managed application until it is guaranteed 
            //   that they will never be called.'
            _hookProc = ShellProc;

            // we are interested in listening to WH_SHELL events, mainly the HSHELL_REDRAW event.
            _hHook = PlatformInvoke.SetWindowsHookEx(PlatformInvoke.WH_.SHELL, _hookProc, IntPtr.Zero, processId);

            Application.ApplicationExit += delegate { PlatformInvoke.UnhookWindowsHookEx(_hHook); };
        }

        internal static void Register(Form f)
        {
            if (f.IsDisposed)
            {
                throw new ArgumentException("Cannot use disposed form.");
            }

            void OnHandleKnown()
            {
                // hold the handle here to unregister it without depending on the form
                var handle = f.Handle;
                _forms[handle] = f;
                f.Closing += delegate { Unregister(handle); };
            }

            if (f.Handle == IntPtr.Zero)
            {
                f.HandleCreated += delegate { OnHandleKnown(); };
            }
            else
            {
                OnHandleKnown();
            }
        }

        internal static void Unregister(IntPtr handle)
        {
            // We can't use 'null', since the type of the object is 'IntPtr'. So we need to use 'IntPtr.Zero'.
            if (handle != IntPtr.Zero)
            {
                _forms.Remove(handle);
            }
        }

        internal static void Unregister(Form f)
        {
            // This will crash if f has been disposed
            // We can't use 'null', since the type of the object is 'IntPtr'. So we need to use 'IntPtr.Zero'.
            if (f.Handle != IntPtr.Zero)
            {
                _forms.Remove(f.Handle);
            }
        }

        private static IntPtr ShellProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code == PlatformInvoke.HSHELL_REDRAW)
            {
                try
                {
                    if (_forms.TryGetValue(wParam, out Form f))
                    {
                        FlashEvent(f, (int)lParam == 1);
                    }
                }
                catch
                {
                    //
                }
            }

            return PlatformInvoke.CallNextHookEx(_hHook, code, wParam, lParam);
        }
    }
}