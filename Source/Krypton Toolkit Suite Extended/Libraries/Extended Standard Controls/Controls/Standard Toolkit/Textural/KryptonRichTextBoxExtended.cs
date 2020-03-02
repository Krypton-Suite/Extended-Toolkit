using ComponentFactory.Krypton.Toolkit;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ExtendedStandardControls
{
    [ToolboxBitmap(typeof(KryptonRichTextBox))]
    public class KryptonRichTextBoxExtended : KryptonRichTextBox
    {
        #region Variables
        private Color _stateActiveBackgroundColour, _stateActiveTextColour, _stateActiveBorderColourOne, _stateActiveBorderColourTwo,
                      _stateCommonBackgroundColour, _stateCommonTextColour, _stateCommonBorderColourOne, _stateCommonBorderColourTwo,
                      _stateDisabledBackgroundColour, _stateDisabledTextColour, _stateDisabledBorderColourOne, _stateDisabledBorderColourTwo,
                      _stateNormalBackgroundColour, _stateNormalTextColour, _stateNormalBorderColourOne, _stateNormalBorderColourTwo;

        private Font _typeface;

        private int _cornerRadius;
        #endregion

        #region Properties

        #region State Active
        public Color StateActiveBackGroundColour { get => _stateActiveBackgroundColour; set { _stateActiveBackgroundColour = value; Invalidate(); } }

        public Color StateActiveTextColour { get => _stateActiveTextColour; set { _stateActiveTextColour = value; Invalidate(); } }

        public Color StateActiveBorderColourOne { get => _stateActiveBorderColourOne; set { _stateActiveBorderColourOne = value; Invalidate(); } }

        public Color StateActiveBorderColourTwo { get => _stateActiveBorderColourTwo; set { _stateActiveBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Common
        public Color StateCommonBackGroundColour { get => _stateCommonBackgroundColour; set { _stateCommonBackgroundColour = value; Invalidate(); } }

        public Color StateCommonTextColour { get => _stateCommonTextColour; set { _stateCommonTextColour = value; Invalidate(); } }

        public Color StateCommonBorderColourOne { get => _stateCommonBorderColourOne; set { _stateCommonBorderColourOne = value; Invalidate(); } }

        public Color StateCommonBorderColourTwo { get => _stateCommonBorderColourTwo; set { _stateCommonBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Disabled
        public Color StateDisabledBackGroundColour { get => _stateDisabledBackgroundColour; set { _stateDisabledBackgroundColour = value; Invalidate(); } }

        public Color StateDisabledTextColour { get => _stateDisabledTextColour; set { _stateDisabledTextColour = value; Invalidate(); } }

        public Color StateDisabledBorderColourOne { get => _stateDisabledBorderColourOne; set { _stateDisabledBorderColourOne = value; Invalidate(); } }

        public Color StateDisabledBorderColourTwo { get => _stateDisabledBorderColourTwo; set { _stateDisabledBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Normal
        public Color StateNormalBackgroundColour { get => _stateNormalBackgroundColour; set { _stateNormalBackgroundColour = value; Invalidate(); } }

        public Color StateNormalTextColour { get => _stateNormalTextColour; set { _stateNormalTextColour = value; Invalidate(); } }

        public Color StateNormalBorderColourOne { get => _stateNormalBorderColourOne; set { _stateNormalBorderColourOne = value; Invalidate(); } }

        public Color StateNormalBorderColourTwo { get => _stateNormalBorderColourTwo; set { _stateNormalBorderColourTwo = value; Invalidate(); } }
        #endregion

        [Category("Appearance"), Description("The typeface of the text box.")]
        public Font Typeface { get => _typeface; set { _typeface = value; Invalidate(); } }

        public int CornerRadius { get => _cornerRadius; set { _cornerRadius = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonRichTextBoxExtended()
        {
            StateActiveBackGroundColour = Color.Empty;

            StateActiveTextColour = Color.Empty;

            StateActiveBorderColourOne = Color.Empty;

            StateActiveBorderColourTwo = Color.Empty;

            StateCommonBackGroundColour = Color.Empty;

            StateCommonTextColour = Color.Empty;

            StateCommonBorderColourOne = Color.Empty;

            StateCommonBorderColourTwo = Color.Empty;

            StateDisabledBackGroundColour = Color.Empty;

            StateDisabledTextColour = Color.Empty;

            StateDisabledBorderColourOne = Color.Empty;

            StateDisabledBorderColourTwo = Color.Empty;

            StateNormalBackgroundColour = Color.Empty;

            StateNormalTextColour = Color.Empty;

            StateNormalBorderColourOne = Color.Empty;

            StateNormalBorderColourTwo = Color.Empty;

            Typeface = Classes.Typeface.DefaultTypeface();

            CornerRadius = -1;

            UpdateStateActiveAppearanceValues(StateActiveBackGroundColour, StateActiveTextColour, StateActiveBorderColourOne, StateActiveBorderColourTwo, Typeface);

            UpdateStateCommonAppearanceValues(StateCommonBackGroundColour, StateCommonTextColour, StateCommonBorderColourOne, StateCommonBorderColourTwo, Typeface);

            UpdateStateDisabledAppearanceValues(StateDisabledBackGroundColour, StateDisabledTextColour, StateDisabledBorderColourOne, StateDisabledBorderColourTwo, Typeface);

            UpdateStateNormalAppearanceValues(StateNormalBackgroundColour, StateNormalTextColour, StateNormalBorderColourOne, StateNormalBorderColourTwo, Typeface);
        }
        #endregion

        #region Method
        private void UpdateStateActiveAppearanceValues(Color stateActiveBackGroundColour, Color stateActiveTextColour, Color borderColourOne, Color borderColourTwo, Font typeface)
        {
            StateActive.Back.Color1 = stateActiveBackGroundColour;

            StateActive.Content.Color1 = stateActiveTextColour;

            StateActive.Border.Color1 = borderColourOne;

            StateActive.Border.Color2 = borderColourTwo;

            StateActive.Content.Font = typeface;
        }

        private void UpdateStateCommonAppearanceValues(Color backgroundColour, Color textColour, Color borderColourOne, Color borderColourTwo, Font typeface)
        {
            StateCommon.Back.Color1 = backgroundColour;

            StateCommon.Content.Color1 = textColour;

            StateCommon.Border.Color1 = borderColourOne;

            StateCommon.Border.Color2 = borderColourTwo;

            StateCommon.Content.Font = typeface;
        }

        private void UpdateStateDisabledAppearanceValues(Color stateDisabledBackGroundColour, Color stateDisabledTextColour, Color borderColourOne, Color borderColourTwo, Font typeface)
        {
            StateDisabled.Back.Color1 = stateDisabledBackGroundColour;

            StateDisabled.Content.Color1 = stateDisabledTextColour;

            StateDisabled.Border.Color1 = borderColourOne;

            StateDisabled.Border.Color2 = borderColourTwo;

            StateDisabled.Content.Font = typeface;
        }

        private void UpdateStateNormalAppearanceValues(Color stateNormalBackgroundColour, Color stateNormalTextColour, Color borderColourOne, Color borderColourTwo, Font typeface)
        {
            StateNormal.Back.Color1 = stateNormalBackgroundColour;

            StateNormal.Content.Color1 = stateNormalTextColour;

            StateNormal.Border.Color1 = borderColourOne;

            StateNormal.Border.Color2 = borderColourTwo;

            StateNormal.Content.Font = typeface;
        }

        //private void DefineCornerRadius(int radiusValue)=>StateCommon.Border.
        #endregion

        #region Override
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateStateActiveAppearanceValues(StateActiveBackGroundColour, StateActiveTextColour, StateActiveBorderColourOne, StateActiveBorderColourTwo, Typeface);

            UpdateStateCommonAppearanceValues(StateCommonBackGroundColour, StateCommonTextColour, StateCommonBorderColourOne, StateCommonBorderColourTwo, Typeface);

            UpdateStateDisabledAppearanceValues(StateDisabledBackGroundColour, StateDisabledTextColour, StateDisabledBorderColourOne, StateDisabledBorderColourTwo, Typeface);

            UpdateStateNormalAppearanceValues(StateNormalBackgroundColour, StateNormalTextColour, StateNormalBorderColourOne, StateNormalBorderColourTwo, Typeface);

            base.OnPaint(e);
        }

        #endregion
    }
}