﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    /// <summary>Main DWM class, provides glass sheet effect and blur behind.</summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    [System.Security.SecuritySafeCritical]
    public static class DesktopWindowManager
    {
        static object ColourisationColourChangedKey = new object();
        static object CompositionChangedKey = new object();
        static EventHandlerList eventHandlerList;
        static object NonClientRenderingChangedKey = new object();
        //static object WindowMaximizedChangedKey = new object();
        static object[] keys = new object[] { CompositionChangedKey, NonClientRenderingChangedKey, ColourisationColourChangedKey/*, WindowMaximizedChangedKey*/ };
        static object _lock = new object();
        static MessageWindow _window;

        /// <summary>
        /// Occurs when the colorization color has changed.
        /// </summary>
        public static event EventHandler ColourisationColourChanged
        {
            add { AddEventHandler(ColourisationColourChangedKey, value); }
            remove { RemoveEventHandler(ColourisationColourChangedKey, value); }
        }

        /// <summary>
        /// Occurs when the desktop window composition has been enabled or disabled.
        /// </summary>
        public static event EventHandler CompositionChanged
        {
            add { AddEventHandler(CompositionChangedKey, value); }
            remove { RemoveEventHandler(CompositionChangedKey, value); }
        }

        /// <summary>
        /// Occurs when the non-client area rendering policy has changed.
        /// </summary>
        public static event EventHandler NonClientRenderingChanged
        {
            add { AddEventHandler(NonClientRenderingChangedKey, value); }
            remove { RemoveEventHandler(NonClientRenderingChangedKey, value); }
        }

        /// <summary>
        /// Gets or sets the current color used for Desktop Window Manager (DWM) glass composition. This value is based on the current color scheme and can be modified by the user.
        /// </summary>
        /// <value>The color of the glass composition.</value>
        public static Color CompositionColour
        {
            get
            {
                if (!CompositionSupported)
                    return Color.Transparent;
                int value = (int)Microsoft.Win32.Registry.CurrentUser.GetValue(@"Software\Microsoft\Windows\DWM\ColorizationColor", 0);
                return Color.FromArgb(value);
            }
            set
            {
                if (!CompositionSupported)
                    return;
                NativeMethods.ColourisationParams p = new NativeMethods.ColourisationParams();
                NativeMethods.DwmGetColorizationParameters(ref p);
                p.Colour1 = (uint)value.ToArgb();
                NativeMethods.DwmSetColorizationParameters(ref p, 1);
                Microsoft.Win32.Registry.CurrentUser.SetValue(@"Software\Microsoft\Windows\DWM\ColorizationColor", value.ToArgb(), Microsoft.Win32.RegistryValueKind.DWord);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether composition (Windows Aero) is enabled.
        /// </summary>
        /// <value><c>true</c> if composition is enabled; otherwise, <c>false</c>.</value>
        public static bool CompositionEnabled
        {
            get { return IsCompositionEnabled(); }
            set { if (CompositionSupported) EnableComposition(value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether composition (Windows Aero) is supported.
        /// </summary>
        /// <value><c>true</c> if composition is supported; otherwise, <c>false</c>.</value>
        public static bool CompositionSupported => System.Environment.OSVersion.Version.Major >= 6;

        /// <summary>
        /// Gets or sets a value that indicates whether the <see cref="CompositionColour"/> is transparent.
        /// </summary>
        /// <value><c>true</c> if transparent; otherwise, <c>false</c>.</value>
        public static bool TransparencyEnabled
        {
            get
            {
                if (!CompositionSupported)
                    return false;
                int value = (int)Microsoft.Win32.Registry.CurrentUser.GetValue(@"Software\Microsoft\Windows\DWM\ColorizationOpaqueBlend", 1);
                return value == 0;
            }
            set
            {
                if (!CompositionSupported)
                    return;
                NativeMethods.ColourisationParams p = new NativeMethods.ColourisationParams();
                NativeMethods.DwmGetColorizationParameters(ref p);
                p.Opaque = value ? 0u : 1u;
                NativeMethods.DwmSetColorizationParameters(ref p, 1);
                Microsoft.Win32.Registry.CurrentUser.SetValue(@"Software\Microsoft\Windows\DWM\ColorizationOpaqueBlend", p.Opaque, Microsoft.Win32.RegistryValueKind.DWord);
            }
        }

        /*/// <summary>
		/// Occurs when a Desktop Window Manager (DWM) composed window is maximized.
		/// </summary>
		public static event EventHandler WindowMaximizedChanged
		{
			add { AddEventHandler(WindowMaximizedChangedKey, value); }
			remove { RemoveEventHandler(WindowMaximizedChangedKey, value); }
		}*/

        /// <summary>
        /// Enable the Aero "Blur Behind" effect on the whole client area. Background must be black.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="enabled"><c>true</c> to enable blur behind for this window, <c>false</c> to disable it.</param>
        public static void EnableBlurBehind(this IWin32Window window, bool enabled)
        {
            EnableBlurBehind(window, null, null, enabled, false);
        }

        /// <summary>
        /// Enable the Aero "Blur Behind" effect on a specific region of a drawing area. Background must be black.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="graphics">The graphics area on which the region resides.</param>
        /// <param name="region">The region within the client area to apply the blur behind.</param>
        /// <param name="enabled"><c>true</c> to enable blur behind for this region, <c>false</c> to disable it.</param>
        /// <param name="transitionOnMaximized"><c>true</c> if the window's colorization should transition to match the maximized windows; otherwise, <c>false</c>.</param>
        public static void EnableBlurBehind(this IWin32Window window, System.Drawing.Graphics graphics, System.Drawing.Region region, bool enabled, bool transitionOnMaximized)
        {
            if (window == null)
                throw new ArgumentNullException(nameof(window));
            NativeMethods.BlurBehind bb = new NativeMethods.BlurBehind(enabled);
            if (graphics != null && region != null)
                bb.SetRegion(graphics, region);
            if (transitionOnMaximized)
                bb.TransitionOnMaximized = true;
            NativeMethods.DwmEnableBlurBehindWindow(window.Handle, ref bb);
        }

        /// <summary>
        /// Enables or disables Desktop Window Manager (DWM) composition.
        /// </summary>
        /// <param name="value"><c>true</c> to enable DWM composition; <c>false</c> to disable composition.</param>
        public static void EnableComposition(bool value)
        {
            NativeMethods.DwmEnableComposition(value ? 1 : 0);
        }

        /// <summary>
        /// Excludes the specified child control from the glass effect.
        /// </summary>
        /// <param name="parent">The parent control.</param>
        /// <param name="control">The control to exclude.</param>
        /// <exception cref="ArgumentNullException">Occurs if control is null.</exception>
        /// <exception cref="ArgumentException">Occurs if control is not a child control.</exception>
        public static void ExcludeChildFromGlass(this Control parent, Control control)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            if (control == null)
                throw new ArgumentNullException(nameof(control));
            if (!parent.Contains(control))
                throw new ArgumentException("Control must be a child control.");

            if (IsCompositionEnabled())
            {
                System.Drawing.Rectangle clientScreen = parent.RectangleToScreen(parent.ClientRectangle);
                System.Drawing.Rectangle controlScreen = control.RectangleToScreen(control.ClientRectangle);

                NativeMethods.Margins margins = new NativeMethods.Margins(controlScreen.Left - clientScreen.Left, controlScreen.Top - clientScreen.Top,
                    clientScreen.Right - controlScreen.Right, clientScreen.Bottom - controlScreen.Bottom);

                // Extend the Frame into client area
                NativeMethods.DwmExtendFrameIntoClientArea(parent.Handle, ref margins);
            }
        }

        /// <summary>
        /// Extends the window frame beyond the client area.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="padding">The padding to use as the area into which the frame is extended.</param>
        public static void ExtendFrameIntoClientArea(this IWin32Window window, Padding padding)
        {
            if (window == null)
                throw new ArgumentNullException(nameof(window));
            NativeMethods.Margins m = new NativeMethods.Margins(padding);
            NativeMethods.DwmExtendFrameIntoClientArea(window.Handle, ref m);
        }

        /// <summary>
        /// Flags used by the SetWindowAttr method to specify the non-client area rendering policy.
        /// </summary>
        public enum NonClientRenderingPolicy
        {
            /// <summary>The non-client rendering area is rendered based on the window style.</summary>
            UseWindowStyle,
            /// <summary>The non-client area rendering is disabled; the window style is ignored.</summary>
            Disabled,
            /// <summary>The non-client area rendering is enabled; the window style is ignored.</summary>
            Enabled
        }

        /// <summary>
        /// Flags used by the SetWindowAttr method to specify the Flip3D window policy.
        /// </summary>
        public enum Flip3DWindowPolicy
        {
            /// <summary>Use the window's style and visibility settings to determine whether to hide or include the window in Flip3D rendering.</summary>
            Default,
            /// <summary>Exclude the window from Flip3D and display it below the Flip3D rendering.</summary>
            ExcludeBelow,
            /// <summary>Exclude the window from Flip3D and display it above the Flip3D rendering.</summary>
            ExcludeAbove
        }

        /// <summary>
        /// Use with GetWindowAttr and WindowAttribute.Cloaked. If the window is cloaked, provides one of the following values explaining why.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1714:FlagsEnumsShouldHavePluralNames")]
        [Flags]
        public enum CloakingSource
        {
            /// <summary>The window was cloaked by its owner application.</summary>
            App = 0x01,
            /// <summary>The window was cloaked by the Shell.</summary>
            Shell = 0x02,
            /// <summary>The cloak value was inherited from its owner window.</summary>
            Inherited = 0x04
        }

        /// <summary>
        /// Window attribute to get through the <see cref="GetWindowAttr"/> methods.
        /// </summary>
        public enum GetWindowAttr
        {
            /// <summary>No attribute.</summary>
            None = 0,
            /// <summary>Gets whether non-client rendering is enabled. The retrieved value is of type bool. True if non-client rendering is enabled; otherwise, False.</summary>
            NonClientRenderingEnabled = 1,
            /// <summary>Gets the bounds of the caption button area in the window-relative space. The retrieved value is of type RECT.</summary>
            CaptionButtonBounds = 5,
            /// <summary>Gets the extended frame bounds rectangle in screen space. The retrieved value is of type RECT.</summary>
            ExtendedFrameBounds = 9,
            /// <summary>Win8+. Get CloakingSource flags explaining why a window is cloaked.</summary>
            Cloaked = 14
        }

        /// <summary>
        /// Window attribute to set through the <see cref="SetWindowAttr"/> methods.
        /// </summary>
        public enum SetWindowAttr
        {
            /// <summary>No attribute.</summary>
            None = 0,
            /// <summary>Sets the non-client rendering policy. The retrieved value is from the NonClientRenderingPolicy enumeration.</summary>
            NonClientRenderingPolicy = 2,
            /// <summary>Enables or forcibly disables DWM transitions. The retrieved value is of type bool. True to disable transitions or False to enable transitions.</summary>
            TransitionsForceDisabled = 3,
            /// <summary>Enables content rendered in the non-client area to be visible on the frame drawn by DWM. The retrieved value is of type bool. True to enable content rendered in the non-client area to be visible on the frame; otherwise, False.</summary>
            AllowNonClientPaint = 4,
            /// <summary>Sets whether non-client content is right-to-left (RTL) mirrored. The retrieved value is of type bool. True if the non-client content is right-to-left (RTL) mirrored; otherwise False.</summary>
            NonClientRtlLayout = 6,
            /// <summary>Forces the window to display an iconic thumbnail or peek representation (a static bitmap), even if a live or snapshot representation of the window is available. This value normally is set during a window's creation and not changed throughout the window's lifetime. Some scenarios, however, might require the value to change over time. The retrieved value is of type bool. True to require a iconic thumbnail or peek representation; otherwise, False.</summary>
            ForceIconicRepresentation = 7,
            /// <summary>Sets how Flip3D treats the window. The pvAttribute parameter points to a value from the Flip3DWindowPolicy enumeration.</summary>
            Flip3DPolicy = 8,
            /// <summary>Win7+. Sets if the window will provide a bitmap for use by DWM as an iconic thumbnail or peek representation (a static bitmap) for the window. HasIconicBitmap can be specified with ForceIconicRepresentation. HasIconicBitmap normally is set during a window's creation and not changed throughout the window's lifetime. Some scenarios, however, might require the value to change over time. The retrieved value is of type bool. True to inform DWM that the window will provide an iconic thumbnail or peek representation; otherwise, False.</summary>
            HasIconicBitmap = 10,
            /// <summary>Win7+. Set true to not show peek preview for the window. The peek view shows a full-sized preview of the window when the mouse hovers over the window's thumbnail in the taskbar. If this attribute is set, hovering the mouse pointer over the window's thumbnail dismisses peek (in case another window in the group has a peek preview showing). The retrieved value is of type bool. True to prevent peek functionality or False to allow it.</summary>
            DisallowPeek = 11,
            /// <summary>Win7+. Sets value preventing a window from fading to a glass sheet when peek is invoked. The retrieved value is of type bool. True to prevent the window from fading during another window's peek or False for normal behavior.</summary>
            ExcludedFromPeek = 12,
            /// <summary>Win8+. Cloaks the window such that it is not visible to the user. The window is still composed by DWM. True to cloak or False to not cloak.</summary>
            Cloak = 13,
            /// <summary>Win8+. Freeze the window's thumbnail image with its current visuals. Do no further live updates on the thumbnail image to match the window's contents.</summary>
            FreezeRepresentation = 15
        }

        /// <summary>
        /// Gets the specified window attribute from the Desktop Window Manager (DWM).
        /// </summary>
        /// <typeparam name="T">Return type. Must match the attribute.</typeparam>
        /// <param name="window">The window.</param>
        /// <param name="attribute">The attribute.</param>
        /// <returns>Value of the windows attribute.</returns>
        public static T GetWindowAttribute<T>(this IWin32Window window, GetWindowAttr attribute) where T : struct
        {
            if (window == null)
                throw new ArgumentNullException(nameof(window));
            using (var ptr = SafeHGlobalHandle.AllocHGlobal<T>())
            {
                NativeMethods.DwmGetWindowAttribute(window.Handle, (NativeMethods.DWMWINDOWATTRIBUTE)attribute, ptr, ptr.Size);
                return ptr.ToStructure<T>();
            }
        }

        /// <summary>
        /// Sets the specified window attribute through the Desktop Window Manager (DWM).
        /// </summary>
        /// <param name="window">The window.</param>
        /// <param name="attribute">The attribute.</param>
        /// <param name="value">The value.</param>
        public static void SetWindowAttribute(this IWin32Window window, SetWindowAttr attribute, object value)
        {
            if (window == null)
                throw new ArgumentNullException(nameof(window));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            using (var ptr = new SafeHGlobalHandle(value))
                NativeMethods.DwmSetWindowAttribute(window.Handle, (NativeMethods.DWMWINDOWATTRIBUTE)attribute, ptr, ptr.Size);
        }

        /// <summary>
        /// Indicates whether Desktop Window Manager (DWM) composition is enabled.
        /// </summary>
        /// <returns><c>true</c> if is composition enabled; otherwise, <c>false</c>.</returns>
        public static bool IsCompositionEnabled()
        {
            if (!CompositionSupported || !System.IO.File.Exists(System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.System), NativeMethods.DWMAPI)))
                return false;
            int res = 0;
            NativeMethods.DwmIsCompositionEnabled(ref res);
            return res != 0;
        }

        private static void AddEventHandler(object id, EventHandler value)
        {
            lock (_lock)
            {
                if (_window == null)
                    _window = new MessageWindow();
                if (eventHandlerList == null)
                    eventHandlerList = new EventHandlerList();
                eventHandlerList.AddHandler(id, value);
            }
        }

        private static void RemoveEventHandler(object id, EventHandler value)
        {
            lock (_lock)
            {
                if (eventHandlerList != null)
                {
                    eventHandlerList.RemoveHandler(id, value);
                }
            }
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        [System.Security.SecuritySafeCritical]
        private class MessageWindow : NativeWindow, IDisposable
        {
            const int WM_DWMCOLORIZATIONCOLORCHANGED = 0x0320;
            const int WM_DWMCOMPOSITIONCHANGED = 0x031E;
            const int WM_DWMNCRENDERINGCHANGED = 0x031F;
            //const int WM_DWMWINDOWMAXIMIZEDCHANGE = 0x0321;

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public MessageWindow()
            {
                CreateParams cp = new CreateParams() { Style = 0, ExStyle = 0, ClassStyle = 0, Parent = IntPtr.Zero };
                cp.Caption = base.GetType().Name;
                CreateHandle(cp);
            }

            public void Dispose()
            {
                DestroyHandle();
            }

            [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
            protected override void WndProc(ref Message m)
            {
                if (m.Msg >= WM_DWMCOMPOSITIONCHANGED && m.Msg <= WM_DWMCOLORIZATIONCOLORCHANGED)
                    ExecuteEvents(m.Msg - WM_DWMCOMPOSITIONCHANGED);

                base.WndProc(ref m);
            }

            private void ExecuteEvents(int idx)
            {
                if (eventHandlerList != null)
                {
                    lock (_lock)
                    {
                        try { ((EventHandler)eventHandlerList[keys[idx]]).Invoke(null, EventArgs.Empty); }
                        catch { };
                    }
                }
            }
        }
    }
}