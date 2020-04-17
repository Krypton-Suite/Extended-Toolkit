using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    public class KryptonFadePanel : Control
    {
        #region Variables
        private int _fadeValue = 0;

        private float _fadeTime;

        private KryptonManager _manager = new KryptonManager();

        private PaletteBackInheritRedirect _paletteBack;

        private PaletteBorderInheritRedirect _paletteBorder;

        private PaletteContentInheritRedirect _paletteContent;

        private IPalette _palette;

        private PaletteRedirect _paletteRedirect;
        #endregion
    }
}