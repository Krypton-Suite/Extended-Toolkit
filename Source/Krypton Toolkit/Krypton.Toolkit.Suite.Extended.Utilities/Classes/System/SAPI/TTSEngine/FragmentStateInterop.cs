#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
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
}
