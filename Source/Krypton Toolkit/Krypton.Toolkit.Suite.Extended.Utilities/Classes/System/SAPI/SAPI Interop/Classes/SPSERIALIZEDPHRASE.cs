#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    internal class SPSERIALIZEDPHRASE
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

        internal uint SMLOffset;

        internal uint SemanticErrorInfoOffset;

        internal SPSERIALIZEDPHRASE()
        {
        }

        internal SPSERIALIZEDPHRASE(SPSERIALIZEDPHRASE_Sapi51 source)
        {
            ulSerializedSize = source.ulSerializedSize;
            cbSize = source.cbSize;
            LangID = source.LangID;
            wHomophoneGroupId = source.wHomophoneGroupId;
            ullGrammarID = source.ullGrammarID;
            ftStartTime = source.ftStartTime;
            ullAudioStreamPosition = source.ullAudioStreamPosition;
            ulAudioSizeBytes = source.ulAudioSizeBytes;
            ulRetainedSizeBytes = source.ulRetainedSizeBytes;
            ulAudioSizeTime = source.ulAudioSizeTime;
            Rule = source.Rule;
            PropertiesOffset = source.PropertiesOffset;
            ElementsOffset = source.ElementsOffset;
            cReplacements = source.cReplacements;
            ReplacementsOffset = source.ReplacementsOffset;
            SREngineID = source.SREngineID;
            ulSREnginePrivateDataSize = source.ulSREnginePrivateDataSize;
            SREnginePrivateDataOffset = source.SREnginePrivateDataOffset;
        }
    }
}