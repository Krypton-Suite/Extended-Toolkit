#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    [ToolboxBitmap(typeof(PropertyGrid), "ToolboxBitmaps.PropertyGridVersionTwo.bmp")]
    public class KryptonPropertyGrid : PropertyGrid
    {
        #region Variables
        private IPalette _palette;

        private PaletteRedirect _paletteRedirect;

        private Color _gradientMiddleColour = Color.Gray;
        #endregion

        #region Properties
        /// <summary>Gets or sets the gradient middle colour.</summary>
        /// <value>The gradient middle colour.</value>
        [Browsable(true), Category("Appearance-Extended"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DefaultValue("Color.Gray")]
        public Color GradientMiddleColour { get => _gradientMiddleColour; set { _gradientMiddleColour = value; Invalidate(); } }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="KryptonPropertyGrid" /> class.</summary>
        public KryptonPropertyGrid()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            UpdateStyles();

            // Add Palette Handler
            if (_palette != null)
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
            }

            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);

            _palette = KryptonManager.CurrentGlobalPalette;

            _paletteRedirect = new PaletteRedirect(_palette);

            InitColours();


        }
        #endregion

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.Paint">Paint</see> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs">PaintEventArgs</see> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(new SolidBrush(_gradientMiddleColour), e.ClipRectangle);
        }

        /// <summary>Paints the background of the control.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs">PaintEventArgs</see> that contains the event data.</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            //e.Graphics.FillRectangle(new SolidBrush(_gradientMiddleColor), e.ClipRectangle);
        }

        #region Krypton
        // Krypton Palette Events
        /// <summary>Called when [global palette changed].</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (_palette != null)
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;

            if (_palette != null)
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                //repaint with new values

                InitColours();

            }

            Invalidate();
        }

        // Krypton Palette Events
        /// <summary>Called when [palette paint].</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PaletteLayoutEventArgs" /> instance containing the event data.</param>
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e) => Invalidate();

        /// <summary>Initialises the colours.</summary>
        private void InitColours()
        {
            ToolStripRenderer = ToolStripManager.Renderer;

            _gradientMiddleColour = _palette.ColorTable.ToolStripGradientMiddle;

            HelpBackColor = _palette.ColorTable.MenuStripGradientBegin;

            HelpForeColor = _palette.ColorTable.StatusStripText;

            LineColor = _palette.ColorTable.ToolStripGradientMiddle;

            CategoryForeColor = _palette.ColorTable.StatusStripText;
        }
        #endregion
    }
}