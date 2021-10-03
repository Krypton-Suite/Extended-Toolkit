#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    /// <summary>
    /// A standard tool strip menu item control with UAC shield.
    /// Modified from the AeroSuite project.
    /// </summary>
    /// <remarks>
    /// The shield is extracted from the system with LoadImage if possible. Otherwise the shield will be enabled by sending the BCM_SETSHIELD Message to the control.
    /// If the operating system is not Windows Vista or higher, no shield will be displayed as there's no such thing as UAC on the target system -> the shield is obsolete.
    /// </remarks>
    [DisplayName("ToolStrip UAC Shield Menu Item")]
    [ToolboxBitmap(typeof(ToolStripMenuItem)), ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public partial class ToolStripMenuItemUACSheld : ToolStripMenuItem
    {
        #region Variables
        private bool _elevateApplicationOnClick = true;

        private string _processName = string.Empty;

        private static bool? _isSystemAbleToLoadShield = null;

        private const int BCM_SETSHIELD = 0x160C;

        private GlobalMethods _globalMethods = new GlobalMethods();

        private UtilityMethods _utilityMethods = new UtilityMethods();
        #endregion

        #region Properties
        /// <summary>
        /// Elevates the current running application to administrator level when button is clicked.
        /// </summary>
        /// <remarks>
        /// The application/process will restart when clicked.
        /// </remarks>
        [Category("Code")]
        [Description("Elevates the current running application to administrator level when button is clicked. The application/process will restart when clicked.")]
        [DefaultValue(true)]
        public bool ElevateApplicationOnClick
        {
            get
            {
                return _elevateApplicationOnClick;
            }

            set
            {
                _elevateApplicationOnClick = value;
            }
        }

        /// <summary>
        /// The application assembly.
        /// </summary>
        /// <remarks>
        /// Use 'Process.GetCurrentProcess().ProcessName;' as a start.
        /// </remarks>
        [Category("Code")]
        [Description("The application assembly. Use 'Process.GetCurrentProcess().ProcessName;' as a start.")]
        [DefaultValue("")]
        public string ProcessName
        {
            get
            {
                return _processName;
            }

            set
            {
                _processName = value;
            }
        }
        #endregion

        #region Events
        /// <summary></summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ExecuteProcessAsAdministratorEventArgs"/> instance containing the event data.</param>
        public delegate void ExecuteProcessAsAdministratorEventHandler(object sender, ExecuteProcessAsAdministratorEventArgs e);

        /// <summary>The execute process as administrator</summary>
        public ExecuteProcessAsAdministratorEventHandler ExecuteProcessAsAdministrator;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialises a new instance of the <see cref="ToolStripMenuItemUACSheld"/> class.
        /// </summary>
        public ToolStripMenuItemUACSheld() : base()
        {
            _globalMethods.CheckIfTargetPlatformIsSupported(true);

            if (_globalMethods.GetIsTargetPlatformSupported())
            {
                if (!_isSystemAbleToLoadShield.HasValue || _isSystemAbleToLoadShield.Value)
                {
                    try
                    {
                        var _icon = IconExtractor.LoadIcon(IconExtractor.IconType.Shield, SystemInformation.SmallIconSize);

                        if (_icon != null)
                        {
                            Image = _icon.ToBitmap();

                            TextImageRelation = TextImageRelation.ImageBeforeText;

                            ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;

                            _isSystemAbleToLoadShield = true;

                            return;
                        }
                        else
                        {
                            _isSystemAbleToLoadShield = false;
                        }
                    }
                    catch (Exception exc)
                    {
                        KryptonMessageBox.Show($"Your platform is unsupported. Please contact the software vendor for details.\nFor reference, your system is running: { _globalMethods.GetOSFriendlyName() }.\nException message: { exc.Message }.", "Unsupported Software", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        _isSystemAbleToLoadShield = false;
                    }
                }

                //NativeMethods.SendMessage(Handle, BCM_SETSHIELD, IntPtr.Zero, new IntPtr(1));
            }
        }
        #endregion

        #region Overrides
        protected override void OnClick(EventArgs e)
        {
            ExecuteProcessAsAdministratorEventArgs evt = new ExecuteProcessAsAdministratorEventArgs(ProcessName);

            OnExecuteProcessAsAdministrator(this, evt);

            base.OnClick(e);
        }
        #endregion

        /// <summary>Called when [execute process as administrator].</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ExecuteProcessAsAdministratorEventArgs"/> instance containing the event data.</param>
        protected virtual void OnExecuteProcessAsAdministrator(object sender, ExecuteProcessAsAdministratorEventArgs e)
        {
            if (ExecuteProcessAsAdministrator != null)
            {
                ExecuteProcessAsAdministrator(sender, e);
            }
        }
    }
}