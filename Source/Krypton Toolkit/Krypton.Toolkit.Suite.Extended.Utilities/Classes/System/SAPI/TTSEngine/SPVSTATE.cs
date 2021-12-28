#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
    [ComConversionLoss]
    [TypeLibType(16)]
    internal struct SPVSTATE
    {
        public SPVACTIONS eAction;

        public short LangID;

        public short wReserved;

        public int EmphAdj;

        public int RateAdj;

        public int Volume;

        public SPVPITCH PitchAdj;

        public int SilenceMSecs;

        public IntPtr pPhoneIds;

        public SPPARTOFSPEECH ePartOfSpeech;

        public SPVCONTEXT Context;
    }
}
