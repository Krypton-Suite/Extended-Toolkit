using System;
using System.ComponentModel;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    [Designer(typeof(KryptonUACButtonDesigner)), DesignerCategory("code"), ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonUACButtonVersion2 : KryptonButton
    {
        #region Variables
        private bool _useAsUACElevatedButton, _elevateOnClick;

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
        public KryptonUACButtonVersion2() : base()
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
            base.OnClick(e);
        }
        #endregion
    }
}