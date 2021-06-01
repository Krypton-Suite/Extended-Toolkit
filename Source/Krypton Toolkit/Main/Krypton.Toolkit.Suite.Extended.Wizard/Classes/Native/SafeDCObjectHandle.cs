#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    internal static partial class NativeMethods
    {
        public class SafeDCObjectHandle : SafeHandle
        {
            private readonly SafeDCHandle hDC;
            private readonly IntPtr hOld;

            public SafeDCObjectHandle(SafeDCHandle hdc, IntPtr hObj) : base(IntPtr.Zero, true)
            {
                if (hdc == null || hdc.IsInvalid) return;
                hDC = hdc;
                hOld = SelectObject(hdc, hObj);
                SetHandle(hObj);
            }

            public override bool IsInvalid => handle == IntPtr.Zero;

            protected override bool ReleaseHandle()
            {
                SelectObject(hDC, hOld);
                return DeleteObject(handle);
            }
        }
    }
}