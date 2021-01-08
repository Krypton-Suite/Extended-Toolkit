using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    [ToolboxBitmap(typeof(ListView))]
    public class KryptonListView : ListView
    {
        #region Constants
        private const int MINIMUM_ITEM_HEIGHT = 18;
        #endregion

        #region Variables
        private bool _hasFocus = false;

        private Color _originalForeColour;

        private Font _originalTypeface;

        #region Krypton
        private IPalette _palette;

        private PaletteRedirect _paletteRedirect;

        private PaletteBackInheritRedirect _paletteBack;

        private PaletteBorderInheritRedirect _paletteBorder;

        private PaletteContentInheritRedirect _paletteContent;

        private IDisposable _momentoContent, _momentoBack1, _momentoBack2;
        #endregion

        #region Designer
        private IContainer components;

        private ImageList ilCheckBoxes, ilHeight;
        #endregion

        #endregion
    }
}