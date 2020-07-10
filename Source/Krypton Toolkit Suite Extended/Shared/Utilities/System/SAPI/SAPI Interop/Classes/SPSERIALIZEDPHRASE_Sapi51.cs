using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [StructLayout(LayoutKind.Sequential)]
    internal class SPSERIALIZEDPHRASE_Sapi51
    {
        internal uint ulSerializedSize;

        internal uint cbSize;

        internal ushort LangID;

        internal ushort wHomophoneGroupId;

        internal ulong ullGrammarID;

        internal ulong ftStartTime;

        internal ulong ullAudioStreamPosition;

        internal uint ulAudioSizeBytes;

        internal uint ulRetainedSizeBytes;

        internal uint ulAudioSizeTime;

        internal SPSERIALIZEDPHRASERULE Rule;

        internal uint PropertiesOffset;

        internal uint ElementsOffset;

        internal uint cReplacements;

        internal uint ReplacementsOffset;

        internal Guid SREngineID;

        internal uint ulSREnginePrivateDataSize;

        internal uint SREnginePrivateDataOffset;
    }
}