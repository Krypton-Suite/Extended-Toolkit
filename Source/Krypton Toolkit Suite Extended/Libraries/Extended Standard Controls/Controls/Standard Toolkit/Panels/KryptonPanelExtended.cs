using ComponentFactory.Krypton.Toolkit;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExtendedStandardControls
{
    [ToolboxBitmap(typeof(KryptonPanel))]
    public class KryptonPanelExtended : KryptonPanel
    {
        #region Variables
        private Color _stateCommonBackGroundColourOne, _stateCommonBackGroundColourTwo,
                     _stateDisabledBackGroundColourOne, _stateDisabledBackGroundColourTwo,
                     _stateNormalBackGroundColourOne, _stateNormalBackGroundColourTwo;

        private Image _image;
        #endregion

        #region Properties

        #region State Common
        public Color StateCommonBackGroundColourOne { get => _stateCommonBackGroundColourOne; set { _stateCommonBackGroundColourOne = value; Invalidate(); } }

        public Color StateCommonBackGroundColourTwo { get => _stateCommonBackGroundColourTwo; set { _stateCommonBackGroundColourTwo = value; Invalidate(); } }
        #endregion

        #region State Disabled
        public Color StateDisabledBackGroundColourOne { get => _stateDisabledBackGroundColourOne; set { _stateDisabledBackGroundColourOne = value; Invalidate(); } }

        public Color StateDisabledBackGroundColourTwo { get => _stateDisabledBackGroundColourTwo; set { _stateDisabledBackGroundColourTwo = value; Invalidate(); } }
        #endregion

        #region State Normal
        public Color StateNormalBackGroundColourOne { get => _stateNormalBackGroundColourOne; set { _stateNormalBackGroundColourOne = value; Invalidate(); } }

        public Color StateNormalBackGroundColourTwo { get => _stateNormalBackGroundColourTwo; set { _stateNormalBackGroundColourTwo = value; Invalidate(); } }
        #endregion

        public Image Image { get => _image; set { _image = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonPanelExtended()
        {
            StateCommonBackGroundColourOne = Color.Empty;

            StateCommonBackGroundColourTwo = Color.Empty;

            StateDisabledBackGroundColourOne = Color.Empty;

            StateDisabledBackGroundColourTwo = Color.Empty;

            StateNormalBackGroundColourOne = Color.Empty;

            StateNormalBackGroundColourTwo = Color.Empty;

            Image = null;

            UpdateStateCommonAppearanceValues(StateCommonBackGroundColourOne, StateCommonBackGroundColourTwo, Image);

            UpdateStateDisabledAppearanceValues(StateDisabledBackGroundColourOne, StateDisabledBackGroundColourTwo, Image);

            UpdateStateNormalAppearanceValues(StateNormalBackGroundColourOne, StateNormalBackGroundColourTwo, Image);
        }
        #endregion

        #region Method
        private void UpdateStateCommonAppearanceValues(Color backGroundColourOne, Color backGroundColourTwo, Image image)
        {
            StateCommon.Color1 = backGroundColourOne;

            StateCommon.Color2 = backGroundColourTwo;

            StateCommon.Image = image;
        }

        private void UpdateStateDisabledAppearanceValues(Color backGroundColourOne, Color backGroundColourTwo, Image image)
        {
            StateDisabled.Color1 = backGroundColourOne;

            StateDisabled.Color2 = backGroundColourTwo;

            StateDisabled.Image = image;
        }

        private void UpdateStateNormalAppearanceValues(Color backGroundColourOne, Color backGroundColourTwo, Image image)
        {
            StateNormal.Color1 = backGroundColourOne;

            StateNormal.Color2 = backGroundColourTwo;

            StateNormal.Image = image;
        }
        #endregion

        #region Override
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateStateCommonAppearanceValues(StateCommonBackGroundColourOne, StateCommonBackGroundColourTwo, Image);

            UpdateStateDisabledAppearanceValues(StateDisabledBackGroundColourOne, StateDisabledBackGroundColourTwo, Image);

            UpdateStateNormalAppearanceValues(StateNormalBackGroundColourOne, StateNormalBackGroundColourTwo, Image);

            base.OnPaint(e);
        }
        #endregion
    }
}