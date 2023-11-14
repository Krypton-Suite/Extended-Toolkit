#region MIT License
/*
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