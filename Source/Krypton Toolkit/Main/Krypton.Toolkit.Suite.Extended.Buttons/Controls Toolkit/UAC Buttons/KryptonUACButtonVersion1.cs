using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    /// <summary>
    /// A standard Krypton button control with UAC shield
    /// Modified from the AeroSuite project.
    /// </summary>
    /// <remarks>
    /// The shield is extracted from the system with LoadImage if possible. Otherwise the shield will be enabled by sending the BCM_SETSHIELD Message to the control.
    /// If the operating system is not Windows Vista or higher, no shield will be displayed as there's no such thing as UAC on the target system -> the shield is obsolete.
    /// </remarks>
    [DefaultEvent("ExecuteProcessAsAdministrator"), DesignerCategory("code"), Description("Krypton UAC Elevated Button"), 
     ToolboxBitmap(typeof(KryptonButton), "ToolboxBitmaps.UACButton.bmp"), ToolboxItem(true)]
    public class KryptonUACButtonVersion1 : KryptonButton
    {
        #region Variables
        private Assembly _assemblyToElevate;

        private bool _elevateApplicationOnClick = true, _showUACShield = true;

        private string _processName = string.Empty, _extraArguments = string.Empty;

        private static bool? _isSystemAbleToLoadShield = null;

        private GlobalMethods _globalMethods = new GlobalMethods();

        private UtilityMethods _utilityMethods = new UtilityMethods();
        #endregion

        #region Constants
        private const int BCM_SETSHIELD = 0x160C;
        #endregion

        #region Properties
        /// <summary>Gets or sets the process to elevate.</summary>
        /// <value>The process to elevate.</value>
        public Assembly AssemblyToElevate { get => _assemblyToElevate; set => _assemblyToElevate = value; }

        /// <summary>
        /// Elevates the current running application to administrator level when button is clicked.
        /// </summary>
        /// <remarks>
        /// The application/process will restart when clicked.
        /// </remarks>
        // [Category("Code"), Description("Elevates the current running application to administrator level when button is clicked. The application/process will restart when clicked."), DefaultValue(true)]
        // public bool ElevateApplicationOnClick { get => _elevateApplicationOnClick; set => _elevateApplicationOnClick = value; }

        /// <summary>Gets or sets a value indicating whether [show uac shield].</summary>
        /// <value><c>true</c> if [show uac shield]; otherwise, <c>false</c>.</value>
        // public bool ShowUACShield { get => _showUACShield; set { _showUACShield = value; Invalidate(); } }

        /// <summary>
        /// The application assembly.
        /// </summary>
        /// <remarks>
        /// Use 'Process.GetCurrentProcess().ProcessName;' as a start.
        /// </remarks>
        [Category("Code"), Description("The application assembly. Use 'Process.GetCurrentProcess().ProcessName;' as a start."), DefaultValue("")]
        public string ProcessName { get => _processName; set => _processName = value; }
        #endregion

        #region Events
        /// <summary></summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ExecuteProcessAsAdministratorEventArgs"/> instance containing the event data.</param>
        public delegate void ExecuteProcessAsAdministratorEventHandler(object sender, ExecuteProcessAsAdministratorEventArgs e);

        /// <summary>The execute process as administrator</summary>
        public event ExecuteProcessAsAdministratorEventHandler ExecuteProcessAsAdministrator;

        /// <summary>Executes the process as an administrator.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ExecuteProcessAsAdministratorEventArgs" /> instance containing the event data.</param>
        protected virtual void OnExecuteProcessAsAdministrator(object sender, ExecuteProcessAsAdministratorEventArgs e) => ExecuteProcessAsAdministrator?.Invoke(sender, e);
        #endregion

        #region Constructor
        public KryptonUACButtonVersion1() : base()
        {
            _assemblyToElevate = null;

            _elevateApplicationOnClick = true;

            _processName = "";

            _extraArguments = "";

            _showUACShield = true;

            if (_showUACShield)
            {
                UACSecurity.AddShieldToButton(this);
            }
        }
        #endregion

        #region Overrides
        protected override void OnClick(EventArgs e)
        {
            if (_elevateApplicationOnClick)
            {
                if (_assemblyToElevate != null)
                {
                    ExecuteProcessAsAdministratorEventArgs administrativeTask = new ExecuteProcessAsAdministratorEventArgs(_assemblyToElevate);

                    OnExecuteProcessAsAdministrator(this, administrativeTask);
                }
                else if (_assemblyToElevate != null && !string.IsNullOrEmpty(_extraArguments))
                {
                    ExecuteProcessAsAdministratorEventArgs administrativeTaskWithExtraArguments = new ExecuteProcessAsAdministratorEventArgs(Path.GetFullPath(_assemblyToElevate.Location), _extraArguments);

                    OnExecuteProcessAsAdministrator(this, administrativeTaskWithExtraArguments);
                }
                else if (!string.IsNullOrEmpty(_processName))
                {
                    ExecuteProcessAsAdministratorEventArgs administrativeTask = new ExecuteProcessAsAdministratorEventArgs(_processName);

                    OnExecuteProcessAsAdministrator(this, administrativeTask);
                }
                else if (!string.IsNullOrEmpty(_processName) && !string.IsNullOrEmpty(_extraArguments))
                {
                    ExecuteProcessAsAdministratorEventArgs administrativeTaskWithExtraArguments = new ExecuteProcessAsAdministratorEventArgs(_processName, _extraArguments);

                    OnExecuteProcessAsAdministrator(this, administrativeTaskWithExtraArguments);
                }
            }

            base.OnClick(e);
        }
        #endregion
    }
}