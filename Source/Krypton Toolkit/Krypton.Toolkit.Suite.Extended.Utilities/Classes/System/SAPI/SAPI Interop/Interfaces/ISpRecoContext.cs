#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("F740A62F-7C15-489E-8234-940A33D9272D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpRecoContext : ISpEventSource, ISpNotifySource
    {
        new void SetNotifySink(ISpNotifySink pNotifySink);

        new void SetNotifyWindowMessage(uint hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        new void Slot3();

        new void Slot4();

        new void Slot5();

        [PreserveSig]
        new int WaitForNotifyEvent(uint dwMilliseconds);

        new void Slot7();

        new void SetInterest(ulong ullEventInterest, ulong ullQueuedInterest);

        new void GetEvents(uint ulCount, out SPEVENT pEventArray, out uint pulFetched);

        new void Slot10();

        void GetRecognizer(out ISpRecognizer ppRecognizer);

        void CreateGrammar(ulong ullGrammarID, out ISpRecoGrammar ppGrammar);

        void GetStatus(out SPRECOCONTEXTSTATUS pStatus);

        void GetMaxAlternates(out uint pcAlternates);

        void SetMaxAlternates(uint cAlternates);

        void SetAudioOptions(SPAUDIOOPTIONS Options, IntPtr pAudioFormatId, IntPtr pWaveFormatEx);

        void Slot17();

        void Slot18();

        void Bookmark(SPBOOKMARKOPTIONS Options, ulong ullStreamPosition, IntPtr lparamEvent);

        void Slot20();

        void Pause(uint dwReserved);

        void Resume(uint dwReserved);

        void Slot23();

        void Slot24();

        void Slot25();

        void Slot26();

        void SetContextState(SPCONTEXTSTATE eContextState);

        void Slot28();
    }
}