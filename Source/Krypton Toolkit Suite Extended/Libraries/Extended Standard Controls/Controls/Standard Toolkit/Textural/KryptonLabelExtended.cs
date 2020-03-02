using ComponentFactory.Krypton.Toolkit;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ExtendedStandardControls
{
    [ToolboxBitmap(typeof(KryptonLabel))]
    public class KryptonLabelExtended : KryptonLabel
    {
        #region Variables
        private Color _stateCommonTextColourOne, _stateCommonTextColourTwo,
                      _stateDisabledTextColourOne, _stateDisabledTextColourTwo,
                      _stateNormalTextColourOne, _stateNormalTextColourTwo;

        private Font _longTextTypeface, _shortTextTypeface;

        private Image _image;
        #endregion

        #region Properties

        #region State Common
        [Category("Appearance"), Description("The first text colour.")]
        public Color StateCommonTextColourOne { get => _stateCommonTextColourOne; set { _stateCommonTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second text colour.")]
        public Color StateCommonTextColourTwo { get => _stateCommonTextColourTwo; set { _stateCommonTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Disabled
        [Category("Appearance"), Description("The first text colour.")]
        public Color StateDisabledTextColourOne { get => _stateDisabledTextColourOne; set { _stateDisabledTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second text colour.")]
        public Color StateDisabledTextColourTwo { get => _stateDisabledTextColourTwo; set { _stateDisabledTextColourTwo = value; Invalidate(); } }  
        #endregion

        #region State Normal
        [Category("Appearance"), Description("The first text colour.")]
        public Color StateNormalTextColourOne { get => _stateNormalTextColourOne; set { _stateNormalTextColourOne = value; Invalidate(); } }

        [Category("Appearance"), Description("The second text colour.")]
        public Color StateNormalTextColourTwo { get => _stateNormalTextColourTwo; set { _stateNormalTextColourTwo = value; Invalidate(); } }            
        #endregion

        #region Globals
        [Category("Appearance"), Description("The 'Long Text' typeface.")]
        public Font LongTextTypeface { get => _longTextTypeface; set { _longTextTypeface = value; Invalidate(); } }

        [Category("Appearance"), Description("The 'Short Text' typeface.")]
        public Font ShortTextTypeface { get => _shortTextTypeface; set { _shortTextTypeface = value; Invalidate(); } }

        [Category("Appearance"), Description("The image.")]
        public Image Image { get => _image; set { _image = value; Invalidate(); } }
        #endregion

        #endregion

        #region Constructor
        public KryptonLabelExtended()
        {
            StateCommonTextColourOne = Color.Empty;

            StateCommonTextColourTwo = Color.Empty;

            StateDisabledTextColourOne = Color.Empty;

            StateDisabledTextColourTwo = Color.Empty;

            StateNormalTextColourOne = Color.Empty;

            StateNormalTextColourTwo = Color.Empty;

            LongTextTypeface = null;

            ShortTextTypeface = null;

            Image = null;

            UpdateCommonAppearanceValues(StateCommonTextColourOne, StateCommonTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateDisabledAppearanceValues(StateDisabledTextColourOne, StateDisabledTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateNormalAppearanceValues(StateNormalTextColourOne, StateNormalTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);
        }
        #endregion

        #region Method
        private void UpdateCommonAppearanceValues(Color textColourOne, Color textColourTwo, Font longTextTypeface, Font shortTextTypeface, Image image)
        {
            StateCommon.LongText.Color1 = textColourOne;

            StateCommon.LongText.Color2 = textColourTwo;

            StateCommon.LongText.Font = longTextTypeface;

            StateCommon.LongText.Image = image;

            StateCommon.ShortText.Color1 = textColourOne;

            StateCommon.ShortText.Color2 = textColourTwo;

            StateCommon.ShortText.Font = shortTextTypeface;

            StateCommon.ShortText.Image = image;
        }

        private void UpdateDisabledAppearanceValues(Color textColourOne, Color textColourTwo, Font longTextTypeface, Font shortTextTypeface, Image image)
        {
            StateDisabled.LongText.Color1 = textColourOne;

            StateDisabled.LongText.Color2 = textColourTwo;

            StateDisabled.LongText.Font = longTextTypeface;

            StateDisabled.LongText.Image = image;

            StateDisabled.ShortText.Color1 = textColourOne;

            StateDisabled.ShortText.Color2 = textColourTwo;

            StateDisabled.ShortText.Font = shortTextTypeface;

            StateDisabled.ShortText.Image = image;
        }

        private void UpdateNormalAppearanceValues(Color textColourOne, Color textColourTwo, Font longTextTypeface, Font shortTextTypeface, Image image)
        {
            StateNormal.LongText.Color1 = textColourOne;

            StateNormal.LongText.Color2 = textColourTwo;

            StateNormal.LongText.Font = longTextTypeface;

            StateNormal.LongText.Image = image;

            StateNormal.ShortText.Color1 = textColourOne;

            StateNormal.ShortText.Color2 = textColourTwo;

            StateNormal.ShortText.Font = shortTextTypeface;

            StateNormal.ShortText.Image = image;
        }
        #endregion

        #region Override
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateCommonAppearanceValues(StateCommonTextColourOne, StateCommonTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateDisabledAppearanceValues(StateDisabledTextColourOne, StateDisabledTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateNormalAppearanceValues(StateNormalTextColourOne, StateNormalTextColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            base.OnPaint(e);
        }
        #endregion
    }
}