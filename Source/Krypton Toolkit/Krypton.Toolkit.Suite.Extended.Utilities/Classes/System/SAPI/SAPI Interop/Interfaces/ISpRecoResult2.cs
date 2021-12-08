#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("27CAC6C4-88F2-41f2-8817-0C95E59F1E6E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpRecoResult2 : ISpRecoResult, ISpPhrase
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

        void CommitAlternate(ISpPhraseAlt pPhraseAlt, out ISpRecoResult ppNewResult);

        void CommitText(uint ulStartElement, uint ulCountOfElements, [MarshalAs(UnmanagedType.LPWStr)] string pszCorrectedData, SPCOMMITFLAGS commitFlags);

        void SetTextFeedback([MarshalAs(UnmanagedType.LPWStr)] string pszFeedback, [MarshalAs(UnmanagedType.Bool)] bool fSuccessful);
    }
}