using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
    [ComImport]
    [Guid("2D0FA0DB-AEA2-4AE2-9F8A-7AFC7794E56B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ITtsEngineSsml
    {
        void GetOutputFormat(SpeakOutputFormat speakOutputFormat, IntPtr targetWaveFormat, out IntPtr waveHeader);

        void AddLexicon(string location, string mediaType, IntPtr site);

        void RemoveLexicon(string location, IntPtr site);

        void Speak(IntPtr fragments, int count, IntPtr waveHeader, IntPtr site);
    }
}
