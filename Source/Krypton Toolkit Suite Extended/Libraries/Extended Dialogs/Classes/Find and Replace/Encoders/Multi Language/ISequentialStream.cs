#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    [ComImport, Guid("0C733A30-2A1C-11CE-ADE5-00AA0044773D"), InterfaceType((short)1)]
    public interface ISequentialStream
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RemoteRead(IntPtr pv, uint cb, ref uint pcbRead);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RemoteWrite([In] ref byte pv, [In] uint cb, ref uint pcbWritten);
    }
}