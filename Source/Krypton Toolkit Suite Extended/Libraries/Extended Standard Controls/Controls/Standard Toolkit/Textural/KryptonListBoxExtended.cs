using ComponentFactory.Krypton.Toolkit;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ExtendedStandardControls.Controls.Toolkit.Textural
{
    [ToolboxBitmap(typeof(KryptonListBox))]
    public class KryptonListBoxExtended : KryptonListBox
    {
        #region Variables
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
        public KryptonListBoxExtended()
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
            OverrideFocus.Item.Back.Color1 = itemBackgroundColourOne;

            OverrideFocus.Item.Back.Color2 = itemBackgroundColourTwo;

            OverrideFocus.Item.Content.LongText.Color1 = longTextColourOne;

            OverrideFocus.Item.Content.LongText.Color2 = longTextColourTwo;

            OverrideFocus.Item.Content.LongText.Font = longTextTypeface;

            OverrideFocus.Item.Content.ShortText.Color1 = shortTextColourOne;

            OverrideFocus.Item.Content.ShortText.Color2 = shortTextColourTwo;

            OverrideFocus.Item.Content.ShortText.Font = shortTextTypeface;
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

            StateCommon.Item.Back.Color1 = itemBackgroundColourOne;

            StateCommon.Item.Back.Color2 = itemBackgroundColourTwo;

            StateCommon.Item.Content.LongText.Color1 = longTextColourOne;

            StateCommon.Item.Content.LongText.Color2 = longTextColourTwo;

            StateCommon.Item.Content.LongText.Font = longTextTypeface;

            StateCommon.Item.Content.ShortText.Color1 = shortTextColourOne;

            StateCommon.Item.Content.ShortText.Color2 = shortTextColourTwo;

            StateCommon.Item.Content.ShortText.Font = shortTextTypeface;

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
            StateCheckedNormal.Item.Back.Color1 = itemBackgroundColourOne;

            StateCheckedNormal.Item.Back.Color2 = itemBackgroundColourTwo;

            StateCheckedNormal.Item.Content.LongText.Color1 = longTextColourOne;

            StateCheckedNormal.Item.Content.LongText.Color2 = longTextColourTwo;

            StateCheckedNormal.Item.Content.LongText.Font = longTextTypeface;

            StateCheckedNormal.Item.Content.ShortText.Color1 = shortTextColourOne;

            StateCheckedNormal.Item.Content.ShortText.Color2 = shortTextColourTwo;

            StateCheckedNormal.Item.Content.ShortText.Font = shortTextTypeface;
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
            StateCheckedPressed.Item.Back.Color1 = itemBackgroundColourOne;

            StateCheckedPressed.Item.Back.Color2 = itemBackgroundColourTwo;

            StateCheckedPressed.Item.Content.LongText.Color1 = longTextColourOne;

            StateCheckedPressed.Item.Content.LongText.Color2 = longTextColourTwo;

            StateCheckedPressed.Item.Content.LongText.Font = longTextTypeface;

            StateCheckedPressed.Item.Content.ShortText.Color1 = shortTextColourOne;

            StateCheckedPressed.Item.Content.ShortText.Color2 = shortTextColourTwo;

            StateCheckedPressed.Item.Content.ShortText.Font = shortTextTypeface;
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
            StateCheckedTracking.Item.Back.Color1 = itemBackgroundColourOne;

            StateCheckedTracking.Item.Back.Color2 = itemBackgroundColourTwo;

            StateCheckedTracking.Item.Content.LongText.Color1 = longTextColourOne;

            StateCheckedTracking.Item.Content.LongText.Color2 = longTextColourTwo;

            StateCheckedTracking.Item.Content.LongText.Font = longTextTypeface;

            StateCheckedTracking.Item.Content.ShortText.Color1 = shortTextColourOne;

            StateCheckedTracking.Item.Content.ShortText.Color2 = shortTextColourTwo;

            StateCheckedTracking.Item.Content.ShortText.Font = shortTextTypeface;
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

            StateDisabled.Item.Back.Color1 = itemBackgroundColourOne;

            StateDisabled.Item.Back.Color2 = itemBackgroundColourTwo;

            StateDisabled.Item.Content.LongText.Color1 = longTextColourOne;

            StateDisabled.Item.Content.LongText.Color2 = longTextColourTwo;

            StateDisabled.Item.Content.LongText.Font = longTextTypeface;

            StateDisabled.Item.Content.ShortText.Color1 = shortTextColourOne;

            StateDisabled.Item.Content.ShortText.Color2 = shortTextColourTwo;

            StateDisabled.Item.Content.ShortText.Font = shortTextTypeface;

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

            StateNormal.Item.Back.Color1 = itemBackgroundColourOne;

            StateNormal.Item.Back.Color2 = itemBackgroundColourTwo;

            StateNormal.Item.Content.LongText.Color1 = longTextColourOne;

            StateNormal.Item.Content.LongText.Color2 = longTextColourTwo;

            StateNormal.Item.Content.LongText.Font = longTextTypeface;

            StateNormal.Item.Content.ShortText.Color1 = shortTextColourOne;

            StateNormal.Item.Content.ShortText.Color2 = shortTextColourTwo;

            StateNormal.Item.Content.ShortText.Font = shortTextTypeface;

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
            StatePressed.Item.Back.Color1 = itemBackgroundColourOne;

            StatePressed.Item.Back.Color2 = itemBackgroundColourTwo;

            StatePressed.Item.Content.LongText.Color1 = longTextColourOne;

            StatePressed.Item.Content.LongText.Color2 = longTextColourTwo;

            StatePressed.Item.Content.LongText.Font = longTextTypeface;

            StatePressed.Item.Content.ShortText.Color1 = shortTextColourOne;

            StatePressed.Item.Content.ShortText.Color2 = shortTextColourTwo;

            StatePressed.Item.Content.ShortText.Font = shortTextTypeface;
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
            StateTracking.Item.Back.Color1 = itemBackgroundColourOne;

            StateTracking.Item.Back.Color2 = itemBackgroundColourTwo;

            StateTracking.Item.Content.LongText.Color1 = longTextColourOne;

            StateTracking.Item.Content.LongText.Color2 = longTextColourTwo;

            StateTracking.Item.Content.LongText.Font = longTextTypeface;

            StateTracking.Item.Content.ShortText.Color1 = shortTextColourOne;

            StateTracking.Item.Content.ShortText.Color2 = shortTextColourTwo;

            StateTracking.Item.Content.ShortText.Font = shortTextTypeface;
        }
        #endregion

        #region Overrides
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