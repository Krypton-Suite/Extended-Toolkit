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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine;

internal struct TextFragmentInterop
{
    internal FragmentStateInterop _state;

    [MarshalAs(UnmanagedType.LPWStr)]
    internal string _textToSpeak;

    internal int _textOffset;

    internal int _textLength;

    internal static IntPtr FragmentToPtr(List<TextFragment> textFragments, Collection<IntPtr> memoryBlocks)
    {
        TextFragmentInterop textFragmentInterop = default(TextFragmentInterop);
        int count = textFragments.Count;
        int num = Marshal.SizeOf((object)textFragmentInterop);
        IntPtr intPtr = Marshal.AllocCoTaskMem(num * count);
        memoryBlocks.Add(intPtr);
        for (int i = 0; i < count; i++)
        {
            textFragmentInterop._state.FragmentStateToPtr(textFragments[i].State, memoryBlocks);
            textFragmentInterop._textToSpeak = textFragments[i].TextToSpeak;
            textFragmentInterop._textOffset = textFragments[i].TextOffset;
            textFragmentInterop._textLength = textFragments[i].TextLength;
            Marshal.StructureToPtr((object)textFragmentInterop, (IntPtr)((long)intPtr + i * num), false);
        }
        return intPtr;
    }
}