#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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

            KryptonMessageBoxExtended.Show(message, caption, ExtendedMessageBoxButtons.OK, ExtendedMessageBoxCustomButtonOptions.NONE, ExtendedMessageBoxIcon.CUSTOM, messageboxTypeface: typeface, customMessageBoxIcon: _underConstruction);
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
                window.TextExtra = $"{ developerText }: ({ applicationVersion.Build })";
            }
            else if (showFullVersion)
            {
                window.TextExtra = $"{ developerText }: ({ applicationVersion })";
            }
        }
        #endregion

        #region Destruction
        ~ApplicationUtilities() => GC.SuppressFinalize(this);
        #endregion
    }
}