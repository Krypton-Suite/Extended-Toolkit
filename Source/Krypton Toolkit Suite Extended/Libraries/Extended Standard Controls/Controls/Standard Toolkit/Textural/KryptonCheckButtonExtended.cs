using ComponentFactory.Krypton.Toolkit;
using ExtendedStandardControls.Classes;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ExtendedStandardControls
{
    [ToolboxBitmap(typeof(KryptonCheckButton))]
    public class KryptonCheckButtonExtended : KryptonCheckButton
    {
        #region Variables
        private Color _overrideDefaultBackGroundColourOne, _overrideDefaultBackGroundColourTwo, _overrideDefaultLongTextColourOne, _overrideDefaultLongTextColourTwo, _overrideDefaultShortTextColourOne, _overrideDefaultShortTextColourTwo, _overrideDefaultBorderColourOne, _overrideDefaultBorderColourTwo,
                      _overrideFocusBackGroundColourOne, _overrideFocusBackGroundColourTwo, _overrideFocusLongTextColourOne, _overrideFocusLongTextColourTwo, _overrideFocusShortTextColourOne, _overrideFocusShortTextColourTwo, _overrideFocusBorderColourOne, _overrideFocusBorderColourTwo,
                      _stateCheckedNormalBackGroundColourOne, _stateCheckedNormalBackGroundColourTwo, _stateCheckedNormalLongTextColourOne, _stateCheckedNormalLongTextColourTwo, _stateCheckedNormalShortTextColourOne, _stateCheckedNormalShortTextColourTwo, _stateCheckedNormalBorderColourOne, _stateCheckedNormalBorderColourTwo,
                      _stateCheckedPressedBackGroundColourOne, _stateCheckedPressedBackGroundColourTwo, _stateCheckedPressedLongTextColourOne, _stateCheckedPressedLongTextColourTwo, _stateCheckedPressedShortTextColourOne, _stateCheckedPressedShortTextColourTwo, _stateCheckedPressedBorderColourOne, _stateCheckedPressedBorderColourTwo,
                      _stateCheckedTrackingBackGroundColourOne, _stateCheckedTrackingBackGroundColourTwo, _stateCheckedTrackingLongTextColourOne, _stateCheckedTrackingLongTextColourTwo, _stateCheckedTrackingShortTextColourOne, _stateCheckedTrackingShortTextColourTwo, _stateCheckedTrackingBorderColourOne, _stateCheckedTrackingBorderColourTwo,
                      _stateCommonBackGroundColourOne, _stateCommonBackGroundColourTwo, _stateCommonLongTextColourOne, _stateCommonLongTextColourTwo, _stateCommonShortTextColourOne, _stateCommonShortTextColourTwo, _stateCommonBorderColourOne, _stateCommonBorderColourTwo,
                      _stateDisabledBackGroundColourOne, _stateDisabledBackGroundColourTwo, _stateDisabledLongTextColourOne, _stateDisabledLongTextColourTwo, _stateDisabledShortTextColourOne, _stateDisabledShortTextColourTwo, _stateDisabledBorderColourOne, _stateDisabledBorderColourTwo,
                      _stateNormalBackGroundColourOne, _stateNormalBackGroundColourTwo, _stateNormalLongTextColourOne, _stateNormalLongTextColourTwo, _stateNormalShortTextColourOne, _stateNormalShortTextColourTwo, _stateNormalBorderColourOne, _stateNormalBorderColourTwo,
                      _statePressedBackGroundColourOne, _statePressedBackGroundColourTwo, _statePressedLongTextColourOne, _statePressedLongTextColourTwo, _statePressedShortTextColourOne, _statePressedShortTextColourTwo, _statePressedBorderColourOne, _statePressedBorderColourTwo,
                      _stateTrackingBackGroundColourOne, _stateTrackingBackGroundColourTwo, _stateTrackingLongTextColourOne, _stateTrackingLongTextColourTwo, _stateTrackingShortTextColourOne, _stateTrackingShortTextColourTwo, _stateTrackingBorderColourOne, _stateTrackingBorderColourTwo;

        private Font _longTextTypeface, _shortTextTypeface;

        private Image _image;
        #endregion

        #region Properties

        #region Override Default
        [Category("Appearance"), Description("The first background colour.")]
        public Color OverrideDefaultBackGroundColourOne { get => _overrideDefaultBackGroundColourOne; set { _overrideDefaultBackGroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second background colour.")]
        public Color OverrideDefaultBackGroundColourTwo { get => _overrideDefaultBackGroundColourTwo; set { _overrideDefaultBackGroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first long text colour.")]
        public Color OverrideDefaultLongTextColourOne { get => _overrideDefaultLongTextColourOne; set { _overrideDefaultLongTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second long text colour.")]
        public Color OverrideDefaultLongTextColourTwo { get => _overrideDefaultLongTextColourTwo; set { _overrideDefaultLongTextColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first short text colour.")]
        public Color OverrideDefaultShortTextColourOne { get => _overrideDefaultShortTextColourOne; set { _overrideDefaultShortTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second short text colour.")]
        public Color OverrideDefaultShortTextColourTwo { get => _overrideDefaultShortTextColourTwo; set { _overrideDefaultShortTextColourTwo = value; Invalidate(); } }

        public Color OverrideDefaultBorderColourOne { get => _overrideDefaultBorderColourOne; set { _overrideDefaultBorderColourOne = value; Invalidate(); } }

        public Color OverrideDefaultBorderColourTwo { get => _overrideDefaultBorderColourTwo; set { _overrideDefaultBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region Override Focus
        [Category("Appearance"), Description("The first background colour.")]
        public Color OverrideFocusBackGroundColourOne { get => _overrideFocusBackGroundColourOne; set { _overrideFocusBackGroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second background colour.")]
        public Color OverrideFocusBackGroundColourTwo { get => _overrideFocusBackGroundColourTwo; set { _overrideFocusBackGroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first long text colour.")]
        public Color OverrideFocusLongTextColourOne { get => _overrideFocusLongTextColourOne; set { _overrideFocusLongTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second long text colour.")]
        public Color OverrideFocusLongTextColourTwo { get => _overrideFocusLongTextColourTwo; set { _overrideFocusLongTextColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first short text colour.")]
        public Color OverrideFocusShortTextColourOne { get => _overrideFocusShortTextColourOne; set { _overrideFocusShortTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second short text colour.")]
        public Color OverrideFocusShortTextColourTwo { get => _overrideFocusShortTextColourTwo; set { _overrideFocusShortTextColourTwo = value; Invalidate(); } }

        public Color OverrideFocusBorderColourOne { get => _overrideFocusBorderColourOne; set { _overrideFocusBorderColourOne = value; Invalidate(); } }

        public Color OverrideFocusBorderColourTwo { get => _overrideFocusBorderColourTwo; set { _overrideFocusBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Checked Normal
        [Category("Appearance"), Description("The first background colour.")]
        public Color StateCheckedNormalBackGroundColourOne { get => _stateCheckedNormalBackGroundColourOne; set { _stateCheckedNormalBackGroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second background colour.")]
        public Color StateCheckedNormalBackGroundColourTwo { get => _stateCheckedNormalBackGroundColourTwo; set { _stateCheckedNormalBackGroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first long text colour.")]
        public Color StateCheckedNormalLongTextColourOne { get => _stateCheckedNormalLongTextColourOne; set { _stateCheckedNormalLongTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second long text colour.")]
        public Color StateCheckedNormalLongTextColourTwo { get => _stateCheckedNormalLongTextColourTwo; set { _stateCheckedNormalLongTextColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first short text colour.")]
        public Color StateCheckedNormalShortTextColourOne { get => _stateCheckedNormalShortTextColourOne; set { _stateCheckedNormalShortTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second short text colour.")]
        public Color StateCheckedNormalShortTextColourTwo { get => _stateCheckedNormalShortTextColourTwo; set { _stateCheckedNormalShortTextColourTwo = value; Invalidate(); } }

        public Color StateCheckedNormalBorderColourOne { get => _stateCheckedNormalBorderColourOne; set { _stateCheckedNormalBorderColourOne = value; Invalidate(); } }

        public Color StateCheckedNormalBorderColourTwo { get => _stateCheckedNormalBorderColourTwo; set { _stateCheckedNormalBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Checked Pressed
        [Category("Appearance"), Description("The first background colour.")]
        public Color StateCheckedPressedBackGroundColourOne { get => _stateCheckedPressedBackGroundColourOne; set { _stateCheckedPressedBackGroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second background colour.")]
        public Color StateCheckedPressedBackGroundColourTwo { get => _stateCheckedPressedBackGroundColourTwo; set { _stateCheckedPressedBackGroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first long text colour.")]
        public Color StateCheckedPressedLongTextColourOne { get => _stateCheckedPressedLongTextColourOne; set { _stateCheckedPressedLongTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second long text colour.")]
        public Color StateCheckedPressedLongTextColourTwo { get => _stateCheckedPressedLongTextColourTwo; set { _stateCheckedPressedLongTextColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first short text colour.")]
        public Color StateCheckedPressedShortTextColourOne { get => _stateCheckedPressedShortTextColourOne; set { _stateCheckedPressedShortTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second short text colour.")]
        public Color StateCheckedPressedShortTextColourTwo { get => _stateCheckedPressedShortTextColourTwo; set { _stateCheckedPressedShortTextColourTwo = value; Invalidate(); } }

        public Color StateCheckedPressedBorderColourOne { get => _stateCheckedPressedBorderColourOne; set { _stateCheckedPressedBorderColourOne = value; Invalidate(); } }

        public Color StateCheckedPressedBorderColourTwo { get => _stateCheckedPressedBorderColourTwo; set { _stateCheckedPressedBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Checked Tracking
        [Category("Appearance"), Description("The first background colour.")]
        public Color StateCheckedTrackingBackGroundColourOne { get => _stateCheckedTrackingBackGroundColourOne; set { _stateCheckedTrackingBackGroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second background colour.")]
        public Color StateCheckedTrackingBackGroundColourTwo { get => _stateCheckedTrackingBackGroundColourTwo; set { _stateCheckedTrackingBackGroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first long text colour.")]
        public Color StateCheckedTrackingLongTextColourOne { get => _stateCheckedTrackingLongTextColourOne; set { _stateCheckedTrackingLongTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second long text colour.")]
        public Color StateCheckedTrackingLongTextColourTwo { get => _stateCheckedTrackingLongTextColourTwo; set { _stateCheckedTrackingLongTextColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first short text colour.")]
        public Color StateCheckedTrackingShortTextColourOne { get => _stateCheckedTrackingShortTextColourOne; set { _stateCheckedTrackingShortTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second short text colour.")]
        public Color StateCheckedTrackingShortTextColourTwo { get => _stateCheckedTrackingShortTextColourTwo; set { _stateCheckedTrackingShortTextColourTwo = value; Invalidate(); } }

        public Color StateCheckedTrackingBorderColourOne { get => _stateCheckedTrackingBorderColourOne; set { _stateCheckedTrackingBorderColourOne = value; Invalidate(); } }

        public Color StateCheckedTrackingBorderColourTwo { get => _stateCheckedTrackingBorderColourTwo; set { _stateCheckedTrackingBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Common
        [Category("Appearance"), Description("The first background colour.")]
        public Color StateCommonBackGroundColourOne { get => _stateCommonBackGroundColourOne; set { _stateCommonBackGroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second background colour.")]
        public Color StateCommonBackGroundColourTwo { get => _stateCommonBackGroundColourTwo; set { _stateCommonBackGroundColourTwo = value; Invalidate(); } }

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
        public Color StateDisabledBackGroundColourOne { get => _stateDisabledBackGroundColourOne; set { _stateDisabledBackGroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second background colour.")]
        public Color StateDisabledBackGroundColourTwo { get => _stateDisabledBackGroundColourTwo; set { _stateDisabledBackGroundColourTwo = value; Invalidate(); } }

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
        public Color StateNormalBackGroundColourOne { get => _stateNormalBackGroundColourOne; set { _stateNormalBackGroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second background colour.")]
        public Color StateNormalBackGroundColourTwo { get => _stateNormalBackGroundColourTwo; set { _stateNormalBackGroundColourTwo = value; Invalidate(); } }

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
        [Category("Appearance"), Description("The first background colour.")]
        public Color StatePressedBackGroundColourOne { get => _statePressedBackGroundColourOne; set { _statePressedBackGroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second background colour.")]
        public Color StatePressedBackGroundColourTwo { get => _statePressedBackGroundColourTwo; set { _statePressedBackGroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first long text colour.")]
        public Color StatePressedLongTextColourOne { get => _statePressedLongTextColourOne; set { _statePressedLongTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second long text colour.")]
        public Color StatePressedLongTextColourTwo { get => _statePressedLongTextColourTwo; set { _statePressedLongTextColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first short text colour.")]
        public Color StatePressedShortTextColourOne { get => _statePressedShortTextColourOne; set { _statePressedShortTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second short text colour.")]
        public Color StatePressedShortTextColourTwo { get => _statePressedShortTextColourTwo; set { _statePressedShortTextColourTwo = value; Invalidate(); } }

        public Color StatePressedBorderColourOne { get => _statePressedBorderColourOne; set { _statePressedBorderColourOne = value; Invalidate(); } }

        public Color StatePressedBorderColourTwo { get => _statePressedBorderColourTwo; set { _statePressedBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Tracking
        [Category("Appearance"), Description("The first background colour.")]
        public Color StateTrackingBackGroundColourOne { get => _stateTrackingBackGroundColourOne; set { _stateTrackingBackGroundColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second background colour.")]
        public Color StateTrackingBackGroundColourTwo { get => _stateTrackingBackGroundColourTwo; set { _stateTrackingBackGroundColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first long text colour.")]
        public Color StateTrackingLongTextColourOne { get => _stateTrackingLongTextColourOne; set { _stateTrackingLongTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second long text colour.")]
        public Color StateTrackingLongTextColourTwo { get => _stateTrackingLongTextColourTwo; set { _stateTrackingLongTextColourTwo = value; Invalidate(); } }

        [Category("Appearance"), Description("The first short text colour.")]
        public Color StateTrackingShortTextColourOne { get => _stateTrackingShortTextColourOne; set { _stateTrackingShortTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second short text colour.")]
        public Color StateTrackingShortTextColourTwo { get => _stateTrackingShortTextColourTwo; set { _stateTrackingShortTextColourTwo = value; Invalidate(); } }

        public Color StateTrackingBorderColourOne { get => _stateTrackingBorderColourOne; set { _stateTrackingBorderColourOne = value; Invalidate(); } }

        public Color StateTrackingBorderColourTwo { get => _stateTrackingBorderColourTwo; set { _stateTrackingBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region Globals
        [Category("Appearance"), Description("The 'Long Text' typeface.")]
        public Font LongTextTypeface { get => _longTextTypeface; set { _longTextTypeface = value; Invalidate(); } }

        [Category("Appearance"), Description("The 'Short Text' typeface.")]
        public Font ShortTextTypeface { get => _shortTextTypeface; set { _shortTextTypeface = value; Invalidate(); } }

        [Category("Appearance"), Description("The chosen image.")]
        public Image Image { get => _image; set { _image = value; Invalidate(); } }
        #endregion

        #endregion

        #region Constructor
        public KryptonCheckButtonExtended()
        {
            #region Override Default
            OverrideDefaultBackGroundColourOne = Color.Empty;

            OverrideDefaultBackGroundColourTwo = Color.Empty;

            OverrideDefaultBorderColourOne = Color.Empty;

            OverrideDefaultBorderColourTwo = Color.Empty;

            OverrideDefaultLongTextColourOne = Color.Empty;

            OverrideDefaultLongTextColourTwo = Color.Empty;

            OverrideDefaultShortTextColourOne = Color.Empty;

            OverrideDefaultShortTextColourTwo = Color.Empty;
            #endregion

            #region Override Focus
            OverrideFocusBackGroundColourOne = Color.Empty;

            OverrideFocusBackGroundColourTwo = Color.Empty;

            OverrideFocusBorderColourOne = Color.Empty;

            OverrideFocusBorderColourTwo = Color.Empty;

            OverrideFocusLongTextColourOne = Color.Empty;

            OverrideFocusLongTextColourTwo = Color.Empty;

            OverrideFocusShortTextColourOne = Color.Empty;

            OverrideFocusShortTextColourTwo = Color.Empty;
            #endregion

            #region Override Checked Normal
            StateCheckedNormalBackGroundColourOne = Color.Empty;

            StateCheckedNormalBackGroundColourTwo = Color.Empty;

            StateCheckedNormalBorderColourOne = Color.Empty;

            StateCheckedNormalBorderColourTwo = Color.Empty;

            StateCheckedNormalLongTextColourOne = Color.Empty;

            StateCheckedNormalLongTextColourTwo = Color.Empty;

            StateCheckedNormalShortTextColourOne = Color.Empty;

            StateCheckedNormalShortTextColourTwo = Color.Empty;
            #endregion

            #region Override Checked Pressed
            StateCheckedPressedBackGroundColourOne = Color.Empty;

            StateCheckedPressedBackGroundColourTwo = Color.Empty;

            StateCheckedPressedBorderColourOne = Color.Empty;

            StateCheckedPressedBorderColourTwo = Color.Empty;

            StateCheckedPressedLongTextColourOne = Color.Empty;

            StateCheckedPressedLongTextColourTwo = Color.Empty;

            StateCheckedPressedShortTextColourOne = Color.Empty;

            StateCheckedPressedShortTextColourTwo = Color.Empty;
            #endregion

            #region Override Checked Tracking
            StateCheckedTrackingBackGroundColourOne = Color.Empty;

            StateCheckedTrackingBackGroundColourTwo = Color.Empty;

            StateCheckedTrackingBorderColourOne = Color.Empty;

            StateCheckedTrackingBorderColourTwo = Color.Empty;

            StateCheckedTrackingLongTextColourOne = Color.Empty;

            StateCheckedTrackingLongTextColourTwo = Color.Empty;

            StateCheckedTrackingShortTextColourOne = Color.Empty;

            StateCheckedTrackingShortTextColourTwo = Color.Empty;
            #endregion

            #region State Common
            StateCommonBackGroundColourOne = Color.Empty;

            StateCommonBackGroundColourTwo = Color.Empty;

            StateCommonBorderColourOne = Color.Empty;

            StateCommonBorderColourTwo = Color.Empty;

            StateCommonLongTextColourOne = Color.Empty;

            StateCommonLongTextColourTwo = Color.Empty;

            StateCommonShortTextColourOne = Color.Empty;

            StateCommonShortTextColourTwo = Color.Empty;
            #endregion

            #region State Disabled
            StateDisabledBackGroundColourOne = Color.Empty;

            StateDisabledBackGroundColourTwo = Color.Empty;

            StateDisabledBorderColourOne = Color.Empty;

            StateDisabledBorderColourTwo = Color.Empty;

            StateDisabledLongTextColourOne = Color.Empty;

            StateDisabledLongTextColourTwo = Color.Empty;

            StateDisabledShortTextColourOne = Color.Empty;

            StateDisabledShortTextColourTwo = Color.Empty;
            #endregion

            #region State Normal
            StateNormalBackGroundColourOne = Color.Empty;

            StateNormalBackGroundColourTwo = Color.Empty;

            StateNormalBorderColourOne = Color.Empty;

            StateNormalBorderColourTwo = Color.Empty;

            StateNormalLongTextColourOne = Color.Empty;

            StateNormalLongTextColourTwo = Color.Empty;

            StateNormalShortTextColourOne = Color.Empty;

            StateNormalShortTextColourTwo = Color.Empty;
            #endregion

            #region State Tracking
            StateTrackingBackGroundColourOne = Color.Empty;

            StateTrackingBackGroundColourTwo = Color.Empty;

            StateTrackingBorderColourOne = Color.Empty;

            StateTrackingBorderColourTwo = Color.Empty;

            StateTrackingLongTextColourOne = Color.Empty;

            StateTrackingLongTextColourTwo = Color.Empty;

            StateTrackingShortTextColourOne = Color.Empty;

            StateTrackingShortTextColourTwo = Color.Empty;
            #endregion

            LongTextTypeface = Typeface.DefaultTypeface();

            ShortTextTypeface = Typeface.DefaultTypeface();

            Image = null;

            UpdateOverrideDefaultAppearanceValues(OverrideDefaultBackGroundColourOne, OverrideDefaultBackGroundColourTwo, OverrideDefaultLongTextColourOne, OverrideDefaultLongTextColourTwo, LongTextTypeface, OverrideDefaultShortTextColourOne, OverrideDefaultShortTextColourTwo, OverrideDefaultBorderColourOne, OverrideDefaultBorderColourTwo, ShortTextTypeface, Image);

            UpdateOverrideFocusAppearanceValues(OverrideFocusBackGroundColourOne, OverrideFocusBackGroundColourTwo, OverrideFocusLongTextColourOne, OverrideFocusLongTextColourTwo, LongTextTypeface, OverrideFocusShortTextColourOne, OverrideFocusShortTextColourTwo, OverrideFocusBorderColourOne, OverrideFocusBorderColourTwo, ShortTextTypeface, Image);

            UpdateStateCheckedNormalAppearanceValues(StateCheckedNormalBackGroundColourOne, StateCheckedNormalBackGroundColourTwo, StateCheckedNormalLongTextColourOne, StateCheckedNormalLongTextColourTwo, LongTextTypeface, StateCheckedNormalShortTextColourOne, StateCheckedNormalShortTextColourTwo, StateCheckedNormalBorderColourOne, StateCheckedNormalBorderColourTwo, ShortTextTypeface, Image);

            UpdateStateCheckedPressedAppearanceValues(StateCheckedPressedBackGroundColourOne, StateCheckedPressedBackGroundColourTwo, StateCheckedPressedLongTextColourOne, StateCheckedPressedLongTextColourTwo, LongTextTypeface, StateCheckedPressedShortTextColourOne, StateCheckedPressedShortTextColourTwo, StateCheckedPressedBorderColourOne, StateCheckedPressedBorderColourTwo, ShortTextTypeface, Image);

            UpdateStateCheckedTrackingAppearanceValues(StateCheckedTrackingBackGroundColourOne, StateCheckedTrackingBackGroundColourTwo, StateCheckedTrackingLongTextColourOne, StateCheckedTrackingLongTextColourTwo, LongTextTypeface, StateCheckedTrackingShortTextColourOne, StateCheckedTrackingShortTextColourTwo, StateCheckedTrackingBorderColourOne, StateCheckedTrackingBorderColourTwo, ShortTextTypeface, Image);

            UpdateStateCommonAppearanceValues(StateCommonBackGroundColourOne, StateCommonBackGroundColourTwo, StateCommonLongTextColourOne, StateCommonLongTextColourTwo, LongTextTypeface, StateCommonShortTextColourOne, StateCommonShortTextColourTwo, StateCommonBorderColourOne, StateCommonBorderColourTwo, ShortTextTypeface, Image);

            UpdateStateDisabledAppearanceValues(StateDisabledBackGroundColourOne, StateDisabledBackGroundColourTwo, StateDisabledLongTextColourOne, StateDisabledLongTextColourTwo, LongTextTypeface, StateDisabledShortTextColourOne, StateDisabledShortTextColourTwo, StateDisabledBorderColourOne, StateDisabledBorderColourTwo, ShortTextTypeface, Image);

            UpdateStateNormalAppearanceValues(StateNormalBackGroundColourOne, StateNormalBackGroundColourTwo, StateNormalLongTextColourOne, StateNormalLongTextColourTwo, LongTextTypeface, StateNormalShortTextColourOne, StateNormalShortTextColourTwo, StateNormalBorderColourOne, StateNormalBorderColourTwo, ShortTextTypeface, Image);

            UpdateStateTrackingAppearanceValues(StateTrackingBackGroundColourOne, StateTrackingBackGroundColourTwo, StateTrackingLongTextColourOne, StateTrackingLongTextColourTwo, LongTextTypeface, StateTrackingShortTextColourOne, StateTrackingShortTextColourTwo, StateTrackingBorderColourOne, StateTrackingBorderColourTwo, ShortTextTypeface, Image);
        }
        #endregion

        #region Methods
        private void UpdateOverrideDefaultAppearanceValues(Color backGroundColourOne, Color backGroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Font longTextTypeface, Color shortTextColourOne, Color shortTextColourTwo, Color overrideDefaultBorderColourOne, Color overrideDefaultBorderColourTwo, Font shortTextTypeface, Image image)
        {
            OverrideDefault.Back.Color1 = backGroundColourOne;

            OverrideDefault.Back.Color2 = backGroundColourTwo;

            OverrideDefault.Border.Color1 = overrideDefaultBorderColourOne;

            OverrideDefault.Border.Color2 = overrideDefaultBorderColourTwo;

            OverrideDefault.Content.LongText.Color1 = longTextColourOne;

            OverrideDefault.Content.LongText.Color2 = longTextColourTwo;

            OverrideDefault.Content.LongText.Font = longTextTypeface;

            OverrideDefault.Content.LongText.Image = image;

            OverrideDefault.Content.ShortText.Color1 = shortTextColourOne;

            OverrideDefault.Content.ShortText.Color2 = shortTextColourTwo;

            OverrideDefault.Content.ShortText.Font = shortTextTypeface;

            OverrideDefault.Content.ShortText.Image = image;
        }

        private void UpdateOverrideFocusAppearanceValues(Color backGroundColourOne, Color backGroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Font longTextTypeface, Color shortTextColourOne, Color shortTextColourTwo, Color overrideFocusBorderColourOne, Color overrideFocusBorderColourTwo, Font shortTextTypeface, Image image)
        {
            OverrideFocus.Back.Color1 = backGroundColourOne;

            OverrideFocus.Back.Color2 = backGroundColourTwo;

            OverrideFocus.Border.Color1 = overrideFocusBorderColourOne;

            OverrideFocus.Border.Color2 = overrideFocusBorderColourTwo;

            OverrideFocus.Content.LongText.Color1 = longTextColourOne;

            OverrideFocus.Content.LongText.Color2 = longTextColourTwo;

            OverrideFocus.Content.LongText.Font = longTextTypeface;

            OverrideFocus.Content.LongText.Image = image;

            OverrideFocus.Content.ShortText.Color1 = shortTextColourOne;

            OverrideFocus.Content.ShortText.Color2 = shortTextColourTwo;

            OverrideFocus.Content.ShortText.Font = shortTextTypeface;

            OverrideFocus.Content.ShortText.Image = image;
        }

        private void UpdateStateCheckedNormalAppearanceValues(Color backGroundColourOne, Color backGroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Font longTextTypeface, Color shortTextColourOne, Color shortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font shortTextTypeface, Image image)
        {
            StateCheckedNormal.Back.Color1 = backGroundColourOne;

            StateCheckedNormal.Back.Color2 = backGroundColourTwo;

            StateCheckedNormal.Border.Color1 = borderColourOne;

            StateCheckedNormal.Border.Color2 = borderColourTwo;
            
            StateCheckedNormal.Content.LongText.Color1 = longTextColourOne;

            StateCheckedNormal.Content.LongText.Color2 = longTextColourTwo;

            StateCheckedNormal.Content.LongText.Font = longTextTypeface;

            StateCheckedNormal.Content.LongText.Image = image;

            StateCheckedNormal.Content.ShortText.Color1 = shortTextColourOne;

            StateCheckedNormal.Content.ShortText.Color2 = shortTextColourTwo;

            StateCheckedNormal.Content.ShortText.Font = shortTextTypeface;

            StateCheckedNormal.Content.ShortText.Image = image;
        }

        private void UpdateStateCheckedPressedAppearanceValues(Color backGroundColourOne, Color backGroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Font longTextTypeface, Color shortTextColourOne, Color shortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font shortTextTypeface, Image image)
        {
            StateCheckedPressed.Back.Color1 = backGroundColourOne;

            StateCheckedPressed.Back.Color2 = backGroundColourTwo;

            StateCheckedPressed.Border.Color1 = borderColourOne;

            StateCheckedPressed.Border.Color2 = borderColourTwo;

            StateCheckedPressed.Content.LongText.Color1 = longTextColourOne;

            StateCheckedPressed.Content.LongText.Color2 = longTextColourTwo;

            StateCheckedPressed.Content.LongText.Font = longTextTypeface;

            StateCheckedPressed.Content.LongText.Image = image;

            StateCheckedPressed.Content.ShortText.Color1 = shortTextColourOne;

            StateCheckedPressed.Content.ShortText.Color2 = shortTextColourTwo;

            StateCheckedPressed.Content.ShortText.Font = shortTextTypeface;

            StateCheckedPressed.Content.ShortText.Image = image;
        }

        private void UpdateStateCheckedTrackingAppearanceValues(Color backGroundColourOne, Color backGroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Font longTextTypeface, Color shortTextColourOne, Color shortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font shortTextTypeface, Image image)
        {
            StateCheckedTracking.Back.Color1 = backGroundColourOne;

            StateCheckedTracking.Back.Color2 = backGroundColourTwo;

            StateCheckedTracking.Border.Color1 = borderColourOne;

            StateCheckedTracking.Border.Color2 = borderColourTwo;

            StateCheckedTracking.Content.LongText.Color1 = longTextColourOne;

            StateCheckedTracking.Content.LongText.Color2 = longTextColourTwo;

            StateCheckedTracking.Content.LongText.Font = longTextTypeface;

            StateCheckedTracking.Content.LongText.Image = image;

            StateCheckedTracking.Content.ShortText.Color1 = shortTextColourOne;

            StateCheckedTracking.Content.ShortText.Color2 = shortTextColourTwo;

            StateCheckedTracking.Content.ShortText.Font = shortTextTypeface;

            StateCheckedTracking.Content.ShortText.Image = image;
        }

        private void UpdateStateCommonAppearanceValues(Color backGroundColourOne, Color backGroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Font longTextTypeface, Color shortTextColourOne, Color shortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font shortTextTypeface, Image image)
        {
            StateCommon.Back.Color1 = backGroundColourOne;

            StateCommon.Back.Color2 = backGroundColourTwo;

            StateCommon.Border.Color1 = borderColourOne;

            StateCommon.Border.Color2 = borderColourTwo;

            StateCommon.Content.LongText.Color1 = longTextColourOne;

            StateCommon.Content.LongText.Color2 = longTextColourTwo;

            StateCommon.Content.LongText.Font = longTextTypeface;

            StateCommon.Content.LongText.Image = image;

            StateCommon.Content.ShortText.Color1 = shortTextColourOne;

            StateCommon.Content.ShortText.Color2 = shortTextColourTwo;

            StateCommon.Content.ShortText.Font = shortTextTypeface;

            StateCommon.Content.ShortText.Image = image;
        }

        private void UpdateStateDisabledAppearanceValues(Color backGroundColourOne, Color backGroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Font longTextTypeface, Color shortTextColourOne, Color shortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font shortTextTypeface, Image image)
        {
            StateDisabled.Back.Color1 = backGroundColourOne;

            StateDisabled.Back.Color2 = backGroundColourTwo;

            StateDisabled.Border.Color1 = borderColourOne;

            StateDisabled.Border.Color2 = borderColourTwo;

            StateDisabled.Content.LongText.Color1 = longTextColourOne;

            StateDisabled.Content.LongText.Color2 = longTextColourTwo;

            StateDisabled.Content.LongText.Font = longTextTypeface;

            StateDisabled.Content.LongText.Image = image;

            StateDisabled.Content.ShortText.Color1 = shortTextColourOne;

            StateDisabled.Content.ShortText.Color2 = shortTextColourTwo;

            StateDisabled.Content.ShortText.Font = shortTextTypeface;

            StateDisabled.Content.ShortText.Image = image;
        }

        private void UpdateStateNormalAppearanceValues(Color backGroundColourOne, Color backGroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Font longTextTypeface, Color shortTextColourOne, Color shortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font shortTextTypeface, Image image)
        {
            StateNormal.Back.Color1 = backGroundColourOne;

            StateNormal.Back.Color2 = backGroundColourTwo;

            StateNormal.Border.Color1 = borderColourOne;

            StateNormal.Border.Color2 = borderColourTwo;

            StateNormal.Content.LongText.Color1 = longTextColourOne;

            StateNormal.Content.LongText.Color2 = longTextColourTwo;

            StateNormal.Content.LongText.Font = longTextTypeface;

            StateNormal.Content.LongText.Image = image;

            StateNormal.Content.ShortText.Color1 = shortTextColourOne;

            StateNormal.Content.ShortText.Color2 = shortTextColourTwo;

            StateNormal.Content.ShortText.Font = shortTextTypeface;

            StateNormal.Content.ShortText.Image = image;
        }

        private void UpdateStateTrackingAppearanceValues(Color backGroundColourOne, Color backGroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Font longTextTypeface, Color shortTextColourOne, Color shortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font shortTextTypeface, Image image)
        {
            StateTracking.Back.Color1 = backGroundColourOne;

            StateTracking.Back.Color2 = backGroundColourTwo;

            StateTracking.Border.Color1 = borderColourOne;

            StateTracking.Border.Color2 = borderColourTwo;

            StateTracking.Content.LongText.Color1 = longTextColourOne;

            StateTracking.Content.LongText.Color2 = longTextColourTwo;

            StateTracking.Content.LongText.Font = longTextTypeface;

            StateTracking.Content.LongText.Image = image;

            StateTracking.Content.ShortText.Color1 = shortTextColourOne;

            StateTracking.Content.ShortText.Color2 = shortTextColourTwo;

            StateTracking.Content.ShortText.Font = shortTextTypeface;

            StateTracking.Content.ShortText.Image = image;
        }
        #endregion

        #region Override
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateOverrideDefaultAppearanceValues(OverrideDefaultBackGroundColourOne, OverrideDefaultBackGroundColourTwo, OverrideDefaultLongTextColourOne, OverrideDefaultLongTextColourTwo, LongTextTypeface, OverrideDefaultShortTextColourOne, OverrideDefaultShortTextColourTwo, OverrideDefaultBorderColourOne, OverrideDefaultBorderColourTwo, ShortTextTypeface, Image);

            UpdateOverrideFocusAppearanceValues(OverrideFocusBackGroundColourOne, OverrideFocusBackGroundColourTwo, OverrideFocusLongTextColourOne, OverrideFocusLongTextColourTwo, LongTextTypeface, OverrideFocusShortTextColourOne, OverrideFocusShortTextColourTwo, OverrideFocusBorderColourOne, OverrideFocusBorderColourTwo, ShortTextTypeface, Image);

            UpdateStateCheckedNormalAppearanceValues(StateCheckedNormalBackGroundColourOne, StateCheckedNormalBackGroundColourTwo, StateCheckedNormalLongTextColourOne, StateCheckedNormalLongTextColourTwo, LongTextTypeface, StateCheckedNormalShortTextColourOne, StateCheckedNormalShortTextColourTwo, StateCheckedNormalBorderColourOne, StateCheckedNormalBorderColourTwo, ShortTextTypeface, Image);

            UpdateStateCheckedPressedAppearanceValues(StateCheckedPressedBackGroundColourOne, StateCheckedPressedBackGroundColourTwo, StateCheckedPressedLongTextColourOne, StateCheckedPressedLongTextColourTwo, LongTextTypeface, StateCheckedPressedShortTextColourOne, StateCheckedPressedShortTextColourTwo, StateCheckedPressedBorderColourOne, StateCheckedPressedBorderColourTwo, ShortTextTypeface, Image);

            UpdateStateCheckedTrackingAppearanceValues(StateCheckedTrackingBackGroundColourOne, StateCheckedTrackingBackGroundColourTwo, StateCheckedTrackingLongTextColourOne, StateCheckedTrackingLongTextColourTwo, LongTextTypeface, StateCheckedTrackingShortTextColourOne, StateCheckedTrackingShortTextColourTwo, StateCheckedTrackingBorderColourOne, StateCheckedTrackingBorderColourTwo, ShortTextTypeface, Image);

            UpdateStateCommonAppearanceValues(StateCommonBackGroundColourOne, StateCommonBackGroundColourTwo, StateCommonLongTextColourOne, StateCommonLongTextColourTwo, LongTextTypeface, StateCommonShortTextColourOne, StateCommonShortTextColourTwo, StateCommonBorderColourOne, StateCommonBorderColourTwo, ShortTextTypeface, Image);

            UpdateStateDisabledAppearanceValues(StateDisabledBackGroundColourOne, StateDisabledBackGroundColourTwo, StateDisabledLongTextColourOne, StateDisabledLongTextColourTwo, LongTextTypeface, StateDisabledShortTextColourOne, StateDisabledShortTextColourTwo, StateDisabledBorderColourOne, StateDisabledBorderColourTwo, ShortTextTypeface, Image);

            UpdateStateNormalAppearanceValues(StateNormalBackGroundColourOne, StateNormalBackGroundColourTwo, StateNormalLongTextColourOne, StateNormalLongTextColourTwo, LongTextTypeface, StateNormalShortTextColourOne, StateNormalShortTextColourTwo, StateNormalBorderColourOne, StateNormalBorderColourTwo, ShortTextTypeface, Image);

            UpdateStateTrackingAppearanceValues(StateTrackingBackGroundColourOne, StateTrackingBackGroundColourTwo, StateTrackingLongTextColourOne, StateTrackingLongTextColourTwo, LongTextTypeface, StateTrackingShortTextColourOne, StateTrackingShortTextColourTwo, StateTrackingBorderColourOne, StateTrackingBorderColourTwo, ShortTextTypeface, Image);

            base.OnPaint(e);
        }
        #endregion
    }
}