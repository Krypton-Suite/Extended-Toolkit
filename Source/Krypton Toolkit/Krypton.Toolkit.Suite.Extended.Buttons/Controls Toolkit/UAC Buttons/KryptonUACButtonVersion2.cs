#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    [Designer(typeof(KryptonUACButtonDesigner)), DesignerCategory("code"), ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonUACButtonVersion2 : KryptonButton
    {
        #region Variables
        private bool _useAsUACElevatedButton, _elevateOnClick;

        private string _pathToElevatedObject, _extraArguments;

        private Size _customShieldSize;

        private GlobalMethods _globalMethods = new GlobalMethods();

        private UtilityMethods _utilityMethods = new UtilityMethods();

        private UACShieldSize _shieldSize;
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

        public string PathToElevatedObject { get => _pathToElevatedObject; set => _pathToElevatedObject = value; }

        public string ExtraArguments { get => _extraArguments; set => _extraArguments = value; }

        public Size CustomShieldSize { get => _customShieldSize; set { _customShieldSize = value; ShowUACShield(_useAsUACElevatedButton, UACShieldSize.CUSTOM, value.Height, value.Width); UACShieldSize = UACShieldSize.CUSTOM; } }

        [DefaultValue(typeof(UACShieldSize), "UACShieldSize.SMALL")]
        public UACShieldSize UACShieldSize { get => _shieldSize; set { _shieldSize = value; ShowUACShield(_useAsUACElevatedButton, value); } }
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
            _shieldSize = UACShieldSize.SMALL;
        }
        #endregion

        #region Methods
        /// <summary>Shows the uac shield.</summary>
        /// <param name="showUACShield">if set to <c>true</c> [show uac shield].</param>
        private void ShowUACShield(bool showUACShield, UACShieldSize shieldSize = UACShieldSize.SMALL, int? height = null, int? width = null)
        {
            int h = height ?? 16, w = width ?? 16;

            if (showUACShield)
            {
                //Values.Image = SystemIcons.Shield.ToBitmap();

                if (shieldSize == UACShieldSize.SMALL)
                {
                    Values.Image = IconExtractor.LoadIcon(IconExtractor.IconType.Shield, SystemInformation.SmallIconSize).ToBitmap();

                    Invalidate();
                }
                else if (shieldSize == UACShieldSize.MEDIUM)
                {
                    Image shield = SystemIcons.Shield.ToBitmap();

                    Values.Image = UtilityMethods.ResizeImage(shield, 32, 32);

                    Invalidate();
                }
                else if (shieldSize == UACShieldSize.LARGE)
                {
                    Image shield = SystemIcons.Shield.ToBitmap();

                    Values.Image = UtilityMethods.ResizeImage(shield, 64, 64);

                    Invalidate();
                }
                else if (shieldSize == UACShieldSize.CUSTOM)
                {
                    Image shield = SystemIcons.Shield.ToBitmap();

                    Values.Image = UtilityMethods.ResizeImage(shield, w, h);
                }
            }
            else
            {
                Values.Image = null;
            }

            _elevateOnClick = showUACShield;
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            //if (_useAsUACElevatedButton)
            //{
            //    //Values.Image = SystemIcons.Shield.ToBitmap();

            //    if (_shieldSize == UACShieldSize.SMALL)
            //    {
            //        Values.Image = IconExtractor.LoadIcon(IconExtractor.IconType.Shield, SystemInformation.SmallIconSize).ToBitmap();
            //    }
            //    else if (_shieldSize == UACShieldSize.MEDIUM)
            //    {
            //        Image shield = SystemIcons.Shield.ToBitmap();

            //        Values.Image = UtilityMethods.ResizeImage(shield, 32, 32);
            //    }
            //    else if (_shieldSize == UACShieldSize.LARGE)
            //    {
            //        Image shield = SystemIcons.Shield.ToBitmap();

            //        Values.Image = UtilityMethods.ResizeImage(shield, 64, 64);
            //    }
            //}

            base.OnPaint(e);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }
        #endregion
    }
}