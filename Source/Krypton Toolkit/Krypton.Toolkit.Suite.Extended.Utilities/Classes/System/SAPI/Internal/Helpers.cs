#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

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