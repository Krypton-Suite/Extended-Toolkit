using ComponentFactory.Krypton.Toolkit;
using ExtendedStandardControls.Classes;
using System.Drawing;
using System.Windows.Forms;

namespace ExtendedStandardControls
{
    [ToolboxBitmap(typeof(KryptonComboBox))]
    public class KryptonComboBoxExtended : KryptonComboBox
    {
        #region Variables
        private Color _stateActiveComboBoxBackColour, _stateActiveComboBoxContentColour, _stateActiveComboBoxBorderColourOne, _stateActiveComboBoxBorderColourTwo,
                      _stateCommonComboBoxBackColour, _stateCommonComboBoxContentColour, _stateCommonComboBoxDropBackColourOne, _stateCommonComboBoxDropBackColourTwo, _stateCommonComboBoxItemBackColourOne, _stateCommonComboBoxItemBackColourTwo, _stateCommonComboBoxItemContentLongTextColourOne, _stateCommonComboBoxItemContentLongTextColourTwo, _stateCommonComboBoxItemContentShortTextColourOne, _stateCommonComboBoxItemContentShortTextColourTwo, _stateCommonComboBoxBorderColourOne, _stateCommonComboBoxBorderColourTwo,
                      _stateDisabledComboBoxBackColour, _stateDisabledComboBoxContentColour, _stateDisabledComboBoxItemBackColourOne, _stateDisabledComboBoxItemBackColourTwo, _stateDisabledComboBoxItemContentLongTextColourOne, _stateDisabledComboBoxItemContentLongTextColourTwo, _stateDisabledComboBoxItemContentShortTextColourOne, _stateDisabledComboBoxItemContentShortTextColourTwo, _stateDisabledComboBoxBorderColourOne, _stateDisabledComboBoxBorderColourTwo,
                      _stateNormalComboBoxBackColour, _stateNormalComboBoxContentColour, _stateNormalComboBoxItemBackColourOne, _stateNormalComboBoxItemBackColourTwo, _stateNormalComboBoxItemContentLongTextColourOne, _stateNormalComboBoxItemContentLongTextColourTwo, _stateNormalComboBoxItemContentShortTextColourOne, _stateNormalComboBoxItemContentShortTextColourTwo, _stateNormalComboBoxBorderColourOne, _stateNormalComboBoxBorderColourTwo,
                      _stateTrackingComboBoxItemBackColourOne, _stateTrackingComboBoxItemBackColourTwo, _stateTrackingComboBoxItemContentLongTextColourOne, _stateTrackingComboBoxItemContentLongTextColourTwo, _stateTrackingComboBoxItemContentShortTextColourOne, _stateTrackingComboBoxItemContentShortTextColourTwo;

        private Font _comboBoxContentTypeface, _comboBoxItemContentLongTextTypeface, _comboBoxItemContentShortTextTypeface;

        private Image _image;
        #endregion

        #region Properties

        #region State Active
        public Color StateActiveComboBoxBackColour { get => _stateActiveComboBoxBackColour; set { _stateActiveComboBoxBackColour = value; Invalidate(); } }

        public Color StateActiveComboBoxContentColour { get => _stateActiveComboBoxContentColour; set { _stateActiveComboBoxContentColour = value; Invalidate(); } }

        public Color StateActiveComboBoxBorderColourOne { get => _stateActiveComboBoxBorderColourOne; set { _stateActiveComboBoxBorderColourOne = value; Invalidate(); } }

