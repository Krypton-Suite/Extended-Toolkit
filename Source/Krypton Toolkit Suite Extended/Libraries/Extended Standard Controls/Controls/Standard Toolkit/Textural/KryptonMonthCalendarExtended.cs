using ComponentFactory.Krypton.Toolkit;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ExtendedStandardControls
{
    [ToolboxBitmap(typeof(KryptonMonthCalendar))]
    public class KryptonMonthCalendarExtended : KryptonMonthCalendar
    {
        #region Variables
        private Color _overrideBoldedDayBackgroundColourOne, _overrideBoldedDayBackgroundColourTwo, _overrideBoldedDayLongTextColourOne, _overrideBoldedDayLongTextColourTwo, _overrideBoldedDayShortTextColourOne, _overrideBoldedDayShortTextColourTwo,
                      _overrideFocusDayBackgroundColourOne, _overrideFocusDayBackgroundColourTwo, _overrideFocusDayLongTextColourOne, _overrideFocusDayLongTextColourTwo, _overrideFocusDayShortTextColourOne, _overrideFocusDayShortTextColourTwo,
                      _overrideTodayDayBackgroundColourOne, _overrideTodayDayBackgroundColourTwo, _overrideTodayDayLongTextColourOne, _overrideTodayDayLongTextColourTwo, _overrideTodayDayShortTextColourOne, _overrideTodayDayShortTextColourTwo,
                      _stateCommonBackgroundColourOne, _stateCommonBackgroundColourTwo, _stateCommonDayBackgroundColourOne, _stateCommonDayBackgroundColourTwo, _stateCommonDayLongTextColourOne, _stateCommonDayLongTextColourTwo, _stateCommonDayShortTextColourOne, _stateCommonDayShortTextColourTwo, _stateCommonDayOfWeekBackgroundColourOne, _stateCommonDayOfWeekBackgroundColourTwo, _stateCommonDayOfWeekLongTextColourOne, _stateCommonDayOfWeekLongTextColourTwo, _stateCommonDayOfWeekShortTextColourOne, _stateCommonDayOfWeekShortTextColourTwo, _stateCommonHeaderBackgroundColourOne, _stateCommonHeaderBackgroundColourTwo, _stateCommonHeaderLongTextColourOne, _stateCommonHeaderLongTextColourTwo, _stateCommonHeaderShortTextColourOne, _stateCommonHeaderShortTextColourTwo, _stateCommonBorderColourOne, _stateCommonBorderColourTwo,
                      _stateCheckedNormalDayBackgroundColourOne, _stateCheckedNormalDayBackgroundColourTwo, _stateCheckedNormalDayLongTextColourOne, _stateCheckedNormalDayLongTextColourTwo, _stateCheckedNormalDayShortTextColourOne, _stateCheckedNormalDayShortTextColourTwo,
                      _stateCheckedPressedDayBackgroundColourOne, _stateCheckedPressedDayBackgroundColourTwo, _stateCheckedPressedDayLongTextColourOne, _stateCheckedPressedDayLongTextColourTwo, _stateCheckedPressedDayShortTextColourOne, _stateCheckedPressedDayShortTextColourTwo,
                      _stateCheckedTrackingDayBackgroundColourOne, _stateCheckedTrackingDayBackgroundColourTwo, _stateCheckedTrackingDayLongTextColourOne, _stateCheckedTrackingDayLongTextColourTwo, _stateCheckedTrackingDayShortTextColourOne, _stateCheckedTrackingDayShortTextColourTwo,
                      _stateDisabledBackgroundColourOne, _stateDisabledBackgroundColourTwo, _stateDisabledDayBackgroundColourOne, _stateDisabledDayBackgroundColourTwo, _stateDisabledDayLongTextColourOne, _stateDisabledDayLongTextColourTwo, _stateDisabledDayShortTextColourOne, _stateDisabledDayShortTextColourTwo, _stateDisabledDayOfWeekBackgroundColourOne, _stateDisabledDayOfWeekBackgroundColourTwo, _stateDisabledDayOfWeekLongTextColourOne, _stateDisabledDayOfWeekLongTextColourTwo, _stateDisabledDayOfWeekShortTextColourOne, _stateDisabledDayOfWeekShortTextColourTwo, _stateDisabledHeaderBackgroundColourOne, _stateDisabledHeaderBackgroundColourTwo, _stateDisabledHeaderLongTextColourOne, _stateDisabledHeaderLongTextColourTwo, _stateDisabledHeaderShortTextColourOne, _stateDisabledHeaderShortTextColourTwo, _stateDisabledBorderColourOne, _stateDisabledBorderColourTwo,
                      _stateNormalBackgroundColourOne, _stateNormalBackgroundColourTwo, _stateNormalDayBackgroundColourOne, _stateNormalDayBackgroundColourTwo, _stateNormalDayLongTextColourOne, _stateNormalDayLongTextColourTwo, _stateNormalDayShortTextColourOne, _stateNormalDayShortTextColourTwo, _stateNormalDayOfWeekBackgroundColourOne, _stateNormalDayOfWeekBackgroundColourTwo, _stateNormalDayOfWeekLongTextColourOne, _stateNormalDayOfWeekLongTextColourTwo, _stateNormalDayOfWeekShortTextColourOne, _stateNormalDayOfWeekShortTextColourTwo, _stateNormalHeaderBackgroundColourOne, _stateNormalHeaderBackgroundColourTwo, _stateNormalHeaderLongTextColourOne, _stateNormalHeaderLongTextColourTwo, _stateNormalHeaderShortTextColourOne, _stateNormalHeaderShortTextColourTwo, _stateNormalBorderColourOne, _stateNormalBorderColourTwo,
                      _statePressedDayBackgroundColourOne, _statePressedDayBackgroundColourTwo, _statePressedDayLongTextColourOne, _statePressedDayLongTextColourTwo, _statePressedDayShortTextColourOne, _statePressedDayShortTextColourTwo,
                      _stateTrackingDayBackgroundColourOne, _stateTrackingDayBackgroundColourTwo, _stateTrackingDayLongTextColourOne, _stateTrackingDayLongTextColourTwo, _stateTrackingDayShortTextColourOne, _stateTrackingDayShortTextColourTwo;

        private Font _longTextTypeface, _shortTextTypeface;
        #endregion

        #region Properties

        #region Override Bolded
        public Color OverrideBoldedDayBackgroundColourOne { get => _overrideBoldedDayBackgroundColourOne; set { _overrideBoldedDayBackgroundColourOne = value; Invalidate(); } }

        public Color OverrideBoldedDayBackgroundColourTwo { get => _overrideBoldedDayBackgroundColourTwo; set { _overrideBoldedDayBackgroundColourTwo = value; Invalidate(); } }

        public Color OverrideBoldedDayLongTextColourOne { get => _overrideBoldedDayLongTextColourOne; set { _overrideBoldedDayLongTextColourOne = value; Invalidate(); } }

        public Color OverrideBoldedDayLongTextColourTwo { get => _overrideBoldedDayLongTextColourTwo; set { _overrideBoldedDayLongTextColourTwo = value; Invalidate(); } }

        public Color OverrideBoldedDayShortTextColourOne { get => _overrideBoldedDayShortTextColourOne; set { _overrideBoldedDayShortTextColourOne = value; Invalidate(); } }

        public Color OverrideBoldedDayShortTextColourTwo { get => _overrideBoldedDayShortTextColourTwo; set { _overrideBoldedDayShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region Override Focus
        public Color OverrideFocusDayBackgroundColourOne { get => _overrideFocusDayBackgroundColourOne; set { _overrideFocusDayBackgroundColourOne = value; Invalidate(); } }

        public Color OverrideFocusDayBackgroundColourTwo { get => _overrideFocusDayBackgroundColourTwo; set { _overrideFocusDayBackgroundColourTwo = value; Invalidate(); } }

        public Color OverrideFocusDayLongTextColourOne { get => _overrideFocusDayLongTextColourOne; set { _overrideFocusDayLongTextColourOne = value; Invalidate(); } }

        public Color OverrideFocusDayLongTextColourTwo { get => _overrideFocusDayLongTextColourTwo; set { _overrideFocusDayLongTextColourTwo = value; Invalidate(); } }

        public Color OverrideFocusDayShortTextColourOne { get => _overrideFocusDayShortTextColourOne; set { _overrideFocusDayShortTextColourOne = value; Invalidate(); } }

        public Color OverrideFocusDayShortTextColourTwo { get => _overrideFocusDayShortTextColourTwo; set { _overrideFocusDayShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region Override Today
        public Color OverrideTodayDayBackgroundColourOne { get => _overrideTodayDayBackgroundColourOne; set { _overrideTodayDayBackgroundColourOne = value; Invalidate(); } }

        public Color OverrideTodayDayBackgroundColourTwo { get => _overrideTodayDayBackgroundColourTwo; set { _overrideTodayDayBackgroundColourTwo = value; Invalidate(); } }

        public Color OverrideTodayDayLongTextColourOne { get => _overrideTodayDayLongTextColourOne; set { _overrideTodayDayLongTextColourOne = value; Invalidate(); } }

        public Color OverrideTodayDayLongTextColourTwo { get => _overrideTodayDayLongTextColourTwo; set { _overrideTodayDayLongTextColourTwo = value; Invalidate(); } }

        public Color OverrideTodayDayShortTextColourOne { get => _overrideTodayDayShortTextColourOne; set { _overrideTodayDayShortTextColourOne = value; Invalidate(); } }

        public Color OverrideTodayDayShortTextColourTwo { get => _overrideTodayDayShortTextColourTwo; set { _overrideTodayDayShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Checked Normal
        public Color StateCheckedNormalDayBackgroundColourOne { get => _stateCheckedNormalDayBackgroundColourOne; set { _stateCheckedNormalDayBackgroundColourOne = value; Invalidate(); } }

        public Color StateCheckedNormalDayBackgroundColourTwo { get => _stateCheckedNormalDayBackgroundColourTwo; set { _stateCheckedNormalDayBackgroundColourTwo = value; Invalidate(); } }

        public Color StateCheckedNormalDayLongTextColourOne { get => _stateCheckedNormalDayLongTextColourOne; set { _stateCheckedNormalDayLongTextColourOne = value; Invalidate(); } }

        public Color StateCheckedNormalDayLongTextColourTwo { get => _stateCheckedNormalDayLongTextColourTwo; set { _stateCheckedNormalDayLongTextColourTwo = value; Invalidate(); } }

        public Color StateCheckedNormalDayShortTextColourOne { get => _stateCheckedNormalDayShortTextColourOne; set { _stateCheckedNormalDayShortTextColourOne = value; Invalidate(); } }

        public Color StateCheckedNormalDayShortTextColourTwo { get => _stateCheckedNormalDayShortTextColourTwo; set { _stateCheckedNormalDayShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Checked Pressed
        public Color StateCheckedPressedDayBackgroundColourOne { get => _stateCheckedPressedDayBackgroundColourOne; set { _stateCheckedPressedDayBackgroundColourOne = value; Invalidate(); } }

        public Color StateCheckedPressedDayBackgroundColourTwo { get => _stateCheckedPressedDayBackgroundColourTwo; set { _stateCheckedPressedDayBackgroundColourTwo = value; Invalidate(); } }

        public Color StateCheckedPressedDayLongTextColourOne { get => _stateCheckedPressedDayLongTextColourOne; set { _stateCheckedPressedDayLongTextColourOne = value; Invalidate(); } }

        public Color StateCheckedPressedDayLongTextColourTwo { get => _stateCheckedPressedDayLongTextColourTwo; set { _stateCheckedPressedDayLongTextColourTwo = value; Invalidate(); } }

        public Color StateCheckedPressedDayShortTextColourOne { get => _stateCheckedPressedDayShortTextColourOne; set { _stateCheckedPressedDayShortTextColourOne = value; Invalidate(); } }

        public Color StateCheckedPressedDayShortTextColourTwo { get => _stateCheckedPressedDayShortTextColourTwo; set { _stateCheckedPressedDayShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Checked Tracking
        public Color StateCheckedTrackingDayBackgroundColourOne { get => _stateCheckedTrackingDayBackgroundColourOne; set { _stateCheckedTrackingDayBackgroundColourOne = value; Invalidate(); } }

        public Color StateCheckedTrackingDayBackgroundColourTwo { get => _stateCheckedTrackingDayBackgroundColourTwo; set { _stateCheckedTrackingDayBackgroundColourTwo = value; Invalidate(); } }

        public Color StateCheckedTrackingDayLongTextColourOne { get => _stateCheckedTrackingDayLongTextColourOne; set { _stateCheckedTrackingDayLongTextColourOne = value; Invalidate(); } }

        public Color StateCheckedTrackingDayLongTextColourTwo { get => _stateCheckedTrackingDayLongTextColourTwo; set { _stateCheckedTrackingDayLongTextColourTwo = value; Invalidate(); } }

        public Color StateCheckedTrackingDayShortTextColourOne { get => _stateCheckedTrackingDayShortTextColourOne; set { _stateCheckedTrackingDayShortTextColourOne = value; Invalidate(); } }

        public Color StateCheckedTrackingDayShortTextColourTwo { get => _stateCheckedTrackingDayShortTextColourTwo; set { _stateCheckedTrackingDayShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Common
        public Color StateCommonBackgroundColourOne { get => _stateCommonBackgroundColourOne; set { _stateCommonBackgroundColourOne = value; Invalidate(); } }

        public Color StateCommonBackgroundColourTwo { get => _stateCommonBackgroundColourTwo; set { _stateCommonBackgroundColourTwo = value; Invalidate(); } }

        public Color StateCommonDayBackgroundColourOne { get => _stateCommonDayBackgroundColourOne; set { _stateCommonDayBackgroundColourOne = value; Invalidate(); } }

        public Color StateCommonDayBackgroundColourTwo { get => _stateCommonDayBackgroundColourTwo; set { _stateCommonDayBackgroundColourTwo = value; Invalidate(); } }

        public Color StateCommonDayLongTextColourOne { get => _stateCommonDayLongTextColourOne; set { _stateCommonDayLongTextColourOne = value; Invalidate(); } }

        public Color StateCommonDayLongTextColourTwo { get => _stateCommonDayLongTextColourTwo; set { _stateCommonDayLongTextColourTwo = value; Invalidate(); } }

        public Color StateCommonDayShortTextColourOne { get => _stateCommonDayShortTextColourOne; set { _stateCommonDayShortTextColourOne = value; Invalidate(); } }

        public Color StateCommonDayShortTextColourTwo { get => _stateCommonDayShortTextColourTwo; set { _stateCommonDayShortTextColourTwo = value; Invalidate(); } }

        public Color StateCommonDayOfWeekBackgroundColourOne { get => _stateCommonDayOfWeekBackgroundColourOne; set { _stateCommonDayBackgroundColourOne = value; Invalidate(); } }

        public Color StateCommonDayOfWeekBackgroundColourTwo { get => _stateCommonDayOfWeekBackgroundColourTwo; set { _stateCommonDayOfWeekBackgroundColourTwo = value; Invalidate(); } }

        public Color StateCommonDayOfWeekLongTextColourOne { get => _stateCommonDayOfWeekLongTextColourOne; set { _stateCommonDayOfWeekLongTextColourOne = value; Invalidate(); } }

        public Color StateCommonDayOfWeekLongTextColourTwo { get => _stateCommonDayOfWeekLongTextColourTwo; set { _stateCommonDayOfWeekLongTextColourTwo = value; Invalidate(); } }

        public Color StateCommonDayOfWeekShortTextColourOne { get => _stateCommonDayOfWeekShortTextColourOne; set { _stateCommonDayOfWeekShortTextColourOne = value; Invalidate(); } }

        public Color StateCommonDayOfWeekShortTextColourTwo { get => _stateCommonDayOfWeekShortTextColourTwo; set { _stateCommonDayOfWeekShortTextColourTwo = value; Invalidate(); } }

        public Color StateCommonHeaderBackgroundColourOne { get => _stateCommonHeaderBackgroundColourOne; set { _stateCommonHeaderBackgroundColourOne = value; Invalidate(); } }

        public Color StateCommonHeaderBackgroundColourTwo { get => _stateCommonHeaderBackgroundColourTwo; set { _stateCommonHeaderBackgroundColourTwo = value; Invalidate(); } }

        public Color StateCommonHeaderLongTextColourOne { get => _stateCommonHeaderLongTextColourOne; set { _stateCommonHeaderLongTextColourOne = value; Invalidate(); } }

        public Color StateCommonHeaderLongTextColourTwo { get => _stateCommonHeaderLongTextColourTwo; set { _stateCommonHeaderLongTextColourTwo = value; Invalidate(); } }

        public Color StateCommonHeaderShortTextColourOne { get => _stateCommonHeaderShortTextColourOne; set { _stateCommonHeaderShortTextColourOne = value; Invalidate(); } }

        public Color StateCommonHeaderShortTextColourTwo { get => _stateCommonHeaderShortTextColourTwo; set { _stateCommonHeaderShortTextColourTwo = value; Invalidate(); } }

        public Color StateCommonBorderColourOne { get => _stateCommonBorderColourOne; set { _stateCommonBorderColourOne = value; Invalidate(); } }

        public Color StateCommonBorderColourTwo { get => _stateCommonBorderColourTwo; set { _stateCommonBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Disabled
        public Color StateDisabledBackgroundColourOne { get => _stateDisabledBackgroundColourOne; set { _stateDisabledBackgroundColourOne = value; Invalidate(); } }

        public Color StateDisabledBackgroundColourTwo { get => _stateDisabledBackgroundColourTwo; set { _stateDisabledBackgroundColourTwo = value; Invalidate(); } }

        public Color StateDisabledDayBackgroundColourOne { get => _stateDisabledDayBackgroundColourOne; set { _stateDisabledDayBackgroundColourOne = value; Invalidate(); } }

        public Color StateDisabledDayBackgroundColourTwo { get => _stateDisabledDayBackgroundColourTwo; set { _stateDisabledDayBackgroundColourTwo = value; Invalidate(); } }

        public Color StateDisabledDayLongTextColourOne { get => _stateDisabledDayLongTextColourOne; set { _stateDisabledDayLongTextColourOne = value; Invalidate(); } }

        public Color StateDisabledDayLongTextColourTwo { get => _stateDisabledDayLongTextColourTwo; set { _stateDisabledDayLongTextColourTwo = value; Invalidate(); } }

        public Color StateDisabledDayShortTextColourOne { get => _stateDisabledDayShortTextColourOne; set { _stateDisabledDayShortTextColourOne = value; Invalidate(); } }

        public Color StateDisabledDayShortTextColourTwo { get => _stateDisabledDayShortTextColourTwo; set { _stateDisabledDayShortTextColourTwo = value; Invalidate(); } }

        public Color StateDisabledDayOfWeekBackgroundColourOne { get => _stateDisabledDayOfWeekBackgroundColourOne; set { _stateDisabledDayBackgroundColourOne = value; Invalidate(); } }

        public Color StateDisabledDayOfWeekBackgroundColourTwo { get => _stateDisabledDayOfWeekBackgroundColourTwo; set { _stateDisabledDayOfWeekBackgroundColourTwo = value; Invalidate(); } }

        public Color StateDisabledDayOfWeekLongTextColourOne { get => _stateDisabledDayOfWeekLongTextColourOne; set { _stateDisabledDayOfWeekLongTextColourOne = value; Invalidate(); } }

        public Color StateDisabledDayOfWeekLongTextColourTwo { get => _stateDisabledDayOfWeekLongTextColourTwo; set { _stateDisabledDayOfWeekLongTextColourTwo = value; Invalidate(); } }

        public Color StateDisabledDayOfWeekShortTextColourOne { get => _stateDisabledDayOfWeekShortTextColourOne; set { _stateDisabledDayOfWeekShortTextColourOne = value; Invalidate(); } }

        public Color StateDisabledDayOfWeekShortTextColourTwo { get => _stateDisabledDayOfWeekShortTextColourTwo; set { _stateDisabledDayOfWeekShortTextColourTwo = value; Invalidate(); } }

        public Color StateDisabledHeaderBackgroundColourOne { get => _stateDisabledHeaderBackgroundColourOne; set { _stateDisabledHeaderBackgroundColourOne = value; Invalidate(); } }

        public Color StateDisabledHeaderBackgroundColourTwo { get => _stateDisabledHeaderBackgroundColourTwo; set { _stateDisabledHeaderBackgroundColourTwo = value; Invalidate(); } }

        public Color StateDisabledHeaderLongTextColourOne { get => _stateDisabledHeaderLongTextColourOne; set { _stateDisabledHeaderLongTextColourOne = value; Invalidate(); } }

        public Color StateDisabledHeaderLongTextColourTwo { get => _stateDisabledHeaderLongTextColourTwo; set { _stateDisabledHeaderLongTextColourTwo = value; Invalidate(); } }

        public Color StateDisabledHeaderShortTextColourOne { get => _stateDisabledHeaderShortTextColourOne; set { _stateDisabledHeaderShortTextColourOne = value; Invalidate(); } }

        public Color StateDisabledHeaderShortTextColourTwo { get => _stateDisabledHeaderShortTextColourTwo; set { _stateDisabledHeaderShortTextColourTwo = value; Invalidate(); } }

        public Color StateDisabledBorderColourOne { get => _stateDisabledBorderColourOne; set { _stateDisabledBorderColourOne = value; Invalidate(); } }

        public Color StateDisabledBorderColourTwo { get => _stateDisabledBorderColourTwo; set { _stateDisabledBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Normal
        public Color StateNormalBackgroundColourOne { get => _stateNormalBackgroundColourOne; set { _stateNormalBackgroundColourOne = value; Invalidate(); } }

        public Color StateNormalBackgroundColourTwo { get => _stateNormalBackgroundColourTwo; set { _stateNormalBackgroundColourTwo = value; Invalidate(); } }

        public Color StateNormalDayBackgroundColourOne { get => _stateNormalDayBackgroundColourOne; set { _stateNormalDayBackgroundColourOne = value; Invalidate(); } }

        public Color StateNormalDayBackgroundColourTwo { get => _stateNormalDayBackgroundColourTwo; set { _stateNormalDayBackgroundColourTwo = value; Invalidate(); } }

        public Color StateNormalDayLongTextColourOne { get => _stateNormalDayLongTextColourOne; set { _stateNormalDayLongTextColourOne = value; Invalidate(); } }

        public Color StateNormalDayLongTextColourTwo { get => _stateNormalDayLongTextColourTwo; set { _stateNormalDayLongTextColourTwo = value; Invalidate(); } }

        public Color StateNormalDayShortTextColourOne { get => _stateNormalDayShortTextColourOne; set { _stateNormalDayShortTextColourOne = value; Invalidate(); } }

        public Color StateNormalDayShortTextColourTwo { get => _stateNormalDayShortTextColourTwo; set { _stateNormalDayShortTextColourTwo = value; Invalidate(); } }

        public Color StateNormalDayOfWeekBackgroundColourOne { get => _stateNormalDayOfWeekBackgroundColourOne; set { _stateNormalDayBackgroundColourOne = value; Invalidate(); } }

        public Color StateNormalDayOfWeekBackgroundColourTwo { get => _stateNormalDayOfWeekBackgroundColourTwo; set { _stateNormalDayOfWeekBackgroundColourTwo = value; Invalidate(); } }

        public Color StateNormalDayOfWeekLongTextColourOne { get => _stateNormalDayOfWeekLongTextColourOne; set { _stateNormalDayOfWeekLongTextColourOne = value; Invalidate(); } }

        public Color StateNormalDayOfWeekLongTextColourTwo { get => _stateNormalDayOfWeekLongTextColourTwo; set { _stateNormalDayOfWeekLongTextColourTwo = value; Invalidate(); } }

        public Color StateNormalDayOfWeekShortTextColourOne { get => _stateNormalDayOfWeekShortTextColourOne; set { _stateNormalDayOfWeekShortTextColourOne = value; Invalidate(); } }

        public Color StateNormalDayOfWeekShortTextColourTwo { get => _stateNormalDayOfWeekShortTextColourTwo; set { _stateNormalDayOfWeekShortTextColourTwo = value; Invalidate(); } }

        public Color StateNormalHeaderBackgroundColourOne { get => _stateNormalHeaderBackgroundColourOne; set { _stateNormalHeaderBackgroundColourOne = value; Invalidate(); } }

        public Color StateNormalHeaderBackgroundColourTwo { get => _stateNormalHeaderBackgroundColourTwo; set { _stateNormalHeaderBackgroundColourTwo = value; Invalidate(); } }

        public Color StateNormalHeaderLongTextColourOne { get => _stateNormalHeaderLongTextColourOne; set { _stateNormalHeaderLongTextColourOne = value; Invalidate(); } }

        public Color StateNormalHeaderLongTextColourTwo { get => _stateNormalHeaderLongTextColourTwo; set { _stateNormalHeaderLongTextColourTwo = value; Invalidate(); } }

        public Color StateNormalHeaderShortTextColourOne { get => _stateNormalHeaderShortTextColourOne; set { _stateNormalHeaderShortTextColourOne = value; Invalidate(); } }

        public Color StateNormalHeaderShortTextColourTwo { get => _stateNormalHeaderShortTextColourTwo; set { _stateNormalHeaderShortTextColourTwo = value; Invalidate(); } }

        public Color StateNormalBorderColourOne { get => _stateNormalBorderColourOne; set { _stateNormalBorderColourOne = value; Invalidate(); } }

        public Color StateNormalBorderColourTwo { get => _stateNormalBorderColourTwo; set { _stateNormalBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Pressed
        public Color StatePressedDayBackgroundColourOne { get => _statePressedDayBackgroundColourOne; set { _statePressedDayBackgroundColourOne = value; Invalidate(); } }

        public Color StatePressedDayBackgroundColourTwo { get => _statePressedDayBackgroundColourTwo; set { _statePressedDayBackgroundColourTwo = value; Invalidate(); } }

        public Color StatePressedDayLongTextColourOne { get => _statePressedDayLongTextColourOne; set { _statePressedDayLongTextColourOne = value; Invalidate(); } }

        public Color StatePressedDayLongTextColourTwo { get => _statePressedDayLongTextColourTwo; set { _statePressedDayLongTextColourTwo = value; Invalidate(); } }

        public Color StatePressedDayShortTextColourOne { get => _statePressedDayShortTextColourOne; set { _statePressedDayShortTextColourOne = value; Invalidate(); } }

        public Color StatePressedDayShortTextColourTwo { get => _statePressedDayShortTextColourTwo; set { _statePressedDayShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Tracking
        public Color StateTrackingDayBackgroundColourOne { get => _stateTrackingDayBackgroundColourOne; set { _stateTrackingDayBackgroundColourOne = value; Invalidate(); } }

        public Color StateTrackingDayBackgroundColourTwo { get => _stateTrackingDayBackgroundColourTwo; set { _stateTrackingDayBackgroundColourTwo = value; Invalidate(); } }

        public Color StateTrackingDayLongTextColourOne { get => _stateTrackingDayLongTextColourOne; set { _stateTrackingDayLongTextColourOne = value; Invalidate(); } }

        public Color StateTrackingDayLongTextColourTwo { get => _stateTrackingDayLongTextColourTwo; set { _stateTrackingDayLongTextColourTwo = value; Invalidate(); } }

        public Color StateTrackingDayShortTextColourOne { get => _stateTrackingDayShortTextColourOne; set { _stateTrackingDayShortTextColourOne = value; Invalidate(); } }

        public Color StateTrackingDayShortTextColourTwo { get => _stateTrackingDayShortTextColourTwo; set { _stateTrackingDayShortTextColourTwo = value; Invalidate(); } }
        #endregion

        [Category("Appearance"), Description("The 'Long Text' typeface.")]
        public Font LongTextTypeface { get => _longTextTypeface; set { _longTextTypeface = value; Invalidate(); } }

        [Category("Appearance"), Description("The 'Short Text' typeface.")]
        public Font ShortTextTypeface { get => _shortTextTypeface; set { _shortTextTypeface = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonMonthCalendarExtended()
        {
            #region Override Bolded
            OverrideBoldedDayBackgroundColourOne = Color.Empty;

            OverrideBoldedDayBackgroundColourTwo = Color.Empty;

            OverrideBoldedDayLongTextColourOne = Color.Empty;

            OverrideBoldedDayLongTextColourTwo = Color.Empty;

            OverrideBoldedDayShortTextColourOne = Color.Empty;

            OverrideBoldedDayShortTextColourTwo = Color.Empty;
            #endregion

            #region Override Focus
            OverrideFocusDayBackgroundColourOne = Color.Empty;

            OverrideFocusDayBackgroundColourTwo = Color.Empty;

            OverrideFocusDayLongTextColourOne = Color.Empty;

            OverrideFocusDayLongTextColourTwo = Color.Empty;

            OverrideFocusDayShortTextColourOne = Color.Empty;

            OverrideFocusDayShortTextColourTwo = Color.Empty;
            #endregion

            #region Override Today
            OverrideTodayDayBackgroundColourOne = Color.Empty;

            OverrideTodayDayBackgroundColourTwo = Color.Empty;

            OverrideTodayDayLongTextColourOne = Color.Empty;

            OverrideTodayDayLongTextColourTwo = Color.Empty;

            OverrideTodayDayShortTextColourOne = Color.Empty;

            OverrideTodayDayShortTextColourTwo = Color.Empty;
            #endregion

            #region State Checked Normal
            StateCheckedNormalDayBackgroundColourOne = Color.Empty;

            StateCheckedNormalDayBackgroundColourTwo = Color.Empty;

            StateCheckedNormalDayLongTextColourOne = Color.Empty;

            StateCheckedNormalDayLongTextColourTwo = Color.Empty;

            StateCheckedNormalDayShortTextColourOne = Color.Empty;

            StateCheckedNormalDayShortTextColourTwo = Color.Empty;
            #endregion

            #region State Checked Pressed
            StateCheckedPressedDayBackgroundColourOne = Color.Empty;

            StateCheckedPressedDayBackgroundColourTwo = Color.Empty;

            StateCheckedPressedDayLongTextColourOne = Color.Empty;

            StateCheckedPressedDayLongTextColourTwo = Color.Empty;

            StateCheckedPressedDayShortTextColourOne = Color.Empty;

            StateCheckedPressedDayShortTextColourTwo = Color.Empty;
            #endregion

            #region State Checked Tracking
            StateCheckedTrackingDayBackgroundColourOne = Color.Empty;

            StateCheckedTrackingDayBackgroundColourTwo = Color.Empty;

            StateCheckedTrackingDayLongTextColourOne = Color.Empty;

            StateCheckedTrackingDayLongTextColourTwo = Color.Empty;

            StateCheckedTrackingDayShortTextColourOne = Color.Empty;

            StateCheckedTrackingDayShortTextColourTwo = Color.Empty;
            #endregion

            #region State Common
            StateCommonBackgroundColourOne = Color.Empty;

            StateCommonBackgroundColourTwo = Color.Empty;

            StateCommonDayBackgroundColourOne = Color.Empty;

            StateCommonDayBackgroundColourTwo = Color.Empty;

            StateCommonDayLongTextColourOne = Color.Empty;

            StateCommonDayLongTextColourTwo = Color.Empty;

            StateCommonDayShortTextColourOne = Color.Empty;

            StateCommonDayShortTextColourTwo = Color.Empty;

            StateCommonDayOfWeekBackgroundColourOne = Color.Empty;

            StateCommonDayOfWeekBackgroundColourTwo = Color.Empty;

            StateCommonDayOfWeekLongTextColourOne = Color.Empty;

            StateCommonDayOfWeekLongTextColourTwo = Color.Empty;

            StateCommonDayOfWeekShortTextColourOne = Color.Empty;

            StateCommonDayOfWeekShortTextColourTwo = Color.Empty;

            StateCommonHeaderBackgroundColourOne = Color.Empty;

            StateCommonHeaderBackgroundColourTwo = Color.Empty;

            StateCommonHeaderLongTextColourOne = Color.Empty;

            StateCommonHeaderLongTextColourTwo = Color.Empty;

            StateCommonHeaderShortTextColourOne = Color.Empty;

            StateCommonHeaderShortTextColourTwo = Color.Empty;

            StateCommonBorderColourOne = Color.Empty;

            StateCommonBorderColourTwo = Color.Empty;
            #endregion

            #region State Disabled
            StateDisabledBackgroundColourOne = Color.Empty;

            StateDisabledBackgroundColourTwo = Color.Empty;

            StateDisabledDayBackgroundColourOne = Color.Empty;

            StateDisabledDayBackgroundColourTwo = Color.Empty;

            StateDisabledDayLongTextColourOne = Color.Empty;

            StateDisabledDayLongTextColourTwo = Color.Empty;

            StateDisabledDayShortTextColourOne = Color.Empty;

            StateDisabledDayShortTextColourTwo = Color.Empty;

            StateDisabledDayOfWeekBackgroundColourOne = Color.Empty;

            StateDisabledDayOfWeekBackgroundColourTwo = Color.Empty;

            StateDisabledDayOfWeekLongTextColourOne = Color.Empty;

            StateDisabledDayOfWeekLongTextColourTwo = Color.Empty;

            StateDisabledDayOfWeekShortTextColourOne = Color.Empty;

            StateDisabledDayOfWeekShortTextColourTwo = Color.Empty;

            StateDisabledHeaderBackgroundColourOne = Color.Empty;

            StateDisabledHeaderBackgroundColourTwo = Color.Empty;

            StateDisabledHeaderLongTextColourOne = Color.Empty;

            StateDisabledHeaderLongTextColourTwo = Color.Empty;

            StateDisabledHeaderShortTextColourOne = Color.Empty;

            StateDisabledHeaderShortTextColourTwo = Color.Empty;

            StateDisabledBorderColourOne = Color.Empty;

            StateDisabledBorderColourTwo = Color.Empty;
            #endregion

            #region State Normal
            StateNormalBackgroundColourOne = Color.Empty;

            StateNormalBackgroundColourTwo = Color.Empty;

            StateNormalDayBackgroundColourOne = Color.Empty;

            StateNormalDayBackgroundColourTwo = Color.Empty;

            StateNormalDayLongTextColourOne = Color.Empty;

            StateNormalDayLongTextColourTwo = Color.Empty;

            StateNormalDayShortTextColourOne = Color.Empty;

            StateNormalDayShortTextColourTwo = Color.Empty;

            StateNormalDayOfWeekBackgroundColourOne = Color.Empty;

            StateNormalDayOfWeekBackgroundColourTwo = Color.Empty;

            StateNormalDayOfWeekLongTextColourOne = Color.Empty;

            StateNormalDayOfWeekLongTextColourTwo = Color.Empty;

            StateNormalDayOfWeekShortTextColourOne = Color.Empty;

            StateNormalDayOfWeekShortTextColourTwo = Color.Empty;

            StateNormalHeaderBackgroundColourOne = Color.Empty;

            StateNormalHeaderBackgroundColourTwo = Color.Empty;

            StateNormalHeaderLongTextColourOne = Color.Empty;

            StateNormalHeaderLongTextColourTwo = Color.Empty;

            StateNormalHeaderShortTextColourOne = Color.Empty;

            StateNormalHeaderShortTextColourTwo = Color.Empty;

            StateNormalBorderColourOne = Color.Empty;

            StateNormalBorderColourTwo = Color.Empty;
            #endregion

            #region State Pressed
            StatePressedDayBackgroundColourOne = Color.Empty;

            StatePressedDayBackgroundColourTwo = Color.Empty;

            StatePressedDayLongTextColourOne = Color.Empty;

            StatePressedDayLongTextColourTwo = Color.Empty;

            StatePressedDayShortTextColourOne = Color.Empty;

            StatePressedDayShortTextColourTwo = Color.Empty;
            #endregion

            #region State Tracking
            StateTrackingDayBackgroundColourOne = Color.Empty;

            StateTrackingDayBackgroundColourTwo = Color.Empty;

            StateTrackingDayLongTextColourOne = Color.Empty;

            StateTrackingDayLongTextColourTwo = Color.Empty;

            StateTrackingDayShortTextColourOne = Color.Empty;

            StateTrackingDayShortTextColourTwo = Color.Empty;
            #endregion

            LongTextTypeface = null;

            ShortTextTypeface = null;

            UpdateOverrideBoldedAppearanceValues(OverrideBoldedDayBackgroundColourOne, OverrideBoldedDayBackgroundColourTwo, OverrideBoldedDayLongTextColourOne, OverrideBoldedDayLongTextColourTwo, OverrideBoldedDayShortTextColourOne, OverrideBoldedDayShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateOverrideFocusAppearanceValues(OverrideFocusDayBackgroundColourOne, OverrideFocusDayBackgroundColourTwo, OverrideFocusDayLongTextColourOne, OverrideFocusDayLongTextColourTwo, OverrideFocusDayShortTextColourOne, OverrideFocusDayShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateOverrideTodayAppearanceValues(OverrideTodayDayBackgroundColourOne, OverrideTodayDayBackgroundColourTwo, OverrideTodayDayLongTextColourOne, OverrideTodayDayLongTextColourTwo, OverrideTodayDayShortTextColourOne, OverrideTodayDayShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateCheckedNormalAppearanceValues(StateCheckedNormalDayBackgroundColourOne, StateCheckedNormalDayBackgroundColourTwo, StateCheckedNormalDayLongTextColourOne, StateCheckedNormalDayLongTextColourTwo, StateCheckedNormalDayShortTextColourOne, StateCheckedNormalDayShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateCheckedPressedAppearanceValues(StateCheckedPressedDayBackgroundColourOne, StateCheckedPressedDayBackgroundColourTwo, StateCheckedPressedDayLongTextColourOne, StateCheckedPressedDayLongTextColourTwo, StateCheckedPressedDayShortTextColourOne, StateCheckedPressedDayShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateCheckedTrackingAppearanceValues(StateCheckedTrackingDayBackgroundColourOne, StateCheckedTrackingDayBackgroundColourTwo, StateCheckedTrackingDayLongTextColourOne, StateCheckedTrackingDayLongTextColourTwo, StateCheckedTrackingDayShortTextColourOne, StateCheckedTrackingDayShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateCommonAppearanceValues(StateCommonBackgroundColourOne, StateCommonBackgroundColourTwo, StateCommonDayBackgroundColourOne, StateCommonDayBackgroundColourTwo, StateCommonDayLongTextColourOne, StateCommonDayLongTextColourTwo, StateCommonDayShortTextColourOne, StateCommonDayShortTextColourTwo, StateCommonDayOfWeekBackgroundColourOne, StateCommonDayOfWeekBackgroundColourTwo, StateCommonDayOfWeekLongTextColourOne, StateCommonDayOfWeekLongTextColourTwo, StateCommonDayOfWeekShortTextColourOne, StateCommonDayOfWeekShortTextColourTwo, StateCommonHeaderBackgroundColourOne, StateCommonHeaderBackgroundColourTwo, StateCommonHeaderLongTextColourOne, StateCommonHeaderLongTextColourTwo, StateCommonHeaderShortTextColourOne, StateCommonHeaderShortTextColourTwo, StateCommonBorderColourOne, StateCommonBorderColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateDisabledAppearanceValues(StateDisabledBackgroundColourOne, StateDisabledBackgroundColourTwo, StateDisabledDayBackgroundColourOne, StateDisabledDayBackgroundColourTwo, StateDisabledDayLongTextColourOne, StateDisabledDayLongTextColourTwo, StateDisabledDayShortTextColourOne, StateDisabledDayShortTextColourTwo, StateDisabledDayOfWeekBackgroundColourOne, StateDisabledDayOfWeekBackgroundColourTwo, StateDisabledDayOfWeekLongTextColourOne, StateDisabledDayOfWeekLongTextColourTwo, StateDisabledDayOfWeekShortTextColourOne, StateDisabledDayOfWeekShortTextColourTwo, StateDisabledHeaderBackgroundColourOne, StateDisabledHeaderBackgroundColourTwo, StateDisabledHeaderLongTextColourOne, StateDisabledHeaderLongTextColourTwo, StateDisabledHeaderShortTextColourOne, StateDisabledBorderColourOne, StateDisabledBorderColourTwo, StateDisabledHeaderShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateNormalAppearanceValues(StateNormalBackgroundColourOne, StateNormalBackgroundColourTwo, StateNormalDayBackgroundColourOne, StateNormalDayBackgroundColourTwo, StateNormalDayLongTextColourOne, StateNormalDayLongTextColourTwo, StateNormalDayShortTextColourOne, StateNormalDayShortTextColourTwo, StateNormalDayOfWeekBackgroundColourOne, StateNormalDayOfWeekBackgroundColourTwo, StateNormalDayOfWeekLongTextColourOne, StateNormalDayOfWeekLongTextColourTwo, StateNormalDayOfWeekShortTextColourOne, StateNormalDayOfWeekShortTextColourTwo, StateNormalHeaderBackgroundColourOne, StateNormalHeaderBackgroundColourTwo, StateNormalHeaderLongTextColourOne, StateNormalHeaderLongTextColourTwo, StateNormalHeaderShortTextColourOne, StateNormalHeaderShortTextColourTwo, StateNormalBorderColourOne, StateNormalBorderColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStatePressedAppearanceValues(StatePressedDayBackgroundColourOne, StatePressedDayBackgroundColourTwo, StatePressedDayLongTextColourOne, StatePressedDayLongTextColourTwo, StatePressedDayShortTextColourOne, StatePressedDayShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateTrackingAppearanceValues(StateTrackingDayBackgroundColourOne, StateTrackingDayBackgroundColourTwo, StateTrackingDayLongTextColourOne, StateTrackingDayLongTextColourTwo, StateTrackingDayShortTextColourOne, StateTrackingDayShortTextColourTwo, LongTextTypeface, ShortTextTypeface);
        }
        #endregion

        #region Methods
        /// <summary>Updates the override bolded appearance values.</summary>
        /// <param name="stateCommonDayBackgroundColourOne">The state common day background colour one.</param>
        /// <param name="stateCommonDayBackgroundColourTwo">The state common day background colour two.</param>
        /// <param name="stateCommonDayLongTextColourOne">The state common day long text colour one.</param>
        /// <param name="stateCommonDayLongTextColourTwo">The state common day long text colour two.</param>
        /// <param name="stateCommonDayShortTextColourOne">The state common day short text colour one.</param>
        /// <param name="stateCommonDayShortTextColourTwo">The state common day short text colour two.</param>
        /// <param name="longTextTypeface">The long text typeface.</param>
        /// <param name="shortTextTypeface">The short text typeface.</param>
        private void UpdateOverrideBoldedAppearanceValues(Color stateCommonDayBackgroundColourOne, Color stateCommonDayBackgroundColourTwo, Color stateCommonDayLongTextColourOne, Color stateCommonDayLongTextColourTwo, Color stateCommonDayShortTextColourOne, Color stateCommonDayShortTextColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            OverrideBolded.Day.Back.Color1 = stateCommonDayBackgroundColourOne;

            OverrideBolded.Day.Back.Color2 = stateCommonDayBackgroundColourTwo;

            OverrideBolded.Day.Content.LongText.Color1 = stateCommonDayLongTextColourOne;

            OverrideBolded.Day.Content.LongText.Color2 = stateCommonDayLongTextColourTwo;

            OverrideBolded.Day.Content.LongText.Font = longTextTypeface;

            OverrideBolded.Day.Content.ShortText.Color1 = stateCommonDayShortTextColourOne;

            OverrideBolded.Day.Content.ShortText.Color2 = stateCommonDayShortTextColourTwo;

            OverrideBolded.Day.Content.ShortText.Font = shortTextTypeface;
        }

        private void UpdateOverrideFocusAppearanceValues(Color stateCommonDayBackgroundColourOne, Color stateCommonDayBackgroundColourTwo, Color stateCommonDayLongTextColourOne, Color stateCommonDayLongTextColourTwo, Color stateCommonDayShortTextColourOne, Color stateCommonDayShortTextColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            OverrideFocus.Day.Back.Color1 = stateCommonDayBackgroundColourOne;

            OverrideFocus.Day.Back.Color2 = stateCommonDayBackgroundColourTwo;

            OverrideFocus.Day.Content.LongText.Color1 = stateCommonDayLongTextColourOne;

            OverrideFocus.Day.Content.LongText.Color2 = stateCommonDayLongTextColourTwo;

            OverrideFocus.Day.Content.LongText.Font = longTextTypeface;

            OverrideFocus.Day.Content.ShortText.Color1 = stateCommonDayShortTextColourOne;

            OverrideFocus.Day.Content.ShortText.Color2 = stateCommonDayShortTextColourTwo;

            OverrideFocus.Day.Content.ShortText.Font = shortTextTypeface;
        }

        private void UpdateOverrideTodayAppearanceValues(Color stateCommonDayBackgroundColourOne, Color stateCommonDayBackgroundColourTwo, Color stateCommonDayLongTextColourOne, Color stateCommonDayLongTextColourTwo, Color stateCommonDayShortTextColourOne, Color stateCommonDayShortTextColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            OverrideToday.Day.Back.Color1 = stateCommonDayBackgroundColourOne;

            OverrideToday.Day.Back.Color2 = stateCommonDayBackgroundColourTwo;

            OverrideToday.Day.Content.LongText.Color1 = stateCommonDayLongTextColourOne;

            OverrideToday.Day.Content.LongText.Color2 = stateCommonDayLongTextColourTwo;

            OverrideToday.Day.Content.LongText.Font = longTextTypeface;

            OverrideToday.Day.Content.ShortText.Color1 = stateCommonDayShortTextColourOne;

            OverrideToday.Day.Content.ShortText.Color2 = stateCommonDayShortTextColourTwo;

            OverrideToday.Day.Content.ShortText.Font = shortTextTypeface;
        }

        private void UpdateStateCheckedNormalAppearanceValues(Color stateCheckedNormalDayBackgroundColourOne, Color stateCheckedNormalDayBackgroundColourTwo, Color stateCheckedNormalDayLongTextColourOne, Color stateCheckedNormalDayLongTextColourTwo, Color stateCheckedNormalDayShortTextColourOne, Color stateCheckedNormalDayShortTextColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            StateCheckedNormal.Day.Back.Color1 = stateCheckedNormalDayBackgroundColourOne;

            StateCheckedNormal.Day.Back.Color2 = stateCheckedNormalDayBackgroundColourTwo;

            StateCheckedNormal.Day.Content.LongText.Color1 = stateCheckedNormalDayLongTextColourOne;

            StateCheckedNormal.Day.Content.LongText.Color2 = stateCheckedNormalDayLongTextColourTwo;

            StateCheckedNormal.Day.Content.LongText.Font = longTextTypeface;

            StateCheckedNormal.Day.Content.ShortText.Color1 = stateCheckedNormalDayShortTextColourOne;

            StateCheckedNormal.Day.Content.ShortText.Color2 = stateCheckedNormalDayShortTextColourTwo;

            StateCheckedNormal.Day.Content.ShortText.Font = shortTextTypeface;
        }

        private void UpdateStateCheckedPressedAppearanceValues(Color stateCheckedPressedDayBackgroundColourOne, Color stateCheckedPressedDayBackgroundColourTwo, Color stateCheckedPressedDayLongTextColourOne, Color stateCheckedPressedDayLongTextColourTwo, Color stateCheckedPressedDayShortTextColourOne, Color stateCheckedPressedDayShortTextColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            StateCheckedPressed.Day.Back.Color1 = stateCheckedPressedDayBackgroundColourOne;

            StateCheckedPressed.Day.Back.Color2 = stateCheckedPressedDayBackgroundColourTwo;

            StateCheckedPressed.Day.Content.LongText.Color1 = stateCheckedPressedDayLongTextColourOne;

            StateCheckedPressed.Day.Content.LongText.Color2 = stateCheckedPressedDayLongTextColourTwo;

            StateCheckedPressed.Day.Content.LongText.Font = longTextTypeface;

            StateCheckedPressed.Day.Content.ShortText.Color1 = stateCheckedPressedDayShortTextColourOne;

            StateCheckedPressed.Day.Content.ShortText.Color2 = stateCheckedPressedDayShortTextColourTwo;

            StateCheckedPressed.Day.Content.ShortText.Font = shortTextTypeface;
        }

        private void UpdateStateCheckedTrackingAppearanceValues(Color stateCheckedTrackingDayBackgroundColourOne, Color stateCheckedTrackingDayBackgroundColourTwo, Color stateCheckedTrackingDayLongTextColourOne, Color stateCheckedTrackingDayLongTextColourTwo, Color stateCheckedTrackingDayShortTextColourOne, Color stateCheckedTrackingDayShortTextColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            StateCheckedTracking.Day.Back.Color1 = stateCheckedTrackingDayBackgroundColourOne;

            StateCheckedTracking.Day.Back.Color2 = stateCheckedTrackingDayBackgroundColourTwo;

            StateCheckedTracking.Day.Content.LongText.Color1 = stateCheckedTrackingDayLongTextColourOne;

            StateCheckedTracking.Day.Content.LongText.Color2 = stateCheckedTrackingDayLongTextColourTwo;

            StateCheckedTracking.Day.Content.LongText.Font = longTextTypeface;

            StateCheckedTracking.Day.Content.ShortText.Color1 = stateCheckedTrackingDayShortTextColourOne;

            StateCheckedTracking.Day.Content.ShortText.Color2 = stateCheckedTrackingDayShortTextColourTwo;

            StateCheckedTracking.Day.Content.ShortText.Font = shortTextTypeface;
        }

        /// <summary>Updates the state common appearance values.</summary>
        /// <param name="stateCommonBackgroundColourOne">The common background colour one.</param>
        /// <param name="stateCommonBackgroundColourTwo">The common background colour two.</param>
        /// <param name="stateCommonDayBackgroundColourOne">The stateCommonDay background colour one.</param>
        /// <param name="stateCommonDayBackgroundColourTwo">The stateCommonDay background colour two.</param>
        /// <param name="stateCommonDayLongTextColourOne">The stateCommonDay long text colour one.</param>
        /// <param name="stateCommonDayLongTextColourTwo">The stateCommonDay long text colour two.</param>
        /// <param name="stateCommonDayShortTextColourOne">The stateCommonDay short text colour one.</param>
        /// <param name="stateCommonDayShortTextColourTwo">The stateCommonDay short text colour two.</param>
        /// <param name="stateCommonDayOfWeekBackgroundColourOne">The stateCommonDay of week background colour one.</param>
        /// <param name="stateCommonDayOfWeekBackgroundColourTwo">The stateCommonDay of week background colour two.</param>
        /// <param name="stateCommonDayOfWeekLongTextColourOne">The stateCommonDay of week long text colour one.</param>
        /// <param name="stateCommonDayOfWeekLongTextColourTwo">The stateCommonDay of week long text colour two.</param>
        /// <param name="stateCommonDayOfWeekShortTextColourOne">The stateCommonDay of week short text colour one.</param>
        /// <param name="stateCommonDayOfWeekShortTextColourTwo">The stateCommonDay of week short text colour two.</param>
        /// <param name="stateCommonHeaderBackgroundColourOne">The stateCommonHeader background colour one.</param>
        /// <param name="stateCommonHeaderBackgroundColourTwo">The stateCommonHeader background colour two.</param>
        /// <param name="stateCommonHeaderLongTextColourOne">The stateCommonHeader long text colour one.</param>
        /// <param name="stateCommonHeaderLongTextColourTwo">The stateCommonHeader long text colour two.</param>
        /// <param name="stateCommonHeaderShortTextColourOne">The stateCommonHeader short text colour one.</param>
        /// <param name="stateCommonHeaderShortTextColourTwo">The stateCommonHeader short text colour two.</param>
        /// <param name="typeface">The typeface.</param>
        private void UpdateStateCommonAppearanceValues(Color stateCommonBackgroundColourOne, Color stateCommonBackgroundColourTwo, Color stateCommonDayBackgroundColourOne, Color stateCommonDayBackgroundColourTwo, Color stateCommonDayLongTextColourOne, Color stateCommonDayLongTextColourTwo, Color stateCommonDayShortTextColourOne, Color stateCommonDayShortTextColourTwo, Color stateCommonDayOfWeekBackgroundColourOne, Color stateCommonDayOfWeekBackgroundColourTwo, Color stateCommonDayOfWeekLongTextColourOne, Color stateCommonDayOfWeekLongTextColourTwo, Color stateCommonDayOfWeekShortTextColourOne, Color stateCommonDayOfWeekShortTextColourTwo, Color stateCommonHeaderBackgroundColourOne, Color stateCommonHeaderBackgroundColourTwo, Color stateCommonHeaderLongTextColourOne, Color stateCommonHeaderLongTextColourTwo, Color stateCommonHeaderShortTextColourOne, Color stateCommonHeaderShortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            StateCommon.Back.Color1 = stateCommonBackgroundColourOne;

            StateCommon.Back.Color2 = stateCommonBackgroundColourTwo;

            StateCommon.Day.Back.Color1 = stateCommonDayBackgroundColourOne;

            StateCommon.Day.Back.Color2 = stateCommonDayBackgroundColourTwo;

            StateCommon.Day.Content.LongText.Color1 = stateCommonDayLongTextColourOne;

            StateCommon.Day.Content.LongText.Color2 = stateCommonDayLongTextColourTwo;

            StateCommon.Day.Content.LongText.Font = longTextTypeface;

            StateCommon.Day.Content.ShortText.Color1 = stateCommonDayShortTextColourOne;

            StateCommon.Day.Content.ShortText.Color2 = stateCommonDayShortTextColourTwo;

            StateCommon.Day.Content.ShortText.Font = shortTextTypeface;

            StateCommon.DayOfWeek.Back.Color1 = stateCommonDayOfWeekBackgroundColourOne;

            StateCommon.DayOfWeek.Back.Color2 = stateCommonDayOfWeekBackgroundColourTwo;

            StateCommon.DayOfWeek.Content.LongText.Color1 = stateCommonDayOfWeekLongTextColourOne;

            StateCommon.DayOfWeek.Content.LongText.Color2 = stateCommonDayOfWeekLongTextColourTwo;

            StateCommon.DayOfWeek.Content.LongText.Font = longTextTypeface;

            StateCommon.DayOfWeek.Content.ShortText.Color1 = stateCommonDayOfWeekShortTextColourOne;

            StateCommon.DayOfWeek.Content.ShortText.Color2 = stateCommonDayOfWeekShortTextColourTwo;

            StateCommon.DayOfWeek.Content.ShortText.Font = shortTextTypeface;

            StateCommon.Header.Back.Color1 = stateCommonHeaderBackgroundColourOne;

            StateCommon.Header.Back.Color2 = stateCommonHeaderBackgroundColourTwo;

            StateCommon.Header.Content.LongText.Color1 = stateCommonHeaderLongTextColourOne;

            StateCommon.Header.Content.LongText.Color2 = stateCommonHeaderLongTextColourTwo;

            StateCommon.Header.Content.LongText.Font = longTextTypeface;

            StateCommon.Header.Content.ShortText.Color1 = stateCommonHeaderShortTextColourOne;

            StateCommon.Header.Content.ShortText.Color2 = stateCommonHeaderShortTextColourTwo;

            StateCommon.Border.Color1 = borderColourOne;

            StateCommon.Border.Color2 = borderColourTwo;

            StateCommon.Header.Content.ShortText.Font = shortTextTypeface;
        }

        private void UpdateStateDisabledAppearanceValues(Color stateDisabledBackgroundColourOne, Color stateDisabledBackgroundColourTwo, Color stateDisabledDayBackgroundColourOne, Color stateDisabledDayBackgroundColourTwo, Color stateDisabledDayLongTextColourOne, Color stateDisabledDayLongTextColourTwo, Color stateDisabledDayShortTextColourOne, Color stateDisabledDayShortTextColourTwo, Color stateDisabledDayOfWeekBackgroundColourOne, Color stateDisabledDayOfWeekBackgroundColourTwo, Color stateDisabledDayOfWeekLongTextColourOne, Color stateDisabledDayOfWeekLongTextColourTwo, Color stateDisabledDayOfWeekShortTextColourOne, Color stateDisabledDayOfWeekShortTextColourTwo, Color stateDisabledHeaderBackgroundColourOne, Color stateDisabledHeaderBackgroundColourTwo, Color stateDisabledHeaderLongTextColourOne, Color stateDisabledHeaderLongTextColourTwo, Color stateDisabledHeaderShortTextColourOne, Color stateDisabledHeaderShortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            StateDisabled.Back.Color1 = stateDisabledBackgroundColourOne;

            StateDisabled.Back.Color2 = stateDisabledBackgroundColourTwo;

            StateDisabled.Day.Back.Color1 = stateDisabledDayBackgroundColourOne;

            StateDisabled.Day.Back.Color2 = stateDisabledDayBackgroundColourTwo;

            StateDisabled.Day.Content.LongText.Color1 = stateDisabledDayLongTextColourOne;

            StateDisabled.Day.Content.LongText.Color2 = stateDisabledDayLongTextColourTwo;

            StateDisabled.Day.Content.LongText.Font = longTextTypeface;

            StateDisabled.Day.Content.ShortText.Color1 = stateDisabledDayShortTextColourOne;

            StateDisabled.Day.Content.ShortText.Color2 = stateDisabledDayShortTextColourTwo;

            StateDisabled.Day.Content.ShortText.Font = shortTextTypeface;

            StateDisabled.DayOfWeek.Back.Color1 = stateDisabledDayOfWeekBackgroundColourOne;

            StateDisabled.DayOfWeek.Back.Color2 = stateDisabledDayOfWeekBackgroundColourTwo;

            StateDisabled.DayOfWeek.Content.LongText.Color1 = stateDisabledDayOfWeekLongTextColourOne;

            StateDisabled.DayOfWeek.Content.LongText.Color2 = stateDisabledDayOfWeekLongTextColourTwo;

            StateDisabled.DayOfWeek.Content.LongText.Font = longTextTypeface;

            StateDisabled.DayOfWeek.Content.ShortText.Color1 = stateDisabledDayOfWeekShortTextColourOne;

            StateDisabled.DayOfWeek.Content.ShortText.Color2 = stateDisabledDayOfWeekShortTextColourTwo;

            StateDisabled.DayOfWeek.Content.ShortText.Font = shortTextTypeface;

            StateDisabled.Header.Back.Color1 = stateDisabledHeaderBackgroundColourOne;

            StateDisabled.Header.Back.Color2 = stateDisabledHeaderBackgroundColourTwo;

            StateDisabled.Header.Content.LongText.Color1 = stateDisabledHeaderLongTextColourOne;

            StateDisabled.Header.Content.LongText.Color2 = stateDisabledHeaderLongTextColourTwo;

            StateDisabled.Header.Content.LongText.Font = longTextTypeface;

            StateDisabled.Header.Content.ShortText.Color1 = stateDisabledHeaderShortTextColourOne;

            StateDisabled.Header.Content.ShortText.Color2 = stateDisabledHeaderShortTextColourTwo;

            StateDisabled.Border.Color1 = borderColourOne;

            StateDisabled.Border.Color2 = borderColourTwo;

            StateDisabled.Header.Content.ShortText.Font = shortTextTypeface;
        }

        private void UpdateStateNormalAppearanceValues(Color stateNormalBackgroundColourOne, Color stateNormalBackgroundColourTwo, Color stateNormalDayBackgroundColourOne, Color stateNormalDayBackgroundColourTwo, Color stateNormalDayLongTextColourOne, Color stateNormalDayLongTextColourTwo, Color stateNormalDayShortTextColourOne, Color stateNormalDayShortTextColourTwo, Color stateNormalDayOfWeekBackgroundColourOne, Color stateNormalDayOfWeekBackgroundColourTwo, Color stateNormalDayOfWeekLongTextColourOne, Color stateNormalDayOfWeekLongTextColourTwo, Color stateNormalDayOfWeekShortTextColourOne, Color stateNormalDayOfWeekShortTextColourTwo, Color stateNormalHeaderBackgroundColourOne, Color stateNormalHeaderBackgroundColourTwo, Color stateNormalHeaderLongTextColourOne, Color stateNormalHeaderLongTextColourTwo, Color stateNormalHeaderShortTextColourOne, Color stateNormalHeaderShortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            StateNormal.Back.Color1 = stateNormalBackgroundColourOne;

            StateNormal.Back.Color2 = stateNormalBackgroundColourTwo;

            StateNormal.Day.Back.Color1 = stateNormalDayBackgroundColourOne;

            StateNormal.Day.Back.Color2 = stateNormalDayBackgroundColourTwo;

            StateNormal.Day.Content.LongText.Color1 = stateNormalDayLongTextColourOne;

            StateNormal.Day.Content.LongText.Color2 = stateNormalDayLongTextColourTwo;

            StateNormal.Day.Content.LongText.Font = longTextTypeface;

            StateNormal.Day.Content.ShortText.Color1 = stateNormalDayShortTextColourOne;

            StateNormal.Day.Content.ShortText.Color2 = stateNormalDayShortTextColourTwo;

            StateNormal.Day.Content.ShortText.Font = shortTextTypeface;

            StateNormal.DayOfWeek.Back.Color1 = stateNormalDayOfWeekBackgroundColourOne;

            StateNormal.DayOfWeek.Back.Color2 = stateNormalDayOfWeekBackgroundColourTwo;

            StateNormal.DayOfWeek.Content.LongText.Color1 = stateNormalDayOfWeekLongTextColourOne;

            StateNormal.DayOfWeek.Content.LongText.Color2 = stateNormalDayOfWeekLongTextColourTwo;

            StateNormal.DayOfWeek.Content.LongText.Font = longTextTypeface;

            StateNormal.DayOfWeek.Content.ShortText.Color1 = stateNormalDayOfWeekShortTextColourOne;

            StateNormal.DayOfWeek.Content.ShortText.Color2 = stateNormalDayOfWeekShortTextColourTwo;

            StateNormal.DayOfWeek.Content.ShortText.Font = shortTextTypeface;

            StateNormal.Header.Back.Color1 = stateNormalHeaderBackgroundColourOne;

            StateNormal.Header.Back.Color2 = stateNormalHeaderBackgroundColourTwo;

            StateNormal.Header.Content.LongText.Color1 = stateNormalHeaderLongTextColourOne;

            StateNormal.Header.Content.LongText.Color2 = stateNormalHeaderLongTextColourTwo;

            StateNormal.Header.Content.LongText.Font = longTextTypeface;

            StateNormal.Header.Content.ShortText.Color1 = stateNormalHeaderShortTextColourOne;

            StateNormal.Header.Content.ShortText.Color2 = stateNormalHeaderShortTextColourTwo;

            StateNormal.Border.Color1 = borderColourOne;

            StateNormal.Border.Color2 = borderColourTwo;

            StateNormal.Header.Content.ShortText.Font = shortTextTypeface;
        }

        private void UpdateStatePressedAppearanceValues(Color statePressedDayBackgroundColourOne, Color statePressedDayBackgroundColourTwo, Color statePressedDayLongTextColourOne, Color statePressedDayLongTextColourTwo, Color statePressedDayShortTextColourOne, Color statePressedDayShortTextColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            StatePressed.Day.Back.Color1 = statePressedDayBackgroundColourOne;

            StatePressed.Day.Back.Color2 = statePressedDayBackgroundColourTwo;

            StatePressed.Day.Content.LongText.Color1 = statePressedDayLongTextColourOne;

            StatePressed.Day.Content.LongText.Color2 = statePressedDayLongTextColourTwo;

            StatePressed.Day.Content.LongText.Font = longTextTypeface;

            StatePressed.Day.Content.ShortText.Color1 = statePressedDayShortTextColourOne;

            StatePressed.Day.Content.ShortText.Color2 = statePressedDayShortTextColourTwo;

            StatePressed.Day.Content.ShortText.Font = shortTextTypeface;
        }

        private void UpdateStateTrackingAppearanceValues(Color stateTrackingDayBackgroundColourOne, Color stateTrackingDayBackgroundColourTwo, Color stateTrackingDayLongTextColourOne, Color stateTrackingDayLongTextColourTwo, Color stateTrackingDayShortTextColourOne, Color stateTrackingDayShortTextColourTwo, Font longTextTypeface, Font shortTextTypeface)
        {
            StateTracking.Day.Back.Color1 = stateTrackingDayBackgroundColourOne;

            StateTracking.Day.Back.Color2 = stateTrackingDayBackgroundColourTwo;

            StateTracking.Day.Content.LongText.Color1 = stateTrackingDayLongTextColourOne;

            StateTracking.Day.Content.LongText.Color2 = stateTrackingDayLongTextColourTwo;

            StateTracking.Day.Content.LongText.Font = longTextTypeface;

            StateTracking.Day.Content.ShortText.Color1 = stateTrackingDayShortTextColourOne;

            StateTracking.Day.Content.ShortText.Color2 = stateTrackingDayShortTextColourTwo;

            StateTracking.Day.Content.ShortText.Font = shortTextTypeface;
        }
        #endregion

        #region Override
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateOverrideBoldedAppearanceValues(OverrideBoldedDayBackgroundColourOne, OverrideBoldedDayBackgroundColourTwo, OverrideBoldedDayLongTextColourOne, OverrideBoldedDayLongTextColourTwo, OverrideBoldedDayShortTextColourOne, OverrideBoldedDayShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateOverrideFocusAppearanceValues(OverrideFocusDayBackgroundColourOne, OverrideFocusDayBackgroundColourTwo, OverrideFocusDayLongTextColourOne, OverrideFocusDayLongTextColourTwo, OverrideFocusDayShortTextColourOne, OverrideFocusDayShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateOverrideTodayAppearanceValues(OverrideTodayDayBackgroundColourOne, OverrideTodayDayBackgroundColourTwo, OverrideTodayDayLongTextColourOne, OverrideTodayDayLongTextColourTwo, OverrideTodayDayShortTextColourOne, OverrideTodayDayShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateCheckedNormalAppearanceValues(StateCheckedNormalDayBackgroundColourOne, StateCheckedNormalDayBackgroundColourTwo, StateCheckedNormalDayLongTextColourOne, StateCheckedNormalDayLongTextColourTwo, StateCheckedNormalDayShortTextColourOne, StateCheckedNormalDayShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateCheckedPressedAppearanceValues(StateCheckedPressedDayBackgroundColourOne, StateCheckedPressedDayBackgroundColourTwo, StateCheckedPressedDayLongTextColourOne, StateCheckedPressedDayLongTextColourTwo, StateCheckedPressedDayShortTextColourOne, StateCheckedPressedDayShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateCheckedTrackingAppearanceValues(StateCheckedTrackingDayBackgroundColourOne, StateCheckedTrackingDayBackgroundColourTwo, StateCheckedTrackingDayLongTextColourOne, StateCheckedTrackingDayLongTextColourTwo, StateCheckedTrackingDayShortTextColourOne, StateCheckedTrackingDayShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateCommonAppearanceValues(StateCommonBackgroundColourOne, StateCommonBackgroundColourTwo, StateCommonDayBackgroundColourOne, StateCommonDayBackgroundColourTwo, StateCommonDayLongTextColourOne, StateCommonDayLongTextColourTwo, StateCommonDayShortTextColourOne, StateCommonDayShortTextColourTwo, StateCommonDayOfWeekBackgroundColourOne, StateCommonDayOfWeekBackgroundColourTwo, StateCommonDayOfWeekLongTextColourOne, StateCommonDayOfWeekLongTextColourTwo, StateCommonDayOfWeekShortTextColourOne, StateCommonDayOfWeekShortTextColourTwo, StateCommonHeaderBackgroundColourOne, StateCommonHeaderBackgroundColourTwo, StateCommonHeaderLongTextColourOne, StateCommonHeaderLongTextColourTwo, StateCommonHeaderShortTextColourOne, StateCommonHeaderShortTextColourTwo, StateCommonBorderColourOne, StateCommonBorderColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateDisabledAppearanceValues(StateDisabledBackgroundColourOne, StateDisabledBackgroundColourTwo, StateDisabledDayBackgroundColourOne, StateDisabledDayBackgroundColourTwo, StateDisabledDayLongTextColourOne, StateDisabledDayLongTextColourTwo, StateDisabledDayShortTextColourOne, StateDisabledDayShortTextColourTwo, StateDisabledDayOfWeekBackgroundColourOne, StateDisabledDayOfWeekBackgroundColourTwo, StateDisabledDayOfWeekLongTextColourOne, StateDisabledDayOfWeekLongTextColourTwo, StateDisabledDayOfWeekShortTextColourOne, StateDisabledDayOfWeekShortTextColourTwo, StateDisabledHeaderBackgroundColourOne, StateDisabledHeaderBackgroundColourTwo, StateDisabledHeaderLongTextColourOne, StateDisabledHeaderLongTextColourTwo, StateDisabledHeaderShortTextColourOne, StateDisabledBorderColourOne, StateDisabledBorderColourTwo, StateDisabledHeaderShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateNormalAppearanceValues(StateNormalBackgroundColourOne, StateNormalBackgroundColourTwo, StateNormalDayBackgroundColourOne, StateNormalDayBackgroundColourTwo, StateNormalDayLongTextColourOne, StateNormalDayLongTextColourTwo, StateNormalDayShortTextColourOne, StateNormalDayShortTextColourTwo, StateNormalDayOfWeekBackgroundColourOne, StateNormalDayOfWeekBackgroundColourTwo, StateNormalDayOfWeekLongTextColourOne, StateNormalDayOfWeekLongTextColourTwo, StateNormalDayOfWeekShortTextColourOne, StateNormalDayOfWeekShortTextColourTwo, StateNormalHeaderBackgroundColourOne, StateNormalHeaderBackgroundColourTwo, StateNormalHeaderLongTextColourOne, StateNormalHeaderLongTextColourTwo, StateNormalHeaderShortTextColourOne, StateNormalHeaderShortTextColourTwo, StateNormalBorderColourOne, StateNormalBorderColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStatePressedAppearanceValues(StatePressedDayBackgroundColourOne, StatePressedDayBackgroundColourTwo, StatePressedDayLongTextColourOne, StatePressedDayLongTextColourTwo, StatePressedDayShortTextColourOne, StatePressedDayShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            UpdateStateTrackingAppearanceValues(StateTrackingDayBackgroundColourOne, StateTrackingDayBackgroundColourTwo, StateTrackingDayLongTextColourOne, StateTrackingDayLongTextColourTwo, StateTrackingDayShortTextColourOne, StateTrackingDayShortTextColourTwo, LongTextTypeface, ShortTextTypeface);

            base.OnPaint(e);
        }
        #endregion
    }
}