#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("20B053BE-E235-43cd-9A2A-8D17A48B7842"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpRecoResult : ISpPhrase
    {
        new void GetPhrase(out IntPtr ppCoMemPhrase);

        new void GetSerializedPhrase(out IntPtr ppCoMemPhrase);

        new void GetText(uint ulStart, uint ulCount, [MarshalAs(UnmanagedType.Bool)] bool fUseTextReplacements, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemText, out byte pbDisplayAttributes);

        new void Discard(uint dwValueTypes);

        void Slot5();

        void GetAlternates(int ulStartElement, int cElements, int ulRequestCount, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] ppPhrases, out int pcPhrasesReturned);

        void GetAudio(uint ulStartElement, uint cElements, out ISpStreamFormat ppStream);

        void Slot8();

        void Serialize(out IntPtr ppCoMemSerializedResult);

        void Slot10();

        void Slot11();
    }
}