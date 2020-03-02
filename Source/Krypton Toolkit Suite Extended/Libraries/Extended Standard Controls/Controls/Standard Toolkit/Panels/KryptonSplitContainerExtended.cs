using ComponentFactory.Krypton.Toolkit;
using System.Drawing;
using System.Windows.Forms;

namespace ExtendedStandardControls
{
    [ToolboxBitmap(typeof(KryptonSplitContainer))]
    public class KryptonSplitContainerExtended : KryptonSplitContainer
    {
        #region Variables
        private Color _stateCommonBackGroundColourOne, _stateCommonBackGroundColourTwo, _stateCommonSplitterColourOne, _stateCommonSplitterColourTwo,
                      _stateDisabledBackGroundColourOne, _stateDisabledBackGroundColourTwo, _stateDisabledSplitterColourOne, _stateDisabledSplitterColourTwo,
                      _stateNormalBackGroundColourOne, _stateNormalBackGroundColourTwo, _stateNormalSplitterColourOne, _stateNormalSplitterColourTwo,
                      _statePressedBackGroundColourOne, _statePressedBackGroundColourTwo,
                      _stateTrackingBackGroundColourOne, _stateTrackingBackGroundColourTwo;
        #endregion

        #region Properties

        #region State Common
        public Color StateCommonBackGroundColourOne { get => _stateCommonBackGroundColourOne; set { _stateCommonBackGroundColourOne = value; Invalidate(); } }

        public Color StateCommonBackGroundColourTwo { get => _stateCommonBackGroundColourTwo; set { _stateCommonBackGroundColourTwo = value; Invalidate(); } }

        public Color StateCommonSplitterColourOne { get => _stateCommonSplitterColourOne; set { _stateCommonSplitterColourOne = value; Invalidate(); } }

        public Color StateCommonSplitterColourTwo { get => _stateCommonSplitterColourTwo; set { _stateCommonSplitterColourTwo = value; Invalidate(); } }
        #endregion

        #region State Disabled
        public Color StateDisabledBackGroundColourOne { get => _stateDisabledBackGroundColourOne; set { _stateDisabledBackGroundColourOne = value; Invalidate(); } }

        public Color StateDisabledBackGroundColourTwo { get => _stateDisabledBackGroundColourTwo; set { _stateDisabledBackGroundColourTwo = value; Invalidate(); } }

        public Color StateDisabledSplitterColourOne { get => _stateDisabledSplitterColourOne; set { _stateDisabledSplitterColourOne = value; Invalidate(); } }

        public Color StateDisabledSplitterColourTwo { get => _stateDisabledSplitterColourTwo; set { _stateDisabledSplitterColourTwo = value; Invalidate(); } }
        #endregion

        #region State Normal
        public Color StateNormalBackGroundColourOne { get => _stateNormalBackGroundColourOne; set { _stateNormalBackGroundColourOne = value; Invalidate(); } }

        public Color StateNormalBackGroundColourTwo { get => _stateNormalBackGroundColourTwo; set { _stateNormalBackGroundColourTwo = value; Invalidate(); } }

        public Color StateNormalSplitterColourOne { get => _stateNormalSplitterColourOne; set { _stateNormalSplitterColourOne = value; Invalidate(); } }

        public Color StateNormalSplitterColourTwo { get => _stateNormalSplitterColourTwo; set { _stateNormalSplitterColourTwo = value; Invalidate(); } }
        #endregion

        #region State Pressed
        public Color StatePressedBackGroundColourOne { get => _statePressedBackGroundColourOne; set { _statePressedBackGroundColourOne = value; Invalidate(); } }

        public Color StatePressedBackGroundColourTwo { get => _statePressedBackGroundColourTwo; set { _statePressedBackGroundColourTwo = value; Invalidate(); } }
        #endregion

        #region State Tracking
        public Color StateTrackingBackGroundColourOne { get => _stateTrackingBackGroundColourOne; set { _stateTrackingBackGroundColourOne = value; Invalidate(); } }

        public Color StateTrackingBackGroundColourTwo { get => _stateTrackingBackGroundColourTwo; set { _stateTrackingBackGroundColourTwo = value; Invalidate(); } }
        #endregion

        #endregion

