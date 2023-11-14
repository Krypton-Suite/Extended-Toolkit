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

namespace Krypton.Toolkit.Suite.Extended.Developer.Utilities
{
    public class ApplicationUtilities
    {
        #region Variables
        private Image _underConstruction = Properties.Resources.UnderConstruction;
        #endregion

        #region Constructor
        public ApplicationUtilities()
        {

        }
        #endregion

        #region Methods
        public static void UnderConstruction(string message = null, string caption = "Under Construction", Font? typeface = null)
        {
            Image _underConstruction = Properties.Resources.UnderConstruction;

            if (message == null)
            {
                message = "This feature is under construction, and will be available in a future update.\nThis window will now close.\n(If you are an end-user seeing this message, then please contact the developer for more information.)";
            }

            if (caption == null)
            {
                caption = "Under Construction";
            }

            KryptonMessageBoxExtended.Show(message, caption, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxCustomButtonOptions.None, ExtendedMessageBoxIcon.Custom, messageboxTypeface: typeface, customMessageBoxIcon: _underConstruction);
        }

        /// <summary>Displays the developer information.</summary>
        /// <param name="window">The window.</param>
        /// <param name="applicationVersion">The application version.</param>
        /// <param name="developerText">The developer text.</param>
        /// <param name="showBuild">if set to <c>true</c> [show build].</param>
        /// <param name="showFullVersion">if set to <c>true</c> [show full version].</param>
        public static void DisplayDeveloperInformation(KryptonForm window, Version applicationVersion, string developerText = "Dev Build", bool showBuild = true, bool showFullVersion = false)
        {
            if (showBuild)
            {
                window.TextExtra = $"{developerText}: ({applicationVersion.Build})";
            }
            else if (showFullVersion)
            {
                window.TextExtra = $"{developerText}: ({applicationVersion})";
            }
        }

        #endregion

        #region Destruction
        ~ApplicationUtilities() => GC.SuppressFinalize(this);
        #endregion
    }
}