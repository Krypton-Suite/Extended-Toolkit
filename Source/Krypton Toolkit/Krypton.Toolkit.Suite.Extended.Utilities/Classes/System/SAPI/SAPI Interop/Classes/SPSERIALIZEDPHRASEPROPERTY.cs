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
    internal class SPSERIALIZEDPHRASEPROPERTY
    {
        internal uint pszNameOffset;

        internal uint ulId;

        internal uint pszValueOffset;

        internal ushort vValue;

        internal ulong SpVariantSubset;

        internal uint ulFirstElement;

        internal uint ulCountOfElements;

        internal uint pNextSiblingOffset;

        internal uint pFirstChildOffset;

        internal float SREngineConfidence;

        internal sbyte Confidence;
    }
}