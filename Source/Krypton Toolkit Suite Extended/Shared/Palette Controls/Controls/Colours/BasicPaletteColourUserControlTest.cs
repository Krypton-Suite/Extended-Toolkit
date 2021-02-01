#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Palette.Controls
{
    /*
    public class BasicPaletteColourUserControlTest : UserControl
    {
        #region Designer Code
        private Toolkit.Extended.Palette.Controls.PaletteColourPreviewControl baseColour;
        private Toolkit.Extended.Palette.Controls.PaletteColourPreviewControl darkestColour;
        private Toolkit.Extended.Palette.Controls.PaletteColourPreviewControl darkColour;
        private Toolkit.Extended.Palette.Controls.PaletteColourPreviewControl lightestColour;
        private Toolkit.Extended.Palette.Controls.PaletteColourPreviewControl lightColour;
        private Toolkit.Extended.Palette.Controls.PaletteColourPreviewControl mediumColour;

        private void InitializeComponent()
        {
            this.mediumColour = new Krypton.Toolkit.Extended.Palette.Controls.PaletteColourPreviewControl();
            this.lightColour = new Krypton.Toolkit.Extended.Palette.Controls.PaletteColourPreviewControl();
            this.lightestColour = new Krypton.Toolkit.Extended.Palette.Controls.PaletteColourPreviewControl();
            this.darkColour = new Krypton.Toolkit.Extended.Palette.Controls.PaletteColourPreviewControl();
            this.darkestColour = new Krypton.Toolkit.Extended.Palette.Controls.PaletteColourPreviewControl();
            this.baseColour = new Krypton.Toolkit.Extended.Palette.Controls.PaletteColourPreviewControl();
            this.SuspendLayout();
            // 
            // mediumColour
            // 
            this.mediumColour.BackColor = System.Drawing.Color.Transparent;
            this.mediumColour.Colour = System.Drawing.Color.Empty;
            this.mediumColour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediumColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediumColour.HeaderText = "Medium Colour";
            this.mediumColour.Location = new System.Drawing.Point(0, 270);
            this.mediumColour.Name = "mediumColour";
            this.mediumColour.Size = new System.Drawing.Size(149, 95);
            this.mediumColour.TabIndex = 5;
            // 
            // lightColour
            // 
            this.lightColour.BackColor = System.Drawing.Color.Transparent;
            this.lightColour.Colour = System.Drawing.Color.Empty;
            this.lightColour.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lightColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lightColour.HeaderText = "Light Colour";
            this.lightColour.Location = new System.Drawing.Point(0, 365);
            this.lightColour.Name = "lightColour";
            this.lightColour.Size = new System.Drawing.Size(149, 90);
            this.lightColour.TabIndex = 4;
            // 
            // lightestColour
            // 
            this.lightestColour.BackColor = System.Drawing.Color.Transparent;
            this.lightestColour.Colour = System.Drawing.Color.Empty;
            this.lightestColour.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lightestColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lightestColour.HeaderText = "Lightest Colour";
            this.lightestColour.Location = new System.Drawing.Point(0, 455);
            this.lightestColour.Name = "lightestColour";
            this.lightestColour.Size = new System.Drawing.Size(149, 90);
            this.lightestColour.TabIndex = 3;
            // 
            // darkColour
            // 
            this.darkColour.BackColor = System.Drawing.Color.Transparent;
            this.darkColour.Colour = System.Drawing.Color.Empty;
            this.darkColour.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkColour.HeaderText = "Dark Colour";
            this.darkColour.Location = new System.Drawing.Point(0, 180);
            this.darkColour.Name = "darkColour";
            this.darkColour.Size = new System.Drawing.Size(149, 90);
            this.darkColour.TabIndex = 2;
            // 
            // darkestColour
            // 
            this.darkestColour.BackColor = System.Drawing.Color.Transparent;
            this.darkestColour.Colour = System.Drawing.Color.Empty;
            this.darkestColour.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkestColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkestColour.HeaderText = "Darkest Colour";
            this.darkestColour.Location = new System.Drawing.Point(0, 90);
            this.darkestColour.Name = "darkestColour";
            this.darkestColour.Size = new System.Drawing.Size(149, 90);
            this.darkestColour.TabIndex = 1;
            // 
            // baseColour
            // 
            this.baseColour.BackColor = System.Drawing.Color.Transparent;
            this.baseColour.Colour = System.Drawing.Color.Empty;
            this.baseColour.Dock = System.Windows.Forms.DockStyle.Top;
            this.baseColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseColour.HeaderText = "Base Colour";
            this.baseColour.ImeMode = System.Windows.Forms.ImeMode.On;
            this.baseColour.Location = new System.Drawing.Point(0, 0);
            this.baseColour.Name = "baseColour";
            this.baseColour.Size = new System.Drawing.Size(149, 90);
            this.baseColour.TabIndex = 0;
            // 
            // BasicPaletteColourUserControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.mediumColour);
            this.Controls.Add(this.lightColour);
            this.Controls.Add(this.lightestColour);
            this.Controls.Add(this.darkColour);
            this.Controls.Add(this.darkestColour);
            this.Controls.Add(this.baseColour);
            this.Name = "BasicPaletteColourUserControl";
            this.Size = new System.Drawing.Size(149, 545);
            this.ResumeLayout(false);

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
        public BasicPaletteColourUserControlTest()
        {
            InitializeComponent();

            // Fill array
            ColourBoxes[0] = baseColour.ColourPreviewBox;

            ColourBoxes[1] = darkestColour.ColourPreviewBox;

            ColourBoxes[2] = darkColour.ColourPreviewBox;

            ColourBoxes[3] = mediumColour.ColourPreviewBox;

            ColourBoxes[4] = lightColour.ColourPreviewBox;

            ColourBoxes[5] = lightestColour.ColourPreviewBox;
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

            if (ColourBoxes.Length > 0)
            {
                ColourBoxes[0].BackColor = _baseColour;

                ColourBoxes[1].BackColor = _darkestColour;

                ColourBoxes[2].BackColor = _darkColour;

                ColourBoxes[3].BackColor = _mediumColour;

                ColourBoxes[4].BackColor = _lightColour;

                ColourBoxes[5].BackColor = _lightestColour;
            }

            base.OnPaint(e);
        }
        #endregion
    }
    */
}