#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Developer.Utilities.Properties;
using Krypton.Toolkit.Suite.Extended.Messagebox;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Developer.Utilities
{
    public class ApplicationUtilities
    {
        #region Variables
        private Image _underConstruction = Resources.UnderConstruction;
        #endregion

        #region Constructor
        public ApplicationUtilities()
        {

        }
        #endregion

        #region Methods
        /// <summary>Under construction.</summary>
        /// <param name="window">The window.</param>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="icon">The icon.</param>
        public static void UnderConstruction(KryptonForm window, string message = null, string title = null, MessageBoxIcon icon = MessageBoxIcon.Exclamation)
        {
            if (message == null)
            {
                message = "This feature is under construction, and will be available in a future update.\nThis window will now close.\n(If you are an end-user seeing this message, then please contact the developer for more information.)";
            }

            if (title == null)
            {
                title = "Under Construction";
            }

            DialogResult result = KryptonMessageBox.Show(message, title, MessageBoxButtons.OK, icon);

            if (result == DialogResult.OK)
            {
                window.Hide();
            }
        }

        public static void UnderConstruction(IWin32Window owner, string message, string caption = "Under Construction", Font typeface = null)
        {
            Image _underConstruction = Resources.UnderConstruction;

            if (message == null)
            {
                message = "This feature is under construction, and will be available in a future update.\nThis window will now close.\n(If you are an end-user seeing this message, then please contact the developer for more information.)";
            }

            if (caption == null)
            {
                caption = "Under Construction";
            }

            KryptonMessageBoxExtended.Show(owner, message, caption, MessageBoxButtons.OK, ExtendedMessageBoxIcon.CUSTOM, messageboxTypeface: typeface, customMessageBoxIcon: _underConstruction);
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