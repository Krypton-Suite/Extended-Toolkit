using Krypton.Toolkit.Extended.Base;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Palette.Controls
{
    public class BasicPaletteColourUserControl : UserControl
    {
        #region Design Code
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klblBasicColour;
        private Base.CircularPictureBox cpbBaseColour;
        private Base.CircularPictureBox cpbDarkestColour;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klblDarkestColour;
        private Base.CircularPictureBox cpbDarkColour;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klblDarkColour;
        private Base.CircularPictureBox cpbMediumColour;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klblMediumColour;
        private Base.CircularPictureBox cpbLightColour;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klblLightColour;
        private Base.CircularPictureBox cpbLightestColour;
        private Suite.Extended.Standard.Controls.KryptonLabelExtended klblLightestColour;

        private void InitializeComponent()
        {
            this.klblBasicColour = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.cpbBaseColour = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.cpbDarkestColour = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.klblDarkestColour = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.cpbDarkColour = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.klblDarkColour = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.cpbMediumColour = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.klblMediumColour = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.cpbLightColour = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.klblLightColour = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.cpbLightestColour = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.klblLightestColour = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            ((System.ComponentModel.ISupportInitialize)(this.cpbBaseColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbDarkestColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbDarkColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbMediumColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbLightColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbLightestColour)).BeginInit();
            this.SuspendLayout();
            // 
            // klblBasicColour
            // 
            this.klblBasicColour.Image = null;
            this.klblBasicColour.Location = new System.Drawing.Point(19, 12);
            this.klblBasicColour.LongTextTypeface = null;
            this.klblBasicColour.Name = "klblBasicColour";
            this.klblBasicColour.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBasicColour.Size = new System.Drawing.Size(102, 21);
            this.klblBasicColour.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBasicColour.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblBasicColour.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblBasicColour.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBasicColour.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblBasicColour.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblBasicColour.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBasicColour.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblBasicColour.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klblBasicColour.TabIndex = 0;
            this.klblBasicColour.Values.Text = "Basic Colour";
            // 
            // cpbBaseColour
            // 
            this.cpbBaseColour.BackColor = System.Drawing.Color.White;
            this.cpbBaseColour.Location = new System.Drawing.Point(47, 39);
            this.cpbBaseColour.Name = "cpbBaseColour";
            this.cpbBaseColour.Size = new System.Drawing.Size(55, 55);
            this.cpbBaseColour.TabIndex = 1;
            this.cpbBaseColour.TabStop = false;
            this.cpbBaseColour.ToolTipValues = null;
            // 
            // cpbDarkestColour
            // 
            this.cpbDarkestColour.BackColor = System.Drawing.Color.White;
            this.cpbDarkestColour.Location = new System.Drawing.Point(47, 127);
            this.cpbDarkestColour.Name = "cpbDarkestColour";
            this.cpbDarkestColour.Size = new System.Drawing.Size(55, 55);
            this.cpbDarkestColour.TabIndex = 3;
            this.cpbDarkestColour.TabStop = false;
            this.cpbDarkestColour.ToolTipValues = null;
            // 
            // klblDarkestColour
            // 
            this.klblDarkestColour.Image = null;
            this.klblDarkestColour.Location = new System.Drawing.Point(11, 100);
            this.klblDarkestColour.LongTextTypeface = null;
            this.klblDarkestColour.Name = "klblDarkestColour";
            this.klblDarkestColour.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblDarkestColour.Size = new System.Drawing.Size(118, 21);
            this.klblDarkestColour.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblDarkestColour.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblDarkestColour.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblDarkestColour.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblDarkestColour.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblDarkestColour.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblDarkestColour.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblDarkestColour.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblDarkestColour.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klblDarkestColour.TabIndex = 2;
            this.klblDarkestColour.Values.Text = "Darkest Colour";
            // 
            // cpbDarkColour
            // 
            this.cpbDarkColour.BackColor = System.Drawing.Color.White;
            this.cpbDarkColour.Location = new System.Drawing.Point(47, 215);
            this.cpbDarkColour.Name = "cpbDarkColour";
            this.cpbDarkColour.Size = new System.Drawing.Size(55, 55);
            this.cpbDarkColour.TabIndex = 5;
            this.cpbDarkColour.TabStop = false;
            this.cpbDarkColour.ToolTipValues = null;
            // 
            // klblDarkColour
            // 
            this.klblDarkColour.Image = null;
            this.klblDarkColour.Location = new System.Drawing.Point(22, 188);
            this.klblDarkColour.LongTextTypeface = null;
            this.klblDarkColour.Name = "klblDarkColour";
            this.klblDarkColour.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblDarkColour.Size = new System.Drawing.Size(97, 21);
            this.klblDarkColour.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblDarkColour.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblDarkColour.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblDarkColour.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblDarkColour.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblDarkColour.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblDarkColour.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblDarkColour.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblDarkColour.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klblDarkColour.TabIndex = 4;
            this.klblDarkColour.Values.Text = "Dark Colour";
            // 
            // cpbMediumColour
            // 
            this.cpbMediumColour.BackColor = System.Drawing.Color.White;
            this.cpbMediumColour.Location = new System.Drawing.Point(47, 303);
            this.cpbMediumColour.Name = "cpbMediumColour";
            this.cpbMediumColour.Size = new System.Drawing.Size(55, 55);
            this.cpbMediumColour.TabIndex = 7;
            this.cpbMediumColour.TabStop = false;
            this.cpbMediumColour.ToolTipValues = null;
            // 
            // klblMediumColour
            // 
            this.klblMediumColour.Image = null;
            this.klblMediumColour.Location = new System.Drawing.Point(10, 276);
            this.klblMediumColour.LongTextTypeface = null;
            this.klblMediumColour.Name = "klblMediumColour";
            this.klblMediumColour.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMediumColour.Size = new System.Drawing.Size(120, 21);
            this.klblMediumColour.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMediumColour.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblMediumColour.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblMediumColour.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMediumColour.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblMediumColour.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblMediumColour.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMediumColour.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblMediumColour.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klblMediumColour.TabIndex = 6;
            this.klblMediumColour.Values.Text = "Medium Colour";
            // 
            // cpbLightColour
            // 
            this.cpbLightColour.BackColor = System.Drawing.Color.White;
            this.cpbLightColour.Location = new System.Drawing.Point(47, 391);
            this.cpbLightColour.Name = "cpbLightColour";
            this.cpbLightColour.Size = new System.Drawing.Size(55, 55);
            this.cpbLightColour.TabIndex = 9;
            this.cpbLightColour.TabStop = false;
            this.cpbLightColour.ToolTipValues = null;
            // 
            // klblLightColour
            // 
            this.klblLightColour.Image = null;
            this.klblLightColour.Location = new System.Drawing.Point(21, 364);
            this.klblLightColour.LongTextTypeface = null;
            this.klblLightColour.Name = "klblLightColour";
            this.klblLightColour.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblLightColour.Size = new System.Drawing.Size(98, 21);
            this.klblLightColour.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblLightColour.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblLightColour.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblLightColour.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblLightColour.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblLightColour.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblLightColour.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblLightColour.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblLightColour.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klblLightColour.TabIndex = 8;
            this.klblLightColour.Values.Text = "Light Colour";
            // 
            // cpbLightestColour
            // 
            this.cpbLightestColour.BackColor = System.Drawing.Color.White;
            this.cpbLightestColour.Location = new System.Drawing.Point(47, 479);
            this.cpbLightestColour.Name = "cpbLightestColour";
            this.cpbLightestColour.Size = new System.Drawing.Size(55, 55);
            this.cpbLightestColour.TabIndex = 11;
            this.cpbLightestColour.TabStop = false;
            this.cpbLightestColour.ToolTipValues = null;
            // 
            // klblLightestColour
            // 
            this.klblLightestColour.Image = null;
            this.klblLightestColour.Location = new System.Drawing.Point(10, 452);
            this.klblLightestColour.LongTextTypeface = null;
            this.klblLightestColour.Name = "klblLightestColour";
            this.klblLightestColour.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblLightestColour.Size = new System.Drawing.Size(120, 21);
            this.klblLightestColour.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblLightestColour.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblLightestColour.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblLightestColour.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblLightestColour.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblLightestColour.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblLightestColour.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblLightestColour.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblLightestColour.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klblLightestColour.TabIndex = 10;
            this.klblLightestColour.Values.Text = "Lightest Colour";
            // 
            // BasicPaletteColourUserControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cpbLightestColour);
            this.Controls.Add(this.klblLightestColour);
            this.Controls.Add(this.cpbLightColour);
            this.Controls.Add(this.klblLightColour);
            this.Controls.Add(this.cpbMediumColour);
            this.Controls.Add(this.klblMediumColour);
            this.Controls.Add(this.cpbDarkColour);
            this.Controls.Add(this.klblDarkColour);
            this.Controls.Add(this.cpbDarkestColour);
            this.Controls.Add(this.klblDarkestColour);
            this.Controls.Add(this.cpbBaseColour);
            this.Controls.Add(this.klblBasicColour);
            this.Name = "BasicPaletteColourUserControl";
            this.Size = new System.Drawing.Size(149, 545);
            ((System.ComponentModel.ISupportInitialize)(this.cpbBaseColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbDarkestColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbDarkColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbMediumColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbLightColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbLightestColour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Variables
        private bool _automaticallyUpdateColourValues;

        private Color _defaultColour, _baseColour, _darkestColour, _darkColour, _mediumColour, _lightColour, _lightestColour;

        private Color[] _basicPaletteColours = new Color[6];

        private CircularPictureBox[] _colourBoxes = new CircularPictureBox[6];
        #endregion

        #region Properties
        [DefaultValue(true)]
        public bool AutomaticallyUpdateColourValues { get => _automaticallyUpdateColourValues; set { _automaticallyUpdateColourValues = value; Invalidate(); } }

        [DefaultValue(null)]
        public Color DefaultColour { get => _defaultColour; set { _defaultColour = value; Invalidate(); } }

        public Color BaseColour { get => _baseColour; set { _baseColour = value; Invalidate(); } }

        public Color DarkestColour { get => _darkestColour; set { _darkestColour = value; Invalidate(); } }

        public Color DarkColour { get => _darkColour; set { _darkColour = value; Invalidate(); } }

        public Color MediumColour { get => _mediumColour; set { _mediumColour = value; Invalidate(); } }

        public Color LightColour { get => _lightColour; set { _lightColour = value; Invalidate(); } }

        public Color LightestColour { get => _lightestColour; set { _lightestColour = value; Invalidate(); } }

        public Color[] BasicPaletteColours { get => _basicPaletteColours; set { _basicPaletteColours = value; Invalidate(); } }

        public CircularPictureBox[] ColourBoxes { get => _colourBoxes; private set => _colourBoxes = value; }
        #endregion

        #region Constructors
        public BasicPaletteColourUserControl()
        {
            InitializeComponent();

            // Fill array
            ColourBoxes[0] = cpbBaseColour;

            ColourBoxes[1] = cpbDarkestColour;

            ColourBoxes[2] = cpbDarkColour;

            ColourBoxes[3] = cpbMediumColour;

            ColourBoxes[4] = cpbLightColour;

            ColourBoxes[5] = cpbLightestColour;
        }
        #endregion

        #region Methods
        /// <summary>Fills the colour array.</summary>
        /// <param name="baseColour">The base colour.</param>
        /// <param name="darkestColour">The darkest colour.</param>
        /// <param name="darkColour">The dark colour.</param>
        /// <param name="mediumColour">The medium colour.</param>
        /// <param name="lightColour">The light colour.</param>
        /// <param name="lightestColour">The lightest colour.</param>
        private void FillColourArray(Color baseColour, Color darkestColour, Color darkColour, Color mediumColour, Color lightColour, Color lightestColour)
        {
            if (baseColour != Color.Empty || darkestColour != Color.Empty || darkColour != Color.Empty || mediumColour != Color.Empty || lightColour != Color.Empty || lightestColour != Color.Empty)
            {
                BasicPaletteColours[0] = baseColour;

                BasicPaletteColours[1] = darkestColour;

                BasicPaletteColours[2] = darkColour;

                BasicPaletteColours[3] = mediumColour;

                BasicPaletteColours[4] = lightColour;

                BasicPaletteColours[5] = lightestColour;
            }
        }

        private void ResetColours()
        {
            if (_baseColour != Color.Empty || _darkestColour != Color.Empty || _darkColour != Color.Empty || _mediumColour != Color.Empty || _lightColour != Color.Empty || _lightestColour != Color.Empty)
            {
                BaseColour = Color.Empty;

                DarkestColour = Color.Empty;

                DarkColour = Color.Empty;

                MediumColour = Color.Empty;

                LightColour = Color.Empty;

                LightestColour = Color.Empty;

                foreach (CircularPictureBox box in ColourBoxes)
                {
                    box.BackColor = _defaultColour;
                }
            }
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!_automaticallyUpdateColourValues)
            {
                cpbBaseColour.BackColor = _baseColour;

                cpbDarkestColour.BackColor = _darkestColour;

                cpbDarkColour.BackColor = _darkColour;

                cpbMediumColour.BackColor = _mediumColour;

                cpbLightColour.BackColor = _lightColour;

                cpbLightestColour.BackColor = _lightestColour;
            }
            else
            {

            }

            base.OnPaint(e);
        }
        #endregion 
    }
}