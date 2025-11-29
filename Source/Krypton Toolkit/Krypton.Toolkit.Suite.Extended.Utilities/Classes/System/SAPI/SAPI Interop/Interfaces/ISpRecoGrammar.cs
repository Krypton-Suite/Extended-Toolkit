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

[ComImport, Guid("2177DB29-7F45-47D0-8554-067E91C80502"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface ISpRecoGrammar : ISpGrammarBuilder
{
    new void Slot1();

    new void Slot2();

    new void Slot3();

    new void Slot4();

    new void Slot5();

    new void Slot6();

    new void Slot7();

    new void Slot8();

    void Slot9();

    void Slot10();

    void LoadCmdFromFile([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, SPLOADOPTIONS Options);

    void Slot12();

    void Slot13();

    void LoadCmdFromMemory(IntPtr pGrammar, SPLOADOPTIONS Options);

    void Slot15();

    [PreserveSig]
    int SetRuleState([MarshalAs(UnmanagedType.LPWStr)] string pszName, IntPtr pReserved, SPRULESTATE NewState);

    void Slot17();

    void LoadDictation([MarshalAs(UnmanagedType.LPWStr)] string pszTopicName, SPLOADOPTIONS Options);

    void Slot19();

    [PreserveSig]
    int SetDictationState(SPRULESTATE NewState);

    void SetWordSequenceData([MarshalAs(UnmanagedType.LPWStr)] string pText, uint cchText, ref SPTEXTSELECTIONINFO pInfo);

    void SetTextSelection(ref SPTEXTSELECTIONINFO pInfo);

    void Slot23();

    void SetGrammarState(SPGRAMMARSTATE eGrammarState);

    void Slot25();

    void Slot26();
}