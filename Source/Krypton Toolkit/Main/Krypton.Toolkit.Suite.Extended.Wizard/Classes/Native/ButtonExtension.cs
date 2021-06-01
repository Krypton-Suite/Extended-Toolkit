#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    internal static class TextBoxExtension
    {
        /// <summary>
        /// Sets the state of the elevation required.
        /// </summary>
        /// <param name="btn">The BTN.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <param name="vistaIsSupported">if set to <c>true</c> [vista is supported].</param>
        /// <exception cref="PlatformNotSupportedException"></exception>
        public static void SetElevationRequiredState(this ButtonBase btn, bool required = true, bool vistaIsSupported = true)
        {
            if (GlobalMethodsStatic.CheckIfTargetPlatformIsSupported(vistaIsSupported))
            {
                if (GlobalMethodsStatic.GetIsTargetPlatformSupported())
                {
                    // Elevated button
                    const uint BCM_SETSHIELD = 0x160C;

                    btn.FlatStyle = required ? FlatStyle.System : FlatStyle.Standard;

                    NativeMethods.SendMessage(btn.Handle, BCM_SETSHIELD, IntPtr.Zero, required ? new IntPtr(1) : IntPtr.Zero);

                    btn.Invalidate();
                }
                else
                {
                    throw new PlatformNotSupportedException();
                }
            }
        }
    }
}