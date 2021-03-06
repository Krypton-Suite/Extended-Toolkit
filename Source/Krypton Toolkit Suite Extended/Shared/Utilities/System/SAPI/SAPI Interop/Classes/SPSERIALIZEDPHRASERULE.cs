﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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