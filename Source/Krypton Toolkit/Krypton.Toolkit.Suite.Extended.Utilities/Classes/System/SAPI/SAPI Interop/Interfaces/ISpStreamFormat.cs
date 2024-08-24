#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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
 *
 */
#endregion

using STATSTG = System.Runtime.InteropServices.ComTypes.STATSTG;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("BED530BE-2606-4F4D-A1C0-54C5CDA5566F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpStreamFormat : IStream
    {
        new void Read([Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pv, int cb, IntPtr pcbRead);

        new void Write([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pv, int cb, IntPtr pcbWritten);

        new void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition);

        new void SetSize(long libNewSize);

        new void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten);

        new void Commit(int grfCommitFlags);

        new void Revert();

        new void LockRegion(long libOffset, long cb, int dwLockType);

        new void UnlockRegion(long libOffset, long cb, int dwLockType);

        new void Stat(out STATSTG pstatstg, int grfStatFlag);

        new void Clone(out IStream ppstm);

        void GetFormat(out Guid pguidFormatId, out IntPtr ppCoMemWaveFormatEx);
    }
}