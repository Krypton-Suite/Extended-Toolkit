using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    internal class SPSERIALIZEDPHRASERULE
    {
        internal uint pszNameOffset;

        internal uint ulId;

        internal uint ulFirstElement;

        internal uint ulCountOfElements;

        internal uint NextSiblingOffset;

        internal uint FirstChildOffset;

        internal float SREngineConfidence;

        internal sbyte Confidence;
    }
}