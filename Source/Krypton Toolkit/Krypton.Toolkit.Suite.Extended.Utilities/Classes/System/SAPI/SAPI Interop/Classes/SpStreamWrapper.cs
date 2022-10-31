#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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