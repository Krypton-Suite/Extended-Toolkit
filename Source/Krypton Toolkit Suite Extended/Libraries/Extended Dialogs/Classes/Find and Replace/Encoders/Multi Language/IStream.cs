#region License
/*
 * MIT License
 *
 * Copyright (c) 2017 ENTech Solutions
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
*/
#endregion

#pragma warning disable 0108

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    [ComImport, Guid("0000000C-0000-0000-C000-000000000046"), InterfaceType((short)1)]
    public interface IStream : ISequentialStream
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RemoteRead(IntPtr pv, uint cb, ref uint pcbRead);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RemoteWrite([In] ref byte pv, [In] uint cb, ref uint pcbWritten);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RemoteSeek([In] _LARGE_INTEGER dlibMove, [In] uint dwOrigin, IntPtr plibNewPosition);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetSize([In] _ULARGE_INTEGER libNewSize);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RemoteCopyTo([In, MarshalAs(UnmanagedType.Interface)] IStream pstm, [In] _ULARGE_INTEGER cb, out _ULARGE_INTEGER pcbRead, out _ULARGE_INTEGER pcbWritten);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Commit([In] uint grfCommitFlags);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Revert();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void LockRegion([In] _ULARGE_INTEGER libOffset, [In] _ULARGE_INTEGER cb, [In] uint dwLockType);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnlockRegion([In] _ULARGE_INTEGER libOffset, [In] _ULARGE_INTEGER cb, [In] uint dwLockType);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Stat(out tagSTATSTG pstatstg, [In] uint grfStatFlag);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Clone([MarshalAs(UnmanagedType.Interface)] out IStream ppstm);
    }
}

#pragma warning restore 0108