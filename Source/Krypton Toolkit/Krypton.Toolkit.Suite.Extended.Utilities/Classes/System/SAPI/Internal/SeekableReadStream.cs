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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Internal
{
    internal class SeekableReadStream : Stream
    {
        private long _virtualPosition;

        private List<byte> _buffer = new();

        private Stream _baseStream;

        private bool _cacheDataForSeeking = true;

        private bool _canSeek;

        internal bool CacheDataForSeeking
        {
            set => _cacheDataForSeeking = value;
        }

        public override bool CanRead => true;

        public override bool CanSeek
        {
            get
            {
                if (!_canSeek)
                {
                    return _cacheDataForSeeking;
                }
                return true;
            }
        }

        public override bool CanWrite => false;

        public override long Length => _baseStream.Length;

        public override long Position
        {
            get
            {
                if (_canSeek)
                {
                    return _baseStream.Position;
                }
                return _virtualPosition;
            }
            set
            {
                if (_canSeek)
                {
                    _baseStream.Position = value;
                }
                else
                {
                    if (value == _virtualPosition)
                    {
                        return;
                    }
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException("value", SR.Get(SRID.MustBeGreaterThanZero));
                    }
                    if (!_cacheDataForSeeking)
                    {
                        throw new NotSupportedException(SR.Get(SRID.SeekNotSupported));
                    }
                    if (value < _buffer.Count)
                    {
                        _virtualPosition = value;
                        return;
                    }
                    long num = value - _buffer.Count;
                    if (num > int.MaxValue)
                    {
                        throw new NotSupportedException(SR.Get(SRID.SeekNotSupported));
                    }
                    byte[] array = new byte[num];
                    Helpers.BlockingRead(_baseStream, array, 0, (int)num);
                    _buffer.AddRange(array);
                    _virtualPosition = value;
                }
            }
        }

        internal SeekableReadStream(Stream baseStream)
        {
            _canSeek = baseStream.CanSeek;
            _baseStream = baseStream;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_canSeek)
            {
                return _baseStream.Read(buffer, offset, count);
            }
            int num = 0;
            if (_virtualPosition < _buffer.Count)
            {
                int num2 = (int)(_buffer.Count - _virtualPosition);
                if (num2 > count)
                {
                    num2 = count;
                }
                _buffer.CopyTo((int)_virtualPosition, buffer, offset, num2);
                count -= num2;
                _virtualPosition += num2;
                offset += num2;
                num += num2;
                if (!_cacheDataForSeeking && _virtualPosition >= _buffer.Count)
                {
                    _buffer.Clear();
                }
            }
            if (count > 0)
            {
                int num3 = _baseStream.Read(buffer, offset, count);
                num += num3;
                _virtualPosition += num3;
                if (_cacheDataForSeeking)
                {
                    _buffer.Capacity += num3;
                    for (int i = 0; i < num3; i++)
                    {
                        _buffer.Add(buffer[offset + i]);
                    }
                }
            }
            return num;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            checked
            {
                long num;
                switch (origin)
                {
                    case SeekOrigin.Begin:
                        num = offset;
                        break;
                    case SeekOrigin.Current:
                        num = Position + offset;
                        break;
                    case SeekOrigin.End:
                        num = Length + offset;
                        break;
                    default:
                        throw new ArgumentException(SR.Get(SRID.EnumInvalid, "SeekOrigin"), "origin");
                }
                Position = num;
                return num;
            }
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException(SR.Get(SRID.SeekNotSupported));
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException(SR.Get(SRID.StreamMustBeWriteable));
        }

        public override void Flush()
        {
            _baseStream.Flush();
        }
    }
}