using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Security.Principal;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Common
{
    public class UtilityMethods
    {
        #region Constructor
        /// <summary>
        /// Initialises a new instance of <see cref="UtilityMethods"/>.
        /// </summary>
        public UtilityMethods()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Elevates the application to use administrative privileges. To be used with <see cref="ExtendedToolkit.Controls.KryptonUACElevatedButton"/> or <see cref="ExtendedToolkit.ToolstripControls.ToolStripMenuItemUACSheld"/> button click.
        /// </summary>
        /// <param name="processName">The process name that you wish to elevate.</param>
        public static void ElevateProcessWithAdministrativeRights(string processName)
        {
            WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

            bool hasAdministrativeRight = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (!hasAdministrativeRight)
            {
                // Relaunch the application with administrative rights
                ProcessStartInfo processStartInfo = new ProcessStartInfo();

                processStartInfo.Verb = "runas";

                processStartInfo.FileName = processName;

                try
                {
                    Process.Start(processStartInfo);
                }
                catch (Win32Exception wexc)
                {
                    KryptonMessageBox.Show("Error: " + wexc.Message, "An Error has Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }
        }

        /// <summary>
        /// Checks to see if the current process has launched with administrative rights.
        /// </summary>
        /// <remarks>
        /// Use this method in your 'Load' event.
        /// </remarks>
        /// <returns>True if the current process has launched with administrative rights, false if not.</returns>
        public static bool GetHasElevateProcessWithAdministrativeRights()
        {
            WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());

            bool hasAdministrativeRight = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (hasAdministrativeRight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>Changes the control location.</summary>
        /// <param name="control">The control.</param>
        /// <param name="location">The location.</param>
        public static void ChangeControlLocation(Control control, Point location) => control.Location = location;
        #endregion
    }
}