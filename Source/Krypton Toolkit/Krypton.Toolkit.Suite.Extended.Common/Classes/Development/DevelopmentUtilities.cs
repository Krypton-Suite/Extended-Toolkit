#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Common
{
    public class DevelopmentUtilities
    {
        #region Constructors
        public DevelopmentUtilities()
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
        #endregion
    }
}