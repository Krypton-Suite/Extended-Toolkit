using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    internal static partial class VisualStyleRendererExtension
    {
        public static Padding GetMargins2(this VisualStyleRenderer rnd, IDeviceContext dc = null, MarginProperty prop = MarginProperty.ContentMargins)
        {
            NativeMethods.RECT rc;
            using (var hdc = new NativeMethods.SafeDCHandle(dc))
                NativeMethods.GetThemeMargins(rnd, hdc, rnd.Part, rnd.State, (int)prop, IntPtr.Zero, out rc);
            return new Padding(rc.Left, rc.Top, rc.Right, rc.Bottom);
        }

        public static int GetTransitionDuration(this VisualStyleRenderer rnd, int toState, int fromState = 0)
        {
            int dwDuration;
            NativeMethods.GetThemeTransitionDuration(rnd, rnd.Part, fromState == 0 ? rnd.State : fromState, toState, (int)NativeMethods.IntegerListProperty.TransitionDuration, out dwDuration);
            return dwDuration;
        }

        /// <summary>
        /// Sets the state of the <see cref="VisualStyleRenderer"/>.
        /// </summary>
        /// <param name="rnd">The <see cref="VisualStyleRenderer"/> instance.</param>
        /// <param name="state">The state.</param>
        public static void SetState(this VisualStyleRenderer rnd, int state) { rnd.SetParameters(rnd.Class, rnd.Part, state); }

        /// <summary>
        /// Sets attributes to control how visual styles are applied to a specified window.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="attr">The attributes to apply or disable.</param>
        /// <param name="enable">if set to <c>true</c> enable the attribute, otherwise disable it.</param>
        public static void SetWindowThemeAttribute(this IWin32Window window, NativeMethods.WindowThemeNonClientAttributes attr, bool enable = true)
        {
            try { NativeMethods.SetWindowThemeAttribute(window, attr, enable ? (int)attr : 0); }
            catch (EntryPointNotFoundException) { }
        }
    }
}