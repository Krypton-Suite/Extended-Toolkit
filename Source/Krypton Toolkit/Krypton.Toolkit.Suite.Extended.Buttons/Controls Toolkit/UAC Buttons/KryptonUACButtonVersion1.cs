#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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

        private bool _elevateApplicationOnClick = true;

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
            this.Size = new Size((int)(this.Width * 1.5), this.Height + 1);
            if (PlatformHelper.VistaOrHigher)
            {
                //Only try to load the icon if it did not fail before
                if (!_isSystemAbleToLoadShield.HasValue || _isSystemAbleToLoadShield.Value)
                {
                    try
                    {
                        var icon = IconExtractor.LoadIcon(IconExtractor.IconType.Shield, SystemInformation.SmallIconSize);
                        if (icon != null)
                        {
                            Values.Image = icon.ToBitmap();
                            //this.TextImageRelation = TextImageRelation.ImageBeforeText;
                            //this.ImageAlign = ContentAlignment.MiddleRight;

                            _isSystemAbleToLoadShield = true;
                            return;
                        }
                        else
                        {
                            _isSystemAbleToLoadShield = false;
                        }
                    }
                    catch (PlatformNotSupportedException)
                    {
                        //This happens when the system does not support this call
                        //Prevent future calling
                        _isSystemAbleToLoadShield = false;
                    }
                }

                NativeMethods.SendMessage(this.Handle, BCM_SETSHIELD, IntPtr.Zero, new IntPtr(1));
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
                else if (_assemblyToElevate != null && !MissingFrameWorkAPIs.IsNullOrWhiteSpace(_extraArguments))
                {
                    ExecuteProcessAsAdministratorEventArgs administrativeTaskWithExtraArguments = new ExecuteProcessAsAdministratorEventArgs(Path.GetFullPath(_assemblyToElevate.Location), _extraArguments);

                    OnExecuteProcessAsAdministrator(this, administrativeTaskWithExtraArguments);
                }
                else if (!MissingFrameWorkAPIs.IsNullOrWhiteSpace(_processName))
                {
                    ExecuteProcessAsAdministratorEventArgs administrativeTask = new ExecuteProcessAsAdministratorEventArgs(_processName);

                    OnExecuteProcessAsAdministrator(this, administrativeTask);
                }
                else if (!MissingFrameWorkAPIs.IsNullOrWhiteSpace(_processName) && !MissingFrameWorkAPIs.IsNullOrWhiteSpace(_extraArguments))
                {
                    ExecuteProcessAsAdministratorEventArgs administrativeTaskWithExtraArguments = new ExecuteProcessAsAdministratorEventArgs(_processName, _extraArguments);

                    OnExecuteProcessAsAdministrator(this, administrativeTaskWithExtraArguments);
                }
            }

            base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        #endregion
    }
}