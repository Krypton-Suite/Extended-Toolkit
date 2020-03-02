using ComponentFactory.Krypton.Toolkit;
using ExtendedStandardControls.Classes;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ExtendedStandardControls
{
    /// <summary></summary>
    /// <seealso cref="ComponentFactory.Krypton.Toolkit.KryptonCheckBox" />
    [ToolboxBitmap(typeof(KryptonCheckBox))]
    public class KryptonCheckBoxExtended : KryptonCheckBox
    {
        #region Variables
        private Color _overrideFocusLongTextColourOne, _overrideFocusLongTextColourTwo, _overrideFocusShortTextColourOne, _overrideFocusShortTextColourTwo, 
                     _stateCommonLongTextColourOne, _stateCommonLongTextColourTwo, _stateCommonShortTextColourOne, _stateCommonShortTextColourTwo, 
                     _stateDisabledLongTextColourOne, _stateDisabledLongTextColourTwo, _stateDisabledShortTextColourOne, _stateDisabledShortTextColourTwo, 
                     _stateNormalLongTextColourOne, _stateNormalLongTextColourTwo, _stateNormalShortTextColourOne, _stateNormalShortTextColourTwo;

        private Font _longTextTypeface, _shortTextTypeface;

        private Image _image;
        #endregion

        #region Properties

        #region Override Focus
        /// <summary>Gets or sets the override focus long text colour one.</summary>
        /// <value>The override focus long text colour one.</value>
        [Category("Appearance"), Description("The first long text colour.")]
        public Color OverrideFocusLongTextColourOne { get => _overrideFocusLongTextColourOne; set { _overrideFocusLongTextColourOne = value; Invalidate(); } }

        /// <summary>Gets or sets the override focus long text colour two.</summary>
        /// <value>The override focus long text colour two.</value>
        [Category("Appearance"), Description("The second long text colour.")]
        public Color OverrideFocusLongTextColourTwo { get => _overrideFocusLongTextColourTwo; set { _overrideFocusLongTextColourTwo = value; Invalidate(); } }

        /// <summary>Gets or sets the override focus short text colour one.</summary>
        /// <value>The override focus short text colour one.</value>
        [Category("Appearance"), Description("The first short text colour.")]
        public Color OverrideFocusShortTextColourOne { get => _overrideFocusShortTextColourOne; set { _overrideFocusShortTextColourOne = value; Invalidate(); } }

        /// <summary>Gets or sets the override focus short text colour two.</summary>
        /// <value>The override focus short text colour two.</value>
        [Category("Appearance"), Description("The second short text colour.")]
        public Color OverrideFocusShortTextColourTwo { get => _overrideFocusShortTextColourTwo; set { _overrideFocusShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Common
        /// <summary>Gets or sets the state common long text colour one.</summary>
        /// <value>The state common long text colour one.</value>
        [Category("Appearance"), Description("The first long text colour.")]
        public Color StateCommonLongTextColourOne { get => _stateCommonLongTextColourOne; set { _stateCommonLongTextColourOne = value; Invalidate(); } }

        /// <summary>Gets or sets the state common long text colour two.</summary>
        /// <value>The state common long text colour two.</value>
        [Category("Appearance"), Description("The second long text colour.")]
        public Color StateCommonLongTextColourTwo { get => _stateCommonLongTextColourTwo; set { _stateCommonLongTextColourTwo = value; Invalidate(); } }

        /// <summary>Gets or sets the state common short text colour one.</summary>
        /// <value>The state common short text colour one.</value>
        [Category("Appearance"), Description("The first short text colour.")]
        public Color StateCommonShortTextColourOne { get => _stateCommonShortTextColourOne; set { _stateCommonShortTextColourOne = value; Invalidate(); } }

        /// <summary>Gets or sets the state common short text colour two.</summary>
        /// <value>The state common short text colour two.</value>
        [Category("Appearance"), Description("The second short text colour.")]
        public Color StateCommonShortTextColourTwo { get => _stateCommonShortTextColourTwo; set { _stateCommonShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Disabled
        /// <summary>Gets or sets the state disabled long text colour one.</summary>
        /// <value>The state disabled long text colour one.</value>
        [Category("Appearance"), Description("The first long text colour.")]
        public Color StateDisabledLongTextColourOne { get => _stateDisabledLongTextColourOne; set { _stateDisabledLongTextColourOne = value; Invalidate(); } }

        /// <summary>Gets or sets the state disabled long text colour two.</summary>
        /// <value>The state disabled long text colour two.</value>
        [Category("Appearance"), Description("The second long text colour.")]
        public Color StateDisabledLongTextColourTwo { get => _stateDisabledLongTextColourTwo; set { _stateDisabledLongTextColourTwo = value; Invalidate(); } }

        /// <summary>Gets or sets the state disabled short text colour one.</summary>
        /// <value>The state disabled short text colour one.</value>
        [Category("Appearance"), Description("The first short text colour.")]
        public Color StateDisabledShortTextColourOne { get => _stateDisabledShortTextColourOne; set { _stateDisabledShortTextColourOne = value; Invalidate(); } }

        /// <summary>Gets or sets the state disabled short text colour two.</summary>
        /// <value>The state disabled short text colour two.</value>
        [Category("Appearance"), Description("The second short text colour.")]
        public Color StateDisabledShortTextColourTwo { get => _stateDisabledShortTextColourTwo; set { _stateDisabledShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region State Normal
        /// <summary>Gets or sets the state normal long text colour one.</summary>
        /// <value>The state normal long text colour one.</value>
        [Category("Appearance"), Description("The first long text colour.")]
        public Color StateNormalLongTextColourOne { get => _stateNormalLongTextColourOne; set { _stateNormalLongTextColourOne = value; Invalidate(); } }

        /// <summary>Gets or sets the state normal long text colour two.</summary>
        /// <value>The state normal long text colour two.</value>
        [Category("Appearance"), Description("The second long text colour.")]
        public Color StateNormalLongTextColourTwo { get => _stateNormalLongTextColourTwo; set { _stateNormalLongTextColourTwo = value; Invalidate(); } }

        /// <summary>Gets or sets the state normal short text colour one.</summary>
        /// <value>The state normal short text colour one.</value>
        [Category("Appearance"), Description("The first short text colour.")]
        public Color StateNormalShortTextColourOne { get => _stateNormalShortTextColourOne; set { _stateNormalShortTextColourOne = value; Invalidate(); } }

        /// <summary>Gets or sets the state normal short text colour two.</summary>
        /// <value>The state normal short text colour two.</value>
        [Category("Appearance"), Description("The second short text colour.")]
        public Color StateNormalShortTextColourTwo { get => _stateNormalShortTextColourTwo; set { _stateNormalShortTextColourTwo = value; Invalidate(); } }
        #endregion

        #region Globals
        /// <summary>Gets or sets the long text typeface.</summary>
        /// <value>The long text typeface.</value>
        [Category("Appearance"), Description("The 'Long Text' typeface.")]
        public Font LongTextTypeface { get => _longTextTypeface; set { _longTextTypeface = value; Invalidate(); } }

        /// <summary>Gets or sets the short text typeface.</summary>
        /// <value>The short text typeface.</value>
        [Category("Appearance"), Description("The 'Short Text' typeface.")]
        public Font ShortTextTypeface { get => _shortTextTypeface; set { _shortTextTypeface = value; Invalidate(); } }

        /// <summary>Gets or sets the image.</summary>
        /// <value>The image.</value>
        [Category("Appearance"), Description("The chosen image.")]
        public Image Image { get => _image; set { _image = value; Invalidate(); } }
        #endregion

        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="KryptonCheckBoxExtended"/> class.</summary>
        public KryptonCheckBoxExtended()
        {
            #region Override Focus
            OverrideFocusLongTextColourOne = Color.Empty;

            OverrideFocusLongTextColourTwo = Color.Empty;

            OverrideFocusShortTextColourOne = Color.Empty;

            OverrideFocusShortTextColourTwo = Color.Empty;
            #endregion

            #region State Common
            StateCommonLongTextColourOne = Color.Empty;

            StateCommonLongTextColourTwo = Color.Empty;

            StateCommonShortTextColourOne = Color.Empty;

            StateCommonShortTextColourTwo = Color.Empty;
            #endregion

            #region State Disabled
            StateDisabledLongTextColourOne = Color.Empty;

            StateDisabledLongTextColourTwo = Color.Empty;

            StateDisabledShortTextColourOne = Color.Empty;

            StateDisabledShortTextColourTwo = Color.Empty;
            #endregion

            #region State Normal
            StateNormalLongTextColourOne = Color.Empty;

            StateNormalLongTextColourTwo = Color.Empty;

            StateNormalShortTextColourOne = Color.Empty;

            StateNormalShortTextColourTwo = Color.Empty;
            #endregion

            LongTextTypeface = Typeface.DefaultTypeface();

            ShortTextTypeface = Typeface.DefaultTypeface();

            Image = null;

            UpdateOverrideFocusAppearanceValues(OverrideFocusLongTextColourOne, OverrideFocusLongTextColourTwo, LongTextTypeface, OverrideFocusShortTextColourOne, OverrideFocusShortTextColourTwo, ShortTextTypeface, Image);

            UpdateStateCommonAppearanceValues(StateCommonLongTextColourOne, StateCommonLongTextColourTwo, LongTextTypeface, StateCommonShortTextColourOne, StateCommonShortTextColourTwo, ShortTextTypeface, Image);

            UpdateStateDisabledAppearanceValues(StateDisabledLongTextColourOne, StateDisabledLongTextColourTwo, LongTextTypeface, StateDisabledShortTextColourOne, StateDisabledShortTextColourTwo, ShortTextTypeface, Image);

            UpdateStateNormalAppearanceValues(StateNormalLongTextColourOne, StateNormalLongTextColourTwo, LongTextTypeface, StateNormalShortTextColourOne, StateNormalShortTextColourTwo, ShortTextTypeface, Image);
        }
        #endregion

        #region Method
        private void UpdateOverrideFocusAppearanceValues(Color longTextColourOne, Color longTextColourTwo, Font longTextTypeface, Color shortTextColourOne, Color shortTextColourTwo, Font shortTextTypeface, Image image)
        {
            OverrideFocus.LongText.Color1 = longTextColourOne;

            OverrideFocus.LongText.Color2 = longTextColourTwo;

            OverrideFocus.LongText.Font = longTextTypeface;

            OverrideFocus.LongText.Image = image;

            OverrideFocus.ShortText.Color1 = shortTextColourOne;

            OverrideFocus.ShortText.Color2 = shortTextColourTwo;

            OverrideFocus.ShortText.Font = shortTextTypeface;

            OverrideFocus.ShortText.Image = image;
        }

        private void UpdateStateCommonAppearanceValues(Color longTextColourOne, Color longTextColourTwo, Font longTextTypeface, Color shortTextColourOne, Color shortTextColourTwo, Font shortTextTypeface, Image image)
        {
            StateCommon.LongText.Color1 = longTextColourOne;

            StateCommon.LongText.Color2 = longTextColourTwo;

            StateCommon.LongText.Font = longTextTypeface;

            StateCommon.LongText.Image = image;

            StateCommon.ShortText.Color1 = shortTextColourOne;

            StateCommon.ShortText.Color2 = shortTextColourTwo;

            StateCommon.ShortText.Font = shortTextTypeface;

            StateCommon.ShortText.Image = image;
        }

        private void UpdateStateDisabledAppearanceValues(Color longTextColourOne, Color longTextColourTwo, Font longTextTypeface, Color shortTextColourOne, Color shortTextColourTwo, Font shortTextTypeface, Image image)
        {
            StateDisabled.LongText.Color1 = longTextColourOne;

            StateDisabled.LongText.Color2 = longTextColourTwo;

            StateDisabled.LongText.Font = longTextTypeface;

            StateDisabled.LongText.Image = image;

            StateDisabled.ShortText.Color1 = shortTextColourOne;

            StateDisabled.ShortText.Color2 = shortTextColourTwo;

            StateDisabled.ShortText.Font = shortTextTypeface;

            StateDisabled.ShortText.Image = image;
        }

        private void UpdateStateNormalAppearanceValues(Color longTextColourOne, Color longTextColourTwo, Font longTextTypeface, Color shortTextColourOne, Color shortTextColourTwo, Font shortTextTypeface, Image image)
        {
            StateNormal.LongText.Color1 = longTextColourOne;

            StateNormal.LongText.Color2 = longTextColourTwo;

            StateNormal.LongText.Font = longTextTypeface;

            StateNormal.LongText.Image = image;

            StateNormal.ShortText.Color1 = shortTextColourOne;

            StateNormal.ShortText.Color2 = shortTextColourTwo;

            StateNormal.ShortText.Font = shortTextTypeface;

            StateNormal.ShortText.Image = image;
        }
        #endregion

        #region Override
        /// <summary>Raises the Paint event.</summary>
        /// <param name="e">A PaintEventArgs that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateOverrideFocusAppearanceValues(OverrideFocusLongTextColourOne, OverrideFocusLongTextColourTwo, LongTextTypeface, OverrideFocusShortTextColourOne, OverrideFocusShortTextColourTwo, ShortTextTypeface, Image);

            UpdateStateCommonAppearanceValues(StateCommonLongTextColourOne, StateCommonLongTextColourTwo, LongTextTypeface, StateCommonShortTextColourOne, StateCommonShortTextColourTwo, ShortTextTypeface, Image);

            UpdateStateDisabledAppearanceValues(StateDisabledLongTextColourOne, StateDisabledLongTextColourTwo, LongTextTypeface, StateDisabledShortTextColourOne, StateDisabledShortTextColourTwo, ShortTextTypeface, Image);

            UpdateStateNormalAppearanceValues(StateNormalLongTextColourOne, StateNormalLongTextColourTwo, LongTextTypeface, StateNormalShortTextColourOne, StateNormalShortTextColourTwo, ShortTextTypeface, Image);

            base.OnPaint(e);
        }
        #endregion
    }
}