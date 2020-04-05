using Krypton.Toolkit.Extended.Common;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Krypton.Toolkit.Extended.Base
{
    [ToolboxBitmap(typeof(ProgressBar)), ToolboxItem(true), ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class KryptonProgressBar : ProgressBarControl
    {
        #region Variables
        private Color _foreColour = Color.Empty;

        private IPalette _palette;

        private PaletteRedirect _paletteRedirect;
        #endregion

        #region Properties
        public Color ForeColour { get => _foreColour; set { _foreColour = value; Invalidate(); } }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="KryptonProgressBar"/> class.</summary>
        public KryptonProgressBar()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            UpdateStyles();

            if (_palette != null) _palette.PalettePaint += OnPalettePaint;

            KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;

            _palette = KryptonManager.CurrentGlobalPalette;

            _paletteRedirect = new PaletteRedirect(_palette);

            InitialiseColours();
        }
        #endregion

        #region Methods
        /// <summary>Initialises the colours.</summary>
        private void InitialiseColours()
        {
            StartColour = _palette.ColorTable.ButtonSelectedGradientEnd;

            EndColour = _palette.ColorTable.ButtonSelectedGradientEnd;

            if (ForeColour != Color.Empty || ForeColour != Color.Transparent)
            {
                ForeColor = ForeColour;
            }
            else
            {
                ForeColor = _palette.ColorTable.MenuItemText;
            }

            Font = _palette.ColorTable.MenuStripFont;
        }
        #endregion

        #region Events
        /// <summary>Called when [global palette changed].</summary>
        /// <param name="senders">The senders.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnGlobalPaletteChanged(object senders, EventArgs e)
        {
            if (_palette != null) _palette.PalettePaint -= OnPalettePaint;

            _palette = KryptonManager.CurrentGlobalPalette;

            _paletteRedirect.Target = _palette;

            if (_palette != null)
            {
                _palette.PalettePaint += OnPalettePaint;

                InitialiseColours();
            }
        }

        /// <summary>Called when [palette paint].</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PaletteLayoutEventArgs"/> instance containing the event data.</param>
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }
        #endregion
    }
}