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
        /// <summary>
        /// A SafeHandle to track DC handles.
        /// </summary>
        public class SafeDCHandle : SafeHandle
        {
            /// <summary>
            /// A null handle.
            /// </summary>
            public static readonly SafeDCHandle Null = new SafeDCHandle(IntPtr.Zero);

            private readonly IDeviceContext idc;
            /// <summary>
            /// Initializes a new instance of the <see cref="SafeDCHandle"/> class.
            /// </summary>
            /// <param name="hDC">The handle to the DC.</param>
            /// <param name="ownsHandle">
            ///     <see langword="true" /> to have the native handle released when this safe handle is disposed or finalized;
            ///     <see langword="false" /> otherwise.
            /// </param>
            public SafeDCHandle(IntPtr hDC, bool ownsHandle = true)
                : base(IntPtr.Zero, ownsHandle)
            {
                SetHandle(hDC);
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="SafeDCHandle"/> class.
            /// </summary>
            /// <param name="dc">An <see cref="IDeviceContext"/> instance.</param>
            public SafeDCHandle(IDeviceContext dc)
                : base(IntPtr.Zero, true)
            {
                if (dc == null)
                {
                    throw new ArgumentNullException(nameof(dc));
                }

                idc = dc;
                SetHandle(dc.GetHdc());
            }

            /// <inheritdoc />
            public override bool IsInvalid => handle == IntPtr.Zero;

            public static SafeDCHandle ScreenCompatibleDCHandle => new SafeDCHandle(CreateCompatibleDC(IntPtr.Zero));

            /// <summary>
            /// Performs an implicit conversion from <see cref="Graphics"/> to <see cref="SafeDCHandle"/>.
            /// </summary>
            /// <param name="graphics">The <see cref="Graphics"/> instance.</param>
            /// <returns>
            /// The result of the conversion.
            /// </returns>
            public static implicit operator SafeDCHandle(Graphics graphics) => new SafeDCHandle(graphics);

            public SafeDCHandle GetCompatibleDCHandle() => new SafeDCHandle(CreateCompatibleDC(handle));

            /// <inheritdoc />
            protected override bool ReleaseHandle()
            {
                if (idc != null)
                {
                    idc.ReleaseHdc();
                    return true;
                }

                return DeleteDC(handle);
            }
        }
    }
}