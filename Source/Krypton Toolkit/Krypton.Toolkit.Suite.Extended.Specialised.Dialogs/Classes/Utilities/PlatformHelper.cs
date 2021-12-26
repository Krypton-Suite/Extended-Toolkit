#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Specialised.Dialogs
{
    /// <summary>
    /// Provides helper functions for platform management
    /// </summary>
    public static class PlatformHelper
    {
        /// <summary>
        /// Initializes the <see cref="PlatformHelper"/> class.
        /// </summary>
        static PlatformHelper()
        {
            PlatformHelper.Win32NT = Environment.OSVersion.Platform == PlatformID.Win32NT;
            PlatformHelper.XpOrHigher = PlatformHelper.Win32NT && Environment.OSVersion.Version.Major >= 5;
            PlatformHelper.VistaOrHigher = PlatformHelper.Win32NT && Environment.OSVersion.Version.Major >= 6;
            PlatformHelper.SevenOrHigher = PlatformHelper.Win32NT && (Environment.OSVersion.Version >= new Version(6, 1));
            PlatformHelper.EightOrHigher = PlatformHelper.Win32NT && (Environment.OSVersion.Version >= new Version(6, 2, 9200));
            PlatformHelper.VisualStylesEnabled = VisualStyleInformation.IsEnabledByUser;

            SystemEvents.UserPreferenceChanged += (s, e) =>
            {
                var vsEnabled = VisualStyleInformation.IsEnabledByUser;
                if (vsEnabled != PlatformHelper.VisualStylesEnabled)
                {
                    PlatformHelper.VisualStylesEnabled = vsEnabled;
                    //Maybe raise an event here
                }
            };
        }

        /// <summary>
        /// Returns a indicating whether the Operating System is Windows 32 NT based.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the Operating System is Windows 32 NT based; otherwise, <c>false</c>.
        /// </value>
        public static bool Win32NT { get; private set; }

        /// <summary>
        /// Returns a value indicating whether the Operating System is Windows XP or higher.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the Operating System is Windows 8 or higher; otherwise, <c>false</c>.
        /// </value>
        public static bool XpOrHigher { get; private set; }

        /// <summary>
        /// Returns a value indicating whether the Operating System is Windows Vista or higher.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the Operating System is Windows Vista or higher; otherwise, <c>false</c>.
        /// </value>
        public static bool VistaOrHigher { get; private set; }

        /// <summary>
        /// Returns a value indicating whether the Operating System is Windows 7 or higher.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the Operating System is Windows 7 or higher; otherwise, <c>false</c>.
        /// </value>
        public static bool SevenOrHigher { get; private set; }

        /// <summary>
        /// Returns a value indicating whether the Operating System is Windows 8 or higher.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the Operating System is Windows 8 or higher; otherwise, <c>false</c>.
        /// </value>
        public static bool EightOrHigher { get; private set; }

        /// <summary>
        /// Returns a value indicating whether Visual Styles are enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if Visual Styles are enabled; otherwise, <c>false</c>.
        /// </value>
        public static bool VisualStylesEnabled { get; private set; }
    }
}