#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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