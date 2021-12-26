#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("06B64F9E-7FDA-11D2-B4F2-00C04F797396"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IEnumSpObjectTokens
    {
        void Slot1();

        void Slot2();

        void Slot3();

        void Slot4();

        void Item(uint Index, out ISpObjectToken ppToken);

        void GetCount(out uint pCount);
    }
}