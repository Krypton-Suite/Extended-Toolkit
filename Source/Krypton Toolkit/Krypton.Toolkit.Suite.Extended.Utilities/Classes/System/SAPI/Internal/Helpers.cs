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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Internal
{
    internal static class Helpers
    {
        internal static readonly char[] _achTrimChars = new char[4]
        {
            ' ',
            '\t',
            '\n',
            '\r'
        };

        internal const int _sizeOfChar = 2;

        internal static void ThrowIfEmptyOrNull(string s, string paramName)
        {
            if (string.IsNullOrEmpty(s))
            {
                if (s == null)
                {
                    throw new ArgumentNullException(paramName);
                }
                throw new ArgumentException(SR.Get(SRID.StringCanNotBeEmpty, paramName), paramName);
            }
        }

        internal static void ThrowIfNull(object value, string paramName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        internal static bool CompareInvariantCulture(CultureInfo culture1, CultureInfo culture2)
        {
            if (culture1.Equals(culture2))
            {
                return true;
            }
            while (!culture1.IsNeutralCulture)
            {
                culture1 = culture1.Parent;
            }
            while (!culture2.IsNeutralCulture)
            {
                culture2 = culture2.Parent;
            }
            return culture1.Equals(culture2);
        }

        internal static void CopyStream(Stream inputStream, Stream outputStream, int bytesToCopy)
        {
            int num = (bytesToCopy > 4096) ? 4096 : bytesToCopy;
            byte[] buffer = new byte[num];
            while (true)
            {
                if (bytesToCopy > 0)
                {
                    int num2 = inputStream.Read(buffer, 0, num);
                    if (num2 <= 0)
                    {
                        break;
                    }
                    outputStream.Write(buffer, 0, num2);
                    bytesToCopy -= num2;
                    continue;
                }
                return;
            }
            throw new EndOfStreamException(SR.Get(SRID.StreamEndedUnexpectedly));
        }

        internal static byte[] ReadStreamToByteArray(Stream inputStream, int bytesToCopy)
        {
            byte[] array = new byte[bytesToCopy];
            BlockingRead(inputStream, array, 0, bytesToCopy);
            return array;
        }

        internal static void BlockingRead(Stream stream, byte[] buffer, int offset, int count)
        {
            while (true)
            {
                if (count > 0)
                {
                    int num = stream.Read(buffer, offset, count);
                    if (num <= 0)
                    {
                        break;
                    }
                    count -= num;
                    offset += num;
                    continue;
                }
                return;
            }
            throw new EndOfStreamException();
        }
    }
}