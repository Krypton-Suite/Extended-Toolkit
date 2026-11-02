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

internal struct FragmentStateInterop
{
    internal TtsEngineAction _action;

    internal int _langId;

    internal int _emphasis;

    internal int _duration;

    internal IntPtr _sayAs;

    internal IntPtr _prosody;

    internal IntPtr _phoneme;

    internal void FragmentStateToPtr(FragmentState state, Collection<IntPtr> memoryBlocks)
    {
        _action = state.Action;
        _langId = state.LangId;
        _emphasis = state.Emphasis;
        _duration = state.Duration;
        if (state.SayAs != null)
        {
            _sayAs = Marshal.AllocCoTaskMem(Marshal.SizeOf((object)state.SayAs));
            memoryBlocks.Add(_sayAs);
            Marshal.StructureToPtr((object)state.SayAs, _sayAs, false);
        }
        else
        {
            _sayAs = IntPtr.Zero;
        }
        if (state.Phoneme != null)
        {
            short[] array = new short[state.Phoneme.Length + 1];
            for (uint num = 0u; num < state.Phoneme.Length; num++)
            {
                array[num] = (short)state.Phoneme[num];
            }
            array[state.Phoneme.Length] = 0;
            int num2 = Marshal.SizeOf((object)array[0]);
            _phoneme = Marshal.AllocCoTaskMem(num2 * array.Length);
            memoryBlocks.Add(_phoneme);
            for (uint num3 = 0u; num3 < array.Length; num3++)
            {
                Marshal.Copy(array, 0, _phoneme, array.Length);
            }
        }
        else
        {
            _phoneme = IntPtr.Zero;
        }
        _prosody = ProsodyInterop.ProsodyToPtr(state.Prosody, memoryBlocks);
    }
}