#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [StructLayout(LayoutKind.Sequential)]
    internal class SPSERIALIZEDPHRASEELEMENT
    {
        internal uint ulAudioTimeOffset;

        internal uint ulAudioSizeTime;

        internal uint ulAudioStreamOffset;

        internal uint ulAudioSizeBytes;

        internal uint ulRetainedStreamOffset;

        internal uint ulRetainedSizeBytes;

        internal uint pszDisplayTextOffset;

        internal uint pszLexicalFormOffset;

        internal uint pszPronunciationOffset;

        internal byte bDisplayAttributes;

        internal char RequiredConfidence;

        internal char ActualConfidence;

        internal byte Reserved;

        internal float SREngineConfidence;
    }
}