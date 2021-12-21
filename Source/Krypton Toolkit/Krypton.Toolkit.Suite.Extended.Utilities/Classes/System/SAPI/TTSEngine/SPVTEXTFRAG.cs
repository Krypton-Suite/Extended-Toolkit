#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
    [StructLayout(LayoutKind.Sequential)]
    internal class SPVTEXTFRAG
    {
        public IntPtr pNext;

        public SPVSTATE State;

        public IntPtr pTextStart;

        public int ulTextLen;

        public int ulTextSrcOffset;

        public GCHandle gcText;

        public GCHandle gcNext;

        public GCHandle gcPhoneme;

        public GCHandle gcSayAsCategory;
    }
}
