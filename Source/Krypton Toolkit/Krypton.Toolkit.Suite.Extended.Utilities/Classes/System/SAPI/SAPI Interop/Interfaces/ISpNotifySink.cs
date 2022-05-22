#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("259684DC-37C3-11D2-9603-00C04F8EE628"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpNotifySink
    {
        void Notify();
    }
}