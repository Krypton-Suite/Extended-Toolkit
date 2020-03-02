using ComponentFactory.Krypton.Toolkit;
using ExtendedStandardControls.Classes;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ExtendedStandardControls
{
    [ToolboxBitmap(typeof(KryptonGroupBox))]
    public class KryptonGroupBoxExtended : KryptonGroupBox
    {
        #region Variables
        private Color _stateCommonBackGroundColourOne, _stateCommonBackGroundColourTwo, _stateCommonLongTextColourOne, _stateCommonLongTextColourTwo, _stateCommonShortTextColourOne, _stateCommonShortTextColourTwo, _stateCommonBorderColourOne, _stateCommonBorderColourTwo,
                      _stateDisabledBackGroundColourOne, _stateDisabledBackGroundColourTwo, _stateDisabledLongTextColourOne, _stateDisabledLongTextColourTwo, _stateDisabledShortTextColourOne, _stateDisabledShortTextColourTwo, _stateDisabledBorderColourOne, _stateDisabledBorderColourTwo,
                      _stateNormalBackGroundColourOne, _stateNormalBackGroundColourTwo, _stateNormalLongTextColourOne, _stateNormalLongTextColourTwo, _stateNormalShortTextColourOne, _stateNormalShortTextColourTwo, _stateNormalBorderColourOne, _stateNormalBorderColourTwo;

        private Font _longTextTypeface, _shortTextTypeface;

        private Image _image;
        #endregion

        #region Properties

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

        public Color StateDisabledBorderColourTwo { get => _stateDisabledBorderColourTwo; set { _stateDisabledLongTextColourOne = value; Invalidate(); } }
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
        public KryptonGroupBoxExtended()
        {
            #region State Common
            StateCommonBackGroundColourOne = Color.Empty;

            StateCommonBackGroundColourTwo = Color.Empty;

            StateCommonLongTextColourOne = Color.Empty;

            StateCommonLongTextColourTwo = Color.Empty;

            StateCommonShortTextColourOne = Color.Empty;

            StateCommonShortTextColourTwo = Color.Empty;

            StateCommonBorderColourOne = Color.Empty;

            StateCommonBorderColourTwo = Color.Empty;
            #endregion

            #region State Disabled
            StateDisabledBackGroundColourOne = Color.Empty;

            StateDisabledBackGroundColourTwo = Color.Empty;

            StateDisabledLongTextColourOne = Color.Empty;

            StateDisabledLongTextColourTwo = Color.Empty;

            StateDisabledShortTextColourOne = Color.Empty;

            StateDisabledShortTextColourTwo = Color.Empty;

            StateDisabledBorderColourOne = Color.Empty;

            StateDisabledBorderColourTwo = Color.Empty;
            #endregion

            #region State Normal
            StateNormalBackGroundColourOne = Color.Empty;

            StateNormalBackGroundColourTwo = Color.Empty;

            StateNormalLongTextColourOne = Color.Empty;

            StateNormalLongTextColourTwo = Color.Empty;

            StateNormalShortTextColourOne = Color.Empty;

            StateNormalShortTextColourTwo = Color.Empty;

            StateNormalBorderColourOne = Color.Empty;

            StateNormalBorderColourTwo = Color.Empty;
            #endregion

            LongTextTypeface = Typeface.DefaultTypeface();

            ShortTextTypeface = Typeface.DefaultTypeface();

            Image = null;

            UpdateStateCommonAppearanceValues(StateCommonBackGroundColourOne, StateCommonBackGroundColourTwo, StateCommonLongTextColourOne, StateCommonLongTextColourTwo, StateCommonShortTextColourOne, StateCommonShortTextColourTwo, StateCommonBorderColourOne, StateCommonBorderColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateDisabledAppearanceValues(StateDisabledBackGroundColourOne, StateDisabledBackGroundColourTwo, StateDisabledLongTextColourOne, StateDisabledLongTextColourTwo, StateDisabledShortTextColourOne, StateDisabledShortTextColourTwo, StateDisabledBorderColourOne, StateDisabledBorderColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateNormalAppearanceValues(StateNormalBackGroundColourOne, StateNormalBackGroundColourTwo, StateNormalLongTextColourOne, StateNormalLongTextColourTwo, StateNormalShortTextColourOne, StateNormalShortTextColourTwo, StateNormalBorderColourOne, StateNormalBorderColourTwo, LongTextTypeface, ShortTextTypeface, Image);
        }
        #endregion

        #region Method
        /// <summary>Updates the state common appearance values.</summary>
        /// <param name="backGroundColourOne">The back ground colour one.</param>
        /// <param name="backGroundColourTwo">The back ground colour two.</param>
        /// <param name="longTextColourOne">The long text colour one.</param>
        /// <param name="longTextColourTwo">The long text colour two.</param>
        /// <param name="longTextTypeface">The long text typeface.</param>
        /// <param name="shortTextColourOne">The short text colour one.</param>
        /// <param name="shortTextColourTwo">The short text colour two.</param>
        /// <param name="shortTextTypeface">The short text typeface.</param>
        /// <param name="image">The image.</param>
        private void UpdateStateCommonAppearanceValues(Color backGroundColourOne, Color backGroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color borderColourOne, Color borderColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Font longTextTypeface, Font shortTextTypeface, Image image)
        {
            StateCommon.Back.Color1 = backGroundColourOne;

            StateCommon.Back.Color2 = backGroundColourTwo;

            StateCommon.Content.LongText.Color1 = longTextColourOne;

            StateCommon.Content.LongText.Color2 = longTextColourTwo;

            StateCommon.Content.LongText.Font = longTextTypeface;

            StateCommon.Content.LongText.Image = image;

            StateCommon.Content.ShortText.Color1 = shortTextColourOne;

            StateCommon.Content.ShortText.Color2 = shortTextColourTwo;

            StateCommon.Border.Color1 = borderColourOne;

            StateCommon.Border.Color2 = borderColourTwo;

            StateCommon.Content.ShortText.Font = shortTextTypeface;

            StateCommon.Content.ShortText.Image = image;
        }

        /// <summary>Updates the state disabled appearance values.</summary>
        /// <param name="backGroundColourOne">The back ground colour one.</param>
        /// <param name="backGroundColourTwo">The back ground colour two.</param>
        /// <param name="longTextColourOne">The long text colour one.</param>
        /// <param name="longTextColourTwo">The long text colour two.</param>
        /// <param name="longTextTypeface">The long text typeface.</param>
        /// <param name="shortTextColourOne">The short text colour one.</param>
        /// <param name="shortTextColourTwo">The short text colour two.</param>
        /// <param name="shortTextTypeface">The short text typeface.</param>
        /// <param name="image">The image.</param>
        private void UpdateStateDisabledAppearanceValues(Color backGroundColourOne, Color backGroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font longTextTypeface, Font shortTextTypeface, Image image)
        {
            StateDisabled.Back.Color1 = backGroundColourOne;

            StateDisabled.Back.Color2 = backGroundColourTwo;

            StateDisabled.Content.LongText.Color1 = longTextColourOne;

            StateDisabled.Content.LongText.Color2 = longTextColourTwo;

            StateDisabled.Content.LongText.Font = longTextTypeface;

            StateDisabled.Content.LongText.Image = image;

            StateDisabled.Content.ShortText.Color1 = shortTextColourOne;

            StateDisabled.Content.ShortText.Color2 = shortTextColourTwo;

            StateDisabled.Border.Color1 = borderColourOne;

            StateDisabled.Border.Color2 = borderColourTwo;

            StateDisabled.Content.ShortText.Font = shortTextTypeface;

            StateDisabled.Content.ShortText.Image = image;
        }

        /// <summary>Updates the state normal appearance values.</summary>
        /// <param name="backGroundColourOne">The back ground colour one.</param>
        /// <param name="backGroundColourTwo">The back ground colour two.</param>
        /// <param name="longTextColourOne">The long text colour one.</param>
        /// <param name="longTextColourTwo">The long text colour two.</param>
        /// <param name="longTextTypeface">The long text typeface.</param>
        /// <param name="shortTextColourOne">The short text colour one.</param>
        /// <param name="shortTextColourTwo">The short text colour two.</param>
        /// <param name="shortTextTypeface">The short text typeface.</param>
        /// <param name="image">The image.</param>
        private void UpdateStateNormalAppearanceValues(Color backGroundColourOne, Color backGroundColourTwo, Color longTextColourOne, Color longTextColourTwo, Color shortTextColourOne, Color shortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font longTextTypeface, Font shortTextTypeface, Image image)
        {
            StateNormal.Back.Color1 = backGroundColourOne;

            StateNormal.Back.Color2 = backGroundColourTwo;

            StateNormal.Content.LongText.Color1 = longTextColourOne;

            StateNormal.Content.LongText.Color2 = longTextColourTwo;

            StateNormal.Content.LongText.Font = longTextTypeface;

            StateNormal.Content.LongText.Image = image;

            StateNormal.Content.ShortText.Color1 = shortTextColourOne;

            StateNormal.Content.ShortText.Color2 = shortTextColourTwo;

            StateNormal.Border.Color1 = borderColourOne;

            StateNormal.Border.Color2 = borderColourTwo;

            StateNormal.Content.ShortText.Font = shortTextTypeface;

            StateNormal.Content.ShortText.Image = image;
        }
        #endregion

        #region Override
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateStateCommonAppearanceValues(StateCommonBackGroundColourOne, StateCommonBackGroundColourTwo, StateCommonLongTextColourOne, StateCommonLongTextColourTwo, StateCommonShortTextColourOne, StateCommonShortTextColourTwo, StateCommonBorderColourOne, StateCommonBorderColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateDisabledAppearanceValues(StateDisabledBackGroundColourOne, StateDisabledBackGroundColourTwo, StateDisabledLongTextColourOne, StateDisabledLongTextColourTwo, StateDisabledShortTextColourOne, StateDisabledShortTextColourTwo, StateDisabledBorderColourOne, StateDisabledBorderColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            UpdateStateNormalAppearanceValues(StateNormalBackGroundColourOne, StateNormalBackGroundColourTwo, StateNormalLongTextColourOne, StateNormalLongTextColourTwo, StateNormalShortTextColourOne, StateNormalShortTextColourTwo, StateNormalBorderColourOne, StateNormalBorderColourTwo, LongTextTypeface, ShortTextTypeface, Image);

            base.OnPaint(e);
        }
        #endregion
    }
}