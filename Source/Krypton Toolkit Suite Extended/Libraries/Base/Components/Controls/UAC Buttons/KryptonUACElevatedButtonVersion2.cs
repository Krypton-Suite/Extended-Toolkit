#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Common;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    [Designer(typeof(KryptonUACButtonDesigner)), DesignerCategory("code"), ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonUACElevatedButtonVersion2 : KryptonButton
    {
        #region Variables
        private bool _useAsUACElevatedButton, _elevateOnClick;

        private object _objectToElevate;

        private string _pathToElevatedObject, _extraArguments;

        private GlobalMethods _globalMethods = new GlobalMethods();

        private UtilityMethods _utilityMethods = new UtilityMethods();
        #endregion

        #region Properties
        public bool UseAsUACElevatedButton
        {
            get => _useAsUACElevatedButton;

            set
            {
                _useAsUACElevatedButton = value;

                ShowUACShield(value);
            }
        }

        //public object ObjectToElevate { get => _objectToElevate; set => _objectToElevate = value; }

        public string PathToElevatedObject { get => _pathToElevatedObject; set => _pathToElevatedObject = value; }

        public string ExtraArguments { get => _extraArguments; set => _extraArguments = value; }
        #endregion

        #region Event
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
        public KryptonUACElevatedButtonVersion2() : base()
        {

        }
        #endregion

        #region Methods
        private void ShowUACShield(bool showUACShield)
        {
            if (showUACShield)
            {
                Values.Image = SystemIcons.Shield.ToBitmap();
            }
            else
            {
                Values.Image = null;
            }

            _elevateOnClick = showUACShield;
        }
        #endregion

        #region Overrides
        protected override void OnClick(EventArgs e)
        {
            if (_extraArguments == null)
            {
                //ExecuteProcessAsAdministratorEventArgs ea = new ExecuteProcessAsAdministratorEventArgs(_pathToElevatedObject, _extraArguments);

                //OnExecuteProcessAsAdministrator(this, ea);
            }
            else
            {
                ExecuteProcessAsAdministratorEventArgs evnt = new ExecuteProcessAsAdministratorEventArgs(_pathToElevatedObject);

                OnExecuteProcessAsAdministrator(this, evnt);
            }

            base.OnClick(e);
        }
        #endregion
    }
}
