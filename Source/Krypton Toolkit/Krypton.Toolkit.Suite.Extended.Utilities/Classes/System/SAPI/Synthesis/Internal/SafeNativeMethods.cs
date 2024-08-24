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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal static class SafeNativeMethods
    {
        internal delegate void WaveOutProc(IntPtr hwo, MM_MSG uMsg, IntPtr dwInstance, IntPtr dwParam1, IntPtr dwParam2);

        internal struct WAVEOUTCAPS
        {
            private ushort wMid;

            private ushort wPid;

            private uint vDriverVersion;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            internal string szPname;

            private uint dwFormats;

            private ushort wChannels;

            private ushort wReserved1;

            private ushort dwSupport;
        }

        internal const uint TIME_MS = 1u;

        internal const uint TIME_SAMPLES = 2u;

        internal const uint TIME_BYTES = 4u;

        internal const uint TIME_TICKS = 32u;

        internal const uint CALLBACK_WINDOW = 65536u;

        internal const uint CALLBACK_NULL = 0u;

        internal const uint CALLBACK_FUNCTION = 196608u;

        [DllImport("winmm.dll")]
        internal static extern MMSYSERR waveOutPrepareHeader(IntPtr hwo, IntPtr pwh, int cbwh);

        [DllImport("winmm.dll")]
        internal static extern MMSYSERR waveOutWrite(IntPtr hwo, IntPtr pwh, int cbwh);

        [DllImport("winmm.dll")]
        internal static extern MMSYSERR waveOutUnprepareHeader(IntPtr hwo, IntPtr pwh, int cbwh);

        [DllImport("winmm.dll")]
        internal static extern MMSYSERR waveOutOpen(ref IntPtr phwo, int uDeviceID, byte[] pwfx, WaveOutProc dwCallback, IntPtr dwInstance, uint fdwOpen);

        [DllImport("winmm.dll")]
        internal static extern MMSYSERR waveOutClose(IntPtr hwo);

        [DllImport("winmm.dll")]
        internal static extern MMSYSERR waveOutReset(IntPtr hwo);

        [DllImport("winmm.dll")]
        internal static extern MMSYSERR waveOutPause(IntPtr hwo);

        [DllImport("winmm.dll")]
        internal static extern MMSYSERR waveOutRestart(IntPtr hwo);

        [DllImport("winmm.dll")]
        internal static extern MMSYSERR waveOutGetDevCaps(IntPtr uDeviceID, ref WAVEOUTCAPS caps, int cbwoc);

        [DllImport("winmm.dll")]
        internal static extern int waveOutGetNumDevs();
    }
}