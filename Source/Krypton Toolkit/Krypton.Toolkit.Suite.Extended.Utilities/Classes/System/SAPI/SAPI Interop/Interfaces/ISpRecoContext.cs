#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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