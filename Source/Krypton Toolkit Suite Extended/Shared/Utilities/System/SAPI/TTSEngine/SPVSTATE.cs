using System;
using System.Runtime.InteropServices;

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
