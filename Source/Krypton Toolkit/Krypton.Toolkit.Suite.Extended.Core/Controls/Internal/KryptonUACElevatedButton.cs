#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Common;
using Krypton.Toolkit.Suite.Extended.Global.Utilities;

using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    /// <summary>
    /// A standard Krypton button control with UAC shield
    /// Modified from the AeroSuite project.
    /// </summary>
    /// <remarks>
    /// The shield is extracted from the system with LoadImage if possible. Otherwise the shield will be enabled by sending the BCM_SETSHIELD Message to the control.
    /// If the operating system is not Windows Vista or higher, no shield will be displayed as there's no such thing as UAC on the target system -> the shield is obsolete.
    /// </remarks>
    [DesignerCategory("code"), Description("Krypton UAC Elevated Button"), ToolboxBitmap(typeof(KryptonButton), "ToolboxBitmaps.UACButton.bmp"), ToolboxItem(true)]
    internal partial class KryptonUACElevatedButton : KryptonButton
    {
        #region Variables
        private Assembly _processToElevate;

        private bool _elevateApplicationOnClick = true, _showUACShield = true;

        private string _processName = string.Empty;

        private static bool? _isSystemAbleToLoadShield = null;

        private const int BCM_SETSHIELD = 0x160C;

        private GlobalMethods _globalMethods = new GlobalMethods();

        private UtilityMethods _utilityMethods = new UtilityMethods();
        #endregion

        #region Properties
        /// <summary>Gets or sets the process to elevate.</summary>
        /// <value>The process to elevate.</value>
        public Assembly ProcessToElevate { get => _processToElevate; set => _processToElevate = value; }

        /// <summary>
        /// Elevates the current running application to administrator level when button is clicked.
        /// </summary>
        /// <remarks>
        /// The application/process will restart when clicked.
        /// </remarks>
        [Category("Code"), Description("Elevates the current running application to administrator level when button is clicked. The application/process will restart when clicked."), DefaultValue(true)]
        public bool ElevateApplicationOnClick { get => _elevateApplicationOnClick; set => _elevateApplicationOnClick = value; }

        /// <summary>Gets or sets a value indicating whether [show uac shield].</summary>
        /// <value>
        ///   <c>true</c> if [show uac shield]; otherwise, <c>false</c>.</value>
        public bool ShowUACShield { get => _showUACShield; set { _showUACShield = value; Invalidate(); } }

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
        public ExecuteProcessAsAdministratorEventHandler ExecuteProcessAsAdministrator;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialises a new instance of the <see cref="KryptonUACElevatedButton"/> class.
        /// </summary>
        public KryptonUACElevatedButton() : base()
        {
            Size = new Size((int)(Width * 1.5), Height + 1);

            _globalMethods.CheckIfTargetPlatformIsSupported(true);

            if (_globalMethods.GetIsTargetPlatformSupported())
            {
                if (!_isSystemAbleToLoadShield.HasValue || _isSystemAbleToLoadShield.Value)
                {
                    try
                    {
                        // TODO: Fix this
                        /*
                        var _icon = IconExtractor.LoadIcon(IconType.SHIELD, SystemInformation.SmallIconSize);

                        if (_icon != null)
                        {
                            Values.Image = _icon.ToBitmap();

                            //this.TextImageRelation = TextImageRelation.ImageBeforeText;

                            //Values.Image.ImageAlign = ContentAlignment.MiddleCenter;

                            _isSystemAbleToLoadShield = true;

                            return;
                        }
                        else
                        {
                            _isSystemAbleToLoadShield = false;
                        }
                        */
                    }
                    catch (Exception exc)
                    {
                        CoreInternalKryptonMessageBoxExtended.Show($"Your platform is unsupported. Please contact the software vendor for details.\nFor reference, your system is running: { _globalMethods.GetOSFriendlyName() }.\nException message: { exc.Message }.", "Unsupported Software", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        _isSystemAbleToLoadShield = false;
                    }
                }

                //FlatStyle = FlatStyle.System;

                CommonNativeMethods.SendMessage(Handle, BCM_SETSHIELD, IntPtr.Zero, new IntPtr(1));
            }
        }
        #endregion

        #region Overrides
        /// <summary>Raises the Click event.</summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            ExecuteProcessAsAdministratorEventArgs evt = new ExecuteProcessAsAdministratorEventArgs(ProcessName);

            OnExecuteProcessAsAdministrator(this, evt);

            base.OnClick(e);
        }

        /// <summary>Raises the Paint event.</summary>
        /// <param name="e">A PaintEventArgs that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        #endregion

        #region Methods
        /// <summary>Captures the exception.</summary>
        /// <param name="exception">The exception.</param>
        /// <param name="currentWindow">The current window.</param>
        /// <param name="control">The control.</param>
        /// <param name="title">The title.</param>
        /// <param name="buttons">The buttons.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="methodSignature">The method signature.</param>
        /// <param name="defaultTypeface">The default typeface.</param>
        private static void CaptureException(Exception exception, KryptonForm currentWindow, Control control = null, string title = @"Exception Caught", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Error, string className = "", string methodSignature = "", Font defaultTypeface = null)
        {
            defaultTypeface = new Font(currentWindow.Font.FontFamily, currentWindow.Font.Size, currentWindow.Font.Style, currentWindow.Font.Unit);

            if (className != "")
            {
                CoreInternalKryptonMessageBoxExtended.Show($"An unexpected error has occurred: { exception.Message }.\n\nError in class: '{ className }.cs'.", title, buttons, icon, messageboxTypeface: defaultTypeface);
            }
            else if (methodSignature != "")
            {
                CoreInternalKryptonMessageBoxExtended.Show($"An unexpected error has occurred: { exception.Message }.\n\nError in method: '{ methodSignature }'.", title, buttons, icon, messageboxTypeface: defaultTypeface);
            }
            else if (className != "" && methodSignature != "")
            {
                CoreInternalKryptonMessageBoxExtended.Show($"An unexpected error has occurred: { exception.Message }.\n\nError in class: '{ className }.cs'.\n\nError in method: '{ methodSignature }'.", title, buttons, icon, messageboxTypeface: defaultTypeface);
            }
            else
            {
                CoreInternalKryptonMessageBoxExtended.Show($"An unexpected error has occurred: { exception.Message }.", title, buttons, icon, messageboxTypeface: defaultTypeface);
            }
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