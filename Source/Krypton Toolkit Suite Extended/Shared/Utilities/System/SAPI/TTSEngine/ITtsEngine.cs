using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
    [ComImport]
    [Guid("A74D7C8E-4CC5-4F2F-A6EB-804DEE18500E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ITtsEngine
    {
        [PreserveSig]
        void Speak(SPEAKFLAGS dwSpeakFlags, ref Guid rguidFormatId, IntPtr pWaveFormatEx, IntPtr pTextFragList, IntPtr pOutputSite);

        [PreserveSig]
        void GetOutputFormat(ref Guid pTargetFmtId, IntPtr pTargetWaveFormatEx, out Guid pOutputFormatId, out IntPtr ppCoMemOutputWaveFormatEx);
    }
}
