#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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