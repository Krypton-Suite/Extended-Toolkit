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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop;

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