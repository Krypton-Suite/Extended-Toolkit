#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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
    [ComImport, Guid("88A3342A-0BED-4834-922B-88D43173162F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpPhraseBuilder : ISpPhrase
    {
        new void GetPhrase(out IntPtr ppCoMemPhrase);

        new void GetSerializedPhrase(out IntPtr ppCoMemPhrase);

        new void GetText(uint ulStart, uint ulCount, [MarshalAs(UnmanagedType.Bool)] bool fUseTextReplacements, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCoMemText, out byte pbDisplayAttributes);

        new void Discard(uint dwValueTypes);

        void InitFromPhrase(SPPHRASE pPhrase);

        void Slot6();

        void Slot7();

        void Slot8();

        void Slot9();

        void Slot10();
    }
}