        #region Constructor
        public KryptonSplitContainerExtended()
        {
            StateCommonBackGroundColourOne = Color.Empty;

            StateCommonBackGroundColourTwo = Color.Empty;

            StateCommonSplitterColourOne = Color.Empty;

            StateCommonSplitterColourTwo = Color.Empty;

            StateDisabledBackGroundColourOne = Color.Empty;

            StateDisabledBackGroundColourTwo = Color.Empty;

            StateDisabledSplitterColourOne = Color.Empty;

            StateDisabledSplitterColourTwo = Color.Empty;

            StateNormalBackGroundColourOne = Color.Empty;

            StateNormalBackGroundColourTwo = Color.Empty;

            StateNormalSplitterColourOne = Color.Empty;

            StateNormalSplitterColourTwo = Color.Empty;

            StatePressedBackGroundColourOne = Color.Empty;

            StatePressedBackGroundColourTwo = Color.Empty;

            StateTrackingBackGroundColourOne = Color.Empty;

            StateTrackingBackGroundColourTwo = Color.Empty;

            UpdateStateCommonAppearanceValues(StateCommonBackGroundColourOne, StateCommonBackGroundColourTwo, StateCommonSplitterColourOne, StateCommonSplitterColourTwo);

            UpdateStateDisabledAppearanceValues(StateDisabledBackGroundColourOne, StateDisabledBackGroundColourTwo, StateDisabledSplitterColourOne, StateDisabledSplitterColourTwo);

            UpdateStateNormalAppearanceValues(StateNormalBackGroundColourOne, StateNormalBackGroundColourTwo, StateNormalSplitterColourOne, StateNormalSplitterColourTwo);

            UpdateStatePressedAppearanceValues(StatePressedBackGroundColourOne, StatePressedBackGroundColourTwo);

            UpdateStateTrackingAppearanceValues(StateTrackingBackGroundColourOne, StateTrackingBackGroundColourTwo);
        }
        #endregion

        #region Method
        private void UpdateStateCommonAppearanceValues(Color commonBackGroundColourOne, Color commonBackGroundColourTwo, Color commonSplitterColourOne, Color commonSplitterColourTwo)
        {
            StateCommon.Back.Color1 = commonBackGroundColourOne;

            StateCommon.Back.Color2 = commonBackGroundColourTwo;

            StateCommon.Separator.Back.Color1 = commonSplitterColourOne;

            StateCommon.Separator.Back.Color2 = commonSplitterColourTwo;
        }

        private void UpdateStateDisabledAppearanceValues(Color commonBackGroundColourOne, Color commonBackGroundColourTwo, Color commonSplitterColourOne, Color commonSplitterColourTwo)
        {
            StateDisabled.Back.Color1 = commonBackGroundColourOne;

            StateDisabled.Back.Color2 = commonBackGroundColourTwo;

            StateDisabled.Separator.Back.Color1 = commonSplitterColourOne;

            StateDisabled.Separator.Back.Color2 = commonSplitterColourTwo;
        }

        private void UpdateStateNormalAppearanceValues(Color commonBackGroundColourOne, Color commonBackGroundColourTwo, Color commonSplitterColourOne, Color commonSplitterColourTwo)
        {
            StateNormal.Back.Color1 = commonBackGroundColourOne;

            StateNormal.Back.Color2 = commonBackGroundColourTwo;

            StateNormal.Separator.Back.Color1 = commonSplitterColourOne;

            StateNormal.Separator.Back.Color2 = commonSplitterColourTwo;
        }

        private void UpdateStatePressedAppearanceValues(Color commonBackGroundColourOne, Color commonBackGroundColourTwo)
        {
            StatePressed.Back.Color1 = commonBackGroundColourOne;

            StatePressed.Back.Color2 = commonBackGroundColourTwo;
        }

        private void UpdateStateTrackingAppearanceValues(Color commonBackGroundColourOne, Color commonBackGroundColourTwo)
        {
            StateTracking.Back.Color1 = commonBackGroundColourOne;

            StateTracking.Back.Color2 = commonBackGroundColourTwo;
        }
        #endregion

        #region Override
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateStateCommonAppearanceValues(StateCommonBackGroundColourOne, StateCommonBackGroundColourTwo, StateCommonSplitterColourOne, StateCommonSplitterColourTwo);

            UpdateStateDisabledAppearanceValues(StateDisabledBackGroundColourOne, StateDisabledBackGroundColourTwo, StateDisabledSplitterColourOne, StateDisabledSplitterColourTwo);

            UpdateStateNormalAppearanceValues(StateNormalBackGroundColourOne, StateNormalBackGroundColourTwo, StateNormalSplitterColourOne, StateNormalSplitterColourTwo);

            UpdateStatePressedAppearanceValues(StatePressedBackGroundColourOne, StatePressedBackGroundColourTwo);

            UpdateStateTrackingAppearanceValues(StateTrackingBackGroundColourOne, StateTrackingBackGroundColourTwo);

            base.OnPaint(e);
        }
        #endregion
    }
}