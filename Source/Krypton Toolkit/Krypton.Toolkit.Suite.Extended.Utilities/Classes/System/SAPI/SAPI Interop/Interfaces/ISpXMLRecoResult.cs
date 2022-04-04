#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("AE39362B-45A8-4074-9B9E-CCF49AA2D0B6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpXMLRecoResult : ISpRecoResult, ISpPhrase
    {
        new void GetPhrase(out IntPtr ppCoMemPhrase);

        new void GetSerializedPhrase(out IntPtr ppCoMemPhrase);

        new void GetText(uint ulStart, uint ulCount, [MarshalAs(UnmanagedType.Bool)] bool fUseTextReplacements, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemText, out byte pbDisplayAttributes);

        new void Discard(uint dwValueTypes);

        new void Slot5();

        new void GetAlternates(int ulStartElement, int cElements, int ulRequestCount, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IntPtr[] ppPhrases, out int pcPhrasesReturned);

        new void GetAudio(uint ulStartElement, uint cElements, out ISpStreamFormat ppStream);

        new void Slot8();

        new void Serialize(out IntPtr ppCoMemSerializedResult);

        new void Slot10();

        new void Slot11();

        void GetXMLResult([MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemXMLResult, SPXMLRESULTOPTIONS Options);

        void GetXMLErrorInfo(out SPSEMANTICERRORINFO pSemanticErrorInfo);
    }
}