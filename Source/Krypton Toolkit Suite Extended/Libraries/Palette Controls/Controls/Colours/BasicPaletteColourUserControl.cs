using Krypton.Toolkit.Extended.Base;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Palette.Controls
{
    public class BasicPaletteColourUserControl : UserControl
    {
        #region Designer Code
        private Standard.Controls.KryptonLabelExtended klblBaseColour;
        private Standard.Controls.KryptonLabelExtended klblDarkestColour;
        private Standard.Controls.KryptonLabelExtended klblMediumColour;
        private Standard.Controls.KryptonLabelExtended klblDarkColour;
        private Standard.Controls.KryptonLabelExtended klblLightestColour;
        private Standard.Controls.KryptonLabelExtended klblLightColour;
        private Toolkit.Extended.Base.CircularPictureBox cbxBaseColour;
        private Toolkit.Extended.Base.CircularPictureBox cbxMediumColour;
        private Toolkit.Extended.Base.CircularPictureBox cbxLightColour;
        private Toolkit.Extended.Base.CircularPictureBox cbxDarkColour;
        private Toolkit.Extended.Base.CircularPictureBox cbxDarkestColour;
        private Toolkit.Extended.Base.CircularPictureBox cbxLightestColour;

        private void InitializeComponent()
        {
            this.klblBaseColour = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.klblDarkestColour = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.klblMediumColour = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.klblDarkColour = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.klblLightestColour = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.klblLightColour = new Krypton.Toolkit.Suite.Extended.Standard.Controls.KryptonLabelExtended();
            this.cbxBaseColour = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.cbxMediumColour = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.cbxLightColour = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.cbxDarkColour = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.cbxDarkestColour = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.cbxLightestColour = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cbxBaseColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxMediumColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxLightColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDarkColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDarkestColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxLightestColour)).BeginInit();
            this.SuspendLayout();
            // 
            // klblBaseColour
            // 
            this.klblBaseColour.Image = null;
            this.klblBaseColour.Location = new System.Drawing.Point(25, 14);
            this.klblBaseColour.LongTextTypeface = null;
            this.klblBaseColour.Name = "klblBaseColour";
            this.klblBaseColour.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBaseColour.Size = new System.Drawing.Size(100, 21);
            this.klblBaseColour.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBaseColour.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblBaseColour.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblBaseColour.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBaseColour.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblBaseColour.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblBaseColour.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblBaseColour.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblBaseColour.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klblBaseColour.TabIndex = 0;
            this.klblBaseColour.Values.Text = "Base Colour";
            // 
            // klblDarkestColour
            // 
            this.klblDarkestColour.Image = null;
            this.klblDarkestColour.Location = new System.Drawing.Point(16, 102);
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
            this.klblDarkestColour.TabIndex = 1;
            this.klblDarkestColour.Values.Text = "Darkest Colour";
            // 
            // klblMediumColour
            // 
            this.klblMediumColour.Image = null;
            this.klblMediumColour.Location = new System.Drawing.Point(20, 278);
            this.klblMediumColour.LongTextTypeface = null;
            this.klblMediumColour.Name = "klblMediumColour";
            this.klblMediumColour.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMediumColour.Size = new System.Drawing.Size(111, 21);
            this.klblMediumColour.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMediumColour.StateCommonTextColourOne = System.Drawing.Color.Empty;
            this.klblMediumColour.StateCommonTextColourTwo = System.Drawing.Color.Empty;
            this.klblMediumColour.StateDisabled.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMediumColour.StateDisabledTextColourOne = System.Drawing.Color.Empty;
            this.klblMediumColour.StateDisabledTextColourTwo = System.Drawing.Color.Empty;
            this.klblMediumColour.StateNormal.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMediumColour.StateNormalTextColourOne = System.Drawing.Color.Empty;
            this.klblMediumColour.StateNormalTextColourTwo = System.Drawing.Color.Empty;
            this.klblMediumColour.TabIndex = 2;
            this.klblMediumColour.Values.Text = "Middle Colour";
            // 
            // klblDarkColour
            // 
            this.klblDarkColour.Image = null;
            this.klblDarkColour.Location = new System.Drawing.Point(27, 190);
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
            this.klblDarkColour.TabIndex = 3;
            this.klblDarkColour.Values.Text = "Dark Colour";
            // 
            // klblLightestColour
            // 
            this.klblLightestColour.Image = null;
            this.klblLightestColour.Location = new System.Drawing.Point(15, 454);
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
            this.klblLightestColour.TabIndex = 4;
            this.klblLightestColour.Values.Text = "Lightest Colour";
            // 
            // klblLightColour
            // 
            this.klblLightColour.Image = null;
            this.klblLightColour.Location = new System.Drawing.Point(26, 366);
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
            this.klblLightColour.TabIndex = 5;
            this.klblLightColour.Values.Text = "Light Colour";
            // 
            // cbxBaseColour
            // 
            this.cbxBaseColour.BackColor = System.Drawing.Color.White;
            this.cbxBaseColour.Location = new System.Drawing.Point(50, 41);
            this.cbxBaseColour.Name = "cbxBaseColour";
            this.cbxBaseColour.Size = new System.Drawing.Size(55, 55);
            this.cbxBaseColour.TabIndex = 6;
            this.cbxBaseColour.TabStop = false;
            this.cbxBaseColour.ToolTipValues = null;
            // 
            // cbxMediumColour
            // 
            this.cbxMediumColour.BackColor = System.Drawing.Color.White;
            this.cbxMediumColour.Location = new System.Drawing.Point(50, 305);
            this.cbxMediumColour.Name = "cbxMediumColour";
            this.cbxMediumColour.Size = new System.Drawing.Size(55, 55);
            this.cbxMediumColour.TabIndex = 7;
            this.cbxMediumColour.TabStop = false;
            this.cbxMediumColour.ToolTipValues = null;
            // 
            // cbxLightColour
            // 
            this.cbxLightColour.BackColor = System.Drawing.Color.White;
            this.cbxLightColour.Location = new System.Drawing.Point(50, 393);
            this.cbxLightColour.Name = "cbxLightColour";
            this.cbxLightColour.Size = new System.Drawing.Size(55, 55);
            this.cbxLightColour.TabIndex = 8;
            this.cbxLightColour.TabStop = false;
            this.cbxLightColour.ToolTipValues = null;
            // 
            // cbxDarkColour
            // 
            this.cbxDarkColour.BackColor = System.Drawing.Color.White;
            this.cbxDarkColour.Location = new System.Drawing.Point(50, 217);
            this.cbxDarkColour.Name = "cbxDarkColour";
            this.cbxDarkColour.Size = new System.Drawing.Size(55, 55);
            this.cbxDarkColour.TabIndex = 9;
            this.cbxDarkColour.TabStop = false;
            this.cbxDarkColour.ToolTipValues = null;
            // 
            // cbxDarkestColour
            // 
            this.cbxDarkestColour.BackColor = System.Drawing.Color.White;
            this.cbxDarkestColour.Location = new System.Drawing.Point(50, 129);
            this.cbxDarkestColour.Name = "cbxDarkestColour";
            this.cbxDarkestColour.Size = new System.Drawing.Size(55, 55);
            this.cbxDarkestColour.TabIndex = 10;
            this.cbxDarkestColour.TabStop = false;
            this.cbxDarkestColour.ToolTipValues = null;
            // 
            // cbxLightestColour
            // 
            this.cbxLightestColour.BackColor = System.Drawing.Color.White;
            this.cbxLightestColour.Location = new System.Drawing.Point(50, 481);
            this.cbxLightestColour.Name = "cbxLightestColour";
            this.cbxLightestColour.Size = new System.Drawing.Size(55, 55);
            this.cbxLightestColour.TabIndex = 11;
            this.cbxLightestColour.TabStop = false;
            this.cbxLightestColour.ToolTipValues = null;
            // 
            // BasicPaletteColourUserControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cbxLightestColour);
            this.Controls.Add(this.cbxDarkestColour);
            this.Controls.Add(this.cbxDarkColour);
            this.Controls.Add(this.cbxLightColour);
            this.Controls.Add(this.cbxMediumColour);
            this.Controls.Add(this.cbxBaseColour);
            this.Controls.Add(this.klblLightColour);
            this.Controls.Add(this.klblLightestColour);
            this.Controls.Add(this.klblDarkColour);
            this.Controls.Add(this.klblMediumColour);
            this.Controls.Add(this.klblDarkestColour);
            this.Controls.Add(this.klblBaseColour);
            this.Name = "BasicPaletteColourUserControl";
            this.Size = new System.Drawing.Size(149, 545);
            ((System.ComponentModel.ISupportInitialize)(this.cbxBaseColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxMediumColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxLightColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDarkColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxDarkestColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxLightestColour)).EndInit();
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

        #region Constructor
        public BasicPaletteColourUserControl()
        {
            InitializeComponent();

            // Fill array
            ColourBoxes[0] = cbxBaseColour;

            ColourBoxes[1] = cbxDarkestColour;

            ColourBoxes[2] = cbxDarkColour;

            ColourBoxes[3] = cbxMediumColour;

            ColourBoxes[4] = cbxLightColour;

            ColourBoxes[5] = cbxLightestColour;
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
            if (_defaultColour != Color.Empty || _defaultColour != Color.Transparent)
            {
                ResetColours();
            }

            base.OnPaint(e);
        }
        #endregion
    }
}