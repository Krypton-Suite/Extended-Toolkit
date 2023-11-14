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
    internal sealed class HGlobalSafeHandle : SafeHandle
    {
        private int _bufferSize;

        public override bool IsInvalid => handle == IntPtr.Zero;

        internal HGlobalSafeHandle()
            : base(IntPtr.Zero, true)
        {
        }

        ~HGlobalSafeHandle()
        {
            Dispose(false);
        }

        protected override void Dispose(bool disposing)
        {
            ReleaseHandle();
            base.Dispose(disposing);
        }

        internal IntPtr Buffer(int size)
        {
            if (size > _bufferSize)
            {
                if (_bufferSize == 0)
                {
                    SetHandle(Marshal.AllocHGlobal(size));
                }
                else
                {
                    SetHandle(Marshal.ReAllocHGlobal(handle, (IntPtr)size));
                }
                GC.AddMemoryPressure(size - _bufferSize);
                _bufferSize = size;
            }
            return handle;
        }

        protected override bool ReleaseHandle()
        {
            if (handle != IntPtr.Zero)
            {
                if (_bufferSize > 0)
                {
                    GC.RemoveMemoryPressure(_bufferSize);
                    _bufferSize = 0;
                }
                Marshal.FreeHGlobal(handle);
                handle = IntPtr.Zero;
                return true;
            }
            return false;
        }
    }
}