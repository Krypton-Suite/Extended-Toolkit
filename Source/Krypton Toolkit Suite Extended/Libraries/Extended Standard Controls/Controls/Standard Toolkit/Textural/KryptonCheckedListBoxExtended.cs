using ComponentFactory.Krypton.Toolkit;
using ExtendedStandardControls.Classes;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ExtendedStandardControls
{
    [ToolboxBitmap(typeof(KryptonCheckedListBox))]
    public class KryptonCheckedListBoxExtended : KryptonCheckedListBox
    {
        #region Variables
        private Color _overrideFocusItemBackgroundColourOne, _overrideFocusItemBackgroundColourTwo, _overrideFocusLongTextColourOne, _overrideFocusLongTextColourTwo, _overrideFocusShortTextColourOne, _overrideFocusShortTextColourTwo,
                      _stateActiveBackgroundColourOne, _stateActiveBackgroundColourTwo, _stateActiveBorderColourOne, _stateActiveBorderColourTwo,
                      _stateCheckedNormalItemBackgroundColourOne, _stateCheckedNormalItemBackgroundColourTwo, _stateCheckedNormalLongTextColourOne, _stateCheckedNormalLongTextColourTwo, _stateCheckedNormalShortTextColourOne, _stateCheckedNormalShortTextColourTwo,
                      _stateCheckedPressedItemBackgroundColourOne, _stateCheckedPressedItemBackgroundColourTwo, _stateCheckedPressedLongTextColourOne, _stateCheckedPressedLongTextColourTwo, _stateCheckedPressedShortTextColourOne, _stateCheckedPressedShortTextColourTwo,
                      _stateCheckedTrackingItemBackgroundColourOne, _stateCheckedTrackingItemBackgroundColourTwo, _stateCheckedTrackingLongTextColourOne, _stateCheckedTrackingLongTextColourTwo, _stateCheckedTrackingShortTextColourOne, _stateCheckedTrackingShortTextColourTwo,
                      _stateCommonBackgroundColourOne, _stateCommonBackgroundColourTwo, _stateCommonItemBackgroundColourOne, _stateCommonItemBackgroundColourTwo, _stateCommonLongTextColourOne, _stateCommonLongTextColourTwo, _stateCommonShortTextColourOne, _stateCommonShortTextColourTwo, _stateCommonBorderColourOne, _stateCommonBorderColourTwo,
                      _stateDisabledBackgroundColourOne, _stateDisabledBackgroundColourTwo, _stateDisabledItemBackgroundColourOne, _stateDisabledItemBackgroundColourTwo, _stateDisabledLongTextColourOne, _stateDisabledLongTextColourTwo, _stateDisabledShortTextColourOne, _stateDisabledShortTextColourTwo, _stateDisabledBorderColourOne, _stateDisabledBorderColourTwo,
                      _stateNormalBackgroundColourOne, _stateNormalBackgroundColourTwo, _stateNormalItemBackgroundColourOne, _stateNormalItemBackgroundColourTwo, _stateNormalLongTextColourOne, _stateNormalLongTextColourTwo, _stateNormalShortTextColourOne, _stateNormalShortTextColourTwo, _stateNormalBorderColourOne, _stateNormalBorderColourTwo,
                      _statePressedItemBackgroundColourOne, _statePressedItemBackgroundColourTwo, _statePressedLongTextColourOne, _statePressedLongTextColourTwo, _statePressedShortTextColourOne, _statePressedShortTextColourTwo,
                      _stateTrackingItemBackgroundColourOne, _stateTrackingItemBackgroundColourTwo, _stateTrackingLongTextColourOne, _stateTrackingLongTextColourTwo, _stateTrackingShortTextColourOne, _stateTrackingShortTextColourTwo;

        private Font _longTextTypeface, _shortTextTypeface;

        private Image _image;
        #endregion

        #region Properties

        #region Override Focus
        [Category("Appearance"), Description("The first item background colour.")]
        public Color OverrideFocusItemBackgroundColourOne { get => _overrideFocusItemBackgroundColourOne; set { _overrideFocusItemBackgroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second item background colour.")]
        public Color OverrideFocusItemBackgroundColourTwo { get => _overrideFocusItemBackgroundColourTwo; set { _overrideFocusItemBackgroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first long text colour.")]
        public Color OverrideFocusLongTextColourOne { get => _overrideFocusLongTextColourOne; set { _overrideFocusLongTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second long text colour.")]
        public Color OverrideFocusLongTextColourTwo { get => _overrideFocusLongTextColourTwo; set { _overrideFocusLongTextColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first short text colour.")]
        public Color OverrideFocusShortTextColourOne { get => _overrideFocusShortTextColourOne; set { _overrideFocusShortTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second short text colour.")]
        public Color OverrideFocusShortTextColourTwo { get => _overrideFocusShortTextColourTwo; set { _overrideFocusShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Active
        [Category("Appearance"), Description("The first background colour.")]
        public Color StateActiveBackgroundColourOne { get => _stateActiveBackgroundColourOne; set { _stateActiveBackgroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second background colour.")]
        public Color StateActiveBackgroundColourTwo { get => _stateActiveBackgroundColourTwo; set { _stateActiveBackgroundColourTwo = value; Invalidate(); } }

        public Color StateActiveBorderColourOne { get => _stateActiveBorderColourOne; set { _stateActiveBorderColourOne = value; Invalidate(); } }

        public Color StateActiveBorderColourTwo { get => _stateActiveBorderColourTwo; set { _stateActiveBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region Checked Normal        
        [Category("Appearance"), Description("The first item background colour.")]
        public Color StateCheckedNormalItemBackgroundColourOne { get => _stateCheckedNormalItemBackgroundColourOne; set { _stateCheckedNormalItemBackgroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second item background colour.")]
        public Color StateCheckedNormalItemBackgroundColourTwo { get => _stateCheckedNormalItemBackgroundColourTwo; set { _stateCheckedNormalItemBackgroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first long text colour.")]
        public Color StateCheckedNormalLongTextColourOne { get => _stateCheckedNormalLongTextColourOne; set { _stateCheckedNormalLongTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second long text colour.")]
        public Color StateCheckedNormalLongTextColourTwo { get => _stateCheckedNormalLongTextColourTwo; set { _stateCheckedNormalLongTextColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first short text colour.")]
        public Color StateCheckedNormalShortTextColourOne { get => _stateCheckedNormalShortTextColourOne; set { _stateCheckedNormalShortTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second short text colour.")]
        public Color StateCheckedNormalShortTextColourTwo { get => _stateCheckedNormalShortTextColourTwo; set { _stateCheckedNormalShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region Checked Pressed 
        [Category("Appearance"), Description("The first item background colour.")]
        public Color StateCheckedPressedItemBackgroundColourOne { get => _stateCheckedPressedItemBackgroundColourOne; set { _stateCheckedPressedItemBackgroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second item background colour.")]
        public Color StateCheckedPressedItemBackgroundColourTwo { get => _stateCheckedPressedItemBackgroundColourTwo; set { _stateCheckedPressedItemBackgroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first long text colour.")]
        public Color StateCheckedPressedLongTextColourOne { get => _stateCheckedPressedLongTextColourOne; set { _stateCheckedPressedLongTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second long text colour.")]
        public Color StateCheckedPressedLongTextColourTwo { get => _stateCheckedPressedLongTextColourTwo; set { _stateCheckedPressedLongTextColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first short text colour.")]
        public Color StateCheckedPressedShortTextColourOne { get => _stateCheckedPressedShortTextColourOne; set { _stateCheckedPressedShortTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second short text colour.")]
        public Color StateCheckedPressedShortTextColourTwo { get => _stateCheckedPressedShortTextColourTwo; set { _stateCheckedPressedShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region Checked Tracking
        [Category("Appearance"), Description("The first item background colour.")]
        public Color StateCheckedTrackingItemBackgroundColourOne { get => _stateCheckedTrackingItemBackgroundColourOne; set { _stateCheckedTrackingItemBackgroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second item background colour.")]
        public Color StateCheckedTrackingItemBackgroundColourTwo { get => _stateCheckedTrackingItemBackgroundColourTwo; set { _stateCheckedTrackingItemBackgroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first long text colour.")]
        public Color StateCheckedTrackingLongTextColourOne { get => _stateCheckedTrackingLongTextColourOne; set { _stateCheckedTrackingLongTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second long text colour.")]
        public Color StateCheckedTrackingLongTextColourTwo { get => _stateCheckedTrackingLongTextColourTwo; set { _stateCheckedTrackingLongTextColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first short text colour.")]
        public Color StateCheckedTrackingShortTextColourOne { get => _stateCheckedTrackingShortTextColourOne; set { _stateCheckedTrackingShortTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second short text colour.")]
        public Color StateCheckedTrackingShortTextColourTwo { get => _stateCheckedTrackingShortTextColourTwo; set { _stateCheckedTrackingShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Common
        [Category("Appearance"), Description("The first background colour.")]
        public Color StateCommonBackgroundColourOne { get => _stateCommonBackgroundColourOne; set { _stateCommonBackgroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second background colour.")]
        public Color StateCommonBackgroundColourTwo { get => _stateCommonBackgroundColourTwo; set { _stateCommonBackgroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first item background colour.")]
        public Color StateCommonItemBackgroundColourOne { get => _stateCommonItemBackgroundColourOne; set { _stateCommonItemBackgroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second item background colour.")]
        public Color StateCommonItemBackgroundColourTwo { get => _stateCommonItemBackgroundColourTwo; set { _stateCommonItemBackgroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first long text colour.")]
        public Color StateCommonLongTextColourOne { get => _stateCommonLongTextColourOne; set { _stateCommonLongTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second long text colour.")]
        public Color StateCommonLongTextColourTwo { get => _stateCommonLongTextColourTwo; set { _stateCommonLongTextColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first short text colour.")]
        public Color StateCommonShortTextColourOne { get => _stateCommonShortTextColourOne; set { _stateCommonShortTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second short text colour.")]
        public Color StateCommonShortTextColourTwo { get => _stateCommonShortTextColourTwo; set { _stateCommonShortTextColourTwo = value; Invalidate(); } }

        public Color StateCommonBorderColourOne { get => _stateCommonBorderColourOne; set { _stateCommonBorderColourOne = value; Invalidate(); } }

        public Color StateCommonBorderColourTwo { get => _stateCommonBorderColourTwo; set { _stateCommonBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Disabled
        [Category("Appearance"), Description("The first background colour.")]
        public Color StateDisabledBackgroundColourOne { get => _stateDisabledBackgroundColourOne; set { _stateDisabledBackgroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second background colour.")]
        public Color StateDisabledBackgroundColourTwo { get => _stateDisabledBackgroundColourTwo; set { _stateDisabledBackgroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first item background colour.")]
        public Color StateDisabledItemBackgroundColourOne { get => _stateDisabledItemBackgroundColourOne; set { _stateDisabledItemBackgroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second item background colour.")]
        public Color StateDisabledItemBackgroundColourTwo { get => _stateDisabledItemBackgroundColourTwo; set { _stateDisabledItemBackgroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first long text colour.")]
        public Color StateDisabledLongTextColourOne { get => _stateDisabledLongTextColourOne; set { _stateDisabledLongTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second long text colour.")]
        public Color StateDisabledLongTextColourTwo { get => _stateDisabledLongTextColourTwo; set { _stateDisabledLongTextColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first short text colour.")]
        public Color StateDisabledShortTextColourOne { get => _stateDisabledShortTextColourOne; set { _stateDisabledShortTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second short text colour.")]
        public Color StateDisabledShortTextColourTwo { get => _stateDisabledShortTextColourTwo; set { _stateDisabledShortTextColourTwo = value; Invalidate(); } }

        public Color StateDisabledBorderColourOne { get => _stateDisabledBorderColourOne; set { _stateDisabledBorderColourOne = value; Invalidate(); } }

        public Color StateDisabledBorderColourTwo { get => _stateDisabledBorderColourTwo; set { _stateDisabledBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Normal
        [Category("Appearance"), Description("The first background colour.")]
        public Color StateNormalBackgroundColourOne { get => _stateNormalBackgroundColourOne; set { _stateNormalBackgroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second background colour.")]
        public Color StateNormalBackgroundColourTwo { get => _stateNormalBackgroundColourTwo; set { _stateNormalBackgroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first item background colour.")]
        public Color StateNormalItemBackgroundColourOne { get => _stateNormalItemBackgroundColourOne; set { _stateNormalItemBackgroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second item background colour.")]
        public Color StateNormalItemBackgroundColourTwo { get => _stateNormalItemBackgroundColourTwo; set { _stateNormalItemBackgroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first long text colour.")]
        public Color StateNormalLongTextColourOne { get => _stateNormalLongTextColourOne; set { _stateNormalLongTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second long text colour.")]
        public Color StateNormalLongTextColourTwo { get => _stateNormalLongTextColourTwo; set { _stateNormalLongTextColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first short text colour.")]
        public Color StateNormalShortTextColourOne { get => _stateNormalShortTextColourOne; set { _stateNormalShortTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second short text colour.")]
        public Color StateNormalShortTextColourTwo { get => _stateNormalShortTextColourTwo; set { _stateNormalShortTextColourTwo = value; Invalidate(); } }

        public Color StateNormalBorderColourOne { get => _stateNormalBorderColourOne; set { _stateNormalBorderColourOne = value; Invalidate(); } }

        public Color StateNormalBorderColourTwo { get => _stateNormalBorderColourTwo; set { _stateNormalBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Pressed
        [Category("Appearance"), Description("The first item background colour.")]
        public Color StatePressedItemBackgroundColourOne { get => _statePressedItemBackgroundColourOne; set { _statePressedItemBackgroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second item background colour.")]
        public Color StatePressedItemBackgroundColourTwo { get => _statePressedItemBackgroundColourTwo; set { _statePressedItemBackgroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first long text colour.")]
        public Color StatePressedLongTextColourOne { get => _statePressedLongTextColourOne; set { _statePressedLongTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second long text colour.")]
        public Color StatePressedLongTextColourTwo { get => _statePressedLongTextColourTwo; set { _statePressedLongTextColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first short text colour.")]
        public Color StatePressedShortTextColourOne { get => _statePressedShortTextColourOne; set { _statePressedShortTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second short text colour.")]
        public Color StatePressedShortTextColourTwo { get => _statePressedShortTextColourTwo; set { _statePressedShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Tracking
        [Category("Appearance"), Description("The first item background colour.")]
        public Color StateTrackingItemBackgroundColourOne { get => _stateTrackingItemBackgroundColourOne; set { _stateTrackingItemBackgroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second item background colour.")]
        public Color StateTrackingItemBackgroundColourTwo { get => _stateTrackingItemBackgroundColourTwo; set { _stateTrackingItemBackgroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first long text colour.")]
        public Color StateTrackingLongTextColourOne { get => _stateTrackingLongTextColourOne; set { _stateTrackingLongTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second long text colour.")]
        public Color StateTrackingLongTextColourTwo { get => _stateTrackingLongTextColourTwo; set { _stateTrackingLongTextColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first short text colour.")]
        public Color StateTrackingShortTextColourOne { get => _stateTrackingShortTextColourOne; set { _stateTrackingShortTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second short text colour.")]
        public Color StateTrackingShortTextColourTwo { get => _stateTrackingShortTextColourTwo; set { _stateTrackingShortTextColourTwo = value; Invalidate(); } }
        #endregion

        [Category("Appearance"), Description("The 'Long Text' typeface.")]
        public Font LongTextTypeface { get => _longTextTypeface; set { _longTextTypeface = value; Invalidate(); } }

        [Category("Appearance"), Description("The 'Short Text' typeface.")]
        public Font ShortTextTypeface { get => _shortTextTypeface; set { _shortTextTypeface = value; Invalidate(); } }

        [Category("Appearance"), Description("The chosen image.")]
        public Image Image { get => _image; set { _image = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonCheckedListBoxExtended()
        {
            #region Override Focus
            OverrideFocusItemBackgroundColourOne = Color.Empty;

            OverrideFocusItemBackgroundColourTwo = Color.Empty;

            OverrideFocusLongTextColourOne = SystemColors.ControlText;

            OverrideFocusLongTextColourTwo = SystemColors.ControlText;

            OverrideFocusShortTextColourOne = SystemColors.ControlText;

            OverrideFocusShortTextColourTwo = SystemColors.ControlText;
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

            StateCheckedNormalLongTextColourOne = SystemColors.ControlText;

            StateCheckedNormalLongTextColourTwo = SystemColors.ControlText;

            StateCheckedNormalShortTextColourOne = SystemColors.ControlText;

            StateCheckedNormalShortTextColourTwo = SystemColors.ControlText;
            #endregion

            #region State Checked Pressed
            StateCheckedPressedItemBackgroundColourOne = Color.Empty;

            StateCheckedPressedItemBackgroundColourTwo = Color.Empty;

            StateCheckedPressedLongTextColourOne = SystemColors.ControlText;

            StateCheckedPressedLongTextColourTwo = SystemColors.ControlText;

            StateCheckedPressedShortTextColourOne = SystemColors.ControlText;

            StateCheckedPressedShortTextColourTwo = SystemColors.ControlText;
            #endregion

            #region State Checked Tracking
            StateCheckedTrackingItemBackgroundColourOne = Color.Empty;

            StateCheckedTrackingItemBackgroundColourTwo = Color.Empty;

            StateCheckedTrackingLongTextColourOne = SystemColors.ControlText;

            StateCheckedTrackingLongTextColourTwo = SystemColors.ControlText;

            StateCheckedTrackingShortTextColourOne = SystemColors.ControlText;

            StateCheckedTrackingShortTextColourTwo = SystemColors.ControlText;
            #endregion

            #region State Common
            StateCommonBackgroundColourOne = Color.Empty;

            StateCommonBackgroundColourTwo = Color.Empty;

            StateCommonBorderColourOne = Color.Empty;

            StateCommonBorderColourTwo = Color.Empty;

            StateCommonItemBackgroundColourOne = Color.Empty;

            StateCommonItemBackgroundColourTwo = Color.Empty;

            StateCommonLongTextColourOne = SystemColors.ControlText;

            StateCommonLongTextColourTwo = SystemColors.ControlText;

            StateCommonShortTextColourOne = SystemColors.ControlText;

            StateCommonShortTextColourTwo = SystemColors.ControlText;
            #endregion

            #region State Disabled
            StateDisabledBackgroundColourOne = Color.Empty;

            StateDisabledBackgroundColourTwo = Color.Empty;

            StateDisabledBorderColourOne = Color.Empty;

            StateDisabledBorderColourTwo = Color.Empty;

            StateDisabledItemBackgroundColourOne = Color.Empty;

            StateDisabledItemBackgroundColourTwo = Color.Empty;

            StateDisabledLongTextColourOne = SystemColors.ControlText;

            StateDisabledLongTextColourTwo = SystemColors.ControlText;

            StateDisabledShortTextColourOne = SystemColors.ControlText;

            StateDisabledShortTextColourTwo = SystemColors.ControlText;
            #endregion

            #region State Normal
            StateNormalBackgroundColourOne = Color.Empty;

            StateNormalBackgroundColourTwo = Color.Empty;

            StateNormalBorderColourOne = Color.Empty;

            StateNormalBorderColourTwo = Color.Empty;

            StateNormalItemBackgroundColourOne = Color.Empty;

            StateNormalItemBackgroundColourTwo = Color.Empty;

            StateNormalLongTextColourOne = SystemColors.ControlText;

            StateNormalLongTextColourTwo = SystemColors.ControlText;

            StateNormalShortTextColourOne = SystemColors.ControlText;

            StateNormalShortTextColourTwo = SystemColors.ControlText;
            #endregion

            #region State Pressed
            StatePressedItemBackgroundColourOne = Color.Empty;

            StatePressedItemBackgroundColourTwo = Color.Empty;

            StatePressedLongTextColourOne = SystemColors.ControlText;

            StatePressedLongTextColourTwo = SystemColors.ControlText;

            StatePressedShortTextColourOne = SystemColors.ControlText;

            StatePressedShortTextColourTwo = SystemColors.ControlText;
            #endregion

            #region State Tracking
            StateTrackingLongTextColourOne = SystemColors.ControlText;

            StateTrackingLongTextColourTwo = SystemColors.ControlText;

            StateTrackingShortTextColourOne = SystemColors.ControlText;

            StateTrackingShortTextColourTwo = SystemColors.ControlText;
            #endregion

            LongTextTypeface = Typeface.DefaultTypeface();

            ShortTextTypeface = Typeface.DefaultTypeface();

            Image = null;

            UpdateOverrideFocusAppearanceValues(OverrideFocusItemBackgroundColourOne, OverrideFocusItemBackgroundColourTwo, OverrideFocusLongTextColourOne, OverrideFocusLongTextColourTwo, OverrideFocusShortTextColourOne, OverrideFocusShortTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateActiveAppearanceValues(StateActiveBackgroundColourOne, StateActiveBackgroundColourTwo, StateActiveBorderColourOne, StateActiveBorderColourTwo);

            UpdateStateCheckedNormalAppearanceValues(StateCheckedNormalItemBackgroundColourOne, StateCheckedNormalItemBackgroundColourTwo, StateCheckedNormalLongTextColourOne, StateCheckedNormalLongTextColourTwo, StateCheckedNormalShortTextColourOne, StateCheckedNormalShortTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateCheckedPressedAppearanceValues(StateCheckedPressedItemBackgroundColourOne, StateCheckedPressedItemBackgroundColourTwo, StateCheckedPressedLongTextColourOne, StateCheckedPressedLongTextColourTwo, StateCheckedPressedShortTextColourOne, StateCheckedPressedShortTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateCheckedTrackingAppearanceValues(StateCheckedTrackingItemBackgroundColourOne, StateCheckedTrackingItemBackgroundColourTwo, StateCheckedTrackingLongTextColourOne, StateCheckedTrackingLongTextColourTwo, StateCheckedTrackingShortTextColourOne, StateCheckedTrackingShortTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateCommonAppearanceValues(StateCommonBackgroundColourOne, StateCommonBackgroundColourTwo, StateCommonItemBackgroundColourOne, StateCommonItemBackgroundColourTwo, StateCommonLongTextColourOne, StateCommonLongTextColourTwo, StateCommonShortTextColourOne, StateCommonShortTextColourTwo, StateCommonBorderColourOne, StateCommonBorderColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateDisabledAppearanceValues(StateDisabledBackgroundColourOne, StateDisabledBackgroundColourTwo, StateDisabledItemBackgroundColourOne, StateDisabledItemBackgroundColourTwo, StateDisabledLongTextColourOne, StateDisabledLongTextColourTwo, StateDisabledShortTextColourOne, StateDisabledShortTextColourTwo, StateDisabledBorderColourOne, StateDisabledBorderColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateNormalAppearanceValues(StateNormalBackgroundColourOne, StateNormalBackgroundColourTwo, StateNormalItemBackgroundColourOne, StateNormalItemBackgroundColourTwo, StateNormalLongTextColourOne, StateNormalLongTextColourTwo, StateNormalShortTextColourOne, StateNormalShortTextColourTwo, StateNormalBorderColourOne, StateNormalBorderColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStatePressedAppearanceValues(StatePressedItemBackgroundColourOne, StatePressedItemBackgroundColourTwo, StatePressedLongTextColourOne, StatePressedLongTextColourTwo, StatePressedShortTextColourOne, StatePressedShortTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateTrackingAppearanceValues(StateTrackingItemBackgroundColourOne, StateTrackingItemBackgroundColourTwo, StateTrackingLongTextColourOne, StateTrackingLongTextColourTwo, StateTrackingShortTextColourOne, StateTrackingShortTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);
        }
        #endregion

        #region Methods        
        private void UpdateOverrideFocusAppearanceValues(Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Font longTextTypeface, Font shortTextTypeface, Image image)
        {
            OverrideFocus.Item.Back.Color1 = itemBackgroundColourOne;

            OverrideFocus.Item.Back.Color2 = itemBackgroundColourTwo;

            OverrideFocus.Item.Content.LongText.Color1 = longTextColourOne;

            OverrideFocus.Item.Content.LongText.Color2 = longTextColourTwo;

            OverrideFocus.Item.Content.LongText.Font = longTextTypeface;

            OverrideFocus.Item.Content.ShortText.Color1 = shortTextColourOne;

            OverrideFocus.Item.Content.ShortText.Color2 = shortTextColourTwo;

            OverrideFocus.Item.Content.ShortText.Font = shortTextTypeface;

            OverrideFocus.Item.Content.LongText.Image = image;

            OverrideFocus.Item.Content.ShortText.Image = image;
        }

        private void UpdateStateActiveAppearanceValues(Color backgroundColourOne, Color backgroundColourTwo, Color borderColourOne, Color borderColourTwo)
        {
            StateActive.Back.Color1 = backgroundColourOne;

            StateActive.Back.Color2 = backgroundColourTwo;

            StateActive.Border.Color1 = borderColourOne;

            StateActive.Border.Color2 = borderColourTwo;
        }

        private void UpdateStateCheckedNormalAppearanceValues(Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Font longTextTypeface, Font shortTextTypeface, Image image)
        {
            StateCheckedNormal.Item.Back.Color1 = itemBackgroundColourOne;

            StateCheckedNormal.Item.Back.Color2 = itemBackgroundColourTwo;

            StateCheckedNormal.Item.Content.LongText.Color1 = longTextColourOne;

            StateCheckedNormal.Item.Content.LongText.Color2 = longTextColourTwo;

            StateCheckedNormal.Item.Content.LongText.Font = longTextTypeface;

            StateCheckedNormal.Item.Content.ShortText.Color1 = shortTextColourOne;

            StateCheckedNormal.Item.Content.ShortText.Color2 = shortTextColourTwo;

            StateCheckedNormal.Item.Content.ShortText.Font = shortTextTypeface;

            StateCheckedNormal.Item.Content.LongText.Image = image;

            StateCheckedNormal.Item.Content.ShortText.Image = image;
        }

        private void UpdateStateCheckedPressedAppearanceValues(Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Font longTextTypeface, Font shortTextTypeface, Image image)
        {
            StateCheckedPressed.Item.Back.Color1 = itemBackgroundColourOne;

            StateCheckedPressed.Item.Back.Color2 = itemBackgroundColourTwo;

            StateCheckedPressed.Item.Content.LongText.Color1 = longTextColourOne;

            StateCheckedPressed.Item.Content.LongText.Color2 = longTextColourTwo;

            StateCheckedPressed.Item.Content.LongText.Font = longTextTypeface;

            StateCheckedPressed.Item.Content.ShortText.Color1 = shortTextColourOne;

            StateCheckedPressed.Item.Content.ShortText.Color2 = shortTextColourTwo;

            StateCheckedPressed.Item.Content.ShortText.Font = shortTextTypeface;

            StateCheckedPressed.Item.Content.LongText.Image = image;

            StateCheckedPressed.Item.Content.ShortText.Image = image;
        }

        private void UpdateStateCheckedTrackingAppearanceValues(Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Font longTextTypeface, Font shortTextTypeface, Image image)
        {
            StateCheckedTracking.Item.Back.Color1 = itemBackgroundColourOne;

            StateCheckedTracking.Item.Back.Color2 = itemBackgroundColourTwo;

            StateCheckedTracking.Item.Content.LongText.Color1 = longTextColourOne;

            StateCheckedTracking.Item.Content.LongText.Color2 = longTextColourTwo;

            StateCheckedTracking.Item.Content.LongText.Font = longTextTypeface;

            StateCheckedTracking.Item.Content.ShortText.Color1 = shortTextColourOne;

            StateCheckedTracking.Item.Content.ShortText.Color2 = shortTextColourTwo;

            StateCheckedTracking.Item.Content.ShortText.Font = shortTextTypeface;

            StateCheckedTracking.Item.Content.LongText.Image = image;

            StateCheckedTracking.Item.Content.ShortText.Image = image;
        }

        /// <summary>
        /// Updates the state common appearance values.
        /// </summary>
        /// <param name="backgroundColourOne">The background colour one.</param>
        /// <param name="backgroundColourTwo">The background colour two.</param>
        /// <param name="itemBackgroundColourOne">The item background colour one.</param>
        /// <param name="itemBackgroundColourTwo">The item background colour two.</param>
        /// <param name="longTextColourOne">The long text colour one.</param>
        /// <param name="longTextColourTwo">The long text colour two.</param>
        /// <param name="shortTextColourOne">The short text colour one.</param>
        /// <param name="shortTextColourTwo">The short text colour two.</param>
        /// <param name="longTextTypeface">The long text typeface.</param>
        /// <param name="shortTextTypeface">The short text typeface.</param>
        /// <param name="image">The image.</param>
        private void UpdateStateCommonAppearanceValues(Color backgroundColourOne, Color backgroundColourTwo, Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font longTextTypeface, Font shortTextTypeface, Image image)
        {
            StateCommon.Back.Color1 = backgroundColourOne;

            StateCommon.Back.Color2 = backgroundColourTwo;

            StateCommon.Border.Color1 = borderColourOne;

            StateCommon.Border.Color2 = borderColourTwo;

            StateCommon.Item.Back.Color1 = itemBackgroundColourOne;

            StateCommon.Item.Back.Color2 = itemBackgroundColourTwo;

            StateCommon.Item.Content.LongText.Color1 = longTextColourOne;

            StateCommon.Item.Content.LongText.Color2 = longTextColourTwo;

            StateCommon.Item.Content.LongText.Font = longTextTypeface;

            StateCommon.Item.Content.ShortText.Color1 = shortTextColourOne;

            StateCommon.Item.Content.ShortText.Color2 = shortTextColourTwo;

            StateCommon.Item.Content.ShortText.Font = shortTextTypeface;

            StateCommon.Item.Content.LongText.Image = image;

            StateCommon.Item.Content.ShortText.Image = image;
        }

        private void UpdateStateDisabledAppearanceValues(Color backgroundColourOne, Color backgroundColourTwo, Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font longTextTypeface, Font shortTextTypeface, Image image)
        {
            StateDisabled.Back.Color1 = backgroundColourOne;

            StateDisabled.Back.Color2 = backgroundColourTwo;

            StateDisabled.Border.Color1 = borderColourOne;

            StateDisabled.Border.Color2 = borderColourTwo;

            StateDisabled.Item.Back.Color1 = itemBackgroundColourOne;

            StateDisabled.Item.Back.Color2 = itemBackgroundColourTwo;

            StateDisabled.Item.Content.LongText.Color1 = longTextColourOne;

            StateDisabled.Item.Content.LongText.Color2 = longTextColourTwo;

            StateDisabled.Item.Content.LongText.Font = longTextTypeface;

            StateDisabled.Item.Content.ShortText.Color1 = shortTextColourOne;

            StateDisabled.Item.Content.ShortText.Color2 = shortTextColourTwo;

            StateDisabled.Item.Content.ShortText.Font = shortTextTypeface;

            StateDisabled.Item.Content.LongText.Image = image;

            StateDisabled.Item.Content.ShortText.Image = image;
        }

        private void UpdateStateNormalAppearanceValues(Color backgroundColourOne, Color backgroundColourTwo, Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font longTextTypeface, Font shortTextTypeface, Image image)
        {
            StateNormal.Back.Color1 = backgroundColourOne;

            StateNormal.Back.Color2 = backgroundColourTwo;

            StateNormal.Border.Color1 = borderColourOne;

            StateNormal.Border.Color2 = borderColourTwo;

            StateNormal.Item.Back.Color1 = itemBackgroundColourOne;

            StateNormal.Item.Back.Color2 = itemBackgroundColourTwo;

            StateNormal.Item.Content.LongText.Color1 = longTextColourOne;

            StateNormal.Item.Content.LongText.Color2 = longTextColourTwo;

            StateNormal.Item.Content.LongText.Font = longTextTypeface;

            StateNormal.Item.Content.ShortText.Color1 = shortTextColourOne;

            StateNormal.Item.Content.ShortText.Color2 = shortTextColourTwo;

            StateNormal.Item.Content.ShortText.Font = shortTextTypeface;

            StateNormal.Item.Content.LongText.Image = image;

            StateNormal.Item.Content.ShortText.Image = image;
        }

        private void UpdateStatePressedAppearanceValues(Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Font longTextTypeface, Font shortTextTypeface, Image image)
        {
            StatePressed.Item.Back.Color1 = itemBackgroundColourOne;

            StatePressed.Item.Back.Color2 = itemBackgroundColourTwo;

            StatePressed.Item.Content.LongText.Color1 = longTextColourOne;

            StatePressed.Item.Content.LongText.Color2 = longTextColourTwo;

            StatePressed.Item.Content.LongText.Font = longTextTypeface;

            StatePressed.Item.Content.ShortText.Color1 = shortTextColourOne;

            StatePressed.Item.Content.ShortText.Color2 = shortTextColourTwo;

            StatePressed.Item.Content.ShortText.Font = shortTextTypeface;

            StatePressed.Item.Content.LongText.Image = image;

            StatePressed.Item.Content.ShortText.Image = image;
        }

        private void UpdateStateTrackingAppearanceValues(Color itemBackgroundColourOne, Color itemBackgroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Font longTextTypeface, Font shortTextTypeface, Image image)
        {
            StateTracking.Item.Back.Color1 = itemBackgroundColourOne;

            StateTracking.Item.Back.Color2 = itemBackgroundColourTwo;

            StateTracking.Item.Content.LongText.Color1 = longTextColourOne;

            StateTracking.Item.Content.LongText.Color2 = longTextColourTwo;

            StateTracking.Item.Content.LongText.Font = longTextTypeface;

            StateTracking.Item.Content.ShortText.Color1 = shortTextColourOne;

            StateTracking.Item.Content.ShortText.Color2 = shortTextColourTwo;

            StateTracking.Item.Content.ShortText.Font = shortTextTypeface;

            StateTracking.Item.Content.LongText.Image = image;

            StateTracking.Item.Content.ShortText.Image = image;
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateOverrideFocusAppearanceValues(OverrideFocusItemBackgroundColourOne, OverrideFocusItemBackgroundColourTwo, OverrideFocusLongTextColourOne, OverrideFocusLongTextColourTwo, OverrideFocusShortTextColourOne, OverrideFocusShortTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateActiveAppearanceValues(StateActiveBackgroundColourOne, StateActiveBackgroundColourTwo, StateActiveBorderColourOne, StateActiveBorderColourTwo);

            UpdateStateCheckedNormalAppearanceValues(StateCheckedNormalItemBackgroundColourOne, StateCheckedNormalItemBackgroundColourTwo, StateCheckedNormalLongTextColourOne, StateCheckedNormalLongTextColourTwo, StateCheckedNormalShortTextColourOne, StateCheckedNormalShortTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateCheckedPressedAppearanceValues(StateCheckedPressedItemBackgroundColourOne, StateCheckedPressedItemBackgroundColourTwo, StateCheckedPressedLongTextColourOne, StateCheckedPressedLongTextColourTwo, StateCheckedPressedShortTextColourOne, StateCheckedPressedShortTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateCheckedTrackingAppearanceValues(StateCheckedTrackingItemBackgroundColourOne, StateCheckedTrackingItemBackgroundColourTwo, StateCheckedTrackingLongTextColourOne, StateCheckedTrackingLongTextColourTwo, StateCheckedTrackingShortTextColourOne, StateCheckedTrackingShortTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateCommonAppearanceValues(StateCommonBackgroundColourOne, StateCommonBackgroundColourTwo, StateCommonItemBackgroundColourOne, StateCommonItemBackgroundColourTwo, StateCommonLongTextColourOne, StateCommonLongTextColourTwo, StateCommonShortTextColourOne, StateCommonShortTextColourTwo, StateCommonBorderColourOne, StateCommonBorderColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateDisabledAppearanceValues(StateDisabledBackgroundColourOne, StateDisabledBackgroundColourTwo, StateDisabledItemBackgroundColourOne, StateDisabledItemBackgroundColourTwo, StateDisabledLongTextColourOne, StateDisabledLongTextColourTwo, StateDisabledShortTextColourOne, StateDisabledShortTextColourTwo, StateDisabledBorderColourOne, StateDisabledBorderColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateNormalAppearanceValues(StateNormalBackgroundColourOne, StateNormalBackgroundColourTwo, StateNormalItemBackgroundColourOne, StateNormalItemBackgroundColourTwo, StateNormalLongTextColourOne, StateNormalLongTextColourTwo, StateNormalShortTextColourOne, StateNormalShortTextColourTwo, StateNormalBorderColourOne, StateNormalBorderColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStatePressedAppearanceValues(StatePressedItemBackgroundColourOne, StatePressedItemBackgroundColourTwo, StatePressedLongTextColourOne, StatePressedLongTextColourTwo, StatePressedShortTextColourOne, StatePressedShortTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateTrackingAppearanceValues(StateTrackingItemBackgroundColourOne, StateTrackingItemBackgroundColourTwo, StateTrackingLongTextColourOne, StateTrackingLongTextColourTwo, StateTrackingShortTextColourOne, StateTrackingShortTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            base.OnPaint(e);
        }
        #endregion
    }
}