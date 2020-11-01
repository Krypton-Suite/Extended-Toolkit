using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("5EFF4AEF-8487-11D2-961C-00C04F8EE628"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpNotifySource
    {
        void SetNotifySink(ISpNotifySink pNotifySink);

        void SetNotifyWindowMessage(uint hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        void Slot3();

        void Slot4();

        void Slot5();

        [PreserveSig]
        int WaitForNotifyEvent(uint dwMilliseconds);

        void Slot7();
    }
}