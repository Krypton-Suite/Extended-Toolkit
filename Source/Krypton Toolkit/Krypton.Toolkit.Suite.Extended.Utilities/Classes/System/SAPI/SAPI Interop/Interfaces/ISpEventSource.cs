#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("BE7A9CCE-5F9E-11D2-960F-00C04F8EE628"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpEventSource : ISpNotifySource
    {
        new void SetNotifySink(ISpNotifySink pNotifySink);

        new void SetNotifyWindowMessage(uint hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        new void Slot3();

        new void Slot4();

        new void Slot5();

        [PreserveSig]
        new int WaitForNotifyEvent(uint dwMilliseconds);

        new void Slot7();

        void SetInterest(ulong ullEventInterest, ulong ullQueuedInterest);

        void GetEvents(uint ulCount, out SPEVENT pEventArray, out uint pulFetched);

        void Slot10();
    }
}