        public Color StateActiveComboBoxBorderColourTwo { get => _stateActiveComboBoxBorderColourTwo; set { _stateActiveComboBoxBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Common
        public Color StateCommonComboBoxBackColour { get => _stateCommonComboBoxBackColour; set { _stateCommonComboBoxBackColour = value; Invalidate(); } }

        public Color StateCommonComboBoxContentColour { get => _stateCommonComboBoxContentColour; set { _stateCommonComboBoxContentColour = value; Invalidate(); } }

        public Color StateCommonComboBoxDropBackColourOne { get => _stateCommonComboBoxDropBackColourOne; set { _stateCommonComboBoxDropBackColourOne = value; Invalidate(); } }

        public Color StateCommonComboBoxDropBackColourTwo { get => _stateCommonComboBoxDropBackColourTwo; set { _stateCommonComboBoxDropBackColourTwo = value; Invalidate(); } }

        public Color StateCommonComboBoxItemBackColourOne { get => _stateCommonComboBoxItemBackColourOne; set { _stateCommonComboBoxItemBackColourOne = value; Invalidate(); } }

        public Color StateCommonComboBoxItemBackColourTwo { get => _stateCommonComboBoxItemBackColourTwo; set { _stateCommonComboBoxItemBackColourTwo = value; Invalidate(); } }

        public Color StateCommonComboBoxItemContentLongTextColourOne { get => _stateCommonComboBoxItemContentLongTextColourOne; set { _stateCommonComboBoxItemContentLongTextColourOne = value; Invalidate(); } }

        public Color StateCommonComboBoxItemContentLongTextColourTwo { get => _stateCommonComboBoxItemContentLongTextColourTwo; set { _stateCommonComboBoxItemContentLongTextColourTwo = value; Invalidate(); } }

        public Color StateCommonComboBoxItemContentShortTextColourOne { get => _stateCommonComboBoxItemContentShortTextColourOne; set { _stateCommonComboBoxItemContentShortTextColourOne = value; Invalidate(); } }

        public Color StateCommonComboBoxItemContentShortTextColourTwo { get => _stateCommonComboBoxItemContentShortTextColourTwo; set { _stateCommonComboBoxItemContentShortTextColourTwo = value; Invalidate(); } }

        public Color StateCommonComboBoxBorderColourOne { get => _stateCommonComboBoxBorderColourOne; set { _stateCommonComboBoxBorderColourOne = value; Invalidate(); } }

        public Color StateCommonComboBoxBorderColourTwo { get => _stateCommonComboBoxBorderColourTwo; set { _stateCommonComboBoxBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Disabled
        public Color StateDisabledComboBoxBackColour { get => _stateDisabledComboBoxBackColour; set { _stateDisabledComboBoxBackColour = value; Invalidate(); } }

        public Color StateDisabledComboBoxContentColour { get => _stateDisabledComboBoxContentColour; set { _stateDisabledComboBoxContentColour = value; Invalidate(); } }

        public Color StateDisabledComboBoxItemBackColourOne { get => _stateDisabledComboBoxItemBackColourOne; set { _stateDisabledComboBoxItemBackColourOne = value; Invalidate(); } }

        public Color StateDisabledComboBoxItemBackColourTwo { get => _stateDisabledComboBoxItemBackColourTwo; set { _stateDisabledComboBoxItemBackColourTwo = value; Invalidate(); } }

        public Color StateDisabledComboBoxItemContentLongTextColourOne { get => _stateDisabledComboBoxItemContentLongTextColourOne; set { _stateDisabledComboBoxItemContentLongTextColourOne = value; Invalidate(); } }

        public Color StateDisabledComboBoxItemContentLongTextColourTwo { get => _stateDisabledComboBoxItemContentLongTextColourTwo; set { _stateDisabledComboBoxItemContentLongTextColourTwo = value; Invalidate(); } }

        public Color StateDisabledComboBoxItemContentShortTextColourOne { get => _stateDisabledComboBoxItemContentShortTextColourOne; set { _stateDisabledComboBoxItemContentShortTextColourOne = value; Invalidate(); } }

        public Color StateDisabledComboBoxItemContentShortTextColourTwo { get => _stateDisabledComboBoxItemContentShortTextColourTwo; set { _stateDisabledComboBoxItemContentShortTextColourTwo = value; Invalidate(); } }

        public Color StateDisabledComboBoxBorderColourOne { get => _stateDisabledComboBoxBorderColourOne; set { _stateDisabledComboBoxBorderColourOne = value; Invalidate(); } }

        public Color StateDisabledComboBoxBorderColourTwo { get => _stateDisabledComboBoxBorderColourTwo; set { _stateDisabledComboBoxBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Normal
        public Color StateNormalComboBoxBackColour { get => _stateNormalComboBoxBackColour; set { _stateNormalComboBoxBackColour = value; Invalidate(); } }

        public Color StateNormalComboBoxContentColour { get => _stateNormalComboBoxContentColour; set { _stateNormalComboBoxContentColour = value; Invalidate(); } }

        public Color StateNormalComboBoxItemBackColourOne { get => _stateNormalComboBoxItemBackColourOne; set { _stateNormalComboBoxItemBackColourOne = value; Invalidate(); } }

        public Color StateNormalComboBoxItemBackColourTwo { get => _stateNormalComboBoxItemBackColourTwo; set { _stateNormalComboBoxItemBackColourTwo = value; Invalidate(); } }

        public Color StateNormalComboBoxItemContentLongTextColourOne { get => _stateNormalComboBoxItemContentLongTextColourOne; set { _stateNormalComboBoxItemContentLongTextColourOne = value; Invalidate(); } }

        public Color StateNormalComboBoxItemContentLongTextColourTwo { get => _stateNormalComboBoxItemContentLongTextColourTwo; set { _stateNormalComboBoxItemContentLongTextColourTwo = value; Invalidate(); } }

        public Color StateNormalComboBoxItemContentShortTextColourOne { get => _stateNormalComboBoxItemContentShortTextColourOne; set { _stateNormalComboBoxItemContentShortTextColourOne = value; Invalidate(); } }

        public Color StateNormalComboBoxItemContentShortTextColourTwo { get => _stateNormalComboBoxItemContentShortTextColourTwo; set { _stateNormalComboBoxItemContentShortTextColourTwo = value; Invalidate(); } }

        public Color StateNormalComboBoxBorderColourOne { get => _stateNormalComboBoxBorderColourOne; set { _stateNormalComboBoxBorderColourOne = value; Invalidate(); } }

        public Color StateNormalComboBoxBorderColourTwo { get => _stateNormalComboBoxBorderColourTwo; set { _stateNormalComboBoxBorderColourTwo = value; Invalidate(); } }
        #endregion

        #region State Tracking
        public Color StateTrackingComboBoxItemBackColourOne { get => _stateTrackingComboBoxItemBackColourOne; set { _stateTrackingComboBoxItemBackColourOne = value; Invalidate(); } }

        public Color StateTrackingComboBoxItemBackColourTwo { get => _stateTrackingComboBoxItemBackColourTwo; set { _stateTrackingComboBoxItemBackColourTwo = value; Invalidate(); } }

        public Color StateTrackingComboBoxItemContentLongTextColourOne { get => _stateTrackingComboBoxItemContentLongTextColourOne; set { _stateTrackingComboBoxItemContentLongTextColourOne = value; Invalidate(); } }

        public Color StateTrackingComboBoxItemContentLongTextColourTwo { get => _stateTrackingComboBoxItemContentLongTextColourTwo; set { _stateTrackingComboBoxItemContentLongTextColourTwo = value; Invalidate(); } }

        public Color StateTrackingComboBoxItemContentShortTextColourOne { get => _stateTrackingComboBoxItemContentShortTextColourOne; set { _stateTrackingComboBoxItemContentShortTextColourOne = value; Invalidate(); } }

        public Color StateTrackingComboBoxItemContentShortTextColourTwo { get => _stateTrackingComboBoxItemContentShortTextColourTwo; set { _stateTrackingComboBoxItemContentShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region Globals
        public Font ComboBoxContentTypeface { get => _comboBoxContentTypeface; set { _comboBoxContentTypeface = value; Invalidate(); } }

        public Font ComboBoxItemContentLongTextTypeface { get => _comboBoxItemContentLongTextTypeface; set { _comboBoxItemContentLongTextTypeface = value; Invalidate(); } }

        public Font ComboBoxItemContentShortTextTypeface { get => _comboBoxItemContentShortTextTypeface; set { _comboBoxItemContentShortTextTypeface = value; Invalidate(); } }

        public Image Image { get => _image; set { _image = value; Invalidate(); } }
        #endregion

        #endregion

        #region Constructor
        public KryptonComboBoxExtended()
        {
            #region State Active
            StateActiveComboBoxBackColour = Color.Empty;

            StateActiveComboBoxContentColour = Color.Empty;

            StateActiveComboBoxBorderColourOne = Color.Empty;

            StateActiveComboBoxBorderColourTwo = Color.Empty;
            #endregion

            #region State Common
            StateCommonComboBoxBackColour = Color.Empty;

            StateCommonComboBoxContentColour = Color.Empty;

            StateCommonComboBoxDropBackColourOne = Color.Empty;

            StateCommonComboBoxDropBackColourTwo = Color.Empty;

            StateCommonComboBoxItemBackColourOne = Color.Empty;

            StateCommonComboBoxItemBackColourTwo = Color.Empty;

            StateCommonComboBoxItemContentLongTextColourOne = Color.Empty;

            StateCommonComboBoxItemContentLongTextColourTwo = Color.Empty;

            StateCommonComboBoxItemContentShortTextColourOne = Color.Empty;

            StateCommonComboBoxItemContentShortTextColourTwo = Color.Empty;

            StateCommonComboBoxBorderColourOne = Color.Empty;

            StateCommonComboBoxBorderColourTwo = Color.Empty;
            #endregion

            #region State Disabled
            StateDisabledComboBoxBackColour = Color.Empty;

            StateDisabledComboBoxContentColour = Color.Empty;

            StateDisabledComboBoxItemBackColourOne = Color.Empty;

            StateDisabledComboBoxItemBackColourTwo = Color.Empty;

            StateDisabledComboBoxItemContentLongTextColourOne = Color.Empty;

            StateDisabledComboBoxItemContentLongTextColourTwo = Color.Empty;

            StateDisabledComboBoxItemContentShortTextColourOne = Color.Empty;

            StateDisabledComboBoxItemContentShortTextColourTwo = Color.Empty;

            StateDisabledComboBoxBorderColourOne = Color.Empty;

            StateDisabledComboBoxBorderColourTwo = Color.Empty;
            #endregion

            #region State Normal
            StateNormalComboBoxBackColour = Color.Empty;

            StateNormalComboBoxContentColour = Color.Empty;

            StateNormalComboBoxItemBackColourOne = Color.Empty;

            StateNormalComboBoxItemBackColourTwo = Color.Empty;

            StateNormalComboBoxItemContentLongTextColourOne = Color.Empty;

            StateNormalComboBoxItemContentLongTextColourTwo = Color.Empty;

            StateNormalComboBoxItemContentShortTextColourOne = Color.Empty;

            StateNormalComboBoxItemContentShortTextColourTwo = Color.Empty;

            StateNormalComboBoxBorderColourOne = Color.Empty;

            StateNormalComboBoxBorderColourTwo = Color.Empty;
            #endregion

            #region State Tracking
            StateTrackingComboBoxItemBackColourOne = Color.Empty;

            StateTrackingComboBoxItemBackColourTwo = Color.Empty;

            StateTrackingComboBoxItemContentLongTextColourOne = Color.Empty;

            StateTrackingComboBoxItemContentLongTextColourTwo = Color.Empty;

            StateTrackingComboBoxItemContentShortTextColourOne = Color.Empty;

            StateTrackingComboBoxItemContentShortTextColourTwo = Color.Empty;
            #endregion

            #region Globals
            ComboBoxContentTypeface = Typeface.DefaultTypeface();

            ComboBoxItemContentLongTextTypeface = Typeface.DefaultTypeface();

            ComboBoxItemContentShortTextTypeface = Typeface.DefaultTypeface();

            Image = null;
            #endregion

            UpdateStateActiveAppearanceValues(StateActiveComboBoxBackColour, StateActiveComboBoxContentColour, StateActiveComboBoxBorderColourOne, StateActiveComboBoxBorderColourTwo, ComboBoxContentTypeface);

            UpdateStateCommonAppearanceValues(StateCommonComboBoxBackColour, StateCommonComboBoxContentColour, StateCommonComboBoxDropBackColourOne, StateCommonComboBoxDropBackColourTwo, StateCommonComboBoxItemBackColourOne, StateCommonComboBoxItemBackColourTwo, StateCommonComboBoxItemContentLongTextColourOne, StateCommonComboBoxItemContentLongTextColourTwo, StateCommonComboBoxItemContentShortTextColourOne, StateCommonComboBoxItemContentShortTextColourTwo, StateCommonComboBoxBorderColourOne, StateCommonComboBoxBorderColourTwo, ComboBoxContentTypeface, ComboBoxItemContentLongTextTypeface, ComboBoxItemContentShortTextTypeface, Image);

            UpdateStateDisabledAppearanceValues(StateDisabledComboBoxBackColour, StateDisabledComboBoxContentColour, StateDisabledComboBoxItemBackColourOne, StateDisabledComboBoxItemBackColourTwo, StateDisabledComboBoxItemContentLongTextColourOne, StateDisabledComboBoxItemContentLongTextColourTwo, StateDisabledComboBoxItemContentShortTextColourOne, StateDisabledComboBoxItemContentShortTextColourTwo, StateDisabledComboBoxBorderColourOne, StateDisabledComboBoxBorderColourTwo, ComboBoxContentTypeface, ComboBoxItemContentLongTextTypeface, ComboBoxItemContentShortTextTypeface, Image);

            UpdateStateNormalAppearanceValues(StateNormalComboBoxBackColour, StateNormalComboBoxContentColour, StateNormalComboBoxItemBackColourOne, StateNormalComboBoxItemBackColourTwo, StateNormalComboBoxItemContentLongTextColourOne, StateNormalComboBoxItemContentLongTextColourTwo, StateNormalComboBoxItemContentShortTextColourOne, StateNormalComboBoxItemContentShortTextColourTwo, StateNormalComboBoxBorderColourOne, StateNormalComboBoxBorderColourTwo, ComboBoxContentTypeface, ComboBoxItemContentLongTextTypeface, ComboBoxItemContentShortTextTypeface, Image);

            UpdateStateTrackingAppearanceValues(StateTrackingComboBoxItemBackColourOne, StateTrackingComboBoxItemBackColourTwo, StateTrackingComboBoxItemContentLongTextColourOne, StateTrackingComboBoxItemContentLongTextColourTwo, StateTrackingComboBoxItemContentShortTextColourOne, StateTrackingComboBoxItemContentShortTextColourTwo, ComboBoxContentTypeface, ComboBoxItemContentLongTextTypeface, ComboBoxItemContentShortTextTypeface, Image);
        }
        #endregion

        #region Method        
        /// <summary>
        /// Updates the state active appearance values.
        /// </summary>
        /// <param name="comboBoxBackColour">The combo box back colour.</param>
        /// <param name="comboBoxContentColour">The combo box content colour.</param>
        /// <param name="comboBoxContentTypeface">The combo box content typeface.</param>
        private void UpdateStateActiveAppearanceValues(Color comboBoxBackColour, Color comboBoxContentColour, Color borderColourOne, Color borderColourTwo, Font comboBoxContentTypeface)
        {
            StateActive.ComboBox.Back.Color1 = comboBoxBackColour;

            StateActive.ComboBox.Content.Color1 = comboBoxContentColour;

            StateActive.ComboBox.Border.Color1 = borderColourOne;

            StateActive.ComboBox.Border.Color2 = borderColourTwo;

            StateActive.ComboBox.Content.Font = comboBoxContentTypeface;
        }

        /// <summary>
        /// Updates the state common appearance values.
        /// </summary>
        /// <param name="comboBoxBackColour">The combo box back colour.</param>
        /// <param name="comboBoxContentColour">The combo box content colour.</param>
        /// <param name="comboBoxDropBackColourOne">The combo box drop back colour one.</param>
        /// <param name="comboBoxDropBackColourTwo">The combo box drop back colour two.</param>
        /// <param name="comboBoxItemBackColourOne">The combo box item back colour one.</param>
        /// <param name="comboBoxItemBackColourTwo">The combo box item back colour two.</param>
        /// <param name="comboBoxItemContentLongTextColourOne">The combo box item content long text colour one.</param>
        /// <param name="comboBoxItemContentLongTextColourTwo">The combo box item content long text colour two.</param>
        /// <param name="comboBoxItemContentShortTextColourOne">The combo box item content short text colour one.</param>
        /// <param name="comboBoxItemContentShortTextColourTwo">The combo box item content short text colour two.</param>
        /// <param name="comboBoxContentTypeface">The combo box content typeface.</param>
        /// <param name="comboBoxItemContentLongTextTypeface">The combo box item content long text typeface.</param>
        /// <param name="comboBoxItemContentShortTextTypeface">The combo box item content short text typeface.</param>
        /// <param name="image">The image.</param>
        private void UpdateStateCommonAppearanceValues(Color comboBoxBackColour, Color comboBoxContentColour, Color comboBoxDropBackColourOne, Color comboBoxDropBackColourTwo, Color comboBoxItemBackColourOne, Color comboBoxItemBackColourTwo, Color comboBoxItemContentLongTextColourOne, Color comboBoxItemContentLongTextColourTwo, Color comboBoxItemContentShortTextColourOne, Color comboBoxItemContentShortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font comboBoxContentTypeface, Font comboBoxItemContentLongTextTypeface, Font comboBoxItemContentShortTextTypeface, Image image)
        {
            StateCommon.ComboBox.Back.Color1 = comboBoxBackColour;

            StateCommon.ComboBox.Content.Color1 = comboBoxContentColour;

            StateCommon.ComboBox.Content.Font = comboBoxContentTypeface;

            StateCommon.DropBack.Color1 = comboBoxDropBackColourOne;

            StateCommon.DropBack.Color2 = comboBoxDropBackColourTwo;

            StateCommon.Item.Back.Color1 = comboBoxItemBackColourOne;

            StateCommon.Item.Back.Color2 = comboBoxItemBackColourTwo;

            StateCommon.Item.Content.LongText.Color1 = comboBoxItemContentLongTextColourOne;

            StateCommon.Item.Content.LongText.Color2 = comboBoxItemContentLongTextColourTwo;

            StateCommon.Item.Content.LongText.Font = comboBoxItemContentLongTextTypeface;

            StateCommon.Item.Content.LongText.Image = image;

            StateCommon.Item.Content.ShortText.Color1 = comboBoxItemContentShortTextColourOne;

            StateCommon.Item.Content.ShortText.Color2 = comboBoxItemContentShortTextColourTwo;

            StateCommon.ComboBox.Border.Color1 = borderColourOne;

            StateCommon.ComboBox.Border.Color2 = borderColourTwo;

            StateCommon.Item.Content.ShortText.Font = comboBoxItemContentShortTextTypeface;

            StateCommon.Item.Content.ShortText.Image = image;
        }

        /// <summary>
        /// Updates the state disabled appearance values.
        /// </summary>
        /// <param name="comboBoxBackColour">The combo box back colour.</param>
        /// <param name="comboBoxContentColour">The combo box content colour.</param>
        /// <param name="comboBoxItemBackColourOne">The combo box item back colour one.</param>
        /// <param name="comboBoxItemBackColourTwo">The combo box item back colour two.</param>
        /// <param name="comboBoxItemContentLongTextColourOne">The combo box item content long text colour one.</param>
        /// <param name="comboBoxItemContentLongTextColourTwo">The combo box item content long text colour two.</param>
        /// <param name="comboBoxItemContentShortTextColourOne">The combo box item content short text colour one.</param>
        /// <param name="comboBoxItemContentShortTextColourTwo">The combo box item content short text colour two.</param>
        /// <param name="comboBoxContentTypeface">The combo box content typeface.</param>
        /// <param name="comboBoxItemContentLongTextTypeface">The combo box item content long text typeface.</param>
        /// <param name="comboBoxItemContentShortTextTypeface">The combo box item content short text typeface.</param>
        /// <param name="image">The image.</param>
        private void UpdateStateDisabledAppearanceValues(Color comboBoxBackColour, Color comboBoxContentColour, Color comboBoxItemBackColourOne, Color comboBoxItemBackColourTwo, Color comboBoxItemContentLongTextColourOne, Color comboBoxItemContentLongTextColourTwo, Color comboBoxItemContentShortTextColourOne, Color comboBoxItemContentShortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font comboBoxContentTypeface, Font comboBoxItemContentLongTextTypeface, Font comboBoxItemContentShortTextTypeface, Image image)
        {
            StateDisabled.ComboBox.Back.Color1 = comboBoxBackColour;

            StateDisabled.ComboBox.Content.Color1 = comboBoxContentColour;

            StateDisabled.ComboBox.Content.Font = comboBoxContentTypeface;

            StateDisabled.Item.Back.Color1 = comboBoxItemBackColourOne;

            StateDisabled.Item.Back.Color2 = comboBoxItemBackColourTwo;

            StateDisabled.Item.Content.LongText.Color1 = comboBoxItemContentLongTextColourOne;

            StateDisabled.Item.Content.LongText.Color2 = comboBoxItemContentLongTextColourTwo;

            StateDisabled.Item.Content.LongText.Font = comboBoxItemContentLongTextTypeface;

            StateDisabled.Item.Content.LongText.Image = image;

            StateDisabled.Item.Content.ShortText.Color1 = comboBoxItemContentShortTextColourOne;

            StateDisabled.Item.Content.ShortText.Color2 = comboBoxItemContentShortTextColourTwo;

            StateDisabled.ComboBox.Border.Color1 = borderColourOne;

            StateDisabled.ComboBox.Border.Color2 = borderColourTwo;

            StateDisabled.Item.Content.ShortText.Font = comboBoxItemContentShortTextTypeface;

            StateDisabled.Item.Content.ShortText.Image = image;
        }

        /// <summary>
        /// Updates the state normal appearance values.
        /// </summary>
        /// <param name="comboBoxBackColour">The combo box back colour.</param>
        /// <param name="comboBoxContentColour">The combo box content colour.</param>
        /// <param name="comboBoxItemBackColourOne">The combo box item back colour one.</param>
        /// <param name="comboBoxItemBackColourTwo">The combo box item back colour two.</param>
        /// <param name="comboBoxItemContentLongTextColourOne">The combo box item content long text colour one.</param>
        /// <param name="comboBoxItemContentLongTextColourTwo">The combo box item content long text colour two.</param>
        /// <param name="comboBoxItemContentShortTextColourOne">The combo box item content short text colour one.</param>
        /// <param name="comboBoxItemContentShortTextColourTwo">The combo box item content short text colour two.</param>
        /// <param name="comboBoxContentTypeface">The combo box content typeface.</param>
        /// <param name="comboBoxItemContentLongTextTypeface">The combo box item content long text typeface.</param>
        /// <param name="comboBoxItemContentShortTextTypeface">The combo box item content short text typeface.</param>
        /// <param name="image">The image.</param>
        private void UpdateStateNormalAppearanceValues(Color comboBoxBackColour, Color comboBoxContentColour, Color comboBoxItemBackColourOne, Color comboBoxItemBackColourTwo, Color comboBoxItemContentLongTextColourOne, Color comboBoxItemContentLongTextColourTwo, Color comboBoxItemContentShortTextColourOne, Color comboBoxItemContentShortTextColourTwo, Color borderColourOne, Color borderColourTwo, Font comboBoxContentTypeface, Font comboBoxItemContentLongTextTypeface, Font comboBoxItemContentShortTextTypeface, Image image)
        {
            StateNormal.ComboBox.Back.Color1 = comboBoxBackColour;

            StateNormal.ComboBox.Content.Color1 = comboBoxContentColour;

            StateNormal.ComboBox.Content.Font = comboBoxContentTypeface;

            StateNormal.Item.Back.Color1 = comboBoxItemBackColourOne;

            StateNormal.Item.Back.Color2 = comboBoxItemBackColourTwo;

            StateNormal.Item.Content.LongText.Color1 = comboBoxItemContentLongTextColourOne;

            StateNormal.Item.Content.LongText.Color2 = comboBoxItemContentLongTextColourTwo;

            StateNormal.Item.Content.LongText.Font = comboBoxItemContentLongTextTypeface;

            StateNormal.Item.Content.LongText.Image = image;

            StateNormal.Item.Content.ShortText.Color1 = comboBoxItemContentShortTextColourOne;

            StateNormal.Item.Content.ShortText.Color2 = comboBoxItemContentShortTextColourTwo;

            StateNormal.ComboBox.Border.Color1 = borderColourOne;

            StateNormal.ComboBox.Border.Color2 = borderColourTwo;

            StateNormal.Item.Content.ShortText.Font = comboBoxItemContentShortTextTypeface;

            StateNormal.Item.Content.ShortText.Image = image;
        }

        /// <summary>
        /// Updates the state tracking appearance values.
        /// </summary>
        /// <param name="comboBoxItemBackColourOne">The combo box item back colour one.</param>
        /// <param name="comboBoxItemBackColourTwo">The combo box item back colour two.</param>
        /// <param name="comboBoxItemContentLongTextColourOne">The combo box item content long text colour one.</param>
        /// <param name="comboBoxItemContentLongTextColourTwo">The combo box item content long text colour two.</param>
        /// <param name="comboBoxItemContentShortTextColourOne">The combo box item content short text colour one.</param>
        /// <param name="comboBoxItemContentShortTextColourTwo">The combo box item content short text colour two.</param>
        /// <param name="comboBoxContentTypeface">The combo box content typeface.</param>
        /// <param name="comboBoxItemContentLongTextTypeface">The combo box item content long text typeface.</param>
        /// <param name="comboBoxItemContentShortTextTypeface">The combo box item content short text typeface.</param>
        /// <param name="image">The image.</param>
        private void UpdateStateTrackingAppearanceValues(Color comboBoxItemBackColourOne, Color comboBoxItemBackColourTwo, Color comboBoxItemContentLongTextColourOne, Color comboBoxItemContentLongTextColourTwo, Color comboBoxItemContentShortTextColourOne, Color comboBoxItemContentShortTextColourTwo, Font comboBoxContentTypeface, Font comboBoxItemContentLongTextTypeface, Font comboBoxItemContentShortTextTypeface, Image image)
        {
            StateTracking.Item.Back.Color1 = comboBoxItemBackColourOne;

            StateTracking.Item.Back.Color2 = comboBoxItemBackColourTwo;

            StateTracking.Item.Content.LongText.Color1 = comboBoxItemContentLongTextColourOne;

            StateTracking.Item.Content.LongText.Color2 = comboBoxItemContentLongTextColourTwo;

            StateTracking.Item.Content.LongText.Font = comboBoxItemContentLongTextTypeface;

            StateTracking.Item.Content.LongText.Image = image;

            StateTracking.Item.Content.ShortText.Color1 = comboBoxItemContentShortTextColourOne;

            StateTracking.Item.Content.ShortText.Color2 = comboBoxItemContentShortTextColourTwo;

            StateTracking.Item.Content.ShortText.Font = comboBoxItemContentShortTextTypeface;

            StateTracking.Item.Content.ShortText.Image = image;
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateStateActiveAppearanceValues(StateActiveComboBoxBackColour, StateActiveComboBoxContentColour, StateActiveComboBoxBorderColourOne, StateActiveComboBoxBorderColourTwo, ComboBoxContentTypeface);

            UpdateStateCommonAppearanceValues(StateCommonComboBoxBackColour, StateCommonComboBoxContentColour, StateCommonComboBoxDropBackColourOne, StateCommonComboBoxDropBackColourTwo, StateCommonComboBoxItemBackColourOne, StateCommonComboBoxItemBackColourTwo, StateCommonComboBoxItemContentLongTextColourOne, StateCommonComboBoxItemContentLongTextColourTwo, StateCommonComboBoxItemContentShortTextColourOne, StateCommonComboBoxItemContentShortTextColourTwo, StateCommonComboBoxBorderColourOne, StateCommonComboBoxBorderColourTwo, ComboBoxContentTypeface, ComboBoxItemContentLongTextTypeface, ComboBoxItemContentShortTextTypeface, Image);

            UpdateStateDisabledAppearanceValues(StateDisabledComboBoxBackColour, StateDisabledComboBoxContentColour, StateDisabledComboBoxItemBackColourOne, StateDisabledComboBoxItemBackColourTwo, StateDisabledComboBoxItemContentLongTextColourOne, StateDisabledComboBoxItemContentLongTextColourTwo, StateDisabledComboBoxItemContentShortTextColourOne, StateDisabledComboBoxItemContentShortTextColourTwo, StateDisabledComboBoxBorderColourOne, StateDisabledComboBoxBorderColourTwo, ComboBoxContentTypeface, ComboBoxItemContentLongTextTypeface, ComboBoxItemContentShortTextTypeface, Image);

            UpdateStateNormalAppearanceValues(StateNormalComboBoxBackColour, StateNormalComboBoxContentColour, StateNormalComboBoxItemBackColourOne, StateNormalComboBoxItemBackColourTwo, StateNormalComboBoxItemContentLongTextColourOne, StateNormalComboBoxItemContentLongTextColourTwo, StateNormalComboBoxItemContentShortTextColourOne, StateNormalComboBoxItemContentShortTextColourTwo, StateNormalComboBoxBorderColourOne, StateNormalComboBoxBorderColourTwo, ComboBoxContentTypeface, ComboBoxItemContentLongTextTypeface, ComboBoxItemContentShortTextTypeface, Image);

            UpdateStateTrackingAppearanceValues(StateTrackingComboBoxItemBackColourOne, StateTrackingComboBoxItemBackColourTwo, StateTrackingComboBoxItemContentLongTextColourOne, StateTrackingComboBoxItemContentLongTextColourTwo, StateTrackingComboBoxItemContentShortTextColourOne, StateTrackingComboBoxItemContentShortTextColourTwo, ComboBoxContentTypeface, ComboBoxItemContentLongTextTypeface, ComboBoxItemContentShortTextTypeface, Image);

            base.OnPaint(e);
        }
        #endregion
    }
}