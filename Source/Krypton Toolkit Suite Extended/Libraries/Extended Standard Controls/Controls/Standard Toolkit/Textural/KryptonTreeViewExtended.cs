using ComponentFactory.Krypton.Toolkit;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ExtendedStandardControls.Controls
{
    [ToolboxBitmap(typeof(KryptonTreeView))]
    public class KryptonTreeViewExtended : KryptonTreeView
    {
        #region Variables
        //private Color _overrideFocusBackGroundColour, _overrideFocusNodeBackgroundColourOne, _overrideFocusNodeBackgroundColourTwo, _overrideFocusNodeLongTextColourOne, _overrideFocusNodeLongTextColourTwo, _overrideFocusNodeShortTextColourOne, _overrideFocusNodeShortTextColourTwo,
        //              _stateCheckedNormalBackGroundColour, _stateCheckedNormalNodeBackgroundColourOne, _stateCheckedNormalNodeBackgroundColourTwo, _stateCheckedNormalNodeLongTextColourOne, _stateCheckedNormalNodeLongTextColourTwo, _stateCheckedNormalNodeShortTextColourOne, _stateCheckedNormalNodeShortTextColourTwo,
        //              _stateCheckedPressedBackGroundColour, _stateCheckedPressedNodeBackgroundColourOne, _stateCheckedPressedNodeBackgroundColourTwo, _stateCheckedPressedNodeLongTextColourOne, _stateCheckedPressedNodeLongTextColourTwo, _stateCheckedPressedNodeShortTextColourOne, _stateCheckedPressedNodeShortTextColourTwo,
        //              _stateCheckedTrackingBackGroundColour, _stateCheckedTrackingNodeBackgroundColourOne, _stateCheckedTrackingNodeBackgroundColourTwo, _stateCheckedTrackingNodeLongTextColourOne, _stateCheckedTrackingNodeLongTextColourTwo, _stateCheckedTrackingNodeShortTextColourOne, _stateCheckedTrackingNodeShortTextColourTwo,
        //              _stateCommonBackGroundColour, _stateCommonNodeBackgroundColourOne, _stateCommonNodeBackgroundColourTwo, _stateCommonNodeLongTextColourOne, _stateCommonNodeLongTextColourTwo, _stateCommonNodeShortTextColourOne, _stateCommonNodeShortTextColourTwo,
        //              _stateDisabledBackGroundColour, _stateDisabledNodeBackgroundColourOne, _stateDisabledNodeBackgroundColourTwo, _stateDisabledNodeLongTextColourOne, _stateDisabledNodeLongTextColourTwo, _stateDisabledNodeShortTextColourOne, _stateDisabledNodeShortTextColourTwo,
        //              _stateNormalBackGroundColour, _stateNormalNodeBackgroundColourOne, _stateNormalNodeBackgroundColourTwo, _stateNormalNodeLongTextColourOne, _stateNormalNodeLongTextColourTwo, _stateNormalNodeShortTextColourOne, _stateNormalNodeShortTextColourTwo,
        //              _statePressedBackGroundColour, _statePressedNodeBackgroundColourOne, _statePressedNodeBackgroundColourTwo, _statePressedNodeLongTextColourOne, _statePressedNodeLongTextColourTwo, _statePressedNodeShortTextColourOne, _statePressedNodeShortTextColourTwo,
        //              _stateTrackingBackGroundColour, _stateTrackingNodeBackgroundColourOne, _stateTrackingNodeBackgroundColourTwo, _stateTrackingNodeLongTextColourOne, _stateTrackingNodeLongTextColourTwo, _stateTrackingNodeShortTextColourOne, _stateTrackingNodeShortTextColourTwo;
        private Color _overrideFocusItemBackgroundColourOne, _overrideFocusItemBackgroundColourTwo, _overrideFocusLongTextBackgroundColourOne, _overrideFocusLongTextBackgroundColourTwo, _overrideFocusShortTextBackgroundColourOne, _overrideFocusShortTextBackgroundColourTwo, _overrideFocusLongTextColourOne, _overrideFocusLongTextColourTwo, _overrideFocusShortTextColourOne, _overrideFocusShortTextColourTwo,
                      _stateActiveBackgroundColourOne, _stateActiveBackgroundColourTwo, _stateActiveBorderColourOne, _stateActiveBorderColourTwo,
                      _stateCheckedNormalItemBackgroundColourOne, _stateCheckedNormalItemBackgroundColourTwo, _stateCheckedNormalLongTextBackgroundColourOne, _stateCheckedNormalLongTextBackgroundColourTwo, _stateCheckedNormalShortTextBackgroundColourOne, _stateCheckedNormalShortTextBackgroundColourTwo, _stateCheckedNormalLongTextColourOne, _stateCheckedNormalLongTextColourTwo, _stateCheckedNormalShortTextColourOne, _stateCheckedNormalShortTextColourTwo,
                      _stateCheckedPressedItemBackgroundColourOne, _stateCheckedPressedItemBackgroundColourTwo, _stateCheckedPressedLongTextBackgroundColourOne, _stateCheckedPressedLongTextBackgroundColourTwo, _stateCheckedPressedShortTextBackgroundColourOne, _stateCheckedPressedShortTextBackgroundColourTwo, _stateCheckedPressedLongTextColourOne, _stateCheckedPressedLongTextColourTwo, _stateCheckedPressedShortTextColourOne, _stateCheckedPressedShortTextColourTwo,
                      _stateCheckedTrackingItemBackgroundColourOne, _stateCheckedTrackingItemBackgroundColourTwo, _stateCheckedTrackingLongTextBackgroundColourOne, _stateCheckedTrackingLongTextBackgroundColourTwo, _stateCheckedTrackingShortTextBackgroundColourOne, _stateCheckedTrackingShortTextBackgroundColourTwo, _stateCheckedTrackingLongTextColourOne, _stateCheckedTrackingLongTextColourTwo, _stateCheckedTrackingShortTextColourOne, _stateCheckedTrackingShortTextColourTwo,
                      _stateCommonBackgroundColourOne, _stateCommonBackgroundColourTwo, _stateCommonItemBackgroundColourOne, _stateCommonItemBackgroundColourTwo, _stateCommonLongTextBackgroundColourOne, _stateCommonLongTextBackgroundColourTwo, _stateCommonShortTextBackgroundColourOne, _stateCommonShortTextBackgroundColourTwo, _stateCommonLongTextColourOne, _stateCommonLongTextColourTwo, _stateCommonShortTextColourOne, _stateCommonShortTextColourTwo, _stateCommonBorderColourOne, _stateCommonBorderColourTwo,
                      _stateDisabledBackgroundColourOne, _stateDisabledBackgroundColourTwo, _stateDisabledItemBackgroundColourOne, _stateDisabledItemBackgroundColourTwo, _stateDisabledLongTextBackgroundColourOne, _stateDisabledLongTextBackgroundColourTwo, _stateDisabledShortTextBackgroundColourOne, _stateDisabledShortTextBackgroundColourTwo, _stateDisabledLongTextColourOne, _stateDisabledLongTextColourTwo, _stateDisabledShortTextColourOne, _stateDisabledShortTextColourTwo, _stateDisabledBorderColourOne, _stateDisabledBorderColourTwo,
                      _stateNormalBackgroundColourOne, _stateNormalBackgroundColourTwo, _stateNormalItemBackgroundColourOne, _stateNormalItemBackgroundColourTwo, _stateNormalLongTextBackgroundColourOne, _stateNormalLongTextBackgroundColourTwo, _stateNormalShortTextBackgroundColourOne, _stateNormalShortTextBackgroundColourTwo, _stateNormalLongTextColourOne, _stateNormalLongTextColourTwo, _stateNormalShortTextColourOne, _stateNormalShortTextColourTwo, _stateNormalBorderColourOne, _stateNormalBorderColourTwo,
                      _statePressedItemBackgroundColourOne, _statePressedItemBackgroundColourTwo, _statePressedLongTextBackgroundColourOne, _statePressedLongTextBackgroundColourTwo, _statePressedShortTextBackgroundColourOne, _statePressedShortTextBackgroundColourTwo, _statePressedLongTextColourOne, _statePressedLongTextColourTwo, _statePressedShortTextColourOne, _statePressedShortTextColourTwo,
                      _stateTrackingItemBackgroundColourOne, _stateTrackingItemBackgroundColourTwo, _stateTrackingLongTextBackgroundColourOne, _stateTrackingLongTextBackgroundColourTwo, _stateTrackingShortTextBackgroundColourOne, _stateTrackingShortTextBackgroundColourTwo, _stateTrackingLongTextColourOne, _stateTrackingLongTextColourTwo, _stateTrackingShortTextColourOne, _stateTrackingShortTextColourTwo;

        private Font _longTextTypeface, _shortTextTypeface;
        #endregion

        #region Properties

        #region Old Code
        /*
        #region Override Focus
        public Color OverrideFocusBackgroundColour { get => _overrideFocusBackGroundColour; set { _overrideFocusBackGroundColour = value; Invalidate(); } }

        public Color OverrideFocusNodeBackgroundColourOne { get => _overrideFocusNodeBackgroundColourOne; set { _overrideFocusNodeBackgroundColourOne = value; Invalidate(); } }

        public Color OverrideFocusNodeBackgroundColourTwo { get => _overrideFocusNodeBackgroundColourTwo; set { _overrideFocusNodeBackgroundColourTwo = value; Invalidate(); } }

        public Color OverrideFocusNodeLongTextColourOne { get => _overrideFocusNodeLongTextColourOne; set { _overrideFocusNodeLongTextColourOne = value; Invalidate(); } }

        public Color OverrideFocusNodeLongTextColourTwo { get => _overrideFocusNodeLongTextColourTwo; set { _overrideFocusNodeLongTextColourTwo = value; Invalidate(); } }

        public Color OverrideFocusNodeShortTextColourOne { get => _overrideFocusNodeShortTextColourOne; set { _overrideFocusNodeShortTextColourOne = value; Invalidate(); } }

        public Color OverrideFocusNodeShortTextColourTwo { get => _overrideFocusNodeShortTextColourTwo; set { _overrideFocusNodeShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Checked Normal
        public Color StateCheckedNormalBackgroundColour { get => _stateCheckedNormalBackGroundColour; set { _stateCheckedNormalBackGroundColour = value; Invalidate(); } }

        public Color StateCheckedNormalNodeBackgroundColourOne { get => _stateCheckedNormalNodeBackgroundColourOne; set { _stateCheckedNormalNodeBackgroundColourOne = value; Invalidate(); } }

        public Color StateCheckedNormalNodeBackgroundColourTwo { get => _stateCheckedNormalNodeBackgroundColourTwo; set { _stateCheckedNormalNodeBackgroundColourTwo = value; Invalidate(); } }

        public Color StateCheckedNormalNodeLongTextColourOne { get => _stateCheckedNormalNodeLongTextColourOne; set { _stateCheckedNormalNodeLongTextColourOne = value; Invalidate(); } }

        public Color StateCheckedNormalNodeLongTextColourTwo { get => _stateCheckedNormalNodeLongTextColourTwo; set { _stateCheckedNormalNodeLongTextColourTwo = value; Invalidate(); } }

        public Color StateCheckedNormalNodeShortTextColourOne { get => _stateCheckedNormalNodeShortTextColourOne; set { _stateCheckedNormalNodeShortTextColourOne = value; Invalidate(); } }

        public Color StateCheckedNormalNodeShortTextColourTwo { get => _stateCheckedNormalNodeShortTextColourTwo; set { _stateCheckedNormalNodeShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Checked Pressed
        public Color StateCheckedPressedBackgroundColour { get => _stateCheckedPressedBackGroundColour; set { _stateCheckedPressedBackGroundColour = value; Invalidate(); } }

        public Color StateCheckedPressedNodeBackgroundColourOne { get => _stateCheckedPressedNodeBackgroundColourOne; set { _stateCheckedPressedNodeBackgroundColourOne = value; Invalidate(); } }

        public Color StateCheckedPressedNodeBackgroundColourTwo { get => _stateCheckedPressedNodeBackgroundColourTwo; set { _stateCheckedPressedNodeBackgroundColourTwo = value; Invalidate(); } }

        public Color StateCheckedPressedNodeLongTextColourOne { get => _stateCheckedPressedNodeLongTextColourOne; set { _stateCheckedPressedNodeLongTextColourOne = value; Invalidate(); } }

        public Color StateCheckedPressedNodeLongTextColourTwo { get => _stateCheckedPressedNodeLongTextColourTwo; set { _stateCheckedPressedNodeLongTextColourTwo = value; Invalidate(); } }

        public Color StateCheckedPressedNodeShortTextColourOne { get => _stateCheckedPressedNodeShortTextColourOne; set { _stateCheckedPressedNodeShortTextColourOne = value; Invalidate(); } }

        public Color StateCheckedPressedNodeShortTextColourTwo { get => _stateCheckedPressedNodeShortTextColourTwo; set { _stateCheckedPressedNodeShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Checked Tracking
        public Color StateCheckedTrackingBackgroundColour { get => _stateCheckedTrackingBackGroundColour; set { _stateCheckedTrackingBackGroundColour = value; Invalidate(); } }

        public Color StateCheckedTrackingNodeBackgroundColourOne { get => _stateCheckedTrackingNodeBackgroundColourOne; set { _stateCheckedTrackingNodeBackgroundColourOne = value; Invalidate(); } }

        public Color StateCheckedTrackingNodeBackgroundColourTwo { get => _stateCheckedTrackingNodeBackgroundColourTwo; set { _stateCheckedTrackingNodeBackgroundColourTwo = value; Invalidate(); } }

        public Color StateCheckedTrackingNodeLongTextColourOne { get => _stateCheckedTrackingNodeLongTextColourOne; set { _stateCheckedTrackingNodeLongTextColourOne = value; Invalidate(); } }

        public Color StateCheckedTrackingNodeLongTextColourTwo { get => _stateCheckedTrackingNodeLongTextColourTwo; set { _stateCheckedTrackingNodeLongTextColourTwo = value; Invalidate(); } }

        public Color StateCheckedTrackingNodeShortTextColourOne { get => _stateCheckedTrackingNodeShortTextColourOne; set { _stateCheckedTrackingNodeShortTextColourOne = value; Invalidate(); } }

        public Color StateCheckedTrackingNodeShortTextColourTwo { get => _stateCheckedTrackingNodeShortTextColourTwo; set { _stateCheckedTrackingNodeShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Common
        public Color StateCommonBackgroundColour { get => _stateCommonBackGroundColour; set { _stateCommonBackGroundColour = value; Invalidate(); } }

        public Color StateCommonNodeBackgroundColourOne { get => _stateCommonNodeBackgroundColourOne; set { _stateCommonNodeBackgroundColourOne = value; Invalidate(); } }

        public Color StateCommonNodeBackgroundColourTwo { get => _stateCommonNodeBackgroundColourTwo; set { _stateCommonNodeBackgroundColourTwo = value; Invalidate(); } }

        public Color StateCommonNodeLongTextColourOne { get => _stateCommonNodeLongTextColourOne; set { _stateCommonNodeLongTextColourOne = value; Invalidate(); } }

        public Color StateCommonNodeLongTextColourTwo { get => _stateCommonNodeLongTextColourTwo; set { _stateCommonNodeLongTextColourTwo = value; Invalidate(); } }

        public Color StateCommonNodeShortTextColourOne { get => _stateCommonNodeShortTextColourOne; set { _stateCommonNodeShortTextColourOne = value; Invalidate(); } }

        public Color StateCommonNodeShortTextColourTwo { get => _stateCommonNodeShortTextColourTwo; set { _stateCommonNodeShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Disabled
        public Color StateDisabledBackgroundColour { get => _stateDisabledBackGroundColour; set { _stateDisabledBackGroundColour = value; Invalidate(); } }

        public Color StateDisabledNodeBackgroundColourOne { get => _stateDisabledNodeBackgroundColourOne; set { _stateDisabledNodeBackgroundColourOne = value; Invalidate(); } }

        public Color StateDisabledNodeBackgroundColourTwo { get => _stateDisabledNodeBackgroundColourTwo; set { _stateDisabledNodeBackgroundColourTwo = value; Invalidate(); } }

        public Color StateDisabledNodeLongTextColourOne { get => _stateDisabledNodeLongTextColourOne; set { _stateDisabledNodeLongTextColourOne = value; Invalidate(); } }

        public Color StateDisabledNodeLongTextColourTwo { get => _stateDisabledNodeLongTextColourTwo; set { _stateDisabledNodeLongTextColourTwo = value; Invalidate(); } }

        public Color StateDisabledNodeShortTextColourOne { get => _stateDisabledNodeShortTextColourOne; set { _stateDisabledNodeShortTextColourOne = value; Invalidate(); } }

        public Color StateDisabledNodeShortTextColourTwo { get => _stateDisabledNodeShortTextColourTwo; set { _stateDisabledNodeShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Normal
        public Color StateNormalBackgroundColour { get => _stateNormalBackGroundColour; set { _stateNormalBackGroundColour = value; Invalidate(); } }

        public Color StateNormalNodeBackgroundColourOne { get => _stateNormalNodeBackgroundColourOne; set { _stateNormalNodeBackgroundColourOne = value; Invalidate(); } }

        public Color StateNormalNodeBackgroundColourTwo { get => _stateNormalNodeBackgroundColourTwo; set { _stateNormalNodeBackgroundColourTwo = value; Invalidate(); } }

        public Color StateNormalNodeLongTextColourOne { get => _stateNormalNodeLongTextColourOne; set { _stateNormalNodeLongTextColourOne = value; Invalidate(); } }

        public Color StateNormalNodeLongTextColourTwo { get => _stateNormalNodeLongTextColourTwo; set { _stateNormalNodeLongTextColourTwo = value; Invalidate(); } }

        public Color StateNormalNodeShortTextColourOne { get => _stateNormalNodeShortTextColourOne; set { _stateNormalNodeShortTextColourOne = value; Invalidate(); } }

        public Color StateNormalNodeShortTextColourTwo { get => _stateNormalNodeShortTextColourTwo; set { _stateNormalNodeShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Pressed
        public Color StatePressedBackgroundColour { get => _statePressedBackGroundColour; set { _statePressedBackGroundColour = value; Invalidate(); } }

        public Color StatePressedNodeBackgroundColourOne { get => _statePressedNodeBackgroundColourOne; set { _statePressedNodeBackgroundColourOne = value; Invalidate(); } }

        public Color StatePressedNodeBackgroundColourTwo { get => _statePressedNodeBackgroundColourTwo; set { _statePressedNodeBackgroundColourTwo = value; Invalidate(); } }

        public Color StatePressedNodeLongTextColourOne { get => _statePressedNodeLongTextColourOne; set { _statePressedNodeLongTextColourOne = value; Invalidate(); } }

        public Color StatePressedNodeLongTextColourTwo { get => _statePressedNodeLongTextColourTwo; set { _statePressedNodeLongTextColourTwo = value; Invalidate(); } }

        public Color StatePressedNodeShortTextColourOne { get => _statePressedNodeShortTextColourOne; set { _statePressedNodeShortTextColourOne = value; Invalidate(); } }

        public Color StatePressedNodeShortTextColourTwo { get => _statePressedNodeShortTextColourTwo; set { _statePressedNodeShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Tracking
        public Color StateTrackingBackgroundColour { get => _stateTrackingBackGroundColour; set { _stateTrackingBackGroundColour = value; Invalidate(); } }

        public Color StateTrackingNodeBackgroundColourOne { get => _stateTrackingNodeBackgroundColourOne; set { _stateTrackingNodeBackgroundColourOne = value; Invalidate(); } }

        public Color StateTrackingNodeBackgroundColourTwo { get => _stateTrackingNodeBackgroundColourTwo; set { _stateTrackingNodeBackgroundColourTwo = value; Invalidate(); } }

        public Color StateTrackingNodeLongTextColourOne { get => _stateTrackingNodeLongTextColourOne; set { _stateTrackingNodeLongTextColourOne = value; Invalidate(); } }

        public Color StateTrackingNodeLongTextColourTwo { get => _stateTrackingNodeLongTextColourTwo; set { _stateTrackingNodeLongTextColourTwo = value; Invalidate(); } }

        public Color StateTrackingNodeShortTextColourOne { get => _stateTrackingNodeShortTextColourOne; set { _stateTrackingNodeShortTextColourOne = value; Invalidate(); } }

        public Color StateTrackingNodeShortTextColourTwo { get => _stateTrackingNodeShortTextColourTwo; set { _stateTrackingNodeShortTextColourTwo = value; Invalidate(); } }
        #endregion
        */
        #endregion

        #region Override Focus
        public Color OverrideFocusItemBackgroundColourOne { get => _overrideFocusItemBackgroundColourOne; set { _overrideFocusItemBackgroundColourOne = value; Invalidate(); } }

        public Color OverrideFocusItemBackgroundColourTwo { get => _overrideFocusItemBackgroundColourTwo; set { _overrideFocusItemBackgroundColourTwo = value; Invalidate(); } }

        public Color OverrideFocusLongTextColourOne { get => _overrideFocusLongTextColourOne; set { _overrideFocusLongTextColourOne = value; Invalidate(); } }

        public Color OverrideFocusLongTextColourTwo { get => _overrideFocusLongTextColourTwo; set { _overrideFocusLongTextColourTwo = value; Invalidate(); } }

        public Color OverrideFocusShortTextColourOne { get => _overrideFocusShortTextColourOne; set { _overrideFocusShortTextColourOne = value; Invalidate(); } }

        public Color OverrideFocusShortTextColourTwo { get => _overrideFocusShortTextColourTwo; set { _overrideFocusShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Active
        public Color StateActiveBackgroundColourOne { get => _stateActiveBackgroundColourOne; set { _stateActiveBackgroundColourOne = value; Invalidate(); } }

        public Color StateActiveBackgroundColourTwo { get => _stateActiveBackgroundColourTwo; set { _stateActiveBackgroundColourTwo = value; Invalidate(); } }

        public Color StateActiveBorderColourOne { get => _stateActiveBorderColourOne; set { _stateActiveBorderColourOne = value; Invalidate(); } }

        public Color StateActiveBorderColourTwo { get => _stateActiveBorderColourTwo; set { _stateActiveBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Checked Normal
        public Color StateCheckedNormalItemBackgroundColourOne { get => _stateCheckedNormalItemBackgroundColourOne; set { _stateCheckedNormalItemBackgroundColourOne = value; Invalidate(); } }

        public Color StateCheckedNormalItemBackgroundColourTwo { get => _stateCheckedNormalItemBackgroundColourTwo; set { _stateCheckedNormalItemBackgroundColourTwo = value; Invalidate(); } }

        public Color StateCheckedNormalLongTextColourOne { get => _stateCheckedNormalLongTextColourOne; set { _stateCheckedNormalLongTextColourOne = value; Invalidate(); } }

        public Color StateCheckedNormalLongTextColourTwo { get => _stateCheckedNormalLongTextColourTwo; set { _stateCheckedNormalLongTextColourTwo = value; Invalidate(); } }

        public Color StateCheckedNormalShortTextColourOne { get => _stateCheckedNormalShortTextColourOne; set { _stateCheckedNormalShortTextColourOne = value; Invalidate(); } }

        public Color StateCheckedNormalShortTextColourTwo { get => _stateCheckedNormalShortTextColourTwo; set { _stateCheckedNormalShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Checked Pressed
        public Color StateCheckedPressedItemBackgroundColourOne { get => _stateCheckedPressedItemBackgroundColourOne; set { _stateCheckedPressedItemBackgroundColourOne = value; Invalidate(); } }

        public Color StateCheckedPressedItemBackgroundColourTwo { get => _stateCheckedPressedItemBackgroundColourTwo; set { _stateCheckedPressedItemBackgroundColourTwo = value; Invalidate(); } }

        public Color StateCheckedPressedLongTextColourOne { get => _stateCheckedPressedLongTextColourOne; set { _stateCheckedPressedLongTextColourOne = value; Invalidate(); } }

        public Color StateCheckedPressedLongTextColourTwo { get => _stateCheckedPressedLongTextColourTwo; set { _stateCheckedPressedLongTextColourTwo = value; Invalidate(); } }

        public Color StateCheckedPressedShortTextColourOne { get => _stateCheckedPressedShortTextColourOne; set { _stateCheckedPressedShortTextColourOne = value; Invalidate(); } }

        public Color StateCheckedPressedShortTextColourTwo { get => _stateCheckedPressedShortTextColourTwo; set { _stateCheckedPressedShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Checked Tracking
        public Color StateCheckedTrackingItemBackgroundColourOne { get => _stateCheckedTrackingItemBackgroundColourOne; set { _stateCheckedTrackingItemBackgroundColourOne = value; Invalidate(); } }

        public Color StateCheckedTrackingItemBackgroundColourTwo { get => _stateCheckedTrackingItemBackgroundColourTwo; set { _stateCheckedTrackingItemBackgroundColourTwo = value; Invalidate(); } }

        public Color StateCheckedTrackingLongTextColourOne { get => _stateCheckedTrackingLongTextColourOne; set { _stateCheckedTrackingLongTextColourOne = value; Invalidate(); } }

        public Color StateCheckedTrackingLongTextColourTwo { get => _stateCheckedTrackingLongTextColourTwo; set { _stateCheckedTrackingLongTextColourTwo = value; Invalidate(); } }

        public Color StateCheckedTrackingShortTextColourOne { get => _stateCheckedTrackingShortTextColourOne; set { _stateCheckedTrackingShortTextColourOne = value; Invalidate(); } }

        public Color StateCheckedTrackingShortTextColourTwo { get => _stateCheckedTrackingShortTextColourTwo; set { _stateCheckedTrackingShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Common
        public Color StateCommonBackgroundColourOne { get => _stateCommonBackgroundColourOne; set { _stateCommonBackgroundColourOne = value; Invalidate(); } }

        public Color StateCommonBackgroundColourTwo { get => _stateCommonBackgroundColourTwo; set { _stateCommonBackgroundColourTwo = value; Invalidate(); } }

        public Color StateCommonItemBackgroundColourOne { get => _stateCommonItemBackgroundColourOne; set { _stateCommonItemBackgroundColourOne = value; Invalidate(); } }

        public Color StateCommonItemBackgroundColourTwo { get => _stateCommonItemBackgroundColourTwo; set { _stateCommonItemBackgroundColourTwo = value; Invalidate(); } }

        public Color StateCommonLongTextColourOne { get => _stateCommonLongTextColourOne; set { _stateCommonLongTextColourOne = value; Invalidate(); } }

        public Color StateCommonLongTextColourTwo { get => _stateCommonLongTextColourTwo; set { _stateCommonLongTextColourTwo = value; Invalidate(); } }

        public Color StateCommonShortTextColourOne { get => _stateCommonShortTextColourOne; set { _stateCommonShortTextColourOne = value; Invalidate(); } }

        public Color StateCommonShortTextColourTwo { get => _stateCommonShortTextColourTwo; set { _stateCommonShortTextColourTwo = value; Invalidate(); } }

        public Color StateCommonBorderColourOne { get => _stateCommonBorderColourOne; set { _stateCommonBorderColourOne = value; Invalidate(); } }

        public Color StateCommonBorderColourTwo { get => _stateCommonBorderColourTwo; set { _stateCommonBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Disabled
        public Color StateDisabledBackgroundColourOne { get => _stateDisabledBackgroundColourOne; set { _stateDisabledBackgroundColourOne = value; Invalidate(); } }

        public Color StateDisabledBackgroundColourTwo { get => _stateDisabledBackgroundColourTwo; set { _stateDisabledBackgroundColourTwo = value; Invalidate(); } }

        public Color StateDisabledItemBackgroundColourOne { get => _stateDisabledItemBackgroundColourOne; set { _stateDisabledItemBackgroundColourOne = value; Invalidate(); } }

        public Color StateDisabledItemBackgroundColourTwo { get => _stateDisabledItemBackgroundColourTwo; set { _stateDisabledItemBackgroundColourTwo = value; Invalidate(); } }

        public Color StateDisabledLongTextColourOne { get => _stateDisabledLongTextColourOne; set { _stateDisabledLongTextColourOne = value; Invalidate(); } }

        public Color StateDisabledLongTextColourTwo { get => _stateDisabledLongTextColourTwo; set { _stateDisabledLongTextColourTwo = value; Invalidate(); } }

        public Color StateDisabledShortTextColourOne { get => _stateDisabledShortTextColourOne; set { _stateDisabledShortTextColourOne = value; Invalidate(); } }

        public Color StateDisabledShortTextColourTwo { get => _stateDisabledShortTextColourTwo; set { _stateDisabledShortTextColourTwo = value; Invalidate(); } }

        public Color StateDisabledBorderColourOne { get => _stateDisabledBorderColourOne; set { _stateDisabledBorderColourOne = value; Invalidate(); } }

        public Color StateDisabledBorderColourTwo { get => _stateDisabledBorderColourTwo; set { _stateDisabledBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Normal
        public Color StateNormalBackgroundColourOne { get => _stateNormalBackgroundColourOne; set { _stateNormalBackgroundColourOne = value; Invalidate(); } }

        public Color StateNormalBackgroundColourTwo { get => _stateNormalBackgroundColourTwo; set { _stateNormalBackgroundColourTwo = value; Invalidate(); } }

        public Color StateNormalItemBackgroundColourOne { get => _stateNormalItemBackgroundColourOne; set { _stateNormalItemBackgroundColourOne = value; Invalidate(); } }

        public Color StateNormalItemBackgroundColourTwo { get => _stateNormalItemBackgroundColourTwo; set { _stateNormalItemBackgroundColourTwo = value; Invalidate(); } }

        public Color StateNormalLongTextColourOne { get => _stateNormalLongTextColourOne; set { _stateNormalLongTextColourOne = value; Invalidate(); } }

        public Color StateNormalLongTextColourTwo { get => _stateNormalLongTextColourTwo; set { _stateNormalLongTextColourTwo = value; Invalidate(); } }

        public Color StateNormalShortTextColourOne { get => _stateNormalShortTextColourOne; set { _stateNormalShortTextColourOne = value; Invalidate(); } }

        public Color StateNormalShortTextColourTwo { get => _stateNormalShortTextColourTwo; set { _stateNormalShortTextColourTwo = value; Invalidate(); } }

        public Color StateNormalBorderColourOne { get => _stateNormalBorderColourOne; set { _stateNormalBorderColourOne = value; Invalidate(); } }

        public Color StateNormalBorderColourTwo { get => _stateNormalBorderColourTwo; set { _stateNormalBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Pressed
        public Color StatePressedItemBackgroundColourOne { get => _statePressedItemBackgroundColourOne; set { _statePressedItemBackgroundColourOne = value; Invalidate(); } }

        public Color StatePressedItemBackgroundColourTwo { get => _statePressedItemBackgroundColourTwo; set { _statePressedItemBackgroundColourTwo = value; Invalidate(); } }

        public Color StatePressedLongTextColourOne { get => _statePressedLongTextColourOne; set { _statePressedLongTextColourOne = value; Invalidate(); } }

        public Color StatePressedLongTextColourTwo { get => _statePressedLongTextColourTwo; set { _statePressedLongTextColourTwo = value; Invalidate(); } }

        public Color StatePressedShortTextColourOne { get => _statePressedShortTextColourOne; set { _statePressedShortTextColourOne = value; Invalidate(); } }

        public Color StatePressedShortTextColourTwo { get => _statePressedShortTextColourTwo; set { _statePressedShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Tracking
        public Color StateTrackingItemBackgroundColourOne { get => _stateTrackingItemBackgroundColourOne; set { _stateTrackingItemBackgroundColourOne = value; Invalidate(); } }

        public Color StateTrackingItemBackgroundColourTwo { get => _stateTrackingItemBackgroundColourTwo; set { _stateTrackingItemBackgroundColourTwo = value; Invalidate(); } }

        public Color StateTrackingLongTextColourOne { get => _stateTrackingLongTextColourOne; set { _stateTrackingLongTextColourOne = value; Invalidate(); } }

        public Color StateTrackingLongTextColourTwo { get => _stateTrackingLongTextColourTwo; set { _stateTrackingLongTextColourTwo = value; Invalidate(); } }

        public Color StateTrackingShortTextColourOne { get => _stateTrackingShortTextColourOne; set { _stateTrackingShortTextColourOne = value; Invalidate(); } }

        public Color StateTrackingShortTextColourTwo { get => _stateTrackingShortTextColourTwo; set { _stateTrackingShortTextColourTwo = value; Invalidate(); } }
        #endregion

        [Category("Appearance"), Description("The 'Long Text' typeface.")]
        public Font LongTextTypeface { get => _longTextTypeface; set { _longTextTypeface = value; Invalidate(); } }

        [Category("Appearance"), Description("The 'Short Text' typeface.")]
        public Font ShortTextTypeface { get => _shortTextTypeface; set { _shortTextTypeface = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonTreeViewExtended()
        {
            #region Override Focus
            OverrideFocusItemBackgroundColourOne = Color.Empty;

            OverrideFocusItemBackgroundColourTwo = Color.Empty;

            OverrideFocusLongTextColourOne = Color.Empty;

            OverrideFocusLongTextColourTwo = Color.Empty;

            OverrideFocusShortTextColourOne = Color.Empty;

            OverrideFocusShortTextColourTwo = Color.Empty;
            #endregion

            #region State Active
            StateActiveBackgroundColourOne = Color.Empty;

            StateActiveBackgroundColourTwo = Color.Empty;

            StateActiveBorderColourOne = Color.Empty;

            StateActiveBorderColourTwo = Color.Empty;
            #endregion

            #region State Checked Normal
            StateCheckedNormalItemBackgroundColourOne = Color.Empty;

            StateCheckedNormalItemBackgroundColourTwo = Color.Empty;

            StateCheckedNormalLongTextColourOne = Color.Empty;

            StateCheckedNormalLongTextColourTwo = Color.Empty;

            StateCheckedNormalShortTextColourOne = Color.Empty;

            StateCheckedNormalShortTextColourTwo = Color.Empty;
            #endregion

            #region State Checked Pressed
            StateCheckedPressedItemBackgroundColourOne = Color.Empty;

            StateCheckedPressedItemBackgroundColourTwo = Color.Empty;

            StateCheckedPressedLongTextColourOne = Color.Empty;

            StateCheckedPressedLongTextColourTwo = Color.Empty;

            StateCheckedPressedShortTextColourOne = Color.Empty;

            StateCheckedPressedShortTextColourTwo = Color.Empty;
            #endregion

            #region State Checked Tracking
            StateCheckedTrackingItemBackgroundColourOne = Color.Empty;

            StateCheckedTrackingItemBackgroundColourTwo = Color.Empty;

            StateCheckedTrackingLongTextColourOne = Color.Empty;

            StateCheckedTrackingLongTextColourTwo = Color.Empty;

            StateCheckedTrackingShortTextColourOne = Color.Empty;

            StateCheckedTrackingShortTextColourTwo = Color.Empty;
            #endregion

            #region State Common
            StateCommonBackgroundColourOne = Color.Empty;

            StateCommonBackgroundColourTwo = Color.Empty;

            StateCommonItemBackgroundColourOne = Color.Empty;

            StateCommonItemBackgroundColourTwo = Color.Empty;

            StateCommonLongTextColourOne = Color.Empty;

            StateCommonLongTextColourTwo = Color.Empty;

            StateCommonShortTextColourOne = Color.Empty;

            StateCommonShortTextColourTwo = Color.Empty;

            StateCommonBorderColourOne = Color.Empty;

            StateCommonBorderColourTwo = Color.Empty;
            #endregion

            #region State Disabled
            StateDisabledBackgroundColourOne = Color.Empty;

            StateDisabledBackgroundColourTwo = Color.Empty;

            StateDisabledItemBackgroundColourOne = Color.Empty;

            StateDisabledItemBackgroundColourTwo = Color.Empty;

            StateDisabledLongTextColourOne = Color.Empty;

            StateDisabledLongTextColourTwo = Color.Empty;

            StateDisabledShortTextColourOne = Color.Empty;

            StateDisabledShortTextColourTwo = Color.Empty;

            StateDisabledBorderColourOne = Color.Empty;

            StateDisabledBorderColourTwo = Color.Empty;
            #endregion

            #region State Normal
            StateNormalBackgroundColourOne = Color.Empty;

            StateNormalBackgroundColourTwo = Color.Empty;

            StateNormalItemBackgroundColourOne = Color.Empty;

            StateNormalItemBackgroundColourTwo = Color.Empty;

            StateNormalLongTextColourOne = Color.Empty;

            StateNormalLongTextColourTwo = Color.Empty;

            StateNormalShortTextColourOne = Color.Empty;

            StateNormalShortTextColourTwo = Color.Empty;

            StateNormalBorderColourOne = Color.Empty;

            StateNormalBorderColourTwo = Color.Empty;
            #endregion

            #region State Pressed
            StatePressedItemBackgroundColourOne = Color.Empty;

            StatePressedItemBackgroundColourTwo = Color.Empty;

            StatePressedLongTextColourOne = Color.Empty;

            StatePressedLongTextColourTwo = Color.Empty;

            StatePressedShortTextColourOne = Color.Empty;

            StatePressedShortTextColourTwo = Color.Empty;
            #endregion

            #region State Tracking
            StateTrackingItemBackgroundColourOne = Color.Empty;

            StateTrackingItemBackgroundColourTwo = Color.Empty;

            StateTrackingLongTextColourOne = Color.Empty;

            StateTrackingLongTextColourTwo = Color.Empty;

            StateTrackingShortTextColourOne = Color.Empty;

            StateTrackingShortTextColourTwo = Color.Empty;
            #endregion

            LongTextTypeface = null;

            ShortTextTypeface = null;

            UpdateOverrideFocusAppearanceValues(OverrideFocusItemBackgroundColourOne, OverrideFocusItemBackgroundColourTwo, OverrideFocusLongTextColourOne, OverrideFocusLongTextColourTwo, OverrideFocusShortTextColourOne, OverrideFocusShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateActiveAppearanceValues(StateActiveBackgroundColourOne, StateActiveBackgroundColourTwo, StateActiveBorderColourOne, StateActiveBorderColourTwo);

            UpdateStateCheckedNormalAppearanceValues(StateCheckedNormalItemBackgroundColourOne, StateCheckedNormalItemBackgroundColourTwo, StateCheckedNormalLongTextColourOne, StateCheckedNormalLongTextColourTwo, StateCheckedNormalShortTextColourOne, StateCheckedNormalShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateCheckedPressedAppearanceValues(StateCheckedPressedItemBackgroundColourOne, StateCheckedPressedItemBackgroundColourTwo, StateCheckedPressedLongTextColourOne, StateCheckedPressedLongTextColourTwo, StateCheckedPressedShortTextColourOne, StateCheckedPressedShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateCheckedTrackingAppearanceValues(StateCheckedTrackingItemBackgroundColourOne, StateCheckedTrackingItemBackgroundColourTwo, StateCheckedTrackingLongTextColourOne, StateCheckedTrackingLongTextColourTwo, StateCheckedTrackingShortTextColourOne, StateCheckedTrackingShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateCommonAppearanceValues(StateCommonBackgroundColourOne, StateCommonBackgroundColourTwo, StateCommonItemBackgroundColourOne, StateCommonItemBackgroundColourTwo, StateCommonLongTextColourOne, StateCommonLongTextColourTwo, StateCommonShortTextColourOne, StateCommonShortTextColourTwo, StateCommonBorderColourOne, StateCommonBorderColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateDisabledAppearanceValues(StateDisabledBackgroundColourOne, StateDisabledBackgroundColourTwo, StateDisabledItemBackgroundColourOne, StateDisabledItemBackgroundColourTwo, StateDisabledLongTextColourOne, StateDisabledLongTextColourTwo, StateDisabledShortTextColourOne, StateDisabledShortTextColourTwo, StateDisabledBorderColourOne, StateDisabledBorderColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateNormalAppearanceValues(StateNormalBackgroundColourOne, StateNormalBackgroundColourTwo, StateNormalItemBackgroundColourOne, StateNormalItemBackgroundColourTwo, StateNormalLongTextColourOne, StateNormalLongTextColourTwo, StateNormalShortTextColourOne, StateNormalShortTextColourTwo, StateNormalBorderColourOne, StateNormalBorderColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStatePressedAppearanceValues(StatePressedItemBackgroundColourOne, StatePressedItemBackgroundColourTwo, StatePressedLongTextColourOne, StatePressedLongTextColourTwo, StatePressedShortTextColourOne, StatePressedShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateTrackingAppearanceValues(StateTrackingItemBackgroundColourOne, StateTrackingItemBackgroundColourTwo, StateTrackingLongTextColourOne, StateTrackingLongTextColourTwo, StateTrackingShortTextColourOne, StateTrackingShortTextColourTwo, LongTextTypeface, ShortTextTypeface);
        }
        #endregion

        #region Method
        /// <summary>Updates the override focus appearance values.</summary>
        /// <param name="itemBackgroundColourOne">The item background colour one.</param>
        /// <param name="itemBackgroundColourTwo">The item background colour two.</param>
        /// <param name="longTextColourOne">The long text colour one.</param>
        /// <param name="longTextColourTwo">The long text colour two.</param>
        /// <param name="shortTextColourOne">The short text colour one.</param>
        /// <param name="shortTextColourTwo">The short text colour two.</param>
        /// <param name="longTextTypeface">The long text typeface.</param>
        /// <param name="shortTextTypeface">The short text typeface.</param>
        private void UpdateOverrideFocusAppearanceValues(Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            OverrideFocus.Node.Back.Color1 = itemBackgroundColourOne;

            OverrideFocus.Node.Back.Color2 = itemBackgroundColourTwo;

            OverrideFocus.Node.Content.LongText.Color1 = longTextColourOne;

            OverrideFocus.Node.Content.LongText.Color2 = longTextColourTwo;

            OverrideFocus.Node.Content.LongText.Font = longTextTypeface;

            OverrideFocus.Node.Content.ShortText.Color1 = shortTextColourOne;

            OverrideFocus.Node.Content.ShortText.Color2 = shortTextColourTwo;

            OverrideFocus.Node.Content.ShortText.Font = shortTextTypeface;
        }

        /// <summary>Updates the state common appearance values.</summary>
        /// <param name="commonBackgroundColourOne">The common background colour one.</param>
        /// <param name="commonBackgroundColourTwo">The common background colour two.</param>
        /// <param name="itemBackgroundColourOne">The item background colour one.</param>
        /// <param name="itemBackgroundColourTwo">The item background colour two.</param>
        /// <param name="longTextColourOne">The long text colour one.</param>
        /// <param name="longTextColourTwo">The long text colour two.</param>
        /// <param name="shortTextColourOne">The short text colour one.</param>
        /// <param name="shortTextColourTwo">The short text colour two.</param>
        /// <param name="longTextTypeface">The long text typeface.</param>
        /// <param name="shortTextTypeface">The short text typeface.</param>
        private void UpdateStateCommonAppearanceValues(Color commonBackgroundColourOne, Color commonBackgroundColourTwo, Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            StateCommon.Back.Color1 = commonBackgroundColourOne;

            StateCommon.Back.Color2 = commonBackgroundColourTwo;

            StateCommon.Node.Back.Color1 = itemBackgroundColourOne;

            StateCommon.Node.Back.Color2 = itemBackgroundColourTwo;

            StateCommon.Node.Content.LongText.Color1 = longTextColourOne;

            StateCommon.Node.Content.LongText.Color2 = longTextColourTwo;

            StateCommon.Node.Content.LongText.Font = longTextTypeface;

            StateCommon.Node.Content.ShortText.Color1 = shortTextColourOne;

            StateCommon.Node.Content.ShortText.Color2 = shortTextColourTwo;

            StateCommon.Node.Content.ShortText.Font = shortTextTypeface;

            StateCommon.Border.Color1 = borderColourOne;

            StateCommon.Border.Color2 = borderColourTwo;
        }

        /// <summary>Updates the state active appearance values.</summary>
        /// <param name="activeBackgroundColourOne">The active background colour one.</param>
        /// <param name="activeBackgroundColourTwo">The active background colour two.</param>
        private void UpdateStateActiveAppearanceValues(Color activeBackgroundColourOne, Color activeBackgroundColourTwo, Color borderColourOne, Color borderColourTwo)
        {
            StateActive.Back.Color1 = activeBackgroundColourOne;

            StateActive.Back.Color2 = activeBackgroundColourTwo;

            StateActive.Border.Color1 = borderColourOne;

            StateActive.Border.Color2 = borderColourTwo;
        }

        /// <summary>Updates the state checked normal appearance values.</summary>
        /// <param name="itemBackgroundColourOne">The item background colour one.</param>
        /// <param name="itemBackgroundColourTwo">The item background colour two.</param>
        /// <param name="longTextColourOne">The long text colour one.</param>
        /// <param name="longTextColourTwo">The long text colour two.</param>
        /// <param name="shortTextColourOne">The short text colour one.</param>
        /// <param name="shortTextColourTwo">The short text colour two.</param>
        /// <param name="longTextTypeface">The long text typeface.</param>
        /// <param name="shortTextTypeface">The short text typeface.</param>
        private void UpdateStateCheckedNormalAppearanceValues(Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            StateCheckedNormal.Node.Back.Color1 = itemBackgroundColourOne;

            StateCheckedNormal.Node.Back.Color2 = itemBackgroundColourTwo;

            StateCheckedNormal.Node.Content.LongText.Color1 = longTextColourOne;

            StateCheckedNormal.Node.Content.LongText.Color2 = longTextColourTwo;

            StateCheckedNormal.Node.Content.LongText.Font = longTextTypeface;

            StateCheckedNormal.Node.Content.ShortText.Color1 = shortTextColourOne;

            StateCheckedNormal.Node.Content.ShortText.Color2 = shortTextColourTwo;

            StateCheckedNormal.Node.Content.ShortText.Font = shortTextTypeface;
        }

        /// <summary>Updates the state checked pressed appearance values.</summary>
        /// <param name="itemBackgroundColourOne">The item background colour one.</param>
        /// <param name="itemBackgroundColourTwo">The item background colour two.</param>
        /// <param name="longTextColourOne">The long text colour one.</param>
        /// <param name="longTextColourTwo">The long text colour two.</param>
        /// <param name="shortTextColourOne">The short text colour one.</param>
        /// <param name="shortTextColourTwo">The short text colour two.</param>
        /// <param name="longTextTypeface">The long text typeface.</param>
        /// <param name="shortTextTypeface">The short text typeface.</param>
        private void UpdateStateCheckedPressedAppearanceValues(Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            StateCheckedPressed.Node.Back.Color1 = itemBackgroundColourOne;

            StateCheckedPressed.Node.Back.Color2 = itemBackgroundColourTwo;

            StateCheckedPressed.Node.Content.LongText.Color1 = longTextColourOne;

            StateCheckedPressed.Node.Content.LongText.Color2 = longTextColourTwo;

            StateCheckedPressed.Node.Content.LongText.Font = longTextTypeface;

            StateCheckedPressed.Node.Content.ShortText.Color1 = shortTextColourOne;

            StateCheckedPressed.Node.Content.ShortText.Color2 = shortTextColourTwo;

            StateCheckedPressed.Node.Content.ShortText.Font = shortTextTypeface;
        }

        /// <summary>Updates the state checked tracking appearance values.</summary>
        /// <param name="itemBackgroundColourOne">The item background colour one.</param>
        /// <param name="itemBackgroundColourTwo">The item background colour two.</param>
        /// <param name="longTextColourOne">The long text colour one.</param>
        /// <param name="longTextColourTwo">The long text colour two.</param>
        /// <param name="shortTextColourOne">The short text colour one.</param>
        /// <param name="shortTextColourTwo">The short text colour two.</param>
        /// <param name="longTextTypeface">The long text typeface.</param>
        /// <param name="shortTextTypeface">The short text typeface.</param>
        private void UpdateStateCheckedTrackingAppearanceValues(Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            StateCheckedTracking.Node.Back.Color1 = itemBackgroundColourOne;

            StateCheckedTracking.Node.Back.Color2 = itemBackgroundColourTwo;

            StateCheckedTracking.Node.Content.LongText.Color1 = longTextColourOne;

            StateCheckedTracking.Node.Content.LongText.Color2 = longTextColourTwo;

            StateCheckedTracking.Node.Content.LongText.Font = longTextTypeface;

            StateCheckedTracking.Node.Content.ShortText.Color1 = shortTextColourOne;

            StateCheckedTracking.Node.Content.ShortText.Color2 = shortTextColourTwo;

            StateCheckedTracking.Node.Content.ShortText.Font = shortTextTypeface;
        }

        /// <summary>Updates the state disabled appearance values.</summary>
        /// <param name="DisabledBackgroundColourOne">The disabled background colour one.</param>
        /// <param name="DisabledBackgroundColourTwo">The disabled background colour two.</param>
        /// <param name="itemBackgroundColourOne">The item background colour one.</param>
        /// <param name="itemBackgroundColourTwo">The item background colour two.</param>
        /// <param name="longTextColourOne">The long text colour one.</param>
        /// <param name="longTextColourTwo">The long text colour two.</param>
        /// <param name="shortTextColourOne">The short text colour one.</param>
        /// <param name="shortTextColourTwo">The short text colour two.</param>
        /// <param name="longTextTypeface">The long text typeface.</param>
        /// <param name="shortTextTypeface">The short text typeface.</param>
        private void UpdateStateDisabledAppearanceValues(Color DisabledBackgroundColourOne, Color DisabledBackgroundColourTwo, Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            StateDisabled.Back.Color1 = DisabledBackgroundColourOne;

            StateDisabled.Back.Color2 = DisabledBackgroundColourTwo;

            StateDisabled.Node.Back.Color1 = itemBackgroundColourOne;

            StateDisabled.Node.Back.Color2 = itemBackgroundColourTwo;

            StateDisabled.Node.Content.LongText.Color1 = longTextColourOne;

            StateDisabled.Node.Content.LongText.Color2 = longTextColourTwo;

            StateDisabled.Node.Content.LongText.Font = longTextTypeface;

            StateDisabled.Node.Content.ShortText.Color1 = shortTextColourOne;

            StateDisabled.Node.Content.ShortText.Color2 = shortTextColourTwo;

            StateDisabled.Node.Content.ShortText.Font = shortTextTypeface;

            StateDisabled.Border.Color1 = borderColourOne;

            StateDisabled.Border.Color2 = borderColourTwo;
        }

        /// <summary>Updates the state normal appearance values.</summary>
        /// <param name="NormalBackgroundColourOne">The normal background colour one.</param>
        /// <param name="NormalBackgroundColourTwo">The normal background colour two.</param>
        /// <param name="itemBackgroundColourOne">The item background colour one.</param>
        /// <param name="itemBackgroundColourTwo">The item background colour two.</param>
        /// <param name="longTextColourOne">The long text colour one.</param>
        /// <param name="longTextColourTwo">The long text colour two.</param>
        /// <param name="shortTextColourOne">The short text colour one.</param>
        /// <param name="shortTextColourTwo">The short text colour two.</param>
        /// <param name="longTextTypeface">The long text typeface.</param>
        /// <param name="shortTextTypeface">The short text typeface.</param>
        private void UpdateStateNormalAppearanceValues(Color NormalBackgroundColourOne, Color NormalBackgroundColourTwo, Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            StateNormal.Back.Color1 = NormalBackgroundColourOne;

            StateNormal.Back.Color2 = NormalBackgroundColourTwo;

            StateNormal.Node.Back.Color1 = itemBackgroundColourOne;

            StateNormal.Node.Back.Color2 = itemBackgroundColourTwo;

            StateNormal.Node.Content.LongText.Color1 = longTextColourOne;

            StateNormal.Node.Content.LongText.Color2 = longTextColourTwo;

            StateNormal.Node.Content.LongText.Font = longTextTypeface;

            StateNormal.Node.Content.ShortText.Color1 = shortTextColourOne;

            StateNormal.Node.Content.ShortText.Color2 = shortTextColourTwo;

            StateNormal.Node.Content.ShortText.Font = shortTextTypeface;

            StateNormal.Border.Color1 = borderColourOne;

            StateNormal.Border.Color2 = borderColourTwo;
        }

        /// <summary>Updates the state pressed appearance values.</summary>
        /// <param name="itemBackgroundColourOne">The item background colour one.</param>
        /// <param name="itemBackgroundColourTwo">The item background colour two.</param>
        /// <param name="longTextColourOne">The long text colour one.</param>
        /// <param name="longTextColourTwo">The long text colour two.</param>
        /// <param name="shortTextColourOne">The short text colour one.</param>
        /// <param name="shortTextColourTwo">The short text colour two.</param>
        /// <param name="longTextTypeface">The long text typeface.</param>
        /// <param name="shortTextTypeface">The short text typeface.</param>
        private void UpdateStatePressedAppearanceValues(Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            StatePressed.Node.Back.Color1 = itemBackgroundColourOne;

            StatePressed.Node.Back.Color2 = itemBackgroundColourTwo;

            StatePressed.Node.Content.LongText.Color1 = longTextColourOne;

            StatePressed.Node.Content.LongText.Color2 = longTextColourTwo;

            StatePressed.Node.Content.LongText.Font = longTextTypeface;

            StatePressed.Node.Content.ShortText.Color1 = shortTextColourOne;

            StatePressed.Node.Content.ShortText.Color2 = shortTextColourTwo;

            StatePressed.Node.Content.ShortText.Font = shortTextTypeface;
        }

        /// <summary>Updates the state tracking appearance values.</summary>
        /// <param name="itemBackgroundColourOne">The item background colour one.</param>
        /// <param name="itemBackgroundColourTwo">The item background colour two.</param>
        /// <param name="longTextColourOne">The long text colour one.</param>
        /// <param name="longTextColourTwo">The long text colour two.</param>
        /// <param name="shortTextColourOne">The short text colour one.</param>
        /// <param name="shortTextColourTwo">The short text colour two.</param>
        /// <param name="longTextTypeface">The long text typeface.</param>
        /// <param name="shortTextTypeface">The short text typeface.</param>
        private void UpdateStateTrackingAppearanceValues(Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            StateTracking.Node.Back.Color1 = itemBackgroundColourOne;

            StateTracking.Node.Back.Color2 = itemBackgroundColourTwo;

            StateTracking.Node.Content.LongText.Color1 = longTextColourOne;

            StateTracking.Node.Content.LongText.Color2 = longTextColourTwo;

            StateTracking.Node.Content.LongText.Font = longTextTypeface;

            StateTracking.Node.Content.ShortText.Color1 = shortTextColourOne;

            StateTracking.Node.Content.ShortText.Color2 = shortTextColourTwo;

            StateTracking.Node.Content.ShortText.Font = shortTextTypeface;
        }
        #endregion

        #region Override
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateOverrideFocusAppearanceValues(OverrideFocusItemBackgroundColourOne, OverrideFocusItemBackgroundColourTwo, OverrideFocusLongTextColourOne, OverrideFocusLongTextColourTwo, OverrideFocusShortTextColourOne, OverrideFocusShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateActiveAppearanceValues(StateActiveBackgroundColourOne, StateActiveBackgroundColourTwo, StateActiveBorderColourOne, StateActiveBorderColourTwo);

            UpdateStateCheckedNormalAppearanceValues(StateCheckedNormalItemBackgroundColourOne, StateCheckedNormalItemBackgroundColourTwo, StateCheckedNormalLongTextColourOne, StateCheckedNormalLongTextColourTwo, StateCheckedNormalShortTextColourOne, StateCheckedNormalShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateCheckedPressedAppearanceValues(StateCheckedPressedItemBackgroundColourOne, StateCheckedPressedItemBackgroundColourTwo, StateCheckedPressedLongTextColourOne, StateCheckedPressedLongTextColourTwo, StateCheckedPressedShortTextColourOne, StateCheckedPressedShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateCheckedTrackingAppearanceValues(StateCheckedTrackingItemBackgroundColourOne, StateCheckedTrackingItemBackgroundColourTwo, StateCheckedTrackingLongTextColourOne, StateCheckedTrackingLongTextColourTwo, StateCheckedTrackingShortTextColourOne, StateCheckedTrackingShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateCommonAppearanceValues(StateCommonBackgroundColourOne, StateCommonBackgroundColourTwo, StateCommonItemBackgroundColourOne, StateCommonItemBackgroundColourTwo, StateCommonLongTextColourOne, StateCommonLongTextColourTwo, StateCommonShortTextColourOne, StateCommonShortTextColourTwo, StateCommonBorderColourOne, StateCommonBorderColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateDisabledAppearanceValues(StateDisabledBackgroundColourOne, StateDisabledBackgroundColourTwo, StateDisabledItemBackgroundColourOne, StateDisabledItemBackgroundColourTwo, StateDisabledLongTextColourOne, StateDisabledLongTextColourTwo, StateDisabledShortTextColourOne, StateDisabledShortTextColourTwo, StateDisabledBorderColourOne, StateDisabledBorderColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateNormalAppearanceValues(StateNormalBackgroundColourOne, StateNormalBackgroundColourTwo, StateNormalItemBackgroundColourOne, StateNormalItemBackgroundColourTwo, StateNormalLongTextColourOne, StateNormalLongTextColourTwo, StateNormalShortTextColourOne, StateNormalShortTextColourTwo, StateNormalBorderColourOne, StateNormalBorderColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStatePressedAppearanceValues(StatePressedItemBackgroundColourOne, StatePressedItemBackgroundColourTwo, StatePressedLongTextColourOne, StatePressedLongTextColourTwo, StatePressedShortTextColourOne, StatePressedShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateTrackingAppearanceValues(StateTrackingItemBackgroundColourOne, StateTrackingItemBackgroundColourTwo, StateTrackingLongTextColourOne, StateTrackingLongTextColourTwo, StateTrackingShortTextColourOne, StateTrackingShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            base.OnPaint(e);
        }
        #endregion
    }
}