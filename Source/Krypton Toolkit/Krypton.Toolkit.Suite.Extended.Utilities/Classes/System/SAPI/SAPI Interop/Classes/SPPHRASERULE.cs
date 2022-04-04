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
    internal class SPPHRASERULE
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        internal string pszName;

        internal uint ulId;

        internal uint ulFirstElement;

        internal uint ulCountOfElements;

        internal IntPtr pNextSibling;

        internal IntPtr pFirstChild;

        internal float SREngineConfidence;

        internal byte Confidence;
    }
}