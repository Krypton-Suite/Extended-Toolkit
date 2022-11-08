#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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