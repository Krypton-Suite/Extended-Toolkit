#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Internal
{
    internal sealed class StreamMarshaler : IDisposable
    {
        private HGlobalSafeHandle _safeHMem = new HGlobalSafeHandle();

        private Stream _stream;

        internal Stream Stream => _stream;

        internal uint Position
        {
            set
            {
                _stream.Position = value;
            }
        }

        internal StreamMarshaler()
        {
        }

        internal StreamMarshaler(Stream stream)
        {
            _stream = stream;
        }

        public void Dispose()
        {
            _safeHMem.Dispose();
        }

        internal void ReadArray<T>(T[] ao, int c)
        {
            Type typeFromHandle = typeof(T);
            int num = Marshal.SizeOf(typeFromHandle);
            int num2 = num * c;
            byte[] source = Helpers.ReadStreamToByteArray(_stream, num2);
            IntPtr intPtr = _safeHMem.Buffer(num2);
            Marshal.Copy(source, 0, intPtr, num2);
            for (int i = 0; i < c; i++)
            {
                ao[i] = (T)Marshal.PtrToStructure((IntPtr)((long)intPtr + i * num), typeFromHandle);
            }
        }

        internal void WriteArray<T>(T[] ao, int c)
        {
            Type typeFromHandle = typeof(T);
            int num = Marshal.SizeOf(typeFromHandle);
            int num2 = num * c;
            byte[] array = new byte[num2];
            IntPtr intPtr = _safeHMem.Buffer(num2);
            for (int i = 0; i < c; i++)
            {
                Marshal.StructureToPtr((object)ao[i], (IntPtr)((long)intPtr + i * num), false);
            }
            Marshal.Copy(intPtr, array, 0, num2);
            _stream.Write(array, 0, num2);
        }

        internal void ReadArrayChar(char[] ach, int c)
        {
            int num = c * 2;
            if (num > 0)
            {
                byte[] source = Helpers.ReadStreamToByteArray(_stream, num);
                IntPtr intPtr = _safeHMem.Buffer(num);
                Marshal.Copy(source, 0, intPtr, num);
                Marshal.Copy(intPtr, ach, 0, c);
            }
        }

        internal string ReadNullTerminatedString()
        {
            BinaryReader binaryReader = new BinaryReader(_stream, Encoding.Unicode);
            StringBuilder stringBuilder = new StringBuilder();
            while (true)
            {
                char c = binaryReader.ReadChar();
                if (c == '\0')
                {
                    break;
                }
                stringBuilder.Append(c);
            }
            return stringBuilder.ToString();
        }

        internal void WriteArrayChar(char[] ach, int c)
        {
            int num = c * 2;
            if (num > 0)
            {
                byte[] array = new byte[num];
                IntPtr intPtr = _safeHMem.Buffer(num);
                Marshal.Copy(ach, 0, intPtr, c);
                Marshal.Copy(intPtr, array, 0, num);
                _stream.Write(array, 0, num);
            }
        }

        internal void ReadStream(object o)
        {
            int num = Marshal.SizeOf(o.GetType());
            byte[] source = Helpers.ReadStreamToByteArray(_stream, num);
            IntPtr intPtr = _safeHMem.Buffer(num);
            Marshal.Copy(source, 0, intPtr, num);
            Marshal.PtrToStructure(intPtr, o);
        }

        internal void WriteStream(object o)
        {
            int num = Marshal.SizeOf(o.GetType());
            byte[] array = new byte[num];
            IntPtr intPtr = _safeHMem.Buffer(num);
            Marshal.StructureToPtr(o, intPtr, false);
            Marshal.Copy(intPtr, array, 0, num);
            _stream.Write(array, 0, num);
        }
    }
}