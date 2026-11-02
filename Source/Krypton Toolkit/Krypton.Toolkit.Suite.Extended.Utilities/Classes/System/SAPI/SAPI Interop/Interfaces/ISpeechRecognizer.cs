#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

[ComImport, Guid("2D5F1C0C-BD75-4b08-9478-3B11FEA2586C"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
internal interface ISpeechRecognizer
{
    object Slot1
    {
        get;
        set;
    }

    object Slot2
    {
        get;
        set;
    }

    object Slot3
    {
        get;
        set;
    }

    object Slot4
    {
        get;
        set;
    }

    object Slot5
    {
        get;
    }

    object Slot6
    {
        get;
        set;
    }

    object Slot7
    {
        get;
        set;
    }

    object Slot8
    {
        get;
    }

    [PreserveSig, DispId(9)]
    int EmulateRecognition(object TextElements, ref object ElementDisplayAttributes, int LanguageId);

    void Slot10();

    void Slot11();

    void Slot12();

    void Slot13();

    void Slot14();

    void Slot15();

    void Slot16();

    void Slot17();

    void Slot18();

    void Slot19();

    void Slot20();
}