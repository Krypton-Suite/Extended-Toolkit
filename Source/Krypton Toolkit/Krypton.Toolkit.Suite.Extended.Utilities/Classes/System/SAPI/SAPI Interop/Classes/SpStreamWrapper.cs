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
    internal class SpStreamWrapper : IStream, IDisposable
    {
        private Stream _stream;

        protected long _endOfStreamPosition = -1L;

        internal SpStreamWrapper(Stream stream)
        {
            _stream = stream;
            _endOfStreamPosition = stream.Length;
        }

        public void Dispose()
        {
            _stream.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Read(byte[] pv, int cb, IntPtr pcbRead)
        {
            if (_endOfStreamPosition >= 0 && _stream.Position + cb > _endOfStreamPosition)
            {
                cb = (int)(_endOfStreamPosition - _stream.Position);
            }
            int num = 0;
            try
            {
                num = _stream.Read(pv, 0, cb);
            }
            catch (EndOfStreamException)
            {
                num = 0;
            }
            if (pcbRead != IntPtr.Zero)
            {
                Marshal.WriteIntPtr(pcbRead, new IntPtr(num));
            }
        }

        public void Write(byte[] pv, int cb, IntPtr pcbWritten)
        {
            throw new NotSupportedException();
        }

        public void Seek(long offset, int seekOrigin, IntPtr plibNewPosition)
        {
            _stream.Seek(offset, (SeekOrigin)seekOrigin);
            if (plibNewPosition != IntPtr.Zero)
            {
                Marshal.WriteIntPtr(plibNewPosition, new IntPtr(_stream.Position));
            }
        }

        public void SetSize(long libNewSize)
        {
            throw new NotSupportedException();
        }

        public void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten)
        {
            throw new NotSupportedException();
        }

        public void Commit(int grfCommitFlags)
        {
            _stream.Flush();
        }

        public void Revert()
        {
            throw new NotSupportedException();
        }

        public void LockRegion(long libOffset, long cb, int dwLockType)
        {
            throw new NotSupportedException();
        }

        public void UnlockRegion(long libOffset, long cb, int dwLockType)
        {
            throw new NotSupportedException();
        }

        public void Stat(out STATSTG pstatstg, int grfStatFlag)
        {
            pstatstg = default(STATSTG);
            pstatstg.cbSize = _stream.Length;
        }

        public void Clone(out IStream ppstm)
        {
            throw new NotSupportedException();
        }
    }
